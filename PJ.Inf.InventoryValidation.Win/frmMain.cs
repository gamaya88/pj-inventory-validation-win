using AutoMapper;
using MaterialSkin.Controls;
using Microsoft.IdentityModel.Tokens;
using PJ.Inf.InventoryValidation.Win.Model;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Report;
using PJ.Inf.InventoryValidation.Win.Resources;
using PJ.Inf.InventoryValidation.Win.Service;
using PJ.Inf.InventoryValidation.Win.Utils.Enums;
using PJ.Inf.InventoryValidation.Win.Views;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ.Inf.InventoryValidation.Win
{
    public partial class frmMain : MaterialForm
    {
        private MarcaService marcaService;

        private DenominacionBienModeloService denominacionBienModeloService;

        private DefinitionValueService definitionValueService;

        private UsuarioService usuarioService;

        private BienPatrimonialService bienPatrimonialService;

        private ParametroService parametroService;

        private ActaBienPatrimonialService actaBienPatrimonialService;

        private List<DenominacionBienModeloView> denominacionBienModeloViews;

        private List<ValordefinicionView> estadoConservacion;

        private List<ValordefinicionView> color;

        private List<ValordefinicionView> estadoActa;

        private Usuario usuarioDetectado;

        private BienPatrimonialView bienEncontrado = null;

        private IMapper mapper;

        private string emailEnvio = "";

        private string credencialEnvio = "";

        private List<string> correosDestino = new List<string>();

        private List<string> usuariosAdmin = new List<string>();

        private string carpetaSubidaActas = "";

        List<BienPatrimonialReporteView> bienesAListar = new List<BienPatrimonialReporteView>();

        public frmMain()
        {
            InitializeComponent();

            dgvListado.Configurar();
            dgvActas.Configurar();

            ConfigureCombo();

            marcaService = new MarcaService();

            denominacionBienModeloService = new DenominacionBienModeloService();

            definitionValueService = new DefinitionValueService();

            usuarioService = new UsuarioService();

            bienPatrimonialService = new BienPatrimonialService();

            parametroService = new ParametroService();

            actaBienPatrimonialService = new ActaBienPatrimonialService();

            this.SetMaterialSkin();

            groupBox5.Font =
            toolStrip1.Font =
            groupBox1.Font =
            groupBox2.Font =
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            mapper = MappingProfile.GetInstance();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            usuarioDetectado = await usuarioService.Get();

            if (usuarioDetectado == null)
            {
                MaterialDialog materialDialog = new MaterialDialog(this, "Mensaje", $"Usuario {UtilService.UsuarioDetectado()} no detectado, saldrá del sistema", false);
                DialogResult result = materialDialog.ShowDialog(this);

                this.Close();
            }

            await LoadParametros();

            ttsUsuario.Text = $"USUARIO: {usuarioDetectado.Per.PerNombres} {usuarioDetectado.Per.PerApellidoPaterno}";

            ttsSede.Text = $"{usuarioDetectado.Per.Sed.SedDescripcion}";

            await CargaCombos();

            await CargaTrabajadoresInventariadosPorUsuario();

            if (!usuariosAdmin.Contains(usuarioDetectado.UsrIdentificador))
            {
                // Guardamos una referencia a la tercera pestaña (índice 2)
                var tabOculta = mtcMain.TabPages[2];

                // Ahora la eliminamos del control para que no sea visible
                mtcMain.TabPages.Remove(tabOculta);
            }
            else
            {
                await ListarActas();
            }

            EndLoad();
        }

        #region Listado de bienes

        private async void btnDescargarActa_Click(object sender, EventArgs e)
        {
            btnDescargarActa.Enabled = false;

            var personaSeleccionada = cmbTrabajadorSearch.SelectedItem as PersonaView;

            if (personaSeleccionada == null)
            {
                return;
            }

            var acta = await actaBienPatrimonialService.GetPorPersona(personaSeleccionada.PerId);

            await descargaActa(acta);

            btnDescargarActa.Enabled = true;
        }

        private async void btnSubirActa_Click(object sender, EventArgs e)
        {
            btnSubirActa.Enabled = false;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                ofd.Title = "Selecciona el acta en PDF";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var personaSeleccionada = cmbTrabajadorSearch.SelectedItem as PersonaView;

                    await subirActa(ofd.FileName, ofd.SafeFileName, personaSeleccionada.PerId);
                }
            }

            btnSubirActa.Enabled = true;
        }

        private async void cmbTrabajadorSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTrabajadorSearch.SelectedValue == null)
            {
                return;
            }

            await CargaTrabajadoresInventariadosPorUsuario(false);

            toolStripProgressBar1.Visible = true;            

            toolStripProgressBar1.Visible = false;
        }


        private async void btnGenerarActa_Click(object sender, EventArgs e)
        {
            btnGenerarActa.Enabled = false;
            toolStripProgressBar1.Visible = true;

            string[] columnas = { "N°", "Descripción según Catálogo", "Cod. Patrimonial", "Estado", "Marca", "Modelo", "Serie", "Color" };

            var personaSeleccionada = cmbTrabajadorSearch.SelectedItem as PersonaView;
            if (personaSeleccionada == null)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Seleccione un trabajador.", "OK", true);
                SnackBarMessage.Show(this);
                btnGenerarActa.Enabled = true;
                toolStripProgressBar1.Visible = false;
                return;
            }

            string nombre_acta = personaSeleccionada.PerNombreLargo.ToUpper().Replace(",", "").Replace(" ", "_");

            List<string[]> filas = bienesAListar.OrderBy(x => x.DebDescripcion)
                .Select((x, idx) => new string[]
                {
            (idx + 1).ToString("D3"),
            x.DebDescripcion ?? "",
            x.BptCodigoPatrimonial ?? "",
            x.BptNuevoEstadoConservacionDescripcionTipo ?? "",
            x.MarDescripcion ?? "",
            x.ModDescripcion ?? "",
            x.BptNuevaSerie ?? "",
            x.BptColorDescripcionTipo ?? "",
                })
                .ToList();

            QuestPDF.Settings.License = LicenseType.Community;
            var reporte = new ActaInventario("ACTA DE ASIGNACIÓN DE BIENES DE LA C.S.J.S.M", columnas, filas);

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.Title = "Guardar acta como...";
                sfd.FileName = $"{nombre_acta}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    reporte.GeneratePdf(path);

                    if (File.Exists(path))
                    {
                        // Abrir el PDF generado
                        var psi = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = path,
                            UseShellExecute = true
                        };
                        System.Diagnostics.Process.Start(psi);

                        var acta = await actaBienPatrimonialService.GetPorPersona(personaSeleccionada.PerId);
                        acta.AbpUltimaImpresion = DateTime.Now;
                        acta.AbpEstadoActa = EstadoActaEnum.IMPRESA;
                        acta.UsrIdentificadorImprime = usuarioDetectado.UsrIdentificador;
                        acta.SecUsuarioActualizacionId = usuarioDetectado.SecUsuarioCreacionId;
                        acta.SecFechaActualizacion = DateTime.Now;
                        acta.AbpImpresiones += 1;

                        await actaBienPatrimonialService.Modifica(acta);

                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Acta generada y guardada correctamente.", "OK", true);
                        SnackBarMessage.Show(this);
                    }
                    else
                    {
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar($"No se pudo generar el acta en {path}", "OK", true);
                        SnackBarMessage.Show(this);
                    }
                }
            }

            await CargaTrabajadoresInventariadosPorUsuario(false);

            toolStripProgressBar1.Visible = false;
            btnGenerarActa.Enabled = true;
        }

        #endregion Listado de bienes

        #region Ingreso de bien

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validate() && bienEncontrado != null)
            {
                if (!txtSerie.Text.IsNullOrEmpty())
                {
                    var bienConMismaSerie = await bienPatrimonialService.GetBySerie(bienEncontrado.BptId, txtSerie.Text.Trim());

                    if (bienConMismaSerie.Any())
                    {
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeExisteSerie, "OK", true);
                        SnackBarMessage.Show(this);

                        epInventario.SetError(txtSerie, SystemMessages.MensajeExisteSerie);
                        return;
                    }
                }

                var personaSeleccionada = cmbTrabajador.SelectedItem as PersonaView;

                var acta = await actaBienPatrimonialService.GetPorPersona(personaSeleccionada.PerId);

                if (acta != null && acta.AbpEstadoActa >= EstadoActaEnum.SUBIDA)
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeActaSubidaPorTrabajador, "OK", true);
                    SnackBarMessage.Show(this);
                    return;
                }

                MaterialDialog materialDialog = new MaterialDialog(this, "Validación de inventario", SystemMessages.MensajeConfirmarInformacion, "OK", true, "Cancel");

                DialogResult result = materialDialog.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    return;
                }

                toolStripProgressBar1.Visible = true;

                var bienPatrimonial = await bienPatrimonialService.Get(bienEncontrado.BptId);

                bienPatrimonial.PerNuevoId = (Guid)cmbTrabajador.SelectedValue;
                bienPatrimonial.UsrInventariaId = usuarioDetectado.UsrId;
                bienPatrimonial.OfiNuevoId = (Guid)cmbOficinaInterna.SelectedValue;
                bienPatrimonial.BptInventariadoTipo = InventariadoTipoEnum.INVENTARIADO;
                bienPatrimonial.BptNuevoEstadoConservacionTipo = (byte)cmbEstadoConversacion.SelectedValue;
                bienPatrimonial.BptNuevaSerie = txtSerie.Text.Trim();
                bienPatrimonial.BptObservacion = txtObservaciones.Text.Trim();

                bienPatrimonial.SecUsuarioActualizacionId = usuarioDetectado.UsrIdentificador;
                bienPatrimonial.SecFechaCreacion = DateTime.Now;

                if (acta != null)
                {
                    bienPatrimonial.AbpId = acta.AbpId;
                }
                else
                {
                    acta = new ActaBienPatrimonial()
                    {
                        PerId = (Guid)bienPatrimonial.PerNuevoId,
                        AbpEstadoActa = EstadoActaEnum.CREADA,
                        SecUsuarioCreacionId = usuarioDetectado.SecUsuarioCreacionId,
                        SecFechaCreacion = DateTime.Now,
                        PerNombre = cmbTrabajador.Text,
                        SecActivo = true,
                        AbpImpresiones = 0
                    };

                    bienPatrimonial.Abp = acta;
                }

                await bienPatrimonialService.Modifica(bienPatrimonial);

                await CargaTrabajadoresInventariadosPorUsuario();

                MaterialSnackBar SnackBarMessage2 = new MaterialSnackBar(SystemMessages.MensajeInventariadoCorrectamente, "OK", true);
                SnackBarMessage2.Show(this);

                toolStripProgressBar1.Visible = false;
            }
        }

        private void cmbDependenciaJudicial_SelectedValueChanged(object sender, EventArgs e)
        {
            var dependencia = cmbDependenciaJudicial.SelectedItem as DependenciaJudicial;
            if (dependencia != null)
            {
                cmbOficinaInterna.DataSource = dependencia.OficinaInternas.OrderBy(x => x.OfiDescripcion).ToList();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBusquedaBienModeloMarca())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                var result = frm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // Aquí puedes manejar lo que sucede después de cerrar el formulario
                    // Por ejemplo, actualizar algún control en el formulario principal
                }
            }
        }

        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modelo = cmbModelo.SelectedItem as ModeloView;

            if (modelo != null && denominacionBienModeloViews != null)
            {
                var denominaciones = denominacionBienModeloViews
                    .Where(x => x.ModId == modelo.ModId)
                    .ToList();


                cmbDenominacionBienModelo.DataSource = denominaciones;
            }
        }

        private async void cmbMarca_SelectedValueChanged(object sender, EventArgs e)
        {
            var marca = cmbMarca.SelectedItem as MarcaView;

            if (marca != null)
            {
                cmbModelo.DataSource = marca.Modelos.OrderBy(m => m.ModDescripcion).ToList();

                denominacionBienModeloViews = await denominacionBienModeloService.GetDenominacionesPorMarca(marca.MarId);

                cmbDenominacionBienModelo.DataSource = denominacionBienModeloViews;
            }
        }

        private async void btnBienEncontrado_Click(object sender, EventArgs e)
        {
            MaterialDialog materialDialog = new MaterialDialog(this, "Validación de inventario", SystemMessages.MensajeNoCoincidenciaBienPatrimonial, "OK", true, "Cancel");

            DialogResult result = materialDialog.ShowDialog(this);

            if (result != DialogResult.OK)
            {
                return;
            }

            toolStripProgressBar1.Visible = true;

            btnGuardar.Enabled =
            btnBienEncontrado.Enabled = false;

            var bienPatrimonial = await bienPatrimonialService.Get(bienEncontrado.BptId);

            bienPatrimonial.BptInventariadoTipo = InventariadoTipoEnum.REPORTADO_POR_REVISAR;
            bienPatrimonial.BptObservacion = txtObservaciones.Text.Trim();

            bienPatrimonial.SecUsuarioActualizacionId = usuarioDetectado.UsrIdentificador;
            bienPatrimonial.SecFechaCreacion = DateTime.Now;

            await bienPatrimonialService.Modifica(bienPatrimonial);

            bienEncontrado = mapper.Map<BienPatrimonialView>(bienPatrimonial);

            UtilService.EnviarEmailNoCoincideBienPatrimonial(correosDestino, bienEncontrado, emailEnvio, credencialEnvio, usuarioDetectado);

            MaterialSnackBar SnackBarMessage2 = new MaterialSnackBar(SystemMessages.MensajeEmailEnviado, "OK", true);
            SnackBarMessage2.Show(this);

            toolStripProgressBar1.Visible = false;
        }

        private async void cmbCodigoPatrimonial_Leave(object sender, EventArgs e)
        {
            // Para buscar por código patrimonial
            var codigoPatrimonial = txtCodigoPatrimonial.Text.Trim();

            toolStripProgressBar1.Visible = true;
            bienEncontrado = await bienPatrimonialService.GetByCodigoPatrimonial(codigoPatrimonial);

            btnBuscar.Visible = bienEncontrado == null;

            epInventario.Clear();

            if (bienEncontrado == null)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeExisteBien, "OK", true);
                SnackBarMessage.Show(this);
            }
            else
            {
                cmbMarca.SelectedValue = bienEncontrado.MarId;
                cmbMarca.Refresh();
                CargaBienPatrimonial();

                btnGuardar.Enabled = bienEncontrado.BptInventariadoTipo == InventariadoTipoEnum.SIN_INVENTARIAR;

                if (bienEncontrado.BptInventariadoTipo == InventariadoTipoEnum.INVENTARIADO)
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeElementoInventariado, "OK", true);
                    SnackBarMessage.Show(this);
                }

                if (bienEncontrado.BptInventariadoTipo == InventariadoTipoEnum.REPORTADO_POR_REVISAR)
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeElementoObservado, "OK", true);
                    SnackBarMessage.Show(this);
                }
            }

            toolStripProgressBar1.Visible = false;
        }

        private void cmbCodigoPatrimonial_KeyPress(object sender, KeyPressEventArgs e)
        {
            bienEncontrado = null;
            btnBienEncontrado.Visible = false;

            e.Handled = UtilService.KeyPressInteger(sender, e, 12);
        }

        #endregion Ingreso de bien

        #region Aprobar actas

        private async void btnLiberarInventario_Click(object sender, EventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0)
            {
                btnLiberarInventario.Enabled = false;

                var actaSeleccionada = dgvActas.SelectedRows[0].DataBoundItem as ActaBienPatrimonialView;

                await CambiarEstadoActa(EstadoActaEnum.CREADA, actaSeleccionada.AbpId);

                btnLiberarInventario.Enabled = true;
            }
        }

        private async void btnAprobarActa_Click(object sender, EventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0)
            {
                btnAprobarActa.Enabled = false;

                var actaSeleccionada = dgvActas.SelectedRows[0].DataBoundItem as ActaBienPatrimonialView;

                await CambiarEstadoActa(EstadoActaEnum.APROBADA, actaSeleccionada.AbpId);

                btnAprobarActa.Enabled = true;
            }                
        }

        private async void btnSubirFirmada_Click(object sender, EventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0) 
            {
                btnSubirFirmada.Enabled = false;

                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    ofd.Title = "Selecciona el acta firmada en PDF";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        var actaSeleccionada = dgvActas.SelectedRows[0].DataBoundItem as ActaBienPatrimonialView;

                        await subirActa(ofd.FileName, ofd.SafeFileName, actaSeleccionada.PerId);

                        await ListarActas();
                    }
                }

                btnSubirFirmada.Enabled = true;
            }
        }

        private async void btnVerActaEnviada_Click(object sender, EventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0)
            {
                btnVerActaEnviada.Enabled = false;

                var actaSeleccionada = dgvActas.SelectedRows[0].DataBoundItem as ActaBienPatrimonialView;

                var acta = await actaBienPatrimonialService.Get(actaSeleccionada.AbpId);

                await descargaActa(acta);

                await ListarActas();

                btnVerActaEnviada.Enabled = true;
            }
        }

        #endregion Aprobar actas

        #region Métodos propios

        private async Task ListarActas()
        {
            toolStripProgressBar1.Visible = true;

            var actas = await actaBienPatrimonialService.Get(!chkPorFirma.Checked ? EstadoActaEnum.TODOS : EstadoActaEnum.SUBIDA);

            actas.ForEach(x =>
            {
                x.AbpDescripcionEstadoActa = estadoActa.FirstOrDefault(y => y.DfvValor == x.AbpEstadoActa)?.DfvDescripcion ?? "";
            });

            dgvActas.DataSource = actas.OrderBy(x => x.PerNombre).ToList();

            btnAprobarActa.Enabled =
            btnLiberarInventario.Enabled =
            btnSubirFirmada.Enabled =
            btnVerActaEnviada.Enabled = false;

            if (actas.Any())
            {
                var actaSeleccionada = actas.OrderBy(x => x.PerNombre).FirstOrDefault();
                ActivarBotonesActas(actaSeleccionada);
            }

            toolStripProgressBar1.Visible = false;
        }

        private void ActivarBotonesActas(ActaBienPatrimonialView actaSeleccionada)
        {
            btnVerActaEnviada.Enabled = actaSeleccionada.AbpEstadoActa >= EstadoActaEnum.SUBIDA;

            btnSubirFirmada.Enabled = actaSeleccionada.AbpEstadoActa == EstadoActaEnum.SUBIDA;

            btnAprobarActa.Enabled = actaSeleccionada.AbpEstadoActa == EstadoActaEnum.FIRMADA_PATRIMONIO;

            btnLiberarInventario.Enabled = actaSeleccionada.AbpEstadoActa == EstadoActaEnum.SUBIDA;
        }

        private async Task CargaCombos()
        {
            var marcas = await marcaService.GetAll();

            estadoConservacion = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_ESTADO_DE_CONSERVACION);

            color = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_DE_COLOR_ALMACEN);

            estadoActa = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_ESTADO_DE_ACTA);

            cmbMarca.DataSource = marcas;
            cmbEstadoConversacion.DataSource = estadoConservacion.OrderBy(x => x.DfvValor).ToList();
            cmbColor.DataSource = color.OrderBy(x => x.DfvDescripcion).ToList();

            cmbDependenciaJudicial.DataSource = usuarioDetectado.Per.Sed.DependenciaJudicials.OrderBy(x => x.DepDescripcion).ToList();

            var personas = mapper.Map<List<PersonaView>>(usuarioDetectado.Per.Sed.Personas.ToList());
            cmbTrabajador.DataSource = personas.OrderBy(x => x.PerNombreLargo).ToList();
        }

        private void EndLoad()
        {
            btnGuardar.Enabled = false;
            btnBuscar.Enabled =
            cmbTrabajadorSearch.Enabled =
            cmbTrabajador.Enabled =
            cmbOficinaInterna.Enabled =
            cmbDependenciaJudicial.Enabled =
            txtObservaciones.Enabled =
            txtCodigoPatrimonial.Enabled = true;

            toolStripProgressBar1.Visible = false;
        }

        private void ConfigureCombo()
        {
            cmbMarca.DisplayMember = "MarDescripcion";
            cmbMarca.ValueMember = "MarId";

            cmbEstadoConversacion.ValueMember =
            cmbColor.ValueMember = "DfvValor";

            cmbEstadoConversacion.DisplayMember =
            cmbColor.DisplayMember = "DfvDescripcion";

            cmbDependenciaJudicial.ValueMember = "DepId";
            cmbDependenciaJudicial.DisplayMember = "DepDescripcion";

            cmbOficinaInterna.ValueMember = "OfiId";
            cmbOficinaInterna.DisplayMember = "OfiDescripcion";

            cmbTrabajadorSearch.ValueMember =
            cmbTrabajador.ValueMember = "PerId";
            cmbTrabajadorSearch.DisplayMember =
            cmbTrabajador.DisplayMember = "PerNombreLargo";

            cmbModelo.ValueMember = "ModId";
            cmbModelo.DisplayMember = "ModDescripcion";

            cmbDenominacionBienModelo.DisplayMember = "DebDescripcion";
            cmbDenominacionBienModelo.ValueMember = "DbmId";
        }

        private async Task CargaTrabajadoresInventariadosPorUsuario(bool cargarComboPersona = true)
        {
            if (usuarioDetectado == null)
            {
                return;
            }

            var bienesInventariados = await bienPatrimonialService.GetByUsuarioQueInventario(usuarioDetectado);


            if (cargarComboPersona)
            {
                var personas = bienesInventariados
                .Where(x => x.PerNuevoId != null)
                .Select(x => new PersonaView()
                {
                    PerId = (Guid)x.PerNuevoId,
                    PerNombreLargo = x.PerNuevoNombreLargo
                })
                .ToList();

                var personaDetectada = mapper.Map<PersonaView>(usuarioDetectado.Per);

                if (!personas.Any(x => x.PerId == personaDetectada.PerId))
                {
                    personas.Add(personaDetectada);
                }

                personas = personas
                            .GroupBy(x => x.PerId)
                            .Select(g => g.First())
                            .OrderBy(x => x.PerNombreLargo)
                            .ToList();

                cmbTrabajadorSearch.DataSource = personas.OrderBy(x => x.PerNombreLargo).ToList();
            }

            var personaSeleccionada = cmbTrabajadorSearch.SelectedItem as PersonaView;

            if (personaSeleccionada != null)
            {
                bienesAListar = mapper.Map<List<BienPatrimonialReporteView>>(bienesInventariados.Where(x => x.PerNuevoId == personaSeleccionada.PerId));

                bienesAListar.ForEach(x =>
                {
                    x.BptEstadoConservacionDescripcionTipo = estadoConservacion.FirstOrDefault(y => y.DfvValor == x.BptEstadoConservacionTipo)?.DfvDescripcion ?? "";

                    x.BptNuevoEstadoConservacionDescripcionTipo = estadoConservacion.FirstOrDefault(y => y.DfvValor == x.BptNuevoEstadoConservacionTipo)?.DfvDescripcion ?? "";

                    x.BptColorDescripcionTipo = color.FirstOrDefault(y => y.DfvValor == x.BptColorTipo)?.DfvDescripcion ?? "";
                });

                var acta = await actaBienPatrimonialService.GetPorPersona(personaSeleccionada.PerId);

                btnSubirActa.Enabled = acta != null && acta.AbpEstadoActa == EstadoActaEnum.IMPRESA;
                btnGenerarActa.Enabled = bienesAListar.Any() && acta != null && acta.AbpEstadoActa < EstadoActaEnum.SUBIDA;
                btnDescargarActa.Enabled = acta != null && acta.AbpEstadoActa >= EstadoActaEnum.SUBIDA;

                dgvListado.DataSource = bienesAListar.OrderBy(x => x.BptCodigoPatrimonial).ToList();
            }
        }

        private void CargaBienPatrimonial()
        {
            btnBienEncontrado.Visible = bienEncontrado != null && bienEncontrado.BptInventariadoTipo == InventariadoTipoEnum.SIN_INVENTARIAR;

            if (bienEncontrado != null && usuarioDetectado != null)
            {
                cmbMarca.SelectedValue = bienEncontrado.MarId;
                cmbModelo.SelectedValue = bienEncontrado.ModId;
                cmbDenominacionBienModelo.SelectedValue = bienEncontrado.DbmId;
                cmbEstadoConversacion.SelectedValue = bienEncontrado.BptEstadoConservacionTipo;
                cmbColor.SelectedValue = bienEncontrado.BptColorTipo;
                txtSerie.Text = bienEncontrado.BptSerie;

                cmbMarca.Refresh();
                cmbModelo.Refresh();
                cmbDenominacionBienModelo.Refresh();
                cmbEstadoConversacion.Refresh();
                cmbColor.Refresh();

                if (bienEncontrado.SedId != usuarioDetectado.Per.SedId)
                {
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeSedeDiferente, "OK", true);
                    SnackBarMessage.Show(this);
                }
                else
                {
                    cmbDependenciaJudicial.SelectedValue = bienEncontrado.DepId;
                    cmbOficinaInterna.SelectedValue = bienEncontrado.OfiId;

                    if (bienEncontrado.PerId != null)
                    {
                        cmbTrabajador.SelectedValue = bienEncontrado.PerId;
                    }

                    cmbDependenciaJudicial.Refresh();
                    cmbOficinaInterna.Refresh();
                    cmbTrabajador.Refresh();
                }
            }
        }

        /// <summary>
        /// Recorre recursivamente todos los controles descendientes de un control padre.
        /// </summary>
        /// <param name="parent">El control desde el cual comenzar el recorrido.</param>
        /// <param name="action">La acción a realizar con cada control encontrado.</param>
        public void RecorrerControles(Control parent, Action<Control> action)
        {
            // Recorre cada control directo del padre
            foreach (Control ctl in parent.Controls)
            {
                // Ejecuta la acción para el control actual
                action(ctl);

                // Si el control actual tiene sus propios hijos,
                // vuelve a llamar a este método para recorrerlos (recursividad)
                if (ctl.HasChildren)
                {
                    RecorrerControles(ctl, action);
                }
            }
        }

        private bool Validate()
        {
            bool hasError = false;

            RecorrerControles(this.tabPage2, (control) =>
            {
                hasError |= ValidarControl(control);
            });

            return hasError;
        }

        private bool ValidarControl(Control control)
        {
            bool hasError = false;

            if (control == cmbDependenciaJudicial)
            {
                bool isValid = cmbDependenciaJudicial.SelectedItem != null;
                epInventario.SetError(cmbDependenciaJudicial, isValid ? string.Empty : SystemMessages.MensajeSeleccionaDependencia);
                hasError |= !isValid;
            }

            if (control == cmbOficinaInterna)
            {
                bool isValid = cmbOficinaInterna.SelectedItem != null;
                epInventario.SetError(cmbOficinaInterna, isValid ? string.Empty : SystemMessages.MensajeSeleccionaOficina);
                hasError |= !isValid;
            }

            if (control == cmbTrabajador)
            {
                bool isValid = cmbTrabajador.SelectedItem != null;
                epInventario.SetError(cmbTrabajador, isValid ? string.Empty : SystemMessages.MensajeSeleccionaTrabajador);
                hasError |= !isValid;
            }

            return hasError;
        }

        private async Task LoadParametros()
        {
            List<string> configuraciones = new List<string> { ParametroEnum.CREDENTIAL_ENVIO_MAIL, ParametroEnum.EMAIL_ENVIO_MAIL, ParametroEnum.EMAILS_ENVIO_MAIL_INVENTARIO, ParametroEnum.CARPETA_SUBIDA_ACTAS, ParametroEnum.USUARIOS_ADMIN_INVENTARIO };

            var parametros = await parametroService.Retorna(configuraciones);

            if (parametros != null && parametros.Any())
            {
                foreach (var parametro in parametros)
                {
                    switch (parametro.ParIdentificador)
                    {
                        case ParametroEnum.EMAIL_ENVIO_MAIL:
                        emailEnvio = parametro.ParValor;
                        break;

                        case ParametroEnum.CREDENTIAL_ENVIO_MAIL:
                        credencialEnvio = parametro.ParValor;
                        break;

                        case ParametroEnum.EMAILS_ENVIO_MAIL_INVENTARIO:
                        correosDestino = parametro.ParValor.Split(",").ToList();
                        break;

                        case ParametroEnum.CARPETA_SUBIDA_ACTAS:
                        carpetaSubidaActas = parametro.ParValor;
                        break;

                        case ParametroEnum.USUARIOS_ADMIN_INVENTARIO:
                        usuariosAdmin = parametro.ParValor.Split(",").ToList();
                        break;
                    }
                }
            }
        }

        private async Task subirActa(string pathSource, string nombreOriginal, Guid perId)
        {
            toolStripProgressBar1.Visible = true;
            try
            {
                if (string.IsNullOrWhiteSpace(carpetaSubidaActas))
                {
                    MaterialSnackBar msg1 = new MaterialSnackBar("No se ha configurado la carpeta de subida de actas.", "OK", true);
                    msg1.Show(this);
                    return;
                }

                // Asegura que la carpeta exista
                if (!Directory.Exists(carpetaSubidaActas))
                    Directory.CreateDirectory(carpetaSubidaActas);

                // Genera un nombre único con Guid y mantiene la extensión .pdf
                string nombreArchivo = $"{Guid.NewGuid()}.pdf";
                string destino = Path.Combine(carpetaSubidaActas, nombreArchivo);

                // Copia el archivo de forma asíncrona
                using (var sourceStream = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                using (var destinationStream = new FileStream(destino, FileMode.Create, FileAccess.Write))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }

                var acta = await actaBienPatrimonialService.GetPorPersona(perId);

                switch (acta.AbpEstadoActa)
                {
                    case EstadoActaEnum.IMPRESA:

                    acta.AbpEstadoActa = EstadoActaEnum.SUBIDA;
                    acta.AbpArchivoSubido = nombreArchivo;
                    acta.AbpArchivoDescargado = nombreOriginal;
                    acta.SecUsuarioActualizacionId = usuarioDetectado.SecUsuarioCreacionId;
                    acta.SecFechaActualizacion = DateTime.Now;

                    await actaBienPatrimonialService.Modifica(acta);

                    await CargaTrabajadoresInventariadosPorUsuario();

                    break;

                    case EstadoActaEnum.SUBIDA:

                    acta.AbpEstadoActa = EstadoActaEnum.FIRMADA_PATRIMONIO;
                    acta.AbpArchivoFirmado = nombreArchivo;
                    acta.SecUsuarioActualizacionId = usuarioDetectado.SecUsuarioCreacionId;
                    acta.SecFechaActualizacion = DateTime.Now;

                    await actaBienPatrimonialService.Modifica(acta);

                    await CargaTrabajadoresInventariadosPorUsuario();

                    break;

                    default:
                    break;
                }

                MaterialSnackBar msg2 = new MaterialSnackBar("Archivo PDF subido correctamente.", "OK", true);
                msg2.Show(this);
            }
            catch (Exception ex)
            {
                MaterialSnackBar msg3 = new MaterialSnackBar($"Error al subir el archivo: {ex.Message}", "OK", true);
                msg3.Show(this);
            }

            toolStripProgressBar1.Visible = false;
        }

        private async Task descargaActa(ActaBienPatrimonial acta)
        {
            toolStripProgressBar1.Visible = true;
            var rutaADescargar = acta.AbpEstadoActa <= EstadoActaEnum.SUBIDA ? acta.AbpArchivoSubido : acta.AbpArchivoFirmado;

            if (acta == null || string.IsNullOrWhiteSpace(rutaADescargar) || string.IsNullOrWhiteSpace(carpetaSubidaActas))
            {
                MaterialSnackBar msg = new MaterialSnackBar("No hay archivo para descargar.", "OK", true);
                msg.Show(this);
                return;
            }

            string origen = Path.Combine(carpetaSubidaActas, rutaADescargar);

            if (!File.Exists(origen))
            {
                MaterialSnackBar msg = new MaterialSnackBar("El archivo no existe en el servidor.", "OK", true);
                msg.Show(this);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.Title = "Guardar acta como...";
                sfd.FileName = acta.AbpArchivoDescargado ?? "Acta.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var sourceStream = new FileStream(origen, FileMode.Open, FileAccess.Read))
                        using (var destinationStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                        {
                            await sourceStream.CopyToAsync(destinationStream);

                            string path = sfd.FileName;

                            if (File.Exists(path))
                            {
                                // Abrir el PDF generado
                                var psi = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = path,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(psi);
                            }
                        }

                        MaterialSnackBar msg = new MaterialSnackBar("Archivo descargado correctamente.", "OK", true);
                        msg.Show(this);
                    }
                    catch (Exception ex)
                    {
                        MaterialSnackBar msg = new MaterialSnackBar($"Error al descargar el archivo: {ex.Message}", "OK", true);
                        msg.Show(this);
                    }
                }
            }

            toolStripProgressBar1.Visible = false;
        }

        private async Task CambiarEstadoActa(byte estadoActa, Guid abpId)
        {
            var acta = await actaBienPatrimonialService.Get(abpId);

            string mensaje = $"Esta seguro que desea {(estadoActa == EstadoActaEnum.CREADA ? "liberar" : "aprobar")} acta de {acta.PerNombre}";

            MaterialDialog materialDialog = new MaterialDialog(this, "Validación de inventario", mensaje, "OK", true, "Cancel");

            DialogResult result = materialDialog.ShowDialog(this);

            if (result != DialogResult.OK)
            {
                return;
            }

            acta.AbpEstadoActa = estadoActa;
            acta.UsrIdentificadorImprime = usuarioDetectado.UsrIdentificador;
            acta.SecUsuarioActualizacionId = usuarioDetectado.SecUsuarioCreacionId;
            acta.AbpImpresiones = 0;
            acta.SecFechaActualizacion = DateTime.Now;

            await actaBienPatrimonialService.Modifica(acta);

            await ListarActas();
        }

        #endregion Métodos propios

        private async void mtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada (empieza en 0)
            int indiceSeleccionado = mtcMain.SelectedIndex;

            switch (indiceSeleccionado)
            {

                case 2: // Tercera pestaña
                await ListarActas();
                // Cargar datos de la Pestaña 3
                break;
            }
        }

        private void txtNombreActaBuscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvActas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0)
            {
                var actaSeleccionada = dgvActas.SelectedRows[0].DataBoundItem as ActaBienPatrimonialView;

                ActivarBotonesActas(actaSeleccionada);
            }
        }
    }
}

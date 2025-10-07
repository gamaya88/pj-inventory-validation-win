using AutoMapper;
using MaterialSkin.Controls;
using Microsoft.IdentityModel.Tokens;
using PJ.Inf.InventoryValidation.Win.Model;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Resources;
using PJ.Inf.InventoryValidation.Win.Service;
using PJ.Inf.InventoryValidation.Win.Utils.Enums;
using PJ.Inf.InventoryValidation.Win.Views;
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

        private List<DenominacionBienModeloView> denominacionBienModeloViews;

        private List<ValordefinicionView> estadoConservacion;

        private List<ValordefinicionView> color;

        private Usuario usuarioDetectado;

        private BienPatrimonialView bienEncontrado = null;

        private IMapper mapper;

        private string emailEnvio = "";

        private string credencialEnvio = "";

        private List<string> correosDestino = new List<string>();

        public frmMain()
        {
            InitializeComponent();

            dgvListado.Configurar();

            ConfigureCombo();

            marcaService = new MarcaService();

            denominacionBienModeloService = new DenominacionBienModeloService();

            definitionValueService = new DefinitionValueService();

            usuarioService = new UsuarioService();

            bienPatrimonialService = new BienPatrimonialService();

            parametroService = new ParametroService();

            this.SetMaterialSkin();

            toolStrip1.Font =
            groupBox1.Font =
            groupBox2.Font =
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            mapper = MappingProfile.GetInstance();
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

        private async Task CargaCombos()
        {
            var marcas = await marcaService.GetAll();

            estadoConservacion = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_ESTADO_DE_CONSERVACION);

            color = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_DE_COLOR_ALMACEN);

            cmbMarca.DataSource = marcas;
            cmbEstadoConversacion.DataSource = estadoConservacion.OrderBy(x => x.DfvValor).ToList();
            cmbColor.DataSource = color.OrderBy(x => x.DfvDescripcion).ToList();

            cmbDependenciaJudicial.DataSource = usuarioDetectado.Per.Sed.DependenciaJudicials.OrderBy(x => x.DepDescripcion).ToList();

            var personas = mapper.Map<List<PersonaView>>(usuarioDetectado.Per.Sed.Personas.ToList());
            cmbTrabajador.DataSource = personas.OrderBy(x => x.PerNombreLargo).ToList();
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

            ttsUsuario.Text = $"USUARIO: {usuarioDetectado.Per.PerNombres} {usuarioDetectado.Per.PerApellidoPaterno}";

            ttsSede.Text = $"{usuarioDetectado.Per.Sed.SedDescripcion}";

            await CargaCombos();

            await CargaTrabajadoresInventariadosPorUsuario();

            await LoadParametros();

            EndLoad();
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

        private void cmbCodigoPatrimonial_KeyPress(object sender, KeyPressEventArgs e)
        {
            bienEncontrado = null;
            btnBienEncontrado.Visible = false;

            e.Handled = UtilService.KeyPressInteger(sender, e, 12);
        }

        private async void cmbCodigoPatrimonial_Leave(object sender, EventArgs e)
        {
            // Para buscar por código patrimonial
            var codigoPatrimonial = txtCodigoPatrimonial.Text.Trim();

            toolStripProgressBar1.Visible = true;
            bienEncontrado = await bienPatrimonialService.GetByCodigoPatrimonial(codigoPatrimonial);

            btnBuscar.Visible = bienEncontrado == null;

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
                .Where(x => x.PerId != null)
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

                cmbTrabajadorSearch.DataSource = personas.OrderBy(x => x.PerNombreLargo).ToList();
            }

            var personaSeleccionada = cmbTrabajadorSearch.SelectedItem as PersonaView;

            if (personaSeleccionada != null)
            {
                var bienesAListar = mapper.Map<List<BienPatrimonialReporteView>>(bienesInventariados.Where(x => x.PerNuevoId == personaSeleccionada.PerId));

                bienesAListar.ForEach(x =>
                {
                    x.BptEstadoConservacionDescripcionTipo = estadoConservacion.FirstOrDefault(y => y.DfvValor == x.BptEstadoConservacionTipo)?.DfvDescripcion ?? "";
                    x.BptColorDescripcionTipo = color.FirstOrDefault(y => y.DfvValor == x.BptColorTipo)?.DfvDescripcion ?? "";
                });

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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validate() && bienEncontrado != null)
            {
                if (!bienEncontrado.BptSerie.IsNullOrEmpty())
                {
                    var bienConMismaSerie = await bienPatrimonialService.GetBySerie(bienEncontrado.BptId, bienEncontrado.BptSerie.Trim());

                    if (bienConMismaSerie.Any())
                    {
                        MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeExisteSerie, "OK", true);
                        SnackBarMessage.Show(this);

                        epInventario.SetError(txtSerie, SystemMessages.MensajeExisteSerie);
                        return;
                    }
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

                await bienPatrimonialService.Modifica(bienPatrimonial);

                await CargaTrabajadoresInventariadosPorUsuario();

                toolStripProgressBar1.Visible = false;
            }
        }

        private async void cmbTrabajadorSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTrabajadorSearch.SelectedValue == null)
            {
                return;
            }

            toolStripProgressBar1.Visible = true;

            await CargaTrabajadoresInventariadosPorUsuario(false);

            toolStripProgressBar1.Visible = false;
        }

        private async Task LoadParametros()
        {
            List<string> configuraciones = new List<string> { ParametroEnum.CREDENTIAL_ENVIO_MAIL, ParametroEnum.EMAIL_ENVIO_MAIL, ParametroEnum.EMAILS_ENVIO_MAIL_INVENTARIO };

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
                    }
                }
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

            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeEmailEnviado, "OK", true);
            SnackBarMessage.Show(this);

            toolStripProgressBar1.Visible = false;
        }
    }
}

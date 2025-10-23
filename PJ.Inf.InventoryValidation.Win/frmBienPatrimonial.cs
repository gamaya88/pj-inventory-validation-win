using MaterialSkin.Controls;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Resources;
using PJ.Inf.InventoryValidation.Win.Service;
using PJ.Inf.InventoryValidation.Win.Utils.Enums;

namespace PJ.Inf.InventoryValidation.Win
{
    public partial class frmBienPatrimonial : MaterialForm
    {
        private string codigoPatrimonial = string.Empty;

        private string UsrIdentificador;

        private BienPatrimonialView bienEncontrado = null;

        private BienPatrimonialService bienPatrimonialService;

        private DefinitionValueService definitionValueService;

        private List<ValordefinicionView> estadoConservacion;

        private List<ValordefinicionView> color;

        public frmBienPatrimonial(string codigoPatrimonial, string UsrIdentificador)
        {
            InitializeComponent();

            ConfigureCombo();

            this.codigoPatrimonial = codigoPatrimonial;
            this.UsrIdentificador = UsrIdentificador;

            bienPatrimonialService = new BienPatrimonialService();

            definitionValueService = new DefinitionValueService();


            txtCodigoPatrimonial.Refresh();
            txtMarca.Refresh();
            txtModelo.Refresh();
            txtBien.Refresh();

            txtCodigoPatrimonial.Enabled =
            txtMarca.Enabled =
            txtModelo.Enabled =
            txtBien.Enabled = false;

        }

        private async void frmBienPatrimonial_Load(object sender, EventArgs e)
        {
            bienEncontrado = await bienPatrimonialService.GetByCodigoPatrimonial(codigoPatrimonial);

            if (bienEncontrado == null)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(SystemMessages.MensajeExisteBien, "OK", true);
                SnackBarMessage.Show(this);

                return;
            }

            await CargaCombos();

            txtCodigoPatrimonial.Text = bienEncontrado.BptCodigoPatrimonial;
            txtMarca.Text = bienEncontrado.MarDescripcion;
            txtModelo.Text = bienEncontrado.ModDescripcion;
            txtBien.Text = bienEncontrado.DebDescripcion;

            cmbColor.SelectedValue = bienEncontrado.BptColorTipo;
            cmbEstadoConversacion.SelectedValue = bienEncontrado.BptEstadoConservacionTipo;
            txtSerie.Text = bienEncontrado.BptSerie;
            txtObservaciones.Text = bienEncontrado.BptObservacion;

            cmbColor.Select();
            cmbColor.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBusquedaBienModeloMarca())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                var result = frm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var denominacion = frm.denominacionSeleccionada;

                    txtMarca.Text = denominacion.MarDescripcion;
                    txtModelo.Text = denominacion.ModDescripcion;
                    txtBien.Text = denominacion.DebDescripcion;

                    bienEncontrado.DbmId = denominacion.DbmId;
                    // Aquí puedes manejar lo que sucede después de cerrar el formulario
                    // Por ejemplo, actualizar algún control en el formulario principal
                }
            }
        }

        private void ConfigureCombo()
        {
            cmbEstadoConversacion.ValueMember =
            cmbColor.ValueMember = "DfvValor";

            cmbEstadoConversacion.DisplayMember =
            cmbColor.DisplayMember = "DfvDescripcion";
        }

        private async Task CargaCombos()
        {
            estadoConservacion = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_ESTADO_DE_CONSERVACION);

            color = await definitionValueService.GetByDefinitionAndGroupAsync(DefinitionEnum.TIPO_DE_COLOR_ALMACEN);

            cmbEstadoConversacion.DataSource = estadoConservacion.OrderBy(x => x.DfvValor).ToList();
            cmbColor.DataSource = color.OrderBy(x => x.DfvDescripcion).ToList();

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var bien = await bienPatrimonialService.Get(bienEncontrado.BptId);

            bien.BptColorTipo = (byte)cmbColor.SelectedValue;
            bien.BptEstadoConservacionTipo = (byte)cmbEstadoConversacion.SelectedValue;
            bien.BptSerie = txtSerie.Text;
            bien.BptObservacion = txtObservaciones.Text;
            bien.BptInventariadoTipo = InventariadoTipoEnum.SIN_INVENTARIAR;

            bien.PerNuevoId = null;
            bien.UsrInventariaId = null;
            bien.OfiNuevoId = null;
            bien.BptNuevoEstadoConservacionTipo = null;
            bien.BptNuevaSerie = null;
            bien.SecUsuarioActualizacionId = UsrIdentificador;
            bien.SecFechaActualizacion = DateTime.Now;

            await bienPatrimonialService.Modifica(bien);

            this.CloseDev();
        }

        private void CloseDev()
        {
            this.DialogResult = DialogResult.OK;
            this.Close(); // Cierra el diálogo
        }
    }
}

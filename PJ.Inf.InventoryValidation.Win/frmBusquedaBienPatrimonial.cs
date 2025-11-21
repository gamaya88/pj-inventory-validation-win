using AutoMapper;
using MaterialSkin.Controls;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Registrars;
using PJ.Inf.InventoryValidation.Win.Service;

namespace PJ.Inf.InventoryValidation.Win
{
    public partial class frmBusquedaBienPatrimonial : MaterialForm
    {
        private BienPatrimonialService bienPatrimonialService;

        public BienPatrimonialReporteView BienPatrimonialReporteView;

        private IMapper mapper;

        private List<ValordefinicionView> estadoConservacion;

        private List<ValordefinicionView> color;

        public frmBusquedaBienPatrimonial(List<ValordefinicionView> estadoConservacion, List<ValordefinicionView> color)
        {
            InitializeComponent();

            bienPatrimonialService = new BienPatrimonialService();

            dgvListado.Configurar();

            mapper = MappingProfile.GetInstance();

            this.estadoConservacion = estadoConservacion;
            this.color = color;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void CloseDev()
        {
            this.DialogResult = DialogResult.OK;
            this.Close(); // Cierra el diálogo
        }

        private async Task Search()
        {
            if (txtSerie.Text.Trim().Length >= 3)
            {
                var bienesEncontradosPorSerie = await bienPatrimonialService.GetBySerie(txtSerie.Text);

                var bienesAListar = mapper.Map<List<BienPatrimonialReporteView>>(bienesEncontradosPorSerie);

                bienesAListar.ForEach(x =>
                {
                    x.BptEstadoConservacionDescripcionTipo = estadoConservacion.FirstOrDefault(y => y.DfvValor == x.BptEstadoConservacionTipo)?.DfvDescripcion ?? "";

                    x.BptColorDescripcionTipo = color.FirstOrDefault(y => y.DfvValor == x.BptColorTipo)?.DfvDescripcion ?? "";
                });

                dgvListado.DataSource = bienesAListar;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await Search();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            BienPatrimonialReporteView = (BienPatrimonialReporteView)dgvListado.SelectedRows[0].DataBoundItem;
            this.CloseDev();
        }

        private void dgvListado_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                BienPatrimonialReporteView = (BienPatrimonialReporteView)dgvListado.SelectedRows[0].DataBoundItem;
            }
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.CloseDev();
            }
        }

        private async void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                await Search();
            }
        }
    }
}

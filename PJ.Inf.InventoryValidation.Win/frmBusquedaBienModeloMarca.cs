using MaterialSkin.Controls;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ.Inf.InventoryValidation.Win
{
    public partial class frmBusquedaBienModeloMarca : MaterialForm
    {
        private DenominacionBienModeloService denominacionBienModeloService;

        public DenominacionBienModeloView denominacionSeleccionada;

        public frmBusquedaBienModeloMarca()
        {
            InitializeComponent();

            this.SetMaterialSkin();

            dgvSearch.Configurar();

            denominacionBienModeloService = new DenominacionBienModeloService();
        }

        private void CloseDev()
        {
            this.DialogResult = DialogResult.OK;
            this.Close(); // Cierra el diálogo
        }

        private async void search_TextChanged(object sender, EventArgs e)
        {
            if (txtDenominacion.Text.Length >= 3 || txtMarca.Text.Length >= 3 || txtModelo.Text.Length >= 3)
            {
                var data = await denominacionBienModeloService.GetDenominaciones(txtDenominacion.Text, txtMarca.Text, txtModelo.Text);

                denominacionSeleccionada = data.FirstOrDefault();

                dgvSearch.DataSource = data;
            }
        }

        private void dgvSearch_DoubleClick(object sender, EventArgs e)
        {
            denominacionSeleccionada = (DenominacionBienModeloView)dgvSearch.SelectedRows[0].DataBoundItem;
            this.CloseDev();
        }

        private void dgvSearch_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.SelectedRows.Count > 0)
            {
                denominacionSeleccionada = (DenominacionBienModeloView)dgvSearch.SelectedRows[0].DataBoundItem;
            }
        }

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.CloseDev();
            }
        }
    }
}

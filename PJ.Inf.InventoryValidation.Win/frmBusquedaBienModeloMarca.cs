using MaterialSkin.Controls;
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

                dgvSearch.DataSource = data;
            }
        }
    }
}

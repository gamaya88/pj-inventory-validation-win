namespace PJ.Inf.InventoryValidation.Win
{
    partial class frmBusquedaBienModeloMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            txtDenominacion = new MaterialSkin.Controls.MaterialTextBox();
            dgvSearch = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            txtMarca = new MaterialSkin.Controls.MaterialTextBox();
            txtModelo = new MaterialSkin.Controls.MaterialTextBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearch).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.Controls.Add(txtDenominacion, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvSearch, 0, 1);
            tableLayoutPanel1.Controls.Add(txtMarca, 1, 0);
            tableLayoutPanel1.Controls.Add(txtModelo, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 64);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 383);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDenominacion
            // 
            txtDenominacion.AnimateReadOnly = false;
            txtDenominacion.BorderStyle = BorderStyle.None;
            txtDenominacion.Depth = 0;
            txtDenominacion.Dock = DockStyle.Fill;
            txtDenominacion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDenominacion.Hint = "Ingrese denominacion";
            txtDenominacion.LeadingIcon = null;
            txtDenominacion.Location = new Point(3, 3);
            txtDenominacion.MaxLength = 50;
            txtDenominacion.MouseState = MaterialSkin.MouseState.OUT;
            txtDenominacion.Multiline = false;
            txtDenominacion.Name = "txtDenominacion";
            txtDenominacion.Size = new Size(324, 50);
            txtDenominacion.TabIndex = 0;
            txtDenominacion.Text = "";
            txtDenominacion.TrailingIcon = null;
            txtDenominacion.TextChanged += search_TextChanged;
            // 
            // dgvSearch
            // 
            dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearch.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            tableLayoutPanel1.SetColumnSpan(dgvSearch, 3);
            dgvSearch.Dock = DockStyle.Fill;
            dgvSearch.Location = new Point(3, 63);
            dgvSearch.Name = "dgvSearch";
            dgvSearch.Size = new Size(994, 317);
            dgvSearch.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "DbmId";
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "MarId";
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.Visible = false;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "ModId";
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.Visible = false;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "DebId";
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.Visible = false;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "DebDescripcion";
            Column5.HeaderText = "DENOMINACIÓN";
            Column5.Name = "Column5";
            Column5.Width = 300;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "MarDescripcion";
            Column6.HeaderText = "MARCA";
            Column6.Name = "Column6";
            Column6.Width = 200;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "ModDescripcion";
            Column7.HeaderText = "MODELO";
            Column7.Name = "Column7";
            Column7.Width = 200;
            // 
            // txtMarca
            // 
            txtMarca.AnimateReadOnly = false;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Depth = 0;
            txtMarca.Dock = DockStyle.Fill;
            txtMarca.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMarca.Hint = "Ingrese marca";
            txtMarca.LeadingIcon = null;
            txtMarca.Location = new Point(333, 3);
            txtMarca.MaxLength = 50;
            txtMarca.MouseState = MaterialSkin.MouseState.OUT;
            txtMarca.Multiline = false;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(324, 50);
            txtMarca.TabIndex = 1;
            txtMarca.Text = "";
            txtMarca.TrailingIcon = null;
            txtMarca.TextChanged += search_TextChanged;
            // 
            // txtModelo
            // 
            txtModelo.AnimateReadOnly = false;
            txtModelo.BorderStyle = BorderStyle.None;
            txtModelo.Depth = 0;
            txtModelo.Dock = DockStyle.Fill;
            txtModelo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtModelo.Hint = "Ingrese modelo";
            txtModelo.LeadingIcon = null;
            txtModelo.Location = new Point(663, 3);
            txtModelo.MaxLength = 50;
            txtModelo.MouseState = MaterialSkin.MouseState.OUT;
            txtModelo.Multiline = false;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(334, 50);
            txtModelo.TabIndex = 2;
            txtModelo.Text = "";
            txtModelo.TrailingIcon = null;
            txtModelo.TextChanged += search_TextChanged;
            // 
            // frmBusquedaBienModeloMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "frmBusquedaBienModeloMarca";
            Text = "frmBusquedaBienModeloMarca";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTextBox txtDenominacion;
        private DataGridView dgvSearch;
        private MaterialSkin.Controls.MaterialTextBox txtMarca;
        private MaterialSkin.Controls.MaterialTextBox txtModelo;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}
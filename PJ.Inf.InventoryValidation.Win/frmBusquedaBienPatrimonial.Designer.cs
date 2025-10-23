namespace PJ.Inf.InventoryValidation.Win
{
    partial class frmBusquedaBienPatrimonial
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
            groupBox1 = new GroupBox();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            txtSerie = new MaterialSkin.Controls.MaterialTextBox();
            dgvListado = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtSerie);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1074, 82);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda";
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = Properties.Resources.manage_search_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnBuscar.Location = new Point(499, 29);
            btnBuscar.Margin = new Padding(4, 6, 4, 6);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(105, 36);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtSerie
            // 
            txtSerie.AnimateReadOnly = false;
            txtSerie.BorderStyle = BorderStyle.None;
            txtSerie.Depth = 0;
            txtSerie.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSerie.Hint = "Ingrese serie";
            txtSerie.LeadingIcon = null;
            txtSerie.Location = new Point(6, 22);
            txtSerie.MaxLength = 50;
            txtSerie.MouseState = MaterialSkin.MouseState.OUT;
            txtSerie.Multiline = false;
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(486, 50);
            txtSerie.TabIndex = 0;
            txtSerie.Text = "";
            txtSerie.TrailingIcon = null;
            txtSerie.KeyPress += txtSerie_KeyPress;
            // 
            // dgvListado
            // 
            dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListado.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10 });
            dgvListado.Dock = DockStyle.Fill;
            dgvListado.Location = new Point(3, 146);
            dgvListado.Name = "dgvListado";
            dgvListado.Size = new Size(1074, 301);
            dgvListado.TabIndex = 2;
            dgvListado.RowEnter += dgvListado_RowEnter;
            dgvListado.DoubleClick += dgvListado_DoubleClick;
            dgvListado.KeyDown += dgvListado_KeyDown;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "DebDescripcion";
            Column2.HeaderText = "DESCRIPCIÓN";
            Column2.Name = "Column2";
            Column2.Width = 300;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "BptCodigoPatrimonial";
            Column3.HeaderText = "CÓD. PATRIMONIAL";
            Column3.Name = "Column3";
            Column3.Width = 110;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "BptEstadoConservacionDescripcionTipo";
            Column4.HeaderText = "ESTADO";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.DataPropertyName = "MarDescripcion";
            Column5.HeaderText = "MARCA";
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "ModDescripcion";
            Column6.HeaderText = "MODELO";
            Column6.Name = "Column6";
            Column6.Width = 150;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "BptSerie";
            Column7.HeaderText = "SERIE";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.DataPropertyName = "BptEstadoConservacionTipo";
            Column8.HeaderText = "Column8";
            Column8.Name = "Column8";
            Column8.Visible = false;
            // 
            // Column9
            // 
            Column9.DataPropertyName = "BptColorTipo";
            Column9.HeaderText = "Column9";
            Column9.Name = "Column9";
            Column9.Visible = false;
            // 
            // Column10
            // 
            Column10.DataPropertyName = "BptColorDescripcionTipo";
            Column10.HeaderText = "COLOR";
            Column10.Name = "Column10";
            // 
            // frmBusquedaBienPatrimonial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 450);
            Controls.Add(dgvListado);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmBusquedaBienPatrimonial";
            Text = "Búsqueda por serie";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtSerie;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private DataGridView dgvListado;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
    }
}
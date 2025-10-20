namespace PJ.Inf.InventoryValidation.Win
{
    partial class frmBienPatrimonial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBienPatrimonial));
            groupBox2 = new GroupBox();
            txtBien = new MaterialSkin.Controls.MaterialTextBox();
            txtModelo = new MaterialSkin.Controls.MaterialTextBox();
            txtMarca = new MaterialSkin.Controls.MaterialTextBox();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            cmbColor = new MaterialSkin.Controls.MaterialComboBox();
            cmbEstadoConversacion = new MaterialSkin.Controls.MaterialComboBox();
            txtObservaciones = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            txtSerie = new MaterialSkin.Controls.MaterialTextBox();
            txtCodigoPatrimonial = new MaterialSkin.Controls.MaterialTextBox();
            btnGuardar = new MaterialSkin.Controls.MaterialButton();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtBien);
            groupBox2.Controls.Add(txtModelo);
            groupBox2.Controls.Add(txtMarca);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Controls.Add(cmbEstadoConversacion);
            groupBox2.Controls.Add(txtObservaciones);
            groupBox2.Controls.Add(txtSerie);
            groupBox2.Controls.Add(txtCodigoPatrimonial);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(6, 67);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(985, 289);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "CARACTERISTICAS FÍSICAS DEL BIEN OBSERVADO";
            // 
            // txtBien
            // 
            txtBien.AnimateReadOnly = false;
            txtBien.BorderStyle = BorderStyle.None;
            txtBien.Depth = 0;
            txtBien.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBien.Hint = "Bien";
            txtBien.LeadingIcon = null;
            txtBien.Location = new Point(525, 78);
            txtBien.MaxLength = 50;
            txtBien.MouseState = MaterialSkin.MouseState.OUT;
            txtBien.Multiline = false;
            txtBien.Name = "txtBien";
            txtBien.Size = new Size(330, 50);
            txtBien.TabIndex = 14;
            txtBien.Text = "";
            txtBien.TrailingIcon = null;
            // 
            // txtModelo
            // 
            txtModelo.AnimateReadOnly = false;
            txtModelo.BorderStyle = BorderStyle.None;
            txtModelo.Depth = 0;
            txtModelo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtModelo.Hint = "Modelo";
            txtModelo.LeadingIcon = null;
            txtModelo.Location = new Point(254, 78);
            txtModelo.MaxLength = 50;
            txtModelo.MouseState = MaterialSkin.MouseState.OUT;
            txtModelo.Multiline = false;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(265, 50);
            txtModelo.TabIndex = 13;
            txtModelo.Text = "";
            txtModelo.TrailingIcon = null;
            // 
            // txtMarca
            // 
            txtMarca.AnimateReadOnly = false;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Depth = 0;
            txtMarca.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMarca.Hint = "Marca";
            txtMarca.LeadingIcon = null;
            txtMarca.Location = new Point(6, 78);
            txtMarca.MaxLength = 50;
            txtMarca.MouseState = MaterialSkin.MouseState.OUT;
            txtMarca.Multiline = false;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(242, 50);
            txtMarca.TabIndex = 12;
            txtMarca.Text = "";
            txtMarca.TrailingIcon = null;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = Properties.Resources.view_in_ar_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnBuscar.Location = new Point(862, 85);
            btnBuscar.Margin = new Padding(4, 6, 4, 6);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(105, 36);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbColor
            // 
            cmbColor.AutoResize = false;
            cmbColor.BackColor = Color.FromArgb(255, 255, 255);
            cmbColor.Depth = 0;
            cmbColor.DrawMode = DrawMode.OwnerDrawVariable;
            cmbColor.DropDownHeight = 174;
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.DropDownWidth = 121;
            cmbColor.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbColor.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbColor.FormattingEnabled = true;
            cmbColor.Hint = "Color";
            cmbColor.IntegralHeight = false;
            cmbColor.ItemHeight = 43;
            cmbColor.Location = new Point(6, 134);
            cmbColor.MaxDropDownItems = 4;
            cmbColor.MouseState = MaterialSkin.MouseState.OUT;
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(242, 49);
            cmbColor.StartIndex = 0;
            cmbColor.TabIndex = 10;
            // 
            // cmbEstadoConversacion
            // 
            cmbEstadoConversacion.AutoResize = false;
            cmbEstadoConversacion.BackColor = Color.FromArgb(255, 255, 255);
            cmbEstadoConversacion.Depth = 0;
            cmbEstadoConversacion.DrawMode = DrawMode.OwnerDrawVariable;
            cmbEstadoConversacion.DropDownHeight = 174;
            cmbEstadoConversacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoConversacion.DropDownWidth = 121;
            cmbEstadoConversacion.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbEstadoConversacion.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbEstadoConversacion.FormattingEnabled = true;
            cmbEstadoConversacion.Hint = "Estado de conservacion";
            cmbEstadoConversacion.IntegralHeight = false;
            cmbEstadoConversacion.ItemHeight = 43;
            cmbEstadoConversacion.Items.AddRange(new object[] { "BUENO", "MALO", "REGULAR" });
            cmbEstadoConversacion.Location = new Point(254, 134);
            cmbEstadoConversacion.MaxDropDownItems = 4;
            cmbEstadoConversacion.MouseState = MaterialSkin.MouseState.OUT;
            cmbEstadoConversacion.Name = "cmbEstadoConversacion";
            cmbEstadoConversacion.Size = new Size(265, 49);
            cmbEstadoConversacion.StartIndex = 0;
            cmbEstadoConversacion.TabIndex = 9;
            // 
            // txtObservaciones
            // 
            txtObservaciones.AnimateReadOnly = false;
            txtObservaciones.BackgroundImageLayout = ImageLayout.None;
            txtObservaciones.CharacterCasing = CharacterCasing.Normal;
            txtObservaciones.Depth = 0;
            txtObservaciones.HideSelection = true;
            txtObservaciones.Hint = "Observaciones";
            txtObservaciones.Location = new Point(6, 189);
            txtObservaciones.MaxLength = 32767;
            txtObservaciones.MouseState = MaterialSkin.MouseState.OUT;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PasswordChar = '\0';
            txtObservaciones.ReadOnly = false;
            txtObservaciones.ScrollBars = ScrollBars.None;
            txtObservaciones.SelectedText = "";
            txtObservaciones.SelectionLength = 0;
            txtObservaciones.SelectionStart = 0;
            txtObservaciones.ShortcutsEnabled = true;
            txtObservaciones.Size = new Size(943, 94);
            txtObservaciones.TabIndex = 8;
            txtObservaciones.TabStop = false;
            txtObservaciones.TextAlign = HorizontalAlignment.Left;
            txtObservaciones.UseSystemPasswordChar = false;
            // 
            // txtSerie
            // 
            txtSerie.AnimateReadOnly = false;
            txtSerie.BorderStyle = BorderStyle.None;
            txtSerie.Depth = 0;
            txtSerie.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSerie.Hint = "Serie";
            txtSerie.LeadingIcon = null;
            txtSerie.Location = new Point(525, 134);
            txtSerie.MaxLength = 50;
            txtSerie.MouseState = MaterialSkin.MouseState.OUT;
            txtSerie.Multiline = false;
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(330, 50);
            txtSerie.TabIndex = 7;
            txtSerie.Text = "";
            txtSerie.TrailingIcon = null;
            // 
            // txtCodigoPatrimonial
            // 
            txtCodigoPatrimonial.AnimateReadOnly = false;
            txtCodigoPatrimonial.BorderStyle = BorderStyle.None;
            txtCodigoPatrimonial.Depth = 0;
            txtCodigoPatrimonial.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCodigoPatrimonial.Hint = "Código Patrimonial";
            txtCodigoPatrimonial.LeadingIcon = null;
            txtCodigoPatrimonial.Location = new Point(6, 23);
            txtCodigoPatrimonial.MaxLength = 50;
            txtCodigoPatrimonial.MouseState = MaterialSkin.MouseState.OUT;
            txtCodigoPatrimonial.Multiline = false;
            txtCodigoPatrimonial.Name = "txtCodigoPatrimonial";
            txtCodigoPatrimonial.Size = new Size(242, 50);
            txtCodigoPatrimonial.TabIndex = 6;
            txtCodigoPatrimonial.Text = "";
            txtCodigoPatrimonial.TrailingIcon = null;
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardar.Depth = 0;
            btnGuardar.HighEmphasis = true;
            btnGuardar.Icon = Properties.Resources.save_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnGuardar.Location = new Point(454, 365);
            btnGuardar.Margin = new Padding(4, 6, 4, 6);
            btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NoAccentTextColor = Color.Empty;
            btnGuardar.Size = new Size(116, 36);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardar.UseAccentColor = false;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmBienPatrimonial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 425);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBienPatrimonial";
            Text = "Bien Patrimonial";
            Load += frmBienPatrimonial_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialComboBox cmbColor;
        private MaterialSkin.Controls.MaterialComboBox cmbEstadoConversacion;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtObservaciones;
        private MaterialSkin.Controls.MaterialTextBox txtSerie;
        private MaterialSkin.Controls.MaterialTextBox txtCodigoPatrimonial;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialTextBox txtBien;
        private MaterialSkin.Controls.MaterialTextBox txtModelo;
        private MaterialSkin.Controls.MaterialTextBox txtMarca;
    }
}
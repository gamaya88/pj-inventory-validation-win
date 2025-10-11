using PJ.Inf.InventoryValidation.Win.Service;

namespace PJ.Inf.InventoryValidation.Win
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            mtcMain = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            btnDescargarActa = new MaterialSkin.Controls.MaterialButton();
            btnSubirActa = new MaterialSkin.Controls.MaterialButton();
            btnGenerarActa = new MaterialSkin.Controls.MaterialButton();
            cmbTrabajadorSearch = new MaterialSkin.Controls.MaterialComboBox();
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
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            cmbTrabajador = new MaterialSkin.Controls.MaterialComboBox();
            btnGuardar = new MaterialSkin.Controls.MaterialButton();
            groupBox2 = new GroupBox();
            btnBienEncontrado = new MaterialSkin.Controls.MaterialButton();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            cmbColor = new MaterialSkin.Controls.MaterialComboBox();
            cmbEstadoConversacion = new MaterialSkin.Controls.MaterialComboBox();
            txtObservaciones = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            cmbModelo = new MaterialSkin.Controls.MaterialComboBox();
            cmbMarca = new MaterialSkin.Controls.MaterialComboBox();
            txtSerie = new MaterialSkin.Controls.MaterialTextBox();
            txtCodigoPatrimonial = new MaterialSkin.Controls.MaterialTextBox();
            cmbDenominacionBienModelo = new MaterialSkin.Controls.MaterialComboBox();
            groupBox1 = new GroupBox();
            cmbOficinaInterna = new MaterialSkin.Controls.MaterialComboBox();
            cmbDependenciaJudicial = new MaterialSkin.Controls.MaterialComboBox();
            tabPage3 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox5 = new GroupBox();
            chkPorFirma = new MaterialSkin.Controls.MaterialCheckbox();
            btnSubirFirmada = new MaterialSkin.Controls.MaterialButton();
            btnVerActaEnviada = new MaterialSkin.Controls.MaterialButton();
            btnLiberarInventario = new MaterialSkin.Controls.MaterialButton();
            btnAprobarActa = new MaterialSkin.Controls.MaterialButton();
            txtNombreActaBuscar = new MaterialSkin.Controls.MaterialTextBox();
            dgvActas = new DataGridView();
            imageList1 = new ImageList(components);
            toolStrip1 = new ToolStrip();
            ttsUsuario = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            ttsSede = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripProgressBar1 = new ToolStripProgressBar();
            epInventario = new ErrorProvider(components);
            Column1 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            mtcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActas).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epInventario).BeginInit();
            SuspendLayout();
            // 
            // mtcMain
            // 
            mtcMain.Controls.Add(tabPage1);
            mtcMain.Controls.Add(tabPage2);
            mtcMain.Controls.Add(tabPage3);
            mtcMain.Depth = 0;
            mtcMain.Dock = DockStyle.Fill;
            mtcMain.ImageList = imageList1;
            mtcMain.Location = new Point(3, 64);
            mtcMain.MouseState = MaterialSkin.MouseState.HOVER;
            mtcMain.Multiline = true;
            mtcMain.Name = "mtcMain";
            mtcMain.SelectedIndex = 0;
            mtcMain.Size = new Size(1062, 609);
            mtcMain.TabIndex = 0;
            mtcMain.SelectedIndexChanged += mtcMain_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.ImageKey = "format_list_numbered_24dp_FFFFFF.png";
            tabPage1.Location = new Point(4, 31);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1054, 574);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado de bienes";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvListado, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1054, 574);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1048, 94);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnDescargarActa);
            groupBox3.Controls.Add(btnSubirActa);
            groupBox3.Controls.Add(btnGenerarActa);
            groupBox3.Controls.Add(cmbTrabajadorSearch);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1048, 94);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "DATOS DE BUSQUEDA";
            // 
            // btnDescargarActa
            // 
            btnDescargarActa.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDescargarActa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDescargarActa.Depth = 0;
            btnDescargarActa.Enabled = false;
            btnDescargarActa.HighEmphasis = true;
            btnDescargarActa.Icon = Properties.Resources.convert_to_text_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnDescargarActa.Location = new Point(814, 33);
            btnDescargarActa.Margin = new Padding(4, 6, 4, 6);
            btnDescargarActa.MouseState = MaterialSkin.MouseState.HOVER;
            btnDescargarActa.Name = "btnDescargarActa";
            btnDescargarActa.NoAccentTextColor = Color.Empty;
            btnDescargarActa.Size = new Size(175, 36);
            btnDescargarActa.TabIndex = 5;
            btnDescargarActa.Text = "DESCARGAR ACTA";
            btnDescargarActa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDescargarActa.UseAccentColor = false;
            btnDescargarActa.UseVisualStyleBackColor = true;
            btnDescargarActa.Click += btnDescargarActa_Click;
            // 
            // btnSubirActa
            // 
            btnSubirActa.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSubirActa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSubirActa.Depth = 0;
            btnSubirActa.Enabled = false;
            btnSubirActa.HighEmphasis = true;
            btnSubirActa.Icon = Properties.Resources.attach_file_add_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnSubirActa.Location = new Point(674, 33);
            btnSubirActa.Margin = new Padding(4, 6, 4, 6);
            btnSubirActa.MouseState = MaterialSkin.MouseState.HOVER;
            btnSubirActa.Name = "btnSubirActa";
            btnSubirActa.NoAccentTextColor = Color.Empty;
            btnSubirActa.Size = new Size(132, 36);
            btnSubirActa.TabIndex = 4;
            btnSubirActa.Text = "SUBIR ACTA";
            btnSubirActa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubirActa.UseAccentColor = false;
            btnSubirActa.UseVisualStyleBackColor = true;
            btnSubirActa.Click += btnSubirActa_Click;
            // 
            // btnGenerarActa
            // 
            btnGenerarActa.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGenerarActa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGenerarActa.Depth = 0;
            btnGenerarActa.Enabled = false;
            btnGenerarActa.HighEmphasis = true;
            btnGenerarActa.Icon = Properties.Resources.picture_as_pdf_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnGenerarActa.Location = new Point(510, 33);
            btnGenerarActa.Margin = new Padding(4, 6, 4, 6);
            btnGenerarActa.MouseState = MaterialSkin.MouseState.HOVER;
            btnGenerarActa.Name = "btnGenerarActa";
            btnGenerarActa.NoAccentTextColor = Color.Empty;
            btnGenerarActa.Size = new Size(156, 36);
            btnGenerarActa.TabIndex = 3;
            btnGenerarActa.Text = "Generar Acta";
            btnGenerarActa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGenerarActa.UseAccentColor = false;
            btnGenerarActa.UseVisualStyleBackColor = true;
            btnGenerarActa.Click += btnGenerarActa_Click;
            // 
            // cmbTrabajadorSearch
            // 
            cmbTrabajadorSearch.AutoResize = false;
            cmbTrabajadorSearch.BackColor = Color.FromArgb(255, 255, 255);
            cmbTrabajadorSearch.Depth = 0;
            cmbTrabajadorSearch.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTrabajadorSearch.DropDownHeight = 174;
            cmbTrabajadorSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrabajadorSearch.DropDownWidth = 121;
            cmbTrabajadorSearch.Enabled = false;
            cmbTrabajadorSearch.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTrabajadorSearch.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTrabajadorSearch.FormattingEnabled = true;
            cmbTrabajadorSearch.Hint = "Trabajador";
            cmbTrabajadorSearch.IntegralHeight = false;
            cmbTrabajadorSearch.ItemHeight = 43;
            cmbTrabajadorSearch.Location = new Point(6, 25);
            cmbTrabajadorSearch.MaxDropDownItems = 4;
            cmbTrabajadorSearch.MouseState = MaterialSkin.MouseState.OUT;
            cmbTrabajadorSearch.Name = "cmbTrabajadorSearch";
            cmbTrabajadorSearch.Size = new Size(493, 49);
            cmbTrabajadorSearch.StartIndex = 0;
            cmbTrabajadorSearch.TabIndex = 2;
            cmbTrabajadorSearch.SelectedValueChanged += cmbTrabajadorSearch_SelectedValueChanged;
            // 
            // dgvListado
            // 
            dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListado.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10 });
            dgvListado.Dock = DockStyle.Fill;
            dgvListado.Location = new Point(3, 103);
            dgvListado.Name = "dgvListado";
            dgvListado.Size = new Size(1048, 438);
            dgvListado.TabIndex = 1;
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
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(btnGuardar);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.ImageKey = "add_shopping_cart_24dp_FFFFFF.png";
            tabPage2.Location = new Point(4, 31);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1054, 574);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ingreso de bien";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbTrabajador);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(3, 380);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(984, 80);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "PERSONA ASIGNADA";
            // 
            // cmbTrabajador
            // 
            cmbTrabajador.AutoResize = false;
            cmbTrabajador.BackColor = Color.FromArgb(255, 255, 255);
            cmbTrabajador.Depth = 0;
            cmbTrabajador.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTrabajador.DropDownHeight = 174;
            cmbTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrabajador.DropDownWidth = 121;
            cmbTrabajador.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTrabajador.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTrabajador.FormattingEnabled = true;
            cmbTrabajador.Hint = "Trabajador a cargo del bien";
            cmbTrabajador.IntegralHeight = false;
            cmbTrabajador.ItemHeight = 43;
            cmbTrabajador.Location = new Point(6, 20);
            cmbTrabajador.MaxDropDownItems = 4;
            cmbTrabajador.MouseState = MaterialSkin.MouseState.OUT;
            cmbTrabajador.Name = "cmbTrabajador";
            cmbTrabajador.Size = new Size(943, 49);
            cmbTrabajador.StartIndex = 0;
            cmbTrabajador.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardar.Depth = 0;
            btnGuardar.Enabled = false;
            btnGuardar.HighEmphasis = true;
            btnGuardar.Icon = Properties.Resources.save_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnGuardar.Location = new Point(465, 469);
            btnGuardar.Margin = new Padding(4, 6, 4, 6);
            btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NoAccentTextColor = Color.Empty;
            btnGuardar.Size = new Size(116, 36);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardar.UseAccentColor = false;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBienEncontrado);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Controls.Add(cmbEstadoConversacion);
            groupBox2.Controls.Add(txtObservaciones);
            groupBox2.Controls.Add(cmbModelo);
            groupBox2.Controls.Add(cmbMarca);
            groupBox2.Controls.Add(txtSerie);
            groupBox2.Controls.Add(txtCodigoPatrimonial);
            groupBox2.Controls.Add(cmbDenominacionBienModelo);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(985, 289);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "CARACTERISTICAS FÍSICAS DEL BIEN A INVENTARIAR";
            // 
            // btnBienEncontrado
            // 
            btnBienEncontrado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBienEncontrado.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBienEncontrado.Depth = 0;
            btnBienEncontrado.HighEmphasis = true;
            btnBienEncontrado.Icon = Properties.Resources.feedback_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnBienEncontrado.Location = new Point(254, 28);
            btnBienEncontrado.Margin = new Padding(4, 6, 4, 6);
            btnBienEncontrado.MouseState = MaterialSkin.MouseState.HOVER;
            btnBienEncontrado.Name = "btnBienEncontrado";
            btnBienEncontrado.NoAccentTextColor = Color.Empty;
            btnBienEncontrado.Size = new Size(140, 36);
            btnBienEncontrado.TabIndex = 12;
            btnBienEncontrado.Text = "No coincide";
            btnBienEncontrado.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBienEncontrado.UseAccentColor = false;
            btnBienEncontrado.UseVisualStyleBackColor = true;
            btnBienEncontrado.Visible = false;
            btnBienEncontrado.Click += btnBienEncontrado_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.Enabled = false;
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
            btnBuscar.Visible = false;
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
            cmbColor.Enabled = false;
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
            txtObservaciones.Enabled = false;
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
            // cmbModelo
            // 
            cmbModelo.AutoResize = false;
            cmbModelo.BackColor = Color.FromArgb(255, 255, 255);
            cmbModelo.Depth = 0;
            cmbModelo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbModelo.DropDownHeight = 174;
            cmbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelo.DropDownWidth = 121;
            cmbModelo.Enabled = false;
            cmbModelo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbModelo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Hint = "Modelo";
            cmbModelo.IntegralHeight = false;
            cmbModelo.ItemHeight = 43;
            cmbModelo.Location = new Point(254, 79);
            cmbModelo.MaxDropDownItems = 4;
            cmbModelo.MouseState = MaterialSkin.MouseState.OUT;
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(265, 49);
            cmbModelo.StartIndex = 0;
            cmbModelo.TabIndex = 4;
            cmbModelo.SelectedIndexChanged += cmbModelo_SelectedIndexChanged;
            // 
            // cmbMarca
            // 
            cmbMarca.AutoResize = false;
            cmbMarca.BackColor = Color.FromArgb(255, 255, 255);
            cmbMarca.Depth = 0;
            cmbMarca.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMarca.DropDownHeight = 174;
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.DropDownWidth = 121;
            cmbMarca.Enabled = false;
            cmbMarca.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMarca.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Hint = "Marca";
            cmbMarca.IntegralHeight = false;
            cmbMarca.ItemHeight = 43;
            cmbMarca.Location = new Point(6, 79);
            cmbMarca.MaxDropDownItems = 4;
            cmbMarca.MouseState = MaterialSkin.MouseState.OUT;
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(242, 49);
            cmbMarca.StartIndex = 0;
            cmbMarca.TabIndex = 3;
            cmbMarca.SelectedValueChanged += cmbMarca_SelectedValueChanged;
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
            txtCodigoPatrimonial.Enabled = false;
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
            txtCodigoPatrimonial.KeyPress += cmbCodigoPatrimonial_KeyPress;
            txtCodigoPatrimonial.Leave += cmbCodigoPatrimonial_Leave;
            // 
            // cmbDenominacionBienModelo
            // 
            cmbDenominacionBienModelo.AutoResize = false;
            cmbDenominacionBienModelo.BackColor = Color.FromArgb(255, 255, 255);
            cmbDenominacionBienModelo.Depth = 0;
            cmbDenominacionBienModelo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbDenominacionBienModelo.DropDownHeight = 174;
            cmbDenominacionBienModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDenominacionBienModelo.DropDownWidth = 121;
            cmbDenominacionBienModelo.Enabled = false;
            cmbDenominacionBienModelo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbDenominacionBienModelo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbDenominacionBienModelo.FormattingEnabled = true;
            cmbDenominacionBienModelo.Hint = "Bien";
            cmbDenominacionBienModelo.IntegralHeight = false;
            cmbDenominacionBienModelo.ItemHeight = 43;
            cmbDenominacionBienModelo.Location = new Point(525, 79);
            cmbDenominacionBienModelo.MaxDropDownItems = 4;
            cmbDenominacionBienModelo.MouseState = MaterialSkin.MouseState.OUT;
            cmbDenominacionBienModelo.Name = "cmbDenominacionBienModelo";
            cmbDenominacionBienModelo.Size = new Size(330, 49);
            cmbDenominacionBienModelo.StartIndex = 0;
            cmbDenominacionBienModelo.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbOficinaInterna);
            groupBox1.Controls.Add(cmbDependenciaJudicial);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(3, 295);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(984, 79);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "DATOS DE LA UBICACIÓN DEL BIEN";
            // 
            // cmbOficinaInterna
            // 
            cmbOficinaInterna.AutoResize = false;
            cmbOficinaInterna.BackColor = Color.FromArgb(255, 255, 255);
            cmbOficinaInterna.Depth = 0;
            cmbOficinaInterna.DrawMode = DrawMode.OwnerDrawVariable;
            cmbOficinaInterna.DropDownHeight = 174;
            cmbOficinaInterna.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOficinaInterna.DropDownWidth = 121;
            cmbOficinaInterna.Enabled = false;
            cmbOficinaInterna.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbOficinaInterna.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbOficinaInterna.FormattingEnabled = true;
            cmbOficinaInterna.Hint = "Oficina Interna";
            cmbOficinaInterna.IntegralHeight = false;
            cmbOficinaInterna.ItemHeight = 43;
            cmbOficinaInterna.Location = new Point(492, 22);
            cmbOficinaInterna.MaxDropDownItems = 4;
            cmbOficinaInterna.MouseState = MaterialSkin.MouseState.OUT;
            cmbOficinaInterna.Name = "cmbOficinaInterna";
            cmbOficinaInterna.Size = new Size(457, 49);
            cmbOficinaInterna.StartIndex = 0;
            cmbOficinaInterna.TabIndex = 3;
            // 
            // cmbDependenciaJudicial
            // 
            cmbDependenciaJudicial.AutoResize = false;
            cmbDependenciaJudicial.BackColor = Color.FromArgb(255, 255, 255);
            cmbDependenciaJudicial.Depth = 0;
            cmbDependenciaJudicial.DrawMode = DrawMode.OwnerDrawVariable;
            cmbDependenciaJudicial.DropDownHeight = 174;
            cmbDependenciaJudicial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDependenciaJudicial.DropDownWidth = 121;
            cmbDependenciaJudicial.Enabled = false;
            cmbDependenciaJudicial.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbDependenciaJudicial.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbDependenciaJudicial.FormattingEnabled = true;
            cmbDependenciaJudicial.Hint = "Dependencia Judicial";
            cmbDependenciaJudicial.IntegralHeight = false;
            cmbDependenciaJudicial.ItemHeight = 43;
            cmbDependenciaJudicial.Location = new Point(6, 22);
            cmbDependenciaJudicial.MaxDropDownItems = 4;
            cmbDependenciaJudicial.MouseState = MaterialSkin.MouseState.OUT;
            cmbDependenciaJudicial.Name = "cmbDependenciaJudicial";
            cmbDependenciaJudicial.Size = new Size(480, 49);
            cmbDependenciaJudicial.StartIndex = 0;
            cmbDependenciaJudicial.TabIndex = 1;
            cmbDependenciaJudicial.SelectedValueChanged += cmbDependenciaJudicial_SelectedValueChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tableLayoutPanel2);
            tabPage3.ImageKey = "fact_check_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png";
            tabPage3.Location = new Point(4, 31);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1054, 574);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Aprobar Actas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(groupBox5, 0, 0);
            tableLayoutPanel2.Controls.Add(dgvActas, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.Size = new Size(1054, 574);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = SystemColors.Control;
            groupBox5.Controls.Add(chkPorFirma);
            groupBox5.Controls.Add(btnSubirFirmada);
            groupBox5.Controls.Add(btnVerActaEnviada);
            groupBox5.Controls.Add(btnLiberarInventario);
            groupBox5.Controls.Add(btnAprobarActa);
            groupBox5.Controls.Add(txtNombreActaBuscar);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox5.Location = new Point(3, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1048, 94);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "DATOS DE BÚSQUEDA DE ACTA";
            // 
            // chkPorFirma
            // 
            chkPorFirma.AutoSize = true;
            chkPorFirma.Depth = 0;
            chkPorFirma.Location = new Point(447, 28);
            chkPorFirma.Margin = new Padding(0);
            chkPorFirma.MouseLocation = new Point(-1, -1);
            chkPorFirma.MouseState = MaterialSkin.MouseState.HOVER;
            chkPorFirma.Name = "chkPorFirma";
            chkPorFirma.ReadOnly = false;
            chkPorFirma.Ripple = true;
            chkPorFirma.Size = new Size(80, 37);
            chkPorFirma.TabIndex = 13;
            chkPorFirma.Text = "Todos";
            chkPorFirma.UseVisualStyleBackColor = true;
            // 
            // btnSubirFirmada
            // 
            btnSubirFirmada.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSubirFirmada.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSubirFirmada.Depth = 0;
            btnSubirFirmada.Enabled = false;
            btnSubirFirmada.HighEmphasis = true;
            btnSubirFirmada.Icon = Properties.Resources.attach_file_add_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnSubirFirmada.Location = new Point(638, 28);
            btnSubirFirmada.Margin = new Padding(4, 6, 4, 6);
            btnSubirFirmada.MouseState = MaterialSkin.MouseState.HOVER;
            btnSubirFirmada.Name = "btnSubirFirmada";
            btnSubirFirmada.NoAccentTextColor = Color.Empty;
            btnSubirFirmada.Size = new Size(113, 36);
            btnSubirFirmada.TabIndex = 12;
            btnSubirFirmada.Text = "FIRMADA";
            btnSubirFirmada.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubirFirmada.UseAccentColor = false;
            btnSubirFirmada.UseVisualStyleBackColor = true;
            btnSubirFirmada.Click += btnSubirFirmada_Click;
            // 
            // btnVerActaEnviada
            // 
            btnVerActaEnviada.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVerActaEnviada.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVerActaEnviada.Depth = 0;
            btnVerActaEnviada.Enabled = false;
            btnVerActaEnviada.HighEmphasis = true;
            btnVerActaEnviada.Icon = Properties.Resources.picture_as_pdf_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnVerActaEnviada.Location = new Point(554, 28);
            btnVerActaEnviada.Margin = new Padding(4, 6, 4, 6);
            btnVerActaEnviada.MouseState = MaterialSkin.MouseState.HOVER;
            btnVerActaEnviada.Name = "btnVerActaEnviada";
            btnVerActaEnviada.NoAccentTextColor = Color.Empty;
            btnVerActaEnviada.Size = new Size(76, 36);
            btnVerActaEnviada.TabIndex = 11;
            btnVerActaEnviada.Text = "Ver";
            btnVerActaEnviada.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVerActaEnviada.UseAccentColor = false;
            btnVerActaEnviada.UseVisualStyleBackColor = true;
            btnVerActaEnviada.Click += btnVerActaEnviada_Click;
            // 
            // btnLiberarInventario
            // 
            btnLiberarInventario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLiberarInventario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLiberarInventario.Depth = 0;
            btnLiberarInventario.Enabled = false;
            btnLiberarInventario.HighEmphasis = true;
            btnLiberarInventario.Icon = Properties.Resources.thumb_down_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnLiberarInventario.Location = new Point(883, 28);
            btnLiberarInventario.Margin = new Padding(4, 6, 4, 6);
            btnLiberarInventario.MouseState = MaterialSkin.MouseState.HOVER;
            btnLiberarInventario.Name = "btnLiberarInventario";
            btnLiberarInventario.NoAccentTextColor = Color.Empty;
            btnLiberarInventario.Size = new Size(107, 36);
            btnLiberarInventario.TabIndex = 10;
            btnLiberarInventario.Text = "Liberar";
            btnLiberarInventario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLiberarInventario.UseAccentColor = false;
            btnLiberarInventario.UseVisualStyleBackColor = true;
            btnLiberarInventario.Click += btnLiberarInventario_Click;
            // 
            // btnAprobarActa
            // 
            btnAprobarActa.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAprobarActa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAprobarActa.Depth = 0;
            btnAprobarActa.Enabled = false;
            btnAprobarActa.HighEmphasis = true;
            btnAprobarActa.Icon = Properties.Resources.inventory_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
            btnAprobarActa.Location = new Point(759, 28);
            btnAprobarActa.Margin = new Padding(4, 6, 4, 6);
            btnAprobarActa.MouseState = MaterialSkin.MouseState.HOVER;
            btnAprobarActa.Name = "btnAprobarActa";
            btnAprobarActa.NoAccentTextColor = Color.Empty;
            btnAprobarActa.Size = new Size(116, 36);
            btnAprobarActa.TabIndex = 9;
            btnAprobarActa.Text = "Aprobar";
            btnAprobarActa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAprobarActa.UseAccentColor = false;
            btnAprobarActa.UseVisualStyleBackColor = true;
            btnAprobarActa.Click += btnAprobarActa_Click;
            // 
            // txtNombreActaBuscar
            // 
            txtNombreActaBuscar.AnimateReadOnly = false;
            txtNombreActaBuscar.BorderStyle = BorderStyle.None;
            txtNombreActaBuscar.Depth = 0;
            txtNombreActaBuscar.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombreActaBuscar.Hint = "Ingrese el nombre del trabajador";
            txtNombreActaBuscar.LeadingIcon = null;
            txtNombreActaBuscar.Location = new Point(6, 22);
            txtNombreActaBuscar.MaxLength = 50;
            txtNombreActaBuscar.MouseState = MaterialSkin.MouseState.OUT;
            txtNombreActaBuscar.Multiline = false;
            txtNombreActaBuscar.Name = "txtNombreActaBuscar";
            txtNombreActaBuscar.Size = new Size(438, 50);
            txtNombreActaBuscar.TabIndex = 8;
            txtNombreActaBuscar.Text = "";
            txtNombreActaBuscar.TrailingIcon = null;
            txtNombreActaBuscar.TextChanged += txtNombreActaBuscar_TextChanged;
            // 
            // dgvActas
            // 
            dgvActas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActas.Columns.AddRange(new DataGridViewColumn[] { Column1, Column11, Column13, Column12, Column14, Column15, Column16 });
            dgvActas.Dock = DockStyle.Fill;
            dgvActas.Location = new Point(3, 103);
            dgvActas.Name = "dgvActas";
            dgvActas.Size = new Size(1048, 438);
            dgvActas.TabIndex = 1;
            dgvActas.RowEnter += dgvActas_RowEnter;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "add_shopping_cart_24dp_FFFFFF.png");
            imageList1.Images.SetKeyName(1, "format_list_numbered_24dp_FFFFFF.png");
            imageList1.Images.SetKeyName(2, "fact_check_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png");
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ttsUsuario, toolStripSeparator1, ttsSede, toolStripSeparator2, toolStripProgressBar1 });
            toolStrip1.Location = new Point(3, 648);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1062, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // ttsUsuario
            // 
            ttsUsuario.Name = "ttsUsuario";
            ttsUsuario.Size = new Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // ttsSede
            // 
            ttsSede.Name = "ttsSede";
            ttsSede.Size = new Size(0, 22);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 22);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            // 
            // epInventario
            // 
            epInventario.ContainerControl = this;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "AbpId";
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // Column11
            // 
            Column11.DataPropertyName = "PerNombre";
            Column11.HeaderText = "NOMBRE TRABAJADOR";
            Column11.Name = "Column11";
            Column11.Width = 300;
            // 
            // Column13
            // 
            Column13.DataPropertyName = "AbpDescripcionEstadoActa";
            Column13.HeaderText = "ESTADO ACTA";
            Column13.Name = "Column13";
            Column13.Width = 120;
            // 
            // Column12
            // 
            Column12.DataPropertyName = "AbpEstadoActa";
            Column12.HeaderText = "Column12";
            Column12.Name = "Column12";
            Column12.Visible = false;
            // 
            // Column14
            // 
            Column14.DataPropertyName = "AbpUltimaImpresion";
            Column14.HeaderText = "FECHA ÚLT IMPRESION";
            Column14.Name = "Column14";
            Column14.Width = 140;
            // 
            // Column15
            // 
            Column15.DataPropertyName = "UsrIdentificadorImprime";
            Column15.HeaderText = "ÚLT. USUARIO IMPRIMIO";
            Column15.Name = "Column15";
            Column15.Width = 120;
            // 
            // Column16
            // 
            Column16.DataPropertyName = "AbpImpresiones";
            Column16.HeaderText = "CANT. IMPRESIONES";
            Column16.Name = "Column16";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 676);
            Controls.Add(toolStrip1);
            Controls.Add(mtcMain);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = mtcMain;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "frmMain";
            Text = "Registro de inventario";
            Load += frmMain_Load;
            mtcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActas).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl mtcMain;
        private TabPage tabPage1;
        private ImageList imageList1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialComboBox cmbTrabajadorSearch;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialComboBox cmbDependenciaJudicial;
        private MaterialSkin.Controls.MaterialComboBox cmbTrabajador;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialComboBox cmbDenominacionBienModelo;
        private MaterialSkin.Controls.MaterialComboBox cmbModelo;
        private MaterialSkin.Controls.MaterialComboBox cmbMarca;
        private MaterialSkin.Controls.MaterialTextBox txtSerie;
        private MaterialSkin.Controls.MaterialTextBox txtCodigoPatrimonial;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtObservaciones;
        private MaterialSkin.Controls.MaterialComboBox cmbColor;
        private MaterialSkin.Controls.MaterialComboBox cmbEstadoConversacion;
        private GroupBox groupBox3;
        private DataGridView dgvListado;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialComboBox cmbOficinaInterna;
        private ToolStrip toolStrip1;
        private ToolStripLabel ttsSede;
        private ToolStripLabel ttsUsuario;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialButton btnBienEncontrado;
        private GroupBox groupBox4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripSeparator toolStripSeparator2;
        private ErrorProvider epInventario;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private MaterialSkin.Controls.MaterialButton btnGenerarActa;
        private MaterialSkin.Controls.MaterialButton btnSubirActa;
        private MaterialSkin.Controls.MaterialButton btnDescargarActa;
        private TabPage tabPage3;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialTextBox txtNombreActaBuscar;
        private MaterialSkin.Controls.MaterialButton btnAprobarActa;
        private MaterialSkin.Controls.MaterialButton btnLiberarInventario;
        private MaterialSkin.Controls.MaterialButton btnVerActaEnviada;
        private MaterialSkin.Controls.MaterialButton btnSubirFirmada;
        private DataGridView dgvActas;
        private MaterialSkin.Controls.MaterialCheckbox chkPorFirma;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
    }
}

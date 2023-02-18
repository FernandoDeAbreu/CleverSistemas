namespace Sistema.UI
{
    partial class UI_FROTA_VEICULOS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_FROTA_VEICULOS));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_quantidade = new System.Windows.Forms.Label();
            this.dgv_Veiculo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MARCAMODELO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RENAVAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANOMOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANOFAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RNTRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHASSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMINICIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMATUAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPACIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Edita = new System.Windows.Forms.Button();
            this.bt_Grava = new System.Windows.Forms.Button();
            this.tbox_kmfinal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbox_kminicial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbox_marcaModelo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbox_chassi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbox_anoFabrica = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbox_anoModelo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbox_placa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_rntrc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_renavam = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Veiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1062, 623);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_renavam);
            this.tabPage1.Controls.Add(this.tbox_kmfinal);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbox_kminicial);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tbox_marcaModelo);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbox_chassi);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbox_anoFabrica);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbox_anoModelo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbox_placa);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbox_rntrc);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_ID);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1054, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CADASTRO";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_quantidade);
            this.tabPage2.Controls.Add(this.dgv_Veiculo);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1054, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PESQUISA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_quantidade
            // 
            this.lbl_quantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_quantidade.AutoSize = true;
            this.lbl_quantidade.Location = new System.Drawing.Point(9, 571);
            this.lbl_quantidade.Name = "lbl_quantidade";
            this.lbl_quantidade.Size = new System.Drawing.Size(84, 15);
            this.lbl_quantidade.TabIndex = 679;
            this.lbl_quantidade.Text = "Quantidade: 0";
            // 
            // dgv_Veiculo
            // 
            this.dgv_Veiculo.AllowUserToAddRows = false;
            this.dgv_Veiculo.AllowUserToDeleteRows = false;
            this.dgv_Veiculo.AllowUserToResizeColumns = false;
            this.dgv_Veiculo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_Veiculo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Veiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Veiculo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_Veiculo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Veiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Veiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MARCAMODELO,
            this.PLACA,
            this.RENAVAM,
            this.ANOMOD,
            this.ANOFAB,
            this.RNTRC,
            this.CHASSI,
            this.KMINICIAL,
            this.KMATUAL,
            this.CAPACIDADE});
            this.dgv_Veiculo.Location = new System.Drawing.Point(3, 3);
            this.dgv_Veiculo.Name = "dgv_Veiculo";
            this.dgv_Veiculo.ReadOnly = true;
            this.dgv_Veiculo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Veiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Veiculo.Size = new System.Drawing.Size(1048, 565);
            this.dgv_Veiculo.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // MARCAMODELO
            // 
            this.MARCAMODELO.HeaderText = "MARCA / MODELO";
            this.MARCAMODELO.Name = "MARCAMODELO";
            this.MARCAMODELO.ReadOnly = true;
            this.MARCAMODELO.Width = 300;
            // 
            // PLACA
            // 
            this.PLACA.HeaderText = "PLACA";
            this.PLACA.Name = "PLACA";
            this.PLACA.ReadOnly = true;
            // 
            // RENAVAM
            // 
            this.RENAVAM.HeaderText = "RENAVAM";
            this.RENAVAM.Name = "RENAVAM";
            this.RENAVAM.ReadOnly = true;
            this.RENAVAM.Width = 200;
            // 
            // ANOMOD
            // 
            this.ANOMOD.HeaderText = "ANO MOD.";
            this.ANOMOD.Name = "ANOMOD";
            this.ANOMOD.ReadOnly = true;
            // 
            // ANOFAB
            // 
            this.ANOFAB.HeaderText = "ANO FAB.";
            this.ANOFAB.Name = "ANOFAB";
            this.ANOFAB.ReadOnly = true;
            // 
            // RNTRC
            // 
            this.RNTRC.HeaderText = "RNTRC ( ANTT )";
            this.RNTRC.Name = "RNTRC";
            this.RNTRC.ReadOnly = true;
            this.RNTRC.Width = 130;
            // 
            // CHASSI
            // 
            this.CHASSI.HeaderText = "CHASSI";
            this.CHASSI.Name = "CHASSI";
            this.CHASSI.ReadOnly = true;
            this.CHASSI.Width = 200;
            // 
            // KMINICIAL
            // 
            this.KMINICIAL.HeaderText = "KM INICIAL";
            this.KMINICIAL.Name = "KMINICIAL";
            this.KMINICIAL.ReadOnly = true;
            // 
            // KMATUAL
            // 
            this.KMATUAL.HeaderText = "KM ATUAL";
            this.KMATUAL.Name = "KMATUAL";
            this.KMATUAL.ReadOnly = true;
            // 
            // CAPACIDADE
            // 
            this.CAPACIDADE.HeaderText = "CAPACIDADE";
            this.CAPACIDADE.Name = "CAPACIDADE";
            this.CAPACIDADE.ReadOnly = true;
            // 
            // bt_Edita
            // 
            this.bt_Edita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Edita.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Edita.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Edita.Image = global::Sistema.UI.Properties.Resources.bt_NotaFiscal;
            this.bt_Edita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Edita.Location = new System.Drawing.Point(955, 627);
            this.bt_Edita.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Edita.Name = "bt_Edita";
            this.bt_Edita.Size = new System.Drawing.Size(99, 34);
            this.bt_Edita.TabIndex = 678;
            this.bt_Edita.Text = "EDITAR";
            this.bt_Edita.UseVisualStyleBackColor = false;
            this.bt_Edita.Click += new System.EventHandler(this.bt_Edita_Click);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Grava.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Grava.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Grava.Image = global::Sistema.UI.Properties.Resources.bt_Salvar;
            this.bt_Grava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Grava.Location = new System.Drawing.Point(852, 627);
            this.bt_Grava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Grava.Name = "bt_Grava";
            this.bt_Grava.Size = new System.Drawing.Size(99, 34);
            this.bt_Grava.TabIndex = 677;
            this.bt_Grava.Text = "GRAVAR";
            this.bt_Grava.UseVisualStyleBackColor = false;
            this.bt_Grava.Click += new System.EventHandler(this.bt_Grava_Click);
            // 
            // tbox_kmfinal
            // 
            this.tbox_kmfinal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbox_kmfinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_kmfinal.Location = new System.Drawing.Point(166, 183);
            this.tbox_kmfinal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_kmfinal.MaxLength = 60;
            this.tbox_kmfinal.Name = "tbox_kmfinal";
            this.tbox_kmfinal.ReadOnly = true;
            this.tbox_kmfinal.Size = new System.Drawing.Size(149, 21);
            this.tbox_kmfinal.TabIndex = 144;
            this.tbox_kmfinal.Tag = "T";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 164);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 145;
            this.label10.Text = "KM ATUAL";
            // 
            // tbox_kminicial
            // 
            this.tbox_kminicial.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_kminicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_kminicial.Location = new System.Drawing.Point(13, 183);
            this.tbox_kminicial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_kminicial.MaxLength = 60;
            this.tbox_kminicial.Name = "tbox_kminicial";
            this.tbox_kminicial.Size = new System.Drawing.Size(149, 21);
            this.tbox_kminicial.TabIndex = 142;
            this.tbox_kminicial.Tag = "T";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 164);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 143;
            this.label9.Text = "KM INICIAL";
            // 
            // tbox_marcaModelo
            // 
            this.tbox_marcaModelo.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_marcaModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_marcaModelo.Location = new System.Drawing.Point(319, 136);
            this.tbox_marcaModelo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_marcaModelo.MaxLength = 60;
            this.tbox_marcaModelo.Name = "tbox_marcaModelo";
            this.tbox_marcaModelo.Size = new System.Drawing.Size(302, 21);
            this.tbox_marcaModelo.TabIndex = 140;
            this.tbox_marcaModelo.Tag = "T";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 15);
            this.label8.TabIndex = 141;
            this.label8.Text = "MARCA / MODELO";
            // 
            // tbox_chassi
            // 
            this.tbox_chassi.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_chassi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_chassi.Location = new System.Drawing.Point(13, 136);
            this.tbox_chassi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_chassi.MaxLength = 60;
            this.tbox_chassi.Name = "tbox_chassi";
            this.tbox_chassi.Size = new System.Drawing.Size(302, 21);
            this.tbox_chassi.TabIndex = 138;
            this.tbox_chassi.Tag = "T";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 139;
            this.label7.Text = "CHASSI";
            // 
            // tbox_anoFabrica
            // 
            this.tbox_anoFabrica.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_anoFabrica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_anoFabrica.Location = new System.Drawing.Point(556, 91);
            this.tbox_anoFabrica.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_anoFabrica.MaxLength = 4;
            this.tbox_anoFabrica.Name = "tbox_anoFabrica";
            this.tbox_anoFabrica.Size = new System.Drawing.Size(65, 21);
            this.tbox_anoFabrica.TabIndex = 136;
            this.tbox_anoFabrica.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 137;
            this.label6.Text = "ANO FAB.";
            // 
            // tbox_anoModelo
            // 
            this.tbox_anoModelo.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_anoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_anoModelo.Location = new System.Drawing.Point(487, 91);
            this.tbox_anoModelo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_anoModelo.MaxLength = 4;
            this.tbox_anoModelo.Name = "tbox_anoModelo";
            this.tbox_anoModelo.Size = new System.Drawing.Size(65, 21);
            this.tbox_anoModelo.TabIndex = 134;
            this.tbox_anoModelo.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(487, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 135;
            this.label5.Text = "ANO MOD.";
            // 
            // tbox_placa
            // 
            this.tbox_placa.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_placa.Location = new System.Drawing.Point(319, 91);
            this.tbox_placa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_placa.MaxLength = 60;
            this.tbox_placa.Name = "tbox_placa";
            this.tbox_placa.Size = new System.Drawing.Size(164, 21);
            this.tbox_placa.TabIndex = 132;
            this.tbox_placa.Tag = "T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 133;
            this.label4.Text = "PLACA";
            // 
            // tbox_rntrc
            // 
            this.tbox_rntrc.BackColor = System.Drawing.SystemColors.Window;
            this.tbox_rntrc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbox_rntrc.Location = new System.Drawing.Point(166, 91);
            this.tbox_rntrc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbox_rntrc.MaxLength = 60;
            this.tbox_rntrc.Name = "tbox_rntrc";
            this.tbox_rntrc.Size = new System.Drawing.Size(149, 21);
            this.tbox_rntrc.TabIndex = 130;
            this.tbox_rntrc.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 131;
            this.label3.Text = "RNTRC ( ANTT )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 128;
            this.label1.Text = "RENAVAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 129;
            this.label2.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ID.Location = new System.Drawing.Point(13, 34);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.MaxLength = 15;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(89, 21);
            this.txt_ID.TabIndex = 126;
            this.txt_ID.Tag = "T";
            // 
            // txt_renavam
            // 
            this.txt_renavam.BackColor = System.Drawing.SystemColors.Window;
            this.txt_renavam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_renavam.Location = new System.Drawing.Point(13, 90);
            this.txt_renavam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_renavam.MaxLength = 60;
            this.txt_renavam.Name = "txt_renavam";
            this.txt_renavam.Size = new System.Drawing.Size(149, 21);
            this.txt_renavam.TabIndex = 146;
            this.txt_renavam.Tag = "T";
            // 
            // UI_FROTA_VEICULOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 667);
            this.Controls.Add(this.bt_Edita);
            this.Controls.Add(this.bt_Grava);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_FROTA_VEICULOS";
            this.Text = "VEÍCULOS";
            this.Load += new System.EventHandler(this.UI_FROTA_VEICULOS_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Veiculo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_Veiculo;
        public System.Windows.Forms.Button bt_Edita;
        public System.Windows.Forms.Button bt_Grava;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MARCAMODELO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RENAVAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANOMOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANOFAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNTRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHASSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMINICIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMATUAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAPACIDADE;
        private System.Windows.Forms.Label lbl_quantidade;
        internal System.Windows.Forms.TextBox tbox_kmfinal;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox tbox_kminicial;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox tbox_marcaModelo;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox tbox_chassi;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox tbox_anoFabrica;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox tbox_anoModelo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox tbox_placa;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox tbox_rntrc;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.TextBox txt_renavam;
    }
}
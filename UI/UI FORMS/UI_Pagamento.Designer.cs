namespace Sistema.UI
{
    partial class UI_Pagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pagamento));
            this.gb_Lancamento = new System.Windows.Forms.GroupBox();
            this.ck_Recebimento = new System.Windows.Forms.CheckBox();
            this.ck_Pagamento = new System.Windows.Forms.CheckBox();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_Parcela = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Porc_Custo = new System.Windows.Forms.TextBox();
            this.cb_TipoP = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.txt_IDP = new System.Windows.Forms.TextBox();
            this.txt_Dia_Lancamento = new System.Windows.Forms.TextBox();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.gb_Parcelamento = new System.Windows.Forms.GroupBox();
            this.txt_Periodo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ck_Personalizado = new System.Windows.Forms.CheckBox();
            this.dg_Parcelamento = new System.Windows.Forms.DataGridView();
            this.col_Personalizado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Parc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ID_Parc = new System.Windows.Forms.TextBox();
            this.bt_Incluir = new System.Windows.Forms.Button();
            this.txt_ParcelaMaxima = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.bt_Excluir = new System.Windows.Forms.Button();
            this.txt_ParcelaMinima = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bt_Editar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Lancamento.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.gb_Parcelamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Parcelamento)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.cb_TipoP);
            this.TabPage2.Controls.Add(this.label8);
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.txt_IDP);
            this.TabPage2.Controls.SetChildIndex(this.textBox1, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_IDP, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label5, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label6, 0);
            this.TabPage2.Controls.SetChildIndex(this.label8, 0);
            this.TabPage2.Controls.SetChildIndex(this.cb_TipoP, 0);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
            // 
            // gb_Lancamento
            // 
            this.gb_Lancamento.Controls.Add(this.ck_Recebimento);
            this.gb_Lancamento.Controls.Add(this.ck_Pagamento);
            this.gb_Lancamento.Location = new System.Drawing.Point(10, 235);
            this.gb_Lancamento.Name = "gb_Lancamento";
            this.gb_Lancamento.Size = new System.Drawing.Size(143, 79);
            this.gb_Lancamento.TabIndex = 10;
            this.gb_Lancamento.TabStop = false;
            this.gb_Lancamento.Text = "Lançamentos";
            // 
            // ck_Recebimento
            // 
            this.ck_Recebimento.AutoSize = true;
            this.ck_Recebimento.Location = new System.Drawing.Point(7, 21);
            this.ck_Recebimento.Name = "ck_Recebimento";
            this.ck_Recebimento.Size = new System.Drawing.Size(100, 19);
            this.ck_Recebimento.TabIndex = 11;
            this.ck_Recebimento.Tag = "T";
            this.ck_Recebimento.Text = "Recebimento";
            this.ck_Recebimento.UseVisualStyleBackColor = true;
            // 
            // ck_Pagamento
            // 
            this.ck_Pagamento.AutoSize = true;
            this.ck_Pagamento.Location = new System.Drawing.Point(7, 49);
            this.ck_Pagamento.Name = "ck_Pagamento";
            this.ck_Pagamento.Size = new System.Drawing.Size(90, 19);
            this.ck_Pagamento.TabIndex = 12;
            this.ck_Pagamento.Tag = "T";
            this.ck_Pagamento.Text = "Pagamento";
            this.ck_Pagamento.UseVisualStyleBackColor = true;
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(10, 146);
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(245, 23);
            this.cb_Tipo.TabIndex = 3;
            this.cb_Tipo.Tag = "T";
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(7, 125);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(115, 15);
            this.Label26.TabIndex = 40;
            this.Label26.Text = "Tipo de Pagamento";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(260, 129);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 15);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "Alíq. Custo";
            // 
            // txt_Parcela
            // 
            this.txt_Parcela.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Parcela.Enabled = false;
            this.txt_Parcela.Location = new System.Drawing.Point(10, 126);
            this.txt_Parcela.MaxLength = 60;
            this.txt_Parcela.Name = "txt_Parcela";
            this.txt_Parcela.Size = new System.Drawing.Size(229, 21);
            this.txt_Parcela.TabIndex = 31;
            this.txt_Parcela.Tag = "";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(10, 39);
            this.txt_ID.MaxLength = 60;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(84, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Código";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(10, 92);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(314, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Descrição";
            // 
            // txt_Porc_Custo
            // 
            this.txt_Porc_Custo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Porc_Custo.Location = new System.Drawing.Point(264, 147);
            this.txt_Porc_Custo.Name = "txt_Porc_Custo";
            this.txt_Porc_Custo.Size = new System.Drawing.Size(61, 21);
            this.txt_Porc_Custo.TabIndex = 4;
            this.txt_Porc_Custo.Tag = "T";
            this.txt_Porc_Custo.Text = "0,00";
            this.txt_Porc_Custo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Porc_Custo.Leave += new System.EventHandler(this.txt_Porc_Custo_Leave);
            // 
            // cb_TipoP
            // 
            this.cb_TipoP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoP.FormattingEnabled = true;
            this.cb_TipoP.Location = new System.Drawing.Point(406, 81);
            this.cb_TipoP.Name = "cb_TipoP";
            this.cb_TipoP.Size = new System.Drawing.Size(206, 23);
            this.cb_TipoP.TabIndex = 3;
            this.cb_TipoP.Tag = "T";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 114;
            this.label8.Text = "Tipo de Pagamento";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(1, 62);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(63, 15);
            this.Label6.TabIndex = 111;
            this.Label6.Text = "Descrição";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(1, 15);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 112;
            this.Label5.Text = "Código";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(5, 81);
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(394, 21);
            this.txt_DescricaoP.TabIndex = 2;
            this.txt_DescricaoP.Tag = "T";
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(5, 34);
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(100, 21);
            this.txt_IDP.TabIndex = 1;
            this.txt_IDP.Tag = "T";
            // 
            // txt_Dia_Lancamento
            // 
            this.txt_Dia_Lancamento.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Dia_Lancamento.Location = new System.Drawing.Point(10, 196);
            this.txt_Dia_Lancamento.MaxLength = 3;
            this.txt_Dia_Lancamento.Name = "txt_Dia_Lancamento";
            this.txt_Dia_Lancamento.Size = new System.Drawing.Size(61, 21);
            this.txt_Dia_Lancamento.TabIndex = 5;
            this.txt_Dia_Lancamento.Tag = "T";
            this.txt_Dia_Lancamento.Text = "0";
            this.txt_Dia_Lancamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.gb_Parcelamento);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_Porc_Custo);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.txt_Dia_Lancamento);
            this.gb_Cadastro.Controls.Add(this.gb_Lancamento);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.Label3);
            this.gb_Cadastro.Controls.Add(this.cb_Tipo);
            this.gb_Cadastro.Controls.Add(this.Label26);
            this.gb_Cadastro.Controls.Add(this.label14);
            this.gb_Cadastro.Controls.Add(this.label4);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 43;
            this.gb_Cadastro.TabStop = false;
            // 
            // gb_Parcelamento
            // 
            this.gb_Parcelamento.Controls.Add(this.txt_Periodo);
            this.gb_Parcelamento.Controls.Add(this.label13);
            this.gb_Parcelamento.Controls.Add(this.ck_Personalizado);
            this.gb_Parcelamento.Controls.Add(this.dg_Parcelamento);
            this.gb_Parcelamento.Controls.Add(this.txt_ID_Parc);
            this.gb_Parcelamento.Controls.Add(this.bt_Incluir);
            this.gb_Parcelamento.Controls.Add(this.txt_ParcelaMaxima);
            this.gb_Parcelamento.Controls.Add(this.label12);
            this.gb_Parcelamento.Controls.Add(this.bt_Excluir);
            this.gb_Parcelamento.Controls.Add(this.txt_ParcelaMinima);
            this.gb_Parcelamento.Controls.Add(this.txt_Parcela);
            this.gb_Parcelamento.Controls.Add(this.label15);
            this.gb_Parcelamento.Controls.Add(this.label16);
            this.gb_Parcelamento.Controls.Add(this.bt_Editar);
            this.gb_Parcelamento.Location = new System.Drawing.Point(358, 84);
            this.gb_Parcelamento.Name = "gb_Parcelamento";
            this.gb_Parcelamento.Size = new System.Drawing.Size(500, 364);
            this.gb_Parcelamento.TabIndex = 20;
            this.gb_Parcelamento.TabStop = false;
            this.gb_Parcelamento.Text = "PARCELAS";
            // 
            // txt_Periodo
            // 
            this.txt_Periodo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Periodo.Location = new System.Drawing.Point(173, 39);
            this.txt_Periodo.MaxLength = 60;
            this.txt_Periodo.Name = "txt_Periodo";
            this.txt_Periodo.Size = new System.Drawing.Size(48, 21);
            this.txt_Periodo.TabIndex = 23;
            this.txt_Periodo.Tag = "";
            this.txt_Periodo.Text = "30";
            this.txt_Periodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 30;
            this.label13.Text = "Parcelas";
            // 
            // ck_Personalizado
            // 
            this.ck_Personalizado.AutoSize = true;
            this.ck_Personalizado.Location = new System.Drawing.Point(10, 80);
            this.ck_Personalizado.Name = "ck_Personalizado";
            this.ck_Personalizado.Size = new System.Drawing.Size(185, 19);
            this.ck_Personalizado.TabIndex = 30;
            this.ck_Personalizado.Tag = "T";
            this.ck_Personalizado.Text = "Parcelamento Personalizado";
            this.ck_Personalizado.UseVisualStyleBackColor = true;
            this.ck_Personalizado.CheckedChanged += new System.EventHandler(this.ck_Personalizado_CheckedChanged);
            // 
            // dg_Parcelamento
            // 
            this.dg_Parcelamento.AllowUserToAddRows = false;
            this.dg_Parcelamento.AllowUserToDeleteRows = false;
            this.dg_Parcelamento.AllowUserToResizeColumns = false;
            this.dg_Parcelamento.AllowUserToResizeRows = false;
            this.dg_Parcelamento.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Parcelamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Parcelamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Parcelamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Personalizado,
            this.col_Parcela,
            this.col_ID_Parc,
            this.col_Periodo});
            this.dg_Parcelamento.Location = new System.Drawing.Point(10, 164);
            this.dg_Parcelamento.MultiSelect = false;
            this.dg_Parcelamento.Name = "dg_Parcelamento";
            this.dg_Parcelamento.ReadOnly = true;
            this.dg_Parcelamento.RowHeadersVisible = false;
            this.dg_Parcelamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Parcelamento.Size = new System.Drawing.Size(355, 194);
            this.dg_Parcelamento.StandardTab = true;
            this.dg_Parcelamento.TabIndex = 33;
            this.dg_Parcelamento.TabStop = false;
            // 
            // col_Personalizado
            // 
            this.col_Personalizado.HeaderText = "";
            this.col_Personalizado.Name = "col_Personalizado";
            this.col_Personalizado.ReadOnly = true;
            this.col_Personalizado.Width = 30;
            // 
            // col_Parcela
            // 
            this.col_Parcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Parcela.HeaderText = "PARCELAMENTO";
            this.col_Parcela.Name = "col_Parcela";
            this.col_Parcela.ReadOnly = true;
            // 
            // col_ID_Parc
            // 
            this.col_ID_Parc.HeaderText = "ID_Parc";
            this.col_ID_Parc.Name = "col_ID_Parc";
            this.col_ID_Parc.ReadOnly = true;
            this.col_ID_Parc.Visible = false;
            // 
            // col_Periodo
            // 
            this.col_Periodo.HeaderText = "PERÍODO";
            this.col_Periodo.Name = "col_Periodo";
            this.col_Periodo.ReadOnly = true;
            // 
            // txt_ID_Parc
            // 
            this.txt_ID_Parc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID_Parc.Enabled = false;
            this.txt_ID_Parc.Location = new System.Drawing.Point(194, 40);
            this.txt_ID_Parc.MaxLength = 3;
            this.txt_ID_Parc.Name = "txt_ID_Parc";
            this.txt_ID_Parc.Size = new System.Drawing.Size(27, 21);
            this.txt_ID_Parc.TabIndex = 25;
            this.txt_ID_Parc.Tag = "";
            this.txt_ID_Parc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Incluir
            // 
            this.bt_Incluir.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Incluir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Incluir.Image = ((System.Drawing.Image)(resources.GetObject("bt_Incluir.Image")));
            this.bt_Incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Incluir.Location = new System.Drawing.Point(247, 122);
            this.bt_Incluir.Name = "bt_Incluir";
            this.bt_Incluir.Size = new System.Drawing.Size(118, 30);
            this.bt_Incluir.TabIndex = 32;
            this.bt_Incluir.Text = "INCLUIR";
            this.bt_Incluir.UseVisualStyleBackColor = false;
            this.bt_Incluir.Click += new System.EventHandler(this.bt_Incluir_Click);
            // 
            // txt_ParcelaMaxima
            // 
            this.txt_ParcelaMaxima.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ParcelaMaxima.Location = new System.Drawing.Point(92, 39);
            this.txt_ParcelaMaxima.MaxLength = 60;
            this.txt_ParcelaMaxima.Name = "txt_ParcelaMaxima";
            this.txt_ParcelaMaxima.Size = new System.Drawing.Size(52, 21);
            this.txt_ParcelaMaxima.TabIndex = 22;
            this.txt_ParcelaMaxima.Tag = "";
            this.txt_ParcelaMaxima.Text = "1";
            this.txt_ParcelaMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Parcelamento Ex. 15/30/45";
            // 
            // bt_Excluir
            // 
            this.bt_Excluir.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Excluir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("bt_Excluir.Image")));
            this.bt_Excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Excluir.Location = new System.Drawing.Point(372, 164);
            this.bt_Excluir.Name = "bt_Excluir";
            this.bt_Excluir.Size = new System.Drawing.Size(118, 30);
            this.bt_Excluir.TabIndex = 34;
            this.bt_Excluir.Text = "EXCLUIR";
            this.bt_Excluir.UseVisualStyleBackColor = false;
            this.bt_Excluir.Click += new System.EventHandler(this.bt_Excluir_Click);
            // 
            // txt_ParcelaMinima
            // 
            this.txt_ParcelaMinima.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ParcelaMinima.Location = new System.Drawing.Point(10, 39);
            this.txt_ParcelaMinima.MaxLength = 60;
            this.txt_ParcelaMinima.Name = "txt_ParcelaMinima";
            this.txt_ParcelaMinima.Size = new System.Drawing.Size(52, 21);
            this.txt_ParcelaMinima.TabIndex = 21;
            this.txt_ParcelaMinima.Tag = "";
            this.txt_ParcelaMinima.Text = "1";
            this.txt_ParcelaMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(169, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 15);
            this.label15.TabIndex = 30;
            this.label15.Text = "Período";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(70, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 15);
            this.label16.TabIndex = 30;
            this.label16.Text = "à";
            // 
            // bt_Editar
            // 
            this.bt_Editar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Editar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Editar.Image = global::Sistema.UI.Properties.Resources.bt_NotaFiscal;
            this.bt_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Editar.Location = new System.Drawing.Point(372, 197);
            this.bt_Editar.Name = "bt_Editar";
            this.bt_Editar.Size = new System.Drawing.Size(118, 30);
            this.bt_Editar.TabIndex = 35;
            this.bt_Editar.TabStop = false;
            this.bt_Editar.Text = "EDITAR";
            this.bt_Editar.UseVisualStyleBackColor = false;
            this.bt_Editar.Click += new System.EventHandler(this.bt_Editar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 178);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Lançar em";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Dias";
            // 
            // UI_Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Pagamento";
            this.Load += new System.EventHandler(this.UI_Pagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Pagamento_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Pagamento_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Lancamento.ResumeLayout(false);
            this.gb_Lancamento.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.gb_Parcelamento.ResumeLayout(false);
            this.gb_Parcelamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Parcelamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Lancamento;
        private System.Windows.Forms.CheckBox ck_Recebimento;
        private System.Windows.Forms.CheckBox ck_Pagamento;
        internal System.Windows.Forms.ComboBox cb_Tipo;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_Parcela;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_Porc_Custo;
        internal System.Windows.Forms.ComboBox cb_TipoP;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.TextBox txt_IDP;
        internal System.Windows.Forms.TextBox txt_Dia_Lancamento;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        private System.Windows.Forms.CheckBox ck_Personalizado;
        internal System.Windows.Forms.TextBox txt_ParcelaMaxima;
        internal System.Windows.Forms.TextBox txt_Periodo;
        internal System.Windows.Forms.TextBox txt_ParcelaMinima;
        private System.Windows.Forms.GroupBox gb_Parcelamento;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Button bt_Incluir;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Button bt_Excluir;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Button bt_Editar;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DataGridView dg_Parcelamento;
        internal System.Windows.Forms.TextBox txt_ID_Parc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Personalizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Parc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Periodo;
    }
}

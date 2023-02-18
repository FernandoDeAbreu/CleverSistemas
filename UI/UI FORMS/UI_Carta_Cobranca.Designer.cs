namespace Sistema.UI
{
    partial class UI_Carta_Cobranca
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Carta_Cobranca));
            this.label30 = new System.Windows.Forms.Label();
            this.mk_Emissao = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bt_Email = new System.Windows.Forms.Button();
            this.dg_CReceber = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Informacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Acrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PrevisaoPagto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_PesquisaConta_P = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoaP = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txt_DocumentoP = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.mk_ContaP = new System.Windows.Forms.MaskedTextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_PessoaP = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label30);
            this.TabPage1.Controls.Add(this.mk_Emissao);
            this.TabPage1.Controls.Add(this.label17);
            this.TabPage1.Controls.Add(this.bt_Email);
            this.TabPage1.Controls.Add(this.dg_CReceber);
            this.TabPage1.Controls.Add(this.bt_PesquisaConta_P);
            this.TabPage1.Controls.Add(this.Label22);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.cb_TipoPessoaP);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.txt_DocumentoP);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.mk_ContaP);
            this.TabPage1.Controls.Add(this.Label21);
            this.TabPage1.Controls.Add(this.Label20);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Controls.Add(this.cb_ID_PessoaP);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Gray;
            this.label30.Location = new System.Drawing.Point(285, 5);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(141, 15);
            this.label30.TabIndex = 465;
            this.label30.Text = "F7 (Pesquisa avançada)";
            // 
            // mk_Emissao
            // 
            this.mk_Emissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mk_Emissao.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Emissao.Location = new System.Drawing.Point(9, 544);
            this.mk_Emissao.Mask = "00/00/0000";
            this.mk_Emissao.Name = "mk_Emissao";
            this.mk_Emissao.Size = new System.Drawing.Size(102, 21);
            this.mk_Emissao.TabIndex = 30;
            this.mk_Emissao.Tag = "T";
            this.mk_Emissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Emissao.ValidatingType = typeof(System.DateTime);
            this.mk_Emissao.Leave += new System.EventHandler(this.mk_Emissao_Leave);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 526);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 15);
            this.label17.TabIndex = 438;
            this.label17.Text = "Emissão";
            // 
            // bt_Email
            // 
            this.bt_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Email.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Email.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Email.Image = global::Sistema.UI.Properties.Resources.bt_email;
            this.bt_Email.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Email.Location = new System.Drawing.Point(9, 575);
            this.bt_Email.Name = "bt_Email";
            this.bt_Email.Size = new System.Drawing.Size(143, 39);
            this.bt_Email.TabIndex = 31;
            this.bt_Email.Text = "ENVIAR e-MAIL";
            this.bt_Email.UseVisualStyleBackColor = false;
            this.bt_Email.Click += new System.EventHandler(this.bt_Email_Click);
            // 
            // dg_CReceber
            // 
            this.dg_CReceber.AllowUserToAddRows = false;
            this.dg_CReceber.AllowUserToDeleteRows = false;
            this.dg_CReceber.AllowUserToResizeColumns = false;
            this.dg_CReceber.AllowUserToResizeRows = false;
            this.dg_CReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_CReceber.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_CReceber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_CReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CReceber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_ID,
            this.col_Conta,
            this.col_DescricaoConta,
            this.col_Pessoa,
            this.col_Emissao,
            this.col_Documento,
            this.col_Parcela,
            this.col_Situacao,
            this.col_Informacao,
            this.col_Vencimento,
            this.col_Valor,
            this.col_Acrescimo,
            this.col_Desconto,
            this.col_ValorLiquido,
            this.col_ID_Conta,
            this.col_TipoPessoa,
            this.col_ID_Pessoa,
            this.col_PrevisaoPagto});
            this.dg_CReceber.Location = new System.Drawing.Point(3, 105);
            this.dg_CReceber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_CReceber.MultiSelect = false;
            this.dg_CReceber.Name = "dg_CReceber";
            this.dg_CReceber.RowHeadersVisible = false;
            this.dg_CReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_CReceber.Size = new System.Drawing.Size(934, 414);
            this.dg_CReceber.StandardTab = true;
            this.dg_CReceber.TabIndex = 20;
            this.dg_CReceber.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DG_CellPainting);
            this.dg_CReceber.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_ColumnHeaderMouseClick);
            this.dg_CReceber.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DG_DataBindingComplete);
            this.dg_CReceber.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.Frozen = true;
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 25;
            // 
            // col_ID
            // 
            this.col_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "Código";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // col_Conta
            // 
            this.col_Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Conta.DataPropertyName = "Conta";
            this.col_Conta.HeaderText = "Conta";
            this.col_Conta.Name = "col_Conta";
            this.col_Conta.ReadOnly = true;
            this.col_Conta.Width = 65;
            // 
            // col_DescricaoConta
            // 
            this.col_DescricaoConta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_DescricaoConta.DataPropertyName = "DescricaoConta";
            this.col_DescricaoConta.HeaderText = "Desc. Conta";
            this.col_DescricaoConta.Name = "col_DescricaoConta";
            this.col_DescricaoConta.ReadOnly = true;
            this.col_DescricaoConta.Width = 92;
            // 
            // col_Pessoa
            // 
            this.col_Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Pessoa.DataPropertyName = "DescricaoPessoa";
            this.col_Pessoa.HeaderText = "Pessoa";
            this.col_Pessoa.Name = "col_Pessoa";
            this.col_Pessoa.ReadOnly = true;
            this.col_Pessoa.Width = 75;
            // 
            // col_Emissao
            // 
            this.col_Emissao.DataPropertyName = "Emissao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.col_Emissao.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Emissao.HeaderText = "Emissão";
            this.col_Emissao.Name = "col_Emissao";
            this.col_Emissao.ReadOnly = true;
            this.col_Emissao.Width = 75;
            // 
            // col_Documento
            // 
            this.col_Documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Documento.DataPropertyName = "Documento";
            this.col_Documento.HeaderText = "Documento";
            this.col_Documento.Name = "col_Documento";
            this.col_Documento.ReadOnly = true;
            this.col_Documento.Width = 96;
            // 
            // col_Parcela
            // 
            this.col_Parcela.DataPropertyName = "ResumoParcela";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Parcela.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Parcela.HeaderText = "Parcela";
            this.col_Parcela.Name = "col_Parcela";
            this.col_Parcela.ReadOnly = true;
            this.col_Parcela.Width = 50;
            // 
            // col_Situacao
            // 
            this.col_Situacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Situacao.DataPropertyName = "DescricaoSituacao";
            this.col_Situacao.HeaderText = "Situação";
            this.col_Situacao.Name = "col_Situacao";
            this.col_Situacao.ReadOnly = true;
            this.col_Situacao.Width = 80;
            // 
            // col_Informacao
            // 
            this.col_Informacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Informacao.DataPropertyName = "Descricao";
            this.col_Informacao.HeaderText = "Informacao";
            this.col_Informacao.Name = "col_Informacao";
            this.col_Informacao.ReadOnly = true;
            this.col_Informacao.Width = 94;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Vencimento.HeaderText = "Vencimento";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.Width = 75;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Valor.HeaderText = "Valor";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 80;
            // 
            // col_Acrescimo
            // 
            this.col_Acrescimo.DataPropertyName = "Acrescimo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_Acrescimo.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Acrescimo.HeaderText = "Acréscimo";
            this.col_Acrescimo.Name = "col_Acrescimo";
            this.col_Acrescimo.ReadOnly = true;
            this.col_Acrescimo.Width = 70;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Desconto.HeaderText = "Desconto";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 70;
            // 
            // col_ValorLiquido
            // 
            this.col_ValorLiquido.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.col_ValorLiquido.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_ValorLiquido.HeaderText = "Total";
            this.col_ValorLiquido.Name = "col_ValorLiquido";
            this.col_ValorLiquido.ReadOnly = true;
            this.col_ValorLiquido.Width = 80;
            // 
            // col_ID_Conta
            // 
            this.col_ID_Conta.DataPropertyName = "ID_Conta";
            this.col_ID_Conta.HeaderText = "ID_Conta";
            this.col_ID_Conta.Name = "col_ID_Conta";
            this.col_ID_Conta.Visible = false;
            // 
            // col_TipoPessoa
            // 
            this.col_TipoPessoa.DataPropertyName = "TipoPessoa";
            this.col_TipoPessoa.HeaderText = "TipoPessoa";
            this.col_TipoPessoa.Name = "col_TipoPessoa";
            this.col_TipoPessoa.Visible = false;
            // 
            // col_ID_Pessoa
            // 
            this.col_ID_Pessoa.DataPropertyName = "ID_Pessoa";
            this.col_ID_Pessoa.HeaderText = "ID_Pessoa";
            this.col_ID_Pessoa.Name = "col_ID_Pessoa";
            this.col_ID_Pessoa.Visible = false;
            // 
            // col_PrevisaoPagto
            // 
            this.col_PrevisaoPagto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_PrevisaoPagto.DataPropertyName = "PrevisaoPagto";
            this.col_PrevisaoPagto.HeaderText = "Previsão Pagto.";
            this.col_PrevisaoPagto.Name = "col_PrevisaoPagto";
            this.col_PrevisaoPagto.Width = 108;
            // 
            // bt_PesquisaConta_P
            // 
            this.bt_PesquisaConta_P.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta_P.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta_P.Image")));
            this.bt_PesquisaConta_P.Location = new System.Drawing.Point(93, 72);
            this.bt_PesquisaConta_P.Name = "bt_PesquisaConta_P";
            this.bt_PesquisaConta_P.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta_P.TabIndex = 11;
            this.bt_PesquisaConta_P.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta_P.Click += new System.EventHandler(this.bt_PesquisaConta_P_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(274, 55);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(50, 15);
            this.Label22.TabIndex = 461;
            this.Label22.Text = "Periodo";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Items.AddRange(new object[] {
            "BAIXA",
            "EMISSÃO",
            "VENCIMENTO"});
            this.cb_Periodo.Location = new System.Drawing.Point(278, 74);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(146, 23);
            this.cb_Periodo.TabIndex = 13;
            this.cb_Periodo.Tag = "T";
            // 
            // cb_TipoPessoaP
            // 
            this.cb_TipoPessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoaP.FormattingEnabled = true;
            this.cb_TipoPessoaP.Location = new System.Drawing.Point(10, 26);
            this.cb_TipoPessoaP.Name = "cb_TipoPessoaP";
            this.cb_TipoPessoaP.Size = new System.Drawing.Size(199, 23);
            this.cb_TipoPessoaP.TabIndex = 2;
            this.cb_TipoPessoaP.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoaP_SelectedValueChanged);
            this.cb_TipoPessoaP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_TipoPessoaP_KeyDown);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(540, 81);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 460;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(562, 74);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 15;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(432, 74);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 14;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // txt_DocumentoP
            // 
            this.txt_DocumentoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DocumentoP.Location = new System.Drawing.Point(132, 74);
            this.txt_DocumentoP.Name = "txt_DocumentoP";
            this.txt_DocumentoP.Size = new System.Drawing.Size(138, 21);
            this.txt_DocumentoP.TabIndex = 12;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(128, 55);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(87, 15);
            this.Label23.TabIndex = 459;
            this.Label23.Text = "Nº Documento";
            // 
            // mk_ContaP
            // 
            this.mk_ContaP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_ContaP.Location = new System.Drawing.Point(9, 73);
            this.mk_ContaP.Mask = "00,00,00,00";
            this.mk_ContaP.Name = "mk_ContaP";
            this.mk_ContaP.PromptChar = '0';
            this.mk_ContaP.Size = new System.Drawing.Size(76, 21);
            this.mk_ContaP.TabIndex = 10;
            this.mk_ContaP.Tag = "T";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(6, 54);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(69, 15);
            this.Label21.TabIndex = 457;
            this.Label21.Text = "Cód. Conta";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(7, 5);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(77, 15);
            this.Label20.TabIndex = 455;
            this.Label20.Text = "Tipo Pessoa";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(213, 5);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(63, 15);
            this.Label19.TabIndex = 456;
            this.Label19.Text = "Descrição";
            // 
            // cb_ID_PessoaP
            // 
            this.cb_ID_PessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_PessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_PessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_PessoaP.FormattingEnabled = true;
            this.cb_ID_PessoaP.Location = new System.Drawing.Point(217, 26);
            this.cb_ID_PessoaP.Name = "cb_ID_PessoaP";
            this.cb_ID_PessoaP.Size = new System.Drawing.Size(446, 23);
            this.cb_ID_PessoaP.TabIndex = 3;
            this.cb_ID_PessoaP.Tag = "T";
            this.cb_ID_PessoaP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_PessoaP_KeyDown);
            // 
            // UI_Carta_Cobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Carta_Cobranca";
            this.Load += new System.EventHandler(this.UI_Carta_Cobranca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Carta_Cobranca_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_CReceber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.MaskedTextBox mk_Emissao;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Button bt_Email;
        public System.Windows.Forms.DataGridView dg_CReceber;
        internal System.Windows.Forms.Button bt_PesquisaConta_P;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.ComboBox cb_TipoPessoaP;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.TextBox txt_DocumentoP;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.MaskedTextBox mk_ContaP;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_PessoaP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Informacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Acrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PrevisaoPagto;
    }
}

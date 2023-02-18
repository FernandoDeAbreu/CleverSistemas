namespace Sistema.UI
{
    partial class UI_NFe_Util
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_NFe_Util));
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.cb_TipoPessoaP = new System.Windows.Forms.ComboBox();
            this.Label53 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.cb_ID_PessoaP = new System.Windows.Forms.ComboBox();
            this.cb_SituacaoNFeP = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ID_NFeP = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.dg_NFe = new System.Windows.Forms.DataGridView();
            this.col_SelecionaNFe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_NFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NaturezaOperacaoNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataEmissaoNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PessoaNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SituacaoNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SerieNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Evento = new System.Windows.Forms.GroupBox();
            this.dg_Evento = new System.Windows.Forms.DataGridView();
            this.col_Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Prot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ID_NF = new System.Windows.Forms.TextBox();
            this.bt_PreDanfe = new System.Windows.Forms.Button();
            this.bt_DANFE = new System.Windows.Forms.Button();
            this.bt_Transmitir = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.bt_CartaCorrecao = new System.Windows.Forms.Button();
            this.bt_Validar = new System.Windows.Forms.Button();
            this.bt_Email = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.bt_ArquivoNFe = new System.Windows.Forms.Button();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_NFe)).BeginInit();
            this.gb_Evento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Evento)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.gb_Evento);
            this.TabPage1.Controls.Add(this.bt_PreDanfe);
            this.TabPage1.Controls.Add(this.bt_ArquivoNFe);
            this.TabPage1.Controls.Add(this.bt_Email);
            this.TabPage1.Controls.Add(this.bt_DANFE);
            this.TabPage1.Controls.Add(this.bt_Transmitir);
            this.TabPage1.Controls.Add(this.bt_Cancelar);
            this.TabPage1.Controls.Add(this.bt_CartaCorrecao);
            this.TabPage1.Controls.Add(this.bt_Validar);
            this.TabPage1.Controls.Add(this.txt_Serie);
            this.TabPage1.Controls.Add(this.label21);
            this.TabPage1.Controls.Add(this.label29);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.cb_TipoPessoaP);
            this.TabPage1.Controls.Add(this.Label53);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.Label54);
            this.TabPage1.Controls.Add(this.cb_ID_PessoaP);
            this.TabPage1.Controls.Add(this.cb_SituacaoNFeP);
            this.TabPage1.Controls.Add(this.label20);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.txt_status);
            this.TabPage1.Controls.Add(this.txt_ID_NFeP);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Controls.Add(this.dg_NFe);
            // 
            // txt_Serie
            // 
            this.txt_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Serie.Location = new System.Drawing.Point(209, 89);
            this.txt_Serie.MaxLength = 200;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(54, 21);
            this.txt_Serie.TabIndex = 5;
            this.txt_Serie.Tag = "T";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(519, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 15);
            this.label21.TabIndex = 188;
            this.label21.Text = "à";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(412, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 15);
            this.label29.TabIndex = 187;
            this.label29.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(538, 89);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 8;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(415, 89);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 7;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // cb_TipoPessoaP
            // 
            this.cb_TipoPessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoaP.FormattingEnabled = true;
            this.cb_TipoPessoaP.Location = new System.Drawing.Point(9, 33);
            this.cb_TipoPessoaP.Name = "cb_TipoPessoaP";
            this.cb_TipoPessoaP.Size = new System.Drawing.Size(192, 23);
            this.cb_TipoPessoaP.TabIndex = 1;
            this.cb_TipoPessoaP.Tag = "T";
            this.cb_TipoPessoaP.SelectedIndexChanged += new System.EventHandler(this.cb_TipoPessoaP_SelectedValueChanged);
            this.cb_TipoPessoaP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_TipoPessoaP_KeyDown);
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.Location = new System.Drawing.Point(6, 14);
            this.Label53.Name = "Label53";
            this.Label53.Size = new System.Drawing.Size(77, 15);
            this.Label53.TabIndex = 185;
            this.Label53.Text = "Tipo Pessoa";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Location = new System.Drawing.Point(205, 14);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(63, 15);
            this.Label54.TabIndex = 186;
            this.Label54.Text = "Descrição";
            // 
            // cb_ID_PessoaP
            // 
            this.cb_ID_PessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_PessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_PessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_PessoaP.FormattingEnabled = true;
            this.cb_ID_PessoaP.Location = new System.Drawing.Point(209, 33);
            this.cb_ID_PessoaP.MaxDropDownItems = 15;
            this.cb_ID_PessoaP.Name = "cb_ID_PessoaP";
            this.cb_ID_PessoaP.Size = new System.Drawing.Size(430, 23);
            this.cb_ID_PessoaP.TabIndex = 2;
            this.cb_ID_PessoaP.Tag = "T";
            this.cb_ID_PessoaP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_PessoaP_KeyDown);
            // 
            // cb_SituacaoNFeP
            // 
            this.cb_SituacaoNFeP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_SituacaoNFeP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_SituacaoNFeP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SituacaoNFeP.FormattingEnabled = true;
            this.cb_SituacaoNFeP.Location = new System.Drawing.Point(9, 89);
            this.cb_SituacaoNFeP.Name = "cb_SituacaoNFeP";
            this.cb_SituacaoNFeP.Size = new System.Drawing.Size(192, 23);
            this.cb_SituacaoNFeP.TabIndex = 4;
            this.cb_SituacaoNFeP.Tag = "T";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 184;
            this.label20.Text = "Situação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 182;
            this.label3.Text = "Serie";
            // 
            // txt_ID_NFeP
            // 
            this.txt_ID_NFeP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_NFeP.Location = new System.Drawing.Point(271, 89);
            this.txt_ID_NFeP.MaxLength = 9;
            this.txt_ID_NFeP.Name = "txt_ID_NFeP";
            this.txt_ID_NFeP.Size = new System.Drawing.Size(137, 21);
            this.txt_ID_NFeP.TabIndex = 6;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(267, 70);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(50, 15);
            this.Label19.TabIndex = 183;
            this.Label19.Text = "Nº NF-e";
            // 
            // dg_NFe
            // 
            this.dg_NFe.AllowUserToAddRows = false;
            this.dg_NFe.AllowUserToDeleteRows = false;
            this.dg_NFe.AllowUserToResizeColumns = false;
            this.dg_NFe.AllowUserToResizeRows = false;
            this.dg_NFe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_NFe.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_NFe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_NFe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_NFe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_SelecionaNFe,
            this.col_ID_NFe,
            this.col_NaturezaOperacaoNFe,
            this.col_DataEmissaoNFe,
            this.col_PessoaNFe,
            this.col_SituacaoNFe,
            this.col_Valor,
            this.col_ID_Empresa,
            this.col_ID,
            this.col_ID_Situacao,
            this.col_SerieNFe});
            this.dg_NFe.Location = new System.Drawing.Point(9, 122);
            this.dg_NFe.MultiSelect = false;
            this.dg_NFe.Name = "dg_NFe";
            this.dg_NFe.RowHeadersVisible = false;
            this.dg_NFe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_NFe.Size = new System.Drawing.Size(926, 305);
            this.dg_NFe.StandardTab = true;
            this.dg_NFe.TabIndex = 10;
            this.dg_NFe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_NFe_CellContentClick);
            this.dg_NFe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_NFe_CellFormatting);
            this.dg_NFe.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_NFe_CellPainting);
            this.dg_NFe.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_NFe_ColumnHeaderMouseClick);
            this.dg_NFe.DoubleClick += new System.EventHandler(this.dg_NFe_DoubleClick);
            this.dg_NFe.Leave += new System.EventHandler(this.dg_NFe_Leave);
            // 
            // col_SelecionaNFe
            // 
            this.col_SelecionaNFe.HeaderText = "";
            this.col_SelecionaNFe.Name = "col_SelecionaNFe";
            this.col_SelecionaNFe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_SelecionaNFe.Width = 30;
            // 
            // col_ID_NFe
            // 
            this.col_ID_NFe.DataPropertyName = "ID_NFe";
            this.col_ID_NFe.HeaderText = "Nº NF-e";
            this.col_ID_NFe.Name = "col_ID_NFe";
            this.col_ID_NFe.ReadOnly = true;
            this.col_ID_NFe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_NFe.Width = 70;
            // 
            // col_NaturezaOperacaoNFe
            // 
            this.col_NaturezaOperacaoNFe.DataPropertyName = "NaturezaOperacao";
            this.col_NaturezaOperacaoNFe.HeaderText = "NATUREZA";
            this.col_NaturezaOperacaoNFe.Name = "col_NaturezaOperacaoNFe";
            this.col_NaturezaOperacaoNFe.ReadOnly = true;
            this.col_NaturezaOperacaoNFe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_NaturezaOperacaoNFe.Width = 150;
            // 
            // col_DataEmissaoNFe
            // 
            this.col_DataEmissaoNFe.DataPropertyName = "DataEmissao";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.col_DataEmissaoNFe.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_DataEmissaoNFe.HeaderText = "DATA";
            this.col_DataEmissaoNFe.Name = "col_DataEmissaoNFe";
            this.col_DataEmissaoNFe.ReadOnly = true;
            this.col_DataEmissaoNFe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_DataEmissaoNFe.Width = 80;
            // 
            // col_PessoaNFe
            // 
            this.col_PessoaNFe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_PessoaNFe.DataPropertyName = "DescricaoPessoa";
            this.col_PessoaNFe.HeaderText = "PESSOA";
            this.col_PessoaNFe.Name = "col_PessoaNFe";
            this.col_PessoaNFe.ReadOnly = true;
            this.col_PessoaNFe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_SituacaoNFe
            // 
            this.col_SituacaoNFe.DataPropertyName = "DescricaoSituacao";
            this.col_SituacaoNFe.HeaderText = "SITUAÇÃO";
            this.col_SituacaoNFe.Name = "col_SituacaoNFe";
            this.col_SituacaoNFe.ReadOnly = true;
            this.col_SituacaoNFe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_SituacaoNFe.Width = 120;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Valor.HeaderText = "VALOR";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ID_Empresa
            // 
            this.col_ID_Empresa.DataPropertyName = "ID_Empresa";
            this.col_ID_Empresa.HeaderText = "ID_Empresa";
            this.col_ID_Empresa.Name = "col_ID_Empresa";
            this.col_ID_Empresa.Visible = false;
            this.col_ID_Empresa.Width = 5;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID_NFe";
            this.col_ID.Name = "col_ID";
            this.col_ID.Visible = false;
            // 
            // col_ID_Situacao
            // 
            this.col_ID_Situacao.DataPropertyName = "Situacao";
            this.col_ID_Situacao.HeaderText = "ID_Situacao";
            this.col_ID_Situacao.Name = "col_ID_Situacao";
            this.col_ID_Situacao.Visible = false;
            // 
            // col_SerieNFe
            // 
            this.col_SerieNFe.DataPropertyName = "Serie";
            this.col_SerieNFe.HeaderText = "Serie";
            this.col_SerieNFe.Name = "col_SerieNFe";
            this.col_SerieNFe.Visible = false;
            // 
            // gb_Evento
            // 
            this.gb_Evento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Evento.Controls.Add(this.dg_Evento);
            this.gb_Evento.Controls.Add(this.txt_ID_NF);
            this.gb_Evento.Location = new System.Drawing.Point(9, 493);
            this.gb_Evento.Name = "gb_Evento";
            this.gb_Evento.Size = new System.Drawing.Size(926, 126);
            this.gb_Evento.TabIndex = 20;
            this.gb_Evento.TabStop = false;
            // 
            // dg_Evento
            // 
            this.dg_Evento.AllowUserToAddRows = false;
            this.dg_Evento.AllowUserToDeleteRows = false;
            this.dg_Evento.AllowUserToResizeColumns = false;
            this.dg_Evento.AllowUserToResizeRows = false;
            this.dg_Evento.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_Evento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Evento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Evento.ColumnHeadersVisible = false;
            this.dg_Evento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seq,
            this.col_DataEvento,
            this.col_Prot,
            this.col_Evento});
            this.dg_Evento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Evento.Location = new System.Drawing.Point(3, 17);
            this.dg_Evento.MultiSelect = false;
            this.dg_Evento.Name = "dg_Evento";
            this.dg_Evento.ReadOnly = true;
            this.dg_Evento.RowHeadersVisible = false;
            this.dg_Evento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Evento.Size = new System.Drawing.Size(920, 106);
            this.dg_Evento.StandardTab = true;
            this.dg_Evento.TabIndex = 21;
            this.dg_Evento.TabStop = false;
            // 
            // col_Seq
            // 
            this.col_Seq.DataPropertyName = "Seq";
            this.col_Seq.HeaderText = "Seq";
            this.col_Seq.Name = "col_Seq";
            this.col_Seq.ReadOnly = true;
            this.col_Seq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Seq.Width = 30;
            // 
            // col_DataEvento
            // 
            this.col_DataEvento.DataPropertyName = "Data";
            this.col_DataEvento.HeaderText = "Data";
            this.col_DataEvento.Name = "col_DataEvento";
            this.col_DataEvento.ReadOnly = true;
            this.col_DataEvento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Prot
            // 
            this.col_Prot.DataPropertyName = "Protocolo";
            this.col_Prot.HeaderText = "Protocolo";
            this.col_Prot.Name = "col_Prot";
            this.col_Prot.ReadOnly = true;
            this.col_Prot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Prot.Width = 150;
            // 
            // col_Evento
            // 
            this.col_Evento.DataPropertyName = "Evento";
            this.col_Evento.HeaderText = "Evento";
            this.col_Evento.Name = "col_Evento";
            this.col_Evento.ReadOnly = true;
            this.col_Evento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Evento.Width = 500;
            // 
            // txt_ID_NF
            // 
            this.txt_ID_NF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_NF.Enabled = false;
            this.txt_ID_NF.Location = new System.Drawing.Point(7, 18);
            this.txt_ID_NF.MaxLength = 200;
            this.txt_ID_NF.Name = "txt_ID_NF";
            this.txt_ID_NF.Size = new System.Drawing.Size(145, 21);
            this.txt_ID_NF.TabIndex = 150;
            this.txt_ID_NF.Tag = "T";
            this.txt_ID_NF.TextChanged += new System.EventHandler(this.txt_ID_NF_TextChanged);
            // 
            // bt_PreDanfe
            // 
            this.bt_PreDanfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_PreDanfe.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PreDanfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PreDanfe.Image = ((System.Drawing.Image)(resources.GetObject("bt_PreDanfe.Image")));
            this.bt_PreDanfe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PreDanfe.Location = new System.Drawing.Point(468, 436);
            this.bt_PreDanfe.Name = "bt_PreDanfe";
            this.bt_PreDanfe.Size = new System.Drawing.Size(104, 51);
            this.bt_PreDanfe.TabIndex = 40;
            this.bt_PreDanfe.Text = "PRÉ-DANFE";
            this.bt_PreDanfe.UseVisualStyleBackColor = false;
            this.bt_PreDanfe.Click += new System.EventHandler(this.bt_PreDanfe_Click);
            // 
            // bt_DANFE
            // 
            this.bt_DANFE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_DANFE.BackColor = System.Drawing.SystemColors.Control;
            this.bt_DANFE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DANFE.Image = ((System.Drawing.Image)(resources.GetObject("bt_DANFE.Image")));
            this.bt_DANFE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_DANFE.Location = new System.Drawing.Point(582, 436);
            this.bt_DANFE.Name = "bt_DANFE";
            this.bt_DANFE.Size = new System.Drawing.Size(104, 51);
            this.bt_DANFE.TabIndex = 41;
            this.bt_DANFE.Text = "IMPRIMIR\r\nDANFE";
            this.bt_DANFE.UseVisualStyleBackColor = false;
            this.bt_DANFE.Click += new System.EventHandler(this.bt_DANFE_Click);
            // 
            // bt_Transmitir
            // 
            this.bt_Transmitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Transmitir.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Transmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Transmitir.Image = ((System.Drawing.Image)(resources.GetObject("bt_Transmitir.Image")));
            this.bt_Transmitir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Transmitir.Location = new System.Drawing.Point(12, 436);
            this.bt_Transmitir.Name = "bt_Transmitir";
            this.bt_Transmitir.Size = new System.Drawing.Size(104, 51);
            this.bt_Transmitir.TabIndex = 30;
            this.bt_Transmitir.Text = "TRANSMITIR / ATUALIZAR";
            this.bt_Transmitir.UseVisualStyleBackColor = false;
            this.bt_Transmitir.Click += new System.EventHandler(this.bt_Transmitir_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Cancelar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bt_Cancelar.Image")));
            this.bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Cancelar.Location = new System.Drawing.Point(354, 436);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(104, 51);
            this.bt_Cancelar.TabIndex = 34;
            this.bt_Cancelar.Text = "CANCELAR";
            this.bt_Cancelar.UseVisualStyleBackColor = false;
            this.bt_Cancelar.Click += new System.EventHandler(this.bt_Cancelar_Click);
            // 
            // bt_CartaCorrecao
            // 
            this.bt_CartaCorrecao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_CartaCorrecao.BackColor = System.Drawing.SystemColors.Control;
            this.bt_CartaCorrecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CartaCorrecao.Image = ((System.Drawing.Image)(resources.GetObject("bt_CartaCorrecao.Image")));
            this.bt_CartaCorrecao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_CartaCorrecao.Location = new System.Drawing.Point(240, 436);
            this.bt_CartaCorrecao.Name = "bt_CartaCorrecao";
            this.bt_CartaCorrecao.Size = new System.Drawing.Size(104, 51);
            this.bt_CartaCorrecao.TabIndex = 33;
            this.bt_CartaCorrecao.Text = "CARTA DE CORREÇÃO";
            this.bt_CartaCorrecao.UseVisualStyleBackColor = false;
            this.bt_CartaCorrecao.Click += new System.EventHandler(this.bt_CartaCorrecao_Click);
            // 
            // bt_Validar
            // 
            this.bt_Validar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Validar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Validar.Image = ((System.Drawing.Image)(resources.GetObject("bt_Validar.Image")));
            this.bt_Validar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Validar.Location = new System.Drawing.Point(126, 436);
            this.bt_Validar.Name = "bt_Validar";
            this.bt_Validar.Size = new System.Drawing.Size(104, 51);
            this.bt_Validar.TabIndex = 31;
            this.bt_Validar.Text = "VALIDAR";
            this.bt_Validar.UseVisualStyleBackColor = false;
            this.bt_Validar.Click += new System.EventHandler(this.bt_Validar_Click);
            // 
            // bt_Email
            // 
            this.bt_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Email.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Email.Image = global::Sistema.UI.Properties.Resources.bt_email;
            this.bt_Email.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Email.Location = new System.Drawing.Point(696, 436);
            this.bt_Email.Name = "bt_Email";
            this.bt_Email.Size = new System.Drawing.Size(104, 51);
            this.bt_Email.TabIndex = 44;
            this.bt_Email.Text = "EMAIL";
            this.bt_Email.UseVisualStyleBackColor = false;
            this.bt_Email.Click += new System.EventHandler(this.bt_Email_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 186;
            this.label1.Text = "STATUS";
            // 
            // txt_status
            // 
            this.txt_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_status.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_status.Location = new System.Drawing.Point(645, 33);
            this.txt_status.MaxLength = 9;
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.Size = new System.Drawing.Size(290, 21);
            this.txt_status.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(276, 14);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 189;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // bt_ArquivoNFe
            // 
            this.bt_ArquivoNFe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_ArquivoNFe.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ArquivoNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ArquivoNFe.Image = global::Sistema.UI.Properties.Resources.bt_Pasta;
            this.bt_ArquivoNFe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ArquivoNFe.Location = new System.Drawing.Point(810, 436);
            this.bt_ArquivoNFe.Name = "bt_ArquivoNFe";
            this.bt_ArquivoNFe.Size = new System.Drawing.Size(125, 51);
            this.bt_ArquivoNFe.TabIndex = 44;
            this.bt_ArquivoNFe.Text = "ABRIR LOCAL\r\nDO ARQUIVO";
            this.bt_ArquivoNFe.UseVisualStyleBackColor = false;
            this.bt_ArquivoNFe.Click += new System.EventHandler(this.bt_ArquivoNFe_Click);
            // 
            // UI_NFe_Util
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_NFe_Util";
            this.Load += new System.EventHandler(this.UI_NFe_Util_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_NFe_Util_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_NFe)).EndInit();
            this.gb_Evento.ResumeLayout(false);
            this.gb_Evento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Evento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Serie;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.ComboBox cb_TipoPessoaP;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.ComboBox cb_ID_PessoaP;
        internal System.Windows.Forms.ComboBox cb_SituacaoNFeP;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_ID_NFeP;
        internal System.Windows.Forms.Label Label19;
        private System.Windows.Forms.GroupBox gb_Evento;
        internal System.Windows.Forms.DataGridView dg_Evento;
        internal System.Windows.Forms.TextBox txt_ID_NF;
        internal System.Windows.Forms.Button bt_PreDanfe;
        internal System.Windows.Forms.Button bt_DANFE;
        internal System.Windows.Forms.Button bt_Transmitir;
        internal System.Windows.Forms.Button bt_Cancelar;
        internal System.Windows.Forms.Button bt_CartaCorrecao;
        internal System.Windows.Forms.Button bt_Validar;
        internal System.Windows.Forms.Button bt_Email;
        internal System.Windows.Forms.DataGridView dg_NFe;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_status;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Button bt_ArquivoNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Prot;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Evento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_SelecionaNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_NFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NaturezaOperacaoNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataEmissaoNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PessoaNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SituacaoNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SerieNFe;
    }
}

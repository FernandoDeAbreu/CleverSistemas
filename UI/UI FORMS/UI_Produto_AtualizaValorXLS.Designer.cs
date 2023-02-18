namespace Sistema.UI
{
    partial class UI_Produto_AtualizaValorXLS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_AtualizaValorXLS));
            this.Pesquisaxls = new System.Windows.Forms.OpenFileDialog();
            this.bt_PesquisaXLS = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Caminho = new System.Windows.Forms.TextBox();
            this.dg_Tabela = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_TabelaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_CadastroProduto = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ck_Ativo = new System.Windows.Forms.CheckBox();
            this.cb_ID_GrupoGrade = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.cb_UnidadeTributavel = new System.Windows.Forms.ComboBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.txt_Informacao = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txt_Fabricante = new System.Windows.Forms.TextBox();
            this.cb_ID_Tabela = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.mk_Conta = new System.Windows.Forms.MaskedTextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_DescricaoConta = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_ID_Conta = new System.Windows.Forms.TextBox();
            this.bt_Estrutura = new System.Windows.Forms.Button();
            this.txt_ReferenciaP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabela)).BeginInit();
            this.gb_CadastroProduto.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txt_DescricaoP);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.txt_ReferenciaP);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.gb_CadastroProduto);
            this.TabPage1.Controls.Add(this.bt_Estrutura);
            this.TabPage1.Controls.Add(this.bt_PesquisaXLS);
            this.TabPage1.Controls.Add(this.label22);
            this.TabPage1.Controls.Add(this.txt_Caminho);
            this.TabPage1.Controls.Add(this.dg_Tabela);
            // 
            // bt_PesquisaXLS
            // 
            this.bt_PesquisaXLS.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaXLS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaXLS.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaXLS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaXLS.Location = new System.Drawing.Point(369, 29);
            this.bt_PesquisaXLS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaXLS.Name = "bt_PesquisaXLS";
            this.bt_PesquisaXLS.Size = new System.Drawing.Size(113, 35);
            this.bt_PesquisaXLS.TabIndex = 2;
            this.bt_PesquisaXLS.Text = "PESQUISA";
            this.bt_PesquisaXLS.UseVisualStyleBackColor = false;
            this.bt_PesquisaXLS.Click += new System.EventHandler(this.bt_PesquisaXLS_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 104;
            this.label22.Text = "Tabela (Excel)";
            // 
            // txt_Caminho
            // 
            this.txt_Caminho.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Caminho.Location = new System.Drawing.Point(8, 35);
            this.txt_Caminho.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Caminho.MaxLength = 60;
            this.txt_Caminho.Name = "txt_Caminho";
            this.txt_Caminho.Size = new System.Drawing.Size(355, 21);
            this.txt_Caminho.TabIndex = 1;
            this.txt_Caminho.Tag = "T";
            // 
            // dg_Tabela
            // 
            this.dg_Tabela.AllowUserToAddRows = false;
            this.dg_Tabela.AllowUserToDeleteRows = false;
            this.dg_Tabela.AllowUserToResizeColumns = false;
            this.dg_Tabela.AllowUserToResizeRows = false;
            this.dg_Tabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Tabela.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Tabela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_ID_Produto,
            this.col_Referencia,
            this.col_Descricao,
            this.col_NCM,
            this.col_ValorCompra,
            this.col_ValorVenda,
            this.col_ID_TabelaValor});
            this.dg_Tabela.Location = new System.Drawing.Point(8, 120);
            this.dg_Tabela.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Tabela.MultiSelect = false;
            this.dg_Tabela.Name = "dg_Tabela";
            this.dg_Tabela.RowHeadersVisible = false;
            this.dg_Tabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Tabela.Size = new System.Drawing.Size(930, 290);
            this.dg_Tabela.StandardTab = true;
            this.dg_Tabela.TabIndex = 10;
            this.dg_Tabela.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Tabela_CellPainting);
            this.dg_Tabela.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Tabela_ColumnHeaderMouseClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "Código Produto";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.Width = 70;
            // 
            // col_Referencia
            // 
            this.col_Referencia.DataPropertyName = "referencia";
            this.col_Referencia.HeaderText = "Referência (referencia)";
            this.col_Referencia.Name = "col_Referencia";
            this.col_Referencia.ReadOnly = true;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "descricao";
            this.col_Descricao.HeaderText = "Descrição (descricao)";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_NCM
            // 
            this.col_NCM.DataPropertyName = "ncm";
            this.col_NCM.HeaderText = "NCM (ncm)";
            this.col_NCM.Name = "col_NCM";
            this.col_NCM.ReadOnly = true;
            this.col_NCM.Width = 70;
            // 
            // col_ValorCompra
            // 
            this.col_ValorCompra.DataPropertyName = "valorcompra";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_ValorCompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_ValorCompra.HeaderText = "Valor Compra (valorcompra)";
            this.col_ValorCompra.Name = "col_ValorCompra";
            this.col_ValorCompra.ReadOnly = true;
            // 
            // col_ValorVenda
            // 
            this.col_ValorVenda.DataPropertyName = "valorvenda";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_ValorVenda.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_ValorVenda.HeaderText = "Valor Venda (valorvenda)";
            this.col_ValorVenda.Name = "col_ValorVenda";
            this.col_ValorVenda.ReadOnly = true;
            // 
            // col_ID_TabelaValor
            // 
            this.col_ID_TabelaValor.DataPropertyName = "ID_TabelaValor";
            this.col_ID_TabelaValor.HeaderText = "ID_TabelaValor";
            this.col_ID_TabelaValor.Name = "col_ID_TabelaValor";
            this.col_ID_TabelaValor.Visible = false;
            // 
            // gb_CadastroProduto
            // 
            this.gb_CadastroProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_CadastroProduto.Controls.Add(this.tabControl1);
            this.gb_CadastroProduto.Location = new System.Drawing.Point(9, 418);
            this.gb_CadastroProduto.Name = "gb_CadastroProduto";
            this.gb_CadastroProduto.Size = new System.Drawing.Size(926, 199);
            this.gb_CadastroProduto.TabIndex = 20;
            this.gb_CadastroProduto.TabStop = false;
            this.gb_CadastroProduto.Text = "Informações Cadastro de Produtos";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 178);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ck_Ativo);
            this.tabPage3.Controls.Add(this.cb_ID_GrupoGrade);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.Label16);
            this.tabPage3.Controls.Add(this.cb_UnidadeTributavel);
            this.tabPage3.Controls.Add(this.Label34);
            this.tabPage3.Controls.Add(this.txt_Informacao);
            this.tabPage3.Controls.Add(this.Label10);
            this.tabPage3.Controls.Add(this.txt_Fabricante);
            this.tabPage3.Controls.Add(this.cb_ID_Tabela);
            this.tabPage3.Controls.Add(this.Label9);
            this.tabPage3.Controls.Add(this.bt_PesquisaConta);
            this.tabPage3.Controls.Add(this.mk_Conta);
            this.tabPage3.Controls.Add(this.Label3);
            this.tabPage3.Controls.Add(this.txt_DescricaoConta);
            this.tabPage3.Controls.Add(this.Label4);
            this.tabPage3.Controls.Add(this.txt_ID_Conta);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(911, 147);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Informações Produto";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // ck_Ativo
            // 
            this.ck_Ativo.AutoSize = true;
            this.ck_Ativo.Checked = true;
            this.ck_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Ativo.Location = new System.Drawing.Point(763, 74);
            this.ck_Ativo.Name = "ck_Ativo";
            this.ck_Ativo.Size = new System.Drawing.Size(96, 19);
            this.ck_Ativo.TabIndex = 34;
            this.ck_Ativo.Text = "Produto Ativo";
            this.ck_Ativo.UseVisualStyleBackColor = true;
            // 
            // cb_ID_GrupoGrade
            // 
            this.cb_ID_GrupoGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_GrupoGrade.FormattingEnabled = true;
            this.cb_ID_GrupoGrade.Location = new System.Drawing.Point(374, 26);
            this.cb_ID_GrupoGrade.Name = "cb_ID_GrupoGrade";
            this.cb_ID_GrupoGrade.Size = new System.Drawing.Size(230, 23);
            this.cb_ID_GrupoGrade.TabIndex = 30;
            this.cb_ID_GrupoGrade.Tag = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(370, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 15);
            this.label18.TabIndex = 111;
            this.label18.Text = "Grade";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(671, 55);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(54, 15);
            this.Label16.TabIndex = 56;
            this.Label16.Text = "Unidade";
            // 
            // cb_UnidadeTributavel
            // 
            this.cb_UnidadeTributavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UnidadeTributavel.FormattingEnabled = true;
            this.cb_UnidadeTributavel.Location = new System.Drawing.Point(675, 72);
            this.cb_UnidadeTributavel.Name = "cb_UnidadeTributavel";
            this.cb_UnidadeTributavel.Size = new System.Drawing.Size(81, 23);
            this.cb_UnidadeTributavel.TabIndex = 33;
            this.cb_UnidadeTributavel.Tag = "T";
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(613, 6);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(44, 15);
            this.Label34.TabIndex = 82;
            this.Label34.Text = "Tabela";
            // 
            // txt_Informacao
            // 
            this.txt_Informacao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Informacao.Location = new System.Drawing.Point(374, 118);
            this.txt_Informacao.MaxLength = 200;
            this.txt_Informacao.Name = "txt_Informacao";
            this.txt_Informacao.Size = new System.Drawing.Size(527, 21);
            this.txt_Informacao.TabIndex = 35;
            this.txt_Informacao.Tag = "T";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(370, 99);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(69, 15);
            this.Label10.TabIndex = 54;
            this.Label10.Text = "Informação";
            // 
            // txt_Fabricante
            // 
            this.txt_Fabricante.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Fabricante.Location = new System.Drawing.Point(374, 73);
            this.txt_Fabricante.MaxLength = 60;
            this.txt_Fabricante.Name = "txt_Fabricante";
            this.txt_Fabricante.Size = new System.Drawing.Size(293, 21);
            this.txt_Fabricante.TabIndex = 32;
            this.txt_Fabricante.Tag = "T";
            // 
            // cb_ID_Tabela
            // 
            this.cb_ID_Tabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Tabela.FormattingEnabled = true;
            this.cb_ID_Tabela.Location = new System.Drawing.Point(613, 26);
            this.cb_ID_Tabela.Name = "cb_ID_Tabela";
            this.cb_ID_Tabela.Size = new System.Drawing.Size(288, 23);
            this.cb_ID_Tabela.TabIndex = 31;
            this.cb_ID_Tabela.Tag = "T";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(370, 54);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(65, 15);
            this.Label9.TabIndex = 52;
            this.Label9.Text = "Fabricante";
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(87, 26);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 23;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // mk_Conta
            // 
            this.mk_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Conta.Location = new System.Drawing.Point(7, 27);
            this.mk_Conta.Mask = "00,00,00,00";
            this.mk_Conta.Name = "mk_Conta";
            this.mk_Conta.PromptChar = '0';
            this.mk_Conta.Size = new System.Drawing.Size(75, 21);
            this.mk_Conta.TabIndex = 22;
            this.mk_Conta.Tag = "T";
            this.mk_Conta.Leave += new System.EventHandler(this.mk_Conta_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 56);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(99, 15);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Descricao Conta";
            // 
            // txt_DescricaoConta
            // 
            this.txt_DescricaoConta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_DescricaoConta.Location = new System.Drawing.Point(7, 74);
            this.txt_DescricaoConta.MaxLength = 60;
            this.txt_DescricaoConta.Multiline = true;
            this.txt_DescricaoConta.Name = "txt_DescricaoConta";
            this.txt_DescricaoConta.ReadOnly = true;
            this.txt_DescricaoConta.Size = new System.Drawing.Size(359, 66);
            this.txt_DescricaoConta.TabIndex = 25;
            this.txt_DescricaoConta.TabStop = false;
            this.txt_DescricaoConta.Tag = "";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 6);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 15);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Cód. Grupo";
            // 
            // txt_ID_Conta
            // 
            this.txt_ID_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Conta.Enabled = false;
            this.txt_ID_Conta.Location = new System.Drawing.Point(62, 27);
            this.txt_ID_Conta.Name = "txt_ID_Conta";
            this.txt_ID_Conta.Size = new System.Drawing.Size(18, 21);
            this.txt_ID_Conta.TabIndex = 24;
            this.txt_ID_Conta.Tag = "T";
            // 
            // bt_Estrutura
            // 
            this.bt_Estrutura.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Estrutura.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Estrutura.Image = global::Sistema.UI.Properties.Resources.bt_NotaFiscal;
            this.bt_Estrutura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Estrutura.Location = new System.Drawing.Point(608, 17);
            this.bt_Estrutura.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Estrutura.Name = "bt_Estrutura";
            this.bt_Estrutura.Size = new System.Drawing.Size(189, 47);
            this.bt_Estrutura.TabIndex = 4;
            this.bt_Estrutura.Text = "MODELO DE TABELA";
            this.bt_Estrutura.UseVisualStyleBackColor = false;
            this.bt_Estrutura.Click += new System.EventHandler(this.bt_Estrutura_Click);
            // 
            // txt_ReferenciaP
            // 
            this.txt_ReferenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReferenciaP.Location = new System.Drawing.Point(8, 90);
            this.txt_ReferenciaP.MaxLength = 60;
            this.txt_ReferenciaP.Name = "txt_ReferenciaP";
            this.txt_ReferenciaP.Size = new System.Drawing.Size(150, 21);
            this.txt_ReferenciaP.TabIndex = 5;
            this.txt_ReferenciaP.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 106;
            this.label1.Text = "Referência";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 106;
            this.label2.Text = "Descrição";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(166, 90);
            this.txt_DescricaoP.MaxLength = 60;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(423, 21);
            this.txt_DescricaoP.TabIndex = 6;
            this.txt_DescricaoP.Tag = "T";
            // 
            // UI_Produto_AtualizaValorXLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_AtualizaValorXLS";
            this.Load += new System.EventHandler(this.UI_Produto_AtualizaValorXLS_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabela)).EndInit();
            this.gb_CadastroProduto.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog Pesquisaxls;
        internal System.Windows.Forms.Button bt_PesquisaXLS;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txt_Caminho;
        internal System.Windows.Forms.DataGridView dg_Tabela;
        private System.Windows.Forms.GroupBox gb_CadastroProduto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.MaskedTextBox mk_Conta;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_DescricaoConta;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_ID_Conta;
        internal System.Windows.Forms.TextBox txt_Fabricante;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txt_Informacao;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.ComboBox cb_UnidadeTributavel;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.ComboBox cb_ID_Tabela;
        internal System.Windows.Forms.ComboBox cb_ID_GrupoGrade;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_TabelaValor;
        internal System.Windows.Forms.Button bt_Estrutura;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ReferenciaP;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_Ativo;
    }
}

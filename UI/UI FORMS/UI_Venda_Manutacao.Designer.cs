namespace Sistema.UI
{
    partial class UI_Venda_Manutacao
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
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.txt_IDP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_Itens = new System.Windows.Forms.GroupBox();
            this.txt_Informacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Acrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.dg_Vendas = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Faturado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_NFe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Cancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.bt_Cancela = new System.Windows.Forms.Button();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Excluir = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Itens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Vendas)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.cb_NFe);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cb_Situacao);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.bt_Excluir);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.label45);
            this.TabPage1.Controls.Add(this.label46);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.Label52);
            this.TabPage1.Controls.Add(this.txt_IDP);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.label40);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.label4);
            this.TabPage1.Controls.Add(this.gb_Itens);
            this.TabPage1.Controls.Add(this.dg_Vendas);
            this.TabPage1.Controls.Add(this.txt_Total);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(9, 28);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(192, 23);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 9);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(77, 15);
            this.label45.TabIndex = 707;
            this.label45.Text = "Tipo Pessoa";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(205, 9);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 15);
            this.label46.TabIndex = 708;
            this.label46.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(209, 28);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(450, 23);
            this.cb_ID_Pessoa.TabIndex = 2;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Location = new System.Drawing.Point(6, 57);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(57, 15);
            this.Label52.TabIndex = 706;
            this.Label52.Text = "Nº Venda";
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(9, 77);
            this.txt_IDP.MaxLength = 14;
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(102, 21);
            this.txt_IDP.TabIndex = 10;
            this.txt_IDP.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 705;
            this.label6.Text = "Período";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(119, 76);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(208, 23);
            this.cb_Periodo.TabIndex = 11;
            this.cb_Periodo.Tag = "T";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(443, 86);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(14, 15);
            this.label40.TabIndex = 704;
            this.label40.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(465, 77);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 13;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(335, 77);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 12;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1013, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 703;
            this.label4.Text = "Valor Total";
            // 
            // gb_Itens
            // 
            this.gb_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Itens.Controls.Add(this.txt_Informacao);
            this.gb_Itens.Controls.Add(this.label2);
            this.gb_Itens.Controls.Add(this.dg_Itens);
            this.gb_Itens.Controls.Add(this.txt_ID);
            this.gb_Itens.Controls.Add(this.bt_Cancela);
            this.gb_Itens.Location = new System.Drawing.Point(7, 350);
            this.gb_Itens.Name = "gb_Itens";
            this.gb_Itens.Size = new System.Drawing.Size(924, 269);
            this.gb_Itens.TabIndex = 30;
            this.gb_Itens.TabStop = false;
            this.gb_Itens.Text = "Produtos";
            // 
            // txt_Informacao
            // 
            this.txt_Informacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Informacao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Informacao.Location = new System.Drawing.Point(76, 216);
            this.txt_Informacao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Informacao.MaxLength = 2000;
            this.txt_Informacao.Multiline = true;
            this.txt_Informacao.Name = "txt_Informacao";
            this.txt_Informacao.Size = new System.Drawing.Size(695, 45);
            this.txt_Informacao.TabIndex = 32;
            this.txt_Informacao.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 216);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 717;
            this.label2.Text = "Informação";
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Itens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Quantidade,
            this.col_ValorUnitario,
            this.col_Desconto,
            this.col_Acrescimo,
            this.col_ValorFinal,
            this.col_TipoSaida});
            this.dg_Itens.Location = new System.Drawing.Point(6, 21);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(918, 189);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 31;
            this.dg_Itens.TabStop = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "Código";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 70;
            // 
            // col_Descricao
            // 
            this.col_Descricao.DataPropertyName = "DescricaoProduto";
            this.col_Descricao.HeaderText = "Descrição do Produto";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            this.col_Descricao.Width = 300;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Quantidade.HeaderText = "Quant.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.Width = 70;
            // 
            // col_ValorUnitario
            // 
            this.col_ValorUnitario.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_ValorUnitario.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ValorUnitario.HeaderText = "Vlr. Unit.";
            this.col_ValorUnitario.Name = "col_ValorUnitario";
            this.col_ValorUnitario.ReadOnly = true;
            this.col_ValorUnitario.Width = 75;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Desconto.HeaderText = "Desconto";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 70;
            // 
            // col_Acrescimo
            // 
            this.col_Acrescimo.DataPropertyName = "Acrescimo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_Acrescimo.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Acrescimo.HeaderText = "Acréscimo";
            this.col_Acrescimo.Name = "col_Acrescimo";
            this.col_Acrescimo.ReadOnly = true;
            this.col_Acrescimo.Width = 70;
            // 
            // col_ValorFinal
            // 
            this.col_ValorFinal.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_ValorFinal.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ValorFinal.HeaderText = "Vlr. Final";
            this.col_ValorFinal.Name = "col_ValorFinal";
            this.col_ValorFinal.ReadOnly = true;
            this.col_ValorFinal.Width = 75;
            // 
            // col_TipoSaida
            // 
            this.col_TipoSaida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_TipoSaida.DataPropertyName = "DescricaoSaida";
            this.col_TipoSaida.HeaderText = "Saída";
            this.col_TipoSaida.Name = "col_TipoSaida";
            this.col_TipoSaida.ReadOnly = true;
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(8, 25);
            this.txt_ID.MaxLength = 14;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(39, 21);
            this.txt_ID.TabIndex = 696;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // dg_Vendas
            // 
            this.dg_Vendas.AllowUserToAddRows = false;
            this.dg_Vendas.AllowUserToDeleteRows = false;
            this.dg_Vendas.AllowUserToResizeColumns = false;
            this.dg_Vendas.AllowUserToResizeRows = false;
            this.dg_Vendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Vendas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Vendas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Vendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Vendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.Column6,
            this.col_ID_Venda,
            this.Column7,
            this.col_Complemento,
            this.col_Municipio,
            this.Column10,
            this.col_Faturado,
            this.col_NFe,
            this.col_Cancelado,
            this.col_ID_Pessoa,
            this.col_TipoPessoa,
            this.col_ID_UF});
            this.dg_Vendas.Location = new System.Drawing.Point(7, 111);
            this.dg_Vendas.MultiSelect = false;
            this.dg_Vendas.Name = "dg_Vendas";
            this.dg_Vendas.RowHeadersVisible = false;
            this.dg_Vendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Vendas.Size = new System.Drawing.Size(924, 231);
            this.dg_Vendas.StandardTab = true;
            this.dg_Vendas.TabIndex = 20;
            this.dg_Vendas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Vendas_CellPainting);
            this.dg_Vendas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Vendas_ColumnHeaderMouseClick);
            this.dg_Vendas.DoubleClick += new System.EventHandler(this.dg_Vendas_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Data";
            this.Column6.HeaderText = "Data";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 75;
            // 
            // col_ID_Venda
            // 
            this.col_ID_Venda.DataPropertyName = "ID_Venda";
            this.col_ID_Venda.HeaderText = "Nº Venda";
            this.col_ID_Venda.Name = "col_ID_Venda";
            this.col_ID_Venda.ReadOnly = true;
            this.col_ID_Venda.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Descricao";
            this.Column7.HeaderText = "Razão Social / Nome";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 250;
            // 
            // col_Complemento
            // 
            this.col_Complemento.DataPropertyName = "Complemento";
            this.col_Complemento.HeaderText = "Nome Fantasia";
            this.col_Complemento.Name = "col_Complemento";
            this.col_Complemento.ReadOnly = true;
            this.col_Complemento.Width = 150;
            // 
            // col_Municipio
            // 
            this.col_Municipio.DataPropertyName = "Municipio";
            this.col_Municipio.HeaderText = "Municipio";
            this.col_Municipio.Name = "col_Municipio";
            this.col_Municipio.ReadOnly = true;
            this.col_Municipio.Width = 180;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.DataPropertyName = "Informacao";
            this.Column10.HeaderText = "Informação";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // col_Faturado
            // 
            this.col_Faturado.DataPropertyName = "Faturado";
            this.col_Faturado.HeaderText = "Fatu.";
            this.col_Faturado.Name = "col_Faturado";
            this.col_Faturado.ReadOnly = true;
            this.col_Faturado.Width = 50;
            // 
            // col_NFe
            // 
            this.col_NFe.DataPropertyName = "NFe";
            this.col_NFe.HeaderText = "NF-e";
            this.col_NFe.Name = "col_NFe";
            this.col_NFe.ReadOnly = true;
            this.col_NFe.Width = 50;
            // 
            // col_Cancelado
            // 
            this.col_Cancelado.DataPropertyName = "Cancelado";
            this.col_Cancelado.HeaderText = "Cancelamento";
            this.col_Cancelado.Name = "col_Cancelado";
            this.col_Cancelado.Visible = false;
            // 
            // col_ID_Pessoa
            // 
            this.col_ID_Pessoa.DataPropertyName = "ID_Pessoa";
            this.col_ID_Pessoa.HeaderText = "ID_Pessoa";
            this.col_ID_Pessoa.Name = "col_ID_Pessoa";
            this.col_ID_Pessoa.ReadOnly = true;
            this.col_ID_Pessoa.Visible = false;
            // 
            // col_TipoPessoa
            // 
            this.col_TipoPessoa.DataPropertyName = "TipoPessoa";
            this.col_TipoPessoa.HeaderText = "TipoPessoa";
            this.col_TipoPessoa.Name = "col_TipoPessoa";
            this.col_TipoPessoa.ReadOnly = true;
            this.col_TipoPessoa.Visible = false;
            // 
            // col_ID_UF
            // 
            this.col_ID_UF.DataPropertyName = "ID_UF";
            this.col_ID_UF.HeaderText = "ID_UF";
            this.col_ID_UF.Name = "col_ID_UF";
            this.col_ID_UF.ReadOnly = true;
            this.col_ID_UF.Visible = false;
            // 
            // txt_Total
            // 
            this.txt_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Total.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(1016, 587);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(133, 28);
            this.txt_Total.TabIndex = 702;
            this.txt_Total.TabStop = false;
            this.txt_Total.Text = "0,00";
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bt_Cancela
            // 
            this.bt_Cancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Cancela.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Cancela.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancela.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Cancela.Location = new System.Drawing.Point(778, 216);
            this.bt_Cancela.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Cancela.Name = "bt_Cancela";
            this.bt_Cancela.Size = new System.Drawing.Size(141, 45);
            this.bt_Cancela.TabIndex = 40;
            this.bt_Cancela.Text = "CANCELAR\r\nVENDA";
            this.bt_Cancela.UseVisualStyleBackColor = false;
            this.bt_Cancela.Click += new System.EventHandler(this.bt_Cancela_Click);
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(770, 76);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(161, 23);
            this.cb_NFe.TabIndex = 17;
            this.cb_NFe.TabStop = false;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(766, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 712;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(574, 76);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 15;
            this.cb_Situacao.TabStop = false;
            this.cb_Situacao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 713;
            this.label1.Text = "Situação Financeira";
            // 
            // bt_Excluir
            // 
            this.bt_Excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Excluir.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Excluir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Excluir.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Excluir.Location = new System.Drawing.Point(1010, 426);
            this.bt_Excluir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Excluir.Name = "bt_Excluir";
            this.bt_Excluir.Size = new System.Drawing.Size(141, 50);
            this.bt_Excluir.TabIndex = 40;
            this.bt_Excluir.Text = "EXCLUIR\r\nVENDA";
            this.bt_Excluir.UseVisualStyleBackColor = false;
            this.bt_Excluir.Click += new System.EventHandler(this.bt_Excluir_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(276, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 714;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Venda_Manutacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Name = "UI_Venda_Manutacao";
            this.Load += new System.EventHandler(this.UI_Venda_Manutacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Venda_Manutacao_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_Manutacao_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Itens.ResumeLayout(false);
            this.gb_Itens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Vendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label45;
        internal System.Windows.Forms.Label label46;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.TextBox txt_IDP;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label label40;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.GroupBox gb_Itens;
        internal System.Windows.Forms.DataGridView dg_Itens;
        internal System.Windows.Forms.DataGridView dg_Vendas;
        internal System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Button bt_Cancela;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Acrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoSaida;
        internal System.Windows.Forms.TextBox txt_Informacao;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Excluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Municipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Faturado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_NFe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Cancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_UF;
        internal System.Windows.Forms.Label label27;
    }
}

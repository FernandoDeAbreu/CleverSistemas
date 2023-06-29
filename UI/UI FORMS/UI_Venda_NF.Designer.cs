namespace Sistema.UI
{
    partial class UI_Venda_NF
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
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Acrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Informacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Vendas = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_InformacaoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Parcelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoPagto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Produto = new System.Windows.Forms.GroupBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_ValorVenda = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label53 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.txt_IDVenda = new System.Windows.Forms.TextBox();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.DateTimePicker();
            this.mk_DataFinal = new System.Windows.Forms.DateTimePicker();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Vendas)).BeginInit();
            this.gb_Produto.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.cb_NFe);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cb_Situacao);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.Label53);
            this.TabPage1.Controls.Add(this.Label54);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.Label52);
            this.TabPage1.Controls.Add(this.txt_IDVenda);
            this.TabPage1.Controls.Add(this.txt_ValorVenda);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.gb_Produto);
            this.TabPage1.Controls.Add(this.dg_Vendas);
            this.TabPage1.Text = "NOTA FISCAL";
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Itens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Itens.CausesValidation = false;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Produto,
            this.col_Descricao_Produto,
            this.col_Quantidade,
            this.col_Valor,
            this.col_Acrescimo,
            this.col_Desconto,
            this.col_ValorFinal,
            this.col_ValorTotal,
            this.col_ValorMinimo,
            this.col_Informacao,
            this.col_TipoSaida});
            this.dg_Itens.Location = new System.Drawing.Point(3, 18);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(921, 200);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 15;
            this.dg_Itens.TabStop = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "Cód.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 40;
            // 
            // col_Descricao_Produto
            // 
            this.col_Descricao_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao_Produto.DataPropertyName = "DescricaoProduto";
            this.col_Descricao_Produto.HeaderText = "Descrição do Produto";
            this.col_Descricao_Produto.Name = "col_Descricao_Produto";
            this.col_Descricao_Produto.ReadOnly = true;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Quantidade.HeaderText = "Quant.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.Width = 50;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "ValorFinal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Valor.HeaderText = "Valor Unit.";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 85;
            // 
            // col_Acrescimo
            // 
            this.col_Acrescimo.DataPropertyName = "Acrescimo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_Acrescimo.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Acrescimo.HeaderText = "Acrés.";
            this.col_Acrescimo.Name = "col_Acrescimo";
            this.col_Acrescimo.ReadOnly = true;
            this.col_Acrescimo.Width = 45;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Desconto.HeaderText = "Desc.";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 45;
            // 
            // col_ValorFinal
            // 
            this.col_ValorFinal.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_ValorFinal.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ValorFinal.HeaderText = "Valor Final";
            this.col_ValorFinal.Name = "col_ValorFinal";
            this.col_ValorFinal.ReadOnly = true;
            this.col_ValorFinal.Width = 85;
            // 
            // col_ValorTotal
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.col_ValorTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_ValorTotal.HeaderText = "Total";
            this.col_ValorTotal.Name = "col_ValorTotal";
            this.col_ValorTotal.ReadOnly = true;
            this.col_ValorTotal.Width = 85;
            // 
            // col_ValorMinimo
            // 
            this.col_ValorMinimo.DataPropertyName = "ValorMinimo";
            this.col_ValorMinimo.HeaderText = "ValorMinimo";
            this.col_ValorMinimo.Name = "col_ValorMinimo";
            this.col_ValorMinimo.ReadOnly = true;
            this.col_ValorMinimo.Visible = false;
            this.col_ValorMinimo.Width = 80;
            // 
            // col_Informacao
            // 
            this.col_Informacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Informacao.DataPropertyName = "Informacao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_Informacao.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_Informacao.HeaderText = "Informação";
            this.col_Informacao.Name = "col_Informacao";
            this.col_Informacao.ReadOnly = true;
            // 
            // col_TipoSaida
            // 
            this.col_TipoSaida.DataPropertyName = "DescricaoVendaProduto";
            this.col_TipoSaida.HeaderText = "Tipo Saída";
            this.col_TipoSaida.Name = "col_TipoSaida";
            this.col_TipoSaida.ReadOnly = true;
            this.col_TipoSaida.Width = 150;
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
            this.col_ID,
            this.col_Data,
            this.col_DescricaoPessoa,
            this.col_InformacaoVenda,
            this.col_TipoPessoa,
            this.col_ID_Pessoa,
            this.col_ID_Pagamento,
            this.col_ID_Parcelamento,
            this.col_DescricaoPagto,
            this.col_Usuario});
            this.dg_Vendas.Location = new System.Drawing.Point(9, 124);
            this.dg_Vendas.MultiSelect = false;
            this.dg_Vendas.Name = "dg_Vendas";
            this.dg_Vendas.RowHeadersVisible = false;
            this.dg_Vendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Vendas.Size = new System.Drawing.Size(928, 221);
            this.dg_Vendas.StandardTab = true;
            this.dg_Vendas.TabIndex = 10;
            this.dg_Vendas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Vendas_CellPainting);
            this.dg_Vendas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Vendas_CellValueChanged);
            this.dg_Vendas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Vendas_ColumnHeaderMouseClick);
            this.dg_Vendas.DoubleClick += new System.EventHandler(this.dg_Vendas_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "Nº Venda";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Width = 85;
            // 
            // col_Data
            // 
            this.col_Data.DataPropertyName = "Data";
            this.col_Data.HeaderText = "Data";
            this.col_Data.Name = "col_Data";
            this.col_Data.ReadOnly = true;
            this.col_Data.Width = 70;
            // 
            // col_DescricaoPessoa
            // 
            this.col_DescricaoPessoa.DataPropertyName = "Descricao";
            this.col_DescricaoPessoa.HeaderText = "Pessoa";
            this.col_DescricaoPessoa.Name = "col_DescricaoPessoa";
            this.col_DescricaoPessoa.ReadOnly = true;
            this.col_DescricaoPessoa.Width = 300;
            // 
            // col_InformacaoVenda
            // 
            this.col_InformacaoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_InformacaoVenda.DataPropertyName = "Informacao";
            this.col_InformacaoVenda.HeaderText = "Informação";
            this.col_InformacaoVenda.Name = "col_InformacaoVenda";
            this.col_InformacaoVenda.ReadOnly = true;
            // 
            // col_TipoPessoa
            // 
            this.col_TipoPessoa.DataPropertyName = "TipoPessoa";
            this.col_TipoPessoa.HeaderText = "TipoPessoa";
            this.col_TipoPessoa.Name = "col_TipoPessoa";
            this.col_TipoPessoa.ReadOnly = true;
            this.col_TipoPessoa.Visible = false;
            // 
            // col_ID_Pessoa
            // 
            this.col_ID_Pessoa.DataPropertyName = "ID_Pessoa";
            this.col_ID_Pessoa.HeaderText = "ID_Pessoa";
            this.col_ID_Pessoa.Name = "col_ID_Pessoa";
            this.col_ID_Pessoa.ReadOnly = true;
            this.col_ID_Pessoa.Visible = false;
            // 
            // col_ID_Pagamento
            // 
            this.col_ID_Pagamento.DataPropertyName = "ID_Pagamento";
            this.col_ID_Pagamento.HeaderText = "ID_Pagamento";
            this.col_ID_Pagamento.Name = "col_ID_Pagamento";
            this.col_ID_Pagamento.ReadOnly = true;
            this.col_ID_Pagamento.Visible = false;
            // 
            // col_ID_Parcelamento
            // 
            this.col_ID_Parcelamento.DataPropertyName = "ID_Parcelamento";
            this.col_ID_Parcelamento.HeaderText = "ID_Parc";
            this.col_ID_Parcelamento.Name = "col_ID_Parcelamento";
            this.col_ID_Parcelamento.ReadOnly = true;
            this.col_ID_Parcelamento.Visible = false;
            // 
            // col_DescricaoPagto
            // 
            this.col_DescricaoPagto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoPagto.DataPropertyName = "PrevisaoPagto";
            this.col_DescricaoPagto.HeaderText = "Previsão Pagto";
            this.col_DescricaoPagto.Name = "col_DescricaoPagto";
            this.col_DescricaoPagto.ReadOnly = true;
            // 
            // col_Usuario
            // 
            this.col_Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Usuario.DataPropertyName = "UsuarioComissao";
            this.col_Usuario.HeaderText = "Vendedor";
            this.col_Usuario.Name = "col_Usuario";
            this.col_Usuario.ReadOnly = true;
            // 
            // gb_Produto
            // 
            this.gb_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Produto.Controls.Add(this.dg_Itens);
            this.gb_Produto.Controls.Add(this.txt_ID);
            this.gb_Produto.Location = new System.Drawing.Point(9, 351);
            this.gb_Produto.Name = "gb_Produto";
            this.gb_Produto.Size = new System.Drawing.Size(928, 223);
            this.gb_Produto.TabIndex = 11;
            this.gb_Produto.TabStop = false;
            this.gb_Produto.Text = "Produtos";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(7, 48);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(65, 21);
            this.txt_ID.TabIndex = 42;
            this.txt_ID.Tag = "T";
            // 
            // txt_ValorVenda
            // 
            this.txt_ValorVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorVenda.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorVenda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorVenda.Location = new System.Drawing.Point(999, 584);
            this.txt_ValorVenda.Name = "txt_ValorVenda";
            this.txt_ValorVenda.ReadOnly = true;
            this.txt_ValorVenda.Size = new System.Drawing.Size(149, 26);
            this.txt_ValorVenda.TabIndex = 20;
            this.txt_ValorVenda.TabStop = false;
            this.txt_ValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label23
            // 
            this.Label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(831, 590);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(102, 15);
            this.Label23.TabIndex = 102;
            this.Label23.Text = "Total Pedido (R$)";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(820, 99);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 147;
            this.Label25.Text = "à";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(16, 33);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(192, 23);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.Location = new System.Drawing.Point(13, 14);
            this.Label53.Name = "Label53";
            this.Label53.Size = new System.Drawing.Size(77, 15);
            this.Label53.TabIndex = 144;
            this.Label53.Text = "Tipo Pessoa";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Location = new System.Drawing.Point(212, 14);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(63, 15);
            this.Label54.TabIndex = 145;
            this.Label54.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(216, 33);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(450, 23);
            this.cb_ID_Pessoa.TabIndex = 2;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Location = new System.Drawing.Point(13, 74);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(57, 15);
            this.Label52.TabIndex = 143;
            this.Label52.Text = "Nº Venda";
            // 
            // txt_IDVenda
            // 
            this.txt_IDVenda.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDVenda.Location = new System.Drawing.Point(16, 94);
            this.txt_IDVenda.MaxLength = 14;
            this.txt_IDVenda.Name = "txt_IDVenda";
            this.txt_IDVenda.Size = new System.Drawing.Size(102, 21);
            this.txt_IDVenda.TabIndex = 3;
            this.txt_IDVenda.Tag = "T";
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(328, 93);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(188, 23);
            this.cb_NFe.TabIndex = 5;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 694;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(132, 93);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 4;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 695;
            this.label6.Text = "Situação Financeira";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Items.AddRange(new object[] {
            "EMISSÃO",
            "FATURAMENTO"});
            this.cb_Periodo.Location = new System.Drawing.Point(533, 93);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(176, 23);
            this.cb_Periodo.TabIndex = 6;
            this.cb_Periodo.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 697;
            this.label3.Text = "Período";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(283, 14);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 698;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mk_DataInicial.Location = new System.Drawing.Point(716, 94);
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 699;
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mk_DataFinal.Location = new System.Drawing.Point(835, 94);
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 700;
            // 
            // UI_Venda_NF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Name = "UI_Venda_NF";
            this.Activated += new System.EventHandler(this.UI_Venda_NF_Activated);
            this.Load += new System.EventHandler(this.UI_Venda_Fatura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Venda_Fatura_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_NF_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Vendas)).EndInit();
            this.gb_Produto.ResumeLayout(false);
            this.gb_Produto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dg_Itens;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Acrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Informacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoSaida;
        internal System.Windows.Forms.DataGridView dg_Vendas;
        private System.Windows.Forms.GroupBox gb_Produto;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.TextBox txt_ValorVenda;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.TextBox txt_IDVenda;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_InformacaoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Parcelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoPagto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Usuario;
        internal System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker mk_DataFinal;
        private System.Windows.Forms.DateTimePicker mk_DataInicial;
    }
}

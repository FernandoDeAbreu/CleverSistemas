namespace Sistema.UI
{
    partial class UI_Venda_Fatura
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
            this.txt_ValorPedido = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.mk_DataFatura = new System.Windows.Forms.MaskedTextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.cb_Conferencia = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
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
            this.TabPage1.Controls.Add(this.cb_Conferencia);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.txt_ValorPedido);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.mk_DataFatura);
            this.TabPage1.Controls.Add(this.Label27);
            this.TabPage1.Controls.Add(this.gb_Produto);
            this.TabPage1.Controls.Add(this.dg_Vendas);
            this.TabPage1.Text = "FATURAMENTO";
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
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
            this.dg_Itens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Itens.Location = new System.Drawing.Point(3, 17);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(922, 237);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 3;
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
            this.dg_Vendas.Location = new System.Drawing.Point(9, 56);
            this.dg_Vendas.MultiSelect = false;
            this.dg_Vendas.Name = "dg_Vendas";
            this.dg_Vendas.ReadOnly = true;
            this.dg_Vendas.RowHeadersVisible = false;
            this.dg_Vendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Vendas.Size = new System.Drawing.Size(928, 255);
            this.dg_Vendas.StandardTab = true;
            this.dg_Vendas.TabIndex = 1;
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
            this.gb_Produto.Location = new System.Drawing.Point(9, 317);
            this.gb_Produto.Name = "gb_Produto";
            this.gb_Produto.Size = new System.Drawing.Size(928, 257);
            this.gb_Produto.TabIndex = 2;
            this.gb_Produto.TabStop = false;
            this.gb_Produto.Text = "Produtos";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(9, 47);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(65, 21);
            this.txt_ID.TabIndex = 42;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_Pedido_TextChanged);
            // 
            // txt_ValorPedido
            // 
            this.txt_ValorPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorPedido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorPedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorPedido.Location = new System.Drawing.Point(999, 586);
            this.txt_ValorPedido.Name = "txt_ValorPedido";
            this.txt_ValorPedido.ReadOnly = true;
            this.txt_ValorPedido.Size = new System.Drawing.Size(149, 26);
            this.txt_ValorPedido.TabIndex = 11;
            this.txt_ValorPedido.TabStop = false;
            this.txt_ValorPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label23
            // 
            this.Label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(832, 579);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(102, 15);
            this.Label23.TabIndex = 102;
            this.Label23.Text = "Total Pedido (R$)";
            // 
            // mk_DataFatura
            // 
            this.mk_DataFatura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mk_DataFatura.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFatura.Location = new System.Drawing.Point(13, 597);
            this.mk_DataFatura.Mask = "00/00/0000";
            this.mk_DataFatura.Name = "mk_DataFatura";
            this.mk_DataFatura.PromptChar = ' ';
            this.mk_DataFatura.Size = new System.Drawing.Size(102, 21);
            this.mk_DataFatura.TabIndex = 10;
            this.mk_DataFatura.Tag = "T";
            this.mk_DataFatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFatura.ValidatingType = typeof(System.DateTime);
            // 
            // Label27
            // 
            this.Label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(9, 579);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(73, 15);
            this.Label27.TabIndex = 101;
            this.Label27.Text = "Data de Fat.";
            // 
            // cb_Conferencia
            // 
            this.cb_Conferencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Conferencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Conferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Conferencia.FormattingEnabled = true;
            this.cb_Conferencia.Location = new System.Drawing.Point(9, 25);
            this.cb_Conferencia.Name = "cb_Conferencia";
            this.cb_Conferencia.Size = new System.Drawing.Size(266, 23);
            this.cb_Conferencia.TabIndex = 103;
            this.cb_Conferencia.Tag = "T";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 5);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 15);
            this.Label3.TabIndex = 104;
            this.Label3.Text = "Conferência";
            // 
            // UI_Venda_Fatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Venda_Fatura";
            this.Load += new System.EventHandler(this.UI_Venda_Fatura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Venda_Fatura_KeyDown);
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
        internal System.Windows.Forms.TextBox txt_ValorPedido;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.MaskedTextBox mk_DataFatura;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.ComboBox cb_Conferencia;
        internal System.Windows.Forms.Label Label3;
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
    }
}

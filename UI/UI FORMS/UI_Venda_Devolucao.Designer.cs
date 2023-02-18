namespace Sistema.UI
{
    partial class UI_Venda_Devolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Venda_Devolucao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.gb_Produto = new System.Windows.Forms.GroupBox();
            this.txt_DescricaoProduto = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.bt_Produto = new System.Windows.Forms.Button();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.bt_Devolver = new System.Windows.Forms.Button();
            this.txt_ID_Produto = new System.Windows.Forms.TextBox();
            this.txt_InformacaoItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.txt_Barra = new System.Windows.Forms.TextBox();
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_ID_Tabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Informacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_QuantidadeDevolvida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_PesquisaVenda = new System.Windows.Forms.Button();
            this.gb_Pessoa = new System.Windows.Forms.GroupBox();
            this.ck_Faturado = new System.Windows.Forms.CheckBox();
            this.txt_Comprador = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.txt_informacao = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_Municipio = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.lb_DescricaoPessoa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.gb_Produto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            this.gb_Pessoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            this.TabPage1.Text = "CONFERÊNCIA";
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.gb_Produto);
            this.gb_Cadastro.Controls.Add(this.dg_Itens);
            this.gb_Cadastro.Controls.Add(this.bt_PesquisaVenda);
            this.gb_Cadastro.Controls.Add(this.gb_Pessoa);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // gb_Produto
            // 
            this.gb_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Produto.Controls.Add(this.txt_DescricaoProduto);
            this.gb_Produto.Controls.Add(this.Label12);
            this.gb_Produto.Controls.Add(this.bt_Produto);
            this.gb_Produto.Controls.Add(this.txt_Quantidade);
            this.gb_Produto.Controls.Add(this.bt_Devolver);
            this.gb_Produto.Controls.Add(this.txt_ID_Produto);
            this.gb_Produto.Controls.Add(this.txt_InformacaoItem);
            this.gb_Produto.Controls.Add(this.label3);
            this.gb_Produto.Controls.Add(this.Label20);
            this.gb_Produto.Controls.Add(this.txt_Barra);
            this.gb_Produto.Location = new System.Drawing.Point(7, 490);
            this.gb_Produto.Name = "gb_Produto";
            this.gb_Produto.Size = new System.Drawing.Size(925, 124);
            this.gb_Produto.TabIndex = 30;
            this.gb_Produto.TabStop = false;
            // 
            // txt_DescricaoProduto
            // 
            this.txt_DescricaoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_DescricaoProduto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_DescricaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescricaoProduto.Location = new System.Drawing.Point(367, 30);
            this.txt_DescricaoProduto.Name = "txt_DescricaoProduto";
            this.txt_DescricaoProduto.ReadOnly = true;
            this.txt_DescricaoProduto.Size = new System.Drawing.Size(516, 20);
            this.txt_DescricaoProduto.TabIndex = 34;
            this.txt_DescricaoProduto.Tag = "T";
            // 
            // Label12
            // 
            this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(8, 11);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(71, 15);
            this.Label12.TabIndex = 86;
            this.Label12.Text = "Quantidade";
            // 
            // bt_Produto
            // 
            this.bt_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Produto.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Produto.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Produto.Image = ((System.Drawing.Image)(resources.GetObject("bt_Produto.Image")));
            this.bt_Produto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Produto.Location = new System.Drawing.Point(233, 24);
            this.bt_Produto.Name = "bt_Produto";
            this.bt_Produto.Size = new System.Drawing.Size(127, 34);
            this.bt_Produto.TabIndex = 33;
            this.bt_Produto.TabStop = false;
            this.bt_Produto.Text = "PRODUTO (F10)";
            this.bt_Produto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Produto.UseVisualStyleBackColor = false;
            this.bt_Produto.Click += new System.EventHandler(this.bt_Produto_Click);
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Quantidade.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Quantidade.Location = new System.Drawing.Point(10, 30);
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(86, 21);
            this.txt_Quantidade.TabIndex = 31;
            this.txt_Quantidade.Tag = "T";
            this.txt_Quantidade.Text = "1,00";
            this.txt_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bt_Devolver
            // 
            this.bt_Devolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Devolver.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Devolver.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Devolver.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Devolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Devolver.Location = new System.Drawing.Point(734, 59);
            this.bt_Devolver.Name = "bt_Devolver";
            this.bt_Devolver.Size = new System.Drawing.Size(149, 36);
            this.bt_Devolver.TabIndex = 35;
            this.bt_Devolver.Text = "DEVOLVER";
            this.bt_Devolver.UseVisualStyleBackColor = false;
            this.bt_Devolver.Click += new System.EventHandler(this.bt_Conferir_Click);
            // 
            // txt_ID_Produto
            // 
            this.txt_ID_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ID_Produto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID_Produto.Location = new System.Drawing.Point(367, 30);
            this.txt_ID_Produto.Name = "txt_ID_Produto";
            this.txt_ID_Produto.ReadOnly = true;
            this.txt_ID_Produto.Size = new System.Drawing.Size(86, 21);
            this.txt_ID_Produto.TabIndex = 87;
            this.txt_ID_Produto.Tag = "T";
            // 
            // txt_InformacaoItem
            // 
            this.txt_InformacaoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_InformacaoItem.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InformacaoItem.Location = new System.Drawing.Point(9, 89);
            this.txt_InformacaoItem.Name = "txt_InformacaoItem";
            this.txt_InformacaoItem.Size = new System.Drawing.Size(574, 21);
            this.txt_InformacaoItem.TabIndex = 88;
            this.txt_InformacaoItem.Tag = "";
            this.txt_InformacaoItem.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 86;
            this.label3.Text = "Código / Barra (F3)";
            // 
            // Label20
            // 
            this.Label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(7, 70);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(69, 15);
            this.Label20.TabIndex = 85;
            this.Label20.Text = "Informação";
            this.Label20.Visible = false;
            // 
            // txt_Barra
            // 
            this.txt_Barra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Barra.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Barra.Location = new System.Drawing.Point(111, 30);
            this.txt_Barra.Name = "txt_Barra";
            this.txt_Barra.Size = new System.Drawing.Size(114, 21);
            this.txt_Barra.TabIndex = 32;
            this.txt_Barra.Tag = "T";
            this.txt_Barra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Barra_KeyDown);
            this.txt_Barra.Leave += new System.EventHandler(this.txt_Barra_Leave);
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
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Tabela,
            this.col_ID_Produto,
            this.col_ID_Grade,
            this.col_Descricao_Produto,
            this.col_Informacao,
            this.col_TipoSaida,
            this.col_Quantidade,
            this.col_QuantidadeDevolvida,
            this.col_ValorVenda});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Itens.DefaultCellStyle = dataGridViewCellStyle10;
            this.dg_Itens.Location = new System.Drawing.Point(7, 185);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(924, 290);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 20;
            this.dg_Itens.TabStop = false;
            // 
            // col_ID_Tabela
            // 
            this.col_ID_Tabela.DataPropertyName = "IDItem";
            this.col_ID_Tabela.HeaderText = "ID";
            this.col_ID_Tabela.Name = "col_ID_Tabela";
            this.col_ID_Tabela.ReadOnly = true;
            this.col_ID_Tabela.Visible = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "CÓD.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 40;
            // 
            // col_ID_Grade
            // 
            this.col_ID_Grade.DataPropertyName = "ID_Grade";
            this.col_ID_Grade.HeaderText = "ID_Grade";
            this.col_ID_Grade.Name = "col_ID_Grade";
            this.col_ID_Grade.ReadOnly = true;
            this.col_ID_Grade.Visible = false;
            // 
            // col_Descricao_Produto
            // 
            this.col_Descricao_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao_Produto.DataPropertyName = "DescricaoProduto";
            this.col_Descricao_Produto.HeaderText = "PRODUTO";
            this.col_Descricao_Produto.MinimumWidth = 200;
            this.col_Descricao_Produto.Name = "col_Descricao_Produto";
            this.col_Descricao_Produto.ReadOnly = true;
            // 
            // col_Informacao
            // 
            this.col_Informacao.DataPropertyName = "Informacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_Informacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Informacao.HeaderText = "INFORMAÇÃO";
            this.col_Informacao.Name = "col_Informacao";
            this.col_Informacao.ReadOnly = true;
            this.col_Informacao.Width = 200;
            // 
            // col_TipoSaida
            // 
            this.col_TipoSaida.DataPropertyName = "DescricaoSaida";
            this.col_TipoSaida.HeaderText = "SAÍDA";
            this.col_TipoSaida.Name = "col_TipoSaida";
            this.col_TipoSaida.ReadOnly = true;
            this.col_TipoSaida.Width = 150;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_Quantidade.HeaderText = "QUANTIDADE";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            // 
            // col_QuantidadeDevolvida
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.col_QuantidadeDevolvida.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_QuantidadeDevolvida.HeaderText = "QT. DEVOLVER";
            this.col_QuantidadeDevolvida.Name = "col_QuantidadeDevolvida";
            this.col_QuantidadeDevolvida.ReadOnly = true;
            this.col_QuantidadeDevolvida.Width = 150;
            // 
            // col_ValorVenda
            // 
            this.col_ValorVenda.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.col_ValorVenda.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_ValorVenda.HeaderText = "VALOR";
            this.col_ValorVenda.Name = "col_ValorVenda";
            this.col_ValorVenda.ReadOnly = true;
            // 
            // bt_PesquisaVenda
            // 
            this.bt_PesquisaVenda.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaVenda.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaVenda.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaVenda.Image")));
            this.bt_PesquisaVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaVenda.Location = new System.Drawing.Point(107, 30);
            this.bt_PesquisaVenda.Name = "bt_PesquisaVenda";
            this.bt_PesquisaVenda.Size = new System.Drawing.Size(164, 34);
            this.bt_PesquisaVenda.TabIndex = 2;
            this.bt_PesquisaVenda.TabStop = false;
            this.bt_PesquisaVenda.Text = "PESQUISAR (F5)";
            this.bt_PesquisaVenda.UseVisualStyleBackColor = false;
            this.bt_PesquisaVenda.Visible = false;
            this.bt_PesquisaVenda.Click += new System.EventHandler(this.bt_PesquisaVenda_Click);
            // 
            // gb_Pessoa
            // 
            this.gb_Pessoa.Controls.Add(this.ck_Faturado);
            this.gb_Pessoa.Controls.Add(this.txt_Comprador);
            this.gb_Pessoa.Controls.Add(this.label28);
            this.gb_Pessoa.Controls.Add(this.label1);
            this.gb_Pessoa.Controls.Add(this.Label18);
            this.gb_Pessoa.Controls.Add(this.mk_Data);
            this.gb_Pessoa.Controls.Add(this.txt_informacao);
            this.gb_Pessoa.Controls.Add(this.txt_Descricao);
            this.gb_Pessoa.Controls.Add(this.txt_Municipio);
            this.gb_Pessoa.Controls.Add(this.Label5);
            this.gb_Pessoa.Controls.Add(this.lb_DescricaoPessoa);
            this.gb_Pessoa.Location = new System.Drawing.Point(7, 70);
            this.gb_Pessoa.Name = "gb_Pessoa";
            this.gb_Pessoa.Size = new System.Drawing.Size(925, 109);
            this.gb_Pessoa.TabIndex = 5;
            this.gb_Pessoa.TabStop = false;
            // 
            // ck_Faturado
            // 
            this.ck_Faturado.AutoSize = true;
            this.ck_Faturado.Enabled = false;
            this.ck_Faturado.Location = new System.Drawing.Point(765, 32);
            this.ck_Faturado.Name = "ck_Faturado";
            this.ck_Faturado.Size = new System.Drawing.Size(112, 19);
            this.ck_Faturado.TabIndex = 124;
            this.ck_Faturado.Tag = "T";
            this.ck_Faturado.Text = "Venda Faturada";
            this.ck_Faturado.UseVisualStyleBackColor = true;
            // 
            // txt_Comprador
            // 
            this.txt_Comprador.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Comprador.Location = new System.Drawing.Point(740, 76);
            this.txt_Comprador.MaxLength = 200;
            this.txt_Comprador.Name = "txt_Comprador";
            this.txt_Comprador.ReadOnly = true;
            this.txt_Comprador.Size = new System.Drawing.Size(183, 21);
            this.txt_Comprador.TabIndex = 14;
            this.txt_Comprador.TabStop = false;
            this.txt_Comprador.Tag = "T";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(736, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 15);
            this.label28.TabIndex = 123;
            this.label28.Text = "Comprador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 85;
            this.label1.Text = "Data";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(7, 58);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(69, 15);
            this.Label18.TabIndex = 122;
            this.Label18.Text = "Informação";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mk_Data.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk_Data.Location = new System.Drawing.Point(587, 30);
            this.mk_Data.Mask = "00/00/0000 90:00";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.PromptChar = ' ';
            this.mk_Data.ReadOnly = true;
            this.mk_Data.Size = new System.Drawing.Size(171, 20);
            this.mk_Data.TabIndex = 12;
            this.mk_Data.TabStop = false;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            // 
            // txt_informacao
            // 
            this.txt_informacao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_informacao.Location = new System.Drawing.Point(10, 76);
            this.txt_informacao.MaxLength = 200;
            this.txt_informacao.Name = "txt_informacao";
            this.txt_informacao.ReadOnly = true;
            this.txt_informacao.Size = new System.Drawing.Size(721, 21);
            this.txt_informacao.TabIndex = 13;
            this.txt_informacao.TabStop = false;
            this.txt_informacao.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Descricao.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descricao.Location = new System.Drawing.Point(10, 30);
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.ReadOnly = true;
            this.txt_Descricao.Size = new System.Drawing.Size(390, 21);
            this.txt_Descricao.TabIndex = 10;
            this.txt_Descricao.TabStop = false;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_Municipio
            // 
            this.txt_Municipio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Municipio.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Municipio.Location = new System.Drawing.Point(408, 30);
            this.txt_Municipio.Name = "txt_Municipio";
            this.txt_Municipio.ReadOnly = true;
            this.txt_Municipio.Size = new System.Drawing.Size(171, 21);
            this.txt_Municipio.TabIndex = 11;
            this.txt_Municipio.TabStop = false;
            this.txt_Municipio.Tag = "T";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(405, 12);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "Cidade";
            // 
            // lb_DescricaoPessoa
            // 
            this.lb_DescricaoPessoa.AutoSize = true;
            this.lb_DescricaoPessoa.Location = new System.Drawing.Point(7, 13);
            this.lb_DescricaoPessoa.Name = "lb_DescricaoPessoa";
            this.lb_DescricaoPessoa.Size = new System.Drawing.Size(41, 15);
            this.lb_DescricaoPessoa.TabIndex = 26;
            this.lb_DescricaoPessoa.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 82;
            this.label2.Text = "Nº Venda";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ID.Location = new System.Drawing.Point(7, 32);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(91, 26);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.TabStop = false;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ID_KeyDown);
            // 
            // UI_Venda_Devolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Venda_Devolucao";
            this.Load += new System.EventHandler(this.UI_Venda_Conferencia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Venda_Conferencia_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_Conferencia_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.gb_Produto.ResumeLayout(false);
            this.gb_Produto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            this.gb_Pessoa.ResumeLayout(false);
            this.gb_Pessoa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Button bt_PesquisaVenda;
        internal System.Windows.Forms.TextBox txt_InformacaoItem;
        internal System.Windows.Forms.DataGridView dg_Itens;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.TextBox txt_Quantidade;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button bt_Devolver;
        internal System.Windows.Forms.TextBox txt_Barra;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox gb_Pessoa;
        internal System.Windows.Forms.TextBox txt_Comprador;
        internal System.Windows.Forms.Label label28;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.TextBox txt_informacao;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_Municipio;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lb_DescricaoPessoa;
        internal System.Windows.Forms.Button bt_Produto;
        internal System.Windows.Forms.TextBox txt_DescricaoProduto;
        internal System.Windows.Forms.TextBox txt_ID_Produto;
        private System.Windows.Forms.GroupBox gb_Produto;
        private System.Windows.Forms.CheckBox ck_Faturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Tabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Informacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_QuantidadeDevolvida;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorVenda;
    }
}

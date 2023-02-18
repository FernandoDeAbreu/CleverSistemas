namespace Sistema.UI
{
    partial class UI_Financeiro_Planejamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dg_Planejamento = new System.Windows.Forms.DataGridView();
            this.col_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ResumoParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_FluxoCaixa = new System.Windows.Forms.DataGridView();
            this.col_ContaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SaldoConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SaldoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Saldo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Limite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SaldoTotal = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.ck_LimiteVirtual = new System.Windows.Forms.CheckBox();
            this.ck_Conciliado = new System.Windows.Forms.CheckBox();
            this.gb_Pesquisa = new System.Windows.Forms.GroupBox();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_Conta = new System.Windows.Forms.MaskedTextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Planejamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_FluxoCaixa)).BeginInit();
            this.gb_Pesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.tabControl1);
            this.gb_Cadastro.Controls.Add(this.dg_FluxoCaixa);
            this.gb_Cadastro.Controls.Add(this.txt_Saldo);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.txt_Limite);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_SaldoTotal);
            this.gb_Cadastro.Controls.Add(this.Label8);
            this.gb_Cadastro.Controls.Add(this.ck_LimiteVirtual);
            this.gb_Cadastro.Controls.Add(this.ck_Conciliado);
            this.gb_Cadastro.Controls.Add(this.gb_Pesquisa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(7, 218);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(928, 402);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dg_Planejamento);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(920, 374);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "PLANEJAMENTO";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dg_Planejamento
            // 
            this.dg_Planejamento.AllowUserToAddRows = false;
            this.dg_Planejamento.AllowUserToDeleteRows = false;
            this.dg_Planejamento.AllowUserToResizeRows = false;
            this.dg_Planejamento.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Planejamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Planejamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Planejamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Conta,
            this.col_DescricaoConta,
            this.col_Pessoa,
            this.col_Documento,
            this.col_ResumoParcela,
            this.col_Vencimento,
            this.col_Credito,
            this.col_Debito,
            this.col_Saldo,
            this.col_Tipo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Planejamento.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_Planejamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Planejamento.GridColor = System.Drawing.Color.LightGray;
            this.dg_Planejamento.Location = new System.Drawing.Point(3, 3);
            this.dg_Planejamento.Name = "dg_Planejamento";
            this.dg_Planejamento.ReadOnly = true;
            this.dg_Planejamento.RowHeadersVisible = false;
            this.dg_Planejamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Planejamento.Size = new System.Drawing.Size(914, 368);
            this.dg_Planejamento.StandardTab = true;
            this.dg_Planejamento.TabIndex = 47;
            this.dg_Planejamento.Tag = "";
            this.dg_Planejamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_Planejamento_CellFormatting);
            this.dg_Planejamento.SelectionChanged += new System.EventHandler(this.dg_Planejamento_SelectionChanged);
            // 
            // col_Conta
            // 
            this.col_Conta.DataPropertyName = "Conta";
            this.col_Conta.HeaderText = "CONTA";
            this.col_Conta.Name = "col_Conta";
            this.col_Conta.ReadOnly = true;
            this.col_Conta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Conta.Width = 70;
            // 
            // col_DescricaoConta
            // 
            this.col_DescricaoConta.DataPropertyName = "DescricaoConta";
            this.col_DescricaoConta.HeaderText = "DESCRIÇÃO CONTA";
            this.col_DescricaoConta.Name = "col_DescricaoConta";
            this.col_DescricaoConta.ReadOnly = true;
            this.col_DescricaoConta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_DescricaoConta.Width = 150;
            // 
            // col_Pessoa
            // 
            this.col_Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Pessoa.DataPropertyName = "DescricaoPessoa";
            this.col_Pessoa.HeaderText = "PESSOA";
            this.col_Pessoa.Name = "col_Pessoa";
            this.col_Pessoa.ReadOnly = true;
            this.col_Pessoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Documento
            // 
            this.col_Documento.DataPropertyName = "Documento";
            this.col_Documento.HeaderText = "DOC.";
            this.col_Documento.Name = "col_Documento";
            this.col_Documento.ReadOnly = true;
            this.col_Documento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Documento.Width = 70;
            // 
            // col_ResumoParcela
            // 
            this.col_ResumoParcela.DataPropertyName = "ResumoParcela";
            this.col_ResumoParcela.HeaderText = "PARC.";
            this.col_ResumoParcela.Name = "col_ResumoParcela";
            this.col_ResumoParcela.ReadOnly = true;
            this.col_ResumoParcela.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ResumoParcela.Width = 45;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Vencimento.HeaderText = "VENCIMENTO";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Vencimento.Width = 80;
            // 
            // col_Credito
            // 
            this.col_Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Credito.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Credito.HeaderText = "RECEITAS";
            this.col_Credito.Name = "col_Credito";
            this.col_Credito.ReadOnly = true;
            this.col_Credito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Debito
            // 
            this.col_Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_Debito.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Debito.HeaderText = "DESPESAS";
            this.col_Debito.Name = "col_Debito";
            this.col_Debito.ReadOnly = true;
            this.col_Debito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Saldo
            // 
            this.col_Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Saldo.HeaderText = "SALDO";
            this.col_Saldo.Name = "col_Saldo";
            this.col_Saldo.ReadOnly = true;
            this.col_Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Saldo.Width = 120;
            // 
            // col_Tipo
            // 
            this.col_Tipo.DataPropertyName = "Tipo";
            this.col_Tipo.HeaderText = "Tipo";
            this.col_Tipo.Name = "col_Tipo";
            this.col_Tipo.ReadOnly = true;
            this.col_Tipo.Visible = false;
            // 
            // dg_FluxoCaixa
            // 
            this.dg_FluxoCaixa.AllowUserToAddRows = false;
            this.dg_FluxoCaixa.AllowUserToDeleteRows = false;
            this.dg_FluxoCaixa.AllowUserToResizeRows = false;
            this.dg_FluxoCaixa.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_FluxoCaixa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_FluxoCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_FluxoCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ContaDescricao,
            this.col_SaldoConta,
            this.col_Limite,
            this.col_SaldoTotal});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 8.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_FluxoCaixa.DefaultCellStyle = dataGridViewCellStyle9;
            this.dg_FluxoCaixa.Location = new System.Drawing.Point(7, 15);
            this.dg_FluxoCaixa.MultiSelect = false;
            this.dg_FluxoCaixa.Name = "dg_FluxoCaixa";
            this.dg_FluxoCaixa.RowHeadersVisible = false;
            this.dg_FluxoCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_FluxoCaixa.Size = new System.Drawing.Size(565, 150);
            this.dg_FluxoCaixa.StandardTab = true;
            this.dg_FluxoCaixa.TabIndex = 53;
            this.dg_FluxoCaixa.TabStop = false;
            this.dg_FluxoCaixa.Tag = "T";
            this.dg_FluxoCaixa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_FluxoCaixa_CellFormatting);
            this.dg_FluxoCaixa.SelectionChanged += new System.EventHandler(this.dg_FluxoCaixa_SelectionChanged);
            // 
            // col_ContaDescricao
            // 
            this.col_ContaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_ContaDescricao.DataPropertyName = "Conta";
            this.col_ContaDescricao.HeaderText = "CAIXA";
            this.col_ContaDescricao.Name = "col_ContaDescricao";
            this.col_ContaDescricao.ReadOnly = true;
            this.col_ContaDescricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_SaldoConta
            // 
            this.col_SaldoConta.DataPropertyName = "Saldo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.col_SaldoConta.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_SaldoConta.HeaderText = "SALDO";
            this.col_SaldoConta.Name = "col_SaldoConta";
            this.col_SaldoConta.ReadOnly = true;
            this.col_SaldoConta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_SaldoConta.Width = 80;
            // 
            // col_Limite
            // 
            this.col_Limite.DataPropertyName = "Limite";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.col_Limite.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_Limite.HeaderText = "LIMITE";
            this.col_Limite.Name = "col_Limite";
            this.col_Limite.ReadOnly = true;
            this.col_Limite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Limite.Width = 80;
            // 
            // col_SaldoTotal
            // 
            this.col_SaldoTotal.DataPropertyName = "SaldoTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.col_SaldoTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_SaldoTotal.HeaderText = "SALDO TOTAL";
            this.col_SaldoTotal.Name = "col_SaldoTotal";
            this.col_SaldoTotal.ReadOnly = true;
            this.col_SaldoTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_SaldoTotal.Width = 120;
            // 
            // txt_Saldo
            // 
            this.txt_Saldo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Saldo.Location = new System.Drawing.Point(11, 191);
            this.txt_Saldo.Name = "txt_Saldo";
            this.txt_Saldo.ReadOnly = true;
            this.txt_Saldo.Size = new System.Drawing.Size(124, 21);
            this.txt_Saldo.TabIndex = 52;
            this.txt_Saldo.Tag = "T";
            this.txt_Saldo.Text = "0,00";
            this.txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Saldo";
            // 
            // txt_Limite
            // 
            this.txt_Limite.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Limite.Location = new System.Drawing.Point(141, 191);
            this.txt_Limite.Name = "txt_Limite";
            this.txt_Limite.ReadOnly = true;
            this.txt_Limite.Size = new System.Drawing.Size(124, 21);
            this.txt_Limite.TabIndex = 52;
            this.txt_Limite.Tag = "T";
            this.txt_Limite.Text = "0,00";
            this.txt_Limite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Limite";
            // 
            // txt_SaldoTotal
            // 
            this.txt_SaldoTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_SaldoTotal.Location = new System.Drawing.Point(271, 191);
            this.txt_SaldoTotal.Name = "txt_SaldoTotal";
            this.txt_SaldoTotal.ReadOnly = true;
            this.txt_SaldoTotal.Size = new System.Drawing.Size(124, 21);
            this.txt_SaldoTotal.TabIndex = 52;
            this.txt_SaldoTotal.Tag = "T";
            this.txt_SaldoTotal.Text = "0,00";
            this.txt_SaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(268, 173);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(68, 15);
            this.Label8.TabIndex = 51;
            this.Label8.Text = "Saldo Total";
            // 
            // ck_LimiteVirtual
            // 
            this.ck_LimiteVirtual.Appearance = System.Windows.Forms.Appearance.Button;
            this.ck_LimiteVirtual.BackColor = System.Drawing.SystemColors.Control;
            this.ck_LimiteVirtual.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_LimiteVirtual.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.ck_LimiteVirtual.Location = new System.Drawing.Point(564, 171);
            this.ck_LimiteVirtual.Name = "ck_LimiteVirtual";
            this.ck_LimiteVirtual.Size = new System.Drawing.Size(113, 48);
            this.ck_LimiteVirtual.TabIndex = 49;
            this.ck_LimiteVirtual.Tag = "T";
            this.ck_LimiteVirtual.Text = "OCULTAR LIMITE";
            this.ck_LimiteVirtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ck_LimiteVirtual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ck_LimiteVirtual.UseVisualStyleBackColor = false;
            this.ck_LimiteVirtual.CheckedChanged += new System.EventHandler(this.ck_LimiteVirtual_CheckedChanged);
            // 
            // ck_Conciliado
            // 
            this.ck_Conciliado.Appearance = System.Windows.Forms.Appearance.Button;
            this.ck_Conciliado.BackColor = System.Drawing.SystemColors.Control;
            this.ck_Conciliado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_Conciliado.Image = global::Sistema.UI.Properties.Resources.bt_Selecionar;
            this.ck_Conciliado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ck_Conciliado.Location = new System.Drawing.Point(433, 171);
            this.ck_Conciliado.Name = "ck_Conciliado";
            this.ck_Conciliado.Size = new System.Drawing.Size(113, 48);
            this.ck_Conciliado.TabIndex = 50;
            this.ck_Conciliado.Tag = "T";
            this.ck_Conciliado.Text = "SOMENTE CONCILIADO";
            this.ck_Conciliado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ck_Conciliado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ck_Conciliado.UseVisualStyleBackColor = false;
            this.ck_Conciliado.CheckedChanged += new System.EventHandler(this.ck_Conciliado_CheckedChanged);
            // 
            // gb_Pesquisa
            // 
            this.gb_Pesquisa.Controls.Add(this.bt_PesquisaConta);
            this.gb_Pesquisa.Controls.Add(this.Label25);
            this.gb_Pesquisa.Controls.Add(this.mk_DataInicial);
            this.gb_Pesquisa.Controls.Add(this.Label22);
            this.gb_Pesquisa.Controls.Add(this.Label21);
            this.gb_Pesquisa.Controls.Add(this.mk_DataFinal);
            this.gb_Pesquisa.Controls.Add(this.mk_Conta);
            this.gb_Pesquisa.Location = new System.Drawing.Point(582, 15);
            this.gb_Pesquisa.Name = "gb_Pesquisa";
            this.gb_Pesquisa.Size = new System.Drawing.Size(348, 141);
            this.gb_Pesquisa.TabIndex = 48;
            this.gb_Pesquisa.TabStop = false;
            this.gb_Pesquisa.Text = "Filtro Pesquisa";
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaConta.Location = new System.Drawing.Point(99, 94);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 28);
            this.bt_PesquisaConta.TabIndex = 43;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(113, 48);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 38;
            this.Label25.Text = "à";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(10, 45);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 41;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(7, 26);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(117, 15);
            this.Label22.TabIndex = 39;
            this.Label22.Text = "Período Vencimento";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(7, 77);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(70, 15);
            this.Label21.TabIndex = 37;
            this.Label21.Text = "Cód. Grupo";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(128, 45);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 42;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_Conta
            // 
            this.mk_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Conta.Location = new System.Drawing.Point(10, 96);
            this.mk_Conta.Mask = "00,00,00,00";
            this.mk_Conta.Name = "mk_Conta";
            this.mk_Conta.PromptChar = '0';
            this.mk_Conta.Size = new System.Drawing.Size(81, 21);
            this.mk_Conta.TabIndex = 40;
            this.mk_Conta.Tag = "T";
            // 
            // UI_Financeiro_Planejamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Financeiro_Planejamento";
            this.Load += new System.EventHandler(this.UI_Financeiro_Planejamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Financeiro_Planejamento_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Planejamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_FluxoCaixa)).EndInit();
            this.gb_Pesquisa.ResumeLayout(false);
            this.gb_Pesquisa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.TextBox txt_SaldoTotal;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.CheckBox ck_LimiteVirtual;
        private System.Windows.Forms.CheckBox ck_Conciliado;
        internal System.Windows.Forms.DataGridView dg_Planejamento;
        private System.Windows.Forms.GroupBox gb_Pesquisa;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_Conta;
        internal System.Windows.Forms.DataGridView dg_FluxoCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ContaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SaldoConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SaldoTotal;
        internal System.Windows.Forms.TextBox txt_Limite;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Saldo;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ResumoParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Tipo;
    }
}

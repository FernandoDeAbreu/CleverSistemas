namespace Sistema.UI
{
    partial class UI_Produto_Desconto_Atacado
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
            this.bt_Adicionar = new System.Windows.Forms.Button();
            this.dg_Produto = new System.Windows.Forms.DataGridView();
            this.col_ID_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Qt_Minima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Qt_Maxima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_ID_Produto = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_Quantidade_Minima = new System.Windows.Forms.TextBox();
            this.txt_Quantidade_Maxima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Desconto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Remove = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_DescontoTodos = new System.Windows.Forms.Button();
            this.bt_DescontoUnico = new System.Windows.Forms.Button();
            this.txt_DescontoPessoa = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.cb_ID_TipoDesconto = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.dg_Desconto = new System.Windows.Forms.DataGridView();
            this.col_DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_TipoDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescontoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_DescontoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_ProdutoDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Usuario = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Desconto)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label17);
            this.TabPage1.Controls.Add(this.cb_ID_Produto);
            this.TabPage1.Controls.Add(this.label16);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.txt_Desconto);
            this.TabPage1.Controls.Add(this.txt_Quantidade_Maxima);
            this.TabPage1.Controls.Add(this.txt_Quantidade_Minima);
            this.TabPage1.Controls.Add(this.bt_Remove);
            this.TabPage1.Controls.Add(this.bt_Adicionar);
            this.TabPage1.Controls.Add(this.dg_Produto);
            this.TabPage1.Text = "DESCONTO ATACADO";
            // 
            // tabctl
            // 
            this.tabctl.Controls.Add(this.tabPage3);
            this.tabctl.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage2, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage1, 0);
            // 
            // bt_Adicionar
            // 
            this.bt_Adicionar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adicionar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adicionar.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adicionar.Location = new System.Drawing.Point(776, 27);
            this.bt_Adicionar.Name = "bt_Adicionar";
            this.bt_Adicionar.Size = new System.Drawing.Size(159, 43);
            this.bt_Adicionar.TabIndex = 5;
            this.bt_Adicionar.Text = "ADICIONAR PRODUTO";
            this.bt_Adicionar.UseVisualStyleBackColor = false;
            this.bt_Adicionar.Click += new System.EventHandler(this.bt_Adicionar_Click);
            // 
            // dg_Produto
            // 
            this.dg_Produto.AllowUserToAddRows = false;
            this.dg_Produto.AllowUserToDeleteRows = false;
            this.dg_Produto.AllowUserToResizeColumns = false;
            this.dg_Produto.AllowUserToResizeRows = false;
            this.dg_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Produto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Produto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Desconto,
            this.col_Descricao,
            this.col_Referencia,
            this.col_Qt_Minima,
            this.col_Qt_Maxima,
            this.col_Desconto});
            this.dg_Produto.Location = new System.Drawing.Point(5, 74);
            this.dg_Produto.MultiSelect = false;
            this.dg_Produto.Name = "dg_Produto";
            this.dg_Produto.ReadOnly = true;
            this.dg_Produto.RowHeadersVisible = false;
            this.dg_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Produto.Size = new System.Drawing.Size(928, 543);
            this.dg_Produto.TabIndex = 722;
            // 
            // col_ID_Desconto
            // 
            this.col_ID_Desconto.DataPropertyName = "ID";
            this.col_ID_Desconto.HeaderText = "ID";
            this.col_ID_Desconto.Name = "col_ID_Desconto";
            this.col_ID_Desconto.ReadOnly = true;
            this.col_ID_Desconto.Visible = false;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "PRODUTO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_Referencia
            // 
            this.col_Referencia.DataPropertyName = "Referencia";
            this.col_Referencia.HeaderText = "REF.";
            this.col_Referencia.Name = "col_Referencia";
            this.col_Referencia.ReadOnly = true;
            // 
            // col_Qt_Minima
            // 
            this.col_Qt_Minima.DataPropertyName = "Quantidade_Minima";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.col_Qt_Minima.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Qt_Minima.HeaderText = "QUANTIDADE MÍNIMA";
            this.col_Qt_Minima.Name = "col_Qt_Minima";
            this.col_Qt_Minima.ReadOnly = true;
            this.col_Qt_Minima.Width = 150;
            // 
            // col_Qt_Maxima
            // 
            this.col_Qt_Maxima.DataPropertyName = "Quantidade_Maxima";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_Qt_Maxima.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Qt_Maxima.HeaderText = "QUANTIDADE MÁXIMA";
            this.col_Qt_Maxima.Name = "col_Qt_Maxima";
            this.col_Qt_Maxima.ReadOnly = true;
            this.col_Qt_Maxima.Width = 150;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Desconto.HeaderText = "DESCONTO (%)";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 150;
            // 
            // cb_ID_Produto
            // 
            this.cb_ID_Produto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Produto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Produto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Produto.FormattingEnabled = true;
            this.cb_ID_Produto.Location = new System.Drawing.Point(9, 36);
            this.cb_ID_Produto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Produto.Name = "cb_ID_Produto";
            this.cb_ID_Produto.Size = new System.Drawing.Size(473, 23);
            this.cb_ID_Produto.TabIndex = 1;
            this.cb_ID_Produto.Tag = "T";
            this.cb_ID_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_Produto_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 15);
            this.label16.TabIndex = 726;
            this.label16.Text = "Descrição";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(488, 19);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(65, 15);
            this.Label5.TabIndex = 725;
            this.Label5.Text = "Qt. Mínima";
            // 
            // txt_Quantidade_Minima
            // 
            this.txt_Quantidade_Minima.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Quantidade_Minima.Location = new System.Drawing.Point(491, 39);
            this.txt_Quantidade_Minima.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Quantidade_Minima.MaxLength = 15;
            this.txt_Quantidade_Minima.Name = "txt_Quantidade_Minima";
            this.txt_Quantidade_Minima.Size = new System.Drawing.Size(89, 21);
            this.txt_Quantidade_Minima.TabIndex = 2;
            this.txt_Quantidade_Minima.Tag = "T";
            this.txt_Quantidade_Minima.Text = "0,000";
            this.txt_Quantidade_Minima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Quantidade_Minima.Leave += new System.EventHandler(this.txt_Quantidade_Minima_Leave);
            // 
            // txt_Quantidade_Maxima
            // 
            this.txt_Quantidade_Maxima.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Quantidade_Maxima.Location = new System.Drawing.Point(586, 39);
            this.txt_Quantidade_Maxima.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Quantidade_Maxima.MaxLength = 15;
            this.txt_Quantidade_Maxima.Name = "txt_Quantidade_Maxima";
            this.txt_Quantidade_Maxima.Size = new System.Drawing.Size(89, 21);
            this.txt_Quantidade_Maxima.TabIndex = 3;
            this.txt_Quantidade_Maxima.Tag = "T";
            this.txt_Quantidade_Maxima.Text = "0,000";
            this.txt_Quantidade_Maxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Quantidade_Maxima.Leave += new System.EventHandler(this.txt_Quantidade_Maxima_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 725;
            this.label1.Text = "Qt. Máxima";
            // 
            // txt_Desconto
            // 
            this.txt_Desconto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Desconto.Location = new System.Drawing.Point(680, 39);
            this.txt_Desconto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Desconto.MaxLength = 15;
            this.txt_Desconto.Name = "txt_Desconto";
            this.txt_Desconto.Size = new System.Drawing.Size(89, 21);
            this.txt_Desconto.TabIndex = 4;
            this.txt_Desconto.Tag = "T";
            this.txt_Desconto.Text = "0,00";
            this.txt_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Desconto.Leave += new System.EventHandler(this.txt_Desconto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 725;
            this.label2.Text = "Desconto (%)";
            // 
            // bt_Remove
            // 
            this.bt_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Remove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Remove.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Remove.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Remove.Location = new System.Drawing.Point(1118, 74);
            this.bt_Remove.Name = "bt_Remove";
            this.bt_Remove.Size = new System.Drawing.Size(33, 30);
            this.bt_Remove.TabIndex = 721;
            this.bt_Remove.UseVisualStyleBackColor = false;
            this.bt_Remove.Click += new System.EventHandler(this.bt_Remove_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(76, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 15);
            this.label17.TabIndex = 727;
            this.label17.Text = "F10 (Pesquisa avançada)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gb_Cadastro);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DESCONTO PERSONALIZADO";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label4);
            this.gb_Cadastro.Controls.Add(this.bt_DescontoTodos);
            this.gb_Cadastro.Controls.Add(this.bt_DescontoUnico);
            this.gb_Cadastro.Controls.Add(this.txt_DescontoPessoa);
            this.gb_Cadastro.Controls.Add(this.label43);
            this.gb_Cadastro.Controls.Add(this.cb_ID_TipoDesconto);
            this.gb_Cadastro.Controls.Add(this.label52);
            this.gb_Cadastro.Controls.Add(this.dg_Desconto);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.lb_Usuario);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Controls.Add(this.cb_TipoPessoa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(3, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(936, 620);
            this.gb_Cadastro.TabIndex = 1;
            this.gb_Cadastro.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(75, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 15);
            this.label4.TabIndex = 728;
            this.label4.Text = "F7 (Pesquisa avançada)";
            // 
            // bt_DescontoTodos
            // 
            this.bt_DescontoTodos.BackColor = System.Drawing.SystemColors.Control;
            this.bt_DescontoTodos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DescontoTodos.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_DescontoTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_DescontoTodos.Location = new System.Drawing.Point(772, 72);
            this.bt_DescontoTodos.Name = "bt_DescontoTodos";
            this.bt_DescontoTodos.Size = new System.Drawing.Size(131, 49);
            this.bt_DescontoTodos.TabIndex = 11;
            this.bt_DescontoTodos.Text = "TODOS";
            this.bt_DescontoTodos.UseVisualStyleBackColor = false;
            this.bt_DescontoTodos.Click += new System.EventHandler(this.bt_DescontoTodos_Click);
            // 
            // bt_DescontoUnico
            // 
            this.bt_DescontoUnico.BackColor = System.Drawing.SystemColors.Control;
            this.bt_DescontoUnico.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DescontoUnico.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_DescontoUnico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_DescontoUnico.Location = new System.Drawing.Point(772, 15);
            this.bt_DescontoUnico.Name = "bt_DescontoUnico";
            this.bt_DescontoUnico.Size = new System.Drawing.Size(131, 49);
            this.bt_DescontoUnico.TabIndex = 10;
            this.bt_DescontoUnico.Text = "ÚNICO";
            this.bt_DescontoUnico.UseVisualStyleBackColor = false;
            this.bt_DescontoUnico.Click += new System.EventHandler(this.bt_DescontoUnico_Click);
            // 
            // txt_DescontoPessoa
            // 
            this.txt_DescontoPessoa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescontoPessoa.Location = new System.Drawing.Point(651, 58);
            this.txt_DescontoPessoa.Name = "txt_DescontoPessoa";
            this.txt_DescontoPessoa.Size = new System.Drawing.Size(93, 21);
            this.txt_DescontoPessoa.TabIndex = 7;
            this.txt_DescontoPessoa.Tag = "T";
            this.txt_DescontoPessoa.Text = "0,00";
            this.txt_DescontoPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(645, 43);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(60, 15);
            this.label43.TabIndex = 116;
            this.label43.Text = "Desconto";
            // 
            // cb_ID_TipoDesconto
            // 
            this.cb_ID_TipoDesconto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_TipoDesconto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_TipoDesconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_TipoDesconto.FormattingEnabled = true;
            this.cb_ID_TipoDesconto.Location = new System.Drawing.Point(467, 58);
            this.cb_ID_TipoDesconto.Name = "cb_ID_TipoDesconto";
            this.cb_ID_TipoDesconto.Size = new System.Drawing.Size(175, 23);
            this.cb_ID_TipoDesconto.TabIndex = 5;
            this.cb_ID_TipoDesconto.Tag = "T";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(463, 39);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(87, 15);
            this.label52.TabIndex = 115;
            this.label52.Text = "Tipo Desconto";
            // 
            // dg_Desconto
            // 
            this.dg_Desconto.AllowUserToAddRows = false;
            this.dg_Desconto.AllowUserToDeleteRows = false;
            this.dg_Desconto.AllowUserToResizeColumns = false;
            this.dg_Desconto.AllowUserToResizeRows = false;
            this.dg_Desconto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Desconto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Desconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Desconto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Desconto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_DescricaoProduto,
            this.col_TipoDesconto,
            this.col_ID_TipoDesconto,
            this.col_DescontoPessoa,
            this.col_ID_DescontoPessoa,
            this.col_ID_ProdutoDesconto});
            this.dg_Desconto.Location = new System.Drawing.Point(7, 132);
            this.dg_Desconto.MultiSelect = false;
            this.dg_Desconto.Name = "dg_Desconto";
            this.dg_Desconto.ReadOnly = true;
            this.dg_Desconto.RowHeadersVisible = false;
            this.dg_Desconto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Desconto.Size = new System.Drawing.Size(922, 482);
            this.dg_Desconto.StandardTab = true;
            this.dg_Desconto.TabIndex = 40;
            // 
            // col_DescricaoProduto
            // 
            this.col_DescricaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoProduto.DataPropertyName = "Descricao";
            this.col_DescricaoProduto.HeaderText = "PRODUTO";
            this.col_DescricaoProduto.Name = "col_DescricaoProduto";
            this.col_DescricaoProduto.ReadOnly = true;
            // 
            // col_TipoDesconto
            // 
            this.col_TipoDesconto.DataPropertyName = "TipoDesconto";
            this.col_TipoDesconto.HeaderText = "TIPO DESCONTO";
            this.col_TipoDesconto.Name = "col_TipoDesconto";
            this.col_TipoDesconto.ReadOnly = true;
            this.col_TipoDesconto.Width = 150;
            // 
            // col_ID_TipoDesconto
            // 
            this.col_ID_TipoDesconto.DataPropertyName = "Tipo";
            this.col_ID_TipoDesconto.HeaderText = "ID_TipoDesconto";
            this.col_ID_TipoDesconto.Name = "col_ID_TipoDesconto";
            this.col_ID_TipoDesconto.ReadOnly = true;
            this.col_ID_TipoDesconto.Visible = false;
            // 
            // col_DescontoPessoa
            // 
            this.col_DescontoPessoa.DataPropertyName = "DESCONTO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_DescontoPessoa.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_DescontoPessoa.HeaderText = "DESCONTO";
            this.col_DescontoPessoa.Name = "col_DescontoPessoa";
            this.col_DescontoPessoa.ReadOnly = true;
            this.col_DescontoPessoa.Width = 80;
            // 
            // col_ID_DescontoPessoa
            // 
            this.col_ID_DescontoPessoa.DataPropertyName = "ID";
            this.col_ID_DescontoPessoa.HeaderText = "ID";
            this.col_ID_DescontoPessoa.Name = "col_ID_DescontoPessoa";
            this.col_ID_DescontoPessoa.ReadOnly = true;
            this.col_ID_DescontoPessoa.Visible = false;
            // 
            // col_ID_ProdutoDesconto
            // 
            this.col_ID_ProdutoDesconto.DataPropertyName = "ID_Produto";
            this.col_ID_ProdutoDesconto.HeaderText = "ID_Produto";
            this.col_ID_ProdutoDesconto.Name = "col_ID_ProdutoDesconto";
            this.col_ID_ProdutoDesconto.ReadOnly = true;
            this.col_ID_ProdutoDesconto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 113;
            this.label3.Text = "Descrição";
            // 
            // lb_Usuario
            // 
            this.lb_Usuario.AutoSize = true;
            this.lb_Usuario.Location = new System.Drawing.Point(3, 20);
            this.lb_Usuario.Name = "lb_Usuario";
            this.lb_Usuario.Size = new System.Drawing.Size(77, 15);
            this.lb_Usuario.TabIndex = 113;
            this.lb_Usuario.Text = "Tipo Pessoa";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(7, 91);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(401, 23);
            this.cb_ID_Pessoa.TabIndex = 2;
            this.cb_ID_Pessoa.Tag = "T";
            this.cb_ID_Pessoa.Leave += new System.EventHandler(this.cb_ID_Pessoa_Leave);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(7, 41);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(203, 23);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // UI_Produto_Desconto_Atacado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Desconto_Atacado";
            this.Load += new System.EventHandler(this.UI_Produto_Desconto_Atacado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Desconto_Atacado_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Desconto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button bt_Adicionar;
        internal System.Windows.Forms.DataGridView dg_Produto;
        internal System.Windows.Forms.ComboBox cb_ID_Produto;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_Desconto;
        internal System.Windows.Forms.TextBox txt_Quantidade_Maxima;
        internal System.Windows.Forms.TextBox txt_Quantidade_Minima;
        internal System.Windows.Forms.Button bt_Remove;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Qt_Minima;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Qt_Maxima;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        private System.Windows.Forms.Button bt_DescontoTodos;
        internal System.Windows.Forms.Button bt_DescontoUnico;
        internal System.Windows.Forms.TextBox txt_DescontoPessoa;
        internal System.Windows.Forms.Label label43;
        internal System.Windows.Forms.ComboBox cb_ID_TipoDesconto;
        internal System.Windows.Forms.Label label52;
        internal System.Windows.Forms.DataGridView dg_Desconto;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lb_Usuario;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_TipoDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescontoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_DescontoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_ProdutoDesconto;
    }
}

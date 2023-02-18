namespace Sistema.UI
{
    partial class UI_Produto_Balanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Balanco));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.ck_ConsultaInversa = new System.Windows.Forms.CheckBox();
            this.ck_ListaProduto = new System.Windows.Forms.CheckBox();
            this.bt_PesquisaGrupoP = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.cb_TipoP = new System.Windows.Forms.ComboBox();
            this.txt_BarraP = new System.Windows.Forms.TextBox();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.txt_IDP = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_InfoAdicional = new System.Windows.Forms.TextBox();
            this.txt_FabricanteP = new System.Windows.Forms.TextBox();
            this.txt_ReferenciaP = new System.Windows.Forms.TextBox();
            this.lb_Info_Adicional = new System.Windows.Forms.Label();
            this.Label45 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_Cod_GrupoP = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.dg_Estoque = new System.Windows.Forms.DataGridView();
            this.col_ID_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Barra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueIdeal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_QtAferido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pesquisa_Arquivo = new System.Windows.Forms.OpenFileDialog();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Estoque)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.ck_ConsultaInversa);
            this.gb_Cadastro.Controls.Add(this.ck_ListaProduto);
            this.gb_Cadastro.Controls.Add(this.bt_PesquisaGrupoP);
            this.gb_Cadastro.Controls.Add(this.label29);
            this.gb_Cadastro.Controls.Add(this.label24);
            this.gb_Cadastro.Controls.Add(this.cb_Situacao);
            this.gb_Cadastro.Controls.Add(this.cb_TipoP);
            this.gb_Cadastro.Controls.Add(this.txt_BarraP);
            this.gb_Cadastro.Controls.Add(this.txt_DescricaoP);
            this.gb_Cadastro.Controls.Add(this.txt_IDP);
            this.gb_Cadastro.Controls.Add(this.Label51);
            this.gb_Cadastro.Controls.Add(this.txt_InfoAdicional);
            this.gb_Cadastro.Controls.Add(this.txt_FabricanteP);
            this.gb_Cadastro.Controls.Add(this.txt_ReferenciaP);
            this.gb_Cadastro.Controls.Add(this.lb_Info_Adicional);
            this.gb_Cadastro.Controls.Add(this.Label45);
            this.gb_Cadastro.Controls.Add(this.label30);
            this.gb_Cadastro.Controls.Add(this.Label38);
            this.gb_Cadastro.Controls.Add(this.Label44);
            this.gb_Cadastro.Controls.Add(this.mk_Cod_GrupoP);
            this.gb_Cadastro.Controls.Add(this.Label37);
            this.gb_Cadastro.Controls.Add(this.dg_Estoque);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // ck_ConsultaInversa
            // 
            this.ck_ConsultaInversa.AutoSize = true;
            this.ck_ConsultaInversa.Location = new System.Drawing.Point(822, 79);
            this.ck_ConsultaInversa.Name = "ck_ConsultaInversa";
            this.ck_ConsultaInversa.Size = new System.Drawing.Size(119, 19);
            this.ck_ConsultaInversa.TabIndex = 26;
            this.ck_ConsultaInversa.Text = "Consulta inversa";
            this.ck_ConsultaInversa.UseVisualStyleBackColor = true;
            // 
            // ck_ListaProduto
            // 
            this.ck_ListaProduto.AutoSize = true;
            this.ck_ListaProduto.Location = new System.Drawing.Point(701, 80);
            this.ck_ListaProduto.Name = "ck_ListaProduto";
            this.ck_ListaProduto.Size = new System.Drawing.Size(123, 19);
            this.ck_ListaProduto.TabIndex = 25;
            this.ck_ListaProduto.Text = "Incluir todos itens";
            this.ck_ListaProduto.UseVisualStyleBackColor = true;
            // 
            // bt_PesquisaGrupoP
            // 
            this.bt_PesquisaGrupoP.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaGrupoP.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaGrupoP.Image")));
            this.bt_PesquisaGrupoP.Location = new System.Drawing.Point(99, 76);
            this.bt_PesquisaGrupoP.Name = "bt_PesquisaGrupoP";
            this.bt_PesquisaGrupoP.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaGrupoP.TabIndex = 7;
            this.bt_PesquisaGrupoP.UseVisualStyleBackColor = false;
            this.bt_PesquisaGrupoP.Click += new System.EventHandler(this.bt_PesquisaGrupoP_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(535, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(55, 15);
            this.label29.TabIndex = 155;
            this.label29.Text = "Situação";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(5, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 15);
            this.label24.TabIndex = 156;
            this.label24.Text = "Tipo";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(539, 77);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(156, 23);
            this.cb_Situacao.TabIndex = 10;
            this.cb_Situacao.Tag = "T";
            // 
            // cb_TipoP
            // 
            this.cb_TipoP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoP.FormattingEnabled = true;
            this.cb_TipoP.Location = new System.Drawing.Point(8, 32);
            this.cb_TipoP.Name = "cb_TipoP";
            this.cb_TipoP.Size = new System.Drawing.Size(205, 23);
            this.cb_TipoP.TabIndex = 1;
            this.cb_TipoP.Tag = "T";
            // 
            // txt_BarraP
            // 
            this.txt_BarraP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_BarraP.Location = new System.Drawing.Point(677, 32);
            this.txt_BarraP.MaxLength = 14;
            this.txt_BarraP.Name = "txt_BarraP";
            this.txt_BarraP.Size = new System.Drawing.Size(144, 21);
            this.txt_BarraP.TabIndex = 4;
            this.txt_BarraP.Tag = "T";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(316, 32);
            this.txt_DescricaoP.MaxLength = 60;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(356, 21);
            this.txt_DescricaoP.TabIndex = 3;
            this.txt_DescricaoP.Tag = "T";
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(219, 32);
            this.txt_IDP.MaxLength = 10;
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(91, 21);
            this.txt_IDP.TabIndex = 2;
            this.txt_IDP.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(313, 13);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 152;
            this.Label51.Text = "Descrição";
            // 
            // txt_InfoAdicional
            // 
            this.txt_InfoAdicional.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InfoAdicional.Location = new System.Drawing.Point(339, 78);
            this.txt_InfoAdicional.MaxLength = 60;
            this.txt_InfoAdicional.Name = "txt_InfoAdicional";
            this.txt_InfoAdicional.Size = new System.Drawing.Size(192, 21);
            this.txt_InfoAdicional.TabIndex = 9;
            this.txt_InfoAdicional.Tag = "T";
            // 
            // txt_FabricanteP
            // 
            this.txt_FabricanteP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_FabricanteP.Location = new System.Drawing.Point(827, 32);
            this.txt_FabricanteP.MaxLength = 60;
            this.txt_FabricanteP.Name = "txt_FabricanteP";
            this.txt_FabricanteP.Size = new System.Drawing.Size(107, 21);
            this.txt_FabricanteP.TabIndex = 5;
            this.txt_FabricanteP.Tag = "T";
            // 
            // txt_ReferenciaP
            // 
            this.txt_ReferenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReferenciaP.Location = new System.Drawing.Point(140, 78);
            this.txt_ReferenciaP.MaxLength = 60;
            this.txt_ReferenciaP.Name = "txt_ReferenciaP";
            this.txt_ReferenciaP.Size = new System.Drawing.Size(192, 21);
            this.txt_ReferenciaP.TabIndex = 8;
            this.txt_ReferenciaP.Tag = "T";
            // 
            // lb_Info_Adicional
            // 
            this.lb_Info_Adicional.AutoSize = true;
            this.lb_Info_Adicional.Location = new System.Drawing.Point(336, 59);
            this.lb_Info_Adicional.Name = "lb_Info_Adicional";
            this.lb_Info_Adicional.Size = new System.Drawing.Size(65, 15);
            this.lb_Info_Adicional.TabIndex = 153;
            this.lb_Info_Adicional.Text = "Fabricante";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(215, 13);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 151;
            this.Label45.Text = "Código";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(824, 13);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 15);
            this.label30.TabIndex = 153;
            this.label30.Text = "Fabricante";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(674, 13);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(37, 15);
            this.Label38.TabIndex = 150;
            this.Label38.Text = "Barra";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(136, 59);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 154;
            this.Label44.Text = "Referência";
            // 
            // mk_Cod_GrupoP
            // 
            this.mk_Cod_GrupoP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Cod_GrupoP.Location = new System.Drawing.Point(8, 78);
            this.mk_Cod_GrupoP.Mask = "00,00,00,00";
            this.mk_Cod_GrupoP.Name = "mk_Cod_GrupoP";
            this.mk_Cod_GrupoP.PromptChar = '0';
            this.mk_Cod_GrupoP.Size = new System.Drawing.Size(83, 21);
            this.mk_Cod_GrupoP.SkipLiterals = false;
            this.mk_Cod_GrupoP.TabIndex = 6;
            this.mk_Cod_GrupoP.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(8, 59);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(70, 15);
            this.Label37.TabIndex = 149;
            this.Label37.Text = "Cód. Grupo";
            // 
            // dg_Estoque
            // 
            this.dg_Estoque.AllowUserToAddRows = false;
            this.dg_Estoque.AllowUserToDeleteRows = false;
            this.dg_Estoque.AllowUserToResizeRows = false;
            this.dg_Estoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Estoque.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Estoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Estoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Grade,
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Referencia,
            this.col_Barra,
            this.col_Grade,
            this.col_EstoqueIdeal,
            this.col_EstoqueMinimo,
            this.col_EstoqueAtual,
            this.col_QtAferido});
            this.dg_Estoque.Cursor = System.Windows.Forms.Cursors.Default;
            this.dg_Estoque.Location = new System.Drawing.Point(8, 109);
            this.dg_Estoque.MultiSelect = false;
            this.dg_Estoque.Name = "dg_Estoque";
            this.dg_Estoque.RowHeadersVisible = false;
            this.dg_Estoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_Estoque.Size = new System.Drawing.Size(923, 505);
            this.dg_Estoque.TabIndex = 139;
            this.dg_Estoque.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Estoque_CellEndEdit);
            // 
            // col_ID_Grade
            // 
            this.col_ID_Grade.DataPropertyName = "ID_Grade";
            this.col_ID_Grade.HeaderText = "ID_Grade";
            this.col_ID_Grade.Name = "col_ID_Grade";
            this.col_ID_Grade.ReadOnly = true;
            this.col_ID_Grade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_Grade.Visible = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "CÓD.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_Produto.Width = 60;
            // 
            // col_Descricao
            // 
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "DESCRIÇÃO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            this.col_Descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Descricao.Width = 350;
            // 
            // col_Referencia
            // 
            this.col_Referencia.DataPropertyName = "Referencia";
            this.col_Referencia.HeaderText = "REF.";
            this.col_Referencia.Name = "col_Referencia";
            this.col_Referencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Referencia.Width = 75;
            // 
            // col_Barra
            // 
            this.col_Barra.DataPropertyName = "Barra";
            this.col_Barra.HeaderText = "BARRA";
            this.col_Barra.Name = "col_Barra";
            this.col_Barra.ReadOnly = true;
            this.col_Barra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Grade
            // 
            this.col_Grade.DataPropertyName = "DescricaoGrade";
            this.col_Grade.HeaderText = "GRADE";
            this.col_Grade.Name = "col_Grade";
            this.col_Grade.ReadOnly = true;
            this.col_Grade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Grade.Width = 70;
            // 
            // col_EstoqueIdeal
            // 
            this.col_EstoqueIdeal.DataPropertyName = "EstoqueIdeal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.col_EstoqueIdeal.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_EstoqueIdeal.HeaderText = "EST. IDEAL";
            this.col_EstoqueIdeal.Name = "col_EstoqueIdeal";
            this.col_EstoqueIdeal.ReadOnly = true;
            this.col_EstoqueIdeal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_EstoqueIdeal.Width = 120;
            // 
            // col_EstoqueMinimo
            // 
            this.col_EstoqueMinimo.DataPropertyName = "EstoqueMinimo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_EstoqueMinimo.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_EstoqueMinimo.HeaderText = "EST. MÍNIMO";
            this.col_EstoqueMinimo.Name = "col_EstoqueMinimo";
            this.col_EstoqueMinimo.ReadOnly = true;
            this.col_EstoqueMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_EstoqueMinimo.Width = 120;
            // 
            // col_EstoqueAtual
            // 
            this.col_EstoqueAtual.DataPropertyName = "EstoqueAtual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_EstoqueAtual.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_EstoqueAtual.HeaderText = "EST. ATUAL";
            this.col_EstoqueAtual.Name = "col_EstoqueAtual";
            this.col_EstoqueAtual.ReadOnly = true;
            this.col_EstoqueAtual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_EstoqueAtual.Width = 120;
            // 
            // col_QtAferido
            // 
            this.col_QtAferido.DataPropertyName = "Qt_Aferido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_QtAferido.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_QtAferido.HeaderText = "QT. AFERIDO";
            this.col_QtAferido.Name = "col_QtAferido";
            this.col_QtAferido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pesquisa_Arquivo
            // 
            this.Pesquisa_Arquivo.FileName = "Abre Arquivo";
            // 
            // UI_Produto_Balanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Balanco";
            this.Load += new System.EventHandler(this.UI_Produto_Balanco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Balanco_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Estoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.DataGridView dg_Estoque;
        internal System.Windows.Forms.Button bt_PesquisaGrupoP;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.ComboBox cb_TipoP;
        internal System.Windows.Forms.TextBox txt_BarraP;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.TextBox txt_IDP;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_FabricanteP;
        internal System.Windows.Forms.TextBox txt_ReferenciaP;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_Cod_GrupoP;
        internal System.Windows.Forms.Label Label37;
        private System.Windows.Forms.OpenFileDialog Pesquisa_Arquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Barra;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueIdeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_QtAferido;
        private System.Windows.Forms.CheckBox ck_ConsultaInversa;
        private System.Windows.Forms.CheckBox ck_ListaProduto;
        internal System.Windows.Forms.TextBox txt_InfoAdicional;
        internal System.Windows.Forms.Label lb_Info_Adicional;
    }
}

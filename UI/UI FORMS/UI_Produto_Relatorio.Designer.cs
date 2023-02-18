namespace Sistema.UI
{
    partial class UI_Produto_Relatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Relatorio));
            this.txt_Barra = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_Referencia = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_GrupoNivelP = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.dg_Produto = new System.Windows.Forms.DataGridView();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TabelaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CustoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueIdeal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.cb_ID_Tabela = new System.Windows.Forms.ComboBox();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_InformacaoAdicional = new System.Windows.Forms.TextBox();
            this.ck_EstoqueLimite = new System.Windows.Forms.CheckBox();
            this.ck_EstoqueCompra = new System.Windows.Forms.CheckBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Label17);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.ck_EstoqueCompra);
            this.TabPage1.Controls.Add(this.ck_EstoqueLimite);
            this.TabPage1.Controls.Add(this.bt_PesquisaConta);
            this.TabPage1.Controls.Add(this.Label34);
            this.TabPage1.Controls.Add(this.cb_ID_Tabela);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.cb_TipoRelatorio);
            this.TabPage1.Controls.Add(this.dg_Produto);
            this.TabPage1.Controls.Add(this.txt_Barra);
            this.TabPage1.Controls.Add(this.txt_Descricao);
            this.TabPage1.Controls.Add(this.txt_ID);
            this.TabPage1.Controls.Add(this.Label51);
            this.TabPage1.Controls.Add(this.txt_InformacaoAdicional);
            this.TabPage1.Controls.Add(this.txt_Referencia);
            this.TabPage1.Controls.Add(this.Label45);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.Label38);
            this.TabPage1.Controls.Add(this.Label44);
            this.TabPage1.Controls.Add(this.mk_GrupoNivelP);
            this.TabPage1.Controls.Add(this.Label37);
            // 
            // txt_Barra
            // 
            this.txt_Barra.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Barra.Location = new System.Drawing.Point(604, 29);
            this.txt_Barra.MaxLength = 14;
            this.txt_Barra.Name = "txt_Barra";
            this.txt_Barra.Size = new System.Drawing.Size(210, 21);
            this.txt_Barra.TabIndex = 3;
            this.txt_Barra.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(140, 29);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(457, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(9, 29);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(123, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(136, 10);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 712;
            this.Label51.Text = "Descrição";
            // 
            // txt_Referencia
            // 
            this.txt_Referencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Referencia.Location = new System.Drawing.Point(140, 76);
            this.txt_Referencia.MaxLength = 60;
            this.txt_Referencia.Name = "txt_Referencia";
            this.txt_Referencia.Size = new System.Drawing.Size(192, 21);
            this.txt_Referencia.TabIndex = 7;
            this.txt_Referencia.Tag = "T";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(6, 10);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 711;
            this.Label45.Text = "Código";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(601, 10);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(90, 15);
            this.Label38.TabIndex = 710;
            this.Label38.Text = "Cód. de Barras";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(136, 59);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 713;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivelP
            // 
            this.mk_GrupoNivelP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivelP.Location = new System.Drawing.Point(9, 76);
            this.mk_GrupoNivelP.Mask = "00,00,00,00";
            this.mk_GrupoNivelP.Name = "mk_GrupoNivelP";
            this.mk_GrupoNivelP.PromptChar = '0';
            this.mk_GrupoNivelP.Size = new System.Drawing.Size(84, 21);
            this.mk_GrupoNivelP.TabIndex = 5;
            this.mk_GrupoNivelP.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(9, 59);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(41, 15);
            this.Label37.TabIndex = 709;
            this.Label37.Text = "Grupo";
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
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Referencia,
            this.col_Grade,
            this.col_TabelaValor,
            this.col_CustoFinal,
            this.col_ValorVenda,
            this.col_EstoqueIdeal,
            this.col_EstoqueMinimo,
            this.col_EstoqueAtual,
            this.col_ID_Grade});
            this.dg_Produto.Location = new System.Drawing.Point(9, 207);
            this.dg_Produto.MultiSelect = false;
            this.dg_Produto.Name = "dg_Produto";
            this.dg_Produto.ReadOnly = true;
            this.dg_Produto.RowHeadersVisible = false;
            this.dg_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Produto.Size = new System.Drawing.Size(928, 414);
            this.dg_Produto.TabIndex = 40;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "CÓD.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 60;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "DESCRIÇÃO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_Referencia
            // 
            this.col_Referencia.DataPropertyName = "Referencia";
            this.col_Referencia.HeaderText = "REF.";
            this.col_Referencia.Name = "col_Referencia";
            this.col_Referencia.ReadOnly = true;
            this.col_Referencia.Width = 75;
            // 
            // col_Grade
            // 
            this.col_Grade.DataPropertyName = "DescricaoGrade";
            this.col_Grade.HeaderText = "GRADE";
            this.col_Grade.Name = "col_Grade";
            this.col_Grade.ReadOnly = true;
            // 
            // col_TabelaValor
            // 
            this.col_TabelaValor.DataPropertyName = "DescricaoTabelaValor";
            this.col_TabelaValor.HeaderText = "TABELA VALOR";
            this.col_TabelaValor.Name = "col_TabelaValor";
            this.col_TabelaValor.ReadOnly = true;
            this.col_TabelaValor.Width = 150;
            // 
            // col_CustoFinal
            // 
            this.col_CustoFinal.DataPropertyName = "CustoFinal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.col_CustoFinal.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_CustoFinal.HeaderText = "CUSTO FINAL";
            this.col_CustoFinal.Name = "col_CustoFinal";
            this.col_CustoFinal.ReadOnly = true;
            this.col_CustoFinal.Width = 70;
            // 
            // col_ValorVenda
            // 
            this.col_ValorVenda.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_ValorVenda.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ValorVenda.HeaderText = "VALOR VENDA";
            this.col_ValorVenda.Name = "col_ValorVenda";
            this.col_ValorVenda.ReadOnly = true;
            this.col_ValorVenda.Width = 70;
            // 
            // col_EstoqueIdeal
            // 
            this.col_EstoqueIdeal.DataPropertyName = "EstoqueIdeal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_EstoqueIdeal.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_EstoqueIdeal.HeaderText = "EST. IDEAL";
            this.col_EstoqueIdeal.Name = "col_EstoqueIdeal";
            this.col_EstoqueIdeal.ReadOnly = true;
            this.col_EstoqueIdeal.Width = 70;
            // 
            // col_EstoqueMinimo
            // 
            this.col_EstoqueMinimo.DataPropertyName = "EstoqueMinimo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_EstoqueMinimo.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_EstoqueMinimo.HeaderText = "EST. MINÍMO";
            this.col_EstoqueMinimo.Name = "col_EstoqueMinimo";
            this.col_EstoqueMinimo.ReadOnly = true;
            this.col_EstoqueMinimo.Width = 70;
            // 
            // col_EstoqueAtual
            // 
            this.col_EstoqueAtual.DataPropertyName = "EstoqueAtual";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_EstoqueAtual.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_EstoqueAtual.HeaderText = "EST. ATUAL";
            this.col_EstoqueAtual.Name = "col_EstoqueAtual";
            this.col_EstoqueAtual.ReadOnly = true;
            this.col_EstoqueAtual.Width = 70;
            // 
            // col_ID_Grade
            // 
            this.col_ID_Grade.DataPropertyName = "ID_Grade";
            this.col_ID_Grade.HeaderText = "ID_Grade";
            this.col_ID_Grade.Name = "col_ID_Grade";
            this.col_ID_Grade.ReadOnly = true;
            this.col_ID_Grade.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 716;
            this.label3.Text = "TIPO DE RELATÓRIO";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(9, 130);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(431, 23);
            this.cb_TipoRelatorio.TabIndex = 20;
            this.cb_TipoRelatorio.Tag = "T";
            this.cb_TipoRelatorio.SelectedValueChanged += new System.EventHandler(this.cb_TipoRelatorio_SelectedValueChanged);
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(336, 59);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(44, 15);
            this.Label34.TabIndex = 718;
            this.Label34.Text = "Tabela";
            // 
            // cb_ID_Tabela
            // 
            this.cb_ID_Tabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Tabela.FormattingEnabled = true;
            this.cb_ID_Tabela.Location = new System.Drawing.Point(339, 75);
            this.cb_ID_Tabela.Name = "cb_ID_Tabela";
            this.cb_ID_Tabela.Size = new System.Drawing.Size(257, 23);
            this.cb_ID_Tabela.TabIndex = 8;
            this.cb_ID_Tabela.Tag = "T";
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(101, 74);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 6;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 713;
            this.label1.Text = "Informação Adicional";
            // 
            // txt_InformacaoAdicional
            // 
            this.txt_InformacaoAdicional.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InformacaoAdicional.Enabled = false;
            this.txt_InformacaoAdicional.Location = new System.Drawing.Point(9, 177);
            this.txt_InformacaoAdicional.MaxLength = 60;
            this.txt_InformacaoAdicional.Name = "txt_InformacaoAdicional";
            this.txt_InformacaoAdicional.Size = new System.Drawing.Size(322, 21);
            this.txt_InformacaoAdicional.TabIndex = 21;
            this.txt_InformacaoAdicional.Tag = "T";
            // 
            // ck_EstoqueLimite
            // 
            this.ck_EstoqueLimite.AutoSize = true;
            this.ck_EstoqueLimite.Location = new System.Drawing.Point(604, 74);
            this.ck_EstoqueLimite.Name = "ck_EstoqueLimite";
            this.ck_EstoqueLimite.Size = new System.Drawing.Size(218, 19);
            this.ck_EstoqueLimite.TabIndex = 10;
            this.ck_EstoqueLimite.Text = "Exibir produtos com estoque crítico";
            this.ck_EstoqueLimite.UseVisualStyleBackColor = true;
            // 
            // ck_EstoqueCompra
            // 
            this.ck_EstoqueCompra.AutoSize = true;
            this.ck_EstoqueCompra.Location = new System.Drawing.Point(604, 101);
            this.ck_EstoqueCompra.Name = "ck_EstoqueCompra";
            this.ck_EstoqueCompra.Size = new System.Drawing.Size(149, 19);
            this.ck_EstoqueCompra.TabIndex = 11;
            this.ck_EstoqueCompra.Text = "Relatório para compra";
            this.ck_EstoqueCompra.UseVisualStyleBackColor = true;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(336, 156);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(33, 15);
            this.Label17.TabIndex = 750;
            this.Label17.Text = "Data";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Enabled = false;
            this.mk_DataInicial.Location = new System.Drawing.Point(339, 177);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 22;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // UI_Produto_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Relatorio";
            this.Load += new System.EventHandler(this.UI_Produto_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Relatorio_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Barra;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_Referencia;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_GrupoNivelP;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.DataGridView dg_Produto;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.ComboBox cb_ID_Tabela;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.TextBox txt_InformacaoAdicional;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_EstoqueLimite;
        private System.Windows.Forms.CheckBox ck_EstoqueCompra;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TabelaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CustoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueIdeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Grade;
    }
}

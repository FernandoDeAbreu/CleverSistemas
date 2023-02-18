namespace Sistema.UI
{
    partial class UI_Produto_ResumoVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_ResumoVenda));
            this.label3 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.dg_Estoque = new System.Windows.Forms.DataGridView();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CustoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_PesquisaGrupo = new System.Windows.Forms.Button();
            this.txt_BarraP = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_ReferenciaP = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_GrupoNivel = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Estoque)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_PesquisaGrupo);
            this.TabPage1.Controls.Add(this.txt_BarraP);
            this.TabPage1.Controls.Add(this.txt_Descricao);
            this.TabPage1.Controls.Add(this.txt_ID);
            this.TabPage1.Controls.Add(this.Label51);
            this.TabPage1.Controls.Add(this.txt_ReferenciaP);
            this.TabPage1.Controls.Add(this.Label45);
            this.TabPage1.Controls.Add(this.Label38);
            this.TabPage1.Controls.Add(this.Label44);
            this.TabPage1.Controls.Add(this.mk_GrupoNivel);
            this.TabPage1.Controls.Add(this.Label37);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.dg_Estoque);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 167;
            this.label3.Text = "Período";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(9, 122);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 10;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(140, 122);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 11;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(118, 125);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 166;
            this.Label25.Text = "à";
            // 
            // dg_Estoque
            // 
            this.dg_Estoque.AllowUserToAddRows = false;
            this.dg_Estoque.AllowUserToDeleteRows = false;
            this.dg_Estoque.AllowUserToResizeColumns = false;
            this.dg_Estoque.AllowUserToResizeRows = false;
            this.dg_Estoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Estoque.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Estoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Estoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Grade,
            this.col_Quantidade,
            this.col_CustoFinal,
            this.col_ValorVenda});
            this.dg_Estoque.Location = new System.Drawing.Point(9, 153);
            this.dg_Estoque.MultiSelect = false;
            this.dg_Estoque.Name = "dg_Estoque";
            this.dg_Estoque.ReadOnly = true;
            this.dg_Estoque.RowHeadersVisible = false;
            this.dg_Estoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Estoque.Size = new System.Drawing.Size(928, 466);
            this.dg_Estoque.TabIndex = 15;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID";
            this.col_ID_Produto.HeaderText = "CÓDIGO";
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
            // col_Grade
            // 
            this.col_Grade.DataPropertyName = "DescricaoGrade";
            this.col_Grade.HeaderText = "GRADE";
            this.col_Grade.Name = "col_Grade";
            this.col_Grade.ReadOnly = true;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Quantidade.HeaderText = "QT. VENDIDA";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.Width = 150;
            // 
            // col_CustoFinal
            // 
            this.col_CustoFinal.DataPropertyName = "CustoFinal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_CustoFinal.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_CustoFinal.HeaderText = "CUSTO TOTAL";
            this.col_CustoFinal.Name = "col_CustoFinal";
            this.col_CustoFinal.ReadOnly = true;
            this.col_CustoFinal.Width = 150;
            // 
            // col_ValorVenda
            // 
            this.col_ValorVenda.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_ValorVenda.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_ValorVenda.HeaderText = "TOTAL DAS VENDAS";
            this.col_ValorVenda.Name = "col_ValorVenda";
            this.col_ValorVenda.ReadOnly = true;
            this.col_ValorVenda.Width = 150;
            // 
            // bt_PesquisaGrupo
            // 
            this.bt_PesquisaGrupo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_PesquisaGrupo.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaGrupo.Image")));
            this.bt_PesquisaGrupo.Location = new System.Drawing.Point(94, 75);
            this.bt_PesquisaGrupo.Name = "bt_PesquisaGrupo";
            this.bt_PesquisaGrupo.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaGrupo.TabIndex = 5;
            this.bt_PesquisaGrupo.UseVisualStyleBackColor = false;
            this.bt_PesquisaGrupo.Click += new System.EventHandler(this.bt_PesquisaGrupo_Click);
            // 
            // txt_BarraP
            // 
            this.txt_BarraP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_BarraP.Location = new System.Drawing.Point(332, 76);
            this.txt_BarraP.MaxLength = 14;
            this.txt_BarraP.Name = "txt_BarraP";
            this.txt_BarraP.Size = new System.Drawing.Size(210, 21);
            this.txt_BarraP.TabIndex = 8;
            this.txt_BarraP.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(9, 30);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(410, 21);
            this.txt_Descricao.TabIndex = 1;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(427, 30);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(116, 21);
            this.txt_ID.TabIndex = 2;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(6, 9);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 177;
            this.Label51.Text = "Descrição";
            // 
            // txt_ReferenciaP
            // 
            this.txt_ReferenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReferenciaP.Location = new System.Drawing.Point(133, 76);
            this.txt_ReferenciaP.MaxLength = 60;
            this.txt_ReferenciaP.Name = "txt_ReferenciaP";
            this.txt_ReferenciaP.Size = new System.Drawing.Size(192, 21);
            this.txt_ReferenciaP.TabIndex = 6;
            this.txt_ReferenciaP.Tag = "T";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(423, 9);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 176;
            this.Label45.Text = "Código";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(329, 58);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(37, 15);
            this.Label38.TabIndex = 175;
            this.Label38.Text = "Barra";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(129, 58);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 178;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivel
            // 
            this.mk_GrupoNivel.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivel.Location = new System.Drawing.Point(9, 76);
            this.mk_GrupoNivel.Mask = "00,00,00,00";
            this.mk_GrupoNivel.Name = "mk_GrupoNivel";
            this.mk_GrupoNivel.PromptChar = '0';
            this.mk_GrupoNivel.Size = new System.Drawing.Size(80, 21);
            this.mk_GrupoNivel.TabIndex = 3;
            this.mk_GrupoNivel.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(9, 58);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(70, 15);
            this.Label37.TabIndex = 174;
            this.Label37.Text = "Cód. Grupo";
            // 
            // UI_Produto_ResumoVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_ResumoVenda";
            this.Load += new System.EventHandler(this.UI_Produto_ResumoVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_ResumoVenda_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Estoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.DataGridView dg_Estoque;
        internal System.Windows.Forms.Button bt_PesquisaGrupo;
        internal System.Windows.Forms.TextBox txt_BarraP;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_ReferenciaP;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_GrupoNivel;
        internal System.Windows.Forms.Label Label37;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CustoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorVenda;
    }
}

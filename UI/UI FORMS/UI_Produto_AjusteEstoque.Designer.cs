namespace Sistema.UI
{
    partial class UI_Produto_AjusteEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_AjusteEstoque));
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.dg_Produto = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstoqueAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_Referencia = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_GrupoNivelP = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.dg_Produto);
            this.gb_Cadastro.Controls.Add(this.bt_PesquisaConta);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.Label51);
            this.gb_Cadastro.Controls.Add(this.txt_Referencia);
            this.gb_Cadastro.Controls.Add(this.Label45);
            this.gb_Cadastro.Controls.Add(this.Label44);
            this.gb_Cadastro.Controls.Add(this.mk_GrupoNivelP);
            this.gb_Cadastro.Controls.Add(this.Label37);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
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
            this.col_Seleciona,
            this.col_ID_Grade,
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Grade,
            this.col_EstoqueAtual});
            this.dg_Produto.Location = new System.Drawing.Point(10, 103);
            this.dg_Produto.MultiSelect = false;
            this.dg_Produto.Name = "dg_Produto";
            this.dg_Produto.RowHeadersVisible = false;
            this.dg_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Produto.Size = new System.Drawing.Size(924, 513);
            this.dg_Produto.TabIndex = 40;
            this.dg_Produto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Produto_CellDoubleClick);
            this.dg_Produto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Produto_CellPainting);
            this.dg_Produto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Produto_ColumnHeaderMouseClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_ID_Grade
            // 
            this.col_ID_Grade.DataPropertyName = "ID_Grade";
            this.col_ID_Grade.HeaderText = "ID_Grade";
            this.col_ID_Grade.Name = "col_ID_Grade";
            this.col_ID_Grade.Visible = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "CÓDIGO";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 55;
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
            this.col_Grade.Width = 120;
            // 
            // col_EstoqueAtual
            // 
            this.col_EstoqueAtual.DataPropertyName = "EstoqueAtual";
            this.col_EstoqueAtual.HeaderText = "ESTOQUE ATUAL";
            this.col_EstoqueAtual.Name = "col_EstoqueAtual";
            this.col_EstoqueAtual.Width = 120;
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(103, 70);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 734;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(141, 25);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(457, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(10, 25);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(123, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(138, 4);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 739;
            this.Label51.Text = "Descrição";
            // 
            // txt_Referencia
            // 
            this.txt_Referencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Referencia.Location = new System.Drawing.Point(141, 72);
            this.txt_Referencia.MaxLength = 60;
            this.txt_Referencia.Name = "txt_Referencia";
            this.txt_Referencia.Size = new System.Drawing.Size(192, 21);
            this.txt_Referencia.TabIndex = 4;
            this.txt_Referencia.Tag = "T";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(7, 4);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 738;
            this.Label45.Text = "Código";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(138, 55);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 740;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivelP
            // 
            this.mk_GrupoNivelP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivelP.Location = new System.Drawing.Point(10, 72);
            this.mk_GrupoNivelP.Mask = "00,00,00,00";
            this.mk_GrupoNivelP.Name = "mk_GrupoNivelP";
            this.mk_GrupoNivelP.PromptChar = '0';
            this.mk_GrupoNivelP.Size = new System.Drawing.Size(84, 21);
            this.mk_GrupoNivelP.TabIndex = 3;
            this.mk_GrupoNivelP.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(10, 55);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(41, 15);
            this.Label37.TabIndex = 737;
            this.Label37.Text = "Grupo";
            // 
            // UI_Produto_AjusteEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_AjusteEstoque";
            this.Load += new System.EventHandler(this.UI_Produto_AjusteEstoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_AjusteEstoque_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.DataGridView dg_Produto;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_Referencia;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_GrupoNivelP;
        internal System.Windows.Forms.Label Label37;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EstoqueAtual;
    }
}

namespace Sistema.UI
{
    partial class UI_Produto_Imposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Imposto));
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
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Barra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Imposto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.cb_Imposto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Pesquisa_CaminhoNFe = new System.Windows.Forms.Button();
            this.gb_Consulta = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MarcaP = new System.Windows.Forms.TextBox();
            this.txt_NCM = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).BeginInit();
            this.gb_Consulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Consulta);
            this.TabPage1.Controls.Add(this.bt_Pesquisa_CaminhoNFe);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.cb_Imposto);
            this.TabPage1.Controls.Add(this.dg_Produto);
            // 
            // txt_Barra
            // 
            this.txt_Barra.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Barra.Location = new System.Drawing.Point(481, 87);
            this.txt_Barra.MaxLength = 14;
            this.txt_Barra.Name = "txt_Barra";
            this.txt_Barra.Size = new System.Drawing.Size(119, 21);
            this.txt_Barra.TabIndex = 9;
            this.txt_Barra.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(143, 39);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(329, 21);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(13, 39);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(123, 21);
            this.txt_ID.TabIndex = 2;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(140, 18);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 712;
            this.Label51.Text = "Descrição";
            // 
            // txt_Referencia
            // 
            this.txt_Referencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Referencia.Location = new System.Drawing.Point(143, 87);
            this.txt_Referencia.MaxLength = 60;
            this.txt_Referencia.Name = "txt_Referencia";
            this.txt_Referencia.Size = new System.Drawing.Size(192, 21);
            this.txt_Referencia.TabIndex = 7;
            this.txt_Referencia.Tag = "T";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(9, 18);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 711;
            this.Label45.Text = "Código";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(477, 66);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(90, 15);
            this.Label38.TabIndex = 710;
            this.Label38.Text = "Cód. de Barras";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(140, 69);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 713;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivelP
            // 
            this.mk_GrupoNivelP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivelP.Location = new System.Drawing.Point(13, 86);
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
            this.Label37.Location = new System.Drawing.Point(13, 69);
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
            this.col_Seleciona,
            this.col_ID_Produto,
            this.col_ID_Empresa,
            this.col_Descricao,
            this.col_Barra,
            this.col_NCM,
            this.col_DescricaoTributacao,
            this.col_ID_Imposto});
            this.dg_Produto.Location = new System.Drawing.Point(5, 147);
            this.dg_Produto.MultiSelect = false;
            this.dg_Produto.Name = "dg_Produto";
            this.dg_Produto.RowHeadersVisible = false;
            this.dg_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Produto.Size = new System.Drawing.Size(929, 474);
            this.dg_Produto.TabIndex = 15;
            this.dg_Produto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Produto_CellPainting);
            this.dg_Produto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Produto_ColumnHeaderMouseClick);
            this.dg_Produto.DoubleClick += new System.EventHandler(this.dg_Produto_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.HeaderText = "CÓDIGO";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Width = 60;
            // 
            // col_ID_Empresa
            // 
            this.col_ID_Empresa.HeaderText = "CÓD. EMPRESA";
            this.col_ID_Empresa.Name = "col_ID_Empresa";
            this.col_ID_Empresa.Width = 80;
            // 
            // col_Descricao
            // 
            this.col_Descricao.HeaderText = "PRODUTO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            this.col_Descricao.Width = 350;
            // 
            // col_Barra
            // 
            this.col_Barra.HeaderText = "BARRA";
            this.col_Barra.Name = "col_Barra";
            this.col_Barra.ReadOnly = true;
            // 
            // col_NCM
            // 
            this.col_NCM.HeaderText = "NCM";
            this.col_NCM.Name = "col_NCM";
            this.col_NCM.ReadOnly = true;
            // 
            // col_DescricaoTributacao
            // 
            this.col_DescricaoTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoTributacao.HeaderText = "GRUPO DE IMPOSTOS";
            this.col_DescricaoTributacao.Name = "col_DescricaoTributacao";
            this.col_DescricaoTributacao.ReadOnly = true;
            // 
            // col_ID_Imposto
            // 
            this.col_ID_Imposto.HeaderText = "ID Imposto";
            this.col_ID_Imposto.Name = "col_ID_Imposto";
            this.col_ID_Imposto.ReadOnly = true;
            this.col_ID_Imposto.Visible = false;
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(105, 84);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 6;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // cb_Imposto
            // 
            this.cb_Imposto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Imposto.FormattingEnabled = true;
            this.cb_Imposto.Location = new System.Drawing.Point(640, 46);
            this.cb_Imposto.Name = "cb_Imposto";
            this.cb_Imposto.Size = new System.Drawing.Size(294, 23);
            this.cb_Imposto.TabIndex = 10;
            this.cb_Imposto.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 718;
            this.label1.Text = "Grupo de Imposto";
            // 
            // bt_Pesquisa_CaminhoNFe
            // 
            this.bt_Pesquisa_CaminhoNFe.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Pesquisa_CaminhoNFe.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Pesquisa_CaminhoNFe.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Pesquisa_CaminhoNFe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Pesquisa_CaminhoNFe.Location = new System.Drawing.Point(640, 89);
            this.bt_Pesquisa_CaminhoNFe.Name = "bt_Pesquisa_CaminhoNFe";
            this.bt_Pesquisa_CaminhoNFe.Size = new System.Drawing.Size(297, 49);
            this.bt_Pesquisa_CaminhoNFe.TabIndex = 11;
            this.bt_Pesquisa_CaminhoNFe.Text = "SELECIONAR IMPOSTO PARA PRODUTOS MARCADOS";
            this.bt_Pesquisa_CaminhoNFe.UseVisualStyleBackColor = false;
            this.bt_Pesquisa_CaminhoNFe.Click += new System.EventHandler(this.bt_Pesquisa_CaminhoNFe_Click);
            // 
            // gb_Consulta
            // 
            this.gb_Consulta.Controls.Add(this.Label45);
            this.gb_Consulta.Controls.Add(this.Label37);
            this.gb_Consulta.Controls.Add(this.bt_PesquisaConta);
            this.gb_Consulta.Controls.Add(this.mk_GrupoNivelP);
            this.gb_Consulta.Controls.Add(this.Label44);
            this.gb_Consulta.Controls.Add(this.label2);
            this.gb_Consulta.Controls.Add(this.label3);
            this.gb_Consulta.Controls.Add(this.Label38);
            this.gb_Consulta.Controls.Add(this.txt_Referencia);
            this.gb_Consulta.Controls.Add(this.txt_MarcaP);
            this.gb_Consulta.Controls.Add(this.txt_NCM);
            this.gb_Consulta.Controls.Add(this.txt_Barra);
            this.gb_Consulta.Controls.Add(this.Label51);
            this.gb_Consulta.Controls.Add(this.txt_Descricao);
            this.gb_Consulta.Controls.Add(this.txt_ID);
            this.gb_Consulta.Location = new System.Drawing.Point(9, 11);
            this.gb_Consulta.Name = "gb_Consulta";
            this.gb_Consulta.Size = new System.Drawing.Size(621, 130);
            this.gb_Consulta.TabIndex = 1;
            this.gb_Consulta.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 710;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 710;
            this.label3.Text = "NCM";
            // 
            // txt_MarcaP
            // 
            this.txt_MarcaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MarcaP.Location = new System.Drawing.Point(343, 87);
            this.txt_MarcaP.MaxLength = 14;
            this.txt_MarcaP.Name = "txt_MarcaP";
            this.txt_MarcaP.Size = new System.Drawing.Size(130, 21);
            this.txt_MarcaP.TabIndex = 8;
            this.txt_MarcaP.Tag = "T";
            // 
            // txt_NCM
            // 
            this.txt_NCM.BackColor = System.Drawing.SystemColors.Window;
            this.txt_NCM.Location = new System.Drawing.Point(481, 39);
            this.txt_NCM.MaxLength = 14;
            this.txt_NCM.Name = "txt_NCM";
            this.txt_NCM.Size = new System.Drawing.Size(119, 21);
            this.txt_NCM.TabIndex = 4;
            this.txt_NCM.Tag = "T";
            // 
            // UI_Produto_Imposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Imposto";
            this.Load += new System.EventHandler(this.UI_Produto_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Relatorio_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).EndInit();
            this.gb_Consulta.ResumeLayout(false);
            this.gb_Consulta.PerformLayout();
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
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cb_Imposto;
        internal System.Windows.Forms.Button bt_Pesquisa_CaminhoNFe;
        private System.Windows.Forms.GroupBox gb_Consulta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Barra;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Imposto;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_MarcaP;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_NCM;
    }
}

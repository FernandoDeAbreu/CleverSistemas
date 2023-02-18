namespace Sistema.UI
{
    partial class UI_Produto_Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Consulta));
            this.DG = new System.Windows.Forms.DataGridView();
            this.txt_BarraP = new System.Windows.Forms.TextBox();
            this.txt_DescricaoProdutoP = new System.Windows.Forms.TextBox();
            this.txt_IDProdutoP = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_ReferenciaP = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_GrupoNivel = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FabricanteP = new System.Windows.Forms.TextBox();
            this.lb_InfoAdicional1 = new System.Windows.Forms.Label();
            this.txt_InfoProduto1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gb_Imagem = new System.Windows.Forms.GroupBox();
            this.pc_Imagem = new System.Windows.Forms.PictureBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Imagem = new System.Windows.Forms.TextBox();
            this.bt_PesquisaGrupo = new System.Windows.Forms.Button();
            this.bt_Localizar = new System.Windows.Forms.Button();
            this.bt_Selecionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.gb_Imagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // DG
            // 
            this.DG.AllowUserToAddRows = false;
            this.DG.AllowUserToDeleteRows = false;
            this.DG.AllowUserToResizeRows = false;
            this.DG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(9, 103);
            this.DG.MultiSelect = false;
            this.DG.Name = "DG";
            this.DG.ReadOnly = true;
            this.DG.RowHeadersVisible = false;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(863, 352);
            this.DG.StandardTab = true;
            this.DG.TabIndex = 20;
            this.DG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellDoubleClick);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_PesquisaProduto_KeyDown);
            // 
            // txt_BarraP
            // 
            this.txt_BarraP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_BarraP.Location = new System.Drawing.Point(473, 30);
            this.txt_BarraP.MaxLength = 14;
            this.txt_BarraP.Name = "txt_BarraP";
            this.txt_BarraP.Size = new System.Drawing.Size(153, 20);
            this.txt_BarraP.TabIndex = 3;
            this.txt_BarraP.Tag = "T";
            // 
            // txt_DescricaoProdutoP
            // 
            this.txt_DescricaoProdutoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoProdutoP.Location = new System.Drawing.Point(9, 30);
            this.txt_DescricaoProdutoP.MaxLength = 60;
            this.txt_DescricaoProdutoP.Name = "txt_DescricaoProdutoP";
            this.txt_DescricaoProdutoP.Size = new System.Drawing.Size(352, 20);
            this.txt_DescricaoProdutoP.TabIndex = 1;
            this.txt_DescricaoProdutoP.Tag = "T";
            this.txt_DescricaoProdutoP.TextChanged += new System.EventHandler(this.txt_DescricaoProdutoP_TextChanged);
            this.txt_DescricaoProdutoP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DescricaoProdutoP_KeyDown);
            // 
            // txt_IDProdutoP
            // 
            this.txt_IDProdutoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDProdutoP.Location = new System.Drawing.Point(367, 30);
            this.txt_IDProdutoP.MaxLength = 10;
            this.txt_IDProdutoP.Name = "txt_IDProdutoP";
            this.txt_IDProdutoP.Size = new System.Drawing.Size(100, 20);
            this.txt_IDProdutoP.TabIndex = 2;
            this.txt_IDProdutoP.Tag = "T";
            this.txt_IDProdutoP.TextChanged += new System.EventHandler(this.txt_IDProdutoP_TextChanged);
            this.txt_IDProdutoP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_IDProdutoP_KeyDown);
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(6, 10);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(52, 14);
            this.Label51.TabIndex = 139;
            this.Label51.Text = "Descrição";
            // 
            // txt_ReferenciaP
            // 
            this.txt_ReferenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReferenciaP.Location = new System.Drawing.Point(115, 73);
            this.txt_ReferenciaP.MaxLength = 60;
            this.txt_ReferenciaP.Name = "txt_ReferenciaP";
            this.txt_ReferenciaP.Size = new System.Drawing.Size(165, 20);
            this.txt_ReferenciaP.TabIndex = 7;
            this.txt_ReferenciaP.Tag = "T";
            this.txt_ReferenciaP.TextChanged += new System.EventHandler(this.txt_ReferenciaP_TextChanged);
            this.txt_ReferenciaP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ReferenciaP_KeyDown);
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(364, 10);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(39, 14);
            this.Label45.TabIndex = 138;
            this.Label45.Text = "Código";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(470, 13);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(32, 14);
            this.Label38.TabIndex = 137;
            this.Label38.Text = "Barra";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(112, 56);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(56, 14);
            this.Label44.TabIndex = 140;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivel
            // 
            this.mk_GrupoNivel.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivel.Location = new System.Drawing.Point(9, 73);
            this.mk_GrupoNivel.Mask = "00,00,00,00";
            this.mk_GrupoNivel.Name = "mk_GrupoNivel";
            this.mk_GrupoNivel.PromptChar = '0';
            this.mk_GrupoNivel.Size = new System.Drawing.Size(69, 20);
            this.mk_GrupoNivel.TabIndex = 5;
            this.mk_GrupoNivel.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(9, 56);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(59, 14);
            this.Label37.TabIndex = 136;
            this.Label37.Text = "Cód. Grupo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 137;
            this.label1.Text = "Fabricante";
            // 
            // txt_FabricanteP
            // 
            this.txt_FabricanteP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_FabricanteP.Location = new System.Drawing.Point(286, 73);
            this.txt_FabricanteP.MaxLength = 14;
            this.txt_FabricanteP.Name = "txt_FabricanteP";
            this.txt_FabricanteP.Size = new System.Drawing.Size(181, 20);
            this.txt_FabricanteP.TabIndex = 8;
            this.txt_FabricanteP.Tag = "T";
            this.txt_FabricanteP.TextChanged += new System.EventHandler(this.txt_FabricanteP_TextChanged);
            this.txt_FabricanteP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_FabricanteP_KeyDown);
            // 
            // lb_InfoAdicional1
            // 
            this.lb_InfoAdicional1.AutoSize = true;
            this.lb_InfoAdicional1.Location = new System.Drawing.Point(470, 55);
            this.lb_InfoAdicional1.Name = "lb_InfoAdicional1";
            this.lb_InfoAdicional1.Size = new System.Drawing.Size(55, 14);
            this.lb_InfoAdicional1.TabIndex = 137;
            this.lb_InfoAdicional1.Text = "Fabricante";
            // 
            // txt_InfoProduto1
            // 
            this.txt_InfoProduto1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InfoProduto1.Location = new System.Drawing.Point(473, 72);
            this.txt_InfoProduto1.MaxLength = 14;
            this.txt_InfoProduto1.Name = "txt_InfoProduto1";
            this.txt_InfoProduto1.Size = new System.Drawing.Size(273, 20);
            this.txt_InfoProduto1.TabIndex = 9;
            this.txt_InfoProduto1.Tag = "T";
            this.txt_InfoProduto1.TextChanged += new System.EventHandler(this.txt_FabricanteP_TextChanged);
            this.txt_InfoProduto1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_FabricanteP_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(67, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 14);
            this.label17.TabIndex = 684;
            this.label17.Text = "F7 (Histórico)";
            // 
            // gb_Imagem
            // 
            this.gb_Imagem.Controls.Add(this.pc_Imagem);
            this.gb_Imagem.Controls.Add(this.txt_ID);
            this.gb_Imagem.Controls.Add(this.txt_Imagem);
            this.gb_Imagem.Location = new System.Drawing.Point(350, 454);
            this.gb_Imagem.Name = "gb_Imagem";
            this.gb_Imagem.Size = new System.Drawing.Size(180, 162);
            this.gb_Imagem.TabIndex = 685;
            this.gb_Imagem.TabStop = false;
            // 
            // pc_Imagem
            // 
            this.pc_Imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pc_Imagem.Location = new System.Drawing.Point(3, 16);
            this.pc_Imagem.Name = "pc_Imagem";
            this.pc_Imagem.Size = new System.Drawing.Size(174, 143);
            this.pc_Imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pc_Imagem.TabIndex = 0;
            this.pc_Imagem.TabStop = false;
            this.pc_Imagem.Tag = "";
            this.pc_Imagem.DoubleClick += new System.EventHandler(this.pc_Imagem_DoubleClick);
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(47, 30);
            this.txt_ID.MaxLength = 14;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(26, 20);
            this.txt_ID.TabIndex = 3;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_Imagem_TextChanged);
            // 
            // txt_Imagem
            // 
            this.txt_Imagem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Imagem.Location = new System.Drawing.Point(15, 30);
            this.txt_Imagem.MaxLength = 14;
            this.txt_Imagem.Name = "txt_Imagem";
            this.txt_Imagem.Size = new System.Drawing.Size(26, 20);
            this.txt_Imagem.TabIndex = 3;
            this.txt_Imagem.Tag = "T";
            this.txt_Imagem.TextChanged += new System.EventHandler(this.txt_Imagem_TextChanged);
            // 
            // bt_PesquisaGrupo
            // 
            this.bt_PesquisaGrupo.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaGrupo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaGrupo.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaGrupo.Image")));
            this.bt_PesquisaGrupo.Location = new System.Drawing.Point(82, 72);
            this.bt_PesquisaGrupo.Name = "bt_PesquisaGrupo";
            this.bt_PesquisaGrupo.Size = new System.Drawing.Size(27, 25);
            this.bt_PesquisaGrupo.TabIndex = 6;
            this.bt_PesquisaGrupo.UseVisualStyleBackColor = false;
            this.bt_PesquisaGrupo.Click += new System.EventHandler(this.bt_PesquisaGrupo_Click);
            // 
            // bt_Localizar
            // 
            this.bt_Localizar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Localizar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Localizar.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_Localizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Localizar.Location = new System.Drawing.Point(752, 31);
            this.bt_Localizar.Name = "bt_Localizar";
            this.bt_Localizar.Size = new System.Drawing.Size(120, 66);
            this.bt_Localizar.TabIndex = 10;
            this.bt_Localizar.Text = "PESQUISA (F5)";
            this.bt_Localizar.UseVisualStyleBackColor = false;
            this.bt_Localizar.Click += new System.EventHandler(this.bt_Localizar_Click);
            // 
            // bt_Selecionar
            // 
            this.bt_Selecionar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Selecionar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Selecionar.Image = ((System.Drawing.Image)(resources.GetObject("bt_Selecionar.Image")));
            this.bt_Selecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Selecionar.Location = new System.Drawing.Point(755, 462);
            this.bt_Selecionar.Name = "bt_Selecionar";
            this.bt_Selecionar.Size = new System.Drawing.Size(117, 44);
            this.bt_Selecionar.TabIndex = 30;
            this.bt_Selecionar.Text = "SELECIONAR";
            this.bt_Selecionar.UseVisualStyleBackColor = false;
            this.bt_Selecionar.Click += new System.EventHandler(this.bt_Seleciona_Click);
            // 
            // UI_Produto_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(880, 619);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.bt_PesquisaGrupo);
            this.Controls.Add(this.txt_InfoProduto1);
            this.Controls.Add(this.txt_FabricanteP);
            this.Controls.Add(this.txt_BarraP);
            this.Controls.Add(this.txt_DescricaoProdutoP);
            this.Controls.Add(this.txt_IDProdutoP);
            this.Controls.Add(this.Label51);
            this.Controls.Add(this.lb_InfoAdicional1);
            this.Controls.Add(this.txt_ReferenciaP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label45);
            this.Controls.Add(this.Label38);
            this.Controls.Add(this.Label44);
            this.Controls.Add(this.mk_GrupoNivel);
            this.Controls.Add(this.Label37);
            this.Controls.Add(this.bt_Localizar);
            this.Controls.Add(this.bt_Selecionar);
            this.Controls.Add(this.DG);
            this.Controls.Add(this.gb_Imagem);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Produto_Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA PRODUTO";
            this.Load += new System.EventHandler(this.UI_Produto_Consulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Consulta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Produto_Consulta_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.gb_Imagem.ResumeLayout(false);
            this.gb_Imagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bt_PesquisaGrupo;
        internal System.Windows.Forms.DataGridView DG;
        internal System.Windows.Forms.TextBox txt_BarraP;
        internal System.Windows.Forms.TextBox txt_DescricaoProdutoP;
        internal System.Windows.Forms.TextBox txt_IDProdutoP;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_ReferenciaP;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_GrupoNivel;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Button bt_Localizar;
        internal System.Windows.Forms.Button bt_Selecionar;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_FabricanteP;
        internal System.Windows.Forms.Label lb_InfoAdicional1;
        internal System.Windows.Forms.TextBox txt_InfoProduto1;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gb_Imagem;
        private System.Windows.Forms.PictureBox pc_Imagem;
        internal System.Windows.Forms.TextBox txt_Imagem;
        internal System.Windows.Forms.TextBox txt_ID;
    }
}
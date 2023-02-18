namespace Sistema.UI
{
    partial class UI_Produto_Etiqueta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Etiqueta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.Label34 = new System.Windows.Forms.Label();
            this.cb_ID_Tabela = new System.Windows.Forms.ComboBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.txt_Referencia = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.mk_GrupoNivelP = new System.Windows.Forms.MaskedTextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Etiqueta = new System.Windows.Forms.ComboBox();
            this.dg_Etiqueta = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Barra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Inicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Qtd_Etiqueta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Parcela = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID_Entrada = new System.Windows.Forms.TextBox();
            this.ck_Estoque = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_InformacaoAdicional = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Etiqueta)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ck_Estoque);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.cb_Etiqueta);
            this.TabPage1.Controls.Add(this.dg_Etiqueta);
            this.TabPage1.Controls.Add(this.txt_Inicio);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.txt_InformacaoAdicional);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.txt_Qtd_Etiqueta);
            this.TabPage1.Controls.Add(this.label4);
            this.TabPage1.Controls.Add(this.txt_Parcela);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.bt_PesquisaConta);
            this.TabPage1.Controls.Add(this.Label34);
            this.TabPage1.Controls.Add(this.cb_ID_Tabela);
            this.TabPage1.Controls.Add(this.txt_Descricao);
            this.TabPage1.Controls.Add(this.txt_ID);
            this.TabPage1.Controls.Add(this.Label51);
            this.TabPage1.Controls.Add(this.txt_ID_Entrada);
            this.TabPage1.Controls.Add(this.txt_Referencia);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.Label45);
            this.TabPage1.Controls.Add(this.Label44);
            this.TabPage1.Controls.Add(this.mk_GrupoNivelP);
            this.TabPage1.Controls.Add(this.Label37);
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(103, 74);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 11;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(337, 59);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(44, 15);
            this.Label34.TabIndex = 731;
            this.Label34.Text = "Tabela";
            // 
            // cb_ID_Tabela
            // 
            this.cb_ID_Tabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Tabela.FormattingEnabled = true;
            this.cb_ID_Tabela.Location = new System.Drawing.Point(341, 75);
            this.cb_ID_Tabela.Name = "cb_ID_Tabela";
            this.cb_ID_Tabela.Size = new System.Drawing.Size(257, 23);
            this.cb_ID_Tabela.TabIndex = 13;
            this.cb_ID_Tabela.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(141, 29);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(457, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(10, 29);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(123, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(138, 10);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 729;
            this.Label51.Text = "Descrição";
            // 
            // txt_Referencia
            // 
            this.txt_Referencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Referencia.Location = new System.Drawing.Point(141, 76);
            this.txt_Referencia.MaxLength = 60;
            this.txt_Referencia.Name = "txt_Referencia";
            this.txt_Referencia.Size = new System.Drawing.Size(192, 21);
            this.txt_Referencia.TabIndex = 12;
            this.txt_Referencia.Tag = "T";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(7, 10);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 728;
            this.Label45.Text = "Código";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(138, 59);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 730;
            this.Label44.Text = "Referência";
            // 
            // mk_GrupoNivelP
            // 
            this.mk_GrupoNivelP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_GrupoNivelP.Location = new System.Drawing.Point(10, 76);
            this.mk_GrupoNivelP.Mask = "00,00,00,00";
            this.mk_GrupoNivelP.Name = "mk_GrupoNivelP";
            this.mk_GrupoNivelP.PromptChar = '0';
            this.mk_GrupoNivelP.Size = new System.Drawing.Size(84, 21);
            this.mk_GrupoNivelP.TabIndex = 10;
            this.mk_GrupoNivelP.Tag = "T";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(10, 59);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(41, 15);
            this.Label37.TabIndex = 726;
            this.Label37.Text = "Grupo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 740;
            this.label6.Text = "Etiqueta";
            // 
            // cb_Etiqueta
            // 
            this.cb_Etiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Etiqueta.FormattingEnabled = true;
            this.cb_Etiqueta.Items.AddRange(new object[] {
            "Etiqueta A4051/A4251/A4351 (Pimaco)",
            "Etiqueta Carta 6087/6187/6287 (Pimaco)",
            "Etiqueta Carta 6080/6180/6280/62580 (Pimaco)"});
            this.cb_Etiqueta.Location = new System.Drawing.Point(10, 140);
            this.cb_Etiqueta.Name = "cb_Etiqueta";
            this.cb_Etiqueta.Size = new System.Drawing.Size(416, 23);
            this.cb_Etiqueta.TabIndex = 20;
            this.cb_Etiqueta.Tag = "T";
            // 
            // dg_Etiqueta
            // 
            this.dg_Etiqueta.AllowUserToAddRows = false;
            this.dg_Etiqueta.AllowUserToDeleteRows = false;
            this.dg_Etiqueta.AllowUserToResizeColumns = false;
            this.dg_Etiqueta.AllowUserToResizeRows = false;
            this.dg_Etiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Etiqueta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Etiqueta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Etiqueta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Etiqueta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Grade,
            this.col_Barra,
            this.col_Valor,
            this.col_Quantidade});
            this.dg_Etiqueta.Location = new System.Drawing.Point(7, 171);
            this.dg_Etiqueta.MultiSelect = false;
            this.dg_Etiqueta.Name = "dg_Etiqueta";
            this.dg_Etiqueta.RowHeadersVisible = false;
            this.dg_Etiqueta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_Etiqueta.Size = new System.Drawing.Size(927, 448);
            this.dg_Etiqueta.TabIndex = 500;
            this.dg_Etiqueta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Etiqueta_CellDoubleClick);
            this.dg_Etiqueta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Etiqueta_CellPainting);
            this.dg_Etiqueta.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Etiqueta_ColumnHeaderMouseClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
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
            this.col_Grade.Width = 70;
            // 
            // col_Barra
            // 
            this.col_Barra.DataPropertyName = "Barra";
            this.col_Barra.HeaderText = "BARRA";
            this.col_Barra.Name = "col_Barra";
            this.col_Barra.ReadOnly = true;
            // 
            // col_Valor
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Valor.HeaderText = "VALOR DE VENDA";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 130;
            // 
            // col_Quantidade
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Quantidade.HeaderText = "QT. ETIQUETA";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.Width = 130;
            // 
            // txt_Inicio
            // 
            this.txt_Inicio.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Inicio.Location = new System.Drawing.Point(429, 140);
            this.txt_Inicio.MaxLength = 60;
            this.txt_Inicio.Name = "txt_Inicio";
            this.txt_Inicio.Size = new System.Drawing.Size(83, 21);
            this.txt_Inicio.TabIndex = 21;
            this.txt_Inicio.Tag = "T";
            this.txt_Inicio.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 737;
            this.label5.Text = "Início";
            // 
            // txt_Qtd_Etiqueta
            // 
            this.txt_Qtd_Etiqueta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Qtd_Etiqueta.Location = new System.Drawing.Point(607, 140);
            this.txt_Qtd_Etiqueta.MaxLength = 60;
            this.txt_Qtd_Etiqueta.Name = "txt_Qtd_Etiqueta";
            this.txt_Qtd_Etiqueta.Size = new System.Drawing.Size(83, 21);
            this.txt_Qtd_Etiqueta.TabIndex = 23;
            this.txt_Qtd_Etiqueta.Tag = "T";
            this.txt_Qtd_Etiqueta.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 738;
            this.label4.Text = "Qtd. Etiqueta";
            // 
            // txt_Parcela
            // 
            this.txt_Parcela.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Parcela.Location = new System.Drawing.Point(518, 140);
            this.txt_Parcela.MaxLength = 60;
            this.txt_Parcela.Name = "txt_Parcela";
            this.txt_Parcela.Size = new System.Drawing.Size(83, 21);
            this.txt_Parcela.TabIndex = 22;
            this.txt_Parcela.Tag = "T";
            this.txt_Parcela.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 739;
            this.label3.Text = "Qtd. Parcela";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 730;
            this.label1.Text = "Nº Entrada";
            // 
            // txt_ID_Entrada
            // 
            this.txt_ID_Entrada.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Entrada.Location = new System.Drawing.Point(605, 29);
            this.txt_ID_Entrada.MaxLength = 60;
            this.txt_ID_Entrada.Name = "txt_ID_Entrada";
            this.txt_ID_Entrada.Size = new System.Drawing.Size(83, 21);
            this.txt_ID_Entrada.TabIndex = 3;
            this.txt_ID_Entrada.Tag = "T";
            // 
            // ck_Estoque
            // 
            this.ck_Estoque.AutoSize = true;
            this.ck_Estoque.Location = new System.Drawing.Point(696, 29);
            this.ck_Estoque.Name = "ck_Estoque";
            this.ck_Estoque.Size = new System.Drawing.Size(179, 19);
            this.ck_Estoque.TabIndex = 4;
            this.ck_Estoque.Text = "Quantidade = Estoque atual";
            this.ck_Estoque.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(693, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 738;
            this.label2.Text = "Informação Adicional";
            // 
            // txt_InformacaoAdicional
            // 
            this.txt_InformacaoAdicional.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InformacaoAdicional.Location = new System.Drawing.Point(696, 140);
            this.txt_InformacaoAdicional.MaxLength = 60;
            this.txt_InformacaoAdicional.Name = "txt_InformacaoAdicional";
            this.txt_InformacaoAdicional.Size = new System.Drawing.Size(235, 21);
            this.txt_InformacaoAdicional.TabIndex = 23;
            this.txt_InformacaoAdicional.Tag = "T";
            // 
            // UI_Produto_Etiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Etiqueta";
            this.Load += new System.EventHandler(this.UI_Produto_Etiqueta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Etiqueta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Produto_Etiqueta_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Etiqueta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.ComboBox cb_ID_Tabela;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.TextBox txt_Referencia;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.MaskedTextBox mk_GrupoNivelP;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cb_Etiqueta;
        internal System.Windows.Forms.DataGridView dg_Etiqueta;
        internal System.Windows.Forms.TextBox txt_Inicio;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_Qtd_Etiqueta;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_Parcela;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_Estoque;
        internal System.Windows.Forms.TextBox txt_ID_Entrada;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Barra;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        internal System.Windows.Forms.TextBox txt_InformacaoAdicional;
        internal System.Windows.Forms.Label label2;
    }
}

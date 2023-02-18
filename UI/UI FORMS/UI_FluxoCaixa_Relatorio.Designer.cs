namespace Sistema.UI
{
    partial class UI_FluxoCaixa_Relatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_FluxoCaixa_Relatorio));
            this.bt_PesquisaConta_P = new System.Windows.Forms.Button();
            this.mk_ContaP = new System.Windows.Forms.MaskedTextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_ConciliadoPesquisa = new System.Windows.Forms.CheckBox();
            this.ck_ExibirConta = new System.Windows.Forms.CheckBox();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.cb_Caixa = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_PesquisaConta_P);
            this.TabPage1.Controls.Add(this.mk_ContaP);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.Label21);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.ck_ConciliadoPesquisa);
            this.TabPage1.Controls.Add(this.ck_ExibirConta);
            this.TabPage1.Controls.Add(this.cb_Tipo);
            this.TabPage1.Controls.Add(this.cb_Caixa);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            // 
            // bt_PesquisaConta_P
            // 
            this.bt_PesquisaConta_P.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta_P.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta_P.Image")));
            this.bt_PesquisaConta_P.Location = new System.Drawing.Point(105, 144);
            this.bt_PesquisaConta_P.Name = "bt_PesquisaConta_P";
            this.bt_PesquisaConta_P.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta_P.TabIndex = 5;
            this.bt_PesquisaConta_P.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta_P.Click += new System.EventHandler(this.bt_PesquisaConta_P_Click);
            // 
            // mk_ContaP
            // 
            this.mk_ContaP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_ContaP.Location = new System.Drawing.Point(21, 145);
            this.mk_ContaP.Mask = "00,00,00,00";
            this.mk_ContaP.Name = "mk_ContaP";
            this.mk_ContaP.PromptChar = '0';
            this.mk_ContaP.Size = new System.Drawing.Size(76, 21);
            this.mk_ContaP.TabIndex = 4;
            this.mk_ContaP.Tag = "T";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(17, 124);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(69, 15);
            this.Label21.TabIndex = 444;
            this.Label21.Text = "Cód. Conta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 441;
            this.label3.Text = "Tipo de Relatório";
            // 
            // ck_ConciliadoPesquisa
            // 
            this.ck_ConciliadoPesquisa.AutoSize = true;
            this.ck_ConciliadoPesquisa.Location = new System.Drawing.Point(20, 252);
            this.ck_ConciliadoPesquisa.Name = "ck_ConciliadoPesquisa";
            this.ck_ConciliadoPesquisa.Size = new System.Drawing.Size(138, 19);
            this.ck_ConciliadoPesquisa.TabIndex = 8;
            this.ck_ConciliadoPesquisa.Text = "Somente Conciliado";
            this.ck_ConciliadoPesquisa.UseVisualStyleBackColor = true;
            // 
            // ck_ExibirConta
            // 
            this.ck_ExibirConta.AutoSize = true;
            this.ck_ExibirConta.Location = new System.Drawing.Point(20, 288);
            this.ck_ExibirConta.Name = "ck_ExibirConta";
            this.ck_ExibirConta.Size = new System.Drawing.Size(196, 19);
            this.ck_ExibirConta.TabIndex = 9;
            this.ck_ExibirConta.Text = "Exibir lançamentos detalhados";
            this.ck_ExibirConta.UseVisualStyleBackColor = true;
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(20, 34);
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(282, 23);
            this.cb_Tipo.TabIndex = 1;
            this.cb_Tipo.Tag = "T";
            // 
            // cb_Caixa
            // 
            this.cb_Caixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Caixa.FormattingEnabled = true;
            this.cb_Caixa.Location = new System.Drawing.Point(21, 87);
            this.cb_Caixa.Name = "cb_Caixa";
            this.cb_Caixa.Size = new System.Drawing.Size(282, 23);
            this.cb_Caixa.TabIndex = 2;
            this.cb_Caixa.Tag = "T";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(129, 206);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 440;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(152, 201);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 7;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(21, 201);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 6;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 441;
            this.label1.Text = "Caixa / Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 444;
            this.label2.Text = "Período";
            // 
            // UI_FluxoCaixa_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_FluxoCaixa_Relatorio";
            this.Load += new System.EventHandler(this.UI_FluxoCaixa_Relatorio_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bt_PesquisaConta_P;
        internal System.Windows.Forms.MaskedTextBox mk_ContaP;
        internal System.Windows.Forms.Label Label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_ConciliadoPesquisa;
        private System.Windows.Forms.CheckBox ck_ExibirConta;
        internal System.Windows.Forms.ComboBox cb_Tipo;
        internal System.Windows.Forms.ComboBox cb_Caixa;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

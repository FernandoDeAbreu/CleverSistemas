namespace Sistema.UI
{
    partial class UI_ContratoServico
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
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.mk_Emissao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mk_InicioContrato = new System.Windows.Forms.MaskedTextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.lb_DescricaoPessoa = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label17);
            this.gb_Cadastro.Controls.Add(this.mk_Emissao);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.mk_InicioContrato);
            this.gb_Cadastro.Controls.Add(this.Label10);
            this.gb_Cadastro.Controls.Add(this.lb_DescricaoPessoa);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(75, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(141, 15);
            this.label17.TabIndex = 685;
            this.label17.Text = "F7 (Pesquisa avançada)";
            // 
            // mk_Emissao
            // 
            this.mk_Emissao.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Emissao.Location = new System.Drawing.Point(7, 145);
            this.mk_Emissao.Mask = "00/00/0000";
            this.mk_Emissao.Name = "mk_Emissao";
            this.mk_Emissao.Size = new System.Drawing.Size(83, 21);
            this.mk_Emissao.TabIndex = 51;
            this.mk_Emissao.Tag = "T";
            this.mk_Emissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Emissao.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 53;
            this.label3.Text = "Emissão";
            // 
            // mk_InicioContrato
            // 
            this.mk_InicioContrato.BackColor = System.Drawing.SystemColors.Window;
            this.mk_InicioContrato.Location = new System.Drawing.Point(7, 90);
            this.mk_InicioContrato.Mask = "00/00/0000";
            this.mk_InicioContrato.Name = "mk_InicioContrato";
            this.mk_InicioContrato.Size = new System.Drawing.Size(83, 21);
            this.mk_InicioContrato.TabIndex = 50;
            this.mk_InicioContrato.Tag = "T";
            this.mk_InicioContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_InicioContrato.ValidatingType = typeof(System.DateTime);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(3, 71);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(86, 15);
            this.Label10.TabIndex = 54;
            this.Label10.Text = "Inicio Contrato";
            // 
            // lb_DescricaoPessoa
            // 
            this.lb_DescricaoPessoa.AutoSize = true;
            this.lb_DescricaoPessoa.Location = new System.Drawing.Point(3, 18);
            this.lb_DescricaoPessoa.Name = "lb_DescricaoPessoa";
            this.lb_DescricaoPessoa.Size = new System.Drawing.Size(63, 15);
            this.lb_DescricaoPessoa.TabIndex = 52;
            this.lb_DescricaoPessoa.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(7, 39);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(527, 23);
            this.cb_ID_Pessoa.TabIndex = 49;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // UI_ContratoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_ContratoServico";
            this.Load += new System.EventHandler(this.UI_ContratoServico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_ContratoServico_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.MaskedTextBox mk_Emissao;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.MaskedTextBox mk_InicioContrato;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label lb_DescricaoPessoa;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label label17;
    }
}

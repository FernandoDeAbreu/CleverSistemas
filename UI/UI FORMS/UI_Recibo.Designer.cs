namespace Sistema.UI
{
    partial class UI_Recibo
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
            this.txt_CNPJ_CPF = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.ck_2Vias = new System.Windows.Forms.CheckBox();
            this.cb_TipoRecibo = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Referente = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.txt_Referente);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.txt_Valor);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.txt_CNPJ_CPF);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.Label9);
            this.TabPage1.Controls.Add(this.cb_TipoRecibo);
            this.TabPage1.Controls.Add(this.ck_2Vias);
            // 
            // txt_CNPJ_CPF
            // 
            this.txt_CNPJ_CPF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CNPJ_CPF.Location = new System.Drawing.Point(23, 152);
            this.txt_CNPJ_CPF.Name = "txt_CNPJ_CPF";
            this.txt_CNPJ_CPF.Size = new System.Drawing.Size(172, 21);
            this.txt_CNPJ_CPF.TabIndex = 10;
            this.txt_CNPJ_CPF.Tag = "";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(20, 132);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(66, 15);
            this.Label9.TabIndex = 679;
            this.Label9.Text = "CNPJ/CPF";
            // 
            // ck_2Vias
            // 
            this.ck_2Vias.AutoSize = true;
            this.ck_2Vias.Location = new System.Drawing.Point(23, 388);
            this.ck_2Vias.Name = "ck_2Vias";
            this.ck_2Vias.Size = new System.Drawing.Size(109, 19);
            this.ck_2Vias.TabIndex = 15;
            this.ck_2Vias.Text = "Imprimir 2 Vias";
            this.ck_2Vias.UseVisualStyleBackColor = true;
            // 
            // cb_TipoRecibo
            // 
            this.cb_TipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRecibo.FormattingEnabled = true;
            this.cb_TipoRecibo.Items.AddRange(new object[] {
            "RECEBIMENTO",
            "PAGAMENTO"});
            this.cb_TipoRecibo.Location = new System.Drawing.Point(23, 39);
            this.cb_TipoRecibo.Name = "cb_TipoRecibo";
            this.cb_TipoRecibo.Size = new System.Drawing.Size(172, 23);
            this.cb_TipoRecibo.TabIndex = 1;
            this.cb_TipoRecibo.Tag = "T";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(23, 95);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(172, 23);
            this.cb_TipoPessoa.TabIndex = 2;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 676;
            this.label3.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 677;
            this.label5.Text = "Tipo de Recibo";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(20, 76);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(77, 15);
            this.Label4.TabIndex = 678;
            this.Label4.Text = "Tipo Pessoa";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(203, 95);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(521, 23);
            this.cb_ID_Pessoa.TabIndex = 3;
            this.cb_ID_Pessoa.Leave += new System.EventHandler(this.cb_ID_Pessoa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 679;
            this.label1.Text = "Valor";
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Valor.Location = new System.Drawing.Point(23, 208);
            this.txt_Valor.MaxLength = 15;
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(118, 21);
            this.txt_Valor.TabIndex = 11;
            this.txt_Valor.Tag = "";
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 679;
            this.label2.Text = "Referente";
            // 
            // txt_Referente
            // 
            this.txt_Referente.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Referente.Location = new System.Drawing.Point(23, 264);
            this.txt_Referente.Multiline = true;
            this.txt_Referente.Name = "txt_Referente";
            this.txt_Referente.Size = new System.Drawing.Size(700, 118);
            this.txt_Referente.TabIndex = 12;
            this.txt_Referente.Tag = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(271, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 680;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Recibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Recibo";
            this.Load += new System.EventHandler(this.UI_Recibo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Recibo_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Recibo_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_CNPJ_CPF;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.CheckBox ck_2Vias;
        internal System.Windows.Forms.ComboBox cb_TipoRecibo;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_Referente;
        internal System.Windows.Forms.Label label27;
    }
}

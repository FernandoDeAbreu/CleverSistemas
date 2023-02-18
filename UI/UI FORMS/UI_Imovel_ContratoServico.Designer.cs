namespace Sistema.UI
{
    partial class UI_Imovel_ContratoServico
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
            this.cb_ID_Proprietario = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Doc_Test2 = new System.Windows.Forms.TextBox();
            this.txt_Descricao_Test2 = new System.Windows.Forms.TextBox();
            this.txt_Doc_Test1 = new System.Windows.Forms.TextBox();
            this.txt_Descricao_Test1 = new System.Windows.Forms.TextBox();
            this.mk_Emissao = new System.Windows.Forms.MaskedTextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID_P = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa_P = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.label4);
            this.TabPage2.Controls.Add(this.label2);
            this.TabPage2.Controls.Add(this.txt_ID_P);
            this.TabPage2.Controls.Add(this.label3);
            this.TabPage2.Controls.Add(this.cb_ID_Pessoa_P);
            this.TabPage2.Controls.SetChildIndex(this.cb_ID_Pessoa_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label3, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ID_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label2, 0);
            this.TabPage2.Controls.SetChildIndex(this.label4, 0);
            // 
            // cb_ID_Proprietario
            // 
            this.cb_ID_Proprietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Proprietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Proprietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Proprietario.FormattingEnabled = true;
            this.cb_ID_Proprietario.Location = new System.Drawing.Point(6, 90);
            this.cb_ID_Proprietario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Proprietario.Name = "cb_ID_Proprietario";
            this.cb_ID_Proprietario.Size = new System.Drawing.Size(539, 23);
            this.cb_ID_Proprietario.TabIndex = 2;
            this.cb_ID_Proprietario.Tag = "T";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 72);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 671;
            this.label16.Text = "Proprietário";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(330, 245);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 676;
            this.label17.Text = "CPF/RG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 677;
            this.label1.Text = "Testemunha 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 245);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 678;
            this.label15.Text = "CPF/RG";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 191);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 15);
            this.label14.TabIndex = 679;
            this.label14.Text = "Testemunha 1";
            // 
            // txt_Doc_Test2
            // 
            this.txt_Doc_Test2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Doc_Test2.Location = new System.Drawing.Point(334, 265);
            this.txt_Doc_Test2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Doc_Test2.MaxLength = 18;
            this.txt_Doc_Test2.Name = "txt_Doc_Test2";
            this.txt_Doc_Test2.Size = new System.Drawing.Size(279, 21);
            this.txt_Doc_Test2.TabIndex = 7;
            this.txt_Doc_Test2.Tag = "T";
            // 
            // txt_Descricao_Test2
            // 
            this.txt_Descricao_Test2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao_Test2.Location = new System.Drawing.Point(334, 210);
            this.txt_Descricao_Test2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao_Test2.MaxLength = 60;
            this.txt_Descricao_Test2.Name = "txt_Descricao_Test2";
            this.txt_Descricao_Test2.Size = new System.Drawing.Size(279, 21);
            this.txt_Descricao_Test2.TabIndex = 6;
            this.txt_Descricao_Test2.Tag = "T";
            // 
            // txt_Doc_Test1
            // 
            this.txt_Doc_Test1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Doc_Test1.Location = new System.Drawing.Point(6, 265);
            this.txt_Doc_Test1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Doc_Test1.MaxLength = 18;
            this.txt_Doc_Test1.Name = "txt_Doc_Test1";
            this.txt_Doc_Test1.Size = new System.Drawing.Size(279, 21);
            this.txt_Doc_Test1.TabIndex = 5;
            this.txt_Doc_Test1.Tag = "T";
            // 
            // txt_Descricao_Test1
            // 
            this.txt_Descricao_Test1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao_Test1.Location = new System.Drawing.Point(6, 210);
            this.txt_Descricao_Test1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao_Test1.MaxLength = 60;
            this.txt_Descricao_Test1.Name = "txt_Descricao_Test1";
            this.txt_Descricao_Test1.Size = new System.Drawing.Size(279, 21);
            this.txt_Descricao_Test1.TabIndex = 4;
            this.txt_Descricao_Test1.Tag = "T";
            // 
            // mk_Emissao
            // 
            this.mk_Emissao.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Emissao.Location = new System.Drawing.Point(6, 148);
            this.mk_Emissao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Emissao.Mask = "00/00/0000";
            this.mk_Emissao.Name = "mk_Emissao";
            this.mk_Emissao.Size = new System.Drawing.Size(93, 21);
            this.mk_Emissao.TabIndex = 3;
            this.mk_Emissao.Tag = "T";
            this.mk_Emissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Emissao.ValidatingType = typeof(System.DateTime);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(2, 130);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 15);
            this.Label12.TabIndex = 681;
            this.Label12.Text = "Data";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 18);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 683;
            this.Label5.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(6, 39);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.MaxLength = 15;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(89, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label27);
            this.gb_Cadastro.Controls.Add(this.txt_Doc_Test1);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.label14);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label15);
            this.gb_Cadastro.Controls.Add(this.mk_Emissao);
            this.gb_Cadastro.Controls.Add(this.txt_Doc_Test2);
            this.gb_Cadastro.Controls.Add(this.label16);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.Label12);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao_Test2);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Proprietario);
            this.gb_Cadastro.Controls.Add(this.label17);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao_Test1);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(78, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 684;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 687;
            this.label2.Text = "Código";
            // 
            // txt_ID_P
            // 
            this.txt_ID_P.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID_P.Location = new System.Drawing.Point(8, 29);
            this.txt_ID_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID_P.MaxLength = 15;
            this.txt_ID_P.Name = "txt_ID_P";
            this.txt_ID_P.ReadOnly = true;
            this.txt_ID_P.Size = new System.Drawing.Size(89, 21);
            this.txt_ID_P.TabIndex = 2;
            this.txt_ID_P.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 686;
            this.label3.Text = "Proprietário";
            // 
            // cb_ID_Pessoa_P
            // 
            this.cb_ID_Pessoa_P.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa_P.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa_P.FormattingEnabled = true;
            this.cb_ID_Pessoa_P.Location = new System.Drawing.Point(8, 80);
            this.cb_ID_Pessoa_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Pessoa_P.Name = "cb_ID_Pessoa_P";
            this.cb_ID_Pessoa_P.Size = new System.Drawing.Size(539, 23);
            this.cb_ID_Pessoa_P.TabIndex = 3;
            this.cb_ID_Pessoa_P.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(80, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 15);
            this.label4.TabIndex = 688;
            this.label4.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Imovel_ContratoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Imovel_ContratoServico";
            this.Load += new System.EventHandler(this.UI_Imovel_Contrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Imovel_ContratoServico_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cb_ID_Proprietario;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txt_Doc_Test2;
        internal System.Windows.Forms.TextBox txt_Descricao_Test2;
        internal System.Windows.Forms.TextBox txt_Doc_Test1;
        internal System.Windows.Forms.TextBox txt_Descricao_Test1;
        internal System.Windows.Forms.MaskedTextBox mk_Emissao;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ID_P;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa_P;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label4;
    }
}

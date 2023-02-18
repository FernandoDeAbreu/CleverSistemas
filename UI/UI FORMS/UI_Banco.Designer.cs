namespace Sistema.UI
{
    partial class UI_Banco
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
            this.txt_Limite = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txt_Conta = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_Agencia = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_ID_Banco = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.cb_ID_Caixa = new System.Windows.Forms.ComboBox();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_ContaP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_AgenciaP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ID_BancoP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_ID_CaixaP = new System.Windows.Forms.ComboBox();
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
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.label12);
            this.TabPage2.Controls.Add(this.txt_ContaP);
            this.TabPage2.Controls.Add(this.label7);
            this.TabPage2.Controls.Add(this.txt_AgenciaP);
            this.TabPage2.Controls.Add(this.label8);
            this.TabPage2.Controls.Add(this.txt_ID_BancoP);
            this.TabPage2.Controls.Add(this.label10);
            this.TabPage2.Controls.Add(this.label11);
            this.TabPage2.Controls.Add(this.cb_ID_CaixaP);
            this.TabPage2.Controls.SetChildIndex(this.cb_ID_CaixaP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label11, 0);
            this.TabPage2.Controls.SetChildIndex(this.label10, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ID_BancoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label8, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_AgenciaP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label7, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ContaP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label12, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Click += new System.EventHandler(this.bt_Edita_Click);
            // 
            // txt_Limite
            // 
            this.txt_Limite.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Limite.Location = new System.Drawing.Point(7, 281);
            this.txt_Limite.MaxLength = 10;
            this.txt_Limite.Name = "txt_Limite";
            this.txt_Limite.Size = new System.Drawing.Size(138, 21);
            this.txt_Limite.TabIndex = 15;
            this.txt_Limite.Tag = "T";
            this.txt_Limite.Text = "0,00";
            this.txt_Limite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Limite.Leave += new System.EventHandler(this.txt_Limite_Leave);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(3, 260);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(41, 15);
            this.Label9.TabIndex = 64;
            this.Label9.Text = "Limite";
            // 
            // txt_Conta
            // 
            this.txt_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Conta.Location = new System.Drawing.Point(87, 184);
            this.txt_Conta.MaxLength = 10;
            this.txt_Conta.Name = "txt_Conta";
            this.txt_Conta.Size = new System.Drawing.Size(116, 21);
            this.txt_Conta.TabIndex = 11;
            this.txt_Conta.Tag = "T";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(84, 165);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 15);
            this.Label5.TabIndex = 62;
            this.Label5.Text = "Conta*";
            // 
            // txt_Agencia
            // 
            this.txt_Agencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Agencia.Location = new System.Drawing.Point(7, 184);
            this.txt_Agencia.MaxLength = 6;
            this.txt_Agencia.Name = "txt_Agencia";
            this.txt_Agencia.Size = new System.Drawing.Size(73, 21);
            this.txt_Agencia.TabIndex = 10;
            this.txt_Agencia.Tag = "T";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(3, 165);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 15);
            this.Label4.TabIndex = 63;
            this.Label4.Text = "Agência*";
            // 
            // txt_ID_Banco
            // 
            this.txt_ID_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Banco.Location = new System.Drawing.Point(7, 88);
            this.txt_ID_Banco.MaxLength = 3;
            this.txt_ID_Banco.Name = "txt_ID_Banco";
            this.txt_ID_Banco.Size = new System.Drawing.Size(73, 21);
            this.txt_ID_Banco.TabIndex = 2;
            this.txt_ID_Banco.Tag = "T";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 69);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 15);
            this.Label3.TabIndex = 61;
            this.Label3.Text = "Cód. Banco";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 212);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 15);
            this.Label6.TabIndex = 60;
            this.Label6.Text = "Caixa";
            // 
            // cb_ID_Caixa
            // 
            this.cb_ID_Caixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Caixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Caixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Caixa.FormattingEnabled = true;
            this.cb_ID_Caixa.Location = new System.Drawing.Point(7, 231);
            this.cb_ID_Caixa.Name = "cb_ID_Caixa";
            this.cb_ID_Caixa.Size = new System.Drawing.Size(296, 23);
            this.cb_ID_Caixa.TabIndex = 12;
            this.cb_ID_Caixa.Tag = "T";
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label17);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.txt_ID_Banco);
            this.gb_Cadastro.Controls.Add(this.txt_Limite);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Caixa);
            this.gb_Cadastro.Controls.Add(this.Label9);
            this.gb_Cadastro.Controls.Add(this.Label6);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.txt_Conta);
            this.gb_Cadastro.Controls.Add(this.Label3);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.Label4);
            this.gb_Cadastro.Controls.Add(this.txt_Agencia);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 65;
            this.gb_Cadastro.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(217, 178);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(272, 30);
            this.label17.TabIndex = 684;
            this.label17.Text = "* Colocar digito verificador separado por traço(-).\r\n   Exemplo: 1234-5";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(7, 35);
            this.txt_ID.MaxLength = 3;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(73, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(7, 138);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(296, 21);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 61;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 61;
            this.label2.Text = "Descrição";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(6, 85);
            this.txt_DescricaoP.MaxLength = 10;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(335, 21);
            this.txt_DescricaoP.TabIndex = 4;
            this.txt_DescricaoP.Tag = "T";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 117;
            this.label12.Text = "Descrição";
            // 
            // txt_ContaP
            // 
            this.txt_ContaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ContaP.Location = new System.Drawing.Point(146, 35);
            this.txt_ContaP.MaxLength = 10;
            this.txt_ContaP.Name = "txt_ContaP";
            this.txt_ContaP.Size = new System.Drawing.Size(116, 21);
            this.txt_ContaP.TabIndex = 3;
            this.txt_ContaP.Tag = "T";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 118;
            this.label7.Text = "Conta";
            // 
            // txt_AgenciaP
            // 
            this.txt_AgenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_AgenciaP.Location = new System.Drawing.Point(65, 35);
            this.txt_AgenciaP.MaxLength = 6;
            this.txt_AgenciaP.Name = "txt_AgenciaP";
            this.txt_AgenciaP.Size = new System.Drawing.Size(73, 21);
            this.txt_AgenciaP.TabIndex = 2;
            this.txt_AgenciaP.Tag = "T";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 119;
            this.label8.Text = "Agência";
            // 
            // txt_ID_BancoP
            // 
            this.txt_ID_BancoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_BancoP.Location = new System.Drawing.Point(6, 35);
            this.txt_ID_BancoP.MaxLength = 3;
            this.txt_ID_BancoP.Name = "txt_ID_BancoP";
            this.txt_ID_BancoP.Size = new System.Drawing.Size(52, 21);
            this.txt_ID_BancoP.TabIndex = 1;
            this.txt_ID_BancoP.Tag = "T";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 116;
            this.label10.Text = "Banco";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 115;
            this.label11.Text = "Caixa";
            // 
            // cb_ID_CaixaP
            // 
            this.cb_ID_CaixaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_CaixaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_CaixaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_CaixaP.FormattingEnabled = true;
            this.cb_ID_CaixaP.Location = new System.Drawing.Point(349, 84);
            this.cb_ID_CaixaP.Name = "cb_ID_CaixaP";
            this.cb_ID_CaixaP.Size = new System.Drawing.Size(296, 23);
            this.cb_ID_CaixaP.TabIndex = 5;
            this.cb_ID_CaixaP.Tag = "T";
            // 
            // UI_Banco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Banco";
            this.Load += new System.EventHandler(this.UI_Banco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Banco_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Banco_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Limite;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txt_Conta;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_Agencia;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_ID_Banco;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cb_ID_Caixa;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txt_ContaP;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_AgenciaP;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_ID_BancoP;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cb_ID_CaixaP;
        internal System.Windows.Forms.Label label17;
    }
}

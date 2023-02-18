namespace Sistema.UI
{
    partial class UI_Usuario
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
            this.ck_MultiEmpresa = new System.Windows.Forms.CheckBox();
            this.lb_TipoPessoa = new System.Windows.Forms.Label();
            this.ck_Cadastrado = new System.Windows.Forms.CheckBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.lb_DescricaoPessoa = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.ck_UsuarioSistema = new System.Windows.Forms.CheckBox();
            this.txt_SenhaMobile = new System.Windows.Forms.TextBox();
            this.ck_UsuarioMobile = new System.Windows.Forms.CheckBox();
            this.lb_senhaSistema = new System.Windows.Forms.Label();
            this.txt_SenhaSistema = new System.Windows.Forms.TextBox();
            this.lb_SenhaMobile = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ck_Situacao = new System.Windows.Forms.CheckBox();
            this.txt_TipoPessoa = new System.Windows.Forms.TextBox();
            this.txt_ID_Pessoa = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.txt_IDP = new System.Windows.Forms.TextBox();
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
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.txt_IDP);
            this.TabPage2.Controls.SetChildIndex(this.textBox1, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_IDP, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label5, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label6, 0);
            // 
            // ck_MultiEmpresa
            // 
            this.ck_MultiEmpresa.AutoSize = true;
            this.ck_MultiEmpresa.Location = new System.Drawing.Point(141, 39);
            this.ck_MultiEmpresa.Name = "ck_MultiEmpresa";
            this.ck_MultiEmpresa.Size = new System.Drawing.Size(106, 19);
            this.ck_MultiEmpresa.TabIndex = 2;
            this.ck_MultiEmpresa.Tag = "T";
            this.ck_MultiEmpresa.Text = "Multi-Empresa";
            this.ck_MultiEmpresa.UseVisualStyleBackColor = true;
            // 
            // lb_TipoPessoa
            // 
            this.lb_TipoPessoa.AutoSize = true;
            this.lb_TipoPessoa.Location = new System.Drawing.Point(7, 114);
            this.lb_TipoPessoa.Name = "lb_TipoPessoa";
            this.lb_TipoPessoa.Size = new System.Drawing.Size(77, 15);
            this.lb_TipoPessoa.TabIndex = 38;
            this.lb_TipoPessoa.Text = "Tipo Pessoa";
            // 
            // ck_Cadastrado
            // 
            this.ck_Cadastrado.AutoSize = true;
            this.ck_Cadastrado.Checked = true;
            this.ck_Cadastrado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Cadastrado.Location = new System.Drawing.Point(10, 88);
            this.ck_Cadastrado.Name = "ck_Cadastrado";
            this.ck_Cadastrado.Size = new System.Drawing.Size(91, 19);
            this.ck_Cadastrado.TabIndex = 5;
            this.ck_Cadastrado.Tag = "T";
            this.ck_Cadastrado.Text = "Cadastrado";
            this.ck_Cadastrado.UseVisualStyleBackColor = true;
            this.ck_Cadastrado.CheckedChanged += new System.EventHandler(this.ck_Cadastrado_CheckedChanged);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(10, 133);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(202, 23);
            this.cb_TipoPessoa.TabIndex = 10;
            this.cb_TipoPessoa.Tag = "";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // lb_DescricaoPessoa
            // 
            this.lb_DescricaoPessoa.AutoSize = true;
            this.lb_DescricaoPessoa.Location = new System.Drawing.Point(7, 164);
            this.lb_DescricaoPessoa.Name = "lb_DescricaoPessoa";
            this.lb_DescricaoPessoa.Size = new System.Drawing.Size(63, 15);
            this.lb_DescricaoPessoa.TabIndex = 39;
            this.lb_DescricaoPessoa.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(10, 183);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(427, 23);
            this.cb_ID_Pessoa.TabIndex = 11;
            this.cb_ID_Pessoa.Tag = "";
            // 
            // ck_UsuarioSistema
            // 
            this.ck_UsuarioSistema.AutoSize = true;
            this.ck_UsuarioSistema.Location = new System.Drawing.Point(10, 318);
            this.ck_UsuarioSistema.Name = "ck_UsuarioSistema";
            this.ck_UsuarioSistema.Size = new System.Drawing.Size(119, 19);
            this.ck_UsuarioSistema.TabIndex = 20;
            this.ck_UsuarioSistema.Tag = "T";
            this.ck_UsuarioSistema.Text = "Usuário Sistema";
            this.ck_UsuarioSistema.UseVisualStyleBackColor = true;
            this.ck_UsuarioSistema.CheckedChanged += new System.EventHandler(this.ck_UsuarioSistema_CheckedChanged);
            // 
            // txt_SenhaMobile
            // 
            this.txt_SenhaMobile.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SenhaMobile.Enabled = false;
            this.txt_SenhaMobile.Location = new System.Drawing.Point(222, 362);
            this.txt_SenhaMobile.MaxLength = 60;
            this.txt_SenhaMobile.Name = "txt_SenhaMobile";
            this.txt_SenhaMobile.Size = new System.Drawing.Size(182, 21);
            this.txt_SenhaMobile.TabIndex = 26;
            this.txt_SenhaMobile.Tag = "T";
            this.txt_SenhaMobile.UseSystemPasswordChar = true;
            // 
            // ck_UsuarioMobile
            // 
            this.ck_UsuarioMobile.AutoSize = true;
            this.ck_UsuarioMobile.Location = new System.Drawing.Point(222, 318);
            this.ck_UsuarioMobile.Name = "ck_UsuarioMobile";
            this.ck_UsuarioMobile.Size = new System.Drawing.Size(109, 19);
            this.ck_UsuarioMobile.TabIndex = 25;
            this.ck_UsuarioMobile.Tag = "T";
            this.ck_UsuarioMobile.Text = "Usuário Mobile";
            this.ck_UsuarioMobile.UseVisualStyleBackColor = true;
            this.ck_UsuarioMobile.CheckedChanged += new System.EventHandler(this.ck_UsuarioMobile_CheckedChanged);
            // 
            // lb_senhaSistema
            // 
            this.lb_senhaSistema.AutoSize = true;
            this.lb_senhaSistema.Enabled = false;
            this.lb_senhaSistema.Location = new System.Drawing.Point(7, 343);
            this.lb_senhaSistema.Name = "lb_senhaSistema";
            this.lb_senhaSistema.Size = new System.Drawing.Size(92, 15);
            this.lb_senhaSistema.TabIndex = 36;
            this.lb_senhaSistema.Text = "Senha Sistema";
            // 
            // txt_SenhaSistema
            // 
            this.txt_SenhaSistema.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SenhaSistema.Enabled = false;
            this.txt_SenhaSistema.Location = new System.Drawing.Point(10, 362);
            this.txt_SenhaSistema.MaxLength = 60;
            this.txt_SenhaSistema.Name = "txt_SenhaSistema";
            this.txt_SenhaSistema.Size = new System.Drawing.Size(182, 21);
            this.txt_SenhaSistema.TabIndex = 21;
            this.txt_SenhaSistema.Tag = "T";
            this.txt_SenhaSistema.UseSystemPasswordChar = true;
            // 
            // lb_SenhaMobile
            // 
            this.lb_SenhaMobile.AutoSize = true;
            this.lb_SenhaMobile.Enabled = false;
            this.lb_SenhaMobile.Location = new System.Drawing.Point(218, 343);
            this.lb_SenhaMobile.Name = "lb_SenhaMobile";
            this.lb_SenhaMobile.Size = new System.Drawing.Size(82, 15);
            this.lb_SenhaMobile.TabIndex = 35;
            this.lb_SenhaMobile.Text = "Senha Mobile";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(10, 260);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(307, 21);
            this.txt_Descricao.TabIndex = 15;
            this.txt_Descricao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Descrição";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(10, 35);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(93, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Código";
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label27);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.ck_Situacao);
            this.gb_Cadastro.Controls.Add(this.ck_MultiEmpresa);
            this.gb_Cadastro.Controls.Add(this.lb_SenhaMobile);
            this.gb_Cadastro.Controls.Add(this.lb_TipoPessoa);
            this.gb_Cadastro.Controls.Add(this.txt_SenhaSistema);
            this.gb_Cadastro.Controls.Add(this.ck_Cadastrado);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.cb_TipoPessoa);
            this.gb_Cadastro.Controls.Add(this.txt_TipoPessoa);
            this.gb_Cadastro.Controls.Add(this.txt_ID_Pessoa);
            this.gb_Cadastro.Controls.Add(this.lb_DescricaoPessoa);
            this.gb_Cadastro.Controls.Add(this.lb_senhaSistema);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Controls.Add(this.ck_UsuarioMobile);
            this.gb_Cadastro.Controls.Add(this.ck_UsuarioSistema);
            this.gb_Cadastro.Controls.Add(this.txt_SenhaMobile);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 45;
            this.gb_Cadastro.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(78, 164);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 70;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // ck_Situacao
            // 
            this.ck_Situacao.AutoSize = true;
            this.ck_Situacao.Location = new System.Drawing.Point(275, 39);
            this.ck_Situacao.Name = "ck_Situacao";
            this.ck_Situacao.Size = new System.Drawing.Size(51, 19);
            this.ck_Situacao.TabIndex = 3;
            this.ck_Situacao.Tag = "T";
            this.ck_Situacao.Text = "Ativo";
            this.ck_Situacao.UseVisualStyleBackColor = true;
            // 
            // txt_TipoPessoa
            // 
            this.txt_TipoPessoa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_TipoPessoa.Enabled = false;
            this.txt_TipoPessoa.Location = new System.Drawing.Point(35, 35);
            this.txt_TipoPessoa.Name = "txt_TipoPessoa";
            this.txt_TipoPessoa.ReadOnly = true;
            this.txt_TipoPessoa.Size = new System.Drawing.Size(27, 21);
            this.txt_TipoPessoa.TabIndex = 42;
            this.txt_TipoPessoa.Tag = "T";
            this.txt_TipoPessoa.TextChanged += new System.EventHandler(this.txt_TipoPessoa_TextChanged);
            // 
            // txt_ID_Pessoa
            // 
            this.txt_ID_Pessoa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID_Pessoa.Enabled = false;
            this.txt_ID_Pessoa.Location = new System.Drawing.Point(70, 35);
            this.txt_ID_Pessoa.Name = "txt_ID_Pessoa";
            this.txt_ID_Pessoa.ReadOnly = true;
            this.txt_ID_Pessoa.Size = new System.Drawing.Size(27, 21);
            this.txt_ID_Pessoa.TabIndex = 42;
            this.txt_ID_Pessoa.Tag = "T";
            this.txt_ID_Pessoa.TextChanged += new System.EventHandler(this.txt_ID_Pessoa_TextChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 64);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(63, 15);
            this.Label6.TabIndex = 111;
            this.Label6.Text = "Descrição";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 17);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 110;
            this.Label5.Text = "Código";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(9, 85);
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(391, 21);
            this.txt_DescricaoP.TabIndex = 2;
            this.txt_DescricaoP.Tag = "T";
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(9, 36);
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(98, 21);
            this.txt_IDP.TabIndex = 1;
            this.txt_IDP.Tag = "T";
            // 
            // UI_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Usuario";
            this.Load += new System.EventHandler(this.UI_Usuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Usuario_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UI_Usuario_KeyUp);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckBox ck_MultiEmpresa;
        internal System.Windows.Forms.Label lb_TipoPessoa;
        internal System.Windows.Forms.CheckBox ck_Cadastrado;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label lb_DescricaoPessoa;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.CheckBox ck_UsuarioSistema;
        internal System.Windows.Forms.TextBox txt_SenhaMobile;
        internal System.Windows.Forms.CheckBox ck_UsuarioMobile;
        internal System.Windows.Forms.Label lb_senhaSistema;
        internal System.Windows.Forms.TextBox txt_SenhaSistema;
        internal System.Windows.Forms.Label lb_SenhaMobile;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.TextBox txt_Descricao;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.CheckBox ck_Situacao;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.TextBox txt_IDP;
        internal System.Windows.Forms.TextBox txt_ID_Pessoa;
        internal System.Windows.Forms.TextBox txt_TipoPessoa;
        internal System.Windows.Forms.Label label27;
    }
}

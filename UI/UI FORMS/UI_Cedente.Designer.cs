namespace Sistema.UI
{
    partial class UI_Cedente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Cedente));
            this.gb_GrupoNivel = new System.Windows.Forms.GroupBox();
            this.mk_Conta = new System.Windows.Forms.MaskedTextBox();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_DescricaoConta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_ID_Conta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_ID_Banco = new System.Windows.Forms.ComboBox();
            this.txt_DiasMulta = new System.Windows.Forms.TextBox();
            this.txt_DiasJuros = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Instrucao_1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Multa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Juros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CNPJ_CPF_Cedente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_Razao_Cedente = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Carteira = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Cod_Cedente = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.ck_Ativo = new System.Windows.Forms.CheckBox();
            this.ck_Altera_Data = new System.Windows.Forms.CheckBox();
            this.ck_Aceite = new System.Windows.Forms.CheckBox();
            this.ck_UtilizaTarifa = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cb_Tipo_Emissao = new System.Windows.Forms.ComboBox();
            this.cb_Tipo_Doc_Cedente = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Tipo_Cobranca = new System.Windows.Forms.TextBox();
            this.txt_Cod_Protesto = new System.Windows.Forms.TextBox();
            this.txt_DiaProtesto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Tarifa = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_Instrucao_2 = new System.Windows.Forms.TextBox();
            this.txt_IDP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_GrupoNivel.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_IDP);
            this.TabPage2.Controls.Add(this.label15);
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.label16);
            this.TabPage2.Controls.SetChildIndex(this.label16, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label15, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_IDP, 0);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Click += new System.EventHandler(this.bt_Edita_Click);
            // 
            // gb_GrupoNivel
            // 
            this.gb_GrupoNivel.Controls.Add(this.mk_Conta);
            this.gb_GrupoNivel.Controls.Add(this.bt_PesquisaConta);
            this.gb_GrupoNivel.Controls.Add(this.label13);
            this.gb_GrupoNivel.Controls.Add(this.txt_DescricaoConta);
            this.gb_GrupoNivel.Controls.Add(this.label14);
            this.gb_GrupoNivel.Controls.Add(this.txt_ID_Conta);
            this.gb_GrupoNivel.Location = new System.Drawing.Point(421, 78);
            this.gb_GrupoNivel.Name = "gb_GrupoNivel";
            this.gb_GrupoNivel.Size = new System.Drawing.Size(491, 161);
            this.gb_GrupoNivel.TabIndex = 22;
            this.gb_GrupoNivel.TabStop = false;
            this.gb_GrupoNivel.Text = "Conta Lançamento de Tarifa";
            // 
            // mk_Conta
            // 
            this.mk_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Conta.Location = new System.Drawing.Point(7, 39);
            this.mk_Conta.Mask = "00,00,00,00";
            this.mk_Conta.Name = "mk_Conta";
            this.mk_Conta.PromptChar = '0';
            this.mk_Conta.Size = new System.Drawing.Size(75, 21);
            this.mk_Conta.TabIndex = 23;
            this.mk_Conta.Tag = "T";
            this.mk_Conta.TextChanged += new System.EventHandler(this.mk_Conta_TextChanged);
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(87, 36);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 24;
            this.bt_PesquisaConta.UseVisualStyleBackColor = true;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Descricao Conta";
            // 
            // txt_DescricaoConta
            // 
            this.txt_DescricaoConta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_DescricaoConta.Location = new System.Drawing.Point(7, 86);
            this.txt_DescricaoConta.MaxLength = 60;
            this.txt_DescricaoConta.Multiline = true;
            this.txt_DescricaoConta.Name = "txt_DescricaoConta";
            this.txt_DescricaoConta.ReadOnly = true;
            this.txt_DescricaoConta.Size = new System.Drawing.Size(476, 66);
            this.txt_DescricaoConta.TabIndex = 25;
            this.txt_DescricaoConta.TabStop = false;
            this.txt_DescricaoConta.Tag = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Cód. Grupo";
            // 
            // txt_ID_Conta
            // 
            this.txt_ID_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Conta.Enabled = false;
            this.txt_ID_Conta.Location = new System.Drawing.Point(55, 39);
            this.txt_ID_Conta.Name = "txt_ID_Conta";
            this.txt_ID_Conta.Size = new System.Drawing.Size(21, 21);
            this.txt_ID_Conta.TabIndex = 95;
            this.txt_ID_Conta.Tag = "T";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 85;
            this.label12.Text = "Banco";
            // 
            // cb_ID_Banco
            // 
            this.cb_ID_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Banco.FormattingEnabled = true;
            this.cb_ID_Banco.Location = new System.Drawing.Point(10, 140);
            this.cb_ID_Banco.Name = "cb_ID_Banco";
            this.cb_ID_Banco.Size = new System.Drawing.Size(249, 23);
            this.cb_ID_Banco.TabIndex = 3;
            this.cb_ID_Banco.Tag = "T";
            // 
            // txt_DiasMulta
            // 
            this.txt_DiasMulta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DiasMulta.Location = new System.Drawing.Point(147, 515);
            this.txt_DiasMulta.MaxLength = 2;
            this.txt_DiasMulta.Name = "txt_DiasMulta";
            this.txt_DiasMulta.Size = new System.Drawing.Size(34, 21);
            this.txt_DiasMulta.TabIndex = 16;
            this.txt_DiasMulta.Tag = "T";
            this.txt_DiasMulta.Text = "0";
            this.txt_DiasMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_DiasJuros
            // 
            this.txt_DiasJuros.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DiasJuros.Location = new System.Drawing.Point(147, 451);
            this.txt_DiasJuros.MaxLength = 2;
            this.txt_DiasJuros.Name = "txt_DiasJuros";
            this.txt_DiasJuros.Size = new System.Drawing.Size(34, 21);
            this.txt_DiasJuros.TabIndex = 14;
            this.txt_DiasJuros.Tag = "T";
            this.txt_DiasJuros.Text = "0";
            this.txt_DiasJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 520);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 83;
            this.label10.Text = "Dias";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 454);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 82;
            this.label7.Text = "Dias";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 81;
            this.label9.Text = "Após";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 432);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 80;
            this.label6.Text = "Após";
            // 
            // txt_Instrucao_1
            // 
            this.txt_Instrucao_1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Instrucao_1.Location = new System.Drawing.Point(10, 574);
            this.txt_Instrucao_1.MaxLength = 200;
            this.txt_Instrucao_1.Name = "txt_Instrucao_1";
            this.txt_Instrucao_1.Size = new System.Drawing.Size(364, 21);
            this.txt_Instrucao_1.TabIndex = 20;
            this.txt_Instrucao_1.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 555);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 79;
            this.label11.Text = "Instrução 1";
            // 
            // txt_Multa
            // 
            this.txt_Multa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Multa.Location = new System.Drawing.Point(10, 515);
            this.txt_Multa.MaxLength = 5;
            this.txt_Multa.Name = "txt_Multa";
            this.txt_Multa.Size = new System.Drawing.Size(116, 21);
            this.txt_Multa.TabIndex = 15;
            this.txt_Multa.Tag = "T";
            this.txt_Multa.Text = "0,00";
            this.txt_Multa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Multa.Leave += new System.EventHandler(this.txt_Multa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 496);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 84;
            this.label8.Text = "Multa (%)";
            // 
            // txt_Juros
            // 
            this.txt_Juros.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Juros.Location = new System.Drawing.Point(10, 451);
            this.txt_Juros.MaxLength = 5;
            this.txt_Juros.Name = "txt_Juros";
            this.txt_Juros.Size = new System.Drawing.Size(116, 21);
            this.txt_Juros.TabIndex = 13;
            this.txt_Juros.Tag = "T";
            this.txt_Juros.Text = "0,00";
            this.txt_Juros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Juros.Leave += new System.EventHandler(this.txt_Juros_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "Juros (%) ao Mês";
            // 
            // txt_CNPJ_CPF_Cedente
            // 
            this.txt_CNPJ_CPF_Cedente.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CNPJ_CPF_Cedente.Location = new System.Drawing.Point(134, 387);
            this.txt_CNPJ_CPF_Cedente.MaxLength = 18;
            this.txt_CNPJ_CPF_Cedente.Name = "txt_CNPJ_CPF_Cedente";
            this.txt_CNPJ_CPF_Cedente.Size = new System.Drawing.Size(172, 21);
            this.txt_CNPJ_CPF_Cedente.TabIndex = 12;
            this.txt_CNPJ_CPF_Cedente.Tag = "T";
            this.txt_CNPJ_CPF_Cedente.TextChanged += new System.EventHandler(this.txt_CNPJ_CPF_Cedente_TextChanged);
            this.txt_CNPJ_CPF_Cedente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CNPJ_CPF_Cedente_KeyDown);
            this.txt_CNPJ_CPF_Cedente.Leave += new System.EventHandler(this.txt_CNPJ_CPF_Cedente_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(131, 366);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 15);
            this.label20.TabIndex = 76;
            this.label20.Text = "Documento Cedente";
            // 
            // txt_Razao_Cedente
            // 
            this.txt_Razao_Cedente.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Razao_Cedente.Location = new System.Drawing.Point(10, 326);
            this.txt_Razao_Cedente.MaxLength = 60;
            this.txt_Razao_Cedente.Name = "txt_Razao_Cedente";
            this.txt_Razao_Cedente.Size = new System.Drawing.Size(364, 21);
            this.txt_Razao_Cedente.TabIndex = 10;
            this.txt_Razao_Cedente.Tag = "T";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 305);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 15);
            this.label19.TabIndex = 75;
            this.label19.Text = "Descrição Cedente";
            // 
            // txt_Carteira
            // 
            this.txt_Carteira.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Carteira.Location = new System.Drawing.Point(134, 195);
            this.txt_Carteira.MaxLength = 3;
            this.txt_Carteira.Name = "txt_Carteira";
            this.txt_Carteira.Size = new System.Drawing.Size(59, 21);
            this.txt_Carteira.TabIndex = 5;
            this.txt_Carteira.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 74;
            this.label3.Text = "Carteira";
            // 
            // txt_Cod_Cedente
            // 
            this.txt_Cod_Cedente.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Cod_Cedente.Location = new System.Drawing.Point(10, 195);
            this.txt_Cod_Cedente.MaxLength = 11;
            this.txt_Cod_Cedente.Name = "txt_Cod_Cedente";
            this.txt_Cod_Cedente.Size = new System.Drawing.Size(116, 21);
            this.txt_Cod_Cedente.TabIndex = 4;
            this.txt_Cod_Cedente.Tag = "T";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 176);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 15);
            this.Label5.TabIndex = 78;
            this.Label5.Text = "Cód. Cedente";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(10, 39);
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
            this.txt_Descricao.Location = new System.Drawing.Point(10, 87);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(364, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 91;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Descrição";
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.ck_Ativo);
            this.gb_Cadastro.Controls.Add(this.ck_Altera_Data);
            this.gb_Cadastro.Controls.Add(this.ck_Aceite);
            this.gb_Cadastro.Controls.Add(this.ck_UtilizaTarifa);
            this.gb_Cadastro.Controls.Add(this.label24);
            this.gb_Cadastro.Controls.Add(this.label21);
            this.gb_Cadastro.Controls.Add(this.cb_Tipo_Emissao);
            this.gb_Cadastro.Controls.Add(this.cb_Tipo_Doc_Cedente);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_Cod_Cedente);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.label25);
            this.gb_Cadastro.Controls.Add(this.label26);
            this.gb_Cadastro.Controls.Add(this.label22);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.txt_Tipo_Cobranca);
            this.gb_Cadastro.Controls.Add(this.txt_Cod_Protesto);
            this.gb_Cadastro.Controls.Add(this.txt_DiaProtesto);
            this.gb_Cadastro.Controls.Add(this.txt_Carteira);
            this.gb_Cadastro.Controls.Add(this.label19);
            this.gb_Cadastro.Controls.Add(this.gb_GrupoNivel);
            this.gb_Cadastro.Controls.Add(this.txt_Razao_Cedente);
            this.gb_Cadastro.Controls.Add(this.label17);
            this.gb_Cadastro.Controls.Add(this.label20);
            this.gb_Cadastro.Controls.Add(this.label12);
            this.gb_Cadastro.Controls.Add(this.txt_Tarifa);
            this.gb_Cadastro.Controls.Add(this.txt_CNPJ_CPF_Cedente);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Banco);
            this.gb_Cadastro.Controls.Add(this.label4);
            this.gb_Cadastro.Controls.Add(this.txt_DiasMulta);
            this.gb_Cadastro.Controls.Add(this.txt_Juros);
            this.gb_Cadastro.Controls.Add(this.txt_DiasJuros);
            this.gb_Cadastro.Controls.Add(this.label8);
            this.gb_Cadastro.Controls.Add(this.label10);
            this.gb_Cadastro.Controls.Add(this.txt_Multa);
            this.gb_Cadastro.Controls.Add(this.label23);
            this.gb_Cadastro.Controls.Add(this.label7);
            this.gb_Cadastro.Controls.Add(this.label18);
            this.gb_Cadastro.Controls.Add(this.label11);
            this.gb_Cadastro.Controls.Add(this.label9);
            this.gb_Cadastro.Controls.Add(this.txt_Instrucao_2);
            this.gb_Cadastro.Controls.Add(this.txt_Instrucao_1);
            this.gb_Cadastro.Controls.Add(this.label6);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 93;
            this.gb_Cadastro.TabStop = false;
            // 
            // ck_Ativo
            // 
            this.ck_Ativo.AutoSize = true;
            this.ck_Ativo.Checked = true;
            this.ck_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Ativo.Location = new System.Drawing.Point(134, 41);
            this.ck_Ativo.Name = "ck_Ativo";
            this.ck_Ativo.Size = new System.Drawing.Size(51, 19);
            this.ck_Ativo.TabIndex = 53;
            this.ck_Ativo.TabStop = false;
            this.ck_Ativo.Tag = "T";
            this.ck_Ativo.Text = "Ativo";
            this.ck_Ativo.UseVisualStyleBackColor = true;
            // 
            // ck_Altera_Data
            // 
            this.ck_Altera_Data.AutoSize = true;
            this.ck_Altera_Data.Location = new System.Drawing.Point(421, 391);
            this.ck_Altera_Data.Name = "ck_Altera_Data";
            this.ck_Altera_Data.Size = new System.Drawing.Size(167, 19);
            this.ck_Altera_Data.TabIndex = 54;
            this.ck_Altera_Data.Tag = "T";
            this.ck_Altera_Data.Text = "Permite alteração de data";
            this.ck_Altera_Data.UseVisualStyleBackColor = true;
            // 
            // ck_Aceite
            // 
            this.ck_Aceite.AutoSize = true;
            this.ck_Aceite.Location = new System.Drawing.Point(661, 354);
            this.ck_Aceite.Name = "ck_Aceite";
            this.ck_Aceite.Size = new System.Drawing.Size(59, 19);
            this.ck_Aceite.TabIndex = 53;
            this.ck_Aceite.Tag = "T";
            this.ck_Aceite.Text = "Aceite";
            this.ck_Aceite.UseVisualStyleBackColor = true;
            // 
            // ck_UtilizaTarifa
            // 
            this.ck_UtilizaTarifa.AutoSize = true;
            this.ck_UtilizaTarifa.Location = new System.Drawing.Point(421, 255);
            this.ck_UtilizaTarifa.Name = "ck_UtilizaTarifa";
            this.ck_UtilizaTarifa.Size = new System.Drawing.Size(96, 19);
            this.ck_UtilizaTarifa.TabIndex = 50;
            this.ck_UtilizaTarifa.Tag = "T";
            this.ck_UtilizaTarifa.Text = "Utilizar Tarifa";
            this.ck_UtilizaTarifa.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(418, 331);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 15);
            this.label24.TabIndex = 94;
            this.label24.Text = "Tipo Emissão";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 366);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 15);
            this.label21.TabIndex = 94;
            this.label21.Text = "Tipo Documento";
            // 
            // cb_Tipo_Emissao
            // 
            this.cb_Tipo_Emissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_Emissao.FormattingEnabled = true;
            this.cb_Tipo_Emissao.Location = new System.Drawing.Point(421, 350);
            this.cb_Tipo_Emissao.Name = "cb_Tipo_Emissao";
            this.cb_Tipo_Emissao.Size = new System.Drawing.Size(219, 23);
            this.cb_Tipo_Emissao.TabIndex = 52;
            this.cb_Tipo_Emissao.Tag = "T";
            this.cb_Tipo_Emissao.SelectedValueChanged += new System.EventHandler(this.cb_Tipo_Doc_Cedente_SelectedValueChanged);
            // 
            // cb_Tipo_Doc_Cedente
            // 
            this.cb_Tipo_Doc_Cedente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_Doc_Cedente.FormattingEnabled = true;
            this.cb_Tipo_Doc_Cedente.Location = new System.Drawing.Point(10, 387);
            this.cb_Tipo_Doc_Cedente.Name = "cb_Tipo_Doc_Cedente";
            this.cb_Tipo_Doc_Cedente.Size = new System.Drawing.Size(116, 23);
            this.cb_Tipo_Doc_Cedente.TabIndex = 11;
            this.cb_Tipo_Doc_Cedente.Tag = "T";
            this.cb_Tipo_Doc_Cedente.SelectedValueChanged += new System.EventHandler(this.cb_Tipo_Doc_Cedente_SelectedValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 236);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 15);
            this.label25.TabIndex = 74;
            this.label25.Text = "Tipo Cobrança";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(197, 176);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 15);
            this.label26.TabIndex = 74;
            this.label26.Text = "Cód. Protesto";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(283, 176);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 15);
            this.label22.TabIndex = 74;
            this.label22.Text = "Protestar após";
            // 
            // txt_Tipo_Cobranca
            // 
            this.txt_Tipo_Cobranca.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Tipo_Cobranca.Location = new System.Drawing.Point(13, 255);
            this.txt_Tipo_Cobranca.MaxLength = 3;
            this.txt_Tipo_Cobranca.Name = "txt_Tipo_Cobranca";
            this.txt_Tipo_Cobranca.Size = new System.Drawing.Size(79, 21);
            this.txt_Tipo_Cobranca.TabIndex = 8;
            this.txt_Tipo_Cobranca.Tag = "T";
            this.txt_Tipo_Cobranca.Text = "0";
            this.txt_Tipo_Cobranca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Cod_Protesto
            // 
            this.txt_Cod_Protesto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Cod_Protesto.Location = new System.Drawing.Point(201, 195);
            this.txt_Cod_Protesto.MaxLength = 3;
            this.txt_Cod_Protesto.Name = "txt_Cod_Protesto";
            this.txt_Cod_Protesto.Size = new System.Drawing.Size(79, 21);
            this.txt_Cod_Protesto.TabIndex = 6;
            this.txt_Cod_Protesto.Tag = "T";
            this.txt_Cod_Protesto.Text = "0";
            this.txt_Cod_Protesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_DiaProtesto
            // 
            this.txt_DiaProtesto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DiaProtesto.Location = new System.Drawing.Point(287, 195);
            this.txt_DiaProtesto.MaxLength = 3;
            this.txt_DiaProtesto.Name = "txt_DiaProtesto";
            this.txt_DiaProtesto.Size = new System.Drawing.Size(59, 21);
            this.txt_DiaProtesto.TabIndex = 7;
            this.txt_DiaProtesto.Tag = "T";
            this.txt_DiaProtesto.Text = "0";
            this.txt_DiaProtesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(418, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 15);
            this.label17.TabIndex = 76;
            this.label17.Text = "Tarifa (R$)";
            // 
            // txt_Tarifa
            // 
            this.txt_Tarifa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Tarifa.Location = new System.Drawing.Point(421, 294);
            this.txt_Tarifa.MaxLength = 18;
            this.txt_Tarifa.Name = "txt_Tarifa";
            this.txt_Tarifa.Size = new System.Drawing.Size(101, 21);
            this.txt_Tarifa.TabIndex = 51;
            this.txt_Tarifa.Tag = "T";
            this.txt_Tarifa.Text = "0,00";
            this.txt_Tarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Tarifa.Leave += new System.EventHandler(this.txt_Tarifa_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(353, 198);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 15);
            this.label23.TabIndex = 82;
            this.label23.Text = "Dias";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(379, 555);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 15);
            this.label18.TabIndex = 79;
            this.label18.Text = "Instrução 2";
            // 
            // txt_Instrucao_2
            // 
            this.txt_Instrucao_2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Instrucao_2.Location = new System.Drawing.Point(383, 574);
            this.txt_Instrucao_2.MaxLength = 200;
            this.txt_Instrucao_2.Name = "txt_Instrucao_2";
            this.txt_Instrucao_2.Size = new System.Drawing.Size(364, 21);
            this.txt_Instrucao_2.TabIndex = 21;
            this.txt_Instrucao_2.Tag = "T";
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(5, 29);
            this.txt_IDP.MaxLength = 11;
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(116, 21);
            this.txt_IDP.TabIndex = 107;
            this.txt_IDP.Tag = "T";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 108;
            this.label15.Text = "Código";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(5, 85);
            this.txt_DescricaoP.MaxLength = 60;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(432, 21);
            this.txt_DescricaoP.TabIndex = 109;
            this.txt_DescricaoP.Tag = "T";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 15);
            this.label16.TabIndex = 106;
            this.label16.Text = "Descrição";
            // 
            // UI_Cedente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Cedente";
            this.Load += new System.EventHandler(this.UI_Cedente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Cedente_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Cedente_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_GrupoNivel.ResumeLayout(false);
            this.gb_GrupoNivel.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gb_GrupoNivel;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cb_ID_Banco;
        internal System.Windows.Forms.TextBox txt_DiasMulta;
        internal System.Windows.Forms.TextBox txt_DiasJuros;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_Instrucao_1;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_Multa;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_Juros;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_CNPJ_CPF_Cedente;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txt_Razao_Cedente;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.TextBox txt_Carteira;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_Cod_Cedente;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox cb_Tipo_Doc_Cedente;
        internal System.Windows.Forms.MaskedTextBox mk_Conta;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txt_DescricaoConta;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txt_IDP;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txt_ID_Conta;
        private System.Windows.Forms.CheckBox ck_UtilizaTarifa;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txt_Tarifa;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txt_Instrucao_2;
        private System.Windows.Forms.CheckBox ck_Aceite;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.ComboBox cb_Tipo_Emissao;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txt_DiaProtesto;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.TextBox txt_Cod_Protesto;
        private System.Windows.Forms.CheckBox ck_Ativo;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.TextBox txt_Tipo_Cobranca;
        private System.Windows.Forms.CheckBox ck_Altera_Data;
    }
}

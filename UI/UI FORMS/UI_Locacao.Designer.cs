namespace Sistema.UI
{
    partial class UI_Locacao
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
            this.Label12 = new System.Windows.Forms.Label();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.dg_Fiador = new System.Windows.Forms.DataGridView();
            this.col_Fiador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_Remove_Fiador = new System.Windows.Forms.Button();
            this.bt_add_Fiador = new System.Windows.Forms.Button();
            this.cb_ID_Fiador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dg_Locatario = new System.Windows.Forms.DataGridView();
            this.col_Locatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Remove_Locatario = new System.Windows.Forms.Button();
            this.bt_add_Locatario = new System.Windows.Forms.Button();
            this.cb_ID_Locatario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ID_Imovel = new System.Windows.Forms.ComboBox();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mk_Inicio = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mk_Termino = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Observacao = new System.Windows.Forms.TextBox();
            this.txt_Doc_Test2 = new System.Windows.Forms.TextBox();
            this.txt_Descricao_Test2 = new System.Windows.Forms.TextBox();
            this.txt_Doc_Test1 = new System.Windows.Forms.TextBox();
            this.txt_Descricao_Test1 = new System.Windows.Forms.TextBox();
            this.txt_DiaVencimento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ID_P = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_ID_Imovel_P = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mk_Inicio_P = new System.Windows.Forms.MaskedTextBox();
            this.mk_Termino_P = new System.Windows.Forms.MaskedTextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Fiador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Locatario)).BeginInit();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.label8);
            this.TabPage2.Controls.Add(this.label9);
            this.TabPage2.Controls.Add(this.txt_ID_P);
            this.TabPage2.Controls.Add(this.label10);
            this.TabPage2.Controls.Add(this.cb_ID_Imovel_P);
            this.TabPage2.Controls.Add(this.label11);
            this.TabPage2.Controls.Add(this.mk_Inicio_P);
            this.TabPage2.Controls.Add(this.mk_Termino_P);
            this.TabPage2.Controls.SetChildIndex(this.mk_Termino_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_Inicio_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label11, 0);
            this.TabPage2.Controls.SetChildIndex(this.cb_ID_Imovel_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label10, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ID_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label9, 0);
            this.TabPage2.Controls.SetChildIndex(this.label8, 0);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(104, 16);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 15);
            this.Label12.TabIndex = 91;
            this.Label12.Text = "Data";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(107, 39);
            this.mk_Data.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(93, 21);
            this.mk_Data.TabIndex = 2;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // dg_Fiador
            // 
            this.dg_Fiador.AllowUserToAddRows = false;
            this.dg_Fiador.AllowUserToDeleteRows = false;
            this.dg_Fiador.AllowUserToResizeColumns = false;
            this.dg_Fiador.AllowUserToResizeRows = false;
            this.dg_Fiador.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Fiador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Fiador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Fiador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Fiador});
            this.dg_Fiador.Location = new System.Drawing.Point(474, 279);
            this.dg_Fiador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Fiador.MultiSelect = false;
            this.dg_Fiador.Name = "dg_Fiador";
            this.dg_Fiador.ReadOnly = true;
            this.dg_Fiador.RowHeadersVisible = false;
            this.dg_Fiador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Fiador.Size = new System.Drawing.Size(416, 149);
            this.dg_Fiador.StandardTab = true;
            this.dg_Fiador.TabIndex = 22;
            // 
            // col_Fiador
            // 
            this.col_Fiador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Fiador.HeaderText = "Fiador";
            this.col_Fiador.Name = "col_Fiador";
            this.col_Fiador.ReadOnly = true;
            // 
            // cb_Remove_Fiador
            // 
            this.cb_Remove_Fiador.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Remove_Fiador.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.cb_Remove_Fiador.Location = new System.Drawing.Point(895, 279);
            this.cb_Remove_Fiador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_Remove_Fiador.Name = "cb_Remove_Fiador";
            this.cb_Remove_Fiador.Size = new System.Drawing.Size(36, 27);
            this.cb_Remove_Fiador.TabIndex = 23;
            this.cb_Remove_Fiador.UseVisualStyleBackColor = true;
            this.cb_Remove_Fiador.Click += new System.EventHandler(this.cb_Remove_Fiador_Click);
            // 
            // bt_add_Fiador
            // 
            this.bt_add_Fiador.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_Fiador.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_add_Fiador.Location = new System.Drawing.Point(854, 245);
            this.bt_add_Fiador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_add_Fiador.Name = "bt_add_Fiador";
            this.bt_add_Fiador.Size = new System.Drawing.Size(36, 27);
            this.bt_add_Fiador.TabIndex = 21;
            this.bt_add_Fiador.UseVisualStyleBackColor = true;
            this.bt_add_Fiador.Click += new System.EventHandler(this.bt_add_Fiador_Click);
            // 
            // cb_ID_Fiador
            // 
            this.cb_ID_Fiador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Fiador.FormattingEnabled = true;
            this.cb_ID_Fiador.Location = new System.Drawing.Point(474, 246);
            this.cb_ID_Fiador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Fiador.Name = "cb_ID_Fiador";
            this.cb_ID_Fiador.Size = new System.Drawing.Size(375, 23);
            this.cb_ID_Fiador.TabIndex = 20;
            this.cb_ID_Fiador.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Fiador";
            // 
            // dg_Locatario
            // 
            this.dg_Locatario.AllowUserToAddRows = false;
            this.dg_Locatario.AllowUserToDeleteRows = false;
            this.dg_Locatario.AllowUserToResizeColumns = false;
            this.dg_Locatario.AllowUserToResizeRows = false;
            this.dg_Locatario.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Locatario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Locatario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Locatario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Locatario});
            this.dg_Locatario.Location = new System.Drawing.Point(6, 279);
            this.dg_Locatario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Locatario.MultiSelect = false;
            this.dg_Locatario.Name = "dg_Locatario";
            this.dg_Locatario.ReadOnly = true;
            this.dg_Locatario.RowHeadersVisible = false;
            this.dg_Locatario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Locatario.Size = new System.Drawing.Size(416, 149);
            this.dg_Locatario.StandardTab = true;
            this.dg_Locatario.TabIndex = 17;
            // 
            // col_Locatario
            // 
            this.col_Locatario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Locatario.HeaderText = "Locatário";
            this.col_Locatario.Name = "col_Locatario";
            this.col_Locatario.ReadOnly = true;
            // 
            // bt_Remove_Locatario
            // 
            this.bt_Remove_Locatario.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Remove_Locatario.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Remove_Locatario.Location = new System.Drawing.Point(427, 279);
            this.bt_Remove_Locatario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Remove_Locatario.Name = "bt_Remove_Locatario";
            this.bt_Remove_Locatario.Size = new System.Drawing.Size(36, 27);
            this.bt_Remove_Locatario.TabIndex = 18;
            this.bt_Remove_Locatario.UseVisualStyleBackColor = true;
            this.bt_Remove_Locatario.Click += new System.EventHandler(this.bt_Remove_Locatario_Click);
            // 
            // bt_add_Locatario
            // 
            this.bt_add_Locatario.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add_Locatario.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_add_Locatario.Location = new System.Drawing.Point(386, 245);
            this.bt_add_Locatario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_add_Locatario.Name = "bt_add_Locatario";
            this.bt_add_Locatario.Size = new System.Drawing.Size(36, 27);
            this.bt_add_Locatario.TabIndex = 16;
            this.bt_add_Locatario.UseVisualStyleBackColor = true;
            this.bt_add_Locatario.Click += new System.EventHandler(this.bt_add_Locatario_Click);
            // 
            // cb_ID_Locatario
            // 
            this.cb_ID_Locatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Locatario.FormattingEnabled = true;
            this.cb_ID_Locatario.Location = new System.Drawing.Point(6, 246);
            this.cb_ID_Locatario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Locatario.Name = "cb_ID_Locatario";
            this.cb_ID_Locatario.Size = new System.Drawing.Size(375, 23);
            this.cb_ID_Locatario.TabIndex = 15;
            this.cb_ID_Locatario.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 95;
            this.label2.Text = "Locatário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 95;
            this.label4.Text = "Imóvel";
            // 
            // cb_ID_Imovel
            // 
            this.cb_ID_Imovel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Imovel.FormattingEnabled = true;
            this.cb_ID_Imovel.Location = new System.Drawing.Point(6, 84);
            this.cb_ID_Imovel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Imovel.Name = "cb_ID_Imovel";
            this.cb_ID_Imovel.Size = new System.Drawing.Size(879, 23);
            this.cb_ID_Imovel.TabIndex = 3;
            this.cb_ID_Imovel.Tag = "T";
            this.cb_ID_Imovel.Leave += new System.EventHandler(this.cb_ID_Imovel_Leave);
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Valor.Location = new System.Drawing.Point(6, 195);
            this.txt_Valor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Valor.MaxLength = 15;
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(93, 21);
            this.txt_Valor.TabIndex = 12;
            this.txt_Valor.Tag = "T";
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Valor";
            // 
            // mk_Inicio
            // 
            this.mk_Inicio.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Inicio.Location = new System.Drawing.Point(6, 138);
            this.mk_Inicio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Inicio.Mask = "00/00/0000";
            this.mk_Inicio.Name = "mk_Inicio";
            this.mk_Inicio.Size = new System.Drawing.Size(93, 21);
            this.mk_Inicio.TabIndex = 10;
            this.mk_Inicio.Tag = "T";
            this.mk_Inicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Inicio.ValidatingType = typeof(System.DateTime);
            this.mk_Inicio.Leave += new System.EventHandler(this.mk_Inicio_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 91;
            this.label6.Text = "Período";
            // 
            // mk_Termino
            // 
            this.mk_Termino.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Termino.Location = new System.Drawing.Point(124, 138);
            this.mk_Termino.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Termino.Mask = "00/00/0000";
            this.mk_Termino.Name = "mk_Termino";
            this.mk_Termino.Size = new System.Drawing.Size(93, 21);
            this.mk_Termino.TabIndex = 11;
            this.mk_Termino.Tag = "T";
            this.mk_Termino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Termino.ValidatingType = typeof(System.DateTime);
            this.mk_Termino.Leave += new System.EventHandler(this.mk_Termino_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 141);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 91;
            this.label7.Text = "à";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 62;
            this.label1.Text = "Código";
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
            this.txt_ID.TabStop = false;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label4);
            this.gb_Cadastro.Controls.Add(this.dg_Fiador);
            this.gb_Cadastro.Controls.Add(this.label18);
            this.gb_Cadastro.Controls.Add(this.label17);
            this.gb_Cadastro.Controls.Add(this.label16);
            this.gb_Cadastro.Controls.Add(this.label15);
            this.gb_Cadastro.Controls.Add(this.label14);
            this.gb_Cadastro.Controls.Add(this.label13);
            this.gb_Cadastro.Controls.Add(this.label5);
            this.gb_Cadastro.Controls.Add(this.cb_Remove_Fiador);
            this.gb_Cadastro.Controls.Add(this.txt_Observacao);
            this.gb_Cadastro.Controls.Add(this.txt_Doc_Test2);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao_Test2);
            this.gb_Cadastro.Controls.Add(this.txt_Doc_Test1);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao_Test1);
            this.gb_Cadastro.Controls.Add(this.txt_DiaVencimento);
            this.gb_Cadastro.Controls.Add(this.txt_Valor);
            this.gb_Cadastro.Controls.Add(this.bt_add_Fiador);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Fiador);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label7);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Imovel);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.mk_Data);
            this.gb_Cadastro.Controls.Add(this.label6);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.dg_Locatario);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Locatario);
            this.gb_Cadastro.Controls.Add(this.Label12);
            this.gb_Cadastro.Controls.Add(this.mk_Inicio);
            this.gb_Cadastro.Controls.Add(this.bt_Remove_Locatario);
            this.gb_Cadastro.Controls.Add(this.bt_add_Locatario);
            this.gb_Cadastro.Controls.Add(this.mk_Termino);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 104;
            this.gb_Cadastro.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 536);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 15);
            this.label18.TabIndex = 62;
            this.label18.Text = "Observações";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(330, 481);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 62;
            this.label17.Text = "CPF/RG";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(330, 432);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 15);
            this.label16.TabIndex = 62;
            this.label16.Text = "Testemunha 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 481);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 62;
            this.label15.Text = "CPF/RG";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 432);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 15);
            this.label14.TabIndex = 62;
            this.label14.Text = "Testemunha 1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 176);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 15);
            this.label13.TabIndex = 62;
            this.label13.Text = "Dia Vencimento";
            // 
            // txt_Observacao
            // 
            this.txt_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Observacao.Location = new System.Drawing.Point(6, 554);
            this.txt_Observacao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Observacao.MaxLength = 200;
            this.txt_Observacao.Multiline = true;
            this.txt_Observacao.Name = "txt_Observacao";
            this.txt_Observacao.Size = new System.Drawing.Size(928, 59);
            this.txt_Observacao.TabIndex = 35;
            this.txt_Observacao.Tag = "T";
            this.txt_Observacao.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // txt_Doc_Test2
            // 
            this.txt_Doc_Test2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Doc_Test2.Location = new System.Drawing.Point(334, 499);
            this.txt_Doc_Test2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Doc_Test2.MaxLength = 18;
            this.txt_Doc_Test2.Name = "txt_Doc_Test2";
            this.txt_Doc_Test2.Size = new System.Drawing.Size(279, 21);
            this.txt_Doc_Test2.TabIndex = 34;
            this.txt_Doc_Test2.Tag = "T";
            this.txt_Doc_Test2.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // txt_Descricao_Test2
            // 
            this.txt_Descricao_Test2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao_Test2.Location = new System.Drawing.Point(334, 451);
            this.txt_Descricao_Test2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao_Test2.MaxLength = 60;
            this.txt_Descricao_Test2.Name = "txt_Descricao_Test2";
            this.txt_Descricao_Test2.Size = new System.Drawing.Size(279, 21);
            this.txt_Descricao_Test2.TabIndex = 33;
            this.txt_Descricao_Test2.Tag = "T";
            this.txt_Descricao_Test2.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // txt_Doc_Test1
            // 
            this.txt_Doc_Test1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Doc_Test1.Location = new System.Drawing.Point(6, 499);
            this.txt_Doc_Test1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Doc_Test1.MaxLength = 18;
            this.txt_Doc_Test1.Name = "txt_Doc_Test1";
            this.txt_Doc_Test1.Size = new System.Drawing.Size(279, 21);
            this.txt_Doc_Test1.TabIndex = 31;
            this.txt_Doc_Test1.Tag = "T";
            this.txt_Doc_Test1.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // txt_Descricao_Test1
            // 
            this.txt_Descricao_Test1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao_Test1.Location = new System.Drawing.Point(6, 451);
            this.txt_Descricao_Test1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao_Test1.MaxLength = 60;
            this.txt_Descricao_Test1.Name = "txt_Descricao_Test1";
            this.txt_Descricao_Test1.Size = new System.Drawing.Size(279, 21);
            this.txt_Descricao_Test1.TabIndex = 30;
            this.txt_Descricao_Test1.Tag = "T";
            this.txt_Descricao_Test1.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // txt_DiaVencimento
            // 
            this.txt_DiaVencimento.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DiaVencimento.Location = new System.Drawing.Point(124, 195);
            this.txt_DiaVencimento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_DiaVencimento.MaxLength = 2;
            this.txt_DiaVencimento.Name = "txt_DiaVencimento";
            this.txt_DiaVencimento.Size = new System.Drawing.Size(93, 21);
            this.txt_DiaVencimento.TabIndex = 13;
            this.txt_DiaVencimento.Tag = "T";
            this.txt_DiaVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_DiaVencimento.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 110;
            this.label8.Text = "Imóvel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 107;
            this.label9.Text = "Código";
            // 
            // txt_ID_P
            // 
            this.txt_ID_P.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_P.Location = new System.Drawing.Point(8, 24);
            this.txt_ID_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID_P.MaxLength = 15;
            this.txt_ID_P.Name = "txt_ID_P";
            this.txt_ID_P.Size = new System.Drawing.Size(89, 21);
            this.txt_ID_P.TabIndex = 103;
            this.txt_ID_P.Tag = "T";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 15);
            this.label10.TabIndex = 108;
            this.label10.Text = "à";
            // 
            // cb_ID_Imovel_P
            // 
            this.cb_ID_Imovel_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Imovel_P.FormattingEnabled = true;
            this.cb_ID_Imovel_P.Location = new System.Drawing.Point(103, 24);
            this.cb_ID_Imovel_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Imovel_P.Name = "cb_ID_Imovel_P";
            this.cb_ID_Imovel_P.Size = new System.Drawing.Size(912, 23);
            this.cb_ID_Imovel_P.TabIndex = 104;
            this.cb_ID_Imovel_P.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 109;
            this.label11.Text = "Período";
            // 
            // mk_Inicio_P
            // 
            this.mk_Inicio_P.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Inicio_P.Location = new System.Drawing.Point(8, 77);
            this.mk_Inicio_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Inicio_P.Mask = "00/00/0000";
            this.mk_Inicio_P.Name = "mk_Inicio_P";
            this.mk_Inicio_P.Size = new System.Drawing.Size(93, 21);
            this.mk_Inicio_P.TabIndex = 105;
            this.mk_Inicio_P.Tag = "T";
            this.mk_Inicio_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Inicio_P.ValidatingType = typeof(System.DateTime);
            this.mk_Inicio_P.Leave += new System.EventHandler(this.mk_Inicio_P_Leave);
            // 
            // mk_Termino_P
            // 
            this.mk_Termino_P.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Termino_P.Location = new System.Drawing.Point(126, 77);
            this.mk_Termino_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Termino_P.Mask = "00/00/0000";
            this.mk_Termino_P.Name = "mk_Termino_P";
            this.mk_Termino_P.Size = new System.Drawing.Size(93, 21);
            this.mk_Termino_P.TabIndex = 106;
            this.mk_Termino_P.Tag = "T";
            this.mk_Termino_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Termino_P.ValidatingType = typeof(System.DateTime);
            this.mk_Termino_P.Leave += new System.EventHandler(this.mk_Termino_P_Leave);
            // 
            // UI_Locacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Locacao";
            this.Load += new System.EventHandler(this.UI_Locacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Locacao_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Locacao_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Fiador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Locatario)).EndInit();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.DataGridView dg_Fiador;
        internal System.Windows.Forms.Button cb_Remove_Fiador;
        internal System.Windows.Forms.Button bt_add_Fiador;
        internal System.Windows.Forms.ComboBox cb_ID_Fiador;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DataGridView dg_Locatario;
        internal System.Windows.Forms.Button bt_Remove_Locatario;
        internal System.Windows.Forms.Button bt_add_Locatario;
        internal System.Windows.Forms.ComboBox cb_ID_Locatario;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.MaskedTextBox mk_Termino;
        internal System.Windows.Forms.MaskedTextBox mk_Inicio;
        internal System.Windows.Forms.ComboBox cb_ID_Imovel;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txt_ID_P;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox cb_ID_Imovel_P;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.MaskedTextBox mk_Inicio_P;
        internal System.Windows.Forms.MaskedTextBox mk_Termino_P;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txt_Doc_Test2;
        internal System.Windows.Forms.TextBox txt_Descricao_Test2;
        internal System.Windows.Forms.TextBox txt_Doc_Test1;
        internal System.Windows.Forms.TextBox txt_Descricao_Test1;
        internal System.Windows.Forms.TextBox txt_DiaVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fiador;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Locatario;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txt_Observacao;
    }
}

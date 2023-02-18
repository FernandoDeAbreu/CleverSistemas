namespace Sistema.UI
{
    partial class UI_NFe_NotaRef
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
            this.gb_Chave = new System.Windows.Forms.GroupBox();
            this.txt_Chave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Notas = new System.Windows.Forms.GroupBox();
            this.lb_CNPJ_CPF = new System.Windows.Forms.Label();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.txt_CNPJ_CPF = new System.Windows.Forms.TextBox();
            this.mk_DataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.Label48 = new System.Windows.Forms.Label();
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID_NFe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Adicionar = new System.Windows.Forms.Button();
            this.gb_ECF = new System.Windows.Forms.GroupBox();
            this.cb_ModeloECF = new System.Windows.Forms.ComboBox();
            this.txt_NumeroECF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_NumeroContador = new System.Windows.Forms.TextBox();
            this.gb_Chave.SuspendLayout();
            this.gb_Notas.SuspendLayout();
            this.gb_ECF.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Chave
            // 
            this.gb_Chave.Controls.Add(this.txt_Chave);
            this.gb_Chave.Controls.Add(this.label2);
            this.gb_Chave.Location = new System.Drawing.Point(12, 12);
            this.gb_Chave.Name = "gb_Chave";
            this.gb_Chave.Size = new System.Drawing.Size(443, 70);
            this.gb_Chave.TabIndex = 20;
            this.gb_Chave.TabStop = false;
            this.gb_Chave.Text = "NF-e / CT-e";
            this.gb_Chave.Visible = false;
            // 
            // txt_Chave
            // 
            this.txt_Chave.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Chave.Location = new System.Drawing.Point(9, 38);
            this.txt_Chave.MaxLength = 44;
            this.txt_Chave.Name = "txt_Chave";
            this.txt_Chave.Size = new System.Drawing.Size(424, 20);
            this.txt_Chave.TabIndex = 21;
            this.txt_Chave.Tag = "T";
            this.txt_Chave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 116;
            this.label2.Text = "Chave";
            // 
            // gb_Notas
            // 
            this.gb_Notas.Controls.Add(this.lb_CNPJ_CPF);
            this.gb_Notas.Controls.Add(this.cb_UF);
            this.gb_Notas.Controls.Add(this.txt_CNPJ_CPF);
            this.gb_Notas.Controls.Add(this.mk_DataEmissao);
            this.gb_Notas.Controls.Add(this.Label48);
            this.gb_Notas.Controls.Add(this.txt_Serie);
            this.gb_Notas.Controls.Add(this.label1);
            this.gb_Notas.Controls.Add(this.txt_ID_NFe);
            this.gb_Notas.Controls.Add(this.label8);
            this.gb_Notas.Controls.Add(this.label7);
            this.gb_Notas.Location = new System.Drawing.Point(12, 12);
            this.gb_Notas.Name = "gb_Notas";
            this.gb_Notas.Size = new System.Drawing.Size(303, 115);
            this.gb_Notas.TabIndex = 10;
            this.gb_Notas.TabStop = false;
            this.gb_Notas.Text = "Nota Fiscal";
            this.gb_Notas.Visible = false;
            // 
            // lb_CNPJ_CPF
            // 
            this.lb_CNPJ_CPF.AutoSize = true;
            this.lb_CNPJ_CPF.Location = new System.Drawing.Point(7, 69);
            this.lb_CNPJ_CPF.Name = "lb_CNPJ_CPF";
            this.lb_CNPJ_CPF.Size = new System.Drawing.Size(56, 14);
            this.lb_CNPJ_CPF.TabIndex = 125;
            this.lb_CNPJ_CPF.Text = "CNPJ/CPF";
            // 
            // cb_UF
            // 
            this.cb_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT ",
            "MS",
            "MG",
            "PR",
            "PB",
            "PA",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cb_UF.Location = new System.Drawing.Point(234, 40);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(63, 22);
            this.cb_UF.TabIndex = 15;
            this.cb_UF.Tag = "T";
            // 
            // txt_CNPJ_CPF
            // 
            this.txt_CNPJ_CPF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CNPJ_CPF.Location = new System.Drawing.Point(10, 87);
            this.txt_CNPJ_CPF.MaxLength = 14;
            this.txt_CNPJ_CPF.Name = "txt_CNPJ_CPF";
            this.txt_CNPJ_CPF.Size = new System.Drawing.Size(182, 20);
            this.txt_CNPJ_CPF.TabIndex = 16;
            this.txt_CNPJ_CPF.Tag = "T";
            this.txt_CNPJ_CPF.Leave += new System.EventHandler(this.txt_CNPJ_CPF_Leave);
            // 
            // mk_DataEmissao
            // 
            this.mk_DataEmissao.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataEmissao.Location = new System.Drawing.Point(151, 40);
            this.mk_DataEmissao.Mask = "00/00";
            this.mk_DataEmissao.Name = "mk_DataEmissao";
            this.mk_DataEmissao.Size = new System.Drawing.Size(77, 20);
            this.mk_DataEmissao.TabIndex = 14;
            this.mk_DataEmissao.Tag = "T";
            this.mk_DataEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataEmissao.ValidatingType = typeof(System.DateTime);
            // 
            // Label48
            // 
            this.Label48.AutoSize = true;
            this.Label48.Location = new System.Drawing.Point(148, 20);
            this.Label48.Name = "Label48";
            this.Label48.Size = new System.Drawing.Size(83, 14);
            this.Label48.TabIndex = 121;
            this.Label48.Text = "Data de Emissão";
            // 
            // txt_Serie
            // 
            this.txt_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Serie.Location = new System.Drawing.Point(10, 40);
            this.txt_Serie.MaxLength = 3;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(42, 20);
            this.txt_Serie.TabIndex = 11;
            this.txt_Serie.Tag = "T";
            this.txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 116;
            this.label1.Text = "UF";
            // 
            // txt_ID_NFe
            // 
            this.txt_ID_NFe.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_NFe.Location = new System.Drawing.Point(58, 40);
            this.txt_ID_NFe.MaxLength = 9;
            this.txt_ID_NFe.Name = "txt_ID_NFe";
            this.txt_ID_NFe.Size = new System.Drawing.Size(87, 20);
            this.txt_ID_NFe.TabIndex = 12;
            this.txt_ID_NFe.Tag = "T";
            this.txt_ID_NFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 14);
            this.label8.TabIndex = 116;
            this.label8.Text = "Série";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 117;
            this.label7.Text = "Número NF-e";
            // 
            // bt_Adicionar
            // 
            this.bt_Adicionar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adicionar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adicionar.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adicionar.Location = new System.Drawing.Point(331, 95);
            this.bt_Adicionar.Name = "bt_Adicionar";
            this.bt_Adicionar.Size = new System.Drawing.Size(124, 28);
            this.bt_Adicionar.TabIndex = 40;
            this.bt_Adicionar.Text = "CONCLUÍDO";
            this.bt_Adicionar.UseVisualStyleBackColor = false;
            this.bt_Adicionar.Click += new System.EventHandler(this.bt_Adicionar_Click);
            // 
            // gb_ECF
            // 
            this.gb_ECF.Controls.Add(this.cb_ModeloECF);
            this.gb_ECF.Controls.Add(this.txt_NumeroECF);
            this.gb_ECF.Controls.Add(this.label3);
            this.gb_ECF.Controls.Add(this.label4);
            this.gb_ECF.Controls.Add(this.label5);
            this.gb_ECF.Controls.Add(this.txt_NumeroContador);
            this.gb_ECF.Location = new System.Drawing.Point(12, 12);
            this.gb_ECF.Name = "gb_ECF";
            this.gb_ECF.Size = new System.Drawing.Size(443, 73);
            this.gb_ECF.TabIndex = 41;
            this.gb_ECF.TabStop = false;
            this.gb_ECF.Text = "Cupom Fiscal";
            this.gb_ECF.Visible = false;
            // 
            // cb_ModeloECF
            // 
            this.cb_ModeloECF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ModeloECF.FormattingEnabled = true;
            this.cb_ModeloECF.Items.AddRange(new object[] {
            "2B",
            "2C",
            "2D"});
            this.cb_ModeloECF.Location = new System.Drawing.Point(233, 39);
            this.cb_ModeloECF.Name = "cb_ModeloECF";
            this.cb_ModeloECF.Size = new System.Drawing.Size(63, 22);
            this.cb_ModeloECF.TabIndex = 120;
            this.cb_ModeloECF.Tag = "T";
            // 
            // txt_NumeroECF
            // 
            this.txt_NumeroECF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_NumeroECF.Location = new System.Drawing.Point(9, 39);
            this.txt_NumeroECF.MaxLength = 3;
            this.txt_NumeroECF.Name = "txt_NumeroECF";
            this.txt_NumeroECF.Size = new System.Drawing.Size(108, 20);
            this.txt_NumeroECF.TabIndex = 118;
            this.txt_NumeroECF.Tag = "T";
            this.txt_NumeroECF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 123;
            this.label3.Text = "Nº COO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 121;
            this.label4.Text = "Nº ECF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 122;
            this.label5.Text = "Modelo";
            // 
            // txt_NumeroContador
            // 
            this.txt_NumeroContador.BackColor = System.Drawing.SystemColors.Window;
            this.txt_NumeroContador.Location = new System.Drawing.Point(123, 39);
            this.txt_NumeroContador.MaxLength = 6;
            this.txt_NumeroContador.Name = "txt_NumeroContador";
            this.txt_NumeroContador.Size = new System.Drawing.Size(104, 20);
            this.txt_NumeroContador.TabIndex = 119;
            this.txt_NumeroContador.Tag = "T";
            this.txt_NumeroContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_NFe_NotaRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(467, 138);
            this.Controls.Add(this.bt_Adicionar);
            this.Controls.Add(this.gb_Notas);
            this.Controls.Add(this.gb_Chave);
            this.Controls.Add(this.gb_ECF);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_NFe_NotaRef";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_NFe_NotaRef";
            this.Load += new System.EventHandler(this.UI_NFe_NotaRef_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_NFe_NotaRef_KeyPress);
            this.gb_Chave.ResumeLayout(false);
            this.gb_Chave.PerformLayout();
            this.gb_Notas.ResumeLayout(false);
            this.gb_Notas.PerformLayout();
            this.gb_ECF.ResumeLayout(false);
            this.gb_ECF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bt_Adicionar;
        private System.Windows.Forms.GroupBox gb_Chave;
        internal System.Windows.Forms.TextBox txt_Chave;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Notas;
        internal System.Windows.Forms.Label lb_CNPJ_CPF;
        internal System.Windows.Forms.ComboBox cb_UF;
        internal System.Windows.Forms.TextBox txt_CNPJ_CPF;
        internal System.Windows.Forms.MaskedTextBox mk_DataEmissao;
        internal System.Windows.Forms.Label Label48;
        internal System.Windows.Forms.TextBox txt_Serie;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID_NFe;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gb_ECF;
        internal System.Windows.Forms.ComboBox cb_ModeloECF;
        internal System.Windows.Forms.TextBox txt_NumeroECF;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_NumeroContador;
    }
}
namespace Sistema.UI
{
    partial class UI_NFe_Importacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_NFe_Importacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lb_CNPJ_CPF = new System.Windows.Forms.Label();
            this.txt_Doc = new System.Windows.Forms.TextBox();
            this.bt_Adicionar = new System.Windows.Forms.Button();
            this.txt_Exportador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mk_Data_Registro = new System.Windows.Forms.MaskedTextBox();
            this.Label48 = new System.Windows.Forms.Label();
            this.gb_Desembaraco = new System.Windows.Forms.GroupBox();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Local = new System.Windows.Forms.TextBox();
            this.mk_Data_Desen = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Adi = new System.Windows.Forms.GroupBox();
            this.bt_Exclui_Adi = new System.Windows.Forms.Button();
            this.bt_Edita_Adi = new System.Windows.Forms.Button();
            this.txt_Fabri_Adi = new System.Windows.Forms.TextBox();
            this.txt_Desc_Adi = new System.Windows.Forms.TextBox();
            this.txt_ID_Adi = new System.Windows.Forms.TextBox();
            this.txt_Num_Adi = new System.Windows.Forms.TextBox();
            this.bt_Add_Adi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dg_Adi = new System.Windows.Forms.DataGridView();
            this.col_ID_Adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Num_Adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Fabri_Adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desc_Adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_Desembaraco.SuspendLayout();
            this.gb_Adi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Adi)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_CNPJ_CPF
            // 
            this.lb_CNPJ_CPF.AutoSize = true;
            this.lb_CNPJ_CPF.Location = new System.Drawing.Point(9, 12);
            this.lb_CNPJ_CPF.Name = "lb_CNPJ_CPF";
            this.lb_CNPJ_CPF.Size = new System.Drawing.Size(101, 13);
            this.lb_CNPJ_CPF.TabIndex = 125;
            this.lb_CNPJ_CPF.Text = "Número DI/DSI/DA";
            // 
            // txt_Doc
            // 
            this.txt_Doc.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Doc.Location = new System.Drawing.Point(12, 29);
            this.txt_Doc.MaxLength = 10;
            this.txt_Doc.Name = "txt_Doc";
            this.txt_Doc.Size = new System.Drawing.Size(182, 20);
            this.txt_Doc.TabIndex = 2;
            this.txt_Doc.Tag = "T";
            // 
            // bt_Adicionar
            // 
            this.bt_Adicionar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adicionar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adicionar.Image = ((System.Drawing.Image)(resources.GetObject("bt_Adicionar.Image")));
            this.bt_Adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adicionar.Location = new System.Drawing.Point(432, 437);
            this.bt_Adicionar.Name = "bt_Adicionar";
            this.bt_Adicionar.Size = new System.Drawing.Size(129, 35);
            this.bt_Adicionar.TabIndex = 30;
            this.bt_Adicionar.Text = "ADICIONAR";
            this.bt_Adicionar.UseVisualStyleBackColor = false;
            this.bt_Adicionar.Click += new System.EventHandler(this.bt_Adicionar_Click);
            // 
            // txt_Exportador
            // 
            this.txt_Exportador.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Exportador.Location = new System.Drawing.Point(12, 74);
            this.txt_Exportador.MaxLength = 60;
            this.txt_Exportador.Name = "txt_Exportador";
            this.txt_Exportador.Size = new System.Drawing.Size(549, 20);
            this.txt_Exportador.TabIndex = 5;
            this.txt_Exportador.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "Código Exportador";
            // 
            // mk_Data_Registro
            // 
            this.mk_Data_Registro.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data_Registro.Location = new System.Drawing.Point(213, 29);
            this.mk_Data_Registro.Mask = "00/00/0000";
            this.mk_Data_Registro.Name = "mk_Data_Registro";
            this.mk_Data_Registro.Size = new System.Drawing.Size(84, 20);
            this.mk_Data_Registro.TabIndex = 3;
            this.mk_Data_Registro.Tag = "T";
            this.mk_Data_Registro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data_Registro.ValidatingType = typeof(System.DateTime);
            this.mk_Data_Registro.Leave += new System.EventHandler(this.mk_Data_Registro_Leave);
            // 
            // Label48
            // 
            this.Label48.AutoSize = true;
            this.Label48.Location = new System.Drawing.Point(210, 12);
            this.Label48.Name = "Label48";
            this.Label48.Size = new System.Drawing.Size(87, 13);
            this.Label48.TabIndex = 127;
            this.Label48.Text = "Data de Registro";
            // 
            // gb_Desembaraco
            // 
            this.gb_Desembaraco.Controls.Add(this.cb_UF);
            this.gb_Desembaraco.Controls.Add(this.label4);
            this.gb_Desembaraco.Controls.Add(this.txt_Local);
            this.gb_Desembaraco.Controls.Add(this.mk_Data_Desen);
            this.gb_Desembaraco.Controls.Add(this.label3);
            this.gb_Desembaraco.Controls.Add(this.label2);
            this.gb_Desembaraco.Location = new System.Drawing.Point(12, 100);
            this.gb_Desembaraco.Name = "gb_Desembaraco";
            this.gb_Desembaraco.Size = new System.Drawing.Size(549, 107);
            this.gb_Desembaraco.TabIndex = 6;
            this.gb_Desembaraco.TabStop = false;
            this.gb_Desembaraco.Text = "Desembaraço Aduaneiro";
            // 
            // cb_UF
            // 
            this.cb_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Location = new System.Drawing.Point(96, 76);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(63, 21);
            this.cb_UF.TabIndex = 9;
            this.cb_UF.Tag = "T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "UF";
            // 
            // txt_Local
            // 
            this.txt_Local.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Local.Location = new System.Drawing.Point(6, 36);
            this.txt_Local.MaxLength = 60;
            this.txt_Local.Name = "txt_Local";
            this.txt_Local.Size = new System.Drawing.Size(537, 20);
            this.txt_Local.TabIndex = 7;
            this.txt_Local.Tag = "T";
            // 
            // mk_Data_Desen
            // 
            this.mk_Data_Desen.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data_Desen.Location = new System.Drawing.Point(6, 77);
            this.mk_Data_Desen.Mask = "00/00/0000";
            this.mk_Data_Desen.Name = "mk_Data_Desen";
            this.mk_Data_Desen.Size = new System.Drawing.Size(84, 20);
            this.mk_Data_Desen.TabIndex = 8;
            this.mk_Data_Desen.Tag = "T";
            this.mk_Data_Desen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data_Desen.ValidatingType = typeof(System.DateTime);
            this.mk_Data_Desen.Leave += new System.EventHandler(this.mk_Data_Desen_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 127;
            this.label3.Text = "Data Desem.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Local";
            // 
            // gb_Adi
            // 
            this.gb_Adi.Controls.Add(this.bt_Exclui_Adi);
            this.gb_Adi.Controls.Add(this.bt_Edita_Adi);
            this.gb_Adi.Controls.Add(this.txt_Fabri_Adi);
            this.gb_Adi.Controls.Add(this.txt_Desc_Adi);
            this.gb_Adi.Controls.Add(this.txt_ID_Adi);
            this.gb_Adi.Controls.Add(this.txt_Num_Adi);
            this.gb_Adi.Controls.Add(this.bt_Add_Adi);
            this.gb_Adi.Controls.Add(this.label6);
            this.gb_Adi.Controls.Add(this.label7);
            this.gb_Adi.Controls.Add(this.dg_Adi);
            this.gb_Adi.Controls.Add(this.label5);
            this.gb_Adi.Location = new System.Drawing.Point(12, 213);
            this.gb_Adi.Name = "gb_Adi";
            this.gb_Adi.Size = new System.Drawing.Size(549, 218);
            this.gb_Adi.TabIndex = 10;
            this.gb_Adi.TabStop = false;
            this.gb_Adi.Text = "Adições";
            // 
            // bt_Exclui_Adi
            // 
            this.bt_Exclui_Adi.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Exclui_Adi.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exclui_Adi.Image = ((System.Drawing.Image)(resources.GetObject("bt_Exclui_Adi.Image")));
            this.bt_Exclui_Adi.Location = new System.Drawing.Point(512, 88);
            this.bt_Exclui_Adi.Name = "bt_Exclui_Adi";
            this.bt_Exclui_Adi.Size = new System.Drawing.Size(27, 26);
            this.bt_Exclui_Adi.TabIndex = 22;
            this.bt_Exclui_Adi.UseVisualStyleBackColor = false;
            this.bt_Exclui_Adi.Click += new System.EventHandler(this.bt_Exclui_Adi_Click);
            // 
            // bt_Edita_Adi
            // 
            this.bt_Edita_Adi.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Edita_Adi.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Edita_Adi.Image = ((System.Drawing.Image)(resources.GetObject("bt_Edita_Adi.Image")));
            this.bt_Edita_Adi.Location = new System.Drawing.Point(512, 59);
            this.bt_Edita_Adi.Name = "bt_Edita_Adi";
            this.bt_Edita_Adi.Size = new System.Drawing.Size(27, 26);
            this.bt_Edita_Adi.TabIndex = 21;
            this.bt_Edita_Adi.UseVisualStyleBackColor = false;
            this.bt_Edita_Adi.Click += new System.EventHandler(this.bt_Edita_Adi_Click);
            // 
            // txt_Fabri_Adi
            // 
            this.txt_Fabri_Adi.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Fabri_Adi.Location = new System.Drawing.Point(89, 34);
            this.txt_Fabri_Adi.MaxLength = 60;
            this.txt_Fabri_Adi.Name = "txt_Fabri_Adi";
            this.txt_Fabri_Adi.Size = new System.Drawing.Size(359, 20);
            this.txt_Fabri_Adi.TabIndex = 12;
            this.txt_Fabri_Adi.Tag = "T";
            // 
            // txt_Desc_Adi
            // 
            this.txt_Desc_Adi.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Desc_Adi.Location = new System.Drawing.Point(454, 34);
            this.txt_Desc_Adi.MaxLength = 15;
            this.txt_Desc_Adi.Name = "txt_Desc_Adi";
            this.txt_Desc_Adi.Size = new System.Drawing.Size(50, 20);
            this.txt_Desc_Adi.TabIndex = 13;
            this.txt_Desc_Adi.Tag = "T";
            this.txt_Desc_Adi.Text = "0,00";
            this.txt_Desc_Adi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Desc_Adi.Leave += new System.EventHandler(this.txt_Desc_Adi_Leave);
            // 
            // txt_ID_Adi
            // 
            this.txt_ID_Adi.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Adi.Enabled = false;
            this.txt_ID_Adi.Location = new System.Drawing.Point(201, 34);
            this.txt_ID_Adi.MaxLength = 3;
            this.txt_ID_Adi.Name = "txt_ID_Adi";
            this.txt_ID_Adi.Size = new System.Drawing.Size(35, 20);
            this.txt_ID_Adi.TabIndex = 11;
            this.txt_ID_Adi.Tag = "T";
            // 
            // txt_Num_Adi
            // 
            this.txt_Num_Adi.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Num_Adi.Location = new System.Drawing.Point(6, 34);
            this.txt_Num_Adi.MaxLength = 3;
            this.txt_Num_Adi.Name = "txt_Num_Adi";
            this.txt_Num_Adi.Size = new System.Drawing.Size(77, 20);
            this.txt_Num_Adi.TabIndex = 11;
            this.txt_Num_Adi.Tag = "T";
            // 
            // bt_Add_Adi
            // 
            this.bt_Add_Adi.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Add_Adi.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Add_Adi.Image = ((System.Drawing.Image)(resources.GetObject("bt_Add_Adi.Image")));
            this.bt_Add_Adi.Location = new System.Drawing.Point(512, 30);
            this.bt_Add_Adi.Name = "bt_Add_Adi";
            this.bt_Add_Adi.Size = new System.Drawing.Size(27, 26);
            this.bt_Add_Adi.TabIndex = 15;
            this.bt_Add_Adi.UseVisualStyleBackColor = false;
            this.bt_Add_Adi.Click += new System.EventHandler(this.bt_Adiciona_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Cód. Fabricante";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(451, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "Desconto";
            // 
            // dg_Adi
            // 
            this.dg_Adi.AllowUserToAddRows = false;
            this.dg_Adi.AllowUserToDeleteRows = false;
            this.dg_Adi.AllowUserToResizeColumns = false;
            this.dg_Adi.AllowUserToResizeRows = false;
            this.dg_Adi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Adi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Adi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Adi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Adi,
            this.col_Num_Adi,
            this.col_Fabri_Adi,
            this.col_Desc_Adi});
            this.dg_Adi.Location = new System.Drawing.Point(6, 60);
            this.dg_Adi.MultiSelect = false;
            this.dg_Adi.Name = "dg_Adi";
            this.dg_Adi.RowHeadersVisible = false;
            this.dg_Adi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Adi.Size = new System.Drawing.Size(498, 152);
            this.dg_Adi.StandardTab = true;
            this.dg_Adi.TabIndex = 20;
            // 
            // col_ID_Adi
            // 
            this.col_ID_Adi.HeaderText = "ID";
            this.col_ID_Adi.Name = "col_ID_Adi";
            this.col_ID_Adi.Visible = false;
            // 
            // col_Num_Adi
            // 
            this.col_Num_Adi.HeaderText = "NÚMERO";
            this.col_Num_Adi.Name = "col_Num_Adi";
            // 
            // col_Fabri_Adi
            // 
            this.col_Fabri_Adi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Fabri_Adi.HeaderText = "CÓD. FABRICANTE";
            this.col_Fabri_Adi.Name = "col_Fabri_Adi";
            // 
            // col_Desc_Adi
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Desc_Adi.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Desc_Adi.HeaderText = "DESCONTO";
            this.col_Desc_Adi.Name = "col_Desc_Adi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Número";
            // 
            // UI_NFe_Importacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(568, 484);
            this.Controls.Add(this.gb_Adi);
            this.Controls.Add(this.gb_Desembaraco);
            this.Controls.Add(this.mk_Data_Registro);
            this.Controls.Add(this.Label48);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_CNPJ_CPF);
            this.Controls.Add(this.txt_Exportador);
            this.Controls.Add(this.txt_Doc);
            this.Controls.Add(this.bt_Adicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_NFe_Importacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DECLARAÇÃO DE IMPORTAÇÃO";
            this.Load += new System.EventHandler(this.frm_NF_DeclaracaoImportacao_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_NF_DeclaracaoImportacao_KeyPress);
            this.gb_Desembaraco.ResumeLayout(false);
            this.gb_Desembaraco.PerformLayout();
            this.gb_Adi.ResumeLayout(false);
            this.gb_Adi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Adi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button bt_Adicionar;
        internal System.Windows.Forms.Label lb_CNPJ_CPF;
        internal System.Windows.Forms.TextBox txt_Doc;
        internal System.Windows.Forms.TextBox txt_Exportador;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.MaskedTextBox mk_Data_Registro;
        internal System.Windows.Forms.Label Label48;
        private System.Windows.Forms.GroupBox gb_Desembaraco;
        internal System.Windows.Forms.TextBox txt_Local;
        internal System.Windows.Forms.MaskedTextBox mk_Data_Desen;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cb_UF;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_Adi;
        internal System.Windows.Forms.DataGridView dg_Adi;
        internal System.Windows.Forms.Button bt_Exclui_Adi;
        internal System.Windows.Forms.Button bt_Edita_Adi;
        internal System.Windows.Forms.TextBox txt_Fabri_Adi;
        internal System.Windows.Forms.TextBox txt_Desc_Adi;
        internal System.Windows.Forms.TextBox txt_Num_Adi;
        internal System.Windows.Forms.Button bt_Add_Adi;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_ID_Adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Num_Adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fabri_Adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desc_Adi;
    }
}
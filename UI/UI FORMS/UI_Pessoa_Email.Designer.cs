namespace Sistema.UI
{
    partial class UI_Pessoa_Email
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Pesquisa = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.txt_ID_Municipio = new System.Windows.Forms.TextBox();
            this.txt_ID_UF = new System.Windows.Forms.TextBox();
            this.txt_ID_Pais = new System.Windows.Forms.TextBox();
            this.ck_Principal = new System.Windows.Forms.CheckBox();
            this.cb_ID_Grupo = new System.Windows.Forms.ComboBox();
            this.cb_Pais = new System.Windows.Forms.ComboBox();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.lb_Pais = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.lb_UF = new System.Windows.Forms.Label();
            this.cb_Municipio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Vendedor = new System.Windows.Forms.Label();
            this.cb_ID_Usuario = new System.Windows.Forms.ComboBox();
            this.bt_Pesquisa = new System.Windows.Forms.Button();
            this.bt_Seleciona = new System.Windows.Forms.Button();
            this.dg_Email = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NomeFantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_Descricaotela = new System.Windows.Forms.Label();
            this.gb_Pesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Email)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Pesquisa
            // 
            this.gb_Pesquisa.BackColor = System.Drawing.Color.Transparent;
            this.gb_Pesquisa.Controls.Add(this.label17);
            this.gb_Pesquisa.Controls.Add(this.cb_TipoPessoa);
            this.gb_Pesquisa.Controls.Add(this.txt_ID_Municipio);
            this.gb_Pesquisa.Controls.Add(this.txt_ID_UF);
            this.gb_Pesquisa.Controls.Add(this.txt_ID_Pais);
            this.gb_Pesquisa.Controls.Add(this.ck_Principal);
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Grupo);
            this.gb_Pesquisa.Controls.Add(this.cb_Pais);
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Pesquisa.Controls.Add(this.lb_Pais);
            this.gb_Pesquisa.Controls.Add(this.Label28);
            this.gb_Pesquisa.Controls.Add(this.lb_UF);
            this.gb_Pesquisa.Controls.Add(this.cb_Municipio);
            this.gb_Pesquisa.Controls.Add(this.label4);
            this.gb_Pesquisa.Controls.Add(this.cb_UF);
            this.gb_Pesquisa.Controls.Add(this.Label3);
            this.gb_Pesquisa.Controls.Add(this.label1);
            this.gb_Pesquisa.Controls.Add(this.lb_Vendedor);
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Usuario);
            this.gb_Pesquisa.Controls.Add(this.bt_Pesquisa);
            this.gb_Pesquisa.Controls.Add(this.bt_Seleciona);
            this.gb_Pesquisa.Controls.Add(this.dg_Email);
            this.gb_Pesquisa.Location = new System.Drawing.Point(5, 28);
            this.gb_Pesquisa.Name = "gb_Pesquisa";
            this.gb_Pesquisa.Size = new System.Drawing.Size(997, 442);
            this.gb_Pesquisa.TabIndex = 16;
            this.gb_Pesquisa.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(237, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 14);
            this.label17.TabIndex = 178;
            this.label17.Text = "F7 (Pesquisa avançada)";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(9, 31);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(163, 22);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // txt_ID_Municipio
            // 
            this.txt_ID_Municipio.Enabled = false;
            this.txt_ID_Municipio.Location = new System.Drawing.Point(21, 32);
            this.txt_ID_Municipio.Name = "txt_ID_Municipio";
            this.txt_ID_Municipio.Size = new System.Drawing.Size(13, 20);
            this.txt_ID_Municipio.TabIndex = 177;
            this.txt_ID_Municipio.Tag = "T";
            // 
            // txt_ID_UF
            // 
            this.txt_ID_UF.Enabled = false;
            this.txt_ID_UF.Location = new System.Drawing.Point(39, 32);
            this.txt_ID_UF.Name = "txt_ID_UF";
            this.txt_ID_UF.Size = new System.Drawing.Size(13, 20);
            this.txt_ID_UF.TabIndex = 176;
            this.txt_ID_UF.Tag = "T";
            // 
            // txt_ID_Pais
            // 
            this.txt_ID_Pais.Enabled = false;
            this.txt_ID_Pais.Location = new System.Drawing.Point(60, 32);
            this.txt_ID_Pais.Name = "txt_ID_Pais";
            this.txt_ID_Pais.Size = new System.Drawing.Size(13, 20);
            this.txt_ID_Pais.TabIndex = 175;
            this.txt_ID_Pais.Tag = "T";
            // 
            // ck_Principal
            // 
            this.ck_Principal.AutoSize = true;
            this.ck_Principal.Checked = true;
            this.ck_Principal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Principal.Location = new System.Drawing.Point(675, 34);
            this.ck_Principal.Name = "ck_Principal";
            this.ck_Principal.Size = new System.Drawing.Size(111, 18);
            this.ck_Principal.TabIndex = 3;
            this.ck_Principal.Text = "Somente Principal";
            this.ck_Principal.UseVisualStyleBackColor = true;
            // 
            // cb_ID_Grupo
            // 
            this.cb_ID_Grupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Grupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Grupo.FormattingEnabled = true;
            this.cb_ID_Grupo.Location = new System.Drawing.Point(224, 79);
            this.cb_ID_Grupo.Name = "cb_ID_Grupo";
            this.cb_ID_Grupo.Size = new System.Drawing.Size(193, 22);
            this.cb_ID_Grupo.TabIndex = 5;
            this.cb_ID_Grupo.Tag = "T";
            // 
            // cb_Pais
            // 
            this.cb_Pais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Pais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Pais.FormattingEnabled = true;
            this.cb_Pais.Location = new System.Drawing.Point(423, 79);
            this.cb_Pais.Name = "cb_Pais";
            this.cb_Pais.Size = new System.Drawing.Size(163, 22);
            this.cb_Pais.TabIndex = 6;
            this.cb_Pais.Tag = "";
            this.cb_Pais.SelectedValueChanged += new System.EventHandler(this.cb_Pais_SelectedValueChanged);
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(177, 32);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(475, 22);
            this.cb_ID_Pessoa.TabIndex = 2;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // lb_Pais
            // 
            this.lb_Pais.AutoSize = true;
            this.lb_Pais.Location = new System.Drawing.Point(421, 62);
            this.lb_Pais.Name = "lb_Pais";
            this.lb_Pais.Size = new System.Drawing.Size(26, 14);
            this.lb_Pais.TabIndex = 126;
            this.lb_Pais.Text = "País";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(777, 62);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(54, 14);
            this.Label28.TabIndex = 125;
            this.Label28.Text = "Município";
            // 
            // lb_UF
            // 
            this.lb_UF.AutoSize = true;
            this.lb_UF.Location = new System.Drawing.Point(589, 62);
            this.lb_UF.Name = "lb_UF";
            this.lb_UF.Size = new System.Drawing.Size(21, 14);
            this.lb_UF.TabIndex = 124;
            this.lb_UF.Text = "UF";
            // 
            // cb_Municipio
            // 
            this.cb_Municipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Municipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Municipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Municipio.FormattingEnabled = true;
            this.cb_Municipio.Location = new System.Drawing.Point(781, 79);
            this.cb_Municipio.Name = "cb_Municipio";
            this.cb_Municipio.Size = new System.Drawing.Size(210, 22);
            this.cb_Municipio.TabIndex = 8;
            this.cb_Municipio.Tag = "";
            this.cb_Municipio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_Municipio_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 123;
            this.label4.Text = "Descrição";
            // 
            // cb_UF
            // 
            this.cb_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Location = new System.Drawing.Point(591, 79);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(183, 22);
            this.cb_UF.TabIndex = 7;
            this.cb_UF.Tag = "";
            this.cb_UF.SelectedValueChanged += new System.EventHandler(this.cb_UF_SelectedValueChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 14);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 14);
            this.Label3.TabIndex = 122;
            this.Label3.Text = "Tipo Pessoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 118;
            this.label1.Text = "Grupo";
            // 
            // lb_Vendedor
            // 
            this.lb_Vendedor.AutoSize = true;
            this.lb_Vendedor.Location = new System.Drawing.Point(7, 62);
            this.lb_Vendedor.Name = "lb_Vendedor";
            this.lb_Vendedor.Size = new System.Drawing.Size(49, 14);
            this.lb_Vendedor.TabIndex = 118;
            this.lb_Vendedor.Text = "Vendedor";
            // 
            // cb_ID_Usuario
            // 
            this.cb_ID_Usuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Usuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Usuario.FormattingEnabled = true;
            this.cb_ID_Usuario.Location = new System.Drawing.Point(9, 79);
            this.cb_ID_Usuario.Name = "cb_ID_Usuario";
            this.cb_ID_Usuario.Size = new System.Drawing.Size(208, 22);
            this.cb_ID_Usuario.TabIndex = 4;
            this.cb_ID_Usuario.Tag = "T";
            this.cb_ID_Usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_Usuario_KeyDown);
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Pesquisa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Pesquisa.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_Pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Pesquisa.Location = new System.Drawing.Point(739, 390);
            this.bt_Pesquisa.Name = "bt_Pesquisa";
            this.bt_Pesquisa.Size = new System.Drawing.Size(123, 46);
            this.bt_Pesquisa.TabIndex = 10;
            this.bt_Pesquisa.Text = "PESQUISA";
            this.bt_Pesquisa.UseVisualStyleBackColor = false;
            this.bt_Pesquisa.Click += new System.EventHandler(this.bt_Pesquisa_Click);
            // 
            // bt_Seleciona
            // 
            this.bt_Seleciona.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Seleciona.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Seleciona.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Seleciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Seleciona.Location = new System.Drawing.Point(868, 390);
            this.bt_Seleciona.Name = "bt_Seleciona";
            this.bt_Seleciona.Size = new System.Drawing.Size(123, 46);
            this.bt_Seleciona.TabIndex = 12;
            this.bt_Seleciona.Text = "SELECIONAR";
            this.bt_Seleciona.UseVisualStyleBackColor = false;
            this.bt_Seleciona.Click += new System.EventHandler(this.bt_Seleciona_Click);
            // 
            // dg_Email
            // 
            this.dg_Email.AllowUserToAddRows = false;
            this.dg_Email.AllowUserToDeleteRows = false;
            this.dg_Email.AllowUserToResizeColumns = false;
            this.dg_Email.AllowUserToResizeRows = false;
            this.dg_Email.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Email.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Email.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Email.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_Pessoa,
            this.col_NomeFantasia,
            this.col_Email});
            this.dg_Email.Location = new System.Drawing.Point(9, 109);
            this.dg_Email.MultiSelect = false;
            this.dg_Email.Name = "dg_Email";
            this.dg_Email.RowHeadersVisible = false;
            this.dg_Email.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Email.Size = new System.Drawing.Size(982, 275);
            this.dg_Email.StandardTab = true;
            this.dg_Email.TabIndex = 11;
            this.dg_Email.Tag = "T";
            this.dg_Email.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Email_CellPainting);
            this.dg_Email.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Email_ColumnHeaderMouseClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_Pessoa
            // 
            this.col_Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Pessoa.HeaderText = "Pessoa";
            this.col_Pessoa.Name = "col_Pessoa";
            this.col_Pessoa.ReadOnly = true;
            // 
            // col_NomeFantasia
            // 
            this.col_NomeFantasia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_NomeFantasia.HeaderText = "Nome Fantasia";
            this.col_NomeFantasia.Name = "col_NomeFantasia";
            this.col_NomeFantasia.ReadOnly = true;
            // 
            // col_Email
            // 
            this.col_Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Email.HeaderText = "Email";
            this.col_Email.Name = "col_Email";
            this.col_Email.ReadOnly = true;
            // 
            // lb_Descricaotela
            // 
            this.lb_Descricaotela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Descricaotela.BackColor = System.Drawing.Color.Transparent;
            this.lb_Descricaotela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Descricaotela.ForeColor = System.Drawing.Color.Gray;
            this.lb_Descricaotela.Location = new System.Drawing.Point(558, 9);
            this.lb_Descricaotela.Name = "lb_Descricaotela";
            this.lb_Descricaotela.Size = new System.Drawing.Size(444, 19);
            this.lb_Descricaotela.TabIndex = 17;
            this.lb_Descricaotela.Text = "frm_Modelo";
            this.lb_Descricaotela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UI_Pessoa_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 477);
            this.Controls.Add(this.lb_Descricaotela);
            this.Controls.Add(this.gb_Pesquisa);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "UI_Pessoa_Email";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Email";
            this.Load += new System.EventHandler(this.UI_Pessoa_Email_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Pessoa_Email_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Pessoa_Email_KeyPress);
            this.gb_Pesquisa.ResumeLayout(false);
            this.gb_Pesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Email)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Pesquisa;
        internal System.Windows.Forms.DataGridView dg_Email;
        internal System.Windows.Forms.Button bt_Seleciona;
        internal System.Windows.Forms.Button bt_Pesquisa;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Label lb_UF;
        internal System.Windows.Forms.ComboBox cb_Municipio;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_UF;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lb_Vendedor;
        internal System.Windows.Forms.ComboBox cb_ID_Usuario;
        private System.Windows.Forms.CheckBox ck_Principal;
        internal System.Windows.Forms.ComboBox cb_ID_Grupo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID_Municipio;
        internal System.Windows.Forms.TextBox txt_ID_UF;
        internal System.Windows.Forms.TextBox txt_ID_Pais;
        private System.Windows.Forms.Label lb_Descricaotela;
        internal System.Windows.Forms.ComboBox cb_Pais;
        internal System.Windows.Forms.Label lb_Pais;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NomeFantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Email;
        internal System.Windows.Forms.Label label17;
    }
}
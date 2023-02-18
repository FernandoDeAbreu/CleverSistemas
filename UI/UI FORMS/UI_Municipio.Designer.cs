namespace Sistema.UI
{
    partial class UI_Municipio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.gb_Aliquota = new System.Windows.Forms.GroupBox();
            this.dg_Aliquota = new System.Windows.Forms.DataGridView();
            this.col_ID_UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_UF_Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Aliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Aliquota_FCP = new System.Windows.Forms.TextBox();
            this.txt_Aliquota_Interna = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Pais = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.lb_Descricao = new System.Windows.Forms.Label();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cb_Pais = new System.Windows.Forms.ComboBox();
            this.lb_UF = new System.Windows.Forms.Label();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_CodigoP = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.lb_PaisP = new System.Windows.Forms.Label();
            this.cb_PaisP = new System.Windows.Forms.ComboBox();
            this.lb_UFP = new System.Windows.Forms.Label();
            this.cb_UFP = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.gb_Aliquota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Aliquota)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.Label4);
            this.TabPage2.Controls.Add(this.txt_CodigoP);
            this.TabPage2.Controls.Add(this.Label3);
            this.TabPage2.Controls.Add(this.lb_PaisP);
            this.TabPage2.Controls.Add(this.cb_PaisP);
            this.TabPage2.Controls.Add(this.lb_UFP);
            this.TabPage2.Controls.Add(this.cb_UFP);
            this.TabPage2.Controls.SetChildIndex(this.cb_UFP, 0);
            this.TabPage2.Controls.SetChildIndex(this.lb_UFP, 0);
            this.TabPage2.Controls.SetChildIndex(this.cb_PaisP, 0);
            this.TabPage2.Controls.SetChildIndex(this.lb_PaisP, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label3, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_CodigoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label4, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.gb_Aliquota);
            this.gb_Cadastro.Controls.Add(this.lb_Pais);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.lb_Descricao);
            this.gb_Cadastro.Controls.Add(this.txt_Codigo);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.cb_Pais);
            this.gb_Cadastro.Controls.Add(this.lb_UF);
            this.gb_Cadastro.Controls.Add(this.cb_UF);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // gb_Aliquota
            // 
            this.gb_Aliquota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Aliquota.Controls.Add(this.dg_Aliquota);
            this.gb_Aliquota.Controls.Add(this.txt_Aliquota_FCP);
            this.gb_Aliquota.Controls.Add(this.txt_Aliquota_Interna);
            this.gb_Aliquota.Controls.Add(this.label6);
            this.gb_Aliquota.Controls.Add(this.label2);
            this.gb_Aliquota.Location = new System.Drawing.Point(7, 175);
            this.gb_Aliquota.Name = "gb_Aliquota";
            this.gb_Aliquota.Size = new System.Drawing.Size(509, 443);
            this.gb_Aliquota.TabIndex = 19;
            this.gb_Aliquota.TabStop = false;
            this.gb_Aliquota.Text = "Alíquota ICMS";
            // 
            // dg_Aliquota
            // 
            this.dg_Aliquota.AllowUserToAddRows = false;
            this.dg_Aliquota.AllowUserToDeleteRows = false;
            this.dg_Aliquota.AllowUserToResizeColumns = false;
            this.dg_Aliquota.AllowUserToResizeRows = false;
            this.dg_Aliquota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dg_Aliquota.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Aliquota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Aliquota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Aliquota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_UF,
            this.col_ID_UF_Destino,
            this.col_Aliquota});
            this.dg_Aliquota.Location = new System.Drawing.Point(213, 19);
            this.dg_Aliquota.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Aliquota.MultiSelect = false;
            this.dg_Aliquota.Name = "dg_Aliquota";
            this.dg_Aliquota.RowHeadersVisible = false;
            this.dg_Aliquota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Aliquota.Size = new System.Drawing.Size(286, 417);
            this.dg_Aliquota.StandardTab = true;
            this.dg_Aliquota.TabIndex = 98;
            // 
            // col_ID_UF
            // 
            this.col_ID_UF.DataPropertyName = "Sigla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_ID_UF.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_ID_UF.HeaderText = "UF DESTINO";
            this.col_ID_UF.Name = "col_ID_UF";
            this.col_ID_UF.ReadOnly = true;
            this.col_ID_UF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ID_UF_Destino
            // 
            this.col_ID_UF_Destino.DataPropertyName = "ID_UF_Destino";
            this.col_ID_UF_Destino.HeaderText = "ID_UF_Destino";
            this.col_ID_UF_Destino.Name = "col_ID_UF_Destino";
            this.col_ID_UF_Destino.Visible = false;
            // 
            // col_Aliquota
            // 
            this.col_Aliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Aliquota.DataPropertyName = "Aliquota";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.col_Aliquota.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Aliquota.HeaderText = "ALÍQ. INTERESTADUAL";
            this.col_Aliquota.Name = "col_Aliquota";
            this.col_Aliquota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_Aliquota_FCP
            // 
            this.txt_Aliquota_FCP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Aliquota_FCP.Location = new System.Drawing.Point(141, 50);
            this.txt_Aliquota_FCP.MaxLength = 5;
            this.txt_Aliquota_FCP.Name = "txt_Aliquota_FCP";
            this.txt_Aliquota_FCP.Size = new System.Drawing.Size(63, 21);
            this.txt_Aliquota_FCP.TabIndex = 5;
            this.txt_Aliquota_FCP.Tag = "T";
            this.txt_Aliquota_FCP.Text = "0,00";
            this.txt_Aliquota_FCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Aliquota_FCP.Leave += new System.EventHandler(this.txt_Aliquota_FCP_Leave);
            // 
            // txt_Aliquota_Interna
            // 
            this.txt_Aliquota_Interna.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Aliquota_Interna.Location = new System.Drawing.Point(141, 19);
            this.txt_Aliquota_Interna.MaxLength = 5;
            this.txt_Aliquota_Interna.Name = "txt_Aliquota_Interna";
            this.txt_Aliquota_Interna.Size = new System.Drawing.Size(63, 21);
            this.txt_Aliquota_Interna.TabIndex = 5;
            this.txt_Aliquota_Interna.Tag = "T";
            this.txt_Aliquota_Interna.Text = "0,00";
            this.txt_Aliquota_Interna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Aliquota_Interna.Leave += new System.EventHandler(this.txt_Aliquota_Interna_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Alíquota FCP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Alíquota Interna ICMS";
            // 
            // lb_Pais
            // 
            this.lb_Pais.AutoSize = true;
            this.lb_Pais.Location = new System.Drawing.Point(127, 11);
            this.lb_Pais.Name = "lb_Pais";
            this.lb_Pais.Size = new System.Drawing.Size(32, 15);
            this.lb_Pais.TabIndex = 18;
            this.lb_Pais.Text = "País";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(7, 30);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(116, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Código";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(7, 133);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(303, 21);
            this.txt_Descricao.TabIndex = 5;
            this.txt_Descricao.Tag = "T";
            // 
            // lb_Descricao
            // 
            this.lb_Descricao.AutoSize = true;
            this.lb_Descricao.Location = new System.Drawing.Point(3, 114);
            this.lb_Descricao.Name = "lb_Descricao";
            this.lb_Descricao.Size = new System.Drawing.Size(63, 15);
            this.lb_Descricao.TabIndex = 16;
            this.lb_Descricao.Text = "Descrição";
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Codigo.Location = new System.Drawing.Point(7, 77);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(116, 21);
            this.txt_Codigo.TabIndex = 4;
            this.txt_Codigo.Tag = "T";
            this.txt_Codigo.TextChanged += new System.EventHandler(this.txt_Codigo_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 58);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 15);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Código IBGE";
            // 
            // cb_Pais
            // 
            this.cb_Pais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Pais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Pais.FormattingEnabled = true;
            this.cb_Pais.Location = new System.Drawing.Point(131, 30);
            this.cb_Pais.Name = "cb_Pais";
            this.cb_Pais.Size = new System.Drawing.Size(273, 23);
            this.cb_Pais.TabIndex = 2;
            this.cb_Pais.Tag = "T";
            this.cb_Pais.SelectedValueChanged += new System.EventHandler(this.cb_Pais_SelectedValueChanged);
            // 
            // lb_UF
            // 
            this.lb_UF.AutoSize = true;
            this.lb_UF.Location = new System.Drawing.Point(408, 11);
            this.lb_UF.Name = "lb_UF";
            this.lb_UF.Size = new System.Drawing.Size(23, 15);
            this.lb_UF.TabIndex = 14;
            this.lb_UF.Text = "UF";
            // 
            // cb_UF
            // 
            this.cb_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Location = new System.Drawing.Point(412, 30);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(188, 23);
            this.cb_UF.TabIndex = 3;
            this.cb_UF.Tag = "T";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(132, 78);
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(608, 21);
            this.txt_DescricaoP.TabIndex = 4;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(128, 59);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 15);
            this.Label4.TabIndex = 122;
            this.Label4.Text = "Descrição";
            // 
            // txt_CodigoP
            // 
            this.txt_CodigoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CodigoP.Location = new System.Drawing.Point(8, 78);
            this.txt_CodigoP.Name = "txt_CodigoP";
            this.txt_CodigoP.Size = new System.Drawing.Size(116, 21);
            this.txt_CodigoP.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(5, 59);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(78, 15);
            this.Label3.TabIndex = 121;
            this.Label3.Text = "Código IBGE";
            // 
            // lb_PaisP
            // 
            this.lb_PaisP.AutoSize = true;
            this.lb_PaisP.Location = new System.Drawing.Point(5, 11);
            this.lb_PaisP.Name = "lb_PaisP";
            this.lb_PaisP.Size = new System.Drawing.Size(32, 15);
            this.lb_PaisP.TabIndex = 120;
            this.lb_PaisP.Text = "País";
            // 
            // cb_PaisP
            // 
            this.cb_PaisP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_PaisP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PaisP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PaisP.FormattingEnabled = true;
            this.cb_PaisP.Location = new System.Drawing.Point(8, 30);
            this.cb_PaisP.Name = "cb_PaisP";
            this.cb_PaisP.Size = new System.Drawing.Size(273, 23);
            this.cb_PaisP.TabIndex = 1;
            this.cb_PaisP.Tag = "T";
            this.cb_PaisP.SelectedValueChanged += new System.EventHandler(this.cb_PaisP_SelectedValueChanged);
            // 
            // lb_UFP
            // 
            this.lb_UFP.AutoSize = true;
            this.lb_UFP.Location = new System.Drawing.Point(286, 11);
            this.lb_UFP.Name = "lb_UFP";
            this.lb_UFP.Size = new System.Drawing.Size(23, 15);
            this.lb_UFP.TabIndex = 119;
            this.lb_UFP.Text = "UF";
            // 
            // cb_UFP
            // 
            this.cb_UFP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UFP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UFP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UFP.FormattingEnabled = true;
            this.cb_UFP.Location = new System.Drawing.Point(289, 30);
            this.cb_UFP.Name = "cb_UFP";
            this.cb_UFP.Size = new System.Drawing.Size(188, 23);
            this.cb_UFP.TabIndex = 2;
            this.cb_UFP.Tag = "T";
            // 
            // UI_Municipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Municipio";
            this.Load += new System.EventHandler(this.UI_Municipio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Municipio_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Municipio_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.gb_Aliquota.ResumeLayout(false);
            this.gb_Aliquota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Aliquota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.TextBox txt_Codigo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cb_Pais;
        internal System.Windows.Forms.Label lb_UF;
        internal System.Windows.Forms.ComboBox cb_UF;
        internal System.Windows.Forms.Label lb_Pais;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label lb_Descricao;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_CodigoP;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lb_PaisP;
        internal System.Windows.Forms.ComboBox cb_PaisP;
        internal System.Windows.Forms.Label lb_UFP;
        internal System.Windows.Forms.ComboBox cb_UFP;
        private System.Windows.Forms.GroupBox gb_Aliquota;
        internal System.Windows.Forms.TextBox txt_Aliquota_FCP;
        internal System.Windows.Forms.TextBox txt_Aliquota_Interna;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dg_Aliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_UF_Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Aliquota;
    }
}

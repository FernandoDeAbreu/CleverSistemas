namespace Sistema.UI
{
    partial class UI_Pessoa_Relatorio
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
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Vendedor = new System.Windows.Forms.Label();
            this.cb_ID_Grupo = new System.Windows.Forms.ComboBox();
            this.cb_ID_Usuario = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.lb_UF = new System.Windows.Forms.Label();
            this.cb_Municipio = new System.Windows.Forms.ComboBox();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Etiqueta = new System.Windows.Forms.ComboBox();
            this.dg_Etiqueta = new System.Windows.Forms.DataGridView();
            this.col_Imprime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Classificar = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Etiqueta)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label7);
            this.TabPage1.Controls.Add(this.cb_Classificar);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.lb_Vendedor);
            this.TabPage1.Controls.Add(this.cb_ID_Grupo);
            this.TabPage1.Controls.Add(this.cb_ID_Usuario);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.Label28);
            this.TabPage1.Controls.Add(this.lb_UF);
            this.TabPage1.Controls.Add(this.cb_Municipio);
            this.TabPage1.Controls.Add(this.cb_UF);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.cb_Etiqueta);
            this.TabPage1.Controls.Add(this.dg_Etiqueta);
            this.TabPage1.Controls.Add(this.txt_Descricao);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Text = "PESQUISA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 190;
            this.label3.Text = "Grupo";
            // 
            // lb_Vendedor
            // 
            this.lb_Vendedor.AutoSize = true;
            this.lb_Vendedor.Location = new System.Drawing.Point(9, 69);
            this.lb_Vendedor.Name = "lb_Vendedor";
            this.lb_Vendedor.Size = new System.Drawing.Size(59, 15);
            this.lb_Vendedor.TabIndex = 189;
            this.lb_Vendedor.Text = "Vendedor";
            // 
            // cb_ID_Grupo
            // 
            this.cb_ID_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Grupo.FormattingEnabled = true;
            this.cb_ID_Grupo.Location = new System.Drawing.Point(290, 88);
            this.cb_ID_Grupo.Name = "cb_ID_Grupo";
            this.cb_ID_Grupo.Size = new System.Drawing.Size(203, 23);
            this.cb_ID_Grupo.TabIndex = 4;
            this.cb_ID_Grupo.Tag = "T";
            // 
            // cb_ID_Usuario
            // 
            this.cb_ID_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Usuario.FormattingEnabled = true;
            this.cb_ID_Usuario.Location = new System.Drawing.Point(13, 88);
            this.cb_ID_Usuario.Name = "cb_ID_Usuario";
            this.cb_ID_Usuario.Size = new System.Drawing.Size(264, 23);
            this.cb_ID_Usuario.TabIndex = 3;
            this.cb_ID_Usuario.Tag = "T";
            this.cb_ID_Usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_Usuario_KeyDown);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(13, 34);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(172, 23);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(679, 69);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(59, 15);
            this.Label28.TabIndex = 187;
            this.Label28.Text = "Município";
            // 
            // lb_UF
            // 
            this.lb_UF.AutoSize = true;
            this.lb_UF.Location = new System.Drawing.Point(504, 69);
            this.lb_UF.Name = "lb_UF";
            this.lb_UF.Size = new System.Drawing.Size(23, 15);
            this.lb_UF.TabIndex = 186;
            this.lb_UF.Text = "UF";
            // 
            // cb_Municipio
            // 
            this.cb_Municipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Municipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Municipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Municipio.FormattingEnabled = true;
            this.cb_Municipio.Location = new System.Drawing.Point(683, 88);
            this.cb_Municipio.Name = "cb_Municipio";
            this.cb_Municipio.Size = new System.Drawing.Size(251, 23);
            this.cb_Municipio.TabIndex = 6;
            this.cb_Municipio.Tag = "";
            this.cb_Municipio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_Municipio_KeyDown);
            // 
            // cb_UF
            // 
            this.cb_UF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_UF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Location = new System.Drawing.Point(507, 88);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(171, 23);
            this.cb_UF.TabIndex = 5;
            this.cb_UF.Tag = "";
            this.cb_UF.SelectedValueChanged += new System.EventHandler(this.cb_UF_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 576);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 185;
            this.label6.Text = "Tipo Relatório";
            // 
            // cb_Etiqueta
            // 
            this.cb_Etiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Etiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Etiqueta.FormattingEnabled = true;
            this.cb_Etiqueta.Location = new System.Drawing.Point(8, 596);
            this.cb_Etiqueta.Name = "cb_Etiqueta";
            this.cb_Etiqueta.Size = new System.Drawing.Size(343, 23);
            this.cb_Etiqueta.TabIndex = 20;
            this.cb_Etiqueta.Tag = "T";
            // 
            // dg_Etiqueta
            // 
            this.dg_Etiqueta.AllowUserToAddRows = false;
            this.dg_Etiqueta.AllowUserToDeleteRows = false;
            this.dg_Etiqueta.AllowUserToResizeColumns = false;
            this.dg_Etiqueta.AllowUserToResizeRows = false;
            this.dg_Etiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Etiqueta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Etiqueta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Etiqueta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Etiqueta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Imprime,
            this.col_ID_Pessoa,
            this.col_Descricao,
            this.col_Endereco,
            this.col_Complemento,
            this.col_Bairro,
            this.col_Cidade,
            this.col_CEP});
            this.dg_Etiqueta.Location = new System.Drawing.Point(8, 170);
            this.dg_Etiqueta.MultiSelect = false;
            this.dg_Etiqueta.Name = "dg_Etiqueta";
            this.dg_Etiqueta.RowHeadersVisible = false;
            this.dg_Etiqueta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Etiqueta.Size = new System.Drawing.Size(928, 392);
            this.dg_Etiqueta.TabIndex = 10;
            this.dg_Etiqueta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_Etiqueta_CellPainting);
            this.dg_Etiqueta.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Etiqueta_ColumnHeaderMouseClick);
            this.dg_Etiqueta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dg_Etiqueta_MouseDoubleClick);
            // 
            // col_Imprime
            // 
            this.col_Imprime.HeaderText = "";
            this.col_Imprime.Name = "col_Imprime";
            this.col_Imprime.Width = 30;
            // 
            // col_ID_Pessoa
            // 
            this.col_ID_Pessoa.HeaderText = "ID";
            this.col_ID_Pessoa.Name = "col_ID_Pessoa";
            this.col_ID_Pessoa.ReadOnly = true;
            this.col_ID_Pessoa.Visible = false;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.HeaderText = "Descrição";
            this.col_Descricao.MinimumWidth = 250;
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_Endereco
            // 
            this.col_Endereco.HeaderText = "Endereço";
            this.col_Endereco.Name = "col_Endereco";
            this.col_Endereco.ReadOnly = true;
            this.col_Endereco.Width = 250;
            // 
            // col_Complemento
            // 
            this.col_Complemento.HeaderText = "Complemento";
            this.col_Complemento.Name = "col_Complemento";
            this.col_Complemento.ReadOnly = true;
            this.col_Complemento.Width = 200;
            // 
            // col_Bairro
            // 
            this.col_Bairro.HeaderText = "Bairro";
            this.col_Bairro.Name = "col_Bairro";
            this.col_Bairro.ReadOnly = true;
            // 
            // col_Cidade
            // 
            this.col_Cidade.HeaderText = "Cidade";
            this.col_Cidade.Name = "col_Cidade";
            this.col_Cidade.ReadOnly = true;
            // 
            // col_CEP
            // 
            this.col_CEP.HeaderText = "CEP";
            this.col_CEP.Name = "col_CEP";
            this.col_CEP.ReadOnly = true;
            this.col_CEP.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 183;
            this.label1.Text = "Descrição";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(192, 34);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(486, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 183;
            this.label2.Text = "Tipo Pessoa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 192;
            this.label7.Text = "Classificar";
            // 
            // cb_Classificar
            // 
            this.cb_Classificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Classificar.FormattingEnabled = true;
            this.cb_Classificar.Items.AddRange(new object[] {
            "DESCRIÇÃO",
            "MUNICÍPIO"});
            this.cb_Classificar.Location = new System.Drawing.Point(13, 139);
            this.cb_Classificar.Name = "cb_Classificar";
            this.cb_Classificar.Size = new System.Drawing.Size(203, 23);
            this.cb_Classificar.TabIndex = 7;
            this.cb_Classificar.Tag = "T";
            // 
            // UI_Pessoa_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Pessoa_Relatorio";
            this.Load += new System.EventHandler(this.UI_Pessoa_Etiqueta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Pessoa_Etiqueta_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Etiqueta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lb_Vendedor;
        internal System.Windows.Forms.ComboBox cb_ID_Grupo;
        internal System.Windows.Forms.ComboBox cb_ID_Usuario;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Label lb_UF;
        internal System.Windows.Forms.ComboBox cb_Municipio;
        internal System.Windows.Forms.ComboBox cb_UF;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cb_Etiqueta;
        internal System.Windows.Forms.DataGridView dg_Etiqueta;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Imprime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CEP;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cb_Classificar;
    }
}

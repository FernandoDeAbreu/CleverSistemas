namespace Sistema.UI
{
    partial class UI_ControleDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_ControleDoc));
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ck_ExibeEntregue = new System.Windows.Forms.CheckBox();
            this.mk_PeriodoP = new System.Windows.Forms.MaskedTextBox();
            this.gb_Lista_Doc = new System.Windows.Forms.GroupBox();
            this.lts_menu = new System.Windows.Forms.ListView();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_QuantidadeLancar = new System.Windows.Forms.TextBox();
            this.mk_Periodo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dg_Config_Doc = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_ID_PessoaP = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.gb_Lista_Doc.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Config_Doc)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            this.TabPage1.Text = "BAIXA DE DOCUMENTOS";
            // 
            // tabctl
            // 
            this.tabctl.Controls.Add(this.tabPage3);
            this.tabctl.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage2, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage1, 0);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.bt_PesquisaConta);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.ck_ExibeEntregue);
            this.gb_Cadastro.Controls.Add(this.mk_PeriodoP);
            this.gb_Cadastro.Controls.Add(this.gb_Lista_Doc);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.Image = ((System.Drawing.Image)(resources.GetObject("bt_PesquisaConta.Image")));
            this.bt_PesquisaConta.Location = new System.Drawing.Point(553, 42);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 27);
            this.bt_PesquisaConta.TabIndex = 31;
            this.bt_PesquisaConta.UseVisualStyleBackColor = true;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Pessoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "Período";
            // 
            // ck_ExibeEntregue
            // 
            this.ck_ExibeEntregue.AutoSize = true;
            this.ck_ExibeEntregue.Location = new System.Drawing.Point(604, 45);
            this.ck_ExibeEntregue.Name = "ck_ExibeEntregue";
            this.ck_ExibeEntregue.Size = new System.Drawing.Size(183, 19);
            this.ck_ExibeEntregue.TabIndex = 32;
            this.ck_ExibeEntregue.Text = "Exibir Documentos Entregue";
            this.ck_ExibeEntregue.UseVisualStyleBackColor = true;
            // 
            // mk_PeriodoP
            // 
            this.mk_PeriodoP.BackColor = System.Drawing.SystemColors.Window;
            this.mk_PeriodoP.Location = new System.Drawing.Point(7, 43);
            this.mk_PeriodoP.Mask = "00/0000";
            this.mk_PeriodoP.Name = "mk_PeriodoP";
            this.mk_PeriodoP.Size = new System.Drawing.Size(95, 21);
            this.mk_PeriodoP.TabIndex = 30;
            this.mk_PeriodoP.TabStop = false;
            this.mk_PeriodoP.Tag = "";
            this.mk_PeriodoP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_PeriodoP.Leave += new System.EventHandler(this.mk_PeriodoP_Leave);
            // 
            // gb_Lista_Doc
            // 
            this.gb_Lista_Doc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Lista_Doc.Controls.Add(this.lts_menu);
            this.gb_Lista_Doc.Location = new System.Drawing.Point(7, 73);
            this.gb_Lista_Doc.Name = "gb_Lista_Doc";
            this.gb_Lista_Doc.Size = new System.Drawing.Size(928, 541);
            this.gb_Lista_Doc.TabIndex = 33;
            this.gb_Lista_Doc.TabStop = false;
            // 
            // lts_menu
            // 
            this.lts_menu.AllowColumnReorder = true;
            this.lts_menu.BackColor = System.Drawing.SystemColors.Control;
            this.lts_menu.CheckBoxes = true;
            this.lts_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lts_menu.FullRowSelect = true;
            this.lts_menu.GridLines = true;
            this.lts_menu.HideSelection = false;
            this.lts_menu.LabelEdit = true;
            this.lts_menu.Location = new System.Drawing.Point(3, 17);
            this.lts_menu.Name = "lts_menu";
            this.lts_menu.RightToLeftLayout = true;
            this.lts_menu.Size = new System.Drawing.Size(922, 521);
            this.lts_menu.TabIndex = 30;
            this.lts_menu.UseCompatibleStateImageBehavior = false;
            this.lts_menu.View = System.Windows.Forms.View.Details;
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(110, 43);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(434, 23);
            this.cb_ID_Pessoa.TabIndex = 31;
            this.cb_ID_Pessoa.TabStop = false;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_QuantidadeLancar);
            this.tabPage3.Controls.Add(this.mk_Periodo);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.Label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dg_Config_Doc);
            this.tabPage3.Controls.Add(this.cb_ID_PessoaP);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CADASTRO DE DOCUMENTOS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_QuantidadeLancar
            // 
            this.txt_QuantidadeLancar.BackColor = System.Drawing.SystemColors.Window;
            this.txt_QuantidadeLancar.Location = new System.Drawing.Point(567, 31);
            this.txt_QuantidadeLancar.MaxLength = 60;
            this.txt_QuantidadeLancar.Name = "txt_QuantidadeLancar";
            this.txt_QuantidadeLancar.Size = new System.Drawing.Size(116, 21);
            this.txt_QuantidadeLancar.TabIndex = 70;
            this.txt_QuantidadeLancar.Tag = "T";
            this.txt_QuantidadeLancar.Text = "1";
            this.txt_QuantidadeLancar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mk_Periodo
            // 
            this.mk_Periodo.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Periodo.Location = new System.Drawing.Point(13, 32);
            this.mk_Periodo.Mask = "00/0000";
            this.mk_Periodo.Name = "mk_Periodo";
            this.mk_Periodo.Size = new System.Drawing.Size(95, 21);
            this.mk_Periodo.TabIndex = 68;
            this.mk_Periodo.TabStop = false;
            this.mk_Periodo.Tag = "";
            this.mk_Periodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Periodo.Leave += new System.EventHandler(this.mk_Periodo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 73;
            this.label6.Text = "Qt. Meses a Lançar";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 13);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 15);
            this.Label4.TabIndex = 74;
            this.Label4.Text = "Período";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "Pessoa";
            // 
            // dg_Config_Doc
            // 
            this.dg_Config_Doc.AllowUserToAddRows = false;
            this.dg_Config_Doc.AllowUserToDeleteRows = false;
            this.dg_Config_Doc.AllowUserToResizeColumns = false;
            this.dg_Config_Doc.AllowUserToResizeRows = false;
            this.dg_Config_Doc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Config_Doc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Config_Doc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Config_Doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Config_Doc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_Tipo,
            this.col_Documento,
            this.col_ID,
            this.col_ID_Doc});
            this.dg_Config_Doc.Location = new System.Drawing.Point(9, 64);
            this.dg_Config_Doc.MultiSelect = false;
            this.dg_Config_Doc.Name = "dg_Config_Doc";
            this.dg_Config_Doc.RowHeadersVisible = false;
            this.dg_Config_Doc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Config_Doc.Size = new System.Drawing.Size(927, 556);
            this.dg_Config_Doc.TabIndex = 71;
            this.dg_Config_Doc.TabStop = false;
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 30;
            // 
            // col_Tipo
            // 
            this.col_Tipo.HeaderText = "Tipo";
            this.col_Tipo.Name = "col_Tipo";
            this.col_Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Tipo.Width = 375;
            // 
            // col_Documento
            // 
            this.col_Documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Documento.HeaderText = "Documento";
            this.col_Documento.Name = "col_Documento";
            // 
            // col_ID
            // 
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.Visible = false;
            // 
            // col_ID_Doc
            // 
            this.col_ID_Doc.HeaderText = "ID_Doc";
            this.col_ID_Doc.Name = "col_ID_Doc";
            this.col_ID_Doc.Visible = false;
            // 
            // cb_ID_PessoaP
            // 
            this.cb_ID_PessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_PessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_PessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_PessoaP.FormattingEnabled = true;
            this.cb_ID_PessoaP.Location = new System.Drawing.Point(115, 31);
            this.cb_ID_PessoaP.MaxDropDownItems = 15;
            this.cb_ID_PessoaP.Name = "cb_ID_PessoaP";
            this.cb_ID_PessoaP.Size = new System.Drawing.Size(434, 23);
            this.cb_ID_PessoaP.TabIndex = 69;
            this.cb_ID_PessoaP.TabStop = false;
            this.cb_ID_PessoaP.Tag = "T";
            // 
            // UI_ControleDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_ControleDoc";
            this.Load += new System.EventHandler(this.UI_ControleDoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_ControleDoc_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_ControleDoc_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.gb_Lista_Doc.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Config_Doc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        private System.Windows.Forms.CheckBox ck_ExibeEntregue;
        internal System.Windows.Forms.MaskedTextBox mk_PeriodoP;
        internal System.Windows.Forms.GroupBox gb_Lista_Doc;
        internal System.Windows.Forms.ListView lts_menu;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.TextBox txt_QuantidadeLancar;
        internal System.Windows.Forms.MaskedTextBox mk_Periodo;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DataGridView dg_Config_Doc;
        internal System.Windows.Forms.ComboBox cb_ID_PessoaP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Doc;
        internal System.Windows.Forms.Button bt_PesquisaConta;
    }
}

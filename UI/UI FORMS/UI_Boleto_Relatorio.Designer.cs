namespace Sistema.UI
{
    partial class UI_Boleto_Relatorio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.cb_sit_Boleto = new System.Windows.Forms.ComboBox();
            this.cb_PeriodoBoleto = new System.Windows.Forms.ComboBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.dg_Boletos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DocBoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NossoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VencimentoBoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorBoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataBaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Boleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AcrescimoBoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescontoBoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Cedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label37 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ID_Boleto = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Boletos)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.label30);
            this.TabPage1.Controls.Add(this.label32);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.cb_sit_Boleto);
            this.TabPage1.Controls.Add(this.cb_PeriodoBoleto);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.dg_Boletos);
            this.TabPage1.Controls.Add(this.label37);
            this.TabPage1.Controls.Add(this.label8);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.label10);
            this.TabPage1.Controls.Add(this.txt_ID_Boleto);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(9, 27);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(199, 23);
            this.cb_TipoPessoa.TabIndex = 79;
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 6);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 15);
            this.label30.TabIndex = 91;
            this.label30.Text = "Tipo Pessoa";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(216, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(109, 15);
            this.label32.TabIndex = 90;
            this.label32.Text = "Descrição Pessoa";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(219, 27);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(476, 23);
            this.cb_ID_Pessoa.TabIndex = 80;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // cb_sit_Boleto
            // 
            this.cb_sit_Boleto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_sit_Boleto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_sit_Boleto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sit_Boleto.FormattingEnabled = true;
            this.cb_sit_Boleto.Items.AddRange(new object[] {
            "TODOS",
            "EM ABERTO",
            "LIQUIDADOS"});
            this.cb_sit_Boleto.Location = new System.Drawing.Point(458, 76);
            this.cb_sit_Boleto.Name = "cb_sit_Boleto";
            this.cb_sit_Boleto.Size = new System.Drawing.Size(237, 23);
            this.cb_sit_Boleto.TabIndex = 84;
            this.cb_sit_Boleto.Tag = "T";
            // 
            // cb_PeriodoBoleto
            // 
            this.cb_PeriodoBoleto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_PeriodoBoleto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_PeriodoBoleto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PeriodoBoleto.FormattingEnabled = true;
            this.cb_PeriodoBoleto.Items.AddRange(new object[] {
            "BAIXA",
            "EMISSÃO",
            "VENCIMENTO"});
            this.cb_PeriodoBoleto.Location = new System.Drawing.Point(9, 75);
            this.cb_PeriodoBoleto.Name = "cb_PeriodoBoleto";
            this.cb_PeriodoBoleto.Size = new System.Drawing.Size(199, 23);
            this.cb_PeriodoBoleto.TabIndex = 81;
            this.cb_PeriodoBoleto.Tag = "T";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(219, 76);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 82;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // dg_Boletos
            // 
            this.dg_Boletos.AllowUserToAddRows = false;
            this.dg_Boletos.AllowUserToDeleteRows = false;
            this.dg_Boletos.AllowUserToResizeColumns = false;
            this.dg_Boletos.AllowUserToResizeRows = false;
            this.dg_Boletos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Boletos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Boletos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Boletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Boletos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.col_DocBoleto,
            this.col_NossoNumero,
            this.col_VencimentoBoleto,
            this.col_ValorBoleto,
            this.col_DataBaixa,
            this.col_ID_Boleto,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn15,
            this.col_AcrescimoBoleto,
            this.col_DescontoBoleto,
            this.col_ID_Cedente});
            this.dg_Boletos.Location = new System.Drawing.Point(4, 114);
            this.dg_Boletos.MultiSelect = false;
            this.dg_Boletos.Name = "dg_Boletos";
            this.dg_Boletos.RowHeadersVisible = false;
            this.dg_Boletos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Boletos.Size = new System.Drawing.Size(934, 507);
            this.dg_Boletos.StandardTab = true;
            this.dg_Boletos.TabIndex = 85;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DescricaoPessoa";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pessoa";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Emissao";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "Emissão";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // col_DocBoleto
            // 
            this.col_DocBoleto.DataPropertyName = "Documento";
            this.col_DocBoleto.HeaderText = "Nº Doc.";
            this.col_DocBoleto.Name = "col_DocBoleto";
            this.col_DocBoleto.ReadOnly = true;
            this.col_DocBoleto.Width = 70;
            // 
            // col_NossoNumero
            // 
            this.col_NossoNumero.DataPropertyName = "NossoNumero";
            this.col_NossoNumero.HeaderText = "Nosso Número";
            this.col_NossoNumero.Name = "col_NossoNumero";
            this.col_NossoNumero.ReadOnly = true;
            this.col_NossoNumero.Width = 120;
            // 
            // col_VencimentoBoleto
            // 
            this.col_VencimentoBoleto.DataPropertyName = "Vencimento";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.col_VencimentoBoleto.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_VencimentoBoleto.HeaderText = "Vencimento";
            this.col_VencimentoBoleto.Name = "col_VencimentoBoleto";
            this.col_VencimentoBoleto.ReadOnly = true;
            this.col_VencimentoBoleto.Width = 80;
            // 
            // col_ValorBoleto
            // 
            this.col_ValorBoleto.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_ValorBoleto.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_ValorBoleto.HeaderText = "Valor";
            this.col_ValorBoleto.Name = "col_ValorBoleto";
            this.col_ValorBoleto.ReadOnly = true;
            this.col_ValorBoleto.Width = 70;
            // 
            // col_DataBaixa
            // 
            this.col_DataBaixa.DataPropertyName = "DataBaixa";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.col_DataBaixa.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_DataBaixa.HeaderText = "Data Baixa";
            this.col_DataBaixa.Name = "col_DataBaixa";
            this.col_DataBaixa.ReadOnly = true;
            this.col_DataBaixa.Width = 90;
            // 
            // col_ID_Boleto
            // 
            this.col_ID_Boleto.DataPropertyName = "ID";
            this.col_ID_Boleto.HeaderText = "ID";
            this.col_ID_Boleto.Name = "col_ID_Boleto";
            this.col_ID_Boleto.ReadOnly = true;
            this.col_ID_Boleto.Visible = false;
            this.col_ID_Boleto.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TipoPessoa";
            this.dataGridViewTextBoxColumn12.HeaderText = "TipoPessoa";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ID_Pessoa";
            this.dataGridViewTextBoxColumn15.HeaderText = "ID_Pessoa";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // col_AcrescimoBoleto
            // 
            this.col_AcrescimoBoleto.DataPropertyName = "Acrescimo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_AcrescimoBoleto.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_AcrescimoBoleto.HeaderText = "Acréscimo";
            this.col_AcrescimoBoleto.Name = "col_AcrescimoBoleto";
            this.col_AcrescimoBoleto.ReadOnly = true;
            // 
            // col_DescontoBoleto
            // 
            this.col_DescontoBoleto.DataPropertyName = "Desconto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_DescontoBoleto.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_DescontoBoleto.HeaderText = "Desconto";
            this.col_DescontoBoleto.Name = "col_DescontoBoleto";
            this.col_DescontoBoleto.ReadOnly = true;
            // 
            // col_ID_Cedente
            // 
            this.col_ID_Cedente.DataPropertyName = "ID_Cedente";
            this.col_ID_Cedente.HeaderText = "Cedente";
            this.col_ID_Cedente.Name = "col_ID_Cedente";
            this.col_ID_Cedente.ReadOnly = true;
            this.col_ID_Cedente.Visible = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(455, 58);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(55, 15);
            this.label37.TabIndex = 87;
            this.label37.Text = "Situação";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 88;
            this.label8.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(350, 76);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 83;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 15);
            this.label10.TabIndex = 86;
            this.label10.Text = "à";
            // 
            // txt_ID_Boleto
            // 
            this.txt_ID_Boleto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_Boleto.Enabled = false;
            this.txt_ID_Boleto.Location = new System.Drawing.Point(279, 76);
            this.txt_ID_Boleto.Name = "txt_ID_Boleto";
            this.txt_ID_Boleto.Size = new System.Drawing.Size(14, 21);
            this.txt_ID_Boleto.TabIndex = 89;
            this.txt_ID_Boleto.Tag = "T";
            // 
            // UI_Boleto_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Boleto_Relatorio";
            this.Load += new System.EventHandler(this.UI_Boleto_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Boleto_Relatorio_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Boletos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.ComboBox cb_sit_Boleto;
        internal System.Windows.Forms.ComboBox cb_PeriodoBoleto;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.DataGridView dg_Boletos;
        internal System.Windows.Forms.Label label37;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txt_ID_Boleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DocBoleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NossoNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VencimentoBoleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorBoleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataBaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Boleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AcrescimoBoleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescontoBoleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Cedente;
    }
}

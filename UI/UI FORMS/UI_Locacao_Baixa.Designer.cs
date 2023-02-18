namespace Sistema.UI
{
    partial class UI_Locacao_Baixa
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
            this.txt_Proprietario = new System.Windows.Forms.TextBox();
            this.dg_CReceber = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Resumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Multa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Juros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.cb_ExibirJuros = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.cb_ExibirJuros);
            this.TabPage1.Controls.Add(this.txt_Total);
            this.TabPage1.Controls.Add(this.txt_Proprietario);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.dg_CReceber);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_Data);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.label7);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            // 
            // txt_Proprietario
            // 
            this.txt_Proprietario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Proprietario.Location = new System.Drawing.Point(22, 101);
            this.txt_Proprietario.MaxLength = 60;
            this.txt_Proprietario.Name = "txt_Proprietario";
            this.txt_Proprietario.ReadOnly = true;
            this.txt_Proprietario.Size = new System.Drawing.Size(403, 21);
            this.txt_Proprietario.TabIndex = 2;
            this.txt_Proprietario.Tag = "T";
            // 
            // dg_CReceber
            // 
            this.dg_CReceber.AllowUserToAddRows = false;
            this.dg_CReceber.AllowUserToDeleteRows = false;
            this.dg_CReceber.AllowUserToOrderColumns = true;
            this.dg_CReceber.AllowUserToResizeRows = false;
            this.dg_CReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_CReceber.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_CReceber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_CReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CReceber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.col_Descricao,
            this.col_Resumo,
            this.col_Vencimento,
            this.col_Valor,
            this.col_Multa,
            this.col_Juros,
            this.col_ValorTotal});
            this.dg_CReceber.Location = new System.Drawing.Point(22, 257);
            this.dg_CReceber.MultiSelect = false;
            this.dg_CReceber.Name = "dg_CReceber";
            this.dg_CReceber.ReadOnly = true;
            this.dg_CReceber.RowHeadersVisible = false;
            this.dg_CReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_CReceber.Size = new System.Drawing.Size(906, 305);
            this.dg_CReceber.StandardTab = true;
            this.dg_CReceber.TabIndex = 30;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "DescricaoConta";
            this.Column2.HeaderText = "Descrição Conta";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "Lançamento";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_Resumo
            // 
            this.col_Resumo.DataPropertyName = "ResumoParcela";
            this.col_Resumo.HeaderText = "Parcela";
            this.col_Resumo.Name = "col_Resumo";
            this.col_Resumo.ReadOnly = true;
            this.col_Resumo.Width = 80;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Vencimento.HeaderText = "Vencimento";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.Width = 75;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Valor.HeaderText = "Valor";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 75;
            // 
            // col_Multa
            // 
            this.col_Multa.DataPropertyName = "Multa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_Multa.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Multa.HeaderText = "Multa";
            this.col_Multa.Name = "col_Multa";
            this.col_Multa.ReadOnly = true;
            this.col_Multa.Width = 75;
            // 
            // col_Juros
            // 
            this.col_Juros.DataPropertyName = "Juros";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_Juros.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Juros.HeaderText = "Juros";
            this.col_Juros.Name = "col_Juros";
            this.col_Juros.ReadOnly = true;
            this.col_Juros.Width = 75;
            // 
            // col_ValorTotal
            // 
            this.col_ValorTotal.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_ValorTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ValorTotal.HeaderText = "Total";
            this.col_ValorTotal.Name = "col_ValorTotal";
            this.col_ValorTotal.ReadOnly = true;
            this.col_ValorTotal.Width = 75;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(131, 155);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 144;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(153, 152);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 5;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(22, 213);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(101, 21);
            this.mk_Data.TabIndex = 15;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(22, 152);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 4;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 140;
            this.label7.Text = "Proprietário";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 139;
            this.label3.Text = "Locatário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 143;
            this.label5.Text = "Período";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(22, 44);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(521, 23);
            this.cb_ID_Pessoa.TabIndex = 1;
            this.cb_ID_Pessoa.Leave += new System.EventHandler(this.cb_ID_Pessoa_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(968, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 145;
            this.label1.Text = "Valor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 143;
            this.label2.Text = "Data";
            // 
            // txt_Total
            // 
            this.txt_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Total.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(1013, 570);
            this.txt_Total.MaxLength = 14;
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(131, 26);
            this.txt_Total.TabIndex = 134;
            this.txt_Total.TabStop = false;
            this.txt_Total.Tag = "T";
            this.txt_Total.Text = "0,00";
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cb_ExibirJuros
            // 
            this.cb_ExibirJuros.AutoSize = true;
            this.cb_ExibirJuros.Location = new System.Drawing.Point(153, 216);
            this.cb_ExibirJuros.Name = "cb_ExibirJuros";
            this.cb_ExibirJuros.Size = new System.Drawing.Size(132, 19);
            this.cb_ExibirJuros.TabIndex = 20;
            this.cb_ExibirJuros.Text = "Exibir Juros e Multa";
            this.cb_ExibirJuros.UseVisualStyleBackColor = true;
            this.cb_ExibirJuros.CheckedChanged += new System.EventHandler(this.cb_ExibirJuros_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(85, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 146;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Locacao_Baixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Locacao_Baixa";
            this.Load += new System.EventHandler(this.UI_Locacao_Baixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Locacao_Baixa_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_CReceber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Proprietario;
        internal System.Windows.Forms.DataGridView dg_CReceber;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.CheckBox cb_ExibirJuros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Resumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Multa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Juros;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorTotal;
        internal System.Windows.Forms.Label label27;
    }
}

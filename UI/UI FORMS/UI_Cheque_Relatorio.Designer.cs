namespace Sistema.UI
{
    partial class UI_Cheque_Relatorio
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
            this.Label22 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txt_Cheque = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txt_Conta = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txt_Agencia = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txt_Banco = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.txt_Documento = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_Consulta = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Consulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Consulta);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(7, 266);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(50, 15);
            this.Label22.TabIndex = 690;
            this.Label22.Text = "Período";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(10, 284);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(146, 23);
            this.cb_Periodo.TabIndex = 30;
            this.cb_Periodo.Tag = "T";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(273, 291);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 689;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(295, 284);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 32;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(164, 284);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 31;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // txt_Cheque
            // 
            this.txt_Cheque.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Cheque.Location = new System.Drawing.Point(237, 154);
            this.txt_Cheque.MaxLength = 10;
            this.txt_Cheque.Name = "txt_Cheque";
            this.txt_Cheque.Size = new System.Drawing.Size(95, 21);
            this.txt_Cheque.TabIndex = 17;
            this.txt_Cheque.Tag = "";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(233, 135);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(67, 15);
            this.Label11.TabIndex = 688;
            this.Label11.Text = "Nº Cheque";
            // 
            // txt_Conta
            // 
            this.txt_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Conta.Location = new System.Drawing.Point(133, 154);
            this.txt_Conta.MaxLength = 10;
            this.txt_Conta.Name = "txt_Conta";
            this.txt_Conta.Size = new System.Drawing.Size(96, 21);
            this.txt_Conta.TabIndex = 16;
            this.txt_Conta.Tag = "";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(129, 135);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(40, 15);
            this.Label13.TabIndex = 687;
            this.Label13.Text = "Conta";
            // 
            // txt_Agencia
            // 
            this.txt_Agencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Agencia.Location = new System.Drawing.Point(70, 154);
            this.txt_Agencia.MaxLength = 6;
            this.txt_Agencia.Name = "txt_Agencia";
            this.txt_Agencia.Size = new System.Drawing.Size(55, 21);
            this.txt_Agencia.TabIndex = 15;
            this.txt_Agencia.Tag = "";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(66, 135);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(51, 15);
            this.Label14.TabIndex = 686;
            this.Label14.Text = "Agência";
            // 
            // txt_Banco
            // 
            this.txt_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Banco.Location = new System.Drawing.Point(10, 154);
            this.txt_Banco.MaxLength = 3;
            this.txt_Banco.Name = "txt_Banco";
            this.txt_Banco.Size = new System.Drawing.Size(52, 21);
            this.txt_Banco.TabIndex = 12;
            this.txt_Banco.Tag = "";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(7, 135);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(42, 15);
            this.Label15.TabIndex = 685;
            this.Label15.Text = "Banco";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(10, 39);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(199, 23);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // txt_Documento
            // 
            this.txt_Documento.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Documento.Location = new System.Drawing.Point(10, 219);
            this.txt_Documento.MaxLength = 10;
            this.txt_Documento.Name = "txt_Documento";
            this.txt_Documento.Size = new System.Drawing.Size(138, 21);
            this.txt_Documento.TabIndex = 20;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(7, 198);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(87, 15);
            this.Label23.TabIndex = 684;
            this.Label23.Text = "Nº Documento";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Situacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(10, 95);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(199, 23);
            this.cb_Situacao.TabIndex = 10;
            this.cb_Situacao.Tag = "T";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 15);
            this.label17.TabIndex = 683;
            this.label17.Text = "Situação";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(7, 18);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(77, 15);
            this.Label20.TabIndex = 682;
            this.Label20.Text = "Tipo Pessoa";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(213, 18);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(63, 15);
            this.Label19.TabIndex = 681;
            this.Label19.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(217, 39);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(476, 23);
            this.cb_ID_Pessoa.TabIndex = 2;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoRelatorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Items.AddRange(new object[] {
            "EMISSÃO",
            "VENCIMENTO"});
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(10, 349);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(385, 23);
            this.cb_TipoRelatorio.TabIndex = 34;
            this.cb_TipoRelatorio.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 690;
            this.label1.Text = "Tipo Relatório";
            // 
            // gb_Consulta
            // 
            this.gb_Consulta.Controls.Add(this.label27);
            this.gb_Consulta.Controls.Add(this.Label20);
            this.gb_Consulta.Controls.Add(this.Label14);
            this.gb_Consulta.Controls.Add(this.label1);
            this.gb_Consulta.Controls.Add(this.txt_Banco);
            this.gb_Consulta.Controls.Add(this.Label22);
            this.gb_Consulta.Controls.Add(this.txt_Agencia);
            this.gb_Consulta.Controls.Add(this.Label15);
            this.gb_Consulta.Controls.Add(this.cb_TipoRelatorio);
            this.gb_Consulta.Controls.Add(this.Label13);
            this.gb_Consulta.Controls.Add(this.cb_Periodo);
            this.gb_Consulta.Controls.Add(this.cb_TipoPessoa);
            this.gb_Consulta.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Consulta.Controls.Add(this.txt_Conta);
            this.gb_Consulta.Controls.Add(this.Label25);
            this.gb_Consulta.Controls.Add(this.txt_Documento);
            this.gb_Consulta.Controls.Add(this.Label19);
            this.gb_Consulta.Controls.Add(this.Label11);
            this.gb_Consulta.Controls.Add(this.mk_DataFinal);
            this.gb_Consulta.Controls.Add(this.Label23);
            this.gb_Consulta.Controls.Add(this.label17);
            this.gb_Consulta.Controls.Add(this.txt_Cheque);
            this.gb_Consulta.Controls.Add(this.mk_DataInicial);
            this.gb_Consulta.Controls.Add(this.cb_Situacao);
            this.gb_Consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Consulta.Location = new System.Drawing.Point(2, 3);
            this.gb_Consulta.Name = "gb_Consulta";
            this.gb_Consulta.Size = new System.Drawing.Size(938, 620);
            this.gb_Consulta.TabIndex = 691;
            this.gb_Consulta.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(285, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 691;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Cheque_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Cheque_Relatorio";
            this.Load += new System.EventHandler(this.UI_Cheque_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Cheque_Relatorio_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Consulta.ResumeLayout(false);
            this.gb_Consulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.TextBox txt_Cheque;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txt_Conta;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txt_Agencia;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txt_Banco;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.TextBox txt_Documento;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        private System.Windows.Forms.GroupBox gb_Consulta;
        internal System.Windows.Forms.Label label27;
    }
}

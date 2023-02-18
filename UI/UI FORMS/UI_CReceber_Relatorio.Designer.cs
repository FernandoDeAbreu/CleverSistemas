namespace Sistema.UI
{
    partial class UI_CReceber_Relatorio
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
            this.label27 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.bt_PesquisaConta = new System.Windows.Forms.Button();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txt_Documento = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.mk_Conta = new System.Windows.Forms.MaskedTextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.txt_Multa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Juros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ck_JuroMulta = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.txt_Multa);
            this.TabPage1.Controls.Add(this.label8);
            this.TabPage1.Controls.Add(this.txt_Juros);
            this.TabPage1.Controls.Add(this.label4);
            this.TabPage1.Controls.Add(this.ck_JuroMulta);
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.cb_TipoRelatorio);
            this.TabPage1.Controls.Add(this.Label22);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.bt_PesquisaConta);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.txt_Documento);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.Label24);
            this.TabPage1.Controls.Add(this.cb_Situacao);
            this.TabPage1.Controls.Add(this.mk_Conta);
            this.TabPage1.Controls.Add(this.Label21);
            this.TabPage1.Controls.Add(this.Label20);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Text = "RELATÓRIO";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(287, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 727;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 726;
            this.label3.Text = "Tipo Relatório";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoRelatorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(13, 33);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(441, 23);
            this.cb_TipoRelatorio.TabIndex = 1;
            this.cb_TipoRelatorio.Tag = "T";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(9, 258);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(50, 15);
            this.Label22.TabIndex = 725;
            this.Label22.Text = "Período";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(13, 276);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(146, 23);
            this.cb_Periodo.TabIndex = 10;
            this.cb_Periodo.Tag = "T";
            // 
            // bt_PesquisaConta
            // 
            this.bt_PesquisaConta.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaConta.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaConta.Location = new System.Drawing.Point(101, 214);
            this.bt_PesquisaConta.Name = "bt_PesquisaConta";
            this.bt_PesquisaConta.Size = new System.Drawing.Size(31, 28);
            this.bt_PesquisaConta.TabIndex = 7;
            this.bt_PesquisaConta.UseVisualStyleBackColor = false;
            this.bt_PesquisaConta.Click += new System.EventHandler(this.bt_PesquisaConta_Click);
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(13, 102);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(199, 23);
            this.cb_TipoPessoa.TabIndex = 2;
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(290, 282);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 724;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(313, 279);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 12;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(182, 279);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 11;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // txt_Documento
            // 
            this.txt_Documento.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Documento.Location = new System.Drawing.Point(219, 159);
            this.txt_Documento.Name = "txt_Documento";
            this.txt_Documento.Size = new System.Drawing.Size(138, 21);
            this.txt_Documento.TabIndex = 5;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(216, 138);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(87, 15);
            this.Label23.TabIndex = 723;
            this.Label23.Text = "Nº Documento";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(9, 139);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(55, 15);
            this.Label24.TabIndex = 722;
            this.Label24.Text = "Situação";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Situacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(13, 159);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(199, 23);
            this.cb_Situacao.TabIndex = 4;
            this.cb_Situacao.Tag = "T";
            // 
            // mk_Conta
            // 
            this.mk_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Conta.Location = new System.Drawing.Point(13, 219);
            this.mk_Conta.Mask = "00,00,00,00";
            this.mk_Conta.Name = "mk_Conta";
            this.mk_Conta.PromptChar = '0';
            this.mk_Conta.Size = new System.Drawing.Size(81, 21);
            this.mk_Conta.TabIndex = 6;
            this.mk_Conta.Tag = "T";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(9, 198);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(70, 15);
            this.Label21.TabIndex = 721;
            this.Label21.Text = "Cód. Grupo";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(9, 81);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(77, 15);
            this.Label20.TabIndex = 719;
            this.Label20.Text = "Tipo Pessoa";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(216, 81);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(63, 15);
            this.Label19.TabIndex = 720;
            this.Label19.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(219, 102);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(476, 23);
            this.cb_ID_Pessoa.TabIndex = 3;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // txt_Multa
            // 
            this.txt_Multa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Multa.Enabled = false;
            this.txt_Multa.Location = new System.Drawing.Point(94, 376);
            this.txt_Multa.MaxLength = 5;
            this.txt_Multa.Name = "txt_Multa";
            this.txt_Multa.Size = new System.Drawing.Size(74, 21);
            this.txt_Multa.TabIndex = 21;
            this.txt_Multa.Tag = "T";
            this.txt_Multa.Text = "0,00";
            this.txt_Multa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Multa.Leave += new System.EventHandler(this.txt_Multa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 732;
            this.label8.Text = "Multa (%)";
            // 
            // txt_Juros
            // 
            this.txt_Juros.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Juros.Enabled = false;
            this.txt_Juros.Location = new System.Drawing.Point(13, 376);
            this.txt_Juros.MaxLength = 5;
            this.txt_Juros.Name = "txt_Juros";
            this.txt_Juros.Size = new System.Drawing.Size(74, 21);
            this.txt_Juros.TabIndex = 20;
            this.txt_Juros.Tag = "T";
            this.txt_Juros.Text = "0,00";
            this.txt_Juros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Juros.Leave += new System.EventHandler(this.txt_Juros_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 731;
            this.label4.Text = "Juros (%)";
            // 
            // ck_JuroMulta
            // 
            this.ck_JuroMulta.AutoSize = true;
            this.ck_JuroMulta.Location = new System.Drawing.Point(13, 327);
            this.ck_JuroMulta.Name = "ck_JuroMulta";
            this.ck_JuroMulta.Size = new System.Drawing.Size(135, 19);
            this.ck_JuroMulta.TabIndex = 15;
            this.ck_JuroMulta.Text = "Incluir Juros e Multa";
            this.ck_JuroMulta.UseVisualStyleBackColor = true;
            this.ck_JuroMulta.CheckedChanged += new System.EventHandler(this.ck_JuroMulta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(101, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 15);
            this.label1.TabIndex = 733;
            this.label1.Text = "* - Permite cálculo de juros";
            // 
            // UI_CReceber_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_CReceber_Relatorio";
            this.Load += new System.EventHandler(this.UI_CReceber_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_CReceber_Relatorio_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_CReceber_Relatorio_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Button bt_PesquisaConta;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.TextBox txt_Documento;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.MaskedTextBox mk_Conta;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.TextBox txt_Multa;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_Juros;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ck_JuroMulta;
        internal System.Windows.Forms.Label label1;
    }
}

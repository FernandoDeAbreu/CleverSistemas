namespace Sistema.UI
{
    partial class UI_Ordem_Servico_Relatorio
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
            this.gb_Periodo = new System.Windows.Forms.GroupBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.cb_StatusP = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.txt_ID_OS = new System.Windows.Forms.TextBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.gb_VendaInativo = new System.Windows.Forms.GroupBox();
            this.cb_SituacaoPessoa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DiasVenda = new System.Windows.Forms.TextBox();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ID_UsuarioComissao2 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cb_ID_UsuarioComissao1 = new System.Windows.Forms.ComboBox();
            this.lb_Comissao1 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Periodo.SuspendLayout();
            this.gb_VendaInativo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.cb_ID_UsuarioComissao2);
            this.TabPage1.Controls.Add(this.label24);
            this.TabPage1.Controls.Add(this.cb_ID_UsuarioComissao1);
            this.TabPage1.Controls.Add(this.lb_Comissao1);
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.gb_Periodo);
            this.TabPage1.Controls.Add(this.gb_VendaInativo);
            this.TabPage1.Controls.Add(this.cb_NFe);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cb_Situacao);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.cb_TipoRelatorio);
            this.TabPage1.Controls.Add(this.label4);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label1);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(275, 266);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 707;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // gb_Periodo
            // 
            this.gb_Periodo.Controls.Add(this.Label17);
            this.gb_Periodo.Controls.Add(this.cb_StatusP);
            this.gb_Periodo.Controls.Add(this.Label25);
            this.gb_Periodo.Controls.Add(this.mk_DataInicial);
            this.gb_Periodo.Controls.Add(this.mk_DataFinal);
            this.gb_Periodo.Controls.Add(this.txt_ID_OS);
            this.gb_Periodo.Controls.Add(this.Label52);
            this.gb_Periodo.Location = new System.Drawing.Point(10, 62);
            this.gb_Periodo.Name = "gb_Periodo";
            this.gb_Periodo.Size = new System.Drawing.Size(456, 124);
            this.gb_Periodo.TabIndex = 694;
            this.gb_Periodo.TabStop = false;
            this.gb_Periodo.Visible = false;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(8, 20);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(94, 15);
            this.Label17.TabIndex = 684;
            this.Label17.Text = "Status / Período";
            // 
            // cb_StatusP
            // 
            this.cb_StatusP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_StatusP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_StatusP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StatusP.FormattingEnabled = true;
            this.cb_StatusP.Location = new System.Drawing.Point(12, 40);
            this.cb_StatusP.Name = "cb_StatusP";
            this.cb_StatusP.Size = new System.Drawing.Size(172, 23);
            this.cb_StatusP.TabIndex = 683;
            this.cb_StatusP.Tag = "T";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(316, 44);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 681;
            this.Label25.Text = "à";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(208, 41);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 6;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(338, 41);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 7;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // txt_ID_OS
            // 
            this.txt_ID_OS.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_OS.Location = new System.Drawing.Point(12, 94);
            this.txt_ID_OS.MaxLength = 14;
            this.txt_ID_OS.Name = "txt_ID_OS";
            this.txt_ID_OS.Size = new System.Drawing.Size(102, 21);
            this.txt_ID_OS.TabIndex = 8;
            this.txt_ID_OS.Tag = "T";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Location = new System.Drawing.Point(8, 75);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(104, 15);
            this.Label52.TabIndex = 682;
            this.Label52.Text = "Nº Ordem Serviço";
            // 
            // gb_VendaInativo
            // 
            this.gb_VendaInativo.Controls.Add(this.cb_SituacaoPessoa);
            this.gb_VendaInativo.Controls.Add(this.label7);
            this.gb_VendaInativo.Controls.Add(this.label8);
            this.gb_VendaInativo.Controls.Add(this.txt_DiasVenda);
            this.gb_VendaInativo.Location = new System.Drawing.Point(10, 62);
            this.gb_VendaInativo.Name = "gb_VendaInativo";
            this.gb_VendaInativo.Size = new System.Drawing.Size(243, 124);
            this.gb_VendaInativo.TabIndex = 695;
            this.gb_VendaInativo.TabStop = false;
            this.gb_VendaInativo.Visible = false;
            // 
            // cb_SituacaoPessoa
            // 
            this.cb_SituacaoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SituacaoPessoa.FormattingEnabled = true;
            this.cb_SituacaoPessoa.Location = new System.Drawing.Point(10, 88);
            this.cb_SituacaoPessoa.Name = "cb_SituacaoPessoa";
            this.cb_SituacaoPessoa.Size = new System.Drawing.Size(215, 23);
            this.cb_SituacaoPessoa.TabIndex = 23;
            this.cb_SituacaoPessoa.Tag = "T";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 700;
            this.label7.Text = "Situação Pessoa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 15);
            this.label8.TabIndex = 698;
            this.label8.Text = "Inativo a mais de: (Dias)";
            // 
            // txt_DiasVenda
            // 
            this.txt_DiasVenda.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DiasVenda.Location = new System.Drawing.Point(10, 35);
            this.txt_DiasVenda.MaxLength = 14;
            this.txt_DiasVenda.Name = "txt_DiasVenda";
            this.txt_DiasVenda.Size = new System.Drawing.Size(72, 21);
            this.txt_DiasVenda.TabIndex = 21;
            this.txt_DiasVenda.Tag = "T";
            this.txt_DiasVenda.Text = "0";
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(208, 222);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(188, 23);
            this.cb_NFe.TabIndex = 697;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 705;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(12, 222);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 696;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 706;
            this.label6.Text = "Situação Financeira";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoRelatorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(12, 31);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(454, 23);
            this.cb_TipoRelatorio.TabIndex = 693;
            this.cb_TipoRelatorio.Tag = "T";
            this.cb_TipoRelatorio.SelectedValueChanged += new System.EventHandler(this.cb_TipoRelatorio_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 704;
            this.label4.Text = "Tipo de Relatório";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(208, 286);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(453, 23);
            this.cb_ID_Pessoa.TabIndex = 699;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(12, 286);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(188, 23);
            this.cb_TipoPessoa.TabIndex = 698;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 701;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 703;
            this.label1.Text = "Tipo Pessoa";
            // 
            // cb_ID_UsuarioComissao2
            // 
            this.cb_ID_UsuarioComissao2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_UsuarioComissao2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_UsuarioComissao2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_UsuarioComissao2.FormattingEnabled = true;
            this.cb_ID_UsuarioComissao2.Location = new System.Drawing.Point(12, 407);
            this.cb_ID_UsuarioComissao2.Name = "cb_ID_UsuarioComissao2";
            this.cb_ID_UsuarioComissao2.Size = new System.Drawing.Size(237, 23);
            this.cb_ID_UsuarioComissao2.TabIndex = 709;
            this.cb_ID_UsuarioComissao2.Tag = "T";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 389);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 15);
            this.label24.TabIndex = 710;
            this.label24.Text = "SERVIÇO";
            // 
            // cb_ID_UsuarioComissao1
            // 
            this.cb_ID_UsuarioComissao1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_UsuarioComissao1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_UsuarioComissao1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_UsuarioComissao1.FormattingEnabled = true;
            this.cb_ID_UsuarioComissao1.Location = new System.Drawing.Point(12, 349);
            this.cb_ID_UsuarioComissao1.Name = "cb_ID_UsuarioComissao1";
            this.cb_ID_UsuarioComissao1.Size = new System.Drawing.Size(237, 23);
            this.cb_ID_UsuarioComissao1.TabIndex = 708;
            this.cb_ID_UsuarioComissao1.Tag = "T";
            // 
            // lb_Comissao1
            // 
            this.lb_Comissao1.AutoSize = true;
            this.lb_Comissao1.Location = new System.Drawing.Point(8, 331);
            this.lb_Comissao1.Name = "lb_Comissao1";
            this.lb_Comissao1.Size = new System.Drawing.Size(83, 15);
            this.lb_Comissao1.TabIndex = 711;
            this.lb_Comissao1.Text = "ORÇAMENTO";
            // 
            // UI_Ordem_Servico_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Ordem_Servico_Relatorio";
            this.Load += new System.EventHandler(this.UI_Ordem_Servico_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Ordem_Servico_Relatorio_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Ordem_Servico_Relatorio_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Periodo.ResumeLayout(false);
            this.gb_Periodo.PerformLayout();
            this.gb_VendaInativo.ResumeLayout(false);
            this.gb_VendaInativo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox gb_Periodo;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.TextBox txt_ID_OS;
        internal System.Windows.Forms.Label Label52;
        private System.Windows.Forms.GroupBox gb_VendaInativo;
        internal System.Windows.Forms.ComboBox cb_SituacaoPessoa;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_DiasVenda;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cb_ID_UsuarioComissao2;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.ComboBox cb_ID_UsuarioComissao1;
        internal System.Windows.Forms.Label lb_Comissao1;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.ComboBox cb_StatusP;
    }
}

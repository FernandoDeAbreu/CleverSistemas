namespace Sistema.UI
{
    partial class UI_Venda_Relatorio
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
            this.cb_ID_UsuarioComissao1 = new System.Windows.Forms.ComboBox();
            this.lb_Comissao1 = new System.Windows.Forms.Label();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.txt_IDPedido = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_Periodo = new System.Windows.Forms.GroupBox();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_SituacaoPessoa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DiasVenda = new System.Windows.Forms.TextBox();
            this.gb_VendaInativo = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.mk_DataInicial = new System.Windows.Forms.DateTimePicker();
            this.mk_DataFinal = new System.Windows.Forms.DateTimePicker();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Periodo.SuspendLayout();
            this.gb_VendaInativo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
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
            this.TabPage1.Controls.Add(this.cb_ID_UsuarioComissao1);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.lb_Comissao1);
            this.TabPage1.Controls.Add(this.label1);
            // 
            // cb_ID_UsuarioComissao1
            // 
            this.cb_ID_UsuarioComissao1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_UsuarioComissao1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_UsuarioComissao1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_UsuarioComissao1.FormattingEnabled = true;
            this.cb_ID_UsuarioComissao1.Location = new System.Drawing.Point(13, 361);
            this.cb_ID_UsuarioComissao1.Name = "cb_ID_UsuarioComissao1";
            this.cb_ID_UsuarioComissao1.Size = new System.Drawing.Size(237, 23);
            this.cb_ID_UsuarioComissao1.TabIndex = 44;
            this.cb_ID_UsuarioComissao1.Tag = "T";
            // 
            // lb_Comissao1
            // 
            this.lb_Comissao1.AutoSize = true;
            this.lb_Comissao1.Location = new System.Drawing.Point(9, 342);
            this.lb_Comissao1.Name = "lb_Comissao1";
            this.lb_Comissao1.Size = new System.Drawing.Size(75, 15);
            this.lb_Comissao1.TabIndex = 683;
            this.lb_Comissao1.Text = "Comissão 1";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(13, 291);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(188, 23);
            this.cb_TipoPessoa.TabIndex = 42;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(209, 291);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(453, 23);
            this.cb_ID_Pessoa.TabIndex = 43;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Location = new System.Drawing.Point(8, 75);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(62, 15);
            this.Label52.TabIndex = 682;
            this.Label52.Text = "Nº Pedido";
            // 
            // txt_IDPedido
            // 
            this.txt_IDPedido.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDPedido.Location = new System.Drawing.Point(12, 94);
            this.txt_IDPedido.MaxLength = 14;
            this.txt_IDPedido.Name = "txt_IDPedido";
            this.txt_IDPedido.Size = new System.Drawing.Size(102, 21);
            this.txt_IDPedido.TabIndex = 8;
            this.txt_IDPedido.Tag = "T";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 683;
            this.label1.Text = "Tipo Pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 683;
            this.label2.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 685;
            this.label4.Text = "Tipo de Relatório";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoRelatorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(13, 36);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(454, 23);
            this.cb_TipoRelatorio.TabIndex = 1;
            this.cb_TipoRelatorio.Tag = "T";
            this.cb_TipoRelatorio.SelectedValueChanged += new System.EventHandler(this.cb_TipoRelatorio_SelectedValueChanged);
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(209, 227);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(188, 23);
            this.cb_NFe.TabIndex = 41;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 690;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(13, 227);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 40;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 691;
            this.label6.Text = "Situação Financeira";
            // 
            // gb_Periodo
            // 
            this.gb_Periodo.Controls.Add(this.mk_DataFinal);
            this.gb_Periodo.Controls.Add(this.mk_DataInicial);
            this.gb_Periodo.Controls.Add(this.cb_Periodo);
            this.gb_Periodo.Controls.Add(this.Label25);
            this.gb_Periodo.Controls.Add(this.label3);
            this.gb_Periodo.Controls.Add(this.txt_IDPedido);
            this.gb_Periodo.Controls.Add(this.Label52);
            this.gb_Periodo.Location = new System.Drawing.Point(12, 69);
            this.gb_Periodo.Name = "gb_Periodo";
            this.gb_Periodo.Size = new System.Drawing.Size(456, 124);
            this.gb_Periodo.TabIndex = 2;
            this.gb_Periodo.TabStop = false;
            this.gb_Periodo.Visible = false;
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Items.AddRange(new object[] {
            "EMISSÃO",
            "FATURAMENTO"});
            this.cb_Periodo.Location = new System.Drawing.Point(12, 41);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(188, 23);
            this.cb_Periodo.TabIndex = 4;
            this.cb_Periodo.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 687;
            this.label3.Text = "Período";
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
            // gb_VendaInativo
            // 
            this.gb_VendaInativo.Controls.Add(this.cb_SituacaoPessoa);
            this.gb_VendaInativo.Controls.Add(this.label7);
            this.gb_VendaInativo.Controls.Add(this.label8);
            this.gb_VendaInativo.Controls.Add(this.txt_DiasVenda);
            this.gb_VendaInativo.Location = new System.Drawing.Point(12, 69);
            this.gb_VendaInativo.Name = "gb_VendaInativo";
            this.gb_VendaInativo.Size = new System.Drawing.Size(243, 124);
            this.gb_VendaInativo.TabIndex = 20;
            this.gb_VendaInativo.TabStop = false;
            this.gb_VendaInativo.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(276, 271);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 692;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.Font = new System.Drawing.Font("Arial", 9F);
            this.mk_DataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mk_DataInicial.Location = new System.Drawing.Point(206, 41);
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 688;
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.Font = new System.Drawing.Font("Arial", 9F);
            this.mk_DataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mk_DataFinal.Location = new System.Drawing.Point(336, 41);
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 689;
            // 
            // UI_Venda_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Name = "UI_Venda_Relatorio";
            this.Load += new System.EventHandler(this.UI_Venda_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Venda_Relatorio_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_Relatorio_KeyPress);
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
        internal System.Windows.Forms.ComboBox cb_ID_UsuarioComissao1;
        internal System.Windows.Forms.Label lb_Comissao1;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.TextBox txt_IDPedido;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb_VendaInativo;
        internal System.Windows.Forms.ComboBox cb_SituacaoPessoa;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_DiasVenda;
        private System.Windows.Forms.GroupBox gb_Periodo;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker mk_DataFinal;
        private System.Windows.Forms.DateTimePicker mk_DataInicial;
    }
}

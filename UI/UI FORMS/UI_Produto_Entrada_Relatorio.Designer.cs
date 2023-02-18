namespace Sistema.UI
{
    partial class UI_Produto_Entrada_Relatorio
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
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_Periodo = new System.Windows.Forms.GroupBox();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Tipo_Entrada = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Periodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.gb_Periodo);
            this.TabPage1.Controls.Add(this.cb_Tipo_Entrada);
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
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(13, 292);
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
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(209, 292);
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
            this.Label52.Size = new System.Drawing.Size(66, 15);
            this.Label52.TabIndex = 682;
            this.Label52.Text = "Nº Entrada";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(12, 95);
            this.txt_ID.MaxLength = 14;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(102, 21);
            this.txt_ID.TabIndex = 8;
            this.txt_ID.Tag = "T";
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(208, 40);
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
            this.mk_DataFinal.Location = new System.Drawing.Point(338, 40);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 7;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
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
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(13, 37);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(454, 23);
            this.cb_TipoRelatorio.TabIndex = 1;
            this.cb_TipoRelatorio.Tag = "T";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(209, 227);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(258, 23);
            this.cb_Situacao.TabIndex = 41;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 691;
            this.label6.Text = "Situação Financeira";
            // 
            // gb_Periodo
            // 
            this.gb_Periodo.Controls.Add(this.cb_Periodo);
            this.gb_Periodo.Controls.Add(this.Label25);
            this.gb_Periodo.Controls.Add(this.label3);
            this.gb_Periodo.Controls.Add(this.mk_DataInicial);
            this.gb_Periodo.Controls.Add(this.mk_DataFinal);
            this.gb_Periodo.Controls.Add(this.txt_ID);
            this.gb_Periodo.Controls.Add(this.Label52);
            this.gb_Periodo.Location = new System.Drawing.Point(12, 68);
            this.gb_Periodo.Name = "gb_Periodo";
            this.gb_Periodo.Size = new System.Drawing.Size(456, 125);
            this.gb_Periodo.TabIndex = 2;
            this.gb_Periodo.TabStop = false;
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
            this.cb_Periodo.Location = new System.Drawing.Point(12, 40);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(188, 23);
            this.cb_Periodo.TabIndex = 4;
            this.cb_Periodo.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 687;
            this.label3.Text = "Período";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 691;
            this.label5.Text = "Tipo Entrada";
            // 
            // cb_Tipo_Entrada
            // 
            this.cb_Tipo_Entrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_Entrada.FormattingEnabled = true;
            this.cb_Tipo_Entrada.Location = new System.Drawing.Point(13, 227);
            this.cb_Tipo_Entrada.Name = "cb_Tipo_Entrada";
            this.cb_Tipo_Entrada.Size = new System.Drawing.Size(188, 23);
            this.cb_Tipo_Entrada.TabIndex = 40;
            this.cb_Tipo_Entrada.Tag = "T";
            // 
            // UI_Produto_Entrada_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 699);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Entrada_Relatorio";
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
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb_Periodo;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cb_Tipo_Entrada;
        internal System.Windows.Forms.Label label5;
    }
}

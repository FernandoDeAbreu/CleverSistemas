namespace Sistema.UI
{
    partial class UI_NFe_CFe_Relatorio
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
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.cb_TipoPessoaP = new System.Windows.Forms.ComboBox();
            this.Label53 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.cb_ID_PessoaP = new System.Windows.Forms.ComboBox();
            this.cb_SituacaoNFeP = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ID_NFeP = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_TipoRelatorio = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.txt_Serie);
            this.TabPage1.Controls.Add(this.label21);
            this.TabPage1.Controls.Add(this.label29);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.cb_TipoPessoaP);
            this.TabPage1.Controls.Add(this.Label53);
            this.TabPage1.Controls.Add(this.Label54);
            this.TabPage1.Controls.Add(this.cb_ID_PessoaP);
            this.TabPage1.Controls.Add(this.cb_TipoRelatorio);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.cb_SituacaoNFeP);
            this.TabPage1.Controls.Add(this.label20);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.txt_ID_NFeP);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Text = "RELATÓRIO";
            // 
            // txt_Serie
            // 
            this.txt_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Serie.Location = new System.Drawing.Point(209, 92);
            this.txt_Serie.MaxLength = 200;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(54, 21);
            this.txt_Serie.TabIndex = 4;
            this.txt_Serie.Tag = "T";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(519, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 15);
            this.label21.TabIndex = 202;
            this.label21.Text = "à";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(412, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 15);
            this.label29.TabIndex = 201;
            this.label29.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(538, 92);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 7;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(415, 92);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 6;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // cb_TipoPessoaP
            // 
            this.cb_TipoPessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoaP.FormattingEnabled = true;
            this.cb_TipoPessoaP.Location = new System.Drawing.Point(9, 36);
            this.cb_TipoPessoaP.Name = "cb_TipoPessoaP";
            this.cb_TipoPessoaP.Size = new System.Drawing.Size(192, 23);
            this.cb_TipoPessoaP.TabIndex = 1;
            this.cb_TipoPessoaP.Tag = "T";
            this.cb_TipoPessoaP.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoaP_SelectedValueChanged);
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.Location = new System.Drawing.Point(6, 17);
            this.Label53.Name = "Label53";
            this.Label53.Size = new System.Drawing.Size(77, 15);
            this.Label53.TabIndex = 199;
            this.Label53.Text = "Tipo Pessoa";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Location = new System.Drawing.Point(205, 17);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(63, 15);
            this.Label54.TabIndex = 200;
            this.Label54.Text = "Descrição";
            // 
            // cb_ID_PessoaP
            // 
            this.cb_ID_PessoaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_PessoaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_PessoaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_PessoaP.FormattingEnabled = true;
            this.cb_ID_PessoaP.Location = new System.Drawing.Point(209, 36);
            this.cb_ID_PessoaP.MaxDropDownItems = 15;
            this.cb_ID_PessoaP.Name = "cb_ID_PessoaP";
            this.cb_ID_PessoaP.Size = new System.Drawing.Size(430, 23);
            this.cb_ID_PessoaP.TabIndex = 2;
            this.cb_ID_PessoaP.Tag = "T";
            // 
            // cb_SituacaoNFeP
            // 
            this.cb_SituacaoNFeP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_SituacaoNFeP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_SituacaoNFeP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SituacaoNFeP.FormattingEnabled = true;
            this.cb_SituacaoNFeP.Location = new System.Drawing.Point(9, 92);
            this.cb_SituacaoNFeP.Name = "cb_SituacaoNFeP";
            this.cb_SituacaoNFeP.Size = new System.Drawing.Size(192, 23);
            this.cb_SituacaoNFeP.TabIndex = 3;
            this.cb_SituacaoNFeP.Tag = "T";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 198;
            this.label20.Text = "Situação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 196;
            this.label3.Text = "Serie";
            // 
            // txt_ID_NFeP
            // 
            this.txt_ID_NFeP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID_NFeP.Location = new System.Drawing.Point(271, 92);
            this.txt_ID_NFeP.MaxLength = 9;
            this.txt_ID_NFeP.Name = "txt_ID_NFeP";
            this.txt_ID_NFeP.Size = new System.Drawing.Size(137, 21);
            this.txt_ID_NFeP.TabIndex = 5;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(267, 73);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(50, 15);
            this.Label19.TabIndex = 197;
            this.Label19.Text = "Nº CF-e";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 198;
            this.label1.Text = "Tipo Relatório";
            // 
            // cb_TipoRelatorio
            // 
            this.cb_TipoRelatorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoRelatorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoRelatorio.FormattingEnabled = true;
            this.cb_TipoRelatorio.Location = new System.Drawing.Point(9, 156);
            this.cb_TipoRelatorio.Name = "cb_TipoRelatorio";
            this.cb_TipoRelatorio.Size = new System.Drawing.Size(629, 23);
            this.cb_TipoRelatorio.TabIndex = 10;
            this.cb_TipoRelatorio.Tag = "T";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(276, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 203;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_NFe_CFe_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_NFe_CFe_Relatorio";
            this.Load += new System.EventHandler(this.UI_NFe_CFe_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_NFe_CFe_Relatorio_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Serie;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.ComboBox cb_TipoPessoaP;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.ComboBox cb_ID_PessoaP;
        internal System.Windows.Forms.ComboBox cb_SituacaoNFeP;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_ID_NFeP;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_TipoRelatorio;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label27;
    }
}

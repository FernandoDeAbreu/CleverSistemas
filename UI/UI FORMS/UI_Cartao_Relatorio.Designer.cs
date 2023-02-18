namespace Sistema.UI
{
    partial class UI_Cartao_Relatorio
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
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_Cartao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Pesquisa = new System.Windows.Forms.GroupBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Pesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Pesquisa);
            this.TabPage1.Text = "RELATÓRIO";
            // 
            // bt_Anterior
            // 
            this.bt_Anterior.Location = new System.Drawing.Point(5, 663);
            // 
            // bt_Proximo
            // 
            this.bt_Proximo.Location = new System.Drawing.Point(48, 663);
            // 
            // bt_Fecha
            // 
            this.bt_Fecha.Location = new System.Drawing.Point(849, 662);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Location = new System.Drawing.Point(93, 662);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Location = new System.Drawing.Point(192, 662);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Location = new System.Drawing.Point(291, 662);
            // 
            // bt_Imprime
            // 
            this.bt_Imprime.Location = new System.Drawing.Point(489, 662);
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.Location = new System.Drawing.Point(687, 662);
            // 
            // bt_Exclui
            // 
            this.bt_Exclui.Location = new System.Drawing.Point(390, 662);
            // 
            // bt_Visualiza
            // 
            this.bt_Visualiza.Location = new System.Drawing.Point(588, 662);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(7, 130);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(50, 15);
            this.Label22.TabIndex = 447;
            this.Label22.Text = "Período";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(10, 150);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(146, 23);
            this.cb_Periodo.TabIndex = 3;
            this.cb_Periodo.Tag = "T";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(295, 150);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 5;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(164, 150);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 4;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(7, 18);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(44, 15);
            this.Label19.TabIndex = 446;
            this.Label19.Text = "Cartão";
            // 
            // cb_ID_Cartao
            // 
            this.cb_ID_Cartao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Cartao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Cartao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Cartao.FormattingEnabled = true;
            this.cb_ID_Cartao.Location = new System.Drawing.Point(10, 38);
            this.cb_ID_Cartao.Name = "cb_ID_Cartao";
            this.cb_ID_Cartao.Size = new System.Drawing.Size(255, 23);
            this.cb_ID_Cartao.TabIndex = 1;
            this.cb_ID_Cartao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 447;
            this.label1.Text = "à";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Situacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(10, 93);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(255, 23);
            this.cb_Situacao.TabIndex = 2;
            this.cb_Situacao.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 446;
            this.label2.Text = "Situação";
            // 
            // gb_Pesquisa
            // 
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Cartao);
            this.gb_Pesquisa.Controls.Add(this.label1);
            this.gb_Pesquisa.Controls.Add(this.cb_Situacao);
            this.gb_Pesquisa.Controls.Add(this.Label22);
            this.gb_Pesquisa.Controls.Add(this.Label19);
            this.gb_Pesquisa.Controls.Add(this.cb_Periodo);
            this.gb_Pesquisa.Controls.Add(this.label2);
            this.gb_Pesquisa.Controls.Add(this.mk_DataFinal);
            this.gb_Pesquisa.Controls.Add(this.mk_DataInicial);
            this.gb_Pesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Pesquisa.Location = new System.Drawing.Point(2, 3);
            this.gb_Pesquisa.Name = "gb_Pesquisa";
            this.gb_Pesquisa.Size = new System.Drawing.Size(938, 620);
            this.gb_Pesquisa.TabIndex = 448;
            this.gb_Pesquisa.TabStop = false;
            // 
            // UI_Cartao_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Cartao_Relatorio";
            this.Load += new System.EventHandler(this.UI_Cartao_Relatorio_Load);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Pesquisa.ResumeLayout(false);
            this.gb_Pesquisa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_Cartao;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        private System.Windows.Forms.GroupBox gb_Pesquisa;
    }
}

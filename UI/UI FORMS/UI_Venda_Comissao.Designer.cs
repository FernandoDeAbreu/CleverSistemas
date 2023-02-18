namespace Sistema.UI
{
    partial class UI_Venda_Comissao
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
            this.ck_Detalhe = new System.Windows.Forms.CheckBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.cb_ID_UsuarioComissao1 = new System.Windows.Forms.ComboBox();
            this.lb_Comissao1 = new System.Windows.Forms.Label();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.cb_NFe);
            this.TabPage1.Controls.Add(this.lb_Comissao1);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cb_Situacao);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.cb_ID_UsuarioComissao1);
            this.TabPage1.Controls.Add(this.ck_Detalhe);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.Label17);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
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
            // ck_Detalhe
            // 
            this.ck_Detalhe.AutoSize = true;
            this.ck_Detalhe.Location = new System.Drawing.Point(14, 242);
            this.ck_Detalhe.Name = "ck_Detalhe";
            this.ck_Detalhe.Size = new System.Drawing.Size(134, 19);
            this.ck_Detalhe.TabIndex = 677;
            this.ck_Detalhe.Text = "Relatório detalhado";
            this.ck_Detalhe.UseVisualStyleBackColor = true;
            this.ck_Detalhe.Visible = false;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(380, 187);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 682;
            this.Label25.Text = "à";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(10, 164);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(50, 15);
            this.Label17.TabIndex = 681;
            this.Label17.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(402, 183);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 676;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(272, 183);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 675;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(14, 183);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(237, 23);
            this.cb_Periodo.TabIndex = 674;
            this.cb_Periodo.Tag = "T";
            // 
            // cb_ID_UsuarioComissao1
            // 
            this.cb_ID_UsuarioComissao1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_UsuarioComissao1.FormattingEnabled = true;
            this.cb_ID_UsuarioComissao1.Location = new System.Drawing.Point(14, 42);
            this.cb_ID_UsuarioComissao1.Name = "cb_ID_UsuarioComissao1";
            this.cb_ID_UsuarioComissao1.Size = new System.Drawing.Size(237, 23);
            this.cb_ID_UsuarioComissao1.TabIndex = 671;
            this.cb_ID_UsuarioComissao1.Tag = "T";
            // 
            // lb_Comissao1
            // 
            this.lb_Comissao1.AutoSize = true;
            this.lb_Comissao1.Location = new System.Drawing.Point(10, 22);
            this.lb_Comissao1.Name = "lb_Comissao1";
            this.lb_Comissao1.Size = new System.Drawing.Size(75, 15);
            this.lb_Comissao1.TabIndex = 678;
            this.lb_Comissao1.Text = "Comissão 1";
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(210, 113);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(188, 23);
            this.cb_NFe.TabIndex = 696;
            this.cb_NFe.TabStop = false;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 698;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(14, 113);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 697;
            this.cb_Situacao.TabStop = false;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 699;
            this.label6.Text = "Situação Financeira";
            // 
            // UI_Venda_Comissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Venda_Comissao";
            this.Load += new System.EventHandler(this.UI_Venda_Comissao_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ck_Detalhe;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.ComboBox cb_ID_UsuarioComissao1;
        internal System.Windows.Forms.Label lb_Comissao1;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;

    }
}

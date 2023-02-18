namespace Sistema.UI
{
    partial class UI_Duplicata
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
            this.txt_Documento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CNPJ_CPF = new System.Windows.Forms.TextBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.mk_Emissao = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mk_Vencimento = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Duplicata = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Observacao = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label27);
            this.TabPage1.Controls.Add(this.mk_Vencimento);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.mk_Emissao);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.txt_Duplicata);
            this.TabPage1.Controls.Add(this.label7);
            this.TabPage1.Controls.Add(this.txt_Observacao);
            this.TabPage1.Controls.Add(this.label8);
            this.TabPage1.Controls.Add(this.txt_Documento);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.cb_ID_Pessoa);
            this.TabPage1.Controls.Add(this.txt_Valor);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.txt_CNPJ_CPF);
            this.TabPage1.Controls.Add(this.cb_TipoPessoa);
            this.TabPage1.Controls.Add(this.Label9);
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
            // txt_Documento
            // 
            this.txt_Documento.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Documento.Location = new System.Drawing.Point(13, 247);
            this.txt_Documento.Name = "txt_Documento";
            this.txt_Documento.Size = new System.Drawing.Size(303, 21);
            this.txt_Documento.TabIndex = 22;
            this.txt_Documento.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 687;
            this.label2.Text = "Documento";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(192, 80);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(521, 23);
            this.cb_ID_Pessoa.TabIndex = 11;
            this.cb_ID_Pessoa.Leave += new System.EventHandler(this.cb_ID_Pessoa_Leave);
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Valor.Location = new System.Drawing.Point(13, 192);
            this.txt_Valor.MaxLength = 15;
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(118, 21);
            this.txt_Valor.TabIndex = 20;
            this.txt_Valor.Tag = "";
            this.txt_Valor.Text = "0,00";
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 60);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(77, 15);
            this.Label4.TabIndex = 686;
            this.Label4.Text = "Tipo Pessoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 688;
            this.label1.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 685;
            this.label3.Text = "Descrição";
            // 
            // txt_CNPJ_CPF
            // 
            this.txt_CNPJ_CPF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CNPJ_CPF.Location = new System.Drawing.Point(13, 136);
            this.txt_CNPJ_CPF.Name = "txt_CNPJ_CPF";
            this.txt_CNPJ_CPF.Size = new System.Drawing.Size(172, 21);
            this.txt_CNPJ_CPF.TabIndex = 12;
            this.txt_CNPJ_CPF.Tag = "";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(13, 80);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(172, 23);
            this.cb_TipoPessoa.TabIndex = 10;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(9, 115);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(66, 15);
            this.Label9.TabIndex = 689;
            this.Label9.Text = "CNPJ/CPF";
            // 
            // mk_Emissao
            // 
            this.mk_Emissao.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Emissao.Location = new System.Drawing.Point(192, 33);
            this.mk_Emissao.Mask = "00/00/0000";
            this.mk_Emissao.Name = "mk_Emissao";
            this.mk_Emissao.Size = new System.Drawing.Size(101, 21);
            this.mk_Emissao.TabIndex = 2;
            this.mk_Emissao.Tag = "T";
            this.mk_Emissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Emissao.ValidatingType = typeof(System.DateTime);
            this.mk_Emissao.Leave += new System.EventHandler(this.mk_Emissao_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 691;
            this.label5.Text = "Emissão";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 691;
            this.label6.Text = "Vencimento";
            // 
            // mk_Vencimento
            // 
            this.mk_Vencimento.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Vencimento.Location = new System.Drawing.Point(141, 192);
            this.mk_Vencimento.Mask = "00/00/0000";
            this.mk_Vencimento.Name = "mk_Vencimento";
            this.mk_Vencimento.Size = new System.Drawing.Size(101, 21);
            this.mk_Vencimento.TabIndex = 21;
            this.mk_Vencimento.Tag = "T";
            this.mk_Vencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Vencimento.ValidatingType = typeof(System.DateTime);
            this.mk_Vencimento.Leave += new System.EventHandler(this.mk_Vencimento_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 687;
            this.label7.Text = "Nº Duplicata";
            // 
            // txt_Duplicata
            // 
            this.txt_Duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Duplicata.Location = new System.Drawing.Point(13, 33);
            this.txt_Duplicata.Name = "txt_Duplicata";
            this.txt_Duplicata.Size = new System.Drawing.Size(172, 21);
            this.txt_Duplicata.TabIndex = 1;
            this.txt_Duplicata.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 687;
            this.label8.Text = "Observação";
            // 
            // txt_Observacao
            // 
            this.txt_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Observacao.Location = new System.Drawing.Point(13, 302);
            this.txt_Observacao.Name = "txt_Observacao";
            this.txt_Observacao.Size = new System.Drawing.Size(303, 21);
            this.txt_Observacao.TabIndex = 23;
            this.txt_Observacao.Tag = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(260, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 692;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Duplicata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Duplicata";
            this.Load += new System.EventHandler(this.UI_Duplicata_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Duplicata_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Documento;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_CNPJ_CPF;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.MaskedTextBox mk_Vencimento;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.MaskedTextBox mk_Emissao;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_Duplicata;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_Observacao;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label27;
    }
}

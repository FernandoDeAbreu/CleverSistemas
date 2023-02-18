namespace Sistema.UI
{
    partial class UI_Email
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
            this.gb_Destinatario = new System.Windows.Forms.GroupBox();
            this.bt_PesquisaCCO = new System.Windows.Forms.Button();
            this.bt_PesquisaCC = new System.Windows.Forms.Button();
            this.bt_PesquisaPara = new System.Windows.Forms.Button();
            this.txt_CCO = new System.Windows.Forms.TextBox();
            this.txt_CC = new System.Windows.Forms.TextBox();
            this.txt_Para = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.gb_Conteudo = new System.Windows.Forms.GroupBox();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtc_Conteudo = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Assunto = new System.Windows.Forms.TextBox();
            this.txt_Conteudo = new System.Windows.Forms.TextBox();
            this.gb_Anexo = new System.Windows.Forms.GroupBox();
            this.bt_BuscaAnexo = new System.Windows.Forms.Button();
            this.txt_Anexo = new System.Windows.Forms.TextBox();
            this.bt_Enviar = new System.Windows.Forms.Button();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_AssuntoP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ProcuraAnexo = new System.Windows.Forms.OpenFileDialog();
            this.CorTexto = new System.Windows.Forms.ColorDialog();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Destinatario.SuspendLayout();
            this.gb_Conteudo.SuspendLayout();
            this.gb_Anexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_Enviar);
            this.TabPage1.Controls.Add(this.gb_Anexo);
            this.TabPage1.Controls.Add(this.gb_Conteudo);
            this.TabPage1.Controls.Add(this.gb_Destinatario);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_AssuntoP);
            this.TabPage2.Controls.Add(this.label7);
            this.TabPage2.Controls.Add(this.Label25);
            this.TabPage2.Controls.Add(this.mk_DataFinal);
            this.TabPage2.Controls.Add(this.mk_DataInicial);
            this.TabPage2.Controls.Add(this.label6);
            this.TabPage2.Controls.SetChildIndex(this.label6, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_DataInicial, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_DataFinal, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label25, 0);
            this.TabPage2.Controls.SetChildIndex(this.label7, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_AssuntoP, 0);
            // 
            // gb_Destinatario
            // 
            this.gb_Destinatario.Controls.Add(this.bt_PesquisaCCO);
            this.gb_Destinatario.Controls.Add(this.bt_PesquisaCC);
            this.gb_Destinatario.Controls.Add(this.bt_PesquisaPara);
            this.gb_Destinatario.Controls.Add(this.txt_CCO);
            this.gb_Destinatario.Controls.Add(this.txt_CC);
            this.gb_Destinatario.Controls.Add(this.txt_Para);
            this.gb_Destinatario.Controls.Add(this.txt_ID);
            this.gb_Destinatario.Location = new System.Drawing.Point(13, 11);
            this.gb_Destinatario.Name = "gb_Destinatario";
            this.gb_Destinatario.Size = new System.Drawing.Size(788, 116);
            this.gb_Destinatario.TabIndex = 0;
            this.gb_Destinatario.TabStop = false;
            this.gb_Destinatario.Text = "Destinatário";
            // 
            // bt_PesquisaCCO
            // 
            this.bt_PesquisaCCO.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaCCO.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaCCO.Location = new System.Drawing.Point(16, 85);
            this.bt_PesquisaCCO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaCCO.Name = "bt_PesquisaCCO";
            this.bt_PesquisaCCO.Size = new System.Drawing.Size(63, 26);
            this.bt_PesquisaCCO.TabIndex = 3;
            this.bt_PesquisaCCO.TabStop = false;
            this.bt_PesquisaCCO.Text = "CCO:";
            this.bt_PesquisaCCO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaCCO.UseVisualStyleBackColor = false;
            this.bt_PesquisaCCO.Click += new System.EventHandler(this.bt_PesquisaCCO_Click);
            // 
            // bt_PesquisaCC
            // 
            this.bt_PesquisaCC.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaCC.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaCC.Location = new System.Drawing.Point(16, 55);
            this.bt_PesquisaCC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaCC.Name = "bt_PesquisaCC";
            this.bt_PesquisaCC.Size = new System.Drawing.Size(63, 26);
            this.bt_PesquisaCC.TabIndex = 2;
            this.bt_PesquisaCC.TabStop = false;
            this.bt_PesquisaCC.Text = "CC:";
            this.bt_PesquisaCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaCC.UseVisualStyleBackColor = false;
            this.bt_PesquisaCC.Click += new System.EventHandler(this.bt_PesquisaCC_Click);
            // 
            // bt_PesquisaPara
            // 
            this.bt_PesquisaPara.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaPara.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaPara.Location = new System.Drawing.Point(16, 25);
            this.bt_PesquisaPara.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaPara.Name = "bt_PesquisaPara";
            this.bt_PesquisaPara.Size = new System.Drawing.Size(63, 26);
            this.bt_PesquisaPara.TabIndex = 1;
            this.bt_PesquisaPara.TabStop = false;
            this.bt_PesquisaPara.Text = "PARA:";
            this.bt_PesquisaPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaPara.UseVisualStyleBackColor = false;
            this.bt_PesquisaPara.Click += new System.EventHandler(this.bt_PesquisaPara_Click);
            // 
            // txt_CCO
            // 
            this.txt_CCO.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_CCO.Location = new System.Drawing.Point(85, 87);
            this.txt_CCO.MaxLength = 200;
            this.txt_CCO.Name = "txt_CCO";
            this.txt_CCO.Size = new System.Drawing.Size(695, 21);
            this.txt_CCO.TabIndex = 7;
            this.txt_CCO.Tag = "T";
            // 
            // txt_CC
            // 
            this.txt_CC.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CC.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_CC.Location = new System.Drawing.Point(85, 57);
            this.txt_CC.MaxLength = 200;
            this.txt_CC.Name = "txt_CC";
            this.txt_CC.Size = new System.Drawing.Size(695, 21);
            this.txt_CC.TabIndex = 6;
            this.txt_CC.Tag = "T";
            // 
            // txt_Para
            // 
            this.txt_Para.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Para.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_Para.Location = new System.Drawing.Point(85, 27);
            this.txt_Para.MaxLength = 200;
            this.txt_Para.Name = "txt_Para";
            this.txt_Para.Size = new System.Drawing.Size(694, 21);
            this.txt_Para.TabIndex = 5;
            this.txt_Para.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(596, 27);
            this.txt_ID.MaxLength = 200;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(44, 21);
            this.txt_ID.TabIndex = 7;
            this.txt_ID.TabStop = false;
            this.txt_ID.Tag = "T";
            // 
            // gb_Conteudo
            // 
            this.gb_Conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Conteudo.Controls.Add(this.mk_Data);
            this.gb_Conteudo.Controls.Add(this.label8);
            this.gb_Conteudo.Controls.Add(this.rtc_Conteudo);
            this.gb_Conteudo.Controls.Add(this.label5);
            this.gb_Conteudo.Controls.Add(this.label4);
            this.gb_Conteudo.Controls.Add(this.txt_Assunto);
            this.gb_Conteudo.Controls.Add(this.txt_Conteudo);
            this.gb_Conteudo.Location = new System.Drawing.Point(13, 133);
            this.gb_Conteudo.Name = "gb_Conteudo";
            this.gb_Conteudo.Size = new System.Drawing.Size(922, 399);
            this.gb_Conteudo.TabIndex = 10;
            this.gb_Conteudo.TabStop = false;
            this.gb_Conteudo.Text = "Mensagem";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mk_Data.Location = new System.Drawing.Point(15, 34);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.ReadOnly = true;
            this.mk_Data.Size = new System.Drawing.Size(101, 21);
            this.mk_Data.TabIndex = 11;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 676;
            this.label8.Text = "Data";
            // 
            // rtc_Conteudo
            // 
            this.rtc_Conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtc_Conteudo.AutoWordSelection = true;
            this.rtc_Conteudo.BackColor = System.Drawing.SystemColors.Window;
            this.rtc_Conteudo.Location = new System.Drawing.Point(15, 135);
            this.rtc_Conteudo.Name = "rtc_Conteudo";
            this.rtc_Conteudo.Size = new System.Drawing.Size(899, 255);
            this.rtc_Conteudo.TabIndex = 15;
            this.rtc_Conteudo.Tag = "";
            this.rtc_Conteudo.Text = "";
            this.rtc_Conteudo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtc_Conteudo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mensagem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Assunto";
            // 
            // txt_Assunto
            // 
            this.txt_Assunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Assunto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Assunto.Location = new System.Drawing.Point(15, 85);
            this.txt_Assunto.MaxLength = 200;
            this.txt_Assunto.Name = "txt_Assunto";
            this.txt_Assunto.Size = new System.Drawing.Size(854, 21);
            this.txt_Assunto.TabIndex = 12;
            this.txt_Assunto.Tag = "T";
            // 
            // txt_Conteudo
            // 
            this.txt_Conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Conteudo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Conteudo.Enabled = false;
            this.txt_Conteudo.Location = new System.Drawing.Point(829, 85);
            this.txt_Conteudo.MaxLength = 200;
            this.txt_Conteudo.Name = "txt_Conteudo";
            this.txt_Conteudo.Size = new System.Drawing.Size(39, 21);
            this.txt_Conteudo.TabIndex = 7;
            this.txt_Conteudo.TabStop = false;
            this.txt_Conteudo.Tag = "T";
            this.txt_Conteudo.TextChanged += new System.EventHandler(this.txt_Conteudo_TextChanged);
            // 
            // gb_Anexo
            // 
            this.gb_Anexo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Anexo.Controls.Add(this.bt_BuscaAnexo);
            this.gb_Anexo.Controls.Add(this.txt_Anexo);
            this.gb_Anexo.Location = new System.Drawing.Point(13, 538);
            this.gb_Anexo.Name = "gb_Anexo";
            this.gb_Anexo.Size = new System.Drawing.Size(921, 75);
            this.gb_Anexo.TabIndex = 20;
            this.gb_Anexo.TabStop = false;
            this.gb_Anexo.Text = "Anexo(s)";
            // 
            // bt_BuscaAnexo
            // 
            this.bt_BuscaAnexo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_BuscaAnexo.BackColor = System.Drawing.SystemColors.Control;
            this.bt_BuscaAnexo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_BuscaAnexo.Image = global::Sistema.UI.Properties.Resources.bt_Anexo;
            this.bt_BuscaAnexo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_BuscaAnexo.Location = new System.Drawing.Point(843, 21);
            this.bt_BuscaAnexo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_BuscaAnexo.Name = "bt_BuscaAnexo";
            this.bt_BuscaAnexo.Size = new System.Drawing.Size(72, 46);
            this.bt_BuscaAnexo.TabIndex = 98;
            this.bt_BuscaAnexo.TabStop = false;
            this.bt_BuscaAnexo.Text = "ANEXO";
            this.bt_BuscaAnexo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_BuscaAnexo.UseVisualStyleBackColor = false;
            this.bt_BuscaAnexo.Click += new System.EventHandler(this.bt_BuscaAnexo_Click);
            // 
            // txt_Anexo
            // 
            this.txt_Anexo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Anexo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Anexo.Location = new System.Drawing.Point(15, 21);
            this.txt_Anexo.MaxLength = 200;
            this.txt_Anexo.Multiline = true;
            this.txt_Anexo.Name = "txt_Anexo";
            this.txt_Anexo.ReadOnly = true;
            this.txt_Anexo.Size = new System.Drawing.Size(821, 46);
            this.txt_Anexo.TabIndex = 21;
            this.txt_Anexo.Tag = "T";
            // 
            // bt_Enviar
            // 
            this.bt_Enviar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Enviar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Enviar.Image = global::Sistema.UI.Properties.Resources.bt_Transmitir;
            this.bt_Enviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Enviar.Location = new System.Drawing.Point(807, 18);
            this.bt_Enviar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Enviar.Name = "bt_Enviar";
            this.bt_Enviar.Size = new System.Drawing.Size(128, 109);
            this.bt_Enviar.TabIndex = 50;
            this.bt_Enviar.Text = "ENVIAR";
            this.bt_Enviar.UseVisualStyleBackColor = false;
            this.bt_Enviar.Click += new System.EventHandler(this.bt_Enviar_Click);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(118, 36);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 679;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(140, 33);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 677;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(9, 33);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 676;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 678;
            this.label6.Text = "Período";
            // 
            // txt_AssuntoP
            // 
            this.txt_AssuntoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_AssuntoP.Location = new System.Drawing.Point(9, 85);
            this.txt_AssuntoP.MaxLength = 200;
            this.txt_AssuntoP.Name = "txt_AssuntoP";
            this.txt_AssuntoP.Size = new System.Drawing.Size(508, 21);
            this.txt_AssuntoP.TabIndex = 680;
            this.txt_AssuntoP.TabStop = false;
            this.txt_AssuntoP.Tag = "T";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 681;
            this.label7.Text = "Assunto";
            // 
            // ProcuraAnexo
            // 
            this.ProcuraAnexo.FileName = "ProcuraAnexo";
            this.ProcuraAnexo.Multiselect = true;
            // 
            // UI_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Email";
            this.Load += new System.EventHandler(this.UI_Email_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Email_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Destinatario.ResumeLayout(false);
            this.gb_Destinatario.PerformLayout();
            this.gb_Conteudo.ResumeLayout(false);
            this.gb_Conteudo.PerformLayout();
            this.gb_Anexo.ResumeLayout(false);
            this.gb_Anexo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Destinatario;
        internal System.Windows.Forms.TextBox txt_CCO;
        internal System.Windows.Forms.TextBox txt_CC;
        internal System.Windows.Forms.TextBox txt_Para;
        internal System.Windows.Forms.Button bt_PesquisaCCO;
        internal System.Windows.Forms.Button bt_PesquisaCC;
        internal System.Windows.Forms.Button bt_PesquisaPara;
        private System.Windows.Forms.GroupBox gb_Conteudo;
        internal System.Windows.Forms.TextBox txt_Assunto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_Anexo;
        private System.Windows.Forms.RichTextBox rtc_Conteudo;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button bt_BuscaAnexo;
        internal System.Windows.Forms.TextBox txt_Anexo;
        private System.Windows.Forms.Button bt_Enviar;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_AssuntoP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog ProcuraAnexo;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_Conteudo;
        private System.Windows.Forms.ColorDialog CorTexto;
    }
}

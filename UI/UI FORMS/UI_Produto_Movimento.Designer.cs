namespace Sistema.UI
{
    partial class UI_Produto_Movimento
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
            this.txt_ReferenciaP = new System.Windows.Forms.TextBox();
            this.Label44 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txt_Barra = new System.Windows.Forms.TextBox();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label51 = new System.Windows.Forms.Label();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_ReferenciaP);
            this.TabPage2.Controls.Add(this.Label44);
            this.TabPage2.Controls.Add(this.Label25);
            this.TabPage2.Controls.Add(this.Label17);
            this.TabPage2.Controls.Add(this.mk_DataFinal);
            this.TabPage2.Controls.Add(this.mk_DataInicial);
            this.TabPage2.Controls.Add(this.txt_Barra);
            this.TabPage2.Controls.Add(this.txt_Descricao);
            this.TabPage2.Controls.Add(this.txt_ID);
            this.TabPage2.Controls.Add(this.Label51);
            this.TabPage2.Controls.Add(this.Label45);
            this.TabPage2.Controls.Add(this.Label38);
            this.TabPage2.Controls.SetChildIndex(this.textBox1, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label38, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label45, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label51, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ID, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_Descricao, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_Barra, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_DataInicial, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_DataFinal, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label17, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label25, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label44, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_ReferenciaP, 0);
            // 
            // txt_ReferenciaP
            // 
            this.txt_ReferenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReferenciaP.Location = new System.Drawing.Point(9, 85);
            this.txt_ReferenciaP.MaxLength = 60;
            this.txt_ReferenciaP.Name = "txt_ReferenciaP";
            this.txt_ReferenciaP.Size = new System.Drawing.Size(192, 21);
            this.txt_ReferenciaP.TabIndex = 15;
            this.txt_ReferenciaP.Tag = "T";
            // 
            // Label44
            // 
            this.Label44.AutoSize = true;
            this.Label44.Location = new System.Drawing.Point(6, 64);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(67, 15);
            this.Label44.TabIndex = 753;
            this.Label44.Text = "Referência";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(330, 88);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 749;
            this.Label25.Text = "à";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(218, 64);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(50, 15);
            this.Label17.TabIndex = 748;
            this.Label17.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(352, 85);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 21;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(222, 85);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 20;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // txt_Barra
            // 
            this.txt_Barra.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Barra.Location = new System.Drawing.Point(121, 35);
            this.txt_Barra.MaxLength = 14;
            this.txt_Barra.Name = "txt_Barra";
            this.txt_Barra.Size = new System.Drawing.Size(158, 21);
            this.txt_Barra.TabIndex = 2;
            this.txt_Barra.Tag = "T";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(289, 35);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(457, 21);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(9, 35);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(101, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // Label51
            // 
            this.Label51.AutoSize = true;
            this.Label51.Location = new System.Drawing.Point(286, 16);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(63, 15);
            this.Label51.TabIndex = 745;
            this.Label51.Text = "Descrição";
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(6, 16);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(47, 15);
            this.Label45.TabIndex = 744;
            this.Label45.Text = "Código";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(118, 16);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(90, 15);
            this.Label38.TabIndex = 743;
            this.Label38.Text = "Cód. de Barras";
            // 
            // UI_Produto_Movimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_Movimento";
            this.Load += new System.EventHandler(this.UI_Produto_Movimento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_Movimento_KeyDown);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_ReferenciaP;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.TextBox txt_Barra;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Label Label38;

    }
}

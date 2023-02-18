namespace Sistema.UI
{
    partial class UI_CFOP
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
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.txt_Ajuda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CFOP = new System.Windows.Forms.TextBox();
            this.lb_CFOP = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CFOPP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_CFOPP);
            this.TabPage2.Controls.Add(this.label5);
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.label4);
            this.TabPage2.Controls.SetChildIndex(this.label4, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label5, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_CFOPP, 0);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.txt_Ajuda);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.txt_CFOP);
            this.gb_Cadastro.Controls.Add(this.lb_CFOP);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // txt_Ajuda
            // 
            this.txt_Ajuda.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Ajuda.Location = new System.Drawing.Point(19, 222);
            this.txt_Ajuda.MaxLength = 400;
            this.txt_Ajuda.Multiline = true;
            this.txt_Ajuda.Name = "txt_Ajuda";
            this.txt_Ajuda.Size = new System.Drawing.Size(664, 132);
            this.txt_Ajuda.TabIndex = 4;
            this.txt_Ajuda.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 15);
            this.label3.TabIndex = 86;
            this.label3.Text = "Informação Complementar";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(19, 144);
            this.txt_Descricao.MaxLength = 400;
            this.txt_Descricao.Multiline = true;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(664, 46);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Descrição";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(19, 36);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(74, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 87;
            this.label2.Text = "Código";
            // 
            // txt_CFOP
            // 
            this.txt_CFOP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CFOP.Location = new System.Drawing.Point(19, 88);
            this.txt_CFOP.MaxLength = 4;
            this.txt_CFOP.Name = "txt_CFOP";
            this.txt_CFOP.Size = new System.Drawing.Size(74, 21);
            this.txt_CFOP.TabIndex = 2;
            this.txt_CFOP.Tag = "T";
            // 
            // lb_CFOP
            // 
            this.lb_CFOP.AutoSize = true;
            this.lb_CFOP.Location = new System.Drawing.Point(15, 68);
            this.lb_CFOP.Name = "lb_CFOP";
            this.lb_CFOP.Size = new System.Drawing.Size(69, 15);
            this.lb_CFOP.TabIndex = 87;
            this.lb_CFOP.Text = "Cód. CFOP";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(9, 84);
            this.txt_DescricaoP.MaxLength = 400;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(664, 21);
            this.txt_DescricaoP.TabIndex = 2;
            this.txt_DescricaoP.Tag = "T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 105;
            this.label4.Text = "Descrição";
            // 
            // txt_CFOPP
            // 
            this.txt_CFOPP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CFOPP.Location = new System.Drawing.Point(9, 35);
            this.txt_CFOPP.MaxLength = 4;
            this.txt_CFOPP.Name = "txt_CFOPP";
            this.txt_CFOPP.Size = new System.Drawing.Size(74, 21);
            this.txt_CFOPP.TabIndex = 1;
            this.txt_CFOPP.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 107;
            this.label5.Text = "Cód. CFOP";
            // 
            // UI_CFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 699);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_CFOP";
            this.Load += new System.EventHandler(this.UI_CFOP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_CFOP_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.TextBox txt_Ajuda;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_CFOP;
        internal System.Windows.Forms.Label lb_CFOP;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_CFOPP;
        internal System.Windows.Forms.Label label5;
    }
}

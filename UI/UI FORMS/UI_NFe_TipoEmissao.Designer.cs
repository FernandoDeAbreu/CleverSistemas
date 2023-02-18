namespace Sistema.UI
{
    partial class UI_NFe_TipoEmissao
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
            this.Label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SerieP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.label4);
            this.TabPage2.Controls.Add(this.txt_SerieP);
            this.TabPage2.Controls.Add(this.label3);
            this.TabPage2.Controls.SetChildIndex(this.label3, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_SerieP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label4, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            // 
            // txt_Serie
            // 
            this.txt_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Serie.Location = new System.Drawing.Point(10, 131);
            this.txt_Serie.MaxLength = 3;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(61, 21);
            this.txt_Serie.TabIndex = 3;
            this.txt_Serie.Tag = "T";
            this.txt_Serie.Text = "0";
            this.txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 110);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(36, 15);
            this.Label5.TabIndex = 56;
            this.Label5.Text = "Série";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "Tipo de Emissão";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(10, 85);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(408, 21);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 56;
            this.label2.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(10, 39);
            this.txt_ID.MaxLength = 10;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(61, 21);
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.txt_Serie);
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 57;
            this.gb_Cadastro.TabStop = false;
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(13, 86);
            this.txt_DescricaoP.MaxLength = 10;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(408, 21);
            this.txt_DescricaoP.TabIndex = 105;
            this.txt_DescricaoP.Tag = "T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 106;
            this.label4.Text = "Tipo de Emissão";
            // 
            // txt_SerieP
            // 
            this.txt_SerieP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SerieP.Location = new System.Drawing.Point(13, 35);
            this.txt_SerieP.MaxLength = 10;
            this.txt_SerieP.Name = "txt_SerieP";
            this.txt_SerieP.Size = new System.Drawing.Size(61, 21);
            this.txt_SerieP.TabIndex = 104;
            this.txt_SerieP.Tag = "T";
            this.txt_SerieP.Text = "0";
            this.txt_SerieP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 107;
            this.label3.Text = "Série";
            // 
            // UI_NFe_TipoEmissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_NFe_TipoEmissao";
            this.Load += new System.EventHandler(this.UI_NFe_TipoEmissao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_NFe_TipoEmissao_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_NFe_TipoEmissao_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Serie;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_SerieP;
        internal System.Windows.Forms.Label label3;
    }
}

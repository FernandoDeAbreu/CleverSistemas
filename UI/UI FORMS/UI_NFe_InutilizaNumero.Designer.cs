namespace Sistema.UI
{
    partial class UI_NFe_InutilizaNumero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_NFe_InutilizaNumero));
            this.bt_Inutiliza = new System.Windows.Forms.Button();
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Numeracao = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txt_Justificativa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // bt_Inutiliza
            // 
            this.bt_Inutiliza.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Inutiliza.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Inutiliza.Image = ((System.Drawing.Image)(resources.GetObject("bt_Inutiliza.Image")));
            this.bt_Inutiliza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Inutiliza.Location = new System.Drawing.Point(10, 152);
            this.bt_Inutiliza.Name = "bt_Inutiliza";
            this.bt_Inutiliza.Size = new System.Drawing.Size(140, 51);
            this.bt_Inutiliza.TabIndex = 186;
            this.bt_Inutiliza.Text = "INUTILIZAR NÚMERO";
            this.bt_Inutiliza.UseVisualStyleBackColor = false;
            this.bt_Inutiliza.Click += new System.EventHandler(this.bt_Inutiliza_Click);
            // 
            // txt_Serie
            // 
            this.txt_Serie.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Serie.Location = new System.Drawing.Point(10, 39);
            this.txt_Serie.MaxLength = 3;
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(54, 21);
            this.txt_Serie.TabIndex = 1;
            this.txt_Serie.Tag = "T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 187;
            this.label3.Text = "Serie";
            // 
            // txt_Numeracao
            // 
            this.txt_Numeracao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Numeracao.Location = new System.Drawing.Point(72, 39);
            this.txt_Numeracao.MaxLength = 20;
            this.txt_Numeracao.Name = "txt_Numeracao";
            this.txt_Numeracao.Size = new System.Drawing.Size(137, 21);
            this.txt_Numeracao.TabIndex = 2;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(69, 18);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(72, 15);
            this.Label19.TabIndex = 188;
            this.Label19.Text = "Numeração";
            // 
            // txt_Justificativa
            // 
            this.txt_Justificativa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Justificativa.Location = new System.Drawing.Point(10, 99);
            this.txt_Justificativa.MaxLength = 255;
            this.txt_Justificativa.Name = "txt_Justificativa";
            this.txt_Justificativa.Size = new System.Drawing.Size(535, 21);
            this.txt_Justificativa.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 15);
            this.label1.TabIndex = 188;
            this.label1.Text = "Justificativa (Mínimo 15 caracteres)";
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.bt_Inutiliza);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.Label19);
            this.gb_Cadastro.Controls.Add(this.txt_Serie);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_Numeracao);
            this.gb_Cadastro.Controls.Add(this.txt_Justificativa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 189;
            this.gb_Cadastro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 15);
            this.label2.TabIndex = 188;
            this.label2.Text = "Para Inutilizar uma faixa de numeração, utilizar o seguinte modelo (1-5)";
            // 
            // UI_NFe_InutilizaNumero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_NFe_InutilizaNumero";
            this.Load += new System.EventHandler(this.UI_NFe_InutilizaNumero_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_NFe_InutilizaNumero_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_NFe_InutilizaNumero_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bt_Inutiliza;
        internal System.Windows.Forms.TextBox txt_Serie;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_Numeracao;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox txt_Justificativa;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label2;
    }
}

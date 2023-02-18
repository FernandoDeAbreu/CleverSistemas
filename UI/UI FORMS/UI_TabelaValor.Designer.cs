namespace Sistema.UI
{
    partial class UI_TabelaValor
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
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_Margem = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_CustoOperacional = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.txt_IDP = new System.Windows.Forms.TextBox();
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
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.label1);
            this.TabPage2.Controls.Add(this.txt_DescricaoP);
            this.TabPage2.Controls.Add(this.txt_IDP);
            this.TabPage2.Controls.SetChildIndex(this.textBox1, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_IDP, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label1, 0);
            this.TabPage2.Controls.SetChildIndex(this.Label6, 0);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.label11);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.Label3);
            this.gb_Cadastro.Controls.Add(this.txt_Margem);
            this.gb_Cadastro.Controls.Add(this.Label4);
            this.gb_Cadastro.Controls.Add(this.txt_CustoOperacional);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_Descricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(6, 85);
            this.txt_Descricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(241, 21);
            this.txt_Descricao.TabIndex = 103;
            this.txt_Descricao.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 64);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 104;
            this.label11.Text = "Descrição";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 18);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 105;
            this.Label5.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(6, 39);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.MaxLength = 15;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(89, 21);
            this.txt_ID.TabIndex = 102;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 110);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Margem";
            this.Label3.Visible = false;
            // 
            // txt_Margem
            // 
            this.txt_Margem.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Margem.Location = new System.Drawing.Point(6, 131);
            this.txt_Margem.Name = "txt_Margem";
            this.txt_Margem.Size = new System.Drawing.Size(105, 21);
            this.txt_Margem.TabIndex = 12;
            this.txt_Margem.Tag = "T";
            this.txt_Margem.Text = "0,00";
            this.txt_Margem.Visible = false;
            this.txt_Margem.Leave += new System.EventHandler(this.txt_Margem_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(138, 110);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(110, 15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Custo Operacional";
            this.Label4.Visible = false;
            // 
            // txt_CustoOperacional
            // 
            this.txt_CustoOperacional.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CustoOperacional.Location = new System.Drawing.Point(141, 131);
            this.txt_CustoOperacional.Name = "txt_CustoOperacional";
            this.txt_CustoOperacional.Size = new System.Drawing.Size(105, 21);
            this.txt_CustoOperacional.TabIndex = 13;
            this.txt_CustoOperacional.Tag = "T";
            this.txt_CustoOperacional.Text = "0,00";
            this.txt_CustoOperacional.Visible = false;
            this.txt_CustoOperacional.Leave += new System.EventHandler(this.txt_CustoOperacional_Leave);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(7, 57);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(63, 15);
            this.Label6.TabIndex = 110;
            this.Label6.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 111;
            this.label1.Text = "Código";
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(10, 76);
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(374, 21);
            this.txt_DescricaoP.TabIndex = 112;
            // 
            // txt_IDP
            // 
            this.txt_IDP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDP.Location = new System.Drawing.Point(10, 29);
            this.txt_IDP.Name = "txt_IDP";
            this.txt_IDP.Size = new System.Drawing.Size(96, 21);
            this.txt_IDP.TabIndex = 109;
            // 
            // UI_TabelaValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_TabelaValor";
            this.Load += new System.EventHandler(this.UI_TabelaValor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_TabelaValor_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_TabelaValor_KeyPress);
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
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_Margem;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_CustoOperacional;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.TextBox txt_IDP;
    }
}

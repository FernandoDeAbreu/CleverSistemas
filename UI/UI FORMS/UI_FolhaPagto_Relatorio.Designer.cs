namespace Sistema.UI
{
    partial class UI_FolhaPagto_Relatorio
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
            this.label11 = new System.Windows.Forms.Label();
            this.cb_TipoP = new System.Windows.Forms.ComboBox();
            this.mk_Periodo_P = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa_P = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label11);
            this.gb_Cadastro.Controls.Add(this.cb_TipoP);
            this.gb_Cadastro.Controls.Add(this.mk_Periodo_P);
            this.gb_Cadastro.Controls.Add(this.label9);
            this.gb_Cadastro.Controls.Add(this.label8);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa_P);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(99, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 118;
            this.label11.Text = "Tipo";
            // 
            // cb_TipoP
            // 
            this.cb_TipoP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoP.FormattingEnabled = true;
            this.cb_TipoP.Location = new System.Drawing.Point(103, 89);
            this.cb_TipoP.MaxDropDownItems = 15;
            this.cb_TipoP.Name = "cb_TipoP";
            this.cb_TipoP.Size = new System.Drawing.Size(304, 23);
            this.cb_TipoP.TabIndex = 117;
            this.cb_TipoP.Tag = "";
            // 
            // mk_Periodo_P
            // 
            this.mk_Periodo_P.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Periodo_P.Location = new System.Drawing.Point(10, 89);
            this.mk_Periodo_P.Mask = "##/####";
            this.mk_Periodo_P.Name = "mk_Periodo_P";
            this.mk_Periodo_P.Size = new System.Drawing.Size(84, 21);
            this.mk_Periodo_P.TabIndex = 114;
            this.mk_Periodo_P.Tag = "T";
            this.mk_Periodo_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Periodo_P.Leave += new System.EventHandler(this.mk_Periodo_P_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 115;
            this.label9.Text = "Período";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 116;
            this.label8.Text = "Funcionário";
            // 
            // cb_ID_Pessoa_P
            // 
            this.cb_ID_Pessoa_P.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa_P.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa_P.FormattingEnabled = true;
            this.cb_ID_Pessoa_P.Location = new System.Drawing.Point(10, 39);
            this.cb_ID_Pessoa_P.MaxDropDownItems = 15;
            this.cb_ID_Pessoa_P.Name = "cb_ID_Pessoa_P";
            this.cb_ID_Pessoa_P.Size = new System.Drawing.Size(396, 23);
            this.cb_ID_Pessoa_P.TabIndex = 113;
            this.cb_ID_Pessoa_P.Tag = "T";
            // 
            // UI_FolhaPagto_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_FolhaPagto_Relatorio";
            this.Load += new System.EventHandler(this.UI_FolhaPagto_Relatorio_Load);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cb_TipoP;
        internal System.Windows.Forms.MaskedTextBox mk_Periodo_P;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa_P;
    }
}

namespace Sistema.UI
{
    partial class UI_ControleDoc_Tipo
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
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ID_Tipo = new System.Windows.Forms.ComboBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_DescricaoP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ID_TipoP = new System.Windows.Forms.ComboBox();
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
            this.TabPage2.Controls.Add(this.label5);
            this.TabPage2.Controls.Add(this.label4);
            this.TabPage2.Controls.Add(this.cb_ID_TipoP);
            this.TabPage2.Controls.SetChildIndex(this.cb_ID_TipoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label4, 0);
            this.TabPage2.Controls.SetChildIndex(this.label5, 0);
            this.TabPage2.Controls.SetChildIndex(this.txt_DescricaoP, 0);
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
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
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
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.label11);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Tipo);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(10, 97);
            this.txt_Descricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(560, 21);
            this.txt_Descricao.TabIndex = 101;
            this.txt_Descricao.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 15);
            this.label11.TabIndex = 102;
            this.label11.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo";
            // 
            // cb_ID_Tipo
            // 
            this.cb_ID_Tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Tipo.FormattingEnabled = true;
            this.cb_ID_Tipo.Location = new System.Drawing.Point(10, 38);
            this.cb_ID_Tipo.Name = "cb_ID_Tipo";
            this.cb_ID_Tipo.Size = new System.Drawing.Size(326, 23);
            this.cb_ID_Tipo.TabIndex = 6;
            this.cb_ID_Tipo.Tag = "T";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(300, 39);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.MaxLength = 60;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(37, 21);
            this.txt_ID.TabIndex = 101;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // txt_DescricaoP
            // 
            this.txt_DescricaoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoP.Location = new System.Drawing.Point(13, 83);
            this.txt_DescricaoP.MaxLength = 60;
            this.txt_DescricaoP.Name = "txt_DescricaoP";
            this.txt_DescricaoP.Size = new System.Drawing.Size(541, 21);
            this.txt_DescricaoP.TabIndex = 108;
            this.txt_DescricaoP.TabStop = false;
            this.txt_DescricaoP.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 109;
            this.label5.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 106;
            this.label4.Text = "Tipo";
            // 
            // cb_ID_TipoP
            // 
            this.cb_ID_TipoP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_TipoP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_TipoP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_TipoP.FormattingEnabled = true;
            this.cb_ID_TipoP.Location = new System.Drawing.Point(13, 28);
            this.cb_ID_TipoP.Name = "cb_ID_TipoP";
            this.cb_ID_TipoP.Size = new System.Drawing.Size(326, 23);
            this.cb_ID_TipoP.TabIndex = 107;
            this.cb_ID_TipoP.Tag = "T";
            this.cb_ID_TipoP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_ID_TipoP_KeyDown);
            // 
            // UI_ControleDoc_Tipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_ControleDoc_Tipo";
            this.Load += new System.EventHandler(this.UI_ControleDoc_Tipo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_ControleDoc_Tipo_KeyDown);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ID_Tipo;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_DescricaoP;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_ID_TipoP;
        internal System.Windows.Forms.TextBox txt_ID;
    }
}

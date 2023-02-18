namespace Sistema.UI
{
    partial class UI_ManutencaoBD
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
            this.tab_Consulta = new System.Windows.Forms.TabControl();
            this.tab_Consulta1 = new System.Windows.Forms.TabPage();
            this.dg_Consulta1 = new System.Windows.Forms.DataGridView();
            this.tab_Consulta2 = new System.Windows.Forms.TabPage();
            this.dg_Consulta2 = new System.Windows.Forms.DataGridView();
            this.tab_Consulta3 = new System.Windows.Forms.TabPage();
            this.dg_Consulta3 = new System.Windows.Forms.DataGridView();
            this.tab_Consulta4 = new System.Windows.Forms.TabPage();
            this.dg_Consulta4 = new System.Windows.Forms.DataGridView();
            this.tab_Consulta5 = new System.Windows.Forms.TabPage();
            this.dg_Consulta5 = new System.Windows.Forms.DataGridView();
            this.dg_Tabelas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Acesso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.bt_PesquisaPessoa = new System.Windows.Forms.Button();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.tab_Consulta.SuspendLayout();
            this.tab_Consulta1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta1)).BeginInit();
            this.tab_Consulta2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta2)).BeginInit();
            this.tab_Consulta3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta3)).BeginInit();
            this.tab_Consulta4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta4)).BeginInit();
            this.tab_Consulta5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabelas)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_PesquisaPessoa);
            this.TabPage1.Controls.Add(this.txt_Descricao);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.txt_ID);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.txt_Acesso);
            this.TabPage1.Controls.Add(this.tab_Consulta);
            this.TabPage1.Controls.Add(this.dg_Tabelas);
            // 
            // tab_Consulta
            // 
            this.tab_Consulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_Consulta.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tab_Consulta.Controls.Add(this.tab_Consulta1);
            this.tab_Consulta.Controls.Add(this.tab_Consulta2);
            this.tab_Consulta.Controls.Add(this.tab_Consulta3);
            this.tab_Consulta.Controls.Add(this.tab_Consulta4);
            this.tab_Consulta.Controls.Add(this.tab_Consulta5);
            this.tab_Consulta.ItemSize = new System.Drawing.Size(120, 30);
            this.tab_Consulta.Location = new System.Drawing.Point(306, 254);
            this.tab_Consulta.Name = "tab_Consulta";
            this.tab_Consulta.SelectedIndex = 0;
            this.tab_Consulta.Size = new System.Drawing.Size(628, 365);
            this.tab_Consulta.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tab_Consulta.TabIndex = 11;
            // 
            // tab_Consulta1
            // 
            this.tab_Consulta1.Controls.Add(this.dg_Consulta1);
            this.tab_Consulta1.Location = new System.Drawing.Point(4, 34);
            this.tab_Consulta1.Name = "tab_Consulta1";
            this.tab_Consulta1.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta1.Size = new System.Drawing.Size(620, 327);
            this.tab_Consulta1.TabIndex = 0;
            this.tab_Consulta1.Text = "CONSULTA 1";
            this.tab_Consulta1.UseVisualStyleBackColor = true;
            // 
            // dg_Consulta1
            // 
            this.dg_Consulta1.AllowUserToAddRows = false;
            this.dg_Consulta1.AllowUserToDeleteRows = false;
            this.dg_Consulta1.AllowUserToOrderColumns = true;
            this.dg_Consulta1.AllowUserToResizeRows = false;
            this.dg_Consulta1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Consulta1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Consulta1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Consulta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Consulta1.Location = new System.Drawing.Point(3, 3);
            this.dg_Consulta1.MultiSelect = false;
            this.dg_Consulta1.Name = "dg_Consulta1";
            this.dg_Consulta1.ReadOnly = true;
            this.dg_Consulta1.RowHeadersVisible = false;
            this.dg_Consulta1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Consulta1.Size = new System.Drawing.Size(614, 321);
            this.dg_Consulta1.StandardTab = true;
            this.dg_Consulta1.TabIndex = 33;
            // 
            // tab_Consulta2
            // 
            this.tab_Consulta2.Controls.Add(this.dg_Consulta2);
            this.tab_Consulta2.Location = new System.Drawing.Point(4, 34);
            this.tab_Consulta2.Name = "tab_Consulta2";
            this.tab_Consulta2.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta2.Size = new System.Drawing.Size(839, 327);
            this.tab_Consulta2.TabIndex = 1;
            this.tab_Consulta2.Text = "CONSULTA 2";
            this.tab_Consulta2.UseVisualStyleBackColor = true;
            // 
            // dg_Consulta2
            // 
            this.dg_Consulta2.AllowUserToAddRows = false;
            this.dg_Consulta2.AllowUserToDeleteRows = false;
            this.dg_Consulta2.AllowUserToOrderColumns = true;
            this.dg_Consulta2.AllowUserToResizeRows = false;
            this.dg_Consulta2.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_Consulta2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Consulta2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Consulta2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Consulta2.Location = new System.Drawing.Point(3, 3);
            this.dg_Consulta2.MultiSelect = false;
            this.dg_Consulta2.Name = "dg_Consulta2";
            this.dg_Consulta2.ReadOnly = true;
            this.dg_Consulta2.RowHeadersVisible = false;
            this.dg_Consulta2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Consulta2.Size = new System.Drawing.Size(833, 321);
            this.dg_Consulta2.StandardTab = true;
            this.dg_Consulta2.TabIndex = 34;
            // 
            // tab_Consulta3
            // 
            this.tab_Consulta3.Controls.Add(this.dg_Consulta3);
            this.tab_Consulta3.Location = new System.Drawing.Point(4, 34);
            this.tab_Consulta3.Name = "tab_Consulta3";
            this.tab_Consulta3.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta3.Size = new System.Drawing.Size(839, 327);
            this.tab_Consulta3.TabIndex = 2;
            this.tab_Consulta3.Text = "CONSULTA 3";
            this.tab_Consulta3.UseVisualStyleBackColor = true;
            // 
            // dg_Consulta3
            // 
            this.dg_Consulta3.AllowUserToAddRows = false;
            this.dg_Consulta3.AllowUserToDeleteRows = false;
            this.dg_Consulta3.AllowUserToOrderColumns = true;
            this.dg_Consulta3.AllowUserToResizeRows = false;
            this.dg_Consulta3.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_Consulta3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Consulta3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Consulta3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Consulta3.Location = new System.Drawing.Point(3, 3);
            this.dg_Consulta3.MultiSelect = false;
            this.dg_Consulta3.Name = "dg_Consulta3";
            this.dg_Consulta3.ReadOnly = true;
            this.dg_Consulta3.RowHeadersVisible = false;
            this.dg_Consulta3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Consulta3.Size = new System.Drawing.Size(833, 321);
            this.dg_Consulta3.StandardTab = true;
            this.dg_Consulta3.TabIndex = 34;
            // 
            // tab_Consulta4
            // 
            this.tab_Consulta4.Controls.Add(this.dg_Consulta4);
            this.tab_Consulta4.Location = new System.Drawing.Point(4, 34);
            this.tab_Consulta4.Name = "tab_Consulta4";
            this.tab_Consulta4.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta4.Size = new System.Drawing.Size(839, 327);
            this.tab_Consulta4.TabIndex = 3;
            this.tab_Consulta4.Text = "CONSULTA 4";
            this.tab_Consulta4.UseVisualStyleBackColor = true;
            // 
            // dg_Consulta4
            // 
            this.dg_Consulta4.AllowUserToAddRows = false;
            this.dg_Consulta4.AllowUserToDeleteRows = false;
            this.dg_Consulta4.AllowUserToOrderColumns = true;
            this.dg_Consulta4.AllowUserToResizeRows = false;
            this.dg_Consulta4.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_Consulta4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Consulta4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Consulta4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Consulta4.Location = new System.Drawing.Point(3, 3);
            this.dg_Consulta4.MultiSelect = false;
            this.dg_Consulta4.Name = "dg_Consulta4";
            this.dg_Consulta4.ReadOnly = true;
            this.dg_Consulta4.RowHeadersVisible = false;
            this.dg_Consulta4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Consulta4.Size = new System.Drawing.Size(833, 321);
            this.dg_Consulta4.StandardTab = true;
            this.dg_Consulta4.TabIndex = 34;
            // 
            // tab_Consulta5
            // 
            this.tab_Consulta5.Controls.Add(this.dg_Consulta5);
            this.tab_Consulta5.Location = new System.Drawing.Point(4, 34);
            this.tab_Consulta5.Name = "tab_Consulta5";
            this.tab_Consulta5.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta5.Size = new System.Drawing.Size(839, 327);
            this.tab_Consulta5.TabIndex = 4;
            this.tab_Consulta5.Text = "CONSULTA 5";
            this.tab_Consulta5.UseVisualStyleBackColor = true;
            // 
            // dg_Consulta5
            // 
            this.dg_Consulta5.AllowUserToAddRows = false;
            this.dg_Consulta5.AllowUserToDeleteRows = false;
            this.dg_Consulta5.AllowUserToOrderColumns = true;
            this.dg_Consulta5.AllowUserToResizeRows = false;
            this.dg_Consulta5.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_Consulta5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Consulta5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Consulta5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Consulta5.Location = new System.Drawing.Point(3, 3);
            this.dg_Consulta5.MultiSelect = false;
            this.dg_Consulta5.Name = "dg_Consulta5";
            this.dg_Consulta5.ReadOnly = true;
            this.dg_Consulta5.RowHeadersVisible = false;
            this.dg_Consulta5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Consulta5.Size = new System.Drawing.Size(833, 321);
            this.dg_Consulta5.StandardTab = true;
            this.dg_Consulta5.TabIndex = 34;
            // 
            // dg_Tabelas
            // 
            this.dg_Tabelas.AllowUserToAddRows = false;
            this.dg_Tabelas.AllowUserToDeleteRows = false;
            this.dg_Tabelas.AllowUserToOrderColumns = true;
            this.dg_Tabelas.AllowUserToResizeColumns = false;
            this.dg_Tabelas.AllowUserToResizeRows = false;
            this.dg_Tabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dg_Tabelas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Tabelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Tabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Tabelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dg_Tabelas.Location = new System.Drawing.Point(9, 55);
            this.dg_Tabelas.MultiSelect = false;
            this.dg_Tabelas.Name = "dg_Tabelas";
            this.dg_Tabelas.ReadOnly = true;
            this.dg_Tabelas.RowHeadersVisible = false;
            this.dg_Tabelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Tabelas.Size = new System.Drawing.Size(286, 566);
            this.dg_Tabelas.StandardTab = true;
            this.dg_Tabelas.TabIndex = 2;
            this.dg_Tabelas.DoubleClick += new System.EventHandler(this.dg_Tabelas_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Tabelas";
            this.Column1.HeaderText = "TABELAS";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // txt_Acesso
            // 
            this.txt_Acesso.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Acesso.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_Acesso.Location = new System.Drawing.Point(9, 25);
            this.txt_Acesso.MaxLength = 60;
            this.txt_Acesso.Name = "txt_Acesso";
            this.txt_Acesso.Size = new System.Drawing.Size(285, 21);
            this.txt_Acesso.TabIndex = 1;
            this.txt_Acesso.TabStop = false;
            this.txt_Acesso.Tag = "T";
            this.txt_Acesso.UseSystemPasswordChar = true;
            this.txt_Acesso.Leave += new System.EventHandler(this.txt_Acesso_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Liberar Acesso";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(306, 25);
            this.txt_Descricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao.Multiline = true;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(630, 193);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(309, 227);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(61, 15);
            this.Label5.TabIndex = 105;
            this.Label5.Text = "Resposta";
            // 
            // txt_ID
            // 
            this.txt_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Location = new System.Drawing.Point(374, 224);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(562, 21);
            this.txt_ID.TabIndex = 10;
            this.txt_ID.Tag = "T";
            // 
            // bt_PesquisaPessoa
            // 
            this.bt_PesquisaPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_PesquisaPessoa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaPessoa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaPessoa.Image = global::Sistema.UI.Properties.Resources.bt_Servidor;
            this.bt_PesquisaPessoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaPessoa.Location = new System.Drawing.Point(1045, 182);
            this.bt_PesquisaPessoa.Name = "bt_PesquisaPessoa";
            this.bt_PesquisaPessoa.Size = new System.Drawing.Size(101, 34);
            this.bt_PesquisaPessoa.TabIndex = 5;
            this.bt_PesquisaPessoa.TabStop = false;
            this.bt_PesquisaPessoa.Text = "EXECUTAR";
            this.bt_PesquisaPessoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_PesquisaPessoa.UseVisualStyleBackColor = false;
            this.bt_PesquisaPessoa.Click += new System.EventHandler(this.bt_PesquisaPessoa_Click);
            // 
            // UI_ManutencaoBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_ManutencaoBD";
            this.Load += new System.EventHandler(this.UI_ManutencaoBD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_ManutencaoBD_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.tab_Consulta.ResumeLayout(false);
            this.tab_Consulta1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta1)).EndInit();
            this.tab_Consulta2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta2)).EndInit();
            this.tab_Consulta3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta3)).EndInit();
            this.tab_Consulta4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta4)).EndInit();
            this.tab_Consulta5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Consulta5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Consulta;
        private System.Windows.Forms.TabPage tab_Consulta1;
        internal System.Windows.Forms.DataGridView dg_Consulta1;
        private System.Windows.Forms.TabPage tab_Consulta2;
        internal System.Windows.Forms.DataGridView dg_Consulta2;
        private System.Windows.Forms.TabPage tab_Consulta3;
        internal System.Windows.Forms.DataGridView dg_Consulta3;
        private System.Windows.Forms.TabPage tab_Consulta4;
        internal System.Windows.Forms.DataGridView dg_Consulta4;
        private System.Windows.Forms.TabPage tab_Consulta5;
        internal System.Windows.Forms.DataGridView dg_Consulta5;
        internal System.Windows.Forms.DataGridView dg_Tabelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Acesso;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Button bt_PesquisaPessoa;
    }
}

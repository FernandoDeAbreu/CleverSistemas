namespace Sistema.UI
{
    partial class UI_FROTA_COMBUSTIVEL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_FROTA_COMBUSTIVEL));
            this.label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_Combustivel = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Edita = new System.Windows.Forms.Button();
            this.bt_Grava = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Combustivel)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 73);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 109;
            this.label11.Text = "Descrição";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 15);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 15);
            this.Label5.TabIndex = 110;
            this.Label5.Text = "Código";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1107, 623);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Descricao);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_ID);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CADASTRO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Descricao.Location = new System.Drawing.Point(8, 91);
            this.txt_Descricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(262, 21);
            this.txt_Descricao.TabIndex = 107;
            this.txt_Descricao.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 108;
            this.label1.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 109;
            this.label2.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ID.Location = new System.Drawing.Point(8, 34);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ID.MaxLength = 15;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(89, 21);
            this.txt_ID.TabIndex = 106;
            this.txt_ID.Tag = "T";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_Combustivel);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1099, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PESQUISA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_Combustivel
            // 
            this.dgv_Combustivel.AllowUserToAddRows = false;
            this.dgv_Combustivel.AllowUserToDeleteRows = false;
            this.dgv_Combustivel.AllowUserToResizeColumns = false;
            this.dgv_Combustivel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_Combustivel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Combustivel.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_Combustivel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Combustivel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Combustivel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DESCRICAO});
            this.dgv_Combustivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Combustivel.Location = new System.Drawing.Point(3, 3);
            this.dgv_Combustivel.Name = "dgv_Combustivel";
            this.dgv_Combustivel.ReadOnly = true;
            this.dgv_Combustivel.RowHeadersWidth = 20;
            this.dgv_Combustivel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Combustivel.Size = new System.Drawing.Size(1093, 586);
            this.dgv_Combustivel.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // DESCRICAO
            // 
            this.DESCRICAO.HeaderText = "DESCRIÇÃO";
            this.DESCRICAO.Name = "DESCRICAO";
            this.DESCRICAO.ReadOnly = true;
            this.DESCRICAO.Width = 400;
            // 
            // bt_Edita
            // 
            this.bt_Edita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Edita.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Edita.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Edita.Image = global::Sistema.UI.Properties.Resources.bt_NotaFiscal;
            this.bt_Edita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Edita.Location = new System.Drawing.Point(1000, 625);
            this.bt_Edita.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Edita.Name = "bt_Edita";
            this.bt_Edita.Size = new System.Drawing.Size(99, 34);
            this.bt_Edita.TabIndex = 676;
            this.bt_Edita.Text = "EDITAR";
            this.bt_Edita.UseVisualStyleBackColor = false;
            this.bt_Edita.Click += new System.EventHandler(this.bt_Edita_Click);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Grava.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Grava.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Grava.Image = global::Sistema.UI.Properties.Resources.bt_Salvar;
            this.bt_Grava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Grava.Location = new System.Drawing.Point(897, 625);
            this.bt_Grava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Grava.Name = "bt_Grava";
            this.bt_Grava.Size = new System.Drawing.Size(99, 34);
            this.bt_Grava.TabIndex = 675;
            this.bt_Grava.Text = "GRAVAR";
            this.bt_Grava.UseVisualStyleBackColor = false;
            this.bt_Grava.Click += new System.EventHandler(this.bt_Grava_Click);
            // 
            // UI_FROTA_COMBUSTIVEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 667);
            this.Controls.Add(this.bt_Edita);
            this.Controls.Add(this.bt_Grava);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_FROTA_COMBUSTIVEL";
            this.Text = "COMBUSTÍVEL";
            this.Load += new System.EventHandler(this.UI_FROTA_COMBUSTIVEL_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Combustivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.DataGridView dgv_Combustivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRICAO;
        public System.Windows.Forms.Button bt_Grava;
        public System.Windows.Forms.Button bt_Edita;
    }
}
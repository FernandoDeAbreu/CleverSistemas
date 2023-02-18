namespace Sistema.UI
{
    partial class UI_Grade
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
            this.dg_Grade = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label6 = new System.Windows.Forms.Label();
            this.cb_ID_Grupo = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Grade)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.txt_Descricao);
            this.gb_Cadastro.Controls.Add(this.label11);
            this.gb_Cadastro.Controls.Add(this.Label5);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.dg_Grade);
            this.gb_Cadastro.Controls.Add(this.Label6);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Grupo);
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
            this.txt_Descricao.Location = new System.Drawing.Point(6, 165);
            this.txt_Descricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(277, 21);
            this.txt_Descricao.TabIndex = 3;
            this.txt_Descricao.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 146);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 15);
            this.label11.TabIndex = 104;
            this.label11.Text = "Descrição Item";
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
            this.txt_ID.TabIndex = 1;
            this.txt_ID.Tag = "T";
            // 
            // dg_Grade
            // 
            this.dg_Grade.AllowUserToAddRows = false;
            this.dg_Grade.AllowUserToDeleteRows = false;
            this.dg_Grade.AllowUserToResizeColumns = false;
            this.dg_Grade.AllowUserToResizeRows = false;
            this.dg_Grade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Grade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Grade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dg_Grade.Location = new System.Drawing.Point(309, 18);
            this.dg_Grade.MultiSelect = false;
            this.dg_Grade.Name = "dg_Grade";
            this.dg_Grade.ReadOnly = true;
            this.dg_Grade.RowHeadersVisible = false;
            this.dg_Grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Grade.Size = new System.Drawing.Size(551, 321);
            this.dg_Grade.StandardTab = true;
            this.dg_Grade.TabIndex = 5;
            this.dg_Grade.TabStop = false;
            this.dg_Grade.DataSourceChanged += new System.EventHandler(this.dg_Grade_DataSourceChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DescricaoGrupo";
            this.Column1.HeaderText = "GRADE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Descricao";
            this.Column2.HeaderText = "DESCRIÇÃO ITEM";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 78);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(41, 15);
            this.Label6.TabIndex = 42;
            this.Label6.Text = "Grade";
            // 
            // cb_ID_Grupo
            // 
            this.cb_ID_Grupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Grupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Grupo.FormattingEnabled = true;
            this.cb_ID_Grupo.Location = new System.Drawing.Point(6, 99);
            this.cb_ID_Grupo.Name = "cb_ID_Grupo";
            this.cb_ID_Grupo.Size = new System.Drawing.Size(277, 23);
            this.cb_ID_Grupo.TabIndex = 2;
            this.cb_ID_Grupo.Tag = "";
            this.cb_ID_Grupo.SelectedValueChanged += new System.EventHandler(this.cb_ID_Grupo_SelectedValueChanged);
            // 
            // UI_Grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Grade";
            this.Load += new System.EventHandler(this.UI_Grade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Grade_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Grade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.DataGridView dg_Grade;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cb_ID_Grupo;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

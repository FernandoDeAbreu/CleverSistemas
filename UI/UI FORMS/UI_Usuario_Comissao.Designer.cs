namespace Sistema.UI
{
    partial class UI_Usuario_Comissao
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
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.bt_ComissaoTodos = new System.Windows.Forms.Button();
            this.bt_ComissaoUnico = new System.Windows.Forms.Button();
            this.txt_Comissao = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.cb_ID_TipoComissao = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.dg_Comissao = new System.Windows.Forms.DataGridView();
            this.col_DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Comissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Comissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_TipoComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_Usuario = new System.Windows.Forms.Label();
            this.cb_ID_Usuario = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Comissao)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.bt_ComissaoTodos);
            this.gb_Cadastro.Controls.Add(this.bt_ComissaoUnico);
            this.gb_Cadastro.Controls.Add(this.txt_Comissao);
            this.gb_Cadastro.Controls.Add(this.label43);
            this.gb_Cadastro.Controls.Add(this.cb_Tipo);
            this.gb_Cadastro.Controls.Add(this.cb_ID_TipoComissao);
            this.gb_Cadastro.Controls.Add(this.label52);
            this.gb_Cadastro.Controls.Add(this.dg_Comissao);
            this.gb_Cadastro.Controls.Add(this.lb_Usuario);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Usuario);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // bt_ComissaoTodos
            // 
            this.bt_ComissaoTodos.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ComissaoTodos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ComissaoTodos.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_ComissaoTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ComissaoTodos.Location = new System.Drawing.Point(608, 75);
            this.bt_ComissaoTodos.Name = "bt_ComissaoTodos";
            this.bt_ComissaoTodos.Size = new System.Drawing.Size(131, 49);
            this.bt_ComissaoTodos.TabIndex = 120;
            this.bt_ComissaoTodos.Text = "TODOS";
            this.bt_ComissaoTodos.UseVisualStyleBackColor = false;
            this.bt_ComissaoTodos.Click += new System.EventHandler(this.bt_ComissaoTodos_Click);
            // 
            // bt_ComissaoUnico
            // 
            this.bt_ComissaoUnico.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ComissaoUnico.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ComissaoUnico.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_ComissaoUnico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ComissaoUnico.Location = new System.Drawing.Point(608, 20);
            this.bt_ComissaoUnico.Name = "bt_ComissaoUnico";
            this.bt_ComissaoUnico.Size = new System.Drawing.Size(131, 49);
            this.bt_ComissaoUnico.TabIndex = 119;
            this.bt_ComissaoUnico.Text = "ÚNICO";
            this.bt_ComissaoUnico.UseVisualStyleBackColor = false;
            this.bt_ComissaoUnico.Click += new System.EventHandler(this.bt_ComissaoUnico_Click);
            // 
            // txt_Comissao
            // 
            this.txt_Comissao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Comissao.Location = new System.Drawing.Point(492, 65);
            this.txt_Comissao.Name = "txt_Comissao";
            this.txt_Comissao.Size = new System.Drawing.Size(93, 21);
            this.txt_Comissao.TabIndex = 118;
            this.txt_Comissao.Tag = "T";
            this.txt_Comissao.Text = "0,00";
            this.txt_Comissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Comissao.Leave += new System.EventHandler(this.txt_Comissao_Leave);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(486, 50);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(65, 15);
            this.label43.TabIndex = 116;
            this.label43.Text = "Comissão";
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(309, 65);
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(166, 23);
            this.cb_Tipo.TabIndex = 117;
            this.cb_Tipo.Tag = "T";
            // 
            // cb_ID_TipoComissao
            // 
            this.cb_ID_TipoComissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_TipoComissao.FormattingEnabled = true;
            this.cb_ID_TipoComissao.Location = new System.Drawing.Point(7, 94);
            this.cb_ID_TipoComissao.Name = "cb_ID_TipoComissao";
            this.cb_ID_TipoComissao.Size = new System.Drawing.Size(259, 23);
            this.cb_ID_TipoComissao.TabIndex = 117;
            this.cb_ID_TipoComissao.Tag = "T";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(3, 75);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(92, 15);
            this.label52.TabIndex = 115;
            this.label52.Text = "Tipo Comissão";
            // 
            // dg_Comissao
            // 
            this.dg_Comissao.AllowUserToAddRows = false;
            this.dg_Comissao.AllowUserToDeleteRows = false;
            this.dg_Comissao.AllowUserToResizeColumns = false;
            this.dg_Comissao.AllowUserToResizeRows = false;
            this.dg_Comissao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Comissao.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Comissao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Comissao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Comissao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_DescricaoProduto,
            this.col_TipoComissao,
            this.col_Comissao,
            this.col_ID_Comissao,
            this.col_ID_Produto,
            this.col_ID_TipoComissao});
            this.dg_Comissao.Location = new System.Drawing.Point(7, 132);
            this.dg_Comissao.MultiSelect = false;
            this.dg_Comissao.Name = "dg_Comissao";
            this.dg_Comissao.ReadOnly = true;
            this.dg_Comissao.RowHeadersVisible = false;
            this.dg_Comissao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Comissao.Size = new System.Drawing.Size(924, 482);
            this.dg_Comissao.StandardTab = true;
            this.dg_Comissao.TabIndex = 114;
            // 
            // col_DescricaoProduto
            // 
            this.col_DescricaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoProduto.DataPropertyName = "Produto";
            this.col_DescricaoProduto.HeaderText = "PRODUTO";
            this.col_DescricaoProduto.Name = "col_DescricaoProduto";
            this.col_DescricaoProduto.ReadOnly = true;
            // 
            // col_TipoComissao
            // 
            this.col_TipoComissao.DataPropertyName = "TipoComissao";
            this.col_TipoComissao.HeaderText = "TIPO COMISSÃO";
            this.col_TipoComissao.Name = "col_TipoComissao";
            this.col_TipoComissao.ReadOnly = true;
            this.col_TipoComissao.Width = 150;
            // 
            // col_Comissao
            // 
            this.col_Comissao.DataPropertyName = "Comissao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Comissao.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Comissao.HeaderText = "COMISSÃO";
            this.col_Comissao.Name = "col_Comissao";
            this.col_Comissao.ReadOnly = true;
            this.col_Comissao.Width = 80;
            // 
            // col_ID_Comissao
            // 
            this.col_ID_Comissao.DataPropertyName = "ID";
            this.col_ID_Comissao.HeaderText = "ID";
            this.col_ID_Comissao.Name = "col_ID_Comissao";
            this.col_ID_Comissao.ReadOnly = true;
            this.col_ID_Comissao.Visible = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "ID_Produto";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Visible = false;
            // 
            // col_ID_TipoComissao
            // 
            this.col_ID_TipoComissao.DataPropertyName = "ID_TipoComissao";
            this.col_ID_TipoComissao.HeaderText = "ID_TipoComissao";
            this.col_ID_TipoComissao.Name = "col_ID_TipoComissao";
            this.col_ID_TipoComissao.ReadOnly = true;
            this.col_ID_TipoComissao.Visible = false;
            // 
            // lb_Usuario
            // 
            this.lb_Usuario.AutoSize = true;
            this.lb_Usuario.Location = new System.Drawing.Point(3, 20);
            this.lb_Usuario.Name = "lb_Usuario";
            this.lb_Usuario.Size = new System.Drawing.Size(51, 15);
            this.lb_Usuario.TabIndex = 113;
            this.lb_Usuario.Text = "Usuário";
            // 
            // cb_ID_Usuario
            // 
            this.cb_ID_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Usuario.FormattingEnabled = true;
            this.cb_ID_Usuario.Location = new System.Drawing.Point(7, 41);
            this.cb_ID_Usuario.Name = "cb_ID_Usuario";
            this.cb_ID_Usuario.Size = new System.Drawing.Size(259, 23);
            this.cb_ID_Usuario.TabIndex = 112;
            this.cb_ID_Usuario.Tag = "T";
            this.cb_ID_Usuario.SelectedValueChanged += new System.EventHandler(this.cb_ID_Usuario_SelectedValueChanged);
            // 
            // UI_Usuario_Comissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Usuario_Comissao";
            this.Load += new System.EventHandler(this.UI_Usuario_Comissao_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Usuario_Comissao_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Comissao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.Label lb_Usuario;
        internal System.Windows.Forms.ComboBox cb_ID_Usuario;
        private System.Windows.Forms.Button bt_ComissaoTodos;
        internal System.Windows.Forms.Button bt_ComissaoUnico;
        internal System.Windows.Forms.TextBox txt_Comissao;
        internal System.Windows.Forms.Label label43;
        internal System.Windows.Forms.ComboBox cb_ID_TipoComissao;
        internal System.Windows.Forms.Label label52;
        internal System.Windows.Forms.DataGridView dg_Comissao;
        internal System.Windows.Forms.ComboBox cb_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoComissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Comissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Comissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_TipoComissao;
    }
}

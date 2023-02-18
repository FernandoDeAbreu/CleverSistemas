namespace Sistema.UI
{
    partial class UI_Pessoa_Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pessoa_Consulta));
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txt_Descricao = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.txt_NomeFantasia = new System.Windows.Forms.TextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.txt_CNPJ_CPF = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.dg_PesquisaPessoa = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Fantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Localizar = new System.Windows.Forms.Button();
            this.bt_SelecionarPessoa = new System.Windows.Forms.Button();
            this.bt_Novo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Telefone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Logradouro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PesquisaPessoa)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(14, 32);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(124, 24);
            this.cb_TipoPessoa.TabIndex = 1;
            this.cb_TipoPessoa.TabStop = false;
            this.cb_TipoPessoa.Tag = "T";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(10, 13);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(80, 16);
            this.Label15.TabIndex = 129;
            this.Label15.Text = "Tipo Pessoa";
            // 
            // txt_Descricao
            // 
            this.txt_Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descricao.Location = new System.Drawing.Point(144, 32);
            this.txt_Descricao.MaxLength = 60;
            this.txt_Descricao.Name = "txt_Descricao";
            this.txt_Descricao.Size = new System.Drawing.Size(434, 22);
            this.txt_Descricao.TabIndex = 2;
            this.txt_Descricao.Tag = "T";
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(140, 10);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(42, 16);
            this.Label30.TabIndex = 128;
            this.Label30.Text = "Nome";
            // 
            // txt_NomeFantasia
            // 
            this.txt_NomeFantasia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_NomeFantasia.Location = new System.Drawing.Point(14, 82);
            this.txt_NomeFantasia.MaxLength = 60;
            this.txt_NomeFantasia.Name = "txt_NomeFantasia";
            this.txt_NomeFantasia.Size = new System.Drawing.Size(305, 22);
            this.txt_NomeFantasia.TabIndex = 3;
            this.txt_NomeFantasia.Tag = "T";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(10, 62);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(96, 16);
            this.Label31.TabIndex = 127;
            this.Label31.Text = "Nome Fantasia";
            // 
            // txt_CNPJ_CPF
            // 
            this.txt_CNPJ_CPF.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CNPJ_CPF.Location = new System.Drawing.Point(436, 82);
            this.txt_CNPJ_CPF.MaxLength = 18;
            this.txt_CNPJ_CPF.Name = "txt_CNPJ_CPF";
            this.txt_CNPJ_CPF.Size = new System.Drawing.Size(142, 22);
            this.txt_CNPJ_CPF.TabIndex = 6;
            this.txt_CNPJ_CPF.Tag = "T";
            this.txt_CNPJ_CPF.Enter += new System.EventHandler(this.txt_CNPJ_CPF_Enter);
            this.txt_CNPJ_CPF.Leave += new System.EventHandler(this.txt_CNPJ_CPF_Leave);
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(323, 62);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(48, 16);
            this.Label32.TabIndex = 126;
            this.Label32.Text = "Código";
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ID.Location = new System.Drawing.Point(327, 82);
            this.txt_ID.MaxLength = 14;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(102, 22);
            this.txt_ID.TabIndex = 5;
            this.txt_ID.Tag = "T";
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(433, 62);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(71, 16);
            this.Label33.TabIndex = 125;
            this.Label33.Text = "CNPJ/CPF";
            // 
            // dg_PesquisaPessoa
            // 
            this.dg_PesquisaPessoa.AllowUserToAddRows = false;
            this.dg_PesquisaPessoa.AllowUserToDeleteRows = false;
            this.dg_PesquisaPessoa.AllowUserToResizeColumns = false;
            this.dg_PesquisaPessoa.AllowUserToResizeRows = false;
            this.dg_PesquisaPessoa.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_PesquisaPessoa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_PesquisaPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_PesquisaPessoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Descricao,
            this.col_Fantasia,
            this.col_TipoPessoa,
            this.col_ID_Pessoa,
            this.col_Endereco});
            this.dg_PesquisaPessoa.Location = new System.Drawing.Point(14, 167);
            this.dg_PesquisaPessoa.MultiSelect = false;
            this.dg_PesquisaPessoa.Name = "dg_PesquisaPessoa";
            this.dg_PesquisaPessoa.ReadOnly = true;
            this.dg_PesquisaPessoa.RowHeadersVisible = false;
            this.dg_PesquisaPessoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_PesquisaPessoa.Size = new System.Drawing.Size(771, 302);
            this.dg_PesquisaPessoa.StandardTab = true;
            this.dg_PesquisaPessoa.TabIndex = 20;
            this.dg_PesquisaPessoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_PesquisaPessoa_CellDoubleClick);
            this.dg_PesquisaPessoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_PesquisaPessoa_KeyDown);
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "CÓD.";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Width = 70;
            // 
            // col_Descricao
            // 
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "NOME";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            this.col_Descricao.Width = 400;
            // 
            // col_Fantasia
            // 
            this.col_Fantasia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Fantasia.DataPropertyName = "NomeFantasia";
            this.col_Fantasia.HeaderText = "NOME FANTASIA";
            this.col_Fantasia.Name = "col_Fantasia";
            this.col_Fantasia.ReadOnly = true;
            this.col_Fantasia.Width = 125;
            // 
            // col_TipoPessoa
            // 
            this.col_TipoPessoa.DataPropertyName = "TipoPessoa";
            this.col_TipoPessoa.HeaderText = "TipoPessoa";
            this.col_TipoPessoa.Name = "col_TipoPessoa";
            this.col_TipoPessoa.ReadOnly = true;
            this.col_TipoPessoa.Visible = false;
            // 
            // col_ID_Pessoa
            // 
            this.col_ID_Pessoa.DataPropertyName = "ID";
            this.col_ID_Pessoa.HeaderText = "ID_Pessoa";
            this.col_ID_Pessoa.Name = "col_ID_Pessoa";
            this.col_ID_Pessoa.ReadOnly = true;
            this.col_ID_Pessoa.Visible = false;
            // 
            // col_Endereco
            // 
            this.col_Endereco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Endereco.DataPropertyName = "Resumo_End";
            this.col_Endereco.HeaderText = "ENDEREÇO";
            this.col_Endereco.Name = "col_Endereco";
            this.col_Endereco.ReadOnly = true;
            this.col_Endereco.Width = 106;
            // 
            // bt_Localizar
            // 
            this.bt_Localizar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Localizar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Localizar.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_Localizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Localizar.Location = new System.Drawing.Point(645, 107);
            this.bt_Localizar.Name = "bt_Localizar";
            this.bt_Localizar.Size = new System.Drawing.Size(140, 50);
            this.bt_Localizar.TabIndex = 10;
            this.bt_Localizar.Text = "PESQUISA (F5)";
            this.bt_Localizar.UseVisualStyleBackColor = false;
            this.bt_Localizar.Click += new System.EventHandler(this.bt_Localizar_Click);
            // 
            // bt_SelecionarPessoa
            // 
            this.bt_SelecionarPessoa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_SelecionarPessoa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SelecionarPessoa.Image = ((System.Drawing.Image)(resources.GetObject("bt_SelecionarPessoa.Image")));
            this.bt_SelecionarPessoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SelecionarPessoa.Location = new System.Drawing.Point(645, 475);
            this.bt_SelecionarPessoa.Name = "bt_SelecionarPessoa";
            this.bt_SelecionarPessoa.Size = new System.Drawing.Size(140, 50);
            this.bt_SelecionarPessoa.TabIndex = 21;
            this.bt_SelecionarPessoa.Text = "SELECIONAR";
            this.bt_SelecionarPessoa.UseVisualStyleBackColor = false;
            this.bt_SelecionarPessoa.Click += new System.EventHandler(this.bt_SelecionarPessoa_Click);
            // 
            // bt_Novo
            // 
            this.bt_Novo.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Novo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Novo.Image = global::Sistema.UI.Properties.Resources.bt_Adicionar;
            this.bt_Novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Novo.Location = new System.Drawing.Point(14, 475);
            this.bt_Novo.Name = "bt_Novo";
            this.bt_Novo.Size = new System.Drawing.Size(140, 50);
            this.bt_Novo.TabIndex = 10;
            this.bt_Novo.TabStop = false;
            this.bt_Novo.Text = "NOVO CADASTRO";
            this.bt_Novo.UseVisualStyleBackColor = false;
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 125;
            this.label2.Text = "Telefone";
            // 
            // txt_Telefone
            // 
            this.txt_Telefone.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Telefone.Location = new System.Drawing.Point(436, 135);
            this.txt_Telefone.MaxLength = 18;
            this.txt_Telefone.Name = "txt_Telefone";
            this.txt_Telefone.Size = new System.Drawing.Size(142, 22);
            this.txt_Telefone.TabIndex = 7;
            this.txt_Telefone.Tag = "T";
            this.txt_Telefone.Enter += new System.EventHandler(this.txt_CNPJ_CPF_Enter);
            this.txt_Telefone.Leave += new System.EventHandler(this.txt_CNPJ_CPF_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 125;
            this.label1.Text = "Logradouro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Logradouro
            // 
            this.txt_Logradouro.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Logradouro.Location = new System.Drawing.Point(14, 135);
            this.txt_Logradouro.MaxLength = 18;
            this.txt_Logradouro.Name = "txt_Logradouro";
            this.txt_Logradouro.Size = new System.Drawing.Size(415, 22);
            this.txt_Logradouro.TabIndex = 7;
            this.txt_Logradouro.Tag = "T";
            this.txt_Logradouro.Enter += new System.EventHandler(this.txt_CNPJ_CPF_Enter);
            this.txt_Logradouro.Leave += new System.EventHandler(this.txt_CNPJ_CPF_Leave);
            // 
            // UI_Pessoa_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(793, 529);
            this.Controls.Add(this.cb_TipoPessoa);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.bt_Novo);
            this.Controls.Add(this.bt_Localizar);
            this.Controls.Add(this.bt_SelecionarPessoa);
            this.Controls.Add(this.txt_Descricao);
            this.Controls.Add(this.Label30);
            this.Controls.Add(this.txt_NomeFantasia);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.txt_Logradouro);
            this.Controls.Add(this.txt_Telefone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CNPJ_CPF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label32);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.dg_PesquisaPessoa);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Pessoa_Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA PESSOA";
            this.Load += new System.EventHandler(this.UI_Pessoa_Consulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Pessoa_Consulta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Pessoa_Consulta_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_PesquisaPessoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Button bt_Localizar;
        internal System.Windows.Forms.Button bt_SelecionarPessoa;
        internal System.Windows.Forms.TextBox txt_Descricao;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.TextBox txt_NomeFantasia;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.TextBox txt_CNPJ_CPF;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.DataGridView dg_PesquisaPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Fantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Endereco;
        internal System.Windows.Forms.Button bt_Novo;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_Telefone;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Logradouro;
    }
}
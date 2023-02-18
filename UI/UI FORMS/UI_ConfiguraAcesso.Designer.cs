namespace Sistema.UI
{
    partial class UI_ConfiguraAcesso
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.col_Cod_Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TipoSistema = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_Servidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Relatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Acesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Configura = new System.Windows.Forms.GroupBox();
            this.ck_CFe = new System.Windows.Forms.CheckBox();
            this.ck_NFe = new System.Windows.Forms.CheckBox();
            this.ck_Controle = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ServidorAtualizacao = new System.Windows.Forms.TextBox();
            this.txt_CaminhoSistema = new System.Windows.Forms.TextBox();
            this.bt_Exclui = new System.Windows.Forms.Button();
            this.bt_Adiciona = new System.Windows.Forms.Button();
            this.bt_Grava = new System.Windows.Forms.Button();
            this.txt_Acesso = new System.Windows.Forms.TextBox();
            this.PesquisaCaminho = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.gb_Configura.SuspendLayout();
            this.SuspendLayout();
            // 
            // DG
            // 
            this.DG.AllowUserToAddRows = false;
            this.DG.AllowUserToDeleteRows = false;
            this.DG.AllowUserToResizeRows = false;
            this.DG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Cod_Empresa,
            this.col_ID,
            this.col_DescricaoEmpresa,
            this.col_TipoSistema,
            this.col_Servidor,
            this.col_Banco,
            this.col_Relatorio,
            this.col_Acesso});
            this.DG.Location = new System.Drawing.Point(5, 50);
            this.DG.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DG.MultiSelect = false;
            this.DG.Name = "DG";
            this.DG.RowHeadersVisible = false;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DG.Size = new System.Drawing.Size(903, 196);
            this.DG.TabIndex = 3;
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // col_Cod_Empresa
            // 
            this.col_Cod_Empresa.Frozen = true;
            this.col_Cod_Empresa.HeaderText = "Código Empresa";
            this.col_Cod_Empresa.Name = "col_Cod_Empresa";
            this.col_Cod_Empresa.Width = 70;
            // 
            // col_ID
            // 
            this.col_ID.Frozen = true;
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.Width = 40;
            // 
            // col_DescricaoEmpresa
            // 
            this.col_DescricaoEmpresa.Frozen = true;
            this.col_DescricaoEmpresa.HeaderText = "Descrição Empresa";
            this.col_DescricaoEmpresa.Name = "col_DescricaoEmpresa";
            this.col_DescricaoEmpresa.Width = 300;
            // 
            // col_TipoSistema
            // 
            this.col_TipoSistema.HeaderText = "Tipo Sistema";
            this.col_TipoSistema.Items.AddRange(new object[] {
            "COMERCIAL",
            "IMOBILIARIA"});
            this.col_TipoSistema.Name = "col_TipoSistema";
            // 
            // col_Servidor
            // 
            this.col_Servidor.HeaderText = "Servidor";
            this.col_Servidor.Name = "col_Servidor";
            // 
            // col_Banco
            // 
            this.col_Banco.HeaderText = "Banco";
            this.col_Banco.Name = "col_Banco";
            // 
            // col_Relatorio
            // 
            this.col_Relatorio.HeaderText = "Relatório";
            this.col_Relatorio.Name = "col_Relatorio";
            this.col_Relatorio.Width = 300;
            // 
            // col_Acesso
            // 
            dataGridViewCellStyle1.Format = "*";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Acesso.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Acesso.HeaderText = "Acesso";
            this.col_Acesso.Name = "col_Acesso";
            // 
            // gb_Configura
            // 
            this.gb_Configura.Controls.Add(this.ck_CFe);
            this.gb_Configura.Controls.Add(this.ck_NFe);
            this.gb_Configura.Controls.Add(this.ck_Controle);
            this.gb_Configura.Controls.Add(this.label2);
            this.gb_Configura.Controls.Add(this.label1);
            this.gb_Configura.Controls.Add(this.txt_ServidorAtualizacao);
            this.gb_Configura.Controls.Add(this.txt_CaminhoSistema);
            this.gb_Configura.Controls.Add(this.bt_Exclui);
            this.gb_Configura.Controls.Add(this.DG);
            this.gb_Configura.Controls.Add(this.bt_Adiciona);
            this.gb_Configura.Controls.Add(this.bt_Grava);
            this.gb_Configura.Enabled = false;
            this.gb_Configura.Location = new System.Drawing.Point(2, 37);
            this.gb_Configura.Name = "gb_Configura";
            this.gb_Configura.Size = new System.Drawing.Size(914, 351);
            this.gb_Configura.TabIndex = 1;
            this.gb_Configura.TabStop = false;
            this.gb_Configura.Visible = false;
            // 
            // ck_CFe
            // 
            this.ck_CFe.AutoSize = true;
            this.ck_CFe.Location = new System.Drawing.Point(303, 310);
            this.ck_CFe.Name = "ck_CFe";
            this.ck_CFe.Size = new System.Drawing.Size(169, 18);
            this.ck_CFe.TabIndex = 685;
            this.ck_CFe.Text = "Terminal Emissor de CF-e SAT";
            this.ck_CFe.UseVisualStyleBackColor = true;
            // 
            // ck_NFe
            // 
            this.ck_NFe.AutoSize = true;
            this.ck_NFe.Location = new System.Drawing.Point(303, 285);
            this.ck_NFe.Name = "ck_NFe";
            this.ck_NFe.Size = new System.Drawing.Size(147, 18);
            this.ck_NFe.TabIndex = 685;
            this.ck_NFe.Text = "Terminal Emissor de NF-e";
            this.ck_NFe.UseVisualStyleBackColor = true;
            // 
            // ck_Controle
            // 
            this.ck_Controle.AutoSize = true;
            this.ck_Controle.Location = new System.Drawing.Point(303, 261);
            this.ck_Controle.Name = "ck_Controle";
            this.ck_Controle.Size = new System.Drawing.Size(136, 18);
            this.ck_Controle.TabIndex = 685;
            this.ck_Controle.Text = "Controle de Atualização";
            this.ck_Controle.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 684;
            this.label2.Text = "Servidor Atualização";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 684;
            this.label1.Text = "Caminho Sistema";
            // 
            // txt_ServidorAtualizacao
            // 
            this.txt_ServidorAtualizacao.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ServidorAtualizacao.Location = new System.Drawing.Point(5, 320);
            this.txt_ServidorAtualizacao.MaxLength = 60;
            this.txt_ServidorAtualizacao.Name = "txt_ServidorAtualizacao";
            this.txt_ServidorAtualizacao.Size = new System.Drawing.Size(266, 20);
            this.txt_ServidorAtualizacao.TabIndex = 683;
            this.txt_ServidorAtualizacao.Tag = "T";
            this.txt_ServidorAtualizacao.DoubleClick += new System.EventHandler(this.txt_ServidorAtualizacao_DoubleClick);
            // 
            // txt_CaminhoSistema
            // 
            this.txt_CaminhoSistema.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CaminhoSistema.Location = new System.Drawing.Point(5, 274);
            this.txt_CaminhoSistema.MaxLength = 60;
            this.txt_CaminhoSistema.Name = "txt_CaminhoSistema";
            this.txt_CaminhoSistema.Size = new System.Drawing.Size(266, 20);
            this.txt_CaminhoSistema.TabIndex = 683;
            this.txt_CaminhoSistema.Tag = "T";
            this.txt_CaminhoSistema.DoubleClick += new System.EventHandler(this.txt_CaminhoSistema_DoubleClick);
            // 
            // bt_Exclui
            // 
            this.bt_Exclui.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Exclui.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exclui.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Exclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Exclui.Location = new System.Drawing.Point(779, 252);
            this.bt_Exclui.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Exclui.Name = "bt_Exclui";
            this.bt_Exclui.Size = new System.Drawing.Size(130, 32);
            this.bt_Exclui.TabIndex = 4;
            this.bt_Exclui.Text = "EXCLUIR";
            this.bt_Exclui.UseVisualStyleBackColor = false;
            this.bt_Exclui.Click += new System.EventHandler(this.bt_Exclui_Click);
            // 
            // bt_Adiciona
            // 
            this.bt_Adiciona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Adiciona.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adiciona.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adiciona.Image = global::Sistema.UI.Properties.Resources.bt_Adicionar;
            this.bt_Adiciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adiciona.Location = new System.Drawing.Point(5, 13);
            this.bt_Adiciona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Adiciona.Name = "bt_Adiciona";
            this.bt_Adiciona.Size = new System.Drawing.Size(130, 32);
            this.bt_Adiciona.TabIndex = 2;
            this.bt_Adiciona.Text = "ADICIONAR";
            this.bt_Adiciona.UseVisualStyleBackColor = false;
            this.bt_Adiciona.Click += new System.EventHandler(this.bt_Adiciona_Click);
            // 
            // bt_Grava
            // 
            this.bt_Grava.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Grava.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Grava.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Grava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Grava.Location = new System.Drawing.Point(778, 314);
            this.bt_Grava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Grava.Name = "bt_Grava";
            this.bt_Grava.Size = new System.Drawing.Size(130, 32);
            this.bt_Grava.TabIndex = 5;
            this.bt_Grava.Text = "GRAVAR";
            this.bt_Grava.UseVisualStyleBackColor = false;
            this.bt_Grava.Click += new System.EventHandler(this.bt_Grava_Click);
            // 
            // txt_Acesso
            // 
            this.txt_Acesso.Location = new System.Drawing.Point(2, 13);
            this.txt_Acesso.Name = "txt_Acesso";
            this.txt_Acesso.Size = new System.Drawing.Size(100, 20);
            this.txt_Acesso.TabIndex = 623;
            this.txt_Acesso.UseSystemPasswordChar = true;
            this.txt_Acesso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Acesso_KeyDown);
            // 
            // UI_ConfiguraAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(920, 391);
            this.Controls.Add(this.txt_Acesso);
            this.Controls.Add(this.gb_Configura);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_ConfiguraAcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração de Acesso";
            this.Load += new System.EventHandler(this.UI_ConfiguraAcesso_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_ConfiguraAcesso_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.gb_Configura.ResumeLayout(false);
            this.gb_Configura.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Button bt_Grava;
        private System.Windows.Forms.Button bt_Adiciona;
        private System.Windows.Forms.Button bt_Exclui;
        private System.Windows.Forms.GroupBox gb_Configura;
        private System.Windows.Forms.TextBox txt_Acesso;
        private System.Windows.Forms.FolderBrowserDialog PesquisaCaminho;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ServidorAtualizacao;
        internal System.Windows.Forms.TextBox txt_CaminhoSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cod_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoEmpresa;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_TipoSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Servidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Relatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Acesso;
        private System.Windows.Forms.CheckBox ck_Controle;
        private System.Windows.Forms.CheckBox ck_CFe;
        private System.Windows.Forms.CheckBox ck_NFe;
    }
}
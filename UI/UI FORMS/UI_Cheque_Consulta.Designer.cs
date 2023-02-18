namespace Sistema.UI
{
    partial class UI_Cheque_Consulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_Cheque = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Titular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Informação = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Seleciona = new System.Windows.Forms.Button();
            this.txt_ChequeP = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txt_ContaP = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txt_AgenciaP = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txt_BancoP = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.bt_Pesquisa = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Cheque)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Cheque
            // 
            this.dg_Cheque.AllowUserToAddRows = false;
            this.dg_Cheque.AllowUserToDeleteRows = false;
            this.dg_Cheque.AllowUserToResizeColumns = false;
            this.dg_Cheque.AllowUserToResizeRows = false;
            this.dg_Cheque.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Cheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Cheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Cheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Titular,
            this.col_Banco,
            this.col_Agencia,
            this.col_Conta,
            this.col_Cheque,
            this.col_Valor,
            this.col_Vencimento,
            this.col_DescricaoPessoa,
            this.col_Informação});
            this.dg_Cheque.Location = new System.Drawing.Point(3, 109);
            this.dg_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Cheque.MultiSelect = false;
            this.dg_Cheque.Name = "dg_Cheque";
            this.dg_Cheque.ReadOnly = true;
            this.dg_Cheque.RowHeadersVisible = false;
            this.dg_Cheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Cheque.Size = new System.Drawing.Size(904, 349);
            this.dg_Cheque.StandardTab = true;
            this.dg_Cheque.TabIndex = 70;
            this.dg_Cheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_Cheque_KeyDown);
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // col_Titular
            // 
            this.col_Titular.DataPropertyName = "Titular";
            this.col_Titular.HeaderText = "Titular";
            this.col_Titular.Name = "col_Titular";
            this.col_Titular.ReadOnly = true;
            this.col_Titular.Width = 230;
            // 
            // col_Banco
            // 
            this.col_Banco.DataPropertyName = "Banco";
            this.col_Banco.HeaderText = "Banco";
            this.col_Banco.Name = "col_Banco";
            this.col_Banco.ReadOnly = true;
            this.col_Banco.Width = 50;
            // 
            // col_Agencia
            // 
            this.col_Agencia.DataPropertyName = "Agencia";
            this.col_Agencia.HeaderText = "Agência";
            this.col_Agencia.Name = "col_Agencia";
            this.col_Agencia.ReadOnly = true;
            this.col_Agencia.Width = 50;
            // 
            // col_Conta
            // 
            this.col_Conta.DataPropertyName = "Conta";
            this.col_Conta.HeaderText = "Conta";
            this.col_Conta.Name = "col_Conta";
            this.col_Conta.ReadOnly = true;
            this.col_Conta.Width = 80;
            // 
            // col_Cheque
            // 
            this.col_Cheque.DataPropertyName = "Cheque";
            this.col_Cheque.HeaderText = "Cheque";
            this.col_Cheque.Name = "col_Cheque";
            this.col_Cheque.ReadOnly = true;
            this.col_Cheque.Width = 80;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Valor.HeaderText = "Valor";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Vencimento.HeaderText = "Vencimento";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.Width = 70;
            // 
            // col_DescricaoPessoa
            // 
            this.col_DescricaoPessoa.DataPropertyName = "DescricaoPessoa";
            this.col_DescricaoPessoa.HeaderText = "Pessoa";
            this.col_DescricaoPessoa.Name = "col_DescricaoPessoa";
            this.col_DescricaoPessoa.ReadOnly = true;
            this.col_DescricaoPessoa.Width = 230;
            // 
            // col_Informação
            // 
            this.col_Informação.DataPropertyName = "Informacao";
            this.col_Informação.HeaderText = "Informação";
            this.col_Informação.Name = "col_Informação";
            this.col_Informação.ReadOnly = true;
            this.col_Informação.Width = 300;
            // 
            // bt_Seleciona
            // 
            this.bt_Seleciona.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Seleciona.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Seleciona.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Seleciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Seleciona.Location = new System.Drawing.Point(755, 464);
            this.bt_Seleciona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Seleciona.Name = "bt_Seleciona";
            this.bt_Seleciona.Size = new System.Drawing.Size(152, 39);
            this.bt_Seleciona.TabIndex = 75;
            this.bt_Seleciona.Text = "SELECIONAR";
            this.bt_Seleciona.UseVisualStyleBackColor = false;
            this.bt_Seleciona.Click += new System.EventHandler(this.bt_Seleciona_Click);
            // 
            // txt_ChequeP
            // 
            this.txt_ChequeP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ChequeP.Location = new System.Drawing.Point(238, 81);
            this.txt_ChequeP.MaxLength = 10;
            this.txt_ChequeP.Name = "txt_ChequeP";
            this.txt_ChequeP.Size = new System.Drawing.Size(82, 20);
            this.txt_ChequeP.TabIndex = 59;
            this.txt_ChequeP.Tag = "";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(235, 64);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(54, 14);
            this.Label11.TabIndex = 69;
            this.Label11.Text = "Nº Cheque";
            // 
            // txt_ContaP
            // 
            this.txt_ContaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ContaP.Location = new System.Drawing.Point(132, 81);
            this.txt_ContaP.MaxLength = 10;
            this.txt_ContaP.Name = "txt_ContaP";
            this.txt_ContaP.Size = new System.Drawing.Size(100, 20);
            this.txt_ContaP.TabIndex = 58;
            this.txt_ContaP.Tag = "";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(129, 64);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(35, 14);
            this.Label13.TabIndex = 68;
            this.Label13.Text = "Conta";
            // 
            // txt_AgenciaP
            // 
            this.txt_AgenciaP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_AgenciaP.Location = new System.Drawing.Point(63, 81);
            this.txt_AgenciaP.MaxLength = 6;
            this.txt_AgenciaP.Name = "txt_AgenciaP";
            this.txt_AgenciaP.Size = new System.Drawing.Size(63, 20);
            this.txt_AgenciaP.TabIndex = 57;
            this.txt_AgenciaP.Tag = "";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(60, 64);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(44, 14);
            this.Label14.TabIndex = 67;
            this.Label14.Text = "Agência";
            // 
            // txt_BancoP
            // 
            this.txt_BancoP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_BancoP.Location = new System.Drawing.Point(12, 81);
            this.txt_BancoP.MaxLength = 3;
            this.txt_BancoP.Name = "txt_BancoP";
            this.txt_BancoP.Size = new System.Drawing.Size(45, 20);
            this.txt_BancoP.TabIndex = 56;
            this.txt_BancoP.Tag = "";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(9, 64);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(36, 14);
            this.Label15.TabIndex = 66;
            this.Label15.Text = "Banco";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(12, 27);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(171, 22);
            this.cb_TipoPessoa.TabIndex = 54;
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(419, 84);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(12, 14);
            this.Label25.TabIndex = 64;
            this.Label25.Text = "à";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(323, 64);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(101, 14);
            this.Label22.TabIndex = 65;
            this.Label22.Text = "Periodo Vencimento";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(436, 81);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(87, 20);
            this.mk_DataFinal.TabIndex = 63;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(326, 81);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(87, 20);
            this.mk_DataInicial.TabIndex = 60;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(9, 9);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(64, 14);
            this.Label20.TabIndex = 61;
            this.Label20.Text = "Tipo Pessoa";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(189, 9);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(52, 14);
            this.Label19.TabIndex = 62;
            this.Label19.Text = "Descrição";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(192, 27);
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(331, 22);
            this.cb_ID_Pessoa.TabIndex = 55;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Pesquisa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Pesquisa.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_Pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Pesquisa.Location = new System.Drawing.Point(545, 23);
            this.bt_Pesquisa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Pesquisa.Name = "bt_Pesquisa";
            this.bt_Pesquisa.Size = new System.Drawing.Size(152, 80);
            this.bt_Pesquisa.TabIndex = 65;
            this.bt_Pesquisa.Text = "PESQUISA (F5)";
            this.bt_Pesquisa.UseVisualStyleBackColor = false;
            this.bt_Pesquisa.Click += new System.EventHandler(this.bt_Pesquisa_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(250, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(113, 14);
            this.label27.TabIndex = 76;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // UI_Cheque_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(910, 508);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txt_ChequeP);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txt_ContaP);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txt_AgenciaP);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.txt_BancoP);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.cb_TipoPessoa);
            this.Controls.Add(this.Label25);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.mk_DataFinal);
            this.Controls.Add(this.mk_DataInicial);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.cb_ID_Pessoa);
            this.Controls.Add(this.bt_Pesquisa);
            this.Controls.Add(this.bt_Seleciona);
            this.Controls.Add(this.dg_Cheque);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Cheque_Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA CHEQUE";
            this.Load += new System.EventHandler(this.UI_Cheque_Consulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Cheque_Consulta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Cheque_Consulta_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Cheque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bt_Seleciona;
        internal System.Windows.Forms.DataGridView dg_Cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Titular;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Informação;
        internal System.Windows.Forms.TextBox txt_ChequeP;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txt_ContaP;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txt_AgenciaP;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txt_BancoP;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Button bt_Pesquisa;
        internal System.Windows.Forms.Label label27;
    }
}
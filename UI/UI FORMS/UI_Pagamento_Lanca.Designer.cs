namespace Sistema.UI
{
    partial class UI_Pagamento_Lanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pagamento_Lanca));
            this.gb_Cheque = new System.Windows.Forms.GroupBox();
            this.ck_ChequeTerceiro = new System.Windows.Forms.CheckBox();
            this.bt_PesquisaCheque = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_Banco = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_Banco = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_Agencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_Info_Cheque = new System.Windows.Forms.TextBox();
            this.txt_Conta = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txt_Cheque = new System.Windows.Forms.TextBox();
            this.txt_Pessoa_Cheque = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Pagamento = new System.Windows.Forms.ComboBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.dg_Pagamento = new System.Windows.Forms.DataGridView();
            this.col_Pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label12 = new System.Windows.Forms.Label();
            this.mk_Baixa = new System.Windows.Forms.MaskedTextBox();
            this.txt_Soma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Diferenca = new System.Windows.Forms.TextBox();
            this.lb_Troco = new System.Windows.Forms.Label();
            this.txt_ValorTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.cb_CaixaBaixa = new System.Windows.Forms.ComboBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.ck_Conciliado = new System.Windows.Forms.CheckBox();
            this.bt_Remover = new System.Windows.Forms.Button();
            this.bt_Concluido = new System.Windows.Forms.Button();
            this.bt_Adiciona = new System.Windows.Forms.Button();
            this.gb_Cheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pagamento)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Cheque
            // 
            this.gb_Cheque.Controls.Add(this.ck_ChequeTerceiro);
            this.gb_Cheque.Controls.Add(this.bt_PesquisaCheque);
            this.gb_Cheque.Controls.Add(this.label8);
            this.gb_Cheque.Controls.Add(this.cb_Banco);
            this.gb_Cheque.Controls.Add(this.Label3);
            this.gb_Cheque.Controls.Add(this.txt_Banco);
            this.gb_Cheque.Controls.Add(this.Label4);
            this.gb_Cheque.Controls.Add(this.txt_Agencia);
            this.gb_Cheque.Controls.Add(this.label1);
            this.gb_Cheque.Controls.Add(this.Label5);
            this.gb_Cheque.Controls.Add(this.txt_Info_Cheque);
            this.gb_Cheque.Controls.Add(this.txt_Conta);
            this.gb_Cheque.Controls.Add(this.Label10);
            this.gb_Cheque.Controls.Add(this.txt_Cheque);
            this.gb_Cheque.Controls.Add(this.txt_Pessoa_Cheque);
            this.gb_Cheque.Controls.Add(this.label2);
            this.gb_Cheque.Enabled = false;
            this.gb_Cheque.Location = new System.Drawing.Point(8, 144);
            this.gb_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_Cheque.Name = "gb_Cheque";
            this.gb_Cheque.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_Cheque.Size = new System.Drawing.Size(385, 222);
            this.gb_Cheque.TabIndex = 10;
            this.gb_Cheque.TabStop = false;
            this.gb_Cheque.Text = "Lançamento de Cheque";
            // 
            // ck_ChequeTerceiro
            // 
            this.ck_ChequeTerceiro.AutoSize = true;
            this.ck_ChequeTerceiro.Location = new System.Drawing.Point(7, 19);
            this.ck_ChequeTerceiro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ck_ChequeTerceiro.Name = "ck_ChequeTerceiro";
            this.ck_ChequeTerceiro.Size = new System.Drawing.Size(105, 17);
            this.ck_ChequeTerceiro.TabIndex = 11;
            this.ck_ChequeTerceiro.Text = "Cheque Terceiro";
            this.ck_ChequeTerceiro.UseVisualStyleBackColor = true;
            this.ck_ChequeTerceiro.CheckedChanged += new System.EventHandler(this.ck_ChequeTerceiro_CheckedChanged);
            // 
            // bt_PesquisaCheque
            // 
            this.bt_PesquisaCheque.Enabled = false;
            this.bt_PesquisaCheque.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaCheque.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaCheque.Location = new System.Drawing.Point(113, 16);
            this.bt_PesquisaCheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaCheque.Name = "bt_PesquisaCheque";
            this.bt_PesquisaCheque.Size = new System.Drawing.Size(81, 23);
            this.bt_PesquisaCheque.TabIndex = 12;
            this.bt_PesquisaCheque.Text = "Pesquisar";
            this.bt_PesquisaCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_PesquisaCheque.UseVisualStyleBackColor = true;
            this.bt_PesquisaCheque.Click += new System.EventHandler(this.bt_PesquisaCheque_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Banco";
            // 
            // cb_Banco
            // 
            this.cb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Banco.FormattingEnabled = true;
            this.cb_Banco.Location = new System.Drawing.Point(7, 57);
            this.cb_Banco.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_Banco.Name = "cb_Banco";
            this.cb_Banco.Size = new System.Drawing.Size(210, 21);
            this.cb_Banco.TabIndex = 13;
            this.cb_Banco.Tag = "T";
            this.cb_Banco.Leave += new System.EventHandler(this.cb_Banco_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 131);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 58;
            this.Label3.Text = "Banco";
            // 
            // txt_Banco
            // 
            this.txt_Banco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Banco.Location = new System.Drawing.Point(8, 148);
            this.txt_Banco.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Banco.MaxLength = 3;
            this.txt_Banco.Name = "txt_Banco";
            this.txt_Banco.Size = new System.Drawing.Size(45, 20);
            this.txt_Banco.TabIndex = 15;
            this.txt_Banco.Tag = "T";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(56, 131);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 61;
            this.Label4.Text = "Agência";
            // 
            // txt_Agencia
            // 
            this.txt_Agencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Agencia.Location = new System.Drawing.Point(60, 148);
            this.txt_Agencia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Agencia.MaxLength = 6;
            this.txt_Agencia.Name = "txt_Agencia";
            this.txt_Agencia.Size = new System.Drawing.Size(63, 20);
            this.txt_Agencia.TabIndex = 16;
            this.txt_Agencia.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Informação Cheque";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(126, 131);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 60;
            this.Label5.Text = "Conta";
            // 
            // txt_Info_Cheque
            // 
            this.txt_Info_Cheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Info_Cheque.Location = new System.Drawing.Point(9, 195);
            this.txt_Info_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Info_Cheque.MaxLength = 60;
            this.txt_Info_Cheque.Name = "txt_Info_Cheque";
            this.txt_Info_Cheque.Size = new System.Drawing.Size(367, 20);
            this.txt_Info_Cheque.TabIndex = 22;
            this.txt_Info_Cheque.Tag = "T";
            // 
            // txt_Conta
            // 
            this.txt_Conta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Conta.Location = new System.Drawing.Point(128, 148);
            this.txt_Conta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Conta.MaxLength = 15;
            this.txt_Conta.Name = "txt_Conta";
            this.txt_Conta.Size = new System.Drawing.Size(135, 20);
            this.txt_Conta.TabIndex = 20;
            this.txt_Conta.Tag = "T";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(264, 131);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(59, 13);
            this.Label10.TabIndex = 59;
            this.Label10.Text = "Nº Cheque";
            // 
            // txt_Cheque
            // 
            this.txt_Cheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Cheque.Location = new System.Drawing.Point(267, 148);
            this.txt_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Cheque.MaxLength = 15;
            this.txt_Cheque.Name = "txt_Cheque";
            this.txt_Cheque.Size = new System.Drawing.Size(109, 20);
            this.txt_Cheque.TabIndex = 21;
            this.txt_Cheque.Tag = "T";
            // 
            // txt_Pessoa_Cheque
            // 
            this.txt_Pessoa_Cheque.BackColor = System.Drawing.Color.White;
            this.txt_Pessoa_Cheque.Location = new System.Drawing.Point(8, 101);
            this.txt_Pessoa_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Pessoa_Cheque.MaxLength = 200;
            this.txt_Pessoa_Cheque.Name = "txt_Pessoa_Cheque";
            this.txt_Pessoa_Cheque.ReadOnly = true;
            this.txt_Pessoa_Cheque.Size = new System.Drawing.Size(368, 20);
            this.txt_Pessoa_Cheque.TabIndex = 14;
            this.txt_Pessoa_Cheque.Tag = "T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Pessoa";
            // 
            // cb_Pagamento
            // 
            this.cb_Pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Pagamento.FormattingEnabled = true;
            this.cb_Pagamento.Location = new System.Drawing.Point(9, 64);
            this.cb_Pagamento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_Pagamento.Name = "cb_Pagamento";
            this.cb_Pagamento.Size = new System.Drawing.Size(210, 21);
            this.cb_Pagamento.TabIndex = 2;
            this.cb_Pagamento.Tag = "T";
            this.cb_Pagamento.SelectedValueChanged += new System.EventHandler(this.cb_Pagamento_SelectedValueChanged);
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(5, 47);
            this.Label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(61, 13);
            this.Label33.TabIndex = 108;
            this.Label33.Text = "Pagamento";
            // 
            // dg_Pagamento
            // 
            this.dg_Pagamento.AllowUserToAddRows = false;
            this.dg_Pagamento.AllowUserToDeleteRows = false;
            this.dg_Pagamento.AllowUserToResizeColumns = false;
            this.dg_Pagamento.AllowUserToResizeRows = false;
            this.dg_Pagamento.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dg_Pagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Pagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Pagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Pagamento,
            this.col_Valor,
            this.col_Cheque,
            this.col_Vencimento});
            this.dg_Pagamento.Location = new System.Drawing.Point(405, 51);
            this.dg_Pagamento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Pagamento.MultiSelect = false;
            this.dg_Pagamento.Name = "dg_Pagamento";
            this.dg_Pagamento.ReadOnly = true;
            this.dg_Pagamento.RowHeadersVisible = false;
            this.dg_Pagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Pagamento.Size = new System.Drawing.Size(351, 244);
            this.dg_Pagamento.StandardTab = true;
            this.dg_Pagamento.TabIndex = 31;
            // 
            // col_Pagamento
            // 
            this.col_Pagamento.DataPropertyName = "Pagamento";
            this.col_Pagamento.HeaderText = "Pagamento";
            this.col_Pagamento.Name = "col_Pagamento";
            this.col_Pagamento.ReadOnly = true;
            this.col_Pagamento.Width = 250;
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
            this.col_Valor.Width = 95;
            // 
            // col_Cheque
            // 
            this.col_Cheque.DataPropertyName = "Cheque";
            this.col_Cheque.HeaderText = "Nº Cheque";
            this.col_Cheque.Name = "col_Cheque";
            this.col_Cheque.ReadOnly = true;
            this.col_Cheque.Width = 120;
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
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(6, 88);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(59, 13);
            this.Label12.TabIndex = 107;
            this.Label12.Text = "Data Baixa";
            // 
            // mk_Baixa
            // 
            this.mk_Baixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mk_Baixa.Location = new System.Drawing.Point(9, 107);
            this.mk_Baixa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Baixa.Mask = "00/00/0000";
            this.mk_Baixa.Name = "mk_Baixa";
            this.mk_Baixa.Size = new System.Drawing.Size(80, 20);
            this.mk_Baixa.TabIndex = 3;
            this.mk_Baixa.Tag = "T";
            this.mk_Baixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Baixa.ValidatingType = typeof(System.DateTime);
            // 
            // txt_Soma
            // 
            this.txt_Soma.BackColor = System.Drawing.Color.White;
            this.txt_Soma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Soma.Location = new System.Drawing.Point(405, 323);
            this.txt_Soma.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Soma.MaxLength = 10;
            this.txt_Soma.Name = "txt_Soma";
            this.txt_Soma.ReadOnly = true;
            this.txt_Soma.Size = new System.Drawing.Size(132, 26);
            this.txt_Soma.TabIndex = 99;
            this.txt_Soma.TabStop = false;
            this.txt_Soma.Tag = "T";
            this.txt_Soma.Text = "0,00";
            this.txt_Soma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 305);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "Soma dos Pagamentos";
            // 
            // txt_Diferenca
            // 
            this.txt_Diferenca.BackColor = System.Drawing.Color.White;
            this.txt_Diferenca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Diferenca.Location = new System.Drawing.Point(405, 375);
            this.txt_Diferenca.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Diferenca.MaxLength = 10;
            this.txt_Diferenca.Name = "txt_Diferenca";
            this.txt_Diferenca.ReadOnly = true;
            this.txt_Diferenca.Size = new System.Drawing.Size(132, 26);
            this.txt_Diferenca.TabIndex = 100;
            this.txt_Diferenca.TabStop = false;
            this.txt_Diferenca.Tag = "T";
            this.txt_Diferenca.Text = "0,00";
            this.txt_Diferenca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Troco
            // 
            this.lb_Troco.AutoSize = true;
            this.lb_Troco.Location = new System.Drawing.Point(402, 357);
            this.lb_Troco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Troco.Name = "lb_Troco";
            this.lb_Troco.Size = new System.Drawing.Size(53, 13);
            this.lb_Troco.TabIndex = 104;
            this.lb_Troco.Text = "Diferença";
            // 
            // txt_ValorTotal
            // 
            this.txt_ValorTotal.BackColor = System.Drawing.Color.White;
            this.txt_ValorTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorTotal.Location = new System.Drawing.Point(405, 19);
            this.txt_ValorTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ValorTotal.MaxLength = 10;
            this.txt_ValorTotal.Name = "txt_ValorTotal";
            this.txt_ValorTotal.ReadOnly = true;
            this.txt_ValorTotal.Size = new System.Drawing.Size(132, 26);
            this.txt_ValorTotal.TabIndex = 96;
            this.txt_ValorTotal.TabStop = false;
            this.txt_ValorTotal.Tag = "T";
            this.txt_ValorTotal.Text = "0,00";
            this.txt_ValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(402, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 105;
            this.label11.Text = "Valor Total";
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Valor.Location = new System.Drawing.Point(93, 107);
            this.txt_Valor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Valor.MaxLength = 12;
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(87, 20);
            this.txt_Valor.TabIndex = 5;
            this.txt_Valor.Tag = "T";
            this.txt_Valor.Text = "0,00";
            this.txt_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(90, 88);
            this.Label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(31, 13);
            this.Label9.TabIndex = 106;
            this.Label9.Text = "Valor";
            // 
            // cb_CaixaBaixa
            // 
            this.cb_CaixaBaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CaixaBaixa.FormattingEnabled = true;
            this.cb_CaixaBaixa.Location = new System.Drawing.Point(8, 23);
            this.cb_CaixaBaixa.Name = "cb_CaixaBaixa";
            this.cb_CaixaBaixa.Size = new System.Drawing.Size(269, 21);
            this.cb_CaixaBaixa.TabIndex = 1;
            this.cb_CaixaBaixa.Tag = "T";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(5, 6);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(33, 13);
            this.Label31.TabIndex = 113;
            this.Label31.Text = "Caixa";
            // 
            // ck_Conciliado
            // 
            this.ck_Conciliado.AutoSize = true;
            this.ck_Conciliado.Location = new System.Drawing.Point(184, 109);
            this.ck_Conciliado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ck_Conciliado.Name = "ck_Conciliado";
            this.ck_Conciliado.Size = new System.Drawing.Size(128, 17);
            this.ck_Conciliado.TabIndex = 7;
            this.ck_Conciliado.Text = "Conciliar Lançamento";
            this.ck_Conciliado.UseVisualStyleBackColor = true;
            // 
            // bt_Remover
            // 
            this.bt_Remover.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Remover.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Remover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Remover.Location = new System.Drawing.Point(632, 301);
            this.bt_Remover.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Remover.Name = "bt_Remover";
            this.bt_Remover.Size = new System.Drawing.Size(124, 28);
            this.bt_Remover.TabIndex = 50;
            this.bt_Remover.TabStop = false;
            this.bt_Remover.Text = "REMOVER";
            this.bt_Remover.UseVisualStyleBackColor = true;
            this.bt_Remover.Click += new System.EventHandler(this.bt_Remover_Click);
            // 
            // bt_Concluido
            // 
            this.bt_Concluido.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Concluido.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Concluido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Concluido.Location = new System.Drawing.Point(632, 375);
            this.bt_Concluido.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Concluido.Name = "bt_Concluido";
            this.bt_Concluido.Size = new System.Drawing.Size(124, 28);
            this.bt_Concluido.TabIndex = 40;
            this.bt_Concluido.Text = "CONCLUÍDO";
            this.bt_Concluido.UseVisualStyleBackColor = true;
            this.bt_Concluido.Click += new System.EventHandler(this.bt_Concluido_Click);
            // 
            // bt_Adiciona
            // 
            this.bt_Adiciona.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adiciona.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Adiciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adiciona.Location = new System.Drawing.Point(216, 373);
            this.bt_Adiciona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Adiciona.Name = "bt_Adiciona";
            this.bt_Adiciona.Size = new System.Drawing.Size(177, 28);
            this.bt_Adiciona.TabIndex = 30;
            this.bt_Adiciona.Text = "ADICIONA PAGAMENTO";
            this.bt_Adiciona.UseVisualStyleBackColor = true;
            this.bt_Adiciona.Click += new System.EventHandler(this.bt_Adiciona_Click);
            // 
            // UI_Pagamento_Lanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(763, 409);
            this.Controls.Add(this.cb_CaixaBaixa);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.ck_Conciliado);
            this.Controls.Add(this.gb_Cheque);
            this.Controls.Add(this.cb_Pagamento);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.bt_Remover);
            this.Controls.Add(this.bt_Concluido);
            this.Controls.Add(this.bt_Adiciona);
            this.Controls.Add(this.dg_Pagamento);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.mk_Baixa);
            this.Controls.Add(this.txt_Soma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Diferenca);
            this.Controls.Add(this.lb_Troco);
            this.Controls.Add(this.txt_ValorTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Valor);
            this.Controls.Add(this.Label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_Pagamento_Lanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANÇAMENTO";
            this.Load += new System.EventHandler(this.UI_Pagamento_Lanca_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Pagamento_Lanca_KeyPress);
            this.gb_Cheque.ResumeLayout(false);
            this.gb_Cheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pagamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cheque;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_Banco;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_Agencia;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_Info_Cheque;
        internal System.Windows.Forms.TextBox txt_Conta;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txt_Cheque;
        internal System.Windows.Forms.TextBox txt_Pessoa_Cheque;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cb_Pagamento;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Button bt_Remover;
        internal System.Windows.Forms.Button bt_Concluido;
        internal System.Windows.Forms.Button bt_Adiciona;
        internal System.Windows.Forms.DataGridView dg_Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.MaskedTextBox mk_Baixa;
        internal System.Windows.Forms.TextBox txt_Soma;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_Diferenca;
        internal System.Windows.Forms.Label lb_Troco;
        internal System.Windows.Forms.TextBox txt_ValorTotal;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.CheckBox ck_ChequeTerceiro;
        internal System.Windows.Forms.Button bt_PesquisaCheque;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cb_Banco;
        internal System.Windows.Forms.ComboBox cb_CaixaBaixa;
        internal System.Windows.Forms.Label Label31;
        private System.Windows.Forms.CheckBox ck_Conciliado;
    }
}
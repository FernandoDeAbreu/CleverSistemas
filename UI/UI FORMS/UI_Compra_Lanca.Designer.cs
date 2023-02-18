namespace Sistema.UI
{
    partial class UI_Compra_Lanca
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Cheque = new System.Windows.Forms.GroupBox();
            this.ck_ChequeTerceiro = new System.Windows.Forms.CheckBox();
            this.bt_PesquisaCheque = new System.Windows.Forms.Button();
            this.cb_Banco = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.mk_DataCheque = new System.Windows.Forms.MaskedTextBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_Pagto_Efetuado = new System.Windows.Forms.DataGridView();
            this.col_Pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label12 = new System.Windows.Forms.Label();
            this.mk_Vencimento = new System.Windows.Forms.MaskedTextBox();
            this.txt_Soma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Diferenca = new System.Windows.Forms.TextBox();
            this.lb_Troco = new System.Windows.Forms.Label();
            this.txt_ValorTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.bt_Concluido = new System.Windows.Forms.Button();
            this.bt_Adiciona = new System.Windows.Forms.Button();
            this.bt_Remover = new System.Windows.Forms.Button();
            this.lstv_Pagamento = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_CaixaBaixa = new System.Windows.Forms.ComboBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.ck_Conciliado = new System.Windows.Forms.CheckBox();
            this.lb_Conciliado = new System.Windows.Forms.Label();
            this.cb_Parcelamento = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ParcelamentoManual = new System.Windows.Forms.TextBox();
            this.txt_Parcela = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gb_Cheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pagto_Efetuado)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "COD.";
            // 
            // gb_Cheque
            // 
            this.gb_Cheque.Controls.Add(this.ck_ChequeTerceiro);
            this.gb_Cheque.Controls.Add(this.bt_PesquisaCheque);
            this.gb_Cheque.Controls.Add(this.cb_Banco);
            this.gb_Cheque.Controls.Add(this.label15);
            this.gb_Cheque.Controls.Add(this.mk_DataCheque);
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
            this.gb_Cheque.Controls.Add(this.label14);
            this.gb_Cheque.Controls.Add(this.label2);
            this.gb_Cheque.Enabled = false;
            this.gb_Cheque.Location = new System.Drawing.Point(524, 13);
            this.gb_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_Cheque.Name = "gb_Cheque";
            this.gb_Cheque.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_Cheque.Size = new System.Drawing.Size(314, 239);
            this.gb_Cheque.TabIndex = 10;
            this.gb_Cheque.TabStop = false;
            this.gb_Cheque.Text = "Lançamento de Cheque";
            // 
            // ck_ChequeTerceiro
            // 
            this.ck_ChequeTerceiro.AutoSize = true;
            this.ck_ChequeTerceiro.Location = new System.Drawing.Point(9, 24);
            this.ck_ChequeTerceiro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ck_ChequeTerceiro.Name = "ck_ChequeTerceiro";
            this.ck_ChequeTerceiro.Size = new System.Drawing.Size(101, 18);
            this.ck_ChequeTerceiro.TabIndex = 11;
            this.ck_ChequeTerceiro.Text = "Cheque Terceiro";
            this.ck_ChequeTerceiro.UseVisualStyleBackColor = true;
            this.ck_ChequeTerceiro.CheckedChanged += new System.EventHandler(this.ck_ChequeTerceiro_CheckedChanged);
            // 
            // bt_PesquisaCheque
            // 
            this.bt_PesquisaCheque.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaCheque.Enabled = false;
            this.bt_PesquisaCheque.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaCheque.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaCheque.Location = new System.Drawing.Point(121, 18);
            this.bt_PesquisaCheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_PesquisaCheque.Name = "bt_PesquisaCheque";
            this.bt_PesquisaCheque.Size = new System.Drawing.Size(90, 32);
            this.bt_PesquisaCheque.TabIndex = 12;
            this.bt_PesquisaCheque.Text = "PESQUISA";
            this.bt_PesquisaCheque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_PesquisaCheque.UseVisualStyleBackColor = false;
            this.bt_PesquisaCheque.Click += new System.EventHandler(this.bt_PesquisaCheque_Click);
            // 
            // cb_Banco
            // 
            this.cb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Banco.FormattingEnabled = true;
            this.cb_Banco.Location = new System.Drawing.Point(7, 68);
            this.cb_Banco.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_Banco.Name = "cb_Banco";
            this.cb_Banco.Size = new System.Drawing.Size(210, 22);
            this.cb_Banco.TabIndex = 13;
            this.cb_Banco.Tag = "T";
            this.cb_Banco.Leave += new System.EventHandler(this.cb_Banco_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 187);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 109;
            this.label15.Text = "Cheque para";
            // 
            // mk_DataCheque
            // 
            this.mk_DataCheque.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataCheque.Location = new System.Drawing.Point(224, 208);
            this.mk_DataCheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_DataCheque.Mask = "00/00/0000";
            this.mk_DataCheque.Name = "mk_DataCheque";
            this.mk_DataCheque.Size = new System.Drawing.Size(80, 20);
            this.mk_DataCheque.TabIndex = 20;
            this.mk_DataCheque.Tag = "T";
            this.mk_DataCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataCheque.ValidatingType = typeof(System.DateTime);
            this.mk_DataCheque.Leave += new System.EventHandler(this.mk_DataCheque_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 143);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 14);
            this.Label3.TabIndex = 58;
            this.Label3.Text = "Banco";
            // 
            // txt_Banco
            // 
            this.txt_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Banco.Location = new System.Drawing.Point(8, 160);
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
            this.Label4.Location = new System.Drawing.Point(56, 143);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(44, 14);
            this.Label4.TabIndex = 61;
            this.Label4.Text = "Agência";
            // 
            // txt_Agencia
            // 
            this.txt_Agencia.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Agencia.Location = new System.Drawing.Point(60, 160);
            this.txt_Agencia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Agencia.MaxLength = 6;
            this.txt_Agencia.Name = "txt_Agencia";
            this.txt_Agencia.Size = new System.Drawing.Size(54, 20);
            this.txt_Agencia.TabIndex = 16;
            this.txt_Agencia.Tag = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 60;
            this.label1.Text = "Informação Cheque";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(116, 143);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 14);
            this.Label5.TabIndex = 60;
            this.Label5.Text = "Conta";
            // 
            // txt_Info_Cheque
            // 
            this.txt_Info_Cheque.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Info_Cheque.Location = new System.Drawing.Point(9, 208);
            this.txt_Info_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Info_Cheque.MaxLength = 200;
            this.txt_Info_Cheque.Name = "txt_Info_Cheque";
            this.txt_Info_Cheque.Size = new System.Drawing.Size(211, 20);
            this.txt_Info_Cheque.TabIndex = 19;
            this.txt_Info_Cheque.Tag = "T";
            // 
            // txt_Conta
            // 
            this.txt_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Conta.Location = new System.Drawing.Point(118, 160);
            this.txt_Conta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Conta.MaxLength = 15;
            this.txt_Conta.Name = "txt_Conta";
            this.txt_Conta.Size = new System.Drawing.Size(102, 20);
            this.txt_Conta.TabIndex = 17;
            this.txt_Conta.Tag = "T";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(221, 143);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(54, 14);
            this.Label10.TabIndex = 59;
            this.Label10.Text = "Nº Cheque";
            // 
            // txt_Cheque
            // 
            this.txt_Cheque.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Cheque.Location = new System.Drawing.Point(224, 160);
            this.txt_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Cheque.MaxLength = 10;
            this.txt_Cheque.Name = "txt_Cheque";
            this.txt_Cheque.Size = new System.Drawing.Size(80, 20);
            this.txt_Cheque.TabIndex = 18;
            this.txt_Cheque.Tag = "T";
            // 
            // txt_Pessoa_Cheque
            // 
            this.txt_Pessoa_Cheque.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Pessoa_Cheque.Location = new System.Drawing.Point(8, 113);
            this.txt_Pessoa_Cheque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Pessoa_Cheque.MaxLength = 200;
            this.txt_Pessoa_Cheque.Name = "txt_Pessoa_Cheque";
            this.txt_Pessoa_Cheque.ReadOnly = true;
            this.txt_Pessoa_Cheque.Size = new System.Drawing.Size(296, 20);
            this.txt_Pessoa_Cheque.TabIndex = 14;
            this.txt_Pessoa_Cheque.Tag = "T";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 51);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 14);
            this.label14.TabIndex = 58;
            this.label14.Text = "Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "Pessoa";
            // 
            // dg_Pagto_Efetuado
            // 
            this.dg_Pagto_Efetuado.AllowUserToAddRows = false;
            this.dg_Pagto_Efetuado.AllowUserToDeleteRows = false;
            this.dg_Pagto_Efetuado.AllowUserToResizeColumns = false;
            this.dg_Pagto_Efetuado.AllowUserToResizeRows = false;
            this.dg_Pagto_Efetuado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Pagto_Efetuado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Pagto_Efetuado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Pagto_Efetuado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Pagamento,
            this.col_Valor,
            this.col_Vencimento,
            this.col_Cheque});
            this.dg_Pagto_Efetuado.Location = new System.Drawing.Point(269, 303);
            this.dg_Pagto_Efetuado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dg_Pagto_Efetuado.MultiSelect = false;
            this.dg_Pagto_Efetuado.Name = "dg_Pagto_Efetuado";
            this.dg_Pagto_Efetuado.ReadOnly = true;
            this.dg_Pagto_Efetuado.RowHeadersVisible = false;
            this.dg_Pagto_Efetuado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Pagto_Efetuado.Size = new System.Drawing.Size(458, 164);
            this.dg_Pagto_Efetuado.StandardTab = true;
            this.dg_Pagto_Efetuado.TabIndex = 22;
            // 
            // col_Pagamento
            // 
            this.col_Pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Pagamento.DataPropertyName = "Pagamento";
            this.col_Pagamento.HeaderText = "RESUMO PAGAMENTO";
            this.col_Pagamento.Name = "col_Pagamento";
            this.col_Pagamento.ReadOnly = true;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Valor.HeaderText = "VALOR";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 70;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Vencimento.HeaderText = "VENCIMENTO";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.Width = 80;
            // 
            // col_Cheque
            // 
            this.col_Cheque.DataPropertyName = "Cheque";
            this.col_Cheque.HeaderText = "Nº CHEQUE";
            this.col_Cheque.Name = "col_Cheque";
            this.col_Cheque.ReadOnly = true;
            this.col_Cheque.Width = 90;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(268, 61);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(65, 14);
            this.Label12.TabIndex = 88;
            this.Label12.Text = "Lançamento";
            // 
            // mk_Vencimento
            // 
            this.mk_Vencimento.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Vencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk_Vencimento.Location = new System.Drawing.Point(268, 81);
            this.mk_Vencimento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Vencimento.Mask = "00/00/0000";
            this.mk_Vencimento.Name = "mk_Vencimento";
            this.mk_Vencimento.Size = new System.Drawing.Size(94, 26);
            this.mk_Vencimento.TabIndex = 5;
            this.mk_Vencimento.Tag = "T";
            this.mk_Vencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Vencimento.ValidatingType = typeof(System.DateTime);
            this.mk_Vencimento.Leave += new System.EventHandler(this.mk_Vencimento_Leave);
            // 
            // txt_Soma
            // 
            this.txt_Soma.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Soma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Soma.Location = new System.Drawing.Point(734, 382);
            this.txt_Soma.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Soma.MaxLength = 10;
            this.txt_Soma.Name = "txt_Soma";
            this.txt_Soma.ReadOnly = true;
            this.txt_Soma.Size = new System.Drawing.Size(104, 26);
            this.txt_Soma.TabIndex = 23;
            this.txt_Soma.TabStop = false;
            this.txt_Soma.Tag = "T";
            this.txt_Soma.Text = "0,00";
            this.txt_Soma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(731, 365);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 14);
            this.label6.TabIndex = 84;
            this.label6.Text = "SOMA PAGAMENTOS";
            // 
            // txt_Diferenca
            // 
            this.txt_Diferenca.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Diferenca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Diferenca.Location = new System.Drawing.Point(734, 436);
            this.txt_Diferenca.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Diferenca.MaxLength = 10;
            this.txt_Diferenca.Name = "txt_Diferenca";
            this.txt_Diferenca.ReadOnly = true;
            this.txt_Diferenca.Size = new System.Drawing.Size(104, 26);
            this.txt_Diferenca.TabIndex = 23;
            this.txt_Diferenca.TabStop = false;
            this.txt_Diferenca.Tag = "T";
            this.txt_Diferenca.Text = "0,00";
            this.txt_Diferenca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Troco
            // 
            this.lb_Troco.AutoSize = true;
            this.lb_Troco.Location = new System.Drawing.Point(731, 419);
            this.lb_Troco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Troco.Name = "lb_Troco";
            this.lb_Troco.Size = new System.Drawing.Size(69, 14);
            this.lb_Troco.TabIndex = 85;
            this.lb_Troco.Text = "DIFERENÇA";
            // 
            // txt_ValorTotal
            // 
            this.txt_ValorTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorTotal.Location = new System.Drawing.Point(734, 314);
            this.txt_ValorTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ValorTotal.MaxLength = 10;
            this.txt_ValorTotal.Name = "txt_ValorTotal";
            this.txt_ValorTotal.ReadOnly = true;
            this.txt_ValorTotal.Size = new System.Drawing.Size(104, 26);
            this.txt_ValorTotal.TabIndex = 21;
            this.txt_ValorTotal.TabStop = false;
            this.txt_ValorTotal.Tag = "T";
            this.txt_ValorTotal.Text = "0,00";
            this.txt_ValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(731, 297);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 14);
            this.label11.TabIndex = 86;
            this.label11.Text = "TOTAL";
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.Location = new System.Drawing.Point(367, 81);
            this.txt_Valor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Valor.MaxLength = 12;
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(144, 26);
            this.txt_Valor.TabIndex = 6;
            this.txt_Valor.Tag = "T";
            this.txt_Valor.Text = "0,00";
            this.txt_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(364, 61);
            this.Label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(31, 14);
            this.Label9.TabIndex = 87;
            this.Label9.Text = "Valor";
            // 
            // bt_Concluido
            // 
            this.bt_Concluido.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Concluido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Concluido.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Concluido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Concluido.Location = new System.Drawing.Point(685, 476);
            this.bt_Concluido.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Concluido.Name = "bt_Concluido";
            this.bt_Concluido.Size = new System.Drawing.Size(153, 41);
            this.bt_Concluido.TabIndex = 25;
            this.bt_Concluido.Text = "CONCLUÍDO";
            this.bt_Concluido.UseVisualStyleBackColor = false;
            this.bt_Concluido.Click += new System.EventHandler(this.bt_Concluido_Click);
            // 
            // bt_Adiciona
            // 
            this.bt_Adiciona.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adiciona.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adiciona.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Adiciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adiciona.Location = new System.Drawing.Point(269, 258);
            this.bt_Adiciona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Adiciona.Name = "bt_Adiciona";
            this.bt_Adiciona.Size = new System.Drawing.Size(569, 37);
            this.bt_Adiciona.TabIndex = 21;
            this.bt_Adiciona.Text = "ADICIONA PAGAMENTO";
            this.bt_Adiciona.UseVisualStyleBackColor = false;
            this.bt_Adiciona.Click += new System.EventHandler(this.bt_Adiciona_Click);
            // 
            // bt_Remover
            // 
            this.bt_Remover.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Remover.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Remover.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Remover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Remover.Location = new System.Drawing.Point(269, 476);
            this.bt_Remover.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Remover.Name = "bt_Remover";
            this.bt_Remover.Size = new System.Drawing.Size(124, 32);
            this.bt_Remover.TabIndex = 25;
            this.bt_Remover.TabStop = false;
            this.bt_Remover.Text = "REMOVER";
            this.bt_Remover.UseVisualStyleBackColor = false;
            this.bt_Remover.Click += new System.EventHandler(this.bt_Remover_Click);
            // 
            // lstv_Pagamento
            // 
            this.lstv_Pagamento.BackColor = System.Drawing.SystemColors.Control;
            this.lstv_Pagamento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            this.columnHeader2});
            this.lstv_Pagamento.FullRowSelect = true;
            this.lstv_Pagamento.GridLines = true;
            this.lstv_Pagamento.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstv_Pagamento.HideSelection = false;
            this.lstv_Pagamento.Location = new System.Drawing.Point(7, 62);
            this.lstv_Pagamento.MultiSelect = false;
            this.lstv_Pagamento.Name = "lstv_Pagamento";
            this.lstv_Pagamento.Size = new System.Drawing.Size(254, 454);
            this.lstv_Pagamento.TabIndex = 2;
            this.lstv_Pagamento.UseCompatibleStateImageBehavior = false;
            this.lstv_Pagamento.View = System.Windows.Forms.View.Details;
            this.lstv_Pagamento.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstv_Pagamento_ItemSelectionChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PAGAMENTO";
            this.columnHeader2.Width = 190;
            // 
            // cb_CaixaBaixa
            // 
            this.cb_CaixaBaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CaixaBaixa.FormattingEnabled = true;
            this.cb_CaixaBaixa.Location = new System.Drawing.Point(7, 31);
            this.cb_CaixaBaixa.Name = "cb_CaixaBaixa";
            this.cb_CaixaBaixa.Size = new System.Drawing.Size(254, 22);
            this.cb_CaixaBaixa.TabIndex = 1;
            this.cb_CaixaBaixa.Tag = "T";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(4, 13);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(42, 14);
            this.Label31.TabIndex = 115;
            this.Label31.Text = "CAIXA";
            // 
            // ck_Conciliado
            // 
            this.ck_Conciliado.AutoSize = true;
            this.ck_Conciliado.FlatAppearance.BorderSize = 4;
            this.ck_Conciliado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_Conciliado.Location = new System.Drawing.Point(463, 137);
            this.ck_Conciliado.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ck_Conciliado.Name = "ck_Conciliado";
            this.ck_Conciliado.Size = new System.Drawing.Size(15, 14);
            this.ck_Conciliado.TabIndex = 7;
            this.ck_Conciliado.UseVisualStyleBackColor = true;
            this.ck_Conciliado.Enter += new System.EventHandler(this.ck_Conciliado_Enter);
            this.ck_Conciliado.Leave += new System.EventHandler(this.ck_Conciliado_Leave);
            // 
            // lb_Conciliado
            // 
            this.lb_Conciliado.AutoSize = true;
            this.lb_Conciliado.Location = new System.Drawing.Point(431, 155);
            this.lb_Conciliado.Name = "lb_Conciliado";
            this.lb_Conciliado.Size = new System.Drawing.Size(86, 28);
            this.lb_Conciliado.TabIndex = 117;
            this.lb_Conciliado.Text = "CONCILIAR\r\nLANÇAMENTO";
            this.lb_Conciliado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Parcelamento
            // 
            this.cb_Parcelamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Parcelamento.FormattingEnabled = true;
            this.cb_Parcelamento.Location = new System.Drawing.Point(268, 31);
            this.cb_Parcelamento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_Parcelamento.Name = "cb_Parcelamento";
            this.cb_Parcelamento.Size = new System.Drawing.Size(204, 22);
            this.cb_Parcelamento.TabIndex = 3;
            this.cb_Parcelamento.Tag = "T";
            this.cb_Parcelamento.SelectedValueChanged += new System.EventHandler(this.cb_Parcelamento_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(474, 13);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 14);
            this.label13.TabIndex = 120;
            this.label13.Text = "Parc.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 121;
            this.label7.Text = "Parcelamento";
            // 
            // txt_ParcelamentoManual
            // 
            this.txt_ParcelamentoManual.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ParcelamentoManual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ParcelamentoManual.Location = new System.Drawing.Point(477, 31);
            this.txt_ParcelamentoManual.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ParcelamentoManual.MaxLength = 12;
            this.txt_ParcelamentoManual.Name = "txt_ParcelamentoManual";
            this.txt_ParcelamentoManual.Size = new System.Drawing.Size(34, 22);
            this.txt_ParcelamentoManual.TabIndex = 4;
            this.txt_ParcelamentoManual.TabStop = false;
            this.txt_ParcelamentoManual.Tag = "T";
            this.txt_ParcelamentoManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ParcelamentoManual.Leave += new System.EventHandler(this.txt_ParcelamentoManual_Leave);
            // 
            // txt_Parcela
            // 
            this.txt_Parcela.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Parcela.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Parcela.Location = new System.Drawing.Point(268, 138);
            this.txt_Parcela.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Parcela.MaxLength = 12;
            this.txt_Parcela.Multiline = true;
            this.txt_Parcela.Name = "txt_Parcela";
            this.txt_Parcela.ReadOnly = true;
            this.txt_Parcela.Size = new System.Drawing.Size(144, 48);
            this.txt_Parcela.TabIndex = 122;
            this.txt_Parcela.TabStop = false;
            this.txt_Parcela.Tag = "T";
            this.txt_Parcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 123;
            this.label8.Text = "Parcela";
            // 
            // UI_Compra_Lanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(848, 523);
            this.Controls.Add(this.txt_Parcela);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_Parcelamento);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ParcelamentoManual);
            this.Controls.Add(this.lb_Conciliado);
            this.Controls.Add(this.ck_Conciliado);
            this.Controls.Add(this.cb_CaixaBaixa);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.lstv_Pagamento);
            this.Controls.Add(this.gb_Cheque);
            this.Controls.Add(this.bt_Remover);
            this.Controls.Add(this.bt_Concluido);
            this.Controls.Add(this.bt_Adiciona);
            this.Controls.Add(this.dg_Pagto_Efetuado);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.mk_Vencimento);
            this.Controls.Add(this.txt_Soma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Diferenca);
            this.Controls.Add(this.lb_Troco);
            this.Controls.Add(this.txt_ValorTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Valor);
            this.Controls.Add(this.Label9);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Compra_Lanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Venda_Lanca_FormClosing);
            this.Load += new System.EventHandler(this.UI_Venda_Lanca_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_Lanca_KeyPress);
            this.gb_Cheque.ResumeLayout(false);
            this.gb_Cheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Pagto_Efetuado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cheque;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_Banco;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_Agencia;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_Conta;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txt_Cheque;
        internal System.Windows.Forms.TextBox txt_Pessoa_Cheque;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button bt_Concluido;
        internal System.Windows.Forms.Button bt_Adiciona;
        internal System.Windows.Forms.DataGridView dg_Pagto_Efetuado;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.MaskedTextBox mk_Vencimento;
        internal System.Windows.Forms.TextBox txt_Soma;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_Diferenca;
        internal System.Windows.Forms.Label lb_Troco;
        internal System.Windows.Forms.TextBox txt_ValorTotal;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Info_Cheque;
        internal System.Windows.Forms.Button bt_Remover;
        private System.Windows.Forms.ListView lstv_Pagamento;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cheque;
        internal System.Windows.Forms.ComboBox cb_CaixaBaixa;
        internal System.Windows.Forms.Label Label31;
        private System.Windows.Forms.CheckBox ck_Conciliado;
        private System.Windows.Forms.Label lb_Conciliado;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.MaskedTextBox mk_DataCheque;
        private System.Windows.Forms.CheckBox ck_ChequeTerceiro;
        internal System.Windows.Forms.Button bt_PesquisaCheque;
        internal System.Windows.Forms.ComboBox cb_Banco;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox cb_Parcelamento;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_ParcelamentoManual;
        internal System.Windows.Forms.TextBox txt_Parcela;
        internal System.Windows.Forms.Label label8;
    }
}
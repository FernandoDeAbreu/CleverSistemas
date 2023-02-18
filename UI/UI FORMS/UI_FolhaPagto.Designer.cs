namespace Sistema.UI
{
    partial class UI_FolhaPagto
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
            this.gb_Cadastro = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.gb_Lancamentos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_Adiciona = new System.Windows.Forms.Button();
            this.txt_Vencimento_Desconto = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Desconto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Vencimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.dg_Lancamentos = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Folha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ID_Evento = new System.Windows.Forms.ComboBox();
            this.bt_Importar = new System.Windows.Forms.Button();
            this.mk_PeriodoLancar = new System.Windows.Forms.MaskedTextBox();
            this.mk_Periodo = new System.Windows.Forms.MaskedTextBox();
            this.mk_Vencimento = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_DescricaoPessoa = new System.Windows.Forms.Label();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_TipoP = new System.Windows.Forms.ComboBox();
            this.mk_Periodo_P = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa_P = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            this.gb_Lancamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Lancamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.label11);
            this.TabPage2.Controls.Add(this.cb_TipoP);
            this.TabPage2.Controls.Add(this.mk_Periodo_P);
            this.TabPage2.Controls.Add(this.label9);
            this.TabPage2.Controls.Add(this.label8);
            this.TabPage2.Controls.Add(this.cb_ID_Pessoa_P);
            this.TabPage2.Controls.SetChildIndex(this.cb_ID_Pessoa_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.label8, 0);
            this.TabPage2.Controls.SetChildIndex(this.label9, 0);
            this.TabPage2.Controls.SetChildIndex(this.mk_Periodo_P, 0);
            this.TabPage2.Controls.SetChildIndex(this.cb_TipoP, 0);
            this.TabPage2.Controls.SetChildIndex(this.label11, 0);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.txt_ID);
            this.gb_Cadastro.Controls.Add(this.gb_Lancamentos);
            this.gb_Cadastro.Controls.Add(this.bt_Importar);
            this.gb_Cadastro.Controls.Add(this.mk_PeriodoLancar);
            this.gb_Cadastro.Controls.Add(this.mk_Periodo);
            this.gb_Cadastro.Controls.Add(this.mk_Vencimento);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.label10);
            this.gb_Cadastro.Controls.Add(this.lb_DescricaoPessoa);
            this.gb_Cadastro.Controls.Add(this.cb_Tipo);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 110;
            this.label2.Text = "Período";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 103;
            this.label1.Text = "Código";
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
            this.txt_ID.TabIndex = 102;
            this.txt_ID.Tag = "T";
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // gb_Lancamentos
            // 
            this.gb_Lancamentos.Controls.Add(this.button1);
            this.gb_Lancamentos.Controls.Add(this.bt_Adiciona);
            this.gb_Lancamentos.Controls.Add(this.txt_Vencimento_Desconto);
            this.gb_Lancamentos.Controls.Add(this.txt_Total);
            this.gb_Lancamentos.Controls.Add(this.label7);
            this.gb_Lancamentos.Controls.Add(this.txt_Desconto);
            this.gb_Lancamentos.Controls.Add(this.label6);
            this.gb_Lancamentos.Controls.Add(this.txt_Vencimento);
            this.gb_Lancamentos.Controls.Add(this.label5);
            this.gb_Lancamentos.Controls.Add(this.txt_Valor);
            this.gb_Lancamentos.Controls.Add(this.Label14);
            this.gb_Lancamentos.Controls.Add(this.dg_Lancamentos);
            this.gb_Lancamentos.Controls.Add(this.label4);
            this.gb_Lancamentos.Controls.Add(this.cb_ID_Evento);
            this.gb_Lancamentos.Location = new System.Drawing.Point(6, 169);
            this.gb_Lancamentos.Name = "gb_Lancamentos";
            this.gb_Lancamentos.Size = new System.Drawing.Size(863, 414);
            this.gb_Lancamentos.TabIndex = 34;
            this.gb_Lancamentos.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(751, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "REMOVER";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.bt_Exclui_Click);
            // 
            // bt_Adiciona
            // 
            this.bt_Adiciona.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Adiciona.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Adiciona.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Adiciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Adiciona.Location = new System.Drawing.Point(644, 32);
            this.bt_Adiciona.Name = "bt_Adiciona";
            this.bt_Adiciona.Size = new System.Drawing.Size(100, 34);
            this.bt_Adiciona.TabIndex = 13;
            this.bt_Adiciona.Text = "INCLUIR";
            this.bt_Adiciona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Adiciona.UseVisualStyleBackColor = false;
            this.bt_Adiciona.Click += new System.EventHandler(this.bt_Adiciona_Click);
            // 
            // txt_Vencimento_Desconto
            // 
            this.txt_Vencimento_Desconto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Vencimento_Desconto.Location = new System.Drawing.Point(411, 41);
            this.txt_Vencimento_Desconto.Name = "txt_Vencimento_Desconto";
            this.txt_Vencimento_Desconto.ReadOnly = true;
            this.txt_Vencimento_Desconto.Size = new System.Drawing.Size(131, 21);
            this.txt_Vencimento_Desconto.TabIndex = 11;
            this.txt_Vencimento_Desconto.TabStop = false;
            this.txt_Vencimento_Desconto.Tag = "T";
            this.txt_Vencimento_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Total
            // 
            this.txt_Total.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Total.Location = new System.Drawing.Point(757, 381);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(98, 21);
            this.txt_Total.TabIndex = 12;
            this.txt_Total.TabStop = false;
            this.txt_Total.Text = "0,00";
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(754, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 55;
            this.label7.Text = "À Receber";
            // 
            // txt_Desconto
            // 
            this.txt_Desconto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Desconto.Location = new System.Drawing.Point(757, 329);
            this.txt_Desconto.Name = "txt_Desconto";
            this.txt_Desconto.ReadOnly = true;
            this.txt_Desconto.Size = new System.Drawing.Size(98, 21);
            this.txt_Desconto.TabIndex = 12;
            this.txt_Desconto.TabStop = false;
            this.txt_Desconto.Text = "0,00";
            this.txt_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "Total Desconto";
            // 
            // txt_Vencimento
            // 
            this.txt_Vencimento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Vencimento.Location = new System.Drawing.Point(757, 273);
            this.txt_Vencimento.Name = "txt_Vencimento";
            this.txt_Vencimento.ReadOnly = true;
            this.txt_Vencimento.Size = new System.Drawing.Size(98, 21);
            this.txt_Vencimento.TabIndex = 12;
            this.txt_Vencimento.TabStop = false;
            this.txt_Vencimento.Text = "0,00";
            this.txt_Vencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 55;
            this.label5.Text = "Total Vencimento";
            // 
            // txt_Valor
            // 
            this.txt_Valor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Valor.Location = new System.Drawing.Point(549, 40);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(86, 21);
            this.txt_Valor.TabIndex = 12;
            this.txt_Valor.Text = "0,00";
            this.txt_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Valor.Leave += new System.EventHandler(this.txt_Valor_Leave);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(546, 19);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(34, 15);
            this.Label14.TabIndex = 55;
            this.Label14.Text = "Valor";
            // 
            // dg_Lancamentos
            // 
            this.dg_Lancamentos.AllowUserToAddRows = false;
            this.dg_Lancamentos.AllowUserToDeleteRows = false;
            this.dg_Lancamentos.AllowUserToResizeColumns = false;
            this.dg_Lancamentos.AllowUserToResizeRows = false;
            this.dg_Lancamentos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Lancamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Lancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Lancamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_ID_Folha,
            this.col_ID_Evento,
            this.col_DescricaoEvento,
            this.col_Vencimento,
            this.col_Desconto});
            this.dg_Lancamentos.Location = new System.Drawing.Point(7, 72);
            this.dg_Lancamentos.MultiSelect = false;
            this.dg_Lancamentos.Name = "dg_Lancamentos";
            this.dg_Lancamentos.ReadOnly = true;
            this.dg_Lancamentos.RowHeadersVisible = false;
            this.dg_Lancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Lancamentos.Size = new System.Drawing.Size(737, 334);
            this.dg_Lancamentos.StandardTab = true;
            this.dg_Lancamentos.TabIndex = 15;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // col_ID_Folha
            // 
            this.col_ID_Folha.DataPropertyName = "ID_Folha";
            this.col_ID_Folha.HeaderText = "ID_Folha";
            this.col_ID_Folha.Name = "col_ID_Folha";
            this.col_ID_Folha.ReadOnly = true;
            this.col_ID_Folha.Visible = false;
            // 
            // col_ID_Evento
            // 
            this.col_ID_Evento.DataPropertyName = "ID_Evento";
            this.col_ID_Evento.HeaderText = "ID_Evento";
            this.col_ID_Evento.Name = "col_ID_Evento";
            this.col_ID_Evento.ReadOnly = true;
            this.col_ID_Evento.Visible = false;
            // 
            // col_DescricaoEvento
            // 
            this.col_DescricaoEvento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoEvento.DataPropertyName = "Descricao";
            this.col_DescricaoEvento.HeaderText = "LANÇAMENTOS";
            this.col_DescricaoEvento.Name = "col_DescricaoEvento";
            this.col_DescricaoEvento.ReadOnly = true;
            this.col_DescricaoEvento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "-";
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Vencimento.HeaderText = "VENCIMENTO";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "-";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Desconto.HeaderText = "DESCONTO";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Eventos";
            // 
            // cb_ID_Evento
            // 
            this.cb_ID_Evento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Evento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Evento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Evento.FormattingEnabled = true;
            this.cb_ID_Evento.Location = new System.Drawing.Point(7, 40);
            this.cb_ID_Evento.MaxDropDownItems = 15;
            this.cb_ID_Evento.Name = "cb_ID_Evento";
            this.cb_ID_Evento.Size = new System.Drawing.Size(396, 23);
            this.cb_ID_Evento.TabIndex = 10;
            this.cb_ID_Evento.Tag = "T";
            // 
            // bt_Importar
            // 
            this.bt_Importar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Importar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Importar.Image = global::Sistema.UI.Properties.Resources.bt_Atualizar;
            this.bt_Importar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Importar.Location = new System.Drawing.Point(414, 132);
            this.bt_Importar.Name = "bt_Importar";
            this.bt_Importar.Size = new System.Drawing.Size(205, 34);
            this.bt_Importar.TabIndex = 33;
            this.bt_Importar.Text = "IMPORTAR MÊS ANTERIOR";
            this.bt_Importar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Importar.UseVisualStyleBackColor = false;
            this.bt_Importar.Click += new System.EventHandler(this.bt_Importar_Click);
            // 
            // mk_PeriodoLancar
            // 
            this.mk_PeriodoLancar.BackColor = System.Drawing.SystemColors.Window;
            this.mk_PeriodoLancar.Location = new System.Drawing.Point(6, 138);
            this.mk_PeriodoLancar.Mask = "00/0000";
            this.mk_PeriodoLancar.Name = "mk_PeriodoLancar";
            this.mk_PeriodoLancar.Size = new System.Drawing.Size(84, 21);
            this.mk_PeriodoLancar.TabIndex = 31;
            this.mk_PeriodoLancar.Tag = "";
            this.mk_PeriodoLancar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_PeriodoLancar.ValidatingType = typeof(System.DateTime);
            this.mk_PeriodoLancar.Leave += new System.EventHandler(this.mk_PeriodoLancar_Leave);
            // 
            // mk_Periodo
            // 
            this.mk_Periodo.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Periodo.Location = new System.Drawing.Point(194, 39);
            this.mk_Periodo.Mask = "00/00/0000";
            this.mk_Periodo.Name = "mk_Periodo";
            this.mk_Periodo.Size = new System.Drawing.Size(84, 21);
            this.mk_Periodo.TabIndex = 29;
            this.mk_Periodo.Tag = "T";
            this.mk_Periodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Periodo.ValidatingType = typeof(System.DateTime);
            this.mk_Periodo.TextChanged += new System.EventHandler(this.mk_Periodo_TextChanged);
            // 
            // mk_Vencimento
            // 
            this.mk_Vencimento.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Vencimento.Location = new System.Drawing.Point(101, 39);
            this.mk_Vencimento.Mask = "00/00/0000";
            this.mk_Vencimento.Name = "mk_Vencimento";
            this.mk_Vencimento.Size = new System.Drawing.Size(84, 21);
            this.mk_Vencimento.TabIndex = 29;
            this.mk_Vencimento.Tag = "T";
            this.mk_Vencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Vencimento.ValidatingType = typeof(System.DateTime);
            this.mk_Vencimento.Leave += new System.EventHandler(this.mk_Vencimento_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Vencimento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "Tipo";
            // 
            // lb_DescricaoPessoa
            // 
            this.lb_DescricaoPessoa.AutoSize = true;
            this.lb_DescricaoPessoa.Location = new System.Drawing.Point(2, 69);
            this.lb_DescricaoPessoa.Name = "lb_DescricaoPessoa";
            this.lb_DescricaoPessoa.Size = new System.Drawing.Size(72, 15);
            this.lb_DescricaoPessoa.TabIndex = 37;
            this.lb_DescricaoPessoa.Text = "Funcionário";
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(98, 137);
            this.cb_Tipo.MaxDropDownItems = 15;
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(304, 23);
            this.cb_Tipo.TabIndex = 32;
            this.cb_Tipo.Tag = "T";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(6, 88);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(396, 23);
            this.cb_ID_Pessoa.TabIndex = 30;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 112;
            this.label11.Text = "Tipo";
            // 
            // cb_TipoP
            // 
            this.cb_TipoP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoP.FormattingEnabled = true;
            this.cb_TipoP.Location = new System.Drawing.Point(96, 84);
            this.cb_TipoP.MaxDropDownItems = 15;
            this.cb_TipoP.Name = "cb_TipoP";
            this.cb_TipoP.Size = new System.Drawing.Size(304, 23);
            this.cb_TipoP.TabIndex = 111;
            this.cb_TipoP.Tag = "";
            // 
            // mk_Periodo_P
            // 
            this.mk_Periodo_P.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Periodo_P.Location = new System.Drawing.Point(3, 84);
            this.mk_Periodo_P.Mask = "##/####";
            this.mk_Periodo_P.Name = "mk_Periodo_P";
            this.mk_Periodo_P.Size = new System.Drawing.Size(84, 21);
            this.mk_Periodo_P.TabIndex = 108;
            this.mk_Periodo_P.Tag = "T";
            this.mk_Periodo_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Periodo_P.Leave += new System.EventHandler(this.mk_Periodo_P_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 109;
            this.label9.Text = "Período";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 110;
            this.label8.Text = "Funcionário";
            // 
            // cb_ID_Pessoa_P
            // 
            this.cb_ID_Pessoa_P.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa_P.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa_P.FormattingEnabled = true;
            this.cb_ID_Pessoa_P.Location = new System.Drawing.Point(3, 32);
            this.cb_ID_Pessoa_P.MaxDropDownItems = 15;
            this.cb_ID_Pessoa_P.Name = "cb_ID_Pessoa_P";
            this.cb_ID_Pessoa_P.Size = new System.Drawing.Size(396, 23);
            this.cb_ID_Pessoa_P.TabIndex = 107;
            this.cb_ID_Pessoa_P.Tag = "T";
            // 
            // UI_FolhaPagto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_FolhaPagto";
            this.Load += new System.EventHandler(this.UI_FolhaPagto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FolhaPagto_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_FolhaPagto_KeyPress);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            this.gb_Lancamentos.ResumeLayout(false);
            this.gb_Lancamentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Lancamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        private System.Windows.Forms.GroupBox gb_Lancamentos;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button bt_Adiciona;
        internal System.Windows.Forms.TextBox txt_Vencimento_Desconto;
        internal System.Windows.Forms.TextBox txt_Total;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_Desconto;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_Vencimento;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.DataGridView dg_Lancamentos;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_ID_Evento;
        internal System.Windows.Forms.Button bt_Importar;
        internal System.Windows.Forms.MaskedTextBox mk_PeriodoLancar;
        internal System.Windows.Forms.MaskedTextBox mk_Vencimento;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label lb_DescricaoPessoa;
        internal System.Windows.Forms.ComboBox cb_Tipo;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_ID;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cb_TipoP;
        internal System.Windows.Forms.MaskedTextBox mk_Periodo_P;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa_P;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Folha;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        internal System.Windows.Forms.MaskedTextBox mk_Periodo;
    }
}

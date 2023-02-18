namespace Sistema.UI
{
    partial class UI_CReceber_Cartao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_CReceber_Cartao));
            this.DG = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_PrevisaoPagto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label22 = new System.Windows.Forms.Label();
            this.cb_Periodo = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.cb_ID_Cartao = new System.Windows.Forms.ComboBox();
            this.bt_Baixa = new System.Windows.Forms.Button();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.cb_Caixa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_Baixa);
            this.TabPage1.Controls.Add(this.txt_Valor);
            this.TabPage1.Controls.Add(this.Label18);
            this.TabPage1.Controls.Add(this.DG);
            this.TabPage1.Controls.Add(this.Label22);
            this.TabPage1.Controls.Add(this.cb_Periodo);
            this.TabPage1.Controls.Add(this.Label25);
            this.TabPage1.Controls.Add(this.mk_DataFinal);
            this.TabPage1.Controls.Add(this.mk_Data);
            this.TabPage1.Controls.Add(this.mk_DataInicial);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.Label19);
            this.TabPage1.Controls.Add(this.cb_Caixa);
            this.TabPage1.Controls.Add(this.cb_ID_Cartao);
            this.TabPage1.Text = "BAIXA DE CARTÃO DE CRÉDITO";
            this.TabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // DG
            // 
            this.DG.AllowUserToAddRows = false;
            this.DG.AllowUserToDeleteRows = false;
            this.DG.AllowUserToResizeColumns = false;
            this.DG.AllowUserToResizeRows = false;
            this.DG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_PrevisaoPagto,
            this.col_Emissao,
            this.col_Documento,
            this.col_Parcela,
            this.col_Vencimento,
            this.col_Valor,
            this.col_Desconto,
            this.col_ValorLiquido,
            this.col_ID});
            this.DG.Location = new System.Drawing.Point(5, 108);
            this.DG.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DG.MultiSelect = false;
            this.DG.Name = "DG";
            this.DG.RowHeadersVisible = false;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(931, 463);
            this.DG.StandardTab = true;
            this.DG.TabIndex = 10;
            this.DG.DataSourceChanged += new System.EventHandler(this.DG_DataSourceChanged);
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            this.DG.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DG_CellPainting);
            this.DG.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_ColumnHeaderMouseClick);
            this.DG.DoubleClick += new System.EventHandler(this.DG_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Width = 25;
            // 
            // col_PrevisaoPagto
            // 
            this.col_PrevisaoPagto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_PrevisaoPagto.DataPropertyName = "PrevisaoPagto";
            this.col_PrevisaoPagto.HeaderText = "Cartão";
            this.col_PrevisaoPagto.Name = "col_PrevisaoPagto";
            this.col_PrevisaoPagto.ReadOnly = true;
            // 
            // col_Emissao
            // 
            this.col_Emissao.DataPropertyName = "Emissao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.col_Emissao.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Emissao.HeaderText = "Emissão";
            this.col_Emissao.Name = "col_Emissao";
            this.col_Emissao.ReadOnly = true;
            this.col_Emissao.Width = 75;
            // 
            // col_Documento
            // 
            this.col_Documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_Documento.DataPropertyName = "Documento";
            this.col_Documento.HeaderText = "Documento";
            this.col_Documento.Name = "col_Documento";
            this.col_Documento.ReadOnly = true;
            this.col_Documento.Width = 96;
            // 
            // col_Parcela
            // 
            this.col_Parcela.DataPropertyName = "ResumoParcela";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Parcela.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Parcela.HeaderText = "Parcela";
            this.col_Parcela.Name = "col_Parcela";
            this.col_Parcela.ReadOnly = true;
            this.col_Parcela.Width = 50;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Vencimento.HeaderText = "Vencimento";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.Width = 75;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Valor.HeaderText = "Valor";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.Width = 80;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Desconto.HeaderText = "Desc. Tarifa";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 70;
            // 
            // col_ValorLiquido
            // 
            this.col_ValorLiquido.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.col_ValorLiquido.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_ValorLiquido.HeaderText = "Total";
            this.col_ValorLiquido.Name = "col_ValorLiquido";
            this.col_ValorLiquido.ReadOnly = true;
            this.col_ValorLiquido.Width = 80;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(6, 59);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(50, 15);
            this.Label22.TabIndex = 441;
            this.Label22.Text = "Periodo";
            // 
            // cb_Periodo
            // 
            this.cb_Periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Periodo.FormattingEnabled = true;
            this.cb_Periodo.Location = new System.Drawing.Point(9, 78);
            this.cb_Periodo.Name = "cb_Periodo";
            this.cb_Periodo.Size = new System.Drawing.Size(146, 23);
            this.cb_Periodo.TabIndex = 2;
            this.cb_Periodo.Tag = "T";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(272, 87);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 440;
            this.Label25.Text = "à";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(294, 78);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 4;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            this.mk_DataFinal.Leave += new System.EventHandler(this.mk_DataFinal_Leave);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(163, 78);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 3;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            this.mk_DataInicial.Leave += new System.EventHandler(this.mk_DataInicial_Leave);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(6, 10);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(44, 15);
            this.Label19.TabIndex = 439;
            this.Label19.Text = "Cartão";
            // 
            // cb_ID_Cartao
            // 
            this.cb_ID_Cartao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Cartao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Cartao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Cartao.FormattingEnabled = true;
            this.cb_ID_Cartao.Location = new System.Drawing.Point(9, 29);
            this.cb_ID_Cartao.Name = "cb_ID_Cartao";
            this.cb_ID_Cartao.Size = new System.Drawing.Size(255, 23);
            this.cb_ID_Cartao.TabIndex = 1;
            this.cb_ID_Cartao.Tag = "T";
            // 
            // bt_Baixa
            // 
            this.bt_Baixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Baixa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Baixa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Baixa.Image = ((System.Drawing.Image)(resources.GetObject("bt_Baixa.Image")));
            this.bt_Baixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Baixa.Location = new System.Drawing.Point(683, 577);
            this.bt_Baixa.Name = "bt_Baixa";
            this.bt_Baixa.Size = new System.Drawing.Size(253, 43);
            this.bt_Baixa.TabIndex = 16;
            this.bt_Baixa.Text = "LANÇAR CRÉDITOS CARTÃO";
            this.bt_Baixa.UseVisualStyleBackColor = false;
            this.bt_Baixa.Click += new System.EventHandler(this.bt_Baixa_Click);
            // 
            // txt_Valor
            // 
            this.txt_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Valor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Valor.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.Location = new System.Drawing.Point(377, 594);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.ReadOnly = true;
            this.txt_Valor.Size = new System.Drawing.Size(137, 24);
            this.txt_Valor.TabIndex = 15;
            this.txt_Valor.TabStop = false;
            this.txt_Valor.Text = "0,00";
            this.txt_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label18
            // 
            this.Label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(373, 574);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(33, 15);
            this.Label18.TabIndex = 443;
            this.Label18.Text = "Total";
            // 
            // cb_Caixa
            // 
            this.cb_Caixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Caixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Caixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Caixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Caixa.FormattingEnabled = true;
            this.cb_Caixa.Location = new System.Drawing.Point(12, 597);
            this.cb_Caixa.Name = "cb_Caixa";
            this.cb_Caixa.Size = new System.Drawing.Size(252, 23);
            this.cb_Caixa.TabIndex = 11;
            this.cb_Caixa.Tag = "T";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 439;
            this.label1.Text = "Caixa";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 439;
            this.label2.Text = "Data";
            // 
            // mk_Data
            // 
            this.mk_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(270, 597);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(101, 21);
            this.mk_Data.TabIndex = 12;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            // 
            // UI_CReceber_Cartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Name = "UI_CReceber_Cartao";
            this.Load += new System.EventHandler(this.UI_CReceber_Cartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_CReceber_Cartao_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DG;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ComboBox cb_Periodo;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cb_ID_Cartao;
        internal System.Windows.Forms.Button bt_Baixa;
        internal System.Windows.Forms.TextBox txt_Valor;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cb_Caixa;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PrevisaoPagto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
    }
}

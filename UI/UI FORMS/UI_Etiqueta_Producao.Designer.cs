namespace Sistema.UI
{
    partial class UI_Etiqueta_Producao
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
            this.txt_InicioEtiqueta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IDPedido = new System.Windows.Forms.TextBox();
            this.Label52 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cb_ID_Pessoa = new System.Windows.Forms.ComboBox();
            this.cb_TipoPessoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_NFe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Situacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dg_PesquisaVenda = new System.Windows.Forms.DataGridView();
            this.col_Seleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ID_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Numeracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.mk_DataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mk_DataInicial = new System.Windows.Forms.MaskedTextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Cadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PesquisaVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Cadastro);
            // 
            // gb_Cadastro
            // 
            this.gb_Cadastro.Controls.Add(this.txt_InicioEtiqueta);
            this.gb_Cadastro.Controls.Add(this.label3);
            this.gb_Cadastro.Controls.Add(this.txt_IDPedido);
            this.gb_Cadastro.Controls.Add(this.Label52);
            this.gb_Cadastro.Controls.Add(this.label27);
            this.gb_Cadastro.Controls.Add(this.cb_ID_Pessoa);
            this.gb_Cadastro.Controls.Add(this.cb_TipoPessoa);
            this.gb_Cadastro.Controls.Add(this.label2);
            this.gb_Cadastro.Controls.Add(this.label1);
            this.gb_Cadastro.Controls.Add(this.cb_NFe);
            this.gb_Cadastro.Controls.Add(this.label5);
            this.gb_Cadastro.Controls.Add(this.cb_Situacao);
            this.gb_Cadastro.Controls.Add(this.label6);
            this.gb_Cadastro.Controls.Add(this.dg_PesquisaVenda);
            this.gb_Cadastro.Controls.Add(this.Label25);
            this.gb_Cadastro.Controls.Add(this.Label17);
            this.gb_Cadastro.Controls.Add(this.mk_DataFinal);
            this.gb_Cadastro.Controls.Add(this.mk_DataInicial);
            this.gb_Cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Cadastro.Location = new System.Drawing.Point(2, 3);
            this.gb_Cadastro.Name = "gb_Cadastro";
            this.gb_Cadastro.Size = new System.Drawing.Size(938, 620);
            this.gb_Cadastro.TabIndex = 0;
            this.gb_Cadastro.TabStop = false;
            // 
            // txt_InicioEtiqueta
            // 
            this.txt_InicioEtiqueta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InicioEtiqueta.Location = new System.Drawing.Point(780, 104);
            this.txt_InicioEtiqueta.MaxLength = 14;
            this.txt_InicioEtiqueta.Name = "txt_InicioEtiqueta";
            this.txt_InicioEtiqueta.Size = new System.Drawing.Size(82, 21);
            this.txt_InicioEtiqueta.TabIndex = 703;
            this.txt_InicioEtiqueta.Tag = "T";
            this.txt_InicioEtiqueta.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 704;
            this.label3.Text = "Inicio Etiqueta";
            // 
            // txt_IDPedido
            // 
            this.txt_IDPedido.BackColor = System.Drawing.SystemColors.Window;
            this.txt_IDPedido.Location = new System.Drawing.Point(9, 45);
            this.txt_IDPedido.MaxLength = 14;
            this.txt_IDPedido.Name = "txt_IDPedido";
            this.txt_IDPedido.Size = new System.Drawing.Size(102, 21);
            this.txt_IDPedido.TabIndex = 701;
            this.txt_IDPedido.Tag = "T";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.Location = new System.Drawing.Point(6, 26);
            this.Label52.Name = "Label52";
            this.Label52.Size = new System.Drawing.Size(57, 15);
            this.Label52.TabIndex = 702;
            this.Label52.Text = "Nº Venda";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(383, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 15);
            this.label27.TabIndex = 700;
            this.label27.Text = "F7 (Pesquisa avançada)";
            // 
            // cb_ID_Pessoa
            // 
            this.cb_ID_Pessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Pessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Pessoa.FormattingEnabled = true;
            this.cb_ID_Pessoa.Location = new System.Drawing.Point(315, 44);
            this.cb_ID_Pessoa.MaxDropDownItems = 15;
            this.cb_ID_Pessoa.Name = "cb_ID_Pessoa";
            this.cb_ID_Pessoa.Size = new System.Drawing.Size(453, 23);
            this.cb_ID_Pessoa.TabIndex = 697;
            this.cb_ID_Pessoa.Tag = "T";
            // 
            // cb_TipoPessoa
            // 
            this.cb_TipoPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPessoa.FormattingEnabled = true;
            this.cb_TipoPessoa.Location = new System.Drawing.Point(119, 44);
            this.cb_TipoPessoa.Name = "cb_TipoPessoa";
            this.cb_TipoPessoa.Size = new System.Drawing.Size(188, 23);
            this.cb_TipoPessoa.TabIndex = 696;
            this.cb_TipoPessoa.Tag = "T";
            this.cb_TipoPessoa.SelectedValueChanged += new System.EventHandler(this.cb_TipoPessoa_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 698;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 699;
            this.label1.Text = "Tipo Pessoa";
            // 
            // cb_NFe
            // 
            this.cb_NFe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NFe.FormattingEnabled = true;
            this.cb_NFe.Location = new System.Drawing.Point(468, 104);
            this.cb_NFe.Name = "cb_NFe";
            this.cb_NFe.Size = new System.Drawing.Size(188, 23);
            this.cb_NFe.TabIndex = 693;
            this.cb_NFe.Tag = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 694;
            this.label5.Text = "Nota fiscal Eletrônica";
            // 
            // cb_Situacao
            // 
            this.cb_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Situacao.FormattingEnabled = true;
            this.cb_Situacao.Location = new System.Drawing.Point(259, 104);
            this.cb_Situacao.Name = "cb_Situacao";
            this.cb_Situacao.Size = new System.Drawing.Size(188, 23);
            this.cb_Situacao.TabIndex = 692;
            this.cb_Situacao.Tag = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 695;
            this.label6.Text = "Situação Financeira";
            // 
            // dg_PesquisaVenda
            // 
            this.dg_PesquisaVenda.AllowUserToAddRows = false;
            this.dg_PesquisaVenda.AllowUserToDeleteRows = false;
            this.dg_PesquisaVenda.AllowUserToResizeColumns = false;
            this.dg_PesquisaVenda.AllowUserToResizeRows = false;
            this.dg_PesquisaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_PesquisaVenda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_PesquisaVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_PesquisaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_PesquisaVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Seleciona,
            this.col_ID_Pedido,
            this.col_Pessoa,
            this.col_OC,
            this.col_Referencia,
            this.col_Cor,
            this.col_Numeracao,
            this.col_Quantidade});
            this.dg_PesquisaVenda.Location = new System.Drawing.Point(7, 134);
            this.dg_PesquisaVenda.MultiSelect = false;
            this.dg_PesquisaVenda.Name = "dg_PesquisaVenda";
            this.dg_PesquisaVenda.RowHeadersVisible = false;
            this.dg_PesquisaVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_PesquisaVenda.Size = new System.Drawing.Size(924, 480);
            this.dg_PesquisaVenda.TabIndex = 136;
            this.dg_PesquisaVenda.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_PesquisaVenda_CellPainting);
            this.dg_PesquisaVenda.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_PesquisaVenda_ColumnHeaderMouseClick);
            this.dg_PesquisaVenda.DoubleClick += new System.EventHandler(this.dg_PesquisaVenda_DoubleClick);
            // 
            // col_Seleciona
            // 
            this.col_Seleciona.HeaderText = "";
            this.col_Seleciona.Name = "col_Seleciona";
            this.col_Seleciona.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Seleciona.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Seleciona.Width = 30;
            // 
            // col_ID_Pedido
            // 
            this.col_ID_Pedido.DataPropertyName = "ID";
            this.col_ID_Pedido.HeaderText = "Venda";
            this.col_ID_Pedido.Name = "col_ID_Pedido";
            this.col_ID_Pedido.ReadOnly = true;
            // 
            // col_Pessoa
            // 
            this.col_Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Pessoa.HeaderText = "Cliente";
            this.col_Pessoa.Name = "col_Pessoa";
            this.col_Pessoa.ReadOnly = true;
            // 
            // col_OC
            // 
            this.col_OC.HeaderText = "OC";
            this.col_OC.Name = "col_OC";
            this.col_OC.Width = 50;
            // 
            // col_Referencia
            // 
            this.col_Referencia.HeaderText = "Referência";
            this.col_Referencia.Name = "col_Referencia";
            // 
            // col_Cor
            // 
            this.col_Cor.HeaderText = "Cor";
            this.col_Cor.Name = "col_Cor";
            // 
            // col_Numeracao
            // 
            this.col_Numeracao.HeaderText = "Numeração";
            this.col_Numeracao.Name = "col_Numeracao";
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.HeaderText = "Quantidade";
            this.col_Quantidade.Name = "col_Quantidade";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(115, 107);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(14, 15);
            this.Label25.TabIndex = 138;
            this.Label25.Text = "à";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(3, 85);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(50, 15);
            this.Label17.TabIndex = 137;
            this.Label17.Text = "Período";
            // 
            // mk_DataFinal
            // 
            this.mk_DataFinal.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataFinal.Location = new System.Drawing.Point(138, 104);
            this.mk_DataFinal.Mask = "00/00/0000";
            this.mk_DataFinal.Name = "mk_DataFinal";
            this.mk_DataFinal.Size = new System.Drawing.Size(101, 21);
            this.mk_DataFinal.TabIndex = 133;
            this.mk_DataFinal.Tag = "T";
            this.mk_DataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // mk_DataInicial
            // 
            this.mk_DataInicial.BackColor = System.Drawing.SystemColors.Window;
            this.mk_DataInicial.Location = new System.Drawing.Point(7, 104);
            this.mk_DataInicial.Mask = "00/00/0000";
            this.mk_DataInicial.Name = "mk_DataInicial";
            this.mk_DataInicial.Size = new System.Drawing.Size(101, 21);
            this.mk_DataInicial.TabIndex = 132;
            this.mk_DataInicial.Tag = "T";
            this.mk_DataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_DataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // UI_Etiqueta_Producao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Etiqueta_Producao";
            this.Load += new System.EventHandler(this.UI_Etiqueta_Producao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Etiqueta_Producao_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Cadastro.ResumeLayout(false);
            this.gb_Cadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PesquisaVenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cadastro;
        internal System.Windows.Forms.DataGridView dg_PesquisaVenda;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mk_DataFinal;
        internal System.Windows.Forms.MaskedTextBox mk_DataInicial;
        internal System.Windows.Forms.ComboBox cb_NFe;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cb_Situacao;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox cb_ID_Pessoa;
        internal System.Windows.Forms.ComboBox cb_TipoPessoa;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_IDPedido;
        internal System.Windows.Forms.Label Label52;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Seleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OC;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Numeracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        internal System.Windows.Forms.TextBox txt_InicioEtiqueta;
        internal System.Windows.Forms.Label label3;
    }
}

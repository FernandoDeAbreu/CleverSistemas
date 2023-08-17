
namespace Sistema.UI.UI_FORMS
{
    partial class UI_PDV_II
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnPagamento = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataHora = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dg_GrupoNivel = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProximo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.bntConfiguracao = new System.Windows.Forms.Button();
            this.pBox_Imagen_Principal = new System.Windows.Forms.PictureBox();
            this.col_InfoAdicional1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ValorCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_GrupoNivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Imagen_Principal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(4, 603);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(595, 123);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(604, 603);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 123);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR PEDIDO";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemoverItem.FlatAppearance.BorderSize = 0;
            this.btnRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnRemoverItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoverItem.Location = new System.Drawing.Point(758, 603);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(149, 123);
            this.btnRemoverItem.TabIndex = 4;
            this.btnRemoverItem.Text = "REMOVER ITEM";
            this.btnRemoverItem.UseVisualStyleBackColor = false;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
            // 
            // btnPagamento
            // 
            this.btnPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagamento.BackColor = System.Drawing.Color.Green;
            this.btnPagamento.FlatAppearance.BorderSize = 0;
            this.btnPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagamento.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnPagamento.ForeColor = System.Drawing.Color.White;
            this.btnPagamento.Location = new System.Drawing.Point(912, 603);
            this.btnPagamento.Name = "btnPagamento";
            this.btnPagamento.Size = new System.Drawing.Size(236, 123);
            this.btnPagamento.TabIndex = 5;
            this.btnPagamento.Text = "PAGAMENTO";
            this.btnPagamento.UseVisualStyleBackColor = false;
            this.btnPagamento.Click += new System.EventHandler(this.btnPagamento_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(599, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 517);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // DataHora
            // 
            this.DataHora.Enabled = true;
            this.DataHora.Tick += new System.EventHandler(this.DataHora_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 62);
            this.label1.TabIndex = 13;
            this.label1.Text = "Venda Balcão Nº";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dg_GrupoNivel
            // 
            this.dg_GrupoNivel.AllowUserToAddRows = false;
            this.dg_GrupoNivel.AllowUserToDeleteRows = false;
            this.dg_GrupoNivel.AllowUserToResizeColumns = false;
            this.dg_GrupoNivel.AllowUserToResizeRows = false;
            this.dg_GrupoNivel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_GrupoNivel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Codigo,
            this.col_Descricao});
            this.dg_GrupoNivel.Location = new System.Drawing.Point(621, 98);
            this.dg_GrupoNivel.Name = "dg_GrupoNivel";
            this.dg_GrupoNivel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_GrupoNivel.Size = new System.Drawing.Size(101, 185);
            this.dg_GrupoNivel.TabIndex = 14;
            // 
            // col_ID
            // 
            this.col_ID.HeaderText = "col_ID";
            this.col_ID.Name = "col_ID";
            // 
            // col_Codigo
            // 
            this.col_Codigo.HeaderText = "col_Codigo";
            this.col_Codigo.Name = "col_Codigo";
            // 
            // col_Descricao
            // 
            this.col_Descricao.HeaderText = "col_Descricao";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.Width = 250;
            // 
            // btnProximo
            // 
            this.btnProximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProximo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProximo.FlatAppearance.BorderSize = 0;
            this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnProximo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnProximo.Location = new System.Drawing.Point(1015, 16);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(75, 45);
            this.btnProximo.TabIndex = 15;
            this.btnProximo.Text = ">>";
            this.btnProximo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProximo.UseVisualStyleBackColor = false;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(418, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 45);
            this.label2.TabIndex = 16;
            this.label2.Text = "Categoria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnterior.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnAnterior.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAnterior.Location = new System.Drawing.Point(816, 16);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 45);
            this.btnAnterior.TabIndex = 17;
            this.btnAnterior.Text = "<<";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTodos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTodos.FlatAppearance.BorderSize = 0;
            this.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodos.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.btnTodos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTodos.Location = new System.Drawing.Point(897, 16);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(112, 45);
            this.btnTodos.TabIndex = 18;
            this.btnTodos.Text = "TODOS";
            this.btnTodos.UseVisualStyleBackColor = false;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // bntConfiguracao
            // 
            this.bntConfiguracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntConfiguracao.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bntConfiguracao.BackgroundImage = global::Sistema.UI.Properties.Resources.ferramenta_de_configuracao_do_gears;
            this.bntConfiguracao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntConfiguracao.FlatAppearance.BorderSize = 0;
            this.bntConfiguracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntConfiguracao.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.bntConfiguracao.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bntConfiguracao.Image = global::Sistema.UI.Properties.Resources.configuracao;
            this.bntConfiguracao.Location = new System.Drawing.Point(1096, 16);
            this.bntConfiguracao.Name = "bntConfiguracao";
            this.bntConfiguracao.Size = new System.Drawing.Size(50, 45);
            this.bntConfiguracao.TabIndex = 19;
            this.bntConfiguracao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bntConfiguracao.UseVisualStyleBackColor = false;
            this.bntConfiguracao.Click += new System.EventHandler(this.bntConfiguracao_Click);
            // 
            // pBox_Imagen_Principal
            // 
            this.pBox_Imagen_Principal.BackColor = System.Drawing.Color.White;
            this.pBox_Imagen_Principal.Location = new System.Drawing.Point(4, 3);
            this.pBox_Imagen_Principal.Name = "pBox_Imagen_Principal";
            this.pBox_Imagen_Principal.Size = new System.Drawing.Size(114, 71);
            this.pBox_Imagen_Principal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox_Imagen_Principal.TabIndex = 0;
            this.pBox_Imagen_Principal.TabStop = false;
            // 
            // col_InfoAdicional1
            // 
            this.col_InfoAdicional1.HeaderText = "col_InfoAdicional1";
            this.col_InfoAdicional1.Name = "col_InfoAdicional1";
            this.col_InfoAdicional1.ReadOnly = true;
            this.col_InfoAdicional1.Visible = false;
            // 
            // Col_ValorCusto
            // 
            this.Col_ValorCusto.HeaderText = "Col_ValorCusto";
            this.Col_ValorCusto.Name = "Col_ValorCusto";
            this.Col_ValorCusto.ReadOnly = true;
            this.Col_ValorCusto.Visible = false;
            // 
            // col_ValorTotal
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle41.Format = "N2";
            this.col_ValorTotal.DefaultCellStyle = dataGridViewCellStyle41;
            this.col_ValorTotal.HeaderText = "TOTAL";
            this.col_ValorTotal.Name = "col_ValorTotal";
            this.col_ValorTotal.ReadOnly = true;
            this.col_ValorTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ValorTotal.Width = 120;
            // 
            // col_Desconto
            // 
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle42.Format = "N2";
            dataGridViewCellStyle42.NullValue = null;
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle42;
            this.col_Desconto.HeaderText = "DESC.";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Desconto.Visible = false;
            this.col_Desconto.Width = 75;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "ValorFinal";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle43.Format = "N2";
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle43;
            this.col_Valor.HeaderText = "VALOR";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Valor.Visible = false;
            this.col_Valor.Width = 75;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle44.Format = "N2";
            dataGridViewCellStyle44.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle44;
            this.col_Quantidade.HeaderText = "QUANT.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Quantidade.Visible = false;
            this.col_Quantidade.Width = 50;
            // 
            // col_Descricao_Produto
            // 
            this.col_Descricao_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao_Produto.DataPropertyName = "DescricaoProduto";
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.col_Descricao_Produto.DefaultCellStyle = dataGridViewCellStyle45;
            this.col_Descricao_Produto.HeaderText = "PRODUTO";
            this.col_Descricao_Produto.Name = "col_Descricao_Produto";
            this.col_Descricao_Produto.ReadOnly = true;
            this.col_Descricao_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.col_ID_Produto.DefaultCellStyle = dataGridViewCellStyle46;
            this.col_ID_Produto.HeaderText = "CÓD.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_Produto.Visible = false;
            this.col_ID_Produto.Width = 40;
            // 
            // col_Item
            // 
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.col_Item.DefaultCellStyle = dataGridViewCellStyle47;
            this.col_Item.HeaderText = "col_Item";
            this.col_Item.Name = "col_Item";
            this.col_Item.ReadOnly = true;
            this.col_Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Item.Width = 30;
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dg_Itens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_Itens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.ColumnHeadersVisible = false;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Item,
            this.col_ID_Produto,
            this.col_Descricao_Produto,
            this.col_Quantidade,
            this.col_Valor,
            this.col_Desconto,
            this.col_ValorTotal,
            this.Col_ValorCusto,
            this.col_InfoAdicional1});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Itens.DefaultCellStyle = dataGridViewCellStyle48;
            this.dg_Itens.Location = new System.Drawing.Point(5, 4);
            this.dg_Itens.Margin = new System.Windows.Forms.Padding(4);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Itens.RowHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.RowHeadersWidth = 60;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dg_Itens.RowsDefaultCellStyle = dataGridViewCellStyle50;
            this.dg_Itens.RowTemplate.Height = 60;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(589, 515);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.dg_Itens);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.dg_GrupoNivel);
            this.panel1.Location = new System.Drawing.Point(4, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 525);
            this.panel1.TabIndex = 20;
            // 
            // UI_PDV_II
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1152, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bntConfiguracao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnPagamento);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnRemoverItem);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pBox_Imagen_Principal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UI_PDV_II";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_PDV_II";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UI_PDV_II_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_PDV_II_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dg_GrupoNivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Imagen_Principal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox_Imagen_Principal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnPagamento;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer DataHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_GrupoNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button bntConfiguracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_InfoAdicional1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ValorCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Item;
        internal System.Windows.Forms.DataGridView dg_Itens;
        private System.Windows.Forms.Panel panel1;
    }
}
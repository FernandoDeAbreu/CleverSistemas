namespace Sistema.UI
{
    partial class UI_PDV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_PDV));
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_Horario = new System.Windows.Forms.Label();
            this.lb_Data = new System.Windows.Forms.Label();
            this.txt_ValorPedido = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.txt_ValorTotal = new System.Windows.Forms.TextBox();
            this.txt_ValorFinal = new System.Windows.Forms.TextBox();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.txt_Cod_Barra = new System.Windows.Forms.TextBox();
            this.DataHora = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_desconto = new System.Windows.Forms.Label();
            this.txt_Desconto = new System.Windows.Forms.TextBox();
            this.txt_DescricaoProduto = new System.Windows.Forms.TextBox();
            this.txt_Quantidade2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txt_ID = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.lbl_ID_UsuarioComissao1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_ID_Pessoa = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_CNPJ_CPF = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.txt_DescricaoPessoa = new System.Windows.Forms.ToolStripLabel();
            this.lb_Comissao1 = new System.Windows.Forms.Label();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.cb_ID_UsuarioComissao1 = new System.Windows.Forms.ComboBox();
            this.pBox_Imagen_Principal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Imagen_Principal)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Itens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Item,
            this.col_ID_Produto,
            this.col_Descricao_Produto,
            this.col_Quantidade,
            this.col_Valor,
            this.col_Desconto,
            this.col_ValorTotal});
            this.dg_Itens.Location = new System.Drawing.Point(368, 246);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(628, 336);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 10;
            // 
            // col_Item
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Silver;
            this.col_Item.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Item.HeaderText = "";
            this.col_Item.Name = "col_Item";
            this.col_Item.ReadOnly = true;
            this.col_Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Item.Width = 30;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID_Produto";
            this.col_ID_Produto.HeaderText = "CÓD.";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_Produto.Width = 40;
            // 
            // col_Descricao_Produto
            // 
            this.col_Descricao_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao_Produto.DataPropertyName = "DescricaoProduto";
            this.col_Descricao_Produto.HeaderText = "PRODUTO";
            this.col_Descricao_Produto.Name = "col_Descricao_Produto";
            this.col_Descricao_Produto.ReadOnly = true;
            this.col_Descricao_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Quantidade.HeaderText = "QUANT.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Quantidade.Width = 50;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "ValorFinal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Valor.HeaderText = "VALOR";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Valor.Width = 75;
            // 
            // col_Desconto
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Desconto.HeaderText = "DESC.";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Desconto.Width = 75;
            // 
            // col_ValorTotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_ValorTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ValorTotal.HeaderText = "TOTAL";
            this.col_ValorTotal.Name = "col_ValorTotal";
            this.col_ValorTotal.ReadOnly = true;
            this.col_ValorTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ValorTotal.Width = 85;
            // 
            // lb_Horario
            // 
            this.lb_Horario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Horario.AutoSize = true;
            this.lb_Horario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lb_Horario.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Horario.Location = new System.Drawing.Point(885, 6);
            this.lb_Horario.Name = "lb_Horario";
            this.lb_Horario.Size = new System.Drawing.Size(116, 31);
            this.lb_Horario.TabIndex = 44;
            this.lb_Horario.Text = "13:00:00";
            // 
            // lb_Data
            // 
            this.lb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Data.AutoSize = true;
            this.lb_Data.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Data.Location = new System.Drawing.Point(737, 6);
            this.lb_Data.Name = "lb_Data";
            this.lb_Data.Size = new System.Drawing.Size(142, 31);
            this.lb_Data.TabIndex = 44;
            this.lb_Data.Text = "01/01/2015";
            // 
            // txt_ValorPedido
            // 
            this.txt_ValorPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorPedido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorPedido.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorPedido.Location = new System.Drawing.Point(368, 172);
            this.txt_ValorPedido.Name = "txt_ValorPedido";
            this.txt_ValorPedido.ReadOnly = true;
            this.txt_ValorPedido.Size = new System.Drawing.Size(629, 63);
            this.txt_ValorPedido.TabIndex = 12;
            this.txt_ValorPedido.TabStop = false;
            this.txt_ValorPedido.Text = "R$ 0,00";
            this.txt_ValorPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label23
            // 
            this.Label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label23.Location = new System.Drawing.Point(366, 155);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(128, 17);
            this.Label23.TabIndex = 101;
            this.Label23.Text = "TOTAL A PAGAR";
            // 
            // txt_ValorTotal
            // 
            this.txt_ValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorTotal.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorTotal.Location = new System.Drawing.Point(786, 122);
            this.txt_ValorTotal.Name = "txt_ValorTotal";
            this.txt_ValorTotal.ReadOnly = true;
            this.txt_ValorTotal.Size = new System.Drawing.Size(211, 32);
            this.txt_ValorTotal.TabIndex = 7;
            this.txt_ValorTotal.TabStop = false;
            this.txt_ValorTotal.Text = "0,00";
            this.txt_ValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_ValorFinal
            // 
            this.txt_ValorFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorFinal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ValorFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorFinal.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorFinal.Location = new System.Drawing.Point(569, 122);
            this.txt_ValorFinal.Name = "txt_ValorFinal";
            this.txt_ValorFinal.ReadOnly = true;
            this.txt_ValorFinal.Size = new System.Drawing.Size(211, 32);
            this.txt_ValorFinal.TabIndex = 6;
            this.txt_ValorFinal.TabStop = false;
            this.txt_ValorFinal.Tag = "";
            this.txt_ValorFinal.Text = "0,00";
            this.txt_ValorFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorFinal.Leave += new System.EventHandler(this.txt_ValorFinal_Leave);
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Quantidade.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Quantidade.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantidade.Location = new System.Drawing.Point(368, 588);
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(92, 32);
            this.txt_Quantidade.TabIndex = 5;
            this.txt_Quantidade.Tag = "T";
            this.txt_Quantidade.Text = "1,000";
            this.txt_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Quantidade.TextChanged += new System.EventHandler(this.txt_Quantidade_TextChanged);
            this.txt_Quantidade.Leave += new System.EventHandler(this.txt_Quantidade_Leave);
            // 
            // Label14
            // 
            this.Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label14.Location = new System.Drawing.Point(783, 104);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(116, 17);
            this.Label14.TabIndex = 104;
            this.Label14.Text = "VALOR TOTAL";
            // 
            // Label13
            // 
            this.Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label13.Location = new System.Drawing.Point(566, 105);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(142, 17);
            this.Label13.TabIndex = 105;
            this.Label13.Text = "VALOR UNITÁRIO";
            // 
            // txt_Cod_Barra
            // 
            this.txt_Cod_Barra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Cod_Barra.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Cod_Barra.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cod_Barra.Location = new System.Drawing.Point(466, 588);
            this.txt_Cod_Barra.Name = "txt_Cod_Barra";
            this.txt_Cod_Barra.Size = new System.Drawing.Size(530, 32);
            this.txt_Cod_Barra.TabIndex = 3;
            this.txt_Cod_Barra.Tag = "";
            this.txt_Cod_Barra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Cod_Barra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Cod_Barra_KeyDown);
            this.txt_Cod_Barra.Leave += new System.EventHandler(this.txt_Cod_Barra_Leave);
            // 
            // DataHora
            // 
            this.DataHora.Enabled = true;
            this.DataHora.Tick += new System.EventHandler(this.DataHora_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lb_Data);
            this.panel1.Controls.Add(this.lb_Horario);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 44);
            this.panel1.TabIndex = 111;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistema.UI.Properties.Resources.New_Logo_Clever1;
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_desconto
            // 
            this.lbl_desconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_desconto.AutoSize = true;
            this.lbl_desconto.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_desconto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_desconto.Location = new System.Drawing.Point(726, 591);
            this.lbl_desconto.Name = "lbl_desconto";
            this.lbl_desconto.Size = new System.Drawing.Size(157, 24);
            this.lbl_desconto.TabIndex = 104;
            this.lbl_desconto.Text = "DESCONTO R$";
            // 
            // txt_Desconto
            // 
            this.txt_Desconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Desconto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Desconto.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.txt_Desconto.Location = new System.Drawing.Point(889, 588);
            this.txt_Desconto.Name = "txt_Desconto";
            this.txt_Desconto.Size = new System.Drawing.Size(107, 32);
            this.txt_Desconto.TabIndex = 11;
            this.txt_Desconto.TabStop = false;
            this.txt_Desconto.Text = "0,00";
            this.txt_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Desconto.Leave += new System.EventHandler(this.txt_Desconto_Leave);
            // 
            // txt_DescricaoProduto
            // 
            this.txt_DescricaoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DescricaoProduto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_DescricaoProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescricaoProduto.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescricaoProduto.Location = new System.Drawing.Point(368, 68);
            this.txt_DescricaoProduto.Name = "txt_DescricaoProduto";
            this.txt_DescricaoProduto.Size = new System.Drawing.Size(629, 32);
            this.txt_DescricaoProduto.TabIndex = 4;
            this.txt_DescricaoProduto.TabStop = false;
            this.txt_DescricaoProduto.Tag = "";
            this.txt_DescricaoProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Cod_Barra_KeyDown);
            // 
            // txt_Quantidade2
            // 
            this.txt_Quantidade2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Quantidade2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Quantidade2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Quantidade2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantidade2.Location = new System.Drawing.Point(368, 122);
            this.txt_Quantidade2.Name = "txt_Quantidade2";
            this.txt_Quantidade2.ReadOnly = true;
            this.txt_Quantidade2.Size = new System.Drawing.Size(195, 32);
            this.txt_Quantidade2.TabIndex = 114;
            this.txt_Quantidade2.TabStop = false;
            this.txt_Quantidade2.Tag = "";
            this.txt_Quantidade2.Text = "0,00";
            this.txt_Quantidade2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(365, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 115;
            this.label2.Text = "QUANTIDADE";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(368, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 116;
            this.label3.Text = "DESCRIÇÃO";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.txt_ID,
            this.toolStripLabel4,
            this.toolStripLabel11,
            this.lbl_ID_UsuarioComissao1,
            this.toolStripLabel9,
            this.toolStripLabel1,
            this.txt_ID_Pessoa,
            this.toolStripLabel2,
            this.txt_CNPJ_CPF,
            this.toolStripLabel3,
            this.toolStripLabel6,
            this.txt_DescricaoPessoa});
            this.toolStrip1.Location = new System.Drawing.Point(0, 623);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 117;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel5.Text = "VENDA :";
            // 
            // txt_ID
            // 
            this.txt_ID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ID.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(28, 22);
            this.txt_ID.Text = "000";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel11.Text = "VENDEDOR :";
            // 
            // lbl_ID_UsuarioComissao1
            // 
            this.lbl_ID_UsuarioComissao1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_UsuarioComissao1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_ID_UsuarioComissao1.Name = "lbl_ID_UsuarioComissao1";
            this.lbl_ID_UsuarioComissao1.Size = new System.Drawing.Size(48, 22);
            this.lbl_ID_UsuarioComissao1.Text = "CLEVER";
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "CLIENTE : ";
            // 
            // txt_ID_Pessoa
            // 
            this.txt_ID_Pessoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ID_Pessoa.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ID_Pessoa.Name = "txt_ID_Pessoa";
            this.txt_ID_Pessoa.Size = new System.Drawing.Size(28, 22);
            this.txt_ID_Pessoa.Text = "001";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel2.Text = "-";
            // 
            // txt_CNPJ_CPF
            // 
            this.txt_CNPJ_CPF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CNPJ_CPF.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txt_CNPJ_CPF.Name = "txt_CNPJ_CPF";
            this.txt_CNPJ_CPF.Size = new System.Drawing.Size(59, 22);
            this.txt_CNPJ_CPF.Text = "CNPJ/CPF";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel3.Text = "-";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(147, 22);
            this.toolStripLabel6.Text = "F10 - MENU DE FUNÇÕES";
            // 
            // txt_DescricaoPessoa
            // 
            this.txt_DescricaoPessoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescricaoPessoa.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txt_DescricaoPessoa.Name = "txt_DescricaoPessoa";
            this.txt_DescricaoPessoa.Size = new System.Drawing.Size(125, 22);
            this.txt_DescricaoPessoa.Text = "CONSUMIDOR FINAL";
            // 
            // lb_Comissao1
            // 
            this.lb_Comissao1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Comissao1.AutoSize = true;
            this.lb_Comissao1.Location = new System.Drawing.Point(730, 48);
            this.lb_Comissao1.Name = "lb_Comissao1";
            this.lb_Comissao1.Size = new System.Drawing.Size(60, 14);
            this.lb_Comissao1.TabIndex = 112;
            this.lb_Comissao1.Text = "Comissão 1";
            this.lb_Comissao1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Comissao1.Visible = false;
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel10.Text = "CLIENTE : ";
            // 
            // cb_ID_UsuarioComissao1
            // 
            this.cb_ID_UsuarioComissao1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ID_UsuarioComissao1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_UsuarioComissao1.FormattingEnabled = true;
            this.cb_ID_UsuarioComissao1.Location = new System.Drawing.Point(797, 43);
            this.cb_ID_UsuarioComissao1.Name = "cb_ID_UsuarioComissao1";
            this.cb_ID_UsuarioComissao1.Size = new System.Drawing.Size(200, 22);
            this.cb_ID_UsuarioComissao1.TabIndex = 113;
            this.cb_ID_UsuarioComissao1.Tag = "T";
            this.cb_ID_UsuarioComissao1.Visible = false;
            this.cb_ID_UsuarioComissao1.TextChanged += new System.EventHandler(this.cb_ID_UsuarioComissao1_TextChanged);
            // 
            // pBox_Imagen_Principal
            // 
            this.pBox_Imagen_Principal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox_Imagen_Principal.Location = new System.Drawing.Point(1, 42);
            this.pBox_Imagen_Principal.Name = "pBox_Imagen_Principal";
            this.pBox_Imagen_Principal.Size = new System.Drawing.Size(357, 579);
            this.pBox_Imagen_Principal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_Imagen_Principal.TabIndex = 111;
            this.pBox_Imagen_Principal.TabStop = false;
            // 
            // UI_PDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1004, 648);
            this.Controls.Add(this.pBox_Imagen_Principal);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Quantidade2);
            this.Controls.Add(this.cb_ID_UsuarioComissao1);
            this.Controls.Add(this.lb_Comissao1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Desconto);
            this.Controls.Add(this.txt_ValorTotal);
            this.Controls.Add(this.txt_DescricaoProduto);
            this.Controls.Add(this.txt_ValorFinal);
            this.Controls.Add(this.txt_Quantidade);
            this.Controls.Add(this.lbl_desconto);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txt_ValorPedido);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.dg_Itens);
            this.Controls.Add(this.txt_Cod_Barra);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "UI_PDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_PDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UI_PDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_PDV_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_PDV_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Imagen_Principal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dg_Itens;
        internal System.Windows.Forms.Label lb_Horario;
        internal System.Windows.Forms.Label lb_Data;
        internal System.Windows.Forms.TextBox txt_ValorPedido;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.TextBox txt_ValorTotal;
        internal System.Windows.Forms.TextBox txt_ValorFinal;
        internal System.Windows.Forms.TextBox txt_Quantidade;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txt_Cod_Barra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer DataHora;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lbl_desconto;
        internal System.Windows.Forms.TextBox txt_Desconto;
        internal System.Windows.Forms.TextBox txt_DescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorTotal;
        internal System.Windows.Forms.TextBox txt_Quantidade2;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel txt_DescricaoPessoa;
        private System.Windows.Forms.ToolStripLabel txt_CNPJ_CPF;
        private System.Windows.Forms.ToolStripLabel txt_ID_Pessoa;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel txt_ID;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel lbl_ID_UsuarioComissao1;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        internal System.Windows.Forms.Label lb_Comissao1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        internal System.Windows.Forms.ComboBox cb_ID_UsuarioComissao1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.PictureBox pBox_Imagen_Principal;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
    }
}
namespace Sistema.UI
{
    partial class UI_Venda_Resumo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CustoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Lucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_TotalCReceber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dg_Financeiro = new System.Windows.Forms.DataGridView();
            this.col_Informacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_TotalLucro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TotalCusto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TotalProduto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Financeiro)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Quantidade,
            this.col_ValorVenda,
            this.col_CustoFinal,
            this.col_Lucro});
            this.dg_Itens.Location = new System.Drawing.Point(3, 6);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(766, 396);
            this.dg_Itens.TabIndex = 16;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.DataPropertyName = "ID";
            this.col_ID_Produto.HeaderText = "CÓDIGO";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ID_Produto.Width = 60;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "Descricao";
            this.col_Descricao.HeaderText = "DESCRIÇÃO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            this.col_Descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Quantidade.HeaderText = "QUANT.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            this.col_Quantidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Quantidade.Width = 70;
            // 
            // col_ValorVenda
            // 
            this.col_ValorVenda.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_ValorVenda.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ValorVenda.HeaderText = "VLR. TOTAL";
            this.col_ValorVenda.Name = "col_ValorVenda";
            this.col_ValorVenda.ReadOnly = true;
            this.col_ValorVenda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ValorVenda.Width = 105;
            // 
            // col_CustoFinal
            // 
            this.col_CustoFinal.DataPropertyName = "CustoFinal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_CustoFinal.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_CustoFinal.HeaderText = "CUSTO TOTAL";
            this.col_CustoFinal.Name = "col_CustoFinal";
            this.col_CustoFinal.ReadOnly = true;
            this.col_CustoFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_CustoFinal.Width = 105;
            // 
            // col_Lucro
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_Lucro.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Lucro.HeaderText = "LUCRO";
            this.col_Lucro.Name = "col_Lucro";
            this.col_Lucro.ReadOnly = true;
            this.col_Lucro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 493);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_TotalCReceber);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dg_Financeiro);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FINANCEIRO CLIENTE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_TotalCReceber
            // 
            this.txt_TotalCReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TotalCReceber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_TotalCReceber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCReceber.Location = new System.Drawing.Point(620, 422);
            this.txt_TotalCReceber.Name = "txt_TotalCReceber";
            this.txt_TotalCReceber.ReadOnly = true;
            this.txt_TotalCReceber.Size = new System.Drawing.Size(144, 20);
            this.txt_TotalCReceber.TabIndex = 102;
            this.txt_TotalCReceber.TabStop = false;
            this.txt_TotalCReceber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 101;
            this.label3.Text = "TOTAL";
            // 
            // dg_Financeiro
            // 
            this.dg_Financeiro.AllowUserToAddRows = false;
            this.dg_Financeiro.AllowUserToDeleteRows = false;
            this.dg_Financeiro.AllowUserToResizeColumns = false;
            this.dg_Financeiro.AllowUserToResizeRows = false;
            this.dg_Financeiro.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Financeiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Financeiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Financeiro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Informacao,
            this.col_Parcela,
            this.col_Vencimento,
            this.col_Valor});
            this.dg_Financeiro.Location = new System.Drawing.Point(3, 3);
            this.dg_Financeiro.MultiSelect = false;
            this.dg_Financeiro.Name = "dg_Financeiro";
            this.dg_Financeiro.ReadOnly = true;
            this.dg_Financeiro.RowHeadersVisible = false;
            this.dg_Financeiro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Financeiro.Size = new System.Drawing.Size(766, 409);
            this.dg_Financeiro.TabIndex = 17;
            // 
            // col_Informacao
            // 
            this.col_Informacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Informacao.DataPropertyName = "Descricao";
            this.col_Informacao.HeaderText = "INFORMAÇÃO";
            this.col_Informacao.Name = "col_Informacao";
            this.col_Informacao.ReadOnly = true;
            this.col_Informacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Parcela
            // 
            this.col_Parcela.DataPropertyName = "ResumoParcela";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Parcela.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Parcela.HeaderText = "PARCELA";
            this.col_Parcela.Name = "col_Parcela";
            this.col_Parcela.ReadOnly = true;
            this.col_Parcela.Width = 70;
            // 
            // col_Vencimento
            // 
            this.col_Vencimento.DataPropertyName = "Vencimento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.col_Vencimento.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Vencimento.HeaderText = "VENCIMENTO";
            this.col_Vencimento.Name = "col_Vencimento";
            this.col_Vencimento.ReadOnly = true;
            this.col_Vencimento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Valor
            // 
            this.col_Valor.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.col_Valor.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_Valor.HeaderText = "VALOR";
            this.col_Valor.Name = "col_Valor";
            this.col_Valor.ReadOnly = true;
            this.col_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_TotalLucro);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_TotalCusto);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txt_TotalProduto);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.dg_Itens);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MARGEM PRODUTOS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_TotalLucro
            // 
            this.txt_TotalLucro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TotalLucro.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_TotalLucro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalLucro.Location = new System.Drawing.Point(620, 424);
            this.txt_TotalLucro.Name = "txt_TotalLucro";
            this.txt_TotalLucro.ReadOnly = true;
            this.txt_TotalLucro.Size = new System.Drawing.Size(144, 20);
            this.txt_TotalLucro.TabIndex = 100;
            this.txt_TotalLucro.TabStop = false;
            this.txt_TotalLucro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 99;
            this.label2.Text = "LUCRO TOTAL";
            // 
            // txt_TotalCusto
            // 
            this.txt_TotalCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TotalCusto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_TotalCusto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCusto.Location = new System.Drawing.Point(449, 424);
            this.txt_TotalCusto.Name = "txt_TotalCusto";
            this.txt_TotalCusto.ReadOnly = true;
            this.txt_TotalCusto.Size = new System.Drawing.Size(144, 20);
            this.txt_TotalCusto.TabIndex = 100;
            this.txt_TotalCusto.TabStop = false;
            this.txt_TotalCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 99;
            this.label1.Text = "CUSTO TOTAL (R$)";
            // 
            // txt_TotalProduto
            // 
            this.txt_TotalProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TotalProduto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_TotalProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalProduto.Location = new System.Drawing.Point(276, 424);
            this.txt_TotalProduto.Name = "txt_TotalProduto";
            this.txt_TotalProduto.ReadOnly = true;
            this.txt_TotalProduto.Size = new System.Drawing.Size(144, 20);
            this.txt_TotalProduto.TabIndex = 100;
            this.txt_TotalProduto.TabStop = false;
            this.txt_TotalProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(273, 406);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 14);
            this.label16.TabIndex = 99;
            this.label16.Text = "TOTAL PRODUTO (R$)";
            // 
            // UI_Venda_Resumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(780, 493);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Venda_Resumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESUMO VENDA";
            this.Load += new System.EventHandler(this.UI_Venda_Resumo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Venda_Resumo_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Financeiro)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dg_Itens;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.DataGridView dg_Financeiro;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.TextBox txt_TotalLucro;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_TotalCusto;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_TotalProduto;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CustoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Lucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Informacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor;
        internal System.Windows.Forms.TextBox txt_TotalCReceber;
        internal System.Windows.Forms.Label label3;
    }
}
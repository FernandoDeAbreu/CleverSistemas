namespace Sistema.UI
{
    partial class UI_CFe
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Pessoa = new System.Windows.Forms.TextBox();
            this.dg_Itens = new System.Windows.Forms.DataGridView();
            this.col_ID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_TotalNF = new System.Windows.Forms.TextBox();
            this.txt_Vlr_Produto = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.txt_Vlr_Desc = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txt_ID_Pessoa = new System.Windows.Forms.TextBox();
            this.bt_Emitir = new System.Windows.Forms.Button();
            this.lb_Status = new System.Windows.Forms.Label();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTE";
            // 
            // txt_Pessoa
            // 
            this.txt_Pessoa.Location = new System.Drawing.Point(15, 27);
            this.txt_Pessoa.Name = "txt_Pessoa";
            this.txt_Pessoa.ReadOnly = true;
            this.txt_Pessoa.Size = new System.Drawing.Size(393, 20);
            this.txt_Pessoa.TabIndex = 1;
            this.txt_Pessoa.TabStop = false;
            // 
            // dg_Itens
            // 
            this.dg_Itens.AllowUserToAddRows = false;
            this.dg_Itens.AllowUserToDeleteRows = false;
            this.dg_Itens.AllowUserToResizeColumns = false;
            this.dg_Itens.AllowUserToResizeRows = false;
            this.dg_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Itens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Itens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID_Item,
            this.col_ID_Produto,
            this.col_Descricao,
            this.col_Quantidade,
            this.col_ValorUnitario,
            this.col_Desconto,
            this.col_ValorTotal});
            this.dg_Itens.Location = new System.Drawing.Point(15, 55);
            this.dg_Itens.MultiSelect = false;
            this.dg_Itens.Name = "dg_Itens";
            this.dg_Itens.ReadOnly = true;
            this.dg_Itens.RowHeadersVisible = false;
            this.dg_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Itens.Size = new System.Drawing.Size(748, 299);
            this.dg_Itens.StandardTab = true;
            this.dg_Itens.TabIndex = 42;
            this.dg_Itens.TabStop = false;
            // 
            // col_ID_Item
            // 
            this.col_ID_Item.DataPropertyName = "IDItem";
            this.col_ID_Item.HeaderText = "ID";
            this.col_ID_Item.Name = "col_ID_Item";
            this.col_ID_Item.ReadOnly = true;
            this.col_ID_Item.Visible = false;
            // 
            // col_ID_Produto
            // 
            this.col_ID_Produto.HeaderText = "ID Produto";
            this.col_ID_Produto.Name = "col_ID_Produto";
            this.col_ID_Produto.ReadOnly = true;
            this.col_ID_Produto.Visible = false;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "DescricaoProduto";
            this.col_Descricao.HeaderText = "PRODUTO";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_Quantidade
            // 
            this.col_Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.col_Quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Quantidade.HeaderText = "QUANT.";
            this.col_Quantidade.Name = "col_Quantidade";
            this.col_Quantidade.ReadOnly = true;
            // 
            // col_ValorUnitario
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_ValorUnitario.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ValorUnitario.HeaderText = "VALOR UNIT.";
            this.col_ValorUnitario.Name = "col_ValorUnitario";
            this.col_ValorUnitario.ReadOnly = true;
            // 
            // col_Desconto
            // 
            this.col_Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_Desconto.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Desconto.HeaderText = "DESC.";
            this.col_Desconto.Name = "col_Desconto";
            this.col_Desconto.ReadOnly = true;
            this.col_Desconto.Width = 70;
            // 
            // col_ValorTotal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_ValorTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_ValorTotal.HeaderText = "TOTAL";
            this.col_ValorTotal.Name = "col_ValorTotal";
            this.col_ValorTotal.ReadOnly = true;
            // 
            // txt_TotalNF
            // 
            this.txt_TotalNF.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalNF.Location = new System.Drawing.Point(630, 363);
            this.txt_TotalNF.Name = "txt_TotalNF";
            this.txt_TotalNF.ReadOnly = true;
            this.txt_TotalNF.Size = new System.Drawing.Size(133, 29);
            this.txt_TotalNF.TabIndex = 43;
            this.txt_TotalNF.TabStop = false;
            this.txt_TotalNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Vlr_Produto
            // 
            this.txt_Vlr_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Vlr_Produto.Location = new System.Drawing.Point(128, 360);
            this.txt_Vlr_Produto.Name = "txt_Vlr_Produto";
            this.txt_Vlr_Produto.ReadOnly = true;
            this.txt_Vlr_Produto.Size = new System.Drawing.Size(79, 20);
            this.txt_Vlr_Produto.TabIndex = 132;
            this.txt_Vlr_Produto.TabStop = false;
            this.txt_Vlr_Produto.Tag = "T";
            this.txt_Vlr_Produto.Text = "0,00";
            this.txt_Vlr_Produto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(21, 363);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(98, 13);
            this.label65.TabIndex = 134;
            this.label65.Text = "TOTAL PRODUTOS";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(560, 371);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(64, 13);
            this.label75.TabIndex = 135;
            this.label75.Text = "TOTAL CF-e";
            // 
            // txt_Vlr_Desc
            // 
            this.txt_Vlr_Desc.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Vlr_Desc.Location = new System.Drawing.Point(365, 360);
            this.txt_Vlr_Desc.Name = "txt_Vlr_Desc";
            this.txt_Vlr_Desc.ReadOnly = true;
            this.txt_Vlr_Desc.Size = new System.Drawing.Size(79, 20);
            this.txt_Vlr_Desc.TabIndex = 133;
            this.txt_Vlr_Desc.TabStop = false;
            this.txt_Vlr_Desc.Tag = "T";
            this.txt_Vlr_Desc.Text = "0,00";
            this.txt_Vlr_Desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(292, 363);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(64, 13);
            this.label66.TabIndex = 136;
            this.label66.Text = "DESCONTO";
            // 
            // txt_ID_Pessoa
            // 
            this.txt_ID_Pessoa.Enabled = false;
            this.txt_ID_Pessoa.Location = new System.Drawing.Point(374, 27);
            this.txt_ID_Pessoa.Name = "txt_ID_Pessoa";
            this.txt_ID_Pessoa.Size = new System.Drawing.Size(32, 20);
            this.txt_ID_Pessoa.TabIndex = 1;
            // 
            // bt_Emitir
            // 
            this.bt_Emitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Emitir.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Emitir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Emitir.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Emitir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Emitir.Location = new System.Drawing.Point(653, 398);
            this.bt_Emitir.Name = "bt_Emitir";
            this.bt_Emitir.Size = new System.Drawing.Size(110, 54);
            this.bt_Emitir.TabIndex = 137;
            this.bt_Emitir.Text = "EMITIR CF-e SAT (F5)";
            this.bt_Emitir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Emitir.UseVisualStyleBackColor = false;
            this.bt_Emitir.Click += new System.EventHandler(this.bt_Emitir_Click);
            // 
            // lb_Status
            // 
            this.lb_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_Status.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Status.Location = new System.Drawing.Point(520, 16);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(243, 19);
            this.lb_Status.TabIndex = 0;
            this.lb_Status.Text = "STATUS";
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Cancelar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Cancelar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancelar.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Cancelar.Location = new System.Drawing.Point(537, 398);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(110, 54);
            this.bt_Cancelar.TabIndex = 137;
            this.bt_Cancelar.Text = "CANCELAR CF-e SAT";
            this.bt_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Cancelar.UseVisualStyleBackColor = false;
            this.bt_Cancelar.Click += new System.EventHandler(this.bt_Cancelar_Click);
            // 
            // UI_CFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(775, 462);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.bt_Emitir);
            this.Controls.Add(this.txt_Vlr_Produto);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.txt_Vlr_Desc);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.txt_TotalNF);
            this.Controls.Add(this.dg_Itens);
            this.Controls.Add(this.txt_Pessoa);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ID_Pessoa);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_CFe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_NFCe_SAT";
            this.Load += new System.EventHandler(this.UI_NFCe_SAT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_NFCe_SAT_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_NFCe_SAT_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Itens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Pessoa;
        internal System.Windows.Forms.DataGridView dg_Itens;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ValorTotal;
        private System.Windows.Forms.TextBox txt_TotalNF;
        internal System.Windows.Forms.TextBox txt_Vlr_Produto;
        internal System.Windows.Forms.Label label65;
        internal System.Windows.Forms.Label label75;
        internal System.Windows.Forms.TextBox txt_Vlr_Desc;
        internal System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txt_ID_Pessoa;
        internal System.Windows.Forms.Button bt_Emitir;
        private System.Windows.Forms.Label lb_Status;
        internal System.Windows.Forms.Button bt_Cancelar;

    }
}
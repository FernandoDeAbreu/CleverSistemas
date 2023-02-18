namespace Sistema.UI
{
    partial class UI_Produto_EstoqueMovimento
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
            this.txt_InformacaoItem = new System.Windows.Forms.TextBox();
            this.bt_LancaMovimento = new System.Windows.Forms.Button();
            this.Label20 = new System.Windows.Forms.Label();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.cb_ID_Produto = new System.Windows.Forms.ComboBox();
            this.gb_Pesquisa = new System.Windows.Forms.GroupBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.txt_EstoqueAtual = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.dg_Produto = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ID_Grade = new System.Windows.Forms.ComboBox();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.gb_Pesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Pesquisa);
            // 
            // bt_Fecha
            // 
            this.bt_Fecha.Location = new System.Drawing.Point(849, 662);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Location = new System.Drawing.Point(93, 662);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Location = new System.Drawing.Point(192, 662);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Location = new System.Drawing.Point(291, 662);
            // 
            // bt_Imprime
            // 
            this.bt_Imprime.Location = new System.Drawing.Point(489, 662);
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.Location = new System.Drawing.Point(687, 662);
            // 
            // bt_Exclui
            // 
            this.bt_Exclui.Location = new System.Drawing.Point(390, 662);
            // 
            // bt_Visualiza
            // 
            this.bt_Visualiza.Location = new System.Drawing.Point(588, 662);
            // 
            // txt_InformacaoItem
            // 
            this.txt_InformacaoItem.BackColor = System.Drawing.SystemColors.Window;
            this.txt_InformacaoItem.Location = new System.Drawing.Point(293, 92);
            this.txt_InformacaoItem.MaxLength = 200;
            this.txt_InformacaoItem.Multiline = true;
            this.txt_InformacaoItem.Name = "txt_InformacaoItem";
            this.txt_InformacaoItem.Size = new System.Drawing.Size(474, 22);
            this.txt_InformacaoItem.TabIndex = 8;
            this.txt_InformacaoItem.Tag = "";
            // 
            // bt_LancaMovimento
            // 
            this.bt_LancaMovimento.BackColor = System.Drawing.SystemColors.Control;
            this.bt_LancaMovimento.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_LancaMovimento.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_LancaMovimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_LancaMovimento.Location = new System.Drawing.Point(775, 86);
            this.bt_LancaMovimento.Name = "bt_LancaMovimento";
            this.bt_LancaMovimento.Size = new System.Drawing.Size(115, 34);
            this.bt_LancaMovimento.TabIndex = 10;
            this.bt_LancaMovimento.Text = "LANÇAR";
            this.bt_LancaMovimento.UseVisualStyleBackColor = false;
            this.bt_LancaMovimento.Click += new System.EventHandler(this.bt_LancaMovimento_Click);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(293, 73);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(69, 15);
            this.Label20.TabIndex = 38;
            this.Label20.Text = "Informação";
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Quantidade.Location = new System.Drawing.Point(199, 92);
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(86, 21);
            this.txt_Quantidade.TabIndex = 7;
            this.txt_Quantidade.Tag = "";
            this.txt_Quantidade.Text = "1,00";
            this.txt_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Quantidade.Leave += new System.EventHandler(this.txt_Quantidade_Leave);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(10, 16);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(50, 15);
            this.Label11.TabIndex = 39;
            this.Label11.Text = "Produto";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(209, 74);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(71, 15);
            this.Label12.TabIndex = 40;
            this.Label12.Text = "Quantidade";
            // 
            // cb_ID_Produto
            // 
            this.cb_ID_Produto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Produto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Produto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Produto.FormattingEnabled = true;
            this.cb_ID_Produto.Location = new System.Drawing.Point(10, 34);
            this.cb_ID_Produto.MaxDropDownItems = 15;
            this.cb_ID_Produto.Name = "cb_ID_Produto";
            this.cb_ID_Produto.Size = new System.Drawing.Size(474, 23);
            this.cb_ID_Produto.TabIndex = 1;
            this.cb_ID_Produto.Tag = "";
            this.cb_ID_Produto.Leave += new System.EventHandler(this.cb_ID_Produto_Leave);
            // 
            // gb_Pesquisa
            // 
            this.gb_Pesquisa.Controls.Add(this.Label17);
            this.gb_Pesquisa.Controls.Add(this.mk_Data);
            this.gb_Pesquisa.Controls.Add(this.txt_EstoqueAtual);
            this.gb_Pesquisa.Controls.Add(this.label55);
            this.gb_Pesquisa.Controls.Add(this.dg_Produto);
            this.gb_Pesquisa.Controls.Add(this.label19);
            this.gb_Pesquisa.Controls.Add(this.label2);
            this.gb_Pesquisa.Controls.Add(this.label1);
            this.gb_Pesquisa.Controls.Add(this.Label11);
            this.gb_Pesquisa.Controls.Add(this.txt_InformacaoItem);
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Grade);
            this.gb_Pesquisa.Controls.Add(this.cb_Tipo);
            this.gb_Pesquisa.Controls.Add(this.cb_ID_Produto);
            this.gb_Pesquisa.Controls.Add(this.bt_LancaMovimento);
            this.gb_Pesquisa.Controls.Add(this.Label12);
            this.gb_Pesquisa.Controls.Add(this.Label20);
            this.gb_Pesquisa.Controls.Add(this.txt_Quantidade);
            this.gb_Pesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Pesquisa.Location = new System.Drawing.Point(2, 3);
            this.gb_Pesquisa.Name = "gb_Pesquisa";
            this.gb_Pesquisa.Size = new System.Drawing.Size(938, 620);
            this.gb_Pesquisa.TabIndex = 43;
            this.gb_Pesquisa.TabStop = false;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(785, 15);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(33, 15);
            this.Label17.TabIndex = 750;
            this.Label17.Text = "Data";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(789, 34);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(101, 21);
            this.mk_Data.TabIndex = 5;
            this.mk_Data.Tag = "";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // txt_EstoqueAtual
            // 
            this.txt_EstoqueAtual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_EstoqueAtual.Location = new System.Drawing.Point(492, 34);
            this.txt_EstoqueAtual.Name = "txt_EstoqueAtual";
            this.txt_EstoqueAtual.ReadOnly = true;
            this.txt_EstoqueAtual.Size = new System.Drawing.Size(79, 21);
            this.txt_EstoqueAtual.TabIndex = 2;
            this.txt_EstoqueAtual.TabStop = false;
            this.txt_EstoqueAtual.Tag = "T";
            this.txt_EstoqueAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(491, 15);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(71, 15);
            this.label55.TabIndex = 142;
            this.label55.Text = "Qt. Estoque";
            // 
            // dg_Produto
            // 
            this.dg_Produto.AllowUserToAddRows = false;
            this.dg_Produto.AllowUserToDeleteRows = false;
            this.dg_Produto.AllowUserToResizeRows = false;
            this.dg_Produto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Produto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Produto.Location = new System.Drawing.Point(3, 126);
            this.dg_Produto.MultiSelect = false;
            this.dg_Produto.Name = "dg_Produto";
            this.dg_Produto.ReadOnly = true;
            this.dg_Produto.RowHeadersVisible = false;
            this.dg_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Produto.Size = new System.Drawing.Size(928, 486);
            this.dg_Produto.StandardTab = true;
            this.dg_Produto.TabIndex = 140;
            this.dg_Produto.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(64, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(141, 15);
            this.label19.TabIndex = 139;
            this.label19.Text = "F7 (Pesquisa avançada)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Grade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tipo de movimentação";
            // 
            // cb_ID_Grade
            // 
            this.cb_ID_Grade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ID_Grade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ID_Grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Grade.FormattingEnabled = true;
            this.cb_ID_Grade.Location = new System.Drawing.Point(586, 34);
            this.cb_ID_Grade.MaxDropDownItems = 15;
            this.cb_ID_Grade.Name = "cb_ID_Grade";
            this.cb_ID_Grade.Size = new System.Drawing.Size(181, 23);
            this.cb_ID_Grade.TabIndex = 3;
            this.cb_ID_Grade.Tag = "";
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(10, 92);
            this.cb_Tipo.MaxDropDownItems = 15;
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(181, 23);
            this.cb_Tipo.TabIndex = 6;
            this.cb_Tipo.Tag = "";
            // 
            // UI_Produto_EstoqueMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Produto_EstoqueMovimento";
            this.Load += new System.EventHandler(this.UI_Produto_EstoqueMovimento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Produto_EstoqueMovimento_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.gb_Pesquisa.ResumeLayout(false);
            this.gb_Pesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Produto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_InformacaoItem;
        internal System.Windows.Forms.Button bt_LancaMovimento;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.TextBox txt_Quantidade;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cb_ID_Produto;
        private System.Windows.Forms.GroupBox gb_Pesquisa;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cb_Tipo;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.DataGridView dg_Produto;
        internal System.Windows.Forms.TextBox txt_EstoqueAtual;
        internal System.Windows.Forms.Label label55;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.ComboBox cb_ID_Grade;
    }
}

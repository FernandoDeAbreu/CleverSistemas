namespace Sistema.UI
{
    partial class UI_NCM
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
            this.bt_PesquisaTabela = new System.Windows.Forms.Button();
            this.dg_Tabela = new System.Windows.Forms.DataGridView();
            this.col_NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AliqNacFederal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AliqImpFederal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AliqEstadual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pesquisa_Tabela = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bt_CEST = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_CEST = new System.Windows.Forms.DataGridView();
            this.col_NCM_CEST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CEST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DescricaoCEST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabela)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CEST)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_PesquisaTabela);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.dg_Tabela);
            this.TabPage1.Text = "NCM IBPT";
            // 
            // tabctl
            // 
            this.tabctl.Controls.Add(this.tabPage3);
            this.tabctl.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage2, 0);
            this.tabctl.Controls.SetChildIndex(this.TabPage1, 0);
            // 
            // bt_PesquisaTabela
            // 
            this.bt_PesquisaTabela.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaTabela.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaTabela.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaTabela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaTabela.Location = new System.Drawing.Point(13, 17);
            this.bt_PesquisaTabela.Name = "bt_PesquisaTabela";
            this.bt_PesquisaTabela.Size = new System.Drawing.Size(226, 45);
            this.bt_PesquisaTabela.TabIndex = 2;
            this.bt_PesquisaTabela.Text = "PESQUISA TABELA IBPT";
            this.bt_PesquisaTabela.UseVisualStyleBackColor = false;
            this.bt_PesquisaTabela.Click += new System.EventHandler(this.bt_PesquisaTabela_Click);
            // 
            // dg_Tabela
            // 
            this.dg_Tabela.AllowUserToAddRows = false;
            this.dg_Tabela.AllowUserToDeleteRows = false;
            this.dg_Tabela.AllowUserToResizeColumns = false;
            this.dg_Tabela.AllowUserToResizeRows = false;
            this.dg_Tabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Tabela.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Tabela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_NCM,
            this.col_Descricao,
            this.col_EX,
            this.col_AliqNacFederal,
            this.col_AliqImpFederal,
            this.col_AliqEstadual});
            this.dg_Tabela.Location = new System.Drawing.Point(13, 70);
            this.dg_Tabela.MultiSelect = false;
            this.dg_Tabela.Name = "dg_Tabela";
            this.dg_Tabela.ReadOnly = true;
            this.dg_Tabela.RowHeadersVisible = false;
            this.dg_Tabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Tabela.Size = new System.Drawing.Size(922, 542);
            this.dg_Tabela.StandardTab = true;
            this.dg_Tabela.TabIndex = 10;
            // 
            // col_NCM
            // 
            this.col_NCM.DataPropertyName = "codigo";
            dataGridViewCellStyle1.NullValue = null;
            this.col_NCM.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_NCM.HeaderText = "NCM";
            this.col_NCM.Name = "col_NCM";
            this.col_NCM.ReadOnly = true;
            // 
            // col_Descricao
            // 
            this.col_Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Descricao.DataPropertyName = "descricao";
            this.col_Descricao.HeaderText = "Descrição";
            this.col_Descricao.Name = "col_Descricao";
            this.col_Descricao.ReadOnly = true;
            // 
            // col_EX
            // 
            this.col_EX.DataPropertyName = "ex";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_EX.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_EX.HeaderText = "EX TIPI";
            this.col_EX.Name = "col_EX";
            this.col_EX.ReadOnly = true;
            this.col_EX.Width = 70;
            // 
            // col_AliqNacFederal
            // 
            this.col_AliqNacFederal.DataPropertyName = "nacionalfederal";
            dataGridViewCellStyle3.Format = "N2";
            this.col_AliqNacFederal.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_AliqNacFederal.HeaderText = "Aliq. Nac. Federal";
            this.col_AliqNacFederal.Name = "col_AliqNacFederal";
            this.col_AliqNacFederal.ReadOnly = true;
            this.col_AliqNacFederal.Width = 150;
            // 
            // col_AliqImpFederal
            // 
            this.col_AliqImpFederal.DataPropertyName = "importadosfederal";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_AliqImpFederal.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_AliqImpFederal.HeaderText = "Aliq. Imp. Federal";
            this.col_AliqImpFederal.Name = "col_AliqImpFederal";
            this.col_AliqImpFederal.ReadOnly = true;
            this.col_AliqImpFederal.Width = 150;
            // 
            // col_AliqEstadual
            // 
            this.col_AliqEstadual.DataPropertyName = "estadual";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_AliqEstadual.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_AliqEstadual.HeaderText = "Aliq. Estadual";
            this.col_AliqEstadual.Name = "col_AliqEstadual";
            this.col_AliqEstadual.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "ATENÇÃO: BAIXE A TABELA ATUALIZADA REFERENTE AO PROJETO DE OLHO NO IMPOSTO.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bt_CEST);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.dg_CEST);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CEST";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bt_CEST
            // 
            this.bt_CEST.BackColor = System.Drawing.SystemColors.Control;
            this.bt_CEST.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CEST.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_CEST.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_CEST.Location = new System.Drawing.Point(12, 16);
            this.bt_CEST.Name = "bt_CEST";
            this.bt_CEST.Size = new System.Drawing.Size(226, 45);
            this.bt_CEST.TabIndex = 119;
            this.bt_CEST.Text = "PESQUISA TABELA CEST";
            this.bt_CEST.UseVisualStyleBackColor = false;
            this.bt_CEST.Click += new System.EventHandler(this.bt_CEST_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "ATENÇÃO: BAIXE A TABELA ATUALIZADA REFERENTE AO CÓDIGO CEST";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dg_CEST
            // 
            this.dg_CEST.AllowUserToAddRows = false;
            this.dg_CEST.AllowUserToDeleteRows = false;
            this.dg_CEST.AllowUserToResizeColumns = false;
            this.dg_CEST.AllowUserToResizeRows = false;
            this.dg_CEST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_CEST.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_CEST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_CEST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CEST.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_NCM_CEST,
            this.col_CEST,
            this.col_DescricaoCEST});
            this.dg_CEST.Location = new System.Drawing.Point(12, 69);
            this.dg_CEST.MultiSelect = false;
            this.dg_CEST.Name = "dg_CEST";
            this.dg_CEST.ReadOnly = true;
            this.dg_CEST.RowHeadersVisible = false;
            this.dg_CEST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_CEST.Size = new System.Drawing.Size(919, 544);
            this.dg_CEST.StandardTab = true;
            this.dg_CEST.TabIndex = 120;
            // 
            // col_NCM_CEST
            // 
            this.col_NCM_CEST.DataPropertyName = "NCM";
            dataGridViewCellStyle6.NullValue = null;
            this.col_NCM_CEST.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_NCM_CEST.HeaderText = "NCM";
            this.col_NCM_CEST.Name = "col_NCM_CEST";
            this.col_NCM_CEST.ReadOnly = true;
            // 
            // col_CEST
            // 
            this.col_CEST.DataPropertyName = "CEST";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_CEST.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_CEST.HeaderText = "CEST";
            this.col_CEST.Name = "col_CEST";
            this.col_CEST.ReadOnly = true;
            // 
            // col_DescricaoCEST
            // 
            this.col_DescricaoCEST.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_DescricaoCEST.DataPropertyName = "descricao";
            this.col_DescricaoCEST.HeaderText = "Descrição";
            this.col_DescricaoCEST.Name = "col_DescricaoCEST";
            this.col_DescricaoCEST.ReadOnly = true;
            // 
            // UI_NCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_NCM";
            this.Load += new System.EventHandler(this.UI_NCM_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tabela)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CEST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bt_PesquisaTabela;
        internal System.Windows.Forms.DataGridView dg_Tabela;
        private System.Windows.Forms.OpenFileDialog Pesquisa_Tabela;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EX;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AliqNacFederal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AliqImpFederal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AliqEstadual;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.Button bt_CEST;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dg_CEST;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NCM_CEST;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CEST;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DescricaoCEST;
    }
}

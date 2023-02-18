namespace Sistema.UI
{
    partial class UI_Boleto_Remessa
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
            this.gb_Remessa = new System.Windows.Forms.GroupBox();
            this.ck_GeradoRemessa = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.cb_Cedente = new System.Windows.Forms.ComboBox();
            this.bt_GerarRemessa = new System.Windows.Forms.Button();
            this.dg_BoletoRemessa = new System.Windows.Forms.DataGridView();
            this.col_SelecionaRemessa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ID_BoletoRemessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MovimentoRemessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Remessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Remessa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_BoletoRemessa)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Remessa);
            this.TabPage1.Text = "REMESSA";
            // 
            // gb_Remessa
            // 
            this.gb_Remessa.Controls.Add(this.ck_GeradoRemessa);
            this.gb_Remessa.Controls.Add(this.label42);
            this.gb_Remessa.Controls.Add(this.cb_Cedente);
            this.gb_Remessa.Controls.Add(this.bt_GerarRemessa);
            this.gb_Remessa.Controls.Add(this.dg_BoletoRemessa);
            this.gb_Remessa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Remessa.Location = new System.Drawing.Point(2, 3);
            this.gb_Remessa.Name = "gb_Remessa";
            this.gb_Remessa.Size = new System.Drawing.Size(938, 620);
            this.gb_Remessa.TabIndex = 2;
            this.gb_Remessa.TabStop = false;
            // 
            // ck_GeradoRemessa
            // 
            this.ck_GeradoRemessa.AutoSize = true;
            this.ck_GeradoRemessa.Location = new System.Drawing.Point(409, 40);
            this.ck_GeradoRemessa.Name = "ck_GeradoRemessa";
            this.ck_GeradoRemessa.Size = new System.Drawing.Size(155, 19);
            this.ck_GeradoRemessa.TabIndex = 2;
            this.ck_GeradoRemessa.Text = "Exibir arquivos gerados";
            this.ck_GeradoRemessa.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(7, 18);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(54, 15);
            this.label42.TabIndex = 116;
            this.label42.Text = "Cedente";
            // 
            // cb_Cedente
            // 
            this.cb_Cedente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Cedente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Cedente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Cedente.FormattingEnabled = true;
            this.cb_Cedente.Items.AddRange(new object[] {
            "Bancoob"});
            this.cb_Cedente.Location = new System.Drawing.Point(6, 36);
            this.cb_Cedente.Name = "cb_Cedente";
            this.cb_Cedente.Size = new System.Drawing.Size(384, 23);
            this.cb_Cedente.TabIndex = 1;
            // 
            // bt_GerarRemessa
            // 
            this.bt_GerarRemessa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_GerarRemessa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_GerarRemessa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_GerarRemessa.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_GerarRemessa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_GerarRemessa.Location = new System.Drawing.Point(752, 569);
            this.bt_GerarRemessa.Name = "bt_GerarRemessa";
            this.bt_GerarRemessa.Size = new System.Drawing.Size(182, 45);
            this.bt_GerarRemessa.TabIndex = 20;
            this.bt_GerarRemessa.Text = "GERAR REMESSA";
            this.bt_GerarRemessa.UseVisualStyleBackColor = false;
            this.bt_GerarRemessa.Click += new System.EventHandler(this.bt_GerarRemessa_Click);
            // 
            // dg_BoletoRemessa
            // 
            this.dg_BoletoRemessa.AllowUserToAddRows = false;
            this.dg_BoletoRemessa.AllowUserToDeleteRows = false;
            this.dg_BoletoRemessa.AllowUserToResizeRows = false;
            this.dg_BoletoRemessa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_BoletoRemessa.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_BoletoRemessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_BoletoRemessa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_BoletoRemessa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_SelecionaRemessa,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.col_ID_BoletoRemessa,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn26,
            this.col_MovimentoRemessa,
            this.col_Remessa,
            this.col_Arquivo});
            this.dg_BoletoRemessa.Location = new System.Drawing.Point(2, 69);
            this.dg_BoletoRemessa.MultiSelect = false;
            this.dg_BoletoRemessa.Name = "dg_BoletoRemessa";
            this.dg_BoletoRemessa.RowHeadersVisible = false;
            this.dg_BoletoRemessa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_BoletoRemessa.Size = new System.Drawing.Size(933, 497);
            this.dg_BoletoRemessa.StandardTab = true;
            this.dg_BoletoRemessa.TabIndex = 10;
            this.dg_BoletoRemessa.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_BoletoRemessa_CellPainting);
            this.dg_BoletoRemessa.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_BoletoRemessa_ColumnHeaderMouseClick);
            this.dg_BoletoRemessa.DoubleClick += new System.EventHandler(this.dg_BoletoRemessa_DoubleClick);
            // 
            // col_SelecionaRemessa
            // 
            this.col_SelecionaRemessa.HeaderText = "";
            this.col_SelecionaRemessa.Name = "col_SelecionaRemessa";
            this.col_SelecionaRemessa.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DescricaoPessoa";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pessoa";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Emissao";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn8.HeaderText = "Emissão";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NossoNumero";
            this.dataGridViewTextBoxColumn9.HeaderText = "Nosso Número";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Vencimento";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn11.HeaderText = "Vencimento";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn13.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 70;
            // 
            // col_ID_BoletoRemessa
            // 
            this.col_ID_BoletoRemessa.DataPropertyName = "ID";
            this.col_ID_BoletoRemessa.HeaderText = "ID";
            this.col_ID_BoletoRemessa.Name = "col_ID_BoletoRemessa";
            this.col_ID_BoletoRemessa.ReadOnly = true;
            this.col_ID_BoletoRemessa.Visible = false;
            this.col_ID_BoletoRemessa.Width = 50;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Acrescimo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn16.HeaderText = "Acréscimo";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 70;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Desconto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn17.HeaderText = "Desconto";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 70;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "ID_Cedente";
            this.dataGridViewTextBoxColumn26.HeaderText = "Cedente";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // col_MovimentoRemessa
            // 
            this.col_MovimentoRemessa.DataPropertyName = "Descricao_Movimento";
            this.col_MovimentoRemessa.HeaderText = "Tipo Movimento";
            this.col_MovimentoRemessa.Name = "col_MovimentoRemessa";
            // 
            // col_Remessa
            // 
            this.col_Remessa.DataPropertyName = "Descricao_Remessa";
            this.col_Remessa.HeaderText = "Remessa";
            this.col_Remessa.Name = "col_Remessa";
            this.col_Remessa.ReadOnly = true;
            // 
            // col_Arquivo
            // 
            this.col_Arquivo.DataPropertyName = "Arquivo";
            this.col_Arquivo.HeaderText = "Arquivo";
            this.col_Arquivo.Name = "col_Arquivo";
            this.col_Arquivo.ReadOnly = true;
            this.col_Arquivo.Width = 130;
            // 
            // UI_Boleto_Remessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Boleto_Remessa";
            this.Load += new System.EventHandler(this.UI_Boleto_Remessa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Boleto_Remessa_KeyDown);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Remessa.ResumeLayout(false);
            this.gb_Remessa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_BoletoRemessa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Remessa;
        private System.Windows.Forms.CheckBox ck_GeradoRemessa;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox cb_Cedente;
        internal System.Windows.Forms.Button bt_GerarRemessa;
        internal System.Windows.Forms.DataGridView dg_BoletoRemessa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_SelecionaRemessa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID_BoletoRemessa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MovimentoRemessa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Remessa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Arquivo;
    }
}

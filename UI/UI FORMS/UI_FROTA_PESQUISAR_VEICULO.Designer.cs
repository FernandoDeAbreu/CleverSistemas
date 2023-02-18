namespace Sistema.UI
{
    partial class UI_FROTA_PESQUISAR_VEICULO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_FROTA_PESQUISAR_VEICULO));
            this.dgv_Veiculo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MARCAMODELO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RENAVAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANOMOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANOFAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RNTRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHASSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMINICIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMATUAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPACIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Veiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Veiculo
            // 
            this.dgv_Veiculo.AllowUserToAddRows = false;
            this.dgv_Veiculo.AllowUserToDeleteRows = false;
            this.dgv_Veiculo.AllowUserToResizeColumns = false;
            this.dgv_Veiculo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_Veiculo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Veiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Veiculo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_Veiculo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Veiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Veiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MARCAMODELO,
            this.PLACA,
            this.RENAVAM,
            this.ANOMOD,
            this.ANOFAB,
            this.RNTRC,
            this.CHASSI,
            this.KMINICIAL,
            this.KMATUAL,
            this.CAPACIDADE});
            this.dgv_Veiculo.Location = new System.Drawing.Point(4, 64);
            this.dgv_Veiculo.Name = "dgv_Veiculo";
            this.dgv_Veiculo.ReadOnly = true;
            this.dgv_Veiculo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Veiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Veiculo.Size = new System.Drawing.Size(794, 506);
            this.dgv_Veiculo.TabIndex = 2;
            this.dgv_Veiculo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Veiculo_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // MARCAMODELO
            // 
            this.MARCAMODELO.HeaderText = "MARCA / MODELO";
            this.MARCAMODELO.Name = "MARCAMODELO";
            this.MARCAMODELO.ReadOnly = true;
            this.MARCAMODELO.Width = 300;
            // 
            // PLACA
            // 
            this.PLACA.HeaderText = "PLACA";
            this.PLACA.Name = "PLACA";
            this.PLACA.ReadOnly = true;
            // 
            // RENAVAM
            // 
            this.RENAVAM.HeaderText = "RENAVAM";
            this.RENAVAM.Name = "RENAVAM";
            this.RENAVAM.ReadOnly = true;
            this.RENAVAM.Width = 200;
            // 
            // ANOMOD
            // 
            this.ANOMOD.HeaderText = "ANO MOD.";
            this.ANOMOD.Name = "ANOMOD";
            this.ANOMOD.ReadOnly = true;
            // 
            // ANOFAB
            // 
            this.ANOFAB.HeaderText = "ANO FAB.";
            this.ANOFAB.Name = "ANOFAB";
            this.ANOFAB.ReadOnly = true;
            // 
            // RNTRC
            // 
            this.RNTRC.HeaderText = "RNTRC ( ANTT )";
            this.RNTRC.Name = "RNTRC";
            this.RNTRC.ReadOnly = true;
            this.RNTRC.Width = 130;
            // 
            // CHASSI
            // 
            this.CHASSI.HeaderText = "CHASSI";
            this.CHASSI.Name = "CHASSI";
            this.CHASSI.ReadOnly = true;
            this.CHASSI.Width = 200;
            // 
            // KMINICIAL
            // 
            this.KMINICIAL.HeaderText = "KM INICIAL";
            this.KMINICIAL.Name = "KMINICIAL";
            this.KMINICIAL.ReadOnly = true;
            // 
            // KMATUAL
            // 
            this.KMATUAL.HeaderText = "KM ATUAL";
            this.KMATUAL.Name = "KMATUAL";
            this.KMATUAL.ReadOnly = true;
            // 
            // CAPACIDADE
            // 
            this.CAPACIDADE.HeaderText = "CAPACIDADE";
            this.CAPACIDADE.Name = "CAPACIDADE";
            this.CAPACIDADE.ReadOnly = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PLACA",
            "MARCA / MODELO"});
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(651, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pesquisar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dados para a pesquisa";
            // 
            // UI_FROTA_PESQUISAR_VEICULO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 573);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgv_Veiculo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_FROTA_PESQUISAR_VEICULO";
            this.Text = "Pesquisar Veículos";
            this.Load += new System.EventHandler(this.UI_FROTA_PESQUISAR_VEICULO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Veiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MARCAMODELO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RENAVAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANOMOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANOFAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNTRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHASSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMINICIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMATUAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAPACIDADE;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
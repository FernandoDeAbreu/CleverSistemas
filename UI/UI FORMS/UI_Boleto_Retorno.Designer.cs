namespace Sistema.UI
{
    partial class UI_Boleto_Retorno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_Retorno = new System.Windows.Forms.GroupBox();
            this.lb_TotalRegistro = new System.Windows.Forms.Label();
            this.bt_PesquisaRetorno = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_Caminho = new System.Windows.Forms.TextBox();
            this.bt_Tratar = new System.Windows.Forms.Button();
            this.dg_BoletoRetorno = new System.Windows.Forms.DataGridView();
            this.col_ret_Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_NossoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_ID_Boleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Acrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Cedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_ValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ret_Tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pesquisa_Retorno = new System.Windows.Forms.OpenFileDialog();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.gb_Retorno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_BoletoRetorno)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.gb_Retorno);
            this.TabPage1.Text = "RETORNO";
            // 
            // gb_Retorno
            // 
            this.gb_Retorno.Controls.Add(this.lb_TotalRegistro);
            this.gb_Retorno.Controls.Add(this.bt_PesquisaRetorno);
            this.gb_Retorno.Controls.Add(this.label34);
            this.gb_Retorno.Controls.Add(this.txt_Caminho);
            this.gb_Retorno.Controls.Add(this.bt_Tratar);
            this.gb_Retorno.Controls.Add(this.dg_BoletoRetorno);
            this.gb_Retorno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Retorno.Location = new System.Drawing.Point(2, 3);
            this.gb_Retorno.Name = "gb_Retorno";
            this.gb_Retorno.Size = new System.Drawing.Size(938, 620);
            this.gb_Retorno.TabIndex = 1;
            this.gb_Retorno.TabStop = false;
            // 
            // lb_TotalRegistro
            // 
            this.lb_TotalRegistro.AutoSize = true;
            this.lb_TotalRegistro.Location = new System.Drawing.Point(7, 69);
            this.lb_TotalRegistro.Name = "lb_TotalRegistro";
            this.lb_TotalRegistro.Size = new System.Drawing.Size(103, 15);
            this.lb_TotalRegistro.TabIndex = 115;
            this.lb_TotalRegistro.Text = "Total de Registro:";
            // 
            // bt_PesquisaRetorno
            // 
            this.bt_PesquisaRetorno.BackColor = System.Drawing.SystemColors.Control;
            this.bt_PesquisaRetorno.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PesquisaRetorno.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_PesquisaRetorno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_PesquisaRetorno.Location = new System.Drawing.Point(499, 30);
            this.bt_PesquisaRetorno.Name = "bt_PesquisaRetorno";
            this.bt_PesquisaRetorno.Size = new System.Drawing.Size(111, 34);
            this.bt_PesquisaRetorno.TabIndex = 2;
            this.bt_PesquisaRetorno.Text = "PESQUISA";
            this.bt_PesquisaRetorno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_PesquisaRetorno.UseVisualStyleBackColor = false;
            this.bt_PesquisaRetorno.Click += new System.EventHandler(this.bt_PesquisaRetorno_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(2, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(105, 15);
            this.label34.TabIndex = 114;
            this.label34.Text = "Caminho Retorno";
            // 
            // txt_Caminho
            // 
            this.txt_Caminho.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Caminho.Location = new System.Drawing.Point(6, 35);
            this.txt_Caminho.Name = "txt_Caminho";
            this.txt_Caminho.Size = new System.Drawing.Size(482, 21);
            this.txt_Caminho.TabIndex = 1;
            this.txt_Caminho.Tag = "T";
            // 
            // bt_Tratar
            // 
            this.bt_Tratar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Tratar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Tratar.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Tratar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Tratar.Location = new System.Drawing.Point(617, 25);
            this.bt_Tratar.Name = "bt_Tratar";
            this.bt_Tratar.Size = new System.Drawing.Size(182, 45);
            this.bt_Tratar.TabIndex = 4;
            this.bt_Tratar.Text = "TRATAR RETORNO";
            this.bt_Tratar.UseVisualStyleBackColor = false;
            this.bt_Tratar.Click += new System.EventHandler(this.bt_Tratar_Click);
            // 
            // dg_BoletoRetorno
            // 
            this.dg_BoletoRetorno.AllowUserToAddRows = false;
            this.dg_BoletoRetorno.AllowUserToDeleteRows = false;
            this.dg_BoletoRetorno.AllowUserToResizeRows = false;
            this.dg_BoletoRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_BoletoRetorno.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_BoletoRetorno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_BoletoRetorno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_BoletoRetorno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ret_Pessoa,
            this.col_ret_Emissao,
            this.col_ret_NossoNumero,
            this.col_ret_Vencimento,
            this.col_ret_Valor,
            this.col_ret_ID_Boleto,
            this.col_ret_Acrescimo,
            this.col_ret_Desconto,
            this.col_ret_Cedente,
            this.col_ret_ValorPago,
            this.col_ret_Pagamento,
            this.col_DataCredito,
            this.col_ret_Documento,
            this.col_ret_Tarifa});
            this.dg_BoletoRetorno.Location = new System.Drawing.Point(6, 91);
            this.dg_BoletoRetorno.MultiSelect = false;
            this.dg_BoletoRetorno.Name = "dg_BoletoRetorno";
            this.dg_BoletoRetorno.ReadOnly = true;
            this.dg_BoletoRetorno.RowHeadersVisible = false;
            this.dg_BoletoRetorno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_BoletoRetorno.Size = new System.Drawing.Size(929, 523);
            this.dg_BoletoRetorno.StandardTab = true;
            this.dg_BoletoRetorno.TabIndex = 10;
            // 
            // col_ret_Pessoa
            // 
            this.col_ret_Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_ret_Pessoa.HeaderText = "Pessoa";
            this.col_ret_Pessoa.Name = "col_ret_Pessoa";
            this.col_ret_Pessoa.ReadOnly = true;
            // 
            // col_ret_Emissao
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.col_ret_Emissao.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_ret_Emissao.HeaderText = "Emissão";
            this.col_ret_Emissao.Name = "col_ret_Emissao";
            this.col_ret_Emissao.ReadOnly = true;
            this.col_ret_Emissao.Width = 70;
            // 
            // col_ret_NossoNumero
            // 
            this.col_ret_NossoNumero.HeaderText = "Nosso Número";
            this.col_ret_NossoNumero.Name = "col_ret_NossoNumero";
            this.col_ret_NossoNumero.ReadOnly = true;
            // 
            // col_ret_Vencimento
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.col_ret_Vencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ret_Vencimento.HeaderText = "Vencimento";
            this.col_ret_Vencimento.Name = "col_ret_Vencimento";
            this.col_ret_Vencimento.ReadOnly = true;
            this.col_ret_Vencimento.Width = 80;
            // 
            // col_ret_Valor
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_ret_Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_ret_Valor.HeaderText = "Valor";
            this.col_ret_Valor.Name = "col_ret_Valor";
            this.col_ret_Valor.ReadOnly = true;
            this.col_ret_Valor.Width = 70;
            // 
            // col_ret_ID_Boleto
            // 
            this.col_ret_ID_Boleto.HeaderText = "ID";
            this.col_ret_ID_Boleto.Name = "col_ret_ID_Boleto";
            this.col_ret_ID_Boleto.ReadOnly = true;
            this.col_ret_ID_Boleto.Visible = false;
            this.col_ret_ID_Boleto.Width = 50;
            // 
            // col_ret_Acrescimo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_ret_Acrescimo.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_ret_Acrescimo.HeaderText = "Acréscimo";
            this.col_ret_Acrescimo.Name = "col_ret_Acrescimo";
            this.col_ret_Acrescimo.ReadOnly = true;
            this.col_ret_Acrescimo.Width = 70;
            // 
            // col_ret_Desconto
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_ret_Desconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ret_Desconto.HeaderText = "Desconto";
            this.col_ret_Desconto.Name = "col_ret_Desconto";
            this.col_ret_Desconto.ReadOnly = true;
            this.col_ret_Desconto.Width = 70;
            // 
            // col_ret_Cedente
            // 
            this.col_ret_Cedente.HeaderText = "Cedente";
            this.col_ret_Cedente.Name = "col_ret_Cedente";
            this.col_ret_Cedente.ReadOnly = true;
            this.col_ret_Cedente.Visible = false;
            // 
            // col_ret_ValorPago
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_ret_ValorPago.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_ret_ValorPago.HeaderText = "Vlr. Pago";
            this.col_ret_ValorPago.Name = "col_ret_ValorPago";
            this.col_ret_ValorPago.ReadOnly = true;
            this.col_ret_ValorPago.Width = 90;
            // 
            // col_ret_Pagamento
            // 
            dataGridViewCellStyle7.Format = "d";
            this.col_ret_Pagamento.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_ret_Pagamento.HeaderText = "Pagamento";
            this.col_ret_Pagamento.Name = "col_ret_Pagamento";
            this.col_ret_Pagamento.ReadOnly = true;
            this.col_ret_Pagamento.Width = 75;
            // 
            // col_DataCredito
            // 
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.col_DataCredito.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_DataCredito.HeaderText = "Crédito";
            this.col_DataCredito.Name = "col_DataCredito";
            this.col_DataCredito.ReadOnly = true;
            this.col_DataCredito.Width = 75;
            // 
            // col_ret_Documento
            // 
            this.col_ret_Documento.HeaderText = "Documento";
            this.col_ret_Documento.Name = "col_ret_Documento";
            this.col_ret_Documento.ReadOnly = true;
            // 
            // col_ret_Tarifa
            // 
            this.col_ret_Tarifa.HeaderText = "Tarifa";
            this.col_ret_Tarifa.Name = "col_ret_Tarifa";
            this.col_ret_Tarifa.ReadOnly = true;
            this.col_ret_Tarifa.Visible = false;
            // 
            // UI_Boleto_Retorno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Boleto_Retorno";
            this.Load += new System.EventHandler(this.UI_Boleto_Retorno_Load);
            this.TabPage1.ResumeLayout(false);
            this.tabctl.ResumeLayout(false);
            this.gb_Retorno.ResumeLayout(false);
            this.gb_Retorno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_BoletoRetorno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Retorno;
        private System.Windows.Forms.Label lb_TotalRegistro;
        internal System.Windows.Forms.Button bt_PesquisaRetorno;
        internal System.Windows.Forms.Label label34;
        internal System.Windows.Forms.TextBox txt_Caminho;
        internal System.Windows.Forms.Button bt_Tratar;
        internal System.Windows.Forms.DataGridView dg_BoletoRetorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_NossoNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_ID_Boleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Acrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Cedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_ValorPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ret_Tarifa;
        private System.Windows.Forms.OpenFileDialog Pesquisa_Retorno;
    }
}

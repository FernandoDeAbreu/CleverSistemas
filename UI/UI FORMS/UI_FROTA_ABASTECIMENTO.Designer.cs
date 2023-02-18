namespace Sistema.UI
{
    partial class UI_FROTA_ABASTECIMENTO
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
            this.tbox_codveiculo = new System.Windows.Forms.TextBox();
            this.tbox_veiculo = new System.Windows.Forms.TextBox();
            this.tbox_fornecedor = new System.Windows.Forms.TextBox();
            this.tbox_codFornec = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.tbox_fornecedor);
            this.TabPage1.Controls.Add(this.tbox_codFornec);
            this.TabPage1.Controls.Add(this.tbox_veiculo);
            this.TabPage1.Controls.Add(this.tbox_codveiculo);
            // 
            // bt_Fecha
            // 
            this.bt_Fecha.Location = new System.Drawing.Point(850, 662);
            // 
            // bt_Novo
            // 
            this.bt_Novo.Location = new System.Drawing.Point(93, 662);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Location = new System.Drawing.Point(197, 662);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Location = new System.Drawing.Point(301, 662);
            // 
            // bt_Imprime
            // 
            this.bt_Imprime.Location = new System.Drawing.Point(504, 662);
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.Location = new System.Drawing.Point(702, 662);
            // 
            // bt_Exclui
            // 
            this.bt_Exclui.Location = new System.Drawing.Point(400, 662);
            // 
            // bt_Visualiza
            // 
            this.bt_Visualiza.Location = new System.Drawing.Point(603, 662);
            // 
            // tbox_codveiculo
            // 
            this.tbox_codveiculo.Location = new System.Drawing.Point(26, 38);
            this.tbox_codveiculo.Name = "tbox_codveiculo";
            this.tbox_codveiculo.Size = new System.Drawing.Size(100, 21);
            this.tbox_codveiculo.TabIndex = 0;
            // 
            // tbox_veiculo
            // 
            this.tbox_veiculo.Location = new System.Drawing.Point(151, 38);
            this.tbox_veiculo.Name = "tbox_veiculo";
            this.tbox_veiculo.Size = new System.Drawing.Size(100, 21);
            this.tbox_veiculo.TabIndex = 1;
            // 
            // tbox_fornecedor
            // 
            this.tbox_fornecedor.Location = new System.Drawing.Point(151, 65);
            this.tbox_fornecedor.Name = "tbox_fornecedor";
            this.tbox_fornecedor.Size = new System.Drawing.Size(100, 21);
            this.tbox_fornecedor.TabIndex = 3;
            // 
            // tbox_codFornec
            // 
            this.tbox_codFornec.Location = new System.Drawing.Point(26, 65);
            this.tbox_codFornec.Name = "tbox_codFornec";
            this.tbox_codFornec.Size = new System.Drawing.Size(100, 21);
            this.tbox_codFornec.TabIndex = 2;
            // 
            // UI_FROTA_ABASTECIMENTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_FROTA_ABASTECIMENTO";
            this.Text = "UI_FROTA_ABASTECIMENTO";
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox tbox_codveiculo;
        public System.Windows.Forms.TextBox tbox_veiculo;
        public System.Windows.Forms.TextBox tbox_fornecedor;
        public System.Windows.Forms.TextBox tbox_codFornec;
    }
}
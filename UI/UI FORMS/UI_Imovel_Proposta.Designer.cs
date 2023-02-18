namespace Sistema.UI
{
    partial class UI_Imovel_Proposta
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 24);
            this.label1.TabIndex = 671;
            this.label1.Text = "Para gerar, clique em \"IMPRIMIR\" ou \"VISUALIZAR\".";
            // 
            // UI_Imovel_Proposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Imovel_Proposta";
            this.Load += new System.EventHandler(this.frm_Proposta_Load);
            this.Controls.SetChildIndex(this.bt_Fecha, 0);
            this.Controls.SetChildIndex(this.tabctl, 0);
            this.Controls.SetChildIndex(this.bt_Exclui, 0);
            this.Controls.SetChildIndex(this.bt_Grava, 0);
            this.Controls.SetChildIndex(this.bt_Edita, 0);
            this.Controls.SetChildIndex(this.bt_Novo, 0);
            this.Controls.SetChildIndex(this.bt_Anterior, 0);
            this.Controls.SetChildIndex(this.bt_Proximo, 0);
            this.Controls.SetChildIndex(this.bt_Pesquisa, 0);
            this.Controls.SetChildIndex(this.bt_Imprime, 0);
            this.Controls.SetChildIndex(this.bt_Visualiza, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

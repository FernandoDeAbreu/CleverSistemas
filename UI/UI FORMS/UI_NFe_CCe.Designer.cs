namespace Sistema.UI
{
    partial class UI_NFe_CCe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_NFe_CCe));
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Justificativa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Confirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 14);
            this.label1.TabIndex = 109;
            this.label1.Text = "Mínimo de 15 e máximo de 1000 caracteres. ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 14);
            this.label10.TabIndex = 110;
            this.label10.Text = "MOTIVO";
            // 
            // txt_Justificativa
            // 
            this.txt_Justificativa.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Justificativa.Location = new System.Drawing.Point(11, 29);
            this.txt_Justificativa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Justificativa.MaxLength = 1000;
            this.txt_Justificativa.Multiline = true;
            this.txt_Justificativa.Name = "txt_Justificativa";
            this.txt_Justificativa.Size = new System.Drawing.Size(657, 188);
            this.txt_Justificativa.TabIndex = 1;
            this.txt_Justificativa.Tag = "T";
            this.txt_Justificativa.Leave += new System.EventHandler(this.txt_Justificativa_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(785, 122);
            this.label2.TabIndex = 109;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // bt_Confirmar
            // 
            this.bt_Confirmar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Confirmar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Confirmar.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Confirmar.Location = new System.Drawing.Point(673, 168);
            this.bt_Confirmar.Name = "bt_Confirmar";
            this.bt_Confirmar.Size = new System.Drawing.Size(124, 50);
            this.bt_Confirmar.TabIndex = 2;
            this.bt_Confirmar.Text = "REGISTRAR CORREÇÃO";
            this.bt_Confirmar.UseVisualStyleBackColor = false;
            this.bt_Confirmar.Click += new System.EventHandler(this.bt_Confirmar_Click);
            // 
            // UI_NFe_CCe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 374);
            this.Controls.Add(this.bt_Confirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Justificativa);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_NFe_CCe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARTA DE CORREÇÃO ELETRÔNICA";
            this.Load += new System.EventHandler(this.UI_NFe_CCe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bt_Confirmar;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txt_Justificativa;
        internal System.Windows.Forms.Label label2;
    }
}
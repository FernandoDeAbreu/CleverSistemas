namespace Sistema.UI
{
    partial class UI_Imagem
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
            this.pc_Imagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // pc_Imagem
            // 
            this.pc_Imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pc_Imagem.Location = new System.Drawing.Point(0, 0);
            this.pc_Imagem.Name = "pc_Imagem";
            this.pc_Imagem.Size = new System.Drawing.Size(680, 558);
            this.pc_Imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pc_Imagem.TabIndex = 0;
            this.pc_Imagem.TabStop = false;
            // 
            // UI_Imagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 558);
            this.Controls.Add(this.pc_Imagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Imagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMAGEM";
            this.Load += new System.EventHandler(this.UI_Imagem_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Imagem_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pc_Imagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pc_Imagem;
    }
}
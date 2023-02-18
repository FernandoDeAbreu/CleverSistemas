namespace Sistema.UI
{
    partial class UI_Estruturaxls
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_Fecha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Sistema.UI.Properties.Resources.TelaExcel;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(678, 474);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bt_Fecha
            // 
            this.bt_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Fecha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Fecha.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Fecha.Image = global::Sistema.UI.Properties.Resources.bt_Sair;
            this.bt_Fecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Fecha.Location = new System.Drawing.Point(557, 483);
            this.bt_Fecha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Fecha.Name = "bt_Fecha";
            this.bt_Fecha.Size = new System.Drawing.Size(110, 30);
            this.bt_Fecha.TabIndex = 671;
            this.bt_Fecha.Text = "FECHAR";
            this.bt_Fecha.UseVisualStyleBackColor = false;
            this.bt_Fecha.Click += new System.EventHandler(this.bt_Fecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 34);
            this.label1.TabIndex = 672;
            this.label1.Text = "ATENÇÃO: A tabela deve estar nesta estrutura.\r\nTabela muito grande, pode ocasiona" +
    "r lentidão na leitura.";
            // 
            // UI_Estruturaxls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Fecha);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Estruturaxls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESTRUTURA PASTA EXCEL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_Fecha;
        private System.Windows.Forms.Label label1;
    }
}
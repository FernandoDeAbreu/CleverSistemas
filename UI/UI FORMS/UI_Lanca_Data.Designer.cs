namespace Sistema.UI
{
    partial class UI_Lanca_Data
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
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.bt_Concluido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk_Data.Location = new System.Drawing.Point(12, 27);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(104, 26);
            this.mk_Data.TabIndex = 36;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // bt_Concluido
            // 
            this.bt_Concluido.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Concluido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Concluido.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_Concluido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Concluido.Location = new System.Drawing.Point(124, 15);
            this.bt_Concluido.Name = "bt_Concluido";
            this.bt_Concluido.Size = new System.Drawing.Size(114, 54);
            this.bt_Concluido.TabIndex = 37;
            this.bt_Concluido.Text = "CONCLUÍDO";
            this.bt_Concluido.UseVisualStyleBackColor = false;
            this.bt_Concluido.Click += new System.EventHandler(this.bt_Concluido_Click);
            // 
            // UI_Lanca_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(248, 76);
            this.Controls.Add(this.bt_Concluido);
            this.Controls.Add(this.mk_Data);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Lanca_Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_Lanca_Data";
            this.Load += new System.EventHandler(this.UI_Lanca_Data_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Lanca_Data_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bt_Concluido;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
    }
}
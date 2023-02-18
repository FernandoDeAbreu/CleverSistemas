namespace Sistema.UI
{
    partial class UI_Backup
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
            this.Pesquisa = new System.Windows.Forms.FolderBrowserDialog();
            this.lb_UltimoBackup = new System.Windows.Forms.Label();
            this.bt_RealizaBackup = new System.Windows.Forms.Button();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.bt_RealizaBackup);
            this.TabPage1.Controls.Add(this.lb_UltimoBackup);
            this.TabPage1.Text = "CÓPIA DE SEGURANÇA";
            // 
            // lb_UltimoBackup
            // 
            this.lb_UltimoBackup.AutoSize = true;
            this.lb_UltimoBackup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UltimoBackup.Location = new System.Drawing.Point(373, 15);
            this.lb_UltimoBackup.Name = "lb_UltimoBackup";
            this.lb_UltimoBackup.Size = new System.Drawing.Size(54, 13);
            this.lb_UltimoBackup.TabIndex = 0;
            this.lb_UltimoBackup.Text = "BACKUP:";
            // 
            // bt_RealizaBackup
            // 
            this.bt_RealizaBackup.BackColor = System.Drawing.SystemColors.Control;
            this.bt_RealizaBackup.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RealizaBackup.Image = global::Sistema.UI.Properties.Resources.bt_GeraBackup;
            this.bt_RealizaBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_RealizaBackup.Location = new System.Drawing.Point(24, 15);
            this.bt_RealizaBackup.Name = "bt_RealizaBackup";
            this.bt_RealizaBackup.Size = new System.Drawing.Size(286, 57);
            this.bt_RealizaBackup.TabIndex = 32;
            this.bt_RealizaBackup.Text = "GERAR CÓPIA DE SEGURANÇA AGORA";
            this.bt_RealizaBackup.UseVisualStyleBackColor = false;
            this.bt_RealizaBackup.Click += new System.EventHandler(this.bt_RealizaBackup_Click);
            // 
            // UI_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Backup";
            this.Load += new System.EventHandler(this.UI_Backup_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog Pesquisa;
        private System.Windows.Forms.Label lb_UltimoBackup;
        private System.Windows.Forms.Button bt_RealizaBackup;
    }
}

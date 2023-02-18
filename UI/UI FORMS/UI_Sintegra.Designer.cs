namespace Sistema.UI
{
    partial class UI_Sintegra
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Gerar = new System.Windows.Forms.Button();
            this.ck_Inventario = new System.Windows.Forms.CheckBox();
            this.Pesquisa_Pasta = new System.Windows.Forms.FolderBrowserDialog();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ck_Inventario);
            this.TabPage1.Controls.Add(this.bt_Gerar);
            this.TabPage1.Controls.Add(this.mk_Data);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Text = "SINTEGRA";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(24, 32);
            this.mk_Data.Mask = "00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(101, 21);
            this.mk_Data.TabIndex = 675;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            this.mk_Data.Leave += new System.EventHandler(this.mk_Data_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 676;
            this.label1.Text = "Mês/Ano";
            // 
            // bt_Gerar
            // 
            this.bt_Gerar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Gerar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Gerar.Image = global::Sistema.UI.Properties.Resources.bt_exportarTXT;
            this.bt_Gerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Gerar.Location = new System.Drawing.Point(24, 109);
            this.bt_Gerar.Name = "bt_Gerar";
            this.bt_Gerar.Size = new System.Drawing.Size(132, 57);
            this.bt_Gerar.TabIndex = 677;
            this.bt_Gerar.Text = "GERAR";
            this.bt_Gerar.UseVisualStyleBackColor = false;
            this.bt_Gerar.Click += new System.EventHandler(this.bt_Gerar_Click);
            // 
            // ck_Inventario
            // 
            this.ck_Inventario.AutoSize = true;
            this.ck_Inventario.Location = new System.Drawing.Point(24, 73);
            this.ck_Inventario.Name = "ck_Inventario";
            this.ck_Inventario.Size = new System.Drawing.Size(79, 19);
            this.ck_Inventario.TabIndex = 679;
            this.ck_Inventario.Text = "Inventário";
            this.ck_Inventario.UseVisualStyleBackColor = true;
            this.ck_Inventario.Visible = false;
            // 
            // UI_Sintegra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Sintegra";
            this.Load += new System.EventHandler(this.UI_Sintegra_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Gerar;
        private System.Windows.Forms.CheckBox ck_Inventario;
        private System.Windows.Forms.FolderBrowserDialog Pesquisa_Pasta;
    }
}

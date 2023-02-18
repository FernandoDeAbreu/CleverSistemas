namespace Sistema.UI
{
    partial class UI_Senha_Supervidor
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
            this.txt_Senha = new System.Windows.Forms.TextBox();
            this.bt_Libera = new System.Windows.Forms.Button();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Senha
            // 
            this.txt_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Senha.Location = new System.Drawing.Point(12, 87);
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(314, 38);
            this.txt_Senha.TabIndex = 2;
            this.txt_Senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Senha.UseSystemPasswordChar = true;
            // 
            // bt_Libera
            // 
            this.bt_Libera.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Libera.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Libera.Image = global::Sistema.UI.Properties.Resources.bt_Assinar;
            this.bt_Libera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Libera.Location = new System.Drawing.Point(216, 135);
            this.bt_Libera.Name = "bt_Libera";
            this.bt_Libera.Size = new System.Drawing.Size(110, 38);
            this.bt_Libera.TabIndex = 3;
            this.bt_Libera.Text = "LIBERAR";
            this.bt_Libera.UseVisualStyleBackColor = false;
            this.bt_Libera.Click += new System.EventHandler(this.bt_Libera_Click);
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Location = new System.Drawing.Point(12, 24);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(314, 38);
            this.txt_Usuario.TabIndex = 1;
            this.txt_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "USUÁRIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "SENHA";
            // 
            // UI_Senha_Supervidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(338, 180);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Libera);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_Senha);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Senha_Supervidor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_Senha_Supervidor";
            this.Load += new System.EventHandler(this.UI_Senha_Supervidor_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Senha_Supervidor_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Senha;
        internal System.Windows.Forms.Button bt_Libera;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
namespace Sistema.UI
{
    partial class UI_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Login));
            this.bt_Entrar = new System.Windows.Forms.Button();
            this.txt_Senha = new System.Windows.Forms.TextBox();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cb_Empresa = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Entrar
            // 
            this.bt_Entrar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bt_Entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Entrar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Entrar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Entrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Entrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_Entrar.Location = new System.Drawing.Point(323, 163);
            this.bt_Entrar.Name = "bt_Entrar";
            this.bt_Entrar.Size = new System.Drawing.Size(130, 46);
            this.bt_Entrar.TabIndex = 4;
            this.bt_Entrar.Text = "ENTRAR";
            this.bt_Entrar.UseVisualStyleBackColor = false;
            this.bt_Entrar.Click += new System.EventHandler(this.bt_Entrar_Click);
            // 
            // txt_Senha
            // 
            this.txt_Senha.BackColor = System.Drawing.Color.White;
            this.txt_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Senha.Location = new System.Drawing.Point(140, 112);
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(313, 22);
            this.txt_Senha.TabIndex = 3;
            this.txt_Senha.UseSystemPasswordChar = true;
            this.txt_Senha.Enter += new System.EventHandler(this.txt_Senha_Enter);
            this.txt_Senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Senha_KeyDown);
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.BackColor = System.Drawing.Color.White;
            this.txt_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Location = new System.Drawing.Point(140, 77);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(313, 22);
            this.txt_Usuario.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(67, 115);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(54, 16);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "SENHA";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Empresa
            // 
            this.cb_Empresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Empresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empresa.FormattingEnabled = true;
            this.cb_Empresa.Location = new System.Drawing.Point(140, 40);
            this.cb_Empresa.Name = "cb_Empresa";
            this.cb_Empresa.Size = new System.Drawing.Size(313, 24);
            this.cb_Empresa.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(53, 79);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(68, 16);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "USUÁRIO";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(48, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 16);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "EMPRESA";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(3, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 3);
            this.panel1.TabIndex = 24;
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Cancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancelar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Cancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_Cancelar.Location = new System.Drawing.Point(140, 163);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(130, 46);
            this.bt_Cancelar.TabIndex = 25;
            this.bt_Cancelar.Text = "CANCELAR";
            this.bt_Cancelar.UseVisualStyleBackColor = false;
            this.bt_Cancelar.Click += new System.EventHandler(this.bt_Cancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.bt_Entrar);
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Controls.Add(this.bt_Cancelar);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Controls.Add(this.cb_Empresa);
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.txt_Senha);
            this.panel2.Controls.Add(this.txt_Usuario);
            this.panel2.Location = new System.Drawing.Point(-1, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 226);
            this.panel2.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistema.UI.Properties.Resources.New_Logo_Clever;
            this.pictureBox1.Location = new System.Drawing.Point(125, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // UI_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 380);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_Login_FormClosed);
            this.Load += new System.EventHandler(this.UI_Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Login_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Login_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button bt_Entrar;
        internal System.Windows.Forms.TextBox txt_Senha;
        internal System.Windows.Forms.TextBox txt_Usuario;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cb_Empresa;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
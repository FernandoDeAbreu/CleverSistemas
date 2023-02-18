namespace Sistema.UI
{
    partial class UI_Usuario_Acesso
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
            this.GB_permissao = new System.Windows.Forms.GroupBox();
            this.lts_menu = new System.Windows.Forms.ListView();
            this.cb_Usuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GB_permissao.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.GB_permissao);
            this.TabPage1.Controls.Add(this.cb_Usuario);
            this.TabPage1.Controls.Add(this.txt_ID);
            // 
            // GB_permissao
            // 
            this.GB_permissao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_permissao.Controls.Add(this.lts_menu);
            this.GB_permissao.Location = new System.Drawing.Point(9, 66);
            this.GB_permissao.Name = "GB_permissao";
            this.GB_permissao.Size = new System.Drawing.Size(928, 553);
            this.GB_permissao.TabIndex = 14;
            this.GB_permissao.TabStop = false;
            this.GB_permissao.Text = "PERMISSÕES DE ACESSO";
            // 
            // lts_menu
            // 
            this.lts_menu.AllowColumnReorder = true;
            this.lts_menu.BackColor = System.Drawing.SystemColors.Control;
            this.lts_menu.CheckBoxes = true;
            this.lts_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lts_menu.FullRowSelect = true;
            this.lts_menu.GridLines = true;
            this.lts_menu.HideSelection = false;
            this.lts_menu.LabelEdit = true;
            this.lts_menu.Location = new System.Drawing.Point(3, 17);
            this.lts_menu.Name = "lts_menu";
            this.lts_menu.RightToLeftLayout = true;
            this.lts_menu.Size = new System.Drawing.Size(922, 533);
            this.lts_menu.TabIndex = 8;
            this.lts_menu.UseCompatibleStateImageBehavior = false;
            this.lts_menu.View = System.Windows.Forms.View.Details;
            this.lts_menu.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lts_menu_ItemChecked);
            // 
            // cb_Usuario
            // 
            this.cb_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Usuario.FormattingEnabled = true;
            this.cb_Usuario.Location = new System.Drawing.Point(9, 32);
            this.cb_Usuario.Name = "cb_Usuario";
            this.cb_Usuario.Size = new System.Drawing.Size(278, 23);
            this.cb_Usuario.TabIndex = 13;
            this.cb_Usuario.Leave += new System.EventHandler(this.cb_Usuario_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "USUÁRIO";
            // 
            // txt_ID
            // 
            this.txt_ID.Enabled = false;
            this.txt_ID.Location = new System.Drawing.Point(246, 33);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(27, 21);
            this.txt_ID.TabIndex = 16;
            // 
            // UI_Usuario_Acesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Usuario_Acesso";
            this.Load += new System.EventHandler(this.UI_Usuario_Acesso_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.GB_permissao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GB_permissao;
        internal System.Windows.Forms.ListView lts_menu;
        internal System.Windows.Forms.ComboBox cb_Usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ID;
    }
}

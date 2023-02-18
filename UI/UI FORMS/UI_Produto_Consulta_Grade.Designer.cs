namespace Sistema.UI
{
    partial class UI_Produto_Consulta_Grade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Produto_Consulta_Grade));
            this.dg_Grade = new System.Windows.Forms.DataGridView();
            this.bt_SelecionaUnico = new System.Windows.Forms.Button();
            this.lb_Produto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Grade)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Grade
            // 
            this.dg_Grade.AllowUserToAddRows = false;
            this.dg_Grade.AllowUserToDeleteRows = false;
            this.dg_Grade.AllowUserToOrderColumns = true;
            this.dg_Grade.AllowUserToResizeColumns = false;
            this.dg_Grade.AllowUserToResizeRows = false;
            this.dg_Grade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_Grade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Grade.Location = new System.Drawing.Point(2, 40);
            this.dg_Grade.MultiSelect = false;
            this.dg_Grade.Name = "dg_Grade";
            this.dg_Grade.RowHeadersVisible = false;
            this.dg_Grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Grade.Size = new System.Drawing.Size(529, 332);
            this.dg_Grade.StandardTab = true;
            this.dg_Grade.TabIndex = 121;
            this.dg_Grade.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Grade_CellEndEdit);
            this.dg_Grade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_Grade_KeyDown);
            // 
            // bt_SelecionaUnico
            // 
            this.bt_SelecionaUnico.BackColor = System.Drawing.SystemColors.Control;
            this.bt_SelecionaUnico.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SelecionaUnico.Image = global::Sistema.UI.Properties.Resources.bt_Concluido;
            this.bt_SelecionaUnico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SelecionaUnico.Location = new System.Drawing.Point(537, 331);
            this.bt_SelecionaUnico.Name = "bt_SelecionaUnico";
            this.bt_SelecionaUnico.Size = new System.Drawing.Size(124, 42);
            this.bt_SelecionaUnico.TabIndex = 120;
            this.bt_SelecionaUnico.Text = "SELECIONAR";
            this.bt_SelecionaUnico.UseVisualStyleBackColor = false;
            this.bt_SelecionaUnico.Click += new System.EventHandler(this.bt_SelecionaUnico_Click);
            // 
            // lb_Produto
            // 
            this.lb_Produto.AutoSize = true;
            this.lb_Produto.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Produto.Location = new System.Drawing.Point(4, 8);
            this.lb_Produto.Name = "lb_Produto";
            this.lb_Produto.Size = new System.Drawing.Size(83, 21);
            this.lb_Produto.TabIndex = 122;
            this.lb_Produto.Text = "PRODUTO";
            // 
            // UI_Produto_Consulta_Grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(673, 379);
            this.Controls.Add(this.lb_Produto);
            this.Controls.Add(this.dg_Grade);
            this.Controls.Add(this.bt_SelecionaUnico);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI_Produto_Consulta_Grade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_Produto_Consulta_Grade";
            this.Load += new System.EventHandler(this.UI_Produto_Consulta_Grade_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Produto_Consulta_Grade_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Grade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dg_Grade;
        internal System.Windows.Forms.Button bt_SelecionaUnico;
        private System.Windows.Forms.Label lb_Produto;
    }
}
namespace Sistema.UI
{
    partial class UI_Visualiza_Relatorio
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
            this.rpt_Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bt_Exporta_XLS = new System.Windows.Forms.Button();
            this.bt_Exporta_DOC = new System.Windows.Forms.Button();
            this.bt_Exporta_PDF = new System.Windows.Forms.Button();
            this.bt_Imprimir = new System.Windows.Forms.Button();
            this.bt_Sair = new System.Windows.Forms.Button();
            this.bt_Email = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rpt_Viewer
            // 
            this.rpt_Viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpt_Viewer.BackColor = System.Drawing.SystemColors.Control;
            this.rpt_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rpt_Viewer.Location = new System.Drawing.Point(0, 0);
            this.rpt_Viewer.Name = "rpt_Viewer";
            this.rpt_Viewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rpt_Viewer.ServerReport.BearerToken = null;
            this.rpt_Viewer.Size = new System.Drawing.Size(995, 548);
            this.rpt_Viewer.TabIndex = 0;
            // 
            // bt_Exporta_XLS
            // 
            this.bt_Exporta_XLS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Exporta_XLS.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Exporta_XLS.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exporta_XLS.Image = global::Sistema.UI.Properties.Resources.bt_Excel;
            this.bt_Exporta_XLS.Location = new System.Drawing.Point(422, 553);
            this.bt_Exporta_XLS.Name = "bt_Exporta_XLS";
            this.bt_Exporta_XLS.Size = new System.Drawing.Size(133, 43);
            this.bt_Exporta_XLS.TabIndex = 4;
            this.bt_Exporta_XLS.Text = "GERAR EXCEL";
            this.bt_Exporta_XLS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Exporta_XLS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Exporta_XLS.UseVisualStyleBackColor = false;
            this.bt_Exporta_XLS.Click += new System.EventHandler(this.bt_Exporta_XLS_Click);
            // 
            // bt_Exporta_DOC
            // 
            this.bt_Exporta_DOC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Exporta_DOC.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Exporta_DOC.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exporta_DOC.Image = global::Sistema.UI.Properties.Resources.bt_Word;
            this.bt_Exporta_DOC.Location = new System.Drawing.Point(283, 553);
            this.bt_Exporta_DOC.Name = "bt_Exporta_DOC";
            this.bt_Exporta_DOC.Size = new System.Drawing.Size(133, 43);
            this.bt_Exporta_DOC.TabIndex = 3;
            this.bt_Exporta_DOC.Text = "GERAR WORD";
            this.bt_Exporta_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Exporta_DOC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Exporta_DOC.UseVisualStyleBackColor = false;
            this.bt_Exporta_DOC.Click += new System.EventHandler(this.bt_Exporta_DOC_Click);
            // 
            // bt_Exporta_PDF
            // 
            this.bt_Exporta_PDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Exporta_PDF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Exporta_PDF.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exporta_PDF.Image = global::Sistema.UI.Properties.Resources.bt_pdf;
            this.bt_Exporta_PDF.Location = new System.Drawing.Point(144, 553);
            this.bt_Exporta_PDF.Name = "bt_Exporta_PDF";
            this.bt_Exporta_PDF.Size = new System.Drawing.Size(133, 43);
            this.bt_Exporta_PDF.TabIndex = 2;
            this.bt_Exporta_PDF.Text = "GERAR PDF";
            this.bt_Exporta_PDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Exporta_PDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Exporta_PDF.UseVisualStyleBackColor = false;
            this.bt_Exporta_PDF.Click += new System.EventHandler(this.bt_Exporta_PDF_Click);
            // 
            // bt_Imprimir
            // 
            this.bt_Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Imprimir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Imprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Imprimir.Image = global::Sistema.UI.Properties.Resources.bt_Imprimir;
            this.bt_Imprimir.Location = new System.Drawing.Point(5, 553);
            this.bt_Imprimir.Name = "bt_Imprimir";
            this.bt_Imprimir.Size = new System.Drawing.Size(133, 43);
            this.bt_Imprimir.TabIndex = 1;
            this.bt_Imprimir.Text = "IMPRIMIR";
            this.bt_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Imprimir.UseVisualStyleBackColor = false;
            this.bt_Imprimir.Click += new System.EventHandler(this.bt_Imprimir_Click);
            // 
            // bt_Sair
            // 
            this.bt_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Sair.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Sair.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Sair.Image = global::Sistema.UI.Properties.Resources.bt_Sair;
            this.bt_Sair.Location = new System.Drawing.Point(859, 553);
            this.bt_Sair.Name = "bt_Sair";
            this.bt_Sair.Size = new System.Drawing.Size(133, 43);
            this.bt_Sair.TabIndex = 7;
            this.bt_Sair.Text = "FECHAR (ESC)";
            this.bt_Sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Sair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Sair.UseVisualStyleBackColor = false;
            this.bt_Sair.Click += new System.EventHandler(this.bt_Sair_Click);
            // 
            // bt_Email
            // 
            this.bt_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Email.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Email.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Email.Image = global::Sistema.UI.Properties.Resources.bt_email;
            this.bt_Email.Location = new System.Drawing.Point(561, 553);
            this.bt_Email.Name = "bt_Email";
            this.bt_Email.Size = new System.Drawing.Size(133, 43);
            this.bt_Email.TabIndex = 5;
            this.bt_Email.Text = "ENVIAR EMAIL";
            this.bt_Email.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Email.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Email.UseVisualStyleBackColor = false;
            this.bt_Email.Click += new System.EventHandler(this.bt_Email_Click);
            // 
            // UI_Visualiza_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(995, 602);
            this.Controls.Add(this.bt_Sair);
            this.Controls.Add(this.bt_Email);
            this.Controls.Add(this.bt_Exporta_XLS);
            this.Controls.Add(this.bt_Exporta_DOC);
            this.Controls.Add(this.bt_Exporta_PDF);
            this.Controls.Add(this.bt_Imprimir);
            this.Controls.Add(this.rpt_Viewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "UI_Visualiza_Relatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISUALIZADOR DE RELATÓRIOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UI_Visualiza_Relatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_Visualiza_Relatorio_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Visualiza_Relatorio_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rpt_Viewer;
        private System.Windows.Forms.Button bt_Imprimir;
        private System.Windows.Forms.Button bt_Exporta_PDF;
        private System.Windows.Forms.Button bt_Exporta_DOC;
        private System.Windows.Forms.Button bt_Exporta_XLS;
        private System.Windows.Forms.Button bt_Sair;
        private System.Windows.Forms.Button bt_Email;

    }
}
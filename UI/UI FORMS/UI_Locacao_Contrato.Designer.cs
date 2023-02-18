namespace Sistema.UI
{
    partial class UI_Locacao_Contrato
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
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ID_Imovel = new System.Windows.Forms.ComboBox();
            this.mk_Data = new System.Windows.Forms.MaskedTextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.cb_TipoImpressao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Auxiliar = new System.Windows.Forms.TextBox();
            this.lb_Auxiliar = new System.Windows.Forms.Label();
            this.TabPage1.SuspendLayout();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txt_Auxiliar);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Controls.Add(this.lb_Auxiliar);
            this.TabPage1.Controls.Add(this.cb_ID_Imovel);
            this.TabPage1.Controls.Add(this.mk_Data);
            this.TabPage1.Controls.Add(this.cb_TipoImpressao);
            this.TabPage1.Controls.Add(this.Label12);
            this.TabPage1.Controls.Add(this.label4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 673;
            this.label4.Text = "Imóvel";
            // 
            // cb_ID_Imovel
            // 
            this.cb_ID_Imovel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ID_Imovel.FormattingEnabled = true;
            this.cb_ID_Imovel.Location = new System.Drawing.Point(12, 99);
            this.cb_ID_Imovel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ID_Imovel.Name = "cb_ID_Imovel";
            this.cb_ID_Imovel.Size = new System.Drawing.Size(423, 23);
            this.cb_ID_Imovel.TabIndex = 2;
            this.cb_ID_Imovel.Tag = "T";
            // 
            // mk_Data
            // 
            this.mk_Data.BackColor = System.Drawing.SystemColors.Window;
            this.mk_Data.Location = new System.Drawing.Point(12, 154);
            this.mk_Data.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mk_Data.Mask = "00/00/0000";
            this.mk_Data.Name = "mk_Data";
            this.mk_Data.Size = new System.Drawing.Size(93, 21);
            this.mk_Data.TabIndex = 3;
            this.mk_Data.Tag = "T";
            this.mk_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mk_Data.ValidatingType = typeof(System.DateTime);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(8, 133);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 15);
            this.Label12.TabIndex = 672;
            this.Label12.Text = "Data";
            // 
            // cb_TipoImpressao
            // 
            this.cb_TipoImpressao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoImpressao.FormattingEnabled = true;
            this.cb_TipoImpressao.Location = new System.Drawing.Point(12, 41);
            this.cb_TipoImpressao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_TipoImpressao.Name = "cb_TipoImpressao";
            this.cb_TipoImpressao.Size = new System.Drawing.Size(423, 23);
            this.cb_TipoImpressao.TabIndex = 1;
            this.cb_TipoImpressao.Tag = "T";
            this.cb_TipoImpressao.Leave += new System.EventHandler(this.cb_TipoImpressao_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 673;
            this.label1.Text = "Tipo de Impressão";
            // 
            // txt_Auxiliar
            // 
            this.txt_Auxiliar.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Auxiliar.Location = new System.Drawing.Point(12, 216);
            this.txt_Auxiliar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Auxiliar.MaxLength = 2000;
            this.txt_Auxiliar.Multiline = true;
            this.txt_Auxiliar.Name = "txt_Auxiliar";
            this.txt_Auxiliar.Size = new System.Drawing.Size(830, 294);
            this.txt_Auxiliar.TabIndex = 4;
            this.txt_Auxiliar.Tag = "T";
            this.txt_Auxiliar.Visible = false;
            // 
            // lb_Auxiliar
            // 
            this.lb_Auxiliar.AutoSize = true;
            this.lb_Auxiliar.Location = new System.Drawing.Point(12, 197);
            this.lb_Auxiliar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Auxiliar.Name = "lb_Auxiliar";
            this.lb_Auxiliar.Size = new System.Drawing.Size(78, 15);
            this.lb_Auxiliar.TabIndex = 675;
            this.lb_Auxiliar.Text = "Vistoria Final";
            this.lb_Auxiliar.Visible = false;
            // 
            // UI_Locacao_Contrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UI_Locacao_Contrato";
            this.Load += new System.EventHandler(this.UI_Locacao_Contrato_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cb_ID_Imovel;
        internal System.Windows.Forms.MaskedTextBox mk_Data;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cb_TipoImpressao;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_Auxiliar;
        internal System.Windows.Forms.Label lb_Auxiliar;
    }
}

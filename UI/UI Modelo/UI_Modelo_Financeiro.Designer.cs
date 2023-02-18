namespace Sistema.UI
{
    partial class UI_Modelo_Financeiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Modelo_Financeiro));
            this.tabctl = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.bt_Novo = new System.Windows.Forms.Button();
            this.bt_Edita = new System.Windows.Forms.Button();
            this.bt_Grava = new System.Windows.Forms.Button();
            this.bt_Visualiza = new System.Windows.Forms.Button();
            this.bt_Imprime = new System.Windows.Forms.Button();
            this.bt_Pesquisa = new System.Windows.Forms.Button();
            this.bt_Exclui = new System.Windows.Forms.Button();
            this.bt_Fecha = new System.Windows.Forms.Button();
            this.bt_Anterior = new System.Windows.Forms.Button();
            this.bt_Proximo = new System.Windows.Forms.Button();
            this.lb_Descricaotela = new System.Windows.Forms.Label();
            this.tabctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctl
            // 
            this.tabctl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabctl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabctl.Controls.Add(this.TabPage1);
            this.tabctl.Controls.Add(this.TabPage2);
            this.tabctl.Location = new System.Drawing.Point(0, 3);
            this.tabctl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabctl.Name = "tabctl";
            this.tabctl.SelectedIndex = 0;
            this.tabctl.Size = new System.Drawing.Size(950, 659);
            this.tabctl.TabIndex = 661;
            // 
            // TabPage1
            // 
            this.TabPage1.Location = new System.Drawing.Point(4, 27);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TabPage1.Size = new System.Drawing.Size(942, 628);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "CADASTRO";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Location = new System.Drawing.Point(4, 27);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TabPage2.Size = new System.Drawing.Size(942, 628);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "PESQUISA";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // bt_Novo
            // 
            this.bt_Novo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Novo.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Novo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Novo.Image = global::Sistema.UI.Properties.Resources.bt_Adicionar;
            this.bt_Novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Novo.Location = new System.Drawing.Point(93, 662);
            this.bt_Novo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Novo.Name = "bt_Novo";
            this.bt_Novo.Size = new System.Drawing.Size(95, 34);
            this.bt_Novo.TabIndex = 665;
            this.bt_Novo.Text = "NOVO";
            this.bt_Novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Novo.UseVisualStyleBackColor = false;
            this.bt_Novo.Click += new System.EventHandler(this.bt_Novo_Click);
            // 
            // bt_Edita
            // 
            this.bt_Edita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Edita.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Edita.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Edita.Image = global::Sistema.UI.Properties.Resources.bt_NotaFiscal;
            this.bt_Edita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Edita.Location = new System.Drawing.Point(192, 662);
            this.bt_Edita.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Edita.Name = "bt_Edita";
            this.bt_Edita.Size = new System.Drawing.Size(95, 34);
            this.bt_Edita.TabIndex = 663;
            this.bt_Edita.Text = "EDITAR";
            this.bt_Edita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Edita.UseVisualStyleBackColor = false;
            this.bt_Edita.Click += new System.EventHandler(this.bt_Edita_Click);
            // 
            // bt_Grava
            // 
            this.bt_Grava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Grava.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Grava.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Grava.Image = global::Sistema.UI.Properties.Resources.bt_Salvar;
            this.bt_Grava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Grava.Location = new System.Drawing.Point(291, 662);
            this.bt_Grava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Grava.Name = "bt_Grava";
            this.bt_Grava.Size = new System.Drawing.Size(95, 34);
            this.bt_Grava.TabIndex = 664;
            this.bt_Grava.Text = "GRAVAR";
            this.bt_Grava.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Grava.UseVisualStyleBackColor = false;
            this.bt_Grava.Click += new System.EventHandler(this.bt_Grava_Click);
            // 
            // bt_Visualiza
            // 
            this.bt_Visualiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Visualiza.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Visualiza.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Visualiza.Image = global::Sistema.UI.Properties.Resources.bt_Visualiza;
            this.bt_Visualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Visualiza.Location = new System.Drawing.Point(588, 662);
            this.bt_Visualiza.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Visualiza.Name = "bt_Visualiza";
            this.bt_Visualiza.Size = new System.Drawing.Size(95, 34);
            this.bt_Visualiza.TabIndex = 668;
            this.bt_Visualiza.Text = "VISUALIZAR";
            this.bt_Visualiza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Visualiza.UseVisualStyleBackColor = false;
            this.bt_Visualiza.Click += new System.EventHandler(this.bt_Visualiza_Click);
            // 
            // bt_Imprime
            // 
            this.bt_Imprime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Imprime.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Imprime.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Imprime.Image = global::Sistema.UI.Properties.Resources.bt_Imprimir;
            this.bt_Imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Imprime.Location = new System.Drawing.Point(489, 662);
            this.bt_Imprime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Imprime.Name = "bt_Imprime";
            this.bt_Imprime.Size = new System.Drawing.Size(95, 34);
            this.bt_Imprime.TabIndex = 667;
            this.bt_Imprime.Text = "IMPRIMIR";
            this.bt_Imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Imprime.UseVisualStyleBackColor = false;
            this.bt_Imprime.Click += new System.EventHandler(this.bt_Imprime_Click);
            // 
            // bt_Pesquisa
            // 
            this.bt_Pesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Pesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Pesquisa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Pesquisa.Image = global::Sistema.UI.Properties.Resources.bt_Localizar;
            this.bt_Pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Pesquisa.Location = new System.Drawing.Point(687, 662);
            this.bt_Pesquisa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Pesquisa.Name = "bt_Pesquisa";
            this.bt_Pesquisa.Size = new System.Drawing.Size(102, 34);
            this.bt_Pesquisa.TabIndex = 669;
            this.bt_Pesquisa.Text = "PESQUISA (F5)";
            this.bt_Pesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Pesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Pesquisa.UseVisualStyleBackColor = false;
            this.bt_Pesquisa.Click += new System.EventHandler(this.bt_Pesquisa_Click);
            // 
            // bt_Exclui
            // 
            this.bt_Exclui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Exclui.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Exclui.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exclui.Image = global::Sistema.UI.Properties.Resources.bt_Apagar;
            this.bt_Exclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Exclui.Location = new System.Drawing.Point(390, 662);
            this.bt_Exclui.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Exclui.Name = "bt_Exclui";
            this.bt_Exclui.Size = new System.Drawing.Size(95, 34);
            this.bt_Exclui.TabIndex = 666;
            this.bt_Exclui.Text = "EXCLUIR";
            this.bt_Exclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Exclui.UseVisualStyleBackColor = false;
            this.bt_Exclui.Click += new System.EventHandler(this.bt_Exclui_Click);
            // 
            // bt_Fecha
            // 
            this.bt_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Fecha.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Fecha.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Fecha.Image = global::Sistema.UI.Properties.Resources.bt_Sair;
            this.bt_Fecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Fecha.Location = new System.Drawing.Point(845, 662);
            this.bt_Fecha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Fecha.Name = "bt_Fecha";
            this.bt_Fecha.Size = new System.Drawing.Size(101, 34);
            this.bt_Fecha.TabIndex = 670;
            this.bt_Fecha.Text = "FECHAR (ESC)";
            this.bt_Fecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Fecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Fecha.UseVisualStyleBackColor = false;
            this.bt_Fecha.Click += new System.EventHandler(this.bt_Fecha_Click);
            // 
            // bt_Anterior
            // 
            this.bt_Anterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Anterior.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Anterior.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Anterior.Image = global::Sistema.UI.Properties.Resources.bt_Anterior1;
            this.bt_Anterior.Location = new System.Drawing.Point(5, 662);
            this.bt_Anterior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Anterior.Name = "bt_Anterior";
            this.bt_Anterior.Size = new System.Drawing.Size(37, 36);
            this.bt_Anterior.TabIndex = 662;
            this.bt_Anterior.UseVisualStyleBackColor = false;
            this.bt_Anterior.Visible = false;
            this.bt_Anterior.Click += new System.EventHandler(this.bt_Anterior_Click);
            // 
            // bt_Proximo
            // 
            this.bt_Proximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Proximo.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Proximo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Proximo.Image = global::Sistema.UI.Properties.Resources.bt_Proximo1;
            this.bt_Proximo.Location = new System.Drawing.Point(48, 662);
            this.bt_Proximo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Proximo.Name = "bt_Proximo";
            this.bt_Proximo.Size = new System.Drawing.Size(37, 36);
            this.bt_Proximo.TabIndex = 662;
            this.bt_Proximo.UseVisualStyleBackColor = false;
            this.bt_Proximo.Visible = false;
            this.bt_Proximo.Click += new System.EventHandler(this.bt_Proximo_Click);
            // 
            // lb_Descricaotela
            // 
            this.lb_Descricaotela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Descricaotela.BackColor = System.Drawing.Color.Transparent;
            this.lb_Descricaotela.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Descricaotela.ForeColor = System.Drawing.Color.Gray;
            this.lb_Descricaotela.Location = new System.Drawing.Point(428, 3);
            this.lb_Descricaotela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Descricaotela.Name = "lb_Descricaotela";
            this.lb_Descricaotela.Size = new System.Drawing.Size(518, 22);
            this.lb_Descricaotela.TabIndex = 671;
            this.lb_Descricaotela.Text = "frm_Modelo";
            this.lb_Descricaotela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UI_Modelo_Financeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.lb_Descricaotela);
            this.Controls.Add(this.bt_Proximo);
            this.Controls.Add(this.bt_Anterior);
            this.Controls.Add(this.bt_Novo);
            this.Controls.Add(this.bt_Edita);
            this.Controls.Add(this.bt_Grava);
            this.Controls.Add(this.bt_Visualiza);
            this.Controls.Add(this.bt_Imprime);
            this.Controls.Add(this.bt_Pesquisa);
            this.Controls.Add(this.bt_Exclui);
            this.Controls.Add(this.bt_Fecha);
            this.Controls.Add(this.tabctl);
            this.Font = new System.Drawing.Font("Arial", 8.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "UI_Modelo_Financeiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_Modelo";
            this.Load += new System.EventHandler(this.UI_Modelo_Venda_Load);
            this.TextChanged += new System.EventHandler(this.UI_Modelo_Financeiro_TextChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UI_Modelo_Venda_KeyPress);
            this.tabctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabPage TabPage1;
        public System.Windows.Forms.TabControl tabctl;
        public System.Windows.Forms.TabPage TabPage2;
        public System.Windows.Forms.Button bt_Novo;
        public System.Windows.Forms.Button bt_Edita;
        public System.Windows.Forms.Button bt_Grava;
        public System.Windows.Forms.Button bt_Imprime;
        public System.Windows.Forms.Button bt_Pesquisa;
        public System.Windows.Forms.Button bt_Exclui;
        public System.Windows.Forms.Button bt_Visualiza;
        public System.Windows.Forms.Button bt_Anterior;
        public System.Windows.Forms.Button bt_Proximo;
        private System.Windows.Forms.Label lb_Descricaotela;
        public System.Windows.Forms.Button bt_Fecha;
    }
}
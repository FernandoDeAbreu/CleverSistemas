namespace Sistema.UI
{
    partial class UI_PAGINA_INICIAL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_PAGINA_INICIAL));
            this.timer_data_hora = new System.Windows.Forms.Timer(this.components);
            this.timer_tempo_atualizacao = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // timer_data_hora
            // 
            this.timer_data_hora.Enabled = true;
            this.timer_data_hora.Tick += new System.EventHandler(this.Timer_data_hora_Tick);
            // 
            // timer_tempo_atualizacao
            // 
            this.timer_tempo_atualizacao.Enabled = true;
            this.timer_tempo_atualizacao.Interval = 1000;
            this.timer_tempo_atualizacao.Tick += new System.EventHandler(this.Timer_tempo_atualizacao_Tick);
            // 
            // UI_PAGINA_INICIAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(780, 483);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_PAGINA_INICIAL";
            this.Text = "Página inicial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_PAGINA_INICIAL_FormClosing);
            this.Load += new System.EventHandler(this.UI_PAGINA_INICIAL_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_data_hora;
        private System.Windows.Forms.Timer timer_tempo_atualizacao;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sistema.UI
{
    public partial class UI_MENU : Form
    {
        public UI_MENU()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 30);

        }

        #region MOVIMENTAR FORM
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region BOTOES NATIVO TELA
        private void Iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Iconmaximizar_Click(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 30);
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }
        private void Iconrestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1000, 700);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }
        private void Iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Iconlogin_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Iconlogin_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
        }
        #endregion

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Cadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }

        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Cadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
          
        }

        private void Panel_form_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void UI_MENU_Load(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Cadastro;
            lbl_Cadastro.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_Cadastro.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));

            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void Timer_abrir_pagina_inicial_Tick(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count == 0)
                AbrirFormEnPanel(new UI_PAGINA_INICIAL());
        }
     
        #region FUNÇÃO MUDAR TAB
        private void cor_label()
        {
            lbl_Cadastro.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_Cadastro.ForeColor = Color.White;

            lbl_imovel.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_imovel.ForeColor = Color.White;

            lbl_equipamento.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_equipamento.ForeColor = Color.White;

            lbl_estoque.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_estoque.ForeColor = Color.White;

            lbl_financeiro.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_financeiro.ForeColor = Color.White;

            lbl_vendas.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_vendas.ForeColor = Color.White;

            lbl_nota_fiscal.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_nota_fiscal.ForeColor = Color.White;

            lbl_contabil.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_contabil.ForeColor = Color.White;

            lbl_ordem_servico.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_ordem_servico.ForeColor = Color.White;

            lbl_frota.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_frota.ForeColor = Color.White;

            lbl_paramentro.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_paramentro.ForeColor = Color.White;

            lbl_manutencao.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_manutencao.ForeColor = Color.White;

            lbl_sair.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            lbl_sair.ForeColor = Color.White;

        }
        private void Lbl_Cadastro_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Cadastro;
            lbl_Cadastro.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_Cadastro.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_imovel_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Imovel;
            lbl_imovel.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_imovel.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_equipamento_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Equipamento;
            lbl_equipamento.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_equipamento.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_estoque_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Estoque;
            lbl_estoque.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_estoque.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_financeiro_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Financeiro;
            lbl_financeiro.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_financeiro.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_vendas_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Vendas;
            lbl_vendas.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_vendas.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_nota_fiscal_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Nota_Fiscal;
            lbl_nota_fiscal.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_nota_fiscal.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_contabil_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Contabil;
            lbl_contabil.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_contabil.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_ordem_servico_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Ordem_de_Servico;
            lbl_ordem_servico.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_ordem_servico.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_frota_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Frota;
            lbl_frota.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_frota.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_paramentro_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Parametros;
            lbl_paramentro.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_paramentro.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_manutencao_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Manutencao;
            lbl_manutencao.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_manutencao.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        private void Lbl_sair_Click(object sender, EventArgs e)
        {
            cor_label();
            tabControl1.SelectedTab = tabPage_Sair;
            lbl_sair.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            lbl_sair.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        }
        #endregion

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void baixaDeAluguelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contratoDeLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contratoDePrestaçãoDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void propostaDeAquisiçãoImovélToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compraDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void entradaDeProduçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void entradaDeProdutoPorXMLNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void controleDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void movimentarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reajusteDeValorVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resumoDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void movimentaçãoDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void entradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void atualizaçãoDeValorExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeProdutoExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ajusteDeEstoqueCorreçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

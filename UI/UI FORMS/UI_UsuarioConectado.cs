using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema.UI.UI_FORMS
{
    public partial class UI_UsuarioConectado : Form
    {
        public UI_UsuarioConectado()
        {
            InitializeComponent();
        }

        private int time = 0;
        private bool open = true;

        #region VARIAVEIS DIVERSAS

        private int obj;

        #endregion VARIAVEIS DIVERSAS

        #region VARIAVEIS DE CLASSE

        private BLL_Sistema BLL_Sistema;
        private BLL_LogAcesso BLL_LogAcesso;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Sistema Sistema;
        private DTO_LogAcesso LogAcesso;

        #endregion ESTRUTURA

        public void PesquisarVersao()
        {
            try
            {
                BLL_Sistema = new BLL_Sistema();
                Sistema = new DTO_Sistema();
                Sistema.ID = 1;
                DataTable _DT = new DataTable();
                _DT = BLL_Sistema.Busca(Sistema);
                LblVersaoSistema.Text = _DT.Rows[0]["Versao"].ToString();
                LblVersaoBanco.Text = _DT.Rows[0]["BD"].ToString();
                LblChaveBanco.Text = _DT.Rows[0]["Chave"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text); throw;
            }
        }

        public void PesquisarLog()
        {
            try
            {
                BLL_LogAcesso = new BLL_LogAcesso();
                LogAcesso = new DTO_LogAcesso();
                DataTable _DT = new DataTable();
                _DT = BLL_LogAcesso.Busca(LogAcesso);

                lblNomeEmpresa.Text = _DT.Rows[0]["Nome_Razao"].ToString();
                LblNomeUsuario.Text = _DT.Rows[0]["Descricao"].ToString();
                LblDataConexao.Text = _DT.Rows[0]["Data"].ToString();
                LblTerminal.Text = _DT.Rows[0]["Terminal"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GravarMySqlRemoto()
        {
            try
            {
                BLL_LogAcesso = new BLL_LogAcesso();
                LogAcesso = new DTO_LogAcesso();

                LogAcesso.NomeEmpresa = lblNomeEmpresa.Text;
                LogAcesso.NomeUsuario = LblNomeUsuario.Text;
                LogAcesso.DataConexao = LblDataConexao.Text;
                LogAcesso.Terminal = LblTerminal.Text;
                LogAcesso.VersaoSistema = LblVersaoSistema.Text;
                LogAcesso.VersaoBanco = LblVersaoBanco.Text;
                LogAcesso.ChaveBanco = LblChaveBanco.Text;

                obj = BLL_LogAcesso.Grava(LogAcesso);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public void BuscaNovaVersao()
        {
            //try
            //{
            //    BLL_LogAcesso = new BLL_LogAcesso();
            //    LogAcesso = new DTO_LogAcesso();
            //    DataTable _DT = new DataTable();
            //    _DT = BLL_LogAcesso.BuscaNovaVersao(LogAcesso);
            //    lblVersaoDisponivelSistema.Text = _DT.Rows[0]["NovaVersaoSistema"].ToString();
            //    lblVersaoDisponivelBanco.Text = _DT.Rows[0]["NovaVersaoBanco"].ToString();

            //    //if (Convert.ToInt32(lblVersaoDisponivelSistema.Text) > Convert.ToInt32(LblVersaoSistema.Text))
            //    //{
            //    //    if (MessageBox.Show("Existem atualizações disponíveis para o seu sistema, Deseja atualizar agora?", "Clever Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    //    {
            //    //        System.Diagnostics.Process.Start("C:\\Clever\\CleverUpdate.exe");
            //    //        Application.Exit();
            //    //        return;
            //    //    }
            //    //}
            //    //if (Convert.ToInt32(lblVersaoDisponivelBanco.Text) > Convert.ToInt32(LblVersaoBanco.Text))
            //    //{
            //    //    if (MessageBox.Show("Existem atualizações disponíveis para o seu sistema, Deseja atualizar agora?", "Clever Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    //    {
            //    //        System.Diagnostics.Process.Start("C:\\Clever\\CleverUpdate.exe");
            //    //        Application.Exit();
            //    //        return;
            //    //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text); throw;
            //}
        }

        private void UI_UsuarioConectado_FormClosing(object sender, FormClosingEventArgs e)
        {
            // e.Cancel = true; cancela o Fechamento do Form
            Hide();

            notifyIcon.Visible = true;
        }

        private void UI_UsuarioConectado_Load(object sender, EventArgs e)
        {
            PesquisarVersao();
            PesquisarLog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*COMENTADO ATÉ EU VER UMA FORMA MELHOR DE GRAVAR LOG REMOTO -CONTA DA HOSTINGER EXPIROU- */

            //time++;

            //if (time > 10)
            //{
            //    if (open)
            //    {
            //        time = 0;
            //        open = false;
            //        //  System.Diagnostics.Process.Start("C:\\Clever\\CleverUpdate.exe");
            //        PesquisarVersao();
            //        PesquisarLog();
            //        GravarMySqlRemoto();
            //        BuscaNovaVersao();

            //    }
            //}
        }
    }
}
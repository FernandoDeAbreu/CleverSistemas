using Sistema.BLL;
using Sistema.BLL.DLL;
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
        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

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
            GravarMySqlRemoto();
        }
    }
}
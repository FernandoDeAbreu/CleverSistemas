using Microsoft.Win32;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_AtualizarBanco : Form
    {
        public UI_AtualizarBanco()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE

        private BLL_Sistema BLL_Sistema;
        private BLL_Backup BLL_Backup;
        private BLL_Pessoa BLL_Pessoa;
        private BLL_Usuario BLL_Usuario;
        private BLL_Parametro BLL_Parametro;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Sistema Sistema;
        private DTO_Pessoa Pessoa;
        private DTO_Usuario Usuario;
        private DTO_Log Log;
        private DTO_Parametro Parametro;

        #endregion ESTRUTURA

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void Inicia_Form()
        {
            try
            {
                this.Text = "Atualizar Banco de Dados";

                lb_Versao.Text = lb_Versao.Text + Parametro_Sistema.Versao;

                RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegKey = RegKey.CreateSubKey("SystemSoft");//CRIA SUBCHAVE
                RegKey.SetValue("Versao", Parametro_Sistema.Versao.Replace(".", ""));
                RegKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public void Atualizacao_Sistema()
        {
            string Versao_Servidor = string.Empty;

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);

            BLL_Sistema = new BLL_Sistema();
            Sistema = new DTO_Sistema();

            DataTable _DT = new DataTable();

            Sistema.ID = 1;
            _DT = BLL_Sistema.Busca(Sistema);

            #region ATUALIZA BANCO DE DADOS

            BLL_Sistema = new BLL_Sistema();
            Sistema = new DTO_Sistema();

            int aux = BLL_Sistema.VersaoBD();
            int VersaoBD = Convert.ToInt32(_DT.Rows[0]["BD"]);

            Sistema.VersaoAtualBanco = VersaoBD;

            try
            {
                if (VersaoBD < aux)
                    BLL_Sistema.Atualiza(Sistema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex);
                Application.Exit();
            }

            #endregion ATUALIZA BANCO DE DADOS
        }

        private void Btn_confirmar_Click(object sender, EventArgs e)
        {
            Atualizacao_Sistema();
        }

        private void UI_AtualizarBanco_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
    }
}
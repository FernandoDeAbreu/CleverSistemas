using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;
using Microsoft.Win32;
using System.IO;
using System.Reflection;


namespace Sistema.UI
{
    public partial class UI_AtualizarBanco : Form
    {
        public UI_AtualizarBanco()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Sistema BLL_Sistema;
        BLL_Backup BLL_Backup;
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region ESTRUTURA
        DTO_Sistema Sistema;
        DTO_Pessoa Pessoa;
        DTO_Usuario Usuario;
        DTO_Log Log;
        DTO_Parametro Parametro;
        #endregion

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

            int aux = BLL_Sistema.Versao();
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
            #endregion
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

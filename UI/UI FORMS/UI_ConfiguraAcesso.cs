using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_ConfiguraAcesso : Form
    {
        public UI_ConfiguraAcesso()
        {
            InitializeComponent();
        }

        #region ROTINAS
        private void Lista_Empresa()
        {
            DG.Rows.Clear();
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);
            for (int i = 1; i <= 50; i++)
                try
                {
                    if (util_dados.Verifica_int(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "ID").ToString())) > 0)
                    {
                        DG.Rows.Add();
                        DG.Rows[i - 1].Cells["col_ID"].Value = Convert.ToInt32(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "ID").ToString()));
                        DG.Rows[i - 1].Cells["col_Cod_Empresa"].Value = RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Cod_Empresa").ToString();
                        DG.Rows[i - 1].Cells["col_DescricaoEmpresa"].Value = RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Empresa").ToString();
                        DG.Rows[i - 1].Cells["col_Servidor"].Value = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Servidor").ToString());
                        DG.Rows[i - 1].Cells["col_Banco"].Value = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Banco").ToString());
                        DG.Rows[i - 1].Cells["col_Acesso"].Value = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Acesso").ToString());
                        DG.Rows[i - 1].Cells["col_Relatorio"].Value = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Relatorio").ToString());
                        DG.Rows[i - 1].Cells["col_TipoSistema"].Value = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "TipoSistema").ToString());
                    }
                }
                catch (Exception)
                {
                }

            txt_CaminhoSistema.Text = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("Sistema").ToString());
            txt_ServidorAtualizacao.Text = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("ServidorAtualizacao").ToString());

            if (RegKey.OpenSubKey("SystemSoft", true).GetValue("ACS") != null)
                ck_Controle.Checked = Convert.ToBoolean(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("ACS").ToString()));

            if (RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe") != null)
                ck_NFe.Checked = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe").ToString());

            if (RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe") != null)
                ck_CFe.Checked = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe").ToString());
          }
        #endregion

        #region BUTTON
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            DG.Rows.Add();
        }

        private void bt_Grava_Click(object sender, EventArgs e)
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);//CRIA REFERENCIA PARA CHAVE DE REGISTRO

            #region CARREGA INFORMAÇÕES
            string Servidor = string.Empty;
            string Acesso = string.Empty;
            string CaminhoBackup = string.Empty;
            string CaminhoXML = string.Empty;
            string Horario = string.Empty;
            string Endereco_Proxy = string.Empty;
            string Porta_Proxy = string.Empty;
            string Usuario_Proxy = string.Empty;
            string Senha_Proxy = string.Empty;
            bool Rede = false;
            string UltimoBKP = string.Empty;
            int ID_EmpresaPrincipal = 0;
            bool Liberado = true;
            bool NFe = false;
            bool CFe = false;
            bool Abrir_Monitor = false;

            if (RegKey.OpenSubKey("SystemSoft", true) != null)
            {
                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Servidor") != null)
                    Servidor = RegKey.OpenSubKey("SystemSoft", true).GetValue("Servidor").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Acesso") != null)
                    Acesso = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("Acesso").ToString());

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("CaminhoBackup") != null)
                    CaminhoBackup = RegKey.OpenSubKey("SystemSoft", true).GetValue("CaminhoBackup").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("CaminhoXML") != null)
                    CaminhoXML = RegKey.OpenSubKey("SystemSoft", true).GetValue("CaminhoXML").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Endereco_Proxy") != null)
                    Endereco_Proxy = RegKey.OpenSubKey("SystemSoft", true).GetValue("Endereco_Proxy").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Porta_Proxy") != null)
                    Porta_Proxy = RegKey.OpenSubKey("SystemSoft", true).GetValue("Porta_Proxy").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Usuario_Proxy") != null)
                    Usuario_Proxy = RegKey.OpenSubKey("SystemSoft", true).GetValue("Usuario_Proxy").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Senha_Proxy") != null)
                    Senha_Proxy = RegKey.OpenSubKey("SystemSoft", true).GetValue("Senha_Proxy").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Horario") != null)
                    Horario = RegKey.OpenSubKey("SystemSoft", true).GetValue("Horario").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Rede") != null)
                    Rede = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("Rede"));

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("UltimoBackup") != null)
                    UltimoBKP = RegKey.OpenSubKey("SystemSoft", true).GetValue("UltimoBackup").ToString();

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("ID_Empresa") != null)
                    ID_EmpresaPrincipal = util_dados.Verifica_int(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("ID_Empresa").ToString()));

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("ACS") != null)
                    Liberado = Convert.ToBoolean(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("ACS").ToString()));

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe") != null)
                    NFe = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe").ToString());

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe") != null)
                    CFe = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe").ToString());

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("Abrir_Monitor") != null)
                    Abrir_Monitor = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("Abrir_Monitor").ToString());
            }
            #endregion

            try
            {
                RegKey.DeleteSubKey("SystemSoft");//EXCLUI SUBCHAVE
            }
            catch (Exception)
            {
            }
            RegKey = RegKey.CreateSubKey("SystemSoft");//CRIA SUBCHAVE

            if (DG.Rows.Count > 0)
                for (int i = 1; i <= DG.Rows.Count; i++)
                {
                    RegKey.SetValue(i + "ID", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_ID"].Value.ToString()));
                    RegKey.SetValue(i + "Cod_Empresa", DG.Rows[i - 1].Cells["col_Cod_Empresa"].Value.ToString());
                    RegKey.SetValue(i + "Empresa", DG.Rows[i - 1].Cells["col_DescricaoEmpresa"].Value.ToString());
                    RegKey.SetValue(i + "Servidor", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_Servidor"].Value.ToString()));
                    RegKey.SetValue(i + "Banco", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_Banco"].Value.ToString()));
                    RegKey.SetValue(i + "Acesso", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_Acesso"].Value.ToString()));
                    RegKey.SetValue(i + "Relatorio", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_Relatorio"].Value.ToString()));
                    RegKey.SetValue(i + "TipoSistema", util_dados.Criptografa(DG.Rows[i - 1].Cells["col_TipoSistema"].Value.ToString()));
                }

            RegKey.SetValue("Servidor", Servidor);
            RegKey.SetValue("Acesso", util_dados.Criptografa(Acesso));
            RegKey.SetValue("CaminhoBackup", CaminhoBackup);
            RegKey.SetValue("CaminhoXML", CaminhoXML);

            RegKey.SetValue("Endereco_Proxy", Endereco_Proxy);
            RegKey.SetValue("Porta_Proxy", Porta_Proxy);
            RegKey.SetValue("Usuario_Proxy", Usuario_Proxy);
            RegKey.SetValue("Senha_Proxy", Senha_Proxy);

            RegKey.SetValue("Horario", Horario);
            RegKey.SetValue("Rede", Rede);
            RegKey.SetValue("UltimoBackup", UltimoBKP);

            RegKey.SetValue("Sistema", util_dados.Criptografa(txt_CaminhoSistema.Text));
            RegKey.SetValue("ServidorAtualizacao", util_dados.Criptografa(txt_ServidorAtualizacao.Text));
            RegKey.SetValue("ID_Empresa", util_dados.Criptografa(ID_EmpresaPrincipal.ToString()).ToString());
            RegKey.SetValue("ACS", util_dados.Criptografa(ck_Controle.Checked.ToString()));
            RegKey.SetValue("NFe", ck_NFe.Checked);
            RegKey.SetValue("CFe", ck_CFe.Checked);
            RegKey.Close();

            MessageBox.Show(util_msg.msg_Grava, this.Text);
        }

        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Exclui, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                DG.Rows.RemoveAt(DG.CurrentRow.Index);
        }
        #endregion

        #region FORM
        private void UI_ConfiguraAcesso_Load(object sender, EventArgs e)
        {
            try
            {
                Lista_Empresa();
            }
            catch (Exception)
            {

            }
        }

        private void UI_ConfiguraAcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region TEXTBOX
        private void txt_Acesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               if (txt_Acesso.Text == Parametro_Sistema.Acesso_Config)
                {
                    gb_Configura.Enabled = true;
                    gb_Configura.Visible = true;
                }
        }

        private void txt_CaminhoSistema_DoubleClick(object sender, EventArgs e)
        {
            PesquisaCaminho.ShowDialog();
            txt_CaminhoSistema.Text = PesquisaCaminho.SelectedPath;
        }

        private void txt_ServidorAtualizacao_DoubleClick(object sender, EventArgs e)
        {
            PesquisaCaminho.ShowDialog();
            txt_ServidorAtualizacao.Text = PesquisaCaminho.SelectedPath;
        }
        #endregion

        #region DATAGRIDVIEW
        private void DG_DoubleClick(object sender, EventArgs e)
        {
            PesquisaCaminho.ShowDialog();
            DG.Rows[DG.CurrentRow.Index].Cells[DG.CurrentCell.ColumnIndex].Value = PesquisaCaminho.SelectedPath;
        }
        #endregion
    }
}

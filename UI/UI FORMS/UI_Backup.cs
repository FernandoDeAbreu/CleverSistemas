using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System.IO;

namespace Sistema.UI
{
    public partial class UI_Backup : Sistema.UI.UI_Modelo
    {
        public UI_Backup()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Backup BLL_Backup;
        #endregion

        #region ESTRUTURAS
        DTO_Backup Backup;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CÓPIA DE SEGURANÇA";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            try
            {
                RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);
                lb_UltimoBackup.Text = "ÚLTIMO BACKUP: " + RegKey.OpenSubKey("SystemSoft", true).GetValue("UltimoBackup").ToString().Trim();
                RegKey.Close();
            }
            catch (Exception)
            {
            }
        }

        private void Copia_Seguranca()
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);

            string CaminhoTemp = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("Sistema").ToString()) + @"\Temp\";
            string CaminhoSistema = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("Sistema").ToString()) + @"\BKP\MANUAL\";
            string CaminhoXML = RegKey.OpenSubKey("SystemSoft", true).GetValue("CaminhoXML").ToString();

            Pesquisa.ShowDialog();
            string CaminhoBackup = Pesquisa.SelectedPath + @"\";

            if (CaminhoBackup != string.Empty)
            {
                lb_UltimoBackup.Text = "Realizando cópia de segurança, aguarde...";
                MessageBox.Show("Aguarde, este processo pode demorar alguns minutos!\nClique em 'OK' e aguarde...");
            }
            else
                return;

            string Data = DateTime.Now.ToString("dd-MM-yyyy_HHmm");

            try
            {
                #region CRIA DIRETORIOS
                if (!Directory.Exists(CaminhoSistema))
                    Directory.CreateDirectory(CaminhoSistema);

                if (!Directory.Exists(CaminhoBackup))
                    Directory.CreateDirectory(CaminhoBackup);
                #endregion

                DataTable _lst_BD = new DataTable();

                BLL_Backup = new BLL_Backup();

                //LISTA BANCO DE DADOS NO SERVIDOR
                _lst_BD = BLL_Backup.Lista_BD();

                for (int i = 0; i < _lst_BD.Rows.Count; i++)
                    try
                    {
                        string _BD = _lst_BD.Rows[i]["name"].ToString();

                        BLL_Backup = new BLL_Backup();
                        Backup = new DTO_Backup();
                        Backup.Banco = _BD;
                        Backup.Local = CaminhoTemp + _BD + ".bak";

                        BLL_Backup.Grava_Backup(Backup);

                        //VERIFICA SE REALMENTE FOI REALIZADO O BACKUP
                        if (!File.Exists(CaminhoTemp + _BD + ".bak"))
                            throw new Exception("Ocorreu um erro ao criar cópia de segurança!\nBanco de dados: " + _BD);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                #region BACKUP BD
                FastZip fz = new FastZip();
                fz.CreateZip(CaminhoSistema + Data + ".zip", CaminhoTemp, true, ".*\\.(bak)$", "");

                if (File.Exists(CaminhoSistema + Data + ".zip"))
                {
                    string[] _aux = Directory.GetFiles(CaminhoTemp, "*.bak");

                    foreach (string arquivo in _aux)
                        File.Delete(arquivo);
                }
                #endregion

                #region BACKUP XML
                if (CaminhoXML != string.Empty)
                {
                    fz = new FastZip();
                    fz.CreateZip(CaminhoSistema + Data + "_xml.zip", CaminhoXML, true, ".*\\.(xml)$", "");
                }
                #endregion

                File.Copy(CaminhoSistema + Data + ".zip", CaminhoBackup + Data + ".zip");

                if (CaminhoXML != string.Empty)
                    File.Copy(CaminhoSistema + Data + "_xml.zip", CaminhoBackup + Data + "_xml.zip");

                MessageBox.Show("Cópia de segurança realizada com sucesso!", this.Text);
                System.Diagnostics.Process.Start("Explorer", CaminhoBackup);

                RegKey = RegKey.CreateSubKey("SystemSoft");
                RegKey.SetValue("UltimoBackup", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                lb_UltimoBackup.Text = "ÚLTIMO BACKUP: " + RegKey.GetValue("UltimoBackup").ToString();
                RegKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RegKey.Close();
            }
        }
        #endregion

        #region BUTTON
        private void bt_RealizaBackup_Click(object sender, EventArgs e)
        {
            Copia_Seguranca();
        }
        #endregion

        #region FORM
        private void UI_Backup_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion
    }
}

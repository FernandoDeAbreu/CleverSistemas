using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Sintegra : Sistema.UI.UI_Modelo
    {
        public UI_Sintegra()
        {
            InitializeComponent();
        }

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "SINTEGRA";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Pesquisa.Visible = false;
        }

        private void Gera_Arquivo()
        {
            try
            {
                string CaminhoArquivo = string.Empty;

                DialogResult msgbox = new DialogResult();
                msgbox = Pesquisa_Pasta.ShowDialog();

                if (msgbox == DialogResult.Cancel)
                    return;

                int TamanhoCaminho = Pesquisa_Pasta.SelectedPath.Length;
                string Barra = Pesquisa_Pasta.SelectedPath.Substring(TamanhoCaminho - 1);

                if (Barra == @"\")
                    CaminhoArquivo = Pesquisa_Pasta.SelectedPath;
                else
                    CaminhoArquivo = Pesquisa_Pasta.SelectedPath + @"\";

                if (CaminhoArquivo == string.Empty)
                    return;

                if (string.IsNullOrEmpty(mk_Data.Text.Replace(@"/", "").Trim()))
                    return;

                BLL_Sintegra sintegra = new BLL_Sintegra();
                sintegra.GerarSintegra(Convert.ToDateTime("01/" + mk_Data.Text), ck_Inventario.Checked, CaminhoArquivo);

                MessageBox.Show(util_msg.msg_ArquivoGerado, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region BUTTON
        private void bt_Gerar_Click(object sender, EventArgs e)
        {
            Gera_Arquivo();
        }
        #endregion

        #region FORM
        private void UI_Sintegra_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Data(@"01/" + mk_Data.Text))
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_Data.Text = util_dados.Config_Data(DateTime.Now, 19).ToString();
            }
        }
        #endregion
    }
}

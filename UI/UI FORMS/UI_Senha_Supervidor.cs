using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Senha_Supervidor : Form
    {
        public UI_Senha_Supervidor()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Usuario BLL_Usuario;
        #endregion

        #region ESTRUTURA
        DTO_Usuario Usuario;
        #endregion

        #region PROPRIEDADES
        public string DescricaoLiberacao { get; set; }
        public bool Liberado { get; set; }

        /// <summary>
        /// 1 - LIBERA DESCONTO
        /// 2 - RESUMO VENDA
        /// </summary>
        public int Tipo { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = DescricaoLiberacao;

            this.DelegateEnterFocus(this);
        }

        private void Consulta_Usuario()
        {
            try
            {
                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.Descricao = txt_Usuario.Text;
                Usuario.SenhaSistema = txt_Senha.Text;
                Usuario.TipoConsulta = Tipo;

                DataTable _DT = new DataTable();

                _DT = BLL_Usuario.Busca_Usuario(Usuario);

                if (_DT.Rows.Count > 0)
                    Liberado = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (sender is UpDownBase)
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                else if (sender is TextBoxBase)
                    ((TextBoxBase)sender).SelectAll();
            });
        }

        private void DelegateEnterFocus(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
            {
                ctrl.Enter += SelectText_Enter;
                return;
            }

            foreach (Control ctrlChild in ctrl.Controls)
                this.DelegateEnterFocus(ctrlChild);
        }
        #endregion

        #region FORM
        private void UI_Senha_Supervidor_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Senha_Supervidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region BUTTON
        private void bt_Libera_Click(object sender, EventArgs e)
        {
            Consulta_Usuario();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFe_CCe : Form
    {
        public UI_NFe_CCe()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        public string Justificativa { get; set; }
        #endregion

        #region BUTTON
        private void bt_Confirmar_Click(object sender, EventArgs e)
        {
            if (txt_Justificativa.Text.ToString().Trim().Length < 15)
            {
                MessageBox.Show(util_msg.msg_qant_invalido, this.Text);
                return;
            }

            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_CC, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
            {
                this.Justificativa = util_dados.RemoveAspa(txt_Justificativa.Text);
                this.Close();
            }
        }
        #endregion

        #region FORM
        private void UI_NFe_CCe_Load(object sender, EventArgs e)
        {
            Justificativa = string.Empty;
            txt_Justificativa.Focus();
        }
        #endregion

        #region TEXTBOX
        private void txt_Justificativa_Leave(object sender, EventArgs e)
        {
            txt_Justificativa.Text = txt_Justificativa.Text.Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }
        #endregion
    }
}

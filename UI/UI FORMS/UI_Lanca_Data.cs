using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Lanca_Data : Form
    {
        public UI_Lanca_Data()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;
        #endregion

        #region PROPRIEDADES
        public bool Lanca { get; set; }
        public DateTime Data { get; set; }
        #endregion

        #region ROTINAS
        private void IniciaForm()
        {
            this.Text = "DATA DE LANÇAMENTO";

            Lanca = false;

            mk_Data.Text = DateTime.Now.ToString();
            
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is TextBoxBase)
                {
                    ((TextBoxBase)sender).SelectAll();
                }
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
            {
                this.DelegateEnterFocus(ctrlChild);
            }
        }
        #endregion

        #region FORM
        private void UI_Lanca_Data_Load(object sender, EventArgs e)
        {
            this.DelegateEnterFocus(this);

            IniciaForm();
        }

        private void UI_Lanca_Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region BUTTON
        private void bt_Concluido_Click(object sender, EventArgs e)
        {
            Data = Convert.ToDateTime(mk_Data.Text);
            Lanca = true;
            this.Close();
        }
        #endregion
        
        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }
           
        }
        #endregion
    }
}

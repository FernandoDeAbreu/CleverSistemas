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
    public partial class UI_Modelo_Financeiro : Form
    {
        public UI_Modelo_Financeiro()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        #region VARIAVEIS
        bool Modo_Edicao = false;
        #endregion

        #region PROPRIEDADES
        public StatusForm Status;
        #endregion

        #region ROTINAS
        public void Config_Botao()
        {
            if (Status == StatusForm.Novo)
            {
                bt_Novo.Enabled = true;
                bt_Edita.Enabled = false;
                bt_Grava.Enabled = true;
                bt_Exclui.Enabled = false;
                bt_Imprime.Enabled = false;
                bt_Visualiza.Enabled = false;
                bt_Pesquisa.Enabled = true;
                bt_Proximo.Enabled = false;
                bt_Anterior.Enabled = false;
            }

            if (Status == StatusForm.Edita)
            {
                bt_Novo.Enabled = true;
                bt_Edita.Enabled = false;
                bt_Grava.Enabled = true;
                bt_Exclui.Enabled = true;
                bt_Imprime.Enabled = true;
                bt_Visualiza.Enabled = true;
                bt_Pesquisa.Enabled = true;
                bt_Proximo.Enabled = false;
                bt_Anterior.Enabled = false;
            }

            if (Status == StatusForm.Consulta)
            {
                bt_Novo.Enabled = true;
                bt_Edita.Enabled = true;
                bt_Grava.Enabled = false;
                bt_Exclui.Enabled = false;
                bt_Imprime.Enabled = true;
                bt_Visualiza.Enabled = true;
                bt_Pesquisa.Enabled = true;
                bt_Proximo.Enabled = true;
                bt_Anterior.Enabled = true;
            }
        }

        public void Config(StatusForm _Status)
        {
            Status = _Status;
            Config_Botao();
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
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

        private void Sair()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_FechaModulo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                this.Close();
        }
        #endregion

        #region MODIFICADORES
        public virtual void Gravar()
        {
        }

        public virtual void Excluir()
        {
        }

        public virtual void Pesquisa()
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }

        public virtual void Edita()
        {
        }

        public virtual void Novo()
        {
        }

        public virtual void Imprimir()
        {
        }

        public virtual void Visualizar()
        {
        }

        public virtual void ExibeRegistro()
        {
        }

        public virtual void Proximo()
        {
        }

        public virtual void Anterior()
        {
        }
        #endregion

        #region FORM
        private void UI_Modelo_Venda_Load(object sender, EventArgs e)
        {
            Status = StatusForm.Novo;
            Config_Botao();

            this.DelegateEnterFocus(this);
        }

        private void UI_Modelo_Venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                Sair();

            if (Parametro_Cadastro.Somente_Maiusculo == true)
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void UI_Modelo_Financeiro_TextChanged(object sender, EventArgs e)
        {
            lb_Descricaotela.Text = this.Text;
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Novo();

            Status = StatusForm.Novo;
            Config_Botao();
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            Status = StatusForm.Edita;
            Config_Botao();
            Edita();
        }

        private void bt_Grava_Click(object sender, EventArgs e)
        {
            Gravar();
            Config_Botao();
        }

        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            Excluir();
            Config_Botao();
        }

        private void bt_Imprime_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void bt_Pesquisa_Click(object sender, EventArgs e)
        {
          //  Status = StatusForm.Consulta;
         //   Config_Botao();

            Pesquisa();
        }

        private void bt_Fecha_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void bt_Visualiza_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void bt_Proximo_Click(object sender, EventArgs e)
        {
            Proximo();
        }

        private void bt_Anterior_Click(object sender, EventArgs e)
        {
            Anterior();
        }
        #endregion
    }
}

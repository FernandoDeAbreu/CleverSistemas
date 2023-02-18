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
    public partial class UI_Modelo : Form
    {
        public UI_Modelo()
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
        #endregion

        #region FORM
        private void UI_Modelo_Venda_Load(object sender, EventArgs e)
        {
            Status = StatusForm.Novo;
            Config_Botao();

            DG.AutoGenerateColumns = false;

            this.DelegateEnterFocus(this);
        }

        private void UI_Modelo_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   e.Cancel = MessageBox.Show("Deseja fechar a rotina?","Clever Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;

        }
        private void UI_Modelo_Venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (this.Text == "CADASTRO DE EMAIL")
                    return;

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                Sair();

            if (Parametro_Cadastro.Somente_Maiusculo == true)
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void UI_Modelo_TextChanged(object sender, EventArgs e)
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
            ExibeRegistro();
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
            Pesquisa();
            textBox1.Text = "Registros: " + Convert.ToString(DG.Rows.Count);
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
            if (DG.Rows.Count == 0 || DG.Rows.Count == 1)
                return;

            if (DG.CurrentRow == null)
                DG.Rows[0].Cells[0].Selected = true;

            int aux = DG.CurrentRow.Index + 1;
            if (aux < DG.Rows.Count)
            {
                DG.Rows[DG.CurrentRow.Index].Cells[0].Selected = false;
                DG.Rows[aux].Cells[0].Selected = true;
            }
        }

        private void bt_Anterior_Click(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0 || DG.Rows.Count == 1)
                return;

            if (DG.CurrentRow == null)
                DG.Rows[0].Cells[0].Selected = true;

            int aux = DG.CurrentRow.Index - 1;
            if (aux >= 0)
            {
                DG.Rows[DG.CurrentRow.Index].Cells[0].Selected = false;
                DG.Rows[aux].Cells[0].Selected = true;
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void DG_DoubleClick(object sender, EventArgs e)
        {
            ExibeRegistro();
        }
        #endregion

      
    }
}

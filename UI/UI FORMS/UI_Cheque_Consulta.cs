using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Cheque_Consulta : Form
    {
        public UI_Cheque_Consulta()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Cheque BLL_Cheque;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        string obj;

        DataTable DT;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Cheque Cheque;
        DTO_Pessoa Pessoa;
        #endregion

        #region PROPRIEDADES
        public int ID_Cheque { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            dg_Cheque.AutoGenerateColumns = false;

            CarregaCB();
        }

        private void Consulta()
        {
            DT = new DataTable();

            BLL_Cheque = new BLL_Cheque();

            Cheque = new DTO_Cheque();

            Cheque.Tipo = 2;
            Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Cheque.Banco = txt_BancoP.Text;
            Cheque.Agencia = txt_AgenciaP.Text;
            Cheque.Conta = txt_ContaP.Text;
            Cheque.Cheque = txt_ChequeP.Text;
            Cheque.Documento = string.Empty;
            Cheque.Situacao = 1;

            if (mk_DataInicial.Text.Replace(@"/", "").Replace(" ", "") != string.Empty &&
                mk_DataFinal.Text.Replace(@"/", "").Replace(" ", "") != string.Empty)
            {
                Cheque.Consulta_Vencimento.Filtra = true;
                Cheque.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Cheque.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DT = BLL_Cheque.Busca(Cheque);

            if (DT.Rows.Count > 0)
                dg_Cheque.DataSource = DT;
            else
                dg_Cheque.DataSource = null;
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DT = new DataTable();
                DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Seleciona_Cheque()
        {
            try
            {
                ID_Cheque = Convert.ToInt32(dg_Cheque.Rows[dg_Cheque.CurrentRow.Index].Cells["col_ID"].Value);
            }
            catch (Exception)
            {
            }

            this.Close();
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

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa();
            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }
        #endregion

        #region FORM
        private void UI_Cheque_Consulta_Load(object sender, EventArgs e)
        {
            this.DelegateEnterFocus(this);

            Inicia_Form();

            ID_Cheque = 0;
            Consulta();
        }

        private void UI_Cheque_Consulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Consulta();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }

        private void UI_Cheque_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                dg_Cheque.Focused == false)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region BUTTON
        private void bt_Seleciona_Click(object sender, EventArgs e)
        {
            Seleciona_Cheque();
        }

        private void bt_Pesquisa_Click(object sender, EventArgs e)
        {
            Consulta();
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }

        }

        private void mk_DataFinal_Leave(object sender, EventArgs e)
        {
            if (mk_DataFinal.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }

        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }
        #endregion

        #region DATAGRID
        private void dg_Cheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Seleciona_Cheque();
        }

        #endregion

    }
}

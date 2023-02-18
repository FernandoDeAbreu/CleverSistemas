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
    public partial class UI_Pessoa_Consulta : Form
    {
        Locacao.frm_Locacao inst_Loc_Produto;
        UI_FROTA_ABASTECIMENTO inst_Abastecimento;
        public string rotina;

        public UI_Pessoa_Consulta()
        {
            InitializeComponent();
        }


        public UI_Pessoa_Consulta(Locacao.frm_Locacao Loc_Produto)
        {
            InitializeComponent();
            inst_Loc_Produto = Loc_Produto;

        }
        public UI_Pessoa_Consulta(UI_FROTA_ABASTECIMENTO abastecimento)
        {
            InitializeComponent();
            inst_Abastecimento = abastecimento;

        }

        #region PROPRIEDADES
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        public bool OcultaNovoCadastro { get; set; }

        public bool NovoCadastro { get; set; }

        public bool Usuario_Restrito { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            if (OcultaNovoCadastro == true)
            {
                bt_Novo.Visible = false;
                cb_TipoPessoa.Enabled = false;
            }

            this.DelegateEnterFocus(this);

            NovoCadastro = false;

            CarregaCB();
            ID_Pessoa = 0;

            if (TipoPessoa == 0)
                cb_TipoPessoa.SelectedIndex = 0;
            else
                cb_TipoPessoa.SelectedValue = TipoPessoa;

            dg_PesquisaPessoa.AutoGenerateColumns = false;

            txt_Descricao.Focus();
        }

        private void Pesquisa()
        {
            DataTable _DT = new DataTable();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = util_dados.Verifica_int(txt_ID.Text);
            Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
            Pessoa.Nome_Razao = txt_Descricao.Text;
            Pessoa.NomeFantasia = txt_NomeFantasia.Text;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Pessoa.PesquisaTelefone = txt_Telefone.Text;
            Pessoa.PesquisaLogradouro = txt_Logradouro.Text;

            _DT = BLL_Pessoa.Busca_Completa(Pessoa);

            dg_PesquisaPessoa.DataSource = _DT;
            dg_PesquisaPessoa.Focus();
        }

        private void preencherCampos()
        {
            try
            {
                if (rotina == "Locação de Equipamento")
                {
                    inst_Loc_Produto.tbox_codClinte.Text = dg_PesquisaPessoa.CurrentRow.Cells[0].Value.ToString();
                    inst_Loc_Produto.tbox_nomeCliente.Text = dg_PesquisaPessoa.CurrentRow.Cells[1].Value.ToString();
                }
                if (rotina == "Locação de Equipamento 2")
                {
                    inst_Loc_Produto.tbox_codCliente2.Text = dg_PesquisaPessoa.CurrentRow.Cells[0].Value.ToString();
                    inst_Loc_Produto.tbox_RazaoSocial.Text = dg_PesquisaPessoa.CurrentRow.Cells[1].Value.ToString();
                }

                if (rotina == "abastecimento")
                {
                    inst_Abastecimento.tbox_codFornec.Text = dg_PesquisaPessoa.CurrentRow.Cells[0].Value.ToString();
                    inst_Abastecimento.tbox_fornecedor.Text = dg_PesquisaPessoa.CurrentRow.Cells[1].Value.ToString();
                }
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show(util_msg.msg_Erro);
            }

        }
        private void Seleciona_Pessoa()
        {
            try
            {
                TipoPessoa = Convert.ToInt32(dg_PesquisaPessoa.Rows[dg_PesquisaPessoa.CurrentRow.Index].Cells["col_TipoPessoa"].Value);
                ID_Pessoa = Convert.ToInt32(dg_PesquisaPessoa.Rows[dg_PesquisaPessoa.CurrentRow.Index].Cells["col_ID_Pessoa"].Value);
            }
            catch (Exception)
            {
            }

            this.Close();
        }

        private void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 1;

            if (Usuario_Restrito == true)
                cb_TipoPessoa.Enabled = false;
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
        private void UI_Pessoa_Consulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }

        private void UI_Pessoa_Consulta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                dg_PesquisaPessoa.Focused == false)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();

            if (txt_ID.Focused == true ||
                txt_CNPJ_CPF.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_SelecionarPessoa_Click(object sender, EventArgs e)
        {
            preencherCampos();
            Seleciona_Pessoa();

        }

        private void bt_Localizar_Click(object sender, EventArgs e)
        {
            Pesquisa();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            NovoCadastro = true;

            this.Close();
        }
        #endregion

        #region TEXTBOX
        private void txt_CNPJ_CPF_Leave(object sender, EventArgs e)
        {
            if (txt_CNPJ_CPF.Text.Trim() == string.Empty)
                return;

            if (txt_CNPJ_CPF.Text.Trim().Length == 11)
                txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CPF);
            else if (txt_CNPJ_CPF.Text.Trim().Length == 14)
                txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CNPJ);

            if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
            {
                MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido);
                txt_CNPJ_CPF.Focus();
                return;
            }
        }

        private void txt_CNPJ_CPF_Enter(object sender, EventArgs e)
        {
            txt_CNPJ_CPF.Text = util_dados.Retorna_Numero(txt_CNPJ_CPF.Text);
        }
        #endregion

        #region DATAGRID
        private void dg_PesquisaPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Seleciona_Pessoa();
        }
        #endregion



        private void dg_PesquisaPessoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherCampos();
            Seleciona_Pessoa();

        }
    }
}

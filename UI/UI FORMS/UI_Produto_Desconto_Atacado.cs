using System;
using System.Data;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Collections.Generic;

namespace Sistema.UI
{
    public partial class UI_Produto_Desconto_Atacado : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Desconto_Atacado()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Pessoa Pessoa;
        #endregion

        #region PROPRIEDADES
        /// <summary>
        /// <para>1 - CADASTRO DESCONTO ATACADO</para>
        /// <para>2 - DESCONTO PERSONALIZADO PESSOA</para>
        /// </summary>
        public Tipo_DescontoProduto Tipo { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            switch (Tipo)
            {
                case Tipo_DescontoProduto.Desconto_Atacado:
                    this.Text = "CONFIGURAÇÃO DE DESCONTO - ATACADO";

                    tabctl.TabPages.Remove(TabPage2);
                    tabctl.TabPages.Remove(tabPage3);

                    tabctl.SelectedTab = TabPage1;
                    break;

                case Tipo_DescontoProduto.Desconto_Pessoa:
                    this.Text = "CONFIGURAÇÃO DE DESCONTO PERSONALIZADO POR PESSOA";

                    tabctl.TabPages.Remove(TabPage2);
                    tabctl.TabPages.Remove(TabPage1);

                    tabctl.SelectedTab = tabPage3;

                    bt_Grava.Visible = true;
                    break;
            }

            dg_Produto.AutoGenerateColumns = false;
            dg_Desconto.AutoGenerateColumns = false;

            Carrega_CB();

            Pesquisa();
        }

        private void Carrega_CB()
        {
            DataTable _DT;
            switch (Tipo)
            {
                case Tipo_DescontoProduto.Desconto_Atacado:
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();

                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Produto.Consulta_Ativo = true;
                    Produto.Ativo = true;
                    Produto.Consulta_Tipo = true;
                    Produto.Tipo = "1, 3, 5";

                    if (Parametro_Venda.Produto_Marca == true)
                        Produto.ConsultaMarca = true;

                    _DT = new DataTable();
                    _DT = BLL_Produto.Busca(Produto);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Produto);
                    cb_ID_Produto.SelectedIndex = -1;
                    break;

                case Tipo_DescontoProduto.Desconto_Pessoa:
                    _DT = new DataTable();
                    _DT = util_Param.Tipo_Pessoa();
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
                    cb_TipoPessoa.SelectedValue = 1;

                    List<string> TipoComissao = new List<string>();
                    TipoComissao.Add("VALOR");
                    TipoComissao.Add("PORCENTAGEM");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, TipoComissao), "Descricao", "ID", cb_ID_TipoDesconto);
                    break;
            }
        }

        private void Carrega_Pessoa()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Pessoa.FiltraSituacao = true;
            Pessoa.Situacao = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
            cb_ID_Pessoa.SelectedIndex = -1;
        }

        private void Busca_Produto()
        {
            dg_Produto.DataSource = null;

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Produto.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Produto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            DataTable _DT = new DataTable();

            _DT = BLL_Produto.Busca_Desconto_Pessoa(Produto);

            dg_Desconto.DataSource = _DT;
        }

        private List<DTO_Produto_Desconto_Pessoa> Carrega_ProdutoDesconto()
        {
            List<DTO_Produto_Desconto_Pessoa> lst_ProdutoDesconto = new List<DTO_Produto_Desconto_Pessoa>();
            DTO_Produto_Desconto_Pessoa _Produto = new DTO_Produto_Desconto_Pessoa();

            for (int i = 0; i <= dg_Desconto.Rows.Count - 1; i++)
            {
                if (util_dados.Verifica_int(dg_Desconto.Rows[i].Cells["col_ID_DescontoPessoa"].Value.ToString()) != 0 ||
                   util_dados.Verifica_Double(dg_Desconto.Rows[i].Cells["col_DescontoPessoa"].Value.ToString()) > 0)
                {
                    _Produto = new DTO_Produto_Desconto_Pessoa();

                    _Produto.ID = util_dados.Verifica_int(dg_Desconto.Rows[i].Cells["col_ID_DescontoPessoa"].Value.ToString());
                    _Produto.ID_Produto = util_dados.Verifica_int(dg_Desconto.Rows[i].Cells["col_ID_ProdutoDesconto"].Value.ToString());
                    _Produto.Tipo = util_dados.Verifica_int(dg_Desconto.Rows[i].Cells["col_ID_TipoDesconto"].Value.ToString());
                    _Produto.Desconto = util_dados.Verifica_Double(dg_Desconto.Rows[i].Cells["col_DescontoPessoa"].Value.ToString());

                    lst_ProdutoDesconto.Add(_Produto);
                }
            }

            return lst_ProdutoDesconto;
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                switch (Tipo)
                {
                    case Tipo_DescontoProduto.Desconto_Atacado:
                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();

                        if (cb_ID_Produto.SelectedValue != null)
                            Produto.ID = util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString());

                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        DataTable _DT = new DataTable();
                        _DT = BLL_Produto.Busca_Desconto(Produto);

                        dg_Produto.DataSource = _DT;
                        break;

                    case Tipo_DescontoProduto.Desconto_Pessoa:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Gravar()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaInfo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                switch (Tipo)
                {
                    case Tipo_DescontoProduto.Desconto_Atacado:

                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();

                        Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Produto.Quantidade_Minima = util_dados.Verifica_Double(txt_Quantidade_Minima.Text);
                        Produto.Quantidade_Maxima = util_dados.Verifica_Double(txt_Quantidade_Maxima.Text);
                        Produto.Desconto = util_dados.Verifica_Double(txt_Desconto.Text);

                        BLL_Produto.Grava_Desconto(Produto);
                        break;

                    case Tipo_DescontoProduto.Desconto_Pessoa:
                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();

                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Produto.Desconto_Pessoa = Carrega_ProdutoDesconto();

                        Produto.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
                        Produto.ID_Pessoa = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());

                        BLL_Produto.Grava_Desconto_Pessoa(Produto);
                        break;
                }
                MessageBox.Show(util_msg.msg_Grava, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();


                Produto = new DTO_Produto();
                Produto.ID_Desconto = util_dados.Verifica_int(dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_ID_Desconto"].Value.ToString());

                BLL_Produto.Exclui_Desconto(Produto);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_Desconto_Atacado_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Desconto_Atacado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F10 &&
                tabctl.SelectedTab == TabPage1)
            {

                UI_Produto_Consulta frm = new UI_Produto_Consulta();
                frm.ID_Tabela = 0;
                frm.ShowDialog();

                if (frm.ID_Produto == 0)
                    return;

                cb_ID_Produto.Focus();
                cb_ID_Produto.SelectedValue = frm.ID_Produto;

                txt_Quantidade_Minima.Focus();
            }

            if (e.KeyCode == Keys.F7 &&
                 tabctl.SelectedTab == tabPage3)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;
                Carrega_Pessoa();

                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Adicionar_Click(object sender, EventArgs e)
        {
            Gravar();
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        #endregion

        #region TEXTBOX
        private void txt_Quantidade_Minima_Leave(object sender, EventArgs e)
        {
            txt_Quantidade_Minima.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade_Minima.Text), 3);
        }

        private void txt_Quantidade_Maxima_Leave(object sender, EventArgs e)
        {
            txt_Quantidade_Maxima.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade_Maxima.Text), 3);
        }

        private void txt_Desconto_Leave(object sender, EventArgs e)
        {
            txt_Desconto.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Desconto.Text), 2);

        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Produto.SelectedIndex = -1;

        }
        #endregion

        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            Carrega_Pessoa();
        }

        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            Busca_Produto();
        }

        private void bt_DescontoUnico_Click(object sender, EventArgs e)
        {
            dg_Desconto.Rows[dg_Desconto.CurrentRow.Index].Cells["col_ID_TipoDesconto"].Value = cb_ID_TipoDesconto.SelectedValue;
            dg_Desconto.Rows[dg_Desconto.CurrentRow.Index].Cells["col_DescontoPessoa"].Value = Convert.ToDouble(txt_DescontoPessoa.Text);
            dg_Desconto.Rows[dg_Desconto.CurrentRow.Index].Cells["col_TipoDesconto"].Value = cb_ID_TipoDesconto.Text;
        }

        private void bt_DescontoTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dg_Desconto.Rows.Count - 1; i++)
            {
                dg_Desconto.Rows[i].Cells["col_ID_TipoDesconto"].Value = cb_ID_TipoDesconto.SelectedValue;
                dg_Desconto.Rows[i].Cells["col_DescontoPessoa"].Value = Convert.ToDouble(txt_DescontoPessoa.Text);
                dg_Desconto.Rows[i].Cells["col_TipoDesconto"].Value = cb_ID_TipoDesconto.Text;
            }
        }
    }
}

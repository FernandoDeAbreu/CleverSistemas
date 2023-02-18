using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Pessoa_Relacionamento : Sistema.UI.UI_Modelo
    {
        public UI_Pessoa_Relacionamento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Venda BLL_Venda;
        #endregion

        #region VARIAVEIS DIVERSAS

        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Pessoa_Endereco;
        DTO_Pessoa_Telefone Pessoa_Telefone;
        DTO_Pessoa_Email Pessoa_Email;
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELACIONAMENTO PESSOA";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            dg_Vendas.AutoGenerateColumns = false;
            dg_Itens_Venda.AutoGenerateColumns = false;

            dg_Endereco.AutoGenerateColumns = false;
            dg_Email.AutoGenerateColumns = false;
            dg_Telefone.AutoGenerateColumns = false;

            dg_ProdutoComprado.AutoGenerateColumns = false;

            Carrega_CB();

            Limpa_Campos();
        }

        private void Carrega_CB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = -1;
        }

        private void Limpa_Campos()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Venda);

            dg_Endereco.DataSource = null;
            dg_Telefone.DataSource = null;
            dg_Email.DataSource = null;

            dg_Vendas.DataSource = null;
            dg_Itens_Venda.Rows.Clear();

            dg_ProdutoComprado.DataSource = null;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                cb_ID_Pessoa.DataSource = null;

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;
                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;

                Limpa_Campos();
            }
            catch (Exception)
            {
            }
        }

        private void Busca_Cadastro()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Pessoa_Endereco = new DTO_Pessoa_Endereco();
            Pessoa_Telefone = new DTO_Pessoa_Telefone();
            Pessoa_Email = new DTO_Pessoa_Email();

            Pessoa.ID = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());
            Pessoa.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());

            if (Pessoa.ID == 0)
                return;

            DataTable _DT = new DataTable();

            _DT = BLL_Pessoa.Busca(Pessoa);
            util_dados.CarregaCampo(this, _DT, gb_Cadastro);

            _DT = new DataTable();
            Pessoa_Endereco.Principal = false;
            Pessoa.Endereco.Add(Pessoa_Endereco);
            _DT = BLL_Pessoa.Busca_Endereco(Pessoa);
            dg_Endereco.DataSource = _DT;

            _DT = new DataTable();
            Pessoa_Telefone.Principal = false;
            Pessoa.Telefone.Add(Pessoa_Telefone);
            _DT = BLL_Pessoa.Busca_Telefone(Pessoa);
            dg_Telefone.DataSource = _DT;

            _DT = new DataTable();
            Pessoa_Email.Principal = false;
            Pessoa.Email.Add(Pessoa_Email);
            _DT = BLL_Pessoa.Busca_Email(Pessoa);
            dg_Email.DataSource = _DT;
        }

        private void Busca_Venda()
        {
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Venda.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            Venda.ID_Pessoa = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());

            if (Venda.ID_Pessoa == 0)
                return;

            DataTable _DT = new DataTable();
            _DT = BLL_Venda.Busca_Fatura(Venda);

            if (_DT.Rows.Count > 0)
            {
                dg_Vendas.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Venda);
            }
        }

        private void Busca_Produto_Venda()
        {
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();
            
            Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            DataTable _DT = new DataTable();
            _DT =  BLL_Venda.Busca_ResumoProduto(Venda);

            dg_ProdutoComprado.DataSource = _DT;
        }

        private void Busca_Item(int _ID)
        {
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = _ID;
            DataTable _DT = new DataTable();
            _DT = BLL_Venda.Busca_Item(Venda);
            //dg_Itens.DataSource = _DT;

            List<DTO_Produto_Item> lst_Produto = new List<DTO_Produto_Item>();

            BLL_Venda = new BLL_Venda();
            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID = (int)_DT.Rows[i]["IDItem"];
                Produto_Item.ID_Produto = (int)_DT.Rows[i]["ID_Produto"];
                Produto_Item.Quantidade = Double.Parse(_DT.Rows[i]["Quantidade"].ToString());
                Produto_Item.ID_Tabela = (int)_DT.Rows[i]["ID_Tabela"];
                Produto_Item.ValorCusto = Double.Parse(_DT.Rows[i]["ValorCusto"].ToString());
                Produto_Item.ValorProduto = Double.Parse(_DT.Rows[i]["ValorProduto"].ToString());
                Produto_Item.ValorVenda = Double.Parse(_DT.Rows[i]["ValorVenda"].ToString());
                Produto_Item.Acrescimo = Double.Parse(_DT.Rows[i]["Acrescimo"].ToString());
                Produto_Item.Desconto = Double.Parse(_DT.Rows[i]["Desconto"].ToString());
                Produto_Item.Descricao_Produto = _DT.Rows[i]["DescricaoProduto"].ToString();
                Produto_Item.Descricao_Saida = _DT.Rows[i]["DescricaoSaida"].ToString();
                Produto_Item.Informacao = _DT.Rows[i]["Informacao"].ToString();
                Produto_Item.TipoSaida = (int)_DT.Rows[i]["TipoSaida"];
                Produto_Item.ID_Grade = (int)_DT.Rows[i]["ID_Grade"]; ;

                lst_Produto.Add(Produto_Item);
            }
            if (lst_Produto.Count > 0)
                Carrega_Item(lst_Produto);
        }

        private void Carrega_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens_Venda.Rows.Clear();
            double SubTotal = 0;
            double TotalDesconto = 0;

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens_Venda.Rows.Add();
                dg_Itens_Venda.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens_Venda.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens_Venda.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens_Venda.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;
                dg_Itens_Venda.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                dg_Itens_Venda.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorProduto;
                dg_Itens_Venda.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
                dg_Itens_Venda.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
                dg_Itens_Venda.Rows[i].Cells["col_TipoSaida"].Value = _lst_Produto[i].Descricao_Saida;
                dg_Itens_Venda.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

                SubTotal += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorProduto + _lst_Produto[i].Acrescimo);
                TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
            }

            txt_ValorPedido.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);
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

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());
                Pessoa.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca(Pessoa);

                util_dados.CarregaCampo(this, _DT, gb_Cadastro);

                Busca_Cadastro();
                Busca_Venda();
                Busca_Produto_Venda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Pessoa_Relacionamento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_Relacionamento_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Pessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Pessoa.Text.Trim() != string.Empty)
                    if (cb_ID_Pessoa.SelectedValue.GetType() == typeof(int) &&
                        Convert.ToInt32(cb_ID_Pessoa.SelectedValue) > 0)
                        Pesquisa();
                    else
                        Limpa_Campos();
            }
            catch (Exception)
            {
            }
        }

        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_Venda_TextChanged(object sender, EventArgs e)
        {
            Busca_Item(util_dados.Verifica_int(txt_ID_Venda.Text));
        }
        #endregion


    }
}

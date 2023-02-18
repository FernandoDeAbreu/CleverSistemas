using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_Orcamento : Sistema.UI.UI_Modelo
    {
        public UI_Orcamento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_TabelaValor BLL_TabelaValor;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Usuario BLL_Usuario;
        BLL_Orcamento BLL_Orcamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataRow DRPessoa;
        DataRow DREndereco;
        DataRow DRTelefone;
        DataRow DRProduto;
        DataTable DTUsuario;
        DataTable DTTabelaValor;
        DataTable DTProduto;
        DataTable DTPessoa;
        DataTable DTEndereco;
        DataTable DTTelefone;
        DataTable DTGrupo;
        DataTable DTR_Empresa;
        DataTable DTR_Orcamento;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        DataTable DTR_ItemOrcamento;

        int ID_Grade;
        public int ID_Temp;

        int obj;
        string DescricaoGrade;

        bool Edita_Item = false;

        List<DTO_Produto_Item> lst_Produto;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_TabelaValor TabelaValor;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Produto Produto;
        DTO_Usuario Usuario;
        DTO_Orcamento Orcamento;
        DTO_Produto_Item Produto_Item;
        DTO_CReceber CReceber;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "ORÇAMENTO";

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            if (Parametro_Venda.TipoSaida_Fixo == true)
            {
                cb_TipoVendaProduto.SelectedValue = 0;
                cb_TipoVendaProduto.Enabled = false;
            }

            #region MONTA GRID CONSULTA
            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 70;
            col_Data.DefaultCellStyle.Format = "d";
            DG.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "PESSOA";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Complemento = new DataGridViewTextBoxColumn();
            col_Complemento.DataPropertyName = "Complemento";
            col_Complemento.HeaderText = "COMPLEMENTO";
            col_Complemento.Width = 400;
            col_Complemento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Complemento);

            DataGridViewTextBoxColumn col_Valor = new DataGridViewTextBoxColumn();
            col_Valor.DataPropertyName = "ValorTotal";
            col_Valor.HeaderText = "VALOR";
            col_Valor.Width = 80;
            col_Valor.DefaultCellStyle.Format = "C2";
            col_Valor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Columns.Add(col_Valor);
            #endregion

            Limpa_Campos();
        }

        public void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DTUsuario = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(DTUsuario, "Descricao", "ID", cb_ID_UsuarioComissao1);

            DTGrupo = util_Param.Saida_Produto();
            util_dados.CarregaCombo(DTGrupo, "Descricao", "ID", cb_TipoVendaProduto);

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            DTTabelaValor = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(DTTabelaValor, "Descricao", "ID", cb_ID_Tabela);

            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 1;

            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;
        }

        public void CarregaProduto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";

            if (Parametro_Venda.Produto_Marca == true)
                Produto.ConsultaMarca = true;

            DTProduto = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(DTProduto, "Descricao", "ID", cb_ID_Produto);
        }

        private void Busca_Produto(int _ID)
        {
            txt_ValorUnitario.Text = "0,00";
            txt_ValorFinal.Text = "0,00";
            txt_Acrescimo.Text = "0,00";
            txt_Desconto.Text = "0,00";
            txt_Estoque.Text = string.Empty;

            try
            {
                BLL_Orcamento = new BLL_Orcamento();

                Produto = new DTO_Produto();
                Orcamento = new DTO_Orcamento();

                Produto.ID = _ID;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                Produto.Consulta_Tipo = true;
                Produto.Tipo = "1, 3, 5";

                DTProduto = BLL_Produto.Busca_Valor(Produto);

                if (DTProduto.Rows.Count > 0)
                {
                    DRProduto = DTProduto.Rows[0];

                    double Valor_Venda = 0;

                    Valor_Venda = Convert.ToDouble(DRProduto["ValorVenda"]);

                    txt_ValorUnitario.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DRProduto["ValorVenda"]), 2);
                    txt_ValorFinal.Text = util_dados.ConfigNumDecimal(Valor_Venda, 2);
                    txt_ValorCusto.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DRProduto["CustoFinal"]), 2);

                    if (Convert.ToDouble(txt_ValorFinal.Text) != Convert.ToDouble(txt_ValorUnitario.Text))
                        if (Convert.ToDouble(txt_ValorFinal.Text) > Convert.ToDouble(txt_ValorUnitario.Text))
                        {
                            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_ValorFinal.Text) - Convert.ToDouble(txt_ValorUnitario.Text), 2);
                            lb_Acrescimo.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Acrescimo.Text) * 100) / Convert.ToDouble(txt_ValorUnitario.Text), 2) + " %";
                        }
                        else if (Convert.ToDouble(txt_ValorFinal.Text) < Convert.ToDouble(txt_ValorUnitario.Text))
                        {
                            txt_Desconto.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_ValorUnitario.Text) - Convert.ToDouble(txt_ValorFinal.Text), 2);
                            lb_Desconto.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Desconto.Text) * 100) / Convert.ToDouble(txt_ValorUnitario.Text), 2) + " %";

                        }
                    Calcula_Item();

                    txt_Estoque.Text = string.Empty;

                    DataTable _DT = new DataTable();

                    _DT = BLL_Produto.Busca_Estoque(Produto);
                    if (_DT == null)
                        return;

                    if (_DT.Rows.Count == 1)
                    {
                        DR = _DT.Rows[0];
                        txt_Estoque.Text = DR["EstoqueAtual"].ToString();
                    }
                }
                else
                    MessageBox.Show(util_msg.msg_Produto_SemValor, this.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Busca_Pessoa(int _ID)
        {
            txt_CNPJ_CPF.Text = string.Empty;
            txt_Telefone.Text = string.Empty;
            txt_Logradouro.Text = string.Empty;
            txt_Numero.Text = string.Empty;
            txt_Bairro.Text = string.Empty;
            txt_Municipio_UF.Text = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = _ID;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DTPessoa = BLL_Pessoa.Busca(Pessoa);
            if (DTPessoa.Rows.Count > 0)
            {
                DRPessoa = DTPessoa.Rows[0];
                txt_CNPJ_CPF.Text = Convert.ToString(DRPessoa["CNPJ_CPF"]);
                txt_Informacao_Venda.Text = Convert.ToString(DRPessoa["Informacao_Venda"]);

                if (Parametro_Usuario.Venda_Fixa_logado == false)
                {
                    if (Convert.ToInt32(cb_TipoPessoa.SelectedValue) == 1)
                        if (Convert.ToInt32(DRPessoa["ID_Usuario"]) > 0)
                        {
                            cb_ID_UsuarioComissao1.Enabled = false;
                            cb_ID_UsuarioComissao1.SelectedValue = DRPessoa["ID_Usuario"];
                        }
                        else
                            cb_ID_UsuarioComissao1.Enabled = true;
                }
                else
                {
                    cb_ID_UsuarioComissao1.Enabled = false;
                    cb_ID_UsuarioComissao1.SelectedValue = Parametro_Usuario.ID_Usuario_Ativo;
                }
            }

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DTEndereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            if (DTEndereco.Rows.Count > 0)
            {
                DREndereco = DTEndereco.Rows[0];
                txt_Logradouro.Text = Convert.ToString(DREndereco["Logradouro"]);
                txt_Numero.Text = Convert.ToString(DREndereco["NumeroEndereco"]);
                txt_Bairro.Text = Convert.ToString(DREndereco["Bairro"]);
                txt_Municipio_UF.Text = Convert.ToString(DREndereco["Municipio_UF"]);
            }

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DTTelefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            if (DTTelefone.Rows.Count > 0)
            {
                DRTelefone = DTTelefone.Rows[0];
                txt_Telefone.Text = "(" + DRTelefone["DDD"] + ") " + DRTelefone["NumeroTelefone"];
            }
        }

        private void Busca_Item(int _ID)
        {
            BLL_Orcamento = new BLL_Orcamento();
            Orcamento = new DTO_Orcamento();

            if (_ID == 0)
                return;

            Orcamento.ID = _ID;
            DataTable _DT = new DataTable();
            _DT = BLL_Orcamento.Busca_Item(Orcamento);

            lst_Produto = new List<DTO_Produto_Item>();

            BLL_Orcamento = new BLL_Orcamento();
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
                Produto_Item.ID_Grade = (int)_DT.Rows[i]["ID_Grade"];

                lst_Produto.Add(Produto_Item);
            }
            if (lst_Produto.Count > 0)
                Carrega_Item(lst_Produto);
            else
                dg_Itens.Rows.Clear();
        }

        public void CarregaPessoa(int _Tipo)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                switch (_Tipo)
                {
                    case 1: //Tab Principal
                        if (util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString()) == 0)
                            return;

                        cb_ID_Pessoa.DataSource = null;

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Pessoa.FiltraSituacao = true;
                        Pessoa.Situacao = true;

                        DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                        cb_ID_Pessoa.SelectedIndex = -1;

                        txt_CNPJ_CPF.Text = string.Empty;
                        txt_Telefone.Text = string.Empty;
                        txt_Logradouro.Text = string.Empty;
                        txt_Numero.Text = string.Empty;
                        txt_Bairro.Text = string.Empty;
                        txt_Municipio_UF.Text = string.Empty;
                        break;

                    case 2://Tab Pesquisa Orcamento
                        if (util_dados.Verifica_int(cb_TipoPessoaP.SelectedValue.ToString()) == 0)
                            return;

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_PessoaP);
                        cb_ID_PessoaP.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        public void SomaItens()
        {
            try
            {
                if (dg_Itens.Rows.Count > 0)
                {
                    double TotalDesconto = 0;
                    double TotalAcrescimo = 0; ;
                    double TotalCustoFinal = 0; ;
                    double TotalValorMinimo = 0; ;
                    double Total = 0; ;
                    double TotalValor = 0; ;

                    for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                    {
                        TotalDesconto += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Desconto"].Value);
                        TotalAcrescimo += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Acrescimo"].Value);
                        TotalCustoFinal += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_CustoFinal"].Value);
                        TotalValorMinimo += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_ValorMinimo"].Value);
                        Total += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_ValorTotal"].Value);
                        TotalValor += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Valor"].Value);
                    }
                    txt_ValorOrcamento.Text = util_dados.ConfigNumDecimal(Total, 2);
                }
                else
                {
                    txt_ValorOrcamento.Text = "0,00";
                }
            }
            catch (Exception)
            {
            }
        }

        public void SomaOrcamento()
        {
            if (dg_Itens.Rows.Count > 0)
            {/*
                if (Rotinas.CalculaLucroReal(Convert.ToDecimal(Rotinas.CalculaValorQuantidade(DTItemOrcamento, "ValorMinimo", "Quantidade")), Convert.ToDecimal(txt_ValorOrcamento.Text)) < Convert.ToDecimal(MargemMinima))
                {
                    lb_Situacao.Text = "Bloqueado";
                    lb_Situacao.ForeColor = Color.Red;
                }
                else if (Rotinas.CalculaLucroReal(Convert.ToDecimal(Rotinas.CalculaValorQuantidade(DTItemOrcamento, "ValorMinimo", "Quantidade")), Convert.ToDecimal(txt_ValorOrcamento.Text)) > Convert.ToDecimal(MargemMinima))
                {
                    lb_Situacao.Text = "Liberado";
                    lb_Situacao.ForeColor = Color.Green;
                }
                */
            }
            CalculaMargens();
        }

        public void Calcula_Item()
        {
            try
            {
                double Quantidade = Convert.ToDouble(txt_Quantidade.Text);

                double ValorUnitario = Convert.ToDouble(txt_ValorUnitario.Text);
                double Desconto = Convert.ToDouble(txt_Desconto.Text);
                double Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);

                double SubValor = (ValorUnitario + Acrescimo) - Desconto;

                txt_ValorFinal.Text = util_dados.ConfigNumDecimal(SubValor, 2);
                txt_ValorTotal.Text = util_dados.ConfigNumDecimal(SubValor * Quantidade, 2);
            }
            catch (Exception)
            {
            }
        }

        public void CalculaMargens()
        {
            try
            {
                if (dg_Itens.Rows.Count > 0)
                {
                    // txt_MargemReal.Text = ConfigNumDecimal(CalculaLucroReal(txt_CustoTotal.Text, txt_ValorOrcamento.Text), 3)
                    // lb_Margem.Text = Rotinas.ConfigNumDecimal((Convert.ToDecimal(txt_ValorOrcamento.Text) / Rotinas.CalculaValorQuantidade(DTItemOrcamento, "ValorMinimo", "Quantidade") - 1) * 100, 3);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Limpa_Campos()
        {
            DG.DataSource = null;

            txt_ValorUnitario.Text = "0,00";
            txt_Quantidade.Text = "1,000";
            txt_ValorFinal.Text = "0,00";
            txt_Acrescimo.Text = "0,00";
            txt_Desconto.Text = "0,00";

            lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;

            mk_Data.Text = DateTime.Now.ToString();

            if (Parametro_Usuario.Venda_Restrita == true)
            {
                cb_TipoPessoa.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
                cb_TipoPessoa.Enabled = false;
                cb_TipoPessoaP.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
                cb_TipoPessoaP.Enabled = false;
            }
            else
            {
                cb_TipoPessoa.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
                cb_TipoPessoa.Enabled = true;
                cb_TipoPessoaP.Enabled = true;
            }

            dg_Itens.Rows.Clear();
            lst_Produto = new List<DTO_Produto_Item>();

            cb_ID_Tabela.SelectedIndex = 0;
            cb_TipoVendaProduto.SelectedValue = 0;

            cb_ID_Pessoa.SelectedValue = Parametro_Venda.ID_ConsumidorFinal;

            cb_ID_Pessoa.Focus();
        }

        private void Carrega_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens.Rows.Clear();
            double SubTotal = 0;
            double TotalDesconto = 0;
            double Quantidade = 0;


            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;

                if (Parametro_Venda.Desconto_Padrao == 1)
                    dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                else
                    dg_Itens.Rows[i].Cells["col_Desconto"].Value = util_dados.ConfigNumDecimal(util_dados.Verifica_Porcentagem(_lst_Produto[i].ValorProduto, _lst_Produto[i].ValorVenda), 2) + "%";

                dg_Itens.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorProduto;
                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
                dg_Itens.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
                dg_Itens.Rows[i].Cells["col_TipoSaida"].Value = _lst_Produto[i].Descricao_Saida;
                dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

                SubTotal += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorProduto + _lst_Produto[i].Acrescimo);
                TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
                Quantidade += _lst_Produto[i].Quantidade;
            }

            dg_Itens.RefreshEdit();

            if (dg_Itens.Rows.Count > 0)
            {
                dg_Itens.Rows[dg_Itens.Rows.Count - 1].Selected = true;
                dg_Itens.FirstDisplayedScrollingRowIndex = dg_Itens.Rows.Count - 1;
            }

            txt_SubTotal.Text = util_dados.ConfigNumDecimal(SubTotal, 2);
            txt_TotalDesconto.Text = util_dados.ConfigNumDecimal(TotalDesconto, 2);
            txt_ValorOrcamento.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + util_dados.ConfigNumDecimal(Quantidade, 3);
            lb_DescontoTotal.Text = util_msg.msg_Desconto_Total + util_dados.ConfigNumDecimal(util_dados.Verifica_Porcentagem(SubTotal, SubTotal - TotalDesconto), 2) + " %";
        }

        private void Consulta_Produto()
        {
            ID_Grade = 0;

            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = frm.ID_Produto;
            ID_Grade = frm.ID_Grade;
            txt_ID_Produto.Text = frm.ID_Produto.ToString();

            txt_Quantidade.Focus();
        }

        private void Consulta_Pessoa()
        {
            if (tabctl.SelectedTab == TabPage1)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                if (Parametro_Usuario.Venda_Restrita == true)
                    UI_Pessoa_Consulta.Usuario_Restrito = true;

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.NovoCadastro == true)
                {
                    bool aux = false;
                    foreach (Form Frm in this.MdiParent.MdiChildren)
                    {
                        if (Frm is UI_Pessoa)
                        {
                            DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msgbox == DialogResult.No)
                            {
                                Frm.BringToFront();
                                aux = true;
                                return;
                            }
                            Frm.Close();
                            aux = false;
                        }
                    }
                    if (aux == false)
                    {
                        UI_Pessoa UI_Pessoa = new UI_Pessoa();

                        UI_Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        util_dados.CarregaForm(UI_Pessoa, this.MdiParent);

                        return;
                    }
                }

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                if (Parametro_Usuario.Venda_Restrita == true &&
                UI_Pessoa_Consulta.TipoPessoa != 1)
                    return;

                cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(Convert.ToInt32(cb_TipoPessoa.SelectedValue));

                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                txt_ID_Pessoa.Text = UI_Pessoa_Consulta.ID_Pessoa.ToString();

                cb_TipoVendaProduto.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.OcultaNovoCadastro = true;
                UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

                if (Parametro_Usuario.Venda_Restrita == true)
                    UI_Pessoa_Consulta.Usuario_Restrito = true;

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                if (Parametro_Usuario.Venda_Restrita == true &&
                UI_Pessoa_Consulta.TipoPessoa != 1)
                    return;

                cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(2);
                cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_PessoaP.Focus();
            }
        }

        private void Verifica_Desconto()
        {
            Calcula_Item();

            #region VERIFICA DESCONTO ATACADO
            double _Qtd_aux = Convert.ToDouble(txt_Quantidade.Text);

            for (int i = 0; i <= lst_Produto.Count - 1; i++)
            {
                if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue))
                    _Qtd_aux += lst_Produto[i].Quantidade;
            }

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Quantidade = _Qtd_aux;
            Produto.Consulta_Quantidade = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Desconto(Produto);

            if (_DT.Rows.Count > 0)
            {
                txt_Desconto.Text = util_dados.Calcula_Desc_Acres(_DT.Rows[0]["Desconto"] + "%", txt_ValorUnitario.Text);
                return;
            }
            #endregion

            #region VERIFICA DESCONTO PERSONALIZADO POR CLIENTE

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            Produto.ID_Pessoa = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());

            _DT = new DataTable();
            _DT = BLL_Produto.Busca_Desconto_Pessoa(Produto);

            if (_DT.Rows.Count > 0)
            {
                if (util_dados.Verifica_int(_DT.Rows[0]["Tipo"].ToString()) == 1)
                    txt_Desconto.Text = util_dados.ConfigNumDecimal(_DT.Rows[0]["Desconto"], 2);

                if (util_dados.Verifica_int(_DT.Rows[0]["Tipo"].ToString()) == 2)
                    txt_Desconto.Text = util_dados.Calcula_Desc_Acres(_DT.Rows[0]["Desconto"] + "%", txt_ValorUnitario.Text);
            }
            #endregion
        }

        private void Verifica_CReceber(int _ID)
        {
            if (Parametro_Venda.DiasBloqueioVenda == 0 ||
                util_dados.Verifica_int(txt_ID.Text) > 0)
                return;

            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.Situacao = 1;
            CReceber.Vencimento = DateTime.Now.AddDays(Parametro_Venda.DiasBloqueioVenda * -1).Date;
            CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CReceber.ID_Pessoa = _ID;

            DataTable _DT = new DataTable();
            _DT = BLL_CReceber.Busca_ContaAtraso(CReceber);

            if (_DT.Rows.Count > 0)
                MessageBox.Show(string.Format(util_msg.msg_CReceberEmAberto, Parametro_Venda.DiasBloqueioVenda), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                if (tabctl.SelectedTab == TabPage2)
                {
                    BLL_Orcamento = new BLL_Orcamento();
                    Orcamento = new DTO_Orcamento();

                    Orcamento.ID = util_dados.Verifica_int(txt_IDP.Text);
                    Orcamento.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Orcamento.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                    Orcamento.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

                    if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                           mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                    {
                        Orcamento.Consulta_Emissao.Filtra = true;
                        Orcamento.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Orcamento.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }

                    DataTable _DT = new DataTable();
                    _DT = BLL_Orcamento.Busca(Orcamento);

                    DG.DataSource = _DT;
                    util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                    util_dados.CarregaCampo(this, _DT, gb_Pessoa);
                    DG.Focus();
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
                if (Parametro_Venda.Limite_Desconto > 0 &&
                    Parametro_Usuario.Libera_Desconto == false &&
                  util_dados.Verifica_Porcentagem(Convert.ToDouble(txt_SubTotal.Text), Convert.ToDouble(txt_ValorOrcamento.Text)) > Parametro_Venda.Limite_Desconto)
                {
                    UI_Senha_Supervidor UI_Senha_Supervidor = new UI_Senha_Supervidor();
                    UI_Senha_Supervidor.DescricaoLiberacao = "LIBERAÇÃO DE DESCONTO";
                    UI_Senha_Supervidor.Tipo = 1;
                    UI_Senha_Supervidor.ShowDialog();

                    if (UI_Senha_Supervidor.Liberado == false)
                    {
                        MessageBox.Show(util_msg.msg_Senha_Incorreta, this.Text);
                        return;
                    }
                }

                BLL_Orcamento = new BLL_Orcamento();
                Orcamento = new DTO_Orcamento();

                Orcamento.Item = lst_Produto;

                Orcamento.ID = util_dados.Verifica_int(txt_ID.Text);
                Orcamento.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Orcamento.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Orcamento.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Orcamento.Data = Convert.ToDateTime(mk_Data.Text);

                Orcamento.Informacao = txt_informacao.Text;
                Orcamento.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);
                Orcamento.Situacao = 1;

                obj = BLL_Orcamento.Grava(Orcamento);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();

                    Busca_Item(obj);

                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Pessoa);
            util_dados.LimpaCampos(this, gb_Itens);

            ExibeRegistro();
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Orcamento = new BLL_Orcamento();
                Orcamento = new DTO_Orcamento();

                Orcamento.ID = util_dados.Verifica_int(txt_ID.Text);

                Orcamento.Item = lst_Produto;

                BLL_Orcamento.Exclui(Orcamento);

                Novo();
                Limpa_Campos();

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Imprimir()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
            {
                MessageBox.Show("Nenhum Orçamento Selecionado!");
                return;
            }
            LocalReport rpt = new LocalReport();
            string rpt_Nome = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Orcamento = new BLL_Orcamento();
            Orcamento = new DTO_Orcamento();

            Orcamento.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_Orcamento = BLL_Orcamento.Busca_Relatorio(Orcamento);
            DTR_ItemOrcamento = BLL_Orcamento.Busca_Item(Orcamento);

            string Financeiro = string.Empty;

            if (DTR_ItemOrcamento.Rows.Count <= 11 &&
                Parametro_Venda.Permitir2Vias == true)
            {
                rpt_Nome = "rpt_Orcamento2.rdlc";

                for (int i = DTR_ItemOrcamento.Rows.Count; i <= 11; i++)
                {
                    DTR_ItemOrcamento.Rows.Add();
                    DTR_ItemOrcamento.Rows[i]["DescricaoProduto"] = "";
                    DTR_ItemOrcamento.Rows[i]["ValorVenda"] = 0;
                    DTR_ItemOrcamento.Rows[i]["Quantidade"] = 0;
                    DTR_ItemOrcamento.Rows[i]["Desconto"] = 0;
                    DTR_ItemOrcamento.Rows[i]["Acrescimo"] = 0;
                    DTR_ItemOrcamento.AcceptChanges();
                }
            }
            else
                rpt_Nome = "rpt_Orcamento.rdlc";


            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            Email.Principal = true;
            Pessoa.Email.Add(Email);
            DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Orcamento = new ReportDataSource("ds_Venda_Orcamento", DTR_Orcamento);
            ReportDataSource ds_ItemOrcamento = new ReportDataSource("ds_Item_Orcamento", DTR_ItemOrcamento);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("Vendedor", cb_ID_UsuarioComissao1.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Orcamento);
            rpt.DataSources.Add(ds_ItemOrcamento);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);

            rpt.SetParameters(new ReportParameter[] { p1 });

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                //Impressora = EscolheImpressora.PrinterSettings.PrinterName;

                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;
            }
        }

        public override void Visualizar()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
            {
                MessageBox.Show("Nenhum Orçamento Selecionado!");
                return;
            }
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "";

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Orcamento = new BLL_Orcamento();
            Orcamento = new DTO_Orcamento();

            Orcamento.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_Orcamento = BLL_Orcamento.Busca_Relatorio(Orcamento);
            DTR_ItemOrcamento = BLL_Orcamento.Busca_Item(Orcamento);

            string Financeiro = string.Empty;
            string TipoPagto = string.Empty;

            DialogResult msgbox = DialogResult.Yes;

            if (Parametro_Venda.TipoImpressoraTermica == 1)
            {
                msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressaoA4, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    rpt_Nome = "rpt_Orcamento_Termica.rdlc";

                if (msgbox == DialogResult.Yes)
                {
                    if (DTR_ItemOrcamento.Rows.Count <= 11 &&
                        Parametro_Venda.Permitir2Vias == true)
                    {
                        rpt_Nome = "rpt_Orcamento2.rdlc";
                        for (int i = DTR_ItemOrcamento.Rows.Count; i <= 11; i++)
                        {
                            DTR_ItemOrcamento.Rows.Add();
                            DTR_ItemOrcamento.Rows[i]["DescricaoProduto"] = "";
                            DTR_ItemOrcamento.Rows[i]["ValorVenda"] = 0;
                            DTR_ItemOrcamento.Rows[i]["Quantidade"] = 0;
                            DTR_ItemOrcamento.Rows[i]["Desconto"] = 0;
                            DTR_ItemOrcamento.Rows[i]["Acrescimo"] = 0;
                            DTR_ItemOrcamento.AcceptChanges();
                        }
                    }
                    else
                        rpt_Nome = "rpt_Orcamento.rdlc";
                }
            }
            else
            {
                if (DTR_ItemOrcamento.Rows.Count <= 11 &&
                       Parametro_Venda.Permitir2Vias == true)
                {
                    rpt_Nome = "rpt_Orcamento2.rdlc";
                    for (int i = DTR_ItemOrcamento.Rows.Count; i <= 11; i++)
                    {
                        DTR_ItemOrcamento.Rows.Add();
                        DTR_ItemOrcamento.Rows[i]["DescricaoProduto"] = "";
                        DTR_ItemOrcamento.Rows[i]["ValorVenda"] = 0;
                        DTR_ItemOrcamento.Rows[i]["Quantidade"] = 0;
                        DTR_ItemOrcamento.Rows[i]["Desconto"] = 0;
                        DTR_ItemOrcamento.Rows[i]["Acrescimo"] = 0;
                        DTR_ItemOrcamento.AcceptChanges();
                    }
                }
                else
                    rpt_Nome = "rpt_Orcamento.rdlc";
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            Email.Principal = true;
            Pessoa.Email.Add(Email);
            DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Orcamento = new ReportDataSource("ds_Venda_Orcamento", DTR_Orcamento);
            ReportDataSource ds_ItemOrcamento = new ReportDataSource("ds_Item_Orcamento", DTR_ItemOrcamento);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("Vendedor", cb_ID_UsuarioComissao1.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Orcamento);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemOrcamento);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            frm_rpt.rpt_Viewer.RefreshReport();

            if (Parametro_Venda.Orca_ValorTotal == true)
            {
                frm_rpt = new UI_Visualiza_Relatorio();
                frm_rpt.Show();

                if (msgbox == DialogResult.No)
                    rpt_Nome = "rpt_Orcamento_Termica_vlrTotal.rdlc";
                else
                {
                    if (DTR_ItemOrcamento.Rows.Count == 12 &&
                        Parametro_Venda.Permitir2Vias == true)
                        rpt_Nome = "rpt_Orcamento2_vlrTotal.rdlc";
                    else
                        rpt_Nome = "rpt_Orcamento_vlrTotal.rdlc";
                }

                Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Orcamento);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemOrcamento);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

                frm_rpt.rpt_Viewer.RefreshReport();
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Acrescimo.Focused == true ||
                txt_Desconto.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimalPorcentagem(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_ValorFinal.Focused == true ||
             txt_Quantidade.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Venda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();

            if (e.KeyCode == Keys.F10 &&
              tabctl.SelectedTab == TabPage1)
                Consulta_Produto();

            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }

        private void UI_Venda_Load(object sender, EventArgs e)
        {
            dg_Itens.AutoGenerateColumns = false;

            dg_Itens.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            bt_Imprime.Visible = true;
            CarregaCB();
            CarregaProduto();

            Novo();
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Consulta_Pessoa();
        }

        private void bt_PesquisaProduto_Click(object sender, EventArgs e)
        {
            Consulta_Produto();
        }

        private void bt_AdicionaProduto_Click(object sender, EventArgs e)
        {
            if (cb_ID_Produto.SelectedValue != null)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);

                List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();

                if (ID_Grade > 0)
                    Produto.ID_Grade = ID_Grade;

                DataTable _DT = new DataTable();


                _DT = BLL_Produto.Busca_Estoque(Produto);
                if (_DT == null)
                {
                    MessageBox.Show("Estoque não cadastrado!");
                    return;
                }

                int TipoProduto = Convert.ToInt32(_DT.Rows[0]["Tipo"]);

                if (_DT.Rows.Count == 1 ||
                    ID_Grade > 0)
                {
                    DR = _DT.Rows[0];
                    ID_Grade = Convert.ToInt32(DR["ID_Grade"]);

                    if (Convert.ToString(DR["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                        DescricaoGrade = " - " + Convert.ToString(DR["DescricaoGrade"]);
                    else
                        DescricaoGrade = string.Empty;

                    if (Parametro_Venda.Bloquear_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                {
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                                    return;
                                }

                    if (Parametro_Venda.msg_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                }
                else
                {
                    UI_Produto_Consulta_Grade frm = new UI_Produto_Consulta_Grade();
                    frm.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                    frm.Descricao = cb_ID_Produto.Text;

                    frm.ShowDialog();

                    lst_Grade = new List<DTO_Produto_Item>();
                    lst_Grade = frm.lst_Produto;

                    if (lst_Grade == null)
                    {
                        MessageBox.Show("Selecione uma Grade!");
                        return;
                    }

                    if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Unico)
                    {
                        ID_Grade = lst_Grade[0].ID_Grade;
                        DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;
                    }

                    if (Parametro_Venda.Bloquear_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                {
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                                    return;
                                }

                    if (Parametro_Venda.msg_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);

                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                            lst_Produto[i].Descricao_Saida == cb_TipoVendaProduto.Text &&
                           lst_Produto[i].ID_Grade == ID_Grade &&
                            TipoProduto != 3)
                        {
                            if (lst_Grade.Count == 1)
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + lst_Grade[0].Quantidade;
                            else
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);

                            Carrega_Item(lst_Produto);

                            ID_Grade = 0;
                            cb_ID_Produto.SelectedIndex = -1;
                            txt_Quantidade.Text = "1,000";
                            cb_ID_Produto.Focus();
                            return;
                        }
                }
                if (Convert.ToInt32(cb_TipoVendaProduto.SelectedValue) != 0)
                {
                    txt_ValorFinal.Text = "0,00";
                    txt_ValorTotal.Text = "0,00";
                    txt_ValorUnitario.Text = "0,00";
                    txt_Acrescimo.Text = "0,00";
                    txt_Desconto.Text = "0,00";
                }

                if (Parametro_Venda.Agrupar_Produto == true)
                {
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                            lst_Produto[i].Descricao_Saida == cb_TipoVendaProduto.Text &&
                            lst_Produto[i].ID_Grade == ID_Grade)
                        {
                            if (Edita_Item == true)
                            {
                                Edita_Item = false;
                                lst_Produto[i].Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                            }
                            else
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);

                            lst_Produto[i].ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                            lst_Produto[i].Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                            lst_Produto[i].Desconto = Convert.ToDouble(txt_Desconto.Text);
                            lst_Produto[i].Informacao = txt_InformacaoItem.Text;

                            Carrega_Item(lst_Produto);

                            ID_Grade = 0;
                            cb_ID_Produto.SelectedIndex = -1;
                            txt_Quantidade.Text = "1,000";
                            cb_ID_Produto.Focus();
                            return;
                        }
                }

                if (lst_Produto == null)
                    lst_Produto = new List<DTO_Produto_Item>();

                BLL_Orcamento = new BLL_Orcamento();
                Produto_Item = new DTO_Produto_Item();

                if (ID_Grade == 0 &&
                    lst_Grade.Count > 0)
                {
                    for (int i = 0; i < lst_Grade.Count; i++)
                    {
                        bool _Novo = true;
                        for (int ii = 0; ii <= lst_Produto.Count - 1; ii++)
                        {
                            if (lst_Produto[ii].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                                lst_Produto[ii].ID_Grade == lst_Grade[i].ID_Grade)
                            {
                                lst_Produto[ii].Quantidade = lst_Produto[ii].Quantidade + lst_Grade[i].Quantidade;
                                _Novo = false;
                            }
                        }
                        if (_Novo == true)
                        {
                            Produto_Item = new DTO_Produto_Item();

                            Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                            Produto_Item.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                            Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                            Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                            Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                            Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                            Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                            Produto_Item.Descricao_Saida = cb_TipoVendaProduto.Text;
                            Produto_Item.TipoSaida = Convert.ToInt32(cb_TipoVendaProduto.SelectedValue);
                            Produto_Item.Descricao_Produto = cb_ID_Produto.Text + " - " + lst_Grade[i].DescricaoGrade;
                            Produto_Item.Informacao = lst_Grade[i].Informacao;
                            Produto_Item.ID_Grade = lst_Grade[i].ID_Grade;
                            Produto_Item.Quantidade = lst_Grade[i].Quantidade;

                            //VALIDA INFORMAÇÕES
                            if (!BLL_Orcamento.Grava_Item(Produto_Item))
                                return;

                            //ADICIONA A LISTA
                            lst_Produto.Add(Produto_Item);
                        }
                    }
                }
                else
                {
                    Produto_Item = new DTO_Produto_Item();

                    Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                    Produto_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                    Produto_Item.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                    Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                    Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                    Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                    Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                    Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                    Produto_Item.Descricao_Saida = cb_TipoVendaProduto.Text;
                    Produto_Item.TipoSaida = Convert.ToInt32(cb_TipoVendaProduto.SelectedValue);
                    Produto_Item.Descricao_Produto = cb_ID_Produto.Text + DescricaoGrade;
                    Produto_Item.Informacao = txt_InformacaoItem.Text;
                    Produto_Item.ID_Grade = ID_Grade;

                    //VALIDA INFORMAÇÕES
                    if (!BLL_Orcamento.Grava_Item(Produto_Item))
                        return;

                    //ADICIONA A LISTA
                    lst_Produto.Add(Produto_Item);
                }

                Carrega_Item(lst_Produto);
                ID_Grade = 0;
                cb_ID_Produto.SelectedIndex = -1;
                txt_Quantidade.Text = "1,000";
                cb_ID_Produto.Focus();
            }
        }

        private void bt_ExcluiProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_Itens.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (util_dados.Verifica_int(txt_ID.Text) > 0 &&
                    lst_Produto[dg_Itens.CurrentRow.Index].ID > 0)
                {
                    BLL_Orcamento = new BLL_Orcamento();
                    Orcamento = new DTO_Orcamento();
                    Produto_Item = new DTO_Produto_Item();
                    List<DTO_Produto_Item> _Item = new List<DTO_Produto_Item>();

                    Produto_Item.ID = lst_Produto[dg_Itens.CurrentRow.Index].ID;
                    Produto_Item.ID_Produto = lst_Produto[dg_Itens.CurrentRow.Index].ID_Produto;
                    Produto_Item.ID_Grade = lst_Produto[dg_Itens.CurrentRow.Index].ID_Grade;

                    _Item.Add(Produto_Item);

                    Orcamento.Item = _Item;

                    BLL_Orcamento.Exclui_Item(Orcamento);

                    Busca_Item(Convert.ToInt32(txt_ID.Text));
                }
                else
                {
                    lst_Produto.RemoveAt(dg_Itens.CurrentRow.Index);

                    Carrega_Item(lst_Produto);
                }
            }
            catch (Exception)
            {
            }
            SomaItens();
            SomaOrcamento();

            // if (ck_Barras.Checked == true)
            //   txt_Barra.Focus();
            // else
            cb_ID_Produto.Focus();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campos();
        }

        private void bt_Edita_Produto_Click(object sender, EventArgs e)
        {
            cb_ID_Tabela.SelectedValue = lst_Produto[dg_Itens.CurrentRow.Index].ID_Tabela;
            cb_ID_Produto.SelectedValue = lst_Produto[dg_Itens.CurrentRow.Index].ID_Produto;
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Quantidade, 3);
            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Acrescimo, 2);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Desconto, 2);
            txt_InformacaoItem.Text = lst_Produto[dg_Itens.CurrentRow.Index].Informacao;

            Calcula_Item();
        }

        private void bt_GerarPedido_Click(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            UI_Venda frm = new UI_Venda();
            frm.Tipo = 1;
            frm.ID_Orcamento = Convert.ToInt32(txt_ID.Text);

            util_dados.CarregaForm(frm, this.ParentForm);
            this.Close();
        }

        private void bt_ExibeResumo_Click(object sender, EventArgs e)
        {
            UI_Senha_Supervidor UI_Senha_Supervidor = new UI_Senha_Supervidor();
            UI_Senha_Supervidor.DescricaoLiberacao = "EXIBIR RESUMO VENDA";
            UI_Senha_Supervidor.Tipo = 2;
            UI_Senha_Supervidor.ShowDialog();

            if (UI_Senha_Supervidor.Liberado == false)
                return;

            UI_Venda_Resumo UI_Venda_Resumo = new UI_Venda_Resumo();
            UI_Venda_Resumo._lst_Produto = lst_Produto;
            UI_Venda_Resumo.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            UI_Venda_Resumo.ID_Pessoa = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());

            UI_Venda_Resumo.Show();
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(1);
        }

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(2);
        }

        private void cb_ID_Pessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Pessoa.Text.Trim() != string.Empty)
                    if (cb_ID_Pessoa.SelectedValue.GetType() == typeof(int) &&
                        Convert.ToInt32(cb_ID_Pessoa.SelectedValue) > 0)
                        Busca_Pessoa(Convert.ToInt32(cb_ID_Pessoa.SelectedValue));
            }
            catch (Exception)
            {
                //  txt_ID_Produto.Text = "0";
            }
        }

        private void cb_ID_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Produto.SelectedIndex = -1;
        }

        private void cb_ID_Produto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Produto.Focused == true)
                    if (cb_ID_Produto.SelectedValue.GetType() == typeof(int) && Convert.ToInt32(cb_ID_Produto.SelectedValue) > 0)
                        Busca_Produto(Convert.ToInt32(cb_ID_Produto.SelectedValue));
            }
            catch (Exception)
            {
            }
        }

        private void cb_ID_Produto_Leave(object sender, EventArgs e)
        {
            Verifica_Desconto();
        }

        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Pessoa.SelectedValue != null &&
            Convert.ToInt32(cb_ID_Pessoa.SelectedValue) != Parametro_Venda.ID_ConsumidorFinal)
                Verifica_CReceber(util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString()));

            if (txt_Informacao_Venda.Text.Trim() != string.Empty)
                MessageBox.Show("ATENÇÃO\n" + DRPessoa["Informacao_Venda"].ToString(), this.Text);
        }
        #endregion

        #region TEXTBOX
        private void txt_ValorFinal_Leave(object sender, EventArgs e)
        {
            txt_Acrescimo.Text = "0,00";
            txt_Desconto.Text = "0,00";
            lb_Acrescimo.Text = "0,00 %";
            lb_Desconto.Text = "0,00 %";

            if (util_dados.Verifica_Double(txt_ValorFinal.Text) == 0)
                txt_ValorFinal.Text = txt_ValorUnitario.Text;

            if (Convert.ToDouble(txt_ValorFinal.Text) != Convert.ToDouble(txt_ValorUnitario.Text))
                if (Convert.ToDouble(txt_ValorFinal.Text) > Convert.ToDouble(txt_ValorUnitario.Text))
                {
                    txt_Acrescimo.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_ValorFinal.Text) - Convert.ToDouble(txt_ValorUnitario.Text), 2);
                    lb_Acrescimo.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Acrescimo.Text) * 100) / Convert.ToDouble(txt_ValorUnitario.Text), 2) + " %";
                }
                else if (Convert.ToDouble(txt_ValorFinal.Text) < Convert.ToDouble(txt_ValorUnitario.Text))
                {
                    txt_Desconto.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_ValorUnitario.Text) - Convert.ToDouble(txt_ValorFinal.Text), 2);
                    lb_Desconto.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Desconto.Text) * 100) / Convert.ToDouble(txt_ValorUnitario.Text), 2) + " %";

                }
            Calcula_Item();
        }

        private void txt_Quantidade_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Quantidade.Text) == 0)
                txt_Quantidade.Text = "1,000";

            txt_Quantidade.Text = util_dados.ConfigNumDecimal(txt_Quantidade.Text, 3);

            Verifica_Desconto();
        }

        private void txt_Acrescimo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cb_ID_Produto.SelectedValue) > 0)
            {
                txt_Acrescimo.Text = util_dados.Calcula_Desc_Acres(txt_Acrescimo.Text, txt_ValorUnitario.Text);
                txt_Acrescimo.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Acrescimo.Text.Replace("%", "").ToUpper().Replace("P", "")), 2);

                lb_Acrescimo.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Acrescimo.Text) * 100) / Convert.ToDouble(txt_ValorUnitario.Text), 2) + " %";
                txt_Acrescimo.Text = util_dados.ConfigNumDecimal(txt_Acrescimo.Text, 2);

                Calcula_Item();
            }
        }

        private void txt_Desconto_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cb_ID_Produto.SelectedValue) > 0)
            {
                txt_Desconto.Text = util_dados.Calcula_Desc_Acres(txt_Desconto.Text, txt_ValorUnitario.Text);
                txt_Desconto.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Desconto.Text), 2);

                lb_Desconto.Text = util_dados.ConfigNumDecimal((Convert.ToDecimal(txt_Desconto.Text) * 100) / Convert.ToDecimal(txt_ValorUnitario.Text), 2) + " %";
                txt_Desconto.Text = util_dados.ConfigNumDecimal(txt_Desconto.Text, 2);

                Calcula_Item();
            }
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Busca_Item(util_dados.Verifica_int(txt_ID.Text));
            Config(StatusForm.Consulta);
        }

        private void txt_TotalDesconto_Leave(object sender, EventArgs e)
        {
            if (txt_TotalDesconto.Text.IndexOf('%') != -1 ||
             txt_TotalDesconto.Text.ToUpper().IndexOf("P") != -1 ||
             Parametro_Venda.Desconto_Padrao == 2)
            {
                double Desconto = 0;
                double Porc_Desconto = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(txt_TotalDesconto.Text.ToUpper().Replace("%", "").Replace("P", ""), 2));

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    double aux = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(lst_Produto[i].ValorProduto * (Porc_Desconto / 100), 2));

                    lst_Produto[i].Desconto = aux;
                    lst_Produto[i].ValorVenda = util_dados.Verifica_Double(util_dados.ConfigNumDecimal((lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo) - lst_Produto[i].Desconto, 2));
                    lst_Produto[i].ValorTotal = lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;

                    Desconto += lst_Produto[i].Quantidade * lst_Produto[i].Desconto;
                }

                txt_TotalDesconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);
            }
            else
            {
                double TotalVenda = 0;
                double TotalVenda_Temp = 0;
                double Porc_Desconto = 0;
                double Desconto = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(txt_TotalDesconto.Text, 2));

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                    TotalVenda += lst_Produto[i].Quantidade * (lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo);

                Porc_Desconto = (Desconto / TotalVenda) * 100;

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    double aux = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(lst_Produto[i].ValorProduto * (Convert.ToDouble(Porc_Desconto) / 100), 2));

                    lst_Produto[i].Desconto = aux;
                    lst_Produto[i].ValorVenda = util_dados.Verifica_Double(util_dados.ConfigNumDecimal((lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo) - lst_Produto[i].Desconto, 2));
                    lst_Produto[i].ValorTotal = lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;
                }

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                    TotalVenda_Temp += Convert.ToDouble(util_dados.ConfigNumDecimal(lst_Produto[i].ValorTotal, 2));

                double Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(TotalVenda - TotalVenda_Temp, 2));

                if (Diferenca != Desconto)
                {
                    if (Diferenca > Desconto)
                    {
                        Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(Diferenca - Desconto, 2));
                        lst_Produto[0].Desconto = lst_Produto[0].Desconto - (Diferenca);
                    }
                    else
                    {
                        Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(Desconto - Diferenca, 2));
                        lst_Produto[0].Desconto = lst_Produto[0].Desconto + (Diferenca);
                    }

                    lst_Produto[0].ValorVenda = util_dados.Verifica_Double(util_dados.ConfigNumDecimal((lst_Produto[0].ValorProduto + lst_Produto[0].Acrescimo) - lst_Produto[0].Desconto, 2));
                    lst_Produto[0].ValorTotal = lst_Produto[0].Quantidade * lst_Produto[0].ValorVenda;
                }
                txt_TotalDesconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);
            }

            Carrega_Item(lst_Produto);
        }
        #endregion

        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, "DATA");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }
        }

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
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
            if (mk_DataFinal.Text.Replace(@"/", "").Trim() == string.Empty)
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

        #region DATAGRIDVIEW
        private void dg_Itens_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edita_Item = true;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = Convert.ToInt32(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ID_Produto"].Value);

            txt_Quantidade.Focus();
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_Quantidade"].Value, 3);
            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_Acrescimo"].Value, 2);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_Desconto"].Value, 2);
            txt_ValorFinal.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ValorFinal"].Value, 2);


        }
        #endregion       
    }
}

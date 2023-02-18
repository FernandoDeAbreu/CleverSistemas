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
    public partial class UI_Ordem_Servico_Monitor : Sistema.UI.UI_Modelo
    {
        public UI_Ordem_Servico_Monitor()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_GrupoNivel BLL_GrupoNivel;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_Pagamento BLL_Pagamento;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Usuario BLL_Usuario;
        BLL_OS BLL_OS;
        BLL_CReceber BLL_CReceber;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataRow DRPessoa;
        DataRow DREndereco;
        DataRow DRTelefone;
        DataRow DRProduto;
        DataTable DT;
        DataTable DTUsuario;
        DataTable DTTabelaValor;
        DataTable DTProduto;
        DataTable DTPessoa;
        DataTable DTEndereco;
        DataTable DTTelefone;
        DataTable DTGrupo;
        DataTable DTR_Empresa;
        DataTable DTR_OS;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        DataTable DTR_Item;
        DataTable DTR_Financeiro;

        int ID_Grade;

        int obj;
        string DescricaoGrade;

        List<DTO_Produto_Item> lst_Produto;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_GrupoNivel GrupoNivel;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_TabelaValor TabelaValor;
        DTO_Pagamento Pagamento;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Usuario Usuario;
        DTO_OS OS;
        DTO_Produto_Item Produto_Item;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        DTO_Parametro Parametro;
        DTO_CReceber CReceber;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "MONITOR ORDEM DE SERVIÇO";

            tabctl.TabPages.Remove(TabPage2);

            tabctl.SelectedTab = tabPage3;

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            gb_Pessoa.Enabled = false;
            cb_TipoAtendimento.Enabled = false;
            cb_Tipo_Equipamento.Enabled = false;
            cb_Marca.Enabled = false;
            ck_Garantia.Enabled = false;
            txt_Reclamacao.ReadOnly = true;

            bt_GerarNFCE.Visible = false;
            bt_NotaFiscal.Visible = false;
            bt_EncerrarOS.Visible = false;

            ck_Faturado.Visible = false;
            ck_NFe.Visible = false;
            ck_Garantia.Visible = false;
            ck_Cancelado.Visible = false;

            txt_Desconto.ReadOnly = true;
            txt_Acrescimo.ReadOnly = true;
            txt_ValorFinal.ReadOnly = true;

            lb_Info_Equip_1.Text = Parametro_OrdemServico.Descricao_Info1;
            lb_Info_Equip_2.Text = Parametro_OrdemServico.Descricao_Info2;
            lb_Info_Equip_3.Text = Parametro_OrdemServico.Descricao_Info3;

            lb_Info_Equip_1P.Text = Parametro_OrdemServico.Descricao_Info1;
            lb_Info_Equip_2P.Text = Parametro_OrdemServico.Descricao_Info2;
            lb_Info_Equip_3P.Text = Parametro_OrdemServico.Descricao_Info3;

            lb_Obs_Equip_1.Text = Parametro_OrdemServico.Descricao_Obs1;
            lb_Obs_Equip_2.Text = Parametro_OrdemServico.Descricao_Obs2;

            dg_Itens.AutoGenerateColumns = false;
            dg_Pesquisa.AutoGenerateColumns = false;

            dg_Itens.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;
            bt_Imprime.Visible = true;

            #region MONTA GRID CONSULTA
            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "NÚMERO";
            col_ID.Width = 70;
            dg_Pesquisa.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data_Abertura";
            col_Data.HeaderText = "ABERTURA";
            col_Data.Width = 70;
            col_Data.DefaultCellStyle.Format = "d";
            dg_Pesquisa.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "PESSOA";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Pesquisa.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Complemento = new DataGridViewTextBoxColumn();
            col_Complemento.DataPropertyName = "InformacaoCompleta";
            col_Complemento.HeaderText = Parametro_OrdemServico.Descricao_Info1 + @"/" + Parametro_OrdemServico.Descricao_Info2 + @"/" + Parametro_OrdemServico.Descricao_Info3;
            col_Complemento.Width = 400;
            col_Complemento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Pesquisa.Columns.Add(col_Complemento);

            DataGridViewTextBoxColumn col_Status = new DataGridViewTextBoxColumn();
            col_Status.DataPropertyName = "DescricaoStatus";
            col_Status.HeaderText = "STATUS";
            col_Status.Width = 100;
            dg_Pesquisa.Columns.Add(col_Status);
            #endregion

            Carrega_Parametros();

            CarregaCB();
            CarregaProduto();

            Limpa_Campos();

            if (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT == 0)
                bt_GerarNFCE.Visible = false;

            mk_Data_Abertura.Text = DateTime.Now.ToString();
            mk_DataStatus.Text = DateTime.Now.ToString();

            cb_ID_Pessoa.Focus();
        }

        private void CarregaCB()
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
            cb_ID_UsuarioComissao1.SelectedIndex = -1;

            DTUsuario = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(DTUsuario, "Descricao", "ID", cb_ID_UsuarioComissao2);
            cb_ID_UsuarioComissao2.SelectedIndex = -1;

            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 1;

            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Equipamento);
            DTGrupo = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(DTGrupo, "Descricao", "ID", cb_Tipo_Equipamento);
            cb_Tipo_Equipamento.SelectedIndex = 0;

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Fabricante);
            DTGrupo = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(DTGrupo, "Descricao", "ID", cb_Marca);
            cb_Marca.SelectedIndex = 0;

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Atendimento);
            DTGrupo = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(DTGrupo, "Descricao", "ID", cb_TipoAtendimento);
            cb_TipoAtendimento.SelectedIndex = 0;

            List<string> Status = new List<string>();
            Status.Add("ORÇAMENTO");
            Status.Add("APROVADA");
            Status.Add("MONTAGEM");
            Status.Add("PRONTA");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(2, Status), "Descricao", "ID", cb_Status_OS);
        }

        private void Carrega_Parametros()
        {
            BLL_Parametro = new BLL_Parametro();

            Parametro = new DTO_Parametro();
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            #region VENDAS
            Parametro.Tipo = 2;

            DataTable _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);
            Parametro_Venda.DiasBloqueioVenda = Convert.ToInt32(_DT.Rows[0]["DiasBloqueioVenda"]);
            Parametro_Venda.TipoImpressoraTermica = Convert.ToInt32(_DT.Rows[0]["TipoImpressoraTermica"]);
            Parametro_Venda.ID_TabelaVendaPadrao = Convert.ToInt32(_DT.Rows[0]["ID_TabelaVenda"]);
            #endregion
        }

        private void CarregaProduto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";

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
                BLL_OS = new BLL_OS();

                Produto = new DTO_Produto();
                OS = new DTO_OS();

                Produto.ID = _ID;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                Produto.Consulta_Tipo = true;
                Produto.Tipo = "1, 3, 5";

                DTProduto = BLL_Produto.Busca_Valor(Produto);

                if (DTProduto.Rows.Count > 0)
                {
                    DRProduto = DTProduto.Rows[0];

                    double Valor_Venda = 0;
                    /*
                    if (Parametro_Venda.Item_UltVlr == true)
                    {
                        BLL_OS = new BLL_OS();
                        OS = new DTO_OS();

                        OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        OS.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        OS.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                        OS.ID_Produto = util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString());

                        double _UltimoValor = BLL_OS.Busca_UltimoValor(OS);

                        if (_UltimoValor > 0 &&
                            _UltimoValor != Convert.ToDouble(DRProduto["ValorVenda"]))
                            Valor_Venda = _UltimoValor;
                        else
                            Valor_Venda = Convert.ToDouble(DRProduto["ValorVenda"]);
                    }
                    else
                        */
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

                    DT = BLL_Produto.Busca_Estoque(Produto);
                    if (DT == null)
                        return;

                    if (DT.Rows.Count == 1)
                    {
                        DR = DT.Rows[0];
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
            try
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

                    /*if (Convert.ToInt32(cb_TipoPessoa.SelectedValue) == 1)
                        if (Convert.ToInt32(DRPessoa["ID_Usuario"]) > 0 && Parametros.Comissao == true)
                        {
                            cb_ID_UsuarioComissao1.Enabled = false;
                            cb_ID_UsuarioComissao1.SelectedValue = DRPessoa["ID_Usuario"];
                        }
                        else
                        {
                            cb_ID_UsuarioComissao1.SelectedIndex = -1;
                            cb_ID_UsuarioComissao1.Enabled = true;
                        }*/
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
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

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

        private void Busca_Item(int _ID)
        {
            BLL_OS = new BLL_OS();
            OS = new DTO_OS();

            if (_ID == 0)
                return;

            OS.ID = _ID;
            DataTable _DT = new DataTable();
            _DT = BLL_OS.Busca_Item(OS);

            lst_Produto = new List<DTO_Produto_Item>();

            BLL_OS = new BLL_OS();
            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID = (int)_DT.Rows[i]["IDItem"];
                Produto_Item.ID_Produto = (int)_DT.Rows[i]["ID_Produto"];
                Produto_Item.Quantidade = Double.Parse(_DT.Rows[i]["Quantidade"].ToString());
                Produto_Item.ID_Tabela = (int)_DT.Rows[i]["ID_Tabela"];
                Produto_Item.Tipo = (int)_DT.Rows[i]["Tipo"];
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

            Carrega_Item(lst_Produto);
        }

        private void CarregaPessoa(int _Tipo)
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

                    case 2://Tab Pesquisa OS
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

        private void SomaItens()
        {
            try
            {

                double TotalProduto = 0;
                double TotalServico = 0;

                if (lst_Produto.Count > 0)
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].Tipo == 3)
                            TotalServico += lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;
                        else
                            TotalProduto += lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;

                txt_TotalProduto.Text = util_dados.ConfigNumDecimal(TotalProduto, 2);
                txt_TotalServico.Text = util_dados.ConfigNumDecimal(TotalServico, 2);
                txt_TotalOS.Text = util_dados.ConfigNumDecimal(TotalProduto + TotalServico, 2);
            }
            catch (Exception)
            {
            }
        }

        private void Calcula_Item()
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

        private void Limpa_Campos()
        {
            DG.DataSource = null;

            txt_ValorUnitario.Text = "0,00";
            txt_Quantidade.Text = "1,000";
            txt_ValorFinal.Text = "0,00";
            txt_Acrescimo.Text = "0,00";
            txt_Desconto.Text = "0,00";

            mk_Data_Abertura.Text = DateTime.Now.ToString();
            mk_DataStatus.Text = DateTime.Now.ToString();

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

            cb_TipoAtendimento.SelectedIndex = 0;
            cb_Tipo_Equipamento.SelectedIndex = 0;
            cb_ID_UsuarioComissao1.SelectedIndex = -1;
            cb_ID_UsuarioComissao2.SelectedIndex = -1;
            cb_Marca.SelectedIndex = 0;

            cb_ID_Pessoa.Focus();
        }

        private void Carrega_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens.Rows.Clear();
            txt_TotalProduto.Text = "0,00";
            txt_TotalServico.Text = "0,00";
            txt_TotalOS.Text = "0,00";

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;
                dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                dg_Itens.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorProduto;
                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
                dg_Itens.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
                dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;
            }

            if (dg_Itens.Rows.Count > 0)
            {
                dg_Itens.Rows[dg_Itens.Rows.Count - 1].Selected = true;
                dg_Itens.FirstDisplayedScrollingRowIndex = dg_Itens.Rows.Count - 1;
            }

            SomaItens();
        }

        private void Consulta_Pessoa()
        {           
            if (tabctl.SelectedTab == tabPage3)
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

        private void Consulta_Produto()
        {
            ID_Grade = 0;

            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;

            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = frm.ID_Produto;
            ID_Grade = frm.ID_Grade;
            txt_ID_Produto.Text = frm.ID_Produto.ToString();

            txt_Quantidade.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            if (tabctl.SelectedTab == tabPage3)
            {
                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_IDP.Text);
                OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                OS.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                OS.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                OS.Info_Equip_1 = txt_Info_Equip_1P.Text;
                OS.Info_Equip_2 = txt_Info_Equip_2P.Text;
                OS.Info_Equip_3 = txt_Info_Equip_3P.Text;

                if (rb_Todas.Checked == true)
                    OS.Status_OS = 0;

                if (rb_Aberta.Checked == true)
                    OS.Status_OS = 1;

                if (rb_Orcamento.Checked == true)
                    OS.Status_OS = 2;

                if (rb_Aprovada.Checked == true)
                    OS.Status_OS = 3;

                if (rb_Montagem.Checked == true)
                    OS.Status_OS = 4;

                if (rb_Pronta.Checked == true)
                    OS.Status_OS = 5;

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                       mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    OS.Consulta_Status.Filtra = true;

                    OS.Consulta_Status.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    OS.Consulta_Status.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
                DT = BLL_OS.Busca(OS);

                dg_Pesquisa.DataSource = DT;
                util_dados.CarregaCampo(this, DT, gb_Cadastro);
                util_dados.CarregaCampo(this, DT, gb_Pessoa);
                util_dados.CarregaCampo(this, DT, gb_Equipamento);

                dg_Pesquisa.Focus();
            }
        }

        public override void Gravar()
        {
            try
            {
                if (ck_Cancelado.Checked == true)
                    return;

                #region GRAVA OS
                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.Item = lst_Produto;

                OS.ID = util_dados.Verifica_int(txt_ID.Text);
                OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                OS.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                OS.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                OS.Data_Abertura = Convert.ToDateTime(mk_Data_Abertura.Text);

                OS.Garantia = ck_Garantia.Checked;
                OS.Reclamacao = txt_Reclamacao.Text;
                OS.Observacao = txt_Observacao.Text;
                OS.TipoAtendimento = Convert.ToInt32(cb_TipoAtendimento.SelectedValue);
                OS.Tipo_Equipamento = Convert.ToInt32(cb_Tipo_Equipamento.SelectedValue);

                OS.Marca = Convert.ToInt32(cb_Marca.SelectedValue);
                OS.Info_Equip_1 = txt_Info_Equip_1.Text;
                OS.Info_Equip_2 = txt_Info_Equip_2.Text;
                OS.Info_Equip_3 = txt_Info_Equip_3.Text;

                OS.Obs_Equip_1 = txt_Obs_Equip_1.Text;
                OS.Obs_Equip_2 = txt_Obs_Equip_2.Text;

                OS.Status_OS = Convert.ToInt32(cb_Status_OS.SelectedValue);

                OS.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);
                OS.ID_UsuarioComissao2 = Convert.ToInt32(cb_ID_UsuarioComissao2.SelectedValue);


                OS.NFe = Convert.ToBoolean(ck_NFe.Checked);
                OS.Faturado = Convert.ToBoolean(ck_Faturado.Checked);
                OS.CPF_CNPJ = txt_CNPJ_CPF.Text;

                obj = BLL_OS.Grava(OS);
                #endregion

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);

                    Busca_Item(obj);
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
            util_dados.LimpaCampos(this, gb_Equipamento);
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

                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_ID.Text);

                OS.Item = lst_Produto;

                BLL_OS.Exclui(OS);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Novo();
                Limpa_Campos();

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
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
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

            BLL_OS = new BLL_OS();
            OS = new DTO_OS();

            OS.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_OS = BLL_OS.Busca_Relatorio(OS);
            DTR_Item = BLL_OS.Busca_Item(OS);
            DTR_Financeiro = BLL_OS.Busca_Financeiro(OS);

            string Financeiro = string.Empty;
            string TipoPagto = string.Empty;

            if (DTR_Financeiro.Rows.Count > 0)
            {
                for (int i = 0; i <= DTR_Financeiro.Rows.Count - 1; i++)
                {
                    if (TipoPagto != DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString())
                    {
                        TipoPagto = DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString();

                        Financeiro += DTR_Financeiro.Rows[i]["PrevisaoPagto"] + "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                          + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                    }
                    else
                        Financeiro += "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                    + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                }
            }

            rpt_Nome = "rpt_OS_Simples.rdlc";

            //if (Parametro_Venda.TipoImpressoraTermica == 1)
            //    rpt_Nome = "rpt_OS_Termica.rdlc";

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
            ReportDataSource ds_OS = new ReportDataSource("ds_OS", DTR_OS);
            ReportDataSource ds_ItemOS = new ReportDataSource("ds_OS_Item", DTR_Item);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalServico", txt_TotalServico.Text);
            ReportParameter p3 = new ReportParameter("TotalProduto", txt_TotalProduto.Text);
            ReportParameter p4 = new ReportParameter("TotalOS", txt_TotalOS.Text);
            ReportParameter p5 = new ReportParameter("Info_1", Parametro_OrdemServico.Descricao_Info1);
            ReportParameter p6 = new ReportParameter("Info_2", Parametro_OrdemServico.Descricao_Info2);
            ReportParameter p7 = new ReportParameter("Info_3", Parametro_OrdemServico.Descricao_Info3);
            ReportParameter p8 = new ReportParameter("Obs_1", Parametro_OrdemServico.Descricao_Obs1);
            ReportParameter p9 = new ReportParameter("Obs_2", Parametro_OrdemServico.Descricao_Obs2);
            ReportParameter p10 = new ReportParameter("Usuario1", cb_ID_UsuarioComissao1.Text);
            ReportParameter p11 = new ReportParameter("Usuario2", cb_ID_UsuarioComissao2.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_OS);
            rpt.DataSources.Add(ds_ItemOS);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;

                if (Parametro_OrdemServico.Imprime_OS_Equipamento == true)
                {
                    rpt = new LocalReport();

                    rpt_Nome = "rpt_OS_Equipamento.rdlc";

                    Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

                    rpt.ReportPath = Caminhorpt;

                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_OS);
                    rpt.DataSources.Add(ds_ItemOS);
                    rpt.DataSources.Add(ds_Pessoa);
                    rpt.DataSources.Add(ds_Endereco);
                    rpt.DataSources.Add(ds_Telefone);
                    rpt.DataSources.Add(ds_Email);

                    rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

                    documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }
        }

        public override void Visualizar()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
            {
                MessageBox.Show("Nenhum OS Selecionado!");
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

            BLL_OS = new BLL_OS();
            OS = new DTO_OS();

            OS.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_OS = BLL_OS.Busca_Relatorio(OS);
            DTR_Item = BLL_OS.Busca_Item(OS);
            DTR_Financeiro = BLL_OS.Busca_Financeiro(OS);

            string Financeiro = string.Empty;
            string TipoPagto = string.Empty;


            if (DTR_Financeiro.Rows.Count > 0)
            {
                for (int i = 0; i <= DTR_Financeiro.Rows.Count - 1; i++)
                {
                    if (TipoPagto != DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString())
                    {
                        TipoPagto = DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString();

                        Financeiro += DTR_Financeiro.Rows[i]["PrevisaoPagto"] + "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                          + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                    }
                    else
                        Financeiro += "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                    + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                }
            }


            rpt_Nome = "rpt_OS_Simples.rdlc";

            //if (Parametro_Venda.TipoImpressoraTermica == 1)
            //rpt_Nome = "rpt_OS_Termica.rdlc";

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
            ReportDataSource ds_OS = new ReportDataSource("ds_OS", DTR_OS);
            ReportDataSource ds_ItemOS = new ReportDataSource("ds_OS_Item", DTR_Item);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalServico", txt_TotalServico.Text);
            ReportParameter p3 = new ReportParameter("TotalProduto", txt_TotalProduto.Text);
            ReportParameter p4 = new ReportParameter("TotalOS", txt_TotalOS.Text);
            ReportParameter p5 = new ReportParameter("Info_1", Parametro_OrdemServico.Descricao_Info1);
            ReportParameter p6 = new ReportParameter("Info_2", Parametro_OrdemServico.Descricao_Info2);
            ReportParameter p7 = new ReportParameter("Info_3", Parametro_OrdemServico.Descricao_Info3);
            ReportParameter p8 = new ReportParameter("Obs_1", Parametro_OrdemServico.Descricao_Obs1);
            ReportParameter p9 = new ReportParameter("Obs_2", Parametro_OrdemServico.Descricao_Obs2);
            ReportParameter p10 = new ReportParameter("Usuario1", cb_ID_UsuarioComissao1.Text);
            ReportParameter p11 = new ReportParameter("Usuario2", cb_ID_UsuarioComissao2.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_OS);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemOS);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

            frm_rpt.rpt_Viewer.RefreshReport();

            if (Parametro_OrdemServico.Imprime_OS_Equipamento == true)
            {
                frm_rpt = new UI_Visualiza_Relatorio();
                frm_rpt.Show();

                rpt_Nome = "rpt_OS_Equipamento.rdlc";

                Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_OS);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemOS);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

                frm_rpt.rpt_Viewer.RefreshReport();
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Ordem_Servico_KeyPress(object sender, KeyPressEventArgs e)
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

        private void UI_Ordem_Servico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == tabPage3)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();

            if (e.KeyCode == Keys.F8 &&
              tabctl.SelectedTab == TabPage1)
                tabControl1.SelectedTab = tab_Equipamento;

            if (e.KeyCode == Keys.F9 &&
              tabctl.SelectedTab == TabPage1)
                tabControl1.SelectedTab = tab_Produto_Servico;

            if (e.KeyCode == Keys.F10 &&
              tabctl.SelectedTab == TabPage1)
                Consulta_Produto();
        }

        private void UI_Ordem_Servico_Load(object sender, EventArgs e)
        {
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
            try
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

                    DT = BLL_Produto.Busca_Estoque(Produto);
                    if (DT == null)
                    {
                        MessageBox.Show("Estoque não cadastrado!");
                        return;
                    }

                    int TipoProduto = Convert.ToInt32(DT.Rows[0]["Tipo"]);

                    if (DT.Rows.Count == 1 ||
                        ID_Grade > 0)
                    {
                        DR = DT.Rows[0];
                        ID_Grade = Convert.ToInt32(DR["ID_Grade"]);

                        if (Convert.ToString(DR["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                            DescricaoGrade = " - " + Convert.ToString(DR["DescricaoGrade"]);
                        else
                            DescricaoGrade = string.Empty;
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

                        for (int i = 0; i <= lst_Produto.Count - 1; i++)
                            if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
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

                    if (lst_Produto == null)
                        lst_Produto = new List<DTO_Produto_Item>();

                    BLL_OS = new BLL_OS();
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
                                Produto_Item.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                                Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                                Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                                Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                                Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                                Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                                Produto_Item.Descricao_Saida = "VENDA";
                                Produto_Item.TipoSaida = 0;
                                Produto_Item.Tipo = Convert.ToInt32(DT.Rows[0]["Tipo"]);
                                Produto_Item.Descricao_Produto = cb_ID_Produto.Text + " - " + lst_Grade[i].DescricaoGrade;
                                Produto_Item.Informacao = lst_Grade[i].Informacao;
                                Produto_Item.ID_Grade = lst_Grade[i].ID_Grade;
                                Produto_Item.Quantidade = lst_Grade[i].Quantidade;

                                //VALIDA INFORMAÇÕES
                                BLL_OS.Grava_Item(Produto_Item);

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
                        Produto_Item.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                        Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                        Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                        Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                        Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                        Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                        Produto_Item.Descricao_Saida = "VENDA";
                        Produto_Item.TipoSaida = 0;
                        Produto_Item.Tipo = Convert.ToInt32(DT.Rows[0]["Tipo"]);
                        Produto_Item.Descricao_Produto = cb_ID_Produto.Text + DescricaoGrade;
                        Produto_Item.Informacao = txt_InformacaoItem.Text;
                        Produto_Item.ID_Grade = ID_Grade;

                        //VALIDA INFORMAÇÕES
                        BLL_OS.Grava_Item(Produto_Item);

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
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
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
                    BLL_OS = new BLL_OS();
                    OS = new DTO_OS();
                    Produto_Item = new DTO_Produto_Item();
                    List<DTO_Produto_Item> _Item = new List<DTO_Produto_Item>();

                    Produto_Item.ID = lst_Produto[dg_Itens.CurrentRow.Index].ID;
                    Produto_Item.ID_Produto = lst_Produto[dg_Itens.CurrentRow.Index].ID_Produto;
                    Produto_Item.ID_Grade = lst_Produto[dg_Itens.CurrentRow.Index].ID_Grade;

                    _Item.Add(Produto_Item);

                    OS.Item = _Item;

                    BLL_OS.Exclui_Item(OS);

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
            ///  Edita_Produto = true;
            cb_ID_Produto.SelectedValue = lst_Produto[dg_Itens.CurrentRow.Index].ID_Produto;
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Quantidade, 3);
            //txt_ValorCusto.Text = lst_Produto[dg_Itens.CurrentRow.Index].ValorCusto;
            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Acrescimo, 2);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(lst_Produto[dg_Itens.CurrentRow.Index].Desconto, 2);
            txt_InformacaoItem.Text = lst_Produto[dg_Itens.CurrentRow.Index].Informacao;

            Calcula_Item();
            /*
            Produto_Item.Quantidade = Convert.ToDouble();
          
            Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
            Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
            Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
            Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
            Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
            Produto_Item.Descricao_Produto = cb_ID_Produto.Text;
            Produto_Item.Descricao_Saida = cb_TipoVendaProduto.Text;
            //Produto_Item.ValorFinal = Convert.ToDouble(txt_ValorFinal.Text);
            Produto_Item.Informacao = txt_InformacaoItem.Text;
            Produto_Item.TipoSaida = Convert.ToInt32(cb_TipoVendaProduto.SelectedValue);
            Produto_Item.ID_Grade = ID_Grade;*/
        }

        private void bt_NotaFiscal_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.ParentForm.MdiChildren)
                if (Frm is UI_NFe_Emissor_Completo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_NFe_Emissor_Completo UI_NFe_Emissor_Completo = new UI_NFe_Emissor_Completo();
                UI_NFe_Emissor_Completo.NF_Venda = true;
                UI_NFe_Emissor_Completo.ID_OS = Convert.ToInt32(txt_ID.Text);

                util_dados.CarregaForm(UI_NFe_Emissor_Completo, this.ParentForm);
                this.Close();
            }
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }

        private void bt_GerarNFCE_Click(object sender, EventArgs e)
        {
            UI_CFe UI_CFe = new UI_CFe();
            UI_CFe.ID_OS = Convert.ToInt32(txt_ID.Text);
            UI_CFe.CNPJ_CPF_Destinatario = txt_CNPJ_CPF.Text;

            UI_CFe.Show();
        }

        private void bt_Atualiza_Status_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Alteracao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_ID.Text);
                OS.Data = Convert.ToDateTime(mk_DataStatus.Text);
                OS.Status_OS = Convert.ToInt32(cb_Status_OS.SelectedValue);

                BLL_OS.Altera_Status(OS);

                switch (Convert.ToInt32(cb_Status_OS.SelectedValue))
                {
                    case 2:
                        mk_Data_Orcamento.Text = mk_DataStatus.Text;
                        break;

                    case 3:
                        mk_Data_Aprovacao.Text = mk_DataStatus.Text;
                        break;

                    case 4:
                        mk_Data_Montagem.Text = mk_DataStatus.Text;
                        break;

                    case 5:
                        mk_Data_Pronta.Text = mk_DataStatus.Text;
                        break;

                    case 6:
                        mk_Data_Entrega.Text = mk_DataStatus.Text;
                        break;
                }

                MessageBox.Show(util_msg.msg_AlteraStatus, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_EncerrarOS_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Encerrar_OS, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                #region LANÇA FINANCEIRO VENDA
                UI_Ordem_Servico_Lanca frm = new UI_Ordem_Servico_Lanca();

                frm.Documento = txt_ID.Text;
                frm.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                frm.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                frm.Descricao_Pessoa = cb_ID_Pessoa.Text;
                frm.Valor = Convert.ToDouble(txt_TotalOS.Text);
                frm.Emissao = DateTime.Now;

                frm.ShowDialog();

                if (frm.Concluido == false)
                    return;
                #endregion

                #region ALTERA SITUAÇÃO OS
                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_ID.Text);
                OS.Faturado = true;
                OS.Data_Entrega = Convert.ToDateTime(mk_DataStatus.Text);

                BLL_OS.Altera_Fatura(OS);
                ck_Faturado.Checked = true;
                #endregion

                #region BAIXA DE ESTOQUE
                DataTable _DT = new DataTable();
                _DT = BLL_OS.Busca_Item(OS);

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto_Estoque = new DTO_Produto_Estoque();
                Produto.Estoque = new List<DTO_Produto_Estoque>();

                Produto_Item = new DTO_Produto_Item();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Produto.Estoque.Add(Produto_Estoque);

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    double Quantidade = util_dados.Verifica_Double(_DT.Rows[i]["Quantidade"].ToString()) - util_dados.Verifica_Double(_DT.Rows[i]["Quantidade_Entregue"].ToString());

                    if (Quantidade > 0)
                    {
                        Produto.Estoque[0].Estoque_Atual = Quantidade;
                        Produto.Estoque[0].ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_Grade"]);
                        Produto.Estoque[0].Adiciona = false;

                        Produto.ID = Convert.ToInt32(_DT.Rows[i]["ID_Produto"]);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        BLL_Produto.Atualiza_Estoque(Produto);

                        Produto_Item.ID = Convert.ToInt32(_DT.Rows[i]["IDItem"]);
                        Produto_Item.Quantidade_Entregue = Quantidade;

                        BLL_OS.Altera_Qt_Entregue(Produto_Item);
                    }
                }
                #endregion

                MessageBox.Show(util_msg.msg_Grava, this.Text);

                txt_IDP.Text = txt_ID.Text;

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
            }
        }

        private void bt_Proximo_Click(object sender, EventArgs e)
        {
            if (dg_Pesquisa.Rows.Count == 1)
                return;

            if (dg_Pesquisa.CurrentRow == null)
                dg_Pesquisa.Rows[0].Cells[0].Selected = true;

            int aux = dg_Pesquisa.CurrentRow.Index + 1;
            if (aux < dg_Pesquisa.Rows.Count)
            {
                dg_Pesquisa.Rows[dg_Pesquisa.CurrentRow.Index].Cells[0].Selected = false;
                dg_Pesquisa.Rows[aux].Cells[0].Selected = true;
            }
        }

        private void bt_Anterior_Click(object sender, EventArgs e)
        {
            if (dg_Pesquisa.Rows.Count == 1)
                return;

            if (dg_Pesquisa.CurrentRow == null)
                dg_Pesquisa.Rows[0].Cells[0].Selected = true;

            int aux = dg_Pesquisa.CurrentRow.Index - 1;
            if (aux >= 0)
            {
                dg_Pesquisa.Rows[dg_Pesquisa.CurrentRow.Index].Cells[0].Selected = false;
                dg_Pesquisa.Rows[aux].Cells[0].Selected = true;
            }
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
                    if (cb_ID_Pessoa.SelectedValue.GetType() == typeof(int) && Convert.ToInt32(cb_ID_Pessoa.SelectedValue) > 0)
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

        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Pessoa.SelectedValue != null)
                Verifica_CReceber(util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString()));
        }

        private void cb_ID_PessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaP.SelectedIndex = -1;
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

            Calcula_Item();

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

        private void txt_Desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                cb_ID_Produto.SelectedValue == null &&
                dg_Itens.Rows.Count > 0)
            {
                txt_Desconto.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Desconto.Text), 2);

                DialogResult msgbox = MessageBox.Show(util_msg.msg_Desconto_Itens.Replace("##", txt_Desconto.Text), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                {
                    double aux = lst_Produto[i].ValorProduto * (Convert.ToDouble(txt_Desconto.Text) / 100);

                    lst_Produto[i].Desconto = aux;
                    lst_Produto[i].ValorVenda = (lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo) - lst_Produto[i].Desconto;
                    lst_Produto[i].ValorTotal = lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;
                }

                Carrega_Item(lst_Produto);
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataStatus_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataStatus.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataStatus.Text = Convert.ToString(DateTime.Now);
                mk_DataStatus.Focus();
            }
        }

        private void mk_Data_Abertura_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data_Abertura.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data_Abertura.Text = Convert.ToString(DateTime.Now);
                mk_Data_Abertura.Focus();
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

        #region CHECKBOX
        private void ck_Faturado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Faturado.Checked == true &&
                ck_NFe.Checked == false)
            {
                bt_EncerrarOS.Enabled = false;
                bt_NotaFiscal.Enabled = true;
                bt_GerarNFCE.Enabled = true;
            }
            else
            {
                bt_EncerrarOS.Enabled = true;
                bt_NotaFiscal.Enabled = false;
                bt_GerarNFCE.Enabled = false;
            }
        }

        private void ck_NFe_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_NFe.Checked == true)
            {
                bt_NotaFiscal.Enabled = false;
                bt_GerarNFCE.Enabled = false;
            }
            else
            {
                bt_NotaFiscal.Enabled = true;
                bt_GerarNFCE.Enabled = true;
            }
        }

        private void ck_Cancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Cancelado.Checked == true)
            {
                bt_NotaFiscal.Enabled = false;
                bt_EncerrarOS.Enabled = false;
                bt_GerarNFCE.Enabled = false;
                bt_Edita.Enabled = false;
                lb_Cancelamento.Text = "O.S. CANCELADA";
            }
            else
            {
                bt_NotaFiscal.Enabled = true;
                bt_Edita.Enabled = true;
                lb_Cancelamento.Text = "";
            }
        }
        #endregion

        #region DATAGRID
        private void dg_Pesquisa_DoubleClick(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion     
    }
}

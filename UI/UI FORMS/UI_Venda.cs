using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;
using System.Threading;

namespace Sistema.UI
{
    public partial class UI_Venda : Sistema.UI.UI_Modelo
    {
        #region VARIAVEIS THREAD
        private volatile int ID;
        private volatile string CNPJ_CPF;
        private volatile bool Concluido_CFe;
        #endregion

        public UI_Venda()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_GrupoNivel BLL_GrupoNivel;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_Pagamento BLL_Pagamento;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Usuario BLL_Usuario;
        BLL_Venda BLL_Venda;
        BLL_Orcamento BLL_Orcamento;
        BLL_CReceber BLL_CReceber;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region PROPRIEDADES
        public int Tipo { get; set; }
        public int ID_Orcamento { get; set; }
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
        DataTable DTR_Venda;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        DataTable DTR_ItemVenda;
        DataTable DTR_Financeiro;

        bool Edita_Item = false;
        bool Faturamento_Personalizado = false;
        string Faturamento;

        int ID_Grade;
        public int ID_Temp;

        int obj;
        string DescricaoGrade;

        List<DTO_Produto_Item> lst_Produto;

        DateTime ValidaData;

        private Thread thread;
        #endregion

        #region ESTRUTURA
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
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        DTO_Orcamento Orcamento;
        DTO_CReceber CReceber;
        DTO_Parametro Parametro;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PEDIDO VENDA";

            bt_Imprime.Visible = true;

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;
            bt_Exclui.Visible = false;

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
            col_Complemento.Width = 320;
            col_Complemento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Complemento);

            DataGridViewTextBoxColumn col_Valor = new DataGridViewTextBoxColumn();
            col_Valor.DataPropertyName = "ValorTotal";
            col_Valor.HeaderText = "VALOR   ";
            col_Valor.Width = 80;
            col_Valor.DefaultCellStyle.Format = "C2";
            col_Valor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Columns.Add(col_Valor);

            DataGridViewCheckBoxColumn col_Faturado = new DataGridViewCheckBoxColumn();
            col_Faturado.DataPropertyName = "Faturado";
            col_Faturado.HeaderText = "FATURADO";
            col_Faturado.Width = 75;
            DG.Columns.Add(col_Faturado);

            if (Parametro_Venda.Exibe_NFeVenda == true)
            {
                DataGridViewTextBoxColumn col_NFe = new DataGridViewTextBoxColumn();
                col_NFe.DataPropertyName = "ID_NFe";
                col_NFe.HeaderText = "NF-e";
                col_NFe.Width = 65;
                DG.Columns.Add(col_NFe);

                DataGridViewTextBoxColumn col_CFe = new DataGridViewTextBoxColumn();
                col_CFe.DataPropertyName = "ID_CFe";
                col_CFe.HeaderText = "CF-e";
                col_CFe.Width = 65;
                DG.Columns.Add(col_CFe);
            }
            #endregion

            dg_Itens.AutoGenerateColumns = false;

            Carrega_Parametro();
            Carrega_CB();
            CarregaProduto();

            Limpa_Campos();

            if (Parametro_Sistema.Terminal_CFe == true)
                bt_GerarNFCE.Visible = true;

            if (Parametro_Sistema.Terminal_NFe == true)
                bt_GerarNFCE.Visible = true;

            if (Parametro_Venda.Limite_Desconto == 0 &&
                Parametro_Usuario.Libera_Desconto == false)
            {
                txt_Desconto.ReadOnly = true;
                txt_Acrescimo.ReadOnly = true;
                txt_ValorFinal.ReadOnly = true;
            }

            if (Parametro_Venda.TipoSaida_Fixo == true)
            {
                cb_TipoVendaProduto.SelectedValue = 0;
                cb_TipoVendaProduto.Enabled = false;
            }

            lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;
            lb_ComissaoP.Text = Parametro_Venda.Descricao_Comissao;

            cb_ID_Pessoa.Focus();

            if (Parametro_Venda.Qt_Dias_Pesquisa > 0)
            {
                if (Parametro_Venda.Qt_Dias_Pesquisa == 1)
                {
                    mk_DataInicial.Text = DateTime.Now.ToString();
                    mk_DataFinal.Text = DateTime.Now.ToString();
                }
                else
                {
                    mk_DataInicial.Text = DateTime.Now.AddDays(Parametro_Venda.Qt_Dias_Pesquisa * -1).ToString();
                    mk_DataFinal.Text = DateTime.Now.ToString();
                }
            }
        }

        private void Busca_Orcamento(int _ID)
        {
            BLL_Orcamento = new BLL_Orcamento();
            Orcamento = new DTO_Orcamento();

            Orcamento.ID = _ID;
            Orcamento.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Orcamento.Busca(Orcamento);
            cb_TipoPessoa.SelectedValue = Convert.ToInt32(_DT.Rows[0]["TipoPessoa"]);
            cb_ID_Pessoa.SelectedValue = Convert.ToInt32(_DT.Rows[0]["ID_Pessoa"]);

            _DT = new DataTable();
            _DT = BLL_Orcamento.Busca_Item(Orcamento);

            lst_Produto = new List<DTO_Produto_Item>();

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID = 0;
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

        private void Carrega_Parametro()
        {
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.Tipo = 2;
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count > 0)
            {
                Parametro_Venda.ID_TabelaVendaPadrao = Convert.ToInt32(_DT.Rows[0]["ID_TabelaVenda"]);
                Parametro_Venda.ID_ConsumidorFinal = Convert.ToInt32(_DT.Rows[0]["ID_ConsumidorFinal"]);
                Parametro_Venda.Ultimo_Valor = Convert.ToBoolean(_DT.Rows[0]["Ultimo_Valor"]);
                Parametro_Venda.Permitir2Vias = Convert.ToBoolean(_DT.Rows[0]["Permitir2Vias"]);
                Parametro_Venda.Agrupar_Produto = Convert.ToBoolean(_DT.Rows[0]["Agrupar_Produto"]);
                Parametro_Venda.Descricao_Comissao = _DT.Rows[0]["Descricao_Comissao"].ToString();
                Parametro_Venda.Limite_Desconto = Convert.ToDouble(_DT.Rows[0]["Limite_Desconto"]);
                Parametro_Venda.Produto_Marca = Convert.ToBoolean(_DT.Rows[0]["Produto_Marca"]);
                Parametro_Venda.Bloquear_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["Bloquear_EstoqueNegativo"]);
                Parametro_Venda.msg_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["msg_EstoqueNegativo"]);
                Parametro_Venda.Orca_ValorTotal = Convert.ToBoolean(_DT.Rows[0]["Orca_ValorTotal"]);
                Parametro_Venda.MultiploUsuarioPDV = Convert.ToBoolean(_DT.Rows[0]["MultiploUsuarioPDV"]);
                Parametro_Venda.Consulta_RapidaProduto = Convert.ToBoolean(_DT.Rows[0]["Consulta_RapidaProduto"]);
                Parametro_Venda.Modelo_Matricial = Convert.ToInt32(_DT.Rows[0]["Modelo_Matricial"]);
            }
        }

        private void Carrega_CB()
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
            util_dados.CarregaCombo(DTUsuario, "Descricao", "ID", cb_ID_UsuarioComissao1P);
            cb_ID_UsuarioComissao1P.SelectedIndex = -1;

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

            _DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;

            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pagamento);
            cb_ID_Pagamento.SelectedIndex = 0;
            CarregaParcelamento();
        }

        private void CarregaParcelamento()
        {
            try
            {
                int aux = util_dados.Verifica_int(cb_ID_Pagamento.SelectedValue.ToString());
                if (aux == 0)
                    return;

                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                Pagamento.ID = aux;

                DataTable _DT = new DataTable();
                _DT = BLL_Pagamento.Busca_Parc(Pagamento);

                if (_DT.Rows.Count > 0)
                {
                    util_dados.CarregaCombo(_DT, "Parcelamento", "ID", cb_ID_Parcelamento);
                }
                else
                {
                    List<string> lst = new List<string> { "0" };
                    _DT = util_dados.CarregaComboDinamico(0, lst);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Parcelamento);
                }
            }
            catch (Exception)
            {

            }
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

            if (Parametro_Venda.Produto_Marca == true)
                Produto.ConsultaMarca = true;

            DTProduto = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(DTProduto, "Descricao", "ID", cb_ID_Produto);
            cb_ID_Produto.SelectedIndex = -1;
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
                BLL_Venda = new BLL_Venda();

                Produto = new DTO_Produto();
                Venda = new DTO_Venda();

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

                    if (Parametro_Venda.Ultimo_Valor == true &&
                        cb_ID_Pessoa.SelectedValue != null &&
                        Convert.ToInt32(cb_ID_Pessoa.SelectedValue) != Parametro_Venda.ID_ConsumidorFinal)
                    {
                        BLL_Venda = new BLL_Venda();
                        Venda = new DTO_Venda();

                        Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                        Venda.ID_Produto = util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString());

                        double _UltimoValor = BLL_Venda.Busca_UltimoValor(Venda);

                        if (_UltimoValor > 0 &&
                            _UltimoValor != Convert.ToDouble(DRProduto["ValorVenda"]))
                            Valor_Venda = _UltimoValor;
                        else
                            Valor_Venda = Convert.ToDouble(DRProduto["ValorVenda"]);
                    }
                    else
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

                if (Convert.ToInt32(cb_TipoPessoa.SelectedValue) == 0)
                    return;

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID = _ID;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DTPessoa = BLL_Pessoa.Busca(Pessoa);
                if (DTPessoa.Rows.Count > 0)
                {
                    DRPessoa = DTPessoa.Rows[0];

                    txt_Informacao_Venda.Text = DRPessoa["Informacao_Venda"].ToString();

                    if (_ID == Parametro_Venda.ID_ConsumidorFinal)
                    {
                        txt_CNPJ_CPF.ReadOnly = false;
                        txt_CNPJ_CPF.BackColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    }
                    else
                    {
                        txt_CNPJ_CPF.ReadOnly = true;
                        txt_CNPJ_CPF.BackColor = Color.White;
                    }

                    if (util_dados.Verifica_int(DRPessoa["Dia_Faturamento"].ToString().Replace("/", "")) != 0)
                    {
                        Faturamento_Personalizado = true;
                        Faturamento = DRPessoa["Dia_Faturamento"].ToString();
                    }

                    txt_CNPJ_CPF.Text = Convert.ToString(DRPessoa["CNPJ_CPF"]);

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
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            if (_ID == 0)
                return;

            Venda.ID = _ID;
            DataTable _DT = new DataTable();
            _DT = BLL_Venda.Busca_Item(Venda);

            lst_Produto = new List<DTO_Produto_Item>();

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
            else
                dg_Itens.Rows.Clear();
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

                    case 2://Tab Pesquisa Pedido
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
                    txt_ValorVenda.Text = util_dados.ConfigNumDecimal(Total, 2);
                }
                else
                {
                    txt_ValorVenda.Text = "0,00";
                }
            }
            catch (Exception)
            {
            }
        }

        private void SomaVenda()
        {
            if (dg_Itens.Rows.Count > 0)
            {/*
                if (Rotinas.CalculaLucroReal(Convert.ToDecimal(Rotinas.CalculaValorQuantidade(DTItemPedido, "ValorMinimo", "Quantidade")), Convert.ToDecimal(txt_ValorVenda.Text)) < Convert.ToDecimal(MargemMinima))
                {
                    lb_Situacao.Text = "Bloqueado";
                    lb_Situacao.ForeColor = Color.Red;
                }
                else if (Rotinas.CalculaLucroReal(Convert.ToDecimal(Rotinas.CalculaValorQuantidade(DTItemPedido, "ValorMinimo", "Quantidade")), Convert.ToDecimal(txt_ValorVenda.Text)) > Convert.ToDecimal(MargemMinima))
                {
                    lb_Situacao.Text = "Liberado";
                    lb_Situacao.ForeColor = Color.Green;
                }
                */
            }
            CalculaMargens();
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

        private void CalculaMargens()
        {
            try
            {
                if (dg_Itens.Rows.Count > 0)
                {
                    // txt_MargemReal.Text = ConfigNumDecimal(CalculaLucroReal(txt_CustoTotal.Text, txt_ValorVenda.Text), 3)
                    // lb_Margem.Text = Rotinas.ConfigNumDecimal((Convert.ToDecimal(txt_ValorVenda.Text) / Rotinas.CalculaValorQuantidade(DTItemPedido, "ValorMinimo", "Quantidade") - 1) * 100, 3);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Limpa_Campos()
        {
            DG.DataSource = null;

            Faturamento_Personalizado = false;

            txt_ValorUnitario.Text = "0,00";
            txt_Quantidade.Text = "1,000";
            txt_ValorFinal.Text = "0,00";
            txt_Acrescimo.Text = "0,00";
            txt_Desconto.Text = "0,00";

            mk_Data.Text = DateTime.Now.ToString();
            mk_DataFatura.Text = DateTime.Now.ToString();
            mk_Entrega.Text = DateTime.Now.ToString();

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
            cb_ID_Pagamento.SelectedIndex = 0;

            cb_ID_Pessoa.SelectedValue = Parametro_Venda.ID_ConsumidorFinal;

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + "0,000";

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
            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + util_dados.ConfigNumDecimal(Quantidade, 3);
            lb_DescontoTotal.Text = util_msg.msg_Desconto_Total + util_dados.ConfigNumDecimal(util_dados.Verifica_Porcentagem(SubTotal, SubTotal - TotalDesconto), 2) + " %";
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
                                UI_Pessoa_Consulta.BringToFront();
                                aux = true;
                                return;
                            }
                            UI_Pessoa_Consulta.Close();
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

                CarregaPessoa(1);

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

        private void Emite_CFe()
        {
            if (Parametro_Sistema.Terminal_CFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorCFe, this.Text);
                return;
            }

            ID = Convert.ToInt32(txt_ID.Text);
            CNPJ_CPF = txt_CNPJ_CPF.Text;

            Concluido_CFe = false;

            try
            {
                UI_CFe UI_CFe = new UI_CFe();
                UI_CFe.ID_Venda = ID;
                UI_CFe.CNPJ_CPF_Destinatario = CNPJ_CPF;

                UI_CFe.ShowDialog();

                if (UI_CFe.NF_Gravada == true)
                    Concluido_CFe = true;

                ck_NFe.Checked = Concluido_CFe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Imprime_Matricial(DataTable _DT_Cliente, DataTable _DT_Endereco, DataTable _DT_Telefone, DataTable _DT_Venda, DataTable _DT_Itens, DataTable _DT_Financeiro)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            int _pagina = 1;
            int _total_pagina = 1;
            int _aux_Financeiro = 0;
            int _aux = 0;

            string _str_Impressao = string.Empty;
            string _str_Venda = string.Empty;
            string _str_Item_Venda = string.Empty;
            string _str_Financeiro = string.Empty;

            if (_DT_Endereco.Rows.Count == 0)
                _DT_Endereco.Rows.Add();

            if (_DT_Telefone.Rows.Count == 0)
                _DT_Telefone.Rows.Add();
            
            switch (Parametro_Venda.Modelo_Matricial)
            {
                #region MODELO MATRICIAL 1
                case 1:
                    #region INFORMAÇÕES VENDA
                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                    _str_Venda += "PEDIDO: " + util_dados.Config_Campo_String(10, 'E', '0', _DT_Venda.Rows[0]["ID"].ToString());
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "");
                    _str_Venda += util_dados.Config_Campo_String(60, 'E', ' ', "*** " + Parametro_Empresa.Razao_Social_Empresa + " ***");
                    _str_Venda += util_dados.Config_Campo_String(20, 'E', ' ', "");
                    _str_Venda += "PAG.: -~pag~-/-~total~-" + Environment.NewLine;

                    _str_Venda += "DATA..: " + util_dados.Config_Data(Convert.ToDateTime(_DT_Venda.Rows[0]["Data"]), 3).ToString() + Environment.NewLine; ;

                    _str_Venda += "CLIENTE..: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Cliente.Rows[0]["Descricao"].ToString());
                    _str_Venda += "CÓDIGO..: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Cliente.Rows[0]["ID_Pessoa"].ToString()) + Environment.NewLine;

                    _str_Venda += "CNPJ/CPF.: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Cliente.Rows[0]["CNPJ_CPF"].ToString());
                    _str_Venda += "IE/RG...: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Cliente.Rows[0]["IE_RG"].ToString()) + Environment.NewLine;

                    _str_Venda += "ENDEREÇO.: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Endereco.Rows[0]["Logradouro"].ToString() + ", " + _DT_Endereco.Rows[0]["NumeroEndereco"].ToString());
                    _str_Venda += "BAIRRO..: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Endereco.Rows[0]["Bairro"].ToString()) + Environment.NewLine;

                    _str_Venda += "MUNICIPIO: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Endereco.Rows[0]["NomeMunicipio"].ToString() + "-" + _DT_Endereco.Rows[0]["Sigla"].ToString());
                    _str_Venda += "TELEFONE: " + util_dados.Config_Campo_String(36, 'D', ' ', "(" + _DT_Telefone.Rows[0]["DDD"].ToString() + ") " + _DT_Telefone.Rows[0]["NumeroTelefone"].ToString()) + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '=', "") + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(10, 'D', ' ', "COD.");
                    _str_Venda += util_dados.Config_Campo_String(55, 'D', ' ', "PRODUTO");
                    _str_Venda += util_dados.Config_Campo_String(19, 'D', ' ', Parametro_CadastroPersonalizado.Info_Produto1 + " ");
                    _str_Venda += util_dados.Config_Campo_String(19, 'D', ' ', Parametro_CadastroPersonalizado.Info_Produto2 + " ");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "QUANT.");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "PREÇO");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "TOTAL") + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                    #endregion

                    #region FINANCEIRO
                    _aux_Financeiro = 1;
                    for (int i = 0; i <= _DT_Financeiro.Rows.Count - 1; i++)
                    {
                        _str_Financeiro += "|";
                        _str_Financeiro += "VENCTO " + (i + 1).ToString() + ": " + util_dados.Config_Campo_String(10, 'D', ' ', util_dados.Config_Data(Convert.ToDateTime(_DT_Financeiro.Rows[i]["Vencimento"]), 3).ToString());
                        _str_Financeiro += util_dados.Config_Campo_String(2, 'E', ' ', "");
                        _str_Financeiro += "R$ " + util_dados.Config_Campo_String(10, 'D', ' ', util_dados.ConfigNumDecimal(_DT_Financeiro.Rows[i]["Valor"], 2));
                        _str_Financeiro += "|";

                        if (_aux_Financeiro < 3)
                            _aux_Financeiro++;
                        else
                        {
                            _str_Financeiro += Environment.NewLine;
                            _aux_Financeiro = 1;
                        }
                    }

                    //LANÇAMENTO PARA VENDAS NÃO FATURADAS
                    if (_DT_Financeiro.Rows.Count == 0 &&
                        ck_Faturado.Checked == false)
                        _str_Financeiro += cb_ID_Pagamento.Text + " (" + cb_ID_Parcelamento.Text + ")";
                    #endregion

                    if (_DT_Itens.Rows.Count + _aux_Financeiro <= 20)
                        _total_pagina = 1;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 21 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 40)
                        _total_pagina = 2;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 41 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 60)
                        _total_pagina = 3;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 61 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 80)
                        _total_pagina = 4;

                    _str_Impressao += _str_Venda.Replace("-~pag~-", _pagina.ToString()).Replace("-~total~-", _total_pagina.ToString());

                    #region ITENS VENDA
                    _aux = 0;
                    for (int i = 0; i <= _DT_Itens.Rows.Count - 1; i++)
                    {
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'D', ' ', _DT_Itens.Rows[i]["Referencia"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(55, 'D', ' ', _DT_Itens.Rows[i]["DescricaoProduto"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(19, 'D', ' ', _DT_Itens.Rows[i]["InfoAdicional1"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(19, 'D', ' ', _DT_Itens.Rows[i]["InfoAdicional2"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["Quantidade"], 2));
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["ValorVenda"], 2));
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["ValorTotal"], 2));
                        _str_Item_Venda += Environment.NewLine;

                        _aux++;

                        if (_aux == 20)
                        {
                            _pagina++;

                            _str_Impressao += _str_Item_Venda;
                            _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                            _str_Impressao += Environment.NewLine;
                            _str_Impressao += Environment.NewLine;
                            _str_Impressao += _str_Venda.Replace("-~pag~-", _pagina.ToString()).Replace("-~total~-", _total_pagina.ToString());

                            _str_Item_Venda = string.Empty;
                            _aux = 0;
                        }
                    }
                    #endregion

                    _str_Impressao += _str_Item_Venda;

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '=', "") + Environment.NewLine;

                    _str_Impressao += "VENDEDOR: " + util_dados.Config_Campo_String(100, 'D', ' ', cb_ID_UsuarioComissao1.Text);

                    _str_Impressao += "TOTAL:" + util_dados.Config_Campo_String(20, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Venda.Rows[0]["ValorTotal"], 2)) + Environment.NewLine;

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;

                    _str_Impressao += _str_Financeiro;

                    _str_Impressao = util_dados.ConfigCampoNFe(_str_Impressao);

                    _aux = _DT_Itens.Rows.Count + _aux_Financeiro;

                    switch (_total_pagina)
                    {
                        case 1:
                            for (int i = _aux + 13; i <= 30; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 2:
                            for (int i = _aux + 31; i <= 60; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 3:
                            for (int i = _aux + 43; i <= 90; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 4:
                            for (int i = _aux + 55; i <= 120; i++)
                                _str_Impressao += Environment.NewLine;
                            break;
                    }

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "");
                    break;
                #endregion

                #region MODELO MATRICIAL 2
                case 2:
                    #region INFORMAÇÕES VENDA
                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                    _str_Venda += "PEDIDO: " + util_dados.Config_Campo_String(10, 'E', '0', _DT_Venda.Rows[0]["ID"].ToString());
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "");
                    _str_Venda += util_dados.Config_Campo_String(60, 'E', ' ', "*** " + Parametro_Empresa.Razao_Social_Empresa + " ***");
                    _str_Venda += util_dados.Config_Campo_String(20, 'E', ' ', "");
                    _str_Venda += "PAG.: -~pag~-/-~total~-" + Environment.NewLine;

                    _str_Venda += "DATA..: " + util_dados.Config_Data(Convert.ToDateTime(_DT_Venda.Rows[0]["Data"]), 3).ToString() + Environment.NewLine; ;

                    _str_Venda += "CLIENTE..: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Cliente.Rows[0]["Descricao"].ToString());
                    _str_Venda += "CÓDIGO..: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Cliente.Rows[0]["ID_Pessoa"].ToString()) + Environment.NewLine;

                    _str_Venda += "CNPJ/CPF.: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Cliente.Rows[0]["CNPJ_CPF"].ToString());
                    _str_Venda += "IE/RG...: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Cliente.Rows[0]["IE_RG"].ToString()) + Environment.NewLine;

                    _str_Venda += "ENDEREÇO.: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Endereco.Rows[0]["Logradouro"].ToString() + ", " + _DT_Endereco.Rows[0]["NumeroEndereco"].ToString());
                    _str_Venda += "BAIRRO..: " + util_dados.Config_Campo_String(36, 'D', ' ', _DT_Endereco.Rows[0]["Bairro"].ToString()) + Environment.NewLine;

                    _str_Venda += "MUNICIPIO: " + util_dados.Config_Campo_String(80, 'D', ' ', _DT_Endereco.Rows[0]["NomeMunicipio"].ToString() + "-" + _DT_Endereco.Rows[0]["Sigla"].ToString());
                    _str_Venda += "TELEFONE: " + util_dados.Config_Campo_String(36, 'D', ' ', "(" + _DT_Telefone.Rows[0]["DDD"].ToString() + ") " + _DT_Telefone.Rows[0]["NumeroTelefone"].ToString()) + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '=', "") + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(10, 'D', ' ', "COD.");
                    _str_Venda += util_dados.Config_Campo_String(74, 'D', ' ', "PRODUTO");
                    _str_Venda += util_dados.Config_Campo_String(19, 'D', ' ', "REFERENCIA");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "QUANT.");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "PREÇO");
                    _str_Venda += util_dados.Config_Campo_String(10, 'E', ' ', "TOTAL") + Environment.NewLine;

                    _str_Venda += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                    #endregion

                    #region FINANCEIRO
                    _aux_Financeiro = 1;
                    for (int i = 0; i <= _DT_Financeiro.Rows.Count - 1; i++)
                    {
                        _str_Financeiro += "|";
                        _str_Financeiro += "VENCTO " + (i + 1).ToString() + ": " + util_dados.Config_Campo_String(10, 'D', ' ', util_dados.Config_Data(Convert.ToDateTime(_DT_Financeiro.Rows[i]["Vencimento"]), 3).ToString());
                        _str_Financeiro += util_dados.Config_Campo_String(2, 'E', ' ', "");
                        _str_Financeiro += "R$ " + util_dados.Config_Campo_String(10, 'D', ' ', util_dados.ConfigNumDecimal(_DT_Financeiro.Rows[i]["Valor"], 2));
                        _str_Financeiro += "|";

                        if (_aux_Financeiro < 3)
                            _aux_Financeiro++;
                        else
                        {
                            _str_Financeiro += Environment.NewLine;
                            _aux_Financeiro = 1;
                        }
                    }

                    //LANÇAMENTO PARA VENDAS NÃO FATURADAS
                    if (_DT_Financeiro.Rows.Count == 0 &&
                        ck_Faturado.Checked == false)
                        _str_Financeiro += cb_ID_Pagamento.Text + " (" + cb_ID_Parcelamento.Text + ")";
                    #endregion

                    if (_DT_Itens.Rows.Count + _aux_Financeiro <= 20)
                        _total_pagina = 1;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 21 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 40)
                        _total_pagina = 2;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 41 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 60)
                        _total_pagina = 3;

                    if (_DT_Itens.Rows.Count + _aux_Financeiro >= 61 &&
                        _DT_Itens.Rows.Count + _aux_Financeiro <= 80)
                        _total_pagina = 4;

                    _str_Impressao += _str_Venda.Replace("-~pag~-", _pagina.ToString()).Replace("-~total~-", _total_pagina.ToString());

                    #region ITENS VENDA
                    _aux = 0;
                    for (int i = 0; i <= _DT_Itens.Rows.Count - 1; i++)
                    {
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'D', ' ', _DT_Itens.Rows[i]["ID_Produto"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(74, 'D', ' ', _DT_Itens.Rows[i]["DescricaoProduto"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(19, 'D', ' ', _DT_Itens.Rows[i]["Referencia"].ToString());
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["Quantidade"], 2));
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["ValorVenda"], 2));
                        _str_Item_Venda += util_dados.Config_Campo_String(10, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Itens.Rows[i]["ValorTotal"], 2));
                        _str_Item_Venda += Environment.NewLine;

                        _aux++;

                        if (_aux == 20)
                        {
                            _pagina++;

                            _str_Impressao += _str_Item_Venda;
                            _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;
                            _str_Impressao += Environment.NewLine;
                            _str_Impressao += Environment.NewLine;
                            _str_Impressao += _str_Venda.Replace("-~pag~-", _pagina.ToString()).Replace("-~total~-", _total_pagina.ToString());

                            _str_Item_Venda = string.Empty;
                            _aux = 0;
                        }
                    }
                    #endregion

                    _str_Impressao += _str_Item_Venda;

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '=', "") + Environment.NewLine;

                    _str_Impressao += "VENDEDOR: " + util_dados.Config_Campo_String(100, 'D', ' ', cb_ID_UsuarioComissao1.Text);

                    _str_Impressao += "TOTAL:" + util_dados.Config_Campo_String(20, 'E', ' ', util_dados.ConfigNumDecimal(_DT_Venda.Rows[0]["ValorTotal"], 2)) + Environment.NewLine;

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "") + Environment.NewLine;

                    _str_Impressao += _str_Financeiro;

                    _str_Impressao = util_dados.ConfigCampoNFe(_str_Impressao);

                    _aux = _DT_Itens.Rows.Count + _aux_Financeiro;

                    switch (_total_pagina)
                    {
                        case 1:
                            for (int i = _aux + 13; i <= 30; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 2:
                            for (int i = _aux + 31; i <= 60; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 3:
                            for (int i = _aux + 43; i <= 90; i++)
                                _str_Impressao += Environment.NewLine;
                            break;

                        case 4:
                            for (int i = _aux + 55; i <= 120; i++)
                                _str_Impressao += Environment.NewLine;
                            break;
                    }

                    _str_Impressao += util_dados.Config_Campo_String(136, 'D', '-', "");
                    break;
                    #endregion
            }

            string Arquivo_txt = Parametro_Sistema.Caminho_Sistema + @"Temp\" + Convert.ToInt32(_DT_Venda.Rows[0]["ID"]) + ".txt";

            if (File.Exists(Arquivo_txt))
                File.Delete(Arquivo_txt);

            StreamWriter GeraTXT = null;
            GeraTXT = new StreamWriter(Arquivo_txt);
            GeraTXT.Write(_str_Impressao);
            GeraTXT.Close();

            File.Copy(Arquivo_txt, @"LPT1", true);

            File.Delete(Parametro_Sistema.Caminho_Sistema + @"Temp\" + Convert.ToInt32(_DT_Venda.Rows[0]["ID"]) + ".txt");
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            if (tabctl.SelectedTab == TabPage2)
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_IDVenda.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1P.SelectedValue);

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                       mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    Venda.Consulta_Emissao.Filtra = true;
                    Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
                DT = BLL_Venda.Busca(Venda);

                DG.DataSource = DT;
                util_dados.CarregaCampo(this, DT, gb_Pessoa);
                util_dados.CarregaCampo(this, DT, gb_Cadastro);
                DG.Focus();
            }
        }

        public override void Gravar()
        {
            try
            {
                if (ck_Cancelado.Checked == true)
                    return;

                bool Pagto_Cartao = false;

                if (Parametro_Venda.NaoAlterarVendaFaturada == true &&
                    ck_Faturado.Checked == true &&
                    Parametro_Usuario.Permite_AterarFaturado == false)
                    return;

                if (Parametro_Venda.Limite_Desconto > 0 &&
                    Parametro_Usuario.Libera_Desconto == false &&
                    util_dados.Verifica_Porcentagem(Convert.ToDouble(txt_SubTotal.Text), Convert.ToDouble(txt_ValorVenda.Text)) > Parametro_Venda.Limite_Desconto)
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

                #region GRAVA PEDIDO
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.Item = lst_Produto;

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Venda.Data = Convert.ToDateTime(mk_Data.Text);

                if (mk_Entrega.Text.Replace(@"/", "").Trim() != string.Empty)
                    Venda.Entrega = Convert.ToDateTime(mk_Entrega.Text);

                if (mk_DataFatura.Text.Replace(@"/", "").Trim() != string.Empty)
                    Venda.DataFatura = Convert.ToDateTime(mk_DataFatura.Text);

                Venda.Informacao = txt_informacao.Text;
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);
                Venda.Comprador = txt_Comprador.Text;
                Venda.NFe = Convert.ToBoolean(ck_NFe.Checked);
                Venda.Faturado = Convert.ToBoolean(ck_Faturado.Checked);
                Venda.ID_Pagamento = Convert.ToInt32(cb_ID_Pagamento.SelectedValue);
                Venda.ID_Parcelamento = Convert.ToInt32(cb_ID_Parcelamento.SelectedValue);
                Venda.CPF_CNPJ = txt_CNPJ_CPF.Text;

                obj = BLL_Venda.Grava(Venda);
                #endregion

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    Venda.ID = obj;
                    txt_ID.Text = Venda.ID.ToString();

                    Busca_Item(Venda.ID);
                }

                if (ck_Faturado.Checked == false &&
                    Parametro_Usuario.Permite_Faturar == true)
                {
                    bool Finaliza_Venda = true;

                    if (Convert.ToDouble(txt_ValorVenda.Text) > 0)
                    {
                        #region LANÇA FINANCEIRO VENDA
                        UI_Venda_Lanca frm = new UI_Venda_Lanca();

                        frm.Documento = txt_ID.Text;
                        frm.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        frm.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                        frm.Descricao_Pessoa = cb_ID_Pessoa.Text;
                        frm.Valor = Convert.ToDouble(txt_ValorVenda.Text);
                        frm.Emissao = Convert.ToDateTime(mk_DataFatura.Text);
                        frm.ID_Pagamento = Convert.ToInt32(cb_ID_Pagamento.SelectedValue);
                        frm.ID_Parcelamento = Convert.ToInt32(cb_ID_Parcelamento.SelectedValue);
                        frm.Finaliza_Venda = Finaliza_Venda;
                        frm.Faturamento_Personalizado = Faturamento_Personalizado;
                        frm.Faturamento = Faturamento;

                        frm.ShowDialog();

                        if (frm.Concluido == false)
                            return;

                        if (frm.Pagto_Cartao == true)
                            Pagto_Cartao = true;
                        #endregion
                    }
                    else
                    {
                        DialogResult msgbox = MessageBox.Show(util_msg.msg_Encerrar_Venda_ValorZero, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msgbox == DialogResult.No)
                            return;
                    }

                    #region ALTERA SITUAÇÃO PEDIDO
                    Venda.Faturado = true;
                    Venda.DataFatura = Convert.ToDateTime(mk_DataFatura.Text);

                    BLL_Venda.Altera_Fatura(Venda);
                    ck_Faturado.Checked = true;
                    #endregion

                    #region BAIXA DE ESTOQUE
                    if (Tipo == 1)
                    {
                        DT = new DataTable();
                        DT = BLL_Venda.Busca_Item(Venda);

                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();
                        Produto_Estoque = new DTO_Produto_Estoque();
                        Produto.Estoque = new List<DTO_Produto_Estoque>();

                        Produto_Item = new DTO_Produto_Item();

                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Produto.Estoque.Add(Produto_Estoque);

                        for (int i = 0; i <= DT.Rows.Count - 1; i++)
                        {
                            double Quantidade = util_dados.Verifica_Double(DT.Rows[i]["Quantidade"].ToString()) - util_dados.Verifica_Double(DT.Rows[i]["Quantidade_Entregue"].ToString());

                            if (Quantidade > 0)
                            {
                                Produto.Estoque[0].Estoque_Atual = Quantidade;
                                Produto.Estoque[0].ID_Grade = Convert.ToInt32(DT.Rows[i]["ID_Grade"]);
                                Produto.Estoque[0].Adiciona = false;

                                Produto.ID = Convert.ToInt32(DT.Rows[i]["ID_Produto"]);
                                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                                Produto.Tipo_Movimento = 2;
                                Produto.Informacao = "VENDA KIT (" + DT.Rows[i]["DescricaoProduto"].ToString() + ") VENDA Nº " + Venda.ID;

                                BLL_Produto.Atualiza_Estoque(Produto);

                                Produto_Item.ID = Convert.ToInt32(DT.Rows[i]["IDItem"]);
                                Produto_Item.Quantidade_Entregue = Quantidade;

                                BLL_Venda.Altera_Qt_Entregue(Produto_Item);
                            }
                        }
                    }
                    #endregion
                }

                MessageBox.Show(util_msg.msg_VendaConcluida, this.Text);

                if (Parametro_Venda.CFe_Cartao &&
                    Pagto_Cartao == true)
                    Emite_CFe();

                if (Parametro_Venda.Venda_ImpressaoDireta == true)
                {
                    Imprimir();

                    Novo();
                    Limpa_Campos();

                    Status = StatusForm.Novo;
                    Config_Botao();
                }
                else
                    txt_ID.Text = Venda.ID.ToString();
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
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);

                Venda.Item = lst_Produto;

                BLL_Venda.Exclui(Venda);

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
                MessageBox.Show(util_msg.msg_NenhumRegistroSelecionado, this.Text);
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

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_Venda = BLL_Venda.Busca_Relatorio(Venda);
            DTR_ItemVenda = BLL_Venda.Busca_Item(Venda);
            DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

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
            else
                Financeiro = cb_ID_Pagamento.Text + "(" + cb_ID_Parcelamento.Text + ")";


            if (Parametro_Venda.TipoImpressoraTermica == 1)
                rpt_Nome = "rpt_Venda_Termica.rdlc";
            else
            {
                if (DTR_ItemVenda.Rows.Count <= 11 && Parametro_Venda.Permitir2Vias == true)
                {
                    rpt_Nome = "rpt_Venda2.rdlc";
                    for (int i = DTR_ItemVenda.Rows.Count; i <= 11; i++)
                    {
                        DTR_ItemVenda.Rows.Add();
                        DTR_ItemVenda.Rows[i]["DescricaoProduto"] = "";
                        DTR_ItemVenda.Rows[i]["ValorVenda"] = 0;
                        DTR_ItemVenda.Rows[i]["Quantidade"] = 0;
                        DTR_ItemVenda.Rows[i]["Desconto"] = 0;
                        DTR_ItemVenda.Rows[i]["Acrescimo"] = 0;
                        DTR_ItemVenda.AcceptChanges();
                    }
                }
                else
                    rpt_Nome = "rpt_Venda.rdlc";
            }

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

            //*****************TEMPORARIO******************
            if (Parametro_Venda.Venda_Matricial == true)
            {
                Imprime_Matricial(DTR_Pessoa, DTR_Endereco, DTR_Telefone, DTR_Venda, DTR_ItemVenda, DTR_Financeiro);
                return;
            }

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemVenda);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(txt_ValorVenda.Text, 3));
            ReportParameter p3 = new ReportParameter("Vendedor", cb_ID_UsuarioComissao1.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pedido);
            rpt.DataSources.Add(ds_ItemPedido);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);

                if (Parametro_Venda.TipoImpressoraTermica == 1)
                    imp.Imprimir(documento, Tipo_Impressao.Termica);
                else
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;
            }
        }

        public override void Visualizar()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistroSelecionado, this.Text);
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

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = util_dados.Verifica_int(txt_ID.Text);

            DTR_Venda = BLL_Venda.Busca_Relatorio(Venda);
            DTR_ItemVenda = BLL_Venda.Busca_Item(Venda);
            DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

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
            else
                Financeiro = cb_ID_Pagamento.Text + "(" + cb_ID_Parcelamento.Text + ")";


            if (Parametro_Venda.TipoImpressoraTermica == 1)
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressaoA4, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    rpt_Nome = "rpt_Venda_Termica.rdlc";

                if (msgbox == DialogResult.Yes)
                {
                    if (DTR_ItemVenda.Rows.Count <= 11 &&
                    Parametro_Venda.Permitir2Vias == true)
                    {
                        rpt_Nome = "rpt_Venda2.rdlc";
                        for (int i = DTR_ItemVenda.Rows.Count; i <= 11; i++)
                        {
                            DTR_ItemVenda.Rows.Add();
                            DTR_ItemVenda.Rows[i]["DescricaoProduto"] = "";
                            DTR_ItemVenda.Rows[i]["ValorVenda"] = 0;
                            DTR_ItemVenda.Rows[i]["Quantidade"] = 0;
                            DTR_ItemVenda.Rows[i]["Desconto"] = 0;
                            DTR_ItemVenda.Rows[i]["Acrescimo"] = 0;
                            DTR_ItemVenda.AcceptChanges();
                        }
                    }
                    else
                        rpt_Nome = "rpt_Venda.rdlc";
                }
            }
            else
            {
                if (DTR_ItemVenda.Rows.Count <= 11 &&
                    Parametro_Venda.Permitir2Vias == true &&
                    Parametro_Venda.TipoImpressoraTermica == 0)
                {
                    rpt_Nome = "rpt_Venda2.rdlc";
                    for (int i = DTR_ItemVenda.Rows.Count; i <= 11; i++)
                    {
                        DTR_ItemVenda.Rows.Add();
                        DTR_ItemVenda.Rows[i]["DescricaoProduto"] = "";
                        DTR_ItemVenda.Rows[i]["ValorVenda"] = 0;
                        DTR_ItemVenda.Rows[i]["Quantidade"] = 0;
                        DTR_ItemVenda.Rows[i]["Desconto"] = 0;
                        DTR_ItemVenda.Rows[i]["Acrescimo"] = 0;
                        DTR_ItemVenda.AcceptChanges();
                    }
                }
                else
                    rpt_Nome = "rpt_Venda.rdlc";
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
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemVenda);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(txt_ValorVenda.Text, 3));
            ReportParameter p3 = new ReportParameter("Vendedor", cb_ID_UsuarioComissao1.Text);

            //ReportParameter p4 = new ReportParameter("Decimal_Quantidade", Parametro_Venda.Decimal_Quantidade);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            frm_rpt.rpt_Viewer.RefreshReport();
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
                txt_Desconto.Focused == true ||
                txt_TotalDesconto.Focused == true)
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
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();

            if (e.KeyCode == Keys.F10 &&
              tabctl.SelectedTab == TabPage1)
                Consulta_Produto();
        }

        private void UI_Venda_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            if (ID_Orcamento > 0)
                Busca_Orcamento(ID_Orcamento);
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
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);
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

                if (util_dados.Verifica_Porcentagem(Convert.ToDouble(txt_ValorUnitario.Text), Convert.ToDouble(txt_ValorFinal.Text)) > Parametro_Venda.Limite_Desconto)
                    MessageBox.Show(util_msg.msg_Desconto_AcimaLimite, this.Text);

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

                BLL_Venda = new BLL_Venda();
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
                            if (!BLL_Venda.Grava_Item(Produto_Item))
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
                    if (!BLL_Venda.Grava_Item(Produto_Item))
                        return;

                    //ADICIONA A LISTA
                    lst_Produto.Add(Produto_Item);
                }

                Carrega_Item(lst_Produto);
                ID_Grade = 0;
                cb_ID_Produto.SelectedIndex = -1;
                txt_Quantidade.Text = "1,000";
                txt_ValorUnitario.Text = "0,00";
                txt_InformacaoItem.Clear();
                cb_ID_Produto.Focus();
            }
        }

        private void bt_ExcluiProduto_Click(object sender, EventArgs e)
        {
            if (Parametro_Venda.NaoAlterarVendaFaturada == true &&
                    ck_Faturado.Checked == true)
                return;

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
                    BLL_Venda = new BLL_Venda();
                    Venda = new DTO_Venda();
                    Produto_Item = new DTO_Produto_Item();
                    List<DTO_Produto_Item> _Item = new List<DTO_Produto_Item>();

                    Produto_Item.ID = lst_Produto[dg_Itens.CurrentRow.Index].ID;
                    Produto_Item.ID_Produto = lst_Produto[dg_Itens.CurrentRow.Index].ID_Produto;
                    Produto_Item.ID_Grade = lst_Produto[dg_Itens.CurrentRow.Index].ID_Grade;

                    _Item.Add(Produto_Item);

                    Venda.Item = _Item;

                    BLL_Venda.Exclui_Item(Venda);

                    Busca_Item(Convert.ToInt32(txt_ID.Text));
                }
                else
                {
                    lst_Produto.RemoveAt(dg_Itens.CurrentRow.Index);

                    Carrega_Item(lst_Produto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

            SomaItens();
            SomaVenda();

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

            cb_ID_Tabela.SelectedValue = lst_Produto[dg_Itens.CurrentRow.Index].ID_Tabela;
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
                UI_NFe_Emissor_Completo.ID_Pedido = Convert.ToInt32(txt_ID.Text);

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
            Emite_CFe();
        }

        private void bt_Resumo_Click(object sender, EventArgs e)
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

        private void cb_ID_Tabela_SelectedValueChanged(object sender, EventArgs e)
        {/*
            try
            {
                if (cb_ID_Tabela.SelectedValue.GetType() == typeof(int) &&
                    dg_Itens.Rows.Count > 0 &&
                    cb_ID_Tabela.Focus() == true)
                {
                    if (Convert.ToInt32(cb_ID_Tabela.SelectedValue) != intTabelaValor)
                    {
                        DialogResult msgbox = MessageBox.Show("Alterar Tabela de Valor?", "Valor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msgbox == DialogResult.No)
                            return;

                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();
                        double Valor = 0;
                        for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                        {
                            Produto.ID = Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value);
                            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            Produto.Situacao = Parametros.SituacaoLiberada;
                            Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                            Produto.Tipo = 1;

                            DT = BLL_Produto.Busca_Valor(Produto);
                            DR = DT.Rows[0];

                            if (Convert.ToBoolean(DR["UtilizarValorPromocao"]) == true)
                                Valor = Convert.ToDouble(DR["ValorPromocional"]);
                            else
                                Valor = Convert.ToDouble(DR["ValorVenda"]);

                            if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_TipoVenda"].Value) != Parametros.TipoVendaProduto)
                            {
                                dg_Itens.Rows[i].Cells["col_Valor"].Value = 0;
                                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = 0;
                                dg_Itens.Rows[i].Cells["col_ID_Tabela"].Value = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                            }
                            else
                            {
                                dg_Itens.Rows[i].Cells["col_Valor"].Value = Valor;
                                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = (Valor + Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Acrescimo"].Value)) - Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Desconto"].Value);
                                dg_Itens.Rows[i].Cells["col_ID_Tabela"].Value = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

                            }
                        }
                    }
                    SomaItens();
                    SomaPedido();
                }
            }
            catch (Exception)
            {
            }
          */
        }

        private void cb_Pagamento_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaParcelamento();
        }

        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Pessoa.SelectedValue != null &&
                Convert.ToInt32(cb_ID_Pessoa.SelectedValue) != Parametro_Venda.ID_ConsumidorFinal)
                Verifica_CReceber(util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString()));

            if (txt_Informacao_Venda.Text.Trim() != string.Empty)
                MessageBox.Show("ATENÇÃO\n" + DRPessoa["Informacao_Venda"].ToString(), this.Text);
        }

        private void cb_ID_Produto_Leave(object sender, EventArgs e)
        {
            Verifica_Desconto();
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
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

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Busca_Item(util_dados.Verifica_int(txt_ID.Text));
            Config(StatusForm.Consulta);
        }

        private void txt_ID_Parcelamento_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID_Parcelamento.Text) > 0)
                cb_ID_Parcelamento.SelectedValue = Convert.ToInt32(txt_ID_Parcelamento.Text);
        }

        private void txt_CNPJ_CPF_Leave(object sender, EventArgs e)
        {
            if (txt_CNPJ_CPF.Text != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
                {
                    cb_ID_Pessoa.SelectedIndex = -1;
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CNPJ_CPF.Clear();
                    cb_ID_Pessoa.SelectedValue = Parametro_Venda.ID_ConsumidorFinal;
                    return;
                }

                if (txt_CNPJ_CPF.Text.Length == 11)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CPF);
                else if (txt_CNPJ_CPF.Text.Length == 14)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CNPJ);

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 1;
                Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca(Pessoa);

                if (_DT.Rows.Count > 0)
                    cb_ID_Pessoa.SelectedValue = Convert.ToInt32(_DT.Rows[0]["ID_Pessoa"]);
            }
            else
            {
                cb_ID_Pessoa.SelectedIndex = -1;
                cb_ID_Pessoa.SelectedValue = Parametro_Venda.ID_ConsumidorFinal;
            }
        }

        private void txt_CPF_CNPJ_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cb_ID_Pessoa.SelectedValue) == Parametro_Venda.ID_ConsumidorFinal &&
                util_dados.Conf_strDoc_NFe(txt_CPF_CNPJ.Text.Replace("0", "")) != string.Empty)
                txt_CNPJ_CPF.Text = txt_CPF_CNPJ.Text;
            else
                Busca_Pessoa(Convert.ToInt32(cb_ID_Pessoa.SelectedValue));
        }
        #endregion

        #region MASKEDBOX
        private void mk_Entrega_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Entrega.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Entrega.Text = Convert.ToString(DateTime.Now);
                mk_Entrega.Focus();
            }
        }

        private void mk_DataFatura_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataFatura.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFatura.Text = Convert.ToString(DateTime.Now);
                mk_DataFatura.Focus();
            }

        }

        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
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

        #region CHECKBOX
        private void ck_Faturado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Faturado.Checked == true &&
                ck_NFe.Checked == false)
            {
                bt_NotaFiscal.Enabled = true;
                bt_GerarNFCE.Enabled = true;
            }
            else
            {
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
                bt_Edita.Enabled = false;
                lb_Cancelamento.Text = "VENDA CANCELADA";
            }
            else
            {
                bt_NotaFiscal.Enabled = true;
                bt_Edita.Enabled = true;
                lb_Cancelamento.Text = "";
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

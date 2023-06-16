using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFCe_Emissor_Completo : Sistema.UI.UI_Modelo
    {
        public UI_NFCe_Emissor_Completo()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NF_TipoEmissao BLL_NF_TipoEmissao;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Parametro BLL_Parametro;
        BLL_Venda BLL_Venda;
        BLL_NF BLL_NF;
        BLL_Municipio BLL_Municipio;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;

        DataTable DT_Pessoa;
        DataTable DT_TipoEmissao;
        DataTable DTPessoa;
        DataTable DTEndereco;
        DataTable DTTelefone;

        DataRow DR;
        DataRow DRPessoa;
        DataRow DREndereco;
        DataRow DRTelefone;

        int obj;

        bool Edita_Vol = false;
        bool Edita_Dup = false;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Parametro Parametro;
        DTO_Venda Venda;

        DTO_NF_TipoEmissao NF_TipoEmissao;
        DTO_Municipio Municipio;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Produto_Item Produto_Item;
        DTO_TabelaValor TabelaValor;
        DTO_NF_Transporte NF_Transporte;
        DTO_NF_Volume NF_Volume;
        DTO_NF_Cobranca NF_Cobranca;
        DTO_NF_Duplicata NF_Duplicata;
        DTO_NF_Ent_Ret NF_Ent_Ret;

        /// <summary>
        /// ESTRUTURA PRINCIPAL
        /// </summary>
        DTO_NF NF_ESTRUTURA;

        DTO_NF NF;
        #endregion

        #region PROPRIEDADES
        public bool NF_Venda { get; set; }
        public bool NF_Devolucao { get; set; }
        public int ID_Pedido { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "EMISSÃO DE NF-e";

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            bt_Proximo.Enabled = true;
            bt_Anterior.Enabled = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID_NFe";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Emissao = new DataGridViewTextBoxColumn();
            col_Emissao.DataPropertyName = "DataEmissao";
            col_Emissao.HeaderText = "EMISSÃO";
            col_Emissao.Width = 75;
            col_Emissao.DefaultCellStyle.Format = "d";
            DG.Columns.Add(col_Emissao);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "DescricaoPessoa";
            col_Descricao.HeaderText = "PESSOA";
            col_Descricao.Width = 400;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Situacao = new DataGridViewTextBoxColumn();
            col_Situacao.DataPropertyName = "DescricaoSituacao";
            col_Situacao.HeaderText = "SITUAÇÃO";
            col_Situacao.Width = 200;
            DG.Columns.Add(col_Situacao);

            DataGridViewTextBoxColumn col_Natureza = new DataGridViewTextBoxColumn();
            col_Natureza.DataPropertyName = "NaturezaOperacao";
            col_Natureza.HeaderText = "NATUREZA";
            col_Natureza.Width = 350;
            DG.Columns.Add(col_Natureza);

            Carrega_CB();
            Carrega_Parametros();

            Limpa_Campo();

            NF_ESTRUTURA = new DTO_NF();

            if (NF_Venda == true)
                Carrega_Venda(ID_Pedido);

            Carrega_NumeroNFC();
        }

        private void Carrega_CB()
        {
            DataTable _DT;

            #region PAGAMENTO
            DataTable _Pagamento;
            _Pagamento = new DataTable();
            _Pagamento.Columns.Add("ID");
            _Pagamento.Columns.Add("Descricao");

            DR = _Pagamento.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - PAGAMENTO À VISTA";
            _Pagamento.Rows.Add(DR);
            _Pagamento.AcceptChanges();
            DR = _Pagamento.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - PAGAMENTO À PRAZO";
            _Pagamento.Rows.Add(DR);
            _Pagamento.AcceptChanges();
            DR = _Pagamento.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - OUTROS";
            _Pagamento.Rows.Add(DR);
            _Pagamento.AcceptChanges();
            util_dados.CarregaCombo(_Pagamento, "Descricao", "ID", cb_FormaPagto);
            #endregion

            #region MODALIDADE FRETE
            DataTable _ModFrete;
            _ModFrete = new DataTable();
            _ModFrete.Columns.Add("ID");
            _ModFrete.Columns.Add("Descricao");

            DR = _ModFrete.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - POR CONTA DO EMITENTE";
            _ModFrete.Rows.Add(DR);
            _ModFrete.AcceptChanges();
            DR = _ModFrete.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - POR CONTA DO DESTINATÁRIO";
            _ModFrete.Rows.Add(DR);
            _ModFrete.AcceptChanges();
            DR = _ModFrete.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - POR CONTA DE TERCEIROS";
            _ModFrete.Rows.Add(DR);
            _ModFrete.AcceptChanges();
            DR = _ModFrete.NewRow();
            DR["ID"] = "9";
            DR["Descricao"] = "9 - SEM FRETE";
            _ModFrete.Rows.Add(DR);
            _ModFrete.AcceptChanges();
            util_dados.CarregaCombo(_ModFrete, "Descricao", "ID", cb_TipoFrete);
            #endregion

            #region TIPO DE ATENDIMENTO
            DataTable _PresencaConsumidor;
            _PresencaConsumidor = new DataTable();
            _PresencaConsumidor.Columns.Add("ID");
            _PresencaConsumidor.Columns.Add("Descricao");

            DR = _PresencaConsumidor.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - NÃO SE APLICA";
            _PresencaConsumidor.Rows.Add(DR);
            _PresencaConsumidor.AcceptChanges();
            DR = _PresencaConsumidor.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - OPERAÇÃO PRESENCIAL";
            _PresencaConsumidor.Rows.Add(DR);
            _PresencaConsumidor.AcceptChanges();
            DR = _PresencaConsumidor.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - OPERAÇÃO NÃO PRESENCIAL (INTERNET)";
            _PresencaConsumidor.Rows.Add(DR);
            _PresencaConsumidor.AcceptChanges();
            DR = _PresencaConsumidor.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "3 - OPERAÇÃO NÃO PRESENCIAL (TELEATENDIMENTO)";
            _PresencaConsumidor.Rows.Add(DR);
            _PresencaConsumidor.AcceptChanges();
            DR = _PresencaConsumidor.NewRow();
            DR["ID"] = "9";
            DR["Descricao"] = "9 - OPERAÇÃO NÃO PRESENCIAL (OUTROS)";
            _PresencaConsumidor.Rows.Add(DR);
            _PresencaConsumidor.AcceptChanges();
            util_dados.CarregaCombo(_PresencaConsumidor, "Descricao", "ID", cb_PresencaConsumidor);
            #endregion

            #region SITUAÇÃO PESQUISA
            _DT = new DataTable();

            List<string> aux = new List<string> { "TODAS", "ASSINADA", "AUTORIZADA",
                                                  "CANCELADA", "DENEGADA", "EM DIGITAÇÃO",
                                                  "VALIDADA", "EM PROCESSAMENTO" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoNFeP);
            #endregion

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
        }

        private void Carrega_Pessoa(int Tipo)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                Pessoa.FiltraEmpresa = true;

                switch (Tipo)
                {
                    case 1:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                        DT_Pessoa = BLL_Pessoa.Busca_Nome(Pessoa);

                        util_dados.CarregaCombo(DT_Pessoa, "Descricao", "ID", cb_ID_Pessoa);
                        cb_ID_Pessoa.SelectedIndex = -1;

                        txt_CNPJ_CPF.Text = string.Empty;
                        txt_Telefone.Text = string.Empty;
                        txt_Logradouro.Text = string.Empty;
                        txt_Numero.Text = string.Empty;
                        txt_Bairro.Text = string.Empty;
                        txt_Municipio_UF.Text = string.Empty;
                        break;

                    case 2:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

                        DT_Pessoa = BLL_Pessoa.Busca_Nome(Pessoa);

                        util_dados.CarregaCombo(DT_Pessoa, "Descricao", "ID", cb_ID_PessoaP);
                        cb_ID_PessoaP.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Carrega_NF(int _ID)
        {
            try
            {
                DataTable _DT;

                BLL_NF = new BLL_NF();

                NF_ESTRUTURA = new DTO_NF();
                DTO_NF _NF = new DTO_NF();

                _NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                _NF.ID = _ID;
                _NF.Modelo = 65;

                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF(_NF);

                #region DADOS DA NOTA FISCAL
                NF_ESTRUTURA.ID = Convert.ToInt32(_DT.Rows[0]["ID"]);
                NF_ESTRUTURA.ID_Empresa = Convert.ToInt32(_DT.Rows[0]["ID_Empresa"]);
                NF_ESTRUTURA.Serie = Convert.ToInt32(_DT.Rows[0]["Serie"]);
                NF_ESTRUTURA.ID_NFe = Convert.ToInt32(_DT.Rows[0]["ID_NFe"]);
                NF_ESTRUTURA.DataEmissao = Convert.ToDateTime(_DT.Rows[0]["DataEmissao"]);
                NF_ESTRUTURA.DataSaida = Convert.ToDateTime(_DT.Rows[0]["DataSaida"]);
                NF_ESTRUTURA.DataContigencia = Convert.ToDateTime(_DT.Rows[0]["DataContigencia"]);
                NF_ESTRUTURA.TipoDocumento = Convert.ToInt32(_DT.Rows[0]["TipoDocumento"]);
                NF_ESTRUTURA.FinalidadeEmissao = Convert.ToInt32(_DT.Rows[0]["FinalidadeEmissao"]);
                NF_ESTRUTURA.FormaEmissao = Convert.ToInt32(_DT.Rows[0]["FormaEmissao"]);
                NF_ESTRUTURA.FormaPagto = Convert.ToInt32(_DT.Rows[0]["FormaPagto"]);
                NF_ESTRUTURA.TipoImpressao = Convert.ToInt32(_DT.Rows[0]["TipoImpressao"]);
                NF_ESTRUTURA.TipoFrete = Convert.ToInt32(_DT.Rows[0]["TipoFrete"]);
                NF_ESTRUTURA.Situacao = Convert.ToInt32(_DT.Rows[0]["Situacao"]);
                NF_ESTRUTURA.TipoPessoa = Convert.ToInt32(_DT.Rows[0]["TipoPessoa"]);
                NF_ESTRUTURA.ID_Pessoa = Convert.ToInt32(_DT.Rows[0]["ID_Pessoa"]);
                NF_ESTRUTURA.Dig_Verificador = Convert.ToInt32(_DT.Rows[0]["Dig_Verificador"]);
                NF_ESTRUTURA.IE_Substituicao = Convert.ToInt32(_DT.Rows[0]["IE_Substituicao"]);
                NF_ESTRUTURA.ConsumidorFinal = Convert.ToInt32(_DT.Rows[0]["ConsumidorFinal"]);
                NF_ESTRUTURA.PresencaConsumidor = Convert.ToInt32(_DT.Rows[0]["PresencaConsumidor"]);

                NF_ESTRUTURA.ValorBC = Convert.ToDouble(_DT.Rows[0]["ValorBC"]);
                NF_ESTRUTURA.ValorICMS = Convert.ToDouble(_DT.Rows[0]["ValorICMS"]);
                NF_ESTRUTURA.ValorICMSDesonerado = Convert.ToDouble(_DT.Rows[0]["ValorICMSDesonerado"]);
                NF_ESTRUTURA.ValorBCST = Convert.ToDouble(_DT.Rows[0]["ValorBCST"]);
                NF_ESTRUTURA.ValorST = Convert.ToDouble(_DT.Rows[0]["ValorST"]);
                NF_ESTRUTURA.ValorProduto = Convert.ToDouble(_DT.Rows[0]["ValorProduto"]);
                NF_ESTRUTURA.ValorFrete = Convert.ToDouble(_DT.Rows[0]["ValorFrete"]);
                NF_ESTRUTURA.ValorSeguro = Convert.ToDouble(_DT.Rows[0]["ValorSeguro"]);
                NF_ESTRUTURA.ValorDesconto = Convert.ToDouble(_DT.Rows[0]["ValorDesconto"]);
                NF_ESTRUTURA.ValorImportacao = Convert.ToDouble(_DT.Rows[0]["ValorImportacao"]);
                NF_ESTRUTURA.ValorIPI = Convert.ToDouble(_DT.Rows[0]["ValorIPI"]);
                NF_ESTRUTURA.ValorPIS = Convert.ToDouble(_DT.Rows[0]["ValorPIS"]);
                NF_ESTRUTURA.ValorCOFINS = Convert.ToDouble(_DT.Rows[0]["ValorCOFINS"]);
                NF_ESTRUTURA.ValorOutro = Convert.ToDouble(_DT.Rows[0]["ValorOutro"]);
                NF_ESTRUTURA.ValorTotal = Convert.ToDouble(_DT.Rows[0]["ValorTotal"]);

                NF_ESTRUTURA.NaturezaOperacao = _DT.Rows[0]["NaturezaOperacao"].ToString();
                NF_ESTRUTURA.Justificativa = _DT.Rows[0]["Justificativa"].ToString();
                NF_ESTRUTURA.InformacaoAdicional = _DT.Rows[0]["InformacaoAdicional"].ToString();
                NF_ESTRUTURA.DescricaoSituacao = _DT.Rows[0]["DescricaoSituacao"].ToString();
                NF_ESTRUTURA.InformacaoFisco = _DT.Rows[0]["InformacaoFisco"].ToString();
                #endregion

                #region AUTORIZACAO XML
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_AutorizadoXML(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Autorizacao_XML = new List<DTO_NF_Autorizacao_XML>();
                    DTO_NF_Autorizacao_XML _AutorizaXML;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _AutorizaXML = new DTO_NF_Autorizacao_XML();
                        _AutorizaXML.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _AutorizaXML.CNPJ_CPF = _DT.Rows[i]["CNPJ_CPF"].ToString();

                        NF_ESTRUTURA.Autorizacao_XML.Add(_AutorizaXML);
                    }
                }
                #endregion

                #region NOTAS REFERENCIADAS
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Referenciada(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Referenciada = new List<DTO_NF_Referenciada>();
                    DTO_NF_Referenciada _Referenciada;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Referenciada = new DTO_NF_Referenciada();
                        _Referenciada.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Referenciada.Tipo = Convert.ToInt32(_DT.Rows[i]["Tipo"]);
                        if (_Referenciada.Tipo == 2 ||
                            _Referenciada.Tipo == 3)
                        {
                            _Referenciada.DataEmissao = Convert.ToDateTime(_DT.Rows[i]["DataEmissao"]);
                            _Referenciada.Modelo = _DT.Rows[i]["Modelo"].ToString();
                            _Referenciada.Serie = _DT.Rows[i]["Serie"].ToString();
                            _Referenciada.Numero_NF = _DT.Rows[i]["Numero_NF"].ToString();
                            _Referenciada.CNPJ_CPF = _DT.Rows[i]["CNPJ_CPF"].ToString();
                            _Referenciada.IE = _DT.Rows[i]["IE"].ToString();
                            _Referenciada.UF = _DT.Rows[i]["UF"].ToString();
                        }
                        _Referenciada.Chave_NFe = _DT.Rows[i]["Chave_NFe"].ToString();

                        _Referenciada.CTE = _DT.Rows[i]["CTE"].ToString();

                        _Referenciada.Mod_CupomFiscal = _DT.Rows[i]["Mod_CupomFiscal"].ToString();
                        _Referenciada.ECF = _DT.Rows[i]["ECF"].ToString();
                        _Referenciada.Numero_Contador = _DT.Rows[i]["Numero_Contador"].ToString();

                        NF_ESTRUTURA.Referenciada.Add(_Referenciada);
                    }
                }
                #endregion

                #region ENTRADA RETIRADA
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Ent_Ret(_NF);

                if (_DT.Rows.Count == 1)
                {
                    NF_ESTRUTURA.Ent_Ret = new List<DTO_NF_Ent_Ret>();
                    DTO_NF_Ent_Ret _Ent_Ret;
                    _Ent_Ret = new DTO_NF_Ent_Ret();
                    _Ent_Ret.ID = Convert.ToInt32(_DT.Rows[0]["ID"]);
                    _Ent_Ret.Tipo = Convert.ToInt32(_DT.Rows[0]["Tipo"]);
                    _Ent_Ret.ID_UF = Convert.ToInt32(_DT.Rows[0]["ID_UF"]);
                    _Ent_Ret.ID_Municipio = Convert.ToInt32(_DT.Rows[0]["ID_Municipio"]);
                    _Ent_Ret.CNPJ_CPF = _DT.Rows[0]["CNPJ_CPF"].ToString();
                    _Ent_Ret.Logradouro = _DT.Rows[0]["Logradouro"].ToString();
                    _Ent_Ret.Numero = _DT.Rows[0]["Numero"].ToString();
                    _Ent_Ret.Complemento = _DT.Rows[0]["Complemento"].ToString();
                    _Ent_Ret.Bairro = _DT.Rows[0]["Bairro"].ToString();

                    NF_ESTRUTURA.Ent_Ret.Add(_Ent_Ret);
                }
                #endregion

                #region VOLUMES
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Volume(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Volume = new List<DTO_NF_Volume>();
                    DTO_NF_Volume _Volume;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Volume = new DTO_NF_Volume();
                        _Volume.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Volume.Quantidade = Convert.ToDouble(_DT.Rows[i]["Quantidade"]);
                        _Volume.Especie = _DT.Rows[i]["Especie"].ToString();
                        _Volume.Marca = _DT.Rows[i]["Marca"].ToString();
                        _Volume.Numeracao = _DT.Rows[i]["Numeracao"].ToString();
                        _Volume.PesoB = Convert.ToDouble(_DT.Rows[i]["PesoB"]);
                        _Volume.PesoL = Convert.ToDouble(_DT.Rows[i]["PesoL"]);

                        NF_ESTRUTURA.Volume.Add(_Volume);
                    }
                }
                #endregion

                #region TRANSPORTADORA
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Transp(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Transporte = new List<DTO_NF_Transporte>();
                    DTO_NF_Transporte _Transporte;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Transporte = new DTO_NF_Transporte();
                        _Transporte.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Transporte.ID_Pessoa = Convert.ToInt32(_DT.Rows[i]["ID_PessoaT"]);
                        _Transporte.IE = _DT.Rows[i]["IE"].ToString();
                        _Transporte.CNPJ_CPF = _DT.Rows[i]["CNPJ_CPF"].ToString();
                        _Transporte.Nome = _DT.Rows[i]["Nome"].ToString();
                        _Transporte.Endereco = _DT.Rows[i]["Endereco"].ToString();
                        _Transporte.Municipio = _DT.Rows[i]["Municipio"].ToString();
                        _Transporte.UF = _DT.Rows[i]["UF"].ToString();

                        NF_ESTRUTURA.Transporte.Add(_Transporte);
                    }
                }
                #endregion

                #region COBRANÇA
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Cobranca(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Cobranca = new List<DTO_NF_Cobranca>();
                    DTO_NF_Cobranca _Cobranca;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Cobranca = new DTO_NF_Cobranca();
                        _Cobranca.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Cobranca.NumeroFatura = _DT.Rows[i]["NumeroFatura"].ToString();
                        _Cobranca.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);
                        _Cobranca.Desconto = Convert.ToDouble(_DT.Rows[i]["Desconto"]);
                        _Cobranca.ValorFinal = Convert.ToDouble(_DT.Rows[i]["ValorFinal"]);

                        NF_ESTRUTURA.Cobranca.Add(_Cobranca);
                    }
                }
                #endregion

                #region DUPLICATA
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Duplicata(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Duplicata = new List<DTO_NF_Duplicata>();
                    DTO_NF_Duplicata _Duplicata;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Duplicata = new DTO_NF_Duplicata();
                        _Duplicata.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Duplicata.NumeroDuplicata = _DT.Rows[i]["NumeroDuplicata"].ToString();
                        _Duplicata.Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);
                        _Duplicata.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);

                        NF_ESTRUTURA.Duplicata.Add(_Duplicata);
                    }
                }
                #endregion

                #region ITENS
                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_Item(_NF);

                if (_DT.Rows.Count > 0)
                {
                    NF_ESTRUTURA.Itens = new List<DTO_NF_Itens>();
                    DTO_NF_Itens _Item;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Item = new DTO_NF_Itens();
                        _Item.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _Item.ID_Produto = Convert.ToInt32(_DT.Rows[i]["ID_Produto"]);
                        _Item.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_Grade"]);
                        _Item.ID_Tabela = Convert.ToInt32(_DT.Rows[i]["ID_Tabela"]);
                        _Item.Quantidade = Convert.ToDouble(_DT.Rows[i]["Quantidade"]);
                        _Item.ValorUnitario = Convert.ToDouble(_DT.Rows[i]["ValorUnitario"]);
                        _Item.ValorTotal = Convert.ToDouble(_DT.Rows[i]["ValorTotal"]);
                        _Item.Acrescimo = Convert.ToDouble(_DT.Rows[i]["Acrescimo"]);
                        _Item.Desconto = Convert.ToDouble(_DT.Rows[i]["Desconto"]);
                        _Item.TipoVendaProduto = Convert.ToInt32(_DT.Rows[i]["TipoVendaProduto"]);
                        _Item.Frete = Convert.ToDouble(_DT.Rows[i]["Frete"]);
                        _Item.Seguro = Convert.ToDouble(_DT.Rows[i]["Seguro"]);

                        _Item.Descricao = _DT.Rows[i]["DescricaoProduto"].ToString();
                        _Item.InformacaoAdicional = _DT.Rows[i]["InformacaoAdicional"].ToString();
                        _Item.CFOP = _DT.Rows[i]["CFOP"].ToString();
                        _Item.Quantidade_Selo = Convert.ToInt32(_DT.Rows[i]["Quantidade_Selo"]);
                        _Item.ClasseEnquadramento = _DT.Rows[i]["ClasseEnquadramento"].ToString();
                        _Item.CNPJProdutor = _DT.Rows[i]["CNPJProdutor"].ToString();

                        _Item.Codigo_Selo = _DT.Rows[i]["Codigo_Selo"].ToString();
                        _Item.EX_TIPI = _DT.Rows[i]["EX_TIPI"].ToString();
                        _Item.CSTIPI = _DT.Rows[i]["CSTIPI"].ToString();
                        _Item.AliquotaIPI = Convert.ToDouble(_DT.Rows[i]["AliquotaIPI"]);
                        _Item.ValorIPI = Convert.ToDouble(_DT.Rows[i]["ValorIPI"]);
                        _Item.IPIDevolvido = Convert.ToDouble(_DT.Rows[i]["IPIDevolvido"]);
                        _Item.Per_IPIDevolvido = Convert.ToDouble(_DT.Rows[i]["Per_IPIDevolvido"]);

                        _Item.CST = _DT.Rows[i]["CST"].ToString();
                        _Item.Origem = Convert.ToInt32(_DT.Rows[i]["Origem"]);
                        _Item.ModalidadeBC = Convert.ToInt32(_DT.Rows[i]["ModalidadeBC"]);
                        _Item.ModalidadeBCST = Convert.ToInt32(_DT.Rows[i]["ModalidadeBCST"]);
                        _Item.AliquotaICMS = Convert.ToDouble(_DT.Rows[i]["AliquotaICMS"]);
                        _Item.AliquotaICMSST = Convert.ToDouble(_DT.Rows[i]["AliquotaICMSST"]);
                        _Item.PercentualReducao = Convert.ToDouble(_DT.Rows[i]["PercentualReducao"]);
                        _Item.PercentualReducaoST = Convert.ToDouble(_DT.Rows[i]["PercentualReducaoST"]);
                        _Item.MargemVLAdicionado = Convert.ToDouble(_DT.Rows[i]["MargemVLAdicionado"]);
                        _Item.ValorICMS = Convert.ToDouble(_DT.Rows[i]["ValorICMS"]);
                        _Item.ValorICMSST = Convert.ToDouble(_DT.Rows[i]["ValorICMSST"]);
                        _Item.ValorICMSSTRet = Convert.ToDouble(_DT.Rows[i]["ValorICMSSTRet"]);
                        _Item.ValorBC = Convert.ToDouble(_DT.Rows[i]["ValorBC"]);
                        _Item.ValorBCST = Convert.ToDouble(_DT.Rows[i]["ValorBCST"]);
                        _Item.ValorBCSTRet = Convert.ToDouble(_DT.Rows[i]["ValorBCSTRet"]);
                        _Item.ValorICMSOperacao = Convert.ToDouble(_DT.Rows[i]["ValorICMSOperacao"]);
                        _Item.PercentualDiferimento = Convert.ToDouble(_DT.Rows[i]["PercentualDiferimento"]);
                        _Item.ValorICMSDeferido = Convert.ToDouble(_DT.Rows[i]["ValorICMSDeferido"]);
                        _Item.ValorICMSDesonerado = Convert.ToDouble(_DT.Rows[i]["ValorICMSDesonerado"]);
                        _Item.MotivoDesonerado = Convert.ToInt32(_DT.Rows[i]["MotivoDesonerado"]);

                        _Item.CSOSN = _DT.Rows[i]["CSOSN"].ToString();
                        _Item.AliquotaCredito = Convert.ToDouble(_DT.Rows[i]["AliquotaCredito"]);
                        _Item.ValorCredito = Convert.ToDouble(_DT.Rows[i]["ValorCredito"]);

                        _Item.ValorBCII = Convert.ToDouble(_DT.Rows[i]["ValorBCII"]);
                        _Item.ValorDesII = Convert.ToDouble(_DT.Rows[i]["ValorDesII"]);
                        _Item.ValorII = Convert.ToDouble(_DT.Rows[i]["ValorII"]);
                        _Item.ValorIOF = Convert.ToDouble(_DT.Rows[i]["ValorIOF"]);

                        _Item.CSTPIS = _DT.Rows[i]["CSTPIS"].ToString();
                        _Item.AliquotaPIS = Convert.ToDouble(_DT.Rows[i]["AliquotaPIS"]);
                        _Item.ValorAliquotaPIS = Convert.ToDouble(_DT.Rows[i]["ValorAliquotaPIS"]);
                        _Item.ValorPIS = Convert.ToDouble(_DT.Rows[i]["ValorPIS"]);

                        _Item.CSTCOFINS = _DT.Rows[i]["CSTCOFINS"].ToString();
                        _Item.AliquotaCOFINS = Convert.ToDouble(_DT.Rows[i]["AliquotaCOFINS"]);
                        _Item.ValorAliquotaCOFINS = Convert.ToDouble(_DT.Rows[i]["ValorAliquotaCOFINS"]);
                        _Item.ValorCOFINS = Convert.ToDouble(_DT.Rows[i]["ValorCOFINS"]);

                        #region IMPORTAÇÃO
                        DataTable _DT_Importacao = new DataTable();
                        _NF.ID_NF_Item = _Item.ID;
                        _DT_Importacao = BLL_NF.Busca_NF_Importacao(_NF);

                        if (_DT_Importacao.Rows.Count > 0)
                        {
                            _Item.Importacao = new List<DTO_NF_Importacao>();
                            DTO_NF_Importacao _Importacao;
                            for (int y = 0; y <= _DT_Importacao.Rows.Count - 1; y++)
                            {
                                _Importacao = new DTO_NF_Importacao();
                                _Importacao.ID = Convert.ToInt32(_DT_Importacao.Rows[y]["ID"]);
                                _Importacao.UF = Convert.ToInt32(_DT_Importacao.Rows[y]["UF"]);
                                _Importacao.Data_Desen = Convert.ToDateTime(_DT_Importacao.Rows[y]["Data_Desen"]);
                                _Importacao.Data_Registro = Convert.ToDateTime(_DT_Importacao.Rows[y]["Data_Registro"]);

                                _Importacao.Documento = _DT_Importacao.Rows[y]["Documento"].ToString();
                                _Importacao.Local = _DT_Importacao.Rows[y]["Local"].ToString();
                                _Importacao.Codigo = _DT_Importacao.Rows[y]["Codigo"].ToString();

                                #region ADIÇÃO
                                DataTable _DT_Adicao = new DataTable();
                                _NF.ID_NF_Importacao = _Importacao.ID;
                                _DT_Adicao = BLL_NF.Busca_NF_Adicao(_NF);

                                if (_DT_Adicao.Rows.Count > 0)
                                {
                                    _Importacao.Adicao = new List<DTO_NF_Adicao>();
                                    DTO_NF_Adicao _Adicao;
                                    for (int x = 0; x <= _DT_Adicao.Rows.Count - 1; x++)
                                    {
                                        _Adicao = new DTO_NF_Adicao();
                                        _Adicao.ID = Convert.ToInt32(_DT_Adicao.Rows[x]["ID"]);
                                        _Adicao.Numero = Convert.ToInt32(_DT_Adicao.Rows[x]["Numero"]);
                                        _Adicao.Seq = Convert.ToInt32(_DT_Adicao.Rows[x]["Seq"]);
                                        _Adicao.Codigo = _DT_Adicao.Rows[x]["Codigo"].ToString();
                                        _Adicao.Desconto = Convert.ToDouble(_DT_Adicao.Rows[x]["Desconto"]);

                                        _Importacao.Adicao.Add(_Adicao);
                                    }
                                }
                                #endregion

                                _Item.Importacao.Add(_Importacao);
                            }
                        }
                        #endregion

                        NF_ESTRUTURA.Itens.Add(_Item);
                    }
                }
                #endregion

                cb_TipoPessoa.SelectedValue = NF_ESTRUTURA.TipoPessoa;
                cb_ID_Pessoa.SelectedValue = NF_ESTRUTURA.ID_Pessoa;

                txt_DescricaoSituacao.Text = NF_ESTRUTURA.DescricaoSituacao;

                Exibe_Duplicata();
                Exibe_Item();

                Calcula_NF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_Venda(int _ID_Venda)
        {
            try
            {
                if (NF_ESTRUTURA.Itens == null)
                    NF_ESTRUTURA.Itens = new List<DTO_NF_Itens>();

                BLL_NF = new BLL_NF();
                BLL_Venda = new BLL_Venda();

                Venda = new DTO_Venda();

                Venda.ID = _ID_Venda;

                DataTable _DT_Venda = new DataTable();
                _DT_Venda = BLL_Venda.Busca(Venda);

                if (_DT_Venda.Rows.Count == 0)
                    return;

                util_dados.LimpaCampos(this, gb_Pessoa);

                cb_TipoPessoa.SelectedValue = Convert.ToInt32(_DT_Venda.Rows[0]["TipoPessoa"]);
                cb_ID_Pessoa.SelectedValue = Convert.ToInt32(_DT_Venda.Rows[0]["ID_Pessoa"]);

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.ID = _ID_Venda;
                Venda.ID_UF = util_dados.Verifica_int(txt_ID_UF.Text);
                Venda.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

                #region BUSCA ITEM VENDA
                DTO_NF_Itens _NF_Item;
                DataTable _DT_Item = new DataTable();
                _DT_Item = BLL_Venda.Busca_Item_NF(Venda);

                if (_DT_Item.Rows.Count > 0)
                    for (int i = 0; i <= _DT_Item.Rows.Count - 1; i++)
                    {
                        _NF_Item = new DTO_NF_Itens();

                        #region CRIA BASE DE CALCULO
                        double vlr_Produto = Convert.ToDouble(_DT_Item.Rows[i]["ValorProduto"]);
                        double vlr_Desconto = Convert.ToDouble(_DT_Item.Rows[i]["Desconto"]);
                        double vlr_Seguro = 0;
                        double vlr_Frete = 0;
                        double vlr_Acrescimo = Convert.ToDouble(_DT_Item.Rows[i]["Acrescimo"]);

                        double Quantidade = Convert.ToDouble(_DT_Item.Rows[i]["Quantidade"]);

                        double vlr_TotalProduto = Quantidade * ((vlr_Produto + vlr_Acrescimo) - vlr_Desconto);

                        double vlr_BC = (vlr_TotalProduto + vlr_Seguro + vlr_Frete);
                        #endregion

                        _NF_Item.ID = 0;
                        _NF_Item.ID_Produto = Convert.ToInt32(_DT_Item.Rows[i]["ID_Produto"]);
                        _NF_Item.Quantidade = Convert.ToDouble(_DT_Item.Rows[i]["Quantidade"]);
                        _NF_Item.ID_Tabela = Convert.ToInt32(_DT_Item.Rows[i]["ID_Tabela"]);

                        _NF_Item.Descricao = _DT_Item.Rows[i]["DescricaoProduto"].ToString();
                        _NF_Item.ID_Grade = Convert.ToInt32(_DT_Item.Rows[i]["ID_Grade"]);


                        if (Parametro_NFe_NFC_SAT.Exibe_Desconto == true)
                        {
                            _NF_Item.ValorUnitario = Convert.ToDouble(vlr_Produto + vlr_Acrescimo);
                            _NF_Item.ValorTotal = Convert.ToDouble(_DT_Item.Rows[i]["ValorTotal"]);
                            _NF_Item.Desconto = Convert.ToDouble(_DT_Item.Rows[i]["Desconto"]);
                        }
                        else
                        {
                            _NF_Item.ValorUnitario = Convert.ToDouble(_DT_Item.Rows[i]["valorVenda"]);
                            _NF_Item.ValorTotal = Convert.ToDouble(_DT_Item.Rows[i]["ValorTotal"]);
                            _NF_Item.Desconto = 0;
                        }

                        _NF_Item.TipoVendaProduto = 0;
                        _NF_Item.Frete = 0;
                        _NF_Item.Seguro = 0;
                        _NF_Item.CFOP = _DT_Item.Rows[i]["CFOP"].ToString();
                        _NF_Item.InformacaoAdicional = _DT_Item.Rows[i]["Informacao"].ToString();

                        _NF_Item.Quantidade_Selo = 0; //VERIFICAR ESTA INFORMAÇÃO
                        _NF_Item.ClasseEnquadramento = _DT_Item.Rows[i]["ClasseEnquadramento"].ToString();
                        _NF_Item.CNPJProdutor = _DT_Item.Rows[i]["CNPJProdutor"].ToString();
                        _NF_Item.Codigo_Selo = _DT_Item.Rows[i]["Cod_Enquadramento"].ToString();
                        _NF_Item.EX_TIPI = _DT_Item.Rows[i]["EX_TIPI"].ToString();

                        _NF_Item.CSTIPI = _DT_Item.Rows[i]["CSTIPI"].ToString();
                        _NF_Item.AliquotaIPI = Convert.ToDouble(_DT_Item.Rows[i]["AliquotaIPI"]);
                        _NF_Item.ValorIPI = vlr_BC * (Convert.ToDouble(_DT_Item.Rows[i]["AliquotaIPI"]) / 100);

                        _NF_Item.IPIDevolvido = 0;
                        _NF_Item.Per_IPIDevolvido = 0;

                        if (Parametro_NFe_NFC_SAT.Regime_Tributario == 3)
                            _NF_Item.CST = _DT_Item.Rows[i]["CST"].ToString();
                        else
                            _NF_Item.CSOSN = _DT_Item.Rows[i]["CST"].ToString();

                        _NF_Item.Origem = Convert.ToInt32(_DT_Item.Rows[i]["Origem"]);
                        _NF_Item.ModalidadeBC = Convert.ToInt32(_DT_Item.Rows[i]["ModalidadeBC"]);
                        _NF_Item.ModalidadeBCST = Convert.ToInt32(_DT_Item.Rows[i]["ModalidadeBCST"]);
                        _NF_Item.MotivoDesonerado = 0;

                        _NF_Item.AliquotaICMS = Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]);
                        _NF_Item.AliquotaICMSST = Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]);
                        _NF_Item.PercentualReducao = Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducao"]);
                        _NF_Item.PercentualReducaoST = Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducaoST"]);
                        _NF_Item.MargemVLAdicionado = Convert.ToDouble(_DT_Item.Rows[i]["MargemVAdicionado"]);

                        if (Parametro_NFe_NFC_SAT.Regime_Tributario == 3)
                            #region REGIME NORMAL
                            switch (_NF_Item.CST)
                            {
                                case "0":
                                    _NF_Item.ValorBC = vlr_BC;
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = 0;
                                    break;
                                case "10":
                                    _NF_Item.ValorBC = vlr_BC;
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]), Convert.ToDouble(_DT_Item.Rows[i]["MargemVAdicionado"]), Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducaoST"]));
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]));
                                    _NF_Item.ValorICMSSTRet = 0;
                                    break;
                                case "20":
                                    _NF_Item.ValorBC = util_dados.CalculaBC(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducao"]));
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = 0;
                                    _NF_Item.ValorICMSDesonerado = 0;
                                    break;
                                case "30":
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]), Convert.ToDouble(_DT_Item.Rows[i]["MargemVAdicionado"]), Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducaoST"]));
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]));
                                    _NF_Item.ValorICMSSTRet = 0;
                                    _NF_Item.ValorICMSDesonerado = 0;
                                    break;
                                case "40":
                                case "41":
                                case "50":
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = 0;
                                    _NF_Item.ValorICMSDesonerado = 0;
                                    break;
                                case "51":
                                    _NF_Item.ValorBC = util_dados.CalculaBC(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducao"]));
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = 0;
                                    _NF_Item.ValorICMSOperacao = 0; //CONFIGURAR DEPOIS
                                    _NF_Item.PercentualDiferimento = 0; //CONFIGURAR DEPOIS
                                    _NF_Item.ValorICMSDeferido = 0; //CONFIGURAR DEPOIS
                                    break;
                                case "60":
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = vlr_BC;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    break;
                                case "70":
                                case "90":
                                    _NF_Item.ValorBC = util_dados.CalculaBC(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducao"]));
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]), Convert.ToDouble(_DT_Item.Rows[i]["MargemVAdicionado"]), Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducaoST"]));
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMSST"]));
                                    _NF_Item.ValorICMSSTRet = 0;
                                    _NF_Item.ValorICMSDesonerado = 0;
                                    break;
                            }
                        #endregion
                        else
                            #region SIMPLES NACIONAL
                            switch (_NF_Item.CSOSN)
                            {
                                case "101":
                                    _NF_Item.AliquotaCredito = Parametro_NFe_NFC_SAT.AliquotaICMS;
                                    _NF_Item.ValorCredito = util_dados.CalculaAliquota(vlr_BC, Parametro_NFe_NFC_SAT.AliquotaICMS);
                                    break;
                                case "102":
                                case "103":
                                case "300":
                                case "400":
                                    break;
                                case "201":
                                    _NF_Item.AliquotaCredito = Parametro_NFe_NFC_SAT.AliquotaICMS;
                                    _NF_Item.ValorCredito = util_dados.CalculaAliquota(vlr_BC, Parametro_NFe_NFC_SAT.AliquotaICMS);
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(vlr_BC, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                                    _NF_Item.ValorICMSSTRet = 0;
                                    break;
                                case "202":
                                case "203":
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(vlr_BC, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                                    _NF_Item.ValorICMSSTRet = 0;
                                    break;
                                case "500":
                                    _NF_Item.ValorBC = 0;
                                    _NF_Item.ValorBCST = 0;
                                    _NF_Item.ValorBCSTRet = vlr_BC;
                                    _NF_Item.ValorICMS = 0;
                                    _NF_Item.ValorICMSST = 0;
                                    _NF_Item.ValorICMSSTRet = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    break;
                                case "900":
                                    _NF_Item.AliquotaCredito = Parametro_NFe_NFC_SAT.AliquotaICMS;
                                    _NF_Item.AliquotaCredito = util_dados.CalculaAliquota(vlr_BC, Parametro_NFe_NFC_SAT.AliquotaICMS);
                                    _NF_Item.ValorBC = util_dados.CalculaBC(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["PercentualReducao"]));
                                    _NF_Item.ValorBCST = util_dados.CalculaBCST(vlr_BC, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                                    _NF_Item.ValorBCSTRet = 0;
                                    _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaICMS"]));
                                    _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(vlr_BC, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                                    _NF_Item.ValorICMSSTRet = 0;
                                    break;
                            }
                        #endregion

                        _NF_Item.ValorBCII = 0;
                        _NF_Item.ValorDesII = 0;
                        _NF_Item.ValorII = 0;
                        _NF_Item.ValorIOF = 0;

                        _NF_Item.CSTPIS = _DT_Item.Rows[i]["CSTPIS"].ToString();
                        _NF_Item.AliquotaPIS = Convert.ToDouble(_DT_Item.Rows[i]["AliquotaPIS"]);
                        _NF_Item.ValorAliquotaPIS = 0;
                        _NF_Item.ValorPIS = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaPIS"]));

                        _NF_Item.CSTCOFINS = _DT_Item.Rows[i]["CSTCOFINS"].ToString();
                        _NF_Item.AliquotaCOFINS = Convert.ToDouble(_DT_Item.Rows[i]["AliquotaCOFINS"]);
                        _NF_Item.ValorAliquotaCOFINS = 0;
                        _NF_Item.ValorCOFINS = util_dados.CalculaAliquota(vlr_BC, Convert.ToDouble(_DT_Item.Rows[i]["AliquotaCOFINS"]));

                        NF_ESTRUTURA.Itens.Add(_NF_Item);
                    }
                else
                    throw new Exception(util_msg.msg_NF_Erro_BuscarItem);

                Exibe_Item();

                Calcula_NF();
                #endregion

                #region BUSCA FATURA
                BLL_CReceber = new BLL_CReceber();
                CReceber = new DTO_CReceber();

                CReceber.ID_Venda = _ID_Venda;

                DataTable _DT = new DataTable();
                _DT = BLL_CReceber.Busca_NFe(CReceber);

                if (_DT.Rows.Count > 0)
                {

                    if (NF_ESTRUTURA.Duplicata == null)
                        NF_ESTRUTURA.Duplicata = new List<DTO_NF_Duplicata>();

                    DTO_NF_Duplicata _Duplicata;
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        _Duplicata = new DTO_NF_Duplicata();

                        _Duplicata.ID = 0;
                        _Duplicata.NumeroDuplicata = txt_ID_NFe.Text + "-(" + (i + 1).ToString() + @"/" + _DT.Rows.Count.ToString() + ")";
                        _Duplicata.Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);
                        _Duplicata.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);

                        NF_ESTRUTURA.Duplicata.Add(_Duplicata);
                    }

                    if (NF_ESTRUTURA.Duplicata.Count > 1 ||
                        NF_ESTRUTURA.Duplicata[0].Vencimento > DateTime.Now)
                        cb_FormaPagto.SelectedValue = 1;

                    Exibe_Duplicata();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_Parametros()
        {
            try
            {
                Parametro = new DTO_Parametro();
                BLL_Parametro = new BLL_Parametro();

                Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Parametro.Tipo = 5;
                DataTable _DT = new DataTable();
                _DT = BLL_Parametro.Busca(Parametro);

                if (_DT.Rows.Count != 1)
                    throw new Exception(util_msg.msg_Erro_Param);

                DataRow _DR = _DT.Rows[0];

                Parametro_NFe_NFC_SAT.CertificadoDigital = _DR["Certificado_NFe"].ToString();
                Parametro_NFe_NFC_SAT.Caminho_NFe = Convert.ToString(_DR["Caminho_NFe"]);
                Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DR["AmbienteNFe"]);
                Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DR["RegimeTributario"]);
                Parametro_NFe_NFC_SAT.Exibe_InfoProd = Convert.ToBoolean(_DR["Exibe_InfoProduto"]);
                Parametro_NFe_NFC_SAT.AliquotaICMS = Convert.ToDouble(_DR["AliquotaCreditoICMS"]);
                Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS = Convert.ToBoolean(_DR["Exibe_msgCreditoICMS"]);
                Parametro_NFe_NFC_SAT.Exibe_Desconto = Convert.ToBoolean(_DR["Exibe_Desconto"]);
                Parametro_NFe_NFC_SAT.Tipo_NF_Venda = Convert.ToInt32(_DR["Tipo_NFe_Venda"]);
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro_Param + ex.Message);
            }
        }

        private DTO_NF CarregaInformaçoes()
        {
            NF_ESTRUTURA.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            NF_ESTRUTURA.ID = util_dados.Verifica_int(txt_ID.Text);
            NF_ESTRUTURA.ID_NFe = Convert.ToInt32(txt_ID_NFe.Text);
            NF_ESTRUTURA.Serie = Convert.ToInt32(txt_Serie.Text);
            NF_ESTRUTURA.Modelo = 65;

            NF_ESTRUTURA.DataEmissao = Convert.ToDateTime(mk_DataEmissao.Text);
            NF_ESTRUTURA.DataSaida = Convert.ToDateTime(mk_DataEmissao.Text);
            NF_ESTRUTURA.DataContigencia = Convert.ToDateTime(mk_DataEmissao.Text);

            NF_ESTRUTURA.TipoDocumento = 1;
            NF_ESTRUTURA.FinalidadeEmissao = 1;
            NF_ESTRUTURA.PresencaConsumidor = Convert.ToInt32(cb_PresencaConsumidor.SelectedValue);

            NF_ESTRUTURA.ConsumidorFinal = 1;

            NF_ESTRUTURA.NaturezaOperacao = "VENDA";
            NF_ESTRUTURA.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

            NF_ESTRUTURA.FormaEmissao = 1;
            NF_ESTRUTURA.TipoImpressao = 4;

            NF_ESTRUTURA.FormaPagto = Convert.ToInt32(cb_FormaPagto.SelectedValue);
            NF_ESTRUTURA.TipoFrete = Convert.ToInt32(cb_TipoFrete.SelectedValue);

            NF_ESTRUTURA.Situacao = 5;
            NF_ESTRUTURA.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            NF_ESTRUTURA.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            NF_ESTRUTURA.ValorBC = Convert.ToDouble(txt_BC_ICMS.Text);
            NF_ESTRUTURA.ValorICMS = Convert.ToDouble(txt_ICMS.Text);
            NF_ESTRUTURA.ValorBCST = Convert.ToDouble(txt_BC_ICMSST.Text);
            NF_ESTRUTURA.ValorST = Convert.ToDouble(txt_ICMS_ST.Text);
            NF_ESTRUTURA.ValorICMSDesonerado = Convert.ToDouble(txt_ValorICMSDesonerado.Text);
            NF_ESTRUTURA.ValorProduto = Convert.ToDouble(txt_Vlr_Produto.Text);
            NF_ESTRUTURA.ValorFrete = Convert.ToDouble(txt_Vlr_Frete.Text);
            NF_ESTRUTURA.ValorSeguro = Convert.ToDouble(txt_Vlr_Seguro.Text);
            NF_ESTRUTURA.ValorDesconto = Convert.ToDouble(txt_Vlr_Desc.Text);
            NF_ESTRUTURA.ValorImportacao = Convert.ToDouble(txt_Vlr_II.Text);
            NF_ESTRUTURA.ValorIPI = Convert.ToDouble(txt_IPI.Text);
            NF_ESTRUTURA.ValorPIS = Convert.ToDouble(txt_PIS.Text);
            NF_ESTRUTURA.ValorCOFINS = Convert.ToDouble(txt_COFINS.Text);
            NF_ESTRUTURA.ValorOutro = Convert.ToDouble(txt_Vlr_Outros.Text);
            NF_ESTRUTURA.ValorTotal = Convert.ToDouble(txt_Vlr_NF.Text);

            return NF_ESTRUTURA;
        }

        private void Busca_Pessoa(int _ID)
        {
            txt_CNPJ_CPF.Text = string.Empty;
            txt_Telefone.Text = string.Empty;
            txt_Logradouro.Text = string.Empty;
            txt_Numero.Text = string.Empty;
            txt_Bairro.Text = string.Empty;
            txt_Municipio_UF.Text = string.Empty;
            txt_ID_UF.Text = string.Empty;

            if (_ID > 0)
            {
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
                }
                else
                    txt_CNPJ_CPF.Text = string.Empty;

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
                    txt_ID_UF.Text = DREndereco["ID_UF"].ToString();
                }
                else
                {
                    txt_Logradouro.Text = string.Empty;
                    txt_Numero.Text = string.Empty;
                    txt_Bairro.Text = string.Empty;
                }

                Telefone.Principal = true;
                Pessoa.Telefone.Add(Telefone);
                DTTelefone = BLL_Pessoa.Busca_Telefone(Pessoa);

                if (DTTelefone.Rows.Count > 0)
                {
                    DRTelefone = DTTelefone.Rows[0];
                    txt_Telefone.Text = "(" + DRTelefone["DDD"] + ") " + DRTelefone["NumeroTelefone"];
                }
                else
                    txt_Telefone.Text = string.Empty;
            }
        }

        private void Exibe_Item()
        {
            dg_Itens.Rows.Clear();

            int aux = 0;
            if (NF_ESTRUTURA.Itens != null &&
                NF_ESTRUTURA.Itens.Count > 0)
                for (int i = 0; i <= NF_ESTRUTURA.Itens.Count - 1; i++)
                {
                    dg_Itens.Rows.Add();

                    dg_Itens.Rows[aux].Cells["col_ID_Item"].Value = NF_ESTRUTURA.Itens[i].ID;
                    dg_Itens.Rows[aux].Cells["col_ID_Produto"].Value = NF_ESTRUTURA.Itens[i].ID_Produto;
                    dg_Itens.Rows[aux].Cells["col_Descricao"].Value = NF_ESTRUTURA.Itens[i].Descricao;
                    dg_Itens.Rows[aux].Cells["col_Quantidade"].Value = NF_ESTRUTURA.Itens[i].Quantidade;
                    dg_Itens.Rows[aux].Cells["col_ValorUnitario"].Value = NF_ESTRUTURA.Itens[i].ValorUnitario;
                    dg_Itens.Rows[aux].Cells["col_ValorTotal"].Value = NF_ESTRUTURA.Itens[i].ValorTotal;
                    dg_Itens.Rows[aux].Cells["col_Desconto"].Value = NF_ESTRUTURA.Itens[i].Desconto;
                    dg_Itens.Rows[aux].Cells["col_InformacaoAdicional"].Value = NF_ESTRUTURA.Itens[i].InformacaoAdicional;
                    dg_Itens.Rows[aux].Cells["col_CFOP"].Value = NF_ESTRUTURA.Itens[i].CFOP;
                    dg_Itens.Rows[aux].Cells["col_CST"].Value = NF_ESTRUTURA.Itens[i].CST;
                    dg_Itens.Rows[aux].Cells["col_AliquotaICMS"].Value = NF_ESTRUTURA.Itens[i].AliquotaICMS;
                    dg_Itens.Rows[aux].Cells["col_ValorICMS"].Value = NF_ESTRUTURA.Itens[i].ValorICMS;
                    dg_Itens.Rows[aux].Cells["col_ValorBC"].Value = NF_ESTRUTURA.Itens[i].ValorBC;
                    dg_Itens.Rows[aux].Cells["col_CSOSN"].Value = NF_ESTRUTURA.Itens[i].CSOSN;
                    aux++;
                }
        }

        private void Exibe_Duplicata()
        {
            dg_Dup.Rows.Clear();


            if (NF_ESTRUTURA.Duplicata != null &&
                NF_ESTRUTURA.Duplicata.Count > 0)
            {
                NF_ESTRUTURA.Duplicata = NF_ESTRUTURA.Duplicata.OrderBy(c => c.Vencimento).ToList();

                for (int i = 0; i <= NF_ESTRUTURA.Duplicata.Count - 1; i++)
                {
                    dg_Dup.Rows.Add();
                    dg_Dup.Rows[i].Cells["col_Num_Dup"].Value = NF_ESTRUTURA.Duplicata[i].NumeroDuplicata;
                    dg_Dup.Rows[i].Cells["col_Venc_Dup"].Value = NF_ESTRUTURA.Duplicata[i].Vencimento;
                    dg_Dup.Rows[i].Cells["col_Vlr_Dup"].Value = NF_ESTRUTURA.Duplicata[i].Valor;
                }
            }
        }

        private void Calcula_NF()
        {
            if (NF_ESTRUTURA.Itens == null)
                return;

            double vlr_BC = 0;
            double vlr_ICMS = 0;
            double vlr_BCST = 0;
            double vlr_ST = 0;
            double vlr_Produto = 0;
            double vlr_Frete = 0;
            double vlr_Seguro = 0;
            double vlr_Desconto = 0;
            double vlr_Importacao = 0;
            double vlr_IPI = 0;
            double vlr_PIS = 0;
            double vlr_COFINS = 0;
            double vlr_Outro = 0;
            double vlr_ICMSDesonerado = 0;
            double Total_NF = 0;

            for (int i = 0; i <= NF_ESTRUTURA.Itens.Count - 1; i++)
            {
                vlr_BC += NF_ESTRUTURA.Itens[i].ValorBC;
                vlr_ICMS += NF_ESTRUTURA.Itens[i].ValorICMS;
                vlr_BCST += NF_ESTRUTURA.Itens[i].ValorBCST;
                vlr_ST += NF_ESTRUTURA.Itens[i].ValorICMSST;
                vlr_Produto += NF_ESTRUTURA.Itens[i].Quantidade * NF_ESTRUTURA.Itens[i].ValorUnitario;
                vlr_Frete += NF_ESTRUTURA.Itens[i].Frete;
                vlr_Seguro += NF_ESTRUTURA.Itens[i].Seguro;
                vlr_Desconto += NF_ESTRUTURA.Itens[i].Quantidade * NF_ESTRUTURA.Itens[i].Desconto;
                vlr_Importacao += NF_ESTRUTURA.Itens[i].ValorII;
                vlr_IPI += NF_ESTRUTURA.Itens[i].ValorIPI;
                vlr_PIS += NF_ESTRUTURA.Itens[i].ValorPIS;
                vlr_COFINS += NF_ESTRUTURA.Itens[i].ValorCOFINS;
                vlr_Outro += NF_ESTRUTURA.Itens[i].Acrescimo;
                vlr_ICMSDesonerado += NF_ESTRUTURA.Itens[i].ValorICMSDesonerado;
            }

            Total_NF = (vlr_Produto + vlr_Frete + vlr_Seguro + vlr_Outro + vlr_IPI + vlr_ST) - vlr_Desconto;

            txt_BC_ICMS.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);
            txt_ICMS.Text = util_dados.ConfigNumDecimal(vlr_ICMS, 2);
            txt_BC_ICMSST.Text = util_dados.ConfigNumDecimal(vlr_BCST, 2);
            txt_ICMS_ST.Text = util_dados.ConfigNumDecimal(vlr_ST, 2);
            txt_Vlr_Produto.Text = util_dados.ConfigNumDecimal(vlr_Produto, 2);
            txt_Vlr_Frete.Text = util_dados.ConfigNumDecimal(vlr_Frete, 2);
            txt_Vlr_Seguro.Text = util_dados.ConfigNumDecimal(vlr_Seguro, 2);
            txt_Vlr_Desc.Text = util_dados.ConfigNumDecimal(vlr_Desconto, 2);
            txt_Vlr_II.Text = util_dados.ConfigNumDecimal(vlr_Importacao, 2);
            txt_IPI.Text = util_dados.ConfigNumDecimal(vlr_IPI, 2);
            txt_PIS.Text = util_dados.ConfigNumDecimal(vlr_PIS, 2);
            txt_COFINS.Text = util_dados.ConfigNumDecimal(vlr_COFINS, 2);
            txt_Vlr_Outros.Text = util_dados.ConfigNumDecimal(vlr_Outro, 2);
            txt_Vlr_NF.Text = util_dados.ConfigNumDecimal(Total_NF, 2);
            txt_ValorICMSDesonerado.Text = util_dados.ConfigNumDecimal(vlr_ICMSDesonerado, 2);
        }

        private void Limpa_Campo()
        {
            util_dados.LimpaCampos(this, gb_Dados_NFe);
            util_dados.LimpaCampos(this, gb_Pessoa);
            util_dados.LimpaCampos(this, gb_Info_NF);
            util_dados.LimpaCampos(this, gb_Totais);
            dg_Itens.Rows.Clear();
            dg_Dup.Rows.Clear();
            DG.DataSource = null;

            mk_DataEmissao.Text = DateTime.Now.ToString();
            mk_DataEmissao.Text = DateTime.Now.ToString();

            cb_TipoFrete.SelectedValue = 0;
            cb_FormaPagto.SelectedIndex = 0;
            cb_TipoPessoaP.SelectedIndex = -1;
            cb_PresencaConsumidor.SelectedValue = 1;

            txt_BC_ICMS.Text = "0,00";
            txt_ICMS.Text = "0,00";
            txt_BC_ICMSST.Text = "0,00";
            txt_ICMS_ST.Text = "0,00";
            txt_ValorICMSDesonerado.Text = "0,00";
            txt_Vlr_Produto.Text = "0,00";
            txt_Vlr_Frete.Text = "0,00";
            txt_Vlr_Seguro.Text = "0,00";
            txt_Vlr_Desc.Text = "0,00";
            txt_Vlr_II.Text = "0,00";
            txt_IPI.Text = "0,00";
            txt_PIS.Text = "0,00";
            txt_COFINS.Text = "0,00";
            txt_Vlr_Outros.Text = "0,00";
            txt_Vlr_NF.Text = "0,00";

            tabctl.SelectedTab = TabPage1;
            tabControl2.SelectedTab = tabPage6;
        }

        private void Pesquisa_Produto(int _indexEdita, bool Edita)
        {

            if (cb_ID_Pessoa.SelectedValue == null)
            {
                MessageBox.Show(util_msg.msg_PessoaNull, this.Text);
                return;
            }

            UI_NFe_Produto UI_NFe_Produto = new UI_NFe_Produto();
            UI_NFe_Produto.ID_UF = util_dados.Verifica_int(txt_ID_UF.Text);
            UI_NFe_Produto.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

            if (Edita == true)
            {
                UI_NFe_Produto.Edita = true;
                UI_NFe_Produto._indexEdita = _indexEdita;
            }

            UI_NFe_Produto.Regime_Trib = Parametro_NFe_NFC_SAT.Regime_Tributario;
            UI_NFe_Produto.AliquotaCredito = Parametro_NFe_NFC_SAT.AliquotaICMS;
            UI_NFe_Produto.ExibeDesconto = Parametro_NFe_NFC_SAT.Exibe_Desconto;
            UI_NFe_Produto.lst_Itens = NF_ESTRUTURA.Itens;

            UI_NFe_Produto.ShowDialog();

            NF_ESTRUTURA.Itens = UI_NFe_Produto.lst_Itens;

            Exibe_Item();

            Calcula_NF();
        }

        private void Consulta_Pessoa()
        {
            if (tabctl.SelectedTab == TabPage1)
            {
                UI_Pessoa_Consulta frm = new UI_Pessoa_Consulta();
                frm.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                frm.ShowDialog();

                if (frm.NovoCadastro == true)
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

                if (frm.ID_Pessoa == 0)
                    return;

                cb_TipoPessoa.SelectedValue = frm.TipoPessoa;

                Carrega_Pessoa(1);

                cb_ID_Pessoa.SelectedValue = frm.ID_Pessoa;
                txt_ID_Pessoa.Text = frm.ID_Pessoa.ToString();

                tabControl2.SelectedTab = tabPage6;
                cb_FormaPagto.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.OcultaNovoCadastro = true;
                UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                Carrega_Pessoa(2);
                cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_PessoaP.Focus();
            }

        }

        /// <summary>
        /// VERIFICA SE NOTA ESTA DISPONIVEL PARA ALTERAÇÃO
        /// </summary>
        /// <returns></returns>
        private bool Verifica_NF()
        {
            if (NF_ESTRUTURA.Situacao == 2 ||
              NF_ESTRUTURA.Situacao == 3 ||
              NF_ESTRUTURA.Situacao == 4)
            {
                MessageBox.Show(util_msg.msg_Erro_AlteraNF + txt_DescricaoSituacao.Text + "!", this.Text);
                return false;
            }

            return true;
        }

        private void Carrega_NumeroNFC()
        {
            BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
            NF_TipoEmissao = new DTO_NF_TipoEmissao();

            BLL_NF = new BLL_NF();
            DTO_NF _NF = new DTO_NF();

            try
            {
                NF_TipoEmissao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF_TipoEmissao.ID = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

                DT_TipoEmissao = BLL_NF_TipoEmissao.Busca(NF_TipoEmissao);
                txt_Serie.Text = DT_TipoEmissao.Rows[0]["Serie"].ToString().PadLeft(3, '0');

                _NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                _NF.Serie = Convert.ToInt32(DT_TipoEmissao.Rows[0]["Serie"]);
                _NF.Modelo = 65;

                txt_ID_NFe.Text = BLL_NF.Busca_ID_NF(_NF).ToString();
            }
            catch (Exception)
            {
                txt_Serie.Text = "000";
                txt_ID_NFe.Text = "0";
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            if (!Verifica_NF())
                return;
            try
            {
                BLL_NF = new BLL_NF();
                NF = new DTO_NF();

                NF = CarregaInformaçoes();

                obj = BLL_NF.Grava(NF);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    txt_DescricaoSituacao.Text = "EM DIGITAÇÃO";

                    if (ID_Pedido > 0) //ALTERA SITUAÇÃO DE VENDA PARA COMO EMITIDO NF-E
                    {
                        BLL_Venda = new BLL_Venda();
                        Venda = new DTO_Venda();

                        Venda.ID = ID_Pedido;
                        Venda.NFe = true;

                        BLL_Venda.Altera_NFe(Venda);
                    }

                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Pesquisa()
        {
            try
            {
                DG.DataSource = null;

                BLL_NF = new BLL_NF();
                NF = new DTO_NF();

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                       mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    NF.Consulta_Emissao.Filtra = true;
                    NF.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    NF.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF.Serie = util_dados.Verifica_int(txt_SerieNFeP.Text);
                NF.Modelo = 65;

                NF.ID_NFe = util_dados.Verifica_int(txt_ID_NFeP.Text);
                NF.Chave = txt_ChavedeAcessoNFeP.Text;
                NF.Situacao = Convert.ToInt32(cb_SituacaoNFeP.SelectedValue);
                NF.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                NF.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

                DT = BLL_NF.Busca_NF(NF);

                DG.DataSource = DT;
                util_dados.CarregaCampo(this, DT, gb_Info_NF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            if (!Verifica_NF())
                return;

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_NF = new BLL_NF();
                NF = new DTO_NF();

                NF.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_NF.Exclui(NF);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            NF_ESTRUTURA = new DTO_NF();

            Limpa_Campo();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
            tabControl2.SelectedTab = tabPage6;
        }
        #endregion

        #region BUTTON
        private void bt_AdicionaProduto_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            Pesquisa_Produto(0, false);
        }

        private void bt_EditarProduto_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            Pesquisa_Produto(dg_Itens.CurrentRow.Index, true);
        }

        private void bt_ExcluiProduto_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            try
            {
                if (dg_Itens.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (NF_ESTRUTURA.Itens[dg_Itens.CurrentRow.Index].ID > 0 &&
                    util_dados.Verifica_int(txt_ID.Text) > 0)
                {
                    BLL_NF = new BLL_NF();
                    DTO_NF_Itens _Item = new DTO_NF_Itens();
                    DTO_NF _NF = new DTO_NF();

                    _NF.Itens = new List<DTO_NF_Itens>();

                    _Item.ID = NF_ESTRUTURA.Itens[dg_Itens.CurrentRow.Index].ID;
                    _NF.Itens.Add(_Item);

                    BLL_NF.Exclui_NF_Item(_NF);
                }

                NF_ESTRUTURA.Itens.RemoveAt(dg_Itens.CurrentRow.Index);

                Calcula_NF();

                Exibe_Item();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_Add_Dup_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            if (txt_Num_Dup.Text.Trim() == string.Empty ||
                txt_Vlr_Dup.Text.Trim() == string.Empty)
                return;

            if (NF_ESTRUTURA.Duplicata == null)
                NF_ESTRUTURA.Duplicata = new List<DTO_NF_Duplicata>();

            DTO_NF_Duplicata _Duplicata = new DTO_NF_Duplicata();

            _Duplicata.ID = util_dados.Verifica_int(txt_ID_Dup.Text);
            _Duplicata.NumeroDuplicata = txt_Num_Dup.Text;
            _Duplicata.Vencimento = Convert.ToDateTime(mk_Venc_Dup.Text);
            _Duplicata.Valor = Convert.ToDouble(txt_Vlr_Dup.Text);

            if (Edita_Dup == true)
                NF_ESTRUTURA.Duplicata.RemoveAt(dg_Dup.CurrentRow.Index);

            NF_ESTRUTURA.Duplicata.Add(_Duplicata);

            Exibe_Duplicata();

            Edita_Dup = false;

            util_dados.LimpaCampos(this, gb_Dup);

            txt_Vlr_Dup.Text = "0,00";

            txt_Num_Dup.Focus();
        }

        private void bt_Edita_Dup_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            if (dg_Dup.Rows.Count > 0)
            {
                Edita_Dup = true;

                txt_ID_Dup.Text = NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].ID.ToString();
                txt_Num_Dup.Text = NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].NumeroDuplicata.ToString();
                mk_Venc_Dup.Text = NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].Vencimento.ToString();
                txt_Vlr_Dup.Text = util_dados.ConfigNumDecimal(NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].Valor.ToString(), 2);
            }
        }

        private void bt_Exclui_Dup_Click(object sender, EventArgs e)
        {
            if (!Verifica_NF())
                return;

            try
            {
                if (dg_Dup.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].ID > 0 &&
                    util_dados.Verifica_int(txt_ID.Text) > 0)
                {
                    BLL_NF = new BLL_NF();
                    DTO_NF _NF = new DTO_NF();
                    NF_Duplicata = new DTO_NF_Duplicata();
                    _NF.Duplicata = new List<DTO_NF_Duplicata>();

                    NF_Duplicata.ID = NF_ESTRUTURA.Duplicata[dg_Dup.CurrentRow.Index].ID;
                    _NF.Duplicata.Add(NF_Duplicata);
                    BLL_NF.Exclui_NF_Duplicata(_NF);
                }

                NF_ESTRUTURA.Duplicata.RemoveAt(dg_Dup.CurrentRow.Index);

                Exibe_Duplicata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Consulta_Pessoa();
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            ExibeRegistro();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Carrega_NumeroNFC();
        }
        #endregion

        #region FORM
        private void UI_NFe_Emissor_Completo_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFe_Emissor_Completo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
            tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F10)
                Pesquisa_Produto(0, false);

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            Carrega_Pessoa(1);
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
            }
        }

        private void cb_TipoPessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_TipoPessoaP.SelectedIndex = -1;
        }

        private void cb_ID_PessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaP.SelectedIndex = -1;
        }

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            Carrega_Pessoa(2);
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataEmissao_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataEmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataEmissao.Text = Convert.ToString(DateTime.Now);
                mk_DataEmissao.Focus();
            }

        }

        private void mk_DataSaida_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataEmissao.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataEmissao.Text = Convert.ToString(DateTime.Now);
                mk_DataEmissao.Focus();
            }

        }

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
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
            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }

        }

        private void mk_Venc_Dup_Leave(object sender, EventArgs e)
        {
            if (mk_Venc_Dup.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_Venc_Dup.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Venc_Dup.Text = Convert.ToString(DateTime.Now);
                mk_Venc_Dup.Focus();
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Vlr_Dup_Leave(object sender, EventArgs e)
        {

        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (txt_ID.Text.Trim() == string.Empty)
                return;

            if (util_dados.Verifica_int(txt_ID.Text) > 0)
            {
                Status = StatusForm.Consulta;
                Config_Botao();
                Carrega_NF(Convert.ToInt32(txt_ID.Text));
            }
        }

        private void txt_Vlr_NF_Leave(object sender, EventArgs e)
        {
            if (txt_Vlr_NF.Text.Trim() == "")
                txt_Vlr_NF.Text = "0,0";

            txt_Vlr_NF.Text = util_dados.ConfigNumDecimal(txt_Vlr_NF.Text, 2);
        }

        private void txt_Vlr_Frete_Leave(object sender, EventArgs e)
        {
            if (txt_Vlr_Frete.Text.Trim() == "")
                txt_Vlr_Frete.Text = "0,0";

            txt_Vlr_Frete.Text = util_dados.ConfigNumDecimal(txt_Vlr_Frete.Text, 2);
            Calcula_NF();
        }

        private void txt_DescricaoSituacao_TextChanged(object sender, EventArgs e)
        {
            switch (txt_DescricaoSituacao.Text)
            {
                case "EM DIGITAÇÃO":
                    txt_DescricaoSituacao.BackColor = Color.White;
                    txt_DescricaoSituacao.ForeColor = Color.Black;
                    break;

                case "ASSINADA":
                    txt_DescricaoSituacao.BackColor = Color.White;
                    txt_DescricaoSituacao.ForeColor = Color.Green;
                    break;

                case "EM PROCESSAMENTO":
                    txt_DescricaoSituacao.BackColor = Color.White;
                    txt_DescricaoSituacao.ForeColor = Color.Green;
                    break;

                case "AUTORIZADA":
                    txt_DescricaoSituacao.BackColor = Color.White;
                    txt_DescricaoSituacao.ForeColor = Color.Blue;
                    break;

                case "CANCELADA":
                    txt_DescricaoSituacao.BackColor = Color.Red;
                    txt_DescricaoSituacao.ForeColor = Color.White;
                    break;

                case "DENEGADA":
                    txt_DescricaoSituacao.BackColor = Color.Red;
                    txt_DescricaoSituacao.ForeColor = Color.White;
                    break;
            }
        }
        #endregion


    }
}

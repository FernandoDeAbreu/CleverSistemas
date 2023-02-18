using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Runtime.InteropServices;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.NFe;
using Microsoft.Reporting.WinForms;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using System.Threading;

namespace Sistema.UI
{
    public partial class UI_CFe : Form
    {
        public UI_CFe()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Parametro BLL_Parametro;
        BLL_NF BLL_NF;
        BLL_Venda BLL_Venda;
        BLL_OS BLL_OS;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        int Qt_Produto = 0;

        DataRow DR_NF;
        DataRow DR_Emit;
        DataRow DR;
        DataRow DR_Dest;
        DataRow DR_Item;
        DataSet DS_NF;

        string Chave;

        StringWriter txt_XML;

        bool NF_Salva = false;
        #endregion

        #region ESTRUTURA
        DTO_Parametro Parametro;
        DTO_CFe_SAT CFe_SAT;
        DTO_CFe_SAT_Retorno CFe_SAT_Retorno;
        DTO_Venda Venda;
        DTO_OS OS;
        DTO_NF NF_ESTRUTURA;
        DTO_NF NF;
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        #endregion

        #region PROPRIEDADES
        public int ID_Venda { get; set; }
        public int ID_OS { get; set; }
        public int ID_NF { get; set; }
        public bool NF_Gravada { get; set; }
        public bool Concluido { get; set; }
        public string CNPJ_CPF_Destinatario { get; set; }
        public bool Cancelamento { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            lb_Status.Text = "";

            this.Text = "NOTA FISCAL CONSUMIDOR";

            Concluido = false;

            Carrega_Parametro();

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            DataTable _DT;

            if (Cancelamento == true)
            {
                NF.ID = ID_NF;
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF(NF);

                if (_DT.Rows.Count == 1)
                {
                    ID_Venda = Convert.ToInt32(_DT.Rows[0]["ID_Venda"]);
                    ID_OS = Convert.ToInt32(_DT.Rows[0]["ID_OS"]);
                }

                bt_Cancelar.Visible = true;
                bt_Emitir.Visible = false;
            }
            else
            {
                NF.ID_Venda = ID_Venda;
                NF.ID_OS = ID_OS;
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF(NF);

                if (_DT.Rows.Count == 1)
                    ID_NF = Convert.ToInt32(_DT.Rows[0]["ID_NF"]);

                bt_Cancelar.Visible = false;
                bt_Emitir.Visible = true;
            }

            if (ID_Venda > 0)
                Carrega_Venda(ID_Venda);

            if (ID_OS > 0)
                Carrega_OS(ID_OS);
        }

        private void Carrega_Parametro()
        {
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.Tipo = 6;
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Parametro.Busca(Parametro);

            Parametro_NFe_NFC_SAT.TipoEquipamentoSAT = Convert.ToInt32(_DT.Rows[0]["TipoEquipamentoSAT"]);
            Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT = _DT.Rows[0]["SenhaAtivacaoSAT"].ToString();
            Parametro_NFe_NFC_SAT.AssinaturaSAT = _DT.Rows[0]["AssinaturaSAT"].ToString();
            Parametro_NFe_NFC_SAT.CFe_A4 = Convert.ToBoolean(_DT.Rows[0]["CFe_A4"]);
            Parametro_NFe_NFC_SAT.Monitor_CFe = Convert.ToBoolean(_DT.Rows[0]["Monitor_CFe"]);

            Parametro.Tipo = 5;

            _DT = BLL_Parametro.Busca(Parametro);

            Parametro_NFe_NFC_SAT.CertificadoDigital = _DT.Rows[0]["Certificado_NFe"].ToString();
            Parametro_NFe_NFC_SAT.Caminho_NFe = Convert.ToString(_DT.Rows[0]["Caminho_NFe"]);
            Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DT.Rows[0]["AmbienteNFe"]);
            Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DT.Rows[0]["RegimeTributario"]);
            Parametro_NFe_NFC_SAT.Exibe_InfoProd = Convert.ToBoolean(_DT.Rows[0]["Exibe_InfoProduto"]);
            Parametro_NFe_NFC_SAT.AliquotaICMS = Convert.ToDouble(_DT.Rows[0]["AliquotaCreditoICMS"]);
            Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS = Convert.ToBoolean(_DT.Rows[0]["Exibe_msgCreditoICMS"]);
            Parametro_NFe_NFC_SAT.Exibe_Desconto = Convert.ToBoolean(_DT.Rows[0]["Exibe_Desconto"]);
            Parametro_NFe_NFC_SAT.Tipo_NF_Venda = Convert.ToInt32(_DT.Rows[0]["Tipo_NFe_Venda"]);
        }

        private void Carrega_Venda(int _ID_Venda)
        {
            try
            {
                NF_ESTRUTURA = new DTO_NF();

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

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.ID = _ID_Venda;

                Venda.ID_UF = 35;

                Venda.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

                txt_Pessoa.Text = _DT_Venda.Rows[0]["Descricao"].ToString();
                txt_ID_Pessoa.Text = _DT_Venda.Rows[0]["ID_Pessoa"].ToString();

                #region BUSCA ITEM VENDA
                DTO_NF_Itens _NF_Item;
                DataTable _DT_Item = new DataTable();

                _DT_Item = BLL_Venda.Busca_Item_NF_CF(Venda);

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
                        _Duplicata.NumeroDuplicata = "(" + (i + 1).ToString() + @"/" + _DT.Rows.Count.ToString() + ")";
                        _Duplicata.Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);
                        _Duplicata.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);

                        NF_ESTRUTURA.Duplicata.Add(_Duplicata);
                    }
                    /*
                    if (NF_ESTRUTURA.Duplicata.Count > 1 ||
                        NF_ESTRUTURA.Duplicata[0].Vencimento > DateTime.Now)
                        cb_FormaPagto.SelectedValue = 1;

                    Exibe_Duplicata();*/
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_OS(int _ID_OS)
        {
            try
            {
                NF_ESTRUTURA = new DTO_NF();

                if (NF_ESTRUTURA.Itens == null)
                    NF_ESTRUTURA.Itens = new List<DTO_NF_Itens>();

                BLL_NF = new BLL_NF();
                BLL_OS = new BLL_OS();

                OS = new DTO_OS();

                OS.ID = _ID_OS;

                DataTable _DT_OS = new DataTable();
                _DT_OS = BLL_OS.Busca(OS);

                if (_DT_OS.Rows.Count == 0)
                    return;

                OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                OS.ID = _ID_OS;

                OS.ID_UF = 35;

                OS.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

                txt_Pessoa.Text = _DT_OS.Rows[0]["Descricao"].ToString();
                txt_ID_Pessoa.Text = _DT_OS.Rows[0]["ID_Pessoa"].ToString();

                #region BUSCA ITEM VENDA
                DTO_NF_Itens _NF_Item;
                DataTable _DT_Item = new DataTable();

                _DT_Item = BLL_OS.Busca_Item_CF(OS);

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

                CReceber.ID_OS = _ID_OS;

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
                        _Duplicata.NumeroDuplicata = "(" + (i + 1).ToString() + @"/" + _DT.Rows.Count.ToString() + ")";
                        _Duplicata.Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);
                        _Duplicata.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);

                        NF_ESTRUTURA.Duplicata.Add(_Duplicata);
                    }
                    /*
                    if (NF_ESTRUTURA.Duplicata.Count > 1 ||
                        NF_ESTRUTURA.Duplicata[0].Vencimento > DateTime.Now)
                        cb_FormaPagto.SelectedValue = 1;

                    Exibe_Duplicata();*/
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
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
                    aux++;
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

            txt_Vlr_Produto.Text = util_dados.ConfigNumDecimal(vlr_Produto, 2);
            txt_Vlr_Desc.Text = util_dados.ConfigNumDecimal(vlr_Desconto, 2);
            txt_TotalNF.Text = util_dados.ConfigNumDecimal(Total_NF, 2);
        }

        private DTO_NF CarregaInformaçoes()
        {
            NF_ESTRUTURA.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            NF_ESTRUTURA.ID = ID_NF;
            NF_ESTRUTURA.ID_NFe = 0;
            NF_ESTRUTURA.Serie = Parametro_NFe_NFC_SAT.NumeroCaixa;
            NF_ESTRUTURA.Modelo = 59;
            NF_ESTRUTURA.ID_Venda = ID_Venda;
            NF_ESTRUTURA.ID_OS = ID_OS;
            NF_ESTRUTURA.Controle_CF = util_dados.Gera_Sessao();

            NF_ESTRUTURA.DataEmissao = DateTime.Now;
            NF_ESTRUTURA.DataSaida = DateTime.Now;
            NF_ESTRUTURA.DataContigencia = DateTime.Now;

            NF_ESTRUTURA.TipoDocumento = 1;
            NF_ESTRUTURA.FinalidadeEmissao = 1;
            NF_ESTRUTURA.PresencaConsumidor = 1;

            NF_ESTRUTURA.ConsumidorFinal = 1;
            NF_ESTRUTURA.CNPJ_CPF_Destinatario = CNPJ_CPF_Destinatario;

            NF_ESTRUTURA.NaturezaOperacao = "VENDA CONSUMIDOR";
            NF_ESTRUTURA.Tipo_NF = Parametro_NFe_NFC_SAT.Tipo_NF_Venda;

            NF_ESTRUTURA.FormaEmissao = 1;
            NF_ESTRUTURA.TipoImpressao = 4;

            NF_ESTRUTURA.FormaPagto = 2;
            NF_ESTRUTURA.TipoFrete = 1;

            NF_ESTRUTURA.Situacao = 5;
            NF_ESTRUTURA.TipoPessoa = 1;
            NF_ESTRUTURA.ID_Pessoa = Convert.ToInt32(txt_ID_Pessoa.Text);
            NF_ESTRUTURA.Status_CFe = 2;

            NF_ESTRUTURA.ValorBC = 0;
            NF_ESTRUTURA.ValorICMS = 0;
            NF_ESTRUTURA.ValorBCST = 0;
            NF_ESTRUTURA.ValorST = 0;
            NF_ESTRUTURA.ValorICMSDesonerado = 0;
            NF_ESTRUTURA.ValorProduto = Convert.ToDouble(txt_Vlr_Produto.Text);
            NF_ESTRUTURA.ValorFrete = 0;
            NF_ESTRUTURA.ValorSeguro = 0;
            NF_ESTRUTURA.ValorDesconto = Convert.ToDouble(txt_Vlr_Desc.Text);
            NF_ESTRUTURA.ValorImportacao = 0;
            NF_ESTRUTURA.ValorIPI = 0;
            NF_ESTRUTURA.ValorPIS = 0;
            NF_ESTRUTURA.ValorCOFINS = 0;
            NF_ESTRUTURA.ValorOutro = 0;
            NF_ESTRUTURA.ValorTotal = Convert.ToDouble(txt_TotalNF.Text);

            return NF_ESTRUTURA;
        }

        private void Grava_NF()
        {
            try
            {
                BLL_NF = new BLL_NF();
                NF = new DTO_NF();

                NF = CarregaInformaçoes();

                if (NF.ID == 0)
                    ID_NF = BLL_NF.Grava(NF);

                if (ID_NF > 0)
                {
                    if (ID_Venda > 0) //ALTERA SITUAÇÃO DE VENDA PARA COMO EMITIDO NF-E
                    {
                        BLL_Venda = new BLL_Venda();
                        Venda = new DTO_Venda();

                        Venda.ID = ID_Venda;
                        Venda.NFe = true;

                        BLL_Venda.Altera_CFe(Venda);

                        NF_Gravada = true;
                    }

                    if (ID_OS > 0) //ALTERA SITUAÇÃO DE ORDEM DE SERVIÇO PARA COMO EMITIDO NF-E
                    {
                        BLL_OS = new BLL_OS();
                        OS = new DTO_OS();

                        OS.ID = ID_OS;
                        OS.NFe = true;

                        BLL_OS.Altera_CFe(OS);

                        NF_Gravada = true;
                    }

                    if (Parametro_NFe_NFC_SAT.Monitor_CFe == false)
                        Envia_NF();

                    if (Parametro_NFe_NFC_SAT.Monitor_CFe == true)
                    {
                        NF.Situacao = 5;
                        NF.Status_CFe = 2;

                        BLL_NF.Altera_Status_CFe(NF);

                        /// <summary>
                        /// <para>0 - FINALIZADO</para>
                        /// <para>1 - ERRO</para>
                        /// <para>2 - ENVIO CFe</para>
                        /// <para>3 - CANCELAMENTO CFe</para>
                        /// <para>4 - PROCESSAMENTO</para>

                        for (int i = 0; i <= 15; i++)
                        {
                            DataTable _DT = new DataTable();
                            _DT = BLL_NF.Busca_CFe_Emitido(NF);

                            if (_DT.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(_DT.Rows[0]["Status_CFe"]) == 0)
                                {
                                    MessageBox.Show(util_msg.msg_EmissaoSATSucesso, this.Text);

                                    Concluido = true;

                                    Imprime();
                                    return;
                                }
                                else if (Convert.ToInt32(_DT.Rows[0]["Status_CFe"]) == 1)
                                {
                                    MessageBox.Show(util_msg.msg_EmissaoSATErro + _DT.Rows[0]["Retorno_CFe"], this.Text);

                                    return;
                                }
                                else
                                    Thread.Sleep(1000);
                            }
                        }
                        MessageBox.Show(util_msg.msg_EmissaoSATErroMonitor, this.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Cancelar_NF()
        {
            lb_Status.Text = "CANCELANDO CF-e...";
            try
            {
                if (Parametro_NFe_NFC_SAT.Monitor_CFe == true)
                {
                    BLL_NF = new BLL_NF();
                    NF = new DTO_NF();

                    NF.ID = ID_NF;
                    NF.Situacao = 7;
                    NF.Status_CFe = 3;

                    BLL_NF.Altera_Status_CFe(NF);

                    for (int i = 0; i <= 15; i++)
                    {
                        DataTable _DT = new DataTable();
                        _DT = BLL_NF.Busca_CFe_Emitido(NF);

                        if (_DT.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(_DT.Rows[0]["Status_CFe"]) == 0)
                            {
                                MessageBox.Show(util_msg.msg_CancelamentoSATSucesso, this.Text);

                                return;
                            }
                            else if (Convert.ToInt32(_DT.Rows[0]["Status_CFe"]) == 1)
                            {
                                MessageBox.Show(util_msg.msg_EmissaoSATErro + _DT.Rows[0]["Retorno_CFe"], this.Text);

                                return;
                            }
                            else
                                Thread.Sleep(1000);
                        }
                    }
                    MessageBox.Show(util_msg.msg_EmissaoSATErroMonitor, this.Text);
                }

                if (Parametro_NFe_NFC_SAT.Monitor_CFe == false)
                {
                    BLL_NF = new BLL_NF();
                    NF = new DTO_NF();

                    NF.ID = ID_NF;
                    NF.Situacao = 7;
                    NF.Status_CFe = 3;

                    BLL_NF.Altera_Status_CFe(NF);

                    string XML = Gera_Estrutura_XML_CFe_Cancelamento(ID_NF);

                    SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                    CFe_SAT = new DTO_CFe_SAT();
                    CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                    CFe_SAT.Funcao = CFe_SAT_Funcao.CancelarUltimaVenda;
                    CFe_SAT.Chave = XML.Substring(XML.IndexOf("chCanc=") + 8, 47);
                    CFe_SAT.XML = XML;

                    CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                    if (CFe_SAT_Retorno.Status == true)
                    {
                        NF = new DTO_NF();
                        NF.ID = ID_NF;
                        NF.Situacao = 3;
                        NF.Status_CFe = 0;
                        NF.Retorno_CFe = CFe_SAT_Retorno.Mensagem;
                        NF.DataEmissao = DateTime.Now;
                        NF.Chave = CFe_SAT_Retorno.Chave;
                        NF.QRCode = CFe_SAT_Retorno.AssinaturaQR;
                        NF.ID_NFe = Convert.ToInt32(CFe_SAT_Retorno.Chave.Substring(34, 6));

                        BLL_NF.Altera_Chave(NF);

                        #region GRAVA XML CF-e
                        XmlDocument xaux = new XmlDocument();
                        xaux.LoadXml(CFe_SAT_Retorno.XML_CFe);

                        string _Periodo = util_dados.Config_Data(Convert.ToDateTime(CFe_SAT_Retorno.Data_HoraEmissao), 9).ToString();

                        string CFe_XML = CFe_SAT_Retorno.Chave + ".xml";
                        string Caminho_XML_Temp = Parametro_Sistema.Caminho_Sistema + @"Temp\";
                        string Caminho_XML = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + @"\SAT_Cancelamento\";

                        if (!Directory.Exists(Caminho_XML_Temp))
                            Directory.CreateDirectory(Caminho_XML_Temp);

                        if (!Directory.Exists(Caminho_XML))
                            Directory.CreateDirectory(Caminho_XML);

                        XmlTextWriter xWriter = new XmlTextWriter(Caminho_XML_Temp + CFe_XML, Encoding.UTF8);
                        xWriter.Formatting = Formatting.None;
                        xaux.Save(xWriter);
                        xWriter.Close();

                        File.Move(Caminho_XML_Temp + CFe_XML, Caminho_XML + CFe_XML);
                        #endregion

                        MessageBox.Show(util_msg.msg_CancelamentoSATSucesso, this.Text);

                        Concluido = true;

                        SAT = null;
                    }
                    else
                    {
                        NF.Situacao = 8;
                        NF.Status_CFe = 0;

                        BLL_NF.Altera_Status_CFe(NF);

                        MessageBox.Show(util_msg.msg_EmissaoSATErro + CFe_SAT_Retorno.Cod_Erro + "-" + CFe_SAT_Retorno.Mensagem);
                    }
                }
                bt_Cancelar.Enabled = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

        }

        private void Envia_NF()
        {
            try
            {
                string XML = Gera_Estrutura_XML_CFe(ID_NF);

                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                DataTable _DT;

                #region VERIFICA SE EXISTE CF-E PENDENTE
                if (Parametro_NFe_NFC_SAT.Monitor_CFe == false)
                {
                    NF = new DTO_NF();
                    NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    NF.Modelo = 59;
                    NF.Status_CFe = 4;

                    _DT = new DataTable();
                    _DT = BLL_NF.Busca_NF_SAT(NF);

                    if (_DT.Rows.Count > 0)
                    {
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        {
                            CFe_SAT.Funcao = CFe_SAT_Funcao.ConsultarNumeroSessao;
                            CFe_SAT.NumeroSessao = Convert.ToInt32(_DT.Rows[i]["Controle_CF"]);

                            CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                            if (CFe_SAT_Retorno.Status == true)
                            {
                                NF = new DTO_NF();
                                NF.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                                NF.Situacao = 8;
                                NF.Status_CFe = 0;
                                NF.Retorno_CFe = CFe_SAT_Retorno.Mensagem;
                                NF.Chave = CFe_SAT_Retorno.Chave;
                                NF.QRCode = CFe_SAT_Retorno.AssinaturaQR;
                                NF.DataEmissao = DateTime.Now;
                                NF.ID_NFe = Convert.ToInt32(CFe_SAT_Retorno.Chave.Substring(34, 6));

                                BLL_NF.Altera_Chave(NF);

                                #region GRAVA XML CF-e
                                XmlDocument xaux = new XmlDocument();
                                xaux.LoadXml(CFe_SAT_Retorno.XML_CFe);

                                string _Periodo = util_dados.Config_Data(Convert.ToDateTime(CFe_SAT_Retorno.Data_HoraEmissao), 9).ToString();

                                string CFe_XML = CFe_SAT_Retorno.Chave + ".xml";
                                string Caminho_XML_Temp = Parametro_Sistema.Caminho_Sistema + @"Temp\";
                                string Caminho_XML = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + @"\SAT_Venda\";

                                if (!Directory.Exists(Caminho_XML_Temp))
                                    Directory.CreateDirectory(Caminho_XML_Temp);

                                if (!Directory.Exists(Caminho_XML))
                                    Directory.CreateDirectory(Caminho_XML);

                                XmlTextWriter xWriter = new XmlTextWriter(Caminho_XML_Temp + CFe_XML, Encoding.UTF8);
                                xWriter.Formatting = Formatting.None;
                                xaux.Save(xWriter);
                                xWriter.Close();

                                File.Move(Caminho_XML_Temp + CFe_XML, Caminho_XML + CFe_XML);
                                #endregion
                            }
                        }
                    }
                }
                #endregion

                NF = new DTO_NF();
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF.ID = ID_NF;

                _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_SAT(NF);

                CFe_SAT.Funcao = CFe_SAT_Funcao.EnviarDadosVenda;
                CFe_SAT.NumeroSessao = util_dados.Gera_Sessao();
                CFe_SAT.XML = XML;

                NF.Situacao = 7;
                NF.Status_CFe = 4;
                NF.Controle_CF = CFe_SAT.NumeroSessao;

                BLL_NF.Altera_Sessao(NF);
                BLL_NF.Altera_Status_CFe(NF);

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                {
                    NF = new DTO_NF();
                    NF.ID = ID_NF;
                    NF.Situacao = 8;
                    NF.Status_CFe = 0;
                    NF.Retorno_CFe = CFe_SAT_Retorno.Mensagem;
                    NF.Chave = CFe_SAT_Retorno.Chave;
                    NF.DataEmissao = DateTime.Now;
                    NF.QRCode = CFe_SAT_Retorno.AssinaturaQR;
                    NF.ID_NFe = Convert.ToInt32(CFe_SAT_Retorno.Chave.Substring(34, 6));

                    BLL_NF.Altera_Chave(NF);

                    #region GRAVA XML CF-e
                    XmlDocument xaux = new XmlDocument();
                    xaux.LoadXml(CFe_SAT_Retorno.XML_CFe);

                    string _Periodo = util_dados.Config_Data(Convert.ToDateTime(CFe_SAT_Retorno.Data_HoraEmissao), 9).ToString();

                    string CFe_XML = CFe_SAT_Retorno.Chave + ".xml";
                    string Caminho_XML_Temp = Parametro_Sistema.Caminho_Sistema + @"Temp\";
                    string Caminho_XML = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + @"\SAT_Venda\";

                    if (!Directory.Exists(Caminho_XML_Temp))
                        Directory.CreateDirectory(Caminho_XML_Temp);

                    if (!Directory.Exists(Caminho_XML))
                        Directory.CreateDirectory(Caminho_XML);

                    XmlTextWriter xWriter = new XmlTextWriter(Caminho_XML_Temp + CFe_XML, Encoding.UTF8);
                    xWriter.Formatting = Formatting.None;
                    xaux.Save(xWriter);
                    xWriter.Close();

                    File.Move(Caminho_XML_Temp + CFe_XML, Caminho_XML + CFe_XML);
                    #endregion

                    MessageBox.Show(util_msg.msg_EmissaoSATSucesso, this.Text);

                    Concluido = true;
                    SAT = null;

                    Imprime();
                }
                else
                {
                    NF.Situacao = 5;
                    NF.Status_CFe = 1;

                    BLL_NF.Altera_Status_CFe(NF);

                    MessageBox.Show(util_msg.msg_EmissaoSATErro + CFe_SAT_Retorno.Cod_Erro + "-" + CFe_SAT_Retorno.Mensagem);

                    bt_Emitir.Enabled = true;
                }
                SAT = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Imprime()
        {
            //LocalReport rpt = new LocalReport();

            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            rpt.Show();

            string rpt_Nome = string.Empty;

            if (Parametro_NFe_NFC_SAT.CFe_A4 == true)
                rpt_Nome = "rpt_SAT_A4.rdlc";
            else
                rpt_Nome = "rpt_SAT_Termica.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            //rpt.ReportPath = Caminhorpt;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.ID = ID_NF;
            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_NF = BLL_NF.Busca_NF_SAT(NF);
            DataTable DTR_Item = BLL_NF.Busca_NF_Item(NF);

            #region PAGAMENTO
            DataTable DTR_Financeiro = new DataTable();
            DTR_Financeiro.Columns.Add("Tipo", typeof(String));
            DTR_Financeiro.Columns.Add("Valor", typeof(Double));

            DataTable _DT = new DataTable();

            if (ID_Venda > 0)
                _DT = BLL_Venda.Busca_PagamentoSAT(Venda);

            if (ID_OS > 0)
                _DT = BLL_OS.Busca_PagamentoSAT(OS);

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DTR_Financeiro.Rows.Add();

                    switch (Convert.ToInt32(_DT.Rows[i]["Tipo"]))
                    {
                        case 1: //BOLETO
                            DTR_Financeiro.Rows[i]["Tipo"] = "CRÉDITO LOJA";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 2: //CARTÃO CREDITO
                            DTR_Financeiro.Rows[i]["Tipo"] = "CARTÃO DE CRÉDITO";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 3: //CHEQUE
                            DTR_Financeiro.Rows[i]["Tipo"] = "CHEQUE";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 4: //DINHEIRO
                            DTR_Financeiro.Rows[i]["Tipo"] = "DINHEIRO";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 5: //CARTEIRA
                            DTR_Financeiro.Rows[i]["Tipo"] = "CRÉDITO LOJA";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 6: //OUTROS
                            DTR_Financeiro.Rows[i]["Tipo"] = "OUTROS";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;

                        case 7: //CARTÃO DÉBITO
                            DTR_Financeiro.Rows[i]["Tipo"] = "CARTÃO DÉBITO";
                            DTR_Financeiro.Rows[i]["Valor"] = _DT.Rows[i]["Valor"];
                            break;
                    }
                }
            #endregion

            #region TRATAMENTO DE CHAVE
            string Chave = DTR_NF.Rows[0]["Chave"].ToString();

            string N_SerieSAT = Chave.Substring(25, 9);
            string N_Cupom = Chave.Substring(34, 6);
            #endregion

            #region CRIA QR CODE
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 7;
            qrCodeEncoder.QRCodeVersion = 0;

            Image QRCode;
            String AssinaturaQR = DTR_NF.Rows[0]["QRCode_CFe"].ToString();

            QRCode = qrCodeEncoder.Encode(AssinaturaQR);
            string str_QRCode;

            using (MemoryStream ms = new MemoryStream())
            {
                QRCode.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                str_QRCode = Convert.ToBase64String(imageBytes);
            }

            qrCodeEncoder = null;
            #endregion

            #region CRIA BARRA
            Image Barra;
            String str_Chave = DTR_NF.Rows[0]["Chave"].ToString().Replace("CFe", "");

            string str_Barra;
            Barra = Code128Rendering.MakeBarcodeImage(str_Chave, 1, true);

            using (MemoryStream ms = new MemoryStream())
            {
                Barra.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                str_Barra = Convert.ToBase64String(imageBytes);
            }
            #endregion

            #region CONFIGURA CHAVE
            string Chave_Tratada = util_dados.Config_ChaveNFe_CFe(DTR_NF.Rows[0]["Chave"].ToString().Replace("CFe", ""));
            #endregion

            #region TRIBUTOS
            string Info_Tributo = "Trib. aprox. R$ ";
            Info_Tributo += util_dados.ConfigNumDecimal(util_dados.Calcula_Aliquota_NF_CF(DTR_Item, "ValorTotal", "AliqNacFederal"), 2) + " Federal - R$ ";
            Info_Tributo += util_dados.ConfigNumDecimal(util_dados.Calcula_Aliquota_NF_CF(DTR_Item, "ValorTotal", "AliqEstadual"), 2) + " Estadual ";
            Info_Tributo += "Fonte: " + Parametro_NFe_NFC_SAT.VersaoIBPT;
            #endregion

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_NF", DTR_NF);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item", DTR_Item);
            ReportDataSource ds_Financeiro = new ReportDataSource("ds_Financeiro", DTR_Financeiro);
            /*
            ReportParameter[] Parametro = new ReportParameter[9];

            Parametro[0] = new ReportParameter("DescricaoPessoa", txt_Pessoa.Text);
            Parametro[1] = new ReportParameter("CNPJ_CPF", CNPJ_CPF_Destinatario);
            Parametro[2] = new ReportParameter("N_CupomFiscal", N_Cupom);
            Parametro[3] = new ReportParameter("N_Serie", N_SerieSAT);
            Parametro[4] = new ReportParameter("QRCode", str_QRCode);
            Parametro[5] = new ReportParameter("Barra", str_Barra);
            Parametro[6] = new ReportParameter("Chave", Chave_Tratada);
            Parametro[7] = new ReportParameter("Total_Produto", txt_TotalNF.Text);
            Parametro[8] = new ReportParameter("Info_Tributo", Info_Tributo);
            */
            ReportParameter p1 = new ReportParameter("DescricaoPessoa", txt_Pessoa.Text);
            ReportParameter p2 = new ReportParameter("CNPJ_CPF", CNPJ_CPF_Destinatario);
            ReportParameter p3 = new ReportParameter("N_CupomFiscal", N_Cupom);
            ReportParameter p4 = new ReportParameter("N_Serie", N_SerieSAT);
            ReportParameter p5 = new ReportParameter("QRCode", str_QRCode);
            ReportParameter p6 = new ReportParameter("Barra", str_Barra);
            ReportParameter p7 = new ReportParameter("Chave", Chave_Tratada);
            ReportParameter p8 = new ReportParameter("Total_Produto", txt_TotalNF.Text);
            ReportParameter p9 = new ReportParameter("Info_Tributo", Info_Tributo);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Financeiro);

            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 });

            //rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 });
            /*
            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();

            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);

                if (Parametro_NFe_NFC_SAT.CFe_A4 == true)
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                else
                    imp.Imprimir(documento, Tipo_Impressao.Termica);

                imp = null;
            }*/

            rpt.rpt_Viewer.RefreshReport();
        }

        public string Gera_Estrutura_XML_CFe(int ID_NFe)
        {
            if (ID_NFe == 0)
                return null;

            try
            {
                BLL_NF = new BLL_NF();
                BLL_Pessoa = new BLL_Pessoa();

                NF = new DTO_NF();
                Pessoa = new DTO_Pessoa();
                string CNPJ_CPF = "";
                int Ambiente;
                int UF;

                #region BUSCA INFORMAÇÃO DA NF-e
                NF.ID = ID_NFe;
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DR_NF = BLL_NF.Busca_NF_SAT(NF).Rows[0];
                #endregion

                DS_NF = new DataSet();

                DS_NF.ReadXmlSchema(Parametro_Sistema.Caminho_Sistema + util_Param.Schemas + "nfe_v3.10.xsd");
                DS_NF.EnforceConstraints = false;

                #region DADOS DA NOTA FISCAL ELETRÔNICA
                DR = DS_NF.Tables["infNFe"].NewRow();

                DR["id"] = "0"; //IDENTIFICAÇÃO DA NOTA
                DR["versao"] = Parametro_NFe_NFC_SAT.VersaoXML;

                DR["infNFe_Id"] = 0;

                DS_NF.Tables["infNFe"].Rows.Add(DR);
                #endregion

                #region IDENTIFICAÇÃO DA NOTA FISCAL ELETRONICA

                //BUSCA INFORMAÇÃO DO EMITENTE 
                Pessoa.ID = Convert.ToInt32(DR_NF["ID_Empresa"]);

                DR_Emit = BLL_Pessoa.Busca_Info_Relatorio(Pessoa).Rows[0];

                Ambiente = Parametro_NFe_NFC_SAT.AmbienteNFe;
                UF = Convert.ToInt32(DR_Emit["ID_UF"]);

                DR = DS_NF.Tables["ide"].NewRow();

                DR["ide_Id"] = 0;
                DR["infNFe_Id"] = 0;

                DS_NF.Tables["ide"].Rows.Add(DR);

                //Chave = DR_Emit["cUF"].ToString() + DR["dhEmi"].ToString().Substring(2, 2) + DR["dhEmi"].ToString().Substring(5, 2); //CHAVE (UF + AAMM(DATA EMISSAO))
                #endregion

                #region EMITENTE
                DR = DS_NF.Tables["emit"].NewRow();
                DR["infNFe_Id"] = 0;
                DR["emit_Id"] = 0;

                CNPJ_CPF = "";
                CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Emit["CNPJ_CPF"].ToString());

                if (CNPJ_CPF.Length == 14)
                    DR["CNPJ"] = CNPJ_CPF;
                if (CNPJ_CPF.Length == 11)
                    DR["CPF"] = CNPJ_CPF;

                DR["IE"] = util_dados.Conf_strDoc_NFe(DR_Emit["IE_RG"]);

                DS_NF.Tables["emit"].Rows.Add(DR);
                #endregion

                #region DESTINATÁRIO
                //BUSCA INFORMAÇÃO DO DESTINATÁRIO
                Pessoa.TipoPessoa = Convert.ToInt32(DR_NF["TipoPessoa"]);
                Pessoa.ID = Convert.ToInt32(DR_NF["ID_Pessoa"]);
                DR_Dest = BLL_Pessoa.Busca_Nome(Pessoa).Rows[0];

                DR = DS_NF.Tables["dest"].NewRow();

                DR["dest_Id"] = 0;
                DR["infNFe_Id"] = 0;

                CNPJ_CPF = "";
                CNPJ_CPF = util_dados.Conf_strDoc_NFe(CNPJ_CPF_Destinatario);

                if (CNPJ_CPF.Replace("0", "").Length == 0)
                    DR["xNome"] = DR_Dest["Descricao"].ToString().TrimEnd();
                else
                {
                    if (CNPJ_CPF.Length == 14)
                    {
                        DR["CNPJ"] = CNPJ_CPF;
                        DR["xNome"] = DR_Dest["Descricao"].ToString().TrimEnd();
                    }

                    if (CNPJ_CPF.Length == 11)
                    {
                        DR["CPF"] = CNPJ_CPF;
                        DR["xNome"] = DR_Dest["Descricao"].ToString().TrimEnd();
                    }
                }

                DS_NF.Tables["dest"].Rows.Add(DR);
                #endregion

                #region DETALHAMENTO DE PRODUTOS E SERVIÇOS
                double vTotalTrib = 0;
                double vTotalTribFereral = 0;
                double VTotalTribEstadual = 0;

                DataTable DT = new DataTable();
                DT = BLL_NF.Busca_NF_Item(NF);

                if (DT.Rows.Count >= 1)
                {
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        #region ITEM DETALHAMENTO, INFORMAÇÃO ADICIONAL PRODUTO
                        DR_Item = DT.Rows[i];

                        DR = DS_NF.Tables["det"].NewRow();
                        DR["nItem"] = i + 1;
                        ++Qt_Produto;

                        DR["infAdProd"] = "~-?-~";

                        DR["det_Id"] = i + 1;
                        DR["infNFe_Id"] = 0;
                        DS_NF.Tables["det"].Rows.Add(DR);
                        #endregion

                        #region INFORMAÇÃO ITEM
                        DR = DS_NF.Tables["prod"].NewRow();
                        DR["cProd"] = DR_Item["ID_Produto"];

                        if (Parametro_NFe_NFC_SAT.Exibe_InfoProd == true)
                            DR["xProd"] = DR_Item["DescricaoProduto"].ToString().TrimEnd() + " " + DR_Item["InformacaoAdicional"].ToString().TrimEnd();
                        else
                            DR["xProd"] = DR_Item["DescricaoProduto"].ToString().TrimEnd();

                        if (DR_Item["NCM"].ToString().Replace("0", "").Trim() != "" && DR_Item["NCM"].ToString().Trim().Length == 8 || DR_Item["NCM"].ToString().Trim().Length == 2)
                            DR["NCM"] = DR_Item["NCM"].ToString().Trim();
                        else
                            DR["NCM"] = string.Empty;

                        DR["CFOP"] = DR_Item["CFOP"];
                        DR["uCom"] = DR_Item["DescricaoUnidade"].ToString().TrimEnd();
                        DR["qCom"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                        DR["vUnCom"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 13);

                        if (Convert.ToDouble(DR_Item["Desconto"]) > 0)
                            DR["vDesc"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["Desconto"]), 12);

                        if (Convert.ToDouble(DR_Item["Acrescimo"]) > 0)
                            DR["vOutro"] = util_dados.ConfigNumDecimal(DR_Item["Acrescimo"], 12);

                        DR["det_Id"] = i + 1;
                        DR["prod_ID"] = i + 1;

                        DS_NF.Tables["prod"].Rows.Add(DR);
                        #endregion

                        #region IMPOSTO
                        DR = DS_NF.Tables["imposto"].NewRow();

                        double AliqNacFederal = util_dados.Verifica_Double(DR_Item["AliqNacFederal"].ToString());
                        double AliqImpFederal = util_dados.Verifica_Double(DR_Item["AliqImpFederal"].ToString());
                        double AliqEstadudal = util_dados.Verifica_Double(DR_Item["AliqEstadual"].ToString());

                        double TotalAliqNac = AliqNacFederal + AliqEstadudal;
                        double TotalAliqImp = AliqImpFederal + AliqEstadudal;

                        if (Convert.ToInt32(DR_Item["Origem"]) == 0 ||
                           Convert.ToInt32(DR_Item["Origem"]) == 3 ||
                            Convert.ToInt32(DR_Item["Origem"]) == 4 ||
                            Convert.ToInt32(DR_Item["Origem"]) == 5)
                        {
                            if (TotalAliqNac > 0)
                            {
                                // DR["vTotTrib"] = util_dados.ConfigNumDecimal(util_dados.Calcula_Porcentagem(TotalAliqNac, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"]))), 12);
                                vTotalTrib += util_dados.Calcula_Porcentagem(TotalAliqNac, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                                vTotalTribFereral += util_dados.Calcula_Porcentagem(AliqNacFederal, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                                VTotalTribEstadual += util_dados.Calcula_Porcentagem(AliqEstadudal, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                            }
                            // else
                            //DR["vTotTrib"] = util_dados.ConfigNumDecimal("0", 12);
                        }
                        else
                            if (TotalAliqImp > 0)
                        {
                            //DR["vTotTrib"] = util_dados.ConfigNumDecimal(util_dados.Calcula_Porcentagem(TotalAliqImp, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"]))), 12);
                            vTotalTrib += util_dados.Calcula_Porcentagem(TotalAliqImp, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                            vTotalTribFereral += util_dados.Calcula_Porcentagem(AliqImpFederal, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                            VTotalTribEstadual += util_dados.Calcula_Porcentagem(AliqEstadudal, (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                        }
                        //else
                        //DR["vTotTrib"] = util_dados.ConfigNumDecimal("0", 12);

                        DR["imposto_Id"] = i + 1;
                        DR["det_Id"] = i + 1;

                        DS_NF.Tables["imposto"].Rows.Add(DR);

                        #region ICMS NORMAL E ST
                        DR = DS_NF.Tables["ICMS"].NewRow();
                        DR["ICMS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NF.Tables["ICMS"].Rows.Add(DR);

                        if (Convert.ToInt32((DR_Item["CSOSN"].ToString() + "0")) > 0)
                        #region SIMPLES NACIONAL
                        {
                            switch (Convert.ToInt32(DR_Item["CSOSN"]))
                            {
                                //CSOSN - 101 - SIMPLES COM APROVEITAMENTO DE CREDITO
                                //CSOSN - 201 - SIMPLES COM APROVEITAMENTO DE CREDITO ST
                                //CSOSN - 202, 203 - SIMPLES SEM APROVEITAMENTO DE CREDITO ST
                                #region CSOSN - 101, 201, 202, 203
                                case 101:
                                case 201:
                                case 202:
                                case 203:
                                    DR = DS_NF.Tables["ICMSSN102"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = "102";

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMSSN102"].Rows.Add(DR);
                                    break;
                                #endregion

                                //CSOSN - 102, 300 - SIMPLES SEM APROVEITAMENTO DE CREDITO
                                //CSOSN - 500 - ICMS COBRADO ANTERIORMENTE POR SUBSTITUIÇÃO TRIBUTÁRIA                              
                                #region CSOSN - 102, 300, 500
                                case 102:
                                case 300:
                                case 500:
                                    DR = DS_NF.Tables["ICMSSN102"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMSSN102"].Rows.Add(DR);

                                    break;
                                #endregion

                                #region CSOSN - 900 - OUTROS
                                case 900:
                                    DR = DS_NF.Tables["ICMSSN900"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMSSN900"].Rows.Add(DR);
                                    break;
                                    #endregion
                            }
                        }
                        #endregion
                        else
                        #region REGIME NORMAL
                        {
                            switch (Convert.ToInt32(DR_Item["CST"]))
                            {
                                //CST – 00 – TRIBUTADA INTEGRALMENTE
                                //CST – 20 - COM REDUÇÃO DE BASE DE CÁLCULO
                                //CST - 90 - OUTROS                               
                                #region CST – 00, 20, 90
                                case 0:
                                case 20:
                                case 90:
                                    DR = DS_NF.Tables["ICMS00"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMS00"].Rows.Add(DR);
                                    break;
                                #endregion

                                //CST - 10 - TRIBUTADA E COM COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                //CST – 30 - ISENTA OU NÃO TRIBUTADA E COM COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                //CST – 51 - DIFERIMENTO - A EXIGÊNCIA DO PREENCHIMENTO DAS INFORMAÇÕES DO ICMS DIFERIDO FICA À CRITÉRIO DE CADA UF.
                                //CST - 70 - COM REDUÇÃO DE BASE DE CÁLCULO E COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                #region CST - 10, 30, 51, 70
                                case 10:
                                case 30:
                                case 51:
                                case 70:
                                    DR = DS_NF.Tables["ICMS00"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = "90";
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMS00"].Rows.Add(DR);
                                    break;
                                #endregion

                                //CST – 40 - ISENTA, 41 - NÃO TRIBUTADA E 50 - SUSPENSÃO
                                //CST – 60 - ICMS COBRADO ANTERIORMENTE POR SUBSTITUIÇÃO TRIBUTÁRIA                                
                                #region
                                case 40:
                                case 41:
                                case 50:
                                case 60:
                                    DR = DS_NF.Tables["ICMS40"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NF.Tables["ICMS40"].Rows.Add(DR);
                                    break;
                                    #endregion
                            }
                        }
                        #endregion
                        #endregion

                        #region PIS
                        DR = DS_NF.Tables["PIS"].NewRow();

                        DR["PIS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NF.Tables["PIS"].Rows.Add(DR);

                        switch (Convert.ToInt32(DR_Item["CSTPIS"]))
                        {
                            case 1:
                            case 2:
                                DR = DS_NF.Tables["PISAliq"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');
                                DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorTotal"], 12);
                                DR["pPIS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaPIS"], 12);

                                DR["PIS_Id"] = i + 1;
                                DS_NF.Tables["PISAliq"].Rows.Add(DR);
                                break;

                            case 3:
                                DR = DS_NF.Tables["PISQtde"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');
                                DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaPIS"], 14);

                                DR["PIS_Id"] = i + 1;
                                DS_NF.Tables["PISQtde"].Rows.Add(DR);
                                break;

                            case 4:
                            //case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                DR = DS_NF.Tables["PISNT"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');

                                DR["PIS_Id"] = i + 1;
                                DS_NF.Tables["PISNT"].Rows.Add(DR);
                                break;

                            case 49:
                                DR = DS_NF.Tables["PISNT"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');

                                DR["PIS_Id"] = i + 1;
                                DS_NF.Tables["PISNT"].Rows.Add(DR);
                                break;

                            case 99:
                                DR = DS_NF.Tables["PISOutr"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"];

                                if (Convert.ToInt32(DR_Item["AliquotaPIS"]) > 0)
                                {
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 12);
                                    DR["pPIS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaPIS"], 12);
                                }
                                else
                                {
                                    DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                    DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaPIS"], 14);
                                }

                                DR["PIS_Id"] = i + 1;
                                DS_NF.Tables["PISOutr"].Rows.Add(DR);
                                break;
                        }
                        #endregion

                        #region COFINS
                        DR = DS_NF.Tables["COFINS"].NewRow();

                        DR["COFINS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NF.Tables["COFINS"].Rows.Add(DR);

                        switch (Convert.ToInt32(DR_Item["CSTCOFINS"]))
                        {
                            case 1:
                            case 2:
                                DR = DS_NF.Tables["COFINSAliq"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');
                                DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorTotal"], 12);
                                DR["pCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaCOFINS"], 12);

                                DR["COFINS_Id"] = i + 1;
                                DS_NF.Tables["COFINSAliq"].Rows.Add(DR);
                                break;

                            case 3:
                                DR = DS_NF.Tables["COFINSQtde"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');
                                DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaCOFINS"], 14);

                                DR["COFINS_Id"] = i + 1;
                                DS_NF.Tables["COFINSQtde"].Rows.Add(DR);
                                break;

                            case 4:
                            //case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                DR = DS_NF.Tables["COFINSNT"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');

                                DR["COFINS_Id"] = i + 1;
                                DS_NF.Tables["COFINSNT"].Rows.Add(DR);
                                break;

                            case 49:
                                DR = DS_NF.Tables["COFINSNT"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');

                                DR["COFINS_Id"] = i + 1;
                                DS_NF.Tables["COFINSNT"].Rows.Add(DR);
                                break;

                            case 99:
                                DR = DS_NF.Tables["COFINSOutr"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"];

                                if (Convert.ToInt32(DR_Item["AliquotaCOFINS"]) > 0)
                                {
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 12);
                                    DR["pCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaCOFINS"], 12);
                                }
                                else
                                {
                                    DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                    DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaCOFINS"], 14);
                                }

                                DR["COFINS_Id"] = i + 1;
                                DS_NF.Tables["COFINSOutr"].Rows.Add(DR);
                                break;
                        }
                        #endregion
                        #endregion
                    }
                }
                #endregion

                #region PAGAMENTO
                DataTable _DT = new DataTable();

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = ID_Venda;

                _DT = BLL_Venda.Busca_PagamentoSAT(Venda);

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DR = DS_NF.Tables["pag"].NewRow();
                        DR["infNFe_Id"] = 0;
                        DR["pag_Id"] = i + 1;
                        //DS_NF.Tables["pag"].Rows.Add(DR);

                        // DR = DS_NF.Tables["pagItem"].NewRow();
                        //DR["pagItem"] = i + 1;

                        switch (Convert.ToInt32(_DT.Rows[i]["Tipo"]))
                        {
                            case 1: //BOLETO
                                DR["tPag"] = "05";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22);
                                break;

                            case 2: //CARTÃO CREDITO
                                DR["tPag"] = "03";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22) + "-~.~-";
                                break;

                            case 3: //CHEQUE
                                DR["tPag"] = "02";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22);
                                break;

                            case 4: //DINHEIRO
                                DR["tPag"] = "01";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22);
                                break;

                            case 5: //CARTEIRA
                                DR["tPag"] = "05";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22);
                                break;

                            case 6: //OUTROS
                                DR["tPag"] = "99";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22);
                                break;

                            case 7: //CARTÃO DÉBITO
                                DR["tPag"] = "04";
                                DR["vPag"] = util_dados.ConfigNumDecimal(_DT.Rows[i]["Valor"], 22) + "-~.~-";
                                break;
                        }

                        // DR["pag_Id"] = 0;
                        DS_NF.Tables["pag"].Rows.Add(DR);
                    }
                #endregion

                #region TOTAIS
                DR = DS_NF.Tables["total"].NewRow();
                DR["total_Id"] = 0;// Qt_Produto.ToString();
                DR["infNFe_Id"] = 0;
                DS_NF.Tables["total"].Rows.Add(DR);
                #endregion

                #region TOTAIS REFERENTE AO ICMS
                DR = DS_NF.Tables["ICMSTot"].NewRow();

                DR["total_Id"] = 0; // Qt_Produto.ToString();
                DR["vTotTrib"] = util_dados.ConfigNumDecimal(vTotalTrib, 12);

                DS_NF.Tables["ICMSTot"].Rows.Add(DR);
                #endregion

                #region CONFIGURA CAMPOS ANTES DE GERAR O XML
                DS_NF.AcceptChanges();

                txt_XML = new StringWriter();
                txt_XML.NewLine = "";

                DS_NF.WriteXml(txt_XML, XmlWriteMode.IgnoreSchema);

                string Aux = util_dados.Limpa_StringXML(txt_XML.ToString());

                //REMOVE ESPAÇOS ENTRE AS TAGS
                txt_XML.GetStringBuilder().Remove(0, txt_XML.ToString().Length);
                txt_XML.GetStringBuilder().Append(Aux);

                Aux = "";

                while (txt_XML.ToString().IndexOf("</infAdProd><prod>") > -1)
                {
                    Aux = txt_XML.ToString().Substring(txt_XML.ToString().IndexOf("\"><infAdProd>") + 2, txt_XML.ToString().IndexOf("</infAdProd><prod>") - txt_XML.ToString().IndexOf("\"><infAdProd>") + 10);

                    if (txt_XML.ToString().IndexOf("</imposto></det>") == -1)
                        throw new Exception("tag </imposto> não encontrada");

                    if (txt_XML.ToString().IndexOf("\"><infAdProd>") == -1)
                        throw new Exception("tag <infAdProd> não encontrada");

                    txt_XML.GetStringBuilder().Remove(txt_XML.ToString().IndexOf("\"><infAdProd>") + 2, Aux.Length);
                    txt_XML.GetStringBuilder().Insert(txt_XML.ToString().IndexOf("</imposto></det>") + 10, Aux);
                }

                //AJUSTANDO A TAG IE DO EMITENTE
                txt_XML.GetStringBuilder().Replace("NewDataSet", "CFe");
                txt_XML.GetStringBuilder().Replace("</xFant>", "</xFant>" + Aux);
                txt_XML.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", "");
                txt_XML.GetStringBuilder().Replace("infNFe versao", "infCFe versaoDadosEnt").Replace(" Id=\"0\"", "");

                txt_XML.GetStringBuilder().Replace("<PISNT><CST>49</CST></PISNT>", "<PISSN><CST>49</CST></PISSN>");
                txt_XML.GetStringBuilder().Replace("<COFINSNT><CST>49</CST></COFINSNT>", "<COFINSSN><CST>49</CST></COFINSSN>");
                txt_XML.GetStringBuilder().Replace("</total><pag>", "</total><pgto><pag>");
                txt_XML.GetStringBuilder().Replace("</pag></infNFe>", "</pag></pgto></infNFe>");
                txt_XML.GetStringBuilder().Replace("<pag>", "<MP>").Replace("</pag>", "</MP>").Replace("<tPag>", "<cMP>").Replace("</tPag>", "</cMP>").Replace("<vPag>", "<vMP>").Replace("</vPag>", "</vMP>");
                txt_XML.GetStringBuilder().Replace("infNFe>", "infCFe>");
                txt_XML.GetStringBuilder().Replace("orig>", "Orig>");
                txt_XML.GetStringBuilder().Replace("-~.~-</vMP>", "</vMP><cAdmC>999</cAdmC>");
                txt_XML.GetStringBuilder().Replace("<infAdProd>~-?-~</infAdProd>", "");
                txt_XML.GetStringBuilder().Replace("<ICMSTot><vTotTrib>", "<vCFeLei12741>").Replace("</vTotTrib></ICMSTot>", "</vCFeLei12741>");
                txt_XML.GetStringBuilder().Replace("<ide/>", "<ide><CNPJ>" + Parametro_NFe_NFC_SAT.CNPJ_Software + "</CNPJ><signAC>" + Parametro_NFe_NFC_SAT.AssinaturaSAT + "</signAC><numeroCaixa>" + Parametro_NFe_NFC_SAT.NumeroCaixa.ToString().PadLeft(3, '0') + "</numeroCaixa></ide>");
                txt_XML.GetStringBuilder().Replace("</vUnCom>", "</vUnCom><indRegra>A</indRegra>");
                txt_XML.GetStringBuilder().Replace("</emit>", "<indRatISSQN>N</indRatISSQN></emit>");
                #endregion

                return "<?xml version='1.0' encoding='UTF-8'?>" + txt_XML.ToString().Replace("\"", "'");
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        public string Gera_Estrutura_XML_CFe_Cancelamento(int ID_NFe)
        {
            if (ID_NFe == 0)
                return null;

            try
            {
                BLL_NF = new BLL_NF();
                BLL_Pessoa = new BLL_Pessoa();

                NF = new DTO_NF();

                #region BUSCA INFORMAÇÃO DA NF-e
                NF.ID = ID_NFe;
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DR_NF = BLL_NF.Busca_NF_SAT(NF).Rows[0];
                #endregion

                string XML = "<CFeCanc><infCFe chCanc='";
                XML += DR_NF["Chave"].ToString() + "'>";
                XML += "<ide><CNPJ>" + Parametro_NFe_NFC_SAT.CNPJ_Software + "</CNPJ><signAC>" + Parametro_NFe_NFC_SAT.AssinaturaSAT + "</signAC><numeroCaixa>" + DR_NF["Serie"].ToString().PadLeft(3, '0') + "</numeroCaixa></ide>";
                XML += "<emit></emit><dest>";

                if (util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString().Replace("0", "")).Trim() != string.Empty)
                {
                    if (util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString()).Length == 11)
                        XML += "<CPF>" + util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString()) + "</CPF>";

                    if (util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString()).Length == 14)
                        XML += "<CNPJ>" + util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString()) + "</CNPJ>";
                }

                XML += "</dest>";
                XML += "<total></total></infCFe></CFeCanc>";

                //return "<?xml version='1.0' encoding='UTF-8'?>" + XML;

                return XML;
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }
        #endregion

        #region FORM
        private void UI_NFCe_SAT_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFCe_SAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) //FINALIZA VENDA
            {
                bt_Emitir.Enabled = false;
                Grava_NF();
            }
        }

        private void UI_NFCe_SAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region BUTTON
        private void bt_Emitir_Click(object sender, EventArgs e)
        {
            bt_Emitir.Enabled = false;

            Grava_NF();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            bt_Cancelar.Enabled = false;

            Cancelar_NF();
        }
        #endregion
    }
}

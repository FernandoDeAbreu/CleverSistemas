using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.NFe;
using System.Threading;
using System.IO;
using System.Xml;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using Microsoft.Reporting.WinForms;

namespace Sistema.UI
{
    public partial class UI_CFe_Util : Sistema.UI.UI_Modelo
    {
        public UI_CFe_Util()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NF BLL_NF;
        BLL_Pessoa BLL_Pessoa;
        BLL_Venda BLL_Venda;
        BLL_OS BLL_OS;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region ESTRUTURA
        DTO_NF NF;
        DTO_Pessoa Pessoa;
        DTO_CFe_SAT CFe_SAT;
        DTO_CFe_SAT_Retorno CFe_SAT_Retorno;
        DTO_Parametro Parametro;
        DTO_Venda Venda;
        DTO_OS OS;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;

        int Qt_Produto = 0;

        DataRow DR_NF;
        DataRow DR_Emit;
        DataRow DR;
        DataRow DR_Dest;
        DataRow DR_Item;
        DataSet DS_NF;

        bool Seleciona;

        StringWriter txt_XML;

        DateTime ValidaData;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "GERENCIAR CF-e SAT";

            TabPage1.Text = "CF-e SAT";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            dg_NFe.AutoGenerateColumns = false;
            dg_Evento.AutoGenerateColumns = false;
            
            mk_DataInicial.Text = DateTime.Now.ToString();
            mk_DataFinal.Text = DateTime.Now.ToString();
            mk_DataInicial.Focus();

            CarregaTipoPessoaP();
            CarregaCombo();
            Carrega_Parametro();
        }

        private void CarregaTipoPessoaP()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;
        }

        private void CarregaPessoaP()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaP);
                cb_ID_PessoaP.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void CarregaCombo()
        {
            DataTable _DT = new DataTable();

            List<string> aux = new List<string> { "TODAS", "ASSINADA", "AUTORIZADA",
                                                  "CANCELADA", "DENEGADA", "EM DIGITAÇÃO",
                                                  "VALIDADA", "EM PROCESSAMENTO", "ENVIADA VIA SAT" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoNFeP);
            cb_SituacaoNFeP.SelectedIndex = 0;
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
                CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_NF["CNPJ_CPF_Destinatario"].ToString());

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


                if (Convert.ToInt32(DR_NF["ID_Venda"]) > 0)
                {
                    BLL_Venda = new BLL_Venda();
                    Venda = new DTO_Venda();

                    Venda.ID = Convert.ToInt32(DR_NF["ID_Venda"]);

                    _DT = BLL_Venda.Busca_PagamentoSAT(Venda);
                }

                if (Convert.ToInt32(DR_NF["ID_OS"]) > 0)
                {
                    BLL_OS = new BLL_OS();
                    OS = new DTO_OS();

                    OS.ID = Convert.ToInt32(DR_NF["ID_OS"]);

                    _DT = BLL_OS.Busca_PagamentoSAT(OS);
                }

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
                txt_XML.GetStringBuilder().Replace("-~.~-</vMP>", "</vMP><cAdmC>999</cAdmC>");
                txt_XML.GetStringBuilder().Replace("<infAdProd>~-?-~</infAdProd>", "");
                txt_XML.GetStringBuilder().Replace("orig>", "Orig>");
                txt_XML.GetStringBuilder().Replace("<ICMSTot><vTotTrib>", "<vCFeLei12741>").Replace("</vTotTrib></ICMSTot>", "</vCFeLei12741>");
                txt_XML.GetStringBuilder().Replace("<ide/>", "<ide><CNPJ>" + Parametro_NFe_NFC_SAT.CNPJ_Software + "</CNPJ><signAC>" + Parametro_NFe_NFC_SAT.AssinaturaSAT + "</signAC><numeroCaixa>" + Parametro_NFe_NFC_SAT.NumeroCaixa.ToString().PadLeft(3, '0') + "</numeroCaixa></ide>");
                txt_XML.GetStringBuilder().Replace("</vUnCom>", "</vUnCom><indRegra>A</indRegra>");
                txt_XML.GetStringBuilder().Replace("</emit>", "<indRatISSQN>N</indRatISSQN></emit>");
                #endregion

                return "<?xml version='1.0'?>" + txt_XML.ToString().Replace("\"", "'");
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        private void Envia_NF()
        {
            txt_status.Text = "EMITINDO CF-e...";
            try
            {
                string XML = Gera_Estrutura_XML_CFe(Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value));

                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                BLL_NF = new BLL_NF();
                NF = new DTO_NF();

                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);

                DataTable _DT = new DataTable();
                _DT = BLL_NF.Busca_NF_SAT(NF);

                if (Convert.ToInt32(_DT.Rows[0]["Status_CFe"]) == 4)
                {
                    CFe_SAT.Funcao = CFe_SAT_Funcao.ConsultarNumeroSessao;
                    CFe_SAT.NumeroSessao = Convert.ToInt32(_DT.Rows[0]["Controle_CF"]);
                }
                else
                {
                    CFe_SAT.NumeroSessao = util_dados.Gera_Sessao();
                    CFe_SAT.Funcao = CFe_SAT_Funcao.EnviarDadosVenda;
                    CFe_SAT.XML = XML;

                    NF.Situacao = 7;
                    NF.Status_CFe = 4;
                    NF.Controle_CF = CFe_SAT.NumeroSessao;

                    BLL_NF.Altera_Sessao(NF);
                    BLL_NF.Altera_Status_CFe(NF);
                }

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                {
                    NF = new DTO_NF();
                    NF.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);
                    NF.Situacao = 8;
                    NF.Chave = CFe_SAT_Retorno.Chave;
                    NF.QRCode = CFe_SAT_Retorno.AssinaturaQR;
                    NF.Status_CFe = 0;
                    NF.Retorno_CFe = CFe_SAT_Retorno.Mensagem;
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

                    MessageBox.Show(util_msg.msg_EmissaoSATSucesso, this.Text);

                    txt_status.Text = "GERANDO EXTRATO DO CF-e! AGUARDE...";

                    SAT = null;
                    Imprime_SAT();
                }
                else
                {
                    NF.Situacao = 5;
                    NF.Status_CFe = 1;
                    BLL_NF.Altera_Status_CFe(NF);

                    MessageBox.Show(util_msg.msg_EmissaoSATErro + CFe_SAT_Retorno.Cod_Erro + "-" + CFe_SAT_Retorno.Mensagem);
                }

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Configura_Botao()
        {
            if (dg_NFe.Rows.Count == 0)
                return;

            bt_Cancelar.Enabled = true;
            bt_DANFE.Enabled = true;
            bt_Transmitir.Enabled = true;
            bt_Email.Enabled = true;
            bt_Excluir.Enabled = true;

            switch (Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Situacao"].Value))
            {
                case 1: //ASSINADA
                    bt_Excluir.Enabled = false;
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 2://AUTORIZADA
                    bt_Excluir.Enabled = false;
                    bt_Transmitir.Enabled = false;
                    break;

                case 3://CANCELADA
                    bt_Excluir.Enabled = false;
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = true;
                    bt_Transmitir.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 4://DENEGADA
                    bt_Excluir.Enabled = false;
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = false;
                    bt_Transmitir.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 5://EM DIGITAÇÃO     
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 6://VALIDADA
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 7://EM PROCESSAMENTO
                    bt_Excluir.Enabled = false;
                    bt_Cancelar.Enabled = false;
                    bt_DANFE.Enabled = false;
                    bt_Email.Enabled = false;
                    break;

                case 8://ENVIADO SAT
                    bt_Excluir.Enabled = false;
                    bt_Transmitir.Enabled = false;
                    bt_Cancelar.Enabled = true;
                    bt_DANFE.Enabled = true;
                    bt_Email.Enabled = false;
                    break;
            }
        }

        private void Consulta_XML(string _Data, DateTime _Periodo)
        {/*
            _Periodo = util_dados.Config_Data(Convert.ToDateTime(_Periodo), 9).ToString();
            filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*" + ".xml");
            foreach (string item in filesInFolder)
                _ProcessaNFe.Consulta_Recibo(item);
            break;*/
        }

        private void Envia_Email()
        {
            string[] filesInFolder;
            string Anexo = string.Empty;

            int Serie = 0;
            int ID_NFe = 0;
            string XML = string.Empty;

            string _Periodo = util_dados.Config_Data(Convert.ToDateTime(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_DataEmissaoNFe"].Value), 9).ToString() + "\\";

            filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*");

            foreach (string item in filesInFolder)
            {
                Serie = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(22, 3));
                ID_NFe = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(25, 9));

                if (Serie == Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SerieNFe"].Value) &&
                    ID_NFe == Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_NFe"].Value))
                {
                    if (item.IndexOf(NFe_extxml.ProcNFe) != -1)
                        XML = item;

                    Anexo += item + "; ";
                }

                string num_NFe = string.Empty;
                string serie_NFe = string.Empty;
                string valor_NFe = string.Empty;
                string emitente_NFe = string.Empty;
                string cnpj_emitente_NFe = string.Empty;
                string emissao_NFe = string.Empty;

                XmlDocument xml = new XmlDocument();
                xml.Load(XML);

                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
                    num_NFe = _elemento.GetElementsByTagName("nNF")[0].InnerText;
                    serie_NFe = _elemento.GetElementsByTagName("serie")[0].InnerText;
                    emissao_NFe = util_dados.Config_Data(Convert.ToDateTime(_elemento.GetElementsByTagName("dhEmi")[0].InnerText), 3).ToString();
                }

                XmlNodeList _emi = xml.GetElementsByTagName("emit");

                foreach (XmlNode _aux in _emi)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    cnpj_emitente_NFe = util_dados.Conf_CPF_CNPJ(_elemento.GetElementsByTagName("CNPJ")[0].InnerText, Documento.CNPJ);
                    emitente_NFe = _elemento.GetElementsByTagName("xFant")[0].InnerText;
                }

                XmlNodeList _total = xml.GetElementsByTagName("total");
                foreach (XmlNode _aux in _total)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    valor_NFe = _elemento.GetElementsByTagName("vNF")[0].InnerText;
                }

                string _msg = util_msg.msg_Mensagem_Email_NFe;
                _msg = _msg.Replace("#num_nota#", num_NFe);
                _msg = _msg.Replace("#serie_nota#", serie_NFe);
                _msg = _msg.Replace("#nome_emitente#", emitente_NFe);
                _msg = _msg.Replace("#valor_nota#", valor_NFe);

                UI_Email UI_Email = new UI_Email();
                UI_Email.Assunto = util_msg.msg_Assunto_Email_NFe.Replace("#num_nota#", num_NFe);
                UI_Email.Mensagem = _msg;
                UI_Email.Endereco = "";
                UI_Email.Anexo = Anexo;

                util_dados.CarregaForm(UI_Email, this.MdiParent);
            }
        }

        private void Imprime_SAT()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();

            string rpt_Nome = string.Empty;

            if (dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SituacaoNFe"].Value.ToString() == "CANCELADA")
            {
                if (Parametro_NFe_NFC_SAT.CFe_A4 == true)
                    rpt_Nome = "rpt_SAT_A4_Canc.rdlc";
                else
                    rpt_Nome = "rpt_SAT_Termica_Canc.rdlc";
            }
            else
            {
                if (Parametro_NFe_NFC_SAT.CFe_A4 == true)
                    rpt_Nome = "rpt_SAT_A4.rdlc";
                else
                    rpt_Nome = "rpt_SAT_Termica.rdlc";
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
            rpt.Show();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);
            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_NF = BLL_NF.Busca_NF_SAT(NF);
            DataTable DTR_Item = BLL_NF.Busca_NF_Item(NF);

            #region PAGAMENTO
            DataTable DTR_Financeiro = new DataTable();
            DTR_Financeiro.Columns.Add("Tipo", typeof(String));
            DTR_Financeiro.Columns.Add("Valor", typeof(Double));

            DataTable _DT = new DataTable();

            if (Convert.ToInt32(DTR_NF.Rows[0]["ID_Venda"]) > 0)
            {

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(DTR_NF.Rows[0]["ID_Venda"].ToString());
                _DT = BLL_Venda.Busca_PagamentoSAT(Venda);
            }

            if (Convert.ToInt32(DTR_NF.Rows[0]["ID_OS"]) > 0)
            {
                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(DTR_NF.Rows[0]["ID_OS"].ToString());
                _DT = BLL_OS.Busca_PagamentoSAT(OS);
            }

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

            ReportParameter p1 = new ReportParameter("DescricaoPessoa", dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_PessoaNFe"].Value.ToString());
            ReportParameter p2 = new ReportParameter("CNPJ_CPF", DTR_NF.Rows[0]["CNPJ_CPF_Destinatario"].ToString());
            ReportParameter p3 = new ReportParameter("N_CupomFiscal", N_Cupom);
            ReportParameter p4 = new ReportParameter("N_Serie", N_SerieSAT);
            ReportParameter p5 = new ReportParameter("QRCode", str_QRCode);
            ReportParameter p6 = new ReportParameter("Barra", str_Barra);
            ReportParameter p7 = new ReportParameter("Chave", Chave_Tratada);
            ReportParameter p8 = new ReportParameter("Total_Produto", DTR_NF.Rows[0]["ValorTotal"].ToString());
            ReportParameter p9 = new ReportParameter("Info_Tributo", Info_Tributo);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Financeiro);

            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 });

            rpt.rpt_Viewer.RefreshReport();
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoaP();
            cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_PessoaP.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            dg_NFe.DataSource = null;

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.Consulta_Emissao.Filtra = true;
            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            NF.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            NF.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            NF.Serie = util_dados.Verifica_int(txt_Serie.Text);
            NF.ID_NFe = util_dados.Verifica_int(txt_ID_NFeP.Text);
            NF.Situacao = Convert.ToInt32(cb_SituacaoNFeP.SelectedValue);
            NF.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
            NF.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            NF.Modelo = 59;

            DT = BLL_NF.Busca_NF(NF);

            dg_NFe.DataSource = DT;
            util_dados.CarregaCampo(this, DT, gb_Evento);
        }
        #endregion

        #region FORM
        private void UI_NFe_Util_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFe_Util_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_NFe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dg_NFe.EndEdit();
            Configura_Botao();
        }

        private void dg_NFe_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SelecionaNFe"].Value) == true)
                {
                    dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SelecionaNFe"].Value = false;
                    return;
                }

                if (Convert.ToBoolean(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SelecionaNFe"].Value) == false)
                    dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_SelecionaNFe"].Value = true;

                Configura_Botao();
            }
            catch (Exception)
            {
            }
        }

        private void dg_NFe_Leave(object sender, EventArgs e)
        {
            Configura_Botao();
        }

        private void dg_NFe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg_NFe.Columns[e.ColumnIndex].Name == "col_SituacaoNFe")
                if (e.Value != null)
                    switch (e.Value.ToString())
                    {
                        case "AUTORIZADA":
                        case "CF-e AUTORIZADO":
                            dg_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                            break;

                        case "CANCELADA":
                        case "DENEGADA":
                            dg_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            break;

                        case "ASSINADA":
                        case "VALIDADA":
                            dg_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                            break;

                        case "Nº INUTILIZADO":
                            dg_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                            break;
                    }
        }
        #endregion

        #region BUTTON
        private void bt_Transmitir_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_CFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorCFe, this.Text);
                return;
            }

            txt_status.Text = "AGUARDE, ENVIANDO NF-e...";

            if (Parametro_NFe_NFC_SAT.Monitor_CFe == false)
                Envia_NF();

            if (Parametro_NFe_NFC_SAT.Monitor_CFe == true)
            {
                NF.Status_CFe = 2;

                BLL_NF.Altera_Status_CFe(NF);

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

                            Imprime_SAT();

                            Pesquisa();
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
            txt_status.Clear();
        }

        private void bt_DANFE_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_CFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorCFe, this.Text);
                return;
            }

            txt_status.Text = "VERIFICANDO...";

            Imprime_SAT();

            txt_status.Clear();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_CFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorCFe, this.Text);
                return;
            }

            try
            {
                UI_CFe UI_CFe = new UI_CFe();
                UI_CFe.ID_NF = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);
                UI_CFe.Cancelamento = true;
                UI_CFe.ShowDialog();

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

        }

        private void bt_Email_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_CFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorCFe, this.Text);
                return;
            }

            Envia_Email();
        }

        private void bt_Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Situacao"].Value) == 5)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;

                    BLL_NF = new BLL_NF();
                    BLL_Venda = new BLL_Venda();
                    BLL_OS = new BLL_OS();

                    NF = new DTO_NF();
                    Venda = new DTO_Venda();
                    OS = new DTO_OS();

                    NF.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);
                    BLL_NF.Exclui(NF);

                    if (dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Venda"].Value != DBNull.Value &&
                        Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Venda"].Value) > 0)
                    {
                        Venda.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Venda"].Value);
                        Venda.NFe = false;

                        BLL_Venda.Altera_NFe(Venda);
                    }

                    if (dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_OS"].Value != DBNull.Value &&
                        Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_OS"].Value) > 0)
                    {
                        OS.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_OS"].Value);
                        OS.NFe = false;

                        BLL_OS.Altera_NFe(OS);
                    }

                    Pesquisa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MASKEDBOX
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
        #endregion

        #region COMBOBOX
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
            CarregaPessoaP();
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_NF_TextChanged(object sender, EventArgs e)
        {
            dg_Evento.DataSource = null;

            if (txt_ID_NF.Text.Trim() == string.Empty)
                return;

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.ID = Convert.ToInt32(txt_ID_NF.Text);
            NF.FiltraEvento = true;

            DT = BLL_NF.Busca_NF_Evento(NF);

            dg_Evento.DataSource = DT;
        }
        #endregion
    }
}

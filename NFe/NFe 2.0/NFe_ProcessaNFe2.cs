using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO;
using Sistema.BLL;
using Sistema.DTO;
using System.Data;
using Sistema.BLL;
using Sistema.UTIL;
using Sistema.NFe;
using System.Reflection;
using System.Windows.Forms;

namespace Sistema.NFe
{
    public class NFe_ProcessaNFe2
    {
        #region VARIAVEIS DE CLASSE
        BLL_Parametro BLL_Parametro;
        BLL_NF BLL_NF;
        BLL_Pessoa BLL_Pessoa;
        BLL_NCM BLL_NCM;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataSet DS_NFe;

        DataTable DT;
        DataTable DT_Lacre;
        DataTable DT_Imp;
        DataTable DT_Adicao;

        DataRow DR_NF;
        DataRow DR_Emit;
        DataRow DR_Dest;
        DataRow DR_NFRef;
        DataRow DR_Ret;
        DataRow DR_Ent;
        DataRow DR_Transp;
        DataRow DR_Vol;
        DataRow DR_Lacre;
        DataRow DR_Fat;
        DataRow DR_Item;
        DataRow DR_Imp;
        DataRow DR_Adicao;
        DataRow DR;

        StringWriter txt_XML;

        string ErroInfo;
        string Chave;

        int DV_NF;
        int Qt_Produto = 0;
        int Qt_Servico = 0;
        int DI_ID = 0;
        int Vol_ID = 0;

        List<DTO_NF_Itens> Itens = new List<DTO_NF_Itens>();
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Parametro Parametro;
        DTO_NF NFe;
        DTO_NCM NCM;
        #endregion

        #region CHECAR CAMPOS NF-e
        private void ChecaCampo(string str, string tag, ObOp optional, int minLength, int maxLength)
        {
            int len = str.Trim().Length;
            if (len == 0 && optional == ObOp.Opcional)
                return;

            if (len == 0 && minLength > 0)
                this.ErroInfo += string.Format("O Campo {0} deve ser informado. Conteúdo: {1}", tag, str) + Environment.NewLine;
            else
                if (len > maxLength || len < minLength)
                this.ErroInfo += string.Format("O Campo {0} deve ter seu tamanho entre {2} e {3}. Conteúdo: {1}", tag, str, minLength, maxLength) + Environment.NewLine;
        }

        private void ChecaCampo(string str, string tag, ObOp optional, int minLength, int maxLength, int decimals)
        {
            this.ChecaCampo(str, tag, optional, minLength, maxLength);

            if (optional == ObOp.Obrigatorio || (optional == ObOp.Opcional && str.Trim() != ""))
            {
                int pos = str.Trim().IndexOf(".") + 1;
                int ndec = str.Trim().Substring(pos).Length;
                if (ndec != decimals)
                    this.ErroInfo += string.Format("O número de casas decimais do campo {0} deve ser de {1} e existe(m) {2}", tag, decimals, ndec) + Environment.NewLine;
            }
        }

        private void ChecaCampo(string str, string tag, ObOp optional)
        {
            this.ChecaCampo(str, tag, optional, 10, 10);

            if (optional == ObOp.Obrigatorio || (optional == ObOp.Opcional && str.Trim() != ""))
            {
                string content = str.Trim();
                int pos = content.IndexOf("-");
                if (pos > -1)
                {
                    string[] dados = content.Split('-');
                    if (dados.Length > 0)
                    {
                        int _ano = Convert.ToInt16("0" + dados[0]);
                        int _mes = Convert.ToInt16("0" + dados[1]);
                        int _dia = Convert.ToInt16("0" + dados[2]);
                        if (_ano == 0 || _mes < 0 || _mes > 12 || _dia < 0 || _dia > 31)
                            pos = -1;
                    }
                    else
                        pos = -1;
                }
                if (pos == -1)
                    this.ErroInfo += string.Format("Data inválida no campo {0}. Conteudo: {1}", tag, str) + Environment.NewLine;
            }
        }
        #endregion

        #region ROTINAS
        public void Carrega_Parametros(int _ID_Empresa)
        {
            try
            {
                Parametro = new DTO_Parametro();
                BLL_Parametro = new BLL_Parametro();

                Parametro.ID_Empresa = _ID_Empresa;
                Parametro.Tipo = 5;
                DataTable _DT = BLL_Parametro.Busca(Parametro);

                if (_DT.Rows.Count != 1)
                    throw new Exception(util_msg.msg_Erro_Param);

                DataRow _DR = _DT.Rows[0];

                Parametro_NFe_NFC_SAT.CertificadoDigital = _DR["Certificado_NFe"].ToString();
                Parametro_NFe_NFC_SAT.Caminho_NFe = Convert.ToString(_DR["Caminho_NFe"]);
                Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DR["AmbienteNFe"]);
                Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DR["RegimeTributario"]);
                Parametro_NFe_NFC_SAT.Exibe_InfoProd = Convert.ToBoolean(_DR["ExibeInfoProduto"]);
                Parametro_NFe_NFC_SAT.AliquotaICMS = Convert.ToDouble(_DR["AliquotaCreditoICMS"]);
                Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS = Convert.ToBoolean(_DR["Exibe_msgCreditoICMS"]);
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro_Param + ex.Message);
            }
        }

        private XmlDocument Gera_Estrutura_XML_NFe(int ID_NFe)
        {
            if (ID_NFe == 0)
                return null;

            try
            {
                BLL_NF = new BLL_NF();
                BLL_Pessoa = new BLL_Pessoa();

                NFe = new DTO_NF();
                Pessoa = new DTO_Pessoa();

                ErroInfo = "";
                string CNPJ_CPF = "";
                double CreditoICMS_Simples = 0;
                int Ambiente;
                int UF;

                #region BUSCA INFORMAÇÃO DA NF-e
                NFe.ID = ID_NFe;
                NFe.FiltraEmpresa = false;

                DR_NF = BLL_NF.Busca_NF(NFe).Rows[0];
                #endregion

                DS_NFe = new DataSet();

                DS_NFe.ReadXmlSchema(Parametro_Sistema.Caminho_Sistema + util_Param.Schemas + "nfe_v2.00.xsd");
                DS_NFe.EnforceConstraints = false;

                #region DADOS DA NOTA FISCAL ELETRÔNICA
                DR = DS_NFe.Tables["infNFe"].NewRow();

                DR["id"] = "0"; //IDENTIFICAÇÃO DA NOTA
                DR["versao"] = "2.00";

                DR["infNFe_Id"] = 0;

                DS_NFe.Tables["infNFe"].Rows.Add(DR);

                this.ChecaCampo(DR["versao"].ToString(), "Versão Schema", ObOp.Obrigatorio, 1, 4);
                #endregion

                #region IDENTIFICAÇÃO DA NOTA FISCAL ELETRONICA
                Chave = "";

                //BUSCA INFORMAÇÃO DO EMITENTE 
                Pessoa.ID = Convert.ToInt32(DR_NF["ID_Empresa"]);

                DR_Emit = BLL_Pessoa.Busca_Info_Relatorio(Pessoa).Rows[0];

                Ambiente = Parametro_NFe_NFC_SAT.AmbienteNFe;
                UF = Convert.ToInt32(DR_Emit["ID_UF"]);

                DR = DS_NFe.Tables["ide"].NewRow();

                DR["ide_Id"] = 0;
                DR["infNFe_Id"] = 0;

                DR["cUF"] = DR_Emit["ID_UF"];
                DR["cNF"] = DR_NF["ID"].ToString().PadLeft(8, '0');
                DR["natOp"] = DR_NF["NaturezaOperacao"];
                DR["indPag"] = DR_NF["FormaPagto"];
                DR["mod"] = "55";
                DR["serie"] = DR_NF["Serie"].ToString().Trim();
                DR["nNF"] = DR_NF["ID_NFe"];
                DR["dEmi"] = util_dados.Config_Data(Convert.ToDateTime(DR_NF["DataEmissao"]), 7);
                DR["dSaiEnt"] = util_dados.Config_Data(Convert.ToDateTime(DR_NF["DataSaida"]), 7);
                DR["hSaiEnt"] = util_dados.Config_Data(Convert.ToDateTime(DR_NF["DataSaida"]), 10);
                DR["tpNF"] = DR_NF["TipoDocumento"];
                DR["cMunFG"] = DR_Emit["ID_Municipio"];
                DR["tpImp"] = DR_NF["TipoImpressao"];
                DR["tpEmis"] = DR_NF["FormaEmissao"];
                DR["cDV"] = 0;
                DR["tpAmb"] = Parametro_NFe_NFC_SAT.AmbienteNFe;
                DR["finNFe"] = DR_NF["FinalidadeEmissao"];
                DR["procEmi"] = 0; //PROCESSO DE EMISSÃO (0 - APLICATIVO DO CONTRIBUINTE)
                DR["VerProc"] = Parametro_Sistema.Versao;

                DS_NFe.Tables["ide"].Rows.Add(DR);

                this.ChecaCampo(DR_Emit["ID_UF"].ToString(), "UF Emissor", ObOp.Obrigatorio, 2, 2);
                this.ChecaCampo(DR_NF["NaturezaOperacao"].ToString(), "Natureza Operação", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["mod"].ToString(), "Modelo", ObOp.Obrigatorio, 2, 2);
                this.ChecaCampo(DR["serie"].ToString(), "Série", ObOp.Obrigatorio, 1, 3);
                this.ChecaCampo(DR["nNF"].ToString(), "Número NF", ObOp.Obrigatorio, 1, 9);
                this.ChecaCampo(DR["dEmi"].ToString(), "Data Emissão", ObOp.Obrigatorio);
                this.ChecaCampo(DR["dSaiEnt"].ToString(), "Data Saída", ObOp.Opcional);
                this.ChecaCampo(DR["hSaiEnt"].ToString(), "Hora Saída", ObOp.Opcional, 8, 8);
                this.ChecaCampo(DR["tpNF"].ToString(), "Tipo de Documento", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["cMunFG"].ToString(), "Município Emissor", ObOp.Obrigatorio, 7, 7);
                this.ChecaCampo(DR["tpImp"].ToString(), "Tipo de Impressão", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["tpEmis"].ToString(), "Tipo de Emissão", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["cDV"].ToString(), "cDV", ObOp.Opcional, 1, 1);
                this.ChecaCampo(DR["tpAmb"].ToString(), "Tipo de Ambiente", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["finNFe"].ToString(), "Finalidade", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["procEmi"].ToString(), "Processo de Emissão", ObOp.Obrigatorio, 1, 1);
                this.ChecaCampo(DR["VerProc"].ToString(), "Versão do Sistema", ObOp.Obrigatorio, 1, 20);

                Chave = DR["cUF"].ToString() + DR["dEmi"].ToString().Substring(2, 2) + DR["dEmi"].ToString().Substring(5, 2); //CHAVE (UF + AAMM(DATA EMISSAO))
                #endregion

                #region INFORMAÇÃO DAS NF/NF-e REFERENCIADAS

                /// TIPO REFERENCIADA
                ///1 - NF-e
                ///2 - NF-A1
                ///3 - NF-A1 PRODUTOR RURAL
                ///4 - CT-e
                ///5 - ECF 

                DT = new DataTable();
                DT = BLL_NF.Busca_NF_Referenciada(NFe);

                if (DT.Rows.Count > 0)
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        DR_NFRef = DT.Rows[i];

                        switch (Convert.ToInt32(DR_NFRef["Tipo"]))
                        {
                            #region NF-e
                            case 1:
                                DR = DS_NFe.Tables["NFref"].NewRow();
                                DR["ide_Id"] = 0;
                                DR["NFref_Id"] = i + 1;
                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                DR = DS_NFe.Tables["NFref"].NewRow();

                                DR["refMFe"] = DR_NFRef["Chave_NFe"];

                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                this.ChecaCampo(DR["refMFe"].ToString(), "Chave NFe Referênciada", ObOp.Obrigatorio, 44, 44);
                                break;
                            #endregion

                            #region NF-A1
                            case 2:
                                DR = DS_NFe.Tables["NFref"].NewRow();
                                DR["ide_Id"] = 0;
                                DR["NFref_Id"] = i + 1;
                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                DR = DS_NFe.Tables["refNF"].NewRow();

                                DR["cUF"] = DR_NFRef["UF"];
                                DR["AAMM"] = util_dados.Config_Data(Convert.ToDateTime(DR_NFRef["DataEmissao"]), 8);
                                DR["CNPJ"] = DR_NFRef["CNPJ_CPF"];
                                DR["mod"] = DR_NFRef["Modelo"];
                                DR["serie"] = DR_NFRef["Serie"];
                                DR["nNF"] = DR_NFRef["Numero_NF"];

                                DS_NFe.Tables["refNF"].Rows.Add(DR);

                                this.ChecaCampo(DR["cUF"].ToString(), "UF NF Referênciada", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["AAMM"].ToString(), "AAMM NF Referênciada", ObOp.Obrigatorio, 4, 4);
                                this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ NF Referênciada", ObOp.Obrigatorio, 14, 14);
                                this.ChecaCampo(DR["mod"].ToString(), "Modelo NF Referênciada", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["serie"].ToString(), "Série NF Referênciada", ObOp.Obrigatorio, 1, 3);
                                this.ChecaCampo(DR["nNF"].ToString(), "Número NF Referênciada", ObOp.Obrigatorio, 1, 9);
                                break;
                            #endregion

                            #region NF-A1-PRODUTOR RURAL
                            case 3:
                                DR = DS_NFe.Tables["NFref"].NewRow();
                                DR["ide_Id"] = 0;
                                DR["NFref_Id"] = i + 1;
                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                DR = DS_NFe.Tables["refNFP"].NewRow();

                                DR["cUF"] = DR_NFRef["UF"];
                                DR["AAMM"] = util_dados.Config_Data(Convert.ToDateTime(DR_NFRef["DataEmissao"]), 8);

                                CNPJ_CPF = "";
                                CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_NFRef["CNPJ_CPF"].ToString());

                                if (CNPJ_CPF.Length == 14)
                                    DR["CNPJ"] = CNPJ_CPF;
                                if (CNPJ_CPF.Length == 11)
                                    DR["CPF"] = CNPJ_CPF;

                                DR["IE"] = DR_NFRef["IE"];
                                DR["mod"] = DR_NFRef["Modelo"];
                                DR["serie"] = DR_NFRef["Serie"];
                                DR["nNF"] = DR_NFRef["Numero_NF"];

                                DS_NFe.Tables["refNFP"].Rows.Add(DR);

                                this.ChecaCampo(DR["cUF"].ToString(), "UF NF Referênciada", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["AAMM"].ToString(), "AAMM NF Referênciada", ObOp.Obrigatorio, 4, 4);
                                this.ChecaCampo(DR["mod"].ToString(), "ModeloNF Referênciada", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["serie"].ToString(), "Série NF Referênciada", ObOp.Obrigatorio, 1, 3);
                                this.ChecaCampo(DR["nNF"].ToString(), "Número NF Referênciada", ObOp.Obrigatorio, 1, 9);

                                if (CNPJ_CPF.Length == 14)
                                    this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ NF Referênciada", ObOp.Obrigatorio, 14, 14);
                                else
                                    this.ChecaCampo(DR["CPF"].ToString(), "CPF NF Referênciada", ObOp.Obrigatorio, 11, 11);
                                break;
                            #endregion

                            #region CT-e
                            case 4:
                                DR = DS_NFe.Tables["NFref"].NewRow();
                                DR["ide_Id"] = 0;
                                DR["NFref_Id"] = i + 1;
                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                DR = DS_NFe.Tables["NFref"].NewRow();

                                DR["refCTe"] = DR_NFRef["CTE"];

                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                this.ChecaCampo(DR["refCTe"].ToString(), "Chave CTe Referênciado", ObOp.Obrigatorio, 44, 44);
                                break;
                            #endregion

                            #region ECF
                            case 5:
                                DR = DS_NFe.Tables["NFref"].NewRow();
                                DR["ide_Id"] = 0;
                                DR["NFref_Id"] = i + 1;
                                DS_NFe.Tables["NFref"].Rows.Add(DR);

                                DR = DS_NFe.Tables["refECF"].NewRow();

                                DR["mod"] = DR_NFRef["Mod_CupomFiscal"];
                                DR["nECF"] = DR_NFRef["ECF"];
                                DR["nCOO"] = DR_NFRef["Numero_Contador"];

                                DS_NFe.Tables["refECF"].Rows.Add(DR);

                                this.ChecaCampo(DR["mod"].ToString(), "Modelo ECF Referênciado", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["nECF"].ToString(), "Número ECF Referênciado", ObOp.Obrigatorio, 1, 3);
                                this.ChecaCampo(DR["nCOO"].ToString(), "COO ECF Referênciado", ObOp.Obrigatorio, 1, 6);
                                break;
                                #endregion
                        }

                    }
                #endregion

                #region EMITENTE
                DR = DS_NFe.Tables["emit"].NewRow();
                DR["infNFe_Id"] = 0;
                DR["emit_Id"] = 0;

                CNPJ_CPF = "";
                CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Emit["CNPJ_CPF"].ToString());

                if (CNPJ_CPF.Length == 14)
                    DR["CNPJ"] = CNPJ_CPF;
                if (CNPJ_CPF.Length == 11)
                    DR["CPF"] = CNPJ_CPF;

                DR["xNome"] = DR_Emit["Nome_Razao"].ToString().TrimEnd();

                //SE NÃO ESTIVER ESTIPULADO NENHUM NOME FANTASIA, É COLOCADO O MESMO NOME DA EMPRESA
                if (DR_Emit["NomeFantasia"].ToString().Trim() == "")
                    DR["xFant"] = DR_Emit["Descricao"].ToString().TrimEnd();
                else
                    DR["xFant"] = DR_Emit["NomeFantasia"].ToString().TrimEnd();

                DR["IE"] = util_dados.Conf_strDoc_NFe(DR_Emit["IE_RG"]);

                //DR["IEST"] = DR_NF["IE_Substituicao"];
                //DR["IM"] = "";
                //DR["CNAE"] = "";

                DR["CRT"] = Parametro_NFe_NFC_SAT.Regime_Tributario;

                DS_NFe.Tables["emit"].Rows.Add(DR);

                this.ChecaCampo(DR["xNome"].ToString(), "Descrição Emitente", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["xFant"].ToString(), "Nome Fantasia Emitente", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["IE"].ToString(), "IE Emitente", ObOp.Obrigatorio, 0, 14);
                this.ChecaCampo(DR["IEST"].ToString(), "IEST Emitente", ObOp.Opcional, 2, 14);
                this.ChecaCampo(DR["IM"].ToString(), "IM Emitente", ObOp.Opcional, 1, 15);
                this.ChecaCampo(DR["CNAE"].ToString(), "CNAE Emitente", ObOp.Opcional, 7, 7);

                if (CNPJ_CPF.Length == 14)
                    this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ Emitente", ObOp.Obrigatorio, 14, 14);
                else
                    this.ChecaCampo(DR["CPF"].ToString(), "CPF Emitente", ObOp.Obrigatorio, 11, 11);

                //COLOCA CNPJ NA CHAVE DE IDENTIFICAÇÃO DA NOTA
                Chave += CNPJ_CPF.PadLeft(14, '0') + "55";

                #region ENDEREÇO EMITENTE
                DR = DS_NFe.Tables["enderEmit"].NewRow();

                DR["emit_Id"] = 0;
                DR["xLgr"] = DR_Emit["Logradouro"].ToString().TrimEnd();
                DR["nro"] = DR_Emit["NumeroEndereco"].ToString().TrimEnd();

                if (DR_Emit["Complemento"].ToString().Trim() != string.Empty)
                    DR["xCpl"] = DR_Emit["Complemento"].ToString().TrimEnd();

                DR["xBairro"] = DR_Emit["Bairro"].ToString().TrimEnd();
                DR["cMun"] = DR_Emit["ID_Municipio"];
                DR["xMun"] = DR_Emit["Municipio"];
                DR["UF"] = DR_Emit["UF"];
                DR["CEP"] = util_dados.Conf_strDoc_NFe(DR_Emit["CEP"]);
                DR["cPais"] = DR_Emit["ID_Pais"];
                DR["xPais"] = DR_Emit["Pais"];
                DR["fone"] = util_dados.Conf_strDoc_NFe(DR_Emit["DDD"].ToString() + DR_Emit["NumeroTelefone"].ToString());

                DS_NFe.Tables["enderEmit"].Rows.Add(DR);

                this.ChecaCampo(DR["xLgr"].ToString(), "Logradouro Emitente", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["nro"].ToString(), "Número Emitente", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["xCpl"].ToString(), "Complemento Emitente", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["xBairro"].ToString(), "Bairro Emitente", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["cMun"].ToString(), "Município Emitente", ObOp.Obrigatorio, 1, 7);
                this.ChecaCampo(DR["xMun"].ToString(), "Município Emitente", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["UF"].ToString(), "UF Emitente", ObOp.Obrigatorio, 2, 2);
                this.ChecaCampo(DR["CEP"].ToString(), "CEP Emitente", ObOp.Obrigatorio, 8, 8);
                this.ChecaCampo(DR["cPais"].ToString(), "Pais Emitente", ObOp.Opcional, 4, 4);
                this.ChecaCampo(DR["xPais"].ToString(), "Pais Emitente", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["fone"].ToString(), "Fone Emitente", ObOp.Opcional, 1, 14);
                #endregion
                #endregion

                #region AVULSA(IMPLEMENTAR DEPOIS)
                /*
                        DataRow dr = dsNfe.Tables["avulsa"].NewRow();
                        if (this.PopulateDataRow(dr, dados, 11))
                        {
                            dr["infNFe_Id"] = 0;
                            dsNfe.Tables["avulsa"].Rows.Add(dr);

                            this.ChecaCampo(dados[0], "CNPJ", dr, ObOp.Obrigatorio, 14, 14);
                            this.ChecaCampo(dados[0], "xOrgao", dr, ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(dados[0], "matr", dr, ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(dados[0], "xAgente", dr, ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(dados[0], "fone", dr, ObOp.Obrigatorio, 1, 10);
                            this.ChecaCampo(dados[0], "UF", dr, ObOp.Obrigatorio, 2, 2);
                            this.ChecaCampo(dados[0], "nDAR", dr, ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(dados[0], "dEmi", dr, ObOp.Obrigatorio);
                            this.ChecaCampo(dados[0], "vDAR", dr, ObOp.Obrigatorio, 1, 15);
                            this.ChecaCampo(dados[0], "repEmi", dr, ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(dados[0], "dPag", dr, ObOp.Opcional);
                        }
                   */
                #endregion

                #region DESTINATÁRIO
                //BUSCA INFORMAÇÃO DO DESTINATÁRIO
                Pessoa.TipoPessoa = Convert.ToInt32(DR_NF["TipoPessoa"]);
                Pessoa.ID = Convert.ToInt32(DR_NF["ID_Pessoa"]);
                DR_Dest = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa).Rows[0];

                DR = DS_NFe.Tables["dest"].NewRow();
                DS_NFe.Tables["dest"].Columns["IE"].AllowDBNull = true;

                DR["dest_Id"] = 0;
                DR["infNFe_Id"] = 0;

                CNPJ_CPF = "";
                CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Dest["CNPJ_CPF"].ToString());

                if (CNPJ_CPF.Length == 14)
                {
                    DR["CNPJ"] = CNPJ_CPF;
                    if (util_dados.Conf_strDoc_NFe(DR_Dest["IE_RG"]).Replace("0", "").Trim() != string.Empty)
                        DR["IE"] = util_dados.Conf_strDoc_NFe(DR_Dest["IE_RG"]);
                    else
                        DR["IE"] = "";
                }
                if (CNPJ_CPF.Length == 11)
                {
                    DR["CPF"] = CNPJ_CPF;
                    DR["IE"] = "";
                }
                DR["xNome"] = DR_Dest["Descricao"].ToString().TrimEnd();

                //DR["ISUF"] = "";

                DR["email"] = DR_Dest["Email"].ToString().Trim();

                DS_NFe.Tables["dest"].Rows.Add(DR);

                this.ChecaCampo(DR["xNome"].ToString(), "Descrição Destinatário", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["IE"].ToString(), "IE Destinatário", ObOp.Obrigatorio, 0, 14);
                this.ChecaCampo(DR["ISUF"].ToString(), "ISUF Destinatário", ObOp.Opcional, 1, 9);
                this.ChecaCampo(DR["email"].ToString(), "e-Mail Destinatário", ObOp.Obrigatorio, 1, 60);

                if (CNPJ_CPF.Length == 14)
                    this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ Destinatário", ObOp.Obrigatorio, 14, 14);
                else
                    this.ChecaCampo(DR["CPF"].ToString(), "CPF Destinatário", ObOp.Obrigatorio, 11, 11);

                #region ENDEREÇO DESTINATÁRIO
                DR = DS_NFe.Tables["enderDest"].NewRow();

                DR["dest_Id"] = 0;
                DR["xLgr"] = DR_Dest["Logradouro"].ToString().TrimEnd(); ;
                DR["nro"] = DR_Dest["NumeroEndereco"].ToString().TrimEnd(); ;

                if (DR_Dest["Complemento"].ToString().Trim() != string.Empty)
                    DR["xCpl"] = DR_Dest["Complemento"].ToString().TrimEnd(); ;

                DR["xBairro"] = DR_Dest["Bairro"].ToString().TrimEnd();
                if (Convert.ToInt32(DR_Dest["ID_Municipio"]) == 1)
                {
                    DR["cMun"] = "9999999";
                    DR["xMun"] = "EXTERIOR";
                    DR["UF"] = "EX";
                }
                else
                {
                    DR["cMun"] = DR_Dest["ID_Municipio"];
                    DR["xMun"] = DR_Dest["NomeMunicipio"];
                    DR["UF"] = DR_Dest["Sigla"];
                }

                DR["cPais"] = DR_Dest["ID_Pais"];
                DR["xPais"] = DR_Dest["Pais"];

                if (DR_Dest["CEP"].ToString().Replace("0", "").Replace("-", "").Trim() != string.Empty)
                    DR["CEP"] = util_dados.Conf_strDoc_NFe(DR_Dest["CEP"]);

                if (DR_Dest["NumeroTelefone"].ToString().Trim() != string.Empty)
                    DR["fone"] = util_dados.Conf_strDoc_NFe(DR_Dest["DDD"].ToString() + DR_Dest["NumeroTelefone"].ToString());

                DS_NFe.Tables["enderDest"].Rows.Add(DR);

                this.ChecaCampo(DR["xLgr"].ToString(), "Logradouro Destinatário", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["nro"].ToString(), "Número Destinatário", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["xCpl"].ToString(), "Complemento Destinatário", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["xBairro"].ToString(), "Bairro Destinatário", ObOp.Obrigatorio, 1, 60);
                this.ChecaCampo(DR["cMun"].ToString(), "Município Destinatário", ObOp.Obrigatorio, 1, 7);
                this.ChecaCampo(DR["xMun"].ToString(), "Município Destinatário", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["UF"].ToString(), "UF Destinatário", ObOp.Obrigatorio, 2, 2);
                this.ChecaCampo(DR["CEP"].ToString(), "CEP Destinatário", ObOp.Obrigatorio, 8, 8);
                this.ChecaCampo(DR["cPais"].ToString(), "cPais", ObOp.Opcional, 4, 4);
                this.ChecaCampo(DR["xPais"].ToString(), "xPais", ObOp.Opcional, 1, 60);
                this.ChecaCampo(DR["fone"].ToString(), "fone", ObOp.Opcional, 1, 14);

                //SE FOR EXPORTAÇÃO NÃO TEM CNPJ NEM IE
                if (DR["UF"].ToString() == "EX")
                {
                    DS_NFe.Tables["dest"].Rows[0]["IE"] = "";
                    DS_NFe.Tables["dest"].Rows[0]["CNPJ"] = "";
                }
                #endregion
                #endregion

                #region RETIRADA
                DT = new DataTable();

                NFe.Tipo_Ent_Ret = 1;
                DT = BLL_NF.Busca_NF_Ent_Ret(NFe);

                if (DT.Rows.Count == 1)
                {
                    DR = DS_NFe.Tables["retirada"].NewRow();
                    DR["infNFe_Id"] = 0;

                    DR_Ret = DT.Rows[0];

                    CNPJ_CPF = "";
                    CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Ret["CNPJ_CPF"].ToString());

                    if (CNPJ_CPF.Length == 14)
                        DR["CNPJ"] = CNPJ_CPF;
                    if (CNPJ_CPF.Length == 11)
                        DR["CPF"] = CNPJ_CPF;

                    DR["xLgr"] = DR_Ret["Logradouro"].ToString().TrimEnd();
                    DR["nro"] = DR_Ret["Numero"].ToString().TrimEnd();

                    if (DR_Ret["Complemento"].ToString().Trim() != string.Empty)
                        DR["xCpl"] = DR_Ret["Complemento"].ToString().TrimEnd();

                    DR["xBairro"] = DR_Ret["Bairro"].ToString().TrimEnd();
                    DR["cMun"] = DR_Ret["Cod_Municipio"];
                    DR["xMun"] = DR_Ret["Municipio"];
                    DR["UF"] = DR_Ret["UF"];

                    DS_NFe.Tables["retirada"].Rows.Add(DR);

                    this.ChecaCampo(DR["xLgr"].ToString(), "xLgr", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["nro"].ToString(), "nro", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["xCpl"].ToString(), "xCpl", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["xBairro"].ToString(), "xBairro", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["cMun"].ToString(), "cMun", ObOp.Obrigatorio, 1, 7);
                    this.ChecaCampo(DR["xMun"].ToString(), "xMun", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["UF"].ToString(), "UF", ObOp.Obrigatorio, 2, 2);

                    if (CNPJ_CPF.Length == 14)
                        this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ", ObOp.Obrigatorio, 14, 14);
                    else
                        this.ChecaCampo(DR["CPF"].ToString(), "CPF", ObOp.Obrigatorio, 11, 11);
                }
                #endregion

                #region ENTREGA
                DT = new DataTable();

                NFe.Tipo_Ent_Ret = 2;
                DT = BLL_NF.Busca_NF_Ent_Ret(NFe);

                if (DT.Rows.Count == 1)
                {
                    DR = DS_NFe.Tables["entrega"].NewRow();
                    DR["infNFe_Id"] = 0;

                    DR_Ent = DT.Rows[0];

                    CNPJ_CPF = "";
                    CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Ent["CNPJ_CPF"].ToString());

                    if (CNPJ_CPF.Length == 14)
                        DR["CNPJ"] = CNPJ_CPF;
                    if (CNPJ_CPF.Length == 11)
                        DR["CPF"] = CNPJ_CPF;

                    DR["xLgr"] = DR_Ent["Logradouro"];
                    DR["nro"] = DR_Ent["Numero"];

                    if (DR_Ent["Complemento"].ToString().Trim() != string.Empty)
                        DR["xCpl"] = DR_Ent["Complemento"];

                    DR["xBairro"] = DR_Ent["Bairro"];
                    DR["cMun"] = DR_Ent["Cod_Municipio"];
                    DR["xMun"] = DR_Ent["Municipio"];
                    DR["UF"] = DR_Ent["UF"];

                    DS_NFe.Tables["entrega"].Rows.Add(DR);

                    this.ChecaCampo(DR["xLgr"].ToString(), "xLgr", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["nro"].ToString(), "nro", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["xCpl"].ToString(), "xCpl", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["xBairro"].ToString(), "xBairro", ObOp.Obrigatorio, 1, 60);
                    this.ChecaCampo(DR["cMun"].ToString(), "cMun", ObOp.Obrigatorio, 1, 7);
                    this.ChecaCampo(DR["xMun"].ToString(), "xMun", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["UF"].ToString(), "UF", ObOp.Obrigatorio, 2, 2);

                    if (CNPJ_CPF.Length == 14)
                        this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ", ObOp.Obrigatorio, 14, 14);
                    else
                        this.ChecaCampo(DR["CPF"].ToString(), "CPF", ObOp.Obrigatorio, 11, 11);
                }
                #endregion

                #region DETALHAMENTO DE PRODUTOS E SERVIÇOS
                double vTotalTrib = 0;
                DT = new DataTable();
                DT = BLL_NF.Busca_NF_Item(NFe);

                if (DT.Rows.Count >= 1)
                {
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        #region ITEM DETALHAMENTO, INFORMAÇÃO ADICIONAL PRODUTO
                        DR_Item = DT.Rows[i];

                        DR = DS_NFe.Tables["det"].NewRow();
                        DR["nItem"] = i + 1;
                        ++Qt_Produto;

                        DR["infAdProd"] = "~-?-~";

                        DR["det_Id"] = i + 1;
                        DR["infNFe_Id"] = 0;
                        DS_NFe.Tables["det"].Rows.Add(DR);

                        this.ChecaCampo(DR["nItem"].ToString(), "nItem", ObOp.Obrigatorio, 1, 3);
                        this.ChecaCampo(DR["infAdProd"].ToString(), "infAdProd", ObOp.Opcional, 0, 500);
                        #endregion

                        #region INFORMAÇÃO ITEM
                        DR = DS_NFe.Tables["prod"].NewRow();
                        DR["cProd"] = DR_Item["ID_Produto"];
                        DR["cEAN"] = "";

                        if (Parametro_NFe_NFC_SAT.Exibe_InfoProd == true)
                            DR["xProd"] = DR_Item["DescricaoProduto"].ToString().TrimEnd() + " " + DR_Item["InformacaoAdicional"].ToString().TrimEnd();
                        else
                            DR["xProd"] = DR_Item["DescricaoProduto"].ToString().TrimEnd();

                        if (DR_Item["NCM"].ToString().Replace("0", "").Trim() != "" && DR_Item["NCM"].ToString().Trim().Length == 8 || DR_Item["NCM"].ToString().Trim().Length == 2)
                            DR["NCM"] = DR_Item["NCM"].ToString().Trim();
                        else
                            DR["NCM"] = string.Empty;

                        if (DR_Item["EX_TIPI"].ToString().Trim() != string.Empty)
                            DR["EXTIPI"] = DR_Item["EX_TIPI"];

                        DR["CFOP"] = DR_Item["CFOP"];
                        DR["uCom"] = DR_Item["DescricaoUnidade"].ToString().TrimEnd();
                        DR["qCom"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 12);
                        DR["vUnCom"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 12);
                        DR["vProd"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"]), 12);
                        DR["CEANTrib"] = "";
                        DR["uTrib"] = DR_Item["DescricaoUnidade"];
                        DR["qTrib"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 12);
                        DR["vUnTrib"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 12);

                        if (Convert.ToDouble(DR_Item["Frete"]) > 0)
                            DR["vFrete"] = util_dados.ConfigNumDecimal(DR_Item["Frete"], 12);

                        if (Convert.ToDouble(DR_Item["Seguro"]) > 0)
                            DR["vSeg"] = util_dados.ConfigNumDecimal(DR_Item["Seguro"], 12);

                        if (Convert.ToDouble(DR_Item["Desconto"]) > 0)
                            DR["vDesc"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["Desconto"]), 12);

                        if (Convert.ToDouble(DR_Item["Acrescimo"]) > 0)
                            DR["vOutro"] = util_dados.ConfigNumDecimal(DR_Item["Acrescimo"], 12);

                        DR["indTot"] = 1;
                        DR["det_Id"] = i + 1;
                        DR["prod_ID"] = i + 1;

                        DS_NFe.Tables["prod"].Rows.Add(DR);

                        this.ChecaCampo(DR["cProd"].ToString(), "cProd", ObOp.Obrigatorio, 1, 60);
                        this.ChecaCampo(DR["cEAN"].ToString(), "cEAN", ObOp.Obrigatorio, 0, 14);
                        this.ChecaCampo(DR["xProd"].ToString(), "xProd", ObOp.Obrigatorio, 1, 120);
                        this.ChecaCampo(DR["NCM"].ToString(), "NCM Produto - " + DR_Item["DescricaoProduto"], ObOp.Obrigatorio, 2, 8);
                        this.ChecaCampo(DR["EXTIPI"].ToString(), "EXTIPI", ObOp.Opcional, 2, 3);
                        this.ChecaCampo(DR["CFOP"].ToString(), "CFOP Produto - " + DR_Item["DescricaoProduto"], ObOp.Obrigatorio, 4, 4);
                        this.ChecaCampo(DR["uCom"].ToString(), "uCom", ObOp.Obrigatorio, 1, 6);
                        this.ChecaCampo(DR["qCom"].ToString(), "qCom", ObOp.Obrigatorio, 1, 15, 2);
                        this.ChecaCampo(DR["vUnCom"].ToString(), "vUnCom", ObOp.Obrigatorio, 1, 15, 2);
                        this.ChecaCampo(DR["vProd"].ToString(), "vProd", ObOp.Obrigatorio, 1, 15, 2);
                        this.ChecaCampo(DR["cEANTrib"].ToString(), "cEANTrib", ObOp.Obrigatorio, 0, 14);
                        this.ChecaCampo(DR["uTrib"].ToString(), "uTrib", ObOp.Obrigatorio, 1, 6);
                        this.ChecaCampo(DR["qTrib"].ToString(), "qTrib", ObOp.Obrigatorio, 1, 15, 2);
                        this.ChecaCampo(DR["vUnTrib"].ToString(), "vUnTrib", ObOp.Obrigatorio, 1, 21, 2);
                        this.ChecaCampo(DR["vFrete"].ToString(), "vFrete", ObOp.Opcional, 1, 15, 2);
                        this.ChecaCampo(DR["vSeg"].ToString(), "vSeg", ObOp.Opcional, 1, 15, 2);
                        this.ChecaCampo(DR["vDesc"].ToString(), "vDesc", ObOp.Opcional, 1, 15, 2);
                        this.ChecaCampo(DR["vOutro"].ToString(), "vOutro", ObOp.Opcional, 1, 15, 2);
                        #endregion

                        #region IMPORTAÇÃO
                        DT_Imp = new DataTable();

                        NFe.ID_NF_Item = Convert.ToInt32(DR_Item["ID"]);
                        DT_Imp = BLL_NF.Busca_NF_Importacao(NFe);

                        if (DT_Imp.Rows.Count >= 1)
                        {
                            ++DI_ID;
                            DR = DS_NFe.Tables["DI"].NewRow();
                            DR_Imp = DT_Imp.Rows[0];
                            DR["nDI"] = DR_Imp["Documento"].ToString().TrimEnd();
                            DR["dDI"] = util_dados.Config_Data(Convert.ToDateTime(DR_Imp["Data_Registro"]), 7);
                            DR["xLocDesemb"] = DR_Imp["Local"].ToString().TrimEnd();
                            DR["UFDesemb"] = DR_Imp["UF"];
                            DR["dDesemb"] = util_dados.Config_Data(Convert.ToDateTime(DR_Imp["Data_Desen"]), 7);
                            DR["cExportador"] = DR_Imp["Codigo"].ToString().TrimEnd();

                            DR["prod_Id"] = i + 1;
                            DR["DI_Id"] = DI_ID;

                            DS_NFe.Tables["DI"].Rows.Add(DR);

                            this.ChecaCampo(DR["nDI"].ToString(), "nDI", ObOp.Obrigatorio, 1, 10);
                            this.ChecaCampo(DR["dDI"].ToString(), "dDI", ObOp.Obrigatorio);
                            this.ChecaCampo(DR["xLocDesemb"].ToString(), "xLocDesemb", ObOp.Obrigatorio, 1, 60);
                            this.ChecaCampo(DR["UFDesemb"].ToString(), "UFDesemb", ObOp.Obrigatorio, 2, 2);
                            this.ChecaCampo(DR["dDesemb"].ToString(), "dDesemb", ObOp.Obrigatorio);
                            this.ChecaCampo(DR["cExportador"].ToString(), "cExportador", ObOp.Obrigatorio, 1, 60);

                            #region ADIÇÃO
                            DT_Adicao = new DataTable();

                            NFe.ID_NF_Importacao = Convert.ToInt32(DR_Imp["ID"]);
                            DT_Adicao = BLL_NF.Busca_NF_Adicao(NFe);

                            if (DT_Adicao.Rows.Count > 0)
                                for (int x = 0; x <= DT_Adicao.Rows.Count - 1; x++)
                                {
                                    DR = DS_NFe.Tables["adi"].NewRow();
                                    DR_Adicao = DT_Adicao.Rows[x];

                                    DR["nAdicao"] = DR_Adicao["Numero"];
                                    DR["nSeqAdic"] = DR_Adicao["Seq"];
                                    DR["cFabricante"] = DR_Adicao["Codigo"];
                                    DR["vDescDI"] = util_dados.ConfigNumDecimal(DR_Adicao["Desconto"], 12);

                                    DR["DI_Id"] = DI_ID;

                                    DS_NFe.Tables["adi"].Rows.Add(DR);

                                    this.ChecaCampo(DR["nAdicao"].ToString(), "nAdicao", ObOp.Obrigatorio, 1, 3);
                                    this.ChecaCampo(DR["nSeqAdic"].ToString(), "nSeqAdic", ObOp.Obrigatorio, 1, 3);
                                    this.ChecaCampo(DR["cFabricante"].ToString(), "cFabricante", ObOp.Obrigatorio, 1, 60);
                                    this.ChecaCampo(DR["vDescDI"].ToString(), "vDescDI", ObOp.Opcional, 1, 15, 2);
                                }
                        }
                        #endregion
                        #endregion

                        #region VEICULO (IMPLEMENTAR DEPOIS)
                        /*
                            DataRow drveicProd = dsNfe.Tables["veicProd"].NewRow();
                            if (this.PopulateDataRow(drveicProd, dados, 22))
                            {
                                drveicProd["prod_id"] = idprod;
                                dsNfe.Tables["veicProd"].Rows.Add(drveicProd);

                                this.ChecaCampo(dados[0], "tpOp", drveicProd, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "chassi", drveicProd, ObOp.Obrigatorio, 1, 17);
                                this.ChecaCampo(dados[0], "cCor", drveicProd, ObOp.Obrigatorio, 1, 4);
                                this.ChecaCampo(dados[0], "xCor", drveicProd, ObOp.Obrigatorio, 1, 40);
                                this.ChecaCampo(dados[0], "pot", drveicProd, ObOp.Obrigatorio, 1, 4);
                                this.ChecaCampo(dados[0], "CM3", drveicProd, ObOp.Obrigatorio, 1, 4);
                                this.ChecaCampo(dados[0], "pesoL", drveicProd, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "pesoB", drveicProd, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "nSerie", drveicProd, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "tpComb", drveicProd, ObOp.Obrigatorio, 1, 8);
                                this.ChecaCampo(dados[0], "nMotor", drveicProd, ObOp.Obrigatorio, 1, 21);
                                this.ChecaCampo(dados[0], "CMKG", drveicProd, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "dist", drveicProd, ObOp.Obrigatorio, 1, 4);
                                this.ChecaCampo(dados[0], "RENAVAM", drveicProd, ObOp.Opcional, 1, 9);
                                this.ChecaCampo(dados[0], "anoMod", drveicProd, ObOp.Obrigatorio, 4, 4);
                                this.ChecaCampo(dados[0], "anoFab", drveicProd, ObOp.Obrigatorio, 4, 4);
                                this.ChecaCampo(dados[0], "tpPint", drveicProd, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "tpVeic", drveicProd, ObOp.Obrigatorio, 1, 2);
                                this.ChecaCampo(dados[0], "espVeic", drveicProd, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "VIN", drveicProd, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "condVeic", drveicProd, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "cMod", drveicProd, ObOp.Obrigatorio, 1, 6);
                            }
                        */
                        #endregion

                        #region MEDICAMENTO (IMPLEMENTAR DEPOIS)
                        /*
                            DataRow drmed = dsNfe.Tables["med"].NewRow();

                            if (this.PopulateDataRow(drmed, dados, 5))
                            {
                                drmed["prod_Id"] = idprod;
                                dsNfe.Tables["med"].Rows.Add(drmed);

                                this.ChecaCampo(dados[0], "nLote", drmed, ObOp.Obrigatorio, 20, 20);
                                this.ChecaCampo(dados[0], "qLote", drmed, ObOp.Obrigatorio, 1, 11, 3);
                                this.ChecaCampo(dados[0], "dFab", drmed, ObOp.Obrigatorio);
                                this.ChecaCampo(dados[0], "dVal", drmed, ObOp.Obrigatorio);
                                this.ChecaCampo(dados[0], "vPMC", drmed, ObOp.Obrigatorio, 1, 15, 2);
                            }
                        */
                        #endregion

                        #region ARMAMENTOS (IMPLEMENTAR DEPOIS)
                        /*
                            DataRow drarma = dsNfe.Tables["arma"].NewRow();
                            if (this.PopulateDataRow(drarma, dados, 4))
                            {
                                drarma["prod_Id"] = idprod;
                                dsNfe.Tables["arma"].Rows.Add(drarma);

                                this.ChecaCampo(dados[0], "tpArma", drarma, ObOp.Obrigatorio, 1, 1);
                                this.ChecaCampo(dados[0], "nSerie", drarma, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "nCano", drarma, ObOp.Obrigatorio, 1, 9);
                                this.ChecaCampo(dados[0], "descr", drarma, ObOp.Obrigatorio, 1, 256);
                            }
                        */
                        #endregion

                        #region COMBUSTIVEL (IMPLEMENTAR DEPOIS)
                        /*
                            DataRow drcomb = dsNfe.Tables["comb"].NewRow();
                            if (this.PopulateDataRow(drcomb, dados, 4))
                            {
                                ++idcomb;
                                drcomb["prod_Id"] = idprod;
                                drcomb["comb_Id"] = idcomb.ToString();
                                dsNfe.Tables["comb"].Rows.Add(drcomb);

                                this.ChecaCampo(dados[0], "cProdANP", drcomb, ObOp.Opcional, 9, 9);
                                this.ChecaCampo(dados[0], "CODIF", drcomb, ObOp.Opcional, 0, 21);
                                this.ChecaCampo(dados[0], "qTemp", drcomb, ObOp.Opcional, 1, 16, 4);
                                this.ChecaCampo(dados[0], "UFCons", drcomb, ObOp.Opcional, 0, 2);
                            }
                       */
                        #endregion

                        #region CIDE (IMPLEMENTAR DEPOIS)
                        /*
                            DataRow drCIDE = dsNfe.Tables["CIDE"].NewRow();
                            if (this.PopulateDataRow(drCIDE, dados, 3))
                            {
                                drCIDE["comb_Id"] = idcomb.ToString();
                                dsNfe.Tables["CIDE"].Rows.Add(drCIDE);

                                this.ChecaCampo(dados[0], "qBCprod", drCIDE, ObOp.Obrigatorio, 1, 16, 4);
                                this.ChecaCampo(dados[0], "vAliqProd", drCIDE, ObOp.Obrigatorio, 1, 15, 4);
                                this.ChecaCampo(dados[0], "vCIDE", drCIDE, ObOp.Obrigatorio, 1, 15, 2);
                            }
                        */
                        #endregion

                        #region IMPOSTO
                        DR = DS_NFe.Tables["imposto"].NewRow();
                        if (Convert.ToInt32(DR_Item["Origem"]) == 0 ||
                           Convert.ToInt32(DR_Item["Origem"]) == 3 ||
                            Convert.ToInt32(DR_Item["Origem"]) == 4 ||
                            Convert.ToInt32(DR_Item["Origem"]) == 5)
                        {
                            if (util_dados.Verifica_Double(DR_Item["AliqNac"].ToString()) > 0)
                            {
                                DR["vTotTrib"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["Quantidade"]) * (util_dados.Calcula_Porcentagem(Convert.ToDouble(DR_Item["AliqNac"]), Convert.ToDouble(DR_Item["ValorUnitario"]))), 12);
                                vTotalTrib += util_dados.Calcula_Porcentagem(Convert.ToDouble(DR_Item["AliqNac"]), (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                            }
                            else
                                DR["vTotTrib"] = util_dados.ConfigNumDecimal("0", 12);
                        }
                        else
                            if (util_dados.Verifica_Double(DR_Item["AliqNac"].ToString()) > 0)
                        {
                            DR["vTotTrib"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["Quantidade"]) * util_dados.Calcula_Porcentagem(Convert.ToDouble(DR_Item["AliqImp"]), Convert.ToDouble(DR_Item["ValorUnitario"])), 12);
                            vTotalTrib += util_dados.Calcula_Porcentagem(Convert.ToDouble(DR_Item["AliqImp"]), (Convert.ToDouble(DR_Item["Quantidade"]) * Convert.ToDouble(DR_Item["ValorUnitario"])));
                        }
                        else
                            DR["vTotTrib"] = util_dados.ConfigNumDecimal("0", 12);

                        DR["imposto_Id"] = i + 1;
                        DR["det_Id"] = i + 1;

                        DS_NFe.Tables["imposto"].Rows.Add(DR);

                        this.ChecaCampo(DR["vTotTrib"].ToString(), "vTotTrib", ObOp.Obrigatorio, 1, 16, 2);

                        #region ICMS NORMAL E ST
                        DR = DS_NFe.Tables["ICMS"].NewRow();
                        DR["ICMS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NFe.Tables["ICMS"].Rows.Add(DR);

                        if (Convert.ToInt32((DR_Item["CSOSN"].ToString() + "0")) > 0)
                        #region SIMPLES NACIONAL
                        {
                            switch (Convert.ToInt32(DR_Item["CSOSN"]))
                            {
                                #region CSOSN - 101 - SIMPLES COM APROVEITAMENTO DE CREDITO
                                case 101:
                                    DR = DS_NFe.Tables["ICMSSN101"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["pCredSN"] = util_dados.ConfigNumDecimal(Parametro_NFe_NFC_SAT.AliquotaICMS, 12);
                                    DR["vCredICMSSN"] = util_dados.ConfigNumDecimal(DR_Item["ValorCredito"], 12);

                                    CreditoICMS_Simples += Convert.ToDouble(DR_Item["ValorCredito"]);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN101"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    this.ChecaCampo(DR["pCredSN"].ToString(), "pCredSN", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vCredICMSSN"].ToString(), "vCredICMSSN", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CSOSN - 102, 103, 300, 400 - SIMPLES SEM APROVEITAMENTO DE CREDITO
                                case 102:
                                case 103:
                                case 300:
                                case 400:
                                    DR = DS_NFe.Tables["ICMSSN102"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN102"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    break;
                                #endregion

                                #region CSOSN - 201 - SIMPLES COM APROVEITAMENTO DE CREDITO ST
                                case 201:
                                    DR = DS_NFe.Tables["ICMSSN201"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);
                                    DR["pCredSN"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaCredito"], 12);
                                    DR["vCredICMSSN"] = util_dados.ConfigNumDecimal(DR_Item["ValorCredito"], 12);

                                    CreditoICMS_Simples += Convert.ToDouble(DR_Item["ValorCredito"]);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN201"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pCredSN"].ToString(), "pCredSN", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vCredICMSSN"].ToString(), "vCredICMSSN", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CSOSN - 202, 203 - SIMPLES SEM APROVEITAMENTO DE CREDITO ST
                                case 202:
                                case 203:
                                    DR = DS_NFe.Tables["ICMSSN202"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN202"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CSOSN - 500 - ICMS COBRADO ANTERIORMENTE POR SUBSTITUIÇÃO TRIBUTÁRIA
                                case 500:
                                    DR = DS_NFe.Tables["ICMSSN500"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["vBCSTRet"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCSTRet"], 12);
                                    DR["vICMSSTRet"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSSTRet"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN500"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    this.ChecaCampo(DR["vBCSTRet"].ToString(), "vBCSTRet", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["vICMSSTRet"].ToString(), "vICMSSTRet", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CSOSN - 900 - OUTROS
                                case 900:
                                    DR = DS_NFe.Tables["ICMSSN900"].NewRow();
                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CSOSN"] = DR_Item["CSOSN"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pRedBC"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducao"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);
                                    DR["pCredSN"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaCredito"], 12);
                                    DR["vCredICMSSN"] = util_dados.ConfigNumDecimal(DR_Item["ValorCredito"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMSSN900"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CSOSN"].ToString(), "CSOSN", ObOp.Obrigatorio, 3, 3);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pRedBC"].ToString(), "pRedBC", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pCredSN"].ToString(), "pCredSN", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vCredICMSSN"].ToString(), "vCredICMSSN", ObOp.Obrigatorio, 1, 16, 2);
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
                                #region CST – 00 – TRIBUTADA INTEGRALMENTE
                                case 0:
                                    DR = DS_NFe.Tables["ICMS00"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = "00";
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS00"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST - 10 - TRIBUTADA E COM COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                case 10:
                                    DR = DS_NFe.Tables["ICMS10"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS10"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST – 20 - COM REDUÇÃO DE BASE DE CÁLCULO
                                case 20:
                                    DR = DS_NFe.Tables["ICMS20"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["pRedBC"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducao"], 12);
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS20"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pRedBC"].ToString(), "pRedBC", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST – 30 - ISENTA OU NÃO TRIBUTADA E COM COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                case 30:
                                    DR = DS_NFe.Tables["ICMS30"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS30"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST – 40 - ISENTA, 41 - NÃO TRIBUTADA E 50 - SUSPENSÃO
                                case 40:
                                case 41:
                                case 50:
                                    DR = DS_NFe.Tables["ICMS40"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS40"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    break;
                                #endregion

                                #region CST – 51 - DIFERIMENTO - A EXIGÊNCIA DO PREENCHIMENTO DAS INFORMAÇÕES DO ICMS DIFERIDO FICA À CRITÉRIO DE CADA UF.
                                case 51:
                                    DR = DS_NFe.Tables["ICMS51"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["pRedBC"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducao"], 12);
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS51"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pRedBC"].ToString(), "pRedBC", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST – 60 - ICMS COBRADO ANTERIORMENTE POR SUBSTITUIÇÃO TRIBUTÁRIA
                                case 60:
                                    DR = DS_NFe.Tables["ICMS60"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["vBCSTRet"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCSTRet"], 12);
                                    DR["vICMSSTRet"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSSTRet"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS60"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["vBCSTRet"].ToString(), "vBCSTRet", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["vICMSSTRet"].ToString(), "vICMSSTRet", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST - 70 - COM REDUÇÃO DE BASE DE CÁLCULO E COBRANÇA DO ICMS POR SUBSTITUIÇÃO TRIBUTÁRIA
                                case 70:
                                    DR = DS_NFe.Tables["ICMS70"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["pRedBC"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducao"], 12);
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS70"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pRedBC"].ToString(), "pRedBC", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                #endregion

                                #region CST - 90 - OUTROS
                                case 90:
                                    DR = DS_NFe.Tables["ICMS90"].NewRow();

                                    DR["orig"] = DR_Item["Origem"];
                                    DR["CST"] = DR_Item["CST"];
                                    DR["modBC"] = DR_Item["ModalidadeBC"];
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBC"], 12);
                                    DR["pRedBC"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducao"], 12);
                                    DR["pICMS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMS"], 12);
                                    DR["vICMS"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMS"], 12);
                                    DR["modBCST"] = DR_Item["ModalidadeBCST"];

                                    if (util_dados.Verifica_Double(DR_Item["MargemVLAdicionado"].ToString()) > 0)
                                        DR["pMVAST"] = util_dados.ConfigNumDecimal(DR_Item["MargemVLAdicionado"], 12);
                                    if (util_dados.Verifica_Double(DR_Item["PercentualReducaoST"].ToString()) > 0)
                                        DR["pRedBCST"] = util_dados.ConfigNumDecimal(DR_Item["PercentualReducaoST"], 12);

                                    DR["vBCST"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCST"], 12);
                                    DR["pICMSST"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaICMSST"], 12);
                                    DR["vICMSST"] = util_dados.ConfigNumDecimal(DR_Item["ValorICMSST"], 12);

                                    DR["ICMS_Id"] = i + 1;
                                    DS_NFe.Tables["ICMS90"].Rows.Add(DR);

                                    this.ChecaCampo(DR["orig"].ToString(), "orig", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                    this.ChecaCampo(DR["modBC"].ToString(), "modBC", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pRedBC"].ToString(), "pRedBC", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pICMS"].ToString(), "pICMS", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["modBCST"].ToString(), "modBCST", ObOp.Obrigatorio, 1, 1);
                                    this.ChecaCampo(DR["pMVAST"].ToString(), "pMVAST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["pRedBCST"].ToString(), "pRedBCST", ObOp.Opcional, 1, 6, 2);
                                    this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pICMSST"].ToString(), "pICMSST", ObOp.Obrigatorio, 1, 6, 2);
                                    this.ChecaCampo(DR["vICMSST"].ToString(), "vICMSST", ObOp.Obrigatorio, 1, 16, 2);
                                    break;
                                    #endregion
                            }
                        }
                        #endregion
                        #endregion

                        #region IPI
                        DR = DS_NFe.Tables["IPI"].NewRow();

                        if (DR_Item["CNPJProdutor"].ToString().Trim() != string.Empty)
                        {
                            DR["clEnq"] = DR_Item["ClasseEnquadramento"];
                            DR["CNPJProd"] = DR_Item["CNPJProdutor"];
                            DR["cSelo"] = DR_Item["Codigo_Selo"];
                            DR["qSelo"] = DR_Item["Quantidade_Selo"];
                        }
                        DR["cEnq"] = "999";

                        DR["IPI_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NFe.Tables["IPI"].Rows.Add(DR);

                        this.ChecaCampo(DR["clEnq"].ToString(), "clEnq", ObOp.Opcional, 5, 5);
                        this.ChecaCampo(DR["CNPJProd"].ToString(), "CNPJProd", ObOp.Opcional, 14, 14);
                        this.ChecaCampo(DR["cSelo"].ToString(), "cSelo", ObOp.Opcional, 1, 60);
                        this.ChecaCampo(DR["qSelo"].ToString(), "qSelo", ObOp.Opcional, 1, 12);
                        this.ChecaCampo(DR["cEnq"].ToString(), "cEnq", ObOp.Obrigatorio, 3, 3);
                        #endregion

                        switch (Convert.ToInt32(DR_Item["CSTIPI"]))
                        {
                            #region IPI TRIBUTÁVEL
                            case 0:
                            case 49:
                            case 50:
                            case 99:
                                DR = DS_NFe.Tables["IPITrib"].NewRow();
                                DR["CST"] = DR_Item["CSTIPI"];
                                if (Convert.ToInt32(DR_Item["AliquotaIPI"]) > 0)
                                {
                                    DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorUnitario"], 12);
                                    DR["pIPI"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaIPI"], 12);
                                }
                                else
                                {
                                    DR["qUnid"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                    DR["vUnid"] = util_dados.ConfigNumDecimal(Convert.ToDouble(DR_Item["ValorIPI"]) / Convert.ToDouble(DR_Item["Quantidade"]), 14);
                                }

                                DR["vIPI"] = util_dados.ConfigNumDecimal(DR_Item["ValorIPI"], 12);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["vIPI"].ToString(), "vIPI", ObOp.Obrigatorio, 1, 16, 2);

                                if (Convert.ToInt32(DR_Item["AliquotaIPI"]) > 0)
                                {
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pIPI"].ToString(), "pIPI", ObOp.Obrigatorio, 1, 6, 2);
                                }
                                else
                                {
                                    this.ChecaCampo(DR["vUnid"].ToString(), "vUnid", ObOp.Obrigatorio, 1, 16, 4);
                                    this.ChecaCampo(DR["qUnid"].ToString(), "qUnid", ObOp.Obrigatorio, 1, 17, 4);
                                }
                                DR["IPI_Id"] = i + 1;
                                DS_NFe.Tables["IPITrib"].Rows.Add(DR);
                                break;
                            #endregion

                            #region IPI NÃO TRIBUTAVEL
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                                DR = DS_NFe.Tables["IPINT"].NewRow();
                                DR["CST"] = DR_Item["CSTIPI"].ToString().PadLeft(2, '0');

                                DR["IPI_Id"] = i + 1;
                                DS_NFe.Tables["IPINT"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                break;
                                #endregion
                        }

                        #region II
                        if (Convert.ToDouble(DR_Item["ValorBCII"]) > 0)
                        {
                            DR = DS_NFe.Tables["II"].NewRow();

                            DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorBCII"], 12);
                            DR["vDespAdu"] = util_dados.ConfigNumDecimal(DR_Item["ValorDesII"], 12);
                            DR["vII"] = util_dados.ConfigNumDecimal(DR_Item["ValorII"], 12);
                            DR["vIOF"] = util_dados.ConfigNumDecimal(DR_Item["ValorIOF"], 12);

                            DR["imposto_Id"] = i + 1;
                            DS_NFe.Tables["II"].Rows.Add(DR);

                            this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(DR["vBC"].ToString(), "vDespAdu", ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(DR["vBC"].ToString(), "vII", ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(DR["vBC"].ToString(), "vIOF", ObOp.Obrigatorio, 1, 16, 2);
                        }
                        #endregion

                        #region PIS
                        DR = DS_NFe.Tables["PIS"].NewRow();

                        DR["PIS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NFe.Tables["PIS"].Rows.Add(DR);

                        switch (Convert.ToInt32(DR_Item["CSTPIS"]))
                        {
                            case 1:
                            case 2:
                                DR = DS_NFe.Tables["PISAliq"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');
                                DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorTotal"], 12);
                                DR["pPIS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaPIS"], 12);
                                DR["vPIS"] = util_dados.ConfigNumDecimal(DR_Item["ValorPIS"], 12);

                                DR["PIS_Id"] = i + 1;
                                DS_NFe.Tables["PISAliq"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                this.ChecaCampo(DR["pPIS"].ToString(), "pPIS", ObOp.Obrigatorio, 1, 6, 2);
                                this.ChecaCampo(DR["vPIS"].ToString(), "vPIS", ObOp.Obrigatorio, 1, 16, 2);
                                break;

                            case 3:
                                DR = DS_NFe.Tables["PISQtde"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');
                                DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaPIS"], 14);
                                DR["vPIS"] = util_dados.ConfigNumDecimal(DR_Item["ValorPIS"], 12);

                                DR["PIS_Id"] = i + 1;
                                DS_NFe.Tables["PISQtde"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["qBCProd"].ToString(), "qBCProd", ObOp.Obrigatorio, 1, 17, 4);
                                this.ChecaCampo(DR["vAliqProd"].ToString(), "vAliqProd", ObOp.Obrigatorio, 1, 16, 4);
                                this.ChecaCampo(DR["vPIS"].ToString(), "vPIS", ObOp.Obrigatorio, 1, 16, 2);
                                break;

                            case 4:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                DR = DS_NFe.Tables["PISNT"].NewRow();

                                DR["CST"] = DR_Item["CSTPIS"].ToString().PadLeft(2, '0');

                                DR["PIS_Id"] = i + 1;
                                DS_NFe.Tables["PISNT"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                break;

                            case 99:
                                DR = DS_NFe.Tables["PISOutr"].NewRow();

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

                                DR["vPIS"] = util_dados.ConfigNumDecimal(DR_Item["ValorPIS"], 12);

                                DR["PIS_Id"] = i + 1;
                                DS_NFe.Tables["PISOutr"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["vPIS"].ToString(), "vPIS", ObOp.Obrigatorio, 1, 16, 2);

                                if (Convert.ToInt32(DR_Item["AliquotaPIS"]) > 0)
                                {
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pPIS"].ToString(), "pPIS", ObOp.Obrigatorio, 1, 6, 2);
                                }
                                else
                                {
                                    this.ChecaCampo(DR["qBCProd"].ToString(), "qBCProd", ObOp.Obrigatorio, 1, 17, 4);
                                    this.ChecaCampo(DR["vAliqProd"].ToString(), "vAliqProd", ObOp.Obrigatorio, 1, 16, 4);
                                }
                                break;
                        }






                        #endregion

                        #region COFINS
                        DR = DS_NFe.Tables["COFINS"].NewRow();

                        DR["COFINS_Id"] = i + 1;
                        DR["imposto_Id"] = i + 1;
                        DS_NFe.Tables["COFINS"].Rows.Add(DR);

                        switch (Convert.ToInt32(DR_Item["CSTCOFINS"]))
                        {
                            case 1:
                            case 2:
                                DR = DS_NFe.Tables["COFINSAliq"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');
                                DR["vBC"] = util_dados.ConfigNumDecimal(DR_Item["ValorTotal"], 12);
                                DR["pCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["AliquotaCOFINS"], 12);
                                DR["vCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["ValorCOFINS"], 12);

                                DR["COFINS_Id"] = i + 1;
                                DS_NFe.Tables["COFINSAliq"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                this.ChecaCampo(DR["pCOFINS"].ToString(), "pCOFINS", ObOp.Obrigatorio, 1, 6, 2);
                                this.ChecaCampo(DR["vCOFINS"].ToString(), "vCOFINS", ObOp.Obrigatorio, 1, 16, 2);
                                break;

                            case 3:
                                DR = DS_NFe.Tables["COFINSQtde"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');
                                DR["qBCProd"] = util_dados.ConfigNumDecimal(DR_Item["Quantidade"], 14);
                                DR["vAliqProd"] = util_dados.ConfigNumDecimal(DR_Item["ValorAliquotaCOFINS"], 14);
                                DR["vCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["ValorCOFINS"], 12);

                                DR["COFINS_Id"] = i + 1;
                                DS_NFe.Tables["COFINSQtde"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["qBCProd"].ToString(), "qBCProd", ObOp.Obrigatorio, 1, 17, 4);
                                this.ChecaCampo(DR["vAliqProd"].ToString(), "vAliqProd", ObOp.Obrigatorio, 1, 16, 4);
                                this.ChecaCampo(DR["vCOFINS"].ToString(), "vCOFINS", ObOp.Obrigatorio, 1, 16, 2);
                                break;

                            case 4:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                DR = DS_NFe.Tables["COFINSNT"].NewRow();

                                DR["CST"] = DR_Item["CSTCOFINS"].ToString().PadLeft(2, '0');

                                DR["COFINS_Id"] = i + 1;
                                DS_NFe.Tables["COFINSNT"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                break;

                            case 99:
                                DR = DS_NFe.Tables["COFINSOutr"].NewRow();

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

                                DR["vCOFINS"] = util_dados.ConfigNumDecimal(DR_Item["ValorCOFINS"], 12);

                                DR["COFINS_Id"] = i + 1;
                                DS_NFe.Tables["COFINSOutr"].Rows.Add(DR);

                                this.ChecaCampo(DR["CST"].ToString(), "CST", ObOp.Obrigatorio, 2, 2);
                                this.ChecaCampo(DR["vCOFINS"].ToString(), "vCOFINS", ObOp.Obrigatorio, 1, 16, 2);

                                if (Convert.ToInt32(DR_Item["AliquotaCOFINS"]) > 0)
                                {
                                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                                    this.ChecaCampo(DR["pCOFINS"].ToString(), "pCOFINS", ObOp.Obrigatorio, 1, 6, 2);
                                }
                                else
                                {
                                    this.ChecaCampo(DR["qBCProd"].ToString(), "qBCProd", ObOp.Obrigatorio, 1, 17, 4);
                                    this.ChecaCampo(DR["vAliqProd"].ToString(), "vAliqProd", ObOp.Obrigatorio, 1, 16, 4);
                                }
                                break;
                        }
                        #endregion

                        #region ISSQN (IMPLEMENTAR DEPOIS)
                        /*
                        DataRow dr = dsNfe.Tables["ISSQN"].NewRow();
                            if (this.PopulateDataRow(dr, dados, 6))
                            {
                                if (idprod == "")
                                {
                                    cMensagemErro += "Segmento [U] sem segmento [H]. Linha: " + iLinhaLida.ToString() + Environment.NewLine;
                                }

                                //Criar a tag Imposto se não informada a tag "M"
                                if (dsNfe.Tables["imposto"].Rows.Count == 0) //danasa 27-2-2011
                                {
                                    DataRow dr2 = dsNfe.Tables["imposto"].NewRow();
                                    dr2["imposto_Id"] = idprod.ToString();
                                    dr2["det_Id"] = idprod.ToString();
                                    dsNfe.Tables["imposto"].Rows.Add(dr2);
                                }
                                dr["imposto_Id"] = idprod;
                                dsNfe.Tables["ISSQN"].Rows.Add(dr);

                                this.ChecaCampo(dados[0], "vBC", dr, ObOp.Obrigatorio, 1, 15, 2);
                                this.ChecaCampo(dados[0], "vAliq", dr, ObOp.Obrigatorio, 1, 6, 2);
                                this.ChecaCampo(dados[0], "vISSQN", dr, ObOp.Obrigatorio, 1, 16, 2);
                                this.ChecaCampo(dados[0], "cMunFG", dr, ObOp.Obrigatorio, 7, 7);
                                this.ChecaCampo(dados[0], "cListServ", dr, ObOp.Obrigatorio, 3, 4);
                                this.ChecaCampo(dados[0], "cSitTrib", dr, ObOp.Opcional, 1, 1);
                        */
                        #endregion
                        #endregion
                    }
                }
                #endregion

                #region TOTAIS
                DR = DS_NFe.Tables["total"].NewRow();
                DR["total_Id"] = Qt_Produto.ToString();
                DR["infNFe_Id"] = 0;
                DS_NFe.Tables["total"].Rows.Add(DR);

                #region TOTAIS REFERENTE AO ICMS
                DR = DS_NFe.Tables["ICMSTot"].NewRow();

                DR["total_Id"] = Qt_Produto.ToString();
                DR["vBC"] = util_dados.ConfigNumDecimal(DR_NF["ValorBC"], 12);
                DR["vICMS"] = util_dados.ConfigNumDecimal(DR_NF["ValorICMS"], 12);
                DR["vBCST"] = util_dados.ConfigNumDecimal(DR_NF["ValorBCST"], 12);
                DR["vST"] = util_dados.ConfigNumDecimal(DR_NF["ValorST"], 12);
                DR["vProd"] = util_dados.ConfigNumDecimal(DR_NF["ValorProduto"], 12);
                DR["vFrete"] = util_dados.ConfigNumDecimal(DR_NF["ValorFrete"], 12);
                DR["vSeg"] = util_dados.ConfigNumDecimal(DR_NF["ValorSeguro"], 12);
                DR["vDesc"] = util_dados.ConfigNumDecimal(DR_NF["ValorDesconto"], 12);
                DR["vII"] = util_dados.ConfigNumDecimal(DR_NF["ValorImportacao"], 12);
                DR["vIPI"] = util_dados.ConfigNumDecimal(DR_NF["ValorIPI"], 12);
                DR["vPIS"] = util_dados.ConfigNumDecimal(DR_NF["ValorPIS"], 12);
                DR["vCOFINS"] = util_dados.ConfigNumDecimal(DR_NF["ValorCOFINS"], 12);
                DR["vOutro"] = util_dados.ConfigNumDecimal(DR_NF["ValorOutro"], 12);
                DR["vNF"] = util_dados.ConfigNumDecimal(DR_NF["ValorTotal"], 12);
                DR["vTotTrib"] = util_dados.ConfigNumDecimal(vTotalTrib, 12);

                DS_NFe.Tables["ICMSTot"].Rows.Add(DR);

                this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vICMS"].ToString(), "vICMS", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vBCST"].ToString(), "vBCST", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vST"].ToString(), "vST", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vProd"].ToString(), "vProd", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vFrete"].ToString(), "vFrete", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vSeg"].ToString(), "vSeg", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vDesc"].ToString(), "vDesc", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vII"].ToString(), "vII", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vIPI"].ToString(), "vIPI", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vPIS"].ToString(), "vPIS", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vCOFINS"].ToString(), "vCOFINS", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vOutro"].ToString(), "vOutro", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vNF"].ToString(), "vNF", ObOp.Obrigatorio, 1, 16, 2);
                this.ChecaCampo(DR["vTotTrib"].ToString(), "vNF", ObOp.Obrigatorio, 1, 16, 2);
                #endregion

                #region TOTAIS REFERENTE A ISSQN
                if (Qt_Servico > 0)
                {
                    DR = DS_NFe.Tables["ISSQNtot"].NewRow();

                    DR["total_Id"] = Qt_Servico.ToString();

                    DR["vServ"] = DR_NF["Valor_Servico"];
                    DR["vBC"] = DR_NF["ValorBC_Servico"];
                    DR["vISS"] = DR_NF["ValorISS"];
                    DR["vPIS"] = DR_NF["ValorPIS_Servico"];
                    DR["vCOFINS"] = DR_NF["ValorCOFINS_Servico"];

                    DS_NFe.Tables["ISSQNtot"].Rows.Add(DR);

                    this.ChecaCampo(DR["vServ"].ToString(), "vServ", ObOp.Opcional, 1, 16, 2);
                    this.ChecaCampo(DR["vBC"].ToString(), "vBC", ObOp.Opcional, 1, 16, 2);
                    this.ChecaCampo(DR["vISS"].ToString(), "vISS", ObOp.Opcional, 1, 16, 2);
                    this.ChecaCampo(DR["vPIS"].ToString(), "vPIS", ObOp.Opcional, 1, 16, 2);
                    this.ChecaCampo(DR["vCOFINS"].ToString(), "vCOFINS", ObOp.Opcional, 1, 16, 2);
                }
                #endregion

                #region RETENÇÕES DE TRIBUTOS (IMPLEMENTAR DEPOIS)
                /*
                        DataRow dr = dsNfe.Tables["retTrib"].NewRow();
                        bool lEntrou = false;
                        for (iLeitura = 0; iLeitura <= Math.Min(nElementos, 7); iLeitura++)
                        {
                            if (iLeitura > 0 & dados[iLeitura] != null && dados[iLeitura].Trim() != "")
                            {
                                dr[iLeitura - 1] = dados[iLeitura].Trim();
                                lEntrou = true;
                            }
                        }
                        if (lEntrou == true)
                        {
                            if (idprod == "")
                            {
                                cMensagemErro += "Segmento [W23] sem segmento [H]. Linha: " + iLinhaLida.ToString() + Environment.NewLine;
                            }
                            dr["total_Id"] = idprod.ToString();
                            dsNfe.Tables["retTrib"].Rows.Add(dr);

                            this.ChecaCampo(dados[0], "vRetPIS", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vRetCOFINS", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vRetCSLL", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vBCIRRF", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vIRRF", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vBCRetPrev", dr, ObOp.Opcional, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vRetPrev", dr, ObOp.Opcional, 1, 16, 2);
                        }
                    */
                #endregion
                #endregion

                #region INFORMAÇÕES DE TRANSPORTE
                DR = DS_NFe.Tables["transp"].NewRow();

                DR["modFrete"] = DR_NF["TipoFrete"];

                DR["transp_Id"] = 0;
                DR["infNFe_Id"] = 0;

                DS_NFe.Tables["transp"].Rows.Add(DR);

                this.ChecaCampo(DR["modFrete"].ToString(), "modFrete", ObOp.Obrigatorio, 1, 1);

                #region TRANSPORTADOR
                DT = new DataTable();
                DT = BLL_NF.Busca_NF_Transp(NFe);
                if (DT.Rows.Count > 0 && util_dados.Verifica_int(DT.Rows[0]["ID_PessoaT"].ToString()) > 0)
                {
                    DR_Transp = DT.Rows[0];

                    DR = DS_NFe.Tables["transporta"].NewRow();

                    CNPJ_CPF = "";
                    CNPJ_CPF = util_dados.Conf_strDoc_NFe(DR_Transp["CNPJ_CPF"].ToString());

                    if (CNPJ_CPF.Length == 14)
                        DR["CNPJ"] = CNPJ_CPF;
                    if (CNPJ_CPF.Length == 11)
                        DR["CPF"] = CNPJ_CPF;

                    DR["transp_Id"] = 0;

                    DR["xNome"] = DR_Transp["Nome"];

                    if (DR_Transp["IE"].ToString().Trim().Replace("0", "") != string.Empty)
                    {
                        DR["IE"] = util_dados.Conf_strDoc_NFe(DR_Transp["IE"]);
                        DR["UF"] = DR_Transp["UF"];
                    }

                    DR["xEnder"] = DR_Transp["Endereco"].ToString().TrimEnd();
                    DR["xMun"] = DR_Transp["Municipio"].ToString().TrimEnd();

                    DS_NFe.Tables["transporta"].Rows.Add(DR);

                    this.ChecaCampo(DR["xNome"].ToString(), "xNome", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["IE"].ToString(), "IE", ObOp.Opcional, 2, 14);
                    this.ChecaCampo(DR["xEnder"].ToString(), "xEnder", ObOp.Opcional, 1, 60);
                    this.ChecaCampo(DR["UF"].ToString(), "UF", ObOp.Opcional, 2, 2);
                    this.ChecaCampo(DR["xMun"].ToString(), "xMun", ObOp.Opcional, 1, 60);

                    if (CNPJ_CPF.Length == 14)
                        this.ChecaCampo(DR["CNPJ"].ToString(), "CNPJ", ObOp.Opcional, 14, 14);
                    else
                        this.ChecaCampo(DR["CPF"].ToString(), "CPF", ObOp.Opcional, 11, 11);
                }
                #endregion

                #region RETENÇÃO DE ICMS (IMPLEMENTAR DEPOIS)
                /*
                        DR = DS_NFe.Tables["retTransp"].NewRow();
                        if (this.PopulateDataRow(dr, dados, 7))
                        {
                            dr["transp_Id"] = 0;
                            dsNfe.Tables["retTransp"].Rows.Add(dr);

                            this.ChecaCampo(dados[0], "vServ", dr, ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(dados[0], "vBCRet", dr, ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(dados[0], "pICMSRet", dr, ObOp.Obrigatorio, 1, 6, 2);
                            this.ChecaCampo(dados[0], "vICMSRet", dr, ObOp.Obrigatorio, 1, 16, 2);
                            this.ChecaCampo(dados[0], "CFOP", dr, ObOp.Obrigatorio, 4, 4);
                            this.ChecaCampo(dados[0], "cMunFG", dr, ObOp.Obrigatorio, 7, 7);
                        }
                    */
                #endregion

                #region VEICULO DE TRANSPORTE (IMPLEMENTAR DEPOIS)
                /*
                    DataRow dr = dsNfe.Tables["veicTransp"].NewRow();
                    if (this.PopulateDataRow(dr, dados, 3))
                    {
                        //dr["placa"] = dados[1];
                        //dr["UF"] = dados[2];
                        //dr["RNTC"] = dados[3];
                        dr["transp_Id"] = 0;
                        dsNfe.Tables["veicTransp"].Rows.Add(dr);

                        this.ChecaCampo(dados[0], "placa", dr, ObOp.Obrigatorio, 1, 8);
                        this.ChecaCampo(dados[0], "UF", dr, ObOp.Obrigatorio, 2, 2);
                        this.ChecaCampo(dados[0], "RNTC", dr, ObOp.Opcional, 1, 20);
                    }
                */
                #endregion

                #region REBOQUE (IMPLEMENTAR DEPOIS)
                /*
                    DataRow dr = dsNfe.Tables["reboque"].NewRow();
                    if (this.PopulateDataRow(dr, dados, 3))
                    {
                        //dr["placa"] = dados[1];
                        //dr["UF"] = dados[2];
                        //dr["RNTC"] = dados[3];
                        dr["transp_Id"] = 0;
                        dsNfe.Tables["reboque"].Rows.Add(dr);

                        this.ChecaCampo(dados[0], "placa", dr, ObOp.Obrigatorio, 1, 8);
                        this.ChecaCampo(dados[0], "UF", dr, ObOp.Obrigatorio, 2, 2);
                        this.ChecaCampo(dados[0], "RNTC", dr, ObOp.Opcional, 1, 20);
                    }
                */
                #endregion

                #region VOLUME
                DT = new DataTable();
                DT = BLL_NF.Busca_NF_Volume(NFe);

                if (DT.Rows.Count > 0)
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        DR_Vol = DT.Rows[i];

                        DR = DS_NFe.Tables["vol"].NewRow();
                        ++Vol_ID;
                        DR["vol_Id"] = Vol_ID;
                        DR["transp_Id"] = 0;

                        if (Convert.ToDouble(DR_Vol["Quantidade"]) > 0)
                            DR["qVol"] = DR_Vol["Quantidade"].ToString().TrimEnd();

                        if (DR_Vol["Especie"].ToString().Trim() != string.Empty)
                            DR["esp"] = DR_Vol["Especie"].ToString().TrimEnd();

                        if (DR_Vol["Marca"].ToString().Trim() != string.Empty)
                            DR["marca"] = DR_Vol["Marca"].ToString().TrimEnd();

                        if (DR_Vol["Numeracao"].ToString().Trim() != string.Empty)
                            DR["nVol"] = DR_Vol["Numeracao"].ToString().TrimEnd();

                        DR["pesoL"] = util_dados.ConfigNumDecimal(DR_Vol["PesoL"], 13);
                        DR["pesoB"] = util_dados.ConfigNumDecimal(DR_Vol["PesoB"], 13);

                        DS_NFe.Tables["vol"].Rows.Add(DR);

                        this.ChecaCampo(DR["qVol"].ToString(), "qVol", ObOp.Opcional, 1, 15);
                        this.ChecaCampo(DR["esp"].ToString(), "esp", ObOp.Opcional, 1, 60);
                        this.ChecaCampo(DR["marca"].ToString(), "marca", ObOp.Opcional, 1, 60);
                        this.ChecaCampo(DR["nVol"].ToString(), "nVol", ObOp.Opcional, 1, 60);
                        this.ChecaCampo(DR["pesoL"].ToString(), "pesoL", ObOp.Opcional, 1, 16, 3);
                        this.ChecaCampo(DR["pesoB"].ToString(), "pesoB", ObOp.Opcional, 1, 16, 3);

                        #region LACRE
                        NFe.ID_NF_Volume = Convert.ToInt32(DR_Vol["ID"]);
                        DT_Lacre = BLL_NF.Busca_NF_Lacre(NFe);

                        if (DT_Lacre.Rows.Count > 0)
                            for (int ii = 0; ii <= DT_Lacre.Rows.Count - 1; ii++)
                            {
                                DR_Lacre = DT_Lacre.Rows[ii];

                                DR = DS_NFe.Tables["lacres"].NewRow();

                                DR["vol_Id"] = Vol_ID;
                                DR["nLacre"] = DR_Lacre["Numero"].ToString().TrimEnd();

                                DS_NFe.Tables["lacres"].Rows.Add(DR);

                                this.ChecaCampo(DR["nLacre"].ToString(), "nLacre", ObOp.Obrigatorio, 1, 60);
                            }
                        #endregion
                    }
                #endregion
                #endregion

                #region INFORMAÇÕES SOBRE COBRANÇA
                DT = new DataTable();
                DT = BLL_NF.Busca_NF_Duplicata(NFe);

                if (DT.Rows.Count > 0)
                {
                    DR = DS_NFe.Tables["cobr"].NewRow();
                    DR["cobr_Id"] = 0;
                    DR["infNFe_Id"] = 0;
                    DS_NFe.Tables["cobr"].Rows.Add(DR);

                    #region FATURA
                    DT = new DataTable();
                    DT = BLL_NF.Busca_NF_Cobranca(NFe);

                    if (DT.Rows.Count > 0)
                    {
                        DR_Fat = DT.Rows[0];

                        DR = DS_NFe.Tables["fat"].NewRow();

                        DR["nFat"] = DR_Fat["NumeroFatura"];
                        DR["vOrig"] = util_dados.ConfigNumDecimal(DR_Fat["Valor"], 12);
                        DR["vDesc"] = util_dados.ConfigNumDecimal(DR_Fat["Desconto"], 12);
                        DR["vLiq"] = util_dados.ConfigNumDecimal(DR_Fat["ValorFinal"], 12);

                        DR["cobr_Id"] = 0;
                        DS_NFe.Tables["fat"].Rows.Add(DR);

                        this.ChecaCampo(DR["nFat"].ToString(), "nFat", ObOp.Opcional, 1, 60);
                        this.ChecaCampo(DR["vOrig"].ToString(), "vOrig", ObOp.Opcional, 1, 16, 2);
                        this.ChecaCampo(DR["vDesc"].ToString(), "vDesc", ObOp.Opcional, 1, 16, 2);
                        this.ChecaCampo(DR["vLiq"].ToString(), "vLiq", ObOp.Opcional, 1, 16, 2);
                    }
                    #endregion

                    #region DUPLICATA
                    DT = new DataTable();
                    DT = BLL_NF.Busca_NF_Duplicata(NFe);

                    if (DT.Rows.Count > 0)
                        for (int i = 0; i <= DT.Rows.Count - 1; i++)
                        {
                            DR = DS_NFe.Tables["dup"].NewRow();

                            DR["cobr_Id"] = 0;

                            DR_Fat = DT.Rows[i];

                            DR["nDup"] = DR_Fat["NumeroDuplicata"].ToString().TrimEnd();
                            DR["dVenc"] = util_dados.Config_Data(Convert.ToDateTime(DR_Fat["Vencimento"]), 7);
                            DR["vDup"] = util_dados.ConfigNumDecimal(DR_Fat["Valor"], 12);

                            DS_NFe.Tables["dup"].Rows.Add(DR);

                            this.ChecaCampo(DR["nDup"].ToString(), "nDup", ObOp.Opcional, 1, 60);
                            this.ChecaCampo(DR["dVenc"].ToString(), "dVenc", ObOp.Opcional);
                            this.ChecaCampo(DR["vDup"].ToString(), "vDup", ObOp.Opcional, 1, 16, 2);
                        }
                    #endregion
                }
                #endregion

                #region INFORMAÇÕES ADICIONAIS
                if (Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS == true ||
                        DR_NF["InformacaoAdicional"].ToString().Trim() != string.Empty)
                {
                    DR = DS_NFe.Tables["infAdic"].NewRow();

                    DR["infAdic_Id"] = 0;
                    DR["infNFe_Id"] = 0;

                    //VERIFICA SE A NOTA FISCAL TEM PRODUTOS COM CFOP 5102 OU 6102 E COLOCA
                    //A INFORMAÇÃO DE PERMISSÃO DE CREDITO DE ICMS NA BASE DA NOTA FISCAL
                    if (Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS == true)
                        DR["infCpl"] = util_msg.msg_CreditoICMS.Replace("%CreditoICMS%", util_dados.ConfigNumDecimal(CreditoICMS_Simples, 22)).Replace("%Aliquota%", Parametro_NFe_NFC_SAT.AliquotaICMS.ToString()) + " - " + DR_NF["InformacaoAdicional"].ToString().TrimEnd();
                    else
                        DR["infCpl"] = DR_NF["InformacaoAdicional"].ToString().TrimEnd();

                    //DR["infAdFisco"] = DR_NF["InformacaoFisco"];                   

                    DS_NFe.Tables["infAdic"].Rows.Add(DR);

                    DS_NFe.Tables["infAdic"].Columns["infAdFisco"].AllowDBNull = true;

                    this.ChecaCampo(DR["infAdFisco"].ToString(), "infAdFisco", ObOp.Opcional, 1, 2000);
                    this.ChecaCampo(DR["infCpl"].ToString(), "infCpl", ObOp.Opcional, 1, 5000);
                }
                #endregion

                #region INFORMAÇÕES DO CONTRIBUINTE (IMPLEMENTAR DEPOIS)
                /*
                if (nElementos > 0)
                {
                    #region Criar a tag infAdic se necessário
                    // Se a tag infAdic ainda não foi criada por que não tem a infCpl e a infAdFisco no registro Z, vou forçar neste ponto pq a obsCont deve ficar dentro dela
                    // Wandrey 27/05/2010
                    if (indadicid == 0)
                    {
                        DataRow drInfAdic = dsNfe.Tables["infAdic"].NewRow();

                        ++indadicid;//danasa 27-9-2009;
                        drInfAdic["infAdic_Id"] = indadicid.ToString();
                        drInfAdic["infNFe_Id"] = 0;
                        dsNfe.Tables["infAdic"].Rows.Add(drInfAdic);
                    }
                    #endregion

                    DataRow dr = dsNfe.Tables["obsCont"].NewRow();
                    if (this.PopulateDataRow(dr, dados, 2))
                    {
                        dr["infAdic_Id"] = indadicid.ToString();
                        dsNfe.Tables["obsCont"].Rows.Add(dr);

                        this.ChecaCampo(dados[0], "xCampo", dr, ObOp.Obrigatorio, 1, 20);
                        this.ChecaCampo(dados[0], "xTexto", dr, ObOp.Obrigatorio, 1, 60);
                    }
                }
            }
            //dsNfe.Tables["obsFisco"]; não encontrei na documentação do TXT nada que fala sobre o conteudo dessa tebela
            */
                #endregion

                #region PROCESSO REFERENCIADO (IMPLEMENTAR DEPOIS)
                /*
                if (nElementos > 0)
                {
                    #region Criar a tag infAdic se necessário
                    // Se a tag infAdic ainda não foi criada por que não tem a infCpl, infAdFisco ou obsCont no registro Z ou Z04, 
                    // vou forçar neste ponto pq a procRef deve ficar dentro dela
                    // Wandrey 27/05/2010
                    if (indadicid == 0)
                    {
                        DataRow drInfAdic = dsNfe.Tables["infAdic"].NewRow();

                        ++indadicid;//danasa 27-9-2009;
                        drInfAdic["infAdic_Id"] = indadicid.ToString();
                        drInfAdic["infNFe_Id"] = 0;
                        dsNfe.Tables["infAdic"].Rows.Add(drInfAdic);
                    }
                    #endregion

                    DataRow dr = dsNfe.Tables["procRef"].NewRow();
                    if (this.PopulateDataRow(dr, dados, 2))
                    {
                        dr["infAdic_Id"] = indadicid.ToString();
                        dsNfe.Tables["procRef"].Rows.Add(dr);

                        this.ChecaCampo(dados[0], "nProc", dr, ObOp.Obrigatorio, 1, 60);
                        this.ChecaCampo(dados[0], "indProc", dr, ObOp.Obrigatorio, 1, 1);
                    }
                }
                }
             * */
                #endregion

                #region EXPORTAÇÃO (IMPLEMENTAR DEPOIS)
                /*
                DataRow dr = dsNfe.Tables["exporta"].NewRow();
                if (this.PopulateDataRow(dr, dados, 2))
                {
                    dr["infNFe_Id"] = 0;
                    dsNfe.Tables["exporta"].Rows.Add(dr);

                    this.ChecaCampo(dados[0], "UFEmbarq", dr, ObOp.Obrigatorio, 2, 2);
                    this.ChecaCampo(dados[0], "xLocEmbarq", dr, ObOp.Obrigatorio, 1, 60);
                }
            */
                #endregion

                #region COMPRA (IMPLEMENTAR DEPOIS)
                /*
                DataRow dr = dsNfe.Tables["compra"].NewRow();
                if (this.PopulateDataRow(dr, dados, 3))
                {
                    dr["infNFe_Id"] = 0;
                    dsNfe.Tables["compra"].Rows.Add(dr);

                    this.ChecaCampo(dados[0], "xNEmp", dr, ObOp.Opcional, 1, 17);
                    this.ChecaCampo(dados[0], "xPed", dr, ObOp.Opcional, 1, 60);
                    this.ChecaCampo(dados[0], "xCont", dr, ObOp.Opcional, 1, 60);
                }
             */
                #endregion

                #region CONFIGURA CAMPOS ANTES DE GERAR O XML
                string _tpEmis = DS_NFe.Tables["ide"].Rows[0]["tpEmis"].ToString();

                string aux = Chave + DR_NF["Serie"].ToString().Trim().PadLeft(3, '0') + DR_NF["ID_NFe"].ToString().PadLeft(9, '0') + _tpEmis + DR_NF["ID"].ToString().PadLeft(8, '0');

                DV_NF = util_dados.GerarDigito(aux);

                Chave += DR_NF["Serie"].ToString().Trim().PadLeft(3, '0') + DR_NF["ID_NFe"].ToString().PadLeft(9, '0') + _tpEmis + DR_NF["ID"].ToString().PadLeft(8, '0') + DV_NF.ToString("0");

                DS_NFe.Tables["ide"].Rows[0]["cDV"] = DV_NF;
                DS_NFe.Tables["infNFe"].Rows[0]["Id"] = "NFe" + Chave;
                DS_NFe.AcceptChanges();

                txt_XML = new StringWriter();
                txt_XML.NewLine = "";

                DS_NFe.WriteXml(txt_XML, XmlWriteMode.IgnoreSchema);

                string Aux = util_dados.Limpa_StringXML(txt_XML.ToString());

                //REMOVE ESPAÇOS ENTRE AS TAGS
                txt_XML.GetStringBuilder().Remove(0, txt_XML.ToString().Length);
                txt_XML.GetStringBuilder().Append(Aux);

                //AJUSTA TAG <NFref>
                if (txt_XML.ToString().IndexOf("<NFref>") > -1 && txt_XML.ToString().LastIndexOf("</NFref>") > -1)
                {
                    Aux = txt_XML.ToString().Substring(txt_XML.ToString().IndexOf("<NFref>"), txt_XML.ToString().LastIndexOf("</NFref>") - txt_XML.ToString().IndexOf("<NFref>") + 8);
                    txt_XML.GetStringBuilder().Remove(txt_XML.ToString().IndexOf("<NFref>"), txt_XML.ToString().LastIndexOf("</NFref>") - txt_XML.ToString().IndexOf("<NFref>") + 8);
                    txt_XML.GetStringBuilder().Replace("<tpImp>", Aux + "<tpImp>");
                }

                //MOVE OS DADOS DA TAG </infAdProd> PARA APOS A TAG IMPOSTOS
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
                if (txt_XML.ToString().IndexOf("<xFant>") == -1)
                    throw new Exception("tag <xFant> não encontrada");

                if (txt_XML.ToString().IndexOf("<enderEmit>") == -1)
                    throw new Exception("tag <enderEmit> não encontada");

                Aux = txt_XML.ToString().Substring(txt_XML.ToString().IndexOf("<enderEmit>"), (txt_XML.ToString().IndexOf("</enderEmit>") - txt_XML.ToString().IndexOf("<enderEmit>")) + 12);
                txt_XML.GetStringBuilder().Replace(Aux, "").Replace("NewDataSet", "NFe");
                txt_XML.GetStringBuilder().Replace("</xFant>", "</xFant>" + Aux);

                // AJUSTA A TAG IE DO DESTINATÁRIO
                if (txt_XML.ToString().IndexOf("<enderDest>") == -1)
                    throw new Exception("tag <enderDest> não encontrada");

                Aux = txt_XML.ToString().Substring(txt_XML.ToString().IndexOf("<enderDest>"), (txt_XML.ToString().IndexOf("</enderDest>") - txt_XML.ToString().IndexOf("<enderDest>")) + 12);
                txt_XML.GetStringBuilder().Replace(Aux, "");

                if (txt_XML.ToString().IndexOf("<dest>") == -1)
                    throw new Exception("tag <dest> não encontrada");

                string Aux2 = txt_XML.ToString().Substring(txt_XML.ToString().IndexOf("<dest>"), (txt_XML.ToString().IndexOf("</dest>") - txt_XML.ToString().IndexOf("<dest>")) + 7);
                if (Aux2.IndexOf("<IE>") == -1 && Aux2.IndexOf("<IE/>") == -1)
                    throw new Exception("tag <IE> não encontrada na tag <dest>");

                if (Aux2.IndexOf("<IE>") == -1)
                    txt_XML.GetStringBuilder().Insert(txt_XML.ToString().IndexOf("<IE/>", txt_XML.ToString().IndexOf("<dest>")), Aux);
                else
                    txt_XML.GetStringBuilder().Insert(txt_XML.ToString().IndexOf("<IE>", txt_XML.ToString().IndexOf("<dest>")), Aux);

                //RETIRA NO NAMESPACE xsi POIS TEM ESTADO QUE NÃO TÁ ACEITANDO
                txt_XML.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                txt_XML.GetStringBuilder().Replace("<infAdProd>~-?-~</infAdProd>", "");
                #endregion

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(txt_XML.ToString());

                #region CONFERE XML
                XmlNodeList prodList = xdoc.GetElementsByTagName("det");
                foreach (XmlNode prodItem in prodList)
                {
                    foreach (XmlNode xItem0 in prodItem.ChildNodes)
                    {
                        if (xItem0.Name == "prod")
                        {
                            XmlNode xItemxPed_ok = null;
                            XmlNode xItemnItemPed_ok = null;
                            bool DI_found = false;

                            foreach (XmlNode xItemxPed in xItem0.ChildNodes)
                            {
                                switch (xItemxPed.Name)
                                {
                                    case "xPed":
                                        xItemxPed_ok = xItemxPed;
                                        break;

                                    case "nItemPed":
                                        xItemnItemPed_ok = xItemxPed;
                                        break;

                                    case "DI":
                                        {
                                            DI_found = true;
                                            if (xItemxPed_ok != null)
                                            {
                                                //se a tag <xPed> for encontrada, insere logo apos a tag <DI>
                                                xItem0.InsertAfter(xItemxPed_ok, xItemxPed);
                                            }
                                            if (xItemnItemPed_ok != null)
                                            {
                                                if (xItemxPed_ok == null)
                                                    //se a tag <nItemPed> for encontrada, insere logo apos a tag <DI><xPed>
                                                    xItem0.InsertAfter(xItemnItemPed_ok, xItemxPed);
                                                else
                                                    //se a tag <nItemPed> for encontrada, insere logo apos a tag <DI>
                                                    xItem0.InsertAfter(xItemnItemPed_ok, xItemxPed_ok);
                                            }
                                        }
                                        break;
                                }
                                if (DI_found)
                                    break;
                            }
                        }
                        break;
                    }
                }
                #endregion

                if (ErroInfo != string.Empty)
                    throw new Exception(util_msg.msg_Erro_XML_NFe + ErroInfo);

                return xdoc;
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        private XmlDocument Gera_Estrutura_XML_Cancelamento(int _ID_NFe, string _Chave, string _UF, string _Amb, string _CNPJ_CPF, string _Just, string _Prot)
        {
            if (_ID_NFe > 0)
            {
                infEvento _evento = new infEvento();

                _evento.cOrgao = _UF;
                _evento.tpAmb = _Amb;

                if (_CNPJ_CPF.Length == 14)
                    _evento.CNPJ = _CNPJ_CPF;

                if (_CNPJ_CPF.Length == 11)
                    DR["CPF"] = _CNPJ_CPF;

                _evento.chNFe = _Chave;
                _evento.dhEvento = util_dados.Config_Data(DateTime.Now, 13).ToString();
                _evento.tpEvento = "110111";
                _evento.nSeqEvento = "1";
                _evento.verEvento = "1.00";

                _evento._detEvento = new detEvento();
                _evento._detEvento.descEvento = "Cancelamento";
                _evento._detEvento.nProt = _Prot;
                _evento._detEvento.xJust = _Just;

                string aux = util_dados.Gerar_XML<infEvento>(_evento);

                aux = aux.Replace("<infEvento>", "<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><infEvento Id=\"ID110111" + _Chave + "01\">");
                aux = aux.Replace("</infEvento>", "</infEvento></evento>");
                aux = aux.Replace("<detEvento>", "<detEvento versao=\"1.00\">");

                aux = util_dados.Limpa_StringXML(aux);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(aux);

                NFe_CertificadoDigital _Cert = new NFe_CertificadoDigital();
                string aux2 = _Cert.Assina_XML(xdoc, Parametro_NFe_NFC_SAT.CertificadoDigital);

                aux2 = aux2.Replace("</evento>", "</evento></envEvento>");
                aux2 = aux2.Replace("<evento", "<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><idLote>1</idLote><evento");

                xdoc = new XmlDocument();
                xdoc.LoadXml(aux2);

                return xdoc;
            }
            return null;
        }

        private XmlDocument Gera_Estrutura_XML_CartaCorrecao(int _ID_NFe, string _Chave, string _UF, string _Amb, string _CNPJ_CPF, string _Just)
        {
            if (_ID_NFe > 0)
            {
                int _Seq = 0;

                NFe = new DTO_NF();
                BLL_NF = new BLL_NF();

                NFe.ID = _ID_NFe;
                NFe.Tipo_Evento = 4;
                DataTable _DT = BLL_NF.Busca_NF_Evento(NFe);

                if (_DT.Rows.Count > 0)
                    _Seq = Convert.ToInt32(_DT.Rows[_DT.Rows.Count - 1]["Seq"]) + 1;
                else
                    _Seq = 1;

                infEvento _evento = new infEvento();

                _evento.cOrgao = _UF;
                _evento.tpAmb = _Amb;

                if (_CNPJ_CPF.Length == 14)
                    _evento.CNPJ = _CNPJ_CPF;

                if (_CNPJ_CPF.Length == 11)
                    DR["CPF"] = _CNPJ_CPF;

                _evento.chNFe = _Chave;
                _evento.dhEvento = util_dados.Config_Data(DateTime.Now, 13).ToString();
                _evento.tpEvento = "110110";
                _evento.nSeqEvento = _Seq.ToString();
                _evento.verEvento = "1.00";

                _evento._detEvento = new detEvento();
                _evento._detEvento.descEvento = "Carta de Correcao";
                _evento._detEvento.xCorrecao = _Just;
                _evento._detEvento.xCondUso = "--~--";

                string aux = util_dados.Gerar_XML<infEvento>(_evento);

                aux = aux.Replace("<infEvento>", "<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><infEvento Id=\"ID110110" + _Chave + _Seq.ToString().PadLeft(2, '0') + "\">");
                aux = aux.Replace("</infEvento>", "</infEvento></evento>");
                aux = aux.Replace("<detEvento>", "<detEvento versao=\"1.00\">");

                aux = util_dados.Limpa_StringXML(aux);
                aux = aux.Replace("--~--", "A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de emissao ou de saida.");

                //aux = util_dados.Limpa_StringXML(aux);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(aux);

                NFe_CertificadoDigital _Cert = new NFe_CertificadoDigital();
                string aux2 = _Cert.Assina_XML(xdoc, Parametro_NFe_NFC_SAT.CertificadoDigital);

                aux2 = aux2.Replace("</evento>", "</evento></envEvento>");
                aux2 = aux2.Replace("<evento", "<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><idLote>1</idLote><evento");
                xdoc = new XmlDocument();
                xdoc.LoadXml(aux2);

                return xdoc;
            }
            return null;
        }

        private void Assina_XML(XmlDocument _xml)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc = _xml;

                if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Envia))
                    System.IO.Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Envia);

                string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Envia + Chave + NFe_extxml.Nfe;

                if (File.Exists(XML_aux))
                    File.Delete(XML_aux);

                XmlTextWriter xWriter = new XmlTextWriter(@XML_aux, Encoding.UTF8);
                xWriter.Formatting = Formatting.None;
                xdoc.Save(xWriter);

                xWriter.Close();

                NFe_CertificadoDigital _Cert = new NFe_CertificadoDigital();

                _Cert.Assina_XML(XML_aux, Parametro_NFe_NFC_SAT.CertificadoDigital);
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_NFe_Assinar + ex.Message);
            }
        }

        public void Consulta_Recibo(string XML)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(XML);

                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                string UF = string.Empty;
                string Amb = string.Empty;
                int ID_NFe = 0;

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    UF = _elemento.GetElementsByTagName("cUF")[0].InnerText;
                    Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                    ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
                }

                if (ID_NFe > 0)
                {
                    NFe = new DTO_NF();
                    BLL_NF = new BLL_NF();

                    NFe.ID = ID_NFe;
                    NFe.Tipo_Evento = 1;
                    string Protocolo = string.Empty;
                    int ID_Empresa = 0;

                    DataTable _DT = BLL_NF.Busca_NF_Evento(NFe);

                    if (_DT.Rows.Count > 0)
                    {
                        Protocolo = _DT.Rows[0]["Protocolo"].ToString();
                        ID_Empresa = Convert.ToInt32(_DT.Rows[0]["ID_Empresa"]);

                        Carrega_Parametros(ID_Empresa);

                        NFe_RetRecepcao2 _RetRecep = new NFe_RetRecepcao2();
                        string retorno = _RetRecep.ConsultaProcesso(XML, Protocolo, Parametro_NFe_NFC_SAT.CertificadoDigital);

                        Ler_Retorno(XML, retorno, RetornoNFe.ConsultaLote, ID_NFe);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Cancela_NFe(string XML, string _Justificativa)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(XML);

            string UF = string.Empty;
            string Amb = string.Empty;
            int ID_NFe = 0;
            string Chave = string.Empty;
            string CNPJ_CPF = string.Empty;
            string Protocolo = string.Empty;

            XmlNodeList _ide = xml.GetElementsByTagName("ide");

            foreach (XmlNode _aux in _ide)
            {
                XmlElement _elemento = (XmlElement)_aux;
                UF = _elemento.GetElementsByTagName("cUF")[0].InnerText;
                Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
            }

            XmlNodeList _infNFe = xml.GetElementsByTagName("infProt");

            foreach (XmlNode _aux in _infNFe)
            {
                XmlElement _elemento = (XmlElement)_aux;
                Chave = _elemento.GetElementsByTagName("chNFe")[0].InnerText;
                Protocolo = _elemento.GetElementsByTagName("nProt")[0].InnerText;
            }

            XmlNodeList _emit = xml.GetElementsByTagName("emit");

            foreach (XmlNode _aux in _emit)
            {
                XmlElement _elemento = (XmlElement)_aux;
                CNPJ_CPF = _elemento.GetElementsByTagName("CNPJ")[0].InnerText;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc = Gera_Estrutura_XML_Cancelamento(ID_NFe, Chave, UF, Amb, CNPJ_CPF, util_dados.ConfigCampoNFe(_Justificativa.TrimEnd()), Protocolo);

            NFe_RecepcaoEvento2 _RecepEvento = new NFe_RecepcaoEvento2();
            string retorno = _RecepEvento.Cancela_NFe(xdoc.InnerXml, Parametro_NFe_NFC_SAT.CertificadoDigital);

            Ler_Retorno(XML, retorno, RetornoNFe.Cancelamento, ID_NFe, xdoc.OuterXml);
        }

        public void CartaCorrecao_NFe(string XML, string _Justificativa)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(XML);

            string UF = string.Empty;
            string Amb = string.Empty;
            int ID_NFe = 0;
            string Chave = string.Empty;
            string CNPJ_CPF = string.Empty;
            string Protocolo = string.Empty;

            XmlNodeList _ide = xml.GetElementsByTagName("ide");

            foreach (XmlNode _aux in _ide)
            {
                XmlElement _elemento = (XmlElement)_aux;
                UF = _elemento.GetElementsByTagName("cUF")[0].InnerText;
                Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
            }

            XmlNodeList _infNFe = xml.GetElementsByTagName("infProt");

            foreach (XmlNode _aux in _infNFe)
            {
                XmlElement _elemento = (XmlElement)_aux;
                Chave = _elemento.GetElementsByTagName("chNFe")[0].InnerText;
            }

            XmlNodeList _emit = xml.GetElementsByTagName("emit");

            foreach (XmlNode _aux in _emit)
            {
                XmlElement _elemento = (XmlElement)_aux;
                CNPJ_CPF = _elemento.GetElementsByTagName("CNPJ")[0].InnerText;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc = Gera_Estrutura_XML_CartaCorrecao(ID_NFe, Chave, UF, Amb, CNPJ_CPF, util_dados.ConfigCampoNFe(_Justificativa.TrimEnd()));

            NFe_RecepcaoEvento2 _RecepEvento = new NFe_RecepcaoEvento2();
            string retorno = _RecepEvento.Cancela_NFe(xdoc.InnerXml, Parametro_NFe_NFC_SAT.CertificadoDigital);

            Ler_Retorno(XML, retorno, RetornoNFe.CartaCorrecao, ID_NFe, xdoc.OuterXml);
        }

        private void Ler_Retorno(string _xml, string _Retorno, RetornoNFe _RetornoNFe, int ID_NFe, string str_aux = "")
        {
            try
            {
                DTO_NFe_Retorno NFe_Retorno;
                XmlDocument doc;
                XmlNodeList _aux;
                XmlDocument xml;
                XmlNodeList _ide;

                string Emissao;

                switch (_RetornoNFe)
                {
                    #region EnvioLote
                    case RetornoNFe.EnvioLote:
                        NFe_Retorno = new DTO_NFe_Retorno();

                        doc = new XmlDocument();
                        doc.LoadXml(_Retorno);

                        _aux = doc.GetElementsByTagName("retEnviNFe");

                        foreach (XmlNode _in in _aux)
                        {
                            XmlElement _elemento = (XmlElement)_in;
                            NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                        }

                        if (NFe_Retorno.cStat == "103")
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRecbto")[0].InnerText);
                                NFe_Retorno.nRec = _elemento.GetElementsByTagName("nRec")[0].InnerText;
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                            }

                            NFe = new DTO_NF();
                            BLL_NF = new BLL_NF();

                            NFe.Protocolo = NFe_Retorno.nRec;
                            NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                            NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                            NFe.Seq_Evento = 0;
                            NFe.Situacao = util_Param.NFe_EmProcessamento;
                            NFe.Tipo_Evento = 1;

                            NFe.ID = ID_NFe;

                            BLL_NF.Grava_Evento(NFe);
                            BLL_NF.Altera_Situacao(NFe);

                            if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento))
                                System.IO.Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento);

                            string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento + _xml.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado, "");

                            if (File.Exists(XML_aux))
                                File.Delete(XML_aux);

                            File.Move(_xml, XML_aux);
                        }
                        else
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRecbto")[0].InnerText);
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                            }
                            NFe = new DTO_NF();
                            BLL_NF = new BLL_NF();

                            NFe.Protocolo = string.Empty;
                            NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                            NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                            NFe.Seq_Evento = 0;
                            NFe.Tipo_Evento = 1;

                            NFe.ID = ID_NFe;

                            BLL_NF.Grava_Evento(NFe);

                            if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro))
                                System.IO.Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro);

                            string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro + _xml.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado, "");

                            if (File.Exists(XML_aux))
                                File.Delete(XML_aux);

                            File.Move(_xml, XML_aux);

                            throw new Exception(util_msg.msg_NFe_erro_Processar + NFe_Retorno.xMotivo);
                        }
                        break;
                    #endregion

                    #region ConsultaLote
                    case RetornoNFe.ConsultaLote:
                        NFe_Retorno = new DTO_NFe_Retorno();

                        xml = new XmlDocument();
                        xml.Load(_xml);

                        _ide = xml.GetElementsByTagName("ide");

                        Emissao = string.Empty;

                        foreach (XmlNode aux in _ide)
                        {
                            XmlElement _elemento = (XmlElement)aux;
                            Emissao = _elemento.GetElementsByTagName("dEmi")[0].InnerText;
                        }

                        doc = new XmlDocument();
                        doc.LoadXml(_Retorno);

                        _aux = doc.GetElementsByTagName("infProt");

                        foreach (XmlNode _in in _aux)
                        {
                            XmlElement _elemento = (XmlElement)_in;
                            NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                        }

                        if (NFe_Retorno.cStat == "100")
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRecbto")[0].InnerText);
                                NFe_Retorno.nRec = _elemento.GetElementsByTagName("nProt")[0].InnerText;
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                            }

                            NFe = new DTO_NF();
                            BLL_NF = new BLL_NF();

                            NFe.Protocolo = NFe_Retorno.nRec;
                            NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                            NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                            NFe.Seq_Evento = 1;
                            NFe.Situacao = util_Param.NFe_Autorizada;
                            NFe.Tipo_Evento = 2;

                            NFe.ID = ID_NFe;

                            BLL_NF.Grava_Evento(NFe);
                            BLL_NF.Altera_Situacao(NFe);

                            XmlDocument xNFe = new XmlDocument();
                            xNFe.Load(_xml);

                            XmlDocument xProt = new XmlDocument();
                            xProt.LoadXml(_Retorno);

                            string xml_nfe = xNFe.InnerXml;
                            XmlNodeList xml_List = xProt.GetElementsByTagName("protNFe");
                            string xml_re = xml_List[0].OuterXml;

                            string aux = xml_nfe.Replace("<NFe", "<nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"2.00\"><NFe");
                            aux = aux.Replace("</NFe>", "</NFe>" + xml_re.Replace(" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", "") + "</nfeProc>");

                            aux = util_dados.Limpa_StringXML(aux);

                            XmlDocument xaux = new XmlDocument();
                            xaux.LoadXml(aux);

                            XmlTextWriter xWriter = new XmlTextWriter(_xml, Encoding.UTF8);
                            xWriter.Formatting = Formatting.None;
                            xaux.Save(xWriter);
                            xWriter.Close();

                            string _Periodo = util_dados.Config_Data(Convert.ToDateTime(Emissao), 9).ToString();

                            if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo))
                                Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo);

                            string _xml2 = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + "\\" + _xml.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento, "").Replace("-nfe.xml", "") + NFe_extxml.ProcNFe;
                            File.Move(_xml, _xml2);

                            Gera_Danfe(_xml2);

                            Envia_Email(_xml2);
                            return;
                        }

                        if (NFe_Retorno.cStat == "101" ||
                            NFe_Retorno.cStat == "104" ||
                            NFe_Retorno.cStat == "105" ||
                            NFe_Retorno.cStat == "107" ||
                            NFe_Retorno.cStat == "108" ||
                            NFe_Retorno.cStat == "109")
                            return;

                        else
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                                NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRecbto")[0].InnerText);
                            }

                            NFe = new DTO_NF();
                            BLL_NF = new BLL_NF();

                            NFe.Protocolo = string.Empty;
                            NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                            NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                            NFe.Seq_Evento = 1;
                            NFe.Tipo_Evento = 1;

                            NFe.ID = ID_NFe;

                            BLL_NF.Grava_Evento(NFe);

                            if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro))
                                System.IO.Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro);

                            string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro + _xml.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento, "");

                            if (File.Exists(XML_aux))
                                File.Delete(XML_aux);

                            File.Move(_xml, XML_aux);

                            NFe = new DTO_NF();
                            BLL_NF = new BLL_NF();

                            NFe.Situacao = util_Param.NFe_Digitacao;

                            NFe.ID = ID_NFe;

                            BLL_NF.Altera_Situacao(NFe);

                            throw new Exception(util_msg.msg_NFe_erro_Processar + NFe_Retorno.xMotivo);
                        }
                        break;
                    #endregion

                    #region Cancelamento
                    case RetornoNFe.Cancelamento:
                        NFe_Retorno = new DTO_NFe_Retorno();

                        xml = new XmlDocument();
                        xml.Load(_xml);

                        _ide = xml.GetElementsByTagName("ide");

                        Emissao = string.Empty;
                        string _Chave = string.Empty;

                        foreach (XmlNode aux in _ide)
                        {
                            XmlElement _elemento = (XmlElement)aux;
                            Emissao = _elemento.GetElementsByTagName("dEmi")[0].InnerText;
                        }

                        doc = new XmlDocument();
                        doc.LoadXml(_Retorno);

                        _aux = doc.GetElementsByTagName("retEnvEvento");

                        foreach (XmlNode _in in _aux)
                        {
                            XmlElement _elemento = (XmlElement)_in;
                            NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                        }

                        if (NFe_Retorno.cStat == "128")
                        {
                            _aux = doc.GetElementsByTagName("infEvento");

                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                            }

                            if (NFe_Retorno.cStat == "135" ||
                                NFe_Retorno.cStat == "155")
                            {
                                foreach (XmlNode _in in _aux)
                                {
                                    XmlElement _elemento = (XmlElement)_in;
                                    NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRegEvento")[0].InnerText);
                                    NFe_Retorno.nRec = _elemento.GetElementsByTagName("nProt")[0].InnerText;
                                    NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                                    _Chave = _elemento.GetElementsByTagName("chNFe")[0].InnerText;
                                }

                                NFe = new DTO_NF();
                                BLL_NF = new BLL_NF();

                                NFe.Protocolo = NFe_Retorno.nRec;
                                NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                                NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                                NFe.Seq_Evento = 1;
                                NFe.Situacao = util_Param.NFe_Cancelada;
                                NFe.Tipo_Evento = 3;

                                NFe.ID = ID_NFe;

                                BLL_NF.Grava_Evento(NFe);
                                BLL_NF.Altera_Situacao(NFe);

                                XmlDocument xaux2 = new XmlDocument();
                                xaux2.LoadXml(str_aux);

                                XmlDocument xProt = new XmlDocument();
                                xProt.LoadXml(_Retorno);

                                XmlNodeList xml_List = xaux2.GetElementsByTagName("evento");
                                string xml_re = "<procEventoNFe versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">" + xml_List[0].OuterXml;

                                XmlNodeList xml_List2 = xProt.GetElementsByTagName("retEvento");
                                xml_re += xml_List2[0].OuterXml + "</procEventoNFe>";

                                xml_re = util_dados.Limpa_StringXML(xml_re);

                                string _Periodo = util_dados.Config_Data(Convert.ToDateTime(Emissao), 9).ToString();

                                if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo))
                                    Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo);

                                string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + @"\" + _Chave + NFe_extxml.ProcCancNFe;

                                if (File.Exists(XML_aux))
                                    File.Delete(XML_aux);

                                XmlDocument xaux = new XmlDocument();
                                xaux.LoadXml(xml_re);

                                XmlTextWriter xWriter = new XmlTextWriter(XML_aux, Encoding.UTF8);
                                xWriter.Formatting = Formatting.None;
                                xaux.Save(xWriter);
                                xWriter.Close();

                                #region ENVIA EMAIL
                                try
                                {
                                    NFe_EnviaEmail _EnviaEmail = new NFe_EnviaEmail();
                                    _EnviaEmail.Envia_Canc(XML_aux, XML_aux.Replace(NFe_extxml.ProcCancNFe, NFe_extxml.ProcNFe));
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }
                                #endregion
                                return;
                            }
                        }
                        if (NFe_Retorno.cStat == "104" ||
                            NFe_Retorno.cStat == "105" ||
                            NFe_Retorno.cStat == "107" ||
                            NFe_Retorno.cStat == "108" ||
                            NFe_Retorno.cStat == "109")
                            return;

                        else
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                            }

                            throw new Exception(util_msg.msg_NFe_erro_Processar + NFe_Retorno.xMotivo);
                        }
                        break;
                    #endregion

                    #region Carta de Correção
                    case RetornoNFe.CartaCorrecao:
                        NFe_Retorno = new DTO_NFe_Retorno();

                        xml = new XmlDocument();
                        xml.Load(_xml);

                        _ide = xml.GetElementsByTagName("ide");

                        Emissao = string.Empty;
                        string _Chave1 = string.Empty;
                        int _Seq = 0;

                        foreach (XmlNode aux in _ide)
                        {
                            XmlElement _elemento = (XmlElement)aux;
                            Emissao = _elemento.GetElementsByTagName("dEmi")[0].InnerText;
                        }

                        doc = new XmlDocument();
                        doc.LoadXml(_Retorno);

                        _aux = doc.GetElementsByTagName("retEnvEvento");

                        foreach (XmlNode _in in _aux)
                        {
                            XmlElement _elemento = (XmlElement)_in;
                            NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                        }

                        if (NFe_Retorno.cStat == "128")
                        {
                            _aux = doc.GetElementsByTagName("infEvento");

                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.cStat = _elemento.GetElementsByTagName("cStat")[0].InnerText;
                            }

                            if (NFe_Retorno.cStat == "135")
                            {
                                foreach (XmlNode _in in _aux)
                                {
                                    XmlElement _elemento = (XmlElement)_in;
                                    NFe_Retorno.dhRecbto = Convert.ToDateTime(_elemento.GetElementsByTagName("dhRegEvento")[0].InnerText);
                                    NFe_Retorno.nRec = _elemento.GetElementsByTagName("nProt")[0].InnerText;
                                    NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xEvento")[0].InnerText + " - " + _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                                    _Chave1 = _elemento.GetElementsByTagName("chNFe")[0].InnerText;
                                    _Seq = Convert.ToInt32(_elemento.GetElementsByTagName("nSeqEvento")[0].InnerText);
                                }

                                NFe = new DTO_NF();
                                BLL_NF = new BLL_NF();

                                NFe.Protocolo = NFe_Retorno.nRec;
                                NFe.Data_Protocolo = NFe_Retorno.dhRecbto;
                                NFe.Evento_Protocolo = NFe_Retorno.xMotivo;
                                NFe.Seq_Evento = _Seq;
                                NFe.Tipo_Evento = 4;

                                NFe.ID = ID_NFe;

                                BLL_NF.Grava_Evento(NFe);

                                XmlDocument xaux2 = new XmlDocument();
                                xaux2.LoadXml(str_aux);

                                XmlDocument xProt = new XmlDocument();
                                xProt.LoadXml(_Retorno);

                                XmlNodeList xml_List = xaux2.GetElementsByTagName("evento");
                                string xml_re = "<procEventoNFe versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">" + xml_List[0].OuterXml;

                                XmlNodeList xml_List2 = xProt.GetElementsByTagName("retEvento");
                                xml_re += xml_List2[0].OuterXml + "</procEventoNFe>";

                                string _Periodo = util_dados.Config_Data(Convert.ToDateTime(Emissao), 9).ToString();

                                if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo))
                                    Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo);

                                string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo + @"\" + _Chave1 + "-" + _Seq + NFe_extxml.ProcCCNFe;

                                if (File.Exists(XML_aux))
                                    File.Delete(XML_aux);

                                XmlDocument xaux = new XmlDocument();
                                xaux.LoadXml(xml_re);

                                XmlTextWriter xWriter = new XmlTextWriter(XML_aux, Encoding.UTF8);
                                xWriter.Formatting = Formatting.None;
                                xaux.Save(xWriter);
                                xWriter.Close();

                                if (File.Exists(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf"))
                                    File.Delete(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf");

                                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                                proc.EnableRaisingEvents = false;
                                proc.StartInfo.FileName = Parametro_Sistema.Caminho_Sistema + @"UniNFe\unidanfe.exe";
                                proc.StartInfo.Arguments = "A=" + XML_aux + " I=\"NFe\" M=1 Ps=1 C=";
                                proc.Start();

                                for (int i = 0; i <= 20; i++)
                                    if (!File.Exists(Parametro_Sistema.Caminho_Sistema + @"\Temp\danfe.pdf"))
                                        Thread.Sleep(1000);
                                    else
                                        break;

                                File.Move(Parametro_Sistema.Caminho_Sistema + @"\Temp\danfe.pdf", XML_aux.Replace(NFe_extxml.ProcCCNFe, NFe_extxml.DanfeCCe));

                                #region ENVIA EMAIL
                                try
                                {
                                    NFe_EnviaEmail _EnviaEmail = new NFe_EnviaEmail();
                                    _EnviaEmail.Envia_CCe(XML_aux, XML_aux.Replace(NFe_extxml.ProcCCNFe, NFe_extxml.DanfeCCe), _xml);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }
                                #endregion
                                return;
                            }
                        }
                        if (NFe_Retorno.cStat == "104" ||
                            NFe_Retorno.cStat == "105" ||
                            NFe_Retorno.cStat == "107" ||
                            NFe_Retorno.cStat == "108" ||
                            NFe_Retorno.cStat == "109")
                            return;

                        else
                        {
                            foreach (XmlNode _in in _aux)
                            {
                                XmlElement _elemento = (XmlElement)_in;
                                NFe_Retorno.xMotivo = _elemento.GetElementsByTagName("xMotivo")[0].InnerText;
                            }

                            throw new Exception(util_msg.msg_NFe_erro_Processar + NFe_Retorno.xMotivo);
                        }
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Processa_NFe(int ID_NFe, ProcessoNF _Processo, string _XMLGerar = "")
        {
            try
            {
                Chave = "";

                XmlDocument xdoc;

                switch (_Processo)
                {
                    #region VALIDAR NFe
                    case ProcessoNF.Validar:
                        xdoc = new XmlDocument();
                        xdoc = Gera_Estrutura_XML_NFe(ID_NFe);
                        Assina_XML(xdoc);

                        NFe = new DTO_NF();
                        BLL_NF = new BLL_NF();

                        NFe.Situacao = util_Param.NFe_Assinada;
                        NFe.ID = ID_NFe;

                        BLL_NF.Altera_Situacao(NFe);
                        break;
                    #endregion

                    #region TRANSMISSÃO DE NFe
                    case ProcessoNF.Transmitir:
                        xdoc = new XmlDocument();
                        xdoc = Gera_Estrutura_XML_NFe(ID_NFe);
                        Assina_XML(xdoc);

                        string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado + Chave + NFe_extxml.Nfe;

                        NFe_Recepcao2 _Recep = new NFe_Recepcao2();
                        string retorno = _Recep.Transmite_XML(XML_aux, Parametro_NFe_NFC_SAT.CertificadoDigital);

                        Ler_Retorno(XML_aux, retorno, RetornoNFe.EnvioLote, ID_NFe);
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Envia_Email(string _xml)
        {
            try
            {
                NFe_EnviaEmail _EnviaEmail = new NFe_EnviaEmail();
                _EnviaEmail.Envia_NFe(_xml, _xml.Replace(NFe_extxml.ProcNFe, NFe_extxml.Danfe));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Gera_Danfe(string _xml)
        {
            #region GERAR PDF USANDO UNIDANFE
            if (File.Exists(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf"))
                File.Delete(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf");

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = Parametro_Sistema.Caminho_Sistema + @"UniNFe\unidanfe.exe";
            proc.StartInfo.Arguments = "A=" + _xml + " I=\"NFe\" M=1 Ps=1 C=";
            proc.Start();

            for (int i = 0; i <= 20; i++)
                if (!File.Exists(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf"))
                    Thread.Sleep(2000);
                else
                    break;

            if (_xml.IndexOf(NFe_extxml.ProcNFe) != -1)
                File.Move(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf", _xml.Replace(NFe_extxml.ProcNFe, NFe_extxml.Danfe));

            if (_xml.IndexOf(NFe_extxml.ProcCCNFe) != -1)
                File.Move(Parametro_Sistema.Caminho_Sistema + @"Temp\danfe.pdf", _xml.Replace(NFe_extxml.ProcCCNFe, NFe_extxml.DanfeCCe));
            #endregion
        }
        #endregion
    }
}

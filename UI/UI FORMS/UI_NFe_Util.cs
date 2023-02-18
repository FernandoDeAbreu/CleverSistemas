using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using System.Diagnostics;

namespace Sistema.UI
{
    public partial class UI_NFe_Util : Sistema.UI.UI_Modelo
    {
        public UI_NFe_Util()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NF BLL_NF;
        BLL_Pessoa BLL_Pessoa;
        BLL_Venda BLL_Venda;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region ESTRUTURA
        DTO_NF NFe;
        DTO_Pessoa Pessoa;
        DTO_Venda Venda;
        DTO_Parametro Parametro;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;

        bool Seleciona;
        bool ConsultaProcesso;

        DateTime ValidaData;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "GERENCIAR NF-e";

            TabPage1.Text = "NF-e";

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
        }

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

                Parametro_NFe_NFC_SAT.CertificadoDigital = _DT.Rows[0]["Certificado_NFe"].ToString();
                Parametro_NFe_NFC_SAT.Caminho_NFe = Convert.ToString(_DT.Rows[0]["Caminho_NFe"]);
                Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DT.Rows[0]["AmbienteNFe"]);
                Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DT.Rows[0]["RegimeTributario"]);
                Parametro_NFe_NFC_SAT.Exibe_InfoProd = Convert.ToBoolean(_DT.Rows[0]["Exibe_InfoProduto"]);
                Parametro_NFe_NFC_SAT.AliquotaICMS = Convert.ToDouble(_DT.Rows[0]["AliquotaCreditoICMS"]);
                Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS = Convert.ToBoolean(_DT.Rows[0]["Exibe_msgCreditoICMS"]);
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro_Param + ex.Message);
            }
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
                                                  "VALIDADA", "EM PROCESSAMENTO" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoNFeP);
            cb_SituacaoNFeP.SelectedIndex = 0;
        }

        private void Processa_NFe(ProcessoNF _ProcessoNF, string _Justificativa = "")
        {
            try
            {
                NFe_ProcessaNFe3 _ProcessaNFe;

                string[] filesInFolder;

                switch (_ProcessoNF)
                {
                    #region VALIDAR
                    case ProcessoNF.Validar:
                        _ProcessaNFe = new NFe_ProcessaNFe3();

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                            {
                                if (Convert.ToDateTime(dg_NFe.Rows[i].Cells["col_DataEmissaoNFe"].Value).Date != DateTime.Now.Date)
                                {
                                    MessageBox.Show(util_msg.msg_DataEmissaoInvalida, this.Text);
                                    return;
                                }

                                _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));
                                _ProcessaNFe.Processa_NFe(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID"].Value), UTIL.ProcessoNF.Validar);
                            }
                        break;
                    #endregion

                    #region TRANSMITIR
                    case ProcessoNF.Transmitir:
                        _ProcessaNFe = new NFe_ProcessaNFe3();

                        _ProcessaNFe.Carrega_Parametros(Parametro_Empresa.ID_Empresa_Ativa);

                        ConsultaProcesso = true;

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                            {
                                if (Convert.ToDateTime(dg_NFe.Rows[i].Cells["col_DataEmissaoNFe"].Value).Date != DateTime.Now.Date)
                                {
                                    MessageBox.Show(util_msg.msg_DataEmissaoInvalida, this.Text);
                                    return;
                                }

                                if (Parametro_Empresa.ID_Empresa_Ativa != Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value))
                                    _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));

                                if (Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Situacao"].Value) == 7)
                                    break;
                                else
                                    _ProcessaNFe.Processa_NFe(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID"].Value), UTIL.ProcessoNF.Transmitir);
                            }
                        Thread.Sleep(1000);

                        filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_EmProcessamento, "*" + ".xml");

                        if (filesInFolder.Length == 0)
                            ConsultaProcesso = false;

                        foreach (string item in filesInFolder)
                            _ProcessaNFe.Consulta_Recibo(item);
                        break;
                    #endregion

                    #region CANCELAR
                    case ProcessoNF.Cancelar:
                        _ProcessaNFe = new NFe_ProcessaNFe3();

                        int aux = 0;

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                                aux++;

                        if (aux != 1)
                            throw new Exception(util_msg.msg_registroUnico);

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                            {
                                string _Periodo = util_dados.Config_Data(Convert.ToDateTime(dg_NFe.Rows[i].Cells["col_DataEmissaoNFe"].Value), 9).ToString() + "\\";
                                _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));

                                filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*" + NFe_extxml.ProcNFe);
                                foreach (string item in filesInFolder)
                                {
                                    int Serie = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(22, 3));
                                    int ID_NFe = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(25, 9));
                                    if (Serie == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_SerieNFe"].Value) &&
                                        ID_NFe == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_NFe"].Value))
                                    {
                                        _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));
                                        _ProcessaNFe.Cancela_NFe(item, _Justificativa);
                                    }
                                }
                            }
                        break;
                    #endregion

                    #region CARTA DE CORREÇÃO
                    case ProcessoNF.CartaCorrecao:
                        _ProcessaNFe = new NFe_ProcessaNFe3();

                        int aux1 = 0;

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                                aux1++;

                        if (aux1 != 1)
                            throw new Exception(util_msg.msg_registroUnico);

                        for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                            {
                                string _Periodo = util_dados.Config_Data(Convert.ToDateTime(dg_NFe.Rows[i].Cells["col_DataEmissaoNFe"].Value), 9).ToString() + "\\";
                                _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));

                                filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*" + "-procNFe.xml");
                                foreach (string item in filesInFolder)
                                {
                                    int Serie = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(22, 3));
                                    int ID_NFe = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(25, 9));
                                    if (Serie == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_SerieNFe"].Value) &&
                                        ID_NFe == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_NFe"].Value))
                                    {
                                        _ProcessaNFe.Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));
                                        _ProcessaNFe.CartaCorrecao_NFe(item, _Justificativa);
                                    }
                                }
                            }
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _ProcessoNF.ToString());
            }
            finally
            {
                Pesquisa();
            }
        }

        private void Configura_Botao()
        {
            bt_Validar.Enabled = true;
            bt_CartaCorrecao.Enabled = true;
            bt_Cancelar.Enabled = true;
            bt_DANFE.Enabled = true;
            bt_Transmitir.Enabled = true;
            bt_PreDanfe.Enabled = true;
            bt_Email.Enabled = true;
            bt_ArquivoNFe.Enabled = true;

            for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                {
                    switch (Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Situacao"].Value))
                    {
                        case 1: //ASSINADA
                            bt_Validar.Enabled = false;
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_Email.Enabled = false;
                            bt_ArquivoNFe.Enabled = false;
                            break;

                        case 2://AUTORIZADA
                            bt_Validar.Enabled = false;
                            bt_Transmitir.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            break;

                        case 3://CANCELADA
                            bt_Validar.Enabled = false;
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_Transmitir.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            bt_Email.Enabled = false;
                            break;

                        case 4://DENEGADA
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_Transmitir.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            bt_Email.Enabled = false;
                            break;

                        case 5://EM DIGITAÇÃO
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            bt_Email.Enabled = false;
                            bt_ArquivoNFe.Enabled = false;
                            break;

                        case 6://VALIDADA
                            bt_Validar.Enabled = false;
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_Email.Enabled = false;
                            bt_ArquivoNFe.Enabled = false;
                            break;

                        case 7://EM PROCESSAMENTO
                            bt_CartaCorrecao.Enabled = false;
                            bt_Cancelar.Enabled = false;
                            bt_DANFE.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            bt_Email.Enabled = false;
                            bt_ArquivoNFe.Enabled = false;
                            break;

                        case 8://ENVIADO SAT
                            bt_CartaCorrecao.Enabled = false;
                            bt_Transmitir.Enabled = false;
                            bt_Cancelar.Enabled = true;
                            bt_DANFE.Enabled = true;
                            bt_Validar.Enabled = false;
                            bt_PreDanfe.Enabled = false;
                            bt_Email.Enabled = false;
                            break;
                    }
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

            int cont_Registro = 0;

            for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                    cont_Registro = +1;

            if (cont_Registro > 1)
            {
                MessageBox.Show(util_msg.msg_SelecioneRegistroUnico, this.Text);
                return;
            }

            for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                {
                    Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));
                    string _Periodo = util_dados.Config_Data(Convert.ToDateTime(dg_NFe.Rows[i].Cells["col_DataEmissaoNFe"].Value), 9).ToString() + "\\";

                    filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*");

                    foreach (string item in filesInFolder)
                    {
                        Serie = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(22, 3));
                        ID_NFe = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(25, 9));

                        if (Serie == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_SerieNFe"].Value) &&
                            ID_NFe == Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_NFe"].Value))
                        {
                            if (item.IndexOf(NFe_extxml.ProcNFe) != -1)
                                XML = item;

                            Anexo += item + "; ";
                        }
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
            string rpt_Nome = "rpt_SAT_Termica.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
            rpt.Show();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_NF = new BLL_NF();
            NFe = new DTO_NF();

            NFe.ID = Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value);
            NFe.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_NF = BLL_NF.Busca_NF_SAT(NFe);
            DataTable DTR_Item = BLL_NF.Busca_NF_Item(NFe);

            #region PAGAMENTO
            DataTable DTR_Financeiro = new DataTable();
            DTR_Financeiro.Columns.Add("Tipo", typeof(String));
            DTR_Financeiro.Columns.Add("Valor", typeof(Double));

            DataTable _DT = new DataTable();
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = util_dados.Verifica_int(DTR_NF.Rows[0]["ID_Venda"].ToString());

            if (Venda.ID > 0)
            {
                _DT = BLL_Venda.Busca_PagamentoSAT(Venda);

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
            Info_Tributo += util_dados.ConfigNumDecimal(util_dados.Calcula_Campo_DT(DTR_Item, "AliqNacFederal"), 2) + " Federal - R$ ";
            Info_Tributo += util_dados.ConfigNumDecimal(util_dados.Calcula_Campo_DT(DTR_Item, "AliqEstadual"), 2) + " Estadual ";
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

        private void Imprime_Danfe_CC(int _ID_NF, int _ID_Empresa)
        {
            try
            {
                DataTable _DT_NF = new DataTable();
                DataTable _DT_Evento = new DataTable();

                DataTable _DT_Destinatario = new DataTable();

                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
                rpt.Show();

                string rpt_Nome = string.Empty;

                Carrega_Parametros(_ID_Empresa);

                BLL_NF = new BLL_NF();
                NFe = new DTO_NF();

                NFe.ID_Empresa = _ID_Empresa;
                NFe.ID = _ID_NF;

                _DT_NF = BLL_NF.Busca_NF(NFe);

                NFe.FiltraEvento = true;
                NFe.Tipo_Evento = 4;

                _DT_Evento = BLL_NF.Busca_NF_Evento(NFe);

                if (Parametro_NFe_NFC_SAT.AmbienteNFe == 1)
                    rpt_Nome = "rpt_NFe_CC_A4_Ret_P.rdlc";
                else
                    rpt_Nome = "rpt_NFe_CC_A4_Ret_H.rdlc";

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                Pessoa.TipoPessoa = Convert.ToInt32(_DT_NF.Rows[0]["TipoPessoa"]);
                Pessoa.ID = Convert.ToInt32(_DT_NF.Rows[0]["ID_Pessoa"]);

                _DT_Destinatario = BLL_Pessoa.Busca_Completa(Pessoa);

                #region INSCRIÇÃO ESTADUAL DESTINATARIO
                string str_IE = util_dados.Conf_strDoc_NFe(_DT_Destinatario.Rows[0]["IE_RG"].ToString());

                if (str_IE.Trim().Replace("0", "") == string.Empty)
                    str_IE = "ISENTO";

                if (Convert.ToInt32(_DT_Destinatario.Rows[0]["TipoDocumento"]) == 2)
                    str_IE = string.Empty;

                #endregion

                #region TRATAMENTO DE CHAVE
                string Chave = _DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", "");
                string N_Serie = Chave.Substring(25, 9);
                string N_NFe = Chave.Substring(34, 6);
                #endregion

                #region CRIA BARRA
                Image Barra;
                string str_Chave = _DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", ""); ;
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
                string Chave_Tratada = util_dados.Config_ChaveNFe_CFe(_DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", ""));
                #endregion

                ReportDataSource ds_NF = new ReportDataSource("ds_NFe", _DT_NF);
                ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
                ReportDataSource ds_Destinatario = new ReportDataSource("ds_Destinatario", _DT_Destinatario);
                ReportDataSource ds_Evento = new ReportDataSource("ds_Evento", _DT_Evento);

                ReportParameter p1 = new ReportParameter("Barra", str_Barra);
                ReportParameter p2 = new ReportParameter("Chave_Acesso", Chave_Tratada);
                ReportParameter p3 = new ReportParameter("Insc_Estadual_Destinatario", str_IE);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_NF);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Evento);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Destinatario);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

                rpt.rpt_Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Imprime_Danfe()
        {
            try
            {
                DataTable _DT_NF;
                DataTable _DT_Evento;
                DataTable _DT_NF_Duplicata;
                DataTable _DT_NF_Item;
                DataTable _DT_Transportadora;
                DataTable _DT_Volumes;
                DataTable _DT_Ent_Ret;

                DataTable _DT_Fatura_col_1;
                DataTable _DT_Fatura_col_2;
                DataTable _DT_Fatura_col_3;
                DataTable _DT_Fatura_col_4;
                DataTable _DT_Fatura_col_5;

                DataTable _DT_Destinatario;

                UI_Visualiza_Relatorio rpt;

                string rpt_Nome = string.Empty;

                for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_NFe.Rows[i].Cells["col_SelecionaNFe"].Value) == true)
                    {
                        _DT_NF = new DataTable();
                        _DT_Evento = new DataTable();
                        _DT_NF_Duplicata = new DataTable();
                        _DT_NF_Item = new DataTable();
                        _DT_Transportadora = new DataTable();
                        _DT_Volumes = new DataTable();
                        _DT_Ent_Ret = new DataTable();

                        _DT_Fatura_col_1 = new DataTable();
                        _DT_Fatura_col_2 = new DataTable();
                        _DT_Fatura_col_3 = new DataTable();
                        _DT_Fatura_col_4 = new DataTable();
                        _DT_Fatura_col_5 = new DataTable();

                        _DT_Destinatario = new DataTable();

                        Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));

                        BLL_NF = new BLL_NF();
                        NFe = new DTO_NF();

                        NFe.ID_Empresa = Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value);
                        NFe.ID = Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID"].Value);

                        _DT_NF = BLL_NF.Busca_NF(NFe);
                        _DT_Evento = BLL_NF.Busca_NF_Evento(NFe);
                        _DT_NF_Duplicata = BLL_NF.Busca_NF_Duplicata(NFe);
                        _DT_NF_Item = BLL_NF.Busca_NF_Item(NFe);
                        _DT_Transportadora = BLL_NF.Busca_NF_Transp(NFe);
                        _DT_Volumes = BLL_NF.Busca_NF_Volume(NFe);
                        _DT_Ent_Ret = BLL_NF.Busca_NF_Ent_Ret(NFe);

                        //IMPRIMIR NFe GERADAS NO PROCESSO ANTIGO, SOMENTE ABRE O PDF!
                        if (_DT_NF.Rows[0]["Chave"].ToString() == string.Empty)
                        {
                            string _Periodo = util_dados.Config_Data(Convert.ToDateTime(_DT_NF.Rows[0]["DataEmissao"]), 9).ToString() + "\\";

                            string[] filesInFolder = Directory.GetFiles(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "*" + ".pdf");
                            foreach (string item in filesInFolder)
                            {
                                int Serie = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(22, 3));
                                int ID_NFe = Convert.ToInt32(item.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo, "").Substring(25, 9));

                                if (Serie == Convert.ToInt32(_DT_NF.Rows[0]["Serie"]) &&
                                    ID_NFe == Convert.ToInt32(_DT_NF.Rows[0]["ID_NFe"]))
                                    Process.Start(item);
                            }

                            break;
                        }

                        if (Convert.ToInt32(_DT_NF.Rows[0]["Situacao"]) == 2)
                            if (Parametro_NFe_NFC_SAT.AmbienteNFe == 1)
                                rpt_Nome = "rpt_NFe_A4_Ret_P.rdlc";
                            else
                                rpt_Nome = "rpt_NFe_A4_Ret_H.rdlc";

                        if (Convert.ToInt32(_DT_NF.Rows[0]["Situacao"]) == 3)
                            rpt_Nome = "rpt_NFe_Cancelada.rdlc";

                        int _aux_Evento = 0;
                        for (int e = 0; e <= _DT_Evento.Rows.Count - 1; e++)
                            if (Convert.ToInt32(_DT_Evento.Rows[e]["Tipo_Evento"]) == 4)
                                _aux_Evento++;

                        string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

                        rpt = new UI_Visualiza_Relatorio();
                        rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
                        rpt.Show();

                        BLL_Pessoa = new BLL_Pessoa();
                        Pessoa = new DTO_Pessoa();

                        Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                        DataTable _DT_Empresa = new DataTable();
                        _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                        Pessoa.TipoPessoa = Convert.ToInt32(_DT_NF.Rows[0]["TipoPessoa"]);
                        Pessoa.ID = Convert.ToInt32(_DT_NF.Rows[0]["ID_Pessoa"]);

                        _DT_Destinatario = BLL_Pessoa.Busca_Completa(Pessoa);

                        #region INSCRIÇÃO ESTADUAL DESTINATARIO
                        string str_IE = util_dados.Conf_strDoc_NFe(_DT_Destinatario.Rows[0]["IE_RG"].ToString());

                        if (str_IE.Trim().Replace("0", "") == string.Empty)
                            str_IE = "ISENTO";

                        if (Convert.ToInt32(_DT_Destinatario.Rows[0]["TipoDocumento"]) == 2)
                            str_IE = string.Empty;
                        #endregion

                        #region TIPO FRETE
                        string str_Frete = string.Empty;

                        switch (Convert.ToInt32(_DT_NF.Rows[0]["TipoFrete"].ToString()))
                        {
                            case 0:
                                str_Frete = "0-EMITENTE";
                                break;
                            case 1:
                                str_Frete = "1-DESTINAT.";
                                break;
                            case 2:
                                str_Frete = "2-TERCEIROS";
                                break;
                            case 3:
                                str_Frete = "9-SEM FRETE";
                                break;
                        }
                        #endregion

                        #region TRATAMENTO DE CHAVE
                        string Chave = _DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", "");
                        string N_Serie = Chave.Substring(25, 9);
                        string N_NFe = Chave.Substring(34, 6);
                        #endregion

                        #region CRIA BARRA
                        Image Barra;
                        string str_Chave = _DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", ""); ;
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
                        string Chave_Tratada = util_dados.Config_ChaveNFe_CFe(_DT_NF.Rows[0]["Chave"].ToString().Replace("NFe", ""));
                        #endregion

                        #region CONFIGURA FATURA
                        if (_DT_NF_Duplicata.Rows.Count > 0 &&
                            _DT_NF_Duplicata.Rows.Count <= 120)
                        {
                            _DT_Fatura_col_1 = _DT_NF_Duplicata.Clone();
                            _DT_Fatura_col_2 = _DT_NF_Duplicata.Clone();
                            _DT_Fatura_col_3 = _DT_NF_Duplicata.Clone();
                            _DT_Fatura_col_4 = _DT_NF_Duplicata.Clone();
                            _DT_Fatura_col_5 = _DT_NF_Duplicata.Clone();

                            int _Coluna_DT = 1;

                            for (int d = 0; d <= _DT_NF_Duplicata.Rows.Count - 1; d++)
                            {
                                switch (_Coluna_DT)
                                {
                                    case 1:
                                        _DT_Fatura_col_1.Rows.Add();
                                        _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                        _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                        _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                        _Coluna_DT = 2;
                                        break;

                                    case 2:
                                        _DT_Fatura_col_2.Rows.Add();
                                        _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                        _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                        _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                        _Coluna_DT = 3;
                                        break;

                                    case 3:
                                        _DT_Fatura_col_3.Rows.Add();
                                        _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                        _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                        _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                        _Coluna_DT = 4;
                                        break;

                                    case 4:
                                        _DT_Fatura_col_4.Rows.Add();
                                        _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                        _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                        _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                        _Coluna_DT = 5;
                                        break;

                                    case 5:
                                        _DT_Fatura_col_5.Rows.Add();
                                        _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                        _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                        _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                        _Coluna_DT = 1;
                                        break;
                                }
                            }
                        }
                        #endregion

                        #region CONFIGURA TRANSPORTADORA
                        if (_DT_Transportadora.Rows.Count > 0)
                        {
                            _DT_Transportadora.Rows[0]["IE"] = util_dados.Conf_strDoc_NFe(_DT_Transportadora.Rows[0]["IE"].ToString());

                            if (_DT_Transportadora.Rows[0]["IE"].ToString().Trim().Replace("0", "") == string.Empty)
                                _DT_Transportadora.Rows[0]["IE"] = "";

                            if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length != 14 &&
                                _DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length != 11 &&
                                _DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString() != "ISENTO")
                                _DT_Transportadora.Rows[0]["CNPJ_CPF"] = string.Empty;

                            if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length == 14)
                                _DT_Transportadora.Rows[0]["CNPJ_CPF"] = util_dados.Conf_CPF_CNPJ(_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString(), Documento.CNPJ);

                            if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length == 11)
                                _DT_Transportadora.Rows[0]["CNPJ_CPF"] = util_dados.Conf_CPF_CNPJ(_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString(), Documento.CPF);
                        }
                        #endregion

                        #region CONFIGURA VOLUMES
                        string str_Volume_Especie = string.Empty;
                        string str_Volume_Marca = string.Empty;
                        string str_Volume_Numeracao = string.Empty;
                        string str_InfoComplementar_Volume = string.Empty;

                        if (_DT_Volumes.Rows.Count > 0)
                        {
                            if (_DT_Volumes.Rows.Count == 1)
                            {
                                str_Volume_Especie = _DT_Volumes.Rows[0]["Especie"].ToString();
                                str_Volume_Marca = _DT_Volumes.Rows[0]["Marca"].ToString();
                                str_Volume_Numeracao = _DT_Volumes.Rows[0]["Numeracao"].ToString();
                            }
                            else
                            {
                                str_Volume_Especie = "(VER INF. COMPL.)";
                                str_Volume_Marca = "(VER INF. COMPL.)";
                                str_Volume_Numeracao = "(VER INF. COMPL.)";

                                for (int d = 0; d <= _DT_Volumes.Rows.Count - 1; d++)
                                {
                                    str_InfoComplementar_Volume += "*ESP.:" + _DT_Volumes.Rows[d]["Especie"].ToString();
                                    str_InfoComplementar_Volume += "-MARCA.:" + _DT_Volumes.Rows[d]["Marca"].ToString();
                                    str_InfoComplementar_Volume += "-NUM.:" + _DT_Volumes.Rows[d]["Numeracao"].ToString() + Environment.NewLine;
                                }
                            }
                        }
                        #endregion

                        #region TRIBUTOS
                        double _vlr_Tributos = 0;
                        double _vlr_tributos_aux = 0;
                        double _vlr_Credito_ICMS = 0;
                        double Valor_ICMSDestino = 0;
                        double Valor_ICMSRemetente = 0;
                        double Valor_FCPICMS = 0;

                        _DT_NF_Item.Columns.Add("Valor_Tributos", typeof(decimal));

                        for (int y = 0; y <= _DT_NF_Item.Rows.Count - 1; y++)
                        {
                            if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                                _DT_NF_Item.Rows[y]["CST"] = _DT_NF_Item.Rows[y]["CSOSN"];

                            if (Convert.ToInt32(_DT_NF_Item.Rows[y]["CST"]) == 101 ||
                                Convert.ToInt32(_DT_NF_Item.Rows[y]["CST"]) == 201)
                                _vlr_Credito_ICMS += util_dados.Calcula_Porcentagem(Parametro_NFe_NFC_SAT.AliquotaICMS, Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorTotal"]));

                            #region PARTILHA DE ICMS
                            if (_DT_Empresa.Rows[0]["ID_UF"].ToString().Trim() != _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() &&
                                _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != "EX" &&
                                Convert.ToBoolean(_DT_NF.Rows[0]["ConsumidorFinal"]) == true)
                            {
                                double Aliquota_Interestadual = 0;
                                double Aliquota_Interna = 0;
                                double Aliquota_FCP = 0;

                                BLL_Municipio BLL_Municipio = new BLL_Municipio();
                                DTO_Municipio Municipio = new DTO_Municipio();

                                Municipio.Tipo_Consulta = 1;
                                Municipio.ID_UF_Origem = util_dados.Retorna_ID_UF(_DT_Empresa.Rows[0]["ID_UF"].ToString().Trim());
                                Municipio.ID_UF_Destino = util_dados.Retorna_ID_UF(_DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim());

                                DataTable _DT = new DataTable();
                                _DT = BLL_Municipio.Busca_UF_Aliquota_Inter(Municipio);

                                if (_DT.Rows.Count == 1)
                                {
                                    Aliquota_Interestadual = Convert.ToDouble(_DT.Rows[0]["Aliquota_Interestadual"]);
                                    Aliquota_Interna = Convert.ToDouble(_DT.Rows[0]["Aliquota_Interna"]);
                                    Aliquota_FCP = Convert.ToDouble(_DT.Rows[0]["Aliquota_FCP"]);
                                }

                                double _ValorBC_ICMSUF = Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorTotal"]) + Convert.ToDouble(_DT_NF_Item.Rows[y]["Acrescimo"]) + Convert.ToDouble(_DT_NF_Item.Rows[y]["Frete"]);
                                _ValorBC_ICMSUF = _ValorBC_ICMSUF - Convert.ToDouble(_DT_NF_Item.Rows[y]["Desconto"]);
                                _ValorBC_ICMSUF = _ValorBC_ICMSUF + Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorIPI"]);

                                #region ALIQUOTA DE PARTILHA PROVISÓRIA
                                int _Aliquota_Provisoria = 0;

                                if (DateTime.Now.Year == 2016)
                                    _Aliquota_Provisoria = 40;

                                if (DateTime.Now.Year == 2017)
                                    _Aliquota_Provisoria = 60;

                                if (DateTime.Now.Year == 2018)
                                    _Aliquota_Provisoria = 80;

                                if (DateTime.Now.Year >= 2019)
                                    _Aliquota_Provisoria = 100;
                                #endregion

                                Valor_FCPICMS += util_dados.Calcula_Porcentagem(Aliquota_FCP, _ValorBC_ICMSUF);

                                _ValorBC_ICMSUF = util_dados.Calcula_Porcentagem(Aliquota_Interna - Aliquota_Interestadual, _ValorBC_ICMSUF);

                                Valor_ICMSDestino += util_dados.Calcula_Porcentagem(_Aliquota_Provisoria, _ValorBC_ICMSUF);
                                Valor_ICMSRemetente += util_dados.Calcula_Porcentagem(100 - _Aliquota_Provisoria, _ValorBC_ICMSUF);
                                #endregion
                            }

                            if (Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 0 ||
                            Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 3 ||
                            Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 4 ||
                            Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 5)
                            {
                                _vlr_tributos_aux = util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqNacFederal"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                                _vlr_tributos_aux += util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqEstadual"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                                _DT_NF_Item.Rows[y]["Valor_Tributos"] = _vlr_tributos_aux;

                                _vlr_Tributos += _vlr_tributos_aux;
                            }
                            else
                            {
                                _vlr_tributos_aux = util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqImpFederal"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                                _vlr_tributos_aux += util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqEstadual"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                                _DT_NF_Item.Rows[y]["Valor_Tributos"] = _vlr_tributos_aux;

                                _vlr_Tributos += _vlr_tributos_aux;
                            }
                        }

                        _DT_NF_Item.AcceptChanges();
                        #endregion

                        #region INFORMAÇÃO COMPLEMENTAR
                        string _str_Info_Complementar = string.Empty;

                        if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                            _str_Info_Complementar += util_msg.msg_NFe_SimplesNacional;

                        if (Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS == true &&
                                  _vlr_Credito_ICMS > 0)
                            _str_Info_Complementar += util_msg.msg_CreditoICMS.Replace("%CreditoICMS%", util_dados.ConfigNumDecimal(_vlr_Credito_ICMS, 22)).Replace("%Aliquota%", Parametro_NFe_NFC_SAT.AliquotaICMS.ToString());

                        if (_DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != _DT_Empresa.Rows[0]["ID_UF"].ToString().Trim() &&
                            _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != "EX" &&
                            Convert.ToBoolean(_DT_NF.Rows[0]["ConsumidorFinal"]) == true)
                        {
                            _str_Info_Complementar += util_msg.msg_Difal_UF;
                            _str_Info_Complementar = _str_Info_Complementar.Replace("#destino#", util_dados.ConfigNumDecimal(Valor_ICMSDestino, 2));
                            _str_Info_Complementar = _str_Info_Complementar.Replace("#origem#", util_dados.ConfigNumDecimal(Valor_ICMSRemetente, 2));
                            _str_Info_Complementar = _str_Info_Complementar.Replace("#fcp#", util_dados.ConfigNumDecimal(Valor_FCPICMS, 2));
                        }

                        if (str_InfoComplementar_Volume != string.Empty)
                            _str_Info_Complementar += str_InfoComplementar_Volume;

                        if (_DT_NF.Rows[0]["InformacaoAdicional"].ToString() != string.Empty)
                            _str_Info_Complementar += " - " + _DT_NF.Rows[0]["InformacaoAdicional"].ToString();


                        //ENTREGA OU RETIRADA INFORMADA
                        if (_DT_Ent_Ret.Rows.Count > 0)
                        {
                            string _str_Ret_Ent = string.Empty;

                            switch (_DT_Ent_Ret.Rows[0]["Tipo"].ToString())
                            {
                                case "1": //RETIRADA
                                    _str_Ret_Ent += "RETIRADA: ";
                                    break;

                                case "2": //ENTREGA
                                    _str_Ret_Ent += "ENTREGA: ";
                                    break;
                            }

                            _str_Ret_Ent += _DT_Ent_Ret.Rows[0]["Logradouro"].ToString() + ", " + _DT_Ent_Ret.Rows[0]["Numero"].ToString();

                            if (_DT_Ent_Ret.Rows[0]["Complemento"].ToString() != string.Empty)
                                _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Complemento"].ToString();

                            _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Bairro"].ToString();
                            _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Municipio"].ToString() + "-" + _DT_Ent_Ret.Rows[0]["UF"].ToString();

                            _str_Info_Complementar += " - " + _str_Ret_Ent;
                        }
                        #endregion

                        ReportDataSource ds_NF = new ReportDataSource("ds_NFe", _DT_NF);
                        ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
                        ReportDataSource ds_Destinatario = new ReportDataSource("ds_Destinatario", _DT_Destinatario);
                        ReportDataSource ds_Fatura_col_1 = new ReportDataSource("ds_Fatura_col_1", _DT_Fatura_col_1);
                        ReportDataSource ds_Fatura_col_2 = new ReportDataSource("ds_Fatura_col_2", _DT_Fatura_col_2);
                        ReportDataSource ds_Fatura_col_3 = new ReportDataSource("ds_Fatura_col_3", _DT_Fatura_col_3);
                        ReportDataSource ds_Fatura_col_4 = new ReportDataSource("ds_Fatura_col_4", _DT_Fatura_col_4);
                        ReportDataSource ds_Fatura_col_5 = new ReportDataSource("ds_Fatura_col_5", _DT_Fatura_col_5);
                        ReportDataSource ds_Evento = new ReportDataSource("ds_Evento", _DT_Evento);
                        ReportDataSource ds_Transporte = new ReportDataSource("ds_Transportadora", _DT_Transportadora);
                        ReportDataSource ds_Volume = new ReportDataSource("ds_Volume", _DT_Volumes);
                        ReportDataSource ds_Itens = new ReportDataSource("ds_Itens", _DT_NF_Item);

                        ReportParameter p1 = new ReportParameter("Barra", str_Barra);
                        ReportParameter p2 = new ReportParameter("Chave_Acesso", Chave_Tratada);
                        ReportParameter p3 = new ReportParameter("Insc_Estadual_Destinatario", str_IE);
                        ReportParameter p4 = new ReportParameter("Tipo_Frete", str_Frete);
                        ReportParameter p5 = new ReportParameter("Volume_Especie", str_Volume_Especie);
                        ReportParameter p6 = new ReportParameter("Volume_Marca", str_Volume_Marca);
                        ReportParameter p7 = new ReportParameter("Volume_Numeracao", str_Volume_Numeracao);
                        ReportParameter p8 = new ReportParameter("Valor_TotalTributo", util_dados.ConfigNumDecimal(_vlr_Tributos, 2));
                        ReportParameter p9 = new ReportParameter("Info_Complementar", _str_Info_Complementar);
                        ReportParameter p10 = new ReportParameter("Decimal_Produto_Valor", "N" + Parametro_Cadastro.Decimal_Produto_Valor);
                        ReportParameter p11 = new ReportParameter("Decimal_Produto_Quantidade", "N" + Parametro_Cadastro.Decimal_Produto_Quantidade);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_NF);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Evento);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Destinatario);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_1);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_2);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_3);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_4);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_5);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Transporte);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Volume);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Itens);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

                        rpt.rpt_Viewer.RefreshReport();

                        if (_aux_Evento > 0)
                            Imprime_Danfe_CC(Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID"].Value), Convert.ToInt32(dg_NFe.Rows[i].Cells["col_ID_Empresa"].Value));
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Imprime_PreDanfe(int _ID_NF, int _ID_Empresa)
        {
            try
            {
                DataTable _DT_NF = new DataTable();
                DataTable _DT_NF_Duplicata = new DataTable();
                DataTable _DT_NF_Item = new DataTable();
                DataTable _DT_Transportadora = new DataTable();
                DataTable _DT_Volumes = new DataTable();
                DataTable _DT_Ent_Ret = new DataTable();

                DataTable _DT_Fatura_col_1 = new DataTable();
                DataTable _DT_Fatura_col_2 = new DataTable();
                DataTable _DT_Fatura_col_3 = new DataTable();
                DataTable _DT_Fatura_col_4 = new DataTable();
                DataTable _DT_Fatura_col_5 = new DataTable();

                DataTable _DT_Destinatario = new DataTable();

                UI_Visualiza_Relatorio rpt;

                string rpt_Nome = string.Empty;


                Carrega_Parametros(_ID_Empresa);

                BLL_NF = new BLL_NF();
                NFe = new DTO_NF();

                NFe.ID_Empresa = _ID_Empresa;
                NFe.ID = _ID_NF;

                _DT_NF = BLL_NF.Busca_NF(NFe);
                _DT_NF_Duplicata = BLL_NF.Busca_NF_Duplicata(NFe);
                _DT_NF_Item = BLL_NF.Busca_NF_Item(NFe);
                _DT_Transportadora = BLL_NF.Busca_NF_Transp(NFe);
                _DT_Volumes = BLL_NF.Busca_NF_Volume(NFe);
                _DT_Ent_Ret = BLL_NF.Busca_NF_Ent_Ret(NFe);

                rpt_Nome = "rpt_NFe_A4_Ret_PreVisualizar.rdlc";

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

                rpt = new UI_Visualiza_Relatorio();
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
                rpt.Show();

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                Pessoa.TipoPessoa = Convert.ToInt32(_DT_NF.Rows[0]["TipoPessoa"]);
                Pessoa.ID = Convert.ToInt32(_DT_NF.Rows[0]["ID_Pessoa"]);

                _DT_Destinatario = BLL_Pessoa.Busca_Completa(Pessoa);

                #region INSCRIÇÃO ESTADUAL DESTINATARIO
                string str_IE = util_dados.Conf_strDoc_NFe(_DT_Destinatario.Rows[0]["IE_RG"].ToString());

                if (str_IE.Trim().Replace("0", "") == string.Empty)
                    str_IE = "ISENTO";

                if (Convert.ToInt32(_DT_Destinatario.Rows[0]["TipoDocumento"]) == 2)
                    str_IE = string.Empty;
                #endregion

                #region TIPO FRETE
                string str_Frete = string.Empty;

                switch (Convert.ToInt32(_DT_NF.Rows[0]["TipoFrete"].ToString()))
                {
                    case 0:
                        str_Frete = "0-EMITENTE";
                        break;
                    case 1:
                        str_Frete = "1-DESTINAT.";
                        break;
                    case 2:
                        str_Frete = "2-TERCEIROS";
                        break;
                    case 3:
                        str_Frete = "9-SEM FRETE";
                        break;
                }
                #endregion

                #region TRATAMENTO DE CHAVE
                string Chave = string.Empty;
                string N_Serie = _DT_NF.Rows[0]["Serie"].ToString();
                string N_NFe = _DT_NF.Rows[0]["ID_NFe"].ToString();
                #endregion

                #region CONFIGURA FATURA
                if (_DT_NF_Duplicata.Rows.Count > 0 &&
                    _DT_NF_Duplicata.Rows.Count <= 120)
                {
                    _DT_Fatura_col_1 = _DT_NF_Duplicata.Clone();
                    _DT_Fatura_col_2 = _DT_NF_Duplicata.Clone();
                    _DT_Fatura_col_3 = _DT_NF_Duplicata.Clone();
                    _DT_Fatura_col_4 = _DT_NF_Duplicata.Clone();
                    _DT_Fatura_col_5 = _DT_NF_Duplicata.Clone();

                    int _Coluna_DT = 1;

                    for (int d = 0; d <= _DT_NF_Duplicata.Rows.Count - 1; d++)
                    {
                        switch (_Coluna_DT)
                        {
                            case 1:
                                _DT_Fatura_col_1.Rows.Add();
                                _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                _DT_Fatura_col_1.Rows[_DT_Fatura_col_1.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                _Coluna_DT = 2;
                                break;

                            case 2:
                                _DT_Fatura_col_2.Rows.Add();
                                _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                _DT_Fatura_col_2.Rows[_DT_Fatura_col_2.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                _Coluna_DT = 3;
                                break;

                            case 3:
                                _DT_Fatura_col_3.Rows.Add();
                                _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                _DT_Fatura_col_3.Rows[_DT_Fatura_col_3.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                _Coluna_DT = 4;
                                break;

                            case 4:
                                _DT_Fatura_col_4.Rows.Add();
                                _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                _DT_Fatura_col_4.Rows[_DT_Fatura_col_4.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                _Coluna_DT = 5;
                                break;

                            case 5:
                                _DT_Fatura_col_5.Rows.Add();
                                _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["NumeroDuplicata"] = _DT_NF_Duplicata.Rows[d]["NumeroDuplicata"];
                                _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["Vencimento"] = _DT_NF_Duplicata.Rows[d]["Vencimento"];
                                _DT_Fatura_col_5.Rows[_DT_Fatura_col_5.Rows.Count - 1]["Valor"] = _DT_NF_Duplicata.Rows[d]["Valor"];

                                _Coluna_DT = 1;
                                break;
                        }
                    }
                }
                #endregion

                #region CONFIGURA TRANSPORTADORA
                if (_DT_Transportadora.Rows.Count > 0)
                {
                    _DT_Transportadora.Rows[0]["IE"] = util_dados.Conf_strDoc_NFe(_DT_Transportadora.Rows[0]["IE"].ToString());

                    if (_DT_Transportadora.Rows[0]["IE"].ToString().Trim().Replace("0", "") == string.Empty)
                        _DT_Transportadora.Rows[0]["IE"] = "";

                    if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length != 14 &&
                        _DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length != 11 &&
                        _DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString() != "ISENTO")
                        _DT_Transportadora.Rows[0]["CNPJ_CPF"] = string.Empty;

                    if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length == 14)
                        _DT_Transportadora.Rows[0]["CNPJ_CPF"] = util_dados.Conf_CPF_CNPJ(_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString(), Documento.CNPJ);

                    if (_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString().Length == 11)
                        _DT_Transportadora.Rows[0]["CNPJ_CPF"] = util_dados.Conf_CPF_CNPJ(_DT_Transportadora.Rows[0]["CNPJ_CPF"].ToString(), Documento.CPF);
                }
                #endregion

                #region CONFIGURA VOLUMES
                string str_Volume_Especie = string.Empty;
                string str_Volume_Marca = string.Empty;
                string str_Volume_Numeracao = string.Empty;
                string str_InfoComplementar_Volume = string.Empty;

                if (_DT_Volumes.Rows.Count > 0)
                {
                    if (_DT_Volumes.Rows.Count == 1)
                    {
                        str_Volume_Especie = _DT_Volumes.Rows[0]["Especie"].ToString();
                        str_Volume_Marca = _DT_Volumes.Rows[0]["Marca"].ToString();
                        str_Volume_Numeracao = _DT_Volumes.Rows[0]["Numeracao"].ToString();
                    }
                    else
                    {
                        str_Volume_Especie = "(VER INF. COMPL.)";
                        str_Volume_Marca = "(VER INF. COMPL.)";
                        str_Volume_Numeracao = "(VER INF. COMPL.)";

                        for (int d = 0; d <= _DT_Volumes.Rows.Count - 1; d++)
                        {
                            str_InfoComplementar_Volume += "*ESP.:" + _DT_Volumes.Rows[d]["Especie"].ToString();
                            str_InfoComplementar_Volume += "-MARCA.:" + _DT_Volumes.Rows[d]["Marca"].ToString();
                            str_InfoComplementar_Volume += "-NUM.:" + _DT_Volumes.Rows[d]["Numeracao"].ToString() + Environment.NewLine;
                        }
                    }
                }
                #endregion

                #region TRIBUTOS
                double _vlr_Tributos = 0;
                double _vlr_tributos_aux = 0;
                double _vlr_Credito_ICMS = 0;
                double Valor_ICMSDestino = 0;
                double Valor_ICMSRemetente = 0;
                double Valor_FCPICMS = 0;

                _DT_NF_Item.Columns.Add("Valor_Tributos", typeof(decimal));

                for (int y = 0; y <= _DT_NF_Item.Rows.Count - 1; y++)
                {
                    if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                        _DT_NF_Item.Rows[y]["CST"] = _DT_NF_Item.Rows[y]["CSOSN"];

                    if (Convert.ToInt32(_DT_NF_Item.Rows[y]["CST"]) == 101 ||
                        Convert.ToInt32(_DT_NF_Item.Rows[y]["CST"]) == 201)
                        _vlr_Credito_ICMS += Convert.ToDouble(Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorCredito"]));

                    #region PARTILHA DE ICMS
                    if (_DT_Empresa.Rows[0]["ID_UF"].ToString().Trim() != _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() &&
                        _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != "EX" &&
                        Convert.ToBoolean(_DT_NF.Rows[0]["ConsumidorFinal"]) == true)
                    {
                        double Aliquota_Interestadual = 0;
                        double Aliquota_Interna = 0;
                        double Aliquota_FCP = 0;

                        BLL_Municipio BLL_Municipio = new BLL_Municipio();
                        DTO_Municipio Municipio = new DTO_Municipio();

                        Municipio.Tipo_Consulta = 1;
                        Municipio.ID_UF_Origem = util_dados.Retorna_ID_UF(_DT_Empresa.Rows[0]["ID_UF"].ToString().Trim());
                        Municipio.ID_UF_Destino = util_dados.Retorna_ID_UF(_DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim());

                        DataTable _DT = new DataTable();
                        _DT = BLL_Municipio.Busca_UF_Aliquota_Inter(Municipio);

                        if (_DT.Rows.Count == 1)
                        {
                            Aliquota_Interestadual = Convert.ToDouble(_DT.Rows[0]["Aliquota_Interestadual"]);
                            Aliquota_Interna = Convert.ToDouble(_DT.Rows[0]["Aliquota_Interna"]);
                            Aliquota_FCP = Convert.ToDouble(_DT.Rows[0]["Aliquota_FCP"]);
                        }
                        
                        double _ValorBC_ICMSUF = Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorTotal"]) + Convert.ToDouble(_DT_NF_Item.Rows[y]["Acrescimo"]) + Convert.ToDouble(_DT_NF_Item.Rows[y]["Frete"]);
                        _ValorBC_ICMSUF = _ValorBC_ICMSUF - Convert.ToDouble(_DT_NF_Item.Rows[y]["Desconto"]);
                        _ValorBC_ICMSUF = _ValorBC_ICMSUF + Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorIPI"]);

                        #region ALIQUOTA DE PARTILHA PROVISÓRIA
                        int _Aliquota_Provisoria = 0;

                        if (DateTime.Now.Year == 2016)
                            _Aliquota_Provisoria = 40;

                        if (DateTime.Now.Year == 2017)
                            _Aliquota_Provisoria = 60;

                        if (DateTime.Now.Year == 2018)
                            _Aliquota_Provisoria = 80;

                        if (DateTime.Now.Year >= 2019)
                            _Aliquota_Provisoria = 100;
                        #endregion

                        Valor_FCPICMS += util_dados.Calcula_Porcentagem(Aliquota_FCP, _ValorBC_ICMSUF);

                        _ValorBC_ICMSUF = util_dados.Calcula_Porcentagem(Aliquota_Interna - Aliquota_Interestadual, _ValorBC_ICMSUF);

                        Valor_ICMSDestino += util_dados.Calcula_Porcentagem(_Aliquota_Provisoria, _ValorBC_ICMSUF);
                        Valor_ICMSRemetente += util_dados.Calcula_Porcentagem(100 - _Aliquota_Provisoria, _ValorBC_ICMSUF);
                    }
                    #endregion

                    if (Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 0 ||
                    Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 3 ||
                    Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 4 ||
                    Convert.ToInt32(_DT_NF_Item.Rows[y]["Origem"]) == 5)
                    {
                        _vlr_tributos_aux = util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqNacFederal"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                        _vlr_tributos_aux += util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqEstadual"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                        _DT_NF_Item.Rows[y]["Valor_Tributos"] = _vlr_tributos_aux;

                        _vlr_Tributos += _vlr_tributos_aux;
                    }
                    else
                    {
                        _vlr_tributos_aux = util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqImpFederal"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                        _vlr_tributos_aux += util_dados.Calcula_Porcentagem(Convert.ToDouble(_DT_NF_Item.Rows[y]["AliqEstadual"]), (Convert.ToDouble(_DT_NF_Item.Rows[y]["Quantidade"]) * Convert.ToDouble(_DT_NF_Item.Rows[y]["ValorUnitario"])));
                        _DT_NF_Item.Rows[y]["Valor_Tributos"] = _vlr_tributos_aux;

                        _vlr_Tributos += _vlr_tributos_aux;
                    }

                    if (Parametro_NFe_NFC_SAT.Exibe_InfoProd == true &&
                        _DT_NF_Item.Rows[y]["InformacaoAdicional"].ToString().Trim() != string.Empty)
                        _DT_NF_Item.Rows[y]["DescricaoProduto"] = _DT_NF_Item.Rows[y]["DescricaoProduto"].ToString() + " " + _DT_NF_Item.Rows[y]["InformacaoAdicional"].ToString();
                }

                _DT_NF_Item.AcceptChanges();
                #endregion

                #region INFORMAÇÃO COMPLEMENTAR
                string _str_Info_Complementar = string.Empty;

                if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                    _str_Info_Complementar += util_msg.msg_NFe_SimplesNacional;

                if (Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS == true &&
                    _vlr_Credito_ICMS > 0)
                    _str_Info_Complementar += util_msg.msg_CreditoICMS.Replace("%CreditoICMS%", util_dados.ConfigNumDecimal(_vlr_Credito_ICMS, 22)).Replace("%Aliquota%", Parametro_NFe_NFC_SAT.AliquotaICMS.ToString());

                if (_DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != _DT_Empresa.Rows[0]["ID_UF"].ToString().Trim() &&
                    _DT_Destinatario.Rows[0]["ID_UF"].ToString().Trim() != "EX" &&
                    Convert.ToBoolean(_DT_NF.Rows[0]["ConsumidorFinal"]) == true)
                {
                    _str_Info_Complementar += util_msg.msg_Difal_UF;
                    _str_Info_Complementar = _str_Info_Complementar.Replace("#destino#", util_dados.ConfigNumDecimal(Valor_ICMSDestino, 2));
                    _str_Info_Complementar = _str_Info_Complementar.Replace("#origem#", util_dados.ConfigNumDecimal(Valor_ICMSRemetente, 2));
                    _str_Info_Complementar = _str_Info_Complementar.Replace("#fcp#", util_dados.ConfigNumDecimal(Valor_FCPICMS, 2));
                }

                if (str_InfoComplementar_Volume != string.Empty)
                    _str_Info_Complementar += str_InfoComplementar_Volume;

                if (_DT_NF.Rows[0]["InformacaoAdicional"].ToString() != string.Empty)
                    _str_Info_Complementar += " - " + _DT_NF.Rows[0]["InformacaoAdicional"].ToString();


                //ENTREGA OU RETIRADA INFORMADA
                if (_DT_Ent_Ret.Rows.Count > 0)
                {
                    string _str_Ret_Ent = string.Empty;

                    switch (_DT_Ent_Ret.Rows[0]["Tipo"].ToString())
                    {
                        case "1": //RETIRADA
                            _str_Ret_Ent += "RETIRADA: ";
                            break;

                        case "2": //ENTREGA
                            _str_Ret_Ent += "ENTREGA: ";
                            break;
                    }

                    _str_Ret_Ent += _DT_Ent_Ret.Rows[0]["Logradouro"].ToString() + ", " + _DT_Ent_Ret.Rows[0]["Numero"].ToString();

                    if (_DT_Ent_Ret.Rows[0]["Complemento"].ToString() != string.Empty)
                        _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Complemento"].ToString();

                    _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Bairro"].ToString();
                    _str_Ret_Ent += " - " + _DT_Ent_Ret.Rows[0]["Municipio"].ToString() + "-" + _DT_Ent_Ret.Rows[0]["UF"].ToString();

                    _str_Info_Complementar += " - " + _str_Ret_Ent;
                }
                #endregion

                ReportDataSource ds_NF = new ReportDataSource("ds_NFe", _DT_NF);
                ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
                ReportDataSource ds_Destinatario = new ReportDataSource("ds_Destinatario", _DT_Destinatario);
                ReportDataSource ds_Fatura_col_1 = new ReportDataSource("ds_Fatura_col_1", _DT_Fatura_col_1);
                ReportDataSource ds_Fatura_col_2 = new ReportDataSource("ds_Fatura_col_2", _DT_Fatura_col_2);
                ReportDataSource ds_Fatura_col_3 = new ReportDataSource("ds_Fatura_col_3", _DT_Fatura_col_3);
                ReportDataSource ds_Fatura_col_4 = new ReportDataSource("ds_Fatura_col_4", _DT_Fatura_col_4);
                ReportDataSource ds_Fatura_col_5 = new ReportDataSource("ds_Fatura_col_5", _DT_Fatura_col_5);
                ReportDataSource ds_Transporte = new ReportDataSource("ds_Transportadora", _DT_Transportadora);
                ReportDataSource ds_Volume = new ReportDataSource("ds_Volume", _DT_Volumes);
                ReportDataSource ds_Itens = new ReportDataSource("ds_Itens", _DT_NF_Item);

                ReportParameter p1 = new ReportParameter("Insc_Estadual_Destinatario", str_IE);
                ReportParameter p2 = new ReportParameter("Tipo_Frete", str_Frete);
                ReportParameter p3 = new ReportParameter("Volume_Especie", str_Volume_Especie);
                ReportParameter p4 = new ReportParameter("Volume_Marca", str_Volume_Marca);
                ReportParameter p5 = new ReportParameter("Volume_Numeracao", str_Volume_Numeracao);
                ReportParameter p6 = new ReportParameter("Valor_TotalTributo", util_dados.ConfigNumDecimal(_vlr_Tributos, 2));
                ReportParameter p7 = new ReportParameter("Info_Complementar", _str_Info_Complementar);
                ReportParameter p8 = new ReportParameter("Decimal_Produto_Valor", "N" + Parametro_Cadastro.Decimal_Produto_Valor);
                ReportParameter p9 = new ReportParameter("Decimal_Produto_Quantidade", "N" + Parametro_Cadastro.Decimal_Produto_Quantidade);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_NF);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Destinatario);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_1);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_2);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_3);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_4);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fatura_col_5);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Transporte);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Volume);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Itens);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 });

                rpt.rpt_Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            dg_NFe.DataSource = null;

            BLL_NF = new BLL_NF();
            NFe = new DTO_NF();

            NFe.Consulta_Emissao.Filtra = true;
            NFe.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            NFe.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            NFe.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            NFe.Serie = util_dados.Verifica_int(txt_Serie.Text);
            NFe.ID_NFe = util_dados.Verifica_int(txt_ID_NFeP.Text);
            NFe.Situacao = Convert.ToInt32(cb_SituacaoNFeP.SelectedValue);
            NFe.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
            NFe.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            NFe.Modelo = 55;

            DT = BLL_NF.Busca_NF(NFe);

            dg_NFe.DataSource = DT;
            util_dados.CarregaCampo(this, DT, gb_Evento);

            if (Parametro_Sistema.Terminal_NFe == true &&
                ConsultaProcesso == true)
            {
                Processa_NFe(ProcessoNF.Transmitir);
                txt_status.Clear();
            }
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
        private void dg_NFe_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)Sistema.UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)Sistema.UI.Properties.Resources._unchecked;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - imgChecked.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - imgChecked.Height) / 2) - 1;

                    if (Seleciona)
                        e.Graphics.DrawImage(imgChecked, X, Y);
                    else
                        e.Graphics.DrawImage(imgUnchecked, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }
        }

        private void dg_NFe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_NFe.Rows.Count - 1; i++)
                    dg_NFe.Rows[i].Cells[0].Value = Seleciona;
            }

        }

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
                        case "ENVIADO VIA SAT":
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
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            txt_status.Text = "AGUARDE, ENVIANDO NF-e...";

            Processa_NFe(ProcessoNF.Transmitir);
            txt_status.Clear();
        }

        private void bt_DANFE_Click(object sender, EventArgs e)
        {
            txt_status.Text = "VERIFICANDO...";

            Imprime_Danfe();

            txt_status.Clear();
        }

        private void bt_PreDanfe_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            Imprime_PreDanfe(Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID"].Value), Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Empresa"].Value));
        }

        private void bt_Validar_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            txt_status.Text = "AGUARDE, VALIDANDO NF-e...";
            Processa_NFe(ProcessoNF.Validar);
            txt_status.Clear();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            try
            {
                UI_NFe_Canc UI_NFe_Canc = new UI_NFe_Canc();
                UI_NFe_Canc.ShowDialog();
                string Just = UI_NFe_Canc.Justificativa;

                if (Just != string.Empty)
                {
                    txt_status.Text = "AGUARDE, REGISTRANDO EVENTO...";
                    Processa_NFe(ProcessoNF.Cancelar, Just);
                    txt_status.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

        }

        private void bt_CartaCorrecao_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            UI_NFe_CCe UI_NFe_CCe = new UI_NFe_CCe();
            UI_NFe_CCe.ShowDialog();
            string Just = UI_NFe_CCe.Justificativa;

            if (Just != string.Empty)
            {
                txt_status.Text = "AGUARDE, REGISTRANDO EVENTO...";
                Processa_NFe(ProcessoNF.CartaCorrecao, Just);
                txt_status.Clear();
            }
        }

        private void bt_Email_Click(object sender, EventArgs e)
        {
            if (Parametro_Sistema.Terminal_NFe == false)
            {
                MessageBox.Show(util_msg.msg_TerminalNaoEmissorNFe, this.Text);
                return;
            }

            Envia_Email();
        }

        private void bt_ArquivoNFe_Click(object sender, EventArgs e)
        {
            Carrega_Parametros(Convert.ToInt32(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_ID_Empresa"].Value));

            string _Periodo = util_dados.Config_Data(Convert.ToDateTime(dg_NFe.Rows[dg_NFe.CurrentRow.Index].Cells["col_DataEmissaoNFe"].Value), 9).ToString() + "\\";

            Process.Start("Explorer", Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Autorizado + _Periodo);
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
            NFe = new DTO_NF();

            NFe.ID = Convert.ToInt32(txt_ID_NF.Text);
            NFe.FiltraEvento = true;

            DT = BLL_NF.Busca_NF_Evento(NFe);

            dg_Evento.DataSource = DT;
        }
        #endregion     
    }
}

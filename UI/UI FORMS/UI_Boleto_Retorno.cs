using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.IO;

namespace Sistema.UI
{
    public partial class UI_Boleto_Retorno : Sistema.UI.UI_Modelo
    {
        public UI_Boleto_Retorno()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Cedente BLL_Cedente;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_Boleto BLL_Boleto;
        #endregion

        #region ESTRUTURA
        DTO_Cedente Cedente;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
        DTO_Boleto Boleto;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTBoletoControle;

        DataRow DR;

        bool Seleciona = false;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "COBRANÇA BANCÁRIA - RETORNO";

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;

            tabctl.TabPages.Remove(TabPage2);

            tabctl.SelectedTab = TabPage1;
        }

        private void Tratar_Retorno()
        {
            try
            {
                if (dg_BoletoRetorno.Rows.Count == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                    return;
                }

                int[] IDConta = null;
                int ID_FluxoCaixa;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaBaixaBoleto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                for (int i = 0; i <= dg_BoletoRetorno.Rows.Count - 1; i++)
                {
                    BLL_Boleto = new BLL_Boleto();
                    BLL_FluxoCaixa = new BLL_FluxoCaixa();
                    BLL_Cedente = new BLL_Cedente();
                    BLL_CReceber = new BLL_CReceber();

                    Cedente = new DTO_Cedente();
                    FluxoCaixa = new DTO_FluxoCaixa();
                    CReceber = new DTO_CReceber();
                    Boleto = new DTO_Boleto();

                    Cedente.ID = Convert.ToInt32(dg_BoletoRetorno.Rows[i].Cells["col_ret_Cedente"].Value);
                    Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    DataTable _DT = new DataTable();
                    _DT = BLL_Cedente.Busca(Cedente);

                    if (_DT.Rows.Count > 0)
                        DR = _DT.Rows[0];

                    if (dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value.ToString().Trim() != string.Empty)
                    {
                        int ID_Boleto = Convert.ToInt32(dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value);

                        Boleto.ID = ID_Boleto;
                        Boleto.Desconto = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value);
                        Boleto.Acrescimo = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value);
                        Boleto.DataBaixa = Convert.ToDateTime(dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value);
                        Boleto.Liquidado = true;
                        Boleto.Cancelado = false;
                        Boleto.Movimento_Remessa = 0;
                        Boleto.Remessa = true;

                        BLL_Boleto.Baixa(Boleto);

                        FluxoCaixa.ID = 0;
                        FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        FluxoCaixa.Emissao = Convert.ToDateTime(dg_BoletoRetorno.Rows[i].Cells["col_DataCredito"].Value);
                        FluxoCaixa.Caixa = Convert.ToInt32(DR["ID_Caixa"]);
                        FluxoCaixa.Documento = dg_BoletoRetorno.Rows[i].Cells["col_ret_Documento"].Value.ToString();
                        FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_CobrancaBancaria;
                        FluxoCaixa.Credito = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_ValorPago"].Value);
                        FluxoCaixa.Debito = 0;
                        FluxoCaixa.Informacao = util_msg.msg_LancaBoleto + dg_BoletoRetorno.Rows[i].Cells["col_ret_NossoNumero"].Value.ToString();
                        FluxoCaixa.ID_Cheque = 0;
                        FluxoCaixa.Conciliado = true;
                        FluxoCaixa.ID_Pagamento = Parametro_Financeiro.ID_PagtoBoleto;
                        FluxoCaixa.Planejamento = false;

                        ID_FluxoCaixa = BLL_FluxoCaixa.Grava(FluxoCaixa);

                        DTBoletoControle = BLL_Boleto.Busca_Controle(Boleto);

                        #region GRAVA TARIFA DE BOLETO
                        FluxoCaixa.ID = 0;
                        FluxoCaixa.Documento = "";
                        FluxoCaixa.ID_Conta = Convert.ToInt32(DR["ID_Conta"]);
                        FluxoCaixa.Credito = 0;
                        FluxoCaixa.Debito = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value);
                        FluxoCaixa.Informacao = util_msg.msg_LancaTarifaBoleto;
                        FluxoCaixa.Conciliado = true;

                        BLL_FluxoCaixa.Grava(FluxoCaixa);
                        #endregion

                        #region BAIXA CONTA
                        if (DTBoletoControle.Rows.Count > 0)
                        {
                            IDConta = new int[DTBoletoControle.Rows.Count];
                            for (int x = 0; x <= DTBoletoControle.Rows.Count - 1; x++)
                            {
                                DR = DTBoletoControle.Rows[x];
                                IDConta[x] = Convert.ToInt32(DR["ID_Conta"]);
                                CReceber.ID = Convert.ToInt32(DR["ID_Conta"]);
                                CReceber.Situacao = 2;
                                CReceber.DataBaixa = Convert.ToDateTime(dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value);

                                if (x == 0)
                                {
                                    CReceber.Desconto = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value);
                                    CReceber.Acrescimo = Convert.ToDouble(dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value);
                                }
                                else
                                {
                                    CReceber.Desconto = 0;
                                    CReceber.Acrescimo = 0;
                                }
                                CReceber.Altera_Registro = 6;

                                BLL_CReceber.Altera(CReceber);
                            }
                        }
                        #endregion

                        #region GRAVA CONTROLE
                        BLL_FluxoCaixa = new BLL_FluxoCaixa();
                        FluxoCaixa = new DTO_FluxoCaixa();

                        for (int x = 0; x <= IDConta.Length - 1; x++)
                        {
                            FluxoCaixa.ID = ID_FluxoCaixa;
                            FluxoCaixa.ID_CPagar = 0;
                            FluxoCaixa.ID_CReceber = IDConta[x];

                            BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                        }
                        #endregion
                    }
                }

                MessageBox.Show(util_msg.msg_Baixa, this.Text);

                dg_BoletoRetorno.Rows.Clear();

                string mensagem;

                List<string> mensagemLinha = new List<string>();

                using (StreamReader texto = new StreamReader(@txt_Caminho.Text))
                {
                    while ((mensagem = texto.ReadLine()) != null)
                        mensagemLinha.Add(mensagem);
                }

                StreamWriter sw = new StreamWriter(@txt_Caminho.Text);

                for (int i = 0; i < mensagemLinha.Count; i++)
                    if (i == 0)
                    {
                        if (mensagemLinha[i].Length == 240)
                        {
                            //SANTANDER 033
                            if (mensagemLinha[i].Substring(0, 3) == "353" || mensagemLinha[i].Substring(0, 3) == "008" || mensagemLinha[i].Substring(0, 3) == "033")
                                sw.WriteLine(mensagemLinha[i].Substring(0, 7) + "2" + mensagemLinha[i].Substring(8, mensagemLinha[i].Length - 8));
                        }
                        if (mensagemLinha[i].Length == 400)
                        {
                            //SICOOB 756
                            if (mensagemLinha[i].Substring(76, 3) == "756")
                                sw.WriteLine("2" + mensagemLinha[i].Substring(1, mensagemLinha[i].Length - 1));

                            //BRADESCO 237
                            if (mensagemLinha[i].Substring(76, 3) == "237")
                                sw.WriteLine("2" + mensagemLinha[i].Substring(1, mensagemLinha[i].Length - 1));
                        }
                    }
                    else
                        sw.WriteLine(mensagemLinha[i]);

                sw.Flush();
                sw.Close();

                txt_Caminho.Clear();
                lb_TotalRegistro.Text = "Total de Registro: ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
            }
        }

        private void LerRetorno()
        {
            try
            {
                Pesquisa_Retorno.FileName = "";
                Pesquisa_Retorno.Title = "Selecione um Arquivo de Retorno";
                Pesquisa_Retorno.Filter = "Todos Arquivos (*.*)|*.*";
                if (Pesquisa_Retorno.ShowDialog() == DialogResult.OK)
                {
                    if (Pesquisa_Retorno.CheckFileExists == true)
                    {
                        txt_Caminho.Text = Pesquisa_Retorno.FileName;
                        string Linha = "";
                        using (StreamReader Ler = new StreamReader(txt_Caminho.Text, System.Text.Encoding.UTF8))
                        {
                            Linha = Ler.ReadLine();
                        }

                        #region VERIFICA TIPO DE ARQUIVO RETORNO RETORNO
                        bool _Retorno_Configurado = false;

                        if (Linha.Length == 240)
                        {
                            if (Linha.Substring(0, 3) == "353" || //SANTANDER
                                Linha.Substring(0, 3) == "008" || //SANTANDER
                                Linha.Substring(0, 3) == "033" || //SANTANDER
                                Linha.Substring(0, 3) == "104") //CAIXA
                                _Retorno_Configurado = true;
                        }

                        if (Linha.Length == 400)
                        {
                            if (Linha.Substring(76, 3) == "756" || //SICOOB
                                Linha.Substring(76, 3) == "237") //BRADESCO
                                _Retorno_Configurado = true;
                        }

                        if (_Retorno_Configurado == false)
                        {
                            MessageBox.Show(util_msg.msg_BoletoRetornoNaoConfig, this.Text);
                            return;
                        }
                        #endregion

                        #region RETORNO CNAB240
                        if (Linha.Length == 240)
                        {
                            #region RETORNO SANTANDER 240
                            if (Linha.Substring(0, 3) == "353" || Linha.Substring(0, 3) == "008" || Linha.Substring(0, 3) == "033")
                            {
                                DTO_Retorno_Santander240 Retorno_Santander240 = new DTO_Retorno_Santander240();
                                Retorno Retorno = new Retorno();
                                Retorno_Santander240 = Retorno.Retorno_Santander240(Pesquisa_Retorno.OpenFile());

                                if (Retorno_Santander240.Header_Arq.Tratado == true)
                                {
                                    MessageBox.Show("Arquivo já Processado!");
                                    return;
                                }

                                if (Retorno_Santander240.Seg_T.Count == 0)
                                {
                                    MessageBox.Show("Arquivo não processado!");
                                    return;
                                }
                                BLL_Boleto = new BLL_Boleto();
                                Boleto = new DTO_Boleto();

                                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                                for (int i = 0; i <= Retorno_Santander240.Seg_T.Count - 1; i++)
                                {
                                    Boleto.List_ID += Convert.ToInt32(Retorno_Santander240.Seg_T[i].NossoNumero.Substring(4, 8)).ToString();
                                    if (i != Retorno_Santander240.Seg_T.Count - 1)
                                        Boleto.List_ID += ", ";
                                }

                                Boleto.Filtra_Liquidado = true;
                                Boleto.Liquidado = false;

                                DataTable _DT = new DataTable();

                                _DT = BLL_Boleto.Busca(Boleto);
                                Carrega_Retorno_Santander240(_DT, Retorno_Santander240);
                            }
                            #endregion

                            #region RETORNO CAIXA 240
                            if (Linha.Substring(0, 3) == "104")
                            {
                                DTO_Retorno_Caixa240 Retorno_Caixa240 = new DTO_Retorno_Caixa240();
                                Retorno Retorno = new Retorno();
                                Retorno_Caixa240 = Retorno.Retorno_Caixa240(Pesquisa_Retorno.OpenFile());

                                if (Retorno_Caixa240.Header_Arq.Tratado == true)
                                {
                                    MessageBox.Show("Arquivo já Processado!");
                                    return;
                                }

                                if (Retorno_Caixa240.Seg_T.Count == 0)
                                {
                                    MessageBox.Show("Arquivo não processado!");
                                    return;
                                }
                                BLL_Boleto = new BLL_Boleto();
                                Boleto = new DTO_Boleto();

                                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                                for (int i = 0; i <= Retorno_Caixa240.Seg_T.Count - 1; i++)
                                {
                                    Boleto.List_ID += Convert.ToInt32(Retorno_Caixa240.Seg_T[i].NossoNumero.Substring(4, 8)).ToString();
                                    if (i != Retorno_Caixa240.Seg_T.Count - 1)
                                        Boleto.List_ID += ", ";
                                }

                                Boleto.Filtra_Liquidado = true;
                                Boleto.Liquidado = false;

                                DataTable _DT = new DataTable();

                                _DT = BLL_Boleto.Busca(Boleto);
                                Carrega_Retorno_Caixa240(_DT, Retorno_Caixa240);
                            }
                            #endregion
                        }
                        #endregion

                        #region RETORNO CNAB400
                        if (Linha.Length == 400)
                        {
                            #region RETORNO SICOOB 400
                            if (Linha.Substring(76, 3) == "756")
                            {
                                DTO_Retorno_Sicoob400 Retorno_Sicoob400 = new DTO_Retorno_Sicoob400();
                                Retorno Retorno = new Retorno();
                                Retorno_Sicoob400 = Retorno.Retorno_Sicoob400(Pesquisa_Retorno.OpenFile());

                                if (Retorno_Sicoob400.Header.Tratado == true)
                                {
                                    MessageBox.Show("Arquivo já Processado!");
                                    return;
                                }

                                if (Retorno_Sicoob400.Detalhe.Count == 0)
                                {
                                    MessageBox.Show("Arquivo não processado!");
                                    return;
                                }

                                BLL_Boleto = new BLL_Boleto();
                                Boleto = new DTO_Boleto();

                                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                                for (int i = 0; i <= Retorno_Sicoob400.Detalhe.Count - 1; i++)
                                {
                                    Boleto.List_ID += Convert.ToInt32(Retorno_Sicoob400.Detalhe[i].NossoNumero.Substring(6, 5)).ToString();
                                    if (i != Retorno_Sicoob400.Detalhe.Count - 1)
                                        Boleto.List_ID += ", ";
                                }

                                Boleto.Filtra_Liquidado = true;
                                Boleto.Liquidado = false;

                                DataTable _DT = new DataTable();

                                _DT = BLL_Boleto.Busca(Boleto);
                                Carrega_Retorno_Sicoob400(_DT, Retorno_Sicoob400);
                            }
                            #endregion

                            #region RETORNO BRADESCO 400
                            if (Linha.Substring(76, 3) == "237")
                            {
                                DTO_Retorno_Bradesco400 Retorno_Bradesco400 = new DTO_Retorno_Bradesco400();
                                Retorno Retorno = new Retorno();
                                Retorno_Bradesco400 = Retorno.Retorno_Bradesco400(Pesquisa_Retorno.OpenFile());

                                if (Retorno_Bradesco400.Header.Tratado == true)
                                {
                                    MessageBox.Show("Arquivo já Processado!");
                                    return;
                                }

                                if (Retorno_Bradesco400.Detalhe.Count == 0)
                                {
                                    MessageBox.Show("Arquivo não processado!");
                                    return;
                                }

                                BLL_Boleto = new BLL_Boleto();
                                Boleto = new DTO_Boleto();

                                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                                for (int i = 0; i <= Retorno_Bradesco400.Detalhe.Count - 1; i++)
                                {
                                    Boleto.List_ID += Convert.ToInt32(Retorno_Bradesco400.Detalhe[i].NossoNumero.Substring(2)).ToString();
                                    if (i != Retorno_Bradesco400.Detalhe.Count - 1)
                                        Boleto.List_ID += ", ";
                                }

                                Boleto.Filtra_Liquidado = true;
                                Boleto.Liquidado = false;

                                DataTable _DT = new DataTable();

                                _DT = BLL_Boleto.Busca(Boleto);
                                Carrega_Retorno_Bradesco400(_DT, Retorno_Bradesco400);
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                MessageBox.Show("Arquivo aberto com sucesso!", this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir arquivo de retorno.");
            }
        }

        private void Carrega_Retorno_Santander240(DataTable _DT, DTO_Retorno_Santander240 _Retorno)
        {
            int aux = 0;

            dg_BoletoRetorno.Rows.Clear();

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DR = _DT.Rows[i];
                    aux = 0;
                    foreach (var x in _Retorno.Seg_T)
                    {
                        if (x.NossoNumero.ToString().Substring(0, 12) == DR["NossoNumero"].ToString())
                            break;
                        aux++;
                    }
                    dg_BoletoRetorno.Rows.Add();
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pessoa"].Value = DR["DescricaoPessoa"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Emissao"].Value = DR["Emissao"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_NossoNumero"].Value = util_dados.Santander_NossoNumero(_Retorno.Seg_T[aux].NossoNumero.ToString().Substring(0, 12));
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Vencimento"].Value = DR["Vencimento"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value = _Retorno.Seg_U[aux].Data_Efetivacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_DataCredito"].Value = _Retorno.Seg_U[aux].Data_Efetivacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Valor"].Value = DR["Valor"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value = DR["ID"];

                    if (Convert.ToDouble(DR["Valor"]) < _Retorno.Seg_U[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = _Retorno.Seg_U[aux].ValorPago - Convert.ToDouble(DR["Valor"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = 0;

                    if (Convert.ToDouble(DR["Valor"]) > _Retorno.Seg_U[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = Convert.ToDouble(DR["Valor"]) - _Retorno.Seg_U[aux].ValorPago;
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = 0;

                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Cedente"].Value = DR["ID_Cedente"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ValorPago"].Value = _Retorno.Seg_U[aux].ValorPago;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Documento"].Value = DR["Documento"];

                    if (Convert.ToBoolean(DR["UtilizaTarifa"]) == true)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = Convert.ToDouble(DR["Tarifa"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = _Retorno.Seg_T[aux].Tarifa;
                }
            lb_TotalRegistro.Text = "Total de Registro: " + _DT.Rows.Count;

        }

        private void Carrega_Retorno_Sicoob400(DataTable _DT, DTO_Retorno_Sicoob400 _Retorno)
        {
            int aux;

            dg_BoletoRetorno.Rows.Clear();

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DR = _DT.Rows[i];
                    aux = 0;
                    foreach (var x in _Retorno.Detalhe)
                    {
                        if (Convert.ToInt32(x.NossoNumero.Substring(6, 5)) == Convert.ToInt32(DR["ID"]))
                            break;
                        aux++;
                    }

                    dg_BoletoRetorno.Rows.Add();
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pessoa"].Value = DR["DescricaoPessoa"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Emissao"].Value = DR["Emissao"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_NossoNumero"].Value = _Retorno.Detalhe[aux].NossoNumero.Substring(0, 10) + "-" + _Retorno.Detalhe[aux].NossoNumero.Substring(10, 1);
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Vencimento"].Value = DR["Vencimento"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value = _Retorno.Detalhe[aux].Data_Liquidacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_DataCredito"].Value = _Retorno.Detalhe[aux].Data_Credito;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Valor"].Value = DR["Valor"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value = DR["ID"];

                    if (Convert.ToDouble(DR["Valor"]) < _Retorno.Detalhe[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = _Retorno.Detalhe[aux].ValorPago - Convert.ToDouble(DR["Valor"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = 0;

                    if (Convert.ToDouble(DR["Valor"]) > _Retorno.Detalhe[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = Convert.ToDouble(DR["Valor"]) - _Retorno.Detalhe[aux].ValorPago;
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = 0;

                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Cedente"].Value = DR["ID_Cedente"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ValorPago"].Value = _Retorno.Detalhe[aux].ValorPago;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Documento"].Value = DR["Documento"];

                    if (Convert.ToBoolean(DR["UtilizaTarifa"]) == true)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = Convert.ToDouble(DR["Tarifa"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = _Retorno.Detalhe[aux].Tarifa;
                }
            lb_TotalRegistro.Text = "Total de Registro: " + _DT.Rows.Count;

        }

        private void Carrega_Retorno_Bradesco400(DataTable _DT, DTO_Retorno_Bradesco400 _Retorno)
        {
            int aux;

            dg_BoletoRetorno.Rows.Clear();

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DR = _DT.Rows[i];
                    aux = 0;
                    foreach (var x in _Retorno.Detalhe)
                    {
                        if (Convert.ToInt32(x.NossoNumero.Substring(2)) == Convert.ToInt32(DR["ID"]))
                            break;
                        aux++;
                    }

                    dg_BoletoRetorno.Rows.Add();
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pessoa"].Value = DR["DescricaoPessoa"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Emissao"].Value = DR["Emissao"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_NossoNumero"].Value = _Retorno.Detalhe[aux].NossoNumero;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Vencimento"].Value = DR["Vencimento"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value = _Retorno.Detalhe[aux].Data_Liquidacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_DataCredito"].Value = _Retorno.Detalhe[aux].Data_Credito;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Valor"].Value = DR["Valor"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value = DR["ID"];

                    if (Convert.ToDouble(DR["Valor"]) < _Retorno.Detalhe[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = _Retorno.Detalhe[aux].ValorPago - Convert.ToDouble(DR["Valor"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = 0;

                    if (Convert.ToDouble(DR["Valor"]) > _Retorno.Detalhe[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = Convert.ToDouble(DR["Valor"]) - _Retorno.Detalhe[aux].ValorPago;
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = 0;

                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Cedente"].Value = DR["ID_Cedente"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ValorPago"].Value = _Retorno.Detalhe[aux].ValorPago;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Documento"].Value = DR["Documento"];

                    if (Convert.ToBoolean(DR["UtilizaTarifa"]) == true)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = Convert.ToDouble(DR["Tarifa"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = _Retorno.Detalhe[aux].Tarifa;
                }
            lb_TotalRegistro.Text = "Total de Registro: " + _DT.Rows.Count;

        }

        private void Carrega_Retorno_Caixa240(DataTable _DT, DTO_Retorno_Caixa240 _Retorno)
        {
            int aux = 0;

            dg_BoletoRetorno.Rows.Clear();

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DR = _DT.Rows[i];
                    aux = 0;
                    foreach (var x in _Retorno.Seg_T)
                    {
                        if (x.NossoNumero.ToString().Substring(0, 15) == DR["NossoNumero"].ToString())
                            break;
                        aux++;
                    }
                    dg_BoletoRetorno.Rows.Add();
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pessoa"].Value = DR["DescricaoPessoa"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Emissao"].Value = DR["Emissao"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_NossoNumero"].Value = DR["NossoNumero"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Vencimento"].Value = DR["Vencimento"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Pagamento"].Value = _Retorno.Seg_U[aux].Data_Efetivacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_DataCredito"].Value = _Retorno.Seg_U[aux].Data_Efetivacao;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Valor"].Value = DR["Valor"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ID_Boleto"].Value = DR["ID"];

                    if (Convert.ToDouble(DR["Valor"]) < _Retorno.Seg_U[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = _Retorno.Seg_U[aux].ValorPago - Convert.ToDouble(DR["Valor"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = 0;

                    if (Convert.ToDouble(DR["Valor"]) > _Retorno.Seg_U[aux].ValorPago)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = Convert.ToDouble(DR["Valor"]) - _Retorno.Seg_U[aux].ValorPago;
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = 0;

                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Acrescimo"].Value = _Retorno.Seg_U[aux].Despesas + _Retorno.Seg_U[aux].Acrescimo;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Desconto"].Value = _Retorno.Seg_U[aux].Desconto + _Retorno.Seg_U[aux].Abatimento;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Cedente"].Value = DR["ID_Cedente"];
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_ValorPago"].Value = _Retorno.Seg_U[aux].ValorPago;
                    dg_BoletoRetorno.Rows[i].Cells["col_ret_Documento"].Value = DR["Documento"];

                    if (Convert.ToBoolean(DR["UtilizaTarifa"]) == true)
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = Convert.ToDouble(DR["Tarifa"]);
                    else
                        dg_BoletoRetorno.Rows[i].Cells["col_ret_Tarifa"].Value = _Retorno.Seg_T[aux].Tarifa;
                }
            lb_TotalRegistro.Text = "Total de Registro: " + _DT.Rows.Count;

        }

        #endregion

        #region FORM
        private void UI_Boleto_Retorno_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region BUTTON  
        private void bt_PesquisaRetorno_Click(object sender, EventArgs e)
        {
            LerRetorno();
        }

        private void bt_Tratar_Click(object sender, EventArgs e)
        {
            Tratar_Retorno();
        }
        #endregion
    }
}

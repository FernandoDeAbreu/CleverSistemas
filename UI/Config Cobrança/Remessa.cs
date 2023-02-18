using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public class Remessa
    {
        #region VARIAVEIS DE CLASSE
        BLL_Cedente BLL_Cedente;
        BLL_Banco BLL_Banco;
        #endregion

        #region ESTRUTURA
        DTO_Cedente Cedente;
        DTO_Banco Banco;
        DTO_Remessa_Sicoob400 Remessa_Sicoob400;
        #endregion

        //SANTANDER HOMOLOGADO - 13/09/2016
        #region SANTANDER 240
        public void Gera_Arq_Remessa240_Santander(DataTable _Boleto, int _ID_Cedente)
        {
            try
            {
                //BUSCA INFORMAÇÃO CEDENTE
                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();
                DataTable _DT_Cedente = new DataTable();

                Cedente.ID = _ID_Cedente;
                Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                _DT_Cedente = BLL_Cedente.Busca(Cedente);

                if (_DT_Cedente.Rows.Count != 1)
                    return;

                //BUSCA INFORMAÇÃO BANCO
                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();
                DataTable _DT_Banco = new DataTable();

                Banco.ID = Convert.ToInt32(_DT_Cedente.Rows[0]["ID_Banco"]);

                _DT_Banco = BLL_Banco.Busca(Banco);

                string Header_Arquivo = string.Empty;
                string Header_Lote = string.Empty;

                List<string> _Remessa = new List<string>();

                string Trailler_Lote = string.Empty;
                string Trailler_Arquivo = string.Empty;

                string[] Agencia = _DT_Banco.Rows[0]["Agencia"].ToString().Split('-');
                string[] Conta = _DT_Banco.Rows[0]["Conta"].ToString().Split('-');

                #region HEADER ARQUIVO
                Header_Arquivo += "033"; //BANCO
                Header_Arquivo += "0000"; //LOTE DE SERVIÇO
                Header_Arquivo += "0"; //IDENTIFICAÇÃO REGISTRO
                Header_Arquivo += util_dados.Config_Campo_String(8, 'D', ' ', ""); //CNAB

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 11)
                    Header_Arquivo += "1";

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 14)
                    Header_Arquivo += "2";

                Header_Arquivo += util_dados.Config_Campo_String(15, 'E', '0', util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()));
                Header_Arquivo += util_dados.Config_Campo_String(4, 'E', '0', Agencia[0]); // CODIGO CONVÉNIO NO SANTANDER COMPOSTO AGENCIA + COD CEDENTE
                Header_Arquivo += util_dados.Config_Campo_String(11, 'E', '0', _DT_Cedente.Rows[0]["Cod_Cedente"].ToString()); // CODIGO CONVÉNIO NO SANTANDER COMPOSTO AGENCIA + COD CEDENTE
                Header_Arquivo += util_dados.Config_Campo_String(25, 'E', ' ', ""); //RESERVADO (BANCO)
                Header_Arquivo += _DT_Cedente.Rows[0]["Razao_Cedente"].ToString().PadRight(30, ' ').Substring(0, 30); //NOME CEDENTE (30)
                Header_Arquivo += util_dados.Config_Campo_String(30, 'D', ' ', "Banco Santander"); //NOME BANCO (30)
                Header_Arquivo += util_dados.Config_Campo_String(10, 'D', ' ', ""); //RESERVADO
                Header_Arquivo += "1"; //CODIGO REMESSA/RETORNO
                Header_Arquivo += util_dados.Config_Data(DateTime.Now, 18); //DATA HORA EMISSÃO REMESSA
                Header_Arquivo += util_dados.Config_Campo_String(6, 'D', ' ', ""); //RESERVADO
                Header_Arquivo += _Boleto.Rows[0]["ID_Remessa"].ToString().PadLeft(6, '0');
                Header_Arquivo += "040"; //VERSÃO DO LAYOUT
                Header_Arquivo += util_dados.Config_Campo_String(74, 'D', ' ', ""); //RESERVADO BANCO

                Header_Arquivo = util_dados.Remove_CaractereEspecial(Header_Arquivo);

                _Remessa.Add(Header_Arquivo);
                #endregion

                #region HEADER LOTE
                Header_Lote += "033"; //BANCO
                Header_Lote += "0001"; //LOTE DE SERVIÇO
                Header_Lote += "1"; //IDENTIFICAÇÃO REGISTRO
                Header_Lote += "R"; //OPERAÇÃO
                Header_Lote += "01"; //SERVIÇO

                Header_Lote += util_dados.Config_Campo_String(2, 'D', ' ', ""); //CNAB
                Header_Lote += "030"; //VERSÃO DO LAYOUT
                Header_Lote += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 11)
                    Header_Lote += "1";

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 14)
                    Header_Lote += "2";

                Header_Lote += util_dados.Config_Campo_String(15, 'E', '0', util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()));
                Header_Lote += util_dados.Config_Campo_String(20, 'D', ' ', ""); //RESERVADO BANCO

                Header_Lote += util_dados.Config_Campo_String(4, 'E', '0', Agencia[0]); // CODIGO CONVÉNIO NO SANTANDER COMPOSTO AGENCIA + COD CEDENTE
                Header_Lote += util_dados.Config_Campo_String(11, 'E', '0', _DT_Cedente.Rows[0]["Cod_Cedente"].ToString()); // CODIGO CONVÉNIO NO SANTANDER COMPOSTO AGENCIA + COD CEDENTE

                Header_Lote += util_dados.Config_Campo_String(5, 'D', ' ', ""); //RESERVADO BANCO

                Header_Lote += _DT_Cedente.Rows[0]["Razao_Cedente"].ToString().PadRight(30, ' ').Substring(0, 30); //NOME CEDENTE (30)
                Header_Lote += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_1"].ToString()); //MENSAGEM 1
                Header_Lote += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_2"].ToString()); //MENSAGEM 2

                Header_Lote += _Boleto.Rows[0]["ID_Remessa"].ToString().PadLeft(8, '0');
                Header_Lote += util_dados.Config_Data(DateTime.Now, 18); //DATA EMISSÃO REMESSA
                Header_Lote += util_dados.Config_Campo_String(41, 'D', ' ', ""); //CNAB

                Header_Lote = util_dados.Remove_CaractereEspecial(Header_Lote);

                _Remessa.Add(Header_Lote);
                #endregion

                #region DETALHES
                int _AuxRegistro = 1;
                for (int i = 0; i <= _Boleto.Rows.Count - 1; i++)
                {
                    string Seguimento_P = string.Empty;
                    string Seguimento_Q = string.Empty;
                    string Seguimento_R = string.Empty;
                    string Seguimento_S = string.Empty;

                    #region SEGUIMENTO P
                    Seguimento_P += "033"; //BANCO
                    Seguimento_P += "0001"; //LOTE DE SERVIÇO
                    Seguimento_P += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_P += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_P += "P";  //IDENTIFICAÇÃO SEGUIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    switch (Convert.ToInt32(_Boleto.Rows[i]["Movimento"]))
                    {
                        case 1: //REGISTRO DE TITULOS
                            Seguimento_P += "01";
                            break;

                        case 2: //ALTERAÇÃO DE VENCIMENTO
                            Seguimento_P += "06";
                            break;

                        case 3: //PEDIDO DE BAIXA
                            Seguimento_P += "02";
                            break;
                    }

                    #region AGENCIA
                    if (Agencia.Length == 1)
                    {
                        Seguimento_P += Agencia[0].PadLeft(4, '0'); //AGENCIA BANCO (4)
                        Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); ; //DV AGENCIA BANCO (1)
                    }

                    if (Agencia.Length == 2)
                    {
                        Seguimento_P += Agencia[0].PadLeft(4, '0'); //AGENCIA BANCO (4)
                        Seguimento_P += Agencia[1]; //DV AGENCIA BANCO (1)
                    }
                    #endregion

                    #region CONTA
                    if (Conta.Length == 1)
                    {
                        Seguimento_P += Conta[0].PadLeft(9, '0'); //CONTA BANCO (4)
                        Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); ; //DV CONTA BANCO (1)
                    }

                    if (Conta.Length == 2)
                    {
                        Seguimento_P += Conta[0].PadLeft(9, '0'); //CONTA BANCO (4)
                        Seguimento_P += Conta[1]; //DV CONTA BANCO (1)
                    }
                    #endregion

                    #region CONTA COBRANÇA
                    if (Conta.Length == 1)
                    {
                        Seguimento_P += Conta[0].PadLeft(9, '0'); //CONTA BANCO (4)
                        Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); ; //DV CONTA BANCO (1)
                    }

                    if (Conta.Length == 2)
                    {
                        Seguimento_P += Conta[0].PadLeft(9, '0'); //CONTA BANCO (4)
                        Seguimento_P += Conta[1]; //DV CONTA BANCO (1)
                    }
                    #endregion

                    //Seguimento_P += util_dados.Config_Campo_String(9, 'D', '0', ""); // CONTA COBRANÇA
                    //Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); // DV CONTA COBRANÇA 

                    Seguimento_P += util_dados.Config_Campo_String(2, 'D', ' ', ""); // DV RESERVADO

                    Seguimento_P += util_dados.Santander_NossoNumeroDV(_Boleto.Rows[i]["NossoNumero"].ToString()).Replace("-", "");
                    //Seguimento_P += _DT_Cedente.Rows[0]["Carteira"].ToString(); //CARTEIRA
                    Seguimento_P += util_dados.Config_Campo_String(1, 'E', '0', _DT_Cedente.Rows[0]["Tipo_Cobranca"].ToString()); //TIPO DE COBRANÇA
                    Seguimento_P += "1"; //COBRANÇA REGISTRADA
                    Seguimento_P += "1"; //TIPO DE DOCUMENTO (1 - TRADICIONAL, 2 - ESCRITURAL)
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //RESERVADO
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //RESERVADO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', _Boleto.Rows[i]["ID_Boleto"].ToString()); //DOCUMENTO
                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); //VENCIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Valor"].ToString(), 32)); //VALOR

                    Seguimento_P += util_dados.Config_Campo_String(4, 'D', '0', ""); // AGENCIA COBRANÇA
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); // DV AGENCIA COBRANÇA 

                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //RESERVADO

                    Seguimento_P += "02";//TIPO DE TITULO (02) DUPLICATA MERCANTIL
                    Seguimento_P += "N";//ACEITE
                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Emissao"]), 18); //EMISSÃO

                    Seguimento_P += "1"; //CODIGO JUROS (1)-VALOR POR DIA
                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); ; //DATA JUROS MORA
                    double _Juros = util_dados.Calcula_Porcentagem(Convert.ToDouble(_Boleto.Rows[i]["Juros"]) / 30, Convert.ToDouble(_Boleto.Rows[i]["Valor"]));

                    if (_Juros < 0.01)
                        _Juros = 0.01;
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Juros, 32)); //JUROS

                    //NÃO CONCEDER DESCONTO PARA PAGAMENTO ANTECIPADO
                    Seguimento_P += "0"; //DESCONTO
                    Seguimento_P += util_dados.Config_Campo_String(8, 'E', '0', ""); // DATA DESCONTO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', ""); ; //DESCONTO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'D', '0', ""); //IOF
                    Seguimento_P += util_dados.Config_Campo_String(15, 'D', '0', ""); //ABATIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(25, 'D', ' ', _Boleto.Rows[i]["ID_Boleto"].ToString()); //IDENTIFICAÇÃO DO TITULO
                    Seguimento_P += _DT_Cedente.Rows[0]["Cod_Protesto"].ToString(); //Cod_Protesto
                    Seguimento_P += util_dados.Config_Campo_String(2, 'D', '0', _DT_Cedente.Rows[0]["DiaProtesto"].ToString()); //CARTEIRA
                    Seguimento_P += "3"; //CODIGO BAIXA/DEVOLUÇÃO
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', '0', ""); //RESERVADO
                    Seguimento_P += "00"; //DIAS BAIXA/DEVOLUÇÃO           
                    Seguimento_P += "00"; //MOEDA
                    Seguimento_P += util_dados.Config_Campo_String(11, 'D', ' ', ""); //RESERVADO

                    Seguimento_P = util_dados.Remove_CaractereEspecial(Seguimento_P);

                    _Remessa.Add(Seguimento_P);
                    #endregion

                    #region SEGUIMENTO Q
                    Seguimento_Q += "033"; //BANCO
                    Seguimento_Q += "0001"; //LOTE DE SERVIÇO
                    Seguimento_Q += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_Q += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_Q += "Q";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_Q += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    switch (Convert.ToInt32(_Boleto.Rows[i]["Movimento"]))
                    {
                        case 1: //REGISTRO DE TITULOS
                            Seguimento_Q += "01";
                            break;

                        case 2: //ALTERAÇÃO DE VENCIMENTO
                            Seguimento_Q += "06";
                            break;

                        case 3: //PEDIDO DE BAIXA
                            Seguimento_Q += "02";
                            break;
                    }

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 11)
                        Seguimento_Q += "1";

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 14)
                        Seguimento_Q += "2";

                    Seguimento_Q += util_dados.Config_Campo_String(15, 'E', '0', util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()));
                    Seguimento_Q += _Boleto.Rows[i]["Nome_Razao"].ToString().PadRight(40, ' ').Substring(0, 40);

                    string Endereco = _Boleto.Rows[i]["Logradouro"].ToString() + ", " + _Boleto.Rows[i]["NumeroEndereco"].ToString() + " " + _Boleto.Rows[i]["Complemento"].ToString();

                    Seguimento_Q += Endereco.PadRight(40, ' ').Substring(0, 40);
                    Seguimento_Q += _Boleto.Rows[i]["Bairro"].ToString().PadRight(15, ' ').Substring(0, 15);

                    string[] CEP = _Boleto.Rows[i]["CEP"].ToString().Split('-');

                    Seguimento_Q += CEP[0];
                    Seguimento_Q += CEP[1];

                    Seguimento_Q += _Boleto.Rows[i]["NomeMunicipio"].ToString().PadRight(15, ' ').Substring(0, 15);
                    Seguimento_Q += _Boleto.Rows[i]["Sigla"].ToString().PadRight(2, ' ').Substring(0, 2);

                    Seguimento_Q += util_dados.Config_Campo_String(1, 'D', '0', ""); //AVALISTA
                    Seguimento_Q += util_dados.Config_Campo_String(15, 'D', '0', ""); //AVALISTA
                    Seguimento_Q += util_dados.Config_Campo_String(40, 'D', ' ', ""); //AVALISTA

                    Seguimento_Q += "000"; //CARNE
                    Seguimento_Q += "000"; //PARCELA INICIAL
                    Seguimento_Q += "000"; //QT PARCELA
                    Seguimento_Q += "000"; //NUMERO PLANO

                    Seguimento_Q += util_dados.Config_Campo_String(19, 'D', ' ', ""); //CNAB

                    Seguimento_Q = util_dados.Remove_CaractereEspecial(Seguimento_Q);

                    _Remessa.Add(Seguimento_Q);
                    #endregion

                    #region SEGUIMENTO R
                    Seguimento_R += "033"; //BANCO
                    Seguimento_R += "0001"; //LOTE DE SERVIÇO
                    Seguimento_R += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_R += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_R += "R";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB


                    switch (Convert.ToInt32(_Boleto.Rows[i]["Movimento"]))
                    {
                        case 1: //REGISTRO DE TITULOS
                            Seguimento_R += "01";
                            break;

                        case 2: //ALTERAÇÃO DE VENCIMENTO
                            Seguimento_R += "06";
                            break;

                        case 3: //PEDIDO DE BAIXA
                            Seguimento_R += "02";
                            break;
                    }

                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(8, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(15, 'D', '0', ""); //DESCONTO

                    Seguimento_R += util_dados.Config_Campo_String(24, 'D', ' ', ""); //RESERVADO

                    Seguimento_R += "2"; //CODIGO JUROS (2)-TAXA MENSAL
                    Seguimento_R += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); ; //DATA JUROS MORA
                    Seguimento_R += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Multa"].ToString(), 32)); //JUROS

                    Seguimento_R += util_dados.Config_Campo_String(10, 'D', ' ', ""); //RESERVADO

                    Seguimento_R += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM
                    Seguimento_R += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM
                    Seguimento_R += util_dados.Config_Campo_String(61, 'D', ' ', ""); //RESERVADO

                    Seguimento_R = util_dados.Remove_CaractereEspecial(Seguimento_R);

                    _Remessa.Add(Seguimento_R);
                    #endregion

                    #region SEGUIMENTO S
                    Seguimento_S += "033"; //BANCO
                    Seguimento_S += "0001"; //LOTE DE SERVIÇO
                    Seguimento_S += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_S += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_S += "S";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_S += util_dados.Config_Campo_String(1, 'D', ' ', ""); //RESERVADO

                    switch (Convert.ToInt32(_Boleto.Rows[i]["Movimento"]))
                    {
                        case 1: //REGISTRO DE TITULOS
                            Seguimento_S += "01";
                            break;

                        case 2: //ALTERAÇÃO DE VENCIMENTO
                            Seguimento_S += "06";
                            break;

                        case 3: //PEDIDO DE BAIXA
                            Seguimento_S += "02";
                            break;
                    }

                    Seguimento_S += "2"; //TIPO DE IMPRESSÃO
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_1"].ToString()); //MENSAGEM 1
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_2"].ToString()); //MENSAGEM 2
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 7
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 8
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 9

                    Seguimento_S += util_dados.Config_Campo_String(22, 'D', ' ', ""); //CNAB

                    Seguimento_S = util_dados.Remove_CaractereEspecial(Seguimento_S);

                    _Remessa.Add(Seguimento_S);
                    #endregion
                }
                #endregion

                #region TRAILLER DO LOTE
                Trailler_Lote += "033"; //BANCO
                Trailler_Lote += "0001"; //LOTE DE SERVIÇO
                Trailler_Lote += "5";  //IDENTIFICAÇÃO DE REGISTRO

                Trailler_Lote += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', (_AuxRegistro + 1).ToString()); //TOTAL DE REGISTRO
                Trailler_Lote += util_dados.Config_Campo_String(217, 'E', ' ', ""); //RESERVADO

                Trailler_Lote = util_dados.Remove_CaractereEspecial(Trailler_Lote);

                _Remessa.Add(Trailler_Lote);
                #endregion

                #region TRAILLER ARQUIVO
                Trailler_Arquivo += "033"; //BANCO
                Trailler_Arquivo += "9999"; //LOTE DE SERVIÇO
                Trailler_Arquivo += "9";  //IDENTIFICAÇÃO DE REGISTRO

                Trailler_Arquivo += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                Trailler_Arquivo += "000001"; //QUANTIDADE DE LOTE

                Trailler_Arquivo += util_dados.Config_Campo_String(6, 'E', '0', (_AuxRegistro + 3).ToString()); //TOTAL DE REGISTRO

                Trailler_Arquivo += util_dados.Config_Campo_String(211, 'E', ' ', ""); //CNAB

                Trailler_Arquivo = util_dados.Remove_CaractereEspecial(Trailler_Arquivo);

                _Remessa.Add(Trailler_Arquivo);
                #endregion

                string Arquivo = _Boleto.Rows[0]["Arquivo"].ToString();

                if (!Directory.Exists(Parametro_Sistema.Caminho_Remessa))
                    Directory.CreateDirectory(Parametro_Sistema.Caminho_Remessa);

                string[] Empresa = Parametro_Empresa.Razao_Social_Empresa.Split(' ');

                if (!Directory.Exists(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0]))
                    Directory.CreateDirectory(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0]);

                File.WriteAllLines(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0] + @"\" + Arquivo + ".REM", _Remessa.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        //SICOOB HOMOLOGADO - 11/06/2016
        #region SICOOB 240
        public void Gera_Arq_Remessa240_Sicoob(DataTable _Boleto, int _ID_Cedente)
        {
            try
            {
                //BUSCA INFORMAÇÃO CEDENTE
                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();
                DataTable _DT_Cedente = new DataTable();

                Cedente.ID = _ID_Cedente;
                Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                _DT_Cedente = BLL_Cedente.Busca(Cedente);

                if (_DT_Cedente.Rows.Count != 1)
                    return;

                //BUSCA INFORMAÇÃO BANCO
                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();
                DataTable _DT_Banco = new DataTable();

                Banco.ID = Convert.ToInt32(_DT_Cedente.Rows[0]["ID_Banco"]);

                _DT_Banco = BLL_Banco.Busca(Banco);

                string Header_Arquivo = string.Empty;
                string Header_Lote = string.Empty;

                List<string> _Remessa = new List<string>();

                string Trailler_Lote = string.Empty;
                string Trailler_Arquivo = string.Empty;

                string[] Agencia = _DT_Banco.Rows[0]["Agencia"].ToString().Split('-');
                string[] Conta = _DT_Banco.Rows[0]["Conta"].ToString().Split('-');

                #region HEADER ARQUIVO
                Header_Arquivo += "756"; //BANCO
                Header_Arquivo += "0000"; //LOTE DE SERVIÇO
                Header_Arquivo += "0"; //IDENTIFICAÇÃO REGISTRO
                Header_Arquivo += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 11)
                    Header_Arquivo += "1";

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 14)
                    Header_Arquivo += "2";

                Header_Arquivo += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()));
                Header_Arquivo += util_dados.Config_Campo_String(20, 'D', ' ', ""); // CODIGO CONVÉNIO NO SICOOB

                #region AGENCIA
                if (Agencia.Length == 1)
                {
                    Header_Arquivo += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                    Header_Arquivo += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV AGENCIA BANCO (1)
                }

                if (Agencia.Length == 2)
                {
                    Header_Arquivo += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                    Header_Arquivo += Agencia[1]; //DV AGENCIA BANCO (1)
                }
                #endregion

                #region CONTA
                if (Conta.Length == 1)
                {
                    Header_Arquivo += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                    Header_Arquivo += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV CONTA BANCO (1)
                }

                if (Conta.Length == 2)
                {
                    Header_Arquivo += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                    Header_Arquivo += Conta[1]; //DV CONTA BANCO (1)
                }
                #endregion

                Header_Arquivo += util_dados.Config_Campo_String(1, 'D', ' ', ""); // DV VERIFICADOR 
                Header_Arquivo += _DT_Cedente.Rows[0]["Razao_Cedente"].ToString().PadRight(30, ' ').Substring(0, 30); //NOME CEDENTE (30)
                Header_Arquivo += util_dados.Config_Campo_String(30, 'D', ' ', "SICOOB"); //NOME bANCO (30)
                Header_Arquivo += util_dados.Config_Campo_String(10, 'D', ' ', "");
                Header_Arquivo += "1"; //CODIGO REMESSA/RETORNO
                Header_Arquivo += util_dados.Config_Data(DateTime.Now, 16); //DATA HORA EMISSÃO REMESSA
                Header_Arquivo += _Boleto.Rows[0]["ID_Remessa"].ToString().PadLeft(6, '0');

                Header_Arquivo += "081"; //VERSÃO DO LAYOUT
                Header_Arquivo += "00000"; //DENSIDADE DE GRAVAÇÃO

                Header_Arquivo += util_dados.Config_Campo_String(20, 'D', ' ', ""); //RESERVADO BANCO
                Header_Arquivo += util_dados.Config_Campo_String(20, 'D', ' ', ""); //RESERVADO EMPRESA
                Header_Arquivo += util_dados.Config_Campo_String(29, 'D', ' ', ""); //CNAB

                Header_Arquivo = util_dados.Remove_CaractereEspecial(Header_Arquivo);

                _Remessa.Add(Header_Arquivo);
                #endregion

                #region HEADER LOTE
                Header_Lote += "756"; //BANCO
                Header_Lote += "0001"; //LOTE DE SERVIÇO
                Header_Lote += "1"; //IDENTIFICAÇÃO REGISTRO
                Header_Lote += "R"; //OPERAÇÃO
                Header_Lote += "01"; //SERVIÇO

                Header_Lote += util_dados.Config_Campo_String(2, 'D', ' ', ""); //CNAB
                Header_Lote += "040"; //VERSÃO DO LAYOUT
                Header_Lote += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 11)
                    Header_Lote += "1";

                if (util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()).Length == 14)
                    Header_Lote += "2";

                Header_Lote += util_dados.Config_Campo_String(15, 'E', '0', util_dados.Retorna_Numero(_DT_Cedente.Rows[0]["CNPJ_CPF_Cedente"].ToString()));
                Header_Lote += util_dados.Config_Campo_String(20, 'D', ' ', ""); // CODIGO CONVÉNIO NO SICOOB

                #region AGENCIA
                if (Agencia.Length == 1)
                {
                    Header_Lote += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                    Header_Lote += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV AGENCIA BANCO (1)
                }

                if (Agencia.Length == 2)
                {
                    Header_Lote += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                    Header_Lote += Agencia[1]; //DV AGENCIA BANCO (1)
                }
                #endregion

                #region CONTA
                if (Conta.Length == 1)
                {
                    Header_Lote += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                    Header_Lote += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV CONTA BANCO (1)
                }

                if (Conta.Length == 2)
                {
                    Header_Lote += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                    Header_Lote += Conta[1]; //DV CONTA BANCO (1)
                }
                #endregion

                Header_Lote += util_dados.Config_Campo_String(1, 'D', ' ', ""); // DV VERIFICADOR 

                Header_Lote += _DT_Cedente.Rows[0]["Razao_Cedente"].ToString().PadRight(30, ' ').Substring(0, 30); //NOME CEDENTE (30)
                Header_Lote += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_1"].ToString()); //MENSAGEM 1
                Header_Lote += util_dados.Config_Campo_String(40, 'D', ' ', _DT_Cedente.Rows[0]["Instrucao_2"].ToString()); //MENSAGEM 2
                Header_Lote += _Boleto.Rows[0]["ID_Remessa"].ToString().PadLeft(8, '0');
                Header_Lote += util_dados.Config_Data(DateTime.Now, 18); //DATA EMISSÃO REMESSA
                Header_Lote += util_dados.Config_Campo_String(8, 'D', '0', ""); //DATA CREDITO
                Header_Lote += util_dados.Config_Campo_String(33, 'D', ' ', ""); //CNAB

                Header_Lote = util_dados.Remove_CaractereEspecial(Header_Lote);

                _Remessa.Add(Header_Lote);
                #endregion

                #region DETALHES
                int _AuxRegistro = 1;
                for (int i = 0; i <= _Boleto.Rows.Count - 1; i++)
                {
                    string Seguimento_P = string.Empty;
                    string Seguimento_Q = string.Empty;
                    string Seguimento_R = string.Empty;
                    string Seguimento_S = string.Empty;

                    #region SEGUIMENTO P
                    Seguimento_P += "756"; //BANCO
                    Seguimento_P += "0001"; //LOTE DE SERVIÇO
                    Seguimento_P += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_P += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_P += "P";  //IDENTIFICAÇÃO SEGUIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    Seguimento_P += "01"; // REGISTRO DE TITULO                        

                    #region AGENCIA
                    if (Agencia.Length == 1)
                    {
                        Seguimento_P += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                        Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV AGENCIA BANCO (1)
                    }

                    if (Agencia.Length == 2)
                    {
                        Seguimento_P += Agencia[0].PadLeft(5, '0'); //AGENCIA BANCO (4)
                        Seguimento_P += Agencia[1]; //DV AGENCIA BANCO (1)
                    }
                    #endregion

                    #region CONTA
                    if (Conta.Length == 1)
                    {
                        Seguimento_P += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                        Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); ; //DV CONTA BANCO (1)
                    }

                    if (Conta.Length == 2)
                    {
                        Seguimento_P += Conta[0].PadLeft(12, '0'); //CONTA BANCO (4)
                        Seguimento_P += Conta[1]; //DV CONTA BANCO (1)
                    }
                    #endregion

                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); // DV VERIFICADOR 

                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 1)
                    {
                        string _NossoNumero = _Boleto.Rows[i]["NossoNumero"].ToString().Substring(0, 2) + _Boleto.Rows[i]["NossoNumero"].ToString().Substring(_Boleto.Rows[i]["NossoNumero"].ToString().Length - 5, 5);
                        Config_Banco _Config_Banco = new Config_Banco();

                        _NossoNumero = _Config_Banco.Sicoob_NossoNumero(Agencia[0], _DT_Cedente.Rows[0]["Cod_Cedente"].ToString(), _NossoNumero);

                        Seguimento_P += util_dados.Config_Campo_String(10, 'E', '0', _NossoNumero); // NOSSO NUMERO

                        Seguimento_P += "01"; //PARCELA

                        Seguimento_P += _DT_Cedente.Rows[0]["Carteira"].ToString().Substring(1, 2); //MODALIDADE

                        Seguimento_P += "4"; //TIPO FORMULARIO IMPRESSÃO
                        Seguimento_P += util_dados.Config_Campo_String(5, 'D', ' ', "");
                    }

                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 2)
                    {
                        Seguimento_P += util_dados.Config_Campo_String(10, 'E', '0', ""); // NOSSO NUMERO

                        Seguimento_P += "01"; //PARCELA

                        Seguimento_P += _DT_Cedente.Rows[0]["Carteira"].ToString().Substring(1, 2); //MODALIDADE

                        Seguimento_P += "3"; //TIPO FORMULARIO IMPRESSÃO (AUTO ENVELOPAVEL)
                        Seguimento_P += util_dados.Config_Campo_String(5, 'D', ' ', "");
                    }

                    Seguimento_P += _DT_Cedente.Rows[0]["Carteira"].ToString().Substring(2, 1); //CARTEIRA
                    Seguimento_P += "0";
                    Seguimento_P += " ";

                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 1)
                        Seguimento_P += "22"; //EMISSÃO SISTEMA

                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 2)
                        Seguimento_P += "11"; //EMISSÃO SICOOB

                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', _Boleto.Rows[i]["ID_Boleto"].ToString()); //DOCUMENTO

                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); //VENCIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Valor"].ToString(), 32)); //VALOR
                    Seguimento_P += "00000";
                    Seguimento_P += " ";
                    Seguimento_P += "02";//TIPO DE TITULO (02) DUPLICATA MERCANTIL

                    if (Convert.ToBoolean(_DT_Cedente.Rows[0]["Aceite"]) == true)
                        Seguimento_P += "A";
                    else
                        Seguimento_P += "N";

                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Emissao"]), 18); //EMISSÃO
                    Seguimento_P += "2"; //CODIGO JUROS (2)-TAXA MENSAL
                    Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); ; //DATA JUROS MORA
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Juros"].ToString(), 32)); //JUROS

                    //NÃO CONCEDER DESCONTO PARA PAGAMENTO ANTECIPADO
                    Seguimento_P += "0"; //DESCONTO
                    Seguimento_P += util_dados.Config_Campo_String(8, 'E', '0', ""); // DATA DESCONTO
                    Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', ""); ; //DESCONTO

                    //CONCEDER DESCONTO (IMPLEMENTAR DEPOIS)
                    //Seguimento_P += "1"; //DESCONTO
                    //Seguimento_P += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); //DESCONTO
                    //Seguimento_P += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Desconto"].ToString(), 32)); ; //DESCONTO

                    Seguimento_P += util_dados.Config_Campo_String(15, 'D', '0', ""); //IOF
                    Seguimento_P += util_dados.Config_Campo_String(15, 'D', '0', ""); //ABATIMENTO
                    Seguimento_P += util_dados.Config_Campo_String(25, 'D', ' ', _Boleto.Rows[i]["ID_Boleto"].ToString()); //IDENTIFICAÇÃO DO TITULO
                    Seguimento_P += "1"; //CODIGO PARA PROTESTO
                    Seguimento_P += util_dados.Config_Campo_String(2, 'E', '0', _DT_Cedente.Rows[0]["DiaProtesto"].ToString());
                    Seguimento_P += "0"; //CODIGO PARA BAIXA/DEVOLUÇÃO 
                    Seguimento_P += util_dados.Config_Campo_String(3, 'D', ' ', ""); //PRAZO DEVOLUÇÃO
                    Seguimento_P += "09"; //MOEDA
                    Seguimento_P += util_dados.Config_Campo_String(10, 'E', '0', ""); //CONTRATO CREDITO
                    Seguimento_P += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    Seguimento_P = util_dados.Remove_CaractereEspecial(Seguimento_P);

                    _Remessa.Add(Seguimento_P);
                    #endregion

                    #region SEGUIMENTO Q
                    Seguimento_Q += "756"; //BANCO
                    Seguimento_Q += "0001"; //LOTE DE SERVIÇO
                    Seguimento_Q += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_Q += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_Q += "Q";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_Q += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    Seguimento_Q += "01"; //REGISTRO DE TITULO

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 11)
                        Seguimento_Q += "1";

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 14)
                        Seguimento_Q += "2";

                    Seguimento_Q += util_dados.Config_Campo_String(15, 'E', '0', util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()));
                    Seguimento_Q += _Boleto.Rows[i]["Nome_Razao"].ToString().PadRight(40, ' ').Substring(0, 40);

                    string Endereco = _Boleto.Rows[i]["Logradouro"].ToString() + ", " + _Boleto.Rows[i]["NumeroEndereco"].ToString() + " " + _Boleto.Rows[i]["Complemento"].ToString();

                    Seguimento_Q += Endereco.PadRight(40, ' ').Substring(0, 40);
                    Seguimento_Q += _Boleto.Rows[i]["Bairro"].ToString().PadRight(15, ' ').Substring(0, 15);

                    string[] CEP = _Boleto.Rows[i]["CEP"].ToString().Split('-');

                    Seguimento_Q += CEP[0];
                    Seguimento_Q += CEP[1];

                    Seguimento_Q += _Boleto.Rows[i]["NomeMunicipio"].ToString().PadRight(15, ' ').Substring(0, 15);
                    Seguimento_Q += _Boleto.Rows[i]["Sigla"].ToString().PadRight(2, ' ').Substring(0, 2);

                    Seguimento_Q += util_dados.Config_Campo_String(1, 'D', '0', ""); //AVALISTA
                    Seguimento_Q += util_dados.Config_Campo_String(15, 'D', '0', ""); //AVALISTA
                    Seguimento_Q += util_dados.Config_Campo_String(40, 'D', ' ', ""); //AVALISTA

                    Seguimento_Q += "000"; //BANCO COMPENSAÇÃO

                    Seguimento_Q += util_dados.Config_Campo_String(20, 'D', ' ', ""); //BANCO CORRESPONDENTE
                    Seguimento_Q += util_dados.Config_Campo_String(8, 'D', ' ', ""); //CNAB

                    Seguimento_Q = util_dados.Remove_CaractereEspecial(Seguimento_Q);

                    _Remessa.Add(Seguimento_Q);
                    #endregion

                    #region SEGUIMENTO R
                    Seguimento_R += "756"; //BANCO
                    Seguimento_R += "0001"; //LOTE DE SERVIÇO
                    Seguimento_R += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_R += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_R += "R";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    Seguimento_R += "01";//REGISTRO DE TITULO

                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(8, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(15, 'D', '0', ""); //DESCONTO

                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(8, 'D', '0', ""); //DESCONTO
                    Seguimento_R += util_dados.Config_Campo_String(15, 'D', '0', ""); //DESCONTO

                    Seguimento_R += "2"; //CODIGO JUROS (2)-TAXA MENSAL
                    Seguimento_R += util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"]), 18); ; //DATA JUROS MORA
                    Seguimento_R += util_dados.Config_Campo_String(15, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Multa"].ToString(), 32)); //JUROS

                    Seguimento_R += util_dados.Config_Campo_String(10, 'D', ' ', ""); //INFORMAÇÃO SACADO

                    Seguimento_R += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM
                    Seguimento_R += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM
                    Seguimento_R += util_dados.Config_Campo_String(20, 'D', ' ', ""); //CNAB
                    Seguimento_R += util_dados.Config_Campo_String(8, 'D', '0', ""); //OCORRENCIA SACADO
                    Seguimento_R += util_dados.Config_Campo_String(3, 'D', '0', ""); //BANCO SACADO
                    Seguimento_R += util_dados.Config_Campo_String(5, 'D', '0', ""); //AGENCIA SACADO
                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', ' ', ""); //DV AGENCIA SACADO
                    Seguimento_R += util_dados.Config_Campo_String(12, 'D', '0', ""); //CONTA CORRENTE SACADO
                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', ' ', ""); //DV CONTA CORRENTE SACADO
                    Seguimento_R += util_dados.Config_Campo_String(1, 'D', ' ', ""); //DV CONTA / AGENCIA
                    Seguimento_R += "0"; //AVISO DE DÉBITO AUTOMATICO
                    Seguimento_R += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                    Seguimento_R = util_dados.Remove_CaractereEspecial(Seguimento_R);

                    _Remessa.Add(Seguimento_R);
                    #endregion

                    #region SEGUIMENTO S
                    Seguimento_S += "756"; //BANCO
                    Seguimento_S += "0001"; //LOTE DE SERVIÇO
                    Seguimento_S += "3";  //IDENTIFICAÇÃO DE REGISTRO

                    Seguimento_S += _AuxRegistro.ToString().PadLeft(5, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Seguimento_S += "S";  //IDENTIFICAÇÃO DE SEGUIMENTO
                    Seguimento_S += util_dados.Config_Campo_String(1, 'D', ' ', ""); //CNAB

                    Seguimento_S += "01"; //REGISTRO DE TITULO

                    Seguimento_S += "3"; //TIPO DE IMPRESSÃO 3
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 5
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 6
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 7
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 8
                    Seguimento_S += util_dados.Config_Campo_String(40, 'D', ' ', ""); //MENSAGEM 9

                    Seguimento_S += util_dados.Config_Campo_String(22, 'D', ' ', ""); //CNAB

                    Seguimento_S = util_dados.Remove_CaractereEspecial(Seguimento_S);

                    _Remessa.Add(Seguimento_S);
                    #endregion
                }
                #endregion

                #region TRAILLER DO LOTE
                Trailler_Lote += "756"; //BANCO
                Trailler_Lote += "0001"; //LOTE DE SERVIÇO
                Trailler_Lote += "5";  //IDENTIFICAÇÃO DE REGISTRO

                Trailler_Lote += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', (_AuxRegistro + 2).ToString()); //TOTAL DE REGISTRO
                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', _Boleto.Rows.Count.ToString()); //TOTAL DE BOLETOS
                Trailler_Lote += util_dados.Config_Campo_String(17, 'E', '0', util_dados.ConfigNumDecimal(util_dados.Calcula_Campo_DT(_Boleto, "Valor"), 32)); //VALOR TOTAL DOS BOLETOS

                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', ""); //COBRANÇA VINCULADA
                Trailler_Lote += util_dados.Config_Campo_String(17, 'E', '0', ""); //COBRANÇA VINCULADA

                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', ""); //COBRANÇA CAUCIONADA
                Trailler_Lote += util_dados.Config_Campo_String(17, 'E', '0', ""); //COBRANÇA CAUCIONADA

                Trailler_Lote += util_dados.Config_Campo_String(6, 'E', '0', ""); //COBRANÇA DESCONTADA
                Trailler_Lote += util_dados.Config_Campo_String(17, 'E', '0', ""); //COBRANÇA DESCONTADA

                Trailler_Lote += util_dados.Config_Campo_String(8, 'E', ' ', ""); //AVISO DE LANÇAMENTO
                Trailler_Lote += util_dados.Config_Campo_String(117, 'E', ' ', ""); //CNAB

                Trailler_Lote = util_dados.Remove_CaractereEspecial(Trailler_Lote);

                _Remessa.Add(Trailler_Lote);
                #endregion

                #region TRAILLER ARQUIVO
                Trailler_Arquivo += "756"; //BANCO
                Trailler_Arquivo += "9999"; //LOTE DE SERVIÇO
                Trailler_Arquivo += "9";  //IDENTIFICAÇÃO DE REGISTRO

                Trailler_Arquivo += util_dados.Config_Campo_String(9, 'D', ' ', ""); //CNAB

                Trailler_Arquivo += "000001"; //QUANTIDADE DE LOTE

                Trailler_Arquivo += util_dados.Config_Campo_String(6, 'E', '0', (_AuxRegistro + 4).ToString()); //TOTAL DE REGISTRO
                Trailler_Arquivo += util_dados.Config_Campo_String(6, 'E', '0', ""); //QUANTIDADE DE CONTA


                Trailler_Arquivo += util_dados.Config_Campo_String(205, 'E', ' ', ""); //CNAB

                Trailler_Arquivo = util_dados.Remove_CaractereEspecial(Trailler_Arquivo);

                _Remessa.Add(Trailler_Arquivo);
                #endregion

                string Arquivo = _Boleto.Rows[0]["Arquivo"].ToString();

                if (!Directory.Exists(Parametro_Sistema.Caminho_Remessa))
                    Directory.CreateDirectory(Parametro_Sistema.Caminho_Remessa);

                string[] Empresa = Parametro_Empresa.Razao_Social_Empresa.Split(' ');

                if (!Directory.Exists(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0]))
                    Directory.CreateDirectory(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0]);

                File.WriteAllLines(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0] + @"\" + Arquivo + ".REM", _Remessa.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        //BRADESCO HOMOLOGADO - 28/11/2016
        #region BRADESCO 400
        public void Gera_Arq_Remessa400_Bradesco(DataTable _Boleto, int _ID_Cedente)
        {
            try
            {
                //BUSCA INFORMAÇÃO CEDENTE
                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();
                DataTable _DT_Cedente = new DataTable();

                Cedente.ID = _ID_Cedente;
                Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                _DT_Cedente = BLL_Cedente.Busca(Cedente);

                if (_DT_Cedente.Rows.Count != 1)
                    return;

                //BUSCA INFORMAÇÃO BANCO
                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();
                DataTable _DT_Banco = new DataTable();

                Banco.ID = Convert.ToInt32(_DT_Cedente.Rows[0]["ID_Banco"]);

                _DT_Banco = BLL_Banco.Busca(Banco);

                string[] Agencia = _DT_Banco.Rows[0]["Agencia"].ToString().Split('-');
                string[] Conta = _DT_Banco.Rows[0]["Conta"].ToString().Split('-');

                string Header = string.Empty;
                string Detalhe = string.Empty;
                string Trailler = string.Empty;

                List<string> _Remessa = new List<string>();

                #region HEADER
                Header += "0"; // IDENTIFICAÇÃO DO REGISTRO "0"
                Header += "1"; // TIPO DE OPERAÇÃO
                Header += "REMESSA";
                Header += "01"; // TIPO DE SERVIÇO
                Header += util_dados.Config_Campo_String(15, 'D', ' ', "COBRANCA");
                Header += util_dados.Config_Campo_String(20, 'E', '0', _DT_Cedente.Rows[0]["Cod_Cedente"].ToString()); //COD CEDENTE (20)
                Header += util_dados.Config_Campo_String(30, 'D', ' ', _DT_Cedente.Rows[0]["Razao_Cedente"].ToString()); //NOME CEDENTE (30)
                Header += "237";
                Header += util_dados.Config_Campo_String(15, 'D', ' ', "BRADESCO");
                Header += util_dados.Config_Data(DateTime.Now, 17); //DATA EMISSÃO REMESSA
                Header += util_dados.Config_Campo_String(8, 'D', ' ', "");
                Header += "MX";
                Header += _Boleto.Rows[0]["ID_Remessa"].ToString().PadLeft(7, '0'); //CODIGO SEQUENCIAL REMESSA
                Header += util_dados.Config_Campo_String(277, 'D', ' ', "");
                Header += "000001";

                Header = util_dados.Remove_CaractereEspecial(Header);

                _Remessa.Add(Header);
                #endregion

                #region DETALHE
                int _AuxRegistro = 2;
                for (int i = 0; i <= _Boleto.Rows.Count - 1; i++)
                {
                    Detalhe = "1";
                    Detalhe += util_dados.Config_Campo_String(5, 'D', '0', ""); // AGENCIA DEBITO (5)
                    Detalhe += util_dados.Config_Campo_String(1, 'D', '0', ""); // DV AGENCIA DEBITO (1)
                    Detalhe += util_dados.Config_Campo_String(5, 'D', '0', ""); // RAZAO CONTA CORRENTE(5)
                    Detalhe += util_dados.Config_Campo_String(7, 'D', '0', ""); // CONTA CORRENTE DEBITO (7)
                    Detalhe += util_dados.Config_Campo_String(1, 'D', '0', ""); // CONTA CORRENTE DEBITO (1)

                    //IDENTIFICAÇAO EMPRESA
                    Detalhe += "0";
                    Detalhe += util_dados.Config_Campo_String(3, 'E', '0', _DT_Cedente.Rows[0]["Carteira"].ToString()); // COD CARTEIRA (2)
                    Detalhe += util_dados.Config_Campo_String(5, 'E', '0', Agencia[0]); // AGENCIA (5)

                    if (Conta.Length == 1)
                    {
                        Detalhe += util_dados.Config_Campo_String(7, 'E', '0', Conta[0]); // CONTA (7)
                        Detalhe += "0"; // DV CONTA (1)
                    }

                    if (Conta.Length == 2)
                    {
                        Detalhe += util_dados.Config_Campo_String(7, 'E', '0', Conta[0]); // CONTA (7)
                        Detalhe += util_dados.Config_Campo_String(1, 'E', '0', Conta[1]); // DV CONTA (1)
                    }

                    Detalhe += util_dados.Config_Campo_String(25, 'E', '0', _Boleto.Rows[i]["ID_Boleto"].ToString()); // CONTROLE EMPRESA (25)
                    Detalhe += "000";

                    //COBRANÇA DE JUROS
                    if (util_dados.Verifica_Double(_Boleto.Rows[i]["Juros"].ToString()) > 0)
                    {
                        Detalhe += "2";
                        Detalhe += util_dados.Config_Campo_String(4, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Juros"].ToString(), 32)); // JUROS (4)

                    }
                    else
                    {
                        Detalhe += "0";
                        Detalhe += "0000"; // JUROS (4)
                    }

                    //NOSSO NUMERO
                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 1)
                    {
                        string _NossoNumero = _Boleto.Rows[i]["NossoNumero"].ToString().Substring(0, 2);
                        _NossoNumero += _Boleto.Rows[i]["NossoNumero"].ToString().Substring(_Boleto.Rows[i]["NossoNumero"].ToString().Length - 9, 9);

                        Detalhe += util_dados.Config_Campo_String(11, 'E', '0', _NossoNumero); // NOSSO NUMERO (11)
                        Detalhe += util_dados.Mod11_Bradesco_NossoNumero(util_dados.Config_Campo_String(2, 'E', '0', _Boleto.Rows[i]["Carteira"].ToString()) + _NossoNumero); // DV NOSSO NUMERO (1)
                    }

                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 2)
                    {
                        Detalhe += util_dados.Config_Campo_String(11, 'E', '0', ""); // NOSSO NUMERO (11)
                        Detalhe += "0"; // DV NOSSO NUMERO (1)
                    }

                    Detalhe += util_dados.Config_Campo_String(10, 'E', '0', ""); // DESCONTO BONIFICAÇÃO (10)

                    //TIPO DE EMISSÃO (CLIENTE OU BANCO)
                    if (Convert.ToInt32(_DT_Cedente.Rows[0]["Tipo_Emissao"]) == 1)
                        Detalhe += "2"; //CEDENTE
                    else
                        Detalhe += "1"; //BANCO

                    Detalhe += "N"; //REGISTRO DE DEBITO AUTOMATICO

                    Detalhe += util_dados.Config_Campo_String(10, 'E', ' ', ""); // BANCO (10)

                    Detalhe += util_dados.Config_Campo_String(1, 'E', ' ', ""); // RATEIO DE CREDITO (1)

                    Detalhe += "2"; //AVISO DE DEBITO AUTOMATICO (NÃO EMITE)

                    Detalhe += util_dados.Config_Campo_String(2, 'E', ' ', ""); // BANCO (2)

                    switch (Convert.ToInt32(_Boleto.Rows[i]["Movimento"]))
                    {
                        case 1: //REGISTRO DE TITULOS
                            Detalhe += "01";
                            break;

                        case 2: //ALTERAÇÃO DE VENCIMENTO
                            Detalhe += "06";
                            break;

                        case 3: //PEDIDO DE BAIXA
                            Detalhe += "02";
                            break;
                    }

                    if (_Boleto.Rows[i]["Documento"].ToString() != string.Empty)
                        Detalhe += util_dados.Config_Campo_String(10, 'D', ' ', _Boleto.Rows[i]["Documento"].ToString()); // DOCUMENTO (10)
                    else
                        Detalhe += util_dados.Config_Campo_String(10, 'D', ' ', _Boleto.Rows[i]["ID_Boleto"].ToString()); // DOCUMENTO (10)

                    Detalhe += util_dados.Config_Campo_String(6, 'E', ' ', util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Vencimento"].ToString()), 17).ToString()); // VENCIMENTO (6)
                    Detalhe += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_Boleto.Rows[i]["Valor"].ToString(), 32)); // VALOR (13)
                    Detalhe += util_dados.Config_Campo_String(3, 'D', '0', ""); // BANCO COBRANÇA (3)
                    Detalhe += util_dados.Config_Campo_String(5, 'D', '0', ""); // AGENCIA DEPOSITÁRIA (5)

                    Detalhe += "01"; // ESPECIE DE TITULO (01 - DUPLICATA)
                    Detalhe += "N"; // IDENTIFICAÇÃO

                    Detalhe += util_dados.Config_Campo_String(6, 'E', ' ', util_dados.Config_Data(Convert.ToDateTime(_Boleto.Rows[i]["Emissao"].ToString()), 17).ToString()); // EMISSÃO (6)

                    Detalhe += "0000"; //INSTRUÇÕES PERSONALIZADAS

                    double _Juros = util_dados.Calcula_Porcentagem(Convert.ToDouble(_Boleto.Rows[i]["Juros"]) / 30, Convert.ToDouble(_Boleto.Rows[i]["Valor"]));
                    if (_Juros < 0.01)
                        _Juros = 0.01;
                    Detalhe += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_Juros, 32)); //MORA POR DIA DE ATRASO (13)

                    Detalhe += util_dados.Config_Campo_String(6, 'E', '0', ""); // DATA LIMITE PARA DESCONTO (6)
                    Detalhe += util_dados.Config_Campo_String(13, 'E', '0', ""); //VALOR DESCONTO (13)
                    Detalhe += util_dados.Config_Campo_String(13, 'E', '0', ""); //VALOR IOF (13)
                    Detalhe += util_dados.Config_Campo_String(13, 'E', '0', ""); //VALOR ABATIMENTO (13)

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 11)
                        Detalhe += "01"; //CPF

                    if (util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString()).Length == 14)
                        Detalhe += "02"; //CNPJ

                    Detalhe += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_Boleto.Rows[i]["CNPJ_CPF"].ToString())); // CNPJ PAGADOR

                    Detalhe += util_dados.Config_Campo_String(40, 'D', ' ', _Boleto.Rows[i]["Nome_Razao"].ToString()); //NOME PAGADOR

                    string Endereco = _Boleto.Rows[i]["Logradouro"].ToString() + ", " + _Boleto.Rows[i]["NumeroEndereco"].ToString() + " " + _Boleto.Rows[i]["Complemento"].ToString() + " " + _Boleto.Rows[i]["Bairro"].ToString();
                    Detalhe += util_dados.Config_Campo_String(40, 'D', ' ', Endereco); //ENDEREÇO

                    Detalhe += util_dados.Config_Campo_String(12, 'D', ' ', _Boleto.Rows[i]["Instrucao_1"].ToString()); //1º INSTRUÇÃO CEDENTE

                    string[] CEP = _Boleto.Rows[i]["CEP"].ToString().Split('-');
                    Detalhe += util_dados.Config_Campo_String(5, 'D', '0', CEP[0]);
                    Detalhe += util_dados.Config_Campo_String(3, 'D', '0', CEP[1]);

                    Detalhe += util_dados.Config_Campo_String(60, 'D', ' ', ""); //SACADOR AVALISTA

                    Detalhe += _AuxRegistro.ToString().PadLeft(6, '0');  //NUMERO DE REGISTRO
                    _AuxRegistro++;

                    Detalhe = util_dados.Remove_CaractereEspecial(Detalhe);

                    _Remessa.Add(Detalhe);
                }
                #endregion

                #region TRAILLER
                Trailler += "9"; // IDENTIFICAÇÃO DO REGISTRO "9"
                Trailler += util_dados.Config_Campo_String(393, 'D', ' ', "");
                Trailler += _AuxRegistro.ToString().PadLeft(6, '0'); //NUMERO DE REGISTRO

                _Remessa.Add(Trailler);
                #endregion

                string Arquivo = _Boleto.Rows[0]["Arquivo"].ToString();

                if (!Directory.Exists(Parametro_Sistema.Caminho_Remessa))
                    Directory.CreateDirectory(Parametro_Sistema.Caminho_Remessa);

                string[] Empresa = Parametro_Empresa.Razao_Social_Empresa.Split(' ');

                File.WriteAllLines(Parametro_Sistema.Caminho_Remessa + @"\" + Empresa[0] + @"\" + Arquivo + ".REM", _Remessa.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}

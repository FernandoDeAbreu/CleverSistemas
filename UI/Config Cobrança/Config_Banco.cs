using System;
using System.IO;
using System.Drawing;
using Sistema.UTIL;

namespace Sistema.UI
{
    public class Config_Banco
    {
        #region VARIAVEIS DIVERSAS
        string Carteira = "";
        string NossoNumero = "";
        DateTime DataVencimento;
        double ValorBoleto = 0;
        int Moeda = 9;
        string Cedente = string.Empty;
        string Banco = string.Empty;
        string Agencia = string.Empty;
        string Conta = string.Empty;
        #endregion

        #region CONTRUTORES
        public Config_Banco()
        {
        }

        public Config_Banco(string strCarteira, string strNossoNumero, DateTime datDataVencimento, double dblValorBoleto, string strCedente,
            string strBanco)
        {
            Carteira = strCarteira;
            NossoNumero = strNossoNumero;
            DataVencimento = datDataVencimento;
            ValorBoleto = dblValorBoleto;
            Cedente = strCedente;
            Banco = strBanco;
        }

        public Config_Banco(string strCarteira, string strNossoNumero, DateTime datDataVencimento, double dblValorBoleto, string strCedente,
            string strBanco, string _Agencia)
        {
            Carteira = strCarteira;
            NossoNumero = strNossoNumero;
            DataVencimento = datDataVencimento;
            ValorBoleto = dblValorBoleto;
            Cedente = strCedente;
            Banco = strBanco;
            Agencia = _Agencia;
        }

        public Config_Banco(string strCarteira, string strNossoNumero, DateTime datDataVencimento, double dblValorBoleto, string strCedente,
    string strBanco, string _Agencia, string _Conta)
        {
            Carteira = strCarteira;
            NossoNumero = strNossoNumero;
            DataVencimento = datDataVencimento;
            ValorBoleto = dblValorBoleto;
            Cedente = strCedente;
            Banco = strBanco;
            Agencia = _Agencia;
            Conta = _Conta;
        }
        #endregion

        #region ROTINAS
        public void CodigoBarra(string strCodigo)
        {
            const int intFino = 1;
            const int intLargo = 3;
            const int intAltura = 50;

            int intLarguraFinal = 405;
            int intAlturaFinal = 50;
            int intAtual = 0;
            int intI;
            int intF;
            int intF1;
            int intF2;
            string strF;
            string strTexto;

            string[] strCodigoBarra = new string[100];

            Size dimensaoFinal = new Size(intLarguraFinal, intAlturaFinal);
            Image oIMGFinal = new Bitmap(intLarguraFinal, intAlturaFinal, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            SolidBrush oBPreto = new SolidBrush(Color.Black);
            SolidBrush oBBranco = new SolidBrush(Color.White);
            Graphics oGrap = Graphics.FromImage(oIMGFinal);
            oGrap.FillRectangle(oBBranco, new Rectangle(0, 0, intLarguraFinal, intAlturaFinal));

            strCodigoBarra[0] = "00110";
            strCodigoBarra[1] = "10001";
            strCodigoBarra[2] = "01001";
            strCodigoBarra[3] = "11000";
            strCodigoBarra[4] = "00101";
            strCodigoBarra[5] = "10100";
            strCodigoBarra[6] = "01100";
            strCodigoBarra[7] = "00011";
            strCodigoBarra[8] = "10010";
            strCodigoBarra[9] = "01010";

            for (intF1 = 9; intF1 >= 0; intF1--)
            {
                for (intF2 = 9; intF2 >= 0; intF2--)
                {
                    intF = intF1 * 10 + intF2;
                    strTexto = "";
                    for (int intCont = 0; intCont <= 4; intCont++)
                    {
                        strTexto += strCodigoBarra[intF1].Substring(intCont, 1) + strCodigoBarra[intF2].Substring(intCont, 1);
                    }
                    strCodigoBarra[intF] = strTexto;
                }
            }

            oGrap.FillRectangle(oBPreto, new Rectangle(0, 0, intFino, intAltura));
            intAtual += intFino;

            oGrap.FillRectangle(oBBranco, new Rectangle(intAtual, 0, intFino, intAltura));
            intAtual += intFino;

            oGrap.FillRectangle(oBPreto, new Rectangle(intAtual, 0, intFino, intAltura));
            intAtual += intFino;

            oGrap.FillRectangle(oBBranco, new Rectangle(intAtual, 0, intFino, intAltura));
            intAtual += intFino;

            strTexto = strCodigo;

            if ((strTexto.Length % 2) != 0)
                strTexto = "0" + strTexto;

            while (strTexto.Length > 0)
            {

                intI = Convert.ToInt32(strTexto.Substring(0, 2));
                strTexto = InverteString(InverteString(strTexto).Substring(0, strTexto.Length - 2));
                strF = strCodigoBarra[intI];

                for (int intCont = 0; intCont <= 9; intCont = intCont + 2)
                {
                    if (strF.ToString().Substring(intCont, 1) == "0")
                        intF1 = intFino;
                    else
                        intF1 = intLargo;
                    oGrap.FillRectangle(oBPreto, new Rectangle(intAtual, 0, intF1, intAltura));
                    intAtual += intF1;

                    if (strF.ToString().Substring(intCont + 1, 1) == "0")
                        intF2 = intFino;
                    else
                        intF2 = intLargo;

                    oGrap.FillRectangle(oBBranco, new Rectangle(intF2, 0, intFino, intAltura));
                    intAtual += intF2;
                }

            }

            oGrap.FillRectangle(oBPreto, new Rectangle(intAtual, 0, intLargo, intAltura));
            intAtual += intLargo;

            oGrap.FillRectangle(oBBranco, new Rectangle(intAtual, 0, intFino, intAltura));
            intAtual += intFino;

            oGrap.FillRectangle(oBPreto, new Rectangle(intAtual, 0, 1, intAltura));
            intAtual += 1;

            if (Directory.Exists(Parametro_Sistema.Caminho_Sistema + @"Temp\") == false)
                Directory.CreateDirectory(Parametro_Sistema.Caminho_Sistema + @"Temp\");

            if (File.Exists(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg"))
                File.Delete(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg");

            oIMGFinal.Save(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            oIMGFinal.Dispose();

        }

        public static string InverteString(string strString)
        {
            string strResult = "";

            for (int intCont = strString.Length - 1; intCont >= 0; intCont--)
                strResult += strString.Substring(intCont, 1);

            return strResult;
        }
        #endregion

        #region EMISSÃO DE BOLETO
        //SANTANDER HOMOLOGADO - 13/09/2016
        #region 033-SANTANDER
        #region MODELO LINHA DIGITAVEL
        ///	A Linha Digitavel para cobrança contém 44 posições dispostas da seguinte forma:
        ///   1º Grupo - 
        ///    01 a 03 -  3 - 033 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$) outra moedas 8
        ///    05 a 05 –  1 - Fixo 9
        ///    06 a 09 -  4 - Código cedente padrão santander
        ///    10 a 10 -  1 - Código DV do primeiro grupo
        ///   2º Grupo -
        ///    11 a 13 –  3 - Restante do código cedente
        ///    14 a 20 -  7 - 7 primeiros campos do nosso número
        ///    21 a 21 - 13 - Código DV do segundo grupo
        ///   3º Grupo -  
        ///    22 - 27 - 6 -  Restante do nosso número
        ///    28 - 28 - 1 - IOS  - Seguradoras(Se 7% informar 7. Limitado  a 9%) Demais clientes usar 0 
        ///    29 - 31 - 3 - Tipo de carteira
        ///    32 - 32 - 1 - Código DV do terceiro grupo
        ///   4º Grupo -
        ///    33 - 33 - 1 - Composto pelo DV do código de barras
        ///   5º Grupo -
        ///    34 - 36 - 4 - Fator de vencimento
        ///    37 - 44 - 10 - Valor do título
        #endregion
        public string Santander_LinhaDigitavel()
        {
            string nossoNumero = util_dados.FormatCode(NossoNumero, 12) + util_dados.Mod11_Santander(NossoNumero, 1);//13
            string codigCedente = util_dados.FormatCode(Cedente.ToString(), 7).ToString();

            #region Grupo1
            string codigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string codigoModeda = Moeda.ToString();//1
            string fixo = "9";//1
            string codigCedente1 = codigCedente.Substring(0, 4);//4
            string calculoDV1 = util_dados.Mod10_Santander(string.Format("{0}{1}{2}{3}", codigBanco, codigoModeda, fixo, codigCedente1)).ToString();//1
            string grupo1 = string.Format("{0}{1}{2}.{3}{4}", codigBanco, codigoModeda, fixo, codigCedente1, calculoDV1);
            #endregion

            #region Grupo2
            string codigCedente2 = codigCedente.Substring(4, 3);//3
            string nossoNumero1 = nossoNumero.Substring(0, 7);//7
            string calculoDV2 = util_dados.Mod10_Santander(string.Format("{0}{1}", codigCedente2, nossoNumero1)).ToString();
            string grupo2 = string.Format("{0}{1}{2}", codigCedente2, nossoNumero1, calculoDV2);
            grupo2 = " " + grupo2.Substring(0, 5) + "." + grupo2.Substring(5, 6);
            #endregion

            #region Grupo3
            string nossoNumero2 = nossoNumero.Substring(7, 6); //6
            string IOS = "0";//1
            string tipCarteira = Carteira.PadLeft(3, '0');//3
            string calculoDV3 = util_dados.Mod10_Santander(string.Format("{0}{1}{2}", nossoNumero2, IOS, tipCarteira)).ToString();//1
            string grupo3 = string.Format("{0}{1}{2}{3}", nossoNumero2, IOS, tipCarteira, calculoDV3);
            grupo3 = " " + grupo3.Substring(0, 5) + "." + grupo3.Substring(5, 6) + " ";
            #endregion

            #region Grupo4
            string DVcodigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string DVcodigMoeda = Moeda.ToString();//1
            string DVfatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString();//4
            string DVvalorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string DVfixo = "9";//1
            string DVcodigCedente = util_dados.FormatCode(Cedente.ToString(), 7).ToString();//7
            string DVnossoNumero = util_dados.FormatCode(NossoNumero, 12) + util_dados.Mod11_Santander(util_dados.FormatCode(NossoNumero, 12), 1);
            string DVIOS = "0";//1
            string DVtipCarteira = Carteira;//3;

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                DVcodigBanco, DVcodigMoeda, DVfatorVencimento, DVvalorNominal, DVfixo, DVcodigCedente, DVnossoNumero, DVIOS, DVtipCarteira);

            string grupo4 = util_dados.Mod11_Santander(calculoDVcodigo, 2) + " ";

            #endregion

            #region Grupo5

            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string grupo5 = string.Format("{0}{1}", fatorVencimento, valorNominal);
            //grupo5 = grupo5.Substring(0, 4) + " " + grupo5.Substring(4, 1)+" "+grupo5.Substring(5,9);



            #endregion

            return string.Format("{0}{1}{2}{3}{4}", grupo1, grupo2, grupo3, grupo4, grupo5);
        }

        public string Santander_CodigoBarra()
        {
            string codigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string codigMoeda = Moeda.ToString();//1
            string calculoDV = "";//1
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string fixo = "9";//1
            string codigCedente = util_dados.FormatCode(Cedente.ToString(), 7).ToString();//7
            string nossoNumero = util_dados.FormatCode(NossoNumero, 12) + util_dados.Mod11_Santander(util_dados.FormatCode(NossoNumero, 12), 1);//13
            string IOS = "0";//1
            string tipCarteira = Carteira;//3

            string CodigoBarra = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                codigBanco, codigMoeda, fatorVencimento, valorNominal, fixo, codigCedente, nossoNumero, IOS, tipCarteira);

            //calculoDV = util_dados.Mod11(CodigoBarra, 9, 0).ToString();
            calculoDV = util_dados.Mod11_Santander(CodigoBarra, 2).ToString();
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                codigBanco, codigMoeda, calculoDV, fatorVencimento, valorNominal, fixo, codigCedente, nossoNumero, IOS, tipCarteira);
        }

        public string Santander_NossoNumero(string _NossoNumero)
        {
            return util_dados.FormatCode(_NossoNumero, 12) + "-" + util_dados.Mod11_Santander(util_dados.FormatCode(_NossoNumero, 12), 1);//13
        }
        #endregion

        //SICOOB HOMOLOGADO - 11/06/2016
        #region 756 - SICOOB
        #region MODELO LINHA DIGITAVEL
        ///	A Linha Digitavel para cobrança contém 44 posições dispostas da seguinte forma:
        ///   1º Grupo - 
        ///    01 a 03 -  3 - 756 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$) outra moedas 8
        ///    05 a 05 –  1 - Código da carteira
        ///    06 a 09 -  4 - Código da Agencia
        ///    10 a 10 -  1 - Código DV do primeiro grupo
        ///   2º Grupo -
        ///    11 a 12 –  2 - Código da Modalidade
        ///    13 a 19 -  7 - Código do Cedente
        ///    20 a 20 -  1 - Nosso Numero
        ///    21 a 21 -  1 - Código DV do segundo grupo
        ///   3º Grupo -  
        ///    22 - 28 - 7 -  Restante do Nosso Numero
        ///    29 - 31 - 3 -  Numero da Parcela 001
        ///    32 - 32 - 1 - Código DV do terceiro grupo
        ///   4º Grupo -
        ///    33 - 33 - 1 - Composto pelo DV do código de barras
        ///   5º Grupo -
        ///    34 - 36 - 4 - Fator de vencimento
        ///    37 - 44 - 10 - Valor do título
        #endregion
        public string Sicoob_LinhaDigitavel()
        {
            string[] _auxAgencia = Agencia.Split('-');
            Agencia = _auxAgencia[0];

            string nossoNumero = Sicoob_NossoNumero(Agencia, Cedente, NossoNumero);//8
            string codigCedente = util_dados.FormatCode(Cedente.ToString(), 7).ToString();//7

            #region Grupo1
            string codigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string codigoModeda = Moeda.ToString();//1
            string codigCarteira = Carteira.Substring(0, 1); //1
            string codigoAgencia = util_dados.FormatCode(Agencia.ToString(), 4);//4
            string calculoDV1 = util_dados.Mod10_Sicoob(string.Format("{0}{1}{2}{3}", codigBanco, codigoModeda, codigCarteira, codigoAgencia)).ToString();//1
            string grupo1 = string.Format("{0}{1}{2}.{3}{4}", codigBanco, codigoModeda, codigCarteira, codigoAgencia, calculoDV1);
            #endregion

            #region Grupo2
            string codigoModalidade = Carteira.Substring(1, 2);//2
            string cedente = util_dados.FormatCode(Cedente.ToString(), 7);//7
            string NossoNumero1 = nossoNumero.Substring(0, 1); //1
            string calculoDV2 = util_dados.Mod10_Sicoob(string.Format("{0}{1}{2}", codigoModalidade, cedente, NossoNumero1)).ToString();
            string grupo2 = string.Format("{0}{1}{2}{3}", codigoModalidade, cedente, NossoNumero1, calculoDV2);
            grupo2 = " " + grupo2.Substring(0, 5) + "." + grupo2.Substring(5, 6);
            #endregion

            #region Grupo3
            string nossoNumero2 = nossoNumero.Substring(1, 7); //7
            string Parcela = "001";
            string calculoDV3 = util_dados.Mod10_Sicoob(string.Format("{0}{1}", nossoNumero2, Parcela)).ToString();//1
            string grupo3 = string.Format("{0}{1}{2}", nossoNumero2, Parcela, calculoDV3);
            grupo3 = " " + grupo3.Substring(0, 5) + "." + grupo3.Substring(5, 6) + " ";
            #endregion

            #region Grupo5
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string grupo5 = string.Format("{0}{1}", fatorVencimento, valorNominal);
            #endregion

            #region Grupo4

            string DVBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string DVMoeda = Moeda.ToString();//1
            string DVVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string DVvalorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string DVCarteira = Carteira.Substring(0, 1); //1
            string DVAgencia = util_dados.FormatCode(Agencia.ToString(), 4);//4
            string DVModalidade = Carteira.Substring(1, 2);//2
            string DVcedente = util_dados.FormatCode(Cedente.ToString(), 7);//7
            string DVNossoNumero = nossoNumero.Substring(0, 8);//8
            string DVParcela = "001";

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
            DVBanco, DVMoeda, DVVencimento, DVvalorNominal, DVCarteira, DVAgencia, DVModalidade, DVcedente, DVNossoNumero, DVParcela);

            //string calculoDVcodigo = string.Format("{0}{1}{2}{3}", grupo1, grupo2, grupo3, grupo5).Replace(".", "").Replace(" ", "");
            string grupo4 = util_dados.Mod11_Sicoob(calculoDVcodigo) + " ";
            #endregion

            return string.Format("{0}{1}{2}{3}{4}", grupo1, grupo2, grupo3, grupo4, grupo5);
        }

        public string Sicoob_CodigoBarra()
        {
            string[] _auxAgencia = Agencia.Split('-');
            Agencia = _auxAgencia[0];

            string codigBanco = Banco.ToString().PadLeft(3, '0');//3
            string codigMoeda = Moeda.ToString();//1
            string calculoDV = "";//1
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = ValorBoleto.ToString("f").Replace(",", "").Replace(".", "").PadLeft(10, '0'); //10
            string carteira = Carteira.Substring(0, 1); //1
            string agencia = Agencia; //4
            string Modalidade = Carteira.Substring(1, 2); //2
            string cedente = util_dados.FormatCode(Cedente.ToString(), 7).ToString();//7
            string nossoNumero = Sicoob_NossoNumero(Agencia, Cedente, NossoNumero);//8
            string Parcela = "001";

            string CodigoBarra = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                codigBanco, codigMoeda, fatorVencimento, valorNominal, carteira, agencia, Modalidade, cedente, nossoNumero, Parcela);

            calculoDV = util_dados.Mod11_Sicoob(CodigoBarra).ToString();
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                codigBanco, codigMoeda, calculoDV, fatorVencimento, valorNominal, carteira, agencia, Modalidade, cedente, nossoNumero, Parcela);
        }

        public string Sicoob_NossoNumero(string _Agencia, string _Cedente, string _NossoNumero)
        {
            string[] _auxAgencia = _Agencia.Split('-');
            return util_dados.FormatCode(_NossoNumero, 7) + Sicoob_DVNossoNumero(_auxAgencia[0].PadLeft(4, '0') + _Cedente.PadLeft(10, '0') + _NossoNumero.PadLeft(7, '0'));//8
        }

        public static int Sicoob_DVNossoNumero(string _NossoNumero)
        {
            string Peso = "319731973197319731973";
            int Soma = 0;
            int Resto;

            for (int i = _NossoNumero.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(_NossoNumero[i]);
                int P = Convert.ToInt32(Peso[i].ToString());
                Soma += (Convert.ToInt32(aux) * P);
            }

            Resto = Soma % 11;
            switch (Resto)
            {
                case 1:
                    return 0;

                case 0:
                    return 0;

                default:
                    return 11 - Resto;
            }
        }
        #endregion

        #region 104 - CAIXA
        #region MODELO LINHA DIGITAVEL
        ///	A Linha Digitavel para cobrança contém 44 posições dispostas da seguinte forma:
        ///   1º Grupo - 
        ///    01 a 03 -  3 - 104 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$) outra moedas 8
        ///    05 a 09 –  1 - Campo Livre Barra (5 Posições)
        ///    10 a 10 -  1 - Código DV do primeiro grupo
        ///   2º Grupo -
        ///    11 a 20 –  2 - Campo Livre Barra (10 Posições)
        ///    21 a 21 -  1 - Código DV do segundo grupo
        ///   3º Grupo -  
        ///    22 - 31 - 7 -  Campo Livre Barra (10 Posições)
        ///    32 - 32 - 1 - Código DV do terceiro grupo
        ///   4º Grupo -
        ///    33 - 33 - 1 - Composto pelo DV do código de barras
        ///   5º Grupo -
        ///    34 - 36 - 4 - Fator de vencimento
        ///    37 - 44 - 10 - Valor do título
        #endregion
        public string Caixa_LinhaDigitavel()
        {
            string nossoNumero = util_dados.FormatCode(NossoNumero, 15);//15
            string codigCedente = util_dados.FormatCode(Cedente, 6);
            string DV_Cedente = util_dados.Mod11_Caixa(Cedente).ToString();

            #region Grupo1
            string codigBanco = util_dados.FormatCode(Banco, 3);//3
            string codigoModeda = Moeda.ToString();//1
            string campolivre1 = Caixa_CampoLivre(Cedente, NossoNumero, Carteira).Substring(0, 5);//5
            string calculoDV1 = util_dados.Mod10_Caixa(string.Format("{0}{1}{2}", codigBanco, codigoModeda, campolivre1)).ToString();//1
            string grupo1 = string.Format("{0}{1}{2}.{3}{4}", codigBanco, codigoModeda, campolivre1.Substring(0, 1), campolivre1.Substring(1), calculoDV1);
            #endregion

            #region Grupo2
            string campolivre2 = Caixa_CampoLivre(Cedente, NossoNumero, Carteira).Substring(5, 10);//10
            string calculoDV2 = util_dados.Mod10_Caixa(campolivre2).ToString();
            string grupo2 = string.Format("{0}{1}", campolivre2, calculoDV2);
            grupo2 = " " + grupo2.Substring(0, 5) + "." + grupo2.Substring(5, 6);
            #endregion

            #region Grupo3
            string campolivre3 = Caixa_CampoLivre(Cedente, NossoNumero, Carteira).Substring(15);//10
            string calculoDV3 = util_dados.Mod10_Caixa(campolivre3).ToString();
            string grupo3 = string.Format("{0}{1}", campolivre3, calculoDV3);
            grupo3 = " " + grupo3.Substring(0, 5) + "." + grupo3.Substring(5, 6) + " ";
            #endregion

            #region Grupo4
            string DVcodigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string DVcodigMoeda = Moeda.ToString();//1
            string DVfatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString();//4
            string DVvalorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string CampoLivre = Caixa_CampoLivre(Cedente, NossoNumero, Carteira);//25

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}",
                DVcodigBanco, DVcodigMoeda, DVfatorVencimento, DVvalorNominal, CampoLivre);

            string grupo4 = util_dados.Mod11_Caixa_CodBarra(calculoDVcodigo) + " ";
            #endregion

            #region Grupo5
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string grupo5 = string.Format("{0}{1}", fatorVencimento, valorNominal);
            #endregion

            return string.Format("{0}{1}{2}{3}{4}", grupo1, grupo2, grupo3, grupo4, grupo5);
        }

        public string Caixa_CodigoBarra()
        {
            string codigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string codigMoeda = Moeda.ToString();//1
            string calculoDV = "";//1
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString();//4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string CampoLivre = Caixa_CampoLivre(Cedente, NossoNumero, Carteira);//25

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}",
                codigBanco, codigMoeda, fatorVencimento, valorNominal, CampoLivre);

            calculoDV = util_dados.Mod11_Caixa_CodBarra(calculoDVcodigo).ToString();
            return string.Format("{0}{1}{2}{3}{4}{5}",
                codigBanco, codigMoeda, calculoDV, fatorVencimento, valorNominal, CampoLivre);
        }

        public string Caixa_NossoNumero(string _NossoNumero, string _Carteira)
        {
            string aux = _Carteira +
                "4" + //Modalidade emissão cedente
                util_dados.FormatCode(_NossoNumero, 15);

            return aux + "-" + util_dados.Mod11_Caixa(aux);//17
        }

        public string Caixa_CampoLivre(string _Cedente, string _NossoNumero, string _Modalidade)
        {
            string Campo = util_dados.FormatCode(_Cedente, 6) +
                util_dados.Mod11_Caixa(util_dados.FormatCode(_Cedente, 6)) +
                util_dados.FormatCode(_NossoNumero, 15).Substring(0, 3) +
                _Modalidade +
                util_dados.FormatCode(_NossoNumero, 15).Substring(3, 3) +
                "4" + //Modalidade emissão cedente
                util_dados.FormatCode(_NossoNumero, 15).Substring(6);

            return Campo + util_dados.Mod11_Caixa(Campo);//25
        }

        public static int Caixa_DVNossoNumeroa(string _NossoNumero)
        {
            string Peso = "319731973197319731973";
            int Soma = 0;
            int Resto;

            for (int i = _NossoNumero.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(_NossoNumero[i]);
                int P = Convert.ToInt32(Peso[i].ToString());
                Soma += (Convert.ToInt32(aux) * P);
            }

            Resto = Soma % 11;
            switch (Resto)
            {
                case 1:
                    return 0;

                case 0:
                    return 0;

                default:
                    return 11 - Resto;
            }
        }

        public static int Caixa_DVCedente(string _Cedente)
        {
            return util_dados.Mod11_Caixa(util_dados.FormatCode(_Cedente, 6));
        }
        #endregion

        //BRADESCO HOMOLOGANDO
        #region 237 - BRADESCO
        #region MODELO LINHA DIGITAVEL
        ///	A Linha Digitavel para cobrança contém 44 posições dispostas da seguinte forma:
        ///   1º Grupo - 
        ///    01 a 03 -  3 - 237 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$) outra moedas 8
        ///    05 a 09 –  1 - Campo Livre Barra (5 Posições)
        ///    10 a 10 -  1 - Código DV do primeiro grupo
        ///   2º Grupo -
        ///    11 a 20 –  2 - Campo Livre Barra (10 Posições)
        ///    21 a 21 -  1 - Código DV do segundo grupo
        ///   3º Grupo -  
        ///    22 - 31 - 7 -  Campo Livre Barra (10 Posições)
        ///    32 - 32 - 1 - Código DV do terceiro grupo
        ///   4º Grupo -
        ///    33 - 33 - 1 - Composto pelo DV do código de barras
        ///   5º Grupo -
        ///    34 - 36 - 4 - Fator de vencimento
        ///    37 - 44 - 10 - Valor do título
        #endregion
        public string Bradesco_LinhaDigitavel()
        {
            string nossoNumero = util_dados.FormatCode(NossoNumero.Substring(0, 2) + NossoNumero.Substring(NossoNumero.Length - 9, 9), 11);//11

            string[] _Conta = Conta.Split('-');
            string conta = util_dados.FormatCode(_Conta[0], 7);

            string DV_Cedente = util_dados.Mod11_Caixa(Cedente).ToString();

            #region Grupo1
            string codigBanco = util_dados.FormatCode(Banco, 3);//3
            string codigoModeda = Moeda.ToString();//1
            string campolivre1 = Bradesco_CampoLivre(Agencia, Carteira, nossoNumero, conta).Substring(0, 5);//5
            string calculoDV1 = util_dados.Mod10_Bradesco(string.Format("{0}{1}{2}", codigBanco, codigoModeda, campolivre1)).ToString();//1
            string grupo1 = string.Format("{0}{1}{2}.{3}{4}", codigBanco, codigoModeda, campolivre1.Substring(0, 1), campolivre1.Substring(1), calculoDV1);
            #endregion

            #region Grupo2
            string campolivre2 = Bradesco_CampoLivre(Agencia, Carteira, nossoNumero, conta).Substring(5, 10);//10
            string calculoDV2 = util_dados.Mod10_Bradesco(campolivre2).ToString();
            string grupo2 = string.Format("{0}{1}", campolivre2, calculoDV2);
            grupo2 = " " + grupo2.Substring(0, 5) + "." + grupo2.Substring(5, 6);
            #endregion

            #region Grupo3
            string campolivre3 = Bradesco_CampoLivre(Agencia, Carteira, nossoNumero, conta).Substring(15);//10
            string calculoDV3 = util_dados.Mod10_Bradesco(campolivre3).ToString();
            string grupo3 = string.Format("{0}{1}", campolivre3, calculoDV3);
            grupo3 = " " + grupo3.Substring(0, 5) + "." + grupo3.Substring(5, 6) + " ";
            #endregion

            #region Grupo4
            string DVcodigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string DVcodigMoeda = Moeda.ToString();//1
            string DVfatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString();//4
            string DVvalorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string CampoLivre = Bradesco_CampoLivre(Agencia, Carteira, nossoNumero, conta);//25

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}", DVcodigBanco, DVcodigMoeda, DVfatorVencimento, DVvalorNominal, CampoLivre);

            string grupo4 = util_dados.Mod11_Bradesco_CodBarra(calculoDVcodigo) + " ";
            #endregion

            #region Grupo5
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString(); //4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string grupo5 = string.Format("{0}{1}", fatorVencimento, valorNominal);
            #endregion

            return string.Format("{0}{1}{2}{3}{4}", grupo1, grupo2, grupo3, grupo4, grupo5);
        }

        public string Bradesco_CodigoBarra()
        {
            string nossoNumero = util_dados.FormatCode(NossoNumero.Substring(0, 2) + NossoNumero.Substring(NossoNumero.Length - 9, 9), 11);//11
            string conta = util_dados.FormatCode(Conta.Substring(0, Conta.IndexOf('-')), 7);

            string codigBanco = util_dados.FormatCode(Banco.ToString(), 3);//3
            string codigMoeda = Moeda.ToString();//1
            string calculoDV = "";//1
            string fatorVencimento = util_dados.FatorVencimento(DataVencimento).ToString();//4
            string valorNominal = util_dados.FormatCode(ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string CampoLivre = Bradesco_CampoLivre(Agencia, Carteira, nossoNumero, conta);//25

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}", codigBanco, codigMoeda, fatorVencimento, valorNominal, CampoLivre);

            calculoDV = util_dados.Mod11_Bradesco_CodBarra(calculoDVcodigo).ToString();
            return string.Format("{0}{1}{2}{3}{4}{5}", codigBanco, codigMoeda, calculoDV, fatorVencimento, valorNominal, CampoLivre);
        }

        public string Bradesco_NossoNumero(string _NossoNumero, string _Carteira)
        {
            string aux = _Carteira + util_dados.FormatCode(_NossoNumero, 11);

            return _Carteira + @"/" + util_dados.FormatCode(_NossoNumero, 11) + "-" + util_dados.Mod11_Bradesco_NossoNumero(aux);//11
        }

        public string Bradesco_CampoLivre(string _Agencia, string _Carteira, string _NossoNumero, string _Conta)
        {
            string[] _Ag = _Agencia.Split('-');

            string Campo = string.Empty;
            Campo += util_dados.Config_Campo_String(4, 'E', '0', _Ag[0]);
            Campo += util_dados.Config_Campo_String(2, 'E', '0', _Carteira);
            Campo += util_dados.Config_Campo_String(11, 'E', '0', _NossoNumero);
            Campo += util_dados.Config_Campo_String(7, 'E', '0', _Conta);
            Campo += "0";

            return Campo;
        }
        #endregion
        #endregion
    }
}

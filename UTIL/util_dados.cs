using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Sistema.UTIL
{

    public static class util_dados
    {
        #region TRATAMENTO E CONFIRMAÇÃO DE DADOS
        /// <summary>
        /// REMOVE ./,- e ESPAÇO
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string Conf_strDoc_NFe(object Str)
        {
            string Doc = Convert.ToString(Str);
            string Campo = null;
            Campo = Doc.Replace(".", "");
            Campo = Campo.Replace("/", "");
            Campo = Campo.Replace(",", "");
            Campo = Campo.Replace("-", "");
            Campo = Campo.Replace(" ", "");
            return Campo;
        }

        /// <summary>
        /// Configura Numero Decimal Quantidade de Casas Decimais
        /// <para>0 - 0.000</para>
        /// <para>1 - 0.000,0</para>
        /// <para>2 - 0.000,00</para>
        /// <para>3 - 0.000,000</para>
        /// <para>4 - 0.000,0000</para>
        /// 
        /// <para>Para DataGrid</para>
        /// <para>10 - 0000</para>
        /// <para>11 - 0000,0</para>
        /// <para>12 - 0000,00</para>
        /// <para>13 - 0000,000</para>
        /// <para>14 - 0000,0000</para>
        /// 
        /// <para>Para NFe</para>
        /// <para>20 - 0000</para>
        /// <para>21 - 0000.0</para>
        /// <para>22 - 0000.00</para>
        /// <para>23 - 0000.000</para>
        /// <para>24 - 0000.0000</para>
        /// 
        /// <para>Arquivo Remessa e Sintegra</para>
        /// <para>32 - 2 casa decimal sem ponto/virgula</para>
        /// <para>33 - 3 casa decimal sem ponto/virgula</para>
        /// </summary>
        public static string ConfigNumDecimal(object Valor, int Dec)
        {
            if (Valor.ToString().Trim() == string.Empty)
                Valor = 0;

            double Numero = 0;
            if (!double.TryParse(Valor.ToString(), out Numero))
                Valor = 0;

            string Mascara = null;
            Mascara = "";
            switch (Dec)
            {
                case 0:
                    Mascara = "{0:N0}";
                    break;
                case 1:
                    Mascara = "{0:N1}";
                    break;
                case 2:
                    Mascara = "{0:N2}";
                    break;
                case 3:
                    Mascara = "{0:N3}";
                    break;
                case 4:
                    Mascara = "{0:N4}";
                    break;
                case 10:
                    Mascara = "{0:F0}";
                    break;
                case 11:
                    Mascara = "{0:F1}";
                    break;
                case 12:
                    Mascara = "{0:F2}";
                    break;
                case 13:
                    Mascara = "{0:F3}";
                    break;
                case 14:
                    Mascara = "{0:F4}";
                    break;
                case 20:
                    Mascara = "{0:F0}";
                    break;
                case 21:
                    Mascara = "{0:F1}";
                    break;
                case 22:
                    Mascara = "{0:F2}";
                    break;
                case 23:
                    Mascara = "{0:F3}";
                    break;
                case 24:
                    Mascara = "{0:F4}";
                    break;
                case 32:
                    Mascara = "{0:N2}";
                    break;
                case 33:
                    Mascara = "{0:N3}";
                    break;
                case 35:
                    Mascara = "{0:N5}";
                    break;
            }
            if (Dec == 10 ||
                Dec == 11 ||
                Dec == 12 ||
                Dec == 13 ||
                Dec == 14)
                return String.Format(Mascara, Convert.ToDouble(Valor)).Replace(",", ".");

            if (Dec == 32 || Dec == 33)
                return String.Format(Mascara, Convert.ToDouble(Valor)).Replace(",", "").Replace(".", "");

            return String.Format(Mascara, Convert.ToDouble(Valor));
        }

        public static int Verifica_int(string str)
        {
            try
            {
                int result = 0;
                if (int.TryParse(str, out result))
                    return int.Parse(str);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool Verifica_Data(string str)
        {
            try
            {
                DateTime ValidaData;

                DateTime.TryParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
                if (ValidaData == DateTime.MinValue)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Remove_CaractereEspecial(object Str)
        {
            string Campo = Convert.ToString(Str);
            string Letra;
            string Resposta;
            Resposta = "";
            if (Campo.Length > 0)
            {
                for (int i = 0; i < Campo.Length; i++)
                {
                    Letra = Campo[i].ToString();
                    switch (Letra)
                    {
                        case "Á":
                        case "À":
                        case "Ã":
                        case "Â":
                        case "Ä":
                            Letra = "A";
                            break;
                        case "É":
                        case "È":
                        case "Ê":
                        case "Ë":
                            Letra = "E";
                            break;
                        case "Í":
                        case "Ì":
                        case "Î":
                        case "Ï":
                            Letra = "I";
                            break;
                        case "Ó":
                        case "Ò":
                        case "Õ":
                        case "Ô":
                        case "Ö":
                            Letra = "O";
                            break;
                        case "Ú":
                        case "Ù":
                        case "Û":
                        case "Ü":
                            Letra = "U";
                            break;
                        case "Ç":
                            Letra = "C";
                            break;
                        case "º":
                        case "°":
                            Letra = "O";
                            break;
                        case "ª":
                            Letra = "A";
                            break;
                        case ",":
                            Letra = ".";
                            break;

                        case "á":
                        case "à":
                        case "ã":
                        case "â":
                        case "ä":
                            Letra = "a";
                            break;
                        case "é":
                        case "è":
                        case "ê":
                        case "ë":
                            Letra = "e";
                            break;
                        case "í":
                        case "ì":
                        case "î":
                        case "ï":
                            Letra = "i";
                            break;
                        case "ó":
                        case "ò":
                        case "õ":
                        case "ô":
                        case "ö":
                            Letra = "o";
                            break;
                        case "ú":
                        case "ù":
                        case "û":
                        case "ü":
                            Letra = "u";
                            break;
                        case "ç":
                            Letra = "c";
                            break;
                        case "$":
                            Letra = "S";
                            break;
                    }
                    Resposta = Resposta + Letra;
                }
            }
            return Resposta;
        }

        public static long Verifica_int64(string str)
        {
            try
            {
                long result = 0;
                if (Int64.TryParse(str, out result))
                    return Convert.ToInt64(str);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double Verifica_Double(string str)
        {
            try
            {
                double Num = 0;
                if (str == null ||
                    str == "" ||
                    !double.TryParse(str, out Num))
                    return 0;

                return Convert.ToDouble(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double Verifica_Porcentagem(double Valor_total, double ValorcomDesconto)
        {
            try
            {
                double Porcetagem = 0;

                Porcetagem = (1 - (ValorcomDesconto / Valor_total)) * 100;

                return Porcetagem;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool Verifica_email(string _email)
        {
            try
            {
                Regex expressaoRegex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (expressaoRegex.IsMatch(_email))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Verifica_CPF_CNPJ(string str)
        {
            try
            {
                if (str.Replace(".", "").Replace("/", "").Replace("-", "").Length == 11)
                {
                    string valor = str.Replace(".", "").Replace("-", "");
                    if (valor.Length != 11)
                        return false;
                    bool igual = true;
                    for (int i = 1; i < 11 && igual; i++)
                        if (valor[i] != valor[0])
                            igual = false;
                    if (igual || valor == "12345678909")
                        return false;
                    int[] numeros = new int[11];
                    for (int i = 0; i < 11; i++)
                        numeros[i] = int.Parse(
                              valor[i].ToString());
                    int soma = 0;
                    for (int i = 0; i < 9; i++)
                        soma += (10 - i) * numeros[i];
                    int resultado = soma % 11;
                    if (resultado == 1 || resultado == 0)
                    {
                        if (numeros[9] != 0)
                            return false;
                    }
                    else if (numeros[9] != 11 - resultado)
                        return false;
                    soma = 0;
                    for (int i = 0; i < 10; i++)
                        soma += (11 - i) * numeros[i];
                    resultado = soma % 11;
                    if (resultado == 1 || resultado == 0)
                    {
                        if (numeros[10] != 0)
                            return false;
                    }
                    else
                        if (numeros[10] != 11 - resultado)
                        return false;
                    return true;
                }
                else
                {
                    string CNPJ = str.Replace(".", "").Replace("/", "").Replace("-", "");
                    int[] digitos, soma, resultado;
                    int nrDig;
                    string ftmt;
                    bool[] CNPJOk;
                    ftmt = "6543298765432";
                    digitos = new int[14];
                    soma = new int[2];
                    soma[0] = 0;
                    soma[1] = 0;
                    resultado = new int[2];
                    resultado[0] = 0;
                    resultado[1] = 0;
                    CNPJOk = new bool[2];
                    CNPJOk[0] = false;
                    CNPJOk[1] = false;
                    try
                    {
                        for (nrDig = 0; nrDig < 14; nrDig++)
                        {
                            digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                            if (nrDig <= 11)
                                soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                            if (nrDig <= 12)
                                soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                        }
                        for (nrDig = 0; nrDig < 2; nrDig++)
                        {
                            resultado[nrDig] = (soma[nrDig] % 11);
                            if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                                CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                            else
                                CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                        }
                        return (CNPJOk[0] && CNPJOk[1]);
                    }
                    catch
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Digita_CNPJ_CPF(string strCPF_CNPJ, int Tipo)
        {
            try
            {
                switch (Tipo)
                {
                    case 1:
                        if (strCPF_CNPJ.Trim().Length == 2)
                            strCPF_CNPJ = strCPF_CNPJ + ".";

                        if (strCPF_CNPJ.Trim().Length == 6)
                            strCPF_CNPJ = strCPF_CNPJ + ".";

                        if (strCPF_CNPJ.Trim().Length == 10)
                            strCPF_CNPJ = strCPF_CNPJ + "/";

                        if (strCPF_CNPJ.Trim().Length == 15)
                            strCPF_CNPJ = strCPF_CNPJ + "-";
                        break;

                    case 2:
                        if (strCPF_CNPJ.Trim().Length == 3)
                            strCPF_CNPJ = strCPF_CNPJ + ".";

                        if (strCPF_CNPJ.Trim().Length == 7)
                            strCPF_CNPJ = strCPF_CNPJ + ".";

                        if (strCPF_CNPJ.Trim().Length == 11)
                            strCPF_CNPJ = strCPF_CNPJ + "-";
                        break;
                }
                return strCPF_CNPJ;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string Digita_CEI(string strCEI)
        {

            if (strCEI.Trim().Length == 2)
                strCEI = strCEI + ".";

            if (strCEI.Trim().Length == 6)
                strCEI = strCEI + ".";

            if (strCEI.Trim().Length == 12)
                strCEI = strCEI + "/";

            return strCEI;
        }

        public static string Conf_CPF_CNPJ(string _CPF_CNPJ, Documento _Doc)
        {
            if (_CPF_CNPJ.Length != 11 &&
                _CPF_CNPJ.Length != 14)
                return string.Empty;

            if (_Doc == Documento.CNPJ)
                _CPF_CNPJ = string.Format("{0}.{1}.{2}/{3}-{4}", _CPF_CNPJ.Substring(0, 2), _CPF_CNPJ.Substring(2, 3), _CPF_CNPJ.Substring(5, 3), _CPF_CNPJ.Substring(8, 4), _CPF_CNPJ.Substring(12, 2));

            if (_Doc == Documento.CPF)
                _CPF_CNPJ = string.Format("{0}.{1}.{2}-{3}", _CPF_CNPJ.Substring(0, 3), _CPF_CNPJ.Substring(3, 3), _CPF_CNPJ.Substring(6, 3), _CPF_CNPJ.Substring(9, 2));

            return _CPF_CNPJ;
        }

        public static string Retorna_Numero(string _str)
        {
            _str = _str.Replace(".", "");
            _str = _str.Replace("-", "");
            _str = _str.Replace("/", "");
            _str = _str.Replace(",", "");

            return _str;
        }

        public static string RemoveAspa(string str)
        {
            while (str.IndexOf("  ") >= 0)
                str = str.Replace("  ", " ");

            return str.Replace("'", "").TrimEnd().TrimStart();
        }

        public static double Calcula_Campo_DT(DataTable DT, string item)
        {
            DataRow DR = null;
            double aux = 0;
            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                DR = DT.Rows[i];
                aux = aux + util_dados.Verifica_Double(DR[item].ToString());
            }
            return aux;
        }

        public static double Calcula_Aliquota_NF_CF(DataTable DT, string _Valor, string _Porcentagem)
        {
            DataRow DR = null;
            double aux = 0;
            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                DR = DT.Rows[i];
                aux = aux + Calcula_Porcentagem(util_dados.Verifica_Double(DR[_Porcentagem].ToString()), util_dados.Verifica_Double(DR[_Valor].ToString()));
            }
            return aux;
        }

        public static double Calcula_Porcentagem(double Porcentagem, double Valor)
        {
            return (Retorna_Porcentagem(Porcentagem) * (Valor));
        }

        public static double CalculaMargem(double dblCusto, double dblValor)
        {
            if (dblCusto == 0)
                return 0;

            return (dblValor - dblCusto) / dblValor * 100;
        }

        public static double CalculaValor(double dblCusto, double dblMargem)
        {
            if (dblCusto == 0)
                return 0;

            return (dblCusto / ((dblMargem - 100) / 100) * -1);
        }

        public static double Retorna_Porcentagem(double Valor)
        {
            double aux = 0;
            aux = Valor / 100;
            return aux;
        }

        public static string Calcula_Desc_Acres(string _Desc_Acres, string _Valor)
        {
            try
            {
                string _aux = _Desc_Acres;

                if (_Desc_Acres.ToUpper().IndexOf("P") != -1 ||
                    _Desc_Acres.IndexOf("%") != -1 ||
                    Parametro_Venda.Desconto_Padrao == 2)
                {
                    _aux = util_dados.ConfigNumDecimal(Convert.ToDouble(_Valor) * (Convert.ToDouble(_Desc_Acres.ToUpper().Replace("P", "").Replace("%", "")) / 100), 2);
                }

                return _aux;
            }
            catch (Exception)
            {
                return "0,00";
            }
        }

        public static double Calcula_Juro(double _Valor, double _Tarifa, DateTime _DataVencimento, DateTime _DataAtual)
        {
            try
            {
                TimeSpan Periodo = _DataAtual - _DataVencimento;

                int Dias = Periodo.Days;
                double Juros_dia = Convert.ToDouble(util_dados.ConfigNumDecimal(_Valor * ((_Tarifa / 30) / 100), 2));

                return (Juros_dia * Dias);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int Calcula_dias_Data(DateTime DataInicial, DateTime DataFinal)
        {
            TimeSpan Dias = Convert.ToDateTime(DataFinal) - Convert.ToDateTime(DataInicial);
            return Dias.Days;
        }

        public static short NumDecimal(short Keyascii)
        {
            short retorno = 0;
            string str = "1234567890,-";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
                case 13:
                    retorno = Keyascii;
                    break;
                case 32:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static short NumDecimalPorcentagem(short Keyascii)
        {
            short retorno = 0;
            string str = "1234567890,%Pp";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
                case 13:
                    retorno = Keyascii;
                    break;
                case 32:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static short NumInteiro(short Keyascii)
        {
            short retorno = 0;
            string str = "1234567890";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
                case 13:
                    retorno = Keyascii;
                    break;
                case 32:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static short NumInteiro_DOC(short Keyascii)
        {
            short retorno = 0;
            string str = "1234567890.-/XISENTOxisento";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
                case 13:
                    retorno = Keyascii;
                    break;
                case 32:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static short NumInteiro_Parc(short Keyascii)
        {
            short retorno = 0;
            string str = "1234567890/";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
                case 13:
                    retorno = Keyascii;
                    break;
                case 32:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static int Email(short Keyascii)
        {
            short retorno = 0;
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.@_-";
            char aux = Convert.ToChar(Keyascii);

            if (str.IndexOf(aux) != -1)
            {
                retorno = Keyascii;
            }
            else
            {
                retorno = 0;
            }
            switch (Keyascii)
            {
                case 8:
                    retorno = Keyascii;
                    break;
            }
            return retorno;
        }

        public static List<int> RetornaParcela(string _aux)
        {
            try
            {
                List<int> Parcela = new List<int>();
                string aux = string.Empty;
                _aux = _aux.Replace(@"/", "*") + "*";

                for (int i = 0; i <= _aux.Length - 1; i++)
                {
                    if (_aux[i].ToString() == "*")
                    {
                        Parcela.Add(Convert.ToInt32(aux));
                        aux = string.Empty;
                    }
                    else
                        aux += _aux[i].ToString();
                }
                return Parcela;
            }
            catch (Exception)
            {
                List<int> Parcela = new List<int>();
                Parcela.Add(0);
                return Parcela;
            }
        }

        public static int Retorna_ID_UF(string _UF)
        {
            switch (_UF)
            {
                case "RO":
                    return 11;
                case "AC":
                    return 12;
                case "AM":
                    return 13;
                case "RR":
                    return 14;
                case "PA":
                    return 15;
                case "AP":
                    return 16;
                case "TO":
                    return 17;
                case "MA":
                    return 21;
                case "PI":
                    return 22;
                case "CE":
                    return 23;
                case "RN":
                    return 24;
                case "PB":
                    return 25;
                case "PE":
                    return 26;
                case "AL":
                    return 27;
                case "SE":
                    return 28;
                case "BA":
                    return 29;
                case "MG":
                    return 31;
                case "ES":
                    return 32;
                case "RJ":
                    return 33;
                case "SP":
                    return 35;
                case "PR":
                    return 41;
                case "SC":
                    return 42;
                case "RS":
                    return 43;
                case "MS":
                    return 50;
                case "MT":
                    return 51;
                case "GO":
                    return 52;
                case "DF":
                    return 53;
                default:
                    return 0;
            }
        }

        public static DateTime Retorna_Dia_Faturamento(string _Faturamento)
        {
            string[] _Dia_Fatu = _Faturamento.Split('/');
            int _Dia = 1;
            bool ProximoMes = false;

            if (_Dia_Fatu.Length == 1)
            {
                if (Convert.ToInt32(_Dia_Fatu[0]) >= DateTime.Now.Day)
                {
                    _Dia = Convert.ToInt32(_Dia_Fatu[0]);
                    ProximoMes = false;
                }
                else
                {
                    _Dia = Convert.ToInt32(_Dia_Fatu[0]);
                    ProximoMes = true;
                }
            }

            if (_Dia_Fatu.Length > 1)
            {
                for (int i = 0; i <= _Dia_Fatu.Length - 1; i++)
                    if (Convert.ToInt32(_Dia_Fatu[i]) >= DateTime.Now.Day &&
                        i <= _Dia_Fatu.Length - 1)
                    {
                        _Dia = Convert.ToInt32(_Dia_Fatu[i]);
                        ProximoMes = false;
                        break;
                    }
                    else
                    {
                        _Dia = Convert.ToInt32(_Dia_Fatu[i]);
                        ProximoMes = true;
                    }
            }

            if (ProximoMes == true)
                return Convert.ToDateTime(_Dia + "/" + DateTime.Now.AddMonths(1).Month + "/" + DateTime.Now.AddMonths(1).Year);
            else
                return Convert.ToDateTime(_Dia + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
        }

        public static string Retorna_UF_Abreviado(int _ID_UF)
        {
            switch (_ID_UF)
            {
                case 11:
                    return "RO";
                case 12:
                    return "AC";
                case 13:
                    return "AM";
                case 14:
                    return "RR";
                case 15:
                    return "PA";
                case 16:
                    return "AP";
                case 17:
                    return "TO";
                case 21:
                    return "MA";
                case 22:
                    return "PI";
                case 23:
                    return "CE";
                case 24:
                    return "RN";
                case 25:
                    return "PB";
                case 26:
                    return "PE";
                case 27:
                    return "AL";
                case 28:
                    return "SE";
                case 29:
                    return "BA";
                case 31:
                    return "MG";
                case 32:
                    return "ES";
                case 33:
                    return "RJ";
                case 35:
                    return "SP";
                case 41:
                    return "PR";
                case 42:
                    return "SC";
                case 43:
                    return "RS";
                case 50:
                    return "MS";
                case 51:
                    return "MT";
                case 52:
                    return "GO";
                case 53:
                    return "DF";
                default:
                    return string.Empty;
            }
        }

        public static Tipo_Cheque Retorna_TipoCheque(int _Tipo)
        {
            switch (_Tipo)
            {
                case 1:
                    return Tipo_Cheque.DISPONIVEL;
                case 2:
                    return Tipo_Cheque.DEVOLVIDO;
                case 3:
                    return Tipo_Cheque.DEPOSITADO;
                case 4:
                    return Tipo_Cheque.PAGTOTERCEIRO;
                case 5:
                    return Tipo_Cheque.COMPENSADO;
                default:
                    return Tipo_Cheque.COMPENSADO;
            }
        }

        public static string Cria_Lista_Consulta(int[] _Lista)
        {
            string aux = string.Empty;

            if (_Lista == null)
                return aux;

            for (int i = 0; i <= _Lista.Length - 1; i++)
            {
                aux += _Lista[i].ToString();
                if (i < _Lista.Length - 1)
                    aux += ", ";
            }

            return aux;
        }

        /// <summary>
        /// <para>1 - Segunda-feira, 01 de Janeiro de 1990</para>
        /// <para>2 - 01-01-1990_12h-30m</para>
        /// <para>3 - 01/01/1990</para>
        /// <para>4 - 01 de Janeiro de 1990</para>
        /// <para>5 - Janeiro</para>
        /// <para>6 - 01-01-1990 dd-mm-yyyy</para>
        /// <para>7 - 1990-01-01 yyyy-mm-dd</para>
        /// <para>8 - 9001 yymm</para>
        /// <para>9 - 199001 yyyymm</para>
        /// <para>10 - "HH:mm:ss"</para>
        /// <para>11 - Primeiro dia do mês</para>
        /// <para>12 - Ultimo dia do mês</para>
        /// <para>13 - Data Evento NFe (AAAA-MM-DDThh:mm:ssTzd)</para>
        /// <para>14 - Hora (12:00)</para>
        /// <para>15 - dd/MM/yyyy HH:mm:ss</para>
        /// <para>16 - ddMMyyyyHHmmss</para>
        /// <para>17 - ddMMyy</para>
        /// <para>18 - ddMMyyyy</para>
        /// <para>19 - MM/yyyy</para>
        /// <para>20 - Janeiro/2016</para>
        /// <para>21 - yyyyMMdd</para>
        /// <para>22 - ddMM</para>
        /// </summary>
        /// <param name="_Data"></param>
        /// <param name="_Tipo"></param>
        /// <returns></returns>
        public static object Config_Data(DateTime _Data, int _Tipo)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = _Data.Day;
            int ano = _Data.Year;
            int intmes = _Data.Month;
            int hora = _Data.Hour;
            int minuto = _Data.Minute;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(_Data.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(_Data.DayOfWeek));

            switch (_Tipo)
            {
                case 1:
                    return diasemana + ", " + dia + " de " + mes + " de " + ano;
                case 2:
                    return dia + "-" + intmes + "-" + ano + "_" + hora + "h-" + minuto + "m";
                case 3:
                    return _Data.ToString("dd/MM/yyyy");
                case 4:
                    return dia + " de " + mes + " de " + ano;
                case 5:
                    return mes;
                case 6:
                    return dia + "-" + intmes + "-" + ano;
                case 7:
                    return _Data.ToString("yyyy-MM-dd");
                case 8:
                    return _Data.ToString("yyMM");
                case 9:
                    return _Data.ToString("yyyyMM");
                case 10:
                    return _Data.ToString("HH:mm:ss");
                case 11:
                    DateTime aux = Convert.ToDateTime("01/" + _Data.ToString("MM/yyyy"));
                    return Convert.ToString(aux);
                case 12:
                    DateTime aux2 = Convert.ToDateTime("01/" + _Data.ToString("MM/yyyy"));
                    return Convert.ToString(aux2.AddMonths(1).AddDays(-1));
                case 13:
                    return _Data.ToString("yyyy-MM-ddTHH:mm:sszzz");
                case 14:
                    return hora + ":" + minuto;
                case 15:
                    return _Data.ToString("dd/MM/yyyy HH:mm:ss");
                case 16:
                    return _Data.ToString("ddMMyyyyHHmmss");
                case 17:
                    return _Data.ToString("ddMMyy");
                case 18:
                    return _Data.ToString("ddMMyyyy");
                case 19:
                    return _Data.ToString("MM/yyyy");
                case 20:
                    return mes + @"/" + ano;
                case 21:
                    return _Data.ToString("yyyyMMdd");
                case 22:
                    return _Data.ToString("ddMM");
            }
            return null;
        }

        public static string Config_ChaveNFe_CFe(string _Chave)
        {
            int _contador = 0;
            string _aux = string.Empty;
            for (int i = 0; i < _Chave.Length; i++)
                if (_contador == 4)
                {
                    _aux += " " + _Chave.Substring(i, 1);
                    _contador = 1;
                }
                else
                {
                    _aux += _Chave.Substring(i, 1);
                    _contador++;
                }
            return _aux;
        }

        public static string Config_Campo_String(int _Tamanho, char _Lado, char _Tipo, string _Conteudo)
        {
            string aux = string.Empty;

            if (_Conteudo.Length > _Tamanho)
                _Conteudo = _Conteudo.Substring(0, _Tamanho);

            if (_Lado == 'D')
                aux = _Conteudo.PadRight(_Tamanho, _Tipo);

            if (_Lado == 'E')
                aux = _Conteudo.PadLeft(_Tamanho, _Tipo);

            return aux;
        }

        #region VALOR POR EXTENSO
        public static string ValorExtenso(decimal Valor)
        {
            string strValorExtenso = ""; //Variável que irá armazenar o valor por extenso do número informado
            string strNumero = ""; //Irá armazenar o número para exibir por extenso
            string strCentena = "";
            string strDezena = "";
            decimal dblCentavos = 0;
            decimal dblValorInteiro = 0;
            int intContador = 0;
            bool bln_Bilhao = false;
            bool bln_Milhao = false;
            bool bln_Mil = false;
            bool bln_Unidade = false;
            //Verificar se foi informado um dado indevido
            if (Valor == 0 || Valor <= 0)
            {
                strValorExtenso = "Verificar se há valor negativo ou nada foi informado";
            }
            if (Valor > (decimal)9999999999.99)
            {
                strValorExtenso = "Valor não suportado pela Função";
            }

            else //Entrada padrão do método
            {
                //Gerar Extenso Centavos
                dblCentavos = Valor - (int)Valor;
                //Gerar Extenso parte Inteira
                dblValorInteiro = (int)Valor;
                if (dblValorInteiro > 0)
                {
                    if (dblValorInteiro > 999)
                    {
                        bln_Mil = true;
                    }
                    if (dblValorInteiro > 999999)
                    {
                        bln_Milhao = true;
                        bln_Mil = false;
                    }
                    if (dblValorInteiro > 999999999)
                    {
                        bln_Mil = false;
                        bln_Milhao = false;
                        bln_Bilhao = true;
                    }
                    for (int i = (dblValorInteiro.ToString().Trim().Length) - 1; i >= 0; i--)
                    {
                        // strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) + 1, 1);
                        strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 1);
                        switch (i)
                        { /*******/
                            case 9: /*Bilhão*
                                /*******/
                                {
                                    strValorExtenso = fcn_Numero_Unidade(strNumero) + ((int.Parse(strNumero) > 1) ? " Bilhões" : " Bilhão");
                                    bln_Bilhao = true;
                                    break;
                                }
                            case 8: /********/

                            case 5: //Centena*
                            case 2: /********/
                                {
                                    if (int.Parse(strNumero) > 0)
                                    {
                                        strCentena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 3);
                                        if (int.Parse(strCentena) > 100 && int.Parse(strCentena) < 200)
                                        {
                                            strValorExtenso = strValorExtenso + " Cento e ";
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + " " + fcn_Numero_Centena(strNumero);
                                        }
                                        if (intContador == 8)
                                        {
                                            bln_Milhao = true;
                                        }

                                        else if (intContador == 5)
                                        {
                                            bln_Mil = true;
                                        }

                                    }
                                    break;
                                }
                            case 7: /*****************/
                            case 4: //Dezena de Milhão*
                            case 1: /*****************/
                                {
                                    if (int.Parse(strNumero) > 0)
                                    {
                                        strDezena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 2);//
                                        if (int.Parse(strDezena) > 10 && int.Parse(strDezena) < 20)
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ") + fcn_Numero_Dezena0(Right(strDezena, 1));
                                            bln_Unidade = true;
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ") + fcn_Numero_Dezena1(Left(strDezena, 1));
                                            bln_Unidade = false;
                                        }
                                        if (intContador == 7)
                                        {
                                            bln_Milhao = true;
                                        }
                                        else if (intContador == 4)
                                        {
                                            bln_Mil = true;
                                        }
                                    }
                                    break;
                                }
                            case 6: /******************/
                            case 3: //Unidade de Milhão*
                            case 0: /******************/
                                {
                                    if (int.Parse(strNumero) > 0 && !bln_Unidade)
                                    {
                                        if ((Right(strValorExtenso, 5).Trim()) == "entos"
                                            || (Right(strValorExtenso, 3).Trim()) == "nte"
                                        || (Right(strValorExtenso, 3).Trim()) == "nta")
                                        {
                                            strValorExtenso = strValorExtenso + " e ";
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + " ";
                                        }
                                        strValorExtenso = strValorExtenso + fcn_Numero_Unidade(strNumero);
                                    }
                                    if (i == 6)
                                    {
                                        if (bln_Milhao || int.Parse(strNumero) > 0)
                                        {
                                            strValorExtenso = strValorExtenso + ((int.Parse(strNumero) == 1) && !bln_Unidade ? " Milhão " : " Milhões ");
                                            bln_Milhao = true;
                                        }
                                    }
                                    if (i == 3)
                                    {
                                        if (bln_Mil || int.Parse(strNumero) > 0)
                                        {
                                            strValorExtenso = strValorExtenso + " Mil";
                                            bln_Mil = true;
                                        }
                                    }
                                    if (i == 0)
                                    {
                                        if ((bln_Bilhao && !bln_Milhao && !bln_Mil && Right((dblValorInteiro.ToString().Trim()), 3) == "0") || (!bln_Bilhao && bln_Milhao && !bln_Mil && Right((dblValorInteiro.ToString().Trim()), 3) == "0"))
                                        {
                                            strValorExtenso = strValorExtenso + " de ";
                                        }
                                        strValorExtenso = strValorExtenso + ((int.Parse(dblValorInteiro.ToString())) > 1 ? " Reais " : " Real ");
                                    }
                                    bln_Unidade = false;
                                    break;
                                }
                        }
                    }//
                }
                if (dblCentavos > 0)
                {
                    if ((Decimal.Parse(dblCentavos.ToString()) > 0) && (dblCentavos < (decimal)0.1))
                    {
                        strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                        strValorExtenso = strValorExtenso + ((Decimal.Parse(dblCentavos.ToString()) > 0) ? " e " : " ") + fcn_Numero_Unidade(strNumero) + ((Decimal.Parse(strNumero) > 1) ? " Centavos " : " Centavo ");
                    }
                    else if (dblCentavos > (decimal)0.1 && dblCentavos < (decimal)0.2)
                    {
                        strNumero = Right(((Decimal.Round(dblCentavos, 2) - (decimal)0.1).ToString().Trim()), 1);
                        strValorExtenso = strValorExtenso + ((Decimal.Parse(dblCentavos.ToString()) > 0) ? " e " : " ")
                            + fcn_Numero_Dezena0(strNumero) + " Centavos ";
                    }
                    else
                    {
                        if (dblCentavos > 0) //0#
                        {
                            strNumero = Right(util_dados.ConfigNumDecimal(dblCentavos, 2), 2);//Mid(dblCentavos.ToString().Trim(), 0, 1);//
                            strValorExtenso = strValorExtenso + ((int.Parse(strNumero) > 0) ? " e " : "")//((Convert.ToInt32(dblCentavos.ToString()) > 0) ? " e " : " ")
                                + fcn_Numero_Dezena1(Left(strNumero, 1));
                            if ((dblCentavos.ToString().Trim().Length) > 2)
                            {
                                strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                                if (int.Parse(strNumero) > 0)
                                {
                                    if (Mid(strValorExtenso.Trim(), strValorExtenso.Trim().Length - 2, 1) == "e")
                                    {
                                        strValorExtenso = strValorExtenso + " " + fcn_Numero_Unidade(strNumero);
                                    }
                                    else
                                    {
                                        strValorExtenso = strValorExtenso + " e " + fcn_Numero_Unidade(strNumero);
                                    }
                                }
                            }
                            strValorExtenso = strValorExtenso + " Centavos ";
                        }
                    }
                }
                if (dblValorInteiro < 1) strValorExtenso = Mid(strValorExtenso.Trim(), 2, strValorExtenso.Trim().Length - 2);
            }
            return strValorExtenso.Trim();
        }

        public static string NumeroExtenso(decimal Valor)
        {
            string strValorExtenso = ""; //Variável que irá armazenar o valor por extenso do número informado
            string strNumero = ""; //Irá armazenar o número para exibir por extenso
            string strCentena = "";
            string strDezena = "";
            decimal dblCentavos = 0;
            decimal dblValorInteiro = 0;
            int intContador = 0;
            bool bln_Bilhao = false;
            bool bln_Milhao = false;
            bool bln_Mil = false;
            bool bln_Unidade = false;
            //Verificar se foi informado um dado indevido
            if (Valor == 0 || Valor <= 0)
            {
                strValorExtenso = "Verificar se há valor negativo ou nada foi informado";
            }
            if (Valor > (decimal)9999999999.99)
            {
                strValorExtenso = "Valor não suportado pela Função";
            }

            else //Entrada padrão do método
            {
                //Gerar Extenso Centavos
                dblCentavos = Valor - (int)Valor;
                //Gerar Extenso parte Inteira
                dblValorInteiro = (int)Valor;
                if (dblValorInteiro > 0)
                {
                    if (dblValorInteiro > 999)
                    {
                        bln_Mil = true;
                    }
                    if (dblValorInteiro > 999999)
                    {
                        bln_Milhao = true;
                        bln_Mil = false;
                    }
                    if (dblValorInteiro > 999999999)
                    {
                        bln_Mil = false;
                        bln_Milhao = false;
                        bln_Bilhao = true;
                    }
                    for (int i = (dblValorInteiro.ToString().Trim().Length) - 1; i >= 0; i--)
                    {
                        // strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) + 1, 1);
                        strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 1);
                        switch (i)
                        { /*******/
                            case 9: /*Bilhão*
                                /*******/
                                {
                                    strValorExtenso = fcn_Numero_Unidade(strNumero) + ((int.Parse(strNumero) > 1) ? " Bilhões" : " Bilhão");
                                    bln_Bilhao = true;
                                    break;
                                }
                            case 8: /********/

                            case 5: //Centena*
                            case 2: /********/
                                {
                                    if (int.Parse(strNumero) > 0)
                                    {
                                        strCentena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 3);
                                        if (int.Parse(strCentena) > 100 && int.Parse(strCentena) < 200)
                                        {
                                            strValorExtenso = strValorExtenso + " Cento e ";
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + " " + fcn_Numero_Centena(strNumero);
                                        }
                                        if (intContador == 8)
                                        {
                                            bln_Milhao = true;
                                        }

                                        else if (intContador == 5)
                                        {
                                            bln_Mil = true;
                                        }

                                    }
                                    break;
                                }
                            case 7: /*****************/
                            case 4: //Dezena de Milhão*
                            case 1: /*****************/
                                {
                                    if (int.Parse(strNumero) > 0)
                                    {
                                        strDezena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 2);//
                                        if (int.Parse(strDezena) > 10 && int.Parse(strDezena) < 20)
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ") + fcn_Numero_Dezena0(Right(strDezena, 1));
                                            bln_Unidade = true;
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ") + fcn_Numero_Dezena1(Left(strDezena, 1));
                                            bln_Unidade = false;
                                        }
                                        if (intContador == 7)
                                        {
                                            bln_Milhao = true;
                                        }
                                        else if (intContador == 4)
                                        {
                                            bln_Mil = true;
                                        }
                                    }
                                    break;
                                }
                            case 6: /******************/
                            case 3: //Unidade de Milhão*
                            case 0: /******************/
                                {
                                    if (int.Parse(strNumero) > 0 && !bln_Unidade)
                                    {
                                        if ((Right(strValorExtenso, 5).Trim()) == "entos"
                                            || (Right(strValorExtenso, 3).Trim()) == "nte"
                                        || (Right(strValorExtenso, 3).Trim()) == "nta")
                                        {
                                            strValorExtenso = strValorExtenso + " e ";
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + " ";
                                        }
                                        strValorExtenso = strValorExtenso + fcn_Numero_Unidade(strNumero);
                                    }
                                    if (i == 6)
                                    {
                                        if (bln_Milhao || int.Parse(strNumero) > 0)
                                        {
                                            strValorExtenso = strValorExtenso + ((int.Parse(strNumero) == 1) && !bln_Unidade ? " Milhão " : " Milhões ");
                                            bln_Milhao = true;
                                        }
                                    }
                                    if (i == 3)
                                    {
                                        if (bln_Mil || int.Parse(strNumero) > 0)
                                        {
                                            strValorExtenso = strValorExtenso + " Mil";
                                            bln_Mil = true;
                                        }
                                    }
                                    bln_Unidade = false;
                                    break;
                                }
                        }
                    }//
                }
                if (dblCentavos > 0)
                {
                    if ((Decimal.Parse(dblCentavos.ToString()) > 0) && (dblCentavos < (decimal)0.1))
                    {
                        strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                        strValorExtenso = strValorExtenso + ((Decimal.Parse(dblCentavos.ToString()) > 0) ? " e " : " ") + fcn_Numero_Unidade(strNumero) + ((Decimal.Parse(strNumero) > 1) ? " Centavos " : " Centavo ");
                    }
                    else if (dblCentavos > (decimal)0.1 && dblCentavos < (decimal)0.2)
                    {
                        strNumero = Right(((Decimal.Round(dblCentavos, 2) - (decimal)0.1).ToString().Trim()), 1);
                        strValorExtenso = strValorExtenso + ((Decimal.Parse(dblCentavos.ToString()) > 0) ? " e " : " ")
                            + fcn_Numero_Dezena0(strNumero);
                    }
                    else
                    {
                        if (dblCentavos > 0) //0#
                        {
                            strNumero = Right(util_dados.ConfigNumDecimal(dblCentavos, 7), 2);//Mid(dblCentavos.ToString().Trim(), 0, 1);//
                            strValorExtenso = strValorExtenso + ((int.Parse(strNumero) > 0) ? " e " : "")//((int.Parse(dblCentavos.ToString()) > 0) ? " e " : " ")
                                + fcn_Numero_Dezena1(Left(strNumero, 1));
                            if ((dblCentavos.ToString().Trim().Length) > 2)
                            {
                                strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                                if (int.Parse(strNumero) > 0)
                                {
                                    if (Mid(strValorExtenso.Trim(), strValorExtenso.Trim().Length - 2, 1) == "e")
                                    {
                                        strValorExtenso = strValorExtenso + " " + fcn_Numero_Unidade(strNumero);
                                    }
                                    else
                                    {
                                        strValorExtenso = strValorExtenso + " e " + fcn_Numero_Unidade(strNumero);
                                    }
                                }
                            }
                        }
                    }
                }
                if (dblValorInteiro < 1) strValorExtenso = Mid(strValorExtenso.Trim(), 2, strValorExtenso.Trim().Length - 2);
            }
            return strValorExtenso.Trim();
        }

        private static string fcn_Numero_Dezena0(string pstrDezena0)
        {
            ArrayList array_Dezena0 = new ArrayList();
            array_Dezena0.Add("Onze");
            array_Dezena0.Add("Doze");
            array_Dezena0.Add("Treze");
            array_Dezena0.Add("Quatorze");
            array_Dezena0.Add("Quinze");
            array_Dezena0.Add("Dezesseis");
            array_Dezena0.Add("Dezessete");
            array_Dezena0.Add("Dezoito");
            array_Dezena0.Add("Dezenove");
            return array_Dezena0[((int.Parse(pstrDezena0)) - 1)].ToString();
        }

        private static string fcn_Numero_Dezena1(string pstrDezena1)
        {
            ArrayList array_Dezena1 = new ArrayList();
            array_Dezena1.Add("Dez");
            array_Dezena1.Add("Vinte");
            array_Dezena1.Add("Trinta");
            array_Dezena1.Add("Quarenta");
            array_Dezena1.Add("Cinquenta");
            array_Dezena1.Add("Sessenta");
            array_Dezena1.Add("Setenta");
            array_Dezena1.Add("Oitenta");
            array_Dezena1.Add("Noventa");
            return array_Dezena1[((int.Parse(pstrDezena1)) - 1)].ToString();
        }

        private static string fcn_Numero_Centena(string pstrCentena)
        {
            ArrayList array_Centena = new ArrayList();
            array_Centena.Add("Cem");
            array_Centena.Add("Duzentos");
            array_Centena.Add("Trezentos");
            array_Centena.Add("Quatrocentos");
            array_Centena.Add("Quinhentos");
            array_Centena.Add("Seiscentos");
            array_Centena.Add("Setecentos");
            array_Centena.Add("Oitocentos");
            array_Centena.Add("Novecentos");
            return array_Centena[((int.Parse(pstrCentena)) - 1)].ToString();
        }

        private static string fcn_Numero_Unidade(string pstrUnidade)
        {
            ArrayList array_Unidade = new ArrayList();
            array_Unidade.Add("Um");
            array_Unidade.Add("Dois");
            array_Unidade.Add("Três");
            array_Unidade.Add("Quatro");
            array_Unidade.Add("Cinco");
            array_Unidade.Add("Seis");
            array_Unidade.Add("Sete");
            array_Unidade.Add("Oito");
            array_Unidade.Add("Nove");
            return array_Unidade[((int.Parse(pstrUnidade)) - 1)].ToString();
        }

        private static string Left(string param, int length)
        {
            if (param == "")
                return "";
            string result = param.Substring(0, length);
            return result;
        }

        private static string Right(string param, int length)
        {
            if (param == "")
                return "";
            string result = param.Substring(param.Length - length, length);
            return result;
        }

        private static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        private static string Mid(string param, int startIndex)
        {
            string result = param.Substring(startIndex);
            return result;
        }
        #endregion
        #endregion

        #region NF-e
        public static Int32 GerarDigito(string chave)
        {
            int i, j, Digito;
            const string PESO = "4329876543298765432987654329876543298765432";

            chave = chave.Replace("NFe", "");
            if (chave.Length != 43)
                throw new Exception("Erro na composição da chave para obter o DV (" + chave.Length.ToString() + ")");

            j = 0;
            Digito = -1;
            try
            {
                for (i = 0; i < 43; ++i)
                    j += Convert.ToInt32(chave.Substring(i, 1)) * Convert.ToInt32(PESO.Substring(i, 1));
                Digito = 11 - (j % 11);
                if ((j % 11) < 2)
                    Digito = 0;
            }
            catch
            {
                Digito = -1;
            }
            if (Digito == -1)
                throw new Exception("Erro no cálculo do DV");

            return Digito;
        }

        public static string ConfigCampoNFe(object Str)
        {
            string Campo = Convert.ToString(Str);
            string Letra;
            string Resposta;
            Resposta = "";
            if (Campo.Length > 0)
            {
                for (int i = 0; i < Campo.Length; i++)
                {
                    Letra = Campo[i].ToString();
                    switch (Letra)
                    {
                        case "Á":
                        case "À":
                        case "Ã":
                        case "Â":
                        case "Ä":
                            Letra = "A";
                            break;
                        case "É":
                        case "È":
                        case "Ê":
                        case "Ë":
                            Letra = "E";
                            break;
                        case "Í":
                        case "Ì":
                        case "Î":
                        case "Ï":
                            Letra = "I";
                            break;
                        case "Ó":
                        case "Ò":
                        case "Õ":
                        case "Ô":
                        case "Ö":
                            Letra = "O";
                            break;
                        case "Ú":
                        case "Ù":
                        case "Û":
                        case "Ü":
                            Letra = "U";
                            break;
                        case "Ç":
                            Letra = "C";
                            break;
                        case "º":
                        case "°":
                            Letra = "O";
                            break;
                        case "ª":
                            Letra = "A";
                            break;
                        case ",":
                            Letra = ".";
                            break;

                        case "á":
                        case "à":
                        case "ã":
                        case "â":
                        case "ä":
                            Letra = "a";
                            break;
                        case "é":
                        case "è":
                        case "ê":
                        case "ë":
                            Letra = "e";
                            break;
                        case "í":
                        case "ì":
                        case "î":
                        case "ï":
                            Letra = "i";
                            break;
                        case "ó":
                        case "ò":
                        case "õ":
                        case "ô":
                        case "ö":
                            Letra = "o";
                            break;
                        case "ú":
                        case "ù":
                        case "û":
                        case "ü":
                            Letra = "u";
                            break;
                        case "ç":
                            Letra = "c";
                            break;
                        case "$":
                            Letra = "S";
                            break;
                    }
                    Resposta = Resposta + Letra;
                }
            }
            return Resposta;
        }

        public static double CalculaBC(double ValorOp, double PercentualReducao)
        {
            return (ValorOp - (ValorOp * (PercentualReducao / 100)));
        }

        public static double CalculaBCST(double ValorOp, double AliquotaICMSST, double MVA, double PercentualReducaoST)
        {
            double BCST = ValorOp - (ValorOp * PercentualReducaoST / 100);
            return BCST + (BCST * (MVA / 100));
            //return ((ValorOp - (ValorOp * (PercentualReducaoST / 100))) + (ValorOp * (MVA / 100)));
        }

        public static double CalculaAliquota(double ValorBC, double Aliquota)
        {
            return (ValorBC * (Aliquota / 100));
        }

        public static double CalculaAliquotaST(double ValorBC, double ValorBCST, double AliquotaICMS, double AliquotaICMSST)
        {
            if (AliquotaICMSST == 0)
                return 0;

            double ICMS = ValorBC * (AliquotaICMS / 100);
            double ICMSST = ValorBCST * (AliquotaICMSST / 100);
            return ICMSST - ICMS;
        }
        #endregion

        #region SAT
        public static int Gera_Sessao()
        {
            Random Sessao = new Random();
            int aux = Sessao.Next(1, 999999);
            int aux1 = Sessao.Next(1, 999999);
            int aux2 = Sessao.Next(1, 999999);

            return Convert.ToInt32((aux + aux1 + aux2).ToString().PadRight(6, '0').Substring(0, 6));
        }
        #endregion

        #region CARREGA OBJETOS
        public static DataTable CarregaComboDinamico(int _Inicio, List<string> _Descricao)
        {
            DataRow DR;
            DataTable _DT;

            _DT = new DataTable("Table");
            _DT.Columns.Add("ID");
            _DT.Columns.Add("Descricao");

            int aux = _Inicio;

            for (int i = 0; i < _Descricao.Count; i++)
            {
                DR = _DT.NewRow();
                DR["ID"] = aux;
                DR["Descricao"] = _Descricao[i];
                _DT.Rows.Add(DR);
                _DT.AcceptChanges();
                aux++;
            }
            return _DT;
        }

        public static void CarregaCampo(Form Frm, DataTable DT, GroupBox A)
        {

            ComboBox cmb = default(ComboBox);
            if (A == null)
                return;
            foreach (Control ctl in A.Controls)
            {
                string tag = (string)ctl.Tag;
                if (tag != null)
                {
                    if (tag.EndsWith("T"))
                    {
                        if (ctl is ComboBox)
                        {
                            cmb = (ComboBox)ctl;
                            ctl.DataBindings.Clear();
                            if ((cmb.ValueMember != null) && cmb.ValueMember != string.Empty)
                            {
                                try
                                {
                                    string Nome = ctl.Name;
                                    Nome = Nome.Substring(3);
                                    ctl.DataBindings.Add("selectedvalue", DT, Nome, false, DataSourceUpdateMode.OnPropertyChanged);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else
                            {
                                try
                                {
                                    string Nome = ctl.Name;
                                    Nome = Nome.Substring(3);
                                    ctl.DataBindings.Add("text", DT, Nome, false, DataSourceUpdateMode.OnPropertyChanged);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        if (ctl is TextBox || ctl is DateTimePicker)
                        {
                            try
                            {
                                ctl.DataBindings.Clear();
                                string Nome = ctl.Name;
                                Nome = Nome.Substring(4);
                                ctl.DataBindings.Add("text", DT, Nome, false, DataSourceUpdateMode.OnPropertyChanged);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        if (ctl is MaskedTextBox)
                        {
                            try
                            {
                                string Nome = ctl.Name;
                                Nome = Nome.Substring(3);
                                ctl.DataBindings.Clear();
                                ctl.DataBindings.Add("text", DT, Nome, false, DataSourceUpdateMode.OnPropertyChanged);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        if (ctl is CheckBox || ctl is RadioButton)
                        {
                            try
                            {
                                string Nome = ctl.Name;
                                Nome = Nome.Substring(3);
                                ctl.DataBindings.Clear();
                                ctl.DataBindings.Add("checked", DT, Nome, false, DataSourceUpdateMode.OnPropertyChanged);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    if (tag.StartsWith("F"))
                        ctl.Focus();
                }
            }
        }

        public static void CarregaCombo(DataTable DT, string Descricao, string Codigo, ComboBox Obj)
        {
            Obj.DataSource = DT;
            Obj.DisplayMember = Descricao;
            Obj.ValueMember = Codigo;
        }

        public static void LimpaCampos(Form frm, GroupBox J)
        {
            ComboBox cmb;
            CheckBox chk;
            foreach (Control ctl in J.Controls)
            {
                if (ctl is TextBox)
                    ctl.Text = string.Empty;
                ctl.DataBindings.Clear();
                if (ctl is MaskedTextBox)
                    ctl.Text = string.Empty;
                ctl.DataBindings.Clear();
                if (ctl is DateTimePicker)
                    ctl.Text = string.Empty;
                ctl.DataBindings.Clear();
                if (ctl is CheckBox)
                {
                    chk = (CheckBox)ctl;
                    chk.Checked = false;
                }
                if (ctl is ComboBox)
                {
                    cmb = (ComboBox)ctl;
                    if ((cmb.ValueMember != null) && cmb.ValueMember != string.Empty)
                    {
                        cmb.SelectedValue = -1;
                    }
                    else
                    {
                        cmb.SelectedIndex = -1;
                    }
                }

                string tag = (string)ctl.Tag;
                if (tag != null)
                {
                    if (tag.StartsWith("F"))
                        ctl.Focus();
                }
            }
        }

        public static void CarregaForm(Form Frm, Form FrmPai)
        {

            //Frm.MdiParent = FrmPai;
           
            Frm.WindowState = FormWindowState.Maximized;
            Frm.Show();
         
           //Frm.Activate();
        }
        #endregion

        #region XML
        public static String Gerar_XML<T>(T objeto)
        {
            XElement xml = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));

                using (MemoryStream memory = new MemoryStream())
                {
                    using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
                    {
                        ser.Serialize(memory, objeto);
                        memory.Position = 0;
                        xml = XElement.Load(tr);
                        xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
                    }
                }
            }
            catch
            {
                throw;
            }
            return xml.ToString();
        }

        public static string Limpa_StringXML(string str)
        {
            string aux = str;
            while (aux.IndexOf("> ") > -1)
            {
                aux = aux.Replace("> ", ">");
            }
            aux = aux.Replace(" />", "/>").Replace(" </", "</");

            aux = ConfigCampoNFe(aux);
            return aux;
        }

        public static T LoadFromXMLString<T>(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serealizer = new XmlSerializer(typeof(T));
            return (T)serealizer.Deserialize(stringReader);
        }

        public static T Deserialize<T>(this XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }

        public static XElement Serialize<T>(this object o)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, o);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }
        #endregion

        #region SEGURANÇA E CRIPTOGRAFIA
        private static string _Chave = "7e5d3f3t7y";

        private static byte[] PegaChave(string password)
        {
            string pwd = null;
            if (Encoding.UTF8.GetByteCount(password) < 24)
                pwd = password.PadRight(24, ' ');
            else
                pwd = password.Substring(0, 24);

            return Encoding.UTF8.GetBytes(pwd);
        }

        public static string Criptografa(string str)
        {
            try
            {
                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

                DES.Mode = CipherMode.ECB;
                DES.Key = PegaChave(_Chave);

                DES.Padding = PaddingMode.PKCS7;
                ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                Byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(str);

                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                return "Erro ao criptografar!" + ex.Message;
            }
        }

        public static string Decriptografa(string str)
        {
            try
            {
                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

                DES.Mode = CipherMode.ECB;
                DES.Key = PegaChave(_Chave);

                DES.Padding = PaddingMode.PKCS7;
                ICryptoTransform DESEncrypt = DES.CreateDecryptor();
                Byte[] Buffer = Convert.FromBase64String(str);

                return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                return "Erro ao descriptografar!" + ex.Message;
            }

        }
        #endregion

        #region PLANO DE CONTAS
        public static object ValidaConta(string strConta)
        {
            return strConta.Replace(".", "").Replace(" ", "0");
        }

        public static string GravaCodigoPai(string strConta, int intNivel)
        {
            string Conta = "";
            switch (intNivel)
            {
                case 1:
                    Conta = "0";
                    break;
                case 2:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 2);
                    break;
                case 3:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 4);
                    break;
                case 4:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 6);
                    break;
            }
            return Conta;
        }

        public static string ConsultaCodigoPai(string strConta, int intNivel)
        {
            string Conta = "";
            if (strConta.Length == 10)
                strConta = strConta + "0";
            switch (intNivel)
            {
                case 1:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 2);
                    break;
                case 2:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 4);
                    break;
                case 3:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 6);
                    break;
                case 4:
                    Conta = strConta.Replace(".", "").Replace(" ", "0");
                    Conta = Conta.Substring(0, 8);
                    break;
            }
            return Conta;
        }

        public static string GravaCodigo(string strConta, int intNivel)
        {
            string conta = "";
            switch (intNivel)
            {
                case 1:
                    conta = strConta.Replace(".", "").Replace(" ", "0");
                    conta = conta.Substring(0, 2);
                    break;
                case 2:
                    conta = strConta.Replace(".", "").Replace(" ", "0");
                    conta = conta.Substring(conta.Length - 4, 2);
                    break;
                case 3:
                    conta = strConta.Replace(".", "").Replace(" ", "0");
                    conta = conta.Substring(conta.Length - 2, 2);
                    break;
                case 4:
                    conta = strConta.Replace(".", "").Replace(" ", "0");
                    conta = conta.Substring(conta.Length - 2, 2);
                    break;
            }
            return conta;
        }

        public static string GravaCodigoDescritivo(string strConta, int intNivel)
        {
            string conta = null;

            switch (intNivel)
            {
                case 1:
                    conta = strConta.Replace(" ", "0") + "00";
                    break;
                case 2:
                    conta = strConta.Replace(" ", "0") + "00";
                    break;
                case 3:
                    conta = strConta.Replace(" ", "0") + "00";
                    break;
                case 4:
                    conta = strConta.Replace(" ", "0");
                    if (conta.Length == 10)
                        conta = conta + "0";
                    break;
            }
            return conta;
        }

        public static int VerificaNivel(string strConta)
        {
            strConta = strConta.Replace(" ", "0");
            if (strConta.Length > 9)
            {
                return 4;
            }
            if (strConta.Substring(strConta.Length - 3, 2) != "00" & strConta.Length == 9)
            {
                return 3;
            }
            if (strConta.Substring(strConta.Length - 6, 2) != "00")
            {
                return 2;
            }
            if (strConta.Substring(0, 2) != "00")
            {
                return 1;
            }
            return 0;
        }
        #endregion

        #region COBRANÇA BANCÁRIA
        public static int Santander_Calc_Mod11(string str, int Tipo)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            if (Tipo == 1) //NOSSO NUMERO
            {
                Resto = Soma % 11;
                switch (Resto)
                {
                    case 10:
                        return 1;

                    case 1:
                        return 0;

                    case 0:
                        return 0;

                    default:
                        return 11 - Resto;
                }
            }
            else //LINHA DIGITAVEL E BARRAS
            {
                Resto = ((Soma * 10) % 11);
                switch (Resto)
                {
                    case 10:
                        return 1;

                    case 1:
                        return 1;

                    case 0:
                        return 1;

                    default:
                        return Resto;
                }
            }
        }

        /// <summary>
        /// RETORNA NOSSO NUMERO COM DIGITO VERIFICADOR SEPARADO POR "-"
        /// PARA PEGAR SOMENTE DIGITO USAR .split('-')
        /// </summary>
        public static string Santander_NossoNumeroDV(string _NossoNumero)
        {
            return _NossoNumero.PadLeft(12, '0').Substring(0, 12) + "-" + Santander_Calc_Mod11(_NossoNumero.PadLeft(12, '0').Substring(0, 12), 1);
        }

        public static string Boleto_Juros(double dblValor, double dblJuros, int intDias)
        {
            double Juros = dblValor * ((dblJuros / 30) / 100);

            if (Juros < 0.01)
                Juros = 0.01;

            if (intDias == 0)
                return "Após Vencimento Cobrar mora diária de R$ " + ConfigNumDecimal(Juros, 2);
            else
                return "Após " + intDias + " dias Cobrar mora diária de R$ " + ConfigNumDecimal(Juros, 2);
        }

        public static string Boleto_Multa(double dblValor, double dblMulta, int intDias)
        {
            double Multa = dblValor * (dblMulta / 100);

            if (intDias == 0)
                return "Após Vencimento Cobrar R$ " + ConfigNumDecimal(Multa, 2) + " de Multa";
            else
                return "Após " + intDias + " dias Cobrar R$ " + ConfigNumDecimal(Multa, 2) + " de Multa";
        }

        public static int Mod10_Santander(string str)
        {
            int Soma = 0;
            int Peso = 2;
            int Resultado;
            string aux;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                aux = Convert.ToString(str[i]);
                Resultado = (Convert.ToInt32(aux) * Peso);
                Soma += Resultado > 9 ? (Resultado - 10) + 1 : Resultado;

                if (Peso == 2)
                    Peso = 1;
                else
                    Peso = 2;
            }

            return Soma % 10 == 0 ? 0 : 10 - (Soma % 10);
        }

        public static int Mod10_Sicoob(string str)
        {
            int Soma = 0;
            int Peso = 2;
            int Resultado;
            string aux;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                aux = Convert.ToString(str[i]);
                Resultado = (Convert.ToInt32(aux) * Peso);
                Soma += Resultado > 9 ? (Resultado - 10) + 1 : Resultado;

                if (Peso == 2)
                    Peso = 1;
                else
                    Peso = 2;
            }

            return Soma % 10 == 0 ? 0 : 10 - (Soma % 10);
        }

        public static int Mod10_Caixa(string str)
        {
            int Soma = 0;
            int Peso = 2;
            int Resultado;
            string aux;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                aux = Convert.ToString(str[i]);
                Resultado = (Convert.ToInt32(aux) * Peso);
                Soma += Resultado > 9 ? (Resultado - 10) + 1 : Resultado;

                if (Peso == 2)
                    Peso = 1;
                else
                    Peso = 2;
            }

            return Soma % 10 == 0 ? 0 : 10 - (Soma % 10);
        }

        public static int Mod10_Bradesco(string str)
        {
            int Soma = 0;
            int Peso = 2;
            int Resultado;
            string aux;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                aux = Convert.ToString(str[i]);
                Resultado = (Convert.ToInt32(aux) * Peso);
                Soma += Resultado > 9 ? (Resultado - 10) + 1 : Resultado;

                if (Peso == 2)
                    Peso = 1;
                else
                    Peso = 2;
            }
            //int aux1 = Soma % 10;
            return Soma % 10 == 0 ? 0 : 10 - (Soma % 10);
            //return 0;
        }

        /// <summary>
        /// <para>1 - NOSSO NUMERO</para>
        /// <para>2 - DIGITO VERIFICADOR BARRAS E LINHA DIGITAVEL</para>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public static int Mod11_Santander(string str, int Tipo)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            if (Tipo == 1) //NOSSO NUMERO
            {
                Resto = Soma % 11;
                switch (Resto)
                {
                    case 10:
                        return 1;

                    case 1:
                        return 0;

                    case 0:
                        return 0;

                    default:
                        return 11 - Resto;
                }
            }
            else //LINHA DIGITAVEL E BARRAS
            {
                Resto = ((Soma * 10) % 11);
                switch (Resto)
                {
                    case 10:
                        return 1;

                    case 1:
                        return 1;

                    case 0:
                        return 1;

                    default:
                        return Resto;
                }
            }
        }

        public static string Santander_NossoNumero(string _NossoNumero)
        {
            return util_dados.FormatCode(_NossoNumero, 12) + "-" + util_dados.Mod11_Santander(util_dados.FormatCode(_NossoNumero, 12), 1);//13
        }

        public static int Mod11_Sicoob(string str)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            Resto = (Soma % 11);
            Resto = 11 - Resto;

            if (Resto > 9)
                return 1;

            switch (Resto)
            {
                case 1:
                    return 1;

                case 0:
                    return 1;

                default:
                    return Resto;
            }
        }

        public static int Mod11_Caixa(string str)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            Resto = (Soma % 11);
            Resto = 11 - Resto;

            if (Resto > 9)
                return 0;

            return Resto;
        }

        public static int Mod11_Caixa_CodBarra(string str)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            Resto = (Soma % 11);
            Resto = 11 - Resto;

            if (Resto == 0 ||
                Resto == 10 ||
                Resto == 11)
                return 1;

            return Resto;
        }

        public static string Mod11_Bradesco_NossoNumero(string str)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 7)
                    Peso = 2;
                else
                    Peso++;
            }

            Resto = (Soma % 11);

            if (Resto == 1)
                return "P";

            if (Resto == 0)
                return "0";

            Resto = 11 - Resto;

            return Resto.ToString();
        }

        public static int Mod11_Bradesco_CodBarra(string str)
        {
            int Peso = 2;
            int Soma = 0;
            int Resto;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(str[i]);
                Soma += (Convert.ToInt32(aux) * Peso);
                if (Peso == 9)
                    Peso = 2;
                else
                    Peso++;
            }

            Resto = (Soma % 11);
            Resto = 11 - Resto;

            if (Resto > 9)
                return 1;

            switch (Resto)
            {
                case 1:
                    return 1;

                case 0:
                    return 1;

                default:
                    return Resto;
            }
        }

        /*
        internal static int Mod101(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             

            int d, s = 0, p = 2, r;

            for (int i = seq.Length; i > 0; i--)
            {
                r = (Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(seq, i, 1)) * p);

                if (r > 9)
                    r = (r / 10) + (r % 10);

                s += r;

                if (p == 2)
                    p = 1;
                else
                    p = p + 1;
            }
            d = ((10 - (s % 10)) % 10);
            return d;
        }
        
        internal static int Mod11(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             

            int d, s = 0, p = 2, b = 9;

            for (int i = 0; i < seq.Length; i++)
            {
                s = s + (Convert.ToInt32(seq[i]) * p);
                if (p < b)
                    p = p + 1;
                else
                    p = 2;
            }

            d = 11 - (s % 11);
            if (d > 9)
                d = 0;
            return d;
        }

        internal static int Mod11(string seq, int b)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
           

            int d, s = 0, p = 2;


            for (int i = seq.Length; i > 0; i--)
            {
                s = s + (Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(seq, i, 1)) * p);
                if (p == b)
                    p = 2;
                else
                    p = p + 1;
            }

            d = 11 - (s % 11);


            if ((d > 9) || (d == 0) || (d == 1))
                d = 1;

            return d;
        }

        internal static int Mod11Base9(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
            

            int d, s = 0, p = 2, b = 9;


            for (int i = seq.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(seq[i]);
                s += (Convert.ToInt32(aux) * p);
                if (p >= b)
                    p = 2;
                else
                    p = p + 1;
            }

            if (s < 11)
            {
                d = 11 - s;
                return d;
            }
            else
            {
                int teste = (s % 11);
                d = 11 - teste;
                if ((d > 9) || (d == 0))
                    d = 0;

                return d;
            }
        }

        internal static int Mod11(string seq, int lim, int flag)
        {
            int mult = 0;
            int total = 0;
            int pos = 1;
            //int res = 0;
            int ndig = 0;
            int nresto = 0;
            string num = string.Empty;

            mult = 1 + (seq.Length % (lim - 1));

            if (mult == 1)
                mult = lim;


            while (pos <= seq.Length)
            {
                num = Microsoft.VisualBasic.Strings.Mid(seq, pos, 1);
                total += Convert.ToInt32(num) * mult;

                mult -= 1;
                if (mult == 1)
                    mult = lim;

                pos += 1;
            }
            nresto = (total % 11);
            if (flag == 1)
                return nresto;
            else
            {
                if (nresto == 0 || nresto == 1 || nresto == 10)
                    ndig = 1;
                else
                    ndig = (11 - nresto);

                return ndig;
            }
        }
*/

        public static int Mult10Mod11(string seq, int lim, int flag)
        {
            int mult = 0;
            int total = 0;
            int pos = 1;
            int ndig = 0;
            int nresto = 0;
            string num = string.Empty;

            mult = 1 + (seq.Length % (lim - 1));

            if (mult == 1)
                mult = lim;

            while (pos <= seq.Length)
            {
                num = Microsoft.VisualBasic.Strings.Mid(seq, pos, 1);
                total += Convert.ToInt32(num) * mult;

                mult -= 1;
                if (mult == 1)
                    mult = lim;

                pos += 1;
            }

            nresto = ((total * 10) % 11);

            if (flag == 1)
                return nresto;
            else
            {
                if (nresto == 0 || nresto == 1)
                    nresto = 0;
                else if (nresto == 10)
                    ndig = 1;
                else
                    ndig = (11 - nresto);

                return ndig;
            }
        }

        public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                // case DateInterval.Week:
                //lngDateDiffValue = (long)(TS.Days / 7);
                // break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }

        public static string FormatCode(string text, string with, int length, bool left)
        {
            length -= text.Length;
            if (left)
            {
                for (int i = 0; i < length; ++i)
                {
                    text = with + text;
                }
            }
            else
            {
                for (int i = 0; i < length; ++i)
                {
                    text += with;
                }
            }
            return text;
        }

        public static string FormatCode(string text, string with, int length)
        {
            return FormatCode(text, with, length, false);
        }

        public static string FormatCode(string text, int length)
        {
            return FormatCode(text, "0", length, true);
        }

        public static long FatorVencimento(DateTime datVencimento)
        {
            DateTime dateBase = new DateTime(2000, 7, 3, 0, 0, 0);
            return DateDiff(DateInterval.Day, dateBase, datVencimento) + 1000;
        }
        #endregion

        #region INFORMAÇÃO GRUPO
        public static int Codigo_TipoGrupo(Tipo_Grupo _Grupo)
        {
            switch (_Grupo)
            {
                case Tipo_Grupo.Tipo_Cliente:
                    return 1;

                case Tipo_Grupo.Tipo_Transportadora:
                    return 2;

                case Tipo_Grupo.Tipo_Fornecedor:
                    return 3;

                case Tipo_Grupo.Tipo_Funcionario:
                    return 4;

                case Tipo_Grupo.Tipo_Empresa:
                    return 5;

                case Tipo_Grupo.Tipo_Endereco:
                    return 6;

                case Tipo_Grupo.Tipo_Telefone:
                    return 7;

                case Tipo_Grupo.Tipo_eMail:
                    return 8;

                case Tipo_Grupo.Tipo_Caixa:
                    return 9;

                case Tipo_Grupo.Tipo_Atendimento:
                    return 12;

                case Tipo_Grupo.Tipo_Fabricante:
                    return 13;

                case Tipo_Grupo.Tipo_Equipamento:
                    return 15;

                case Tipo_Grupo.Tipo_Unidade:
                    return 16;

                case Tipo_Grupo.Tipo_DocumentoCompra:
                    return 22;

                case Tipo_Grupo.Tipo_Grade:
                    return 27;

                case Tipo_Grupo.Tipo_Comodato:
                    return 28;

                case Tipo_Grupo.Tipo_FolhaPagto:
                    return 29;

                case Tipo_Grupo.Tipo_DocumentoContabil:
                    return 31;

                case Tipo_Grupo.Tipo_Imovel:
                    return 32;

                case Tipo_Grupo.Tipo_Custo_Imovel:
                    return 33;

                default:
                    return 0;
            }
        }
        #endregion
    }
}

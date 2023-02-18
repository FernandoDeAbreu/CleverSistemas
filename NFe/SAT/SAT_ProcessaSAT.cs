using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Sistema.UTIL;
using Sistema.DTO;

namespace Sistema.NFe
{
    class SAT_DLL_C
    {
        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtivarSAT(int numeroSessao, int Tipo_Certificado, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJ_Contribuinte, int ID_UF);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EnviarDadosVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CancelarUltimaVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Chave, [MarshalAs(UnmanagedType.LPStr)] string dadosCancelamento);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TesteFimAFim(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarStatusOperacional(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConfigurarInterfaceDeRede(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Configuracao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AssociarAssinatura(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJs, [MarshalAs(UnmanagedType.LPStr)] string Assinatura);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtualizarSoftwareSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DesbloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ExtrairLogs(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarNumeroSessao(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, int sessaoConsulta);
    }

    class SAT_DLL_DOTNET
    {
        [DllImport("SAT.dll")]
        public static extern string AtivarSAT(int numeroSessao, int Tipo_Certificado, string codigoDeAtivacao, string CNPJ_Contribuinte, int ID_UF);

        [DllImport("SAT.dll")]
        public static extern string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("SAT.dll")]
        public static extern string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string Chave, string dadosCancelamento);

        [DllImport("SAT.dll")]
        public static extern string ConsultarSAT(int numeroSessao);

        [DllImport("SAT.dll")]
        public static extern string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("SAT.dll")]
        public static extern string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);

        [DllImport("SAT.dll")]
        public static extern string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string Configuracao);

        [DllImport("SAT.dll")]
        public static extern string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string CNPJs, string Assinatura);

        [DllImport("SAT.dll")]
        public static extern string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("SAT.dll")]
        public static extern string BloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("SAT.dll")]
        public static extern string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("SAT.dll")]
        public static extern string ExtrairLogs(int numeroSessao, string codigoDeAtivacao);

        [DllImport("SAT.dll")]
        public static extern string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int sessaoConsulta);

    }

    class ElginSAT_I
    {
        [DllImport("ElginSAT_I.dll")]
        public static extern string AtivarSAT(int numeroSessao, int Tipo_Certificado, string codigoDeAtivacao, string CNPJ_Contribuinte, int ID_UF);

        [DllImport("ElginSAT_I.dll")]
        public static extern string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("ElginSAT_I.dll")]
        public static extern string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string Chave, string dadosCancelamento);

        [DllImport("ElginSAT_I.dll")]
        public static extern string ConsultarSAT(int numeroSessao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("ElginSAT_I.dll")]
        public static extern string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string Configuracao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string CNPJs, string Assinatura);

        [DllImport("ElginSAT_I.dll")]
        public static extern string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string BloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string ExtrairLogs(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_I.dll")]
        public static extern string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int ConsultaSessao);
    }

    class ElginSAT_II
    {
        [DllImport("ElginSAT_II.dll")]
        public static extern string AtivarSAT(int numeroSessao, int Tipo_Certificado, string codigoDeAtivacao, string CNPJ_Contribuinte, int ID_UF);

        [DllImport("ElginSAT_II.dll")]
        public static extern string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("ElginSAT_II.dll")]
        public static extern string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string Chave, string dadosCancelamento);

        [DllImport("ElginSAT_II.dll")]
        public static extern string ConsultarSAT(int numeroSessao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda);

        [DllImport("ElginSAT_II.dll")]
        public static extern string ConsultarStatusOperacional(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string Configuracao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string CNPJs, string Assinatura);

        [DllImport("ElginSAT_II.dll")]
        public static extern string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string BloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string ExtrairLogs(int numeroSessao, string codigoDeAtivacao);

        [DllImport("ElginSAT_II.dll")]
        public static extern string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int ConsultaSessao);
    }

    class SAT_DLL_BEMATECH32
    {
        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtivarSAT(int numeroSessao, int Tipo_Certificado, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJ_Contribuinte, int ID_UF);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EnviarDadosVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CancelarUltimaVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Chave, [MarshalAs(UnmanagedType.LPStr)] string dadosCancelamento);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TesteFimAFim(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarStatusOperacional(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConfigurarInterfaceDeRede(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Configuracao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AssociarAssinatura(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJs, [MarshalAs(UnmanagedType.LPStr)] string Assinatura);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtualizarSoftwareSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DesbloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ExtrairLogs(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarNumeroSessao(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, int sessaoConsulta);
    }

    class SAT_DLL_BEMATECH64
    {
        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtivarSAT(int numeroSessao, int Tipo_Certificado, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJ_Contribuinte, int ID_UF);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EnviarDadosVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CancelarUltimaVenda(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Chave, [MarshalAs(UnmanagedType.LPStr)] string dadosCancelamento);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TesteFimAFim(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarStatusOperacional(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConfigurarInterfaceDeRede(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string Configuracao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AssociarAssinatura(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, [MarshalAs(UnmanagedType.LPStr)] string CNPJs, [MarshalAs(UnmanagedType.LPStr)] string Assinatura);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AtualizarSoftwareSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DesbloquearSAT(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ExtrairLogs(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

        [DllImport("BemaSAT64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConsultarNumeroSessao(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao, int sessaoConsulta);
    }

    public class SAT_ProcessaSAT
    {
        public DTO_CFe_SAT_Retorno Funcao(DTO_CFe_SAT _CFe_SAT)
        {
            int sessao = util_dados.Gera_Sessao();

            string _str_Retorno = string.Empty;

            DTO_CFe_SAT_Retorno _Retorno = new DTO_CFe_SAT_Retorno();

            switch (_CFe_SAT.Funcao)
            {
                case CFe_SAT_Funcao.AtivarSAT:
                    _str_Retorno = AtivarSAT(sessao, _CFe_SAT.Tipo_Opcao, _CFe_SAT.CNPJ, _CFe_SAT.ID_UF);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.EnviarDadosVenda:
                    _str_Retorno = ConsultarSAT(sessao + 1);
                    _Retorno = Trata_Retorno(_str_Retorno);

                    if (_Retorno.Status == true)
                    {
                        _str_Retorno = string.Empty;
                        _Retorno = new DTO_CFe_SAT_Retorno();

                        _str_Retorno = EnviarDadosVenda(_CFe_SAT.NumeroSessao, _CFe_SAT.XML);
                        _Retorno = Trata_Retorno(_str_Retorno);
                    }
                    break;

                case CFe_SAT_Funcao.CancelarUltimaVenda:
                    _str_Retorno = CancelarUltimaVenda(sessao, _CFe_SAT.Chave, _CFe_SAT.XML);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.ConsultarSAT:
                    _str_Retorno = ConsultarSAT(sessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.TesteFimAFim:
                    _str_Retorno = TesteFimAFim(sessao, _CFe_SAT.XML);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.ConfigurarInterfaceDeRede:
                    _str_Retorno = ConfigurarInterfaceDeRede(sessao, _CFe_SAT.XML);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.ConsultarNumeroSessao:
                    _str_Retorno = ConsultarNumeroSessao(sessao, _CFe_SAT.NumeroSessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.ConsultarStatusOperacional:
                    _str_Retorno = ConsultarStatusOperacional(sessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.AssociarAssinatura:
                    _str_Retorno = AssociarAssinatura(sessao, _CFe_SAT.CNPJ, _CFe_SAT.Assinatura);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.AtualizarSoftwareSAT:
                    _str_Retorno = AtualizarSoftwareSAT(sessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.BloquearSAT:
                    _Retorno = Trata_Retorno(BloquearSAT(sessao));
                    break;

                case CFe_SAT_Funcao.DesbloquearSAT:
                    _str_Retorno = DesbloquearSAT(sessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;

                case CFe_SAT_Funcao.ExtrairLogs:
                    _str_Retorno = ExtrairLogs(sessao);
                    _Retorno = Trata_Retorno(_str_Retorno);
                    break;
            }
            return _Retorno;
        }

        private DTO_CFe_SAT_Retorno Trata_Retorno(string _str)
        {
            DTO_CFe_SAT_Retorno _Retorno = new DTO_CFe_SAT_Retorno();
            string[] ret_dados = _str.Split('|');

            string Cod_Retorno = ret_dados[1];

            switch (Cod_Retorno)
            {
                #region AtivarSAT
                case "04000":
                case "04003":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "04001":
                case "04002":
                case "04004":
                case "04005":
                case "04006":
                case "04007":
                case "04098":
                case "04099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region EnviaDadosVenda
                case "06000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[3];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    _Retorno.Mensagem_SEFAZ = ret_dados[5];
                    _Retorno.XML_CFe = Encoding.UTF8.GetString(Convert.FromBase64String(ret_dados[6]));
                    _Retorno.Data_HoraEmissao = DateTime.ParseExact(ret_dados[7], "yyyyMMddHHmmss", null);
                    _Retorno.Chave = ret_dados[8];
                    _Retorno.AssinaturaQR = ret_dados[8] + "|" + ret_dados[7] + "|" + ret_dados[9] + "|" + ret_dados[10] + "|" + ret_dados[11];
                    break;

                case "06001":
                case "06002":
                case "06003":
                case "06004":
                case "06005":
                case "06006":
                case "06007":
                case "06008":
                case "06009":
                case "06010":
                case "06098":
                case "06099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[3];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    _Retorno.Mensagem_SEFAZ = ret_dados[5];
                    break;
                #endregion

                #region CancelarUltimaVenda
                case "07000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[3];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    _Retorno.Mensagem_SEFAZ = ret_dados[5];
                    _Retorno.XML_CFe = Encoding.UTF8.GetString(Convert.FromBase64String(ret_dados[6]));
                    _Retorno.Data_HoraEmissao = DateTime.ParseExact(ret_dados[7], "yyyyMMddHHmmss", null);
                    _Retorno.Chave = ret_dados[8];
                    _Retorno.AssinaturaQR = ret_dados[8] + "|" + ret_dados[7] + "|" + ret_dados[9] + "|" + ret_dados[10] + "|" + ret_dados[11];
                    break;

                case "07001":
                case "07002":
                case "07003":
                case "07004":
                case "07005":
                case "07006":
                case "07007":
                case "07098":
                case "07099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[3];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    _Retorno.Mensagem_SEFAZ = ret_dados[5];
                    break;
                #endregion

                #region TesteFimAFim
                case "09000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    _Retorno.Data_HoraEmissao = DateTime.ParseExact(ret_dados[6], "yyyyMMddHHmmss", null);
                    _Retorno.ID_CFe = Convert.ToInt32(ret_dados[7]);
                    _Retorno.Chave = ret_dados[8];
                    break;

                case "09001":
                case "09002":
                case "09098":
                case "09099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region ConsultarSAT
                case "08000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "08098":
                case "08099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region ConsultarStatusOperacional
                case "10000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];

                    if (ret_dados.Length == 27)
                    {
                        switch (ret_dados[26])
                        {
                            case "0":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: DESBLOQUEADO\n";
                                break;

                            case "1":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (SEFAZ)\n";
                                break;

                            case "2":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (APLICATIVO)\n";
                                break;

                            case "3":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (EQUIPAMENTO)\n";
                                break;

                            case "4":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO PARA DESATIVAÇÃO\n";
                                break;
                        }

                        _Retorno.StatusOperacional += "VENCIMENTO CERTIFICADO SAT: " + DateTime.ParseExact(ret_dados[25].Substring(0, 8), "yyyyMMdd", null).ToShortDateString() + "\n";
                    }

                    if (ret_dados.Length == 28)
                    {
                        switch (ret_dados[27])
                        {
                            case "0":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: DESBLOQUEADO\n";
                                break;

                            case "1":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (SEFAZ)\n";
                                break;

                            case "2":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (APLICATIVO)\n";
                                break;

                            case "3":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO (EQUIPAMENTO)\n";
                                break;

                            case "4":
                                _Retorno.StatusOperacional = "NUMERO DE SÉRIE: " + ret_dados[5] + " - STATUS: BLOQUEADO PARA DESATIVAÇÃO\n";
                                break;
                        }

                        _Retorno.StatusOperacional += "VENCIMENTO CERTIFICADO SAT: " + DateTime.ParseExact(ret_dados[26].Substring(0, 8), "yyyyMMdd", null).ToShortDateString() + "\n";
                    }

                    _Retorno.StatusOperacional += "TIPO DE REDE: " + ret_dados[6] + " - STATUS: " + ret_dados[13] + "\n";
                    _Retorno.StatusOperacional += @"IP/MASCARA: " + ret_dados[7] + @"/" + ret_dados[8] + "\n";
                    _Retorno.StatusOperacional += "GATEWAY: " + ret_dados[10] + "\n";
                    _Retorno.StatusOperacional += "DNS: " + ret_dados[11] + @"/" + ret_dados[12] + "\n";
                    _Retorno.StatusOperacional += "NÍVEL BATERÍA: " + ret_dados[14] + "\n";
                    _Retorno.StatusOperacional += "MEMÓRIA (TOTAL/USADA): " + ret_dados[15] + @"MB/" + ret_dados[16] + "MB\n";
                    _Retorno.StatusOperacional += "DATA / HORA: " + DateTime.ParseExact(ret_dados[17], "yyyyMMddHHmmss", null).ToString() + "\n";
                    _Retorno.StatusOperacional += "VERSÃO SOFTWARE BÁSICO: " + ret_dados[18] + "\n";
                    _Retorno.StatusOperacional += "VERSÃO LAYOUT TABELAS: " + ret_dados[19] + "\n";

                    break;

                case "10001":
                case "10098":
                case "10099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region ConsultarNumeroSessao
                case "11000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[3];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    _Retorno.Mensagem_SEFAZ = ret_dados[5];
                    _Retorno.XML_CFe = Encoding.UTF8.GetString(Convert.FromBase64String(ret_dados[6]));
                    _Retorno.Data_HoraEmissao = DateTime.ParseExact(ret_dados[7], "yyyyMMddHHmmss", null);
                    _Retorno.Chave = ret_dados[8];
                    _Retorno.AssinaturaQR = ret_dados[8] + "|" + ret_dados[7] + "|" + ret_dados[9] + "|" + ret_dados[10] + "|" + ret_dados[11];
                    break;

                case "11001":
                case "11002":
                case "11003":
                case "11098":
                case "11099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    //_Retorno.Cod_Erro = ret_dados[2];
                    _Retorno.Mensagem = ret_dados[2];
                    //_Retorno.Cod_msg_SEFAZ = ret_dados[4];
                    //_Retorno.Mensagem_SEFAZ = ret_dados[5];
                    break;
                #endregion

                #region ConfigurarInterfaceDeRede
                case "12000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "12001":
                case "12002":
                case "12098":
                case "12099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region AssociarAssinatura
                case "13000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "13001":
                case "13002":
                case "13003":
                case "13004":
                case "13098":
                case "13099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region AtualizarSoftwareSAT
                case "14000":
                case "14002":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "14001":
                case "14003":
                case "14004":
                case "14098":
                case "14099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region BloquearSAT
                case "16000":
                case "16002":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "16001":
                case "16003":
                case "16004":
                case "16098":
                case "16099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region DesbloquearSAT
                case "17000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;

                case "17001":
                case "17002":
                case "17003":
                case "17004":
                case "17098":
                case "17099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                #endregion

                #region ExtrairLogs
                case "15000":
                    _Retorno.Status = true;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    _Retorno.Logs = Trata_Log(Encoding.UTF8.GetString(Convert.FromBase64String(ret_dados[5])));
                    break;

                case "15001":
                case "15002":
                case "15098":
                case "15099":
                    _Retorno.Status = false;
                    _Retorno.NumeroSessao = Convert.ToInt32(ret_dados[0]);
                    _Retorno.Cod_Retorno = ret_dados[1];
                    _Retorno.Mensagem = ret_dados[2];
                    _Retorno.Cod_msg_SEFAZ = ret_dados[3];
                    _Retorno.Mensagem_SEFAZ = ret_dados[4];
                    break;
                    #endregion
            }
            return _Retorno;
        }

        private string AtivarSAT(int sessao, int Tipo_Certificado, string CNPJ_Contribuinte, int ID_UF)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);

                    case 4: // SAT BEMATECH 32
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // SAT BEMATECH 64
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.AtivarSAT(sessao, Tipo_Certificado, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJ_Contribuinte, ID_UF);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string EnviarDadosVenda(int sessao, string XML)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR                
                        XML = XML.Replace("<emit><CNPJ>08097009000174</CNPJ><IE>310410817119</IE>", "<emit><CNPJ>11111111111111</CNPJ><IE>111111111111</IE>");
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 4: //BEMATECH32                
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: //BEMATECH64                
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.EnviarDadosVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CancelarUltimaVenda(int sessao, string Chave, string XML)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR  
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);

                    case 4: //BEMATECH32     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: //BEMATECH64     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.CancelarUltimaVenda(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, Chave, XML);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConsultarSAT(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.ConsultarSAT(sessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.ConsultarSAT(sessao);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.ConsultarSAT(sessao);

                    case 4: //BEMATECH32      
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.ConsultarSAT(sessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: //BEMATECH64      
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.ConsultarSAT(sessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.ConsultarSAT(sessao);
                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string TesteFimAFim(int sessao, string XML)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 4: // BEMATECH32     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.TesteFimAFim(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);


                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConsultarNumeroSessao(int sessao, int ConsultaSessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR    
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);

                    case 4: // BEMATECH32     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.ConsultarNumeroSessao(ConsultaSessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, ConsultaSessao);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConsultarStatusOperacional(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 4: // BEMATECH32      
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64      
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.ConsultarStatusOperacional(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ConfigurarInterfaceDeRede(int sessao, string XML)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    case 4: // BEMATECH32        
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64        
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.ConfigurarInterfaceDeRede(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, XML);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string AssociarAssinatura(int sessao, string CNPJs, string Assinatura)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);

                    case 4: // BEMATECH32     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.AssociarAssinatura(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT, CNPJs, Assinatura);

                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string AtualizarSoftwareSAT(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR   
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 4: // BEMATECH32    
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.AtualizarSoftwareSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);


                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string BloquearSAT(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR    
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 4: // BEMATECH32 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64 
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.BloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);


                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string DesbloquearSAT(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR    
                        ptr = new IntPtr();
                        ptr = SAT_DLL_C.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 4: // BEMATECH32     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: // BEMATECH64     
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.DesbloquearSAT(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);


                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ExtrairLogs(int sessao)
        {
            try
            {
                IntPtr ptr;
                switch (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT)
                {
                    case 1: //EMULADOR                                   
                        ptr = SAT_DLL_C.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 2: // SAT.dll .NET
                        return SAT_DLL_DOTNET.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 3: // ElginSAT_I
                        return ElginSAT_I.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);

                    case 4: //BEMATECH32  
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH32.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 5: //BEMATECH64  
                        ptr = new IntPtr();
                        ptr = SAT_DLL_BEMATECH64.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);
                        return Marshal.PtrToStringAnsi(ptr);

                    case 6: // ElginSAT_II
                        return ElginSAT_II.ExtrairLogs(sessao, Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT);


                    default:
                        throw new Exception(util_msg.msg_TipoSATinvalido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string Trata_Log(string _Logs)
        {
            string[] aux = _Logs.Split('\n');
            string[] aux2;
            string Logs = string.Empty;

            for (int i = 0; i <= aux.Count() - 1; i++)
            {
                aux2 = aux[i].Split('|');
                try
                {
                    Logs += util_dados.Config_Data(DateTime.ParseExact(aux2[0], "yyyyMMddHHmmss", null), 15);
                }
                catch (Exception)
                {
                    Logs += aux2[0] + "|";
                }

                for (int ii = 1; ii <= aux2.Count() - 1; ii++)
                    Logs += "|" + aux2[ii];

                Logs += Environment.NewLine;
            }
            return Logs;
        }
    }
}

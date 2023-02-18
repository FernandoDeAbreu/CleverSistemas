using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public class Retorno
    {
        //SANTANDER HOMOLOGADO CNAB 240 - 13/09/2016
        #region 033 - SANTANDER
        private int Consulta_Tipo_Santander(string Linha)
        {
            return Convert.ToInt32(Linha.Substring(7, 1));
        }

        private string Consulta_Segmento_Santander(string Linha)
        {
            return Linha.Substring(13, 1);
        }

        private DTO_Retorno_HeaderAquivo240 Retorno_HeaderArq240_Santander(string Linha)
        {
            DTO_Retorno_HeaderAquivo240 aux = new DTO_Retorno_HeaderAquivo240();
            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(16, 1));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(18, 15), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Banco.Agencia = Linha.Substring(32, 5);
            aux.Banco.Conta = Linha.Substring(37, 10);
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(52, 9));
            aux.Cedente.DescricaoEmpresa = Linha.Substring(72, 30);
            aux.Cedente.DescricaoBanco = Linha.Substring(102, 30);
            aux.Remessa_Retorno = Convert.ToInt32(Linha.Substring(142, 1));
            aux.DataGer_Arq = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(143, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy")); ;
            aux.VersaoLayout = Convert.ToInt32(Linha.Substring(163, 3));

            return aux;
        }

        private DTO_Retorno_HeaderLote240 Retorno_HeaderLote240_Santander(string Linha)
        {
            DTO_Retorno_HeaderLote240 aux = new DTO_Retorno_HeaderLote240();
            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Retorno = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Operacao = Linha.Substring(8, 1);
            aux.Servico = Linha.Substring(9, 2);
            aux.VersaoLayout = Convert.ToInt32(Linha.Substring(13, 3));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(17, 1));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(19, 15), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(33, 9));
            aux.Banco.Agencia = Linha.Substring(53, 5);
            aux.Banco.Conta = Linha.Substring(58, 10);
            aux.Cedente.DescricaoEmpresa = Linha.Substring(73, 30);
            aux.ID_Retorno = Convert.ToInt32(Linha.Substring(183, 8));
            aux.DataGer_Arq = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(191, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy")); ;

            return aux;
        }

        private DTO_Retorno_SegmentoT Retorno_SegmentoT_Santander(string Linha)
        {
            DTO_Retorno_SegmentoT aux = new DTO_Retorno_SegmentoT();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Retorno = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Seq_RegistroLote = Convert.ToInt32(Linha.Substring(8, 5));
            aux.Cod_Segmento = Linha.Substring(13, 1);
            aux.ID_Movimento = Convert.ToInt32(Linha.Substring(15, 2));
            aux.Banco.Agencia = Linha.Substring(17, 5);
            aux.Banco.Conta = Linha.Substring(22, 10);
            aux.NossoNumero = Linha.Substring(40, 13);
            aux.Carteira = Convert.ToInt32(Linha.Substring(53, 1));
            aux.Documento = Linha.Substring(54, 15);
            aux.Vencimento = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(69, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Valor = Convert.ToDouble(Linha.Substring(77, 13) + "," + Linha.Substring(90, 2));
            aux.Banco_Recebedor = Linha.Substring(92, 3);
            aux.Agencia_Recebedor = Linha.Substring(95, 4);
            aux.Tipo_Documento = Convert.ToInt32(Linha.Substring(127, 1));
            aux.CNPJ_CPF_Sacado = util_dados.Conf_CPF_CNPJ(Linha.Substring(129, 15), (aux.Tipo_Documento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Nome_Sacado = Linha.Substring(143, 40);
            aux.Conta_Cobranca = Linha.Substring(183, 10);
            aux.Tarifa = Convert.ToDouble(Linha.Substring(193, 13) + "," + Linha.Substring(206, 2));
            aux.Ocorrencia = new int[5];
            aux.Ocorrencia[0] = Convert.ToInt32(Linha.Substring(208, 2));
            aux.Ocorrencia[1] = Convert.ToInt32(Linha.Substring(210, 2));
            aux.Ocorrencia[2] = Convert.ToInt32(Linha.Substring(212, 2));
            aux.Ocorrencia[3] = Convert.ToInt32(Linha.Substring(214, 2));
            aux.Ocorrencia[4] = Convert.ToInt32(Linha.Substring(216, 2));

            return aux;
        }

        private DTO_Retorno_SegmentoU Retorno_SegmentoU_Santander(string Linha)
        {
            DTO_Retorno_SegmentoU aux = new DTO_Retorno_SegmentoU();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Seq_RegistroLote = Convert.ToInt32(Linha.Substring(8, 5));
            aux.Cod_Segmento = Linha.Substring(13, 1);
            aux.Cod_Movimento = Convert.ToInt32(Linha.Substring(15, 2));
            aux.Acrescimo = Convert.ToDouble(Linha.Substring(17, 13) + "," + Linha.Substring(30, 2));
            aux.Desconto = Convert.ToDouble(Linha.Substring(32, 13) + "," + Linha.Substring(45, 2));
            aux.Abatimento = Convert.ToDouble(Linha.Substring(47, 13) + "," + Linha.Substring(60, 2));
            aux.IOF = Convert.ToDouble(Linha.Substring(62, 13) + "," + Linha.Substring(75, 2));
            aux.ValorPago = Convert.ToDouble(Linha.Substring(77, 13) + "," + Linha.Substring(90, 2));
            aux.ValorCreditado = Convert.ToDouble(Linha.Substring(92, 13) + "," + Linha.Substring(105, 2));
            aux.Despesas = Convert.ToDouble(Linha.Substring(107, 13) + "," + Linha.Substring(120, 2));
            aux.Creditos = Convert.ToDouble(Linha.Substring(122, 13) + "," + Linha.Substring(135, 2));
            aux.Data_Ocorrencia = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(137, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Data_Efetivacao = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(145, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Cod_Ocorrencia = Convert.ToInt32(Linha.Substring(153, 4));

            //aux.Data_Ocorrencia_Sacado = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(158, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.ValorOcorrencia = Convert.ToDouble(Linha.Substring(165, 13) + "," + Linha.Substring(179, 2));
            aux.Comp_Ocorrencia = Linha.Substring(180, 30);
            aux.Cod_Banco_Correspondente = Convert.ToInt32(Linha.Substring(210, 3));

            return aux;
        }

        private DTO_Retorno_TrailerLote240 Retorno_TrailerLote240_Santander(string Linha)
        {
            DTO_Retorno_TrailerLote240 aux = new DTO_Retorno_TrailerLote240();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Qt_Registro = Convert.ToInt32(Linha.Substring(17, 6));
            aux.Qt_Cob_Simples = Convert.ToInt32(Linha.Substring(23, 6));
            aux.Total_Cob_Simples = Convert.ToDouble(Linha.Substring(29, 15) + "," + Linha.Substring(45, 2));
            aux.Qt_Cob_Vinculada = Convert.ToInt32(Linha.Substring(46, 6));
            aux.Total_Cob_Vinculada = Convert.ToDouble(Linha.Substring(52, 15) + "," + Linha.Substring(68, 2));
            aux.Qt_Cob_Caucionada = Convert.ToInt32(Linha.Substring(69, 6));
            aux.Total_Cob_Caucionada = Convert.ToDouble(Linha.Substring(75, 15) + "," + Linha.Substring(91, 2));
            aux.Qt_Cob_Descontada = Convert.ToInt32(Linha.Substring(92, 6));
            aux.Total_Cob_Descontada = Convert.ToDouble(Linha.Substring(98, 15) + "," + Linha.Substring(114, 2));
            aux.Numero_Aviso = Convert.ToInt32(Linha.Substring(115, 8));

            return aux;
        }

        private DTO_Retorno_TrailerArquivo240 Retorno_TrailerArquivo240_Santander(string Linha)
        {
            DTO_Retorno_TrailerArquivo240 aux = new DTO_Retorno_TrailerArquivo240();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Remessa = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Qt_Lote = Convert.ToInt32(Linha.Substring(17, 6));
            aux.Qt_Registro = Convert.ToInt32(Linha.Substring(23, 6));

            return aux;
        }

        public DTO_Retorno_Santander240 Retorno_Santander240(Stream Arquivo)
        {
            try
            {
                DTO_Retorno_Santander240 aux = new DTO_Retorno_Santander240();
                aux.Seg_T = new List<DTO_Retorno_SegmentoT>();
                aux.Seg_U = new List<DTO_Retorno_SegmentoU>();

                StreamReader Ler = new StreamReader(Arquivo,  System.Text.Encoding.UTF8);

                string Linha = "";

                Linha = Ler.ReadLine();

                while (Consulta_Tipo_Santander(Linha) <= 9)
                {
                    switch (Consulta_Tipo_Santander(Linha))
                    {
                        case 0:
                            aux.Header_Arq = Retorno_HeaderArq240_Santander(Linha);
                            break;
                        case 1:
                            aux.Header_Lote = Retorno_HeaderLote240_Santander(Linha);
                            break;
                        case 2:
                            aux.Header_Arq = new DTO_Retorno_HeaderAquivo240();
                            aux.Header_Arq.Tratado = true;
                            Ler.Close();
                            return aux;
                        case 3:
                            if (Consulta_Segmento_Santander(Linha) == "T")
                                aux.Seg_T.Add(Retorno_SegmentoT_Santander(Linha));
                            else
                                aux.Seg_U.Add(Retorno_SegmentoU_Santander(Linha));
                            break;
                        case 5:
                            aux.Trailer_Lote = Retorno_TrailerLote240_Santander(Linha);
                            break;
                        case 9:
                            aux.Trailer_Arq = Retorno_TrailerArquivo240_Santander(Linha);
                            break;
                    }
                    Linha = Ler.ReadLine();
                    if (Linha == null)
                        break;
                }
                Ler.Close();
                return aux;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        //SICOOB HOMOLOGADO CNAB 400- 11/06/2016
        #region 756 - SICOOB
        private int Consulta_Tipo_Sicoob(string Linha)
        {
            return Convert.ToInt32(Linha.Substring(0, 1));
        }

        private DTO_Retorno_Header400 Retorno_Header400_Sicoob(string Linha)
        {
            DTO_Retorno_Header400 aux = new DTO_Retorno_Header400();
            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Operacao = Convert.ToInt32(Linha.Substring(1, 1));
            aux.DescricaoOperacao = Linha.Substring(2, 7);
            aux.Servico = Convert.ToInt32(Linha.Substring(9, 2));
            aux.DescricaoServico = Linha.Substring(11, 8);
            aux.Banco.Agencia = Linha.Substring(26, 5);
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(31, 9));
            aux.Cedente.Descricao = Linha.Substring(46, 30);
            aux.Banco.Descricao = Linha.Substring(76, 18);
            aux.DataRetorno = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(94, 6), "ddMMyy", null).ToString("dd/MM/yyyy")); ;

            return aux;
        }

        private DTO_Retorno_Detalhe400 Retorno_Detalhe400_Sicoob(string Linha)
        {
            DTO_Retorno_Detalhe400 aux = new DTO_Retorno_Detalhe400();

            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(1, 2));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(3, 14), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Banco.Agencia = Linha.Substring(17, 5);
            aux.Banco.Conta = Linha.Substring(22, 9);
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(31, 6));
            aux.NossoNumero = Linha.Substring(62, 12);
            aux.Parcela = Convert.ToInt32(Linha.Substring(74, 2));
            aux.Cod_Baixa = Convert.ToInt32(Linha.Substring(80, 2));
            aux.Carteira = Convert.ToInt32(Linha.Substring(106, 2));
            aux.Movimento = Convert.ToInt32(Linha.Substring(108, 2));
            aux.Data_Liquidacao = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(110, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));
            aux.Documento = Linha.Substring(116, 10);
            aux.Data_Vencimento = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(146, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));
            aux.ValorPago = Convert.ToDouble(Linha.Substring(152, 11) + "," + Linha.Substring(163, 2));
            aux.Banco_Recebedor = Linha.Substring(165, 3);
            aux.Agencia_Recebedor = Linha.Substring(168, 5);
            aux.Tipo_Titulo = Convert.ToInt32(Linha.Substring(173, 2));
            aux.Data_Credito = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(175, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));
            aux.Tarifa = Convert.ToDouble(Linha.Substring(181, 5) + "," + Linha.Substring(186, 2));
            aux.OutrasDespesas = Convert.ToDouble(Linha.Substring(188, 11) + "," + Linha.Substring(199, 2));
            aux.ValorAbatimento = Convert.ToDouble(Linha.Substring(227, 11) + "," + Linha.Substring(238, 2));
            aux.Desconto = Convert.ToDouble(Linha.Substring(240, 11) + "," + Linha.Substring(251, 2));
            aux.ValorPago = Convert.ToDouble(Linha.Substring(253, 11) + "," + Linha.Substring(264, 2));
            aux.ValorCreditado = Convert.ToDouble(Linha.Substring(253, 11) + "," + Linha.Substring(264, 2));

            return aux;
        }

        private DTO_Retorno_Trailler400 Retorno_Trailer400_Sicoob(string Linha)
        {
            DTO_Retorno_Trailler400 aux = new DTO_Retorno_Trailler400();

            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(3, 3));

            return aux;
        }

        public DTO_Retorno_Sicoob400 Retorno_Sicoob400(Stream Arquivo)
        {
            try
            {
                DTO_Retorno_Sicoob400 aux = new DTO_Retorno_Sicoob400();
                aux.Detalhe = new List<DTO_Retorno_Detalhe400>();

                StreamReader Ler = new StreamReader(Arquivo, System.Text.Encoding.UTF8);

                string Linha = "";

                Linha = Ler.ReadLine();

                while (Consulta_Tipo_Sicoob(Linha) <= 9)
                {
                    switch (Consulta_Tipo_Sicoob(Linha))
                    {
                        case 0:
                            aux.Header = Retorno_Header400_Sicoob(Linha);
                            break;
                        case 1:
                            //VERIFICA SE A LINHA É DE LIQUIDAÇÃO E NÃO DE OUTRA MOVIMENTAÇÃO
                            if (Convert.ToInt32(Linha.Substring(108, 2)) == 5 ||
                                Convert.ToInt32(Linha.Substring(108, 2)) == 6 ||
                                Convert.ToInt32(Linha.Substring(108, 2)) == 15)
                                aux.Detalhe.Add(Retorno_Detalhe400_Sicoob(Linha));
                            break;
                        case 2:
                            aux.Header = new DTO_Retorno_Header400();
                            aux.Header.Tratado = true;
                            Ler.Close();
                            return aux;
                        case 9:
                            aux.Trailler = Retorno_Trailer400_Sicoob(Linha);
                            break;
                    }
                    Linha = Ler.ReadLine();
                    if (Linha == null)
                        break;
                }
                Ler.Close();
                return aux;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 104 - CAIXA
        private int Consulta_Tipo_Caixa(string Linha)
        {
            return Convert.ToInt32(Linha.Substring(7, 1));
        }

        private string Consulta_Segmento_Caixa(string Linha)
        {
            return Linha.Substring(13, 1);
        }

        private DTO_Retorno_HeaderAquivo240 Retorno_HeaderArq240_Caixa(string Linha)
        {
            DTO_Retorno_HeaderAquivo240 aux = new DTO_Retorno_HeaderAquivo240();
            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(16, 1));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(18, 15), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Banco.Agencia = Linha.Substring(52, 5);
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(58, 6));
            aux.Cedente.DescricaoEmpresa = Linha.Substring(72, 30);
            aux.Cedente.DescricaoBanco = Linha.Substring(102, 30);
            aux.Remessa_Retorno = Convert.ToInt32(Linha.Substring(142, 1));
            aux.DataGer_Arq = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(143, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy")); ;
            aux.VersaoLayout = Convert.ToInt32(Linha.Substring(163, 3));

            return aux;
        }

        private DTO_Retorno_HeaderLote240 Retorno_HeaderLote240_Caixa(string Linha)
        {
            DTO_Retorno_HeaderLote240 aux = new DTO_Retorno_HeaderLote240();
            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Retorno = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Operacao = Linha.Substring(8, 1);
            aux.Servico = Linha.Substring(9, 2);
            aux.VersaoLayout = Convert.ToInt32(Linha.Substring(13, 3));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(17, 1));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(19, 15), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Cedente.Cod_Cedente = Convert.ToInt32(Linha.Substring(33, 6));
            aux.Banco.Agencia = Linha.Substring(53, 5);
            aux.Cedente.DescricaoEmpresa = Linha.Substring(73, 30);
            aux.ID_Retorno = Convert.ToInt32(Linha.Substring(183, 8));
            aux.DataGer_Arq = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(191, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy")); ;

            return aux;
        }

        private DTO_Retorno_SegmentoT Retorno_SegmentoT_Caixa(string Linha)
        {
            DTO_Retorno_SegmentoT aux = new DTO_Retorno_SegmentoT();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Retorno = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Seq_RegistroLote = Convert.ToInt32(Linha.Substring(8, 5));
            aux.Cod_Segmento = Linha.Substring(13, 1);
            aux.ID_Movimento = Convert.ToInt32(Linha.Substring(15, 2));
            aux.Banco.Agencia = Linha.Substring(17, 5);
            aux.NossoNumero = Linha.Substring(41, 15);
            aux.Carteira = Convert.ToInt32(Linha.Substring(57, 1));
            aux.Documento = Linha.Substring(58, 11);
            aux.Vencimento = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(73, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Valor = Convert.ToDouble(Linha.Substring(77, 13) + "," + Linha.Substring(81, 2));
            aux.Banco_Recebedor = Linha.Substring(96, 3);
            aux.Agencia_Recebedor = Linha.Substring(99, 5);
            aux.Tipo_Documento = Convert.ToInt32(Linha.Substring(132, 1));
            aux.CNPJ_CPF_Sacado = util_dados.Conf_CPF_CNPJ(Linha.Substring(133, 15), (aux.Tipo_Documento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Nome_Sacado = Linha.Substring(148, 40);
            aux.Tarifa = Convert.ToDouble(Linha.Substring(198, 11) + "," + Linha.Substring(210, 2));
            aux.Ocorrencia = new int[5];
            aux.Ocorrencia[0] = Convert.ToInt32(Linha.Substring(213, 2));
            aux.Ocorrencia[1] = Convert.ToInt32(Linha.Substring(215, 2));
            aux.Ocorrencia[2] = Convert.ToInt32(Linha.Substring(217, 2));
            aux.Ocorrencia[3] = Convert.ToInt32(Linha.Substring(219, 2));
            aux.Ocorrencia[4] = Convert.ToInt32(Linha.Substring(221, 2));

            return aux;
        }

        private DTO_Retorno_SegmentoU Retorno_SegmentoU_Caixa(string Linha)
        {
            DTO_Retorno_SegmentoU aux = new DTO_Retorno_SegmentoU();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Seq_RegistroLote = Convert.ToInt32(Linha.Substring(8, 5));
            aux.Cod_Segmento = Linha.Substring(13, 1);
            aux.Cod_Movimento = Convert.ToInt32(Linha.Substring(15, 2));
            aux.Acrescimo = Convert.ToDouble(Linha.Substring(17, 11) + "," + Linha.Substring(29, 2));
            aux.Desconto = Convert.ToDouble(Linha.Substring(32, 11) + "," + Linha.Substring(45, 2));
            aux.Abatimento = Convert.ToDouble(Linha.Substring(47, 11) + "," + Linha.Substring(60, 2));
            aux.IOF = Convert.ToDouble(Linha.Substring(62, 11) + "," + Linha.Substring(75, 2));
            aux.ValorPago = Convert.ToDouble(Linha.Substring(77, 11) + "," + Linha.Substring(90, 2));
            aux.ValorCreditado = Convert.ToDouble(Linha.Substring(92, 11) + "," + Linha.Substring(105, 2));
            aux.Despesas = Convert.ToDouble(Linha.Substring(107, 11) + "," + Linha.Substring(120, 2));
            aux.Creditos = Convert.ToDouble(Linha.Substring(122, 11) + "," + Linha.Substring(135, 2));
            aux.Data_Ocorrencia = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(137, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Data_Efetivacao = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(145, 8), "ddMMyyyy", null).ToString("dd/MM/yyyy"));
            aux.Cod_Banco_Correspondente = Convert.ToInt32(Linha.Substring(210, 3));

            return aux;
        }

        private DTO_Retorno_TrailerLote240 Retorno_TrailerLote240_Caixa(string Linha)
        {
            DTO_Retorno_TrailerLote240 aux = new DTO_Retorno_TrailerLote240();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Servico = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Qt_Registro = Convert.ToInt32(Linha.Substring(17, 6));
            aux.Qt_Cob_Simples = Convert.ToInt32(Linha.Substring(23, 6));
            aux.Total_Cob_Simples = Convert.ToDouble(Linha.Substring(29, 15) + "," + Linha.Substring(45, 2));
            aux.Qt_Cob_Caucionada = Convert.ToInt32(Linha.Substring(46, 6));
            aux.Total_Cob_Caucionada = Convert.ToDouble(Linha.Substring(52, 15) + "," + Linha.Substring(91, 2));
            aux.Qt_Cob_Descontada = Convert.ToInt32(Linha.Substring(69, 6));
            aux.Total_Cob_Descontada = Convert.ToDouble(Linha.Substring(75, 15) + "," + Linha.Substring(114, 2));

            return aux;
        }

        private DTO_Retorno_TrailerArquivo240 Retorno_TrailerArquivo240_Caixa(string Linha)
        {
            DTO_Retorno_TrailerArquivo240 aux = new DTO_Retorno_TrailerArquivo240();

            Linha = Linha.Replace("'", "");

            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(0, 3));
            aux.ID_Lote_Remessa = Convert.ToInt32(Linha.Substring(3, 4));
            aux.Tipo = Convert.ToInt32(Linha.Substring(7, 1));
            aux.Qt_Lote = Convert.ToInt32(Linha.Substring(17, 6));
            aux.Qt_Registro = Convert.ToInt32(Linha.Substring(23, 6));

            return aux;
        }

        public DTO_Retorno_Caixa240 Retorno_Caixa240(Stream Arquivo)
        {
            try
            {
                DTO_Retorno_Caixa240 aux = new DTO_Retorno_Caixa240();
                aux.Seg_T = new List<DTO_Retorno_SegmentoT>();
                aux.Seg_U = new List<DTO_Retorno_SegmentoU>();

                StreamReader Ler = new StreamReader(Arquivo, System.Text.Encoding.UTF8);

                string Linha = "";

                Linha = Ler.ReadLine();

                while (Consulta_Tipo_Caixa(Linha) <= 9)
                {
                    switch (Consulta_Tipo_Caixa(Linha))
                    {
                        case 0:
                            aux.Header_Arq = Retorno_HeaderArq240_Caixa(Linha);
                            break;
                        case 1:
                            aux.Header_Lote = Retorno_HeaderLote240_Caixa(Linha);
                            break;
                        case 2:
                            aux.Header_Arq = new DTO_Retorno_HeaderAquivo240();
                            aux.Header_Arq.Tratado = true;
                            Ler.Close();
                            return aux;
                        case 3:
                            if (Consulta_Segmento_Caixa(Linha) == "T")
                                aux.Seg_T.Add(Retorno_SegmentoT_Caixa(Linha));
                            else
                                aux.Seg_U.Add(Retorno_SegmentoU_Caixa(Linha));
                            break;
                        case 5:
                            aux.Trailer_Lote = Retorno_TrailerLote240_Caixa(Linha);
                            break;
                        case 9:
                            aux.Trailer_Arq = Retorno_TrailerArquivo240_Caixa(Linha);
                            break;
                    }
                    Linha = Ler.ReadLine();
                    if (Linha == null)
                        break;
                }
                Ler.Close();
                return aux;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        //BRADESCO HOMOLOGADO CNAB 400 - 28/11/2016
        #region 237 - BRADESCO
        private int Consulta_Tipo_Bradesco(string Linha)
        {
            return Convert.ToInt32(Linha.Substring(0, 1));
        }

        private DTO_Retorno_Header400 Retorno_Header400_Bradesco(string Linha)
        {
            DTO_Retorno_Header400 aux = new DTO_Retorno_Header400();
            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Operacao = Convert.ToInt32(Linha.Substring(1, 1));
            aux.DescricaoOperacao = Linha.Substring(2, 7);
            aux.Servico = Convert.ToInt32(Linha.Substring(9, 2));
            aux.DescricaoServico = Linha.Substring(11, 15);
            aux.Banco.Descricao = Linha.Substring(79, 15);
            aux.DataRetorno = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(94, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));

            return aux;
        }

        private DTO_Retorno_Detalhe400 Retorno_Detalhe400_Bradesco(string Linha)
        {
            DTO_Retorno_Detalhe400 aux = new DTO_Retorno_Detalhe400();

            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Cedente.TipoDocumento = Convert.ToInt32(Linha.Substring(1, 2));
            aux.Cedente.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(Linha.Substring(3, 14), (aux.Cedente.TipoDocumento == 1 ? Documento.CPF : Documento.CNPJ));
            aux.Banco.Agencia = Linha.Substring(24, 4);
            aux.Banco.Conta = Linha.Substring(29, 7);
            aux.NossoNumero = Linha.Substring(70, 11);
            aux.Carteira = Convert.ToInt32(Linha.Substring(21, 2));
            aux.Data_Liquidacao = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(110, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));
            aux.Documento = Linha.Substring(116, 10);
            aux.ValorPago = Convert.ToDouble(Linha.Substring(253, 11) + "," + Linha.Substring(264, 2));
            aux.Data_Credito = Convert.ToDateTime(DateTime.ParseExact(Linha.Substring(110, 6), "ddMMyy", null).ToString("dd/MM/yyyy"));
            aux.Tarifa = Convert.ToDouble(Linha.Substring(175, 11) + "," + Linha.Substring(186, 2));
            
            return aux;
        }

        private DTO_Retorno_Trailler400 Retorno_Trailer400_Bradesco(string Linha)
        {
            DTO_Retorno_Trailler400 aux = new DTO_Retorno_Trailler400();

            Linha = Linha.Replace("'", "");

            aux.Tipo = Convert.ToInt32(Linha.Substring(0, 1));
            aux.Banco.ID_Banco = Convert.ToInt32(Linha.Substring(4, 3));

            return aux;
        }

        public DTO_Retorno_Bradesco400 Retorno_Bradesco400(Stream Arquivo)
        {
            try
            {
                DTO_Retorno_Bradesco400 aux = new DTO_Retorno_Bradesco400();
                aux.Detalhe = new List<DTO_Retorno_Detalhe400>();

                StreamReader Ler = new StreamReader(Arquivo, System.Text.Encoding.UTF8);

                string Linha = "";

                Linha = Ler.ReadLine();

                while (Consulta_Tipo_Bradesco(Linha) <= 9)
                {
                    switch (Consulta_Tipo_Bradesco(Linha))
                    {
                        case 0:
                            aux.Header = Retorno_Header400_Bradesco(Linha);
                            break;
                        case 1:
                            aux.Detalhe.Add(Retorno_Detalhe400_Bradesco(Linha));
                            break;
                        case 2:
                            aux.Header = new DTO_Retorno_Header400();
                            aux.Header.Tratado = true;
                            Ler.Close();
                            return aux;
                        case 9:
                            aux.Trailler = Retorno_Trailer400_Bradesco(Linha);
                            break;
                    }
                    Linha = Ler.ReadLine();
                    if (Linha == null)
                        break;
                }
                Ler.Close();
                return aux;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}

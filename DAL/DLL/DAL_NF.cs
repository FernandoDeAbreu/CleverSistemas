using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_NF
    {
        #region VARIAVEIS DE CLASSE
        Conexao conexao;
        #endregion

        #region VARIAVEIS DIVERAS
        string sql;
        SqlCommand cmd;

        DataRow DR;
        #endregion

        #region ESTRUTURA
        DTO_NF NF;
        // DTO_TipoNF_Serie TipoNF;
        #endregion

        #region CONSTRUTORES
        public DAL_NF(DTO_NF _NF)
        {
            this.NF = _NF;
        }
        #endregion

        public int Grava()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();
                #region NOTA FISCAL INFORMAÇÕES
                if (NF.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "NotaFiscal ";
                    sql += "(ID_Empresa, Serie, ID_NFe, DataEmissao, DataSaida, DataContigencia, TipoDocumento, FinalidadeEmissao, ";
                    sql += "FormaEmissao, FormaPagto, TipoImpressao, TipoFrete, Situacao, TipoPessoa, ID_Pessoa, Dig_Verificador, ";
                    sql += "IE_Substituicao, ValorBC, ValorICMS, ValorICMSDesonerado, ValorBCST, ValorST, ValorProduto, ValorFrete, ValorSeguro, ValorDesconto, ";
                    sql += "ValorImportacao, ValorIPI, ValorPIS, ValorCOFINS, ValorOutro, ValorTotal, NaturezaOperacao, Justificativa, ";
                    sql += "InformacaoAdicional, InformacaoFisco, Tipo_NF, ConsumidorFinal, PresencaConsumidor, Modelo, CNPJ_CPF_Destinatario, Trib_Federal, Trib_Estadual, ";
                    sql += "Trib_Municipal, ID_Venda, Controle_CF, ID_OS) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Serie, @ID_NFe, @DataEmissao, @DataSaida, @DataContigencia, @TipoDocumento, @FinalidadeEmissao, ";
                    sql += "@FormaEmissao, @FormaPagto, @TipoImpressao, @TipoFrete, @Situacao, @TipoPessoa, @ID_Pessoa, @Dig_Verificador, ";
                    sql += "@IE_Substituicao, @ValorBC, @ValorICMS, @ValorICMSDesonerado, @ValorBCST, @ValorST, @ValorProduto, @ValorFrete, @ValorSeguro, @ValorDesconto, ";
                    sql += "@ValorImportacao, @ValorIPI, @ValorPIS, @ValorCOFINS, @ValorOutro, @ValorTotal, @NaturezaOperacao, @Justificativa, ";
                    sql += "@InformacaoAdicional, @InformacaoFisco, @Tipo_NF, @ConsumidorFinal, @PresencaConsumidor, @Modelo, @CNPJ_CPF_Destinatario, @Trib_Federal, @Trib_Estadual, ";
                    sql += "@Trib_Municipal, @ID_Venda, @Controle_CF, @ID_OS) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", NF.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Serie", NF.Serie);
                    cmd.Parameters.AddWithValue("@ID_NFe", NF.ID_NFe);
                    cmd.Parameters.AddWithValue("@DataEmissao", NF.DataEmissao);
                    cmd.Parameters.AddWithValue("@DataSaida", NF.DataSaida);
                    cmd.Parameters.AddWithValue("@DataContigencia", NF.DataContigencia);
                    cmd.Parameters.AddWithValue("@TipoDocumento", NF.TipoDocumento);
                    cmd.Parameters.AddWithValue("@FinalidadeEmissao", NF.FinalidadeEmissao);
                    cmd.Parameters.AddWithValue("@FormaEmissao", NF.FormaEmissao);
                    cmd.Parameters.AddWithValue("@FormaPagto", NF.FormaPagto);
                    cmd.Parameters.AddWithValue("@TipoImpressao", NF.TipoImpressao);
                    cmd.Parameters.AddWithValue("@TipoFrete", NF.TipoFrete);
                    cmd.Parameters.AddWithValue("@Situacao", NF.Situacao);
                    cmd.Parameters.AddWithValue("@TipoPessoa", NF.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", NF.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Dig_Verificador", NF.Dig_Verificador);
                    cmd.Parameters.AddWithValue("@IE_Substituicao", NF.IE_Substituicao);
                    cmd.Parameters.AddWithValue("@ValorBC", NF.ValorBC);
                    cmd.Parameters.AddWithValue("@ValorICMS", NF.ValorICMS);
                    cmd.Parameters.AddWithValue("@ValorICMSDesonerado", NF.ValorICMSDesonerado);
                    cmd.Parameters.AddWithValue("@ValorBCST", NF.ValorBCST);
                    cmd.Parameters.AddWithValue("@ValorST", NF.ValorST);
                    cmd.Parameters.AddWithValue("@ValorProduto", NF.ValorProduto);
                    cmd.Parameters.AddWithValue("@ValorFrete", NF.ValorFrete);
                    cmd.Parameters.AddWithValue("@ValorSeguro", NF.ValorSeguro);
                    cmd.Parameters.AddWithValue("@ValorDesconto", NF.ValorDesconto);
                    cmd.Parameters.AddWithValue("@ValorImportacao", NF.ValorImportacao);
                    cmd.Parameters.AddWithValue("@ValorIPI", NF.ValorIPI);
                    cmd.Parameters.AddWithValue("@ValorPIS", NF.ValorPIS);
                    cmd.Parameters.AddWithValue("@ValorCOFINS", NF.ValorCOFINS);
                    cmd.Parameters.AddWithValue("@ValorOutro", NF.ValorOutro);
                    cmd.Parameters.AddWithValue("@ValorTotal", NF.ValorTotal);
                    cmd.Parameters.AddWithValue("@NaturezaOperacao", NF.NaturezaOperacao);
                    cmd.Parameters.AddWithValue("@Justificativa", NF.Justificativa);
                    cmd.Parameters.AddWithValue("@InformacaoAdicional", NF.InformacaoAdicional);
                    cmd.Parameters.AddWithValue("@InformacaoFisco", NF.InformacaoFisco);
                    cmd.Parameters.AddWithValue("@Tipo_NF", NF.Tipo_NF);
                    cmd.Parameters.AddWithValue("@ConsumidorFinal", NF.ConsumidorFinal);
                    cmd.Parameters.AddWithValue("@PresencaConsumidor", NF.PresencaConsumidor);
                    cmd.Parameters.AddWithValue("@Modelo", NF.Modelo);
                    cmd.Parameters.AddWithValue("@CNPJ_CPF_Destinatario", NF.CNPJ_CPF_Destinatario);
                    cmd.Parameters.AddWithValue("@Trib_Federal", NF.Trib_Federal);
                    cmd.Parameters.AddWithValue("@Trib_Estadual", NF.Trib_Estadual);
                    cmd.Parameters.AddWithValue("@Trib_Municipal", NF.Trib_Municipal);
                    cmd.Parameters.AddWithValue("@ID_Venda", NF.ID_Venda);
                    cmd.Parameters.AddWithValue("@Controle_CF", NF.Controle_CF);
                    cmd.Parameters.AddWithValue("@ID_OS", NF.ID_OS);
                    NF.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "NotaFiscal ";
                    sql += "SET ";
                    sql += "Serie = @Serie, ";
                    sql += "ID_NFe = @ID_NFe, ";
                    sql += "DataEmissao = @DataEmissao, ";
                    sql += "DataSaida = @DataSaida, ";
                    sql += "DataContigencia = @DataContigencia, ";
                    sql += "TipoDocumento = @TipoDocumento, ";
                    sql += "FinalidadeEmissao = @FinalidadeEmissao, ";
                    sql += "FormaEmissao = @FormaEmissao, ";
                    sql += "FormaPagto = @FormaPagto, ";
                    sql += "TipoImpressao = @TipoImpressao, ";
                    sql += "TipoFrete = @TipoFrete, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Dig_Verificador = @Dig_Verificador, ";
                    sql += "IE_Substituicao = @IE_Substituicao, ";
                    sql += "ValorBC = @ValorBC, ";
                    sql += "ValorICMS = @ValorICMS, ";
                    sql += "ValorICMSDesonerado = @ValorICMSDesonerado, ";
                    sql += "ValorBCST = @ValorBCST, ";
                    sql += "ValorST = @ValorST, ";
                    sql += "ValorProduto = @ValorProduto, ";
                    sql += "ValorFrete = @ValorFrete, ";
                    sql += "ValorSeguro = @ValorSeguro, ";
                    sql += "ValorDesconto = @ValorDesconto, ";
                    sql += "ValorImportacao = @ValorImportacao, ";
                    sql += "ValorIPI = @ValorIPI, ";
                    sql += "ValorPIS = @ValorPIS, ";
                    sql += "ValorCOFINS = @ValorCOFINS, ";
                    sql += "ValorOutro = @ValorOutro, ";
                    sql += "ValorTotal = @ValorTotal, ";
                    sql += "NaturezaOperacao = @NaturezaOperacao, ";
                    sql += "Justificativa = @Justificativa , ";
                    sql += "InformacaoAdicional = @InformacaoAdicional, ";
                    sql += "InformacaoFisco = @InformacaoFisco, ";
                    sql += "Tipo_NF = @Tipo_NF, ";
                    sql += "ConsumidorFinal = @ConsumidorFinal, ";
                    sql += "PresencaConsumidor = @PresencaConsumidor, ";
                    sql += "Trib_Federal = @Trib_Federal, ";
                    sql += "Trib_Estadual = @Trib_Estadual, ";
                    sql += "Trib_Municipal = @Trib_Municipal, ";
                    sql += "ID_Venda = @ID_Venda, ";
                    sql += "ID_OS = @ID_OS ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", NF.ID);
                    cmd.Parameters.AddWithValue("@Serie", NF.Serie);
                    cmd.Parameters.AddWithValue("@ID_NFe", NF.ID_NFe);
                    cmd.Parameters.AddWithValue("@DataEmissao", NF.DataEmissao);
                    cmd.Parameters.AddWithValue("@DataSaida", NF.DataSaida);
                    cmd.Parameters.AddWithValue("@DataContigencia", NF.DataContigencia);
                    cmd.Parameters.AddWithValue("@TipoDocumento", NF.TipoDocumento);
                    cmd.Parameters.AddWithValue("@FinalidadeEmissao", NF.FinalidadeEmissao);
                    cmd.Parameters.AddWithValue("@FormaEmissao", NF.FormaEmissao);
                    cmd.Parameters.AddWithValue("@FormaPagto", NF.FormaPagto);
                    cmd.Parameters.AddWithValue("@TipoImpressao", NF.TipoImpressao);
                    cmd.Parameters.AddWithValue("@TipoFrete", NF.TipoFrete);
                    cmd.Parameters.AddWithValue("@Situacao", NF.Situacao);
                    cmd.Parameters.AddWithValue("@TipoPessoa", NF.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", NF.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Dig_Verificador", NF.Dig_Verificador);
                    cmd.Parameters.AddWithValue("@IE_Substituicao", NF.IE_Substituicao);
                    cmd.Parameters.AddWithValue("@ValorBC", NF.ValorBC);
                    cmd.Parameters.AddWithValue("@ValorICMS", NF.ValorICMS);
                    cmd.Parameters.AddWithValue("@ValorICMSDesonerado", NF.ValorICMSDesonerado);
                    cmd.Parameters.AddWithValue("@ValorBCST", NF.ValorBCST);
                    cmd.Parameters.AddWithValue("@ValorST", NF.ValorST);
                    cmd.Parameters.AddWithValue("@ValorProduto", NF.ValorProduto);
                    cmd.Parameters.AddWithValue("@ValorFrete", NF.ValorFrete);
                    cmd.Parameters.AddWithValue("@ValorSeguro", NF.ValorSeguro);
                    cmd.Parameters.AddWithValue("@ValorDesconto", NF.ValorDesconto);
                    cmd.Parameters.AddWithValue("@ValorImportacao", NF.ValorImportacao);
                    cmd.Parameters.AddWithValue("@ValorIPI", NF.ValorIPI);
                    cmd.Parameters.AddWithValue("@ValorPIS", NF.ValorPIS);
                    cmd.Parameters.AddWithValue("@ValorCOFINS", NF.ValorCOFINS);
                    cmd.Parameters.AddWithValue("@ValorOutro", NF.ValorOutro);
                    cmd.Parameters.AddWithValue("@ValorTotal", NF.ValorTotal);
                    cmd.Parameters.AddWithValue("@NaturezaOperacao", NF.NaturezaOperacao);
                    cmd.Parameters.AddWithValue("@Justificativa", NF.Justificativa);
                    cmd.Parameters.AddWithValue("@InformacaoAdicional", NF.InformacaoAdicional);
                    cmd.Parameters.AddWithValue("@InformacaoFisco", NF.InformacaoFisco);
                    cmd.Parameters.AddWithValue("@Tipo_NF", NF.Tipo_NF);
                    cmd.Parameters.AddWithValue("@ConsumidorFinal", NF.ConsumidorFinal);
                    cmd.Parameters.AddWithValue("@PresencaConsumidor", NF.PresencaConsumidor);
                    cmd.Parameters.AddWithValue("@Trib_Federal", NF.Trib_Federal);
                    cmd.Parameters.AddWithValue("@Trib_Estadual", NF.Trib_Estadual);
                    cmd.Parameters.AddWithValue("@Trib_Municipal", NF.Trib_Municipal);
                    cmd.Parameters.AddWithValue("@ID_Venda", NF.ID_Venda);
                    cmd.Parameters.AddWithValue("@ID_OS", NF.ID_OS);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region AUTORIZACAO DE ACESSO XML
                if (NF.Autorizacao_XML != null &&
                    NF.Autorizacao_XML.Count > 0)
                    for (int i = 0; i <= NF.Autorizacao_XML.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (NF.Autorizacao_XML[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "NotaFiscal_AutXML ";
                            sql += "(ID_NF, CNPJ_CPF) ";
                            sql += "VALUES ";
                            sql += "(@ID_NF, @CNPJ_CPF) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                            cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Autorizacao_XML[i].CNPJ_CPF);

                            NF.Autorizacao_XML[i].ID = conexao.Executa_ComandoID(cmd);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "NotaFiscal_AutXML ";
                            sql += "SET ";
                            sql += "CNPJ_CPF = @CNPJ_CPF ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", NF.Autorizacao_XML[i].ID);
                            cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Autorizacao_XML[i].CNPJ_CPF);

                            conexao.Executa_Comando(cmd);
                        }
                    }
                #endregion

                #region NOTA FISCAL ITEM
                if (NF.Itens.Count > 0)
                    for (int i = 0; i <= NF.Itens.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (NF.Itens[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "NotaFiscal_Item ";
                            sql += "(ID_NF, ID_Produto, Quantidade, ID_Tabela, ValorUnitario, ValorTotal, Acrescimo, Desconto, InformacaoAdicional, TipoVendaProduto, ID_Grade, EX_TIPI, ";
                            sql += "Quantidade_Selo, ClasseEnquadramento, CNPJProdutor, Codigo_Selo, CST, Origem, ModalidadeBC, AliquotaICMS, PercentualReducao, ModalidadeBCST, ";
                            sql += "AliquotaICMSST, PercentualReducaoST, MargemVLAdicionado, CFOP, Frete, Seguro, ValorBC, ValorICMS, ValorBCST, ValorICMSST, ValorBCSTRet, ValorICMSSTRet, ";
                            sql += "CSOSN, AliquotaCredito, ValorCredito, CSTIPI, AliquotaIPI, ValorIPI, ValorBCII, ValorDesII, ValorII, ValorIOF, CSTPIS, AliquotaPIS, ValorPIS, ";
                            sql += "ValorAliquotaPIS, CSTCOFINS, AliquotaCOFINS, ValorCOFINS, ValorAliquotaCOFINS, ValorICMSOperacao, PercentualDiferimento, ValorICMSDeferido, ValorICMSDesonerado, ";
                            sql += "MotivoDesonerado, IPIDevolvido, Per_IPIDevolvido) ";
                            sql += "VALUES ";
                            sql += "(@ID_NF, @ID_Produto, @Quantidade, @ID_Tabela, @ValorUnitario, @ValorTotal, @Acrescimo, @Desconto, @InformacaoAdicional, @TipoVendaProduto, @ID_Grade, @EX_TIPI, ";
                            sql += "@Quantidade_Selo, @ClasseEnquadramento, @CNPJProdutor, @Codigo_Selo, @CST, @Origem, @ModalidadeBC, @AliquotaICMS, @PercentualReducao, @ModalidadeBCST, ";
                            sql += "@AliquotaICMSST, @PercentualReducaoST, @MargemVLAdicionado, @CFOP, @Frete, @Seguro, @ValorBC, @ValorICMS, @ValorBCST, @ValorICMSST, @ValorBCSTRet, @ValorICMSSTRet, ";
                            sql += "@CSOSN, @AliquotaCredito, @ValorCredito, @CSTIPI, @AliquotaIPI, @ValorIPI, @ValorBCII, @ValorDesII, @ValorII, @ValorIOF, @CSTPIS, @AliquotaPIS, @ValorPIS, ";
                            sql += "@ValorAliquotaPIS, @CSTCOFINS, @AliquotaCOFINS, @ValorCOFINS, @ValorAliquotaCOFINS, @ValorICMSOperacao, @PercentualDiferimento, @ValorICMSDeferido, @ValorICMSDesonerado, ";
                            sql += "@MotivoDesonerado, @IPIDevolvido, @Per_IPIDevolvido) ";
                            cmd.CommandText = sql;

                            cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", NF.Itens[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", NF.Itens[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", NF.Itens[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorUnitario", NF.Itens[i].ValorUnitario);
                            cmd.Parameters.AddWithValue("@ValorTotal", NF.Itens[i].ValorTotal);
                            cmd.Parameters.AddWithValue("@Acrescimo", NF.Itens[i].Acrescimo);
                            cmd.Parameters.AddWithValue("@Desconto", NF.Itens[i].Desconto);
                            cmd.Parameters.AddWithValue("@InformacaoAdicional", NF.Itens[i].InformacaoAdicional);
                            cmd.Parameters.AddWithValue("@TipoVendaProduto", NF.Itens[i].TipoVendaProduto);
                            cmd.Parameters.AddWithValue("@ID_Grade", NF.Itens[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@EX_TIPI", NF.Itens[i].EX_TIPI);
                            cmd.Parameters.AddWithValue("@Quantidade_Selo", NF.Itens[i].Quantidade_Selo);
                            cmd.Parameters.AddWithValue("@ClasseEnquadramento", NF.Itens[i].ClasseEnquadramento);
                            cmd.Parameters.AddWithValue("@CNPJProdutor", NF.Itens[i].CNPJProdutor);
                            cmd.Parameters.AddWithValue("@Codigo_Selo", NF.Itens[i].Codigo_Selo);
                            cmd.Parameters.AddWithValue("@CST", NF.Itens[i].CST);
                            cmd.Parameters.AddWithValue("@Origem", NF.Itens[i].Origem);
                            cmd.Parameters.AddWithValue("@ModalidadeBC", NF.Itens[i].ModalidadeBC);
                            cmd.Parameters.AddWithValue("@AliquotaICMS", NF.Itens[i].AliquotaICMS);
                            cmd.Parameters.AddWithValue("@PercentualReducao", NF.Itens[i].PercentualReducao);
                            cmd.Parameters.AddWithValue("@ModalidadeBCST", NF.Itens[i].ModalidadeBCST);
                            cmd.Parameters.AddWithValue("@AliquotaICMSST", NF.Itens[i].AliquotaICMSST);
                            cmd.Parameters.AddWithValue("@PercentualReducaoST", NF.Itens[i].PercentualReducaoST);
                            cmd.Parameters.AddWithValue("@MargemVLAdicionado", NF.Itens[i].MargemVLAdicionado);
                            cmd.Parameters.AddWithValue("@CFOP", NF.Itens[i].CFOP);
                            cmd.Parameters.AddWithValue("@Frete", NF.Itens[i].Frete);
                            cmd.Parameters.AddWithValue("@Seguro", NF.Itens[i].Seguro);
                            cmd.Parameters.AddWithValue("@ValorBC", NF.Itens[i].ValorBC);
                            cmd.Parameters.AddWithValue("@ValorICMS", NF.Itens[i].ValorICMS);
                            cmd.Parameters.AddWithValue("@ValorBCST", NF.Itens[i].ValorBCST);
                            cmd.Parameters.AddWithValue("@ValorICMSST", NF.Itens[i].ValorICMSST);
                            cmd.Parameters.AddWithValue("@ValorBCSTRet", NF.Itens[i].ValorBCSTRet);
                            cmd.Parameters.AddWithValue("@ValorICMSSTRet", NF.Itens[i].ValorICMSSTRet);
                            cmd.Parameters.AddWithValue("@CSOSN", NF.Itens[i].CSOSN);
                            cmd.Parameters.AddWithValue("@AliquotaCredito", NF.Itens[i].AliquotaCredito);
                            cmd.Parameters.AddWithValue("@ValorCredito", NF.Itens[i].ValorCredito);
                            cmd.Parameters.AddWithValue("@CSTIPI", NF.Itens[i].CSTIPI);
                            cmd.Parameters.AddWithValue("@AliquotaIPI", NF.Itens[i].AliquotaIPI);
                            cmd.Parameters.AddWithValue("@ValorIPI", NF.Itens[i].ValorIPI);
                            cmd.Parameters.AddWithValue("@ValorBCII", NF.Itens[i].ValorBCII);
                            cmd.Parameters.AddWithValue("@ValorDesII", NF.Itens[i].ValorDesII);
                            cmd.Parameters.AddWithValue("@ValorII", NF.Itens[i].ValorII);
                            cmd.Parameters.AddWithValue("@ValorIOF", NF.Itens[i].ValorIOF);
                            cmd.Parameters.AddWithValue("@CSTPIS", NF.Itens[i].CSTPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPIS", NF.Itens[i].AliquotaPIS);
                            cmd.Parameters.AddWithValue("@ValorPIS", NF.Itens[i].ValorPIS);
                            cmd.Parameters.AddWithValue("@ValorAliquotaPIS", NF.Itens[i].ValorAliquotaPIS);
                            cmd.Parameters.AddWithValue("@CSTCOFINS", NF.Itens[i].CSTCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINS", NF.Itens[i].AliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@ValorCOFINS", NF.Itens[i].ValorCOFINS);
                            cmd.Parameters.AddWithValue("@ValorAliquotaCOFINS", NF.Itens[i].ValorAliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@ValorICMSOperacao", NF.Itens[i].ValorICMSOperacao);
                            cmd.Parameters.AddWithValue("@PercentualDiferimento", NF.Itens[i].PercentualDiferimento);
                            cmd.Parameters.AddWithValue("@ValorICMSDeferido", NF.Itens[i].ValorICMSDeferido);
                            cmd.Parameters.AddWithValue("@ValorICMSDesonerado", NF.Itens[i].ValorICMSDesonerado);
                            cmd.Parameters.AddWithValue("@MotivoDesonerado", NF.Itens[i].MotivoDesonerado);
                            cmd.Parameters.AddWithValue("@IPIDevolvido", NF.Itens[i].IPIDevolvido);
                            cmd.Parameters.AddWithValue("@Per_IPIDevolvido", NF.Itens[i].Per_IPIDevolvido);

                            NF.Itens[i].ID = conexao.Executa_ComandoID(cmd);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "NotaFiscal_Item ";
                            sql += "SET ";
                            sql += "ID_Produto = @ID_Produto, ";
                            sql += "Quantidade = @Quantidade, ";
                            sql += "ID_Tabela = @ID_Tabela, ";
                            sql += "ValorUnitario= @ValorUnitario, ";
                            sql += "ValorTotal = @ValorTotal, ";
                            sql += "Acrescimo = @Acrescimo, ";
                            sql += "Desconto = @Desconto, ";
                            sql += "InformacaoAdicional = @InformacaoAdicional, ";
                            sql += "TipoVendaProduto = @TipoVendaProduto, ";
                            sql += "ID_Grade = @ID_Grade, ";
                            sql += "EX_TIPI = @EX_TIPI, ";
                            sql += "Quantidade_Selo = @Quantidade_Selo, ";
                            sql += "ClasseEnquadramento = @ClasseEnquadramento, ";
                            sql += "CNPJProdutor = @CNPJProdutor, ";
                            sql += "Codigo_Selo = Codigo_Selo, ";
                            sql += "CST = @CST, ";
                            sql += "Origem = Origem, ";
                            sql += "ModalidadeBC = @ModalidadeBC, ";
                            sql += "AliquotaICMS = @AliquotaICMS, ";
                            sql += "PercentualReducao = @PercentualReducao, ";
                            sql += "ModalidadeBCST = @ModalidadeBCST, ";
                            sql += "AliquotaICMSST = @AliquotaICMSST, ";
                            sql += "PercentualReducaoST = @PercentualReducaoST, ";
                            sql += "MargemVLAdicionado = @MargemVLAdicionado, ";
                            sql += "CFOP = @CFOP, ";
                            sql += "Frete = @Frete, ";
                            sql += "Seguro = @Seguro, ";
                            sql += "ValorBC = @ValorBC, ";
                            sql += "ValorICMS = @ValorICMS, ";
                            sql += "ValorBCST = @ValorBCST, ";
                            sql += "ValorICMSST = @ValorICMSST, ";
                            sql += "ValorBCSTRet = @ValorBCSTRet, ";
                            sql += "ValorICMSSTRet = @ValorICMSSTRet, ";
                            sql += "CSOSN = @CSOSN, ";
                            sql += "AliquotaCredito = @AliquotaCredito, ";
                            sql += "ValorCredito = @ValorCredito, ";
                            sql += "CSTIPI = @CSTIPI, ";
                            sql += "AliquotaIPI = @AliquotaIPI, ";
                            sql += "ValorIPI = @ValorIPI, ";
                            sql += "ValorBCII = @ValorBCII, ";
                            sql += "ValorDesII = @ValorDesII, ";
                            sql += "ValorII = @ValorII, ";
                            sql += "ValorIOF = @ValorIOF, ";
                            sql += "CSTPIS = @CSTPIS, ";
                            sql += "AliquotaPIS = @AliquotaPIS, ";
                            sql += "ValorPIS = @ValorPIS, ";
                            sql += "ValorAliquotaPIS = ValorAliquotaPIS, ";
                            sql += "CSTCOFINS = @CSTCOFINS, ";
                            sql += "AliquotaCOFINS = @AliquotaCOFINS, ";
                            sql += "ValorCOFINS = @ValorCOFINS, ";
                            sql += "ValorAliquotaCOFINS = @ValorAliquotaCOFINS, ";
                            sql += "ValorICMSOperacao = @ValorICMSOperacao, ";
                            sql += "PercentualDiferimento = @PercentualDiferimento, ";
                            sql += "ValorICMSDeferido = @ValorICMSDeferido, ";
                            sql += "ValorICMSDesonerado = @ValorICMSDesonerado, ";
                            sql += "MotivoDesonerado = @MotivoDesonerado, ";
                            sql += "IPIDevolvido = @IPIDevolvido, ";
                            sql += "Per_IPIDevolvido = @Per_IPIDevolvido ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", NF.Itens[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", NF.Itens[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", NF.Itens[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", NF.Itens[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorUnitario", NF.Itens[i].ValorUnitario);
                            cmd.Parameters.AddWithValue("@ValorTotal", NF.Itens[i].ValorTotal);
                            cmd.Parameters.AddWithValue("@Acrescimo", NF.Itens[i].Acrescimo);
                            cmd.Parameters.AddWithValue("@Desconto", NF.Itens[i].Desconto);
                            cmd.Parameters.AddWithValue("@InformacaoAdicional", NF.Itens[i].InformacaoAdicional);
                            cmd.Parameters.AddWithValue("@TipoVendaProduto", NF.Itens[i].TipoVendaProduto);
                            cmd.Parameters.AddWithValue("@ID_Grade", NF.Itens[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@EX_TIPI", NF.Itens[i].EX_TIPI);
                            cmd.Parameters.AddWithValue("@Quantidade_Selo", NF.Itens[i].Quantidade_Selo);
                            cmd.Parameters.AddWithValue("@ClasseEnquadramento", NF.Itens[i].ClasseEnquadramento);
                            cmd.Parameters.AddWithValue("@CNPJProdutor", NF.Itens[i].CNPJProdutor);
                            cmd.Parameters.AddWithValue("@Codigo_Selo", NF.Itens[i].Codigo_Selo);
                            cmd.Parameters.AddWithValue("@CST", NF.Itens[i].CST);
                            cmd.Parameters.AddWithValue("@Origem", NF.Itens[i].Origem);
                            cmd.Parameters.AddWithValue("@ModalidadeBC", NF.Itens[i].ModalidadeBC);
                            cmd.Parameters.AddWithValue("@AliquotaICMS", NF.Itens[i].AliquotaICMS);
                            cmd.Parameters.AddWithValue("@PercentualReducao", NF.Itens[i].PercentualReducao);
                            cmd.Parameters.AddWithValue("@ModalidadeBCST", NF.Itens[i].ModalidadeBCST);
                            cmd.Parameters.AddWithValue("@AliquotaICMSST", NF.Itens[i].AliquotaICMSST);
                            cmd.Parameters.AddWithValue("@PercentualReducaoST", NF.Itens[i].PercentualReducaoST);
                            cmd.Parameters.AddWithValue("@MargemVLAdicionado", NF.Itens[i].MargemVLAdicionado);
                            cmd.Parameters.AddWithValue("@CFOP", NF.Itens[i].CFOP);
                            cmd.Parameters.AddWithValue("@Frete", NF.Itens[i].Frete);
                            cmd.Parameters.AddWithValue("@Seguro", NF.Itens[i].Seguro);
                            cmd.Parameters.AddWithValue("@ValorBC", NF.Itens[i].ValorBC);
                            cmd.Parameters.AddWithValue("@ValorICMS", NF.Itens[i].ValorICMS);
                            cmd.Parameters.AddWithValue("@ValorBCST", NF.Itens[i].ValorBCST);
                            cmd.Parameters.AddWithValue("@ValorICMSST", NF.Itens[i].ValorICMSST);
                            cmd.Parameters.AddWithValue("@ValorBCSTRet", NF.Itens[i].ValorBCSTRet);
                            cmd.Parameters.AddWithValue("@ValorICMSSTRet", NF.Itens[i].ValorICMSSTRet);
                            cmd.Parameters.AddWithValue("@CSOSN", NF.Itens[i].CSOSN);
                            cmd.Parameters.AddWithValue("@AliquotaCredito", NF.Itens[i].AliquotaCredito);
                            cmd.Parameters.AddWithValue("@ValorCredito", NF.Itens[i].ValorCredito);
                            cmd.Parameters.AddWithValue("@CSTIPI", NF.Itens[i].CSTIPI);
                            cmd.Parameters.AddWithValue("@AliquotaIPI", NF.Itens[i].AliquotaIPI);
                            cmd.Parameters.AddWithValue("@ValorIPI", NF.Itens[i].ValorIPI);
                            cmd.Parameters.AddWithValue("@ValorBCII", NF.Itens[i].ValorBCII);
                            cmd.Parameters.AddWithValue("@ValorDesII", NF.Itens[i].ValorDesII);
                            cmd.Parameters.AddWithValue("@ValorII", NF.Itens[i].ValorII);
                            cmd.Parameters.AddWithValue("@ValorIOF", NF.Itens[i].ValorIOF);
                            cmd.Parameters.AddWithValue("@CSTPIS", NF.Itens[i].CSTPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPIS", NF.Itens[i].AliquotaPIS);
                            cmd.Parameters.AddWithValue("@ValorPIS", NF.Itens[i].ValorPIS);
                            cmd.Parameters.AddWithValue("@ValorAliquotaPIS", NF.Itens[i].ValorAliquotaPIS);
                            cmd.Parameters.AddWithValue("@CSTCOFINS", NF.Itens[i].CSTCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINS", NF.Itens[i].AliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@ValorCOFINS", NF.Itens[i].ValorCOFINS);
                            cmd.Parameters.AddWithValue("@ValorAliquotaCOFINS", NF.Itens[i].ValorAliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@ValorICMSOperacao", NF.Itens[i].ValorICMSOperacao);
                            cmd.Parameters.AddWithValue("@PercentualDiferimento", NF.Itens[i].PercentualDiferimento);
                            cmd.Parameters.AddWithValue("@ValorICMSDeferido", NF.Itens[i].ValorICMSDeferido);
                            cmd.Parameters.AddWithValue("@ValorICMSDesonerado", NF.Itens[i].ValorICMSDesonerado);
                            cmd.Parameters.AddWithValue("@MotivoDesonerado", NF.Itens[i].MotivoDesonerado);
                            cmd.Parameters.AddWithValue("@IPIDevolvido", NF.Itens[i].IPIDevolvido);
                            cmd.Parameters.AddWithValue("@Per_IPIDevolvido", NF.Itens[i].Per_IPIDevolvido);

                            conexao.Executa_Comando(cmd);
                        }
                        #region IMPORTAÇÃO
                        if (NF.Itens[i].Importacao != null &&
                            NF.Itens[i].Importacao.Count > 0)
                            for (int x = 0; x <= NF.Itens[i].Importacao.Count - 1; x++)
                            {
                                cmd = new SqlCommand();
                                if (NF.Itens[i].Importacao[x].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Importacao ";
                                    sql += "(ID_NF_Item, Documento, Data_Registro, Local, UF, Data_Desen, Codigo) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF_Item, @Documento, @Data_Registro, @Local, @UF, @Data_Desen, @Codigo) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF_Item", NF.Itens[i].ID);
                                    cmd.Parameters.AddWithValue("@Documento", NF.Itens[i].Importacao[x].Documento);
                                    cmd.Parameters.AddWithValue("@Data_Registro", NF.Itens[i].Importacao[x].Data_Registro);
                                    cmd.Parameters.AddWithValue("@Local", NF.Itens[i].Importacao[x].Local);
                                    cmd.Parameters.AddWithValue("@UF", NF.Itens[i].Importacao[x].UF);
                                    cmd.Parameters.AddWithValue("@Data_Desen", NF.Itens[i].Importacao[x].Data_Desen);
                                    cmd.Parameters.AddWithValue("@Codigo", NF.Itens[i].Importacao[x].Codigo);

                                    NF.Itens[i].Importacao[x].ID = conexao.Executa_ComandoID(cmd);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Importacao ";
                                    sql += "SET ";
                                    sql += "Documento = @Documento, ";
                                    sql += "Data_Registro = @Data_Registro, ";
                                    sql += "Local = @Local, ";
                                    sql += "UF = @UF, ";
                                    sql += "Data_Desen = @Data_Desen, ";
                                    sql += "Codigo = @Codigo ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Itens[i].Importacao[x].ID);
                                    cmd.Parameters.AddWithValue("@Documento", NF.Itens[i].Importacao[x].Documento);
                                    cmd.Parameters.AddWithValue("@Data_Registro", NF.Itens[i].Importacao[x].Data_Registro);
                                    cmd.Parameters.AddWithValue("@Local", NF.Itens[i].Importacao[x].Local);
                                    cmd.Parameters.AddWithValue("@UF", NF.Itens[i].Importacao[x].UF);
                                    cmd.Parameters.AddWithValue("@Data_Desen", NF.Itens[i].Importacao[x].Data_Desen);
                                    cmd.Parameters.AddWithValue("@Codigo", NF.Itens[i].Importacao[x].Codigo);

                                    conexao.Executa_Comando(cmd);
                                }
                                #region ADIÇÃO IMPORTAÇÃO
                                if (NF.Itens[i].Importacao[x].Adicao.Count > 0)
                                    for (int y = 0; y <= NF.Itens[i].Importacao[x].Adicao.Count - 1; y++)
                                    {
                                        cmd = new SqlCommand();
                                        if (NF.Itens[i].Importacao[x].Adicao[y].ID == 0)
                                        {
                                            sql = "INSERT INTO ";
                                            sql += "NotaFiscal_Adicao ";
                                            sql += "(ID_Importacao, Numero, Seq, Codigo, Desconto) ";
                                            sql += "VALUES ";
                                            sql += "(@ID_Importacao, @Numero, @Seq, @Codigo, @Desconto) ";
                                            cmd.CommandText = sql;
                                            cmd.Parameters.AddWithValue("@ID_Importacao", NF.Itens[i].Importacao[x].ID);
                                            cmd.Parameters.AddWithValue("@Numero", NF.Itens[i].Importacao[x].Adicao[y].Numero);
                                            cmd.Parameters.AddWithValue("@Seq", y + 1);
                                            cmd.Parameters.AddWithValue("@Codigo", NF.Itens[i].Importacao[x].Adicao[y].Codigo);
                                            cmd.Parameters.AddWithValue("@Desconto", NF.Itens[i].Importacao[x].Adicao[y].Desconto);

                                            NF.Itens[i].Importacao[x].Adicao[y].ID = conexao.Executa_ComandoID(cmd);
                                        }
                                        else
                                        {
                                            sql = "UPDATE ";
                                            sql += "NotaFiscal_Adicao ";
                                            sql += "SET ";
                                            sql += "Numero = @Numero, ";
                                            sql += "Seq = @Seq, ";
                                            sql += "Codigo = @Codigo, ";
                                            sql += "Desconto = @Desconto ";
                                            sql += "WHERE ";
                                            sql += "ID = @ID ";
                                            cmd.CommandText = sql;
                                            cmd.Parameters.AddWithValue("@ID", NF.Itens[i].Importacao[x].Adicao[y].ID);
                                            cmd.Parameters.AddWithValue("@Numero", NF.Itens[i].Importacao[x].Adicao[y].Numero);
                                            cmd.Parameters.AddWithValue("@Seq", NF.Itens[i].Importacao[x].Adicao[y].Seq);
                                            cmd.Parameters.AddWithValue("@Codigo", NF.Itens[i].Importacao[x].Adicao[y].Codigo);
                                            cmd.Parameters.AddWithValue("@Desconto", NF.Itens[i].Importacao[x].Adicao[y].Desconto);

                                            conexao.Executa_Comando(cmd);
                                        }
                                    }
                                #endregion
                            }
                        #endregion
                    }
                #endregion

                #region NOTA FISCAL REFERENCIADA
                if (NF.Referenciada != null &&
                    NF.Referenciada.Count > 0)
                    for (int i = 0; i <= NF.Referenciada.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        switch (NF.Referenciada[i].Tipo)
                        {
                            #region NFe
                            case 1:
                                if (NF.Referenciada[i].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "(ID_NF, Tipo, Chave_NFe) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF, @Tipo, @Chave_NFe) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                                    cmd.Parameters.AddWithValue("@Tipo", NF.Referenciada[i].Tipo);
                                    cmd.Parameters.AddWithValue("@Chave_NFe", NF.Referenciada[i].Chave_NFe);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "SET ";
                                    sql += "Chave_NFe = @Chave_NFe ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Referenciada[i].ID);
                                    cmd.Parameters.AddWithValue("@Chave_NFe", NF.Referenciada[i].Chave_NFe);
                                }
                                conexao.Executa_Comando(cmd);
                                break;
                            #endregion

                            #region NF-A1
                            case 2:
                                if (NF.Referenciada[i].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "(ID_NF, Tipo, UF, DataEmissao, CNPJ_CPF, Modelo, Serie, Numero_NF) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF, @Tipo, @UF, @DataEmissao, @CNPJ_CPF, @Modelo, @Serie, @Numero_NF) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                                    cmd.Parameters.AddWithValue("@Tipo", NF.Referenciada[i].Tipo);
                                    cmd.Parameters.AddWithValue("@UF", NF.Referenciada[i].UF);
                                    cmd.Parameters.AddWithValue("@DataEmissao", NF.Referenciada[i].DataEmissao);
                                    cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Referenciada[i].CNPJ_CPF);
                                    cmd.Parameters.AddWithValue("@Modelo", NF.Referenciada[i].Modelo);
                                    cmd.Parameters.AddWithValue("@Serie", NF.Referenciada[i].Serie);
                                    cmd.Parameters.AddWithValue("@Numero_NF", NF.Referenciada[i].Numero_NF);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "SET ";
                                    sql += "UF = @UF, ";
                                    sql += "DataEmissao = @DataEmissao, ";
                                    sql += "CNPJ_CPF = @CNPJ_CPF, ";
                                    sql += "Modelo = @Modelo, ";
                                    sql += "Serie = @Serie, ";
                                    sql += "Numero_NF = @Numero_NF ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Referenciada[i].ID);
                                    cmd.Parameters.AddWithValue("@UF", NF.Referenciada[i].UF);
                                    cmd.Parameters.AddWithValue("@DataEmissao", NF.Referenciada[i].DataEmissao);
                                    cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Referenciada[i].CNPJ_CPF);
                                    cmd.Parameters.AddWithValue("@Modelo", NF.Referenciada[i].Modelo);
                                    cmd.Parameters.AddWithValue("@Serie", NF.Referenciada[i].Serie);
                                    cmd.Parameters.AddWithValue("@Numero_NF", NF.Referenciada[i].Numero_NF);
                                }
                                conexao.Executa_Comando(cmd);
                                break;
                            #endregion

                            #region NF-A1 PRODUTOR RURAL
                            case 3:
                                if (NF.Referenciada[i].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "(ID_NF, Tipo, UF, DataEmissao, CNPJ_CPF, Modelo, Serie, Numero_NF, IE) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF, @Tipo, @UF, @DataEmissao, @CNPJ_CPF, @Modelo, @Serie, @Numero_NF, @IE) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                                    cmd.Parameters.AddWithValue("@Tipo", NF.Referenciada[i].Tipo);
                                    cmd.Parameters.AddWithValue("@UF", NF.Referenciada[i].UF);
                                    cmd.Parameters.AddWithValue("@DataEmissao", NF.Referenciada[i].DataEmissao);
                                    cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Referenciada[i].CNPJ_CPF);
                                    cmd.Parameters.AddWithValue("@Modelo", NF.Referenciada[i].Modelo);
                                    cmd.Parameters.AddWithValue("@Serie", NF.Referenciada[i].Serie);
                                    cmd.Parameters.AddWithValue("@Numero_NF", NF.Referenciada[i].Numero_NF);
                                    cmd.Parameters.AddWithValue("@IE", NF.Referenciada[i].IE);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "SET ";
                                    sql += "UF = @UF, ";
                                    sql += "DataEmissao = @DataEmissao, ";
                                    sql += "CNPJ_CPF = @CNPJ_CPF, ";
                                    sql += "Modelo = @Modelo, ";
                                    sql += "Serie = @Serie, ";
                                    sql += "Numero_NF = @Numero_NF, ";
                                    sql += "IE = @IE ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Referenciada[i].ID);
                                    cmd.Parameters.AddWithValue("@UF", NF.Referenciada[i].UF);
                                    cmd.Parameters.AddWithValue("@DataEmissao", NF.Referenciada[i].DataEmissao);
                                    cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Referenciada[i].CNPJ_CPF);
                                    cmd.Parameters.AddWithValue("@Modelo", NF.Referenciada[i].Modelo);
                                    cmd.Parameters.AddWithValue("@Serie", NF.Referenciada[i].Serie);
                                    cmd.Parameters.AddWithValue("@Numero_NF", NF.Referenciada[i].Numero_NF);
                                    cmd.Parameters.AddWithValue("@IE", NF.Referenciada[i].IE);
                                }
                                conexao.Executa_Comando(cmd);
                                break;
                            #endregion

                            #region CTE
                            case 4:
                                if (NF.Referenciada[i].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "(ID_NF, Tipo, CTE) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF, @Tipo, @CTE) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                                    cmd.Parameters.AddWithValue("@Tipo", NF.Referenciada[i].Tipo);
                                    cmd.Parameters.AddWithValue("@CTE", NF.Referenciada[i].CTE);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "SET ";
                                    sql += "CTE = @CTE ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Referenciada[i].ID);
                                    cmd.Parameters.AddWithValue("@CTE", NF.Referenciada[i].CTE);
                                }
                                conexao.Executa_Comando(cmd);
                                break;
                            #endregion

                            #region ECF
                            case 5:
                                if (NF.Referenciada[i].ID == 0)
                                {
                                    sql = "INSERT INTO ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "(ID_NF, Tipo, Mod_CupomFiscal, ECF, Numero_Contador) ";
                                    sql += "VALUES ";
                                    sql += "(@ID_NF, @Tipo, @Mod_CupomFiscal, @ECF, @Numero_Contador) ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                                    cmd.Parameters.AddWithValue("@Tipo", NF.Referenciada[i].Tipo);
                                    cmd.Parameters.AddWithValue("@Mod_CupomFiscal", NF.Referenciada[i].Mod_CupomFiscal);
                                    cmd.Parameters.AddWithValue("@ECF", NF.Referenciada[i].ECF);
                                    cmd.Parameters.AddWithValue("@Numero_Contador", NF.Referenciada[i].Numero_Contador);
                                }
                                else
                                {
                                    sql = "UPDATE ";
                                    sql += "NotaFiscal_Referenciada ";
                                    sql += "SET ";
                                    sql += "Mod_CupomFiscal = @Mod_CupomFiscal ";
                                    sql += "ECF = @ECF ";
                                    sql += "Numero_Contador = @Numero_Contador ";
                                    sql += "WHERE ";
                                    sql += "ID = @ID ";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@ID", NF.Referenciada[i].ID);
                                    cmd.Parameters.AddWithValue("@Mod_CupomFiscal", NF.Referenciada[i].Mod_CupomFiscal);
                                    cmd.Parameters.AddWithValue("@ECF", NF.Referenciada[i].ECF);
                                    cmd.Parameters.AddWithValue("@Numero_Contador", NF.Referenciada[i].Numero_Contador);
                                }
                                conexao.Executa_Comando(cmd);
                                break;
                                #endregion
                        }
                    }
                #endregion

                #region NOTA FISCAL ENTREGA RETIRADA
                if (NF.Ent_Ret != null &&
                    NF.Ent_Ret.Count > 0)
                    for (int i = 0; i <= NF.Ent_Ret.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (NF.Ent_Ret[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "NotaFiscal_Ent_Ret ";
                            sql += "(ID_NF, Tipo, CNPJ_CPF, Logradouro, Numero, Complemento, Bairro, ID_Municipio) ";
                            sql += "VALUES ";
                            sql += "(@ID_NF, @Tipo, @CNPJ_CPF, @Logradouro, @Numero, @Complemento, @Bairro, @ID_Municipio) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                            cmd.Parameters.AddWithValue("@Tipo", NF.Ent_Ret[i].Tipo);
                            cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Ent_Ret[i].CNPJ_CPF);
                            cmd.Parameters.AddWithValue("@Logradouro", NF.Ent_Ret[i].Logradouro);
                            cmd.Parameters.AddWithValue("@Numero", NF.Ent_Ret[i].Numero);
                            cmd.Parameters.AddWithValue("@Complemento", NF.Ent_Ret[i].Complemento);
                            cmd.Parameters.AddWithValue("@Bairro", NF.Ent_Ret[i].Bairro);
                            cmd.Parameters.AddWithValue("@ID_Municipio", NF.Ent_Ret[i].ID_Municipio);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "NotaFiscal_Ent_Ret ";
                            sql += "SET ";
                            sql += "Tipo = @Tipo, ";
                            sql += "CNPJ_CPF = @CNPJ_CPF, ";
                            sql += "Logradouro = @Logradouro, ";
                            sql += "Numero = @Numero, ";
                            sql += "Complemento = @Complemento, ";
                            sql += "Bairro = @Bairro, ";
                            sql += "ID_Municipio = @ID_Municipio ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", NF.Ent_Ret[i].ID);
                            cmd.Parameters.AddWithValue("@Tipo", NF.Ent_Ret[i].Tipo);
                            cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Ent_Ret[i].CNPJ_CPF);
                            cmd.Parameters.AddWithValue("@Logradouro", NF.Ent_Ret[i].Logradouro);
                            cmd.Parameters.AddWithValue("@Numero", NF.Ent_Ret[i].Numero);
                            cmd.Parameters.AddWithValue("@Complemento", NF.Ent_Ret[i].Complemento);
                            cmd.Parameters.AddWithValue("@Bairro", NF.Ent_Ret[i].Bairro);
                            cmd.Parameters.AddWithValue("@ID_Municipio", NF.Ent_Ret[i].ID_Municipio);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region NOTA FISCAL TRANSPORTE
                #region TRANSPORTADORA
                if (NF.Transporte != null &&
                    NF.Transporte.Count > 0)
                {
                    cmd = new SqlCommand();
                    if (NF.Transporte[0].ID == 0)
                    {
                        sql = "INSERT INTO ";
                        sql += "NotaFiscal_Transporte ";
                        sql += "(ID_NF, ID_Pessoa, CNPJ_CPF, Nome, IE, Endereco, Municipio, UF, UFPlaca, Placa) ";
                        sql += "VALUES ";
                        sql += "(@ID_NF, @ID_Pessoa, @CNPJ_CPF, @Nome, @IE, @Endereco, @Municipio, @UF, @UFPlaca, @Placa) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", NF.Transporte[0].ID_Pessoa);
                        cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Transporte[0].CNPJ_CPF);
                        cmd.Parameters.AddWithValue("@Nome", NF.Transporte[0].Nome);
                        cmd.Parameters.AddWithValue("@IE", NF.Transporte[0].IE);
                        cmd.Parameters.AddWithValue("@Endereco", (NF.Transporte[0].Endereco.ToString().Length <= 60 ? NF.Transporte[0].Endereco.ToString() : NF.Transporte[0].Endereco.Substring(0, 60)));
                        cmd.Parameters.AddWithValue("@Municipio", NF.Transporte[0].Municipio);
                        cmd.Parameters.AddWithValue("@UF", NF.Transporte[0].UF);
                        cmd.Parameters.AddWithValue("@UFPlaca", NF.Transporte[0].UFPlaca);
                        cmd.Parameters.AddWithValue("@Placa", NF.Transporte[0].Placa);

                        NF.Transporte[0].ID = conexao.Executa_ComandoID(cmd);
                    }
                    else
                    {
                        sql = "UPDATE ";
                        sql += "NotaFiscal_Transporte ";
                        sql += "SET ";
                        sql += "ID_Pessoa = @ID_Pessoa, ";
                        sql += "CNPJ_CPF = @CNPJ_CPF, ";
                        sql += "Nome = @Nome, ";
                        sql += "IE = @IE, ";
                        sql += "Endereco = @Endereco, ";
                        sql += "Municipio = @Municipio, ";
                        sql += "UF = @UF, ";
                        sql += "UFPlaca = @UFPlaca, ";
                        sql += "Placa = @Placa ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", NF.Transporte[0].ID);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", NF.Transporte[0].ID_Pessoa);
                        cmd.Parameters.AddWithValue("@CNPJ_CPF", NF.Transporte[0].CNPJ_CPF);
                        cmd.Parameters.AddWithValue("@Nome", NF.Transporte[0].Nome);
                        cmd.Parameters.AddWithValue("@IE", NF.Transporte[0].IE);
                        cmd.Parameters.AddWithValue("@Endereco", (NF.Transporte[0].Endereco.ToString().Length <= 60 ? NF.Transporte[0].Endereco.ToString() : NF.Transporte[0].Endereco.Substring(0, 60)));
                        cmd.Parameters.AddWithValue("@Municipio", NF.Transporte[0].Municipio);
                        cmd.Parameters.AddWithValue("@UF", NF.Transporte[0].UF);
                        cmd.Parameters.AddWithValue("@UFPlaca", NF.Transporte[0].UFPlaca);
                        cmd.Parameters.AddWithValue("@Placa", NF.Transporte[0].Placa);

                        conexao.Executa_Comando(cmd);
                    }
                }
                #endregion

                #region VOLUME
                if (NF.Volume != null &&
                    NF.Volume.Count > 0)
                    for (int i = 0; i <= NF.Volume.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (NF.Volume[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "NotaFiscal_Volume ";
                            sql += "(ID_NF, Quantidade, Especie, Marca, Numeracao, PesoL, PesoB) ";
                            sql += "VALUES ";
                            sql += "(@ID_NF, @Quantidade, @Especie, @Marca, @Numeracao, @PesoL, @PesoB) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                            cmd.Parameters.AddWithValue("@Quantidade", NF.Volume[i].Quantidade);
                            cmd.Parameters.AddWithValue("@Especie", NF.Volume[i].Especie);
                            cmd.Parameters.AddWithValue("@Marca", NF.Volume[i].Marca);
                            cmd.Parameters.AddWithValue("@Numeracao", NF.Volume[i].Numeracao);
                            cmd.Parameters.AddWithValue("@PesoL", NF.Volume[i].PesoL);
                            cmd.Parameters.AddWithValue("@PesoB", NF.Volume[i].PesoB);

                            NF.Volume[i].ID = conexao.Executa_ComandoID(cmd);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "NotaFiscal_Volume ";
                            sql += "SET ";
                            sql += "Quantidade = @Quantidade, ";
                            sql += "Especie = @Especie, ";
                            sql += "Marca = @Marca, ";
                            sql += "Numeracao = @Numeracao, ";
                            sql += "PesoL = @PesoL, ";
                            sql += "PesoB = @PesoB ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", NF.Volume[i].ID);
                            cmd.Parameters.AddWithValue("@Quantidade", NF.Volume[i].Quantidade);
                            cmd.Parameters.AddWithValue("@Especie", NF.Volume[i].Especie);
                            cmd.Parameters.AddWithValue("@Marca", NF.Volume[i].Marca);
                            cmd.Parameters.AddWithValue("@Numeracao", NF.Volume[i].Numeracao);
                            cmd.Parameters.AddWithValue("@PesoL", NF.Volume[i].PesoL);
                            cmd.Parameters.AddWithValue("@PesoB", NF.Volume[i].PesoB);

                            conexao.Executa_Comando(cmd);
                        }
                        #region LACRE
                        /*
                            if (NF.Volume[i].Lacre.Count > 0)
                                for (int x = 0; x <= NF.Volume[i].Lacre.Count - 1; x++)
                                {
                                    cmd = new SqlCommand();
                                    if (NF.Volume[i].Lacre[i].ID == 0)
                                    {
                                        sql = "INSERT INTO ";
                                        sql += "NotaFiscal_Lacre ";
                                        sql += "(ID_NF_Volume, Numero) ";
                                        sql += "VALUES ";
                                        sql += "(@ID_NF_Volume, @Numero) ";
                                        cmd.CommandText = sql;
                                        cmd.Parameters.AddWithValue("@ID_NF_Volume", NF.Volume[i].ID);
                                        cmd.Parameters.AddWithValue("@Numero", NF.Volume[i].Lacre[x].Numero);
                                    }
                                    else
                                    {
                                        sql = "UPDATE ";
                                        sql += "NotaFiscal_Lacre ";
                                        sql += "SET ";
                                        sql += "Numero = @Numero ";
                                        sql += "WHERE ";
                                        sql += "ID = @ID ";
                                        cmd.CommandText = sql;
                                        cmd.Parameters.AddWithValue("@ID", NF.Volume[i].Lacre[i].ID);
                                        cmd.Parameters.AddWithValue("@Numero", NF.Volume[i].Lacre[x].Numero);
                                    }
                                    conexao.Executa_Comando(cmd);
                                }
                            */
                        #endregion
                    }
                #endregion
                #endregion

                #region COBRANÇA
                if (NF.Cobranca != null &&
                    NF.Cobranca.Count > 0)
                {
                    cmd = new SqlCommand();
                    if (NF.Cobranca[0].ID == 0)
                    {
                        sql = "INSERT INTO ";
                        sql += "NotaFiscal_Cobranca ";
                        sql += "(ID_NF, NumeroFatura, Valor, Desconto, ValorFinal) ";
                        sql += "VALUES ";
                        sql += "(@ID_NF, @NumeroFatura, @Valor, @Desconto, @ValorFinal) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                        cmd.Parameters.AddWithValue("@NumeroFatura", NF.Cobranca[0].NumeroFatura);
                        cmd.Parameters.AddWithValue("@Valor", NF.Cobranca[0].Valor);
                        cmd.Parameters.AddWithValue("@Desconto", NF.Cobranca[0].Desconto);
                        cmd.Parameters.AddWithValue("@ValorFinal", NF.Cobranca[0].ValorFinal);
                    }
                    else
                    {
                        sql = "UPDATE ";
                        sql += "NotaFiscal_Cobranca ";
                        sql += "SET ";
                        sql += "NumeroFatura = @NumeroFatura, ";
                        sql += "Valor = @Valor, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "ValorFinal = @ValorFinal ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", NF.Cobranca[0].ID);
                        cmd.Parameters.AddWithValue("@NumeroFatura", NF.Cobranca[0].NumeroFatura);
                        cmd.Parameters.AddWithValue("@Valor", NF.Cobranca[0].Valor);
                        cmd.Parameters.AddWithValue("@Desconto", NF.Cobranca[0].Desconto);
                        cmd.Parameters.AddWithValue("@ValorFinal", NF.Cobranca[0].ValorFinal);
                    }
                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region DUPLICATA
                if (NF.Duplicata != null && NF.Duplicata.Count > 0)
                    for (int i = 0; i <= NF.Duplicata.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (NF.Duplicata[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "NotaFiscal_Duplicata ";
                            sql += "(ID_NF, NumeroDuplicata, Vencimento, Valor) ";
                            sql += "VALUES ";
                            sql += "(@ID_NF, @NumeroDuplicata, @Vencimento, @Valor) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                            cmd.Parameters.AddWithValue("@NumeroDuplicata", NF.Duplicata[i].NumeroDuplicata);
                            cmd.Parameters.AddWithValue("@Vencimento", NF.Duplicata[i].Vencimento);
                            cmd.Parameters.AddWithValue("@Valor", NF.Duplicata[i].Valor);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "NotaFiscal_Duplicata ";
                            sql += "SET ";
                            sql += "NumeroDuplicata = @NumeroDuplicata, ";
                            sql += "Vencimento = @Vencimento, ";
                            sql += "Valor = @Valor ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", NF.Duplicata[i].ID);
                            cmd.Parameters.AddWithValue("@NumeroDuplicata", NF.Duplicata[i].NumeroDuplicata);
                            cmd.Parameters.AddWithValue("@Vencimento", NF.Duplicata[i].Vencimento);
                            cmd.Parameters.AddWithValue("@Valor", NF.Duplicata[i].Valor);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                conexao.Commit_Conexao();

                return NF.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public int Grava_Evento()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "NotaFiscal_Evento ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";
                sql += "AND Tipo_Evento = " + NF.Tipo_Evento + " ";

                if (NF.Tipo_Evento != 1)
                    sql += "AND Seq = " + NF.Seq_Evento + " ";

                DataTable _DT = conexao.Consulta(sql);

                conexao.Begin_Conexao();

                if (_DT.Rows.Count > 0)
                {
                    sql = "DELETE FROM ";
                    sql += "NotaFiscal_Evento ";
                    sql += "WHERE ";
                    sql += "ID_NF = " + NF.ID + " ";
                    sql += "AND Tipo_Evento = " + NF.Tipo_Evento + " ";

                    if (NF.Tipo_Evento != 1)
                        sql += "AND Seq = " + NF.Seq_Evento + " ";

                    cmd.CommandText = sql;
                    conexao.Executa_Comando(cmd);
                }

                sql = "INSERT INTO ";
                sql += "NotaFiscal_Evento ";
                sql += "(ID_NF, Protocolo, Data, Evento, Seq, Tipo_Evento, Motivo, Stat) ";
                sql += "VALUES ";
                sql += "(@ID_NF, @Protocolo, @Data, @Evento, @Seq, @Tipo_Evento, @Motivo, @Stat) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_NF", NF.ID);
                cmd.Parameters.AddWithValue("@Protocolo", NF.Protocolo);
                cmd.Parameters.AddWithValue("@Data", NF.Data_Protocolo);
                cmd.Parameters.AddWithValue("@Evento", NF.Evento_Protocolo);
                cmd.Parameters.AddWithValue("@Seq", NF.Seq_Evento);
                cmd.Parameters.AddWithValue("@Tipo_Evento", NF.Tipo_Evento);
                cmd.Parameters.AddWithValue("@Motivo", NF.Motivo);
                cmd.Parameters.AddWithValue("@Stat", NF.Stat);

                NF.ID_Protocolo = conexao.Executa_ComandoID(cmd);

                conexao.Commit_Conexao();

                return NF.ID_Protocolo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Grava_Inutilizacao()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO ";
                sql += "NotaFiscal_Inutilizacao ";
                sql += "(ID_Empresa, Serie, Numeracao, Justificativa, Protocolo) ";
                sql += "VALUES ";
                sql += "(@ID_Empresa, @Serie, @Numeracao, @Justificativa, @Protocolo) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Empresa", NF.ID_Empresa);
                cmd.Parameters.AddWithValue("@Serie", NF.Serie);
                cmd.Parameters.AddWithValue("@Numeracao", NF.NumeracaoInut);
                cmd.Parameters.AddWithValue("@Justificativa", NF.Justificativa);
                cmd.Parameters.AddWithValue("@Protocolo", NF.Protocolo);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Grava_Chave()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE NotaFiscal ";
                sql += "SET Chave = @Chave ";

                if (NF.ID > 0)
                    sql += "WHERE ID = @ID ";
                else
                {
                    sql += "WHERE Serie = @Serie ";
                    sql += "AND ID_NFe = @ID_NFe";
                }

                cmd.CommandText = sql;

                if (NF.ID > 0)
                    cmd.Parameters.AddWithValue("@ID", NF.ID);
                else
                {
                    cmd.Parameters.AddWithValue("@Serie", NF.Serie);
                    cmd.Parameters.AddWithValue("@ID_NFe", NF.ID_NFe);
                }

                cmd.Parameters.AddWithValue("@Chave", NF.Chave);
                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera_Situacao()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE NotaFiscal ";
                sql += "SET Situacao = @Situacao ";

                if (NF.ID > 0)
                    sql += "WHERE ID = @ID ";
                else
                {
                    sql += "WHERE Serie = @Serie ";
                    sql += "AND ID_NFe = @ID_NFe";
                }

                cmd.CommandText = sql;

                if (NF.ID > 0)
                    cmd.Parameters.AddWithValue("@ID", NF.ID);
                else
                {
                    cmd.Parameters.AddWithValue("@Serie", NF.Serie);
                    cmd.Parameters.AddWithValue("@ID_NFe", NF.ID_NFe);
                }

                cmd.Parameters.AddWithValue("@Situacao", NF.Situacao);
                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera_Status_CFe()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE NotaFiscal SET ";
                sql += "Situacao = @Situacao, ";
                sql += "Status_CFe = @Status_CFe ";
                sql += "WHERE ID = @ID ";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@ID", NF.ID);
                cmd.Parameters.AddWithValue("@Situacao", NF.Situacao);
                cmd.Parameters.AddWithValue("@Status_CFe", NF.Status_CFe);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera_Sessao()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE NotaFiscal ";
                sql += "SET Controle_CF = @Controle_CF ";
                sql += "WHERE ID = @ID ";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                cmd.Parameters.AddWithValue("@Controle_CF", NF.Controle_CF);
                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera_Chave()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE NotaFiscal SET ";
                sql += "Situacao = @Situacao, ";
                sql += "DataEmissao = @DataEmissao, ";
                sql += "Retorno_CFe = @Retorno_CFe, ";
                sql += "Status_CFe = @Status_CFe, ";
                sql += "Chave = @Chave, ";
                sql += "QRCode_CFe = @QRCode, ";
                sql += "ID_NFe = @ID_NFe ";
                sql += "WHERE ID = @ID ";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                cmd.Parameters.AddWithValue("@Situacao", NF.Situacao);
                cmd.Parameters.AddWithValue("@Retorno_CFe", NF.Retorno_CFe);
                cmd.Parameters.AddWithValue("@Status_CFe", NF.Status_CFe);
                cmd.Parameters.AddWithValue("@Chave", NF.Chave);
                cmd.Parameters.AddWithValue("@QRCode", NF.QRCode);
                cmd.Parameters.AddWithValue("@ID_NFe", NF.ID_NFe);
                cmd.Parameters.AddWithValue("@DataEmissao", NF.DataEmissao);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public int Busca_ID_NF()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                sql = "SELECT ";
                sql += "MAX(ID_NFe) AS ID_NFe ";
                sql += "FROM NotaFiscal ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + NF.ID_Empresa + " ";
                sql += "AND Serie = " + NF.Serie + " ";
                sql += "AND Modelo = " + NF.Modelo + " ";
                DR = conexao.Consulta(sql).Rows[0];

                return Convert.ToInt32(util_dados.Verifica_int(DR["ID_NFe"].ToString())) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_CFe_Emitido()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                sql = "SELECT ";
                sql += "Status_CFe, Retorno_CFe ";
                sql += "FROM NotaFiscal ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID = " + NF.ID + " ";
                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID, NF.ID AS ID_NF, NF.ID_Empresa, NF.Serie, NF.ID_NFe, NF.DataEmissao, NF.DataSaida, NF.DataSaida AS HoraSaida, NF.DataContigencia, NF.TipoDocumento, NF.FinalidadeEmissao, ";
                sql += "NF.FormaEmissao, NF.FormaPagto, NF.TipoImpressao, NF.TipoFrete, NF.Situacao, NF.TipoPessoa, NF.ID_Pessoa, NF.Dig_Verificador, NF.ID_Venda, NF.ID_OS, ";
                sql += "NF.IE_Substituicao, NF.ValorBC, NF.ValorICMS, NF.ValorICMSDesonerado, NF.ValorBCST, NF.ValorST, NF.ValorProduto, NF.ValorFrete, NF.ValorSeguro, NF.ValorDesconto, ";
                sql += "NF.ValorImportacao, NF.ValorIPI, NF.ValorPIS, NF.ValorCOFINS, NF.ValorOutro, NF.ValorTotal, NF.NaturezaOperacao, NF.Justificativa, ";
                sql += "NF.InformacaoAdicional, NF.InformacaoFisco, NF.Tipo_NF, NF.ConsumidorFinal, NF.PresencaConsumidor, NF.Modelo, NF.Trib_Federal, NF.Trib_Estadual, NF.Trib_Municipal, NF.Chave, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 1 THEN 'ASSINADA' ";
                sql += "WHEN 2 THEN 'AUTORIZADA' ";
                sql += "WHEN 3 THEN 'CANCELADA' ";
                sql += "WHEN 4 THEN 'DENEGADA' ";
                sql += "WHEN 5 THEN 'EM DIGITAÇÃO' ";
                sql += "WHEN 6 THEN 'VALIDADA' ";
                sql += "WHEN 7 THEN 'EM PROCESSAMENTO' ";
                sql += "WHEN 8 THEN 'CF-e AUTORIZADO' ";
                sql += "WHEN 9 THEN 'Nº INUTILIZADO' ";
                sql += "END AS DescricaoSituacao, ";
                sql += "P.Nome_Razao AS DescricaoPessoa, ";
                sql += "T.Descricao AS NaturezaOperacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "INNER JOIN NF_TipoEmissao AS T ON T.ID = NF.Tipo_NF ";
                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";

                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.ID > 0)
                    sql += "AND NF.ID = " + NF.ID + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Serie > 0)
                    sql += "AND NF.Serie = " + NF.Serie + " ";

                if (NF.ID_NFe > 0)
                    sql += "AND NF.ID_NFe = " + NF.ID_NFe + " ";

                if (NF.Situacao > 0)
                    sql += "AND NF.Situacao = " + NF.Situacao + " ";

                if (NF.Tipo_NF > 0)
                    sql += "AND NF.Tipo_NF = " + NF.Tipo_NF + " ";

                if (NF.ID_Venda > 0)
                    sql += "AND NF.ID_Venda = " + NF.ID_Venda + " ";

                if (NF.ID_OS > 0)
                    sql += "AND NF.ID_OS = " + NF.ID_OS + " ";

                if (NF.TipoPessoa > 0)
                    sql += "AND NF.TipoPessoa = " + NF.TipoPessoa + " ";

                if (NF.ID_Pessoa > 0)
                    sql += "AND NF.ID_Pessoa = " + NF.ID_Pessoa + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                {
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";

                    if (NF.Modelo == 55 ||
                        NF.Modelo == 59)
                    {
                        sql += "OR ";
                        if (NF.Modelo > 0)
                            sql += "NF.Modelo = " + NF.Modelo + " ";

                        sql += "AND NF.Situacao IN (1, 5, 7) "; //EXIBE AS NOTAS EM DIGITAÇÃO
                    }
                }

                sql += "ORDER BY NF.DataEmissao DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_SAT()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID, NF.ID AS ID_NF, NF.ID_Empresa, NF.Serie, NF.ID_NFe, NF.DataEmissao, NF.DataSaida, ";
                sql += "NF.FormaEmissao, NF.FormaPagto, NF.TipoImpressao, NF.TipoFrete, NF.Situacao, NF.TipoPessoa, NF.ID_Pessoa, NF.Dig_Verificador, ";
                sql += "NF.ValorProduto, NF.ValorDesconto, NF.ValorOutro, NF.ValorTotal, NF.NaturezaOperacao,";
                sql += "NF.InformacaoAdicional, NF.InformacaoFisco, NF.Tipo_NF, NF.ConsumidorFinal, NF.PresencaConsumidor, ";
                sql += "NF.Modelo, NF.CNPJ_CPF_Destinatario, NF.Chave, NF.QRCode_CFe, NF.Trib_Federal, NF.Trib_Estadual, NF.Trib_Municipal, ";
                sql += "NF.ID_Venda, NF.ID_OS, NF.Controle_CF, NF.Status_CFe, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 1 THEN 'ASSINADA' ";
                sql += "WHEN 2 THEN 'AUTORIZADA' ";
                sql += "WHEN 3 THEN 'CANCELADA' ";
                sql += "WHEN 4 THEN 'DENEGADA' ";
                sql += "WHEN 5 THEN 'EM DIGITAÇÃO' ";
                sql += "WHEN 6 THEN 'VALIDADA' ";
                sql += "WHEN 7 THEN 'EM PROCESSAMENTO' ";
                sql += "WHEN 8 THEN 'CF-e AUTORIZADO' ";
                sql += "WHEN 9 THEN 'INUTILIZADO' ";
                sql += "END AS DescricaoSituacao, ";
                sql += "P.Nome_Razao AS DescricaoPessoa, ";
                sql += "T.Descricao AS NaturezaOperacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "INNER JOIN NF_TipoEmissao AS T ON T.ID = NF.Tipo_NF ";
                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";

                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.ID > 0)
                    sql += "AND NF.ID = " + NF.ID + " ";

                if (NF.Serie > 0)
                    sql += "AND NF.Serie = " + NF.Serie + " ";

                if (NF.ID_NFe > 0)
                    sql += "AND NF.ID_NFe = " + NF.ID_NFe + " ";

                if (NF.Situacao > 0)
                    sql += "AND NF.Situacao = " + NF.Situacao + " ";

                if (NF.Status_CFe > 0)
                    sql += "AND NF.Status_CFe = " + NF.Status_CFe + " ";

                if (NF.Tipo_NF > 0)
                    sql += "AND NF.Tipo_NF = " + NF.Tipo_NF + " ";

                if (NF.TipoPessoa > 0)
                    sql += "AND NF.TipoPessoa = " + NF.TipoPessoa + " ";

                if (NF.ID_Pessoa > 0)
                    sql += "AND NF.ID_Pessoa = " + NF.ID_Pessoa + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                {
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE, '" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + NF.Consulta_Emissao.Final + "') ";
                    sql += "OR NF.Situacao IN (1, 5, 7) "; //EXIBE AS NOTAS EM DIGITAÇÃO
                }

                sql += "ORDER BY NF.ID_NFe DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Sintegra()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID_NFe, NF.Serie, NF.Modelo, NF.DataEmissao, NF.Chave, P.CNPJ_CPF,P.IE_RG, UF.Sigla AS UF, 'P' AS Emitente, 0 AS Isento, ";
                sql += "I.CFOP,I.AliquotaICMS, SUM(I.ValorTotal) AS ValorTotal, SUM(I.ValorBC)AS ValorBC, SUM(I.ValorICMS) AS ValorICMS, SUM(I.Seguro) as Outras, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 2 THEN 'N' ";
                sql += "WHEN 3 THEN 'S' ";
                sql += "WHEN 4 THEN '2' ";
                sql += "WHEN 9 THEN '4' ";
                sql += "END AS Situacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN NotaFiscal_Item AS I ON I.ID_NF = NF.ID ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = NF.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";


                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";
                sql += "AND NF.Situacao in (2,3,4,9) ";
                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";

                sql += "GROUP BY I.CFOP, I.AliquotaICMS, NF.Serie, NF.Modelo, NF.ID_NFe, NF.DataEmissao, NF.Situacao, NF.Chave, P.CNPJ_CPF, P.IE_RG, UF.Sigla ";
                sql += "ORDER BY NF.ID_NFe DESC ";


                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Sintegra_ST()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID_NFe, NF.Serie, NF.Modelo, NF.DataEmissao, NF.Chave, P.CNPJ_CPF,P.IE_RG, UF.Sigla AS UF, 'P' AS Emitente, ";
                sql += "I.CFOP,  SUM(I.ValorBCST)AS ValorBCST, SUM(I.ValorICMSST)AS ValorICMSST, SUM(I.Frete + I.Seguro) AS Outras, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 2 THEN 'N' ";
                sql += "WHEN 3 THEN 'S' ";
                sql += "WHEN 4 THEN '2' ";
                sql += "WHEN 9 THEN '4' ";
                sql += "END AS Situacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN NotaFiscal_Item AS I ON I.ID_NF = NF.ID ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = NF.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";
                sql += "AND I.ValorBCST > 0 ";
                sql += "AND NF.Situacao in (2,3,4,9) ";
                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";


                sql += "GROUP BY I.CFOP, NF.Serie, NF.Modelo, NF.ID_NFe, NF.DataEmissao, NF.Situacao, NF.Chave, P.CNPJ_CPF, P.IE_RG, UF.Sigla ";
                sql += "ORDER BY NF.ID_NFe  ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Sintegra_Item()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ROW_NUMBER() OVER(partition by NF.ID_NFe, NF.Serie order by NF.ID_NFe, NF.Serie, I.ID) as NumItem,  ";
                sql += "NF.ID_NFe, NF.Serie, NF.Modelo,NF.DataEmissao, NF.Chave, P.CNPJ_CPF, ";
                sql += "I.CFOP,I.ID_Produto, I.Quantidade,  I.AliquotaICMS, I.ValorBC, I.ValorBCST, I.ValorIPI, I.CST,I.CSOSN,  ";
                sql += "I.ValorUnitario* I.Quantidade as ValorBrunto,  I.Desconto* I.Quantidade as Desconto, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 2 THEN 'N' ";
                sql += "WHEN 3 THEN 'S' ";
                sql += "WHEN 4 THEN '2' ";
                sql += "WHEN 9 THEN '4' ";
                sql += "END AS Situacao, ";
                sql += "PR.NCM, GS.Descricao AS Unidade, 0 AS IPI, 0 as ReducaoBC, 0 as BCST, ";
                sql += "(select top 1 V.AliquotaICMS from V_Produto_Imposto V where V.ID_Produto = PR.ID) as AliquotaICMSProd, ";
                sql += "CASE WHEN GP.Descricao = 'ÚNICO' THEN PR.Descricao ELSE PR.Descricao + ' - ' + GP.Descricao END AS DescricaoProduto ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN NotaFiscal_Item AS I ON I.ID_NF = NF.ID ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "INNER JOIN Produto_Servico AS PR ON PR.ID = I.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = I.ID_Grade ";
                sql += "LEFT JOIN Grupo AS GS ON GS.ID = PR.UnidadeTributavel ";

                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";
                sql += "AND NF.Situacao in (2) ";
                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";


                sql += "ORDER BY NF.ID_NFe, NF.Serie,I.ID ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }
        public DataTable Busca_NF_Relatorio()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID, NF.ID AS ID_NF, NF.ID_Empresa, NF.Serie, NF.ID_NFe, NF.DataEmissao, NF.DataSaida, NF.DataSaida AS HoraSaida, NF.DataContigencia, NF.TipoDocumento, NF.FinalidadeEmissao, ";
                sql += "NF.FormaEmissao, NF.FormaPagto, NF.TipoImpressao, NF.TipoFrete, NF.Situacao, NF.TipoPessoa, NF.ID_Pessoa, NF.Dig_Verificador, NF.ID_Venda, ";
                sql += "NF.IE_Substituicao, NF.ValorBC, NF.ValorICMS, NF.ValorICMSDesonerado, NF.ValorBCST, NF.ValorST, NF.ValorProduto, NF.ValorFrete, NF.ValorSeguro, NF.ValorDesconto, ";
                sql += "NF.ValorImportacao, NF.ValorIPI, NF.ValorPIS, NF.ValorCOFINS, NF.ValorOutro, NF.ValorTotal, NF.NaturezaOperacao, NF.Justificativa, ";
                sql += "NF.InformacaoAdicional, NF.InformacaoFisco, NF.Tipo_NF, NF.ConsumidorFinal, NF.PresencaConsumidor, NF.Modelo, NF.Trib_Federal, NF.Trib_Estadual, NF.Trib_Municipal, NF.Chave, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 1 THEN 'ASSINADA' ";
                sql += "WHEN 2 THEN 'AUTORIZADA' ";
                sql += "WHEN 3 THEN 'CANCELADA' ";
                sql += "WHEN 4 THEN 'DENEGADA' ";
                sql += "WHEN 5 THEN 'EM DIGITAÇÃO' ";
                sql += "WHEN 6 THEN 'VALIDADA' ";
                sql += "WHEN 7 THEN 'EM PROCESSAMENTO' ";
                sql += "WHEN 8 THEN 'CF-e AUTORIZADO' ";
                sql += "WHEN 9 THEN 'INUTILIZADO' ";
                sql += "END AS DescricaoSituacao, ";
                sql += "P.Nome_Razao AS DescricaoPessoa, ";
                sql += "T.Descricao AS NaturezaOperacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "INNER JOIN NF_TipoEmissao AS T ON T.ID = NF.Tipo_NF ";
                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";

                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.ID > 0)
                    sql += "AND NF.ID = " + NF.ID + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Serie > 0)
                    sql += "AND NF.Serie = " + NF.Serie + " ";

                if (NF.ID_NFe > 0)
                    sql += "AND NF.ID_NFe = " + NF.ID_NFe + " ";

                if (NF.Situacao > 0)
                    sql += "AND NF.Situacao = " + NF.Situacao + " ";

                if (NF.Tipo_NF > 0)
                    sql += "AND NF.Tipo_NF = " + NF.Tipo_NF + " ";

                if (NF.ID_Venda > 0)
                    sql += "AND NF.ID_Venda = " + NF.ID_Venda + " ";

                if (NF.TipoPessoa > 0)
                    sql += "AND NF.TipoPessoa = " + NF.TipoPessoa + " ";

                if (NF.ID_Pessoa > 0)
                    sql += "AND NF.ID_Pessoa = " + NF.ID_Pessoa + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY NF.ID_NFe DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Relatorio_CFOP()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID, NF.ID AS ID_NF, NF.Serie, NF.ID_NFe, NF.DataEmissao, NF.Situacao, NF.ValorTotal, NF.NaturezaOperacao, NF.Chave, ";
                sql += "CASE NF.Situacao ";
                sql += "WHEN 1 THEN 'ASSINADA' ";
                sql += "WHEN 2 THEN 'AUTORIZADA' ";
                sql += "WHEN 3 THEN 'CANCELADA' ";
                sql += "WHEN 4 THEN 'DENEGADA' ";
                sql += "WHEN 5 THEN 'EM DIGITAÇÃO' ";
                sql += "WHEN 6 THEN 'VALIDADA' ";
                sql += "WHEN 7 THEN 'EM PROCESSAMENTO' ";
                sql += "WHEN 8 THEN 'CF-e AUTORIZADO' ";
                sql += "WHEN 9 THEN 'INUTILIZADO' ";
                sql += "END AS DescricaoSituacao, ";
                sql += "NFI.CFOP, SUM(NFI.ValorTotal) AS ValorTotal_Item, ";
                sql += "P.Nome_Razao AS DescricaoPessoa, ";
                sql += "T.Descricao AS NaturezaOperacao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN NotaFiscal_Item AS NFI ON NFI.ID_NF = NF.ID ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = NF.TipoPessoa AND P.ID_Pessoa = NF.ID_Pessoa ";
                sql += "INNER JOIN NF_TipoEmissao AS T ON T.ID = NF.Tipo_NF ";
                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";

                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.ID > 0)
                    sql += "AND NF.ID = " + NF.ID + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Serie > 0)
                    sql += "AND NF.Serie = " + NF.Serie + " ";

                if (NF.ID_NFe > 0)
                    sql += "AND NF.ID_NFe = " + NF.ID_NFe + " ";

                if (NF.Situacao > 0)
                    sql += "AND NF.Situacao = " + NF.Situacao + " ";

                if (NF.Tipo_NF > 0)
                    sql += "AND NF.Tipo_NF = " + NF.Tipo_NF + " ";

                if (NF.ID_Venda > 0)
                    sql += "AND NF.ID_Venda = " + NF.ID_Venda + " ";

                if (NF.TipoPessoa > 0)
                    sql += "AND NF.TipoPessoa = " + NF.TipoPessoa + " ";

                if (NF.ID_Pessoa > 0)
                    sql += "AND NF.ID_Pessoa = " + NF.ID_Pessoa + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";

                sql += "GROUP BY NFI.CFOP, NF.ID, NF.Serie,NF.ID_NFe, NF.DataEmissao, NF.Situacao, NF.ValorTotal, NF.NaturezaOperacao, NF.Chave, P.Nome_Razao, T.Descricao ";
                sql += "ORDER BY NF.ID_NFe DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Relatorio_Produto()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID,  ";
                sql += "NFI.CFOP, NFI.ID_Produto, NFI.Quantidade, NFI.ValorUnitario, NFI.ValorTotal, ";
                sql += "P.Descricao ";
                sql += "FROM ";
                sql += "NotaFiscal AS NF ";
                sql += "INNER JOIN NotaFiscal_Item AS NFI ON NFI.ID_NF = NF.ID ";
                sql += "INNER JOIN Produto_Servico AS P ON P.ID = NFI.ID_Produto ";
                sql += "WHERE ";
                sql += "NOT NF.ID IS NULL ";

                sql += "AND NF.ID_Empresa = " + NF.ID_Empresa + " ";

                if (NF.ID > 0)
                    sql += "AND NF.ID = " + NF.ID + " ";

                if (NF.Modelo > 0)
                    sql += "AND NF.Modelo = " + NF.Modelo + " ";

                if (NF.Serie > 0)
                    sql += "AND NF.Serie = " + NF.Serie + " ";

                if (NF.ID_NFe > 0)
                    sql += "AND NF.ID_NFe = " + NF.ID_NFe + " ";

                if (NF.Situacao > 0)
                    sql += "AND NF.Situacao = " + NF.Situacao + " ";

                if (NF.Tipo_NF > 0)
                    sql += "AND NF.Tipo_NF = " + NF.Tipo_NF + " ";

                if (NF.ID_Venda > 0)
                    sql += "AND NF.ID_Venda = " + NF.ID_Venda + " ";

                if (NF.TipoPessoa > 0)
                    sql += "AND NF.TipoPessoa = " + NF.TipoPessoa + " ";

                if (NF.ID_Pessoa > 0)
                    sql += "AND NF.ID_Pessoa = " + NF.ID_Pessoa + " ";

                if (NF.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, NF.DataEmissao) BETWEEN CONVERT(DATE,'" + NF.Consulta_Emissao.Inicial + "') AND CONVERT(DATE,'" + NF.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY P.Descricao DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Referenciada()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NFR.ID, NFR.Tipo, NFR.Chave_NFe, NFR.UF, NFR.DataEmissao, NFR.CNPJ_CPF, NFR.Modelo, NFR.Serie, NFR.Numero_NF, ";
                sql += "NFR.IE, NFR.CTE, NFR.Mod_CupomFiscal, NFR.ECF, NFR.Numero_Contador, ";
                sql += "UF.ID_UF ";
                sql += "FROM NotaFiscal_Referenciada AS NFR ";
                sql += "LEFT JOIN UF ON UF.Sigla = NFR.UF ";
                sql += "WHERE ";
                sql += "NFR.ID_NF = " + NF.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Ent_Ret()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NF.ID, NF.Tipo, NF.CNPJ_CPF, NF.Logradouro, NF.Numero, NF.Complemento, NF.Bairro, NF.ID_Municipio, ";
                sql += "M.Descricao AS Municipio, M.ID_Municipio AS Cod_Municipio, ";
                sql += "UF.Sigla AS UF, UF.ID_UF ";
                sql += "FROM ";
                sql += "NotaFiscal_Ent_Ret AS NF ";
                sql += "LEFT JOIN Municipios AS M ON NF.ID_Municipio = M.ID ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                sql += "WHERE ";
                sql += "NF.ID_NF = " + NF.ID + " ";

                if (NF.Tipo_Ent_Ret > 0)
                    sql += "AND NF.Tipo = " + NF.Tipo_Ent_Ret + " ";
                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_AutorizadoXML()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_NF, CNPJ_CPF ";
                sql += "FROM ";
                sql += "NotaFiscal_AutXML ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";
                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Transp()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID AS ID_Transporte, ID_Pessoa AS ID_PessoaT, ID_NF, CNPJ_CPF, Nome, IE, Endereco, Municipio, UF, ";
                sql += "UFPlaca, Placa ";
                sql += "FROM ";
                sql += "NotaFiscal_Transporte ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Volume()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Quantidade, Especie, Marca, Numeracao, PesoL, PesoB ";
                sql += "FROM ";
                sql += "NotaFiscal_Volume ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Lacre()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Numero ";
                sql += "FROM ";
                sql += "NotaFiscal_Lacre ";
                sql += "WHERE ";
                sql += "ID_NF_Volume = " + NF.ID_NF_Volume + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Importacao()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "NFI.ID, NFI.Documento, NFI.Data_Registro, NFI.Local, NFI.Data_Desen, NFI.Codigo, ";
                sql += "UF.Sigla AS UF ";
                sql += "FROM ";
                sql += "NotaFiscal_Importacao AS NFI ";
                sql += "INNER JOIN UF ON NFI.UF = ID_UF ";
                sql += "WHERE ";
                sql += "ID_NF_Item = " + NF.ID_NF_Item + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Adicao()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Numero, Seq, Codigo, Desconto ";
                sql += "FROM ";
                sql += "NotaFiscal_Adicao ";
                sql += "WHERE ";
                sql += "ID_Importacao = " + NF.ID_NF_Importacao + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Item()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "I.ID, I.ID_NF, I.ID_Produto, I.Quantidade, I.ID_Tabela, I.ValorUnitario, I.ValorTotal, I.Acrescimo, I.Desconto, I.InformacaoAdicional, I.TipoVendaProduto, I.ID_Grade, I.EX_TIPI, ";
                sql += "I.Quantidade_Selo, I.ClasseEnquadramento, I.CNPJProdutor, I.Codigo_Selo, I.CST, I.Origem, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, ";
                sql += "I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVLAdicionado, I.CFOP, I.Frete, I.Seguro, I.ValorBC, I.ValorICMS, I.ValorBCST, I.ValorICMSST, I.ValorBCSTRet, I.ValorICMSSTRet, ";
                sql += "I.CSOSN, I.AliquotaCredito, I.ValorCredito, I.CSTIPI, I.AliquotaIPI, I.ValorIPI, I.ValorBCII, I.ValorDesII, I.ValorII, I.ValorIOF, I.CSTPIS, I.AliquotaPIS, I.ValorPIS, ";
                sql += "I.ValorAliquotaPIS, I.CSTCOFINS, I.AliquotaCOFINS, I.ValorCOFINS, I.ValorAliquotaCOFINS, ValorICMSOperacao, PercentualDiferimento, ValorICMSDeferido, ValorICMSDesonerado, ";
                sql += "MotivoDesonerado, IPIDevolvido, Per_IPIDevolvido, ";
                sql += "P.NCM, P.ProdutoEspecifico, P.Cod_ANP, P.Referencia, P.ID_CEST, ";

                if (Parametro_NFe_NFC_SAT.Exibe_InfoProd == true)
                {
                    if (Parametro_NFe_NFC_SAT.Exibe_ReferenciaNFe == true)
                    {
                        sql += "CASE GP.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao + ' ' + P.Referencia + ' ' + I.InformacaoAdicional ";
                        sql += "ELSE P.Descricao + ' - ' + GP.Descricao + ' ' + P.Referencia + ' ' + I.InformacaoAdicional ";
                        sql += "END AS DescricaoProduto, ";
                    }
                    else
                    {
                        sql += "CASE GP.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao + ' ' + I.InformacaoAdicional  ";
                        sql += "ELSE P.Descricao + ' - ' + GP.Descricao + ' ' + I.InformacaoAdicional ";
                        sql += "END AS DescricaoProduto, ";
                    }
                }
                else
                {
                    if (Parametro_NFe_NFC_SAT.Exibe_ReferenciaNFe == true)
                    {
                        sql += "CASE GP.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao  + ' ' + P.Referencia ";
                        sql += "ELSE P.Descricao + ' - ' + GP.Descricao  + ' ' + P.Referencia ";
                        sql += "END AS DescricaoProduto, ";
                    }
                    else
                    {
                        sql += "CASE GP.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + GP.Descricao ";
                        sql += "END AS DescricaoProduto, ";
                    }
                }

                sql += "GS.Descricao AS DescricaoUnidade, ";
                sql += "ISNULL(N.AliqNacFederal, 0) AS AliqNacFederal, ISNULL(N.AliqImpFederal, 0) AS AliqImpFederal, ISNULL(N.AliqEstadual, 0) AS AliqEstadual ";
                sql += "FROM ";
                sql += "NotaFiscal_Item AS I ";
                sql += "INNER JOIN Produto_Servico AS P ON P.ID = I.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = I.ID_Grade ";
                sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                sql += "LEFT JOIN NCM AS N ON N.NCM = P.NCM AND N.EX = P.EX_TIPI ";
                sql += "WHERE ";
                sql += "I.ID_NF = " + NF.ID + " ";
                sql += "ORDER BY P.Descricao ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Duplicata()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, NumeroDuplicata, Vencimento, Valor ";
                sql += "FROM ";
                sql += "NotaFiscal_Duplicata ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Cobranca()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, NumeroFatura, Valor, Desconto, ValorFinal ";
                sql += "FROM ";
                sql += "NotaFiscal_Cobranca ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Evento()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "E.ID, E.Protocolo, E.Data, E.Evento, E.Seq, E.Tipo_Evento, E.Motivo, E.Stat, ";
                sql += "NF.ID_Empresa ";
                sql += "FROM ";
                sql += "NotaFiscal_Evento AS E ";
                sql += "INNER JOIN NotaFiscal AS NF ON NF.ID = E.ID_NF ";
                sql += "WHERE ";
                sql += "E.ID_NF = " + NF.ID + " ";

                if (NF.Tipo_Evento > 0)
                    sql += "AND E.Tipo_Evento = " + NF.Tipo_Evento + " ";

                if (NF.FiltraEvento == true)
                    sql += "AND E.Seq > 0 ";

                sql += "ORDER BY E.Data ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_NF_Email()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "E.Email ";
                sql += "FROM ";
                sql += "PessoaEmail AS E ";
                sql += "INNER JOIN NotaFiscal AS NF ON E.TipoPessoa = NF.TipoPessoa AND E.ID_Pessoa = NF.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NF.ID = " + NF.ID + " ";
                sql += "AND E.PrincipalEmail = 'true'";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Inutilizacao()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Serie, ";
                sql += "CONVERT(VARCHAR, CONVERT(DATE, SUBSTRING(Protocolo, 19, 10)), 103) AS Data, ";
                sql += "Numeracao, Justificativa, Protocolo ";
                sql += "FROM NotaFiscal_Inutilizacao ";
                sql += "WHERE ";
                sql += "ID_Empresa = " + NF.ID_Empresa + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            int[] lst_ID_Volume = null;
            int[] lst_ID_Item = null; ;
            int[] lst_ID_Importacao = null; ;

            DataTable _DT;
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID ";
                sql += "FROM NotaFiscal_Volume ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                _DT = new DataTable();
                _DT = conexao.Consulta(sql);
                if (_DT.Rows.Count > 0)
                {
                    lst_ID_Volume = new int[_DT.Rows.Count];
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        lst_ID_Volume[i] = Convert.ToInt32(_DT.Rows[i]["ID"]);
                }

                sql = "SELECT ID ";
                sql += "FROM NotaFiscal_Item ";
                sql += "WHERE ";
                sql += "ID_NF = " + NF.ID + " ";

                _DT = new DataTable();
                _DT = conexao.Consulta(sql);
                if (_DT.Rows.Count > 0)
                {
                    lst_ID_Item = new int[_DT.Rows.Count];
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        lst_ID_Item[i] = Convert.ToInt32(_DT.Rows[i]["ID"]);
                }

                if (lst_ID_Item != null)
                {
                    sql = "SELECT ID ";
                    sql += "FROM NotaFiscal_Importacao ";
                    sql += "WHERE ";
                    sql += "ID_NF_Item IN (" + util_dados.Cria_Lista_Consulta(lst_ID_Item) + ") ";

                    _DT = new DataTable();
                    _DT = conexao.Consulta(sql);
                    if (_DT.Rows.Count > 0)
                    {
                        lst_ID_Importacao = new int[_DT.Rows.Count];
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            lst_ID_Importacao[i] = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    }
                }

                conexao.Begin_Conexao();

                if (lst_ID_Importacao != null)
                {
                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "NotaFiscal_Adicao ";
                    sql += "WHERE ";
                    sql += "ID_Importacao IN (" + util_dados.Cria_Lista_Consulta(lst_ID_Importacao) + ")";
                    cmd.CommandText = sql;
                    conexao.Executa_Comando(cmd);
                }

                if (lst_ID_Item != null)
                {
                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "NotaFiscal_Importacao ";
                    sql += "WHERE ";
                    sql += "ID_NF_Item IN (" + util_dados.Cria_Lista_Consulta(lst_ID_Item) + ")";
                    cmd.CommandText = sql;
                    conexao.Executa_Comando(cmd);
                }

                if (lst_ID_Volume != null)
                {
                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "NotaFiscal_Lacre ";
                    sql += "WHERE ";
                    sql += "ID_NF_Volume IN (" + util_dados.Cria_Lista_Consulta(lst_ID_Volume) + ")";
                    cmd.CommandText = sql;
                    conexao.Executa_Comando(cmd);
                }

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_AutXML ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Cobranca ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Duplicata ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Ent_Ret ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);


                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Evento ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Referenciada ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Transporte ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Volume ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Item ";
                sql += "WHERE ";
                sql += "ID_NF = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.ID);
                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Duplicata()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_Duplicata ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Duplicata[0].ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Cobranca()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_Cobranca ";
                sql += "WHERE ";
                sql += "ID_NF = @ID_NF";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_NF", NF.ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Transportadora()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_Transporte ";
                sql += "WHERE ";
                sql += "ID_NF = @ID_NF";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_NF", NF.ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Volume()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_Volume ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Volume[0].ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_AutorizadoXML()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_AutXML ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Autorizacao_XML[0].ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Referenciada()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "NotaFiscal_Referenciada ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Referenciada[0].ID);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_NF_Item()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID FROM NotaFiscal_Importacao ";
                sql += "WHERE ID_NF_Item = " + NF.Itens[0].ID + " ";
                DataTable DT = conexao.Consulta(sql);

                conexao.Begin_Conexao();

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Item ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Itens[0].ID);

                conexao.Executa_Comando(cmd);

                if (DT.Rows.Count > 0)
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        sql = "DELETE FROM ";
                        sql += "NotaFiscal_Adicao ";
                        sql += "WHERE ";
                        sql += "ID_Importacao = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", DT.Rows[i]["ID"]);
                        conexao.Executa_Comando(cmd);
                    }

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "NotaFiscal_Importacao ";
                sql += "WHERE ";
                sql += "ID_NF_Item = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF.Itens[0].ID);

                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }
    }
}

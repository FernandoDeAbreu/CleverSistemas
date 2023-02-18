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
    public class DAL_Parametro
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Parametro Parametro;
        #endregion

        #region CONSTRUTOR
        public DAL_Parametro(DTO_Parametro _Parametro)
        {
            Parametro = _Parametro;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_Empresa FROM Parametro_Sistema ";
                sql += "WHERE ID_Empresa = " + Parametro.ID_Empresa + " ";

                switch (Parametro.Tipo)
                {
                    #region PARAMETRO FINANCEIRO
                    case 1:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, Juros_Mes, Multa, ID_ContaTransValor, ID_ContaDevolucaoCheque, ID_ContaFaturaVenda, ";
                            sql += "ID_ContaFaturaOS, ID_ContaFaturaCompra, ID_ContaDevolucaoVenda, ID_Caixa_Principal, ID_Conta_PagtoDiverso, ";
                            sql += "ID_Conta_RectoDiverso, ID_Conta_CobrancaBancaria, ID_PagtoBoleto) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @Juros_Mes, @Multa, @ID_ContaTransValor, @ID_ContaDevolucaoCheque, @ID_ContaFaturaVenda, ";
                            sql += "@ID_ContaFaturaOS, @ID_ContaFaturaCompra, @ID_ContaDevolucaoVenda, @ID_Caixa_Principal, @ID_Conta_PagtoDiverso, ";
                            sql += "@ID_Conta_RectoDiverso, @ID_Conta_CobrancaBancaria, @ID_PagtoBoleto) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Juros_Mes", Parametro.Financeiro.Juros_Mes);
                            cmd.Parameters.AddWithValue("@Multa", Parametro.Financeiro.Multa);
                            cmd.Parameters.AddWithValue("@ID_ContaTransValor", Parametro.Financeiro.ID_ContaTransValor);
                            cmd.Parameters.AddWithValue("@ID_ContaDevolucaoCheque", Parametro.Financeiro.ID_ContaDevolucaoCheque);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaVenda", Parametro.Financeiro.ID_ContaFaturaVenda);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaOS", Parametro.Financeiro.ID_ContaFaturaOS);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaOS", Parametro.Financeiro.ID_ContaFaturaCompra);
                            cmd.Parameters.AddWithValue("@ID_ContaDevolucaoVenda", Parametro.Financeiro.ID_ContaDevolucaoVenda);
                            cmd.Parameters.AddWithValue("@ID_Caixa_Principal", Parametro.Financeiro.ID_Caixa_Principal);
                            cmd.Parameters.AddWithValue("@ID_Conta_PagtoDiverso", Parametro.Financeiro.ID_Conta_PagtoDiverso);
                            cmd.Parameters.AddWithValue("@ID_Conta_RectoDiverso", Parametro.Financeiro.ID_Conta_RectoDiverso);
                            cmd.Parameters.AddWithValue("@ID_Conta_CobrancaBancaria", Parametro.Financeiro.ID_Conta_CobrancaBancaria);
                            cmd.Parameters.AddWithValue("@ID_PagtoBoleto", Parametro.Financeiro.ID_PagtoBoleto);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "Juros_Mes = @Juros_Mes, ";
                            sql += "Multa = @Multa, ";
                            sql += "ID_ContaTransValor = @ID_ContaTransValor, ";
                            sql += "ID_ContaDevolucaoCheque = @ID_ContaDevolucaoCheque, ";
                            sql += "ID_ContaFaturaVenda = @ID_ContaFaturaVenda, ";
                            sql += "ID_ContaFaturaOS = @ID_ContaFaturaOS, ";
                            sql += "ID_ContaFaturaCompra = @ID_ContaFaturaCompra, ";
                            sql += "ID_ContaDevolucaoVenda = @ID_ContaDevolucaoVenda, ";
                            sql += "ID_Caixa_Principal = @ID_Caixa_Principal, ";
                            sql += "ID_Conta_PagtoDiverso = @ID_Conta_PagtoDiverso, ";
                            sql += "ID_Conta_RectoDiverso = @ID_Conta_RectoDiverso, ";
                            sql += "ID_Conta_CobrancaBancaria = @ID_Conta_CobrancaBancaria, ";
                            sql += "ID_PagtoBoleto = @ID_PagtoBoleto ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Juros_Mes", Parametro.Financeiro.Juros_Mes);
                            cmd.Parameters.AddWithValue("@Multa", Parametro.Financeiro.Multa);
                            cmd.Parameters.AddWithValue("@ID_ContaTransValor", Parametro.Financeiro.ID_ContaTransValor);
                            cmd.Parameters.AddWithValue("@ID_ContaDevolucaoCheque", Parametro.Financeiro.ID_ContaDevolucaoCheque);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaVenda", Parametro.Financeiro.ID_ContaFaturaVenda);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaOS", Parametro.Financeiro.ID_ContaFaturaOS);
                            cmd.Parameters.AddWithValue("@ID_ContaFaturaCompra", Parametro.Financeiro.ID_ContaFaturaCompra);
                            cmd.Parameters.AddWithValue("@ID_ContaDevolucaoVenda", Parametro.Financeiro.ID_ContaDevolucaoVenda);
                            cmd.Parameters.AddWithValue("@ID_Caixa_Principal", Parametro.Financeiro.ID_Caixa_Principal);
                            cmd.Parameters.AddWithValue("@ID_Conta_PagtoDiverso", Parametro.Financeiro.ID_Conta_PagtoDiverso);
                            cmd.Parameters.AddWithValue("@ID_Conta_RectoDiverso", Parametro.Financeiro.ID_Conta_RectoDiverso);
                            cmd.Parameters.AddWithValue("@ID_Conta_CobrancaBancaria", Parametro.Financeiro.ID_Conta_CobrancaBancaria);
                            cmd.Parameters.AddWithValue("@ID_PagtoBoleto", Parametro.Financeiro.ID_PagtoBoleto);
                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO VENDAS
                    case 2:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, DiasBloqueioVenda, ID_ConsumidorFinal, ID_TabelaVenda, Consulta_Grade, TipoImpressoraTermica, ";
                            sql += "Ultimo_Valor, Permitir2Vias, Agrupar_Produto, Descricao_Comissao, Limite_Desconto, Produto_Marca, Bloquear_EstoqueNegativo, ";
                            sql += "msg_EstoqueNegativo, Orca_ValorTotal, MultiploUsuarioPDV, Consulta_RapidaProduto, NaoAlterarVendaFaturada, PagamentoTrocoDevolucao, ";
                            sql += "Venda_Matricial, Modelo_Matricial, Desconto_Padrao, Exibe_NFeVenda, CFe_Cartao, Venda_ImpressaoDireta, CFe_PDV_Cartao, TipoSaida_Fixo, ";
                            sql += "Produto_PrecoVenda, Qt_Dias_Pesquisa, Altera_ValorPDV) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @DiasBloqueioVenda, @ID_ConsumidorFinal, @ID_TabelaVenda, Consulta_Grade, @TipoImpressoraTermica, ";
                            sql += "@Ultimo_Valor, @Permitir2Vias, @Agrupar_Produto, @Descricao_Comissao, @Limite_Desconto, @Produto_Marca, @Bloquear_EstoqueNegativo, ";
                            sql += "@msg_EstoqueNegativo, @Orca_ValorTotal, @MultiploUsuarioPDV, @Consulta_RapidaProduto, @NaoAlterarVendaFaturada, @PagamentoTrocoDevolucao, ";
                            sql += "@Venda_Matricial, @Modelo_Matricial @Desconto_Padrao, @Exibe_NFeVenda, @CFe_Cartao, @Venda_ImpressaoDireta, @CFe_PDV_Cartao, @TipoSaida_Fixo, ";
                            sql += "@Produto_PrecoVenda, @Qt_Dias_Pesquisa, Altera_ValorPDV) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@DiasBloqueioVenda", Parametro.Vendas.DiasBloqueioVenda);
                            cmd.Parameters.AddWithValue("@ID_ConsumidorFinal", Parametro.Vendas.ID_ConsumidorFinal);
                            cmd.Parameters.AddWithValue("@ID_TabelaVenda", Parametro.Vendas.ID_TabelaVenda);
                            cmd.Parameters.AddWithValue("@Consulta_Grade", Parametro.Vendas.Consulta_Grade);
                            cmd.Parameters.AddWithValue("@TipoImpressoraTermica", Parametro.Vendas.TipoImpressoraTermica);
                            cmd.Parameters.AddWithValue("@Ultimo_Valor", Parametro.Vendas.Ultimo_Valor);
                            cmd.Parameters.AddWithValue("@Permitir2Vias", Parametro.Vendas.Permitir2Vias);
                            cmd.Parameters.AddWithValue("@Agrupar_Produto", Parametro.Vendas.Agrupar_Produto);
                            cmd.Parameters.AddWithValue("@Descricao_Comissao", Parametro.Vendas.Descricao_Comissao);
                            cmd.Parameters.AddWithValue("@Limite_Desconto", Parametro.Vendas.Limite_Desconto);
                            cmd.Parameters.AddWithValue("@Produto_Marca", Parametro.Vendas.Produto_Marca);
                            cmd.Parameters.AddWithValue("@Bloquear_EstoqueNegativo", Parametro.Vendas.Bloquear_EstoqueNegativo);
                            cmd.Parameters.AddWithValue("@msg_EstoqueNegativo", Parametro.Vendas.msg_EstoqueNegativo);
                            cmd.Parameters.AddWithValue("@Orca_ValorTotal", Parametro.Vendas.Orca_ValorTotal);
                            cmd.Parameters.AddWithValue("@MultiploUsuarioPDV", Parametro.Vendas.MultiploUsuarioPDV);
                            cmd.Parameters.AddWithValue("@Consulta_RapidaProduto", Parametro.Vendas.Consulta_RapidaProduto);
                            cmd.Parameters.AddWithValue("@NaoAlterarVendaFaturada", Parametro.Vendas.NaoAlterarVendaFaturada);
                            cmd.Parameters.AddWithValue("@PagamentoTrocoDevolucao", Parametro.Vendas.PagamentoTrocoDevolucao);
                            cmd.Parameters.AddWithValue("@Venda_Matricial", Parametro.Vendas.Venda_Matricial);
                            cmd.Parameters.AddWithValue("@Modelo_Matricial", Parametro.Vendas.Modelo_Matricial);
                            cmd.Parameters.AddWithValue("@Desconto_Padrao", Parametro.Vendas.Desconto_Padrao);
                            cmd.Parameters.AddWithValue("@Exibe_NFeVenda", Parametro.Vendas.Exibe_NFeVenda);
                            cmd.Parameters.AddWithValue("@CFe_Cartao", Parametro.Vendas.CFe_Cartao);
                            cmd.Parameters.AddWithValue("@Venda_ImpressaoDireta", Parametro.Vendas.Venda_ImpressaoDireta);
                            cmd.Parameters.AddWithValue("@CFe_PDV_Cartao", Parametro.Vendas.CFe_PDV_Cartao);
                            cmd.Parameters.AddWithValue("@TipoSaida_Fixo", Parametro.Vendas.TipoSaida_Fixo);
                            cmd.Parameters.AddWithValue("@Qt_Dias_Pesquisa", Parametro.Vendas.Qt_Dias_Pesquisa);
                            cmd.Parameters.AddWithValue("@Altera_ValorPDV", Parametro.Vendas.Altera_ValorPDV);

                            switch (Parametro.Vendas.Produto_PrecoVenda)
                            {
                                case Composicao_PrecoVenda.Custo_Final:
                                    cmd.Parameters.AddWithValue("@Produto_PrecoVenda", 1);
                                    break;

                                case Composicao_PrecoVenda.Preco_Compra:
                                    cmd.Parameters.AddWithValue("@Produto_PrecoVenda", 1);
                                    break;
                            }

                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE Parametro_Sistema SET ";
                            sql += "DiasBloqueioVenda = @DiasBloqueioVenda, ";
                            sql += "ID_ConsumidorFinal = @ID_ConsumidorFinal, ";
                            sql += "ID_TabelaVenda = @ID_TabelaVenda, ";
                            sql += "Consulta_Grade = @Consulta_Grade, ";
                            sql += "TipoImpressoraTermica = @TipoImpressoraTermica, ";
                            sql += "Ultimo_Valor = @Ultimo_Valor, ";
                            sql += "Permitir2Vias = @Permitir2Vias, ";
                            sql += "Agrupar_Produto = @Agrupar_Produto, ";
                            sql += "Descricao_Comissao = @Descricao_Comissao, ";
                            sql += "Limite_Desconto = @Limite_Desconto, ";
                            sql += "Produto_Marca = @Produto_Marca, ";
                            sql += "Bloquear_EstoqueNegativo = @Bloquear_EstoqueNegativo, ";
                            sql += "msg_EstoqueNegativo = @msg_EstoqueNegativo, ";
                            sql += "Orca_ValorTotal = @Orca_ValorTotal, ";
                            sql += "MultiploUsuarioPDV = @MultiploUsuarioPDV, ";
                            sql += "Consulta_RapidaProduto = @Consulta_RapidaProduto, ";
                            sql += "NaoAlterarVendaFaturada = @NaoAlterarVendaFaturada, ";
                            sql += "PagamentoTrocoDevolucao = @PagamentoTrocoDevolucao, ";
                            sql += "Venda_Matricial = @Venda_Matricial, ";
                            sql += "Modelo_Matricial = @Modelo_Matricial, ";
                            sql += "Desconto_Padrao = @Desconto_Padrao, ";
                            sql += "Exibe_NFeVenda = @Exibe_NFeVenda, ";
                            sql += "CFe_Cartao = @CFe_Cartao, ";
                            sql += "Venda_ImpressaoDireta = @Venda_ImpressaoDireta, ";
                            sql += "CFe_PDV_Cartao = @CFe_PDV_Cartao, ";
                            sql += "TipoSaida_Fixo = @TipoSaida_Fixo, ";
                            sql += "Produto_PrecoVenda = @Produto_PrecoVenda, ";
                            sql += "Qt_Dias_Pesquisa = @Qt_Dias_Pesquisa, ";
                            sql += "Altera_ValorPDV = @Altera_ValorPDV ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@DiasBloqueioVenda", Parametro.Vendas.DiasBloqueioVenda);
                            cmd.Parameters.AddWithValue("@ID_ConsumidorFinal", Parametro.Vendas.ID_ConsumidorFinal);
                            cmd.Parameters.AddWithValue("@ID_TabelaVenda", Parametro.Vendas.ID_TabelaVenda);
                            cmd.Parameters.AddWithValue("@Consulta_Grade", Parametro.Vendas.Consulta_Grade);
                            cmd.Parameters.AddWithValue("@TipoImpressoraTermica", Parametro.Vendas.TipoImpressoraTermica);
                            cmd.Parameters.AddWithValue("@Ultimo_Valor", Parametro.Vendas.Ultimo_Valor);
                            cmd.Parameters.AddWithValue("@Permitir2Vias", Parametro.Vendas.Permitir2Vias);
                            cmd.Parameters.AddWithValue("@Agrupar_Produto", Parametro.Vendas.Agrupar_Produto);
                            cmd.Parameters.AddWithValue("@Descricao_Comissao", Parametro.Vendas.Descricao_Comissao);
                            cmd.Parameters.AddWithValue("@Limite_Desconto", Parametro.Vendas.Limite_Desconto);
                            cmd.Parameters.AddWithValue("@Produto_Marca", Parametro.Vendas.Produto_Marca);
                            cmd.Parameters.AddWithValue("@Bloquear_EstoqueNegativo", Parametro.Vendas.Bloquear_EstoqueNegativo);
                            cmd.Parameters.AddWithValue("@msg_EstoqueNegativo", Parametro.Vendas.msg_EstoqueNegativo);
                            cmd.Parameters.AddWithValue("@Orca_ValorTotal", Parametro.Vendas.Orca_ValorTotal);
                            cmd.Parameters.AddWithValue("@MultiploUsuarioPDV", Parametro.Vendas.MultiploUsuarioPDV);
                            cmd.Parameters.AddWithValue("@Consulta_RapidaProduto", Parametro.Vendas.Consulta_RapidaProduto);
                            cmd.Parameters.AddWithValue("@NaoAlterarVendaFaturada", Parametro.Vendas.NaoAlterarVendaFaturada);
                            cmd.Parameters.AddWithValue("@PagamentoTrocoDevolucao", Parametro.Vendas.PagamentoTrocoDevolucao);
                            cmd.Parameters.AddWithValue("@Venda_Matricial", Parametro.Vendas.Venda_Matricial);
                            cmd.Parameters.AddWithValue("@Modelo_Matricial", Parametro.Vendas.Modelo_Matricial);
                            cmd.Parameters.AddWithValue("@Desconto_Padrao", Parametro.Vendas.Desconto_Padrao);
                            cmd.Parameters.AddWithValue("@Exibe_NFeVenda", Parametro.Vendas.Exibe_NFeVenda);
                            cmd.Parameters.AddWithValue("@CFe_Cartao", Parametro.Vendas.CFe_Cartao);
                            cmd.Parameters.AddWithValue("@Venda_ImpressaoDireta", Parametro.Vendas.Venda_ImpressaoDireta);
                            cmd.Parameters.AddWithValue("@CFe_PDV_Cartao", Parametro.Vendas.CFe_PDV_Cartao);
                            cmd.Parameters.AddWithValue("@TipoSaida_Fixo", Parametro.Vendas.TipoSaida_Fixo);
                            cmd.Parameters.AddWithValue("@Qt_Dias_Pesquisa", Parametro.Vendas.Qt_Dias_Pesquisa);
                            cmd.Parameters.AddWithValue("@Altera_ValorPDV", Parametro.Vendas.Altera_ValorPDV);

                            switch (Parametro.Vendas.Produto_PrecoVenda)
                            {
                                case Composicao_PrecoVenda.Custo_Final:
                                    cmd.Parameters.AddWithValue("@Produto_PrecoVenda", 1);
                                    break;

                                case Composicao_PrecoVenda.Preco_Compra:
                                    cmd.Parameters.AddWithValue("@Produto_PrecoVenda", 2);
                                    break;
                            }

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO MOBILE
                    case 3:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, HistoricoVenda) ";
                            sql += "VALUES ";
                            sql += "(ID_Empresa, @HistoricoVenda) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@HistoricoVenda", Parametro.Mobile.HistoricoVenda);

                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "HistoricoVenda = @HistoricoVenda ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@HistoricoVenda", Parametro.Mobile.HistoricoVenda);

                            conexao.Executa_Comando(cmd);
                        }

                        cmd = new SqlCommand();

                        sql = "DROP VIEW V_HistoricoVenda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda AS ";
                        sql += "SELECT DISTINCT ";
                        sql += "V.ID_Venda AS ID, V.ID_Pessoa, CONVERT(VARCHAR(10), V.Data, 103) AS Data, ";
                        sql += "VI.ID_Tabela, V.ID_Parcelamento, V.Informacao, 0 AS Desconto, V.Comprador, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Venda AS V ";
                        sql += "INNER JOIN V_Venda_Item AS VI ON V.ID_Venda = VI.ID_Venda ";
                        sql += "WHERE (V.Data >= DATEADD(d, -" + Parametro.Mobile.HistoricoVenda + ", GETDATE())) ";
                        sql += "GROUP BY V.ID_Venda, V.ID_Pessoa, V.Data, VI.ID_Tabela, VI.ID_Tabela, V.ID_Parcelamento, ";
                        sql += "V.Informacao, VI.Desconto, V.Comprador, V.ID_UsuarioComissao1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_HistoricoVenda_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda_Item AS ";
                        sql += "SELECT VI.ID_Venda AS ID_Venda, VI.ID_Produto, VI.Quantidade, VI.Informacao, VI.TipoSaida, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Venda_Item AS VI ";
                        sql += "INNER JOIN V_Venda AS V ON V.ID_Venda = VI.ID_Venda ";
                        sql += "WHERE (V.Data >= DATEADD(d, -" + Parametro.Mobile.HistoricoVenda + ", GETDATE())) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion

                    #region PARAMETRO NF-e / NFC-e
                    case 5:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, AmbienteNFe, RegimeTributario, Exibe_msgCreditoICMS, AliquotaCreditoICMS, Caminho_NFe, Exibe_Desconto, ";
                            sql += "Exibe_InfoProduto, Certificado_NFe, Tipo_NFe_Venda, Exibe_ReferenciaNFe) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @AmbienteNFe, @RegimeTributario, @Exibe_msgCreditoICMS, @AliquotaCreditoICMS, @Caminho_NFe, @Exibe_Desconto, ";
                            sql += "@Exibe_InfoProduto, @Certificado_NFe, @Tipo_NFe_Venda, @Exibe_ReferenciaNFe) ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@AmbienteNFe", Parametro.NFe_NFCe.AmbienteNFe);
                            cmd.Parameters.AddWithValue("@RegimeTributario", Parametro.NFe_NFCe.RegimeTributario);
                            cmd.Parameters.AddWithValue("@Exibe_msgCreditoICMS", Parametro.NFe_NFCe.Exibe_msgCreditoICMS);
                            cmd.Parameters.AddWithValue("@AliquotaCreditoICMS", Parametro.NFe_NFCe.AliquotaCreditoICMS);
                            cmd.Parameters.AddWithValue("@Caminho_NFe", Parametro.NFe_NFCe.Caminho_NFe);
                            cmd.Parameters.AddWithValue("@Exibe_Desconto", Parametro.NFe_NFCe.Exibe_Desconto);
                            cmd.Parameters.AddWithValue("@Exibe_InfoProduto", Parametro.NFe_NFCe.Exibe_InfoProduto);
                            cmd.Parameters.AddWithValue("@Certificado_NFe", Parametro.NFe_NFCe.Certificado_NFe);
                            cmd.Parameters.AddWithValue("@Tipo_NFe_Venda", Parametro.NFe_NFCe.Tipo_NFe_Venda);
                            cmd.Parameters.AddWithValue("@Exibe_ReferenciaNFe", Parametro.NFe_NFCe.Exibe_ReferenciaNFe);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "AmbienteNFe = @AmbienteNFe, ";
                            sql += "RegimeTributario = @RegimeTributario, ";
                            sql += "Exibe_msgCreditoICMS = @Exibe_msgCreditoICMS, ";
                            sql += "AliquotaCreditoICMS = @AliquotaCreditoICMS, ";
                            sql += "Caminho_NFe = @Caminho_NFe, ";
                            sql += "Exibe_Desconto = @Exibe_Desconto, ";
                            sql += "Exibe_InfoProduto = @Exibe_InfoProduto, ";
                            sql += "Certificado_NFe = @Certificado_NFe, ";
                            sql += "Tipo_NFe_Venda = @Tipo_NFe_Venda, ";
                            sql += "Exibe_ReferenciaNFe = @Exibe_ReferenciaNFe ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@AmbienteNFe", Parametro.NFe_NFCe.AmbienteNFe);
                            cmd.Parameters.AddWithValue("@RegimeTributario", Parametro.NFe_NFCe.RegimeTributario);
                            cmd.Parameters.AddWithValue("@Exibe_msgCreditoICMS", Parametro.NFe_NFCe.Exibe_msgCreditoICMS);
                            cmd.Parameters.AddWithValue("@AliquotaCreditoICMS", Parametro.NFe_NFCe.AliquotaCreditoICMS);
                            cmd.Parameters.AddWithValue("@Caminho_NFe", Parametro.NFe_NFCe.Caminho_NFe);
                            cmd.Parameters.AddWithValue("@Exibe_Desconto", Parametro.NFe_NFCe.Exibe_Desconto);
                            cmd.Parameters.AddWithValue("@Exibe_InfoProduto", Parametro.NFe_NFCe.Exibe_InfoProduto);
                            cmd.Parameters.AddWithValue("@Certificado_NFe", Parametro.NFe_NFCe.Certificado_NFe);
                            cmd.Parameters.AddWithValue("@Tipo_NFe_Venda", Parametro.NFe_NFCe.Tipo_NFe_Venda);
                            cmd.Parameters.AddWithValue("@Exibe_ReferenciaNFe", Parametro.NFe_NFCe.Exibe_ReferenciaNFe);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO CF-e SAT
                    case 6:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, TipoEquipamentoSAT, SenhaAtivacaoSAT, AssinaturaSAT, CFe_A4, Monitor_CFe) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @TipoEquipamentoSAT, @SenhaAtivacaoSAT, @AssinaturaSAT, @CFe_A4, @Monitor_CFe) ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@TipoEquipamentoSAT", Parametro.CFe_SAT.TipoEquipamentoSAT);
                            cmd.Parameters.AddWithValue("@SenhaAtivacaoSAT", Parametro.CFe_SAT.SenhaAtivacaoSAT);
                            cmd.Parameters.AddWithValue("@AssinaturaSAT", Parametro.CFe_SAT.AssinaturaSAT);
                            cmd.Parameters.AddWithValue("@CFe_A4", Parametro.CFe_SAT.CFe_A4);
                            cmd.Parameters.AddWithValue("@Monitor_CFe", Parametro.CFe_SAT.Monitor_CFe);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "TipoEquipamentoSAT = @TipoEquipamentoSAT, ";
                            sql += "SenhaAtivacaoSAT = @SenhaAtivacaoSAT, ";
                            sql += "AssinaturaSAT = @AssinaturaSAT, ";
                            sql += "CFe_A4 =  @CFe_A4, ";
                            sql += "Monitor_CFe = @Monitor_CFe ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@TipoEquipamentoSAT", Parametro.CFe_SAT.TipoEquipamentoSAT);
                            cmd.Parameters.AddWithValue("@SenhaAtivacaoSAT", Parametro.CFe_SAT.SenhaAtivacaoSAT);
                            cmd.Parameters.AddWithValue("@AssinaturaSAT", Parametro.CFe_SAT.AssinaturaSAT);
                            cmd.Parameters.AddWithValue("@CFe_A4", Parametro.CFe_SAT.CFe_A4);
                            cmd.Parameters.AddWithValue("@Monitor_CFe", Parametro.CFe_SAT.Monitor_CFe);
                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO ORDEM DE SERVIÇO
                    case 7:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, Descricao_Info1, Descricao_Info2, Descricao_Info3, Descricao_Obs1, Descricao_Obs2, Imprime_OS_Equip) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @Descricao_Info1, @Descricao_Info2, @Descricao_Info3, @Descricao_Obs1, @Descricao_Obs2, @Imprime_OS_Equip) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Descricao_Info1", Parametro.OrdemServico.Descricao_Info1);
                            cmd.Parameters.AddWithValue("@Descricao_Info2", Parametro.OrdemServico.Descricao_Info2);
                            cmd.Parameters.AddWithValue("@Descricao_Info3", Parametro.OrdemServico.Descricao_Info3);
                            cmd.Parameters.AddWithValue("@Descricao_Obs1", Parametro.OrdemServico.Descricao_Obs1);
                            cmd.Parameters.AddWithValue("@Descricao_Obs2", Parametro.OrdemServico.Descricao_Obs2);
                            cmd.Parameters.AddWithValue("@Imprime_OS_Equip", Parametro.OrdemServico.Imprime_OS_Equip);

                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "Descricao_Info1 = @Descricao_Info1, ";
                            sql += "Descricao_Info2 = @Descricao_Info2, ";
                            sql += "Descricao_Info3 = @Descricao_Info3, ";
                            sql += "Descricao_Obs1 = @Descricao_Obs1, ";
                            sql += "Descricao_Obs2 = @Descricao_Obs2, ";
                            sql += "Imprime_OS_Equip = @Imprime_OS_Equip ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Descricao_Info1", Parametro.OrdemServico.Descricao_Info1);
                            cmd.Parameters.AddWithValue("@Descricao_Info2", Parametro.OrdemServico.Descricao_Info2);
                            cmd.Parameters.AddWithValue("@Descricao_Info3", Parametro.OrdemServico.Descricao_Info3);
                            cmd.Parameters.AddWithValue("@Descricao_Obs1", Parametro.OrdemServico.Descricao_Obs1);
                            cmd.Parameters.AddWithValue("@Descricao_Obs2", Parametro.OrdemServico.Descricao_Obs2);
                            cmd.Parameters.AddWithValue("@Imprime_OS_Equip", Parametro.OrdemServico.Imprime_OS_Equip);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO CADASTRO PERSONALIZADO
                    case 8:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();

                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, ClienteDescricao1, ClienteDescricao2, ClienteDescricao3, EmpresaDescricao1, EmpresaDescricao2, EmpresaDescricao3, ";
                            sql += "FornecedorDescricao1, FornecedorDescricao2, FornecedorDescricao3, FuncionarioDescricao1, FuncionarioDescricao2, FuncionarioDescricao3, ";
                            sql += "TransportadoraDescricao1, TransportadoraDescricao2, TransportadoraDescricao3, Info_Produto1, Info_Produto2) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @ClienteDescricao1, @ClienteDescricao2, @ClienteDescricao3, @EmpresaDescricao1, @EmpresaDescricao2, @EmpresaDescricao3, ";
                            sql += "@FornecedorDescricao1, @FornecedorDescricao2, @FornecedorDescricao3, @FuncionarioDescricao1, @FuncionarioDescricao2, @FuncionarioDescricao3, ";
                            sql += "@TransportadoraDescricao1, @TransportadoraDescricao2, @TransportadoraDescricao3, @Info_Produto1, @Info_Produto2) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@ClienteDescricao1", Parametro.CadastroPersonalizado.ClienteDescricao1);
                            cmd.Parameters.AddWithValue("@ClienteDescricao2", Parametro.CadastroPersonalizado.ClienteDescricao2);
                            cmd.Parameters.AddWithValue("@ClienteDescricao3", Parametro.CadastroPersonalizado.ClienteDescricao3);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao1", Parametro.CadastroPersonalizado.EmpresaDescricao1);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao2", Parametro.CadastroPersonalizado.EmpresaDescricao2);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao3", Parametro.CadastroPersonalizado.EmpresaDescricao3);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao1", Parametro.CadastroPersonalizado.FornecedorDescricao1);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao2", Parametro.CadastroPersonalizado.FornecedorDescricao2);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao3", Parametro.CadastroPersonalizado.FornecedorDescricao3);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao1", Parametro.CadastroPersonalizado.FuncionarioDescricao1);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao2", Parametro.CadastroPersonalizado.FuncionarioDescricao2);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao3", Parametro.CadastroPersonalizado.FuncionarioDescricao3);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao1", Parametro.CadastroPersonalizado.TransportadoraDescricao1);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao2", Parametro.CadastroPersonalizado.TransportadoraDescricao2);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao3", Parametro.CadastroPersonalizado.TransportadoraDescricao3);
                            cmd.Parameters.AddWithValue("@Info_Produto1", Parametro.CadastroPersonalizado.Info_Produto1);
                            cmd.Parameters.AddWithValue("@Info_Produto2", Parametro.CadastroPersonalizado.Info_Produto2);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE ";
                            sql += "Parametro_Sistema ";
                            sql += "SET ";
                            sql += "ClienteDescricao1 = @ClienteDescricao1, ";
                            sql += "ClienteDescricao2 = @ClienteDescricao2, ";
                            sql += "ClienteDescricao3 = @ClienteDescricao3, ";
                            sql += "EmpresaDescricao1 = @EmpresaDescricao1, ";
                            sql += "EmpresaDescricao2 = @EmpresaDescricao2, ";
                            sql += "EmpresaDescricao3 = @EmpresaDescricao3, ";
                            sql += "FornecedorDescricao1 = @FornecedorDescricao1, ";
                            sql += "FornecedorDescricao2 = @FornecedorDescricao2, ";
                            sql += "FornecedorDescricao3 = @FornecedorDescricao3, ";
                            sql += "FuncionarioDescricao1 = @FuncionarioDescricao1, ";
                            sql += "FuncionarioDescricao2 = @FuncionarioDescricao2, ";
                            sql += "FuncionarioDescricao3 = @FuncionarioDescricao3, ";
                            sql += "TransportadoraDescricao1 = @TransportadoraDescricao1, ";
                            sql += "TransportadoraDescricao2 = @TransportadoraDescricao2, ";
                            sql += "TransportadoraDescricao3 = @TransportadoraDescricao3, ";
                            sql += "Info_Produto1 = @Info_Produto1, ";
                            sql += "Info_Produto2 = @Info_Produto2 ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@ClienteDescricao1", Parametro.CadastroPersonalizado.ClienteDescricao1);
                            cmd.Parameters.AddWithValue("@ClienteDescricao2", Parametro.CadastroPersonalizado.ClienteDescricao2);
                            cmd.Parameters.AddWithValue("@ClienteDescricao3", Parametro.CadastroPersonalizado.ClienteDescricao3);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao1", Parametro.CadastroPersonalizado.EmpresaDescricao1);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao2", Parametro.CadastroPersonalizado.EmpresaDescricao2);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao3", Parametro.CadastroPersonalizado.EmpresaDescricao3);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao1", Parametro.CadastroPersonalizado.FornecedorDescricao1);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao2", Parametro.CadastroPersonalizado.FornecedorDescricao2);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao3", Parametro.CadastroPersonalizado.FornecedorDescricao3);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao1", Parametro.CadastroPersonalizado.FuncionarioDescricao1);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao2", Parametro.CadastroPersonalizado.FuncionarioDescricao2);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao3", Parametro.CadastroPersonalizado.FuncionarioDescricao3);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao1", Parametro.CadastroPersonalizado.TransportadoraDescricao1);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao2", Parametro.CadastroPersonalizado.TransportadoraDescricao2);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao3", Parametro.CadastroPersonalizado.TransportadoraDescricao3);
                            cmd.Parameters.AddWithValue("@Info_Produto1", Parametro.CadastroPersonalizado.Info_Produto1);
                            cmd.Parameters.AddWithValue("@Info_Produto2", Parametro.CadastroPersonalizado.Info_Produto2);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO CONFIGURAÇÃO DE EMAIL
                    case 9:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();
                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, De, Email) ";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @De, @Email) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@De", Parametro.Config_Email.De);
                            cmd.Parameters.AddWithValue("@Email", Parametro.Config_Email.Email);

                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE Parametro_Sistema SET ";
                            sql += "De = @De, ";
                            sql += "Email = @Email ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@De", Parametro.Config_Email.De);
                            cmd.Parameters.AddWithValue("@Email", Parametro.Config_Email.Email);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PARAMETRO CADASTRO
                    case 10:
                        if (conexao.Consulta(sql).Rows.Count == 0)
                        {
                            conexao.Begin_Conexao();
                            sql = "INSERT INTO ";
                            sql += "Parametro_Sistema ";
                            sql += "(ID_Empresa, Exibe_DuplicarProduto, Somente_Maiusculo, Cadastro_PessoaPadrao, Endereco_Padrao, Telefone_Padrao, EntradaProduto, ";
                            sql += "Decimal_Produto_Valor, Decimal_Produto_Quantidade)";
                            sql += "VALUES ";
                            sql += "(@ID_Empresa, @Exibe_DuplicarProduto, @Somente_Maiusculo, Cadastro_PessoaPadrao, @Endereco_Padrao, @Telefone_Padrao, @EntradaProduto, ";
                            sql += "@Decimal_Produto_Valor, @Decimal_Produto_Quantidade)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Exibe_DuplicarProduto", Parametro.Parametro_Cadastro.Exibe_DuplicarProduto);
                            cmd.Parameters.AddWithValue("@Somente_Maiusculo", Parametro.Parametro_Cadastro.Somente_Maiusculo);
                            cmd.Parameters.AddWithValue("@Cadastro_PessoaPadrao", Parametro.Parametro_Cadastro.Cadastro_PessoaPadrao);
                            cmd.Parameters.AddWithValue("@Endereco_Padrao", Parametro.Parametro_Cadastro.Endereco_Padrao);
                            cmd.Parameters.AddWithValue("@Telefone_Padrao", Parametro.Parametro_Cadastro.Telefone_Padrao);
                            cmd.Parameters.AddWithValue("@EntradaProduto", Parametro.Parametro_Cadastro.EntradaProduto);
                            cmd.Parameters.AddWithValue("@Decimal_Produto_Valor", Parametro.Parametro_Cadastro.Decimal_Produto_Valor);
                            cmd.Parameters.AddWithValue("@Decimal_Produto_Quantidade", Parametro.Parametro_Cadastro.Decimal_Produto_Quantidade);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            conexao.Begin_Conexao();

                            sql = "UPDATE Parametro_Sistema SET ";
                            sql += "Exibe_DuplicarProduto = @Exibe_DuplicarProduto, ";
                            sql += "Somente_Maiusculo = @Somente_Maiusculo, ";
                            sql += "Cadastro_PessoaPadrao = @Cadastro_PessoaPadrao, ";
                            sql += "Endereco_Padrao = @Endereco_Padrao, ";
                            sql += "Telefone_Padrao = @Telefone_Padrao, ";
                            sql += "EntradaProduto =  @EntradaProduto, ";
                            sql += "Decimal_Produto_Valor =  @Decimal_Produto_Valor, ";
                            sql += "Decimal_Produto_Quantidade =  @Decimal_Produto_Quantidade ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                            cmd.Parameters.AddWithValue("@Exibe_DuplicarProduto", Parametro.Parametro_Cadastro.Exibe_DuplicarProduto);
                            cmd.Parameters.AddWithValue("@Somente_Maiusculo", Parametro.Parametro_Cadastro.Somente_Maiusculo);
                            cmd.Parameters.AddWithValue("@Cadastro_PessoaPadrao", Parametro.Parametro_Cadastro.Cadastro_PessoaPadrao);
                            cmd.Parameters.AddWithValue("@Endereco_Padrao", Parametro.Parametro_Cadastro.Endereco_Padrao);
                            cmd.Parameters.AddWithValue("@Telefone_Padrao", Parametro.Parametro_Cadastro.Telefone_Padrao);
                            cmd.Parameters.AddWithValue("@EntradaProduto", Parametro.Parametro_Cadastro.EntradaProduto);
                            cmd.Parameters.AddWithValue("@Decimal_Produto_Valor", Parametro.Parametro_Cadastro.Decimal_Produto_Valor);
                            cmd.Parameters.AddWithValue("@Decimal_Produto_Quantidade", Parametro.Parametro_Cadastro.Decimal_Produto_Quantidade);

                            conexao.Executa_Comando(cmd);
                        }

                        /*cmd = new SqlCommand();
                        #region VALOR
                        sql = "ALTER TABLE Venda_Item ALTER COLUMN ValorVenda decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Valor + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Venda_Item ALTER COLUMN ValorProduto decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Valor + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Venda_Item ALTER COLUMN ValorCusto decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Valor + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN ValorUnitario decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Valor + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        #endregion

                        #region QUANTIDADE
                        sql = "ALTER TABLE Venda_Item ALTER COLUMN Quantidade decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Quantidade + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN Quantidade decimal(10, " + Parametro.Parametro_Cadastro.Decimal_Produto_Quantidade + ") ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        #endregion*/
                        break;
                        #endregion
                }
                conexao.Commit_Conexao();

                return Parametro.ID_Empresa;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Grava_Padrao()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_Empresa FROM Parametro_Sistema ";
                sql += "WHERE ID_Empresa = " + Parametro.ID_Empresa + " ";

                if (conexao.Consulta(sql).Rows.Count == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Parametro_Sistema ";
                    sql += "(ID_Empresa, Juros_Mes, Multa, ID_ContaTransValor, ID_ContaDevolucaoCheque, ID_ContaFaturaVenda, ID_ContaFaturaOS, ID_ContaFaturaCompra, DiasBloqueioVenda, ";
                    sql += "HistoricoVenda, AmbienteNFe, RegimeTributario, Exibe_msgCreditoICMS, AliquotaCreditoICMS, Caminho_NFe, Exibe_Desconto, ";
                    sql += "Exibe_InfoProduto, Certificado_NFe, Tipo_NFe_Venda, Imprime_OS_Equip, TipoImpressoraTermica, Consulta_Grade, Ultimo_Valor, Permitir2Vias, Agrupar_Produto, ";
                    sql += "Descricao_Comissao, Limite_Desconto, Produto_Marca, Bloquear_EstoqueNegativo, msg_EstoqueNegativo, Orca_ValorTotal, MultiploUsuarioPDV, Consulta_RapidaProduto, ";
                    sql += "CFe_A4, Monitor_CFe, ID_ContaDevolucaoVenda, NaoAlterarVendaFaturada, PagamentoTrocoDevolucao, ID_Caixa_Principal, ";
                    sql += "ClienteDescricao1, ClienteDescricao2, ClienteDescricao3, EmpresaDescricao1, EmpresaDescricao2, EmpresaDescricao3, ";
                    sql += "FornecedorDescricao1, FornecedorDescricao2, FornecedorDescricao3, FuncionarioDescricao1, FuncionarioDescricao2, FuncionarioDescricao3, ";
                    sql += "TransportadoraDescricao1, TransportadoraDescricao2, TransportadoraDescricao3, Info_Produto1, Info_Produto2, ID_Conta_PagtoDiverso, ID_Conta_RectoDiverso, ";
                    sql += "ID_Conta_CobrancaBancaria, ID_PagtoBoleto, De, Email, Venda_Matricial, Modelo_Matricial, Exibe_DuplicarProduto, ";
                    sql += "Desconto_Padrao, Exibe_NFeVenda, Exibe_Referencia, CFe_Cartao, Venda_ImpressaoDireta, CFe_PDV_Cartao, TipoSaida_Fixo, ";
                    sql += "Produto_PrecoVenda, Somente_Maiusculo, Qt_Dias_Pesquisa, Cadastro_PessoaPadrao, Altera_ValorPDV, Endereco_Padrao, Telefone_Padrao, EntradaProduto, ";
                    sql += "Decimal_Produto_Valor, Decimal_Produto_Quantidade)";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Juros_Mes, @Multa, @ID_ContaTransValor, @ID_ContaDevolucaoCheque, @ID_ContaFaturaVenda, @ID_ContaFaturaOS, @ID_ContaFaturaCompra, @DiasBloqueioVenda, ";
                    sql += "@HistoricoVenda, @AmbienteNFe, @RegimeTributario, @Exibe_msgCreditoICMS, @AliquotaCreditoICMS, @Caminho_NFe, @Exibe_Desconto, ";
                    sql += "@Exibe_InfoProduto, @Certificado_NFe, @Tipo_NFe_Venda, @Imprime_OS_Equip, @TipoImpressoraTermica, @Consulta_Grade, @Ultimo_Valor, @Permitir2Vias, @Agrupar_Produto, ";
                    sql += "@Descricao_Comissao, @Limite_Desconto, @Produto_Marca, @Bloquear_EstoqueNegativo, @msg_EstoqueNegativo, @Orca_ValorTotal, @MultiploUsuarioPDV, @Consulta_RapidaProduto, ";
                    sql += "@CFe_A4, @Monitor_CFe, @ID_ContaDevolucaoVenda, @NaoAlterarVendaFaturada, @PagamentoTrocoDevolucao, @ID_Caixa_Principal, ";
                    sql += "@ClienteDescricao1, @ClienteDescricao2, @ClienteDescricao3, @EmpresaDescricao1, @EmpresaDescricao2, @EmpresaDescricao3, ";
                    sql += "@FornecedorDescricao1, @FornecedorDescricao2, @FornecedorDescricao3, @FuncionarioDescricao1, @FuncionarioDescricao2, @FuncionarioDescricao3, ";
                    sql += "@TransportadoraDescricao1, @TransportadoraDescricao2, @TransportadoraDescricao3, @Info_Produto1, @Info_Produto2, @ID_Conta_PagtoDiverso, @ID_Conta_RectoDiverso, ";
                    sql += "@ID_Conta_CobrancaBancaria, @ID_PagtoBoleto, @De, @Email, @Venda_Matricial, @Modelo_MatriciaL, @Exibe_DuplicarProduto, ";
                    sql += "@Desconto_Padrao, @Exibe_NFeVenda, @Exibe_ReferenciaNFe, @CFe_Cartao, @Venda_ImpressaoDireta, @CFe_PDV_Cartao, @TipoSaida_Fixo, ";
                    sql += "@Produto_PrecoVenda, @Somente_Maiusculo, @Qt_Dias_Pesquisa, @Cadastro_PessoaPadrao, @Altera_ValorPDV, @Endereco_Padrao, @Telefone_Padrao, @EntradaProduto, ";
                    sql += "@Decimal_Produto_Valor, @Decimal_Produto_Quantidade)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Parametro.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Juros_Mes", 0);
                    cmd.Parameters.AddWithValue("@Multa", 0);
                    cmd.Parameters.AddWithValue("@ID_ContaTransValor", 0);
                    cmd.Parameters.AddWithValue("@ID_ContaDevolucaoCheque", 0);
                    cmd.Parameters.AddWithValue("@ID_ContaFaturaVenda", 0);
                    cmd.Parameters.AddWithValue("@ID_ContaFaturaCompra", 0);
                    cmd.Parameters.AddWithValue("@ID_ContaFaturaOS", 0);
                    cmd.Parameters.AddWithValue("@DiasBloqueioVenda", 0);
                    cmd.Parameters.AddWithValue("@HistoricoVenda", 0);
                    cmd.Parameters.AddWithValue("@AmbienteNFe", 2);
                    cmd.Parameters.AddWithValue("@RegimeTributario", 1);
                    cmd.Parameters.AddWithValue("@Exibe_msgCreditoICMS", false);
                    cmd.Parameters.AddWithValue("@AliquotaCreditoICMS", 0);
                    cmd.Parameters.AddWithValue("@Caminho_NFe", "");
                    cmd.Parameters.AddWithValue("@Exibe_Desconto", false);
                    cmd.Parameters.AddWithValue("@Exibe_InfoProduto", false);
                    cmd.Parameters.AddWithValue("@Certificado_NFe", "");
                    cmd.Parameters.AddWithValue("@Tipo_NFe_Venda", 0);
                    cmd.Parameters.AddWithValue("@Imprime_OS_Equip", false);
                    cmd.Parameters.AddWithValue("@TipoImpressoraTermica", 0);
                    cmd.Parameters.AddWithValue("@Consulta_Grade", 1);
                    cmd.Parameters.AddWithValue("@Ultimo_Valor", false);
                    cmd.Parameters.AddWithValue("@Permitir2Vias", false);
                    cmd.Parameters.AddWithValue("@Agrupar_Produto", false);
                    cmd.Parameters.AddWithValue("@Descricao_Comissao", "VENDEDOR");
                    cmd.Parameters.AddWithValue("@Limite_Desconto", 100);
                    cmd.Parameters.AddWithValue("@Produto_Marca", false);
                    cmd.Parameters.AddWithValue("@Bloquear_EstoqueNegativo", false);
                    cmd.Parameters.AddWithValue("@msg_EstoqueNegativo", false);
                    cmd.Parameters.AddWithValue("@Orca_ValorTotal", false);
                    cmd.Parameters.AddWithValue("@MultiploUsuarioPDV", false);
                    cmd.Parameters.AddWithValue("@Consulta_RapidaProduto", false);
                    cmd.Parameters.AddWithValue("@CFe_A4", false);
                    cmd.Parameters.AddWithValue("@Monitor_CFe", false);
                    cmd.Parameters.AddWithValue("@ID_ContaDevolucaoVenda", 0);
                    cmd.Parameters.AddWithValue("@NaoAlterarVendaFaturada", false);
                    cmd.Parameters.AddWithValue("@PagamentoTrocoDevolucao", 0);
                    cmd.Parameters.AddWithValue("@ClienteDescricao1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@ClienteDescricao2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@ClienteDescricao3", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@EmpresaDescricao1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@EmpresaDescricao2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@EmpresaDescricao3", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FornecedorDescricao1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FornecedorDescricao2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FornecedorDescricao3", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FuncionarioDescricao1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FuncionarioDescricao2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@FuncionarioDescricao3", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@TransportadoraDescricao1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@TransportadoraDescricao2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@TransportadoraDescricao3", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@Info_Produto1", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@Info_Produto2", "INFORMAÇÃO ADICIONAL");
                    cmd.Parameters.AddWithValue("@ID_Caixa_Principal", 0);
                    cmd.Parameters.AddWithValue("@ID_Conta_PagtoDiverso", 0);
                    cmd.Parameters.AddWithValue("@ID_Conta_RectoDiverso", 0);
                    cmd.Parameters.AddWithValue("@ID_Conta_CobrancaBancaria", 0);
                    cmd.Parameters.AddWithValue("@ID_PagtoBoleto", 0);
                    cmd.Parameters.AddWithValue("@De", "");
                    cmd.Parameters.AddWithValue("@Email", "");
                    cmd.Parameters.AddWithValue("@Venda_Matricial", false);
                    cmd.Parameters.AddWithValue("@Modelo_Matricial", 1);
                    cmd.Parameters.AddWithValue("@Exibe_DuplicarProduto", false);
                    cmd.Parameters.AddWithValue("@Desconto_Padrao", 1);
                    cmd.Parameters.AddWithValue("@Exibe_NFeVenda", false);
                    cmd.Parameters.AddWithValue("@Exibe_ReferenciaNFe", false);
                    cmd.Parameters.AddWithValue("@CFe_Cartao", false);
                    cmd.Parameters.AddWithValue("@Venda_ImpressaoDireta", false);
                    cmd.Parameters.AddWithValue("@CFe_PDV_Cartao", false);
                    cmd.Parameters.AddWithValue("@TipoSaida_Fixo", false);
                    cmd.Parameters.AddWithValue("@Produto_PrecoVenda", 1);
                    cmd.Parameters.AddWithValue("@Somente_Maiusculo", true);
                    cmd.Parameters.AddWithValue("@Qt_Dias_Pesquisa", 0);
                    cmd.Parameters.AddWithValue("@Cadastro_PessoaPadrao", 1);
                    cmd.Parameters.AddWithValue("@Altera_ValorPDV", false);
                    cmd.Parameters.AddWithValue("@Endereco_Padrao", 13);
                    cmd.Parameters.AddWithValue("@Telefone_Padrao", 16);
                    cmd.Parameters.AddWithValue("@EntradaProduto", 1);
                    cmd.Parameters.AddWithValue("@Decimal_Produto_Valor", 2);
                    cmd.Parameters.AddWithValue("@Decimal_Produto_Quantidade", 3);
                    conexao.Executa_Comando(cmd);
                }
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                switch (Parametro.Tipo)
                {
                    #region PARAMETRO FINANCEIRO
                    case 1:
                        sql = "SELECT ";
                        sql += "P.Juros_Mes, P.Multa, P.ID_ContaTransValor, P.ID_ContaDevolucaoCheque, ID_ContaFaturaVenda, ID_ContaFaturaOS, ID_ContaDevolucaoVenda, ";
                        sql += "ID_ContaFaturaCompra, ID_Caixa_Principal, ID_Conta_PagtoDiverso, ID_Conta_RectoDiverso, ID_Conta_CobrancaBancaria, ID_PagtoBoleto, ";
                        sql += "PC_ContaTrans.CodigoDescritivo AS ContaTransValor, ";
                        sql += "PC_ContaDevol.CodigoDescritivo AS ContaDevolucaoCheque, ";
                        sql += "PC_ContaFatVenda.CodigoDescritivo AS ContaFatVenda, ";
                        sql += "PC_ContaFatOS.CodigoDescritivo AS ContaFatOS, ";
                        sql += "PC_ContaFatCompra.CodigoDescritivo AS ContaFatCompra, ";
                        sql += "PC_ContaDevolucaoVenda.CodigoDescritivo AS ContaDevolucaoVenda, ";
                        sql += "PC_ContaPagtoDiverso.CodigoDescritivo AS Conta_PagtoDiverso, ";
                        sql += "PC_ContaRectoDiverso.CodigoDescritivo AS Conta_RectoDiverso, ";
                        sql += "PC_Conta_CobrancaBancaria.CodigoDescritivo AS Conta_CobrancaBancaria ";
                        sql += "FROM Parametro_Sistema AS P ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaTrans ON PC_ContaTrans.ID = P.ID_ContaTransValor ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaDevol ON PC_ContaDevol.ID = P.ID_ContaDevolucaoCheque ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaFatVenda ON PC_ContaFatVenda.ID = P.ID_ContaFaturaVenda ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaFatOS ON PC_ContaFatOS.ID = P.ID_ContaFaturaOS ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaFatCompra ON PC_ContaFatCompra.ID = P.ID_ContaFaturaCompra ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaDevolucaoVenda ON PC_ContaDevolucaoVenda.ID = P.ID_ContaDevolucaoVenda ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaPagtoDiverso ON PC_ContaPagtoDiverso.ID = P.ID_Conta_PagtoDiverso ";
                        sql += "LEFT JOIN PlanoConta AS PC_ContaRectoDiverso ON PC_ContaRectoDiverso.ID = P.ID_Conta_RectoDiverso ";
                        sql += "LEFT JOIN PlanoConta AS PC_Conta_CobrancaBancaria ON PC_Conta_CobrancaBancaria.ID = P.ID_Conta_CobrancaBancaria ";
                        sql += "WHERE ";
                        sql += "NOT P.ID_Empresa IS NULL ";
                        sql += "AND P.ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO VENDAS
                    case 2:
                        sql = "SELECT ";
                        sql += "DiasBloqueioVenda, ID_ConsumidorFinal, ID_TabelaVenda, Consulta_Grade, TipoImpressoraTermica, Ultimo_Valor, ";
                        sql += "Permitir2Vias, Agrupar_Produto, Descricao_Comissao, Limite_Desconto, Produto_Marca, Bloquear_EstoqueNegativo, ";
                        sql += "msg_EstoqueNegativo, Orca_ValorTotal, MultiploUsuarioPDV, Consulta_RapidaProduto, NaoAlterarVendaFaturada, PagamentoTrocoDevolucao, ";
                        sql += "Venda_Matricial, Modelo_Matricial, Desconto_Padrao, Exibe_NFeVenda, CFe_Cartao, Venda_ImpressaoDireta, CFe_PDV_Cartao, TipoSaida_Fixo, ";
                        sql += "Produto_PrecoVenda, Qt_Dias_Pesquisa, Altera_ValorPDV ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO MOBILE
                    case 3:
                        sql = "SELECT ";
                        sql += "HistoricoVenda ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO NF-e NFC-e
                    case 5:
                        sql = "SELECT ";
                        sql += "AmbienteNFe, RegimeTributario, Exibe_msgCreditoICMS, AliquotaCreditoICMS, Caminho_NFe, Exibe_Desconto, ";
                        sql += "Exibe_InfoProduto, Certificado_NFe, Tipo_NFe_Venda, Exibe_ReferenciaNFe ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO CF-e SAT
                    case 6:
                        sql = "SELECT ";
                        sql += "TipoEquipamentoSAT, SenhaAtivacaoSAT, AssinaturaSAT, CFe_A4, Monitor_CFe ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO ORDEM DE SERVIÇO
                    case 7:
                        sql = "SELECT ";
                        sql += "Descricao_Info1, Descricao_Info2, Descricao_Info3, Descricao_Obs1, Descricao_Obs2, Imprime_OS_Equip ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO CADASTROS PERSONALIZADOS
                    case 8:
                        sql = "SELECT ";
                        sql += "ClienteDescricao1, ClienteDescricao2, ClienteDescricao3, EmpresaDescricao1, EmpresaDescricao2, EmpresaDescricao3, ";
                        sql += "FornecedorDescricao1, FornecedorDescricao2, FornecedorDescricao3, FuncionarioDescricao1, FuncionarioDescricao2, FuncionarioDescricao3, ";
                        sql += "TransportadoraDescricao1, TransportadoraDescricao2, TransportadoraDescricao3, Info_Produto1, Info_Produto2 ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO CONFIGURAÇÃO DE EMAIL
                    case 9:
                        sql = "SELECT ";
                        sql += "De, Email ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                    #endregion

                    #region PARAMETRO CADASTRO
                    case 10:
                        sql = "SELECT ";
                        sql += "Exibe_DuplicarProduto, Somente_Maiusculo, Cadastro_PessoaPadrao, Endereco_Padrao, Telefone_Padrao, EntradaProduto, ";
                        sql += "Decimal_Produto_Valor, Decimal_Produto_Quantidade ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = " + Parametro.ID_Empresa + " ";
                        break;
                        #endregion
                }

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
    }
}
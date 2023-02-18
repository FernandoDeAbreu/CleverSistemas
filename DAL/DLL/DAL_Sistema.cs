using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_Sistema
    {
        //ULTIMA ALTERAÇÃO: 06/03/2017

        public int UltimaVersao = 256;

        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Sistema Sistema;
        #endregion

        #region CONSTRUTORES
        public DAL_Sistema(DTO_Sistema _Sistema)
        {
            this.Sistema = _Sistema;
        }

        public DAL_Sistema()
        {
        }
        #endregion

        #region VIEWS
        private void Atualiza_V_FichaProducao()
        {
            sql = "ALTER VIEW V_FichaProducao AS ";
            sql += "SELECT ";
            sql += "FP.ID, FP.ID_Empresa, FP.ID_Venda, FP.Situacao, FP.Entrada, FP.Saida, FP.Transportadora, FP.ID_Item_Venda, FP.AnoModelo, ";
            sql += "FP.CorCouro, FP.Costura, FP.Logomarca, FP.Laterais_Porta, FP.ApoioCabeca, FP.TipoAcento, FP.TipoEncosto, FP.ABD, FP.ABT, FP.Observacao, ";
            sql += "CASE FP.Situacao ";
            sql += "WHEN 1 THEN 'AGUARDANDO PAGAMENTO' ";
            sql += "WHEN 2 THEN 'EM PRODUÇÃO' ";
            sql += "WHEN 3 THEN 'CONCLUÍDO' ";
            sql += "END AS DescricaoSituacao, ";
            sql += "CASE FP.Logomarca ";
            sql += "WHEN 1 THEN 'SEM LOGO' ";
            sql += "WHEN 2 THEN 'BORDADA' ";
            sql += "WHEN 3 THEN 'CARIMBADA' ";
            sql += "END AS DescricaoLogomarca, ";
            sql += "V.ID_Pessoa, V.Descricao AS DescricaoPessoa, V.Data AS DataVenda, ";
            sql += "VI.DescricaoProduto, VI.InfoAdicional1, VI.DescricaoProduto + ' ' + VI.Informacao AS DescricaoProdutoInfo, ";
            sql += "U.Descricao AS DescricaoUsuarioComissao1 ";
            sql += "FROM FichaProducao AS FP ";
            sql += "INNER JOIN V_Venda AS V ON FP.ID_Venda = V.ID_Venda ";
            sql += "INNER JOIN V_Venda_Item AS VI ON FP.ID_Item_Venda = VI.IDItem ";
            sql += "LEFT JOIN Usuario AS U ON U.ID = V.ID_UsuarioComissao1 ";

            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }

        private void Atualiza_V_Venda()
        {
            sql = "ALTER VIEW V_Venda AS ";
            sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
            sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
            sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
            sql += "AS CustoTotal, PV.Cancelado, PV.ID_Usuario_Conferencia, PV.CPF_CNPJ, PV.ID_NFe, ";
            sql += "NF.ID_NFe AS ID_CFe, ";
            sql += "U.Descricao AS Usuario_Conferencia ";
            sql += "FROM Venda AS PV ";
            sql += "INNER JOIN Venda_Item AS PI ON PI.ID_Venda = PV.ID ";
            sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
            sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
            sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
            sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
            sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
            sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
            sql += "LEFT OUTER JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
            sql += "LEFT OUTER JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
            sql += "LEFT OUTER JOIN Usuario AS U ON PV.ID_Usuario_Conferencia = U.ID ";
            sql += "LEFT OUTER JOIN NotaFiscal AS NF ON PV.ID = NF.ID_Venda AND PV.ID_Empresa = NF.ID_Empresa AND NF.Situacao = 8 ";
            sql += "WHERE (NOT (PV.ID IS NULL)) ";
            sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
            sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
            sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia, PV.ID_Usuario_Conferencia, PV.CPF_CNPJ, ";
            sql += "U.Descricao, PV.ID_NFe, PV.ID_CFe, NF.ID_NFe ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }

        private void Atualiza_V_Ordem_Servico()
        {
            sql = "ALTER VIEW V_Ordem_Servico AS ";
            sql += "SELECT OS.ID AS ID_OS, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
            sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
            sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
            sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, ";
            sql += "(OS.Info_Equip_1 + ' / ' + OS.Info_Equip_2 + ' / ' + OS.Info_Equip_3) AS InformacaoCompleta, ";
            sql += "OS.Faturado, OS.NFe,  OS.Cancelado, OS.CPF_CNPJ, OS.ID_NFe, ";
            sql += "NF.ID_NFe AS ID_CFe, ";
            sql += "CASE OS.Status_OS ";
            sql += "WHEN 1 THEN 'ABERTA' ";
            sql += "WHEN 2 THEN 'EM ORÇAMENTO' ";
            sql += "WHEN 3 THEN 'APROVADO' ";
            sql += "WHEN 4 THEN 'MONTAGEM' ";
            sql += "WHEN 5 THEN 'PRONTO' ";
            sql += "WHEN 6 THEN 'FINALIZADO' ";
            sql += "END AS DescricaoStatus, ";
            sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
            sql += "SUM(OSI.Quantidade * OSI.ValorVenda) AS ValorTotal, SUM(OSI.Quantidade * OSI.ValorCusto) AS CustoTotal, ";
            sql += "GA.Descricao AS DescricaoAtendimento, ";
            sql += "GE.Descricao AS DescricaoEquipamento, ";
            sql += "GM.Descricao AS DescricaoMarca ";
            sql += "FROM Ordem_Servico AS OS ";
            sql += "LEFT OUTER JOIN Ordem_Servico_Item AS OSI ON OSI.ID_OS = OS.ID ";
            sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
            sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
            sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
            sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
            sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
            sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
            sql += "LEFT OUTER JOIN Grupo AS GA ON OS.TipoAtendimento = GA.ID ";
            sql += "LEFT OUTER JOIN Grupo AS GE ON OS.Tipo_Equipamento = GE.ID ";
            sql += "LEFT OUTER JOIN Grupo AS GM ON OS.Marca = GM.ID ";
            sql += "LEFT OUTER JOIN NotaFiscal AS NF ON OS.ID = NF.ID_OS AND OS.ID_Empresa = NF.ID_Empresa AND NF.Situacao = 8 ";
            sql += "WHERE (NOT (OS.ID IS NULL)) ";
            sql += "GROUP BY OS.ID, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
            sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
            sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
            sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, OS.CPF_CNPJ, OS.ID_NFe, OS.ID_CFe, ";
            sql += "OS.Faturado, OS.NFe,  OS.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao, GA.Descricao, GE.Descricao, GM.Descricao, ";
            sql += "NF.ID_NFe ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }

        private void Atualiza_V_Produto_Venda()
        {
            sql = "ALTER VIEW V_Produto_Venda AS ";
            sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
            sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Imagem, ";
            sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, ";
            sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, P.InfoAdicional1, P.InfoAdicional2, ";
            sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, ";
            sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
            sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
            sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
            sql += "UN.Descricao AS Unidade, ";
            sql += "CASE G.Descricao ";
            sql += "WHEN 'ÚNICO' THEN P.Descricao ";
            sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
            sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
            sql += "FROM Produto_Servico AS P ";
            sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
            sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
            sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
            sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
            sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
            sql += "LEFT JOIN Grupo AS UN ON UN.ID = P.UnidadeTributavel ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }

        private void Atualiza_V_Produto_Movimento()
        {
            sql = "ALTER VIEW V_Produto_Movimento AS ";
            sql += "SELECT C.ID_Empresa, C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, CP.ID_Produto, ";
            sql += "CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, P.Descricao, P.Referencia, P.Barra, ";
            sql += "PS.Nome_Razao AS Pessoa ";
            sql += "FROM Produto_Entrada AS C ";
            sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
            sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
            sql += "WHERE C.Tipo_Entrada = 1 ";
            sql += "UNION ";
            sql += "SELECT C.ID_Empresa, C.Data, 'ENTRADA PRODUÇÃO: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, CP.ID_Produto, ";
            sql += "CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, P.Descricao, P.Referencia, P.Barra, ";
            sql += "PS.Nome_Razao AS Pessoa ";
            sql += "FROM Produto_Entrada AS C ";
            sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
            sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
            sql += "WHERE C.Tipo_Entrada = 2 ";
            sql += "UNION ";
            sql += "SELECT V.ID_Empresa, V.Data, 'ÚLTIMA VENDA: Nº ' + CAST(V.ID AS VARCHAR(20)) AS UltimoLancamento, PP.ID_Produto, ";
            sql += "NULL AS Compra, ISNULL(PP.Quantidade_Entregue, PP.Quantidade) AS Venda, ";
            sql += "CASE ";
            sql += "WHEN PP.Quantidade_Entregue IS NULL ";
            sql += "THEN 'SAÍDA (PREVISTO)' ";
            sql += "WHEN PP.Quantidade_Entregue IS NOT NULL ";
            sql += "THEN 'SAÍDA' ";
            sql += "END AS Tipo, P.Descricao, P.Referencia, P.Barra, PS.Nome_Razao AS Pessoa ";
            sql += "FROM Venda AS V ";
            sql += "INNER JOIN Venda_Item AS PP ON V.ID = PP.ID_Venda ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
            sql += "INNER JOIN Pessoa AS PS ON V.TipoPessoa = PS.TipoPessoa AND V.ID_Pessoa = PS.ID_Pessoa ";
            sql += "UNION ";
            sql += "SELECT OS.ID_Empresa, OS.Data_Entrega AS Data, 'ÚLTIMA OS: Nº ' + CAST(OS.ID AS VARCHAR(20)) AS UltimoLancamento, ";
            sql += "PP.ID_Produto, NULL AS Compra, ISNULL(PP.Quantidade_Entregue, PP.Quantidade) AS Venda, ";
            sql += "CASE ";
            sql += "WHEN PP.Quantidade_Entregue IS NULL ";
            sql += "THEN 'SAÍDA (PREVISTO)'  ";
            sql += "WHEN PP.Quantidade_Entregue IS NOT NULL ";
            sql += "THEN 'SAÍDA'  ";
            sql += "END AS Tipo, P.Descricao, P.Referencia, P.Barra, PS.Nome_Razao AS Pessoa ";
            sql += "FROM Ordem_Servico AS OS ";
            sql += "INNER JOIN Ordem_Servico_Item AS PP ON OS.ID = PP.ID_OS ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
            sql += "INNER JOIN Pessoa AS PS ON OS.TipoPessoa = PS.TipoPessoa AND OS.ID_Pessoa = PS.ID_Pessoa ";
            sql += "WHERE OS.Status_OS = 6 ";
            sql += "UNION ";
            sql += "SELECT PM.ID_Empresa, PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, PM.Quantidade AS Compra, ";
            sql += "NULL AS Venda, 'ENTRADA' AS Tipo, P.Descricao, P.Referencia, P.Barra, NULL AS Pessoa ";
            sql += "FROM Produto_Movimento AS PM ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
            sql += "WHERE PM.Tipo = 1 ";
            sql += "UNION ";
            sql += "SELECT PM.ID_Empresa, PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, NULL AS Compra, PM.Quantidade AS Venda, ";
            sql += "'SÁIDA' AS Tipo, P.Descricao, P.Referencia, P.Barra, NULL AS Pessoa ";
            sql += "FROM Produto_Movimento AS PM ";
            sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
            sql += "WHERE PM.Tipo = 2 ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }

        private void Atualiza_VM_Usuario()
        {
            sql = "ALTER VIEW VM_Usuario AS ";
            sql += "SELECT ID AS ID_Usuario, Descricao, SenhaMobile AS Senha ";
            sql += "FROM Usuario ";
            sql += "WHERE ";
            sql += "NOT ID IS NULL ";
            sql += "AND Situacao = 'true' ";
            sql += "AND UsuarioMobile = 'true'";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
        }
        #endregion

        private void Atualiza(int intVersao)
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            DataTable _DT;

            #region EXEMPLOS
            /*
            sql = "CREATE TABLE Produto_Desconto(";
            sql += "ID int IDENTITY PRIMARY KEY, ";
            sql += "ID_Produto int,	";
            sql += "QtdMinima int, ";
            sql += "QtdMaxima int, ";
            sql += "Desconto decimal(9, 2), ";                        
            sql += "ID_Folha int FOREIGN KEY REFERENCES FolhaPagamento(ID), ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
                        
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);

            ALTER TABLE empregados ADD sexo varchar(10)
            
            IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Produto_Imagem') DROP TABLE Produto_Imagem";

            ALTER TABLE empregados ADD cpf varchar(20),rg varchar(15)

            ALTER TABLE empregados ALTER COLUMN sexo varchar(30)

            ALTER TABLE empregados DROP COLUMN cpf,rg
             
            EXEC sp_rename 'ProdutoComissao', 'Produto_Comissao'
            
            EXEC sp_rename 'Produto_Valor.ID_ProdutoTabelaValor', 'ID', 'COLUMN';
             
            CREATE INDEX I_ID_PrevisaoPagto ON CReceber (ID_PrevisaoPagto);
             */
            #endregion

            #region CRIAÇÃO DE VIEW
            #region Produto
            /*
                        sql = "CREATE VIEW Produto AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.ValorIPI, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Cheque_Historico
            /*
            
                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.ID AS ID_CPagar, 0 AS ID_CReceber, CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN Grupo AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT 0 AS ID_CPagar, CR.ID AS ID_CReceber, CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN Grupo AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_CPagar
            /*
                sql = "ALTER VIEW V_CPagar AS ";
                        sql += "SELECT C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, ";
                        sql += "C.TipoPessoa, C.ID_Pessoa, C.Valor, C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, C.Acrescimo, C.Controle, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "PC.CodigoDescritivo1 AS Conta1, PC.Descricao1 AS DescricaoConta1,  ";
                        sql += "PC.CodigoDescritivo2 AS Conta2, PC.Descricao2 AS DescricaoConta2,  ";
                        sql += "PC.CodigoDescritivo3 AS Conta3, PC.Descricao3 AS DescricaoConta3,  ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa ";
                        sql += "FROM CPagar AS C ";
                        sql += "LEFT JOIN V_PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_CReceber
            /*
                           sql = "ALTER VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Venda, C.ID_OS, C.ID_PrevisaoPagto, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta,  ";
                        sql += "PC.CodigoDescritivo1 AS Conta1, PC.Descricao1 AS DescricaoConta1,  ";
                        sql += "PC.CodigoDescritivo2 AS Conta2, PC.Descricao2 AS DescricaoConta2,  ";
                        sql += "PC.CodigoDescritivo3 AS Conta3, PC.Descricao3 AS DescricaoConta3,  ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto, ";
                        sql += "TP.Descricao AS PrevisaoPagto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN V_PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "LEFT JOIN Pagamento AS TP ON TP.ID = C.ID_PrevisaoPagto ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Financeiro_Mobile
            /*
            sql = "CREATE VIEW V_Financeiro_Mobile AS ";
                        sql += "SELECT C.ID, PC.ID_Usuario, C.Emissao, C.Vencimento, C.ID_Pessoa, C.Valor, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + ";
                        sql += "'(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, C.Descricao ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT OUTER JOIN PessoaCliente AS PC ON C.ID_Pessoa = PC.ID ";
                        sql += "WHERE ";
                        sql += "C.Situacao = 1 ";
                        sql += "AND C.TipoPessoa = 1 ";
                        sql += "AND (C.Vencimento <= GETDATE()) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_HistoricoVenda
            /*
            sql = "CREATE VIEW V_HistoricoVenda AS ";
            sql += "SELECT DISTINCT ";
            sql += "V.ID_Pedido AS ID, V.ID_Pessoa, CONVERT(VARCHAR(10), V.Data, 103) AS Data, ";
            sql += "VI.ID_Tabela, V.ID_Parcelamento, V.Informacao, 0 AS Desconto, V.Comprador, V.ID_UsuarioComissao1 AS ID_Usuario ";
            sql += "FROM V_Pedido AS V ";
            sql += "INNER JOIN V_Pedido_Item AS VI ON V.ID_Pedido = VI.ID_Pedido ";
            sql += "WHERE (V.Data >= DATEADD(d, -1, GETDATE())) ";
            sql += "GROUP BY V.ID_Pedido, V.ID_Pessoa, V.Data, VI.ID_Tabela, VI.ID_Tabela, V.ID_Parcelamento, ";
            sql += "V.Informacao, VI.Desconto, V.Comprador, V.ID_UsuarioComissao1 ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_HistoricoVenda_Item
            /*
            sql = "CREATE VIEW V_HistoricoVenda_Item AS ";
            sql += "SELECT VI.ID_Pedido AS ID_Venda, VI.ID_Produto, VI.Quantidade, VI.Informacao, VI.TipoSaida, V.ID_UsuarioComissao1 AS ID_Usuario ";
            sql += "FROM V_Pedido_Item AS VI ";
            sql += "INNER JOIN V_Pedido AS V ON V.ID_Pedido = VI.ID_Pedido ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Orcamento
            /*
               sql = "ALTER VIEW V_Orcamento AS ";
                        sql += "SELECT O.ID AS ID_Orcamento, O.ID_Empresa, O.TipoPessoa, O.ID_Pessoa, O.Data, O.Informacao, ";
                        sql += "O.ID_UsuarioComissao1, O.ID_UsuarioComissao2, O.ID_UsuarioComissao3, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "SUM(OI.Quantidade * OI.ValorVenda) AS ValorTotal, SUM(OI.Quantidade * OI.ValorCusto) AS CustoTotal ";
                        sql += "FROM Orcamento AS O ";
                        sql += "INNER JOIN Orcamento_Item AS OI ON OI.ID_Orcamento = O.ID ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = O.TipoPessoa AND P.ID_Pessoa = O.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE NOT O.ID IS NULL ";
                        sql += "GROUP BY O.ID, O.ID_Empresa, O.TipoPessoa, O.ID_Pessoa, O.Data, O.Informacao, ";
                        sql += "O.ID_UsuarioComissao1, O.ID_UsuarioComissao2, O.ID_UsuarioComissao3, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, M.Descricao, UF.ID_UF, UF.Sigla ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Orcamento_Item
            /*
             sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, P.Fabricante AS Marca, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Grupo AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Ordem_Servico_Item
            /*
              sql = "CREATE VIEW V_Ordem_Servico_Item AS ";
                        sql += "SELECT OS.ID AS IDItem, OS.ID_OS, OS.ID_Produto, OS.Quantidade, OS.ID_Tabela, ";
                        sql += "OS.ValorProduto, OS.ValorVenda, OS.ValorCusto, (OS.ValorVenda * OS.Quantidade) AS ValorTotal, OS.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "OS.TipoSaida, OS.ID_Grade, OS.Quantidade_Entregue, ";
                        sql += "CASE OS.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Ordem_Servico_Item AS OS ";
                        sql += "INNER JOIN Grade AS G ON G.ID = OS.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = OS.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Ordem_Servico_Item_Imposto
            /*
                  sql = "ALTER VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND VP.ID_UF = IUF.ID_UF ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Ordem_Servico_Item_Imposto_CF
            /*
                  sql = "ALTER VIEW V_Ordem_Servico_Item_Imposto_CF AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND IUF.ID_UF = 35 ";
            cmd.CommandText = sql;
            conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Ordem_Servico_ResumoPagto
            /*
            sql = " CREATE VIEW V_Ordem_Servico_ResumoPagto AS ";
            sql += "SELECT P.Descricao, OS.ID_OS, CR.Vencimento AS Data, "; 
            sql += "CR.Valor AS Credito, ";
            sql += "CASE CR.Situacao ";
            sql += "WHEN 1 THEN 0 ";
            sql += "WHEN 2 THEN CR.Total ";
            sql += "END AS ValorPago ";
            sql += "FROM V_Ordem_Servico AS OS ";
            sql += "INNER JOIN V_CReceber AS CR ON CR.ID_OS = OS.ID_OS ";
            sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
             */
            #endregion


            //REMOVER DEPOIS
            #region V_PessoaMobile
            /*
                sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, PC.ID_Usuario AS ID_Vendedor, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 1 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 1 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 1 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN Grupo AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE P.Situacao = 'True' ";
                         cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Planejamento
            /*
                sql = "CREATE VIEW V_Planejamento AS ";
                        sql += "SELECT CP.ID_Empresa, CP.Conta, CP.DescricaoConta, CP.DescricaoPessoa, CP.Documento, CP.ResumoParcela, ";
                        sql += "CP.Vencimento, CP.Total AS Debito, 0.0 AS Credito, 0.0 AS Saldo, 'CP' AS Tipo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "WHERE CP.Situacao = 1 ";
                        sql += "UNION ";
                        sql += "SELECT CR.ID_Empresa, CR.Conta, CR.DescricaoConta, CR.DescricaoPessoa, CR.Documento, CR.ResumoParcela, ";
                        sql += "CR.Vencimento, 0.0 AS Debito, CR.Total AS Credito, 0.0 AS Saldo, 'CR' AS Tipo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "WHERE CR.Situacao = 1 ";
                        sql += "UNION ";
                        sql += "SELECT FC.ID_Empresa, '' AS Conta, 'CHEQUE PRÉ' AS DescricaoConta, Informacao AS DescricaoPessoa, FC.Documento, '' AS ResumoParcela,  ";
                        sql += "FC.Emissao AS Vencimento, FC.Debito, FC.Credito, 0.0 AS Saldo, 'FC' AS Tipo ";
                        sql += "FROM FluxoCaixa AS FC ";
                        sql += "WHERE FC.Planejamento = 'True' AND FC.ID_Cheque > 0 ";
                        sql += "UNION ";
                        sql += "SELECT C.ID_Empresa, '' AS Conta, 'RECEBIMENTO CARTÃO CRÉDITO/DÉBITO' AS DescricaoConta, P.Descricao AS DescricaoPessoa,   '' AS Documento,  ";
                        sql += "CONVERT(varchar(10), C.Parcela) +'/' + CONVERT(varchar(10), C.QuantidadeParcela) AS ResumoParcela, ";
                        sql += "C.Vencimento, 0.0 AS Debito, C.Valor AS Credito, 0.0 AS Saldo, 'CC' AS Tipo ";
                        sql += "FROM Cartao AS C ";
                        sql += "INNER JOIN Pagamento AS P ON C.ID_Pagamento = P.ID ";
                        sql += "WHERE C.Baixado = 'False' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_PlanoConta
            /*
               sql = "ALTER VIEW V_PlanoConta AS ";
                        sql += "SELECT PC.ID, PC.Nivel, PC.CodigoPai, PC.Codigo, PC.CodigoDescritivo, PC.Descricao,";
                        sql += "PC1.Nivel AS Nivel1, PC1.CodigoPai AS CodigoPai1, PC1.Codigo AS Codigo1, PC1.CodigoDescritivo AS CodigoDescritivo1, PC1.Descricao AS Descricao1,";
                        sql += "PC2.Nivel AS Nivel2, PC2.CodigoPai AS CodigoPai2, PC2.Codigo AS Codigo2, PC2.CodigoDescritivo AS CodigoDescritivo2, PC2.Descricao AS Descricao2, ";
                        sql += "PC3.Nivel AS Nivel3, PC3.CodigoPai AS CodigoPai3, PC3.Codigo AS Codigo3, PC3.CodigoDescritivo AS CodigoDescritivo3, PC3.Descricao AS Descricao3";
                        sql += "FROM PlanoConta AS PC";
                        sql += "LEFT JOIN PlanoConta AS PC1 ON PC1.Nivel = 1 AND LEFT(PC.CodigoPai, 2) = PC1.Codigo";
                        sql += "LEFT JOIN PlanoConta AS PC2 ON PC2.Nivel = 2 AND LEFT(PC.CodigoPai, 4) = (PC2.CodigoPai + PC2.Codigo)";
                        sql += "LEFT JOIN PlanoConta AS PC3 ON PC3.Nivel = 3 AND LEFT(PC.CodigoPai, 6) = (PC3.CodigoPai + PC3.Codigo)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Produto_Entrada
            /*
                sql = "CREATE VIEW V_Produto_Entrada AS ";
                        sql += "SELECT PE.ID AS ID_Entrada, PE.ID_Empresa, PE.TipoPessoa, PE.ID_Pessoa, PE.Tipo_Entrada, ";
                        sql += "CASE PE.Tipo_Entrada ";
                        sql += "WHEN 1 THEN 'COMPRA DE PRODUTO' ";
                        sql += "WHEN 2 THEN 'ENTRADA PRODUÇÃO' ";
                        sql += "END AS Descricao_Tipo_Entrada, ";
                        sql += "PE.Data, PE.Entrega, PE.Informacao, PE.Faturado, PE.Documento, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, ";
                        sql += "UF.ID_UF, SUM(PI.Quantidade * (PI.ValorCompra + PI.ValorIPI + PI.ValorST)) AS CustoTotal ";
                        sql += "FROM Produto_Entrada AS PE ";
                        sql += "INNER JOIN Produto_Entrada_Item AS PI ON PI.ID_Produto_Entrada = PE.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PE.TipoPessoa AND P.ID_Pessoa = PE.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "GROUP BY PE.ID, PE.ID_Empresa, PE.TipoPessoa, PE.ID_Pessoa,PE.Tipo_Entrada, PE.Data, PE.Entrega, PE.Informacao, ";
                        sql += "PE.Faturado, PE.Documento, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Produto_Imposto
            /*
                 sql = "ALTER VIEW V_Produto_Imposto AS  ";
                        sql += "SELECT P.ID AS ID_Produto, P.Tipo, P.ID_Grupo, P.Descricao, P.Referencia, ";
                        sql += "P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, ";
                        sql += "P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.ValorST, P.UnidadeTributavel, P.Validade, ";
                        sql += "P.Garantia, P.Situacao, P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, ";
                        sql += "P.ID_CEST, ";
                        sql += "PP.ID AS ID_Imposto_Produto, PP.ID_Empresa, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, ";
                        sql += "I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, ";
                        sql += "I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, IUF.ID_UF ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion



            #region V_Produto_Servico
            /*
               sql = "ALTER VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.Controle_Estoque, P.Imagem, ";
                        sql += "P.InfoAdicional1, P.InfoAdicional2, P.ABC, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_ResumoLocacao
            /*
                 sql = "CREATE VIEW V_ResumoLocacao AS ";
                        sql += "SELECT L.ID, L.ID_Imovel, L.Data, L.Inicio, L.Termino, L.DiaVencimento, L.Valor, L.Descricao_Test1, ";
                        sql += "L.Descricao_Test2, L.Doc_Test1, L.Doc_Test2, L.Observacao, I.Descricao, I.ID_Tipo, I.Tipo_Imovel, ";
                        sql += "I.Area, I.Valor AS ValorImovel, I.Comissao_Porc, I.Logradouro, I.Numero, I.Complemento, I.Bairro, I.CEP, ";
                        sql += "I.ID_Municipio, I.RGI, I.UC, I.Comissao_Valor, LL.ID_Locacao, LL.ID_Locatario, P.MultiEmpresa, P.ID_Empresa, ";
                        sql += "P.TipoPessoa, P.ID_Pessoa, P.TipoDocumento, P.CNPJ_CPF, P.Nome_Razao, P.NomeFantasia, P.Contato, P.IE_RG, ";
                        sql += "P.IM, P.CNAE, P.Cadastro, P.Informacao, P.ID_Grupo, P.Nascimento_Fundacao, P.Ramo_Profissao, P.Descricao1, ";
                        sql += "P.Descricao2, P.Descricao3, P.Limite, P.DiaFaturamento, P.Situacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.Profissao_Conjuge, ";
                        sql += "P.RG_Conjuge ";
                        sql += "FROM Locacao AS L ";
                        sql += "INNER JOIN Imovel AS I ON I.ID = L.ID_Imovel ";
                        sql += "INNER JOIN Locacao_Locatario AS LL ON LL.ID_Locacao = L.ID ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 8 AND P.ID_Pessoa = LL.ID_Locatario ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_UsuarioMobile
            /*
                 sql = "CREATE VIEW V_UsuarioMobile AS ";
                        sql += "SELECT ";
                        sql += "ID, Descricao, SenhaMobile AS Senha ";
                        sql += "FROM Usuario ";
                        sql += "WHERE ";
                        sql += "NOT ID IS NULL ";
                        sql += "AND UsuarioMobile = 'true' ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Venda_Item
            /*
                        sql = "CREATE VIEW V_Venda_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Venda, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "PV.Quantidade_Entregue, PV.Quantidade_Conferido, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, P.Barra, InfoAdicional1, InfoAdicional2, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Venda_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Venda_Item_Imposto
            /*
                        sql = "ALTER VIEW V_Venda_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.ProdutoEspecifico, P.Cod_ANP, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVi.ID_Venda = VP.ID_Venda AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Venda_Item_Imposto_CF
            /*
                        sql = "ALTER VIEW V_Venda_Item_Imposto_CF AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVI.ID_Venda = VP.ID_Venda AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion

            #region V_Venda_Mobile
            /*
                  sql = "CREATE VIEW V_Venda_Mobile AS ";
                        sql += "SELECT ";
                        sql += "VM.ID, VM.ID_Venda, VM.ID_Pessoa, VM.Data, VM.ID_Tabela, VM.Informacao, VM.Desconto, VM.Comprador, ";
                        sql += "P.Nome_Razao AS Descricao, ";
                        sql += "PC.ID_Usuario, ";
                        sql += "U.Descricao AS Usuario, ";
                        sql += "PGP.Descricao AS Pagamento, ";
                        sql += "PG.ID_Pagamento, PG.Parcelamento, PG.ID AS ID_Parcelamento, ";
                        sql += "M.Equipamento, M.IMEI ";
                        sql += "FROM Venda_Mobile AS VM ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = 1 AND P.ID_Pessoa = VM.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID ";
                        sql += "LEFT JOIN Usuario AS U ON PC.ID_Usuario = U.ID ";
                        sql += "LEFT JOIN Mobile AS M ON M.IMEI = VM.IMEI ";
                        sql += "LEFT JOIN Pagamento_Parc AS PG ON VM.ID_Parcelamento = PG.ID ";
                        sql += "LEFT JOIN Pagamento AS PGP ON PG.ID_Pagamento = PGP.ID ";
                        sql += "WHERE ";
                        sql += "NOT VM.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
            */
            #endregion

            #region V_Venda_PessoaInativo
            /*
                        sql = "CREATE VIEW V_Venda_PessoaInativo AS ";
                        sql += "SELECT P.TipoPessoa, P.ID_Pessoa, P.Nome_Razao, P.NomeFantasia, P.Contato, P.Informacao, P.Situacao, ";
                        sql += "PE.ID as ID_Venda, PE.Data, PE.DataFatura, PE.Faturado, PE.Cancelado, PE.NFe, ";
                        sql += "CONVERT(VARCHAR, DATEDIFF(DAY, PE.Data, GETDATE())) as TempoCompra, ";
                        sql += "PC.ID_Usuario AS ID_UsuarioComissao1 ";
                        sql += "FROM Pessoa AS P ";
                        sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN Venda AS PE ON P.ID_Pessoa = PE.ID_Pessoa AND P.TipoPessoa = PE.TipoPessoa ";
                        sql += "INNER JOIN (SELECT PP.ID_Pessoa, MAX(PP.ID) AS ID_P FROM Venda AS PP GROUP BY PP.ID_Pessoa) AS Tab_Venda ON Tab_Venda.ID_P = PE.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

             */
            #endregion

            #region V_Venda_ResumoPagto
            /*
                        sql = "CREATE VIEW V_Venda_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Venda, CR.Vencimento AS Data, CR.Total AS Credito, ";
                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN CR.Total ";
                        sql += "END AS ValorPago ";
                        sql += "FROM V_Venda AS PV ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_Venda = PV.ID_Venda ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
             */
            #endregion
            #endregion

            try
            {
                conexao.Abre_Conexao();

                switch (intVersao)
                {
                    #region ATUALIZAÇÃO ANTIGAS
                    #region 1 - Altera Tabela(Versao) - Adiciona Campo(Chave)
                    case 1:
                        sql = "ALTER TABLE ";
                        sql += "Versao ";
                        sql += "ADD ";
                        sql += "Chave nvarchar(200)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 2 - Cria Tabela(Eventos, FolhaPagamento, Folha_Eventos)
                    case 2:
                        sql = "CREATE TABLE Eventos ( ";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "Descricao nvarchar(60), ";
                        sql += "Referencia nvarchar(200), ";
                        sql += "Vencimento bit, ";
                        sql += "Desconto bit) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE FolhaPagamento ( ";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Pessoa int, ";
                        sql += "ID_Empresa int, ";
                        sql += "Periodo datetime, ";
                        sql += "Vencimento datetime) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Folha_Eventos ( ";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Folha int FOREIGN KEY REFERENCES FolhaPagamento(ID),  ";
                        sql += "ID_Eventos int FOREIGN KEY REFERENCES Eventos(ID), ";
                        sql += "Valor money) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 3 - Altera Tabela(FolhaPagamento) - Adiciona Campo(Tipo)
                    case 3:
                        sql = "ALTER TABLE ";
                        sql += "FolhaPagamento ";
                        sql += "ADD ";
                        sql += "Tipo int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE FolhaPagamento ";
                        sql += "SET ";
                        sql += "Tipo = 0";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 4 - Altera Tabela(ControleCheque) - Remove Campo(Conciliado)
                    case 4:
                        sql = "ALTER TABLE ";
                        sql += "ControleCheque ";
                        sql += "DROP COLUMN ";
                        sql += "Conciliado";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 5 - Altera Tabela(CReceber) - Remove Campo(ID_UsuarioLancamento, ID_UsuarioBaixa)
                    case 5:
                        sql = "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "DROP COLUMN ";
                        sql += "ID_UsuarioLancamento, ID_UsuarioBaixa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 6 - Altera Tabela(CPagar) - Remove Campo(ID_UsuarioLancamento, ID_UsuarioBaixa)
                    case 6:
                        sql = "ALTER TABLE ";
                        sql += "CPagar ";
                        sql += "DROP COLUMN ";
                        sql += "ID_UsuarioLancamento, ID_UsuarioBaixa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 7 - Remove Tabela(FichaVenda, ControleVisita, Evento, OrdemPax, OrdemRota, Recado)
                    case 7:
                        sql = "DROP TABLE FichaVenda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ControleVisita ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE Evento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE OrdemPax ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE OrdemRota ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE Recado ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 8 - Altera Tabela(Servico, Servico_Valor)
                    case 8:
                        sql = "EXEC sp_rename 'ServicoTabelaValor', 'Servico_Valor' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico.Custo', 'CustoValor', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico.CustoAdicional', 'CustoTerceiro', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ADD ";
                        sql += "CustoFinal money, ";
                        sql += "ID_GrupoNivel int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Servico ";
                        sql += "SET CustoFinal = CustoValor + CustoTerceiro ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico_Valor.ID_TabelaValor', 'ID_Tabela', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico_Valor.Acrescimo', 'MargemVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico_Valor.Valor', 'ValorVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Servico_Valor.Reajuste', 'UltimoReajuste', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ADD ";
                        sql += "MargemPromocional money, ";
                        sql += "MargemMinima money, ";
                        sql += "ValorPromocional money, ";
                        sql += "UtilizarValorPromocao bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Servico_Valor ";
                        sql += "SET MargemPromocional = MargemVenda, ";
                        sql += "MargemMinima = MargemVenda, ";
                        sql += "ValorPromocional = ValorVenda, ";
                        sql += "UtilizarValorPromocao = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 9 - Altera Tabela(Produto, Produto_Valor, Produto_Imposto, Produto_Fornecedor, Produto_Imagem, Produto_Comissao, Produto_Estoque)
                    case 9:
                        sql = "EXEC sp_rename 'ProdutoComissao', 'Produto_Comissao' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ProdutoEstoque', 'Produto_Estoque' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ProdutoImagem', 'Produto_Imagem' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ProdutoFornecedor', 'Produto_Fornecedor' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ProdutoTabelaValor', 'Produto_Valor' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ProdutoImposto', 'Produto_Imposto' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ProdutoFiscal ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Valor.ID_ProdutoTabelaValor', 'ID', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Fornecedor.ID_ProdutoFornecedor', 'ID', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto.Custo', 'ValorCompra', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto.CustoAdicional', 'OutrosCustos', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ADD ";
                        sql += "Frete money, ";
                        sql += "ICMS money, ";
                        sql += "PIS money, ";
                        sql += "Cofins money, ";
                        sql += "CustoFinal money, ";
                        sql += "ID_GrupoNivel int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto ";
                        sql += "SET CustoFinal = ValorCompra + OutrosCustos, Frete = 0, ICMS = 0, PIS = 0, Cofins = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Valor.Valor', 'ValorVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Valor.Acrescimo', 'MargemVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Valor.Reajuste', 'UltimoReajuste', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Valor.ID_TabelaValor', 'ID_Tabela', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ADD ";
                        sql += "MargemPromocional money, ";
                        sql += "MargemMinima money, ";
                        sql += "ValorPromocional money, ";
                        sql += "Custo money, ";
                        sql += "UtilizarValorPromocao bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Valor  ";
                        sql += "SET ValorPromocional = ValorVenda, ";
                        sql += "UtilizarValorPromocao = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Valor ";
                        sql += "SET Custo = (SELECT Produto.CustoFinal FROM Produto WHERE Produto.ID = Produto_Valor.ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Valor ";
                        sql += "SET MargemVenda = (((ValorVenda - Custo) / ValorVenda) * 100) ";
                        sql += "WHERE     (ValorVenda > 0) AND (Custo > 0)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Valor ";
                        sql += "SET MargemPromocional = (((ValorVenda - Custo) / ValorVenda) * 100) ";
                        sql += "WHERE     (ValorVenda > 0) AND (Custo > 0)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Valor ";
                        sql += "SET MargemMinima = (((ValorPromocional - Custo) / ValorPromocional) * 100) ";
                        sql += "WHERE     (ValorPromocional > 0) AND (Custo > 0)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "DROP COLUMN ";
                        sql += "Custo ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 10 - Altera Tabela(Pedido, Pedido_Item) Exclui Tabela(UsuarioBonificacao)
                    case 10:
                        sql = "EXEC sp_rename 'PedidoVenda', 'Pedido' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'PedidoVendaItem', 'Pedido_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE UsuarioBonificacao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.ID_PedidoVenda', 'ID_Pedido', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.ValorUnitario', 'Valor', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ADD ";
                        sql += "CustoFinal money ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pedido_Item ";
                        sql += "SET CustoFinal = (SELECT Produto.CustoFinal FROM Produto WHERE Produto.ID = Pedido_Item.ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 11 - Altera Tabela(GrupoSimples)
                    case 11:
                        sql = "ALTER TABLE ";
                        sql += "GrupoSimples ";
                        sql += "ADD ";
                        sql += "Exibir bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE GrupoSimples ";
                        sql += "SET Exibir = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 12 - Altera Tabela(Mudança de Campos Money para Decimal (10, 3)
                    case 12:
                        sql = "ALTER TABLE ";
                        sql += "ControleCheque ";
                        sql += "ALTER COLUMN Agencia nvarchar(6); ";
                        sql += "ALTER TABLE ";
                        sql += "Banco ";
                        sql += "ALTER COLUMN Limite decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Boleto ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Boleto ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Boleto ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Cedente ";
                        sql += "ALTER COLUMN Juros decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Cedente ";
                        sql += "ALTER COLUMN Multa decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Cedente ";
                        sql += "ALTER COLUMN Tarifa decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "ComodatoItem ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "ControleCheque ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CPagar ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CPagar ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CPagar ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "DROP COLUMN ";
                        sql += "ValorParcial ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "DROP COLUMN ";
                        sql += "Prorrogacao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Folha_Eventos ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaICMS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN PercentualReducao decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaICMSST decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN PercentualReducaoST decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN MargemVAdicionado decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaPIS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaPISST decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaCOFINS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaCOFINSST decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ALTER COLUMN AliquotaIPI decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "LivroCaixa ";
                        sql += "ALTER COLUMN Credito decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "LivroCaixa ";
                        sql += "ALTER COLUMN Debito decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscal ";
                        sql += "ALTER COLUMN ValorTotal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 4); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 4); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN ValorUnitario decimal(10, 4); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 4); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE Ordem ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ALTER COLUMN AliquotaCreditoICMS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Valor decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Desconto decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Pessoa ";
                        sql += "ALTER COLUMN Limite decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pessoa ";
                        sql += "ALTER COLUMN ValorMensalidade decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "PessoaFuncionario ";
                        sql += "ALTER COLUMN Salario decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN ValorCompra decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN OutrosCustos decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN Frete decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN ICMS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN PIS decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN Cofins decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto_Comissao ";
                        sql += "ALTER COLUMN Comissao decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Estoque ";
                        sql += "ALTER COLUMN EstoqueAtual decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Estoque ";
                        sql += "ALTER COLUMN EstoqueIdeal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Estoque ";
                        sql += "ALTER COLUMN EstoqueMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN MargemVenda decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorVenda decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN MargemPromocional decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN MargemMinima decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorPromocional decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoValor decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoTerceiro decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN MargemVenda decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorVenda decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN MargemPromocional decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN MargemMinima decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorPromocional decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 13 - Altera Tabela(Ordem de Compra e Ordem de Compra item)
                    case 13:
                        sql = "EXEC sp_rename 'OrdemCompra', 'Compra' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrdemCompraItem', 'Compra_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Compra.Previsao', 'Entrega', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Compra.Pagamento', 'ID_Pagamento', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Compra_Item.ID_OrdemCompra', 'ID_Compra', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Compra_Item.Valor', 'ValorCompra', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra ";
                        sql += "ADD ";
                        sql += "TipoDocumento int, ";
                        sql += "Documento nvarchar(20) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ADD ";
                        sql += "OutrosCustos decimal(10, 3), ";
                        sql += "Frete decimal(10, 2), ";
                        sql += "CustoFinal decimal(10, 3), ";
                        sql += "ID_Grade int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ALTER COLUMN  ValorCompra decimal(10, 3); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Compra_Item ";
                        sql += "SET ";
                        sql += "OutrosCustos = '0', ";
                        sql += "Frete = '0', ";
                        sql += "CustoFinal = ValorCompra ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE EntradaProduto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 14 - Altera Tabela(Produto) Campo (Frete)
                    case 14:
                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN  Frete decimal(10, 3); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 15 - Altera Tabela(Produto_Estoque) Exclui Campo(Barra)
                    case 15:
                        sql = "ALTER TABLE ";
                        sql += "Produto_Estoque ";
                        sql += "DROP COLUMN ";
                        sql += "Barra ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 16 - Altera Tabela(Orcamento e Orcamento_Item)
                    case 16:
                        sql = "EXEC sp_rename 'OrcamentoVenda', 'Orcamento' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrcamentoVendaItem', 'Orcamento_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Orcamento ";
                        sql += "DROP COLUMN ";
                        sql += "Validade ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.ID_OrcamentoVenda', 'ID_Orcamento', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.ValorUnitario', 'Valor', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ADD ";
                        sql += "CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Valor decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Desconto decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 3); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 3); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 17 - Altera Tabela(Ordem de Serviço e Parametros Sistema)
                    case 17:
                        sql = "EXEC sp_rename 'OS_Info', 'OrdemServico' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OS_InfoProduto', 'OrdemServico_Produto' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OS_InfoServico', 'OrdemServico_Servico' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrdemServico_Produto.ID_OS_Info', 'ID_OrdemServico', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrdemServico_Produto.ValorUnitario', 'Valor', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ADD ";
                        sql += "CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrdemServico_Servico.ID_OS_Info', 'ID_OrdemServico', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'OrdemServico_Servico.ValorUnitario', 'Valor', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ADD ";
                        sql += "CustoFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ";
                        sql += "OSInformaticaProduto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ";
                        sql += "OSInformaticaServico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);


                        sql = "EXEC sp_rename 'ParametroSistema.OS_InfoFinalizado', 'OrdemServicoFinalizado', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ParametroSistema.OS_InfoFaturado', 'OrdemServicoFaturado', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ParametroSistema.OS_InfoCancelado', 'OrdemServicoCancelado', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ParametroSistema.ID_ContaFaturaOS_Info', 'ID_ContaFaturaOrdemServico', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ParametroSistema.ContaFaturaOS_Info', 'ContaFaturaOrdemServico', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 18 - Altera Tabela(Ordem de Serviço_Produto) Adiciona Campo(TipoSaida)
                    case 18:
                        sql = "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ADD ";
                        sql += "TipoSaida int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "OrdemServico_Produto ";
                        sql += "SET ";
                        sql += "TipoSaida = (SELECT TipoVendaProduto FROM ParametroSistema WHERE ID_Empresa = 1) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 19 - Altera Tabela(Ordem_Serviço_Produto, Ordem_Servico_Servico, Pedido_Mobile, Pedido_Mobile_Item)
                    case 19:
                        sql = "EXEC sp_rename 'PedidoVendaMobile', 'Pedido_Mobile' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'PedidoVendaItemMobile', 'Pedido_Mobile_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Mobile.ID_TabelaValor', 'ID_Tabela', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Mobile.InformacaoPedido', 'Informacao', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Mobile_Item.TipoVendaProduto', 'TipoSaida', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Mobile.ID_Mobile', 'ID_Pedido', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Desconto decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Valor decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Desconto decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Valor decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Pedido_Mobile_Item ";
                        sql += "ALTER COLUMN ValorUnitario decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Mobile ";
                        sql += "ALTER COLUMN Desconto decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Mobile ";
                        sql += "ALTER COLUMN Bonificacao decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Mobile ";
                        sql += "ALTER COLUMN PorcentagemVenda decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 20 - Altera Tabela(Ordem_Serviço_Produto, Ordem_Servico_Servico, Pedido_Mobile, Pedido_Mobile_Item)
                    case 20:
                        sql = "ALTER TABLE ";
                        sql += "Cedente ";
                        sql += "ADD ";
                        sql += "ID_Empresa int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Cedente ";
                        sql += "SET ";
                        sql += "ID_Empresa  = 1";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 21 - Altera Tabela(Ordem_Serviço_Produto, Ordem_Servico_Servico, Pedido_Mobile, Pedido_Mobile_Item)
                    case 21:
                        sql = "CREATE TABLE Pessoa_EmpresaResponsavel ( ";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Pessoa int, ";
                        sql += "TipoPessoaResponsavel int, ";
                        sql += "ID_PessoaResponsavel int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 22 - Altera Tabela(Parametros Sistema) Adiciona Campo(SMTP, Porta, SSL, De, Usuario, Senha)
                    case 22:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "SMTP nvarchar(60), ";
                        sql += "Porta int, ";
                        sql += "SSL bit, ";
                        sql += "De nvarchar(60), ";
                        sql += "Usuario nvarchar(60), ";
                        sql += "Senha nvarchar(100) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 23 - Altera Tabela(Parametros Sistema) Adiciona Campo(Email)
                    case 23:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Email nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 24 - Altera Tabela(ImpostoControle, Imposto) Adiciona Campo(Tipo_NF)
                    case 24:
                        sql = "ALTER TABLE ";
                        sql += "ImpostoControle ";
                        sql += "ADD ";
                        sql += "Tipo_NF int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Imposto ";
                        sql += "ADD ";
                        sql += "Tipo_NF int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 25 - Altera Tabela(Produto) Adiciona Campo(Imagem) Remove Campo (Genero e Classe)
                    case 25:
                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ADD ";
                        sql += "Imagem Image ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "DROP COLUMN ";
                        sql += "Genero, Classe ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 26 - Altera Tabela(Produto) Adiciona Campo(PesoB, PesoL)
                    case 26:
                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ADD ";
                        sql += "PesoB decimal(10,3), PesoL decimal(10,3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Produto ";
                        sql += "SET ";
                        sql += "PesoB = 0, PesoL = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 27 - Altera Tabela(NotaFiscal) Adiciona Campo(ID_Transporadora)
                    case 27:
                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal ";
                        sql += "ADD ";
                        sql += "ID_Transportadora int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "NotaFiscal ";
                        sql += "SET ";
                        sql += "ID_Transportadora = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 28 - Altera Tabela(NotaFiscal) Adiciona Campo(TipoFrete)
                    case 28:
                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal ";
                        sql += "ADD ";
                        sql += "TipoFrete int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "NotaFiscal ";
                        sql += "SET ";
                        sql += "TipoFrete = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 29 - Altera Tabela(Boleto) Adiciona Campo(DataBaixa)
                    case 29:
                        sql = "ALTER TABLE ";
                        sql += "Boleto ";
                        sql += "ADD ";
                        sql += "DataBaixa datetime";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Boleto ";
                        sql += "SET ";
                        sql += "DataBaixa = Vencimento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 30 - Altera Tabela(Parametro Sistema) Adiciona Campo(Exibe Desconto)
                    case 30:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "ExibeDesconto bit";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "ExibeDesconto = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 31 - Criar Tabela(NF_TipoEmissao)
                    case 31:
                        sql = "CREATE TABLE NF_TipoEmissao (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "Descricao varchar(60), ";
                        sql += "Serie int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 32 - Altera Tabela(NotaFiscal, NotaFiscal_Item)
                    case 32:
                        sql = "CREATE TABLE NotaFiscal_Volume(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "Quantidade int, ";
                        sql += "Especie nvarchar(60), ";
                        sql += "Marca nvarchar(60), ";
                        sql += "Numeracao nvarchar(60), ";
                        sql += "PesoL Decimal(15,3), ";
                        sql += "PesoB Decimal(15,3)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO ";
                        sql += "NotaFiscal_Volume ";
                        sql += "(ID_NF, Quantidade, Especie, PesoL, PesoB) ";
                        sql += "SELECT ID AS ID_NF, QtVolume AS Quantidade, EspecieVolume AS Volume, PesoL, PesoB FROM NotaFiscal ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Lacre(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF_Volume int, ";
                        sql += "Numero nvarchar(60)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Transporte(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "CNPJ_CPF nvarchar(18), ";
                        sql += "Nome nvarchar(60), ";
                        sql += "IE nvarchar(15), ";
                        sql += "Endereco nvarchar(60), ";
                        sql += "Municipio nvarchar(60), ";
                        sql += "UF nvarchar(2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Cobranca(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "NumeroFatura nvarchar(60), ";
                        sql += "Valor decimal(15,2), ";
                        sql += "Desconto decimal(15,2), ";
                        sql += "ValorFinal decimal(15,2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Duplicata(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "NumeroDuplicata nvarchar(60), ";
                        sql += "Vencimento datetime, ";
                        sql += "Valor decimal(15,2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Importacao(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF_Item int, ";
                        sql += "Documento nvarchar(10), ";
                        sql += "Data_Registro datetime, ";
                        sql += "Local nvarchar(60), ";
                        sql += "UF nvarchar(2), ";
                        sql += "Data_Desen datetime, ";
                        sql += "Codigo nvarchar(60)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);


                        sql = "CREATE TABLE NotaFiscal_Adicao(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Importacao int, ";
                        sql += "Numero nvarchar(3), ";
                        sql += "Seq int, ";
                        sql += "Codigo nvarchar(60), ";
                        sql += "Desconto decimal(15,2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_XML(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "Chave nvarchar(44), ";
                        sql += "XML xml) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Ent_Ret(";
                        sql += "ID int identity primary key, ";
                        sql += "Tipo int, ";
                        sql += "ID_NF int, ";
                        sql += "CNPJ_CPF nvarchar(18), ";
                        sql += "Logradouro nvarchar(60), ";
                        sql += "Numero nvarchar(60), ";
                        sql += "Complemento nvarchar(60), ";
                        sql += "Bairro nvarchar(60), ";
                        sql += "ID_Municipio int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE NotaFiscal_Referenciada(";
                        sql += "ID int identity primary key, ";
                        sql += "Tipo int, ";
                        sql += "ID_NF int, ";
                        sql += "Chave_NFe nvarchar(44), ";
                        sql += "UF nvarchar(2), ";
                        sql += "DataEmissao datetime, ";
                        sql += "CNPJ_CPF nvarchar(18), ";
                        sql += "Modelo nvarchar(2), ";
                        sql += "Serie nvarchar(3), ";
                        sql += "Numero_NF nvarchar(9), ";
                        sql += "IE nvarchar(15), ";
                        sql += "CTE nvarchar(44), ";
                        sql += "Mod_CupomFiscal nvarchar(2), ";
                        sql += "ECF nvarchar(3), ";
                        sql += "Numero_Contador nvarchar(6)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal ";
                        sql += "ADD ";
                        sql += "TipoImpressao int, ";
                        sql += "Dig_Verificador int, ";
                        sql += "DataContigencia datetime, ";
                        sql += "Justificativa nvarchar(256), ";
                        sql += "IE_Substituicao nvarchar(15), ";
                        sql += "ValorBC decimal(15,2), ";
                        sql += "ValorICMS decimal(15,2), ";
                        sql += "ValorBCST decimal(15,2), ";
                        sql += "ValorST decimal(15,2), ";
                        sql += "ValorProduto decimal(15,2), ";
                        sql += "ValorFrete decimal(15,2), ";
                        sql += "ValorSeguro decimal(15,2), ";
                        sql += "ValorDesconto decimal(15,2), ";
                        sql += "ValorImportacao decimal(15,2), ";
                        sql += "ValorIPI decimal(15,2), ";
                        sql += "ValorPIS decimal(15,2), ";
                        sql += "ValorCOFINS decimal(15,2), ";
                        sql += "ValorOutro decimal(15,2), ";
                        sql += "InformacaoFisco nvarchar(2000), ";
                        sql += "Tipo_Frete int, ";
                        sql += "Tipo_NF int, ";
                        sql += "Serie int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal ";
                        sql += "SET Serie = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscal.Informacao', 'InformacaoAdicional', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal DROP COLUMN CFOP, HoraSaida, QtVolume, EspecieVolume, PesoL, PesoB, ID_Transportadora ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "NotaFiscalItem ";
                        sql += "ADD ";
                        sql += "Frete decimal(15,2), ";
                        sql += "Seguro decimal(15,2), ";
                        sql += "ValorBC decimal(15,2), ";
                        sql += "ValorICMS decimal(15,2), ";
                        sql += "ValorBCST decimal(15,2), ";
                        sql += "ValorICMSST decimal(15,2), ";
                        sql += "ValorBCSTRet decimal(15,2), ";
                        sql += "ValorICMSSTRet decimal(15,2), ";
                        sql += "CSOSN nvarchar(3), ";
                        sql += "AliquotaCredito decimal(15,2), ";
                        sql += "ValorCredito decimal(15,2), ";
                        sql += "CSTIPI nvarchar(2), ";
                        sql += "AliquotaIPI decimal(5,2), ";
                        sql += "ValorIPI decimal(15,2), ";
                        sql += "ValorBCII decimal(15,2), ";
                        sql += "ValorDesII decimal(15,2), ";
                        sql += "ValorII decimal(15,2), ";
                        sql += "ValorIOF decimal(15,2), ";
                        sql += "CSTPIS nvarchar(2), ";
                        sql += "AliquotaPIS decimal(5,2), ";
                        sql += "ValorPIS decimal(15,2), ";
                        sql += "ValorAliquotaPIS decimal(15,2), ";
                        sql += "CSTCOFINS nvarchar(2), ";
                        sql += "AliquotaCOFINS decimal(5,2), ";
                        sql += "ValorCOFINS decimal(15,2), ";
                        sql += "ValorAliquotaCOFINS decimal(15,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.ValorFinal', 'ValorTotal', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.ID_NFe', 'ID_NF', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.PercentualReducaoBCST', 'PercentualReducaoST', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.Informacao', 'InformacaoAdicional', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.QuantidadeGrupoN', 'Quantidade_Selo', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem.CodigoEnquadramento', 'Codigo_Selo', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscalItem DROP COLUMN ValorMinimo, IPI ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscalItem', 'NotaFiscal_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 33 - Altera Tabela(Mudança de Campos Money para Decimal (10, 3)
                    case 33:
                        sql = "ALTER TABLE ";
                        sql += "Notafiscal_Item ";
                        sql += "ALTER COLUMN Quantidade decimal(15, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Notafiscal_Item ";
                        sql += "ALTER COLUMN ValorUnitario decimal(15, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Notafiscal_Item ";
                        sql += "ALTER COLUMN ValorTotal decimal(15, 2); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 34 - Altera Tabela(Parametros Sistema) Adiciona Campo(Certificado Digital)
                    case 34:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "CertificadoDigital nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 35 - Altera Tabela(NotaFiscal_Transporte) Adiciona Campo(ID_Pessoa)
                    case 35:
                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal_Transporte ";
                        sql += "ADD ";
                        sql += "ID_Pessoa int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 36 - Altera Tabela(Parametros Sistema) Adiciona Campo(Tipo_NF_Venda)
                    case 36:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Tipo_NF_Venda int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 37 - Criar Tabela(Pedido_Tipo)
                    case 37:
                        sql = "CREATE TABLE Pedido_Tipo (";
                        sql += "ID int identity primary key, ";
                        sql += "Descricao nvarchar(60), ";
                        sql += "Finaliza bit, ";
                        sql += "EmitirNFe bit) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 38 - Criar Tabela(Cont_Doc)
                    case 38:
                        sql = "CREATE TABLE Cont_Doc (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Tipo int, ";
                        sql += "Descricao nvarchar(100)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 39 - Altera Tabela(Pagamento)
                    case 39:
                        sql = "ALTER TABLE ";
                        sql += "Pagamento ";
                        sql += "ADD ";
                        sql += "Qt_Parcela int, ";
                        sql += "Tipo int, ";
                        sql += "Fatura bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.LancarCaixa', 'Lanca_Caixa', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.Cheque', 'Lanca_Financa', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.MargemMinima', 'Porc_Custo', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.DescontoMaximo', 'Vlr_Custo', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Pagamento ";
                        sql += "ALTER COLUMN Porc_Custo decimal(6,2); ";

                        sql = "ALTER TABLE ";
                        sql += "Pagamento ";
                        sql += "ALTER COLUMN Vlr_Custo decimal(6,2); ";

                        sql = "UPDATE ";
                        sql += "Pagamento ";
                        sql += "SET ";
                        sql += "Porc_Custo = '0', ";
                        sql += "Vlr_Custo = '0' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 40 - Criar Tabela(Cont_Controle_Doc)
                    case 40:
                        sql = "CREATE TABLE Cont_Controle_Doc (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Documento int, ";
                        sql += "TipoPessoa int, ";
                        sql += "ID_Pessoa int, ";
                        sql += "Periodo datetime, ";
                        sql += "DataEntrada datetime, ";
                        sql += "Entregue bit) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 41 - Criar Tabela(Cont_Controle_Doc)
                    case 41:
                        sql = "CREATE TABLE Log_Acesso (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Usuario int, ";
                        sql += "ID_Empresa int, ";
                        sql += "Data datetime, ";
                        sql += "Terminal nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 42 - Alterar Tabela(Pedido_Tipo)
                    case 42:
                        sql = "EXEC sp_rename 'Pedido_Tipo.Finaliza', 'EstoqueManual', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 43 - Altera Tabela(Parametros Sistema) Adiciona Campo(Tipo_Pedido)
                    case 43:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Tipo_Pedido int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "Tipo_Pedido = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 44 - Altera Tabela(Pedido_Item) Adiciona Campo(Quantidade_Entregue)
                    case 44:
                        sql = "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ADD ";
                        sql += "Quantidade_Entregue decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pedido_Item ";
                        sql += "SET ";
                        sql += "Quantidade_Entregue = Quantidade ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 45 - Altera Tabela(Pedido_Item) Adiciona Campo(Quantidade_Entregue)
                    case 45:
                        sql = "ALTER TABLE ";
                        sql += "Pedido ";
                        sql += "ADD ";
                        sql += "Tipo int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pedido ";
                        sql += "SET ";
                        sql += "Tipo = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 46 - Altera Tabela(PessoaEndereco) Adiciona Campo(ID_Pais)
                    case 46:
                        sql = "ALTER TABLE ";
                        sql += "PessoaEndereco ";
                        sql += "ADD ";
                        sql += "ID_Pais int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "PessoaEndereco ";
                        sql += "SET ";
                        sql += "ID_Pais = 1058 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 47 - Altera Tabela(Mudança de Campos Money para Decimal (10, 2)
                    case 47:
                        sql = "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Item ";
                        sql += "ALTER COLUMN Quantidade_Entregue decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Mobile_Item ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Pedido_Mobile_Item ";
                        sql += "ALTER COLUMN ValorUnitario decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal_Item ";
                        sql += "ALTER COLUMN Quantidade decimal(10, 3) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN ValorCompra decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN OutrosCustos decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);


                        sql = "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorVenda decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Produto_Valor ";
                        sql += "ALTER COLUMN ValorPromocional decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoValor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoTerceiro decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorVenda decimal(10, 3); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Servico_Valor ";
                        sql += "ALTER COLUMN ValorPromocional decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "Orcamento_Item ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";

                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Produto ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";

                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN ValorMinimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Valor decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN ValorFinal decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Acrescimo decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN Desconto decimal(10, 2); ";
                        sql += "ALTER TABLE ";
                        sql += "OrdemServico_Servico ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 48 - Altera Tabela(CReceber) Adiciona Campo(ID_Pedido)
                    case 48:
                        sql = "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "ADD ";
                        sql += "ID_Pedido int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 49 - Altera Tabela(ParametroSistema) Adiciona Campo(ExibeInfoProduto)
                    case 49:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "ExibeInfoProduto bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "ExibeInfoProduto = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 50 - Altera Tabela(Parametros Sistema) Adiciona Campo(Certificado Digital)
                    case 50:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "FiltraEmpresa bit";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "FiltraEmpresa = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 51 - Altera Tabela(FluxoCaixa) Altera Campo(Data, GrupoConta)
                    case 51:
                        sql = "EXEC sp_rename 'LivroCaixa', 'FluxoCaixa'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'FluxoCaixaControle', 'FluxoCaixa_Controle'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'FluxoCaixa.Data', 'Emissao', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 52 - Altera Tabela(ParametroSistema) Adiciona Campo(ExibeInfoProduto)
                    case 52:
                        sql = "ALTER TABLE ";
                        sql += "ControleCheque ";
                        sql += "ADD ";
                        sql += "Titular nvarchar(200), CNPJ_CPF nvarchar(18) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ControleCheque.DataEmissao', 'Emissao', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ControleCheque.DataVencimento', 'Vencimento', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 53 - Altera Tabela(CPagar) AlteraCampo Campo(Situação)
                    case 53:
                        sql = "SELECT ";
                        sql += "SituacaoCPagar ";
                        sql += "FROM ParametroSistema ";

                        int aux = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["SituacaoCPagar"].ToString());

                        sql = "UPDATE CPagar ";
                        sql += "SET ";
                        sql += "Situacao = 2 ";
                        sql += "WHERE Situacao = " + aux + " ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE CPagar ";
                        sql += "SET ";
                        sql += "Situacao = 1 ";
                        sql += "WHERE Situacao <> 2";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 54 - Criar Tabela(NotaFiscal_Evento)
                    case 54:
                        sql = "CREATE TABLE NotaFiscal_Evento (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "Protocolo nvarchar(20), ";
                        sql += "Data datetime, ";
                        sql += "Evento nvarchar(200), ";
                        sql += "Seq int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 55 - Altera Tabela(NF_Evento) Adiciona Campo(Tipo_Evento)
                    case 55:
                        sql = "ALTER TABLE ";
                        sql += "NotaFiscal_Evento ";
                        sql += "ADD ";
                        sql += "Tipo_Evento int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 56 - Criação de Tabela NCM
                    case 56:
                        sql = "CREATE TABLE NCM (";
                        sql += "ID int identity primary key, ";
                        sql += "NCM nvarchar(8), ";
                        sql += "EX int, ";
                        sql += "Tabela int, ";
                        sql += "AliqNac Decimal(5,2), ";
                        sql += "AliqImp Decimal(5,2)) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 57 - Altera Tabela(ParametroSistema) Adiciona Campo(Item_UltVlr)
                    case 57:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Item_UltVlr bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "Item_UltVlr = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 58 - Altera Tabela(ParametroSistema) Adiciona Campo(Ped_Orc_2Vias)
                    case 58:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Ped_Orc_2Vias bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "Ped_Orc_2Vias = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 59 - Altera Tabela(Cedente) Adiciona Campo(Tipo_Doc_Cedente, CNPJ_CPF_Cedente, Razao_Cedente)
                    case 59:
                        sql = "ALTER TABLE ";
                        sql += "Cedente ";
                        sql += "ADD ";
                        sql += "Tipo_Doc_Cedente int, ";
                        sql += "CNPJ_CPF_Cedente nvarchar(18), ";
                        sql += "Razao_Cedente nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 60 - Altera Tabela(Pagamento)
                    case 60:
                        sql = "ALTER TABLE ";
                        sql += "Pagamento ";
                        sql += "ADD ";
                        sql += "Recebimento bit, ";
                        sql += "Pagamento bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pagamento ";
                        sql += "SET ";
                        sql += "Recebimento = 'true', ";
                        sql += "Pagamento = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.Lanca_Financa', 'Gera_Financ', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.Fatura', 'Fatura_Manual', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pagamento DROP COLUMN Lanca_Caixa";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Pagamento_Parc (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Pagamento int, ";
                        sql += "Parcelamento nvarchar(100)) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 61 - Altera Tabela(Pagamento)
                    case 61:
                        sql = "ALTER TABLE Pagamento DROP COLUMN Gera_Financ, Fatura_Manual";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 62 - Altera Tabela(Pagamento)
                    case 62:
                        sql = "ALTER TABLE ";
                        sql += "Pagamento ";
                        sql += "ADD ";
                        sql += "Dia_Pagto int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pagamento ";
                        sql += "SET ";
                        sql += "Dia_Pagto = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 63 - Altera Tabela(ParametroSistema) Adiciona Campo(ExibeInfoProduto)
                    case 63:
                        sql = "ALTER TABLE ";
                        sql += "Pedido ";
                        sql += "ADD ";
                        sql += "Faturado bit, NFe bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pedido DROP COLUMN ID_Pagamento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pedido_Item DROP COLUMN ValorMinimo, Acrescimo, Desconto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.Valor', 'ValorProduto', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.TipoVendaProduto', 'TipoSaida', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.CustoFinal', 'ValorCusto', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item.ValorFinal', 'ValorVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 64 - Create View V_Pedido
                    case 64:
                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, PV.DataFatura, ";
                        sql += "PV.Comprador, PV.Faturado, PV.NFe, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento ";
                        sql += "FROM Pedido AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM ";
                        sql += "Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN GrupoSimples AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 65 - Altera Tabela(CReceber) AlteraCampo Campo(Situação)
                    case 65:
                        sql = "SELECT ";
                        sql += "SituacaoCReceber ";
                        sql += "FROM ParametroSistema ";

                        int CReceber = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["SituacaoCReceber"].ToString());

                        sql = "UPDATE CReceber ";
                        sql += "SET ";
                        sql += "Situacao = 2 ";
                        sql += "WHERE Situacao = " + CReceber + " ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE CReceber ";
                        sql += "SET ";
                        sql += "Situacao = 1 ";
                        sql += "WHERE Situacao <> 2";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 66 - Criar Tabela Pessoa (Proprietario, Locatario, Fiador)
                    case 66:
                        sql = "CREATE TABLE PessoaProprietario (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Usuario int, ";
                        sql += "Referencia nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE PessoaLocatario (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Usuario int, ";
                        sql += "Referencia nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE PessoaFiador (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Usuario int, ";
                        sql += "Referencia nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 67 - Criar Tabela Pessoa (Imoveis)
                    case 67:
                        sql = "CREATE TABLE Imovel (";
                        sql += "ID int identity primary key, ";
                        sql += "Descricao nvarchar(200), ";
                        sql += "ID_Tipo int, ";
                        sql += "Tipo_Imovel int, ";
                        sql += "Area decimal(13,2), ";
                        sql += "Valor decimal(13,2), ";
                        sql += "Comissao decimal(13,2), ";
                        sql += "Logradouro nvarchar(60), ";
                        sql += "Numero nvarchar(60), ";
                        sql += "Complemento nvarchar(60), ";
                        sql += "Bairro nvarchar(60), ";
                        sql += "CEP nvarchar(9), ";
                        sql += "ID_Municipio int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imovel_Proprietario (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imovel int, ";
                        sql += "TipoPessoa int, ";
                        sql += "ID_Pessoa int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imovel_Imagem (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imovel int, ";
                        sql += "Informacao nvarchar(60), ";
                        sql += "Imagem image) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imovel_Custo (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imovel int, ";
                        sql += "ID_Tipo int, ";
                        sql += "Valor decimal(13,2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imovel_Vistoria (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imovel int, ";
                        sql += "Local nvarchar(60), ";
                        sql += "Descricao nvarchar(2000)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 68 - Criar Tabela Pessoa (Imoveis)
                    case 68:
                        sql = "CREATE TABLE Locacao (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imovel int, ";
                        sql += "Data date, ";
                        sql += "Inicio date, ";
                        sql += "Termino date, ";
                        sql += "DiaVencimento int, ";
                        sql += "Valor decimal(13,2), ";
                        sql += "Descricao_Test1 nvarchar(60), ";
                        sql += "Descricao_Test2 nvarchar(60), ";
                        sql += "Doc_Test1 nvarchar(18), ";
                        sql += "Doc_Test2 nvarchar(18)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Locacao_Locatario (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Locacao int, ";
                        sql += "ID_Locatario int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Locacao_Fiador (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Locacao int, ";
                        sql += "ID_Fiador int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 69 - Altera Tabela(Imovel)
                    case 69:
                        sql = "ALTER TABLE ";
                        sql += "Imovel ";
                        sql += "ADD ";
                        sql += "RGI nvarchar(10), ";
                        sql += "UC nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 70 - Altera Tabela(Locacao)
                    case 70:
                        sql = "ALTER TABLE ";
                        sql += "Locacao ";
                        sql += "ADD ";
                        sql += "Observacao nvarchar(200), ";
                        sql += "UC nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 71 - Altera Tabela(Pessoa)
                    case 71:
                        sql = "ALTER TABLE ";
                        sql += "Pessoa ";
                        sql += "ADD ";
                        sql += "Conjuge nvarchar(60), ";
                        sql += "Doc_Conjuge nvarchar(18) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 72 - Criar Tabela Pessoa (Imoveis)
                    case 72:
                        sql = "CREATE TABLE Imovel_Contrato (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Proprietario int, ";
                        sql += "Emissao date, ";
                        sql += "Descricao_Test1 nvarchar(60), ";
                        sql += "Descricao_Test2 nvarchar(60), ";
                        sql += "Doc_Test1 nvarchar(18), ";
                        sql += "Doc_Test2 nvarchar(18)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 73 - Alterar Tabela (Imoveis)
                    case 73:
                        sql = "ALTER TABLE ";
                        sql += "Imovel ";
                        sql += "ADD ";
                        sql += "Comissao_Valor decimal(13,2)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Imovel.Comissao', 'Comissao_Porc', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Imovel ";
                        sql += "SET ";
                        sql += "Comissao_Valor = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 74 - Alterar Tabela (Imoveis)
                    case 74:
                        sql = "ALTER TABLE ";
                        sql += "Pessoa ";
                        sql += "ADD ";
                        sql += "Profissao_Conjuge nvarchar(60)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 75 - Create View V_CPagar
                    case 75:
                        sql = "CREATE VIEW V_CPagar AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle,  ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa ";
                        sql += "FROM CPagar AS C ";
                        sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 76 - Create View V_CReceber
                    case 76:
                        sql = "CREATE VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Pedido, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 77 - Altera Tabela(ControleCheque)
                    case 77:
                        sql = "EXEC sp_rename 'ControleCheque', 'Cheque' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 78 - Create View V_Cheque_Historico
                    case 78:
                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Caixa AS ID_Caixa, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Caixa AS ID_Caixa, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 79 - Altera Tabela(Pessoa)
                    case 79:
                        sql = "EXEC sp_rename 'Pessoa.Doc_Conjuge', 'CPF_Conjuge', 'COLUMN';";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Pessoa ";
                        sql += "ADD ";
                        sql += "RG_Conjuge nvarchar(15)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 80 - Altera Tabela(PessoaTelefone)
                    case 80:
                        sql = "ALTER TABLE PessoaTelefone ALTER COLUMN NumeroTelefone nvarchar(13)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 81 - Altera Tabela(Pessoa)
                    case 81:
                        sql = "ALTER TABLE Pessoa ALTER COLUMN RG_Conjuge nvarchar(18)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 82 - Altera Tabela(Compra, Compra_Item)
                    case 82:
                        sql = "ALTER TABLE ";
                        sql += "Compra ";
                        sql += "ADD ";
                        sql += "Faturado bit";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Compra ";
                        sql += "SET ";
                        sql += "Faturado = 'true'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ADD ";
                        sql += "ValorIPI decimal(10,2)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Compra_Item ";
                        sql += "SET ";
                        sql += "ValorIPI = 0";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ADD ";
                        sql += "ValorIPI decimal(10,2)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Produto ";
                        sql += "SET ";
                        sql += "ValorIPI = 0";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ALTER COLUMN ValorCompra decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ALTER COLUMN OutrosCustos decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ALTER COLUMN Frete decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Compra_Item ";
                        sql += "ALTER COLUMN CustoFinal decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 83 - Altera Tabela(Parametros)
                    case 83:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "ID_ContaFatCompra int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "ID_ContaFatCompra = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 84 - Create View V_Pedido_ResumoPagto
                    case 84:
                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, F.Credito, F.Emissao ";
                        sql += "FROM V_Pedido AS PV ";
                        sql += "INNER JOIN CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS FCC ON CR.ID = FCC.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS F ON F.ID = FCC.ID_FluxoCaixa ";
                        sql += "INNER JOIN Pagamento AS p ON F.ID_Pagamento = p.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 85 - Create View V_Pedido
                    case 85:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, PV.DataFatura, ";
                        sql += "PV.Comprador, PV.Faturado, PV.NFe, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio ";
                        sql += "FROM Pedido AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 86 - Create View V_Pedido
                    case 86:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, PV.DataFatura, ";
                        sql += "PV.Comprador, PV.Faturado, PV.NFe, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF ";
                        sql += "FROM Pedido AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 87 - Altera Tabela(FluxoCaixa)
                    case 87:
                        sql = " ALTER TABLE FluxoCaixa ALTER COLUMN Documento nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " ALTER TABLE FluxoCaixa ALTER COLUMN Informacao nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 88 - Altera Tabela(Cheque)
                    case 88:
                        sql = " ALTER TABLE Cheque ALTER COLUMN Documento nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " ALTER TABLE Cheque ALTER COLUMN Conta nvarchar(15) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 89 - Create View V_ResumoLocacao
                    case 89:
                        sql = "CREATE VIEW V_ResumoLocacao AS ";
                        sql += "SELECT L.ID, L.ID_Imovel, L.Data, L.Inicio, L.Termino, L.DiaVencimento, L.Valor, L.Descricao_Test1, ";
                        sql += "L.Descricao_Test2, L.Doc_Test1, L.Doc_Test2, L.Observacao, I.Descricao, I.ID_Tipo, I.Tipo_Imovel, ";
                        sql += "I.Area, I.Valor AS ValorImovel, I.Comissao_Porc, I.Logradouro, I.Numero, I.Complemento, I.Bairro, I.CEP, ";
                        sql += "I.ID_Municipio, I.RGI, I.UC, I.Comissao_Valor, LL.ID_Locacao, LL.ID_Locatario, P.MultiEmpresa, P.ID_Empresa, ";
                        sql += "P.TipoPessoa, P.ID_Pessoa, P.TipoDocumento, P.CNPJ_CPF, P.Nome_Razao, P.NomeFantasia, P.Contato, P.IE_RG, ";
                        sql += "P.IM, P.CNAE, P.Cadastro, P.Informacao, P.ID_Grupo, P.Nascimento_Fundacao, P.Ramo_Profissao, P.Descricao1, ";
                        sql += "P.Descricao2, P.Descricao3, P.Limite, P.DiaFaturamento, P.Situacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.Profissao_Conjuge, ";
                        sql += "P.RG_Conjuge ";
                        sql += "FROM Locacao AS L ";
                        sql += "INNER JOIN Imovel AS I ON I.ID = L.ID_Imovel ";
                        sql += "INNER JOIN Locacao_Locatario AS LL ON LL.ID_Locacao = L.ID ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 8 AND P.ID_Pessoa = LL.ID_Locatario ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 90 - Create View V_CReceber
                    case 90:
                        sql = "ALTER TABLE ";
                        sql += "CReceber ";
                        sql += "ADD ";
                        sql += "ID_PrevisaoPagto int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "CReceber ";
                        sql += "SET ";
                        sql += "ID_PrevisaoPagto = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_CReceber ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Pedido, C.ID_PrevisaoPagto, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto, ";
                        sql += "TP.Descricao AS PrevisaoPagto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "LEFT JOIN Pagamento AS TP ON TP.ID = C.ID_PrevisaoPagto ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 91 - Corrige Tabela (Pedido)
                    case 91:
                        sql = "UPDATE ";
                        sql += "Pedido ";
                        sql += "SET ";
                        sql += "Faturado = 'true' ";
                        sql += "WHERE ";
                        sql += "Faturado IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pedido ";
                        sql += "SET ";
                        sql += "NFe = 'true' ";
                        sql += "WHERE ";
                        sql += "NFe IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 92 - Cria Tabela (Email)
                    case 92:
                        sql = "CREATE TABLE Email (";
                        sql += "ID int identity primary key, ";
                        sql += "Data date, ";
                        sql += "Para nvarchar(500), ";
                        sql += "CC nvarchar(500), ";
                        sql += "CCO nvarchar(500), ";
                        sql += "Assunto nvarchar(60), ";
                        sql += "Conteudo text, ";
                        sql += "Anexo nvarchar(500)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 93 - Create View V_Pedido
                    case 93:
                        sql = "ALTER TABLE Orcamento DROP COLUMN Entrega, ID_Pagamento, Situacao";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Orcamento_Item DROP COLUMN Acrescimo, Desconto";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pedido_Item ALTER COLUMN Quantidade decimal(9,3)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.Valor', 'ValorProduto', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.ValorFinal', 'ValorVenda', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.TipoVendaProduto', 'TipoSaida', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Orcamento_Item.CustoFinal', 'ValorCusto', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Orcamento, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF ";
                        sql += "FROM Orcamento AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM ";
                        sql += "Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN GrupoSimples AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 94 - Create View V_UsuarioMobile
                    case 94:
                        sql = "CREATE VIEW V_UsuarioMobile AS ";
                        sql += "SELECT ";
                        sql += "ID, Descricao, SenhaMobile AS Senha ";
                        sql += "FROM Usuario ";
                        sql += "WHERE ";
                        sql += "NOT ID IS NULL ";
                        sql += "AND UsuarioMobile = 'true' ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 95 - Create View V_Pedido_Item
                    case 95:
                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM ";
                        sql += "Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN GrupoSimples AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 96 - Create View V_Orcamento_Item
                    case 96:
                        sql = "DROP VIEW V_Orcamento_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM ";
                        sql += "Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN GrupoSimples AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 97 - Create View V_PessoaMobile
                    case 97:
                        sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "I.Imagem AS Imagem_rpt, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 2 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 2 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 2 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN GrupoSimples AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Imagem AS I ON PC.ID = I.ID_Empresa AND I.Tipo = 1 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 98 - Altera Tabela(FluxoCaixa)
                    case 98:
                        sql = " ALTER TABLE FluxoCaixa ALTER COLUMN Documento nvarchar(2000) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " ALTER TABLE FluxoCaixa ALTER COLUMN Informacao nvarchar(2000) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " ALTER TABLE Cheque ALTER COLUMN Documento nvarchar(2000) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW Produto_Movimento AS ";
                        sql += " SELECT C.Data, CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, Produto.Descricao ";
                        sql += "FROM Compra AS C INNER JOIN ";
                        sql += "Compra_Item AS CP ON C.ID = CP.ID_Compra INNER JOIN ";
                        sql += "Produto ON Produto.ID = CP.ID_Produto ";
                        sql += "UNION ";
                        sql += "SELECT P.Data, PP.ID_Produto, NULL AS compra, PP.Quantidade_Entregue AS Venda, Produto.Descricao  ";
                        sql += "FROM Pedido AS P INNER JOIN ";
                        sql += "Pedido_Item AS PP ON P.ID = PP.ID_Pedido INNER JOIN ";
                        sql += "Produto ON Produto.ID = PP.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 99 - Altera Tabela(Produto Movimento)
                    case 99:
                        sql = "DROP VIEW Produto_Movimento";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Movimento AS ";
                        sql += " SELECT C.Data, CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, Produto.Descricao ";
                        sql += "FROM Compra AS C INNER JOIN ";
                        sql += "Compra_Item AS CP ON C.ID = CP.ID_Compra INNER JOIN ";
                        sql += "Produto ON Produto.ID = CP.ID_Produto ";
                        sql += "UNION ";
                        sql += "SELECT P.Data, PP.ID_Produto, NULL AS compra, PP.Quantidade_Entregue AS Venda, Produto.Descricao  ";
                        sql += "FROM Pedido AS P INNER JOIN ";
                        sql += "Pedido_Item AS PP ON P.ID = PP.ID_Pedido INNER JOIN ";
                        sql += "Produto ON Produto.ID = PP.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 100 - Create View V_PessoaMobile
                    case 100:

                        sql = "DROP VIEW V_PessoaMobile ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 1 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 1 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 1 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN GrupoSimples AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 101 - Cria tabela(Venda_Mobile)
                    case 101:
                        sql = "CREATE TABLE Venda_Mobile (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Venda int, ";
                        sql += "ID_Pessoa int, ";
                        sql += "Data nvarchar(10), ";
                        sql += "ID_Tabela int, ";
                        sql += "ID_Parcelamento int, ";
                        sql += "Informacao nvarchar(200), ";
                        sql += "Desconto decimal(10,2), ";
                        sql += "Comprador nvarchar(200), ";
                        sql += "ID_Usuario int, ";
                        sql += "IMEI nvarchar(30)) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Venda_Item_Mobile (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Venda int, ";
                        sql += "ID_Produto int, ";
                        sql += "Quantidade decimal(10,2), ";
                        sql += "Informacao nvarchar(200), ";
                        sql += "TipoSaida int, ";
                        sql += "IMEI nvarchar(30)) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 102 - Create View V_PessoaMobile
                    case 102:

                        sql = "DROP VIEW V_PessoaMobile ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, PC.ID_Usuario AS ID_Vendedor, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 1 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 1 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 1 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN GrupoSimples AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 103 - Cria tabela(Mobile)
                    case 103:
                        sql = "CREATE TABLE Mobile(";
                        sql += "ID int identity primary key, ";
                        sql += "IMEI nvarchar(20), ";
                        sql += "Equipamento nvarchar(100), ";
                        sql += "Ativo bit) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 104 - Altera View Pedido
                    case 104:

                        sql = "ALTER TABLE ";
                        sql += "Pedido ";
                        sql += "ADD ";
                        sql += "ID_Pagamento int, ";
                        sql += "ID_Parcelamento int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Pedido ";
                        sql += "SET ";
                        sql += "ID_Pagamento = 0, ";
                        sql += "ID_Parcelamento = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, PV.DataFatura, ";
                        sql += "PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF ";
                        sql += "FROM Pedido AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 105 - Create View V_UsuarioMobile
                    case 105:
                        sql = "DROP VIEW V_UsuarioMobile ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_UsuarioMobile AS ";
                        sql += "SELECT ";
                        sql += "ID, UPPER(Descricao) AS Descricao, UPPER(SenhaMobile) AS Senha ";
                        sql += "FROM Usuario ";
                        sql += "WHERE ";
                        sql += "NOT ID IS NULL ";
                        sql += "AND UsuarioMobile = 'true' ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 106 - Create View V_Venda_Mobile
                    case 106:
                        sql = "CREATE VIEW V_Venda_Mobile AS ";
                        sql += "SELECT ";
                        sql += "VM.ID, VM.ID_Venda, VM.ID_Pessoa, VM.Data, VM.ID_Tabela, VM.ID_Usuario, VM.Informacao, VM.Desconto, VM.Comprador, ";
                        sql += "P.Nome_Razao AS Descricao, ";
                        sql += "U.Descricao AS Usuario, ";
                        sql += "PGP.Descricao AS Pagamento, ";
                        sql += "PG.ID_Pagamento, PG.Parcelamento, PG.ID AS ID_Parcelamento, ";
                        sql += "M.Equipamento, M.IMEI ";
                        sql += "FROM Venda_Mobile AS VM ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = 1 AND P.ID_Pessoa = VM.ID_Pessoa ";
                        sql += "LEFT JOIN Usuario AS U ON VM.ID_Usuario = U.ID ";
                        sql += "LEFT JOIN Mobile AS M ON M.IMEI = VM.IMEI ";
                        sql += "LEFT JOIN Pagamento_Parc AS PG ON VM.ID_Parcelamento = PG.ID ";
                        sql += "LEFT JOIN Pagamento AS PGP ON PG.ID_Pagamento = PGP.ID ";
                        sql += "WHERE ";
                        sql += "NOT VM.ID IS NULL ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 107 - Altera View Pedido
                    case 107:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT ";
                        sql += "PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, ";
                        sql += "PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, PV.DataFatura, ";
                        sql += "PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto ";
                        sql += "FROM Pedido AS PV ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                        sql += "LEFT JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE ";
                        sql += "NOT PV.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 108 - Altera Tabela(ParametroSistema) Adiciona Campo(ExibeInfoProduto)
                    case 108:
                        sql = "ALTER TABLE ";
                        sql += "ParametroSistema ";
                        sql += "ADD ";
                        sql += "Finaliza_Fatura bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "ParametroSistema ";
                        sql += "SET ";
                        sql += "Finaliza_Fatura = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 109 - Create View V_Pedido_Item
                    case 109:
                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM ";
                        sql += "Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 110 - Create View V_Pedido_Item
                    case 110:
                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN MargemVLAdicionado decimal(10,2)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 111 - Create View V_Pedido_ResumoPagto
                    case 111:
                        sql = "DROP VIEW V_Pedido_ResumoPagto ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, ";

                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN F.Credito ";
                        sql += "END AS Credito, ";

                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN CR.Vencimento ";
                        sql += "WHEN 2 THEN F.Emissao ";
                        sql += "END AS Data ";

                        sql += "FROM V_Pedido AS PV ";
                        sql += "INNER JOIN CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido ";
                        sql += "LEFT JOIN FluxoCaixa_Controle AS FCC ON CR.ID = FCC.ID_CReceber ";
                        sql += "LEFT JOIN FluxoCaixa AS F ON F.ID = FCC.ID_FluxoCaixa ";
                        sql += "INNER JOIN Pagamento AS P ON F.ID_Pagamento = p.ID OR CR.ID_PrevisaoPagto = P.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 112 - Create View V_Pedido_ResumoPagto e V_Pedido
                    case 112:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, ";
                        sql += "PV.Situacao, PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal ";
                        sql += "FROM Pedido AS PV INNER JOIN ";
                        sql += "Pedido_Item AS PI ON PI.ID_Pedido = PV.ID LEFT OUTER JOIN ";
                        sql += "Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa LEFT OUTER JOIN ";
                        sql += "PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' LEFT OUTER JOIN ";
                        sql += "Municipios AS M ON PEND.ID_Municipio = M.ID LEFT OUTER JOIN ";
                        sql += "UF ON M.ID_UF = UF.ID_UF LEFT OUTER JOIN ";
                        sql += "Pagamento AS PG ON PV.ID_Pagamento = PG.ID LEFT OUTER JOIN ";
                        sql += "Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_ResumoPagto ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, CR.Vencimento AS Data, CR.Total AS Credito ";
                        sql += "FROM V_Pedido AS PV INNER JOIN ";
                        sql += "V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido INNER JOIN ";
                        sql += "Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        sql += "WHERE (CR.Situacao = 1) ";
                        sql += "UNION ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, F.Emissao AS Data, CR.Total AS Credito ";
                        sql += "FROM V_Pedido AS PV INNER JOIN ";
                        sql += "V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido INNER JOIN ";
                        sql += "FluxoCaixa_Controle AS FCC ON CR.ID = FCC.ID_CReceber INNER JOIN ";
                        sql += "FluxoCaixa AS F ON F.ID = FCC.ID_FluxoCaixa INNER JOIN ";
                        sql += "Pagamento AS P ON F.ID_Pagamento = P.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 113 - Create View V_Pedido_ResumoPagto e V_Pedido
                    case 113:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, ";
                        sql += "PV.Situacao, PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal ";
                        sql += "FROM Pedido AS PV INNER JOIN ";
                        sql += "Pedido_Item AS PI ON PI.ID_Pedido = PV.ID LEFT OUTER JOIN ";
                        sql += "Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa LEFT OUTER JOIN ";
                        sql += "PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' LEFT OUTER JOIN ";
                        sql += "Municipios AS M ON PEND.ID_Municipio = M.ID LEFT OUTER JOIN ";
                        sql += "UF ON M.ID_UF = UF.ID_UF LEFT OUTER JOIN ";
                        sql += "Pagamento AS PG ON PV.ID_Pagamento = PG.ID LEFT OUTER JOIN ";
                        sql += "Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_ResumoPagto ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, CR.Vencimento AS Data, CR.Total AS Credito ";
                        sql += "FROM V_Pedido AS PV INNER JOIN ";
                        sql += "V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido INNER JOIN ";
                        sql += "Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        sql += "WHERE (CR.Situacao = 1) ";
                        sql += "UNION ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, F.Emissao AS Data, CR.Total AS Credito ";
                        sql += "FROM V_Pedido AS PV INNER JOIN ";
                        sql += "V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido INNER JOIN ";
                        sql += "FluxoCaixa_Controle AS FCC ON CR.ID = FCC.ID_CReceber INNER JOIN ";
                        sql += "FluxoCaixa AS F ON F.ID = FCC.ID_FluxoCaixa INNER JOIN ";
                        sql += "Pagamento AS P ON F.ID_Pagamento = P.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 114
                    //VERSÃO 114 - 19-05-2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE TABELA - Parametro_Sistema                        
                    case 114:
                        sql = " CREATE TABLE Parametro_Sistema ( ";
                        sql += "ID_Empresa int primary key,";
                        sql += "Juros_Mes decimal(6,2),";
                        sql += "Multa decimal(6,2))";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 115
                    //VERSÃO 115 - 04/06/2014
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA NCM MEDIA DE IMPOSTO                        
                    case 115:
                        sql = "DROP TABLE NCM ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " CREATE TABLE NCM ( ";
                        sql += "ID int identity primary key,";
                        sql += "NCM int,";
                        sql += "Descricao nvarchar(200), ";
                        sql += "AliqNac Decimal(4,2), ";
                        sql += "AliqImp Decimal(4,2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 116
                    //VERSÃO 116 - 12/06/2014
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA CEDENTE                     
                    case 116:
                        sql = "ALTER TABLE Cedente DROP COLUMN Matricial, Conta ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Cedente.Instrucoes', 'Instrucao', 'COLUMN'; ";
                        sql += "EXEC sp_rename 'Cedente.IDConta', 'ID_Conta', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 117
                    //VERSÃO 117 - 07/07/2014
                    //ALTERAÇÕES:
                    //- INCLUSÃO CAMPO (Cancelado) Tabela Pedido                   
                    case 117:
                        sql = "ALTER TABLE Pedido ADD Cancelado bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pedido SET ";
                        sql += "Cancelado = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 118
                    //VERSÃO 118 - 09/07/2014
                    //ALTERAÇÕES:
                    //- INCLUSÃO CAMPO (Cancelado) View V_Pedido
                    case 118:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido AS ";
                        sql += "SELECT PV.ID AS ID_Pedido, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, ";
                        sql += "PV.Situacao, PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado ";
                        sql += "FROM Pedido AS PV INNER JOIN ";
                        sql += "Pedido_Item AS PI ON PI.ID_Pedido = PV.ID LEFT OUTER JOIN ";
                        sql += "Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa LEFT OUTER JOIN ";
                        sql += "PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' LEFT OUTER JOIN ";
                        sql += "Municipios AS M ON PEND.ID_Municipio = M.ID LEFT OUTER JOIN ";
                        sql += "UF ON M.ID_UF = UF.ID_UF LEFT OUTER JOIN ";
                        sql += "Pagamento AS PG ON PV.ID_Pagamento = PG.ID LEFT OUTER JOIN ";
                        sql += "Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, PV.ID_UsuarioComissao3, PV.Tipo, PV.Situacao, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 119
                    //VERSÃO 119 - 22/07/2014
                    //ALTERAÇÕES:
                    //- INCLUSÃO CAMPO (DiasBloqueioVenda, HistoricoVenda) Tabela Parametro_Sistema
                    //- INCLUSÃO CAMPO (Ativo, Localizacao) Tabela Produto
                    //- ALTERA CAMPO (Informacao) Pedido, Venda_Mobile
                    //- CRIA VIEW V_HistoricoVenda, V_HistoricoVenda_Item
                    case 119:
                        sql = "ALTER TABLE ";
                        sql += "Parametro_Sistema ";
                        sql += "ADD ";
                        sql += "DiasBloqueioVenda int, HistoricoVenda int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema ";
                        sql += "SET ";
                        sql += "DiasBloqueioVenda = 0, ";
                        sql += "HistoricoVenda = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE ";
                        sql += "Produto ";
                        sql += "ADD ";
                        sql += "Ativo bit, Localizacao nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto ";
                        sql += "SET ";
                        sql += "Ativo = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pedido ALTER COLUMN Informacao varchar(1000); ";
                        sql += "ALTER TABLE Venda_Mobile ALTER COLUMN Informacao varchar(1000) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda AS ";
                        sql += "SELECT DISTINCT ";
                        sql += "V.ID_Pedido AS ID, V.ID_Pessoa, CONVERT(VARCHAR(10), V.Data, 103) AS Data, ";
                        sql += "VI.ID_Tabela, V.ID_Parcelamento, V.Informacao, 0 AS Desconto, V.Comprador, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Pedido AS V ";
                        sql += "INNER JOIN V_Pedido_Item AS VI ON V.ID_Pedido = VI.ID_Pedido ";
                        sql += "WHERE (V.Data >= DATEADD(d, -1, GETDATE())) ";
                        sql += "GROUP BY V.ID_Pedido, V.ID_Pessoa, V.Data, VI.ID_Tabela, VI.ID_Tabela, V.ID_Parcelamento, ";
                        sql += "V.Informacao, VI.Desconto, V.Comprador, V.ID_UsuarioComissao1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda_Item AS ";
                        sql += "SELECT VI.ID_Pedido AS ID_Venda, VI.ID_Produto, VI.Quantidade, VI.Informacao, VI.TipoSaida, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Pedido_Item AS VI ";
                        sql += "INNER JOIN V_Pedido AS V ON V.ID_Pedido = VI.ID_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 120
                    //VERSÃO 120 - 25/07/2014
                    //ALTERAÇÕES:
                    //- ALTERA VIEW V_HistoricoVenda_Item
                    case 120:
                        sql = "DROP VIEW V_HistoricoVenda_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda_Item AS ";
                        sql += "SELECT VI.ID_Pedido AS ID_Venda, VI.ID_Produto, VI.Quantidade, VI.Informacao, VI.TipoSaida, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Pedido_Item AS VI ";
                        sql += "INNER JOIN V_Pedido AS V ON V.ID_Pedido = VI.ID_Pedido ";
                        sql += "WHERE (V.Data >= DATEADD(d, -1, GETDATE())) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 121
                    //VERSÃO 121 - 11/08/2014
                    //ALTERAÇÕES:
                    //- ALTERA TABELA EMAIL (CAMPO ANEXO PARA TEXT)
                    case 121:
                        sql = "ALTER TABLE Email ALTER COLUMN Anexo text; ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 122
                    //VERSÃO 122 - 12/08/2014
                    //ALTERAÇÕES:
                    //- INCLUSÃO (Tipo de Venda COMODATO) View V_Pedido_Item
                    case 122:
                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM ";
                        sql += "Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 123
                    //VERSÃO 123 - 15/08/2014
                    //ALTERAÇÕES:
                    //- ALTERA TABELA CEDENTE (CRIA CAMPOS UtilizaTarifa, Tarifa)
                    case 123:
                        sql = "ALTER TABLE Cedente DROP COLUMN Tarifa";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Cedente ADD ";
                        sql += "UtilizaTarifa bit, ";
                        sql += "Tarifa Decimal(6,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Cedente SET ";
                        sql += "UtilizaTarifa = 'false', ";
                        sql += "Tarifa = '0' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 124
                    //VERSÃO 124 - 18/09/2014
                    //ALTERAÇÕES:
                    //- ALTERA TABELA IMOVEL (Adiciona campo CI, Matricula)
                    case 124:

                        sql = "ALTER TABLE Imovel ADD ";
                        sql += "CI nvarchar(18), ";
                        sql += "Matricula nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Imovel SET ";
                        sql += "CI = '', ";
                        sql += "Matricula = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 125
                    //VERSÃO 125 - 03/10/2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE INDEX TABELAS (CRECEBER, CPAGAR, FLUXOCAIXA_CONTROLE, PEDIDO_ITEM)
                    case 125:
                        sql = "CREATE INDEX I_ID_PrevisaoPagto ON CReceber (ID_PrevisaoPagto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pedido ON CReceber (ID_Pedido) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON CReceber (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON CPagar (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_FluxoCaixa ON FluxoCaixa_Controle (ID_FluxoCaixa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_CPagar ON FluxoCaixa_Controle (ID_CPagar) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_CReceber ON FluxoCaixa_Controle (ID_CReceber) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pedido ON Pedido_Item (ID_Pedido) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Pedido_Item (ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 126
                    //VERSÃO 126 - 17/10/2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE INDEX TABELAS (CRECEBER, BOLETO, BOLETOCONTROLE, NOTAFISCAL_ITEM, NOTAFISCAL, PESSOAENDERECO,
                    //PESSOATELEFONE, PESSOAEMAIL, PESSOA, PRODUTO_COMISSAO, PRODUTO_ESTOQUE, PRODUTO_IMPOSTO)
                    case 126:
                        sql = "CREATE INDEX I_ID_Pessoa ON Boleto (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Boleto ON BoletoControle (ID_Boleto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Conta ON BoletoControle (ID_Conta) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON NotaFiscal_Item (ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON NotaFiscal (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pedido ON NotaFiscal (ID_Pedido) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON PessoaEndereco (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON PessoaTelefone (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON PessoaEmail (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Pessoa ON Pessoa (ID_Pessoa) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Produto_Comissao (ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Produto_Estoque (ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Produto_Imposto (ID_Produto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Imposto ON Produto_Imposto (ID_Imposto) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 127
                    //VERSÃO 127 - 17/10/2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW (V_Financeiro_Historico)
                    case 127:
                        sql = "CREATE VIEW V_Financeiro_Historico AS ";
                        sql += "SELECT C.ID, PC.ID_Usuario, C.Emissao, C.Vencimento, C.ID_Pessoa, C.Valor, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + ";
                        sql += "'(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, C.Descricao ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT OUTER JOIN PessoaCliente AS PC ON C.ID_Pessoa = PC.ID ";
                        sql += "WHERE     (C.Situacao = 1) AND (C.TipoPessoa = 1) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 128
                    //VERSÃO 127 - 17/10/2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW (V_Financeiro_Historico)
                    case 128:
                        sql = "DROP VIEW V_Financeiro_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Financeiro_Mobile AS ";
                        sql += "SELECT C.ID, PC.ID_Usuario, C.Emissao, C.Vencimento, C.ID_Pessoa, C.Valor, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + ";
                        sql += "'(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, C.Descricao ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT OUTER JOIN PessoaCliente AS PC ON C.ID_Pessoa = PC.ID ";
                        sql += "WHERE ";
                        sql += "C.Situacao = 1 ";
                        sql += "AND C.TipoPessoa = 1 ";
                        sql += "AND (C.Vencimento <= GETDATE()) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 129
                    //VERSÃO 127 - 22/10/2014
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW (V_Venda_PessoaInativo)
                    case 129:

                        sql = "CREATE VIEW V_Venda_PessoaInativo AS ";
                        sql += "SELECT P.TipoPessoa, P.ID_Pessoa, P.Nome_Razao, P.NomeFantasia, P.Contato, P.Informacao, P.Situacao,";
                        sql += "PE.ID as ID_Pedido, PE.Data, PE.DataFatura, PE.Faturado, PE.Cancelado, PE.NFe, PE.Tipo, PE.ID_UsuarioComissao1, PE.ID_UsuarioComissao2, ";
                        sql += "CONVERT(VARCHAR, DATEDIFF(DAY, PE.Data, GETDATE())) as TempoCompra ";
                        sql += "FROM Pessoa AS P ";
                        sql += "LEFT JOIN Pedido AS PE ON P.ID_Pessoa = PE.ID_Pessoa AND P.TipoPessoa = PE.TipoPessoa ";
                        sql += "INNER JOIN (SELECT PP.ID_Pessoa, MAX(PP.ID)as ID_P FROM Pedido AS PP GROUP BY PP.ID_Pessoa) AS Tab_Pedido ON Tab_Pedido.ID_P = PE.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 130
                    //VERSÃO 130 - 03/11/2014
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Venda_PessoaInativo)
                    case 130:
                        sql = "DROP VIEW V_Venda_PessoaInativo ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_PessoaInativo AS ";
                        sql += "SELECT P.TipoPessoa, P.ID_Pessoa, P.Nome_Razao, P.NomeFantasia, P.Contato, P.Informacao, P.Situacao, ";
                        sql += "PE.ID as ID_Pedido, PE.Data, PE.DataFatura, PE.Faturado, PE.Cancelado, PE.NFe, PE.Tipo, ";
                        sql += "CONVERT(VARCHAR, DATEDIFF(DAY, PE.Data, GETDATE())) as TempoCompra, ";
                        sql += "PC.ID_Usuario AS ID_UsuarioComissao1 ";
                        sql += "FROM Pessoa AS P ";
                        sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN Pedido AS PE ON P.ID_Pessoa = PE.ID_Pessoa AND P.TipoPessoa = PE.TipoPessoa ";
                        sql += "INNER JOIN (SELECT PP.ID_Pessoa, MAX(PP.ID)as ID_P FROM Pedido AS PP GROUP BY PP.ID_Pessoa) AS Tab_Pedido ON Tab_Pedido.ID_P = PE.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 131
                    //VERSÃO 131 - 14/11/2014
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (ControleDoc, ControleDoc_Tipo)
                    case 131:
                        sql = "EXEC sp_rename 'Cont_Controle_Doc', 'ControleDoc' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Cont_Doc', 'ControleDoc_Tipo' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 132
                    //VERSÃO 132 - 25/11/2014
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_PessoaMobile)
                    case 132:
                        sql = "EXEC sp_rename 'Pessoa.Situacao', 'Situacao_old', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pessoa ADD Situacao bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        _DT = new DataTable();
                        sql = "SELECT SituacaoLiberada FROM ParametroSistema";
                        _DT = conexao.Consulta(sql);

                        sql = "UPDATE Pessoa SET ";
                        sql += "Situacao = 'true' ";
                        sql += "WHERE ";
                        sql += "Situacao_old = " + _DT.Rows[0]["SituacaoLiberada"] + " ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pessoa SET ";
                        sql += "Situacao = 'false' ";
                        sql += "WHERE ";
                        sql += "Situacao IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_PessoaMobile ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, PC.ID_Usuario AS ID_Vendedor, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 1 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 1 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 1 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN GrupoSimples AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE P.Situacao = 'True' ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 133
                    case 133:
                        //VERSÃO 133 - 25/11/2014
                        //ALTERAÇÕES:
                        //- ALTERAÇÃO DE VIEW (V_Produto_Movimento)
                        sql = "DROP VIEW V_Produto_Movimento";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Movimento AS ";

                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "Produto.Descricao, Produto.Referencia, Produto.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Compra AS C ";
                        sql += "INNER JOIN Compra_Item AS CP ON C.ID = CP.ID_Compra ";
                        sql += "INNER JOIN Produto ON Produto.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";

                        sql += "UNION ";

                        sql += "SELECT P.Data, 'ÚLTIMA VENDA: Nº ' + CAST(P.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "Produto.Descricao, Produto.Referencia, Produto.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Pedido AS P ";
                        sql += "INNER JOIN Pedido_Item AS PP ON P.ID = PP.ID_Pedido ";
                        sql += "INNER JOIN Produto ON Produto.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON P.TipoPessoa = PS.TipoPessoa AND P.ID_Pessoa = PS.ID_Pessoa ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 134
                    case 134:
                        //VERSÃO 134 - 09/12/2014
                        //ALTERAÇÕES:
                        //- CRIAÇÃO DE VIEW (V_Produto_Venda)

                        sql = "CREATE VIEW V_Produto_Venda AS ";

                        sql += "SELECT ";
                        sql += "P.ID, P.MultiEmpresa, P.ID_Empresa, P.GrupoNivel, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.Frete, P.OutrosCustos, P.ICMS, P.PIS, P.Cofins, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Situacao, ";
                        sql += "P.Ativo, P.Localizacao, P.Tipo, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) ";
                        sql += "+ CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoCompleta ";
                        sql += "FROM ";
                        sql += "Produto AS P ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoSimples AS UN ON UN.ID = P.UnidadeTributavel ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 135
                    case 135:
                        //VERSÃO 135 - 05/02/2015
                        //ALTERAÇÕES:
                        //- ALTERAÇÃO TABELA USUARIO, CRIAÇÃO TABELA USUARIO_PARAM

                        sql = " CREATE TABLE Usuario_Param (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Usuario int, ";
                        sql += "Comissao bit, ";
                        sql += "Pedido bit, ";
                        sql += "Orca bit, ";
                        sql += "OrdemServico bit) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        _DT = new DataTable();

                        sql = "SELECT ID AS ID_Usuario, Pedido, Orca, OrdemServico ";
                        sql += "FROM Usuario ";

                        _DT = conexao.Consulta(sql);

                        if (_DT.Rows.Count > 0)
                        {
                            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            {
                                cmd = new SqlCommand();

                                sql = "INSERT INTO Usuario_Param ";
                                sql += "(ID_Usuario, Comissao, Pedido, Orca, OrdemServico) ";
                                sql += "VALUES  ";
                                sql += "(@ID_Usuario, @Comissao, @Pedido, @Orca, @OrdemServico) ";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@ID_Usuario", _DT.Rows[i]["ID_Usuario"]);
                                cmd.Parameters.AddWithValue("@Comissao", "True");
                                cmd.Parameters.AddWithValue("@Pedido", _DT.Rows[i]["Pedido"]);
                                cmd.Parameters.AddWithValue("@Orca", _DT.Rows[i]["Orca"]);
                                cmd.Parameters.AddWithValue("@OrdemServico", _DT.Rows[i]["OrdemServico"]);

                                conexao.Executa_Comando(cmd);
                            }
                        }

                        cmd = new SqlCommand();

                        sql = "ALTER TABLE Usuario DROP COLUMN TipoUsuario, Pedido, Orca, OrdemServico, Situacao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Usuario ADD Situacao bit";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Usuario SET Situacao = 'true'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 136
                    //VERSÃO 136 - 09/02/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Cheque_Historico)
                    case 136:
                        sql = "DROP VIEW V_Cheque_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 137
                    //VERSÃO 137 - 10/02/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Cheque_Historico)
                    case 137:
                        sql = "DROP VIEW V_Cheque_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 138
                    //VERSÃO 138 - 10/02/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Parametro_Sistema)
                    case 138:
                        sql = "ALTER TABLE Parametro_Sistema ADD ID_ContaTransValor int, ID_ContaDevolucaoCheque int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ID_ContaTransValor = 0, ID_ContaDevolucaoCheque = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 139
                    //VERSÃO 139 - 10/02/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Cheque_Historico)
                    case 139:
                        sql = "DROP VIEW V_Cheque_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.ID AS ID_CPagar, 0 AS ID_CReceber, CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT 0 AS ID_CPagar, CR.ID AS ID_CReceber, CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 140
                    //VERSÃO 140 - 17/02/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Parametro_Sistema)
                    //- CRIAÇÃO TABELA (Imposto, Imposto_Tributacao, Imposto_UF)
                    case 140:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "AmbienteNFe int, ";
                        sql += "RegimeTributario int, ";
                        sql += "Exibe_msgCreditoICMS bit, ";
                        sql += "AliquotaCreditoICMS decimal(10,2), ";
                        sql += "Caminho_NFe nvarchar(200), ";
                        sql += "Exibe_Desconto bit, ";
                        sql += "Exibe_InfoProduto bit, ";
                        sql += "Certificado_NFe nvarchar(200), ";
                        sql += "Tipo_NFe_Venda int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "AmbienteNFe = 0, ";
                        sql += "RegimeTributario = 0, ";
                        sql += "Exibe_msgCreditoICMS = 'false', ";
                        sql += "AliquotaCreditoICMS = '0.00', ";
                        sql += "Exibe_Desconto = 'false', ";
                        sql += "Exibe_InfoProduto = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Imposto', 'Imposto_old' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'ImpostoControle', 'ImpostoControle_old' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imposto( ";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "Descricao nvarchar(60)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imposto_Tributacao( ";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Imposto int, ";
                        sql += "Tipo_NF int, ";
                        sql += "CFOP nvarchar(4), ";
                        sql += "CST int, ";
                        sql += "Origem int, ";
                        sql += "ModalidadeBC int, ";
                        sql += "AliquotaICMS decimal(10, 2), ";
                        sql += "PercentualReducao decimal(10, 2), ";
                        sql += "ModalidadeBCST int, ";
                        sql += "AliquotaICMSST decimal(10, 2), ";
                        sql += "PercentualReducaoST decimal(10, 2), ";
                        sql += "MargemVAdicionado decimal(10, 2), ";
                        sql += "vICMSDeson decimal(10, 2), ";
                        sql += "vICMSOp decimal(10, 2), ";
                        sql += "pDif decimal(10, 2), ";
                        sql += "vICMSDif decimal(10, 2), ";
                        sql += "CSTPIS int, ";
                        sql += "AliquotaPIS decimal(10, 2), ";
                        sql += "AliquotaPISST decimal(10, 2), ";
                        sql += "CSTCOFINS int, ";
                        sql += "AliquotaCOFINS decimal(10, 2), ";
                        sql += "AliquotaCOFINSST decimal(10, 2), ";
                        sql += "CSTIPI int, ";
                        sql += "AliquotaIPI decimal(10, 2), ";
                        sql += "Cod_Enquadramento nchar(3)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Imposto_UF( ";
                        sql += "ID_Tributacao int, ";
                        sql += "ID_UF int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 141
                    //VERSÃO 141 - 13/03/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (NOTA FISCAL)
                    case 141:
                        sql = "ALTER TABLE NotaFiscal ADD ";
                        sql += "ValorICMSDesonerado decimal(15,2), ";
                        sql += "ConsumidorFinal bit, ";
                        sql += "PresencaConsumidor int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal SET ";
                        sql += "ValorICMSDesonerado = '0', ";
                        sql += "ConsumidorFinal = 'false', ";
                        sql += "PresencaConsumidor = 1 ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 142
                    //VERSÃO 142 - 14/03/2015
                    //ALTERAÇÕES:
                    //- CRIAÇÃO TABELA NOTA FISCAL AUTORIZAXML
                    //- ALTERAÇÃO DE TABELA (NOTA FISCAL)
                    case 142:
                        sql = "CREATE TABLE NotaFiscal_AutXML ( ";
                        sql += "ID int identity primary key, ";
                        sql += "ID_NF int, ";
                        sql += "CNPJ_CPF nvarchar(18))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ADD ";
                        sql += "ValorICMSOperacao decimal(15,2), ";
                        sql += "PercentualDiferimento decimal(15,2), ";
                        sql += "ValorICMSDeferido decimal(15,2), ";
                        sql += "ValorICMSDesonerado decimal(15,2), ";
                        sql += "MotivoDesonerado int, ";
                        sql += "IPIDevolvido decimal(15,2), ";
                        sql += "Per_IPIDevolvido decimal(15,2) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal_Item SET ";
                        sql += "ValorICMSOperacao = '0', ";
                        sql += "PercentualDiferimento = '0', ";
                        sql += "ValorICMSDeferido = '0', ";
                        sql += "ValorICMSDesonerado = '0', ";
                        sql += "MotivoDesonerado = 0, ";
                        sql += "IPIDevolvido = '0', ";
                        sql += "Per_IPIDevolvido = '0' ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 143
                    //VERSÃO 143 - 21/03/2015
                    //ALTERAÇÕES:
                    //- CRIAÇÃO VIEW V_Produto_Imposto, V_Pedido_Item_Imposto
                    case 143:
                        sql = "CREATE VIEW V_Produto_Imposto AS ";
                        sql += "SELECT ";
                        sql += "P.ID AS ID_Produto, P.Tipo,P.MultiEmpresa, P.GrupoNivel, P.Descricao, P.Referencia, P.Fabricante, ";
                        sql += "P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.Frete, P.OutrosCustos, ";
                        sql += "P.ICMS, P.PIS, P.Cofins, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Situacao, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PI.ID AS ID_Imposto_Produto, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, PV.ValorMinimo, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "IM.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, ";
                        sql += "I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, I.AliquotaPISST, I.CSTCOFINS, ";
                        sql += "I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, ";
                        sql += "IUF.ID_UF ";
                        sql += "FROM ";
                        sql += "Produto AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Imposto AS PI ON P.ID = PI.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PI.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PI.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item_Imposto AS ";
                        sql += "SELECT ";
                        sql += "PVI.ID_Pedido, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo, PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, ";
                        sql += "PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "IM.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, ";
                        sql += "I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, I.AliquotaPISST, I.CSTCOFINS, ";
                        sql += "I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM ";
                        sql += "V_Pedido_Item AS PVI ";
                        sql += "INNER JOIN Produto as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Imposto AS PI ON PVI.ID_Produto = PI.ID_Produto ";
                        sql += "inner join Imposto AS IM ON PI.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PI.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Pedido as VP ON PVi.ID_Pedido = VP.ID_Pedido AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DELETE FROM Produto_Imposto; TRUNCATE TABLE Produto_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ControleChequeFinanceiro";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE NotaFiscal_XML";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 144
                    //VERSÃO 141 - 14/04/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (PessoaFuncionario)
                    case 144:
                        sql = "ALTER TABLE PessoaFuncionario ALTER COLUMN PIS nvarchar(15)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 145
                    //VERSÃO 145 - 14/04/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Cheque_Historico)
                    case 145:
                        sql = "DROP VIEW V_Cheque_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.ID AS ID_CPagar, 0 AS ID_CReceber, CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT 0 AS ID_CPagar, CR.ID AS ID_CReceber, CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 146
                    //VERSÃO 146 - 15/04/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Pedido_ResumoPagto)
                    case 146:
                        sql = "DROP VIEW V_Pedido_ResumoPagto ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, CR.Vencimento AS Data, CR.Total AS Credito ";
                        sql += "FROM V_Pedido AS PV ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 147
                    //VERSÃO 147 - 25/05/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELAS E VIEW(Produto_Estoque, Produto_Servico, Produto_Parametro, V_Produto_Imposto, V_Produto_Venda,
                    //V_Pedido_Item, V_Orcamento_Item, V_Produto_Imposto)
                    //- CRIAÇÃO TABELA Produto_Estrutura
                    case 147:
                        sql = "EXEC sp_rename 'Produto', 'Produto_Servico' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Imposto', 'Produto_Parametro' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Servico.ID_GrupoNivel', 'ID_Grupo', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Estoque ADD Localizacao nvarchar(60), ID_Empresa int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Servico ADD Controle_Estoque bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Parametro ADD ID_Empresa int, Ativo bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET OutrosCustos = (OutrosCustos + Frete), Controle_Estoque = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Estoque SET Localizacao = (SELECT Localizacao FROM Produto_Servico WHERE (Produto_estoque.ID_Produto = Produto_Servico.ID)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Parametro SET Ativo = (SELECT Ativo FROM Produto_Servico WHERE (Produto_Parametro.ID_Produto = Produto_Servico.ID)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Estoque set ID_Empresa = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Parametro set ID_Empresa = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Servico DROP COLUMN Frete, ICMS, PIS, COFINS, Ativo, Localizacao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Produto_Estrutura( ";
                        sql += "ID int IDENTITY(1,1) NOT NULL, ";
                        sql += "ID_Produto int NULL, ";
                        sql += "ID_Produto_Estrutura int NULL, ";
                        sql += "ID_Grade_Estrutura int NULL, ";
                        sql += "Quantidade decimal(10,3) NULL, ";
                        sql += "Vlr_Custo decimal (10,2) null) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);


                        sql = "CREATE VIEW Produto AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.ClasseEnquadramento, P.CNPJProdutor, P.PesoB, P.PesoL, P.ValorIPI, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN GrupoSimples AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Imposto AS  ";
                        sql += "SELECT P.ID AS ID_Produto, P.Tipo, P.ID_Grupo, P.Descricao, P.Referencia, ";
                        sql += "P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, ";
                        sql += "P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.UnidadeTributavel, P.Validade, ";
                        sql += "P.Garantia, P.Situacao, P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID AS ID_Imposto_Produto, PP.ID_Empresa, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, ";
                        sql += "I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, ";
                        sql += "I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, IUF.ID_UF ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Venda AS ";
                        sql += "SELECT P.ID,  P.ID_Empresa, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Cod_Grupo, ";
                        sql += "P.Ativo, P.Tipo, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta ";
                        sql += "FROM Produto AS P ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoSimples AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);


                        sql = "DROP VIEW V_Orcamento_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN GrupoSimples AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Pedido, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Pedido_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Pedido as VP ON PVi.ID_Pedido = VP.ID_Pedido AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 148
                    //VERSÃO 148 - 27/05/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(NotaFiscal)
                    case 148:
                        sql = "ALTER TABLE NotaFiscal ADD Modelo int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal SET Modelo = 55 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 149
                    //VERSÃO 149 - 28/05/2015
                    //ALTERAÇÕES:
                    //- CONFIGURAÇÃO DE INDEX
                    case 149:
                        sql = "CREATE INDEX I_ID_Imposto ON Imposto_Tributacao (ID_Imposto); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Tributacao ON Imposto_UF (ID_Tributacao); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_UF ON Imposto_UF (ID_UF); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Produto_Valor (ID_Produto); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto ON Produto_Estrutura (ID_Produto); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Produto_Estrutura ON Produto_Estrutura (ID_Produto_Estrutura); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE INDEX I_ID_Grade_Estrutura ON Produto_Estrutura (ID_Grade_Estrutura); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 150
                    //VERSÃO 150 - 09/06/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(NCM)
                    case 150:
                        sql = " EXEC sp_rename 'NCM.AliqNac', 'AliqNacFederal', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = " EXEC sp_rename 'NCM.AliqImp', 'AliqImpFederal', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NCM ADD  EX int, AliqEstadual decimal(4,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NCM SET  EX = 0, AliqEstadual = '0' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET EX_TIPI = NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Servico ALTER COLUMN EX_TIPI int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET EX_TIPI = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal_Item SET EX_TIPI = NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN EX_TIPI int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal_Item SET EX_TIPI = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion  #region 148
                    #region 151
                    //VERSÃO 151 - 11/06/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(Parametro)
                    case 151:
                        sql = "ALTER TABLE Parametro_Sistema ADD ID_ConsumidorFinal int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ID_ConsumidorFinal = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 152
                    //VERSÃO 152 - 24/06/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW(V_Pedido_ResumoPagto)
                    case 152:
                        sql = "DROP VIEW V_Pedido_ResumoPagto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Pedido, CR.Vencimento AS Data, CR.Total AS Credito, ";
                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN CR.Total ";
                        sql += "END AS ValorPago ";
                        sql += "FROM V_Pedido AS PV ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_Pedido = PV.ID_Pedido ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 153
                    //VERSÃO 153 - 12/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(Parametro_Sistema)
                    case 153:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "ID_TabelaVenda int, ";
                        sql += "TipoEquipamentoSAT int, ";
                        sql += "SenhaAtivacaoSAT nvarchar(32) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "ID_TabelaVenda = 0, ";
                        sql += "TipoEquipamentoSAT = 0, ";
                        sql += "SenhaAtivacaoSAT = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 154
                    //VERSÃO 154 - 17/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(NotaFiscal)
                    case 154:
                        sql = "ALTER TABLE NotaFiscal ADD ";
                        sql += "CNPJ_CPF_Destinatario varchar(18), ";
                        sql += "Chave varchar(50), ";
                        sql += "QRCode_CFe text ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 155
                    //VERSÃO 155 - 20/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(NotaFiscal)
                    case 155:
                        sql = "ALTER TABLE NotaFiscal ADD ";
                        sql += "Trib_Federal decimal(10, 2), ";
                        sql += "Trib_Estadual decimal(10, 2), ";
                        sql += "Trib_Municipal decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal SET ";
                        sql += "Trib_Federal = 0, ";
                        sql += "Trib_Estadual = 0, ";
                        sql += "Trib_Municipal = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'NotaFiscal.ID_Pedido', 'ID_Venda', 'COLUMN'; ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 156
                    //VERSÃO 156 - 21/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(NotaFiscal)
                    case 156:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "AssinaturaSAT nvarchar(344) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "AssinaturaSAT = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 157
                    //VERSÃO 157 - 21/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(Parametro_Sistema)
                    case 157:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Consulta_Grade int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Consulta_Grade = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 158
                    //VERSÃO 158 - 22/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(Parametro_Sistema)
                    case 158:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "TipoImpressoraTermica int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "TipoImpressoraTermica = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 159
                    //VERSÃO 159 - 24/07/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA(Produto_Servico)
                    //- CRIAÇÃO DE TABELA(Ordem_Servico, Ordem_Servico_Item)
                    //- CRIAÇÃO DE VIEW(V_Ordem_Servico, V_Ordem_Servico_Item)
                    case 159:
                        sql = "UPDATE Produto_Servico SET ";
                        sql += "ValorIPI = 0 ";
                        sql += "WHERE ValorIPI IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CReceber ADD ID_OS int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Ordem_Servico ( ";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "TipoPessoa int, ";
                        sql += "ID_Pessoa int, ";
                        sql += "Data_Abertura datetime, ";
                        sql += "Data_Orcamento datetime, ";
                        sql += "Data_Aprovacao datetime, ";
                        sql += "Data_Montagem datetime, ";
                        sql += "Data_Pronta datetime, ";
                        sql += "Data_Entrega datetime, ";
                        sql += "Garantia bit, ";
                        sql += "Reclamacao nvarchar(1000), ";
                        sql += "Observacao nvarchar(1000), ";
                        sql += "TipoAtendimento int, ";
                        sql += "Tipo_Equipamento int, ";
                        sql += "Marca int, ";
                        sql += "Info_Equip_1 nvarchar(60), ";
                        sql += "Info_Equip_2 nvarchar(60), ";
                        sql += "Info_Equip_3 nvarchar(60), ";
                        sql += "Obs_Equip_1 nvarchar(200), ";
                        sql += "Obs_Equip_2 nvarchar(200), ";
                        sql += "Status_OS int, ";
                        sql += "ID_UsuarioComissao1 int, ";
                        sql += "ID_UsuarioComissao2 int, ";
                        sql += "Faturado bit, ";
                        sql += "NFe bit, ";
                        sql += "Cancelado bit) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Ordem_Servico_Item(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_OS int, ";
                        sql += "ID_Produto int, ";
                        sql += "Quantidade decimal(9, 3), ";
                        sql += "ID_Tabela int, ";
                        sql += "ValorProduto decimal(10, 2), ";
                        sql += "ValorVenda decimal(10, 2), ";
                        sql += "Informacao nvarchar(100), ";
                        sql += "TipoSaida int, ";
                        sql += "ID_Grade int, ";
                        sql += "ValorCusto decimal(10, 2), ";
                        sql += "Quantidade_Entregue decimal(10, 2))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico AS ";
                        sql += "SELECT OS.ID AS ID_OS, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, ";
                        sql += "(OS.Info_Equip_1 + ' / ' + OS.Info_Equip_2 + ' / ' + OS.Info_Equip_3) AS InformacaoCompleta, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, ";
                        sql += "CASE OS.Status_OS ";
                        sql += "WHEN 1 THEN 'ABERTA' ";
                        sql += "WHEN 2 THEN 'EM ORÇAMENTO' ";
                        sql += "WHEN 3 THEN 'APROVADO' ";
                        sql += "WHEN 4 THEN 'MONTAGEM' ";
                        sql += "WHEN 5 THEN 'PRONTO' ";
                        sql += "WHEN 6 THEN 'FINALIZADO' ";
                        sql += "END AS DescricaoStatus, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "SUM(OSI.Quantidade * OSI.ValorVenda) AS ValorTotal, SUM(OSI.Quantidade * OSI.ValorCusto) AS CustoTotal, ";
                        sql += "GA.Descricao AS DescricaoAtendimento, ";
                        sql += "GE.Descricao AS DescricaoEquipamento, ";
                        sql += "GM.Descricao AS DescricaoMarca ";
                        sql += "FROM Ordem_Servico AS OS ";
                        sql += "LEFT OUTER JOIN Ordem_Servico_Item AS OSI ON OSI.ID_OS = OS.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GA ON OS.TipoAtendimento = GA.ID ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GE ON OS.Tipo_Equipamento = GE.ID ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GM ON OS.Marca = GM.ID ";
                        sql += "WHERE (NOT (OS.ID IS NULL)) ";
                        sql += "GROUP BY OS.ID, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao, GA.Descricao, GE.Descricao, GM.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item AS ";
                        sql += "SELECT OS.ID AS IDItem, OS.ID_OS, OS.ID_Produto, OS.Quantidade, OS.ID_Tabela, ";
                        sql += "OS.ValorProduto, OS.ValorVenda, OS.ValorCusto, (OS.ValorVenda * OS.Quantidade) AS ValorTotal, OS.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "OS.TipoSaida, OS.ID_Grade, OS.Quantidade_Entregue, ";
                        sql += "CASE OS.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Ordem_Servico_Item AS OS ";
                        sql += "INNER JOIN Grade AS G ON G.ID = OS.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = OS.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_CReceber ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Pedido, C.ID_OS, C.ID_PrevisaoPagto, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto, ";
                        sql += "TP.Descricao AS PrevisaoPagto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "LEFT JOIN Pagamento AS TP ON TP.ID = C.ID_PrevisaoPagto ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Descricao_Info1 nvarchar(60), ";
                        sql += "Descricao_Info2 nvarchar(60), ";
                        sql += "Descricao_Info3 nvarchar(60), ";
                        sql += "Descricao_Obs1 nvarchar(60), ";
                        sql += "Descricao_Obs2 nvarchar(60), ";
                        sql += "ID_ContaFaturaVenda int, ";
                        sql += "ID_ContaFaturaOS int, ";
                        sql += "ID_ContaFaturaCompra int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "ID_ContaFaturaVenda = 0, ";
                        sql += "ID_ContaFaturaOS = 0, ";
                        sql += "ID_ContaFaturaCompra = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 160
                    //VERSÃO 160 - 06/08/2015
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW(V_Ordem_Servico_Item_Imposto)
                    case 160:
                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Pedido as VP ON OSI.ID_OS = VP.ID_Pedido AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "TipoImpressoraTermica = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 161
                    //VERSÃO 161 - 08/09/2015
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW(V_Pedido_Item_Imposto_CF)
                    case 161:
                        sql = "CREATE VIEW V_Pedido_Item_Imposto_CF AS ";
                        sql += "SELECT PVI.ID_Pedido, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Pedido_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Pedido as VP ON PVI.ID_Pedido = VP.ID_Pedido AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 162
                    //VERSÃO 161 - 01/10/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (Produto)
                    //- CRIAR VIEW (V_Produto_Servico)
                    case 162:
                        sql = "ALTER TABLE Produto_Servico ADD ProdutoEspecifico bit, Cod_ANP int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Servico DROP COLUMN CodigoEnquadramento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET ProdutoEspecifico = 'false'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW Produto AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.ValorIPI, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN GrupoSimples AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.ValorIPI, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN GrupoSimples AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Imposto AS  ";
                        sql += "SELECT P.ID AS ID_Produto, P.Tipo, P.ID_Grupo, P.Descricao, P.Referencia, ";
                        sql += "P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, ";
                        sql += "P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.UnidadeTributavel, P.Validade, ";
                        sql += "P.Garantia, P.Situacao, P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, ";
                        sql += "PP.ID AS ID_Imposto_Produto, PP.ID_Empresa, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, ";
                        sql += "I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, ";
                        sql += "I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, IUF.ID_UF ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Pedido, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.ProdutoEspecifico, P.Cod_ANP, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Pedido_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Pedido as VP ON PVi.ID_Pedido = VP.ID_Pedido AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 163
                    //VERSÃO 163 - 01/10/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA (Produto_Servico)
                    case 163:
                        sql = "UPDATE Produto_Servico SET Cod_ANP = 0";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 164
                    //VERSÃO 164 - 07/10/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA (Notafiscal_Transporte)
                    case 164:
                        sql = "ALTER TABLE NotaFiscal_Transporte ADD UFPlaca nvarchar(2), Placa nvarchar(8)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal_Transporte SET UFPlaca = '', Placa = ''";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion                
                    #region 165
                    //VERSÃO 165 - 02/11/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (V_Pedido_Item)
                    case 165:
                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Pedido_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Pedido, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, P.Barra, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Pedido_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 166
                    //VERSÃO 166 - 05/11/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO ATUALIZAÇÕES PEDIDO PARA VENDA
                    case 166:
                        sql = "DROP VIEW V_Pedido ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_ResumoPagto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_CReceber ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda_PessoaInativo ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Movimento";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido', 'Venda' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pedido_Item', 'Venda_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Venda_Item.ID_Pedido', 'ID_Venda', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Venda DROP COLUMN ID_UsuarioComissao3, Situacao, Tipo ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'CReceber.ID_Pedido', 'ID_Venda', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado ";
                        sql += "FROM Venda AS PV INNER JOIN ";
                        sql += "Venda_Item AS PI ON PI.ID_Venda = PV.ID LEFT OUTER JOIN ";
                        sql += "Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa LEFT OUTER JOIN ";
                        sql += "PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' LEFT OUTER JOIN ";
                        sql += "Municipios AS M ON PEND.ID_Municipio = M.ID LEFT OUTER JOIN ";
                        sql += "UF ON M.ID_UF = UF.ID_UF LEFT OUTER JOIN ";
                        sql += "Pagamento AS PG ON PV.ID_Pagamento = PG.ID LEFT OUTER JOIN ";
                        sql += "Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Venda, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, PV.Quantidade_Entregue, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, P.Barra, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Venda_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.ProdutoEspecifico, P.Cod_ANP, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVi.ID_Venda = VP.ID_Venda AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Venda, C.ID_OS, C.ID_PrevisaoPagto, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto, ";
                        sql += "TP.Descricao AS PrevisaoPagto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "LEFT JOIN Pagamento AS TP ON TP.ID = C.ID_PrevisaoPagto ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Venda, CR.Vencimento AS Data, CR.Total AS Credito, ";
                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN CR.Total ";
                        sql += "END AS ValorPago ";
                        sql += "FROM V_Venda AS PV ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_Venda = PV.ID_Venda ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Pedido_Item_Imposto_CF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item_Imposto_CF AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVI.ID_Venda = VP.ID_Venda AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_PessoaInativo AS ";
                        sql += "SELECT P.TipoPessoa, P.ID_Pessoa, P.Nome_Razao, P.NomeFantasia, P.Contato, P.Informacao, P.Situacao, ";
                        sql += "PE.ID as ID_Venda, PE.Data, PE.DataFatura, PE.Faturado, PE.Cancelado, PE.NFe, ";
                        sql += "CONVERT(VARCHAR, DATEDIFF(DAY, PE.Data, GETDATE())) as TempoCompra, ";
                        sql += "PC.ID_Usuario AS ID_UsuarioComissao1 ";
                        sql += "FROM Pessoa AS P ";
                        sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN Venda AS PE ON P.ID_Pessoa = PE.ID_Pessoa AND P.TipoPessoa = PE.TipoPessoa ";
                        sql += "INNER JOIN (SELECT PP.ID_Pessoa, MAX(PP.ID) AS ID_P FROM Venda AS PP GROUP BY PP.ID_Pessoa) AS Tab_Venda ON Tab_Venda.ID_P = PE.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Movimento AS ";
                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "Produto.Descricao, Produto.Referencia, Produto.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Compra AS C ";
                        sql += "INNER JOIN Compra_Item AS CP ON C.ID = CP.ID_Compra ";
                        sql += "INNER JOIN Produto ON Produto.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT P.Data, 'ÚLTIMA VENDA: Nº ' + CAST(P.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "Produto.Descricao, Produto.Referencia, Produto.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Venda AS P ";
                        sql += "INNER JOIN Venda_Item AS PP ON P.ID = PP.ID_Venda ";
                        sql += "INNER JOIN Produto ON Produto.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON P.TipoPessoa = PS.TipoPessoa AND P.ID_Pessoa = PS.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'NotaFiscal_XML') DROP TABLE NotaFiscal_XML";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'ControleChequeFinanceiro') DROP TABLE ControleChequeFinanceiro";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Imposto_old') DROP TABLE Imposto_old";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'ImpostoControle_old') DROP TABLE ImpostoControle_old";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'ChequeSituacao') DROP TABLE ChequeSituacao";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Produto_Imagem') DROP TABLE Produto_Imagem";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal ADD Controle_CF int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 167
                    //VERSÃO 167 - 10/11/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (V_Venda_ResumoPagto)
                    case 167:
                        sql = "DROP VIEW V_Venda_ResumoPagto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, PV.ID_Venda, CR.Vencimento AS Data, CR.Valor AS Credito, ";
                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN CR.Total ";
                        sql += "END AS ValorPago ";
                        sql += "FROM V_Venda AS PV ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_Venda = PV.ID_Venda ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 168
                    //VERSÃO 168 - 11/11/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (V_Venda_ResumoPagto)
                    case 168:
                        sql = "SELECT ";
                        sql += "HistoricoVenda ";
                        sql += "FROM Parametro_Sistema ";
                        sql += "WHERE ";
                        sql += "NOT ID_Empresa IS NULL ";
                        sql += "AND ID_Empresa = 1 ";

                        _DT = new DataTable();
                        int _Dias = 0;
                        _DT = conexao.Consulta(sql);

                        if (_DT.Rows.Count > 0)
                            _Dias = Convert.ToInt32(_DT.Rows[0]["HistoricoVenda"]);

                        sql = "DROP VIEW V_HistoricoVenda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_HistoricoVenda AS ";
                        sql += "SELECT DISTINCT ";
                        sql += "V.ID_Venda AS ID, V.ID_Pessoa, CONVERT(VARCHAR(10), V.Data, 103) AS Data, ";
                        sql += "VI.ID_Tabela, V.ID_Parcelamento, V.Informacao, 0 AS Desconto, V.Comprador, V.ID_UsuarioComissao1 AS ID_Usuario ";
                        sql += "FROM V_Venda AS V ";
                        sql += "INNER JOIN V_Venda_Item AS VI ON V.ID_Venda = VI.ID_Venda ";
                        sql += "WHERE (V.Data >= DATEADD(d, -" + _Dias + ", GETDATE())) ";
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
                        sql += "WHERE (V.Data >= DATEADD(d, -" + _Dias + ", GETDATE())) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 169
                    //VERSÃO 169 - 27/11/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (V_Venda_ResumoPagto)
                    case 169:
                        sql = "ALTER TABLE Venda ADD Situacao_Entrega int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET Situacao_Entrega = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Venda_Item ADD Quantidade_Conferido decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 170
                    //VERSÃO 170 - 16/12/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW (V_Venda, V_Venda_Item, V_OrdemServico_Item_Imposto)
                    case 170:
                        sql = "ALTER TABLE Venda ADD Situacao_Conferencia int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET Situacao_Conferencia = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado, PV.Situacao_Conferencia ";
                        sql += "FROM Venda AS PV INNER JOIN ";
                        sql += "Venda_Item AS PI ON PI.ID_Venda = PV.ID LEFT OUTER JOIN ";
                        sql += "Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa LEFT OUTER JOIN ";
                        sql += "PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' LEFT OUTER JOIN ";
                        sql += "PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' LEFT OUTER JOIN ";
                        sql += "Municipios AS M ON PEND.ID_Municipio = M.ID LEFT OUTER JOIN ";
                        sql += "UF ON M.ID_UF = UF.ID_UF LEFT OUTER JOIN ";
                        sql += "Pagamento AS PG ON PV.ID_Pagamento = PG.ID LEFT OUTER JOIN ";
                        sql += "Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
                        sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Venda, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "PV.Quantidade_Entregue, PV.Quantidade_Conferido, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, P.Barra, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Venda_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Ordem_Servico_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON OSI.ID_OS = VP.ID_Venda AND VP.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 171
                    //VERSÃO 171 - 17/12/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(Parametro_Sistema)
                    case 171:
                        sql = "ALTER TABLE Parametro_Sistema ADD Imprime_OS_Equip bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET Imprime_OS_Equip = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 172
                    //VERSÃO 172 - 18/12/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(NotaFiscal)
                    case 172:
                        sql = "ALTER TABLE NotaFiscal ADD ID_OS int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal SET ID_OS = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 173
                    //VERSÃO 172 - 26/12/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(Venda)
                    case 173:
                        sql = "ALTER TABLE Venda ADD ID_Usuario_Conferencia int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado, PV.ID_Usuario_Conferencia, ";
                        sql += "U.Descricao AS Usuario_Conferencia ";
                        sql += "FROM Venda AS PV ";
                        sql += "INNER JOIN Venda_Item AS PI ON PI.ID_Venda = PV.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                        sql += "LEFT OUTER JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "LEFT OUTER JOIN Usuario AS U ON PV.ID_Usuario_Conferencia = U.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
                        sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia, PV.ID_Usuario_Conferencia, U.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 174
                    //VERSÃO 174 - 31/12/2015
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(Boleto)
                    //- CRIAÇÃO TABELA (Boleto_Remessa)
                    case 174:
                        sql = "ALTER TABLE Boleto ADD Remessa bit, Cancelado bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Boleto SET Remessa = 'true', Cancelado = 'false'  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Boleto_Remessa (";
                        sql += "ID int identity primary key, ";
                        sql += "Emissao datetime, ";
                        sql += "Arquivo nvarchar(20))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Boleto_RemessaControle (";
                        sql += "ID_Remessa int, ";
                        sql += "ID_Boleto int, ";
                        sql += "Movimento int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 175
                    //VERSÃO 174 - 06/01/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(Boleto)
                    case 175:
                        sql = "ALTER TABLE Boleto ADD Tipo_Remessa int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Boleto SET Tipo_Remessa = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Cedente.Instrucao', 'Instrucao_1', 'COLUMN'; ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Cedente ADD instrucao_2 nvarchar(100), DiaProtesto int, Aceite bit, Tipo_Emissao int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Cedente SET DiaProtesto = 0, Aceite = 'false', Tipo_Emissao = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 176
                    //VERSÃO 176 - 08/01/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(Ordem_Servico)
                    case 176:
                        sql = "DROP VIEW V_Ordem_Servico_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND VP.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 177
                    //VERSÃO 177 - 10/01/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(V_Produto_Venda)
                    case 177:
                        sql = "DROP VIEW V_Produto_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Venda AS ";
                        sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
                        sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN GrupoSimples AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 178
                    //VERSÃO 178 - 12/01/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE(V_Produto_Venda)
                    case 178:
                        sql = "UPDATE Venda_Item SET Quantidade_Conferido = 0 WHERE Quantidade_Conferido IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Servico ADD ValorST decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET ValorST = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Compra_Item ADD ValorST decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Compra_Item SET ValorST = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Movimento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Movimento AS ";
                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Compra AS C ";
                        sql += "INNER JOIN Compra_Item AS CP ON C.ID = CP.ID_Compra ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT V.Data, 'ÚLTIMA VENDA: Nº ' + CAST(V.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Venda AS V ";
                        sql += "INNER JOIN Venda_Item AS PP ON V.ID = PP.ID_Venda ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON V.TipoPessoa = PS.TipoPessoa AND V.ID_Pessoa = PS.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Venda AS ";
                        sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
                        sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN GrupoSimples AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Servico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN GrupoSimples AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Imposto AS  ";
                        sql += "SELECT P.ID AS ID_Produto, P.Tipo, P.ID_Grupo, P.Descricao, P.Referencia, ";
                        sql += "P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, ";
                        sql += "P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.ValorST, P.UnidadeTributavel, P.Validade, ";
                        sql += "P.Garantia, P.Situacao, P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, ";
                        sql += "PP.ID AS ID_Imposto_Produto, PP.ID_Empresa, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, ";
                        sql += "I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, ";
                        sql += "I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, IUF.ID_UF ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 179
                    //VERSÃO 179 - 29/01/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Cheque_Historico)
                    case 179:
                        sql = "DROP VIEW V_Cheque_Historico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.ID AS ID_CPagar, 0 AS ID_CReceber, CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT 0 AS ID_CPagar, CR.ID AS ID_CReceber, CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN GrupoSimples AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Pagamento.Dia_Pagto', 'Dia_Lancamento', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Pagamento_Parc ADD Personalizado bit, Periodo int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pagamento_Parc SET Personalizado = 'true', Periodo = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 180
                    //VERSÃO 180 - 10/02/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Pagamento)
                    case 180:
                        sql = "UPDATE Pagamento SET Tipo = 2 WHERE Tipo = 7 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Cartao (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "ID_Pagamento int, ";
                        sql += "Emissao datetime, ";
                        sql += "Vencimento datetime, ";
                        sql += "Valor decimal(10, 2), ";
                        sql += "QuantidadeParcela int, ";
                        sql += "Parcela int, ";
                        sql += "Baixado bit, ";
                        sql += "Data_Baixa datetime) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Cartao_Controle (";
                        sql += "ID_Cartao int, ";
                        sql += "ID_CReceber int) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 181
                    //VERSÃO 181 - 24/02/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Venda)
                    case 181:
                        sql = "DROP VIEW V_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado, PV.ID_Usuario_Conferencia, PV.Situacao_Conferencia, ";
                        sql += "U.Descricao AS Usuario_Conferencia ";
                        sql += "FROM Venda AS PV ";
                        sql += "INNER JOIN Venda_Item AS PI ON PI.ID_Venda = PV.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                        sql += "LEFT OUTER JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "LEFT OUTER JOIN Usuario AS U ON PV.ID_Usuario_Conferencia = U.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
                        sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia, PV.ID_Usuario_Conferencia, U.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 182
                    //VERSÃO 182 - 26/02/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW (V_Venda)
                    case 182:
                        sql = "ALTER TABLE Pessoa ALTER COLUMN IE_RG varchar(25) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 183
                    //VERSÃO 183 - 02/03/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Cedente)
                    case 183:
                        sql = "ALTER TABLE Cedente ADD Cod_Protesto int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Cedente SET Cod_Protesto = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 184
                    //VERSÃO 184 - 10/03/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Usuario_Param, Parametro_Sistema)
                    case 184:
                        sql = "EXEC sp_rename 'Usuario_Param.Pedido', 'Venda_Restrita', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD Ultimo_Valor bit, Permitir2Vias bit, Agrupar_Produto bit, Descricao_Comissao nvarchar(60), Limite_Desconto decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        _DT = new DataTable();
                        sql = "SELECT ID_Empresa, Item_UltVlr, Ped_Orc_2Vias, PedidoComissao1 FROM ParametroSistema ";

                        _DT = conexao.Consulta(sql);

                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        {
                            sql = "UPDATE Parametro_Sistema SET ";
                            sql += "Ultimo_Valor = '" + _DT.Rows[i]["Item_UltVlr"] + "', ";
                            sql += "Permitir2Vias = '" + _DT.Rows[i]["Ped_Orc_2Vias"] + "', ";
                            sql += "Agrupar_Produto = 'true', ";
                            sql += "Descricao_Comissao = '" + _DT.Rows[i]["PedidoComissao1"] + "', ";
                            sql += "Limite_Desconto = 100 ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = " + _DT.Rows[i]["ID_Empresa"] + " ";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                        }

                        sql = "ALTER TABLE Usuario_Param DROP COLUMN Orca, OrdemServico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 185
                    //VERSÃO 185 - 11/03/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Venda, OS)
                    case 185:
                        sql = "ALTER TABLE Venda ADD CPF_CNPJ nvarchar(18) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET CPF_CNPJ = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Ordem_Servico ADD CPF_CNPJ nvarchar(18) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Ordem_Servico SET CPF_CNPJ = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado, PV.ID_Usuario_Conferencia, PV.CPF_CNPJ, ";
                        sql += "U.Descricao AS Usuario_Conferencia ";
                        sql += "FROM Venda AS PV ";
                        sql += "INNER JOIN Venda_Item AS PI ON PI.ID_Venda = PV.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                        sql += "LEFT OUTER JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "LEFT OUTER JOIN Usuario AS U ON PV.ID_Usuario_Conferencia = U.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
                        sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia, PV.CPF_CNPJ, PV.ID_Usuario_Conferencia, U.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Ordem_Servico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico AS ";
                        sql += "SELECT OS.ID AS ID_OS, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, ";
                        sql += "(OS.Info_Equip_1 + ' / ' + OS.Info_Equip_2 + ' / ' + OS.Info_Equip_3) AS InformacaoCompleta, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, OS.CPF_CNPJ, ";
                        sql += "CASE OS.Status_OS ";
                        sql += "WHEN 1 THEN 'ABERTA' ";
                        sql += "WHEN 2 THEN 'EM ORÇAMENTO' ";
                        sql += "WHEN 3 THEN 'APROVADO' ";
                        sql += "WHEN 4 THEN 'MONTAGEM' ";
                        sql += "WHEN 5 THEN 'PRONTO' ";
                        sql += "WHEN 6 THEN 'FINALIZADO' ";
                        sql += "END AS DescricaoStatus, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "SUM(OSI.Quantidade * OSI.ValorVenda) AS ValorTotal, SUM(OSI.Quantidade * OSI.ValorCusto) AS CustoTotal, ";
                        sql += "GA.Descricao AS DescricaoAtendimento, ";
                        sql += "GE.Descricao AS DescricaoEquipamento, ";
                        sql += "GM.Descricao AS DescricaoMarca ";
                        sql += "FROM Ordem_Servico AS OS ";
                        sql += "LEFT OUTER JOIN Ordem_Servico_Item AS OSI ON OSI.ID_OS = OS.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GA ON OS.TipoAtendimento = GA.ID ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GE ON OS.Tipo_Equipamento = GE.ID ";
                        sql += "LEFT OUTER JOIN GrupoSimples AS GM ON OS.Marca = GM.ID ";
                        sql += "WHERE (NOT (OS.ID IS NULL)) ";
                        sql += "GROUP BY OS.ID, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, OS.CPF_CNPJ, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao, GA.Descricao, GE.Descricao, GM.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 186
                    //VERSÃO 185 - 11/03/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Venda, OS)
                    case 186:
                        sql = "ALTER TABLE Parametro_Sistema ADD Produto_Marca bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Produto_Marca = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 187
                    //VERSÃO 187 - 16/03/2016
                    //ALTERAÇÕES:
                    //- CRIA TABELA (NotaFiscal_Inutilizacao)
                    case 187:
                        sql = " CREATE TABLE NotaFiscal_Inutilizacao (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "Serie int, ";
                        sql += "Numeracao nvarchar(60), ";
                        sql += "Justificativa nvarchar(255), ";
                        sql += "Protocolo nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 188
                    //VERSÃO 188 - 19/03/2016
                    //ALTERAÇÕES:
                    //- CRIA TABELA (Produto_Movimento)
                    case 188:
                        sql = " CREATE TABLE Produto_Movimento (";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "Data datetime, ";
                        sql += "ID_Produto int, ";
                        sql += "Tipo int, ";
                        sql += "Quantidade decimal(10,3), ";
                        sql += "Informacao nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD Bloquear_EstoqueNegativo bit, Msg_EstoqueNegativo bit, Orca_ValorTotal bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Bloquear_EstoqueNegativo = 'false', ";
                        sql += "Msg_EstoqueNegativo = 'false', ";
                        sql += "Orca_ValorTotal = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql += "DROP VIEW V_Produto_Movimento ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Movimento AS ";
                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Compra AS C ";
                        sql += "INNER JOIN Compra_Item AS CP ON C.ID = CP.ID_Compra ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT V.Data, 'ÚLTIMA VENDA: Nº ' + CAST(V.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS Compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Venda AS V ";
                        sql += "INNER JOIN Venda_Item AS PP ON V.ID = PP.ID_Venda ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON V.TipoPessoa = PS.TipoPessoa AND V.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, PM.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 1 ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, NULL AS Compra, PM.Quantidade AS Venda, 'SÁIDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 2 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 189
                    //VERSÃO 189 - 22/03/2016
                    //ALTERAÇÕES:
                    //- CRIA TABELA (Produto_Movimento)
                    case 189:
                        sql = "ALTER TABLE Compra_Item ADD ValorVenda decimal(10, 2), Margem decimal(10, 2), ValorAntigo decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Compra_Item SET ";
                        sql += "ValorVenda = 0, ";
                        sql += "Margem = 0, ";
                        sql += "ValorAntigo = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 190
                    //VERSÃO 190 - 23/03/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA (Parametro_Sistema)
                    case 190:
                        sql = "ALTER TABLE Parametro_Sistema ADD Consulta_RapidaProduto bit, MultiploUsuarioPDV bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Consulta_RapidaProduto = 'false', ";
                        sql += "MultiploUsuarioPDV = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 191
                    //VERSÃO 191 - 31/03/2016
                    //ALTERAÇÕES:
                    //- CRIA TABELA (CEST)
                    case 191:
                        sql = " CREATE TABLE CEST (";
                        sql += "ID int identity primary key, ";
                        sql += "NCM int, ";
                        sql += "CEST int, ";
                        sql += "Descricao nvarchar(200)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 192
                    //VERSÃO 192 - 07/04/2016
                    //ALTERAÇÕES:
                    //- CRIA TABELA (V_Ordem_Servico_Item_Imposto)
                    case 192:
                        sql = "DROP VIEW V_Ordem_Servico_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND VP.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Venda_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.ProdutoEspecifico, P.Cod_ANP, P.NCM, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVi.ID_Venda = VP.ID_Venda AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 193
                    //VERSÃO 193 - 14/04/2016
                    //ALTERAÇÕES:
                    //- ALTERA TABELA (Parametro_Sistema)
                    case 193:
                        sql = "ALTER TABLE Parametro_Sistema ADD CFe_A4 bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "CFe_A4 = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 194
                    //VERSÃO 194 - 03/05/2016
                    //ALTERAÇÕES:
                    //- ALTERA TABELA (NotaFisal, Parametro_Sistema)
                    case 194:
                        sql = "ALTER TABLE Parametro_Sistema ADD Monitor_CFe bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Monitor_CFe = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal ADD Status_CFe int, Retorno_CFe nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal SET ";
                        sql += "Status_CFe = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion                    
                    #region 195
                    //VERSÃO 195 - 05/05/2016
                    //ALTERAÇÕES:
                    //- CRIA VIEW (V_Ordem_Servico_ResumoPagto)
                    case 195:
                        sql = " CREATE VIEW V_Ordem_Servico_ResumoPagto AS ";
                        sql += "SELECT P.Descricao, OS.ID_OS, CR.Vencimento AS Data, ";
                        sql += "CR.Valor AS Credito, ";
                        sql += "CASE CR.Situacao ";
                        sql += "WHEN 1 THEN 0 ";
                        sql += "WHEN 2 THEN CR.Total ";
                        sql += "END AS ValorPago ";
                        sql += "FROM V_Ordem_Servico AS OS ";
                        sql += "INNER JOIN V_CReceber AS CR ON CR.ID_OS = OS.ID_OS ";
                        sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 196
                    //VERSÃO 196 - 12/05/2016
                    //ALTERAÇÕES:
                    //- EXCLUIR TABELAS ANTIGAS
                    case 196:
                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'OrdemServico') DROP TABLE OrdemServico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'OrdemServico_Produto') DROP TABLE OrdemServico_Produto";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'OrdemServico_Servico') DROP TABLE OrdemServico_Servico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'SituacaoBackup') DROP TABLE SituacaoBackup";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'ParametroUsuario') DROP TABLE ParametroUsuario";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Servico') DROP TABLE Servico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Servico_Valor') DROP TABLE Servico_Valor";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Pedido_Mobile') DROP TABLE Pedido_Mobile";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Pedido_Mobile_Item') DROP TABLE Pedido_Mobile_Item";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 197
                    //VERSÃO 197 - 24/05/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW V_Venda_Mobile
                    case 197:
                        sql = "DROP VIEW V_Venda_Mobile ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Mobile AS ";
                        sql += "SELECT ";
                        sql += "VM.ID, VM.ID_Venda, VM.ID_Pessoa, VM.Data, VM.ID_Tabela, VM.Informacao, VM.Desconto, VM.Comprador, ";
                        sql += "P.Nome_Razao AS Descricao, ";
                        sql += "PC.ID_Usuario, ";
                        sql += "U.Descricao AS Usuario, ";
                        sql += "PGP.Descricao AS Pagamento, ";
                        sql += "PG.ID_Pagamento, PG.Parcelamento, PG.ID AS ID_Parcelamento, ";
                        sql += "M.Equipamento, M.IMEI ";
                        sql += "FROM Venda_Mobile AS VM ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = 1 AND P.ID_Pessoa = VM.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID ";
                        sql += "LEFT JOIN Usuario AS U ON PC.ID_Usuario = U.ID ";
                        sql += "LEFT JOIN Mobile AS M ON M.IMEI = VM.IMEI ";
                        sql += "LEFT JOIN Pagamento_Parc AS PG ON VM.ID_Parcelamento = PG.ID ";
                        sql += "LEFT JOIN Pagamento AS PGP ON PG.ID_Pagamento = PGP.ID ";
                        sql += "WHERE ";
                        sql += "NOT VM.ID IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 198
                    //VERSÃO 198 - 01/06/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Usuario_Param
                    case 198:
                        sql = "ALTER TABLE Usuario_Param ADD Libera_Desconto bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Usuario_Param SET ";
                        sql += "Libera_Desconto = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 199
                    //VERSÃO 199 - 11/06/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Usuario_Param
                    case 199:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "NaoAlterarVendaFaturada bit, ";
                        sql += "PagamentoTrocoDevolucao int, ";
                        sql += "ID_ContaDevolucaoVenda int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "NaoAlterarVendaFaturada = 'false', ";
                        sql += "PagamentoTrocoDevolucao = 0, ";
                        sql += "ID_ContaDevolucaoVenda = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 200
                    //VERSÃO 200 - 24/06/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Usuario_Param
                    case 200:
                        sql = "ALTER TABLE Pessoa ADD ";
                        sql += "Desconto_Venda decimal(10, 2), ";
                        sql += "Informacao_Venda nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pessoa SET ";
                        sql += "Desconto_Venda = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 201
                    //VERSÃO 201 - 07/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA UF E CRIAÇÃO TABELA UF_AliquotaICMS
                    case 201:
                        sql = "ALTER TABLE UF ADD ";
                        sql += "Aliquota_Interna decimal(10, 2), ";
                        sql += "Aliquota_FCP decimal(10, 2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE UF SET ";
                        sql += "Aliquota_Interna = 0, ";
                        sql += "Aliquota_FCP = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE UF_AliquotaICMS(";
                        sql += "ID_UF_Origem int, ";
                        sql += "ID_UF_Destino int, ";
                        sql += "Aliquota decimal(10, 2)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 202
                    //VERSÃO 202 - 13/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO ALIQUOTAS ICMS
                    case 202:
                        sql = "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'AC'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'AL'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'AM'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'AP'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'BA'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'CE'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'DF'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'ES'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'GO'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'MA'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'MT'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'MS'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'MG'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'PA'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'PB'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'PR'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'PE'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'PI'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'RN'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'RS'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'RJ'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17.5' WHERE Sigla = 'RO'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'RR'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '17' WHERE Sigla = 'SC'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'SP'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'SE'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '18' WHERE Sigla = 'TO'; ";
                        sql += "UPDATE UF SET Aliquota_Interna = '04' WHERE Sigla = 'EX' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DELETE FROM UF_AliquotaICMS ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('12', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('04', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('27', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('13', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('16', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('29', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('23', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('53', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('32', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('52', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('21', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('31', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('50', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('51', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('15', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('25', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('26', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('22', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('41', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('33', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('24', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('11', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('14', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('43', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('42', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '17', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('28', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '12', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '27', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '13', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '16', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '29', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '23', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '53', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '32', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '52', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '21', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '50', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '51', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '15', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '25', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '26', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '22', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '24', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '11', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '14', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '28', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '17', '07'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('35', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '12', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '27', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '13', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '16', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '29', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '23', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '53', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '32', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '52', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '21', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '31', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '50', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '51', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '15', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '25', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '26', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '22', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '41', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '33', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '24', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '11', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '14', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '43', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '42', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '28', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '35', '12'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('17', '01', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '12', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '27', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '13', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '16', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '29', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '23', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '53', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '32', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '52', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '21', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '31', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '50', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '51', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '15', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '25', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '26', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '22', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '41', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '33', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '24', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '11', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '14', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '43', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '42', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '28', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '35', '04'); ";
                        sql += "INSERT INTO UF_AliquotaICMS(ID_UF_Origem, ID_UF_Destino, Aliquota) VALUES('01', '17', '04'); ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 203
                    //VERSÃO 203 - 16/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA FOLHA DE PAGAMENTOS E EVENTOS
                    case 203:
                        sql = "EXEC sp_rename 'FolhaPagamento', 'FolhaPagto'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Folha_Eventos', 'FolhaPagto_Evento'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Eventos', 'Evento'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'FolhaPagto_Evento.ID_Eventos', 'ID_Evento', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'FolhaPagto_Evento.ID_Folha', 'ID_FolhaPagto', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 204
                    //VERSÃO 204 - 22/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA GRUPO_SIMPLES
                    case 204:
                        sql = "EXEC sp_rename 'GrupoSimples', 'Grupo'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Ordem_Servico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico AS ";
                        sql += "SELECT OS.ID AS ID_OS, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, ";
                        sql += "(OS.Info_Equip_1 + ' / ' + OS.Info_Equip_2 + ' / ' + OS.Info_Equip_3) AS InformacaoCompleta, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, OS.CPF_CNPJ, ";
                        sql += "CASE OS.Status_OS ";
                        sql += "WHEN 1 THEN 'ABERTA' ";
                        sql += "WHEN 2 THEN 'EM ORÇAMENTO' ";
                        sql += "WHEN 3 THEN 'APROVADO' ";
                        sql += "WHEN 4 THEN 'MONTAGEM' ";
                        sql += "WHEN 5 THEN 'PRONTO' ";
                        sql += "WHEN 6 THEN 'FINALIZADO' ";
                        sql += "END AS DescricaoStatus, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "SUM(OSI.Quantidade * OSI.ValorVenda) AS ValorTotal, SUM(OSI.Quantidade * OSI.ValorCusto) AS CustoTotal, ";
                        sql += "GA.Descricao AS DescricaoAtendimento, ";
                        sql += "GE.Descricao AS DescricaoEquipamento, ";
                        sql += "GM.Descricao AS DescricaoMarca ";
                        sql += "FROM Ordem_Servico AS OS ";
                        sql += "LEFT OUTER JOIN Ordem_Servico_Item AS OSI ON OSI.ID_OS = OS.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN Grupo AS GA ON OS.TipoAtendimento = GA.ID ";
                        sql += "LEFT OUTER JOIN Grupo AS GE ON OS.Tipo_Equipamento = GE.ID ";
                        sql += "LEFT OUTER JOIN Grupo AS GM ON OS.Marca = GM.ID ";
                        sql += "WHERE (NOT (OS.ID IS NULL)) ";
                        sql += "GROUP BY OS.ID, OS.ID_Empresa, OS.TipoPessoa, OS.ID_Pessoa, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, ";
                        sql += "OS.Data_Pronta, OS.Data_Entrega, OS.Garantia, OS.Reclamacao, OS.Observacao, OS.TipoAtendimento, ";
                        sql += "OS.Tipo_Equipamento, OS.Marca, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                        sql += "OS.Status_OS, OS.ID_UsuarioComissao1, OS.ID_UsuarioComissao2, OS.CPF_CNPJ, ";
                        sql += "OS.Faturado, OS.NFe,  OS.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao, GA.Descricao, GE.Descricao, GM.Descricao ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Venda";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Venda AS ";
                        sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
                        sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Grupo AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Servico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Cheque_Historico";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Cheque_Historico AS ";
                        sql += "SELECT CP.ID AS ID_CPagar, 0 AS ID_CReceber, CP.Documento, CP.DataBaixa, CP.Descricao, CP.DescricaoPessoa, CP.DescricaoConta, NULL AS Credito, ";
                        sql += "CP.Total AS Debito, FC.ID_Cheque, CP.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CP.ID = fcc.ID_CPagar ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN Grupo AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        sql += "UNION ";
                        sql += "SELECT 0 AS ID_CPagar, CR.ID AS ID_CReceber, CR.Documento, CR.DataBaixa, CR.Descricao, CR.DescricaoPessoa, CR.DescricaoConta, CR.Total AS Credito, ";
                        sql += "NULL AS Debito, FC.ID_Cheque, CR.Total, ";
                        sql += "FC.ID AS ID_FluxoCaixa, FC.Emissao, FC.Caixa AS ID_Caixa, FC.ID_Pagamento, FC.Credito AS CreditoFluxo, FC.Debito as DebitoFluxo, ";
                        sql += "G.Descricao AS DescricaoCaixa, ";
                        sql += "PC.Descricao AS DescricaoContaFluxo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "INNER JOIN FluxoCaixa_Controle AS fcc ON CR.ID = fcc.ID_CReceber ";
                        sql += "INNER JOIN FluxoCaixa AS FC ON fcc.ID_FluxoCaixa = FC.ID ";
                        sql += "INNER JOIN PlanoConta AS PC ON PC.ID = FC.ID_Conta ";
                        sql += "INNER JOIN Grupo AS G ON G.ID = FC.Caixa ";
                        sql += "WHERE (FC.ID_Cheque > 0) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_PessoaMobile ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_PessoaMobile AS ";
                        sql += "SELECT ";
                        sql += "PC.ID, PC.ID_Usuario AS ID_Vendedor, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, ";
                        sql += "GS.Descricao AS DescricaoGrupo, ";
                        sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                        sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                        sql += "PEMAIL.Email, ";
                        sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                        sql += "UF.Sigla AS UF, ";
                        sql += "PA.Descricao AS Pais ";
                        sql += "FROM ";
                        sql += "PessoaCliente AS PC ";
                        sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PC.ID AND PEND.TipoPessoa = 1 AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PC.ID AND PTEL.TipoPessoa = 1 AND PTEL.PrincipalTelefone = 'True'";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PC.ID AND PEMAIL.TipoPessoa = 1 AND PEMAIL.PrincipalEmail = 'True'";
                        sql += "LEFT JOIN Grupo AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                        sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE P.Situacao = 'True' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW Produto AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.ValorIPI, P.Controle_Estoque, P.Imagem, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 205
                    //VERSÃO 205 - 16/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA PARAMETRO_SISTEMA
                    case 205:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "ID_Caixa_Principal int, ";
                        sql += "ID_Conta_PagtoDiverso int, ";
                        sql += "ID_Conta_RectoDiverso int, ";
                        sql += "ID_Conta_CobrancaBancaria int, ";
                        sql += "ID_PagtoBoleto int, ";
                        sql += "SMTP nvarchar(60), ";
                        sql += "Porta int, ";
                        sql += "SSL bit, ";
                        sql += "De nvarchar(60), ";
                        sql += "Usuario nvarchar(60), ";
                        sql += "Senha nvarchar(60), ";
                        sql += "Email nvarchar(60), ";
                        sql += "ClienteDescricao1 nvarchar(60), ";
                        sql += "ClienteDescricao2 nvarchar(60), ";
                        sql += "ClienteDescricao3 nvarchar(60), ";
                        sql += "EmpresaDescricao1 nvarchar(60), ";
                        sql += "EmpresaDescricao2 nvarchar(60), ";
                        sql += "EmpresaDescricao3 nvarchar(60), ";
                        sql += "FornecedorDescricao1 nvarchar(60), ";
                        sql += "FornecedorDescricao2 nvarchar(60), ";
                        sql += "FornecedorDescricao3 nvarchar(60), ";
                        sql += "FuncionarioDescricao1 nvarchar(60), ";
                        sql += "FuncionarioDescricao2 nvarchar(60), ";
                        sql += "FuncionarioDescricao3 nvarchar(60), ";
                        sql += "TransportadoraDescricao1 nvarchar(60), ";
                        sql += "TransportadoraDescricao2 nvarchar(60), ";
                        sql += "TransportadoraDescricao3 nvarchar(60), ";
                        sql += "Info_Produto1 nvarchar(60), ";
                        sql += "Info_Produto2 nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Info_Produto1 = 'INFORMAÇÃO ADICIONAL', ";
                        sql += "Info_Produto2 = 'INFORMAÇÃO ADICIONAL' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        _DT = new DataTable();
                        sql = "SELECT * FROM ParametroSistema ";
                        _DT = conexao.Consulta(sql);

                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        {
                            cmd = new SqlCommand();

                            sql = "UPDATE Parametro_Sistema SET ";
                            sql += "ID_Caixa_Principal = @ID_Caixa_Principal, ";
                            sql += "ID_Conta_PagtoDiverso = @ID_Conta_PagtoDiverso, ";
                            sql += "ID_Conta_RectoDiverso = @ID_Conta_RectoDiverso, ";
                            sql += "ID_Conta_CobrancaBancaria = @ID_Conta_CobrancaBancaria, ";
                            sql += "ID_PagtoBoleto = @ID_PagtoBoleto, ";
                            sql += "SMTP = @SMTP, ";
                            sql += "Porta = @Porta, ";
                            sql += "SSL = @SSL, ";
                            sql += "De = @De, ";
                            sql += "Usuario = @Usuario, ";
                            sql += "Senha = @Senha, ";
                            sql += "Email = @Email, ";
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
                            sql += "TransportadoraDescricao3 = @TransportadoraDescricao3 ";
                            sql += "WHERE ";
                            sql += "ID_Empresa = @ID_Empresa ";

                            cmd.Parameters.AddWithValue("@ID_Empresa", _DT.Rows[i]["ID_Empresa"]);
                            cmd.Parameters.AddWithValue("@SMTP", _DT.Rows[i]["SMTP"]);
                            cmd.Parameters.AddWithValue("@Porta", _DT.Rows[i]["Porta"]);
                            cmd.Parameters.AddWithValue("@SSL", _DT.Rows[i]["SSL"]);
                            cmd.Parameters.AddWithValue("@De", _DT.Rows[i]["De"]);
                            cmd.Parameters.AddWithValue("@Usuario", _DT.Rows[i]["Usuario"]);
                            cmd.Parameters.AddWithValue("@Senha", _DT.Rows[i]["Senha"]);
                            cmd.Parameters.AddWithValue("@Email", _DT.Rows[i]["Email"]);
                            cmd.Parameters.AddWithValue("@ClienteDescricao1", _DT.Rows[i]["ClienteDescricao1"]);
                            cmd.Parameters.AddWithValue("@ClienteDescricao2", _DT.Rows[i]["ClienteDescricao2"]);
                            cmd.Parameters.AddWithValue("@ClienteDescricao3", _DT.Rows[i]["ClienteDescricao3"]);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao1", _DT.Rows[i]["EmpresaDescricao1"]);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao2", _DT.Rows[i]["EmpresaDescricao2"]);
                            cmd.Parameters.AddWithValue("@EmpresaDescricao3", _DT.Rows[i]["EmpresaDescricao3"]);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao1", _DT.Rows[i]["FornecedorDescricao1"]);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao2", _DT.Rows[i]["FornecedorDescricao2"]);
                            cmd.Parameters.AddWithValue("@FornecedorDescricao3", _DT.Rows[i]["FornecedorDescricao3"]);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao1", _DT.Rows[i]["FuncionarioDescricao1"]);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao2", _DT.Rows[i]["FuncionarioDescricao2"]);
                            cmd.Parameters.AddWithValue("@FuncionarioDescricao3", _DT.Rows[i]["FuncionarioDescricao3"]);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao1", _DT.Rows[i]["TransportadoraDescricao1"]);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao2", _DT.Rows[i]["TransportadoraDescricao2"]);
                            cmd.Parameters.AddWithValue("@TransportadoraDescricao3", _DT.Rows[i]["TransportadoraDescricao3"]);
                            cmd.Parameters.AddWithValue("@ID_Caixa_Principal", _DT.Rows[i]["CaixaPrincipal"]);
                            cmd.Parameters.AddWithValue("@ID_Conta_PagtoDiverso", _DT.Rows[i]["ID_ContaPagar"]);
                            cmd.Parameters.AddWithValue("@ID_Conta_RectoDiverso", _DT.Rows[i]["ID_ContaReceber"]);
                            cmd.Parameters.AddWithValue("@ID_Conta_CobrancaBancaria", _DT.Rows[i]["ID_Boleto"]);
                            cmd.Parameters.AddWithValue("@ID_PagtoBoleto", _DT.Rows[i]["CobrancaBancaria"]);

                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                        }

                        cmd = new SqlCommand();

                        sql = "CREATE VIEW V_Planejamento AS ";
                        sql += "SELECT CP.ID_Empresa, CP.Conta, CP.DescricaoConta, CP.DescricaoPessoa, CP.Documento, CP.ResumoParcela, ";
                        sql += "CP.Vencimento, CP.Total AS Debito, 0.0 AS Credito, 0.0 AS Saldo, 'CP' AS Tipo ";
                        sql += "FROM V_CPagar AS CP ";
                        sql += "WHERE CP.Situacao = 1 ";
                        sql += "UNION ";
                        sql += "SELECT CR.ID_Empresa, CR.Conta, CR.DescricaoConta, CR.DescricaoPessoa, CR.Documento, CR.ResumoParcela, ";
                        sql += "CR.Vencimento, 0.0 AS Debito, CR.Total AS Credito, 0.0 AS Saldo, 'CR' AS Tipo ";
                        sql += "FROM V_CReceber AS CR ";
                        sql += "WHERE CR.Situacao = 1 ";
                        sql += "UNION ";
                        sql += "SELECT FC.ID_Empresa, '' AS Conta, 'CHEQUE PRÉ' AS DescricaoConta, Informacao AS DescricaoPessoa, FC.Documento, '' AS ResumoParcela,  ";
                        sql += "FC.Emissao AS Vencimento, FC.Debito, FC.Credito, 0.0 AS Saldo, 'FC' AS Tipo ";
                        sql += "FROM FluxoCaixa AS FC ";
                        sql += "WHERE FC.Planejamento = 'True' AND FC.ID_Cheque > 0 ";
                        sql += "UNION ";
                        sql += "SELECT C.ID_Empresa, '' AS Conta, 'RECEBIMENTO CARTÃO CRÉDITO/DÉBITO' AS DescricaoConta, P.Descricao AS DescricaoPessoa,   '' AS Documento,  ";
                        sql += "CONVERT(varchar(10), C.Parcela) +'/' + CONVERT(varchar(10), C.QuantidadeParcela) AS ResumoParcela, ";
                        sql += "C.Vencimento, 0.0 AS Debito, C.Valor AS Credito, 0.0 AS Saldo, 'CC' AS Tipo ";
                        sql += "FROM Cartao AS C ";
                        sql += "INNER JOIN Pagamento AS P ON C.ID_Pagamento = P.ID ";
                        sql += "WHERE C.Baixado = 'False' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 206
                    //VERSÃO 206 - 26/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW V_ORCAMENTO_ITEM
                    case 206:
                        sql = "DROP VIEW V_Orcamento_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, P.Fabricante AS Marca, P.Referencia, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Grupo AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 207
                    //VERSÃO 207 - 26/07/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA PRODUTO_SERVICO E V_PRODUTO_SERVICO
                    case 207:
                        sql = "ALTER TABLE Produto_Servico ADD ";
                        sql += "InfoAdicional1 nvarchar(60), ";
                        sql += "InfoAdicional2 nvarchar(60), ";
                        sql += "ABC nvarchar(1) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET ";
                        sql += "InfoAdicional1 = '', ";
                        sql += "InfoAdicional2 = '', ";
                        sql += "ABC = 'A'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Produto_Servico ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.Controle_Estoque, P.Imagem, ";
                        sql += "P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 208
                    //VERSÃO 208 - 03/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA NOTAFISCAL_EVENTO
                    case 208:
                        sql = "ALTER TABLE NotaFiscal_Evento ADD ";
                        sql += "Motivo nvarchar(1000), ";
                        sql += "Stat int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE NotaFiscal_Evento SET ";
                        sql += "Motivo = '', ";
                        sql += "Stat = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 209
                    //VERSÃO 209 - 10/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA CEDENTE
                    case 209:
                        sql = "ALTER TABLE Cedente ADD ";
                        sql += "Ativo bit, ";
                        sql += "Tipo_Cobranca int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Cedente SET ";
                        sql += "Ativo = 'true', ";
                        sql += "Tipo_Cobranca = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 210
                    //VERSÃO 210 - 12/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA CEDENTE
                    case 210:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Venda_Matricial bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Venda_Matricial = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 211
                    //VERSÃO 211 - 16/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA CEDENTE
                    case 211:
                        sql = "DROP VIEW V_Venda_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Venda_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Venda, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, ";
                        sql += "PV.ValorProduto, PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "PV.Quantidade_Entregue, PV.Quantidade_Conferido, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, ";
                        sql += "CASE PV.TipoSaida ";
                        sql += "WHEN 0 THEN 'VENDA' ";
                        sql += "WHEN 1 THEN 'TROCA' ";
                        sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                        sql += "WHEN 3 THEN 'COMODATO' ";
                        sql += "END AS DescricaoSaida, ";
                        sql += "P.Fabricante AS Marca, P.Referencia, P.Controle_Estoque, P.Tipo, P.Barra, InfoAdicional1, InfoAdicional2, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto ";
                        sql += "FROM Venda_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 212
                    //VERSÃO 212 - 23/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA PessoaFuncionario
                    case 212:
                        sql = "ALTER TABLE PessoaFuncionario ADD ";
                        sql += "Referencia nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE PessoaFuncionario SET ";
                        sql += "Referencia = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion                    
                    #region 213
                    //VERSÃO 213 - 24/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Parametro_Sistema
                    case 213:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Modelo_Matricial int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Modelo_Matricial = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP TABLE ParametroSistema ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 214
                    //VERSÃO 214 - 31/08/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Usuario_Param
                    //- CRIAÇÃO TABELA Produto_Desconto, Venda_Externo, Venda_Externo_Item
                    case 214:
                        sql = "ALTER TABLE Usuario_Param ADD ";
                        sql += "Venda_Fixa_logado bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Usuario_Param SET ";
                        sql += "Venda_Fixa_logado = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Venda_Externo(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Empresa int, ";
                        sql += "ID_Usuario int,";
                        sql += "Data datetime, ";
                        sql += "Informacao nvarchar(500)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Venda_Externo_Item(";
                        sql += "ID int identity primary key, ";
                        sql += "ID_Venda_Externa int FOREIGN KEY REFERENCES Venda_Externo(ID), ";
                        sql += "ID_Produto int FOREIGN KEY REFERENCES Produto_Servico(ID), ";
                        sql += "Informacao nvarchar(500)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 215
                    //VERSÃO 215 - 01/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Usuario_Param
                    case 215:
                        sql = "ALTER TABLE Usuario_Param ADD ";
                        sql += "Permite_Faturar bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Usuario_Param SET ";
                        sql += "Permite_Faturar = 'true' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS (SELECT * FROM sys.tables WHERE NAME = 'Pedido_Tipo') DROP TABLE Pedido_Tipo";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 216
                    //VERSÃO 216 - 02/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA V_Produto_Venda
                    case 216:
                        sql = "DROP VIEW V_Produto_Venda ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Produto_Venda AS ";
                        sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
                        sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, P.InfoAdicional1, P.InfoAdicional2, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Grupo AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 217
                    //VERSÃO 217 - 06/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA V_Ordem_Servico_Item, V_Ordem_Servico_Item_Imposto
                    case 217:
                        sql = "DROP VIEW V_Ordem_Servico_Item_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND VP.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Ordem_Servico_Item_Imposto_CF AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "DROP VIEW V_Orcamento_Item ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_Orcamento_Item AS ";
                        sql += "SELECT PV.ID AS IDItem, PV.ID_Orcamento, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorProduto, ";
                        sql += "PV.ValorVenda, PV.ValorCusto, (PV.ValorVenda * PV.Quantidade) AS ValorTotal, PV.Informacao, ";
                        sql += "ISNULL((select ValorProduto - ValorVenda WHERE ValorProduto > ValorVenda), 0) AS Desconto, ";
                        sql += "ISNULL((select ValorVenda - ValorProduto WHERE ValorProduto < ValorVenda), 0) AS Acrescimo, ";
                        sql += "PV.TipoSaida, PV.ID_Grade, P.Fabricante AS Marca, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao ";
                        sql += "END AS DescricaoProduto, ";
                        sql += "GP.Descricao AS DescricaoSaida ";
                        sql += "FROM Orcamento_Item AS PV ";
                        sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                        sql += "LEFT JOIN Produto_Servico AS P ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Grupo AS GP ON PV.TipoSaida = GP.ID ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 218
                    //VERSÃO 218 - 12/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Parametro_Sistema
                    case 218:
                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Exibe_DuplicarProduto bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Exibe_DuplicarProduto = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 219
                    //VERSÃO 219 - 12/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA NotaFiscal_Item
                    case 219:
                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN AliquotaICMS decimal(10,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN PercentualReducao decimal(10,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN AliquotaICMSST decimal(10,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN PercentualReducaoST decimal(10,2) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 220
                    //VERSÃO 220 - 14/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Cedente
                    case 220:
                        sql = "ALTER TABLE Cedente ADD Altera_Data Bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Cedente SET Altera_Data = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 221
                    //VERSÃO 221 - 14/09/2016
                    //ALTERAÇÕES:
                    //- CRIAÇÃO TABELAS  Produto_Desconto E Produto_Desconto_Pessoa
                    case 221:
                        sql = "CREATE TABLE Produto_Desconto(";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Empresa int, ";
                        sql += "ID_Produto int,	";
                        sql += "Quantidade_Minima decimal(9, 2), ";
                        sql += "Quantidade_Maxima decimal(9, 2), ";
                        sql += "Desconto decimal(9, 2))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Produto_Desconto_Pessoa(";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Empresa int,";
                        sql += "ID_Produto int, ";
                        sql += "ID_Pessoa int, ";
                        sql += "Desconto decimal(9, 2))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 222
                    //VERSÃO 222 - 22/09/2016
                    //ALTERAÇÕES:
                    //- CRIAÇÃO TABELAS Produto_Desconto_Pessoa
                    case 222:
                        sql = "DROP TABLE Produto_Desconto_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE TABLE Produto_Desconto_Pessoa(";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Empresa int,";
                        sql += "ID_Produto int, ";
                        sql += "TipoPessoa int, ";
                        sql += "ID_Pessoa int, ";
                        sql += "Tipo int, ";
                        sql += "Desconto decimal(9, 2))";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 223
                    //VERSÃO 223 - 24/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÕES DE TABELA Parametro_Sistema, Parametro_Usuario
                    case 223:
                        sql = "ALTER TABLE Parametro_Sistema ADD Desconto_Padrao int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET Desconto_Padrao = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Usuario_Param', 'Parametro_Usuario' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Usuario ADD Permite_AterarFaturado bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Usuario SET Permite_AterarFaturado = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 224
                    //VERSÃO 224 - 25/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÕES DE TABELA Parametro_Usuario
                    case 224:
                        sql = "ALTER TABLE Parametro_Usuario ADD Visualiza_ResumoVenda bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Usuario SET Visualiza_ResumoVenda = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 225
                    //VERSÃO 225 - 28/09/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÕES DE TABELA Compra
                    case 225:
                        sql = "EXEC sp_rename 'Compra', 'Produto_Entrada' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Compra_Item', 'Produto_Entrada_Item' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "EXEC sp_rename 'Produto_Entrada_Item.ID_Compra', 'ID_Produto_Entrada', 'COLUMN'";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Entrada ADD Tipo_Entrada int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Entrada SET Tipo_Entrada = 1 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Produto_Movimento AS ";
                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Produto_Entrada AS C ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE C.Tipo_Entrada = 1 ";
                        sql += "UNION ";
                        sql += "SELECT C.Data, 'ENTRADA PRODUÇÃO: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Produto_Entrada AS C ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE C.Tipo_Entrada = 2 ";
                        sql += "UNION ";
                        sql += "SELECT V.Data, 'ÚLTIMA VENDA: Nº ' + CAST(V.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS Compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Venda AS V ";
                        sql += "INNER JOIN Venda_Item AS PP ON V.ID = PP.ID_Venda ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON V.TipoPessoa = PS.TipoPessoa AND V.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT OS.Data_Entrega AS Data, 'ÚLTIMA OS: Nº ' + CAST(OS.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS Compra, PP.Quantidade_Entregue AS Venda, 'SAÍDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Ordem_Servico AS OS ";
                        sql += "INNER JOIN Ordem_Servico_Item AS PP ON OS.ID = PP.ID_OS ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON OS.TipoPessoa = PS.TipoPessoa AND OS.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE OS.Status_OS = 6 ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, PM.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 1 ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, NULL AS Compra, PM.Quantidade AS Venda, 'SÁIDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 2 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 226
                    //VERSÃO 226 - 29/09/2016
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW V_Produto_Entrada, V_Produto_Entrada_Item
                    case 226:
                        sql = "CREATE VIEW V_Produto_Entrada AS ";
                        sql += "SELECT PE.ID AS ID_Entrada, PE.ID_Empresa, PE.TipoPessoa, PE.ID_Pessoa, PE.Tipo_Entrada, ";
                        sql += "CASE PE.Tipo_Entrada ";
                        sql += "WHEN 1 THEN 'COMPRA DE PRODUTO' ";
                        sql += "WHEN 2 THEN 'ENTRADA PRODUÇÃO' ";
                        sql += "END AS Descricao_Tipo_Entrada, ";
                        sql += "PE.Data, PE.Entrega, PE.Informacao, PE.Faturado, PE.Documento, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, ";
                        sql += "UF.ID_UF, SUM(PI.Quantidade * (PI.ValorCompra + PI.ValorIPI + PI.ValorST)) AS CustoTotal ";
                        sql += "FROM Produto_Entrada AS PE ";
                        sql += "INNER JOIN Produto_Entrada_Item AS PI ON PI.ID_Produto_Entrada = PE.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PE.TipoPessoa AND P.ID_Pessoa = PE.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "GROUP BY PE.ID, PE.ID_Empresa, PE.TipoPessoa, PE.ID_Pessoa,PE.Tipo_Entrada, PE.Data, PE.Entrega, PE.Informacao, ";
                        sql += "PE.Faturado, PE.Documento, P.Nome_Razao, P.NomeFantasia, UF.Sigla, UF.ID_UF, M.Descricao";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Entrada_Item DROP COLUMN CustoFinal, Frete ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 227
                    //VERSÃO 227 - 06/10/2016
                    //ALTERAÇÕES:
                    //- CRIAÇÃO DE VIEW V_Produto_Entrada, V_Produto_Entrada_Item
                    case 227:
                        sql = "ALTER VIEW V_Orcamento AS ";
                        sql += "SELECT O.ID AS ID_Orcamento, O.ID_Empresa, O.TipoPessoa, O.ID_Pessoa, O.Data, O.Informacao, ";
                        sql += "O.ID_UsuarioComissao1, O.ID_UsuarioComissao2, O.ID_UsuarioComissao3, ";
                        sql += "P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, ";
                        sql += "UPPER(M.Descricao) + '-' + UF.Sigla AS Municipio, UF.ID_UF, ";
                        sql += "SUM(OI.Quantidade * OI.ValorVenda) AS ValorTotal, SUM(OI.Quantidade * OI.ValorCusto) AS CustoTotal ";
                        sql += "FROM Orcamento AS O ";
                        sql += "INNER JOIN Orcamento_Item AS OI ON OI.ID_Orcamento = O.ID ";
                        sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = O.TipoPessoa AND P.ID_Pessoa = O.ID_Pessoa ";
                        sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "WHERE NOT O.ID IS NULL ";
                        sql += "GROUP BY O.ID, O.ID_Empresa, O.TipoPessoa, O.ID_Pessoa, O.Data, O.Informacao, ";
                        sql += "O.ID_UsuarioComissao1, O.ID_UsuarioComissao2, O.ID_UsuarioComissao3, ";
                        sql += "P.Nome_Razao, P.NomeFantasia, M.Descricao, UF.ID_UF, UF.Sigla ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Venda AS ";
                        sql += "SELECT PV.ID AS ID_Venda, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Situacao_Entrega, P.Nome_Razao AS Descricao, P.NomeFantasia AS Complemento, UPPER(M.Descricao) ";
                        sql += "+ '-' + UF.Sigla AS Municipio, UF.ID_UF, PG.Descricao + '(' + PGP.Parcelamento + ')' AS PrevisaoPagto, SUM(PI.Quantidade * PI.ValorVenda) AS ValorTotal, SUM(PI.Quantidade * PI.ValorCusto) ";
                        sql += "AS CustoTotal, PV.Cancelado, PV.ID_Usuario_Conferencia, PV.CPF_CNPJ, ";
                        sql += "U.Descricao AS Usuario_Conferencia, ";
                        sql += "CASE(NF.Modelo) ";
                        sql += "WHEN 55 ";
                        sql += "THEN 'NF-e ' + CAST(NF.ID_NFe AS varchar(10)) ";
                        sql += "WHEN 59 ";
                        sql += "THEN 'CF-e ' + CAST(NF.ID_NFe AS varchar(10)) ";
                        sql += "END AS NFe_CFe, NF.ID_NFe ";
                        sql += "FROM Venda AS PV ";
                        sql += "INNER JOIN Venda_Item AS PI ON PI.ID_Venda = PV.ID ";
                        sql += "LEFT OUTER JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                        sql += "LEFT OUTER JOIN PessoaEndereco AS PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaTelefone AS PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = P.TipoPessoa AND PTEL.PrincipalTelefone = 'True' ";
                        sql += "LEFT OUTER JOIN PessoaEmail AS PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = P.TipoPessoa AND PEMAIL.PrincipalEmail = 'True' ";
                        sql += "LEFT OUTER JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                        sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                        sql += "LEFT OUTER JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                        sql += "LEFT OUTER JOIN Pagamento_Parc AS PGP ON PV.ID_Parcelamento = PGP.ID ";
                        sql += "LEFT OUTER JOIN Usuario AS U ON PV.ID_Usuario_Conferencia = U.ID ";
                        sql += "LEFT OUTER JOIN NotaFiscal AS NF ON NF.ID_Venda = PV.ID ";
                        sql += "WHERE (NOT (PV.ID IS NULL)) ";
                        sql += "GROUP BY PV.ID, PV.ID_Empresa, PV.TipoPessoa, PV.ID_Pessoa, PV.Data, PV.Entrega, PV.Informacao, PV.ID_UsuarioComissao1, PV.ID_UsuarioComissao2, ";
                        sql += "PV.DataFatura, PV.Comprador, PV.Faturado, PV.NFe, PV.ID_Pagamento, PV.ID_Parcelamento, PV.Cancelado, P.Nome_Razao, P.NomeFantasia, UF.Sigla, ";
                        sql += "UF.ID_UF, PG.Descricao, M.Descricao, PGP.Parcelamento, PV.Situacao_Entrega, PV.Situacao_Conferencia, PV.ID_Usuario_Conferencia, PV.CPF_CNPJ, ";
                        sql += "U.Descricao,  NF.ID_NFe, NF.Modelo ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "Exibe_NFeVenda bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Exibe_NFeVenda = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 228
                    //VERSÃO 228 - 08/10/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW V_Produto_Venda
                    case 228:
                        sql = "ALTER VIEW V_Produto_Venda AS ";
                        sql += "SELECT PP.Ativo, PP.ID_Empresa, ";
                        sql += "P.ID, P.ID_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Imagem, ";
                        sql += "P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, ";
                        sql += "P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.Tipo, P.InfoAdicional1, P.InfoAdicional2, ";
                        sql += "PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.MargemMinima, ";
                        sql += "PV.ValorMinimo, PV.UltimoReajuste, ";
                        sql += "REPLICATE('0', 4 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PP.ID_Empresa AS Varchar))) + CAST(PP.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, PE.Localizacao, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, ";
                        sql += "UN.Descricao AS Unidade, ";
                        sql += "CASE G.Descricao ";
                        sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                        sql += "ELSE P.Descricao + ' - ' + G.Descricao END AS DescricaoCompleta, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "LEFT JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Grupo AS UN ON UN.ID = P.UnidadeTributavel ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 229
                    //VERSÃO 229 - 08/10/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE PESSOA
                    case 229:
                        sql = "ALTER TABLE Pessoa ADD Dia_Faturamento nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pessoa SET Dia_Faturamento = '0' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 230
                    //VERSÃO 230 - 21/10/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE CPagar / CReceber / Cheque
                    case 230:
                        sql = "ALTER TABLE CPagar ALTER COLUMN Documento varchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CReceber ALTER COLUMN Documento varchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 231
                    //VERSÃO 231 - 05/11/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW V_CReceber, V_CPagar
                    //- CRIAÇÃO VIEW V_PlanoConta
                    case 231:
                        sql = "CREATE VIEW V_PlanoConta AS ";
                        sql += "SELECT PC.ID, PC.Nivel, PC.CodigoPai, PC.Codigo, PC.CodigoDescritivo, PC.Descricao, ";
                        sql += "PC1.Nivel AS Nivel1, PC1.CodigoPai AS CodigoPai1, PC1.Codigo AS Codigo1, PC1.CodigoDescritivo AS CodigoDescritivo1, PC1.Descricao AS Descricao1, ";
                        sql += "PC2.Nivel AS Nivel2, PC2.CodigoPai AS CodigoPai2, PC2.Codigo AS Codigo2, PC2.CodigoDescritivo AS CodigoDescritivo2, PC2.Descricao AS Descricao2, ";
                        sql += "PC3.Nivel AS Nivel3, PC3.CodigoPai AS CodigoPai3, PC3.Codigo AS Codigo3, PC3.CodigoDescritivo AS CodigoDescritivo3, PC3.Descricao AS Descricao3 ";
                        sql += "FROM PlanoConta AS PC ";
                        sql += "LEFT JOIN PlanoConta AS PC1 ON PC1.Nivel = 1 AND LEFT(PC.CodigoPai, 2) = PC1.Codigo ";
                        sql += "LEFT JOIN PlanoConta AS PC2 ON PC2.Nivel = 2 AND LEFT(PC.CodigoPai, 4) = (PC2.CodigoPai + PC2.Codigo) ";
                        sql += "LEFT JOIN PlanoConta AS PC3 ON PC3.Nivel = 3 AND LEFT(PC.CodigoPai, 6) = (PC3.CodigoPai + PC3.Codigo) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_CReceber AS ";
                        sql += "SELECT ";
                        sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, ";
                        sql += "C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, ";
                        sql += "C.Acrescimo, C.Controle, C.Boleto, C.ID_Venda, C.ID_OS, C.ID_PrevisaoPagto, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, PC.Nivel, ";
                        sql += "PC.CodigoDescritivo1 AS Conta1, PC.Descricao1 AS DescricaoConta1,  ";
                        sql += "PC.CodigoDescritivo2 AS Conta2, PC.Descricao2 AS DescricaoConta2,  ";
                        sql += "PC.CodigoDescritivo3 AS Conta3, PC.Descricao3 AS DescricaoConta3,  ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa, ";
                        sql += "CASE C.Boleto ";
                        sql += "WHEN 'true' THEN 'GERADO' ";
                        sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                        sql += "END AS DescricaoBoleto, ";
                        sql += "TP.Descricao AS PrevisaoPagto ";
                        sql += "FROM CReceber AS C ";
                        sql += "LEFT JOIN V_PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "LEFT JOIN Pagamento AS TP ON TP.ID = C.ID_PrevisaoPagto ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_CPagar AS ";
                        sql += "SELECT C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, ";
                        sql += "C.TipoPessoa, C.ID_Pessoa, C.Valor, C.QuantidadeParcela, C.Parcela, ";
                        sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) + '(' + CAST(C.Controle AS VARCHAR(10)) + ')' AS ResumoParcela, ";
                        sql += "C.Descricao, C.Desconto, ((C.Valor + C.Acrescimo) - C.Desconto) AS Total, C.Acrescimo, C.Controle, ";
                        sql += "PC.CodigoDescritivo AS Conta, PC.Descricao AS DescricaoConta, PC.Nivel, ";
                        sql += "PC.CodigoDescritivo1 AS Conta1, PC.Descricao1 AS DescricaoConta1,  ";
                        sql += "PC.CodigoDescritivo2 AS Conta2, PC.Descricao2 AS DescricaoConta2,  ";
                        sql += "PC.CodigoDescritivo3 AS Conta3, PC.Descricao3 AS DescricaoConta3,  ";
                        sql += "P.Nome_Razao AS DescricaoPessoa, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN 'EM ABERTO' ";
                        sql += "WHEN 2 THEN 'PAGO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE C.Situacao ";
                        sql += "WHEN 1 THEN NULL ";
                        sql += "WHEN 2 THEN C.DataBaixa ";
                        sql += "END AS DataBaixa ";
                        sql += "FROM CPagar AS C ";
                        sql += "LEFT JOIN V_PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                        sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 232
                    //VERSÃO 232 - 15/11/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TEBELA Parametro_Sistema
                    case 232:
                        sql = "ALTER TABLE Parametro_Sistema ADD Exibe_ReferenciaNFe bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET Exibe_ReferenciaNFe = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 233
                    //VERSÃO 233 - 15/11/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW V_Produto_Movimento
                    case 233:
                        sql = "ALTER VIEW V_Produto_Movimento AS ";
                        sql += "SELECT C.Data, 'ÚLTIMA COMPRA: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Produto_Entrada AS C ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE C.Tipo_Entrada = 1 ";
                        sql += "UNION ";
                        sql += "SELECT C.Data, 'ENTRADA PRODUÇÃO: Nº ' + CAST(C.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "CP.ID_Produto, CP.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Produto_Entrada AS C ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CP ON C.ID = CP.ID_Produto_Entrada ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = CP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON C.TipoPessoa = PS.TipoPessoa AND C.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE C.Tipo_Entrada = 2 ";
                        sql += "UNION ";
                        sql += "SELECT V.Data, 'ÚLTIMA VENDA: Nº ' + CAST(V.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS Compra, ISNULL(PP.Quantidade_Entregue, PP.Quantidade) AS Venda, ";
                        sql += "CASE ";
                        sql += "WHEN PP.Quantidade_Entregue IS NULL THEN 'SAÍDA (PREVISTO)' ";
                        sql += "WHEN PP.Quantidade_Entregue IS NOT NULL THEN 'SAÍDA' ";
                        sql += "END AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Venda AS V ";
                        sql += "INNER JOIN Venda_Item AS PP ON V.ID = PP.ID_Venda ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON V.TipoPessoa = PS.TipoPessoa AND V.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "UNION ";
                        sql += "SELECT OS.Data_Entrega AS Data, 'ÚLTIMA OS: Nº ' + CAST(OS.ID AS VARCHAR(20)) AS UltimoLancamento, ";
                        sql += "PP.ID_Produto, NULL AS Compra, ISNULL(PP.Quantidade_Entregue, PP.Quantidade) AS Venda, ";
                        sql += "CASE ";
                        sql += "WHEN PP.Quantidade_Entregue IS NULL THEN 'SAÍDA (PREVISTO)' ";
                        sql += "WHEN PP.Quantidade_Entregue IS NOT NULL THEN 'SAÍDA' ";
                        sql += "END AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "PS.Nome_Razao AS Pessoa ";
                        sql += "FROM Ordem_Servico AS OS ";
                        sql += "INNER JOIN Ordem_Servico_Item AS PP ON OS.ID = PP.ID_OS ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Pessoa AS PS ON OS.TipoPessoa = PS.TipoPessoa AND OS.ID_Pessoa = PS.ID_Pessoa ";
                        sql += "WHERE OS.Status_OS = 6 ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, PM.Quantidade AS Compra, NULL AS Venda, 'ENTRADA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 1 ";
                        sql += "UNION ";
                        sql += "SELECT PM.Data, PM.Informacao AS UltimoLancamento, PM.ID_Produto, NULL AS Compra, PM.Quantidade AS Venda, 'SÁIDA' AS Tipo, ";
                        sql += "P.Descricao, P.Referencia, P.Barra, ";
                        sql += "NULL AS Pessoa ";
                        sql += "FROM Produto_Movimento AS PM ";
                        sql += "INNER JOIN Produto_Servico AS P ON P.ID = PM.ID_Produto ";
                        sql += "WHERE PM.Tipo = 2 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 234
                    //VERSÃO 234 - 30/11/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO VIEW Remove Campos Email
                    case 234:
                        sql = "ALTER TABLE Parametro_Sistema DROP COLUMN SMTP, Porta, SSL, Usuario, Senha ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CEST ALTER COLUMN NCM varchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CEST ALTER COLUMN CEST varchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 235
                    //VERSÃO 235 - 01/12/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABLE Cria CAMPO ID_CEST
                    //- ALTERAÇÃO DE VIEWS COM PRODUTOS
                    case 235:
                        sql = "ALTER TABLE Produto_Servico ADD ID_CEST int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Servico SET ID_CEST = 0 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Venda_Item_Imposto AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.ProdutoEspecifico, P.Cod_ANP, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVi.ID_Venda = VP.ID_Venda AND vp.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Venda_Item_Imposto_CF AS ";
                        sql += "SELECT PVI.ID_Venda, PVI.ID_Produto, PVI.Quantidade, PVI.ID_Tabela, PVI.ValorProduto, PVI.Acrescimo,  ";
                        sql += "PVI.Desconto, PVI.ValorVenda, PVI.ID_Grade, PVI.ValorTotal, PVI.Informacao, PVI.TipoSaida, ";
                        sql += "PVI.DescricaoProduto, PVI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Venda_Item AS PVI ";
                        sql += "INNER JOIN Produto_Servico as P ON PVI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PVI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Venda as VP ON PVI.ID_Venda = VP.ID_Venda AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Ordem_Servico_Item_Imposto AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND VP.ID_UF = IUF.ID_UF ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Ordem_Servico_Item_Imposto_CF AS ";
                        sql += "SELECT OSI.ID_OS, OSI.ID_Produto, OSI.Quantidade, OSI.ID_Tabela, OSI.ValorProduto, OSI.Acrescimo, ";
                        sql += "OSI.Desconto, OSI.ValorVenda, OSI.ID_Grade, OSI.ValorTotal, OSI.Informacao, OSI.TipoSaida, ";
                        sql += "OSI.DescricaoProduto, OSI.ValorCusto, ";
                        sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.NCM, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, ";
                        sql += "I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                        sql += "FROM V_Ordem_Servico_Item AS OSI ";
                        sql += "INNER JOIN Produto_Servico as P ON OSI.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON OSI.ID_Produto = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID ";
                        sql += "INNER JOIN V_Ordem_Servico as VP ON OSI.ID_OS = VP.ID_OS AND IUF.ID_UF = 35 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Produto_Servico AS ";
                        sql += "SELECT ";
                        sql += "P.ID, P.ID_Grupo, P.Tipo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.Barratributavel, P.NCM, ";
                        sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, P.UnidadeTributavel, P.Validade, P.Garantia, P.EX_TIPI, ";
                        sql += "P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.PesoB, P.PesoL, P.Controle_Estoque, P.Imagem, ";
                        sql += "P.InfoAdicional1, P.InfoAdicional2, P.ABC, P.ID_CEST, ";
                        sql += "PP.ID_Empresa, PP.Ativo, PP.ID_Imposto, ";
                        sql += "GS.Descricao AS DescricaoUnidade, ";
                        sql += "GN.Descricao AS DescricaoGrupo, GN.CodigoDescritivo AS Cod_Grupo, ";
                        sql += "IP.Descricao AS DescricaoImposto ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "LEFT JOIN Grupo AS GS ON GS.ID = P.UnidadeTributavel ";
                        sql += "LEFT JOIN GrupoNivel AS GN ON GN.ID = P.ID_Grupo ";
                        sql += "LEFT JOIN Imposto AS IP ON IP.ID = PP.ID_Imposto ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER VIEW V_Produto_Imposto AS  ";
                        sql += "SELECT P.ID AS ID_Produto, P.Tipo, P.ID_Grupo, P.Descricao, P.Referencia, ";
                        sql += "P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, P.ValorCompra, ";
                        sql += "P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.ValorST, P.UnidadeTributavel, P.Validade, ";
                        sql += "P.Garantia, P.Situacao, P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, ";
                        sql += "P.ID_CEST, ";
                        sql += "PP.ID AS ID_Imposto_Produto, PP.ID_Empresa, ";
                        sql += "PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela, ";
                        sql += "I.ID_Imposto, I.CFOP, I.CST, I.Origem, I.Tipo_NF, I.ModalidadeBC, ";
                        sql += "I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, ";
                        sql += "I.PercentualReducaoST, I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, ";
                        sql += "I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, ";
                        sql += "I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento, IUF.ID_UF ";
                        sql += "FROM Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON P.ID = PP.ID_Produto ";
                        sql += "INNER JOIN Imposto AS IM ON PP.ID_Imposto = IM.ID ";
                        sql += "INNER JOIN Imposto_Tributacao AS I ON PP.ID_Imposto = I.ID_Imposto ";
                        sql += "INNER JOIN Imposto_UF AS IUF ON IUF.ID_Tributacao = I.ID  ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 236
                    //VERSÃO 236 - 04/12/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Ordem_Servico_Item
                    case 236:
                        sql = "ALTER TABLE Ordem_Servico_Item ALTER COLUMN Informacao nvarchar(1000)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CEST ALTER COLUMN NCM nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE CEST ALTER COLUMN CEST nvarchar(10) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 237
                    //VERSÃO 237 - 18/12/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Ordem_Servico_Item
                    case 237:
                        sql = "ALTER TABLE Venda ADD ID_NFe int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Venda ADD ID_CFe int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET ";
                        sql += "ID_NFe = (SELECT TOP(1)ID_NFe FROM NotaFiscal WHERE ID_Venda = Venda.ID AND ID_Empresa = Venda.ID_Empresa AND Modelo = 55 ORDER BY ID_NFe DESC) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET ";
                        sql += "ID_CFe = (SELECT TOP(1)ID_NFe FROM NotaFiscal WHERE ID_Venda = Venda.ID AND ID_Empresa = Venda.ID_Empresa AND Modelo = 59 ORDER BY ID_NFe DESC) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET ";
                        sql += "ID_NFe = 0 ";
                        sql += "WHERE ";
                        sql += "ID_NFe IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Venda SET ";
                        sql += "ID_CFe = 0 ";
                        sql += "WHERE ";
                        sql += "ID_CFe IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Ordem_Servico ADD ID_NFe int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Ordem_Servico ADD ID_CFe int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Ordem_Servico SET ";
                        sql += "ID_NFe = (SELECT TOP(1)ID_NFe FROM NotaFiscal WHERE ID_OS = Ordem_Servico.ID AND ID_Empresa = Ordem_Servico.ID_Empresa AND Modelo = 55 ORDER BY ID_NFe DESC) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Ordem_Servico SET ";
                        sql += "ID_CFe = (SELECT TOP(1)ID_NFe FROM NotaFiscal WHERE ID_OS = Ordem_Servico.ID AND ID_Empresa = Ordem_Servico.ID_Empresa AND Modelo = 59 ORDER BY ID_NFe DESC) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Ordem_Servico SET ";
                        sql += "ID_NFe = 0 ";
                        sql += "WHERE ";
                        sql += "ID_NFe IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Ordem_Servico SET ";
                        sql += "ID_CFe = 0 ";
                        sql += "WHERE ";
                        sql += "ID_CFe IS NULL ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        Atualiza_V_Venda();

                        Atualiza_V_Ordem_Servico();

                        sql = "ALTER TABLE Parametro_Sistema ADD ";
                        sql += "CFe_Cartao bit, ";
                        sql += "Venda_ImpressaoDireta bit, ";
                        sql += "CFe_PDV_Cartao bit, ";
                        sql += "TipoSaida_Fixo bit, ";
                        sql += "Produto_PrecoVenda int, ";
                        sql += "Somente_Maiusculo bit ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "CFe_Cartao = 'false', ";
                        sql += "Venda_ImpressaoDireta = 'false', ";
                        sql += "CFe_PDV_Cartao = 'false', ";
                        sql += "TipoSaida_Fixo = 'false', ";
                        sql += "Produto_PrecoVenda = 1, ";
                        sql += "Somente_Maiusculo = 'false' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 238
                    //VERSÃO 238 - 24/12/2016
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Parametro_Sistema
                    case 238:
                        sql = "ALTER TABLE Parametro_Sistema ADD Qt_Dias_Pesquisa int, Cadastro_PessoaPadrao int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Qt_Dias_Pesquisa = 0, ";
                        sql += "Cadastro_PessoaPadrao = 1";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 239
                    //VERSÃO 239 - 04/01/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Produto_Estrutura
                    case 239:
                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Estrutura' AND [COLUMN_NAME] = 'Vlr_Custo')";
                        sql += "BEGIN ALTER TABLE Produto_Estrutura DROP COLUMN Vlr_Custo END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Valor' AND [COLUMN_NAME] = 'ValorMinimo')";
                        sql += "BEGIN ALTER TABLE Produto_Valor DROP COLUMN ValorMinimo END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Valor' AND [COLUMN_NAME] = 'MargemPromocional')";
                        sql += "BEGIN ALTER TABLE Produto_Valor DROP COLUMN MargemPromocional END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Valor' AND [COLUMN_NAME] = 'MargemMinima')";
                        sql += "BEGIN ALTER TABLE Produto_Valor DROP COLUMN MargemMinima END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Valor' AND [COLUMN_NAME] = 'ValorPromocional')";
                        sql += "BEGIN ALTER TABLE Produto_Valor DROP COLUMN ValorPromocional END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS ";
                        sql += "WHERE [TABLE_NAME] = 'Produto_Valor' AND [COLUMN_NAME] = 'UtilizarValorPromocao')";
                        sql += "BEGIN ALTER TABLE Produto_Valor DROP COLUMN UtilizarValorPromocao END";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Fornecedor ADD Codigo_Produto nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Fornecedor SET Codigo_Produto = ''";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD Altera_ValorPDV bit, Endereco_Padrao int, Telefone_Padrao int, EntradaProduto int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Altera_ValorPDV = 'false', ";
                        sql += "Endereco_Padrao = 13, ";
                        sql += "Telefone_Padrao = 16, ";
                        sql += "EntradaProduto = 1";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Produto_Entrada ALTER COLUMN Documento nvarchar(100)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        Atualiza_V_Produto_Venda();

                        Atualiza_V_Venda();

                        Atualiza_V_Ordem_Servico();

                        sql = "ALTER TABLE Produto_Entrada_Item ADD NFe_Descricao nvarchar(60), NFe_CodigoProduto nvarchar(60) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Produto_Entrada_Item SET ";
                        sql += "NFe_Descricao = '', ";
                        sql += "NFe_CodigoProduto = '' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 240
                    //VERSÃO 240 - 23/01/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Produto_Entrada_Item
                    case 240:
                        sql = "ALTER TABLE Produto_Entrada_Item ALTER COLUMN NFe_Descricao nvarchar(200) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #endregion
                    #region 241
                    //VERSÃO 241 - 30/01/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO TABELA Parametro_Sistema
                    case 241:
                        sql = "ALTER TABLE Parametro_Sistema ADD Decimal_Produto_Valor int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE Parametro_Sistema ADD Decimal_Produto_Quantidade int";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Parametro_Sistema SET ";
                        sql += "Decimal_Produto_Valor  = 2, ";
                        sql += "Decimal_Produto_Quantidade  = 3 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal ALTER COLUMN InformacaoAdicional nvarchar(500)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 242
                    //VERSÃO 242 - 10/02/2017
                    //ALTERAÇÕES:
                    //- CRIAÇÃO TABELA FichaProducao
                    case 242:
                        sql = "CREATE TABLE FichaProducao (";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "ID_Empresa int, ";
                        sql += "ID_Venda int, ";
                        sql += "Situacao int, ";
                        sql += "Entrada datetime, ";
                        sql += "Saida datetime, ";
                        sql += "Transportadora nvarchar(200), ";
                        sql += "ID_Item_Venda int, ";
                        sql += "AnoModelo nvarchar(60), ";
                        sql += "CorCouro nvarchar(100), ";
                        sql += "Costura nvarchar(100), ";
                        sql += "Logomarca int, ";
                        sql += "Laterais_Porta int, ";
                        sql += "Acento int, ";
                        sql += "TipoAcento nvarchar(100), ";
                        sql += "ABD nvarchar(100), ";
                        sql += "ABT nvarchar(100), ";
                        sql += "Observacao nvarchar(500)) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "CREATE VIEW V_FichaProducao AS ";
                        sql += "SELECT ";
                        sql += "FP.ID, FP.ID_Empresa, FP.ID_Venda, FP.Situacao, FP.Entrada, FP.Saida, FP.Transportadora, FP.ID_Item_Venda, FP.AnoModelo, ";
                        sql += "FP.CorCouro, FP.Costura, FP.Logomarca, FP.Laterais_Porta, FP.Acento, FP.TipoAcento, FP.ABD, FP.ABT, FP.Observacao, ";
                        sql += "CASE FP.Situacao ";
                        sql += "WHEN 1 THEN 'AGUARDANDO PAGAMENTO' ";
                        sql += "WHEN 2 THEN 'EM PRODUÇÃO' ";
                        sql += "WHEN 3 THEN 'CONCLUÍDO' ";
                        sql += "END AS DescricaoSituacao, ";
                        sql += "CASE FP.Logomarca ";
                        sql += "WHEN 1 THEN 'SEM LOGO' ";
                        sql += "WHEN 2 THEN 'BORDADA' ";
                        sql += "WHEN 3 THEN 'CARIMBADA' ";
                        sql += "END AS DescricaoLogomarca, ";
                        sql += "V.Descricao AS DescricaoPessoa, V.Data AS DataVenda, ";
                        sql += "VI.DescricaoProduto AS DescricaoProduto, VI.InfoAdicional1, ";
                        sql += "U.Descricao AS DescricaoUsuarioComissao1 ";
                        sql += "FROM FichaProducao AS FP ";
                        sql += "INNER JOIN V_Venda AS V ON FP.ID_Venda = V.ID_Venda ";
                        sql += "INNER JOIN V_Venda_Item AS VI ON FP.ID_Item_Venda = VI.IDItem ";
                        sql += "LEFT JOIN Usuario AS U ON U.ID = V.ID_UsuarioComissao1 ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE NotaFiscal_Item ALTER COLUMN Quantidade decimal(12,4); ";
                        sql += "ALTER TABLE NotaFiscal_Item ALTER COLUMN ValorUnitario decimal(12,4); ";
                        sql += "ALTER TABLE NotaFiscal_Item ALTER COLUMN Acrescimo decimal(12,4); ";
                        sql += "ALTER TABLE NotaFiscal_Item ALTER COLUMN Desconto decimal(12,4); ";

                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 243
                    //VERSÃO 243 - 23/02/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA FichaProducao
                    case 243:
                        sql = "EXEC sp_rename 'FichaProducao.Acento', 'ApoioCabeca', 'COLUMN' ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "ALTER TABLE FichaProducao ADD TipoEncosto nvarchar(100) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        Atualiza_V_FichaProducao();
                        break;
                    #endregion
                    #region 244
                    //VERSÃO 244 - 06/03/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW V_FichaProducao
                    case 244:
                        Atualiza_V_FichaProducao();
                        break;
                    #endregion
                    #region 245
                    //VERSÃO 245 - 15/03/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA Pessoa_EmpresaResponsavel
                    case 245:
                        sql = "ALTER TABLE Pessoa_EmpresaResponsavel ADD TipoPessoa int ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE Pessoa_EmpresaResponsavel SET TipoPessoa = 6 ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);
                        break;
                    #endregion
                    #region 246
                    //VERSÃO 246 - 17/03/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW V_Produto_Movimento
                    case 246:
                        Atualiza_V_Produto_Movimento();
                        break;
                    #endregion
                    #region 247
                    //VERSÃO 247 - 20/03/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE VIEW V_FichaProducao
                    case 247:
                        Atualiza_V_FichaProducao();
                        break;
                    #endregion
                    #region 248
                    //VERSÃO 248 - 14/05/2019
                    //ALTERAÇÕES:
                    //- CRIAÇÃO TABELA locProduto
                    case 248:
                        //sql = "CREATE TABLE locProduto (";
                        //sql += "ID int IDENTITY PRIMARY KEY, ";
                        //sql += "ID_Empresa int, ";
                        //sql += "ID_Cliente int, ";
                        //sql += "Dt_Emissao datetime, ";
                        //sql += "Dt_Locacao datetime, ";
                        //sql += "Dt_Entrega datetime, ";
                        //sql += "Dt_Retirada date, ";
                        //sql += "ContratoExterno nvarchar(50), ";
                        //sql += "Observacao nvarchar(500)) ";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);



                        //break;
                    #endregion
                    #region 249
                    //VERSÃO 245 - 15/03/2017
                    //ALTERAÇÕES:
                    //- ALTERAÇÃO DE TABELA Pessoa_EmpresaResponsavel
                    case 249:

                        //sql = "ALTER TABLE CReceber ADD ID_LocProduto int ";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                       break;



                    #endregion
                    #region 250
                    case 250:

                        //sql = "ALTER TABLE locProduto ADD status nvarchar ";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 251
                    case 251:

                        //sql = "ALTER TABLE Usuario ADD PosicaoMenu nvarchar(20) ";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 252
                    case 252:

                        //sql = "ALTER TABLE Usuario ADD PosicaoMenu nvarchar(20) ";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 253
                    case 253:

                        //sql = "CREATE TABLE Frota_Combustivel ( ";
                        //sql += "ID int IDENTITY PRIMARY KEY, ";
                        //sql += "Descricao nvarchar(60))";
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 254
                    case 254:

                        //sql = "CREATE TABLE FROTA_VEICULO ( ";
                        //sql += "ID int IDENTITY PRIMARY KEY, ";
                        //sql += "RENAVAM nvarchar(60))";
                        //sql += "RNTRC   nvarchar(60))";
                        //sql += "PLACA   nvarchar(60))";
                        //sql += "ANOMOD  nvarchar(60))";
                        //sql += "ANOFAB  nvarchar(60))";
                        //sql += "CHASSI  nvarchar(60))";
                        //sql += "MARCA_MODELO nvarchar(60))";
                        //sql += "KMINI   nvarchar(60))";
                        //sql += "KMATUAL nvarchar(60))";                      
                        //cmd.CommandText = sql;
                        //conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 255
                    case 255:

                        sql = "ALTER TABLE VENDA ";
                        sql += "ADD SEQVENDA VARCHAR(20) ";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion
                    #region 256
                    case 256:

                        sql = "CREATE TABLE Venda_Sequencia (";
                        sql += "ID int IDENTITY PRIMARY KEY, ";
                        sql += "SEQ int	)";
                        cmd.CommandText = sql;
                        conexao.Executa_Comando(cmd);

                        break;
                    #endregion

                }
                cmd.CommandText = "UPDATE Versao SET BD = " + intVersao;
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

        public void Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Sistema.ID == 0)
                {
                    sql = "INSERT INTO Versao ";
                    sql += "(Versao, BD) ";
                    sql += "VALUES ";
                    sql += "(@Versao, @BD) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Versao", Sistema.VersaoSistema);
                    cmd.Parameters.AddWithValue("@BD", Sistema.VersaoBanco);
                    conexao.Executa_Comando(cmd);
                }
                else
                {
                    sql = "UPDATE Versao ";
                    sql += "SET ";
                    sql += "Versao = @Versao, ";
                    sql += "BD = @BD ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Sistema.ID);
                    cmd.Parameters.AddWithValue("@Versao", Sistema.VersaoSistema);
                    cmd.Parameters.AddWithValue("@BD", Sistema.VersaoBanco);
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

                sql = "SELECT ";
                sql += "Versao, BD, Chave ";
                sql += "FROM Versao ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID  = " + Sistema.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Abre_Conexao();
            }
        }

        public void Verifica_Conexao()
        {
            conexao = new Conexao();
            bool _aux = false;
            try
            {
                conexao.Abre_Conexao();
                _aux = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_aux == true)
                    conexao.Fecha_Conexao();
            }
        }

        public string Busca_Chave()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Chave ";
                sql += "FROM Versao ";
                sql += "WHERE ID = 1";

                return conexao.Consulta(sql).Rows[0]["Chave"].ToString();
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

        public void AtualizaBanco()
        {
            try
            {
                for (int i = Sistema.VersaoAtualBanco + 1; i <= UltimaVersao; i++)
                    Atualiza(i);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Versao()
        {
            return UltimaVersao;
        }

        public string Executa_Comando()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                switch (Sistema.TipoComando)
                {
                    case 1:
                        cmd.CommandText = Sistema.ComandoSQL;
                        conexao.Executa_Comando(cmd);
                        return "Comando Executado Com Sucesso!";

                    case 2:
                        cmd.CommandText = Sistema.ComandoSQL;
                        return conexao.Executa_ComandoID(cmd).ToString();

                    default:
                        return string.Empty;
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

        public DataTable Consulta()
        {
            conexao = new Conexao();
            conexao.Abre_Conexao();
            try
            {
                switch (Sistema.TipoComando)
                {
                    case 1:
                        return conexao.Consulta(Sistema.ComandoSQL.ToString());

                    case 2:
                        sql = "SELECT TABLE_NAME AS Tabelas ";
                        sql += "FROM INFORMATION_SCHEMA.TABLES ";
                        sql += "ORDER BY TABLE_NAME ";
                        return conexao.Consulta(sql);

                    default:
                        return null;
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
    }
}

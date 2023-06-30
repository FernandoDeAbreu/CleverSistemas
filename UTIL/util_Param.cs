using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Sistema.UTIL
{
    public static class util_Param
    {
        
        #region PARAMETROS VARIAVEIS
        public static string Descricao_Empresa;

        //ESTA OPÇÃO É SOMENTE PARA QUANDO EXIBIR A MENSAGEM QUE EXISTE
        //PEDIDOS MOBILE PARA EFETIVAR NÃO REPETIR A MENSAGEM.
        public static bool Consulta_Mobile;
        #endregion

        #region PARAMETROS FIXOS
        #region PASTAS XML NFe
        public static string XML_Envia = @"Envia\";
        public static string XML_Assinado = @"Assinadas\";
        public static string XML_Retorno = @"Retorno\";
        public static string XML_EmProcessamento = @"EmProcessamento\";
        public static string XML_Autorizado = @"Autorizadas\";
        public static string XML_Erro = @"Erro\";
        public static string XML_Entrada = @"Entradas\";
        public static string Schemas = @"Schemas\";
        #endregion

        #region NFe
        public static int NFe_Assinada = 1;
        public static int NFe_Autorizada = 2;
        public static int NFe_Cancelada = 3;
        public static int NFe_Denegada = 4;
        public static int NFe_Digitacao = 5;
        public static int NFe_Validada = 6;
        public static int NFe_EmProcessamento = 7;
        #endregion

        #region PARAMETROS DE INICIAÇÃO DO SISTEMA
        private class DTO_TipoPessoa
        {
            public string Cliente { get; set; }
            public string Empresa { get; set; }
            public string Fornecedor { get; set; }
            public string Funcionario { get; set; }
            public string Transportadora { get; set; }
            public string Locador { get; set; }
            public string Locatario { get; set; }
            public string Fiador { get; set; }
        }

        public static DataTable Tipo_Pessoa()
        {
            DataRow DR;
            DataTable _DT;
            DTO_TipoPessoa _Tipo_Pessoa = new DTO_TipoPessoa();

            switch (Parametro_Empresa.Tipo_Sistema)
            {
                case Tipo_Sistema.Comercial:
                    _Tipo_Pessoa.Cliente = "CLIENTE";
                    _Tipo_Pessoa.Empresa = "EMPRESA";
                    _Tipo_Pessoa.Fornecedor = "FORNECEDOR";
                    _Tipo_Pessoa.Funcionario = "FUNCIONÁRIO";
                    _Tipo_Pessoa.Transportadora = "TRANSPORTADORA";

                    _DT = new DataTable("TipoPessoa");
                    _DT.Columns.Add("ID");
                    _DT.Columns.Add("Descricao");

                    DR = _DT.NewRow();
                    DR["ID"] = "1";
                    DR["Descricao"] = _Tipo_Pessoa.Cliente;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "2";
                    DR["Descricao"] = _Tipo_Pessoa.Empresa;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = _Tipo_Pessoa.Fornecedor;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "4";
                    DR["Descricao"] = _Tipo_Pessoa.Funcionario;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "5";
                    DR["Descricao"] = _Tipo_Pessoa.Transportadora;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();

                    return _DT;

                case Tipo_Sistema.Imobiliaria:
                    _Tipo_Pessoa.Empresa = "EMPRESA";
                    _Tipo_Pessoa.Fornecedor = "FORNECEDOR";
                    _Tipo_Pessoa.Funcionario = "FUNCIONÁRIO";
                    _Tipo_Pessoa.Locador = "PROPRIETÁRIO";
                    _Tipo_Pessoa.Locatario = "LOCATÁRIO";
                    _Tipo_Pessoa.Fiador = "FIADOR";


                    _DT = new DataTable("TipoPessoa");
                    _DT.Columns.Add("ID");
                    _DT.Columns.Add("Descricao");

                    DR = _DT.NewRow();
                    DR["ID"] = "2";
                    DR["Descricao"] = _Tipo_Pessoa.Empresa;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = _Tipo_Pessoa.Fornecedor;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "4";
                    DR["Descricao"] = _Tipo_Pessoa.Funcionario;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR = _DT.NewRow();
                    DR["ID"] = "7";
                    DR["Descricao"] = _Tipo_Pessoa.Locador;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "8";
                    DR["Descricao"] = _Tipo_Pessoa.Locatario;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();
                    DR = _DT.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = _Tipo_Pessoa.Fiador;
                    _DT.Rows.Add(DR);
                    _DT.AcceptChanges();

                    return _DT;

                default:
                    return null;
            }
        }

        public static DataTable Saida_Produto()
        {
            DataRow DR;
            DataTable _DT;
            _DT = new DataTable();
            _DT.Columns.Add("ID");
            _DT.Columns.Add("Descricao");

            DR = _DT.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "VENDA";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "TROCA";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "BONIFICAÇÃO";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "COMODATO";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            return _DT;
        }

        public static DataTable Pesquisa_Fatura()
        {
            DataRow DR;
            DataTable _DT;
            _DT = new DataTable();
            _DT.Columns.Add("ID");
            _DT.Columns.Add("Descricao");

            DR = _DT.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "TODOS";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "FATURADOS";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "NÃO FATURADOS";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "CANCELADOS";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            return _DT;
        }

        public static DataTable Pesquisa_NFE()
        {
            DataRow DR;
            DataTable _DT;
            _DT = new DataTable();
            _DT.Columns.Add("ID");
            _DT.Columns.Add("Descricao");

            DR = _DT.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "TODOS";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "EMITIDO NFe";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            DR = _DT.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "NÃO EMITIDO NFe";
            _DT.Rows.Add(DR);
            _DT.AcceptChanges();
            return _DT;
        }
        #endregion
        #endregion
    }

    public static class SQL
    {
        public static string Servidor;
        public static string Banco;
        public static string Usuario;
        public static string Senha;
        public static string Teste;
    }

    public static class Parametro_Sistema
    {
        //public static string Versao = "2.0.00";
        public static string Versao = "2.0.05";
        public static string Usuario_Config = "Admin";
        public static string Acesso_Config = "suporte";
        public static string Caminho_Relatorio;
        public static string Caminho_Sistema;
        public static string Caminho_Atualizacao;
        public static string Caminho_Remessa = @"C:\Remessa_Banco";
        public static bool Terminal_NFe;
        public static bool Terminal_CFe;
        public static bool Usuario_Suporte = false;
        public static bool Monitor_SAT = false;
        public static int TipoPessoaPadrao = 1; //CLIENTE

        //CONFIGURAÇÃO EMAIL
        public static string SMTP = "mail.dominio.com.br";
        public static int Porta = 587;
        public static bool SSL = false;
        public static string Usuario_email = "email@dominio.com.br";
        public static string Senha_email = "password";
    }

    public static class Parametro_Empresa
    {
        public static int ID_Empresa_Ativa;
        public static string DescricaoEmpresa;
        public static string Razao_Social_Empresa;
        public static string CNPJ;
        public static string IE;
        public static Tipo_Sistema Tipo_Sistema;
    }

    public static class Parametro_Venda
    {
        public static string Descricao_Comissao;

        public static bool Ultimo_Valor;
        public static bool Permitir2Vias;
        public static bool Agrupar_Produto;
        public static double Limite_Desconto;
        public static bool Produto_Marca;
        public static bool Bloquear_EstoqueNegativo;
        public static bool msg_EstoqueNegativo;
        public static bool Orca_ValorTotal;
        public static bool MultiploUsuarioPDV;
        public static bool Consulta_RapidaProduto;
        public static bool NaoAlterarVendaFaturada;
        public static int PagamentoTrocoDevolucao;
        public static int ID_ConsumidorFinal;
        public static int ID_TabelaVendaPadrao;
        public static bool Venda_Matricial;
        public static int Modelo_Matricial;

        /// <summary>
        /// <para>1 - VALOR</para>
        /// <para>2 - PORCENTAGEM</para>
        /// </summary>
        public static int Desconto_Padrao;

        public static bool Exibe_NFeVenda;

        /// <summary>
        /// <para>0 - NENHUMA</para>
        /// <para>1 - PADRÃO 75/80cm</para>
        /// </summary>
        public static int TipoImpressoraTermica;

        public static int DiasBloqueioVenda;

        public static Consulta_Grade Tipo_ConsultaGrade;
        public static bool CFe_Cartao;
        public static bool Venda_ImpressaoDireta;
        public static bool CFe_PDV_Cartao;
        public static bool TipoSaida_Fixo;
        public static int Qt_Dias_Pesquisa;
        public static bool Altera_ValorPDV;
        public static Composicao_PrecoVenda Produto_PrecoVenda;

        public static string Decimal_Quantidade = "N2";
        public static string Decimal_Produto_ValorCompra = "N2";
        public static string Decimal_Produto_ValorVenda = "N2";
 
    }

    public static class Parametro_Financeiro
    {
        public static int ID_Conta_FatVenda;
        public static int ID_Conta_FatOS;
        public static int ID_Conta_FatCompra;
        public static int ID_Caixa_Principal;
        public static int ID_Conta_PagtoDiverso;
        public static int ID_Conta_RectoDiverso;
        public static int ID_ContaDevolucaoVenda;
        public static int ID_Conta_CobrancaBancaria;
        public static int ID_PagtoBoleto;

        public static int ID_Conta_TransferenciaValores;

        //PARAMETROS CHEQUE
        public static int ID_Conta_Lanc_ChequeDevolvido;

        public static double Tarifa_Multa = 0;
        public static double Tarifa_Juros = 0;
    }

    public static class Parametro_NFe_NFC_SAT
    {
        /// <summary>
        /// <para>1 - SIMPLES NACIONAL</para>
        /// <para>2 - SIMPLES NACIONAL (EXCESSO DE SUBLIMITE)</para>
        /// <para>3 - REGIME NORMAL</para>
        /// </summary>
        public static int Regime_Tributario;

        public static string Schema = "4.00";

        public static int AmbienteNFe;
        public static string Caminho_NFe;
        public static string CertificadoDigital;
        public static bool Exibe_InfoProd;
        public static double AliquotaICMS;
        public static string Info_Complementar;
        public static bool Exibe_msgCreditoICMS;
        public static bool Exibe_Desconto;
        public static int Tipo_NF_Venda;
        public static bool Exibe_ReferenciaNFe;

        //SAT
        /// <summary>
        /// <para>1 - EMULADOR</para>
        /// <para>2 - SAT.DLL .NET</para>
        /// <para>3 - SAT ELGIN</para>
        /// <para>4 - BEMATECH 32</para>
        /// <para>5 - BEMATECH 64</para>
        /// </summary>
        public static int TipoEquipamentoSAT;
        public static string SenhaAtivacaoSAT;
        public static string AssinaturaSAT;
        public static string CNPJ_Software = "08097009000174";
        public static int NumeroCaixa = 1;
        public static string VersaoXML = "0.07";
        public static string VersaoIBPT = "IBPT Ar5Fr7";
        public static bool CFe_A4;
        public static bool Monitor_CFe;
    }

    public static class Parametro_OrdemServico
    {
        public static string Descricao_Info1;
        public static string Descricao_Info2;
        public static string Descricao_Info3;
        public static string Descricao_Obs1;
        public static string Descricao_Obs2;
        public static bool Imprime_OS_Equipamento;
    }

    public static class Parametro_Usuario
    {
        //PERMITE VENDA SOMENTE PARA CLIENTES
        public static int ID_Usuario_Ativo;
        public static string Descricao_UsuarioAtivo;
        public static bool Venda_Restrita;
        public static bool Libera_Desconto;
        public static bool Venda_Fixa_logado;
        public static bool Permite_Faturar;
        public static bool Permite_AterarFaturado;
        public static bool Visualiza_ResumoVenda;
    }

    public static class Parametro_CadastroPersonalizado
    {
        public static string DescricaoComissao;

        #region CADASTRO PESSOA
        //CLIENTE
        public static string ClienteDescricao1;
        public static string ClienteDescricao2;
        public static string ClienteDescricao3;

        //EMPRESA
        public static string EmpresaDescricao1;
        public static string EmpresaDescricao2;
        public static string EmpresaDescricao3;

        //FORNECEDOR
        public static string FornecedorDescricao1;
        public static string FornecedorDescricao2;
        public static string FornecedorDescricao3;

        //FUNCIONÁRIO
        public static string FuncionarioDescricao1;
        public static string FuncionarioDescricao2;
        public static string FuncionarioDescricao3;

        //TRANSPORTADORA
        public static string TransportadoraDescricao1;
        public static string TransportadoraDescricao2;
        public static string TransportadoraDescricao3;
        #endregion

        #region CADASTRO PRODUTO
        public static string Info_Produto1;
        public static string Info_Produto2;
        #endregion
    }

    public static class Parametro_Cadastro
    {
        public static bool Exibe_DuplicarProduto;
        public static bool Somente_Maiusculo;
        public static int Cadastro_PessoaPadrao;
        public static int Endereco_Padrao;
        public static int Telefone_Padrao;

        /// <summary>
        /// <para>1 - ATUALIZA MARGEM</para>
        /// <para>2 - ATUALIZA VALOR VENDA</para>
        /// </summary>
        public static int EntradaProduto;

        public static int Decimal_Produto_Valor;
        public static int Decimal_Produto_Quantidade;
    }
}
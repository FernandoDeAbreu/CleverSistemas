using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Parametro
    {
        public int ID_Empresa { get; set; }

        /// <summary>
        /// <para>1 - FINANCEIRO</para>
        /// <para>2 - VENDAS</para>
        /// <para>3 - MOBILE</para>
        /// <para>4 - USUÁRIO</para>
        /// <para>5 - NF-e/NFC-e</para>
        /// <para>6 - CF-e SAT</para>
        /// <para>7 - ORDEM DE SERVIÇO</para>
        /// <para>8 - CADASTRO PERSONALIZADO</para>
        /// <para>9 - CONFIGURAÇÃO DE EMAIL</para>
        /// <para>10 - PARAMETROS DE CADASTRO</para>
        /// </summary>
        public int Tipo { get; set; }

        public DTO_Parametro_Financeiro Financeiro { get; set; }
        public DTO_Parametro_Vendas Vendas { get; set; }
        public DTO_Parametro_Mobile Mobile { get; set; }
        public DTO_Usuario_Parametros Usuario_Parametros { get; set; }
        public DTO_Parametro_NFe_NFCe NFe_NFCe { get; set; }
        public DTO_Parametro_CFe_SAT CFe_SAT { get; set; }
        public DTO_Parametro_OrdemServico OrdemServico { get; set; }
        public DTO_Parametro_CadastroPersonalizado CadastroPersonalizado { get; set; }
        public DTO_Parametro_Config_Email Config_Email { get; set; }

        public DTO_Parametro_Cadastro Parametro_Cadastro { get; set; }
    }

    public class DTO_Parametro_Financeiro
    {
        public double Juros_Mes { get; set; }
        public double Multa { get; set; }
        public int ID_ContaTransValor { get; set; }
        public int ID_ContaDevolucaoCheque { get; set; }
        public int ID_ContaFaturaVenda { get; set; }
        public int ID_ContaFaturaOS { get; set; }
        public int ID_ContaFaturaCompra { get; set; }
        public int ID_ContaDevolucaoVenda { get; set; }
        public int ID_Caixa_Principal { get; set; }
        public int ID_Conta_PagtoDiverso { get; set; }
        public int ID_Conta_RectoDiverso { get; set; }
        public int ID_Conta_CobrancaBancaria { get; set; }
        public int ID_PagtoBoleto { get; set; }
    }

    public class DTO_Parametro_Vendas
    {
        public int DiasBloqueioVenda { get; set; }
        public int ID_ConsumidorFinal { get; set; }
        public int ID_TabelaVenda { get; set; }
        public int Consulta_Grade { get; set; }
        public int TipoImpressoraTermica { get; set; }
        public bool Ultimo_Valor { get; set; }
        public bool Permitir2Vias { get; set; }
        public bool Agrupar_Produto { get; set; }
        public string Descricao_Comissao { get; set; }
        public double Limite_Desconto { get; set; }
        public bool Produto_Marca { get; set; }
        public bool Bloquear_EstoqueNegativo { get; set; }
        public bool msg_EstoqueNegativo { get; set; }
        public bool Orca_ValorTotal { get; set; }
        public bool MultiploUsuarioPDV { get; set; }
        public bool Consulta_RapidaProduto { get; set; }
        public bool NaoAlterarVendaFaturada { get; set; }
        public int PagamentoTrocoDevolucao { get; set; }
        public bool Venda_Matricial { get; set; }
        public int Modelo_Matricial { get; set; }

        /// <summary>
        /// <para>1 - VALOR</para>
        /// <para>2 - PORCENTAGEM</para> 
        /// </summary>
        public int Desconto_Padrao { get; set; }
        public bool Exibe_NFeVenda { get; set; }
        public bool CFe_Cartao { get; set; }
        public bool Venda_ImpressaoDireta { get; set; }
        public bool CFe_PDV_Cartao { get; set; }
        public Composicao_PrecoVenda Produto_PrecoVenda { get; set; }
        public bool TipoSaida_Fixo { get; set; }
        public bool Altera_ValorPDV { get; set; }
        public int Qt_Dias_Pesquisa { get; set; }
    }

    public class DTO_Parametro_Mobile
    {
        public int HistoricoVenda { get; set; }
    }

    public class DTO_Usuario_Parametros
    {
        public int ID_Usuario { get; set; }
        public bool Venda_Restrita { get; set; }
        public bool Comissao { get; set; }
        public bool Libera_Desconto { get; set; }
        public bool Venda_Fixa_logado { get; set; }
        public bool Permite_Faturar { get; set; }
        public bool Permite_AterarFaturado { get; set; }
        public bool Visualiza_ResumoVenda { get; set; }
        public string Menu { get; set; }
    }

    public class DTO_Parametro_NFe_NFCe
    {
        /// <summary>
        /// <para>1 - PRODUÇÃO</para>
        /// <para>2 - HOMOLOGAÇÃO (TESTES)</para>
        /// </summary>
        public int AmbienteNFe { get; set; }
        public int RegimeTributario { get; set; }
        public bool Exibe_msgCreditoICMS { get; set; }
        public double AliquotaCreditoICMS { get; set; }

        private string caminho_nfe;
        public string Caminho_NFe
        {
            get
            {
                if (caminho_nfe == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(caminho_nfe);
            }

            set { caminho_nfe = value; }
        }

        public bool Exibe_Desconto { get; set; }
        public bool Exibe_InfoProduto { get; set; }
        public bool Exibe_ReferenciaNFe { get; set; }
        public string Certificado_NFe { get; set; }

        public int Tipo_NFe_Venda { get; set; }
    }

    public class DTO_Parametro_CFe_SAT
    {
        /// <summary>
        /// 1 - EMULADOR
        /// 2 - SAT DESENVOLVIDO .NET
        /// </summary>
        public int TipoEquipamentoSAT { get; set; }

        private string senhaativacaosat;
        public string SenhaAtivacaoSAT
        {
            get
            {
                if (senhaativacaosat == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(senhaativacaosat);
            }

            set { senhaativacaosat = value; }
        }

        private string assinaturasat;
        public string AssinaturaSAT
        {
            get
            {
                if (assinaturasat == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(assinaturasat);
            }

            set { assinaturasat = value; }
        }

        public bool CFe_A4 { get; set; }
        public bool Monitor_CFe { get; set; }
    }

    public class DTO_Parametro_OrdemServico
    {
        private string descricao_info1;
        public string Descricao_Info1
        {
            get
            {
                if (descricao_info1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_info1);
            }

            set { descricao_info1 = value; }
        }

        private string descricao_info2;
        public string Descricao_Info2
        {
            get
            {
                if (descricao_info2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_info2);
            }

            set { descricao_info2 = value; }
        }

        private string descricao_info3;
        public string Descricao_Info3
        {
            get
            {
                if (descricao_info3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_info3);
            }

            set { descricao_info3 = value; }
        }

        private string descricao_obs1;
        public string Descricao_Obs1
        {
            get
            {
                if (descricao_obs1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_obs1);
            }

            set { descricao_obs1 = value; }
        }

        private string descricao_obs2;
        public string Descricao_Obs2
        {
            get
            {
                if (descricao_obs2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_obs2);
            }

            set { descricao_obs2 = value; }
        }

        public bool Imprime_OS_Equip { get; set; }
    }

    public class DTO_Parametro_CadastroPersonalizado
    {
        #region CADASTRO PESSOA
        //CLIENTE
        private string clientedescricao1;
        public string ClienteDescricao1
        {
            get
            {
                if (clientedescricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(clientedescricao1);
            }

            set { clientedescricao1 = value; }
        }

        private string clientedescricao2;
        public string ClienteDescricao2
        {
            get
            {
                if (clientedescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(clientedescricao2);
            }

            set { clientedescricao2 = value; }
        }

        private string clientedescricao3;
        public string ClienteDescricao3
        {
            get
            {
                if (clientedescricao3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(clientedescricao3);
            }

            set { clientedescricao3 = value; }
        }

        //EMPRESA
        private string empresadescricao1;
        public string EmpresaDescricao1
        {
            get
            {
                if (empresadescricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(empresadescricao1);
            }

            set { empresadescricao1 = value; }
        }

        private string empresadescricao2;
        public string EmpresaDescricao2
        {
            get
            {
                if (empresadescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(empresadescricao2);
            }

            set { empresadescricao2 = value; }
        }

        private string empresadescricao3;
        public string EmpresaDescricao3
        {
            get
            {
                if (empresadescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(empresadescricao2);
            }

            set { empresadescricao2 = value; }
        }

        //FORNECEDOR
        private string fornecedordescricao1;
        public string FornecedorDescricao1
        {
            get
            {
                if (fornecedordescricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(fornecedordescricao1);
            }

            set { fornecedordescricao1 = value; }
        }

        private string fornecedordescricao2;
        public string FornecedorDescricao2
        {
            get
            {
                if (fornecedordescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(fornecedordescricao2);
            }

            set { fornecedordescricao2 = value; }
        }

        private string fornecedordescricao3;
        public string FornecedorDescricao3
        {
            get
            {
                if (fornecedordescricao3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(fornecedordescricao3);
            }

            set { fornecedordescricao3 = value; }
        }

        //FUNCIONÁRIO
        private string funcionariodescricao1;
        public string FuncionarioDescricao1
        {
            get
            {
                if (funcionariodescricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(funcionariodescricao1);
            }

            set { funcionariodescricao1 = value; }
        }

        private string funcionariodescricao2;
        public string FuncionarioDescricao2
        {
            get
            {
                if (funcionariodescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(funcionariodescricao2);
            }

            set { funcionariodescricao2 = value; }
        }

        private string funcionariodescricao3;
        public string FuncionarioDescricao3
        {
            get
            {
                if (funcionariodescricao3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(funcionariodescricao3);
            }

            set { funcionariodescricao3 = value; }
        }

        //TRANSPORTADORA
        private string transportadoradescricao1;
        public string TransportadoraDescricao1
        {
            get
            {
                if (transportadoradescricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(transportadoradescricao1);
            }

            set { transportadoradescricao1 = value; }
        }

        private string transportadoradescricao2;
        public string TransportadoraDescricao2
        {
            get
            {
                if (transportadoradescricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(transportadoradescricao2);
            }

            set { transportadoradescricao2 = value; }
        }

        private string transportadoradescricao3;
        public string TransportadoraDescricao3
        {
            get
            {
                if (transportadoradescricao3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(transportadoradescricao3);
            }

            set { transportadoradescricao3 = value; }
        }
        #endregion

        #region CADASTRO PRODUTO
        private string info_produto1;
        public string Info_Produto1
        {
            get
            {
                if (info_produto1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(info_produto1);
            }

            set { info_produto1 = value; }
        }

        private string info_produto2;
        public string Info_Produto2
        {
            get
            {
                if (info_produto2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(info_produto2);
            }

            set { info_produto2 = value; }
        }
        #endregion
    }

    public class DTO_Parametro_Config_Email
    {
        private string smtp;
        public string SMTP
        {
            get
            {
                if (smtp == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(smtp);
            }

            set { smtp = value; }
        }

        public int Porta { get; set; }
        public bool SSL { get; set; }

        private string de;
        public string De
        {
            get
            {
                if (de == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(de);
            }

            set { de = value; }
        }

        private string usuario;
        public string Usuario
        {
            get
            {
                if (usuario == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(usuario);
            }

            set { usuario = value; }
        }

        private string senha;
        public string Senha
        {
            get
            {
                if (senha == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(senha);
            }

            set { senha = value; }
        }

        private string email;
        public string Email
        {
            get
            {
                if (email == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(email);
            }

            set { email = value; }
        }
    }

    public class DTO_Parametro_Cadastro
    {
        public bool Exibe_DuplicarProduto { get; set; }
        public int EntradaProduto { get; set; }
        public bool Somente_Maiusculo { get; set; }
        public int Cadastro_PessoaPadrao { get; set; }
        public int Endereco_Padrao { get; set; }
        public int Telefone_Padrao { get; set; }
        public int Decimal_Produto_Valor { get; set; }
        public int Decimal_Produto_Quantidade { get; set; }

    }
}

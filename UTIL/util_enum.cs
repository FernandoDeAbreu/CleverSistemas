using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.UTIL
{
    public enum ObOp
    {
        Obrigatorio,
        Opcional
    }

    public enum ProcessoNF
    {
        Validar,
        ExportarXML,
        Transmitir,
        Assinar,
        ConsultaLote,
        Cancelar,
        CartaCorrecao
    }

    public enum RetornoNFe
    {
        EnvioLote,
        ConsultaLote,
        Cancelamento,
        CartaCorrecao
    }

    public enum Documento
    {
        CNPJ,
        CPF
    }

    public enum StatusForm
    {
        Novo,
        Consulta,
        Edita
    }

    public enum Relatorio
    {
        Visualiza,
        Imprime
    }

    public enum Tipo_Cheque
    {
        DISPONIVEL,
        DEVOLVIDO,
        DEPOSITADO,
        PAGTOTERCEIRO,
        COMPENSADO
    }

    public enum Tipo_Cheque_Lanca
    {
        TRANSFERENCIA,
        DEPOSITO,
        DEVOLVIDO_REPRESENTAR,
        DEVOLVIDO_FINANCEIRO
    }

    public enum Tipo_Sistema
    {
        Comercial,
        Imobiliaria
    }

    public enum Tipo_Parametro
    {
        Financeiro,
        Vendas,
        Mobile,
        Usuario,
        NFe_NFC_e,
        Imagens,
        SAT,
        OrdemServico,
        Cadastro_Personalizado,
        Config_eMail,
        Parametro_Cadastro
    }

    public enum Tipo_Boleto
    {
        Gerar,
        Retorno,
        Baixa,
        Matricial
    }

    public enum Tipo_Financeiro
    {
        Lancamento_Baixa,
        Consulta
    }

    public enum Manutencao_Venda
    {
        Impressao,
        Cancelamento
    }

    public enum Tipo_Impressao
    {
        Retrato,
        Paisagem,
        Termica
    }

    public enum NF_Tipo_Ref
    {
        NFe,
        CTE,
        NotaFiscal,
        CupomFiscal
    }

    public enum CFe_SAT_Funcao
    {
        AtivarSAT,
        EnviarDadosVenda,
        CancelarUltimaVenda,
        ConsultarSAT,
        TesteFimAFim,
        ConsultarStatusOperacional,
        ConsultarNumeroSessao,
        ConfigurarInterfaceDeRede,
        AssociarAssinatura,
        AtualizarSoftwareSAT,
        ExtrairLogs,
        BloquearSAT,
        DesbloquearSAT,
        TrocarCodigoDeAtivacao
    }

    public enum Tipo_NF_SAT
    {
        NFe,
        NFCe,
        SAT
    }

    public enum Consulta_Grade
    {
        Unico,
        Quantidade
    }

    public enum Tipo_Grupo
    {
        Tipo_Cliente,
        Tipo_Transportadora,
        Tipo_Fornecedor,
        Tipo_Funcionario,
        Tipo_Empresa,
        Tipo_Endereco,
        Tipo_Telefone,
        Tipo_eMail,
        Tipo_Caixa,
        Tipo_Atendimento,
        Tipo_Fabricante,
        Tipo_Equipamento,
        Tipo_Unidade,
        Tipo_DocumentoCompra,
        Tipo_Grade,
        Tipo_Comodato,
        Tipo_FolhaPagto,
        Tipo_DocumentoContabil,
        Tipo_Imovel,
        Tipo_Custo_Imovel
    }

    public enum Tipo_DescontoProduto
    {
        Desconto_Atacado,
        Desconto_Pessoa
    }

    public enum Tipo_Entrada_Produto
    {
        Compra,
        Producao,
        NFe
    }

    public enum Composicao_PrecoVenda
    {
        Preco_Compra,//1
        Custo_Final  //2
    }
}

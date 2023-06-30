using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ParametroSistema
{
    public int IdEmpresa { get; set; }

    public decimal? JurosMes { get; set; }

    public decimal? Multa { get; set; }

    public int? DiasBloqueioVenda { get; set; }

    public int? HistoricoVenda { get; set; }

    public int? IdContaTransValor { get; set; }

    public int? IdContaDevolucaoCheque { get; set; }

    public int? AmbienteNfe { get; set; }

    public int? RegimeTributario { get; set; }

    public bool? ExibeMsgCreditoIcms { get; set; }

    public decimal? AliquotaCreditoIcms { get; set; }

    public string? CaminhoNfe { get; set; }

    public bool? ExibeDesconto { get; set; }

    public bool? ExibeInfoProduto { get; set; }

    public string? CertificadoNfe { get; set; }

    public int? TipoNfeVenda { get; set; }

    public int? IdConsumidorFinal { get; set; }

    public int? IdTabelaVenda { get; set; }

    public int? TipoEquipamentoSat { get; set; }

    public string? SenhaAtivacaoSat { get; set; }

    public string? AssinaturaSat { get; set; }

    public int? ConsultaGrade { get; set; }

    public int? TipoImpressoraTermica { get; set; }

    public string? DescricaoInfo1 { get; set; }

    public string? DescricaoInfo2 { get; set; }

    public string? DescricaoInfo3 { get; set; }

    public string? DescricaoObs1 { get; set; }

    public string? DescricaoObs2 { get; set; }

    public int? IdContaFaturaVenda { get; set; }

    public int? IdContaFaturaOs { get; set; }

    public int? IdContaFaturaCompra { get; set; }

    public bool? ImprimeOsEquip { get; set; }

    public bool? UltimoValor { get; set; }

    public bool? Permitir2Vias { get; set; }

    public bool? AgruparProduto { get; set; }

    public string? DescricaoComissao { get; set; }

    public decimal? LimiteDesconto { get; set; }

    public bool? ProdutoMarca { get; set; }

    public bool? BloquearEstoqueNegativo { get; set; }

    public bool? MsgEstoqueNegativo { get; set; }

    public bool? OrcaValorTotal { get; set; }

    public bool? ConsultaRapidaProduto { get; set; }

    public bool? MultiploUsuarioPdv { get; set; }

    public bool? CfeA4 { get; set; }

    public bool? MonitorCfe { get; set; }

    public bool? NaoAlterarVendaFaturada { get; set; }

    public int? PagamentoTrocoDevolucao { get; set; }

    public int? IdContaDevolucaoVenda { get; set; }

    public int? IdCaixaPrincipal { get; set; }

    public int? IdContaPagtoDiverso { get; set; }

    public int? IdContaRectoDiverso { get; set; }

    public int? IdContaCobrancaBancaria { get; set; }

    public int? IdPagtoBoleto { get; set; }

    public string? De { get; set; }

    public string? Email { get; set; }

    public string? ClienteDescricao1 { get; set; }

    public string? ClienteDescricao2 { get; set; }

    public string? ClienteDescricao3 { get; set; }

    public string? EmpresaDescricao1 { get; set; }

    public string? EmpresaDescricao2 { get; set; }

    public string? EmpresaDescricao3 { get; set; }

    public string? FornecedorDescricao1 { get; set; }

    public string? FornecedorDescricao2 { get; set; }

    public string? FornecedorDescricao3 { get; set; }

    public string? FuncionarioDescricao1 { get; set; }

    public string? FuncionarioDescricao2 { get; set; }

    public string? FuncionarioDescricao3 { get; set; }

    public string? TransportadoraDescricao1 { get; set; }

    public string? TransportadoraDescricao2 { get; set; }

    public string? TransportadoraDescricao3 { get; set; }

    public string? InfoProduto1 { get; set; }

    public string? InfoProduto2 { get; set; }

    public bool? VendaMatricial { get; set; }

    public int? ModeloMatricial { get; set; }

    public bool? ExibeDuplicarProduto { get; set; }

    public int? DescontoPadrao { get; set; }

    public bool? ExibeNfeVenda { get; set; }

    public bool? ExibeReferenciaNfe { get; set; }

    public bool? CfeCartao { get; set; }

    public bool? VendaImpressaoDireta { get; set; }

    public bool? CfePdvCartao { get; set; }

    public bool? TipoSaidaFixo { get; set; }

    public int? ProdutoPrecoVenda { get; set; }

    public bool? SomenteMaiusculo { get; set; }

    public int? QtDiasPesquisa { get; set; }

    public int? CadastroPessoaPadrao { get; set; }

    public bool? AlteraValorPdv { get; set; }

    public int? EnderecoPadrao { get; set; }

    public int? TelefonePadrao { get; set; }

    public int? EntradaProduto { get; set; }

    public int? DecimalProdutoValor { get; set; }

    public int? DecimalProdutoQuantidade { get; set; }
}

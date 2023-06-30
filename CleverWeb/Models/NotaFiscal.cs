using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscal
{
    public int Id { get; set; }

    public string? NaturezaOperacao { get; set; }

    public DateTime? DataEmissao { get; set; }

    public DateTime? DataSaida { get; set; }

    public int? TipoDocumento { get; set; }

    public int? FinalidadeEmissao { get; set; }

    public int? FormaEmissao { get; set; }

    public int? FormaPagto { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? IdNfe { get; set; }

    public int? IdEmpresa { get; set; }

    public string? InformacaoAdicional { get; set; }

    public int? Situacao { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public int? IdVenda { get; set; }

    public int? TipoFrete { get; set; }

    public int? TipoImpressao { get; set; }

    public int? DigVerificador { get; set; }

    public DateTime? DataContigencia { get; set; }

    public string? Justificativa { get; set; }

    public string? IeSubstituicao { get; set; }

    public decimal? ValorBc { get; set; }

    public decimal? ValorIcms { get; set; }

    public decimal? ValorBcst { get; set; }

    public decimal? ValorSt { get; set; }

    public decimal? ValorProduto { get; set; }

    public decimal? ValorFrete { get; set; }

    public decimal? ValorSeguro { get; set; }

    public decimal? ValorDesconto { get; set; }

    public decimal? ValorImportacao { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? ValorPis { get; set; }

    public decimal? ValorCofins { get; set; }

    public decimal? ValorOutro { get; set; }

    public string? InformacaoFisco { get; set; }

    public int? TipoFrete1 { get; set; }

    public int? TipoNf { get; set; }

    public int? Serie { get; set; }

    public decimal? ValorIcmsdesonerado { get; set; }

    public bool? ConsumidorFinal { get; set; }

    public int? PresencaConsumidor { get; set; }

    public int? Modelo { get; set; }

    public string? CnpjCpfDestinatario { get; set; }

    public string? Chave { get; set; }

    public string? QrcodeCfe { get; set; }

    public decimal? TribFederal { get; set; }

    public decimal? TribEstadual { get; set; }

    public decimal? TribMunicipal { get; set; }

    public int? ControleCf { get; set; }

    public int? IdOs { get; set; }

    public int? StatusCfe { get; set; }

    public string? RetornoCfe { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Creceber
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdConta { get; set; }

    public string? GrupoConta { get; set; }

    public int? Situacao { get; set; }

    public string? Documento { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public decimal? Valor { get; set; }

    public bool? Parcelado { get; set; }

    public int? QuantidadeParcela { get; set; }

    public int? Parcela { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataBaixa { get; set; }

    public decimal? Desconto { get; set; }

    public decimal? Acrescimo { get; set; }

    public int? Caixa { get; set; }

    public int? IdPagamento { get; set; }

    public string? InformacaoBaixa { get; set; }

    public int? Controle { get; set; }

    public bool? Boleto { get; set; }

    public int? IdVenda { get; set; }

    public int? IdPrevisaoPagto { get; set; }

    public int? IdOs { get; set; }
}

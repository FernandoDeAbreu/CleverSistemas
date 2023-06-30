using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VChequeHistorico
{
    public int IdCpagar { get; set; }

    public int IdCreceber { get; set; }

    public string? Documento { get; set; }

    public DateTime? DataBaixa { get; set; }

    public string? Descricao { get; set; }

    public string? DescricaoPessoa { get; set; }

    public string? DescricaoConta { get; set; }

    public decimal? Credito { get; set; }

    public decimal? Debito { get; set; }

    public int? IdCheque { get; set; }

    public decimal? Total { get; set; }

    public int IdFluxoCaixa { get; set; }

    public DateTime? Emissao { get; set; }

    public int? IdCaixa { get; set; }

    public int? IdPagamento { get; set; }

    public decimal? CreditoFluxo { get; set; }

    public decimal? DebitoFluxo { get; set; }

    public string? DescricaoCaixa { get; set; }

    public string? DescricaoContaFluxo { get; set; }
}

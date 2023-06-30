using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class FluxoCaixa
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public DateTime? Emissao { get; set; }

    public int? Caixa { get; set; }

    public string? Documento { get; set; }

    public int? IdConta { get; set; }

    public string? GrupoConta { get; set; }

    public decimal? Credito { get; set; }

    public decimal? Debito { get; set; }

    public string? Informacao { get; set; }

    public bool? Conciliado { get; set; }

    public int? IdCheque { get; set; }

    public int? IdPagamento { get; set; }

    public bool? Planejamento { get; set; }
}

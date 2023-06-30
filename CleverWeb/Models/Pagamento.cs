using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Pagamento
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public decimal? PorcCusto { get; set; }

    public decimal? VlrCusto { get; set; }

    public int? QtParcela { get; set; }

    public int? Tipo { get; set; }

    public bool? Recebimento { get; set; }

    public bool? Pagamento1 { get; set; }

    public int? DiaLancamento { get; set; }
}

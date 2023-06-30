using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PagamentoParc
{
    public int Id { get; set; }

    public int? IdPagamento { get; set; }

    public string? Parcelamento { get; set; }

    public bool? Personalizado { get; set; }

    public int? Periodo { get; set; }
}

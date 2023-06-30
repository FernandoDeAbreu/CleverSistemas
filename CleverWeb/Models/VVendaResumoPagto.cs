using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VVendaResumoPagto
{
    public string? Descricao { get; set; }

    public int IdVenda { get; set; }

    public DateTime? Data { get; set; }

    public decimal? Credito { get; set; }

    public decimal? ValorPago { get; set; }
}

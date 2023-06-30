using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VOrdemServicoResumoPagto
{
    public string? Descricao { get; set; }

    public int IdOs { get; set; }

    public DateTime? Data { get; set; }

    public decimal? Credito { get; set; }

    public decimal? ValorPago { get; set; }
}

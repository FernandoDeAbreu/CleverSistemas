using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class UfAliquotaIcm
{
    public int? IdUfOrigem { get; set; }

    public int? IdUfDestino { get; set; }

    public decimal? Aliquota { get; set; }
}

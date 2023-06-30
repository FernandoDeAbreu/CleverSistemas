using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalDuplicatum
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public string? NumeroDuplicata { get; set; }

    public DateTime? Vencimento { get; set; }

    public decimal? Valor { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalCobranca
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public string? NumeroFatura { get; set; }

    public decimal? Valor { get; set; }

    public decimal? Desconto { get; set; }

    public decimal? ValorFinal { get; set; }
}

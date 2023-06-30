using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class TabelaValor
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public decimal? Margem { get; set; }

    public decimal? CustoOperacional { get; set; }
}

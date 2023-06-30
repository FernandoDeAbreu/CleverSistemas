using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImovelCusto
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public int? IdTipo { get; set; }

    public decimal? Valor { get; set; }
}

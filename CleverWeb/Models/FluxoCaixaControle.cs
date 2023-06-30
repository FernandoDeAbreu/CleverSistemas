using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class FluxoCaixaControle
{
    public int Id { get; set; }

    public int? IdFluxoCaixa { get; set; }

    public int? IdCpagar { get; set; }

    public int? IdCreceber { get; set; }
}

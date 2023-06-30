using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImovelVistorium
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public string? Local { get; set; }

    public string? Descricao { get; set; }
}

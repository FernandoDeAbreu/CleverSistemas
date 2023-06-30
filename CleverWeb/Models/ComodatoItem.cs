using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ComodatoItem
{
    public int Id { get; set; }

    public int? IdComodato { get; set; }

    public decimal? Quantidade { get; set; }

    public string? Descricao { get; set; }

    public string? Marca { get; set; }
}

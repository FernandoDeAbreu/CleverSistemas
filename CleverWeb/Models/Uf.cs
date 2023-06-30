using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Uf
{
    public int Id { get; set; }

    public int? IdPais { get; set; }

    public int? IdUf { get; set; }

    public string? Sigla { get; set; }

    public string? Descricao { get; set; }

    public decimal? AliquotaInterna { get; set; }

    public decimal? AliquotaFcp { get; set; }
}

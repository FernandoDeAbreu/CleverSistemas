using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public int? IdPais { get; set; }

    public int? IdUf { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Descricao { get; set; }
}

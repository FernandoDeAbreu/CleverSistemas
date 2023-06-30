using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Ncm
{
    public int Id { get; set; }

    public int? Ncm1 { get; set; }

    public string? Descricao { get; set; }

    public decimal? AliqNacFederal { get; set; }

    public decimal? AliqImpFederal { get; set; }

    public int? Ex { get; set; }

    public decimal? AliqEstadual { get; set; }
}

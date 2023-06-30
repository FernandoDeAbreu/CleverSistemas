using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImovelContrato
{
    public int Id { get; set; }

    public int? IdProprietario { get; set; }

    public DateTime? Emissao { get; set; }

    public string? DescricaoTest1 { get; set; }

    public string? DescricaoTest2 { get; set; }

    public string? DocTest1 { get; set; }

    public string? DocTest2 { get; set; }
}

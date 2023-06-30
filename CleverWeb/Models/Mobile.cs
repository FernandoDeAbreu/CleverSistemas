using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Mobile
{
    public int Id { get; set; }

    public string? Imei { get; set; }

    public string? Equipamento { get; set; }

    public bool? Ativo { get; set; }
}

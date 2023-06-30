using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class BoletoRemessa
{
    public int Id { get; set; }

    public DateTime? Emissao { get; set; }

    public string? Arquivo { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class BoletoControle
{
    public int Id { get; set; }

    public int? IdBoleto { get; set; }

    public int? IdConta { get; set; }
}

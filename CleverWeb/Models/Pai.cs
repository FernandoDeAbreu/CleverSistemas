using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Pai
{
    public int Id { get; set; }

    public int? IdPais { get; set; }

    public string? Descricao { get; set; }
}

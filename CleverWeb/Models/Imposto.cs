using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Imposto
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public string? Descricao { get; set; }
}

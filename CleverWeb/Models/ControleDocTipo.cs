using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ControleDocTipo
{
    public int Id { get; set; }

    public int? IdTipo { get; set; }

    public string? Descricao { get; set; }
}

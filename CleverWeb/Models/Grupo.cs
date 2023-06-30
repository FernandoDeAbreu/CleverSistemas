using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Grupo
{
    public int Id { get; set; }

    public int? Tipo { get; set; }

    public string? Descricao { get; set; }

    public bool? Exibir { get; set; }
}

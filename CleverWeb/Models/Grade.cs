using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int? IdGrupo { get; set; }

    public string? Descricao { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class GrupoNivel
{
    public int Id { get; set; }

    public int? Nivel { get; set; }

    public string? CodigoPai { get; set; }

    public string? Codigo { get; set; }

    public string? CodigoDescritivo { get; set; }

    public string? Descricao { get; set; }
}

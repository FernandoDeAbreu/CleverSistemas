using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VHistoricoVendum
{
    public int Id { get; set; }

    public int? IdPessoa { get; set; }

    public string? Data { get; set; }

    public int? IdTabela { get; set; }

    public int? IdParcelamento { get; set; }

    public string? Informacao { get; set; }

    public int Desconto { get; set; }

    public string? Comprador { get; set; }

    public int? IdUsuario { get; set; }
}

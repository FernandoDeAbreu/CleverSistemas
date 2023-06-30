using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VHistoricoVendaItem
{
    public int? IdVenda { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Quantidade { get; set; }

    public string? Informacao { get; set; }

    public int? TipoSaida { get; set; }

    public int? IdUsuario { get; set; }
}

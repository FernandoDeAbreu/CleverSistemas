using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VendaExternoItem
{
    public int Id { get; set; }

    public int? IdVendaExterna { get; set; }

    public int? IdProduto { get; set; }

    public string? Informacao { get; set; }

    public virtual ProdutoServico? IdProdutoNavigation { get; set; }

    public virtual VendaExterno? IdVendaExternaNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoComissao
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTipoComissao { get; set; }

    public decimal? Comissao { get; set; }
}

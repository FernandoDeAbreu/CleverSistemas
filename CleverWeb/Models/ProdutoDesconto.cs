using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoDesconto
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdProduto { get; set; }

    public decimal? QuantidadeMinima { get; set; }

    public decimal? QuantidadeMaxima { get; set; }

    public decimal? Desconto { get; set; }
}

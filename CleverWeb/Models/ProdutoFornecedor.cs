using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoFornecedor
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdFornecedor { get; set; }

    public string? CodigoProduto { get; set; }
}

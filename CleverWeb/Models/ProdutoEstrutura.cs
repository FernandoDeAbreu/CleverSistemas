using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoEstrutura
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdProdutoEstrutura { get; set; }

    public int? IdGradeEstrutura { get; set; }

    public decimal? Quantidade { get; set; }
}

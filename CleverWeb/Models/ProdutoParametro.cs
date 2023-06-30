using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoParametro
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdImposto { get; set; }

    public int? IdEmpresa { get; set; }

    public bool? Ativo { get; set; }
}

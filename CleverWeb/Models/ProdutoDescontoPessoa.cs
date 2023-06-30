using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoDescontoPessoa
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdProduto { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public int? Tipo { get; set; }

    public decimal? Desconto { get; set; }
}

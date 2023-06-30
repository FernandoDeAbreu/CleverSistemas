using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoMovimento
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public DateTime? Data { get; set; }

    public int? IdProduto { get; set; }

    public int? Tipo { get; set; }

    public decimal? Quantidade { get; set; }

    public string? Informacao { get; set; }
}

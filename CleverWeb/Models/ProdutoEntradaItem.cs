using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoEntradaItem
{
    public int Id { get; set; }

    public int? IdProdutoEntrada { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Quantidade { get; set; }

    public decimal? ValorCompra { get; set; }

    public decimal? OutrosCustos { get; set; }

    public int? IdGrade { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? ValorSt { get; set; }

    public decimal? ValorVenda { get; set; }

    public decimal? Margem { get; set; }

    public decimal? ValorAntigo { get; set; }

    public string? NfeDescricao { get; set; }

    public string? NfeCodigoProduto { get; set; }
}

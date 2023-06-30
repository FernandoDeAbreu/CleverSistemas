using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VProdutoMovimento
{
    public int? IdEmpresa { get; set; }

    public DateTime? Data { get; set; }

    public string? UltimoLancamento { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Compra { get; set; }

    public decimal? Venda { get; set; }

    public string? Tipo { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public string? Barra { get; set; }

    public string? Pessoa { get; set; }
}

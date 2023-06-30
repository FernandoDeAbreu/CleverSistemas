using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoValor
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdTabela { get; set; }

    public decimal? MargemVenda { get; set; }

    public decimal? ValorVenda { get; set; }

    public DateTime? UltimoReajuste { get; set; }
}

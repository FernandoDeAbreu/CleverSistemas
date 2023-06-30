using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoEstoque
{
    public int Id { get; set; }

    public int? IdProduto { get; set; }

    public int? IdGrade { get; set; }

    public decimal? EstoqueAtual { get; set; }

    public decimal? EstoqueIdeal { get; set; }

    public decimal? EstoqueMinimo { get; set; }

    public string? Localizacao { get; set; }

    public int? IdEmpresa { get; set; }
}

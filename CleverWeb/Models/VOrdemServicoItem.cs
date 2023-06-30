using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VOrdemServicoItem
{
    public int Iditem { get; set; }

    public int? IdOs { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Quantidade { get; set; }

    public int? IdTabela { get; set; }

    public decimal? ValorProduto { get; set; }

    public decimal? ValorVenda { get; set; }

    public decimal? ValorCusto { get; set; }

    public decimal? ValorTotal { get; set; }

    public string? Informacao { get; set; }

    public decimal Desconto { get; set; }

    public decimal Acrescimo { get; set; }

    public int? TipoSaida { get; set; }

    public int? IdGrade { get; set; }

    public decimal? QuantidadeEntregue { get; set; }

    public string? DescricaoSaida { get; set; }

    public string? Marca { get; set; }

    public string? Referencia { get; set; }

    public bool? ControleEstoque { get; set; }

    public int? Tipo { get; set; }

    public string? DescricaoProduto { get; set; }
}

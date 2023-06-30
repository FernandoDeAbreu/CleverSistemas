using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Produto
{
    public int Id { get; set; }

    public int? IdGrupo { get; set; }

    public int? Tipo { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public string? Fabricante { get; set; }

    public string? Informacao { get; set; }

    public string? Barra { get; set; }

    public string? Barratributavel { get; set; }

    public string? Ncm { get; set; }

    public decimal? ValorCompra { get; set; }

    public decimal? OutrosCustos { get; set; }

    public decimal? CustoFinal { get; set; }

    public int? UnidadeTributavel { get; set; }

    public int? Validade { get; set; }

    public int? Garantia { get; set; }

    public int? ExTipi { get; set; }

    public string? Cnpjprodutor { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public int? CodAnp { get; set; }

    public bool? ProdutoEspecifico { get; set; }

    public decimal? PesoB { get; set; }

    public decimal? PesoL { get; set; }

    public decimal? ValorIpi { get; set; }

    public bool? ControleEstoque { get; set; }

    public byte[]? Imagem { get; set; }

    public int? IdEmpresa { get; set; }

    public bool? Ativo { get; set; }

    public int? IdImposto { get; set; }

    public string? DescricaoUnidade { get; set; }

    public string? DescricaoGrupo { get; set; }

    public string? CodGrupo { get; set; }

    public string? DescricaoImposto { get; set; }
}

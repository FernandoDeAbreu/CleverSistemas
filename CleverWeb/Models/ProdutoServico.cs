using CleverWeb.Shared;
using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoServico
{
    public int Id { get; set; }

    public bool? MultiEmpresa { get; set; }

    public int? IdEmpresa { get; set; }

    public string? GrupoNivel { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public string? Fabricante { get; set; }

    public string? Informacao { get; set; }

    public string? Barra { get; set; }

    public string? Barratributavel { get; set; }

    public string? Ncm { get; set; }

    public decimal? ValorCompra { get; set; }

    public decimal? OutrosCustos { get; set; }

    public int? UnidadeTributavel { get; set; }

    public int? Validade { get; set; }

    public int? Garantia { get; set; }

    public bool? Situacao { get; set; }

    public TipoProdutoEnum Tipo { get; set; }

    public int? ExTipi { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public string? Cnpjprodutor { get; set; }

    public decimal? CustoFinal { get; set; }

    public int? IdGrupo { get; set; }

    public byte[]? Imagem { get; set; }

    public decimal? PesoB { get; set; }

    public decimal? PesoL { get; set; }

    public decimal? ValorIpi { get; set; }

    public bool? ControleEstoque { get; set; }

    public bool? ProdutoEspecifico { get; set; }

    public int? CodAnp { get; set; }

    public decimal? ValorSt { get; set; }

    public string? InfoAdicional1 { get; set; }

    public string? InfoAdicional2 { get; set; }

    public string? Abc { get; set; }

    public int? IdCest { get; set; }

    public virtual ICollection<VendaExternoItem> VendaExternoItems { get; set; } = new List<VendaExternoItem>();
}

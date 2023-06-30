using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VProdutoVendum
{
    public bool? Ativo { get; set; }

    public int? IdEmpresa { get; set; }

    public int Id { get; set; }

    public int? IdGrupo { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public string? Fabricante { get; set; }

    public string? Informacao { get; set; }

    public byte[]? Imagem { get; set; }

    public string? Barra { get; set; }

    public string? BarraTributavel { get; set; }

    public string? Ncm { get; set; }

    public decimal? ValorCompra { get; set; }

    public decimal? OutrosCustos { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? ValorSt { get; set; }

    public decimal? CustoFinal { get; set; }

    public int? UnidadeTributavel { get; set; }

    public int? Validade { get; set; }

    public int? Garantia { get; set; }

    public int? Tipo { get; set; }

    public string? InfoAdicional1 { get; set; }

    public string? InfoAdicional2 { get; set; }

    public int? IdTabela { get; set; }

    public decimal? MargemVenda { get; set; }

    public decimal? ValorVenda { get; set; }

    public DateTime? UltimoReajuste { get; set; }

    public string? BarraEtiqueta { get; set; }

    public int? IdGrade { get; set; }

    public decimal? EstoqueMinimo { get; set; }

    public decimal? EstoqueIdeal { get; set; }

    public decimal? EstoqueAtual { get; set; }

    public string? Localizacao { get; set; }

    public string? DescricaoGrade { get; set; }

    public int? IdGrupoGrade { get; set; }

    public string? Unidade { get; set; }

    public string? DescricaoCompleta { get; set; }

    public string? DescricaoGrupo { get; set; }

    public string? CodGrupo { get; set; }
}

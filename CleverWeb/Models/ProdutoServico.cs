using CleverWeb.Shared;
using System.ComponentModel.DataAnnotations;

namespace CleverWeb.Models;

public partial class ProdutoServico
{
    public int Id { get; set; }

    public bool? MultiEmpresa { get; set; }

    public int? IdEmpresa { get; set; }

    public string? GrupoNivel { get; set; }

    [Required]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Required]
    [Display(Name = "Referência")]
    public string? Referencia { get; set; }

    [Display(Name = "Fabricante")]
    public string? Fabricante { get; set; }

    [Display(Name = "Informação")]
    public string? Informacao { get; set; }

    [Required]
    [Display(Name = "Código de barras")]
    public string? Barra { get; set; }

    public string? Barratributavel { get; set; }

    public string? Ncm { get; set; }

    [Required]
    [Display(Name = "Valor Compra R$")]
    public decimal ValorCompra { get; set; }

    [Display(Name = "Outros Custo R$")]
    public decimal? OutrosCustos { get; set; }

    [Display(Name = "Valor IPI R$")]
    public decimal? ValorIpi { get; set; }

    [Display(Name = "Valor ST R$")]
    public decimal? ValorSt { get; set; }

    [Required]
    [Display(Name = "Custo Final R$")]
    public decimal? CustoFinal { get; set; }

    public int? UnidadeTributavel { get; set; }

    public int? Validade { get; set; }

    public int? Garantia { get; set; }

    public bool? Situacao { get; set; }

    public TipoProduto Tipo { get; set; }

    public int? ExTipi { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public string? Cnpjprodutor { get; set; }

    public int? IdGrupo { get; set; }

    public byte[]? Imagem { get; set; }

    public decimal? PesoB { get; set; }

    public decimal? PesoL { get; set; }

    public bool? ControleEstoque { get; set; }

    public bool? ProdutoEspecifico { get; set; }

    public int? CodAnp { get; set; }

    public string? InfoAdicional1 { get; set; }

    public string? InfoAdicional2 { get; set; }

    public string? Abc { get; set; }

    public int? IdCest { get; set; }

    public virtual ICollection<VendaExternoItem> VendaExternoItems { get; set; } = new List<VendaExternoItem>();
}
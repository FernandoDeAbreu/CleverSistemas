using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VProdutoImposto
{
    public int IdProduto { get; set; }

    public int? Tipo { get; set; }

    public int? IdGrupo { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public string? Fabricante { get; set; }

    public string? Informacao { get; set; }

    public string? Barra { get; set; }

    public string? BarraTributavel { get; set; }

    public string? Ncm { get; set; }

    public decimal? ValorCompra { get; set; }

    public decimal? OutrosCustos { get; set; }

    public decimal? CustoFinal { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? ValorSt { get; set; }

    public int? UnidadeTributavel { get; set; }

    public int? Validade { get; set; }

    public int? Garantia { get; set; }

    public int? Situacao { get; set; }

    public int? ExTipi { get; set; }

    public string? Cnpjprodutor { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public int? CodAnp { get; set; }

    public bool? ProdutoEspecifico { get; set; }

    public int? IdCest { get; set; }

    public int IdImpostoProduto { get; set; }

    public int? IdEmpresa { get; set; }

    public decimal? MargemVenda { get; set; }

    public decimal? ValorVenda { get; set; }

    public DateTime? UltimoReajuste { get; set; }

    public int? IdTabela { get; set; }

    public int? IdImposto { get; set; }

    public string? Cfop { get; set; }

    public int? Cst { get; set; }

    public int? Origem { get; set; }

    public int? TipoNf { get; set; }

    public int? ModalidadeBc { get; set; }

    public decimal? AliquotaIcms { get; set; }

    public decimal? PercentualReducao { get; set; }

    public int? ModalidadeBcst { get; set; }

    public decimal? AliquotaIcmsst { get; set; }

    public decimal? PercentualReducaoSt { get; set; }

    public decimal? MargemVadicionado { get; set; }

    public int? Cstpis { get; set; }

    public decimal? AliquotaPis { get; set; }

    public decimal? AliquotaPisst { get; set; }

    public int? Cstcofins { get; set; }

    public decimal? AliquotaCofins { get; set; }

    public decimal? AliquotaCofinsst { get; set; }

    public int? Cstipi { get; set; }

    public decimal? AliquotaIpi { get; set; }

    public string? CodEnquadramento { get; set; }

    public int? IdUf { get; set; }
}

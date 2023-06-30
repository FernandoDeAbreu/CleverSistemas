using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VOrdemServicoItemImpostoCf
{
    public int? IdOs { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Quantidade { get; set; }

    public int? IdTabela { get; set; }

    public decimal? ValorProduto { get; set; }

    public decimal Acrescimo { get; set; }

    public decimal Desconto { get; set; }

    public decimal? ValorVenda { get; set; }

    public int? IdGrade { get; set; }

    public decimal? ValorTotal { get; set; }

    public string? Informacao { get; set; }

    public int? TipoSaida { get; set; }

    public string? DescricaoProduto { get; set; }

    public decimal? ValorCusto { get; set; }

    public int? ExTipi { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public string? Cnpjprodutor { get; set; }

    public string? Ncm { get; set; }

    public int? IdCest { get; set; }

    public int? IdEmpresa { get; set; }

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
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImpostoTributacao
{
    public int Id { get; set; }

    public int? IdImposto { get; set; }

    public int? TipoNf { get; set; }

    public string? Cfop { get; set; }

    public int? Cst { get; set; }

    public int? Origem { get; set; }

    public int? ModalidadeBc { get; set; }

    public decimal? AliquotaIcms { get; set; }

    public decimal? PercentualReducao { get; set; }

    public int? ModalidadeBcst { get; set; }

    public decimal? AliquotaIcmsst { get; set; }

    public decimal? PercentualReducaoSt { get; set; }

    public decimal? MargemVadicionado { get; set; }

    public decimal? VIcmsdeson { get; set; }

    public decimal? VIcmsop { get; set; }

    public decimal? PDif { get; set; }

    public decimal? VIcmsdif { get; set; }

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

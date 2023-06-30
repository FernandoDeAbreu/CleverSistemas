using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalItem
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public int? IdProduto { get; set; }

    public decimal? Quantidade { get; set; }

    public int? IdTabela { get; set; }

    public decimal? ValorUnitario { get; set; }

    public decimal? ValorTotal { get; set; }

    public decimal? Acrescimo { get; set; }

    public decimal? Desconto { get; set; }

    public string? InformacaoAdicional { get; set; }

    public int? TipoVendaProduto { get; set; }

    public int? IdGrade { get; set; }

    public int? ExTipi { get; set; }

    public string? QuantidadeSelo { get; set; }

    public string? ClasseEnquadramento { get; set; }

    public string? Cnpjprodutor { get; set; }

    public string? CodigoSelo { get; set; }

    public int? Cst { get; set; }

    public int? Origem { get; set; }

    public int? ModalidadeBc { get; set; }

    public decimal? AliquotaIcms { get; set; }

    public decimal? PercentualReducao { get; set; }

    public int? ModalidadeBcst { get; set; }

    public decimal? AliquotaIcmsst { get; set; }

    public decimal? PercentualReducaoSt { get; set; }

    public decimal? MargemVladicionado { get; set; }

    public string? Cfop { get; set; }

    public decimal? Frete { get; set; }

    public decimal? Seguro { get; set; }

    public decimal? ValorBc { get; set; }

    public decimal? ValorIcms { get; set; }

    public decimal? ValorBcst { get; set; }

    public decimal? ValorIcmsst { get; set; }

    public decimal? ValorBcstret { get; set; }

    public decimal? ValorIcmsstret { get; set; }

    public string? Csosn { get; set; }

    public decimal? AliquotaCredito { get; set; }

    public decimal? ValorCredito { get; set; }

    public string? Cstipi { get; set; }

    public decimal? AliquotaIpi { get; set; }

    public decimal? ValorIpi { get; set; }

    public decimal? ValorBcii { get; set; }

    public decimal? ValorDesIi { get; set; }

    public decimal? ValorIi { get; set; }

    public decimal? ValorIof { get; set; }

    public string? Cstpis { get; set; }

    public decimal? AliquotaPis { get; set; }

    public decimal? ValorPis { get; set; }

    public decimal? ValorAliquotaPis { get; set; }

    public string? Cstcofins { get; set; }

    public decimal? AliquotaCofins { get; set; }

    public decimal? ValorCofins { get; set; }

    public decimal? ValorAliquotaCofins { get; set; }

    public decimal? ValorIcmsoperacao { get; set; }

    public decimal? PercentualDiferimento { get; set; }

    public decimal? ValorIcmsdeferido { get; set; }

    public decimal? ValorIcmsdesonerado { get; set; }

    public int? MotivoDesonerado { get; set; }

    public decimal? Ipidevolvido { get; set; }

    public decimal? PerIpidevolvido { get; set; }
}

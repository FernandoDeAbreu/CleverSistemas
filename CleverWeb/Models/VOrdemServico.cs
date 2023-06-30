using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VOrdemServico
{
    public int IdOs { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? DataAbertura { get; set; }

    public DateTime? DataOrcamento { get; set; }

    public DateTime? DataAprovacao { get; set; }

    public DateTime? DataMontagem { get; set; }

    public DateTime? DataPronta { get; set; }

    public DateTime? DataEntrega { get; set; }

    public bool? Garantia { get; set; }

    public string? Reclamacao { get; set; }

    public string? Observacao { get; set; }

    public int? TipoAtendimento { get; set; }

    public int? TipoEquipamento { get; set; }

    public int? Marca { get; set; }

    public string? InfoEquip1 { get; set; }

    public string? InfoEquip2 { get; set; }

    public string? InfoEquip3 { get; set; }

    public string? ObsEquip1 { get; set; }

    public string? ObsEquip2 { get; set; }

    public int? StatusOs { get; set; }

    public int? IdUsuarioComissao1 { get; set; }

    public int? IdUsuarioComissao2 { get; set; }

    public string? InformacaoCompleta { get; set; }

    public bool? Faturado { get; set; }

    public bool? Nfe { get; set; }

    public bool? Cancelado { get; set; }

    public string? CpfCnpj { get; set; }

    public int? IdNfe { get; set; }

    public int? IdCfe { get; set; }

    public string? DescricaoStatus { get; set; }

    public string? Descricao { get; set; }

    public string? Complemento { get; set; }

    public string? Municipio { get; set; }

    public int? IdUf { get; set; }

    public decimal? ValorTotal { get; set; }

    public decimal? CustoTotal { get; set; }

    public string? DescricaoAtendimento { get; set; }

    public string? DescricaoEquipamento { get; set; }

    public string? DescricaoMarca { get; set; }
}

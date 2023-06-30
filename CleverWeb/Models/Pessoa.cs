using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Pessoa
{
    public int Id { get; set; }

    public bool? MultiEmpresa { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public int? TipoDocumento { get; set; }

    public string? CnpjCpf { get; set; }

    public string? NomeRazao { get; set; }

    public string? NomeFantasia { get; set; }

    public string? Contato { get; set; }

    public string? IeRg { get; set; }

    public string? Im { get; set; }

    public string? Cnae { get; set; }

    public DateTime? Cadastro { get; set; }

    public string? Informacao { get; set; }

    public int? IdGrupo { get; set; }

    public DateTime? NascimentoFundacao { get; set; }

    public string? RamoProfissao { get; set; }

    public string? Descricao1 { get; set; }

    public string? Descricao2 { get; set; }

    public string? Descricao3 { get; set; }

    public decimal? Limite { get; set; }

    public int? DiaFaturamento { get; set; }

    public int? SituacaoOld { get; set; }

    public string? Cei { get; set; }

    public decimal? ValorMensalidade { get; set; }

    public int? Responsavel { get; set; }

    public string? Conjuge { get; set; }

    public string? CpfConjuge { get; set; }

    public string? ProfissaoConjuge { get; set; }

    public string? RgConjuge { get; set; }

    public bool? Situacao { get; set; }

    public decimal? DescontoVenda { get; set; }

    public string? InformacaoVenda { get; set; }

    public string? DiaFaturamento1 { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VResumoLocacao
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Inicio { get; set; }

    public DateTime? Termino { get; set; }

    public int? DiaVencimento { get; set; }

    public decimal? Valor { get; set; }

    public string? DescricaoTest1 { get; set; }

    public string? DescricaoTest2 { get; set; }

    public string? DocTest1 { get; set; }

    public string? DocTest2 { get; set; }

    public string? Observacao { get; set; }

    public string? Descricao { get; set; }

    public int? IdTipo { get; set; }

    public int? TipoImovel { get; set; }

    public decimal? Area { get; set; }

    public decimal? ValorImovel { get; set; }

    public decimal? ComissaoPorc { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Rgi { get; set; }

    public string? Uc { get; set; }

    public decimal? ComissaoValor { get; set; }

    public int? IdLocacao { get; set; }

    public int? IdLocatario { get; set; }

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

    public int? Situacao { get; set; }

    public string? Cei { get; set; }

    public string? Conjuge { get; set; }

    public string? CpfConjuge { get; set; }

    public string? ProfissaoConjuge { get; set; }

    public string? RgConjuge { get; set; }
}

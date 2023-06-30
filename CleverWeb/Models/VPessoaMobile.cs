using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VPessoaMobile
{
    public int Id { get; set; }

    public int? IdVendedor { get; set; }

    public string? NomeRazao { get; set; }

    public string? NomeFantasia { get; set; }

    public string? CnpjCpf { get; set; }

    public string? IeRg { get; set; }

    public string? Descricao1 { get; set; }

    public string? Descricao2 { get; set; }

    public string? Descricao3 { get; set; }

    public string? Informacao { get; set; }

    public string? Cei { get; set; }

    public string? Conjuge { get; set; }

    public string? CpfConjuge { get; set; }

    public string? RgConjuge { get; set; }

    public string? ProfissaoConjuge { get; set; }

    public string? DescricaoGrupo { get; set; }

    public string? Logradouro { get; set; }

    public string? NumeroEndereco { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public string? Complemento { get; set; }

    public string? Ddd { get; set; }

    public string? NumeroTelefone { get; set; }

    public string? Email { get; set; }

    public string? Municipio { get; set; }

    public int? IdPais { get; set; }

    public int? IdUf { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Uf { get; set; }

    public string? Pais { get; set; }
}

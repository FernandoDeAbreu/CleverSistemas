using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaEndereco
{
    public int IdEndereco { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public bool? PrincipalEndereco { get; set; }

    public int? TipoEndereco { get; set; }

    public string? Logradouro { get; set; }

    public string? NumeroEndereco { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Cep { get; set; }

    public int? IdPais { get; set; }
}

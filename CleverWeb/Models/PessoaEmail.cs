using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaEmail
{
    public int IdEmail { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public bool? PrincipalEmail { get; set; }

    public int? TipoEmail { get; set; }

    public string? Email { get; set; }

    public string? InformacaoEmail { get; set; }
}

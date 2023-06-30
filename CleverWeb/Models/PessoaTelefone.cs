using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaTelefone
{
    public int IdTelefone { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public bool? PrincipalTelefone { get; set; }

    public int? TipoTelefone { get; set; }

    public string? Ddd { get; set; }

    public string? NumeroTelefone { get; set; }

    public string? InformacaoTelefone { get; set; }
}

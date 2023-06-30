using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaEmpresaResponsavel
{
    public int Id { get; set; }

    public int? IdPessoa { get; set; }

    public int? TipoPessoaResponsavel { get; set; }

    public int? IdPessoaResponsavel { get; set; }

    public int? TipoPessoa { get; set; }
}

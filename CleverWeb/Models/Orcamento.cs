using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Orcamento
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Data { get; set; }

    public string? Informacao { get; set; }

    public int? IdUsuarioComissao1 { get; set; }

    public int? IdUsuarioComissao2 { get; set; }

    public int? IdUsuarioComissao3 { get; set; }
}

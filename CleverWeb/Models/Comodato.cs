using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Comodato
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Data { get; set; }

    public int? Situacao { get; set; }
}

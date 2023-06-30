using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaProprietario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? Referencia { get; set; }
}

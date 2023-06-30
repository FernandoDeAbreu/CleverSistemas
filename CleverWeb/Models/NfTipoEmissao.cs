using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NfTipoEmissao
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public string? Descricao { get; set; }

    public int? Serie { get; set; }
}

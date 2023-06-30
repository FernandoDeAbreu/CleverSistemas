using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalInutilizacao
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? Serie { get; set; }

    public string? Numeracao { get; set; }

    public string? Justificativa { get; set; }

    public string? Protocolo { get; set; }
}

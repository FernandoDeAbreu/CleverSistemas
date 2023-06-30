using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalEvento
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public string? Protocolo { get; set; }

    public DateTime? Data { get; set; }

    public string? Evento { get; set; }

    public int? Seq { get; set; }

    public int? TipoEvento { get; set; }

    public string? Motivo { get; set; }

    public int? Stat { get; set; }
}

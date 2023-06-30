using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ControleDoc
{
    public int Id { get; set; }

    public int? IdDocumento { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Periodo { get; set; }

    public DateTime? DataEntrada { get; set; }

    public bool? Entregue { get; set; }
}

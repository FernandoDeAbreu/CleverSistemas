using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalAdicao
{
    public int Id { get; set; }

    public int? IdImportacao { get; set; }

    public string? Numero { get; set; }

    public int? Seq { get; set; }

    public string? Codigo { get; set; }

    public decimal? Desconto { get; set; }
}

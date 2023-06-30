using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalImportacao
{
    public int Id { get; set; }

    public int? IdNfItem { get; set; }

    public string? Documento { get; set; }

    public DateTime? DataRegistro { get; set; }

    public string? Local { get; set; }

    public string? Uf { get; set; }

    public DateTime? DataDesen { get; set; }

    public string? Codigo { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalAutXml
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public string? CnpjCpf { get; set; }
}

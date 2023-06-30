using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalEntRet
{
    public int Id { get; set; }

    public int? Tipo { get; set; }

    public int? IdNf { get; set; }

    public string? CnpjCpf { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public int? IdMunicipio { get; set; }
}

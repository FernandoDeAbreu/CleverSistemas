using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalReferenciadum
{
    public int Id { get; set; }

    public int? Tipo { get; set; }

    public int? IdNf { get; set; }

    public string? ChaveNfe { get; set; }

    public string? Uf { get; set; }

    public DateTime? DataEmissao { get; set; }

    public string? CnpjCpf { get; set; }

    public string? Modelo { get; set; }

    public string? Serie { get; set; }

    public string? NumeroNf { get; set; }

    public string? Ie { get; set; }

    public string? Cte { get; set; }

    public string? ModCupomFiscal { get; set; }

    public string? Ecf { get; set; }

    public string? NumeroContador { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalTransporte
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public string? CnpjCpf { get; set; }

    public string? Nome { get; set; }

    public string? Ie { get; set; }

    public string? Endereco { get; set; }

    public string? Municipio { get; set; }

    public string? Uf { get; set; }

    public int? IdPessoa { get; set; }

    public string? Ufplaca { get; set; }

    public string? Placa { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Cheque
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? Tipo { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public string? Documento { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public string? Banco { get; set; }

    public string? Agencia { get; set; }

    public string? Conta { get; set; }

    public string? Cheque1 { get; set; }

    public int? Situacao { get; set; }

    public string? Informacao { get; set; }

    public decimal? Valor { get; set; }

    public string? Titular { get; set; }

    public string? CnpjCpf { get; set; }
}

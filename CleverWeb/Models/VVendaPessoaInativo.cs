using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VVendaPessoaInativo
{
    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public string? NomeRazao { get; set; }

    public string? NomeFantasia { get; set; }

    public string? Contato { get; set; }

    public string? Informacao { get; set; }

    public bool? Situacao { get; set; }

    public int? IdVenda { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? DataFatura { get; set; }

    public bool? Faturado { get; set; }

    public bool? Cancelado { get; set; }

    public bool? Nfe { get; set; }

    public string? TempoCompra { get; set; }

    public int? IdUsuarioComissao1 { get; set; }
}

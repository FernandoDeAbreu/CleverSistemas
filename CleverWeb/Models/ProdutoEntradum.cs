using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ProdutoEntradum
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Entrega { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPagamento { get; set; }

    public string? Informacao { get; set; }

    public int? Situacao { get; set; }

    public int? TipoDocumento { get; set; }

    public string? Documento { get; set; }

    public bool? Faturado { get; set; }

    public int? TipoEntrada { get; set; }
}

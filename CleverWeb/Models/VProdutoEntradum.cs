using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VProdutoEntradum
{
    public int IdEntrada { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public int? TipoEntrada { get; set; }

    public string? DescricaoTipoEntrada { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Entrega { get; set; }

    public string? Informacao { get; set; }

    public bool? Faturado { get; set; }

    public string? Documento { get; set; }

    public string? Descricao { get; set; }

    public string? Complemento { get; set; }

    public string? Municipio { get; set; }

    public int? IdUf { get; set; }

    public decimal? CustoTotal { get; set; }
}

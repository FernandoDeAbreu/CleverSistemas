using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VOrcamento
{
    public int IdOrcamento { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Data { get; set; }

    public string? Informacao { get; set; }

    public int? IdUsuarioComissao1 { get; set; }

    public int? IdUsuarioComissao2 { get; set; }

    public int? IdUsuarioComissao3 { get; set; }

    public string? Descricao { get; set; }

    public string? Complemento { get; set; }

    public string? Municipio { get; set; }

    public int? IdUf { get; set; }

    public decimal? ValorTotal { get; set; }

    public decimal? CustoTotal { get; set; }
}

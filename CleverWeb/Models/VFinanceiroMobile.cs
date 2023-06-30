using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VFinanceiroMobile
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public int? IdPessoa { get; set; }

    public decimal? Valor { get; set; }

    public string? ResumoParcela { get; set; }

    public string? Descricao { get; set; }
}

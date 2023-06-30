using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VPlanejamento
{
    public int? IdEmpresa { get; set; }

    public string? Conta { get; set; }

    public string? DescricaoConta { get; set; }

    public string? DescricaoPessoa { get; set; }

    public string? Documento { get; set; }

    public string? ResumoParcela { get; set; }

    public DateTime? Vencimento { get; set; }

    public decimal? Debito { get; set; }

    public decimal? Credito { get; set; }

    public decimal Saldo { get; set; }

    public string Tipo { get; set; } = null!;
}

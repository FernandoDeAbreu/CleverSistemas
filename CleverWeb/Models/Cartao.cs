using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Cartao
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdPagamento { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public decimal? Valor { get; set; }

    public int? QuantidadeParcela { get; set; }

    public int? Parcela { get; set; }

    public bool? Baixado { get; set; }

    public DateTime? DataBaixa { get; set; }
}

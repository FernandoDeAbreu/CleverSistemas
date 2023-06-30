using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Boleto
{
    public int Id { get; set; }

    public string? NossoNumero { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdCedente { get; set; }

    public decimal? Valor { get; set; }

    public decimal? Acrescimo { get; set; }

    public decimal? Desconto { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public string? Documento { get; set; }

    public byte[]? CodigoBarra { get; set; }

    public bool? Liquidado { get; set; }

    public DateTime? DataBaixa { get; set; }

    public bool? Remessa { get; set; }

    public bool? Cancelado { get; set; }

    public int? TipoRemessa { get; set; }
}

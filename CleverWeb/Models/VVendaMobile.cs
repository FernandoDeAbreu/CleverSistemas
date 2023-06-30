using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VVendaMobile
{
    public int Id { get; set; }

    public int? IdVenda { get; set; }

    public int? IdPessoa { get; set; }

    public string? Data { get; set; }

    public int? IdTabela { get; set; }

    public string? Informacao { get; set; }

    public decimal? Desconto { get; set; }

    public string? Comprador { get; set; }

    public string? Descricao { get; set; }

    public int? IdUsuario { get; set; }

    public string? Usuario { get; set; }

    public string? Pagamento { get; set; }

    public int? IdPagamento { get; set; }

    public string? Parcelamento { get; set; }

    public int? IdParcelamento { get; set; }

    public string? Equipamento { get; set; }

    public string? Imei { get; set; }
}

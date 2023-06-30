using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Vendum
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Entrega { get; set; }

    public string? Informacao { get; set; }

    public int? IdUsuarioComissao1 { get; set; }

    public int? IdUsuarioComissao2 { get; set; }

    public DateTime? DataFatura { get; set; }

    public string? Comprador { get; set; }

    public bool? Faturado { get; set; }

    public bool? Nfe { get; set; }

    public int? IdPagamento { get; set; }

    public int? IdParcelamento { get; set; }

    public bool? Cancelado { get; set; }

    public int? SituacaoEntrega { get; set; }

    public int? SituacaoConferencia { get; set; }

    public int? IdUsuarioConferencia { get; set; }

    public string? CpfCnpj { get; set; }

    public int? IdNfe { get; set; }

    public int? IdCfe { get; set; }

    public string? Seqvenda { get; set; }
}

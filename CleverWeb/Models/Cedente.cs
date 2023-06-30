using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Cedente
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public string? CodCedente { get; set; }

    public int? Carteira { get; set; }

    public decimal? Juros { get; set; }

    public int? DiasJuros { get; set; }

    public decimal? Multa { get; set; }

    public int? DiasMulta { get; set; }

    public string? Instrucao1 { get; set; }

    public int? IdBanco { get; set; }

    public int? IdConta { get; set; }

    public int? IdEmpresa { get; set; }

    public int? TipoDocCedente { get; set; }

    public string? CnpjCpfCedente { get; set; }

    public string? RazaoCedente { get; set; }

    public bool? UtilizaTarifa { get; set; }

    public decimal? Tarifa { get; set; }

    public string? Instrucao2 { get; set; }

    public int? DiaProtesto { get; set; }

    public bool? Aceite { get; set; }

    public int? TipoEmissao { get; set; }

    public int? CodProtesto { get; set; }

    public bool? Ativo { get; set; }

    public int? TipoCobranca { get; set; }

    public bool? AlteraData { get; set; }
}

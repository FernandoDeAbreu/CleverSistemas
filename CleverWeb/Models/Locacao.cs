using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Locacao
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public DateTime? Data { get; set; }

    public DateTime? Inicio { get; set; }

    public DateTime? Termino { get; set; }

    public int? DiaVencimento { get; set; }

    public decimal? Valor { get; set; }

    public string? DescricaoTest1 { get; set; }

    public string? DescricaoTest2 { get; set; }

    public string? DocTest1 { get; set; }

    public string? DocTest2 { get; set; }

    public string? Observacao { get; set; }

    public string? Uc { get; set; }
}

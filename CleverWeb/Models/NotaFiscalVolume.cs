using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class NotaFiscalVolume
{
    public int Id { get; set; }

    public int? IdNf { get; set; }

    public int? Quantidade { get; set; }

    public string? Especie { get; set; }

    public string? Marca { get; set; }

    public string? Numeracao { get; set; }

    public decimal? PesoL { get; set; }

    public decimal? PesoB { get; set; }
}

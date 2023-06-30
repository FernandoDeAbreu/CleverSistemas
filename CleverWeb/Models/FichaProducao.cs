using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class FichaProducao
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdVenda { get; set; }

    public int? Situacao { get; set; }

    public DateTime? Entrada { get; set; }

    public DateTime? Saida { get; set; }

    public string? Transportadora { get; set; }

    public int? IdItemVenda { get; set; }

    public string? AnoModelo { get; set; }

    public string? CorCouro { get; set; }

    public string? Costura { get; set; }

    public int? Logomarca { get; set; }

    public int? LateraisPorta { get; set; }

    public int? ApoioCabeca { get; set; }

    public string? TipoAcento { get; set; }

    public string? Abd { get; set; }

    public string? Abt { get; set; }

    public string? Observacao { get; set; }

    public string? TipoEncosto { get; set; }
}

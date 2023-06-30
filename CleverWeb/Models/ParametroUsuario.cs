using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ParametroUsuario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public bool? Comissao { get; set; }

    public bool? VendaRestrita { get; set; }

    public bool? LiberaDesconto { get; set; }

    public bool? VendaFixaLogado { get; set; }

    public bool? PermiteFaturar { get; set; }

    public bool? PermiteAterarFaturado { get; set; }

    public bool? VisualizaResumoVenda { get; set; }
}

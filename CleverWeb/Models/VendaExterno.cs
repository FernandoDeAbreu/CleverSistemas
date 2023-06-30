using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VendaExterno
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? Data { get; set; }

    public string? Informacao { get; set; }

    public virtual ICollection<VendaExternoItem> VendaExternoItems { get; set; } = new List<VendaExternoItem>();
}

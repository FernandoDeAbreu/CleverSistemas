using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class FolhaPagto
{
    public int Id { get; set; }

    public int? IdPessoa { get; set; }

    public int? IdEmpresa { get; set; }

    public DateTime? Periodo { get; set; }

    public DateTime? Vencimento { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<FolhaPagtoEvento> FolhaPagtoEventos { get; set; } = new List<FolhaPagtoEvento>();
}

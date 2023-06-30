using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Evento
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public string? Referencia { get; set; }

    public bool? Vencimento { get; set; }

    public bool? Desconto { get; set; }

    public virtual ICollection<FolhaPagtoEvento> FolhaPagtoEventos { get; set; } = new List<FolhaPagtoEvento>();
}

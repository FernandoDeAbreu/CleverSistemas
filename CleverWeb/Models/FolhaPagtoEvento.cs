using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class FolhaPagtoEvento
{
    public int Id { get; set; }

    public int? IdFolhaPagto { get; set; }

    public int? IdEvento { get; set; }

    public decimal? Valor { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual FolhaPagto? IdFolhaPagtoNavigation { get; set; }
}

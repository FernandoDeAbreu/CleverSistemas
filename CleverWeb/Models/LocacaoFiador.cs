using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class LocacaoFiador
{
    public int Id { get; set; }

    public int? IdLocacao { get; set; }

    public int? IdFiador { get; set; }
}

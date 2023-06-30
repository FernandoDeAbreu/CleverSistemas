using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class LocacaoLocatario
{
    public int Id { get; set; }

    public int? IdLocacao { get; set; }

    public int? IdLocatario { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class LogAcesso
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEmpresa { get; set; }

    public DateTime? Data { get; set; }

    public string? Terminal { get; set; }
}

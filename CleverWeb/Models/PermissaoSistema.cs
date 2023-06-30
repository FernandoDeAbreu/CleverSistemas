using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PermissaoSistema
{
    public int IdUsuario { get; set; }

    public string Menu { get; set; } = null!;
}

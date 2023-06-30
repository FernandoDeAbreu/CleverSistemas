using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Imagem
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? Tipo { get; set; }

    public byte[]? Imagem1 { get; set; }
}

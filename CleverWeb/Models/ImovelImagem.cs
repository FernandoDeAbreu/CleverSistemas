using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImovelImagem
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public string? Informacao { get; set; }

    public byte[]? Imagem { get; set; }
}

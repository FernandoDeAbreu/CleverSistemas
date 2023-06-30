using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaImagem
{
    public int Id { get; set; }

    public int? Tipo { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public byte[]? Imagem { get; set; }
}

using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Email
{
    public int Id { get; set; }

    public DateTime? Data { get; set; }

    public string? Para { get; set; }

    public string? Cc { get; set; }

    public string? Cco { get; set; }

    public string? Assunto { get; set; }

    public string? Conteudo { get; set; }

    public string? Anexo { get; set; }
}

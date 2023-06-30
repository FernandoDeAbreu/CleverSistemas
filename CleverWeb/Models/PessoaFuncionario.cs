using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class PessoaFuncionario
{
    public int Id { get; set; }

    public decimal? Salario { get; set; }

    public string? CarteiraProfissional { get; set; }

    public string? Pis { get; set; }

    public string? Referencia { get; set; }
}

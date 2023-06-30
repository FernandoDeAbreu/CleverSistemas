using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public bool? MultiEmpresa { get; set; }

    public int? IdEmpresa { get; set; }

    public bool? Cadastrado { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public string? Descricao { get; set; }

    public bool? UsuarioSistema { get; set; }

    public string? SenhaSistema { get; set; }

    public bool? UsuarioMobile { get; set; }

    public string? SenhaMobile { get; set; }

    public bool? Situacao { get; set; }
}

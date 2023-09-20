using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Banco
{
    public int Id { get; set; }

    public int IdEmpresa { get; set; }

    public int IdBanco { get; set; }

    public string Descricao { get; set; }

    public string Agencia { get; set; }

    public string Conta { get; set; }

    public int IdCaixa { get; set; }

    public decimal Limite { get; set; }
    public bool ativo { get; set; }
}

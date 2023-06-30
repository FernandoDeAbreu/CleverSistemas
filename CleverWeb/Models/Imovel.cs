using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class Imovel
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public int? IdTipo { get; set; }

    public int? TipoImovel { get; set; }

    public decimal? Area { get; set; }

    public decimal? Valor { get; set; }

    public decimal? ComissaoPorc { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Rgi { get; set; }

    public string? Uc { get; set; }

    public decimal? ComissaoValor { get; set; }

    public string? Ci { get; set; }

    public string? Matricula { get; set; }
}

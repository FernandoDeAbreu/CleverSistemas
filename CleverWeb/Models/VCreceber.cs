using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class VCreceber
{
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdConta { get; set; }

    public int? Situacao { get; set; }

    public string? Documento { get; set; }

    public DateTime? Emissao { get; set; }

    public DateTime? Vencimento { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }

    public decimal? Valor { get; set; }

    public int? QuantidadeParcela { get; set; }

    public int? Parcela { get; set; }

    public string? ResumoParcela { get; set; }

    public string? Descricao { get; set; }

    public decimal? Desconto { get; set; }

    public decimal? Total { get; set; }

    public decimal? Acrescimo { get; set; }

    public int? Controle { get; set; }

    public bool? Boleto { get; set; }

    public int? IdVenda { get; set; }

    public int? IdOs { get; set; }

    public int? IdPrevisaoPagto { get; set; }

    public string? Conta { get; set; }

    public string? DescricaoConta { get; set; }

    public int? Nivel { get; set; }

    public string? Conta1 { get; set; }

    public string? DescricaoConta1 { get; set; }

    public string? Conta2 { get; set; }

    public string? DescricaoConta2 { get; set; }

    public string? Conta3 { get; set; }

    public string? DescricaoConta3 { get; set; }

    public string? DescricaoPessoa { get; set; }

    public string? DescricaoSituacao { get; set; }

    public DateTime? DataBaixa { get; set; }

    public string? DescricaoBoleto { get; set; }

    public string? PrevisaoPagto { get; set; }
}

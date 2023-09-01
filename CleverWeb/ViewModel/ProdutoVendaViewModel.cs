using CleverWeb.Models;

namespace CleverWeb.ViewModel
{
    public class ProdutoVendaViewModel
    {
        public IEnumerable<ProdutoServico> ProdutoServico { get; set; }

        public int Id { get; set; }

        public bool? MultiEmpresa { get; set; }

        public int? IdEmpresa { get; set; }

        public string? GrupoNivel { get; set; }

        public string? Descricao { get; set; }

        public string? Referencia { get; set; }

        public string? Fabricante { get; set; }

        public string? ValorVenda { get; set; }

        public string? Barra { get; set; }

        public byte[] Imagem { get; set; }
    }
}

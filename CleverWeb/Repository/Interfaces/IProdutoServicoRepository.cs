using CleverWeb.Models;

namespace CleverWeb.Repository.Interfaces
{
    public interface IProdutoServicoRepository
    {
        IEnumerable<VProdutoVenda> VProdutoVenda { get; }
        IEnumerable<ProdutoServico> ProdutoServicosGetByCategoria { get; }
        ProdutoServico GetById(int id);
    }
}
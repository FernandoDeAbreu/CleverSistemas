using CleverWeb.Models;
using CleverWeb.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleverWeb.Repository
{
    public class ProdutoServicoRepository : IProdutoServicoRepository
    {
        private readonly BdSystemContext _context;

        public ProdutoServicoRepository(BdSystemContext context)
        {
            _context = context;
        }

        public IEnumerable<VProdutoVenda> VProdutoVenda => _context.VProdutoVenda;

        public IEnumerable<ProdutoServico> ProdutoServicosGetByCategoria => _context.ProdutoServicos;

        public ProdutoServico GetById(int id)
        {
            return _context.ProdutoServicos.FirstOrDefault(p => p.Id == id);
        }
    }
}
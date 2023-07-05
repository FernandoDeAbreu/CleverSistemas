using CleverWeb.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleverWeb.Controllers
{
    public class PDVController : Controller
    {
        private readonly IProdutoServicoRepository _produtoServicoRepository;

        public PDVController(IProdutoServicoRepository produtoServicoRepository)
        {
            _produtoServicoRepository = produtoServicoRepository;
        }

        public IActionResult List()
        {
            var produtoServicos = _produtoServicoRepository.VProdutoVenda;
            return View(produtoServicos);
        }
    }
}

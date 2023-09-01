using CleverWeb.Repository.Interfaces;
using CleverWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CleverWeb.Controllers
{
    public class LancheController : Controller
    {
        private readonly IProdutoServicoRepository _produtoServicoRepository;

        public LancheController(IProdutoServicoRepository produtoServicoRepository)
        {
            _produtoServicoRepository = produtoServicoRepository;
        }

        public IActionResult List()
        {

            var lanches = _produtoServicoRepository.VProdutoVenda;
                        return View(lanches);
          
        }
        public ActionResult ExibirImagem(int id)
        {
            var produto = _produtoServicoRepository.GetById(id);

            if (produto != null && produto.Imagem != null && produto.Imagem.Length > 0)
            {
                return File(produto.Imagem, "image/jpeg"); // ou o tipo de mídia correto
            }

            // Retorna uma imagem padrão ou tratamento de erro
            return File("~/Content/Images/default-image.jpg", "image/jpeg"); // substitua pelo caminho da imagem padrão
        }
    }
}

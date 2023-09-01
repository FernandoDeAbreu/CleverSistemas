using CleverWeb.Models;
using CleverWeb.Repository.Interfaces;
using CleverWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CleverWeb.Controllers
{
    public class VendaMobileController : Controller
    {
        private readonly IProdutoServicoRepository _produtoServicoRepository;
        private readonly VendaMobile _vendaMobile;

        public VendaMobileController(IProdutoServicoRepository produtoServicoRepository, VendaMobile vendaMobile)
        {
            _produtoServicoRepository = produtoServicoRepository;
            _vendaMobile = vendaMobile;
        }

        public ActionResult Index()
        {
            var itens = _vendaMobile.GetVendaItemMobile();
            _vendaMobile.vendaItemMobiles = itens;

            var vendasMobileViewModel = new VendaMobileViewModel
            {
                VendaMobile = _vendaMobile,
                VendaMobileTotal = _vendaMobile.GetVendaMobileTotal(),
            };
            return View(vendasMobileViewModel);
        }

        public ActionResult AdicionarItemNoPedido(int produtoId)
        {
            var itemSelecionado = _produtoServicoRepository.VProdutoVenda
                                    .FirstOrDefault(p => p.Id == produtoId);

            if (itemSelecionado != null)
            {
                _vendaMobile.AdicionarAoPedido(itemSelecionado);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoverItemDoPedido(int produtoId)
        {
            var itemSelecionado = _produtoServicoRepository.VProdutoVenda
                        .FirstOrDefault(p => p.Id == produtoId);
            if (itemSelecionado != null)
            {
                _vendaMobile.RemoverDoPedido(itemSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
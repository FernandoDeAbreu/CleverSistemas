using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleverWeb.Models;
using CleverWeb.Shared;

namespace CleverWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly BdSystemContext _context;

        public ProdutoController(BdSystemContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DescricaoParm"] = String.IsNullOrEmpty(sortOrder) ? "descricao_desc" : "";
            ViewData["ReferenciaParm"] = sortOrder == "Referencia" ? "referencia_desc" : "Referencia";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var produtoServico = from s in _context.ProdutoServicos
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                produtoServico = produtoServico.Where(s => s.Descricao.Contains(searchString)
                                       || s.Referencia.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "descricao_desc":
                    produtoServico = produtoServico.OrderByDescending(s => s.Descricao);
                    break;
                case "Referencia":
                    produtoServico = produtoServico.OrderBy(s => s.Referencia);
                    break;
                case "referencia_desc":
                    produtoServico = produtoServico.OrderByDescending(s => s.Fabricante);
                    break;
                default:
                    produtoServico = produtoServico.OrderBy(s => s.Id);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<ProdutoServico>.CreateAsync(produtoServico.AsNoTracking(), pageNumber ?? 1, pageSize));

          
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProdutoServicos == null)
            {
                return NotFound();
            }

            var produtoServico = await _context.ProdutoServicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoServico == null)
            {
                return NotFound();
            }

            return View(produtoServico);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MultiEmpresa,IdEmpresa,GrupoNivel,Descricao,Referencia,Fabricante,Informacao,Barra,Barratributavel,Ncm,ValorCompra,OutrosCustos,UnidadeTributavel,Validade,Garantia,Situacao,Tipo,ExTipi,ClasseEnquadramento,Cnpjprodutor,CustoFinal,IdGrupo,Imagem,PesoB,PesoL,ValorIpi,ControleEstoque,ProdutoEspecifico,CodAnp,ValorSt,InfoAdicional1,InfoAdicional2,Abc,IdCest")] ProdutoServico produtoServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoServico);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProdutoServicos == null)
            {
                return NotFound();
            }

            var produtoServico = await _context.ProdutoServicos.FindAsync(id);
            if (produtoServico == null)
            {
                return NotFound();
            }
            return View(produtoServico);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MultiEmpresa,IdEmpresa,GrupoNivel,Descricao,Referencia,Fabricante,Informacao,Barra,Barratributavel,Ncm,ValorCompra,OutrosCustos,UnidadeTributavel,Validade,Garantia,Situacao,Tipo,ExTipi,ClasseEnquadramento,Cnpjprodutor,CustoFinal,IdGrupo,Imagem,PesoB,PesoL,ValorIpi,ControleEstoque,ProdutoEspecifico,CodAnp,ValorSt,InfoAdicional1,InfoAdicional2,Abc,IdCest")] ProdutoServico produtoServico)
        {
            if (id != produtoServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoServicoExists(produtoServico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtoServico);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProdutoServicos == null)
            {
                return NotFound();
            }

            var produtoServico = await _context.ProdutoServicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoServico == null)
            {
                return NotFound();
            }

            return View(produtoServico);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProdutoServicos == null)
            {
                return Problem("Entity set 'BdSystemContext.ProdutoServicos'  is null.");
            }
            var produtoServico = await _context.ProdutoServicos.FindAsync(id);
            if (produtoServico != null)
            {
                _context.ProdutoServicos.Remove(produtoServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoServicoExists(int id)
        {
          return (_context.ProdutoServicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleverWeb.Models;

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
        public async Task<IActionResult> Index()
        {
              return _context.ProdutoServicos != null ? 
                          View(await _context.ProdutoServicos.ToListAsync()) :
                          Problem("Entity set 'BdSystemContext.ProdutoServicos'  is null.");
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

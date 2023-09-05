using Microsoft.EntityFrameworkCore;

namespace CleverWeb.Models;

public partial class VendaMobile
{
    private readonly BdSystemContext _context;

    public VendaMobile(BdSystemContext context)
    {
        _context = context;
    }

    public int Id { get; set; }

    public int? IdVenda { get; set; }

    public int? IdPessoa { get; set; }

    public string? Data { get; set; }

    public int? IdTabela { get; set; }

    public int? IdParcelamento { get; set; }

    public string? Informacao { get; set; }

    public decimal? Desconto { get; set; }

    public string? Comprador { get; set; }

    public int? IdUsuario { get; set; }

    public string? Imei { get; set; }

    public List<VendaItemMobile> vendaItemMobiles { get; set; }

    public static VendaMobile GetVendaMobile(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<BdSystemContext>();
        string idVenda = session.GetString("IdVenda") ?? Guid.NewGuid().ToString();
        session.SetString("IdVenda", idVenda);
        return new VendaMobile(context)
        {
            IdVenda = Convert.ToInt32(idVenda)
        };
    }

    public void AdicionarAoPedido(VProdutoVenda produtoServico)
    {
        var vendaItemMobile = _context.VendaItemMobiles.SingleOrDefault(
            s => s.IdProduto == produtoServico.Id &&
            s.IdVenda == IdVenda);

        if (vendaItemMobile == null)
        {
            vendaItemMobile = new VendaItemMobile
            {
                IdVenda = IdVenda,
               //  = produtoServico,
                IdProduto = produtoServico.Id,
                Quantidade = 0
            };
        }
        else
        {
            vendaItemMobile.Quantidade++;
        }
        _context.SaveChanges();
    }

    public void RemoverDoPedido(VProdutoVenda produtoServico)
    {
        var vendaItemMobile = _context.VendaItemMobiles.SingleOrDefault(
            s => s.IdProduto == produtoServico.Id &&
            s.IdVenda == IdVenda);

        if (vendaItemMobile == null)
        {
            if (vendaItemMobile.Quantidade > 1)
            {
                vendaItemMobile.Quantidade--;
            }
        }
        _context.SaveChanges();
    }

    public List<VendaItemMobile> GetVendaItemMobile()
    {
        return vendaItemMobiles ??
            (vendaItemMobiles = 
             _context.VendaItemMobiles
             .Where(c => c.IdVenda == IdVenda)
             .Include(s => s.IdProduto)
             .ToList());

    }
   
    public void LimparPedido()
    {
        var vendaItemMobile = _context.VendaItemMobiles.Where(c => c.IdVenda == IdVenda);

        _context.VendaItemMobiles.RemoveRange(vendaItemMobile);
        _context.SaveChanges();
    }

    public decimal? GetVendaMobileTotal()
    {
        var total = _context.VendaItemMobiles
            .Where(c => c.IdVenda == IdVenda)
            .Select(c => c.ProdutoServico.ValorVenda * c.Quantidade).Sum();
        return total;
    }
}
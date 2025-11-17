using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PitsLanches.Context;
using System.Linq;

namespace PitsLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalPedidos = _context.Pedidos.Count();
            var totalLanches = _context.Lanches.Count();
            var vendasTotais = _context.Pedidos.Sum(m => m.PedidoTotal);

            ViewBag.TotalPedidos = totalPedidos;
            ViewBag.TotalLanches = totalLanches;
            ViewBag.VendasTotais = vendasTotais;

            return View();
        }
    }
}
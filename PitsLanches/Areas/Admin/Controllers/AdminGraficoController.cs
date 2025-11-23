using Microsoft.AspNetCore.Mvc;
using PitsLanches.Areas.Admin.Services;

namespace PitsLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendaService _graficoVendaService;

        public AdminGraficoController(GraficoVendaService graficoVendaService)
        {
            _graficoVendaService = graficoVendaService ?? throw
                new ArgumentNullException(nameof(graficoVendaService));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendaService.GetVendasLanches(dias);
            return Json(lanchesVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PitsLanches.Models;

namespace PitsLanches.Controllers
{
    public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            TempData["Nome"] = "Well";
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

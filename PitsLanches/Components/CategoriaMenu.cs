using Microsoft.AspNetCore.Mvc;
using PitsLanches.Repositories.Interfaces;

namespace PitsLanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(m => m.CategoriaNome);
            return View(categorias);
        }
    }
}

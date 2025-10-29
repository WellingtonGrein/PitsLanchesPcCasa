using PitsLanches.Context;
using PitsLanches.Models;
using PitsLanches.Repositories.Interfaces;

namespace PitsLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

using Microsoft.EntityFrameworkCore;
using PitsLanches.Context;
using PitsLanches.Models;
using PitsLanches.Repositories.Interfaces;

namespace PitsLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(m => m.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(m => m.IsLanchePreferido).Include(m => m.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(m => m.LancheId == lancheId);
        }
    }
}

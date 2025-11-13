using Microsoft.EntityFrameworkCore;
using PitsLanches.Context;
using PitsLanches.Models;

namespace PitsLanches.Areas.Admin.Servicos
{
    public class RelatorioVendasServices
    {
        private readonly AppDbContext context;
        public RelatorioVendasServices(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(m => m.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(m => m.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                         .Include(m => m.PedidoItens)
                         .ThenInclude(m => m.Lanche)
                         .OrderByDescending(m => m.PedidoEnviado)
                         .ToListAsync();
        }
    }
}

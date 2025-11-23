using PitsLanches.Context;
using PitsLanches.Models;

namespace PitsLanches.Areas.Admin.Services
{
    public class GraficoVendaService
    {
        private readonly AppDbContext context;

        public GraficoVendaService(AppDbContext context)
        {
            this.context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from m in context.PedidoDetalhes
                           join i in context.Lanches on m.LancheId equals i.LancheId
                           where m.Pedido.PedidoEnviado >= data
                           group m by new { m.LancheId, i.Nome, m.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidae = g.Sum(m => m.Quantidade),
                               LanchesValorTotal = g.Sum (m => m.Preco * m.Quantidade)
                           });

            var lista = new List<LancheGrafico>();

            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidae;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }
            return lista;
        }
    }
}

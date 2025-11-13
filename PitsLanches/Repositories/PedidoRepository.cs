using PitsLanches.Context;
using PitsLanches.Models;
using PitsLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PitsLanches.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra; 

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

      
            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            pedido.PedidoItens = new List<PedidoDetalhe>();

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco,
                    Lanche = carrinhoItem.Lanche
                };

                pedido.PedidoItens.Add(pedidoDetail);
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
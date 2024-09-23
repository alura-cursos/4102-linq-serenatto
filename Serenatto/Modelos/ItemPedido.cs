using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenattoEnsaio.Modelos;
public class ItemPedido
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
}

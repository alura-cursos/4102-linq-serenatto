using SerenattoEnsaio.Modelos;

namespace SerenattoPreGravacao.Dados;
public class DadosCarrinho
{
    public static List<Produto> GetProdutosCarrinho()
    {
        List<Produto> produtos = new() {
            new Produto { Id = Guid.NewGuid(), Nome = "Café", Preco = 5, Descricao = "Café" },
            new Produto { Id = Guid.NewGuid(), Nome = "Café", Preco = 5, Descricao = "Café" },
            new Produto { Id = Guid.NewGuid(), Nome = "Cappuccino", Preco = 6, Descricao = "Cappuccino" },
            new Produto { Id = Guid.NewGuid(), Nome = "Cappuccino", Preco = 6, Descricao = "Cappuccino" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão de queijo", Preco = 6, Descricao = "Pão de Queijo" },
            new Produto { Id = Guid.NewGuid(), Nome = "Biscoito Goiabinha", Preco = 6, Descricao = "Biscoito Goiabinha" },
            new Produto { Id = Guid.NewGuid(), Nome = "Biscoito Goiabinha", Preco = 6, Descricao = "Biscoito Goiabinha" },
            new Produto { Id = Guid.NewGuid(), Nome = "Biscoito Goiabinha", Preco = 6, Descricao = "Biscoito Goiabinha" },

        };
        return produtos;
    }
}

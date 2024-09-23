using SerenattoEnsaio.Modelos;

namespace SerenattoPreGravacao.Dados;
public class DadosCardapio
{
    public static List<Produto> GetProdutos()
    {
        List<Produto> produtos = new() {
            new Produto { Id = Guid.NewGuid(), Nome = "Café", Preco = 5, Descricao = "Café" },
            new Produto { Id = Guid.NewGuid(), Nome = "Cappuccino", Preco = 9, Descricao = "Cappuccino" },
            new Produto { Id = Guid.NewGuid(), Nome = "Broa", Preco = 6, Descricao = "Broa de milho" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão doce", Preco = 7, Descricao = "Pão doce" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão de queijo", Preco = 6, Descricao = "Pão de Queijo" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão de queijo recheado", Preco = 10, Descricao = "Pão de Queijo recheado de goiabada" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão de queijo recheado", Preco = 9, Descricao = "Pão de Queijo recheado de calabresa" }
        };
        return produtos;


    }

    public static List<Produto> CardapioDelivery()
    {
        List<Produto> produtos = new() {
            new Produto { Id = Guid.NewGuid(), Nome = "Café", Preco = 5, Descricao = "Café" },
            new Produto { Id = Guid.NewGuid(), Nome = "Cappuccino", Preco = 9, Descricao = "Cappuccino" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão francês", Preco = 2, Descricao = "Pão francês" },
            new Produto { Id = Guid.NewGuid(), Nome = "Pão de queijo", Preco = 6, Descricao = "Pão de Queijo" },
            new Produto { Id = Guid.NewGuid(), Nome = "Biscoito Goiabinha", Preco = 6, Descricao = "Biscoito Goiabinha" },
            new Produto { Id = Guid.NewGuid(), Nome = "Palito de Queijo", Preco = 5, Descricao = "Palito de Queijo" },
        };
        return produtos;
    }
}

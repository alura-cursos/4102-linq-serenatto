using SerenattoEnsaio.Dados;
using SerenattoEnsaio.Modelos;
using SerenattoPreGravacao.Dados;

IEnumerable<Cliente> clientes = DadosClientes.GetClientes().ToList();
IEnumerable<string> formasPagamento = DadosFormaDePagamento.FormasDePagamento;
IEnumerable<Produto> cardapioLoja = DadosCardapio.GetProdutos();

Console.WriteLine("RELATÓRIO DE DADOS CLIENTES");
foreach (var cliente in clientes)
{
    Console.WriteLine($"{cliente.Id} | {cliente.Nome} | {cliente.Endereco} | {cliente.Telefone}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO FORMAS DE PAGAMENTO");
var pesquisa = from p in formasPagamento
               where p.Contains('c')
               select p;

Console.WriteLine(string.Join(" ", pesquisa));

var pesquisa2 = formasPagamento.Where(p => p.StartsWith('d'));

Console.WriteLine(string.Join(" ", pesquisa2));

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO DADOS CARDÁPIO LOJA");

cardapioLoja.ToList();

foreach (var item in cardapioLoja)
{
    Console.WriteLine($"{item.Id} | {item.Nome} | {item.Descricao} | {item.Preco}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS DO CARDÁPIO POR NOME");

var produtosPorNome = cardapioLoja.Select(p => p.Nome);

foreach (var item in produtosPorNome)
{
    Console.WriteLine(item);
}



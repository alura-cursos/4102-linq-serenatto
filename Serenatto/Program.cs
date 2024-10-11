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

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS POR PREÇO");

var produtosPreco = cardapioLoja.Select(c => new
{
    NomeProduto = c.Nome,
    PrecoProduto = c.Preco
});

foreach (var item in produtosPreco)
{
    Console.WriteLine($"{item.NomeProduto} | {item.PrecoProduto}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS POR PREÇO NO COMBO LEVE 4 E PAGUE 3");

var produtosPrecoCombo = cardapioLoja.Select(c => new
{
    NomeProduto = c.Nome,
    PrecoCombo = c.Preco * 3
});

foreach (var item in produtosPrecoCombo)
{
    Console.WriteLine($"{item.NomeProduto} | {item.PrecoCombo}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO QUANTIDADE PRODUTOS PEDIDOS NO MÊS");

IEnumerable<int> totalPedidosMes = DadosPedidos.QuantidadeItensPedidosPorDia.SelectMany(lista => lista);

foreach (var pedido in totalPedidosMes)
{
    Console.Write($"{pedido} ");
}

Console.WriteLine(" ");
Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO TOTAL DE PEDIDOS INDIVIDUAIS NO MÊS");

var pedidosIndividuais = DadosPedidos.QuantidadeItensPedidosPorDia
    .SelectMany(lista => lista)
    .Count(numero => numero == 1);

Console.WriteLine($"O total de pedidos individuais foi: {pedidosIndividuais}");

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO CLIENTES POR N0ME E TELEFONE");

var clientesNomeTelefone = clientes.Select(c => new
{
    NomeCliente = c.Nome,
    TelefoneCliente = c.Telefone
});

foreach (var cliente in clientesNomeTelefone)
{
    Console.WriteLine($"{cliente.NomeCliente} | {cliente.TelefoneCliente}");
}
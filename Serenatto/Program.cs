using SerenattoEnsaio.Dados;
using SerenattoEnsaio.Modelos;
using SerenattoPreGravacao.Dados;

IEnumerable<Cliente> clientes = DadosClientes.GetClientes().ToList();
IEnumerable<string> formasPagamento = DadosFormaDePagamento.FormasDePagamento;
IEnumerable<Produto> cardapioLoja = DadosCardapio.GetProdutos();
IEnumerable<Produto> cardapioDelivery = DadosCardapio.CardapioDelivery();
IEnumerable<int> totalPedidosMes = DadosPedidos.QuantidadeItensPedidosPorDia.SelectMany(lista => lista);
IEnumerable<Produto> carrinho = DadosCarrinho.GetProdutosCarrinho();

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

foreach (var pedido in totalPedidosMes)
{
    Console.Write($"{pedido} ");
}

Console.WriteLine(" ");
Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO TOTAL DE PEDIDOS INDIVIDUAIS NO MÊS");

var pedidosIndividuais = totalPedidosMes
    .Count(numero => numero == 1);

Console.WriteLine($"O total de pedidos individuais foi: {pedidosIndividuais}");

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PEDIDOS COM QUANTIDADES DIFERENTES DE ITENS");

IEnumerable<int> totalPedidosDiferentesMes = totalPedidosMes.Distinct();

foreach (var pedido in totalPedidosDiferentesMes)
{
    Console.Write($"{pedido} ");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS SOMENTE LOJA");

IEnumerable<string> produtoCardapioLoja = cardapioLoja.Select(p => p.Nome);
IEnumerable<string> produtoCardapioDelivery = cardapioDelivery.Select(p => p.Nome);

var produtosSomenteLoja = produtoCardapioLoja.Except(produtoCardapioDelivery).ToList();

foreach (var produto in produtosSomenteLoja)
{
    Console.WriteLine(produto);
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS LOJA E DELIVERY");

var listaProdutosLojaEDelivery = produtoCardapioLoja.Intersect(produtoCardapioDelivery).ToList();

foreach (var item in listaProdutosLojaEDelivery)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO TODOS OS PRODUTOS CARDÁPIO");

var listaProdutosGeral = produtoCardapioLoja.Union(produtoCardapioDelivery).ToList();

foreach (var item in listaProdutosGeral)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO PRODUTOS ORDENADOS POR NOME E PREÇO");

var cardapioOrdenado = cardapioLoja
    .OrderBy(p => p.Nome)
    .ThenBy(p => p.Preco);

foreach (var item in cardapioOrdenado)
{
    Console.WriteLine($"{item.Nome} | {item.Preco}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("RELATÓRIO CARRINHO DE COMPRAS");

IEnumerable<string> nomeProdutos = carrinho.Select(c => c.Nome);
IEnumerable<decimal> precoProdutos = carrinho.Select(p => p.Preco);

string resultado = nomeProdutos.Aggregate((p1, p2) => p1 + ", " + p2);
decimal valorFinal = precoProdutos.Aggregate((n1, n2) => n1 + n2);

Console.WriteLine(resultado);
Console.WriteLine($"Valor total da compra: {valorFinal}");


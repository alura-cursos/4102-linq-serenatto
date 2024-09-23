using SerenattoEnsaio.Dados;
using SerenattoEnsaio.Modelos;

IEnumerable<Cliente> clientes = DadosClientes.GetClientes().ToList();
IEnumerable<string> formasPagamento = DadosFormaDePagamento.FormasDePagamento;

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
              


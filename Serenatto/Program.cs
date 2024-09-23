using SerenattoEnsaio.Dados;
using SerenattoEnsaio.Modelos;

IEnumerable<Cliente> clientes = DadosClientes.GetClientes().ToList();

Console.WriteLine("RELATÓRIO DE DADOS CLIENTES");
foreach (var cliente in clientes)
{
    Console.WriteLine($"{cliente.Id} | {cliente.Nome} | {cliente.Endereco} | {cliente.Telefone}");
}


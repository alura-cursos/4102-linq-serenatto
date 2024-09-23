using SerenattoEnsaio.Modelos;

namespace SerenattoEnsaio.Dados;
public class DadosClientes
{
    public static List<Cliente> GetClientes()
    {
        List<Cliente> clientes = new() {
            new Cliente { Id = Guid.NewGuid(), Nome = "Carlos Pereira", Endereco = "Rua das Acácias, 567", Telefone = "(41) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Fernanda Costa", Endereco = "Avenida Independência, 890", Telefone = "(12) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Bruno Santos", Endereco = "Rua da Liberdade, 112", Telefone = "(27) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Camila Silva", Endereco = "Avenida Central, 345", Telefone = "(16) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Gustavo Almeida", Endereco = "Rua da Paz, 987", Telefone = "(18) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Ana Paula Rodrigues", Endereco = "Rua dos Pinheiros, 234", Telefone = "(31) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Rafael Oliveira", Endereco = "Avenida Paulista, 1567", Telefone = "(11) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Juliana Santos", Endereco = "Rua da Praia, 789", Telefone = "(24) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Felipe Souza", Endereco = "Avenida Brasil, 1234", Telefone = "(21) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Larissa Pereira", Endereco = "Rua Central, 567", Telefone = "(19) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Marcos Gomes", Endereco = "Rua das Flores, 890", Telefone = "(11) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Amanda Costa", Endereco = "Avenida Independência, 112", Telefone = "(12) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Victor Santos", Endereco = "Rua da Liberdade, 345", Telefone = "(27) 98765-4321", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Beatriz Silva", Endereco = "Avenida Central, 987", Telefone = "(16) 12345-6789", Pedidos = [] },
            new Cliente { Id = Guid.NewGuid(), Nome = "Henrique Almeida", Endereco = "Rua da Paz, 234", Telefone = "(18) 98765-4321", Pedidos = [] }

        };
        return clientes;
    }
}

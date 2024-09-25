using Microsoft.Data.SqlClient;
using Serenatto.Dados;
using SerenattoEnsaio.Modelos;
using System.Configuration;

string connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

using (var context = new SerenattoContext())
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("----- Boas vindas ao Serenatto -----");
        Console.WriteLine("1. Cadastrar produto");
        Console.WriteLine("2. Listar produtos");
        Console.WriteLine("3. Atualizar produto");
        Console.WriteLine("4. Excluir produto");
        Console.WriteLine("5. Sair");
        Console.Write("Opção: ");

        if (!int.TryParse(Console.ReadLine(), out int opcao))
        {
            Console.WriteLine("Opção inválida!");
            continue;
        }

        switch (opcao)
        {
            case 1:
                CadastrarProduto(connectionString);
                break;
            case 2:
                ListarProdutos(connectionString);
                break;
            case 3:
                AtualizarProduto(connectionString);
                break;
            case 4:
                ExcluirProduto(connectionString);
                break;
            case 5:
                return;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();

    }

    static void CadastrarProduto(string connectionString)
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();
        Console.Write("Preço: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            Console.WriteLine("Preço inválido!");
            return;
        }
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Produtos(Id, Nome, Preco, Descricao) VALUES(@Id, @Nome, @Preco, @Descricao)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                command.Parameters.AddWithValue("@Nome",
     nome);
                command.Parameters.AddWithValue("@Preco", preco);
                command.Parameters.AddWithValue("@Descricao", descricao);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro ao cadastrar o produto.");
                }
            }
        }
    }

    static void ListarProdutos(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Produtos";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())

                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Não há produtos cadastrados.");
                    }
                    else
                    {
                        Console.WriteLine("Lista de produtos:");
                        Console.WriteLine("------------------");
                        Console.WriteLine("ID\tNome\tPreço\tDescrição");

                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string nome = reader.GetString(1);
                            decimal preco = reader.GetDecimal(2);
                            string descricao = reader.GetString(3);

                            Console.WriteLine($"{id}\t{nome}\t{preco}\t{descricao}");
                        }
                    }
                }
            }
        }
    }

    static void AtualizarProduto(string connectionString)
    {
        Console.Write("Digite o ID do produto a ser atualizado: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid produtoId))
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        Console.Write("Novo nome (deixe em branco para manter): ");
        string novoNome = Console.ReadLine();
        Console.Write("Novo preço (deixe em branco para manter): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
        {
            novoPreco = 0;
        }
        Console.Write("Nova descrição (deixe em branco para manter): ");
        string novaDescricao = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = @"UPDATE Produtos SET Nome = @NovoNome, Preco = @NovoPreco, Descricao = @NovaDescricao WHERE Id = @ProdutoId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProdutoId", produtoId);
                command.Parameters.AddWithValue("@NovoNome", novoNome);
                command.Parameters.AddWithValue("@NovoPreco", novoPreco);
                command.Parameters.AddWithValue("@NovaDescricao", novaDescricao);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado ou não houve alterações.");
                }
            }
        }
    }

    static void ExcluirProduto(string connectionString)
    {
        Console.Write("Digite o ID do produto a ser excluído: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid produtoId))
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Produtos WHERE Id = @ProdutoId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProdutoId", produtoId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }
    }
}

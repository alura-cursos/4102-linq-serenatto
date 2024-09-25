using Microsoft.EntityFrameworkCore;
using SerenattoEnsaio.Modelos;
using System.Configuration;


namespace Serenatto.Dados;
internal class SerenattoContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    static private string connectionString = string.Empty;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

    }


}
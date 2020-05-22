using BackendApplication.Data.Configurations;
using BackendApplication.Domain;
using System.Data.Entity;

namespace BackendApplication.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        // base("DatabaseContext") nome da string de conexão com o banco
        public DatabaseContext() : base("DatabaseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

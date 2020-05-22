using BackendApplication.Domain;
using System.Data.Entity.ModelConfiguration;

namespace BackendApplication.Data.Configurations
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("Produto");

            HasKey(t => t.Codigo);

            Property(t => t.Nome)
                .HasMaxLength(50)
                .HasColumnName("NomeProduto")
                .IsRequired();

            Property(t => t.Preco)
                .IsRequired();

            Property(t => t.ImagemUrl)
                .IsOptional();
        }
    }
}

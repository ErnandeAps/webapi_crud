using CleanSuporte.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanSuporte.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Caderno",
                    Description = "Caderno esperial 100 folhas",
                    Price = 9.45m
                },
                new Product
                {
                    Id = 2,
                    Name = "Borracha",
                    Description = "Borracha branca",
                    Price = 3.15m
                },
                new Product
                {
                    Id = 3,
                    Name = "Caneta",
                    Description = "Caneta preta",
                    Price = 1.00m
                },
                new Product
                {
                    Id = 4,
                    Name = "Resma 200F",
                    Description = "Resma folha 500F branca",
                    Price = 19.00m
                },
                new Product
                {
                    Id = 5,
                    Name = "Lápis",
                    Description = "Lápis preto 01mm",
                    Price = 1.75m
                }
                );
        }
    }
}

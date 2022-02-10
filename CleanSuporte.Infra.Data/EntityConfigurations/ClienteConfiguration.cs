using CleanSuporte.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Infra.Data.EntityConfigurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Rg).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(p => p.Endereco).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Num).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Uf).HasMaxLength(2).IsRequired();
            builder.Property(p => p.Cep).HasMaxLength(8).IsRequired();
           
        }
    }
}

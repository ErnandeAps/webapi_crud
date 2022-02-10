using CleanSuporte.Domain.Entities;
using CleanSuporte.Infra.Data.EntityConfigurations;
using CleanSuporte.Infra.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanSuporte.Infra.Data.Context{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ClienteConfiguration());
            //builder.ApplyConfiguration(new UsuarioConfiguration());
        }  
    }
}

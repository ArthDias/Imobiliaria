using Microsoft.EntityFrameworkCore;
using Imobiliaria.Domain.Entities;

namespace Imobiliaria.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Imovel> IMOVEIS { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Imovel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Descricao).IsRequired();
            entity.Property(e => e.Cep).IsRequired().HasMaxLength(8);
            entity.Property(e => e.Logradouro).IsRequired();
            entity.Property(e => e.Numero).IsRequired();
            entity.Property(e => e.Cidade).IsRequired();
            entity.Property(e => e.Estado).IsRequired();
            entity.Property(e => e.ValorAluguel).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.Status).HasConversion<int>().IsRequired();
        });
    }

}

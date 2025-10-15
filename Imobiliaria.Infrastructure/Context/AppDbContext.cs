using Microsoft.EntityFrameworkCore;
using Imobiliaria.Domain.Entities;

namespace Imobiliaria.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Imovel> IMOVEIS { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }

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
            entity.Property(e => e.Status).IsRequired();
        });
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired();
            entity.Property(e => e.Cpf).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Telefone).IsRequired();
        });
        modelBuilder.Entity<Locacao>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ImovelId).IsRequired();
            entity.Property(e => e.ClienteId).IsRequired();
            entity.Property(e => e.DataInicio);
            entity.Property(e => e.DataFim);
            entity.Property(e => e.ValorTotal).IsRequired().HasColumnType("decimal(18,2)");
            entity.HasOne<Imovel>()
                  .WithMany()
                  .HasForeignKey(e => e.ImovelId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Cliente>()
                  .WithMany()
                  .HasForeignKey(e => e.ClienteId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }

}

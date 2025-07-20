using Microsoft.EntityFrameworkCore;
using StockManager.Dominio.Entities;

namespace StockManager.Data.DbContext;

public class StockManagerDbContext(StockManagerDbContext.StockManagerContextOptions dbContextOptions) : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItensVenda { get; set; }
    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<FuncaoAcesso> FuncaoAcessos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tamanho> Tamanhos { get; set; }
    public DbSet<Marca> Marcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(dbContextOptions.DbConnectionString, opt =>
        {
            opt.MigrationsAssembly(GetType().Assembly.FullName);
            opt.CommandTimeout(300);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemVenda>()
            .HasOne(iv => iv.Produto)
            .WithMany()
            .HasForeignKey(iv => iv.ProdutoId);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(iv => iv.Venda)
            .WithMany(v => v.Itens)
            .HasForeignKey(iv => iv.VendaId);

        modelBuilder.Entity<MovimentacaoEstoque>()
            .HasOne(me => me.Produto)
            .WithMany()
            .HasForeignKey(me => me.ProdutoId);
        
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Marca)
            .WithMany(m => m.Produtos)
            .HasForeignKey(p => p.MarcaId);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Tamanho)
            .WithMany(t => t.Produtos)
            .HasForeignKey(p => p.TamanhoId);
        
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.FuncaoAcesso)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(u => u.FuncaoAcessoId);
    }

    public class StockManagerContextOptions
    {
        public string DbConnectionString { get; set; }
    }
}
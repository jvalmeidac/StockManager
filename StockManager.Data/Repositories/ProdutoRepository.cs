using StockManager.Data.DbContext;
using StockManager.Data.Repositories.Base;
using StockManager.Dominio.Entities;
using StockManager.Dominio.Repositories;

namespace StockManager.Data.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(StockManagerDbContext context) : base(context)
    {
    }
}
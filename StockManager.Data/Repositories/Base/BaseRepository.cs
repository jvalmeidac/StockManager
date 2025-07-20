using Microsoft.EntityFrameworkCore;
using StockManager.Data.DbContext;
using StockManager.Dominio.Repositories.Base;

namespace StockManager.Data.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly StockManagerDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(StockManagerDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    public void Update(TEntity entity) => _dbSet.Update(entity);
    public void Remove(TEntity entity) => _dbSet.Remove(entity);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
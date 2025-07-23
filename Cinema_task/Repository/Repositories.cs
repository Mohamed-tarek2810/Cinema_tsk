using Cinema_task.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cinema_task.Repository
{
    public class Repositories<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public Repositories()
        {
            _context = new ApplicationDbContext();
            _db = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync( Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null)
        {
            IQueryable<T> entities = _db;

            if (filter is not null)
            {
                entities = entities.Where(filter);
            }

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            return await entities.ToListAsync();
        }

        public async Task<T?> GetOneAsync( Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null)
        {
            return (await GetAsync(filter, includes)).FirstOrDefault();
        }

        
        public async Task CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Edit(T entity)
        {
            _db.Update(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
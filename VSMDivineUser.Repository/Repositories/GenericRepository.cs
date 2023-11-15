using Microsoft.EntityFrameworkCore;
using VSMDivineUser.Models.Entities;
using VSMDivineUser.Repository.IRepositories;

namespace VSMDivineUser.Repository.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly UserDataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(UserDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<T>> GetAllAsync(int pageIndex = 1, int pageSize = 10)
        {
            // Calculate the number of entities to skip based on the page index and page size
            int skipCount = (pageIndex - 1) * pageSize;

            try
            {
                List<T> entities = await _context.Set<T>()
                                        .Skip(skipCount)
                                        .Take(pageSize)
                                        .ToListAsync();

                return entities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

    }
}

using Cars.DAL.Abstract;
using Cars.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class AsyncRepositoryBase<T> : IAsyncRepositoryBase<T> where T : class
    {
        protected IApplicationDbContext _context;

        public AsyncRepositoryBase(IApplicationDbContext context) 
        {
            _context = context;
        }


        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }


        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

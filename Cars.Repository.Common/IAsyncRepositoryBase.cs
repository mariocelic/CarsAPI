using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IAsyncRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        Task<T> FindById(int id);
        Task Create(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}


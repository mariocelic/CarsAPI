using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Repository.Interfaces
{
    public interface IAsyncRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
        Task Create(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}


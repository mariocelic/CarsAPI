using Cars.Data.Models;
using Cars.Repository.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Interfaces
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<VehicleModel>
    {
        IQueryable<VehicleModel> FindAllWithMake();
        Task<VehicleModel> FindByIdWithMake(int id);
        Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
    }
}

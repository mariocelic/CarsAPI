using Cars.Data.Models;
using Cars.Repository.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
        IQueryable<VehicleMake> FindAllAsync();

        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);

    }
}

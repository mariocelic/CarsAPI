using Cars.Common;
using Cars.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<IVehicleMakeEntity>
    {
        IQueryable<IVehicleMakeEntity> FindAllAsync();

        Task<IList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);

    }
}

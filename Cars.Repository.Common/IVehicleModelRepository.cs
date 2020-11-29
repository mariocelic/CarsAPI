using Cars.Common;
using Cars.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<IVehicleModelEntity>
    {
        IQueryable<IVehicleModelEntity> FindAllWithMake();
        Task<IVehicleModelEntity> FindByIdWithMake(int id);
        Task<IList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
    }
}

using Cars.Common;
using Cars.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<IVehicleMakeEntity> FindVehicleMakeById(int id);
        Task<IVehicleMakeEntity> CreateAsync(IVehicleMakeEntity vehicleMake);
        Task<IVehicleMakeEntity> UpdateAsync(int id, IVehicleMakeEntity vehicleMake);
        Task<IVehicleMakeEntity> DeleteAsync(int id);

    }
}

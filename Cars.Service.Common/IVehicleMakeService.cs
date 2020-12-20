using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model.Common;
using System.Threading.Tasks;

namespace Cars.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<PaginationList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<VehicleMakeEntity> FindVehicleMakeById(int id);
        Task CreateAsync(IVehicleMake vehicleMake);
        Task UpdateAsync(IVehicleMake vehicleMake);
        Task DeleteAsync(int id);

    }
}

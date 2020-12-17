using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model.Common;
using System.Threading.Tasks;

namespace Cars.Service.Common
{
    public interface IVehicleModelService
    {
        Task<PaginationList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<IVehicleModel> FindVehicleModelById(int id);
        Task CreateAsync(IVehicleModel vehicleModel);
        Task UpdateAsync(IVehicleModel vehicleModel);
        Task DeleteAsync(int id);
    }
}

using Cars.Common;
using Cars.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<VehicleModelEntity>
    {
        Task<VehicleModelEntity> FindWithMakeById(int id);
        Task<PaginationList<VehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<PaginationList<VehicleModelEntity>> Paginate(IPagingParameters page, IQueryable<VehicleModelEntity> models);
    }
}

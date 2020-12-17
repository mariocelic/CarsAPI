using Cars.Common;
using Cars.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<IVehicleModelEntity>
    {
        IQueryable<IVehicleModelEntity> FindAllWithMake(int id);
        Task<IVehicleModelEntity> FindByIdWithMake(int id);
        Task<PaginationList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<PaginationList<IVehicleModelEntity>> Paginate(IPagingParameters page, IQueryable<IVehicleModelEntity> models);
    }
}

using Cars.Common;
using Cars.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMakeEntity>
    {
        IQueryable<IVehicleMakeEntity> FindAllAsync();
        Task<PaginationList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<PaginationList<IVehicleMakeEntity>> Paginate(IPagingParameters page, IQueryable<IVehicleMakeEntity> makes);
    }
}

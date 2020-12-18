using Cars.Common;
using Cars.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository.Common
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMakeEntity>
    {
        IQueryable<VehicleMakeEntity> FindAllAsync();
        Task<PaginationList<VehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        Task<PaginationList<VehicleMakeEntity>> Paginate(IPagingParameters page, IQueryable<VehicleMakeEntity> makes);
    }
}

using AutoMapper;
using Cars.Common;
using Cars.DAL.Abstract;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class VehicleModelRepository : AsyncRepositoryBase<IVehicleModelEntity>, IVehicleModelRepository
    {
        private readonly IMapper _mapper;

        public VehicleModelRepository(IApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }


        public IQueryable<IVehicleModelEntity> FindAllWithMake()
        {
            return _context.Set<IVehicleModelEntity>()
               .AsNoTracking()
               .Include(q => q.VehicleMake);
        }

        public async Task<IVehicleModelEntity> FindByIdWithMake(int id)
        {
            return await _context.Set<IVehicleModelEntity>()
                .AsNoTracking()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);

        }

        public async Task<IList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {
            IQueryable<IVehicleModelEntity> vehicleModels;

            // Filtering
            using (_context)
            {
                try
                {

                    if (filteringParams.FilterString != null)
                    {
                        pagingParams.PageNumber = 1;
                    }
                    else
                    {
                        filteringParams.FilterString = filteringParams.CurrentFilter;
                    }


                    if (!string.IsNullOrEmpty(filteringParams.FilterString))
                    {
                        vehicleModels = _context.VehicleModels.Include(q => q.VehicleMake).Where(q => q.VehicleMake.Name.Contains(filteringParams.FilterString));
                    }
                    else vehicleModels = null;

                    //sorting
                    switch (sortingParams.SortOrder)
                    {
                        case "name_desc":
                            vehicleModels = _context.VehicleModels.Include(q => q.VehicleMake).OrderByDescending(q => q.VehicleMake.Name);
                            break;

                        default:
                            vehicleModels = vehicleModels != null ? vehicleModels.Include(q => q.VehicleMake).OrderBy(q => q.VehicleMake.Name) : _context.VehicleModels.Include(q => q.VehicleMake).OrderBy(q => q.VehicleMake.Name);
                            break;
                    }

                    return _mapper.Map<IList<IVehicleModelEntity>>(await PaginationList<IVehicleModelEntity>.CreateAsync(vehicleModels, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}

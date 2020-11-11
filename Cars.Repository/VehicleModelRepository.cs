using AutoMapper;
using Cars.Data.Interfaces;
using Cars.Data.Models;
using Cars.Repository.Helpers;
using Cars.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class VehicleModelRepository : AsyncRepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        private readonly IMapper _mapper;

        public VehicleModelRepository(IApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }


        public IQueryable<VehicleModel> FindAllWithMake()
        {
            return _context.Set<VehicleModel>()
               .AsNoTracking()
               .Include(q => q.VehicleMake);
        }

        public async Task<VehicleModel> FindByIdWithMake(int id)
        {
            return await _context.Set<VehicleModel>()
                .AsNoTracking()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);

        }

        public async Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {
            IQueryable<VehicleModel> vehicleModels;

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

                    return _mapper.Map<IList<VehicleModel>>(await PaginationList<VehicleModel>.CreateAsync(vehicleModels, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}

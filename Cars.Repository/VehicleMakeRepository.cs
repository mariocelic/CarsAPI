using AutoMapper;
using Cars.Common;
using Cars.DAL.Abstract;
using Cars.DAL.Entities;
using Cars.Model.Common;
using Cars.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<IVehicleMakeEntity>, IVehicleMakeRepository
    {       
        private readonly IMapper _mapper;

        public VehicleMakeRepository(IApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }

        public IQueryable<IVehicleMakeEntity> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
        }

        public async Task<IList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            IQueryable<IVehicleMakeEntity> vehicleMakes;

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
                        vehicleMakes = _context.VehicleMakes.Where(q => q.Name.Contains(filteringParams.FilterString));
                    }
                    else vehicleMakes = null;

                    //sorting
                    switch (sortingParams.SortOrder)
                    {
                        case "name_desc":
                            vehicleMakes = _context.VehicleMakes.OrderByDescending(q => q.Name);
                            break;

                        default:
                            vehicleMakes = vehicleMakes != null ? vehicleMakes.OrderBy(q => q.Name) : _context.VehicleMakes.OrderBy(q => q.Name);
                            break;
                    }

                    return _mapper.Map<IList<IVehicleMakeEntity>>(await PaginationList<IVehicleMakeEntity>.CreateAsync(vehicleMakes, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}

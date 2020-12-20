using AutoMapper;
using Cars.Common;
using Cars.DAL;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMakeEntity>, IVehicleMakeRepository
    {
        private readonly IMapper _mapper;

        public VehicleMakeRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }

        public IQueryable<IVehicleMakeEntity> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
        }

        public async Task<PaginationList<IVehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams,
            IPagingParameters pagingParams)
        {

            // Filtering
            if (!String.IsNullOrEmpty(filteringParams.SearchString))
            {
                var searchMakes = _context.VehicleMakes.Where(m => m.Name.Contains(filteringParams.SearchString)
                                                                        || m.Abrv.Contains(filteringParams.SearchString)).OrderByDescending(m => m.Name);

                return await Paginate(pagingParams, searchMakes);
            }

            // Sorting
            switch (sortingParams.SortOrder)
            {
                case "name_desc":
                    {
                        var makes = _context.VehicleMakes.OrderByDescending(m => m.Name);

                        return await Paginate(pagingParams, makes);
                    }
                case "abrv":
                    {
                        var makes = _context.VehicleMakes.OrderBy(m => m.Abrv);

                        return await Paginate(pagingParams, makes);
                    }
                case "abrv_desc":
                    {
                        var makes = _context.VehicleMakes.OrderByDescending(m => m.Abrv);

                        return await Paginate(pagingParams, makes);
                    }
                default:
                    {
                        var makes = _context.VehicleMakes.OrderBy(m => m.Name);

                        return await Paginate(pagingParams, makes);
                    }
            }
        }

        public async Task<PaginationList<IVehicleMakeEntity>> Paginate(IPagingParameters page, IQueryable<IVehicleMakeEntity> makes)
        {
            var makesPage = await PaginationList<IVehicleMakeEntity>.CreateAsync(makes, page.PageNumber, page.PageSize);

            var list = _mapper.Map<List<IVehicleMakeEntity>>(makesPage.Items);

            var listMakes = new PaginationList<IVehicleMakeEntity>(list, makesPage.TotalCount, makesPage.CurrentPage, makesPage.PageSize);

            return listMakes;
        }

    }
}

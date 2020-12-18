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
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMakeEntity>, IVehicleMakeRepository
    {
        private readonly IMapper _mapper;

        public VehicleMakeRepository(IApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }

        public IQueryable<VehicleMakeEntity> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
        }

        public async Task<PaginationList<VehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams,
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

        public async Task<PaginationList<VehicleMakeEntity>> Paginate(IPagingParameters page, IQueryable<VehicleMakeEntity> makes)
        {
            var makesPage = await PaginationList<VehicleMakeEntity>.CreateAsync(makes, page.PageNumber, page.PageSize);

            var list = _mapper.Map<List<VehicleMakeEntity>>(makesPage.Items);

            var listMakes = new PaginationList<VehicleMakeEntity>(list, makesPage.TotalCount, makesPage.CurrentPage, makesPage.PageSize);

            return listMakes;
        }

    }
}

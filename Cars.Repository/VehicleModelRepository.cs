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


        public IQueryable<IVehicleModelEntity> FindAllWithMake(int id)
        {
            return _context.VehicleModels.Where(m => m.MakeId == id);
        }

        public async Task<IVehicleModelEntity> FindByIdWithMake(int id)
        {
            return await _context.Set<IVehicleModelEntity>()
                .AsNoTracking()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);

        }

        public async Task<PaginationList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams,
            IPagingParameters pagingParams)
        {
            // Filtering
            if (!String.IsNullOrEmpty(filteringParams.SearchString))
            {
                var searchModels = _context.VehicleModels.Include(q => q.VehicleMake).Where(q => q.VehicleMake.Name.Contains(filteringParams.SearchString)
                                                                        || q.Abrv.Contains(filteringParams.SearchString)).OrderByDescending(m => m.Name);

                return await Paginate(pagingParams, searchModels);
            }
            
            // Sorting
            switch (sortingParams.SortOrder)
            {
                case "name_desc":
                    {
                        var models = _context.VehicleModels.Include(q => q.VehicleMake).OrderByDescending(q => q.VehicleMake.Name);

                        return await Paginate(pagingParams, models);
                    }
                case "abrv_desc":
                    {
                        var models = _context.VehicleModels.Include(q => q.VehicleMake).OrderByDescending(q => q.Abrv);

                        return await Paginate(pagingParams, models);
                    }
                case "abrv":
                    {
                        var models = _context.VehicleModels.Include(q => q.VehicleMake).OrderBy(q => q.Abrv);

                        return await Paginate(pagingParams, models);
                    }
                default:
                    {
                        var models = _context.VehicleModels.Include(q => q.VehicleMake).OrderBy(q => q.VehicleMake.Name);

                        return await Paginate(pagingParams, models);
                    }
            }
        }

        public async Task<PaginationList<IVehicleModelEntity>> Paginate(IPagingParameters page, IQueryable<IVehicleModelEntity> models)
        {
            var modelsPage = await PaginationList<IVehicleModelEntity>.CreateAsync(models, page.PageNumber, page.PageSize);

            var list = _mapper.Map<List<IVehicleModelEntity>>(modelsPage.Items);

            var listModels = new PaginationList<IVehicleModelEntity>(list, modelsPage.TotalCount, modelsPage.CurrentPage, modelsPage.PageSize);

            return listModels;
        }

    }
}

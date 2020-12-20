using AutoMapper;
using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;
using Cars.Repository.Common;
using Cars.Service.Common;
using System.Threading.Tasks;

namespace Cars.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(IVehicleModel vehicleModel)
        {
            var newModel = _mapper.Map<VehicleModelEntity>(vehicleModel);
            await _unitOfWork.VehicleModel.Create(newModel);
            await _unitOfWork.CommitAsync();

        }

        public async Task UpdateAsync(IVehicleModel vehicleModel)
        {
            var editModel = _mapper.Map<VehicleModelEntity>(vehicleModel);
            _unitOfWork.VehicleModel.Update(editModel);
            await _unitOfWork.CommitAsync();

        }
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.VehicleModel.Delete(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<VehicleModelEntity> FindVehicleModelById(int id)
        {
            var model = await _unitOfWork.VehicleModel.FindById(id);
            var listModel = _mapper.Map<VehicleModelEntity>(model);
            return listModel;
        }
        public async Task<PaginationList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            return await _unitOfWork.VehicleModel.FindAllModelsPaged(sortingParams, filteringParams, pagingParams);

        }
    }
}

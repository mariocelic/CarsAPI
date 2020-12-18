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
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }


        public async Task CreateAsync(IVehicleMake vehicleMake)
        {
            var newMake = _mapper.Map<VehicleMakeEntity>(vehicleMake);            
            await _unitOfWork.VehicleMake.Create(newMake);
            await _unitOfWork.CommitAsync();

        }

        public async Task UpdateAsync(IVehicleMake vehicleMake)
        {
            var editMake = _mapper.Map<VehicleMakeEntity>(vehicleMake);
            _unitOfWork.VehicleMake.Update(editMake);
            await _unitOfWork.CommitAsync();
        }

       
        public async Task DeleteAsync(int id)
        {           
            await _unitOfWork.VehicleMake.Delete(id);
            await _unitOfWork.CommitAsync();            
        }

        public async Task<IVehicleMake> FindVehicleMakeById(int id)
        {
            var make = await _unitOfWork.VehicleMake.FindById(id);
            var listMake = _mapper.Map<IVehicleMake>(make);
            return listMake;
        }
        public async Task<PaginationList<VehicleMakeEntity>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            return await _unitOfWork.VehicleMake.FindAllMakesPaged(sortingParams, filteringParams, pagingParams);

        }        
    }
}

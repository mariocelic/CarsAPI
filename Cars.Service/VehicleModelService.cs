using Cars.Data.Models;
using Cars.Repository.Helpers;
using Cars.Repository.Interfaces;
using Cars.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;



        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<VehicleModel> CreateAsync(VehicleModel vehicleModel)
        {
            await _unitOfWork.VehicleModel.Create(vehicleModel);
            await _unitOfWork.CommitAsync();

            return vehicleModel;

        }

        public async Task<VehicleModel> DeleteAsync(int id)
        {
            var model = await _unitOfWork.VehicleModel.FindById(id);

            await _unitOfWork.VehicleModel.Delete(id);
            await _unitOfWork.CommitAsync();
            return model;
        }

        public async Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            return await _unitOfWork.VehicleModel.FindAllModelsPaged(sortingParams, filteringParams, pagingParams);

        }



        public async Task<VehicleModel> FindVehicleModelById(int id)
        {
            return await _unitOfWork.VehicleModel.FindByIdWithMake(id);
        }

        public async Task<VehicleModel> UpdateAsync(int id, VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = await _unitOfWork.VehicleModel.FindById(id);

            if (string.IsNullOrEmpty(vehicleModel.Name))
            {
                vehicleModelToUpdate.Name = vehicleModelToUpdate.Name;
            }
            else
            {
                vehicleModelToUpdate.Name = vehicleModel.Name;
            }


            if (string.IsNullOrEmpty(vehicleModel.Abrv))
            {
                vehicleModelToUpdate.Abrv = vehicleModelToUpdate.Abrv;
            }
            else
            {
                vehicleModelToUpdate.Abrv = vehicleModel.Abrv;
            }

            _unitOfWork.VehicleModel.Update(vehicleModelToUpdate);
            await _unitOfWork.CommitAsync();


            return vehicleModelToUpdate;

        }
    }
}

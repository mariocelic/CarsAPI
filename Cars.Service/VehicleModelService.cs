using Cars.Common;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using Cars.Service.Common;
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

        public async Task<IVehicleModelEntity> CreateAsync(IVehicleModelEntity vehicleModel)
        {
            await _unitOfWork.VehicleModel.Create(vehicleModel);
            await _unitOfWork.CommitAsync();

            return vehicleModel;

        }

        public async Task<IVehicleModelEntity> DeleteAsync(int id)
        {
            var model = await _unitOfWork.VehicleModel.FindById(id);

            await _unitOfWork.VehicleModel.Delete(id);
            await _unitOfWork.CommitAsync();
            return model;
        }

        public async Task<IList<IVehicleModelEntity>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            return await _unitOfWork.VehicleModel.FindAllModelsPaged(sortingParams, filteringParams, pagingParams);

        }



        public async Task<IVehicleModelEntity> FindVehicleModelById(int id)
        {
            return await _unitOfWork.VehicleModel.FindByIdWithMake(id);
        }

        public async Task<IVehicleModelEntity> UpdateAsync(int id, IVehicleModelEntity vehicleModel)
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

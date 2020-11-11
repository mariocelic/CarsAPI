using Cars.Data.Models;
using Cars.Repository.Helpers;
using Cars.Repository.Interfaces;
using Cars.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public async Task<VehicleMake> CreateAsync(VehicleMake vehicleMake)
        {
            await _unitOfWork.VehicleMake.Create(vehicleMake);
            await _unitOfWork.CommitAsync();

            return vehicleMake;

        }

        public async Task<VehicleMake> DeleteAsync(int id)
        {
            var make = await _unitOfWork.VehicleMake.FindById(id);

            await _unitOfWork.VehicleMake.Delete(id);
            await _unitOfWork.CommitAsync();
            return make;
        }

        public async Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            return await _unitOfWork.VehicleMake.FindAllMakesPaged(sortingParams, filteringParams, pagingParams);

        }

        public async Task<VehicleMake> FindVehicleMakeById(int id)
        {
            return await _unitOfWork.VehicleMake.FindById(id);
        }

        public async Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake)
        {
            var vehicleMakeToUpdate = await _unitOfWork.VehicleMake.FindById(id);

            if (string.IsNullOrEmpty(vehicleMake.Name))
            {
                vehicleMakeToUpdate.Name = vehicleMakeToUpdate.Name;
            }
            else
            {
                vehicleMakeToUpdate.Name = vehicleMake.Name;
            }


            if (string.IsNullOrEmpty(vehicleMake.Abrv))
            {
                vehicleMakeToUpdate.Abrv = vehicleMakeToUpdate.Abrv;
            }
            else
            {
                vehicleMakeToUpdate.Abrv = vehicleMake.Abrv;
            }

            _unitOfWork.VehicleMake.Update(vehicleMakeToUpdate);
            await _unitOfWork.CommitAsync();


            return vehicleMakeToUpdate;

        }
    }
}

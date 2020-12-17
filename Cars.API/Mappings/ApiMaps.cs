using AutoMapper;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;
using Cars.WebAPI.DTO;

namespace Cars.API.Mappings
{
    public class ApiMaps : Profile
    {
        public ApiMaps()
        {
            // VehicleMake
            
            CreateMap<IVehicleMake, VehicleMakeDTO>().ReverseMap();
            

            // VehicleModel
            
            CreateMap<IVehicleModel, VehicleModelDTO>().ReverseMap();


        }

    }
}

using AutoMapper;
using Cars.Common;
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
            CreateMap<VehicleMakeDTO, IVehicleMake>().ReverseMap();

            // VehicleModel
            CreateMap<VehicleModelDTO, IVehicleModel>().ReverseMap();
        }

    }
}

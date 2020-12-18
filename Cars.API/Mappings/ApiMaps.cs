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
            CreateMap<IVehicleMake, VehicleMakeEntity>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMake, VehicleMakeEntity>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMakeDTO>().ReverseMap();

            // VehicleModel
            CreateMap<IVehicleModel, IVehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModelEntity>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModelDTO>().ReverseMap();


            //Paging
            CreateMap<PaginationList<IVehicleMakeEntity>, PaginationList<IVehicleMake>>();
            CreateMap<PaginationList<IVehicleModelEntity>, PaginationList<IVehicleModel>>();

        }

    }
}

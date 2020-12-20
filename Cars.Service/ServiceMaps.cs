using AutoMapper;
using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;

namespace Cars.Service
{
    public class ServiceMaps : Profile
    {
        public ServiceMaps()
        {

            // VehicleMake
            CreateMap<VehicleMakeEntity, IVehicleMakeEntity>().ReverseMap();
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();            
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMakeEntity, IVehicleMake>().ReverseMap();

            // VehicleModel
            CreateMap<VehicleModelEntity, IVehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModelEntity, IVehicleModel>().ReverseMap();

            //Pagination
            CreateMap<PaginationList<IVehicleMakeEntity>, PaginationList<IVehicleMake>>();
            CreateMap<PaginationList<IVehicleModelEntity>, PaginationList<IVehicleModel>>();
        }       
    }
}

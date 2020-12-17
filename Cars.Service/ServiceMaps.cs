using AutoMapper;
using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;
using System.Collections.Generic;

namespace Cars.Service
{
    public class ServiceMaps : Profile
    {
        public ServiceMaps()
        {
            //VehicleMake
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, IVehicleMakeEntity>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMakeEntity>().ReverseMap();

            //VehicleModel
            CreateMap<VehicleModel, VehicleModelEntity>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModelEntity>().ReverseMap();            
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();            
            CreateMap<IVehicleModel, IVehicleModelEntity>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModelEntity>().ReverseMap();

            //Paging
            CreateMap<PaginationList<IVehicleMakeEntity>, PaginationList<IVehicleMake>>();
            CreateMap<PaginationList<IVehicleModelEntity>, PaginationList<IVehicleModel>>();
        }
    }
}

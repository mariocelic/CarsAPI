using AutoMapper;
using Cars.Common;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;

namespace Cars.Repository
{
    public class RepoMaps : Profile
    {
        public RepoMaps()
        {

            // VehicleMake
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, IVehicleMakeEntity>().ReverseMap();


            // VehicleModel
            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, IVehicleModelEntity>().ReverseMap();


            //Paging
            CreateMap<PaginationList<IVehicleMakeEntity>, PaginationList<IVehicleMake>>();
            CreateMap<PaginationList<IVehicleModelEntity>, PaginationList<IVehicleModel>>();

        }       
    }
}

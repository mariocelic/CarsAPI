using AutoMapper;
using Cars.DAL.Entities;
using Cars.Model;
using Cars.Model.Common;
using Cars.WebAPI.DTO;

namespace Cars.API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
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

            // User
            CreateMap<IUser, UserEntity>().ReverseMap();
            CreateMap<User, IUser>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<IUser, UserDTO>().ReverseMap();
        }

    }
}

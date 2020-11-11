using AutoMapper;
using Cars.Data.Models;
using Cars.API.DTO;

namespace Cars.API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {

            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelDTO>()
                //.ForMember(dest => dest.VehicleMake, opts => opts.MapFrom(src => src.VehicleMake))
                .ReverseMap();
        }

    }
}

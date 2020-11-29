using System.Collections.Generic;

namespace Cars.DAL.Entities
{
    public interface IVehicleMakeEntity
    {
        string Abrv { get; set; }
        int MakeId { get; set; }
        string Name { get; set; }
        ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
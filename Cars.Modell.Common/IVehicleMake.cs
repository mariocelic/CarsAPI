using System.Collections.Generic;

namespace Cars.Model.Common
{
    public interface IVehicleMake
    {
        string Abrv { get; set; }
        int MakeId { get; set; }
        string Name { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
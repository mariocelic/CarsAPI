using Cars.Model.Common;
using System.Collections.Generic;

namespace Cars.Model
{
    public class VehicleMake : IVehicleMake
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IEnumerable<IVehicleModel> VehicleModels { get; set; }
    }
}

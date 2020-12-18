using Cars.Model.Common;

namespace Cars.Model
{
    public class VehicleModel : IVehicleModel
    {

        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IVehicleMake VehicleMake { get; set; }
        public int MakeId { get; set; }
    }
}

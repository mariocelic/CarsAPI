namespace Cars.Model.Common
{
    public interface IVehicleModel
    {
        string Abrv { get; set; }
        int MakeId { get; set; }
        int ModelId { get; set; }
        string Name { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
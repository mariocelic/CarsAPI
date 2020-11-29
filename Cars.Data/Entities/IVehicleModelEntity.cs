namespace Cars.DAL.Entities
{
    public interface IVehicleModelEntity
    {
        string Abrv { get; set; }
        int MakeId { get; set; }
        int ModelId { get; set; }
        string Name { get; set; }
        VehicleMakeEntity VehicleMake { get; set; }
    }
}
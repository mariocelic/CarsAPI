using System.ComponentModel.DataAnnotations;

namespace Cars.WebAPI.DTO
{
    public class VehicleModelDTO
    {
        public int ModelId { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
    }
}


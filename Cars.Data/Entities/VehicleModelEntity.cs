using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.DAL.Entities
{
    public class VehicleModelEntity : IVehicleModelEntity
    {
        [Key]
        public int ModelId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMakeEntity VehicleMake { get; set; }
        public int MakeId { get; set; }
    }
}

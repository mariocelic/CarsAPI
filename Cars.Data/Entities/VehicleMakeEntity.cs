using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Entities
{
    public class VehicleMakeEntity : IVehicleMakeEntity
    {
        [Key]
        public int MakeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual IEnumerable<VehicleModelEntity> VehicleModels { get; set; }
    }
}

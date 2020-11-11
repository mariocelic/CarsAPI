using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.Data.Models
{
    public class VehicleMake
    {
        [Key]
        public int MakeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}

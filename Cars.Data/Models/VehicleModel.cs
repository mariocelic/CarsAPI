using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Data.Models
{
    public class VehicleModel
    {
        [Key]
        public int ModelId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMake VehicleMake { get; set; }
        public int MakeId { get; set; }
    }
}

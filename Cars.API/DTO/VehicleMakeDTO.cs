﻿using System.ComponentModel.DataAnnotations;

namespace Cars.WebAPI.DTO
{
    public class VehicleMakeDTO
    {
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}

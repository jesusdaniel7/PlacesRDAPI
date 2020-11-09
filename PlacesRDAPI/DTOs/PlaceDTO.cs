using PlacesRDAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.DTOs
{
    public class PlaceDTO
    {
        public int PlaceID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public Province Province { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
   
    }
}

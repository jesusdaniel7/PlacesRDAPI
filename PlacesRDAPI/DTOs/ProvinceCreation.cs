using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.DTOs
{
    public class ProvinceCreation
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public List<PlaceDTO> PlaceDTO { get; set; }
    }
}

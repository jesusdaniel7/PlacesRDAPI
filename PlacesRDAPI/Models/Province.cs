using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Models
{
    public class Province
    {
        public int ProvinceID { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public List<Place> Place { get; set; }
    }
}

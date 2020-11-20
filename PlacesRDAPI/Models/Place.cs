using AutoMapper;
using PlacesRDAPI.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Models
{
    public class Place
    {
        public int PlaceID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public Province Province { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Photo { get; set; }
        public List<PlacePhotos> Photos { get; set; }

    }
}

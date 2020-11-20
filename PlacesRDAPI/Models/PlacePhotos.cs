using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Models
{
    public class PlacePhotos
    {
        public int PlacePhotosID { get; set; }
        public string Name { get; set; }
        public int PlaceID { get; set; }
        public string Photo { get; set; }
        public Place Place { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using PlacesRDAPI.Models;
using PlacesRDAPI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.DTOs
{
    public class PlacePhotosCreation
    {
        public string Name { get; set; }
        public int PlaceID { get; set; }
        public IFormFile Photo { get; set; }
        [WeightFileValidation(MaxWeightMB: 4)]
        [ContentTypeValidation(contentTypeGroup: ContentTypeGroup.Photo)]
        public PlaceDTO PlaceDTO { get; set; }
    }
}

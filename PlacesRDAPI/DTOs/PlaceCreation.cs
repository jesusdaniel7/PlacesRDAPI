﻿using Microsoft.AspNetCore.Http;
using PlacesRDAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.DTOs
{
    public class PlaceCreation : PlacePatchDTO
    {
        [WeightFileValidation(MaxWeightMB: 4)]
        [ContentTypeValidation(contentTypeGroup: ContentTypeGroup.Photo)]
        public IFormFile Photo { get; set; }

    }
}

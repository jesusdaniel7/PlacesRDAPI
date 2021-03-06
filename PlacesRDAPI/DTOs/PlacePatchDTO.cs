﻿using Microsoft.AspNetCore.Http;
using PlacesRDAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.DTOs
{
    public class PlacePatchDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public ProvinceDTO provinceDTO { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PlacesRDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlacePhotos> PlacesPhotos { get; set; } 
    }
}

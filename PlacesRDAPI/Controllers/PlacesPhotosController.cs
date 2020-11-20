using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesRDAPI.Context;
using PlacesRDAPI.DTOs;
using PlacesRDAPI.Models;
using PlacesRDAPI.Services;

namespace PlacesRDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesPhotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IFileStorage fileStorage;
        private readonly string container = "placesphotos";

        public PlacesPhotosController(ApplicationDbContext context, IMapper mapper, IFileStorage fileStorage)
        {
            _context = context;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlacePhotos>>> Get()
        {
            return await _context.PlacesPhotos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PlacePhotos>> Get(int id)
        {
            var placePhotos = await _context.PlacesPhotos.FindAsync(id);

          

            return placePhotos;
        }
        [HttpPost]
        public async Task<ActionResult<PlacePhotos>> Post([FromForm]PlacePhotosCreation placePhotoscreation)
        {
            var placePhotos = mapper.Map<PlacePhotos>(placePhotoscreation);
            if (placePhotoscreation.Photo != null)
            {
                using (var memoryStrean = new MemoryStream())
                {
                    await placePhotoscreation.Photo.CopyToAsync(memoryStrean);
                    var content = memoryStrean.ToArray();
                    var extension = Path.GetExtension(placePhotoscreation.Photo.FileName);

                    placePhotos.Photo = await fileStorage.SaveFile(content, extension, container, placePhotoscreation.Photo.ContentType);
                }
            }

            if (placePhotos == null)
            {
                return NotFound();
            }

            await _context.PlacesPhotos.AddAsync(placePhotos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlacePhotos", new { id = placePhotos.PlacePhotosID }, placePhotos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PlacePhotos placePhotos)
        {
            if (id != placePhotos.PlacePhotosID)
            {
                return BadRequest();
            }

            _context.Entry(placePhotos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacePhotosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlacePhotos>> Delete(int id)
        {
            var placePhotos = await _context.PlacesPhotos.FindAsync(id);
            if (placePhotos == null)
            {
                return NotFound();
            }

            _context.PlacesPhotos.Remove(placePhotos);
            await _context.SaveChangesAsync();

            return placePhotos;
        }

        private bool PlacePhotosExists(int id)
        {
            return _context.PlacesPhotos.Any(e => e.PlacePhotosID == id);
        }
    }
}

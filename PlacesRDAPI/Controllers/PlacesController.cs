﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesRDAPI.Context;
using PlacesRDAPI.DTOs;
using PlacesRDAPI.Models;

namespace PlacesRDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PlacesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlaceDTO>>> Get()
        {
            var place = await context.Places.Include(x => x.Province).ToListAsync();

            var placeDTO = mapper.Map<List<PlaceDTO>>(place);
            return placeDTO;
        }

        [HttpGet("{id:int}", Name = "GetPlace")]
        public async Task<ActionResult<PlaceDTO>> Get(int id)
        {
            var place = await context.Places.Include(x => x.Province).FirstOrDefaultAsync(x => x.PlaceID == id);
            var placeDTO = mapper.Map<PlaceDTO>(place);
            if (place == null)
            {
                return NotFound();
            }

            return placeDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlaceCreation placeCreation)
        {

            var place = mapper.Map<Place>(placeCreation);
            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();
            var placeDTO = mapper.Map<PlaceDTO>(place);

            return new CreatedAtRouteResult("GetPlace", new { id = place.PlaceID }, placeDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] PlaceCreation placeCreation, int id)
        {
            var place = mapper.Map<Place>(placeCreation);
            place.PlaceID = id;

            if (place == null)
            {
                return NotFound();
            }

            context.Entry(place).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var place = await context.Places.AnyAsync(x => x.PlaceID == id);

            if(!place)
            {
                return NotFound();
            }

            context.Places.Remove(new Place(){PlaceID = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
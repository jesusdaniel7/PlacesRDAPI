using System;
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
    public class ProvincesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProvincesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvinceDTO>>> Get()
        {
            var province = await context.Provinces.Include(x => x.Place).ToListAsync();
            var provinceDTO = mapper.Map<List<ProvinceDTO>>(province);

            return provinceDTO;
        }

        [HttpGet("{id:int}", Name = "GetProvince")]
        public async Task<ActionResult<ProvinceDTO>> Get(int id)
        {
            var place = await context.Provinces.FirstOrDefaultAsync(x => x.ProvinceID == id);
            if (place == null)
            {
                return NotFound();
            }

            var placeDTO = mapper.Map<ProvinceDTO>(place);
            return placeDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProvinceCreation provinceCreation)
        {
            if (provinceCreation == null)
            {
                return NotFound();
            }

            var province = mapper.Map<Province>(provinceCreation);
            await context.Provinces.AddAsync(province);
            await context.SaveChangesAsync();

            var provinceDTO = mapper.Map<ProvinceDTO>(province);
            return new CreatedAtRouteResult("GetProvince", new { id = province.ProvinceID }, provinceDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProvinceCreation provinceCreation)
        {
            var province = mapper.Map<Province>(provinceCreation);
            province.ProvinceID = id;

            context.Entry(province).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var provinceDTO = mapper.Map<ProvinceDTO>(province);
            return new CreatedAtRouteResult("GetProvince", new { id = provinceDTO.ProvinceID}, provinceDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var province = await context.Provinces.AnyAsync(x => x.ProvinceID == id);
            if(!province)
            {
                return NotFound();
            }

            context.Provinces.Remove(new Province { ProvinceID = id});
            await context.SaveChangesAsync();
            var provinceDTO = mapper.Map<ProvinceDTO>(new Province { ProvinceID = id});
            return new CreatedAtRouteResult("GetProvince", new { id = provinceDTO.ProvinceID }, provinceDTO);
        }

    }
}
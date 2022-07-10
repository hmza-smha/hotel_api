using hotel_api.Models;
using hotel_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        [HttpGet]
        public async Task<ActionResult<List<Amenity>>> GetAmenities()
        {
            return Ok(await _amenity.GetAmenities());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            return Ok(await _amenity.GetAmenity(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            try
            {
                Amenity modifiedAmenity = await _amenity.Update(id, amenity);
                return Ok(modifiedAmenity);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Amenity>> CreateHotel(Amenity amenity)
        {
            try
            {
                Amenity newAmenity = await _amenity.Create(amenity);
                return Ok(newAmenity);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            try
            {
                await _amenity.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}

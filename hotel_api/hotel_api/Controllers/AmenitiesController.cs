using hotel_api.DTOs;
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
        public async Task<ActionResult<List<GetAmenityDTO>>> GetAmenities()
        {
            return Ok(await _amenity.GetAmenities());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAmenityDTO>> GetAmenity(int id)
        {
            try
            {
                return Ok(await _amenity.GetAmenity(id));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("{id}/Rooms/{hotelId}")]
        public async Task<ActionResult<GetAmenityDTO>> GetRooms(int id, int hotelId)
        {
            return Ok(await _amenity.GetRooms(id, hotelId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmenity(int id, CreateAmenityDTO amenity)
        {
            try
            {
                CreateAmenityDTO modifiedAmenity = await _amenity.Update(id, amenity);
                return Ok(modifiedAmenity);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetAmenityDTO>> CreateHotel(CreateAmenityDTO amenity)
        {
            try
            {
                CreateAmenityDTO newAmenity = await _amenity.Create(amenity);
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

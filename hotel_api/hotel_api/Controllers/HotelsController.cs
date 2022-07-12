using hotel_api.DTOs;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetHotelDTO>>> GetHotels()
        {
            return Ok(await _hotel.GetHotels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelDTO>> GetHotel(int id)
        {
            return Ok(await _hotel.GetHotel(id));
        }

        [HttpGet("{id}/AvailableRooms")]
        public async Task<ActionResult<GetRoomDTO>> GetAvailableRooms(int id)
        {
            return Ok(await _hotel.GetAvailable(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, CreateHotelDTO hotel)
        {
            //if (id != hotel.Id)
            //{
            //    return BadRequest();
            //}

            try
            {
                CreateHotelDTO modifiedHotel = await _hotel.Update(id, hotel);
                return Ok(modifiedHotel);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateHotelDTO>> CreateHotel(CreateHotelDTO hotel)
        {
            try
            {
                CreateHotelDTO newHotel = await _hotel.Create(hotel);
                return Ok(newHotel);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotel.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}

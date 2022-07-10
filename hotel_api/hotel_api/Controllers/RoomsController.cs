using hotel_api.Models;
using hotel_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        [HttpGet("{roomNumber}/Hotel/{hotelId}")]
        public async Task<ActionResult<Room>> GetRoom(int roomNumber, int hotelId)
        {
            return Ok(await _room.GetRoom(roomNumber, hotelId));
        }

        [HttpPut("{roomNumber}/Hotel/{hotelId}")]
        public async Task<IActionResult> UpdateRoom(int roomNumber, int hotelId, Room room)
        {
            if (hotelId != room.HotelId && roomNumber != room.RoomNumber)
            {
                return BadRequest();
            }
            try
            {
                var modifiedHotel = await _room.Update(hotelId, roomNumber, room);
                return Ok(modifiedHotel);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            try
            {
                Room newRoom = await _room.Create(room);
                return Ok(newRoom);
            }
            catch( Exception e)
            {
                return Content(e.Message );
            }
        }

        [HttpDelete("{roomNumber}/Hotel/{hotelId}")]
        public async Task<IActionResult> DeleteRoom(int roomNumber, int hotelId)
        {
            try
            {
                await _room.Delete(roomNumber, hotelId);
                return NoContent();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}

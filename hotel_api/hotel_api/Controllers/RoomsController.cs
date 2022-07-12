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

        [HttpGet("{hotelId}")]
        public async Task<ActionResult<List<Room>>> GetRooms(int hotelId)
        {
            return Ok(await _room.GetRooms(hotelId));
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

        [HttpPost("{roomNumber}/Hotel/{hotelId}/Amenity/{amenityId}")]
        public async Task<ActionResult> AddAmenityToRoom(int roomNumber, int hotelId, int amenityId)
        {
            try
            {
                await _room.AddAmenityToRoom(roomNumber, hotelId, amenityId);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpDelete("{roomNumber}/Hotel/{hotelId}/Amenity/{amenityId}")]
        public async Task<ActionResult> RemoveAmenityFromRoom(int roomNumber, int hotelId, int amenityId)
        {
            try
            {
                await _room.RemoveAmenityFromRoom(roomNumber, hotelId, amenityId);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(e.Message);
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

        [HttpPut("{roomNumber}/{hotelId}/Customer/{customerUsername}")]
        public async Task BookRoom(int roomNumber, int hotelId, string customerUsername)
        {
            await _room.BookRoom(roomNumber, hotelId, customerUsername);
        }

        [HttpPut("{roomNumber}/{hotelId}")]
        public async Task RemoveBook(int roomNumber, int hotelId)
        {
            await _room.RemoveBook(roomNumber, hotelId);
        }
    }
}

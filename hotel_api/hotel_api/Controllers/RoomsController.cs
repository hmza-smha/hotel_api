using hotel_api.DTOs;
using hotel_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


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
        public async Task<ActionResult<List<GetRoomDTO>>> GetRooms(int hotelId)
        {
            return Ok(await _room.GetRooms(hotelId));
        }

        [HttpGet("{roomNumber}/Hotel/{hotelId}")]
        public async Task<ActionResult<GetRoomDTO>> GetRoom(int roomNumber, int hotelId)
        {
            try
            {
                return Ok(await _room.GetRoom(roomNumber, hotelId));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }

        [HttpPut("{roomNumber}/Hotel/{hotelId}")]
        public async Task<IActionResult> UpdateRoom(int roomNumber, int hotelId, PutRoomDTO room)
        {
            if (roomNumber != room.RoomNumber)
            {
                return BadRequest();
            }
            try
            {
                var modifiedHotel = await _room.Update(roomNumber, hotelId, room);
                return Ok(modifiedHotel);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<CreateRoomDTO>> CreateRoom(CreateRoomDTO room)
        {
            try
            {
                CreateRoomDTO newRoom = await _room.Create(room);
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
                await _room.RemoveAmenityFromRoom(hotelId, roomNumber,  amenityId);
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

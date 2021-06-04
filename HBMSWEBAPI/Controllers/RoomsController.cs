using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;

namespace HBMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly HBMSDbContext _context;

        public RoomsController(HBMSDbContext context)
        {
            _context = context;
        }





        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return await _context.Room.Include(e => e.Hotel).Include(e => e.RoomType).ToListAsync();
        }





        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {

            var room = await _context.Room.Include(e => e.Hotel).Include(e => e.RoomType).ToListAsync();
           
            var ro = room.Find(r => r.RoomNo == id);

            if (room == null)
            {
                return NotFound();
            }

            return ro;
        }






        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            Room obj = _context.Room.Find(id);
            obj.RoomTypeId = room.RoomTypeId;
            obj.HotelId = room.HotelId;
            obj.RatePerNight = room.RatePerNight;
            obj.Capacity = room.Capacity;


            _context.Room.Update(obj);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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





        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomNo }, room);
        }





        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }



        //roomexits
        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomNo == id);
        }
    }
}

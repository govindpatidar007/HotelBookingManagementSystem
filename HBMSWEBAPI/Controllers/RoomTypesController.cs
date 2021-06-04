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
    public class RoomTypesController : ControllerBase
    {
        private readonly HBMSDbContext _context;

        public RoomTypesController(HBMSDbContext context)
        {
            _context = context;
        }




        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomType()
        {
            return await _context.RoomType.ToListAsync();
        }




        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
            var roomType = await _context.RoomType.FindAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            return roomType;
        }





        // PUT: api/RoomTypes/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomType(int id, RoomType roomType)
        {
            RoomType obj = _context.RoomType.Find(id);
            obj.RoomTypes = roomType.RoomTypes;
            _context.RoomType.Update(obj);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {


                return NotFound();

            }

            return NoContent();
        }





        // POST: api/RoomTypes
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
        {
            _context.RoomType.Add(roomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomType", new { id = roomType.RoomTypeId }, roomType);
        }




        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomType>> DeleteRoomType(int id)
        {
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomType.Remove(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }




        //searchhotel
        [HttpGet("search/{criteria}")]
        public async Task<IEnumerable<RoomType>> getsearch(string criteria)
        {
            IEnumerable<RoomType> list = null;

            criteria = criteria.ToLower();
            list = await _context.RoomType.Where
                (e => e.RoomTypes.ToLower().Contains(criteria)).ToListAsync();


            return list;
        }





        private bool RoomTypeExists(int id)
        {
            return _context.RoomType.Any(e => e.RoomTypeId == id);
        }
    }
}

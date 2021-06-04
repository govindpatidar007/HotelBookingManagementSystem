using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBMS.Models.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;


namespace HBMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly HBMSDbContext _context;

        public BookingDetailsController(HBMSDbContext context)
        {
            _context = context;
        }
        
       


        //View Room
        [HttpGet("viewroom/{id}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetViewRoom(int id)
        {
            return await _context.Room.Include(e => e.Hotel).Where(e => e.HotelId == id).Include(e => e.RoomType).ToListAsync();
        }





        //Room Details
        [HttpGet("getroomdetails/{id}")]
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





     
        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetail()
        {
           
            return await _context.BookingDetail.Include(e=>e.Hotel).Include(e => e.Room).ToListAsync();
        }






        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(int id)
        {
            var bookingDetail = await _context.BookingDetail.Include(e => e.Hotel).Include(e => e.Room).ToListAsync();
            var bd = bookingDetail.Find(r => r.BookingId == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return bd;
        }





        // PUT: api/BookingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetail(int id, BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(id))
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






        // POST: api/BookingDetails
       [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail bookingDetail)
        {
            _context.BookingDetail.Add(bookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetail", new { id = bookingDetail.BookingId }, bookingDetail);
        }
     






        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDetail>> DeleteBookingDetail(int id)
        {
            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            _context.BookingDetail.Remove(bookingDetail);
            await _context.SaveChangesAsync();

            return bookingDetail;
        }





        //checksbookings
        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetail.Any(e => e.BookingId == id);
        }





        //searchhotelbycity
        [HttpGet("search/{criteria}")]
        public async Task<IEnumerable<Hotel>> searchotel(string criteria)
        {
            IEnumerable<Hotel> list = null;
            if (int.TryParse(criteria, out int cityid))
            {
                list = await _context.Hotel.Include(e => e.City).Where(e => e.CityId == cityid).ToListAsync();
            }
            else
            {
                criteria = criteria.ToLower();
                list = await _context.Hotel.Include(e => e.City)
                    .Where(e => e.City.CityName.ToLower().Contains(criteria)
                    || e.Email.ToLower().Contains(criteria)
                    || e.HotelName.ToLower().Contains(criteria)).ToListAsync();


            }

            return list;
        }

    }
}

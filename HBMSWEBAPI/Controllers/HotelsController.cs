using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBMS.Models.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;

namespace HBMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin")]
    public class HotelsController : ControllerBase
    {
        private readonly HBMSDbContext _context;

        public HotelsController(HBMSDbContext context)
        {
            _context = context;
        }




        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return await _context.Hotel.Include(e => e.City).ToListAsync();

        }




        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotel.Include(e => e.City).ToListAsync();

            var hot = hotel.Find(r => r.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return hot;
        }




        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            Hotel obj = _context.Hotel.Find(id);
            obj.HotelName = hotel.HotelName;
            obj.Description = hotel.Description;
            obj.Phone = hotel.Phone;
            obj.Email = hotel.Email;
            obj.AvgRatePerNight = hotel.AvgRatePerNight;
            obj.CityId = hotel.CityId;


            _context.Hotel.Update(obj);

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




        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }




        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }




        //checkshotels
        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.HotelId == id);
        }






        //searchhotelbycity
        [HttpGet("search/{criteria}")]
        public async Task<IEnumerable<Hotel>> getsearch(string criteria)
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





        //searchhotelbyhotelbyid
        [HttpGet("hotelbycityid/{cityId}")]
        public async Task<IEnumerable<Hotel>> hotelbycityid(int cityId)
        {


            IEnumerable<Hotel> li = _context.Hotel.Include(e => e.City).ToList();
            IEnumerable<Hotel> List = li
                .Where(e => e.CityId == cityId).ToList();
            return List;

        }





        ////admin can see alll bookings
        //// GET: api/BookingDetails
        [HttpGet("bookingdetails/{id}")]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetail(int id)
        {
            return await _context.BookingDetail.Include(e => e.Hotel).Where(e => e.HotelId==id).Include(e => e.Room).ToListAsync();
        }



    }
}

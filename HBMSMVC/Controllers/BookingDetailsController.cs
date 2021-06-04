using MODELS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using HBMS.Models.models;
using System.Text;

namespace HBMS.MVC.Controllers
{
    public class BookingDetailsController : Controller
    {
        private IHttpClientFactory clientFactory;
        private string apiUrl = "https://localhost:44362/api/";

        public BookingDetailsController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }




        //Customer
        // GET: Hotels
        public async Task<ActionResult> FindHotels()
        {
            IEnumerable<Hotel> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);

                    var response = await client.GetAsync("hotels");


                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Hotel>>(content);
                        return View(list);
                    }
                    else
                    {
                        list = Enumerable.Empty<Hotel>();
                        ModelState.AddModelError(string.Empty, "Empty List");

                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<Hotel>();
                ModelState.AddModelError(string.Empty, "Server error");

            }
            return View(list);
        }






        //Customer
        //Hotel Details
        // GET: Hotels/Details/5
        public async Task<ActionResult> HotelDetails(int id)
        {

            Hotel hotel = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"hotels/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        hotel = JsonConvert.DeserializeObject<Hotel>(content);

                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Server error.");
            }
            return View(hotel);

        }





        //Customer
        //List of Rooms
        // 

        public async Task<ActionResult> ViewRooms(int id)
        {
            IEnumerable<Room> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);

                    var response = await client.GetAsync($"bookingdetails/viewroom/{id}");


                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Room>>(content);
                        return View(list);
                    }
                    else
                    {
                        list = Enumerable.Empty<Room>();
                        ModelState.AddModelError(string.Empty, "Empty List");

                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<Room>();
                ModelState.AddModelError(string.Empty, "Server error");

            }
            return View(list);
        }







        // GET: RoomsController/Details/5
        public async Task<ActionResult> RoomDetails(int id)
        {

            Room room = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"bookingdetails/getroomdetails/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        room = JsonConvert.DeserializeObject<Room>(content);

                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Server error.");
            }
            return View(room);


        }




         // GET: BookingDetailsController
        public async Task<ActionResult> IndexAsync()
        {
            IEnumerable<BookingDetail> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("BookingDetails");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<BookingDetail>>(content);
                        return View(list);
                    }
                    else
                    {
                        list = Enumerable.Empty<BookingDetail>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<BookingDetail>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }

            return View(list);
           
        }





        // GET: BookingDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      




        // POST: BookingDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }






       // / GET: RoomsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            IEnumerable<BookingDetail> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("bookingdetails");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<BookingDetail>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<BookingDetail>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<BookingDetail>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            var li = list.ToList();
            var emp = li.Find(r => r.BookingId == id);
            if (emp != null)
            {
                return View(emp);
            }
            //return View(emp);
            return RedirectToAction(nameof(Index));
        }







        // POST: RoomsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, BookingDetail bookingdetail)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.DeleteAsync($"bookingdetails/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Booking Successfully deleted ";

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Server error.");
            }
            return RedirectToAction(nameof(Index));
        }





        

        // GET: BookingDetailController/Create
        public async Task<ActionResult> Create()
        {
            //list of hotels
            IEnumerable<Hotel> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("hotels");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Hotel>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<Hotel>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<Hotel>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            ViewBag.HotelID = new SelectList(list, "HotelId", "HotelName", "");//
            //list of rooms

            IEnumerable<Room> list1 = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("rooms");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list1 = JsonConvert.DeserializeObject<List<Room>>(content);

                    }
                    else
                    {
                        list1 = Enumerable.Empty<Room>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list1 = Enumerable.Empty<Room>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }



            ViewBag.RoomID = new SelectList(list1, "RoomNo", "RoomType.RoomTypes", "");// "RoomTypes",
            var bookingdetails = new BookingDetail();
            return View(bookingdetails);
        }






        // POST: BookingDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingDetail bookingdetail)
        {

             try
                {


                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(bookingdetail);
                    var response = await client.PostAsync("BookingDetails",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                    
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "  Room Booked Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error");
                        return View(bookingdetail);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(bookingdetail);
            }

        }




        //searchhotels
        [HttpPost]
        public async Task<ActionResult> FindHotels(string criteria)
        {
            IEnumerable<Hotel> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"bookingdetails/search/{criteria}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Hotel>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<Hotel>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<Hotel>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }


            ViewData["criteria"] = criteria;

            return View(list);
        }



    }   

}
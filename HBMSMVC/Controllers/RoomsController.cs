using MODELS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HBMS.MVC.Controllers
{
    public class RoomsController : Controller
    {
        private IHttpClientFactory clientFactory;
        private string apiUrl = "https://localhost:44362/api/";

        public RoomsController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }




        // GET: RoomsController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Room> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);

                    var response = await client.GetAsync("rooms");


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
        public async Task<ActionResult> Details(int id)
        {

            Room room = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"rooms/{id}");
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







        // GET: RoomsController/Create
        public async Task<ActionResult> Create()
        {
            //list of cities
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
            ViewBag.HotelID = new SelectList(list, "HotelId", "HotelName", "");
            //list of roomtypes

            IEnumerable<RoomType> list1 = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("roomtypes");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list1 = JsonConvert.DeserializeObject<List<RoomType>>(content);

                    }
                    else
                    {
                        list1 = Enumerable.Empty<RoomType>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list1 = Enumerable.Empty<RoomType>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }



            ViewBag.RoomID = new SelectList(list1, "RoomTypeId", "RoomTypes", "");
            return View();
        }







        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Room room)
        {
            //list of cities
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
            ViewBag.HotelID = new SelectList(list, "HotelId", "HotelName", "");
            //list of roomtypes

            IEnumerable<RoomType> list1 = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("roomtypes");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list1 = JsonConvert.DeserializeObject<List<RoomType>>(content);

                    }
                    else
                    {
                        list1 = Enumerable.Empty<RoomType>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list1 = Enumerable.Empty<RoomType>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }



            ViewBag.RoomID = new SelectList(list1, "RoomTypeId", "RoomTypes", "");

            ///////
            ///

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(room);
                    var response = await client.PostAsync("rooms",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                   
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Created Room";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error");
                        return View(room);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(room);
            }


        }







        // GET: RoomsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            

            //list of cities
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
            ViewBag.HotelID = new SelectList(list, "HotelId", "HotelName", "");
            //list of roomtypes

            IEnumerable<RoomType> list1 = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("roomtypes");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list1 = JsonConvert.DeserializeObject<List<RoomType>>(content);

                    }
                    else
                    {
                        list1 = Enumerable.Empty<RoomType>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list1 = Enumerable.Empty<RoomType>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }



            ViewBag.RoomID = new SelectList(list1, "RoomTypeId", "RoomTypes", "");


            ///

            Room room = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"rooms/{id}");
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

        





        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Room room)
        {

            //list of cities
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
            ViewBag.HotelID = new SelectList(list, "HotelId", "HotelName", "");
            //list of roomtypes

            IEnumerable<RoomType> list1 = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("roomtypes");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list1 = JsonConvert.DeserializeObject<List<RoomType>>(content);

                    }
                    else
                    {
                        list1 = Enumerable.Empty<RoomType>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list1 = Enumerable.Empty<RoomType>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }



            ViewBag.RoomID = new SelectList(list1, "RoomTypeId", "RoomTypes", "");


            ///

            //
            if (!ModelState.IsValid)
            {
                return View(room);
            }

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(room);
                    var response = await client.PutAsync($"rooms/{id}",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Updated Room";



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
                return View(room);
            }


            return View(room);

        }





        // GET: RoomsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            IEnumerable<Room> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("rooms");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Room>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<Room>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<Room>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            var li = list.ToList();
            var emp = li.Find(r => r.RoomNo == id);
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
        public async Task<ActionResult> Delete(int id, Room room)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.DeleteAsync($"rooms/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully deleted Room";

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
    }
}

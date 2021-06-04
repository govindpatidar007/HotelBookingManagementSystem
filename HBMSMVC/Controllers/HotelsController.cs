using HBMS.Models.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MODELS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HBMSMVC.Controllers
{
    public class HotelsController : Controller
    {


        private IHttpClientFactory clientFactory;
        private string apiUrl = "https://localhost:44362/api/";

        public HotelsController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }






        //searchspecificbooking
        public async Task<ActionResult> SpecificHotelBookings(int id)
        {
            IEnumerable<BookingDetail> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"hotels/bookingdetails/{id}");
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








        // GET: HotelsController
        public async Task<ActionResult> Index()
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






        // GET: HotelsController/Details/5
        public async Task<ActionResult> Details(int id)
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






        // GET: HotelsController/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<City> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            ViewBag.CityID = new SelectList(list, "CityId", "CityName", "");
            return View();
        }







        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            IEnumerable<City> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            ViewBag.CityID = new SelectList(list, "CityId", "CityName", "");


            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(hotel);
                    var response = await client.PostAsync("hotels",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Created hotel";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error");
                        return View(hotel);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(hotel);
            }
        }
     
       



        // GET: HotelsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IEnumerable<City> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            ViewBag.CityID = new SelectList(list, "CityId", "CityName", "");
            ///


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






        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Hotel hotel)
        {

            IEnumerable<City> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }
            ViewBag.CityID = new SelectList(list, "CityId", "CityName", "");

            //


            //
            if (!ModelState.IsValid)
            {
                return View(hotel);
            }

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(hotel);
                    var response = await client.PutAsync($"hotels/{id}",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Updated Hotel";



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
                return View(hotel);
            }


            return View(hotel);



        }





        // GET: HotelsController/Delete/5
        public async Task<ActionResult> Delete(int id)
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
            var li = list.ToList();
            var emp = li.Find(r => r.HotelId == id);
            if (emp != null)
            {
                return View(emp);
            }
            //return View(emp);
            return RedirectToAction(nameof(Index));

        }






        // POST: HotelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.DeleteAsync($"hotels/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully deleted Hotel";

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





        //index

        [HttpPost]
        public async Task<ActionResult> Index(string criteria)
        {
            IEnumerable<Hotel> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"hotels/search/{criteria}");
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






        //get hotelsbycity
        public async Task<ActionResult> HotelsByCity()
        {
            IEnumerable<City> list = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");


            }
            ViewBag.City = new SelectList(list, "CityId", "CityName", "");
            return View();
        }





        //post/hotelbycity

        [HttpPost]
        public async Task<ActionResult> HotelsByCity(int cityId)
        {
            IEnumerable<City> clist = null;

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync("cities");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        clist = JsonConvert.DeserializeObject<List<City>>(content);

                    }
                    else
                    {
                        clist = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            catch (Exception ex)
            {
                clist = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error.");


            }
            ViewBag.City = new SelectList(clist, "CityId", "CityName", "");

            ///


            IEnumerable<Hotel> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"hotels/hotelbycityid/{cityId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Hotel>>(content);
                        return View(list);
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

            return View(list);

        }


      
      

       
    }
}

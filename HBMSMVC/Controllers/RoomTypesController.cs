using MODELS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HBMS.MVC.Controllers
{
    public class RoomTypesController : Controller
    {

        private IHttpClientFactory clientFactory;
        private string apiUrl = "https://localhost:44362/api/";

        public RoomTypesController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }




        // GET: RoomTypesController
        public async Task<ActionResult> Index()
        {
            IEnumerable<RoomType> list = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);

                    var response = await client.GetAsync("roomtypes");


                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<RoomType>>(content);
                        return View(list);
                    }
                    else
                    {
                        list = Enumerable.Empty<RoomType>();
                        ModelState.AddModelError(string.Empty, "Empty List");
                        ViewBag.msg = "empty list";
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<RoomType>();
                ModelState.AddModelError(string.Empty, "Server error");
                ViewBag.msg = "Server error";
            }
            return View(list);
        }






        // GET: RoomTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            RoomType roomtype = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"roomtypes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        roomtype = JsonConvert.DeserializeObject<RoomType>(content);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            if (roomtype == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(roomtype);
        }




        // GET: RoomTypesController/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: RoomTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoomType roomType)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(roomType);
                    var response = await client.PostAsync("roomtypes",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Created  New Room Category";
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                        return View(roomType);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(roomType);
            }
        }




        // GET: RoomTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            RoomType type = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"roomtypes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        type = JsonConvert.DeserializeObject<RoomType>(content);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            if (type == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(type);
        }






        // POST: RoomTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RoomType roomType)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(roomType);
                    var response = await client.PutAsync($"roomtypes/{id}",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Updated  Room Category";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error");
                    }
                }

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(roomType);
            }
            return View(roomType);
        }






        // GET: RoomTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            RoomType type = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"roomtypes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        type = JsonConvert.DeserializeObject<RoomType>(content);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            if (type == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(type);
        }






        // POST: RoomTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, RoomType type)
        {

            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.DeleteAsync($"roomtypes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Deleted Room Category";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                    }

                }


            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Server Error");
                return View(type);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

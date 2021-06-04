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
    public class CitiesController : Controller
    {
        private IHttpClientFactory clientFactory;
        private string apiUrl = "https://localhost:44362/api/";

        public CitiesController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }



        // GET: CitiesController
        public async Task<ActionResult> Index()
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
                        return View(list);
                    }
                    else
                    {
                        list = Enumerable.Empty<City>();
                        ModelState.AddModelError(string.Empty, "Empty List");
                        ViewBag.msg = "empty list";
                    }
                }
            }
            catch (Exception ex)
            {
                list = Enumerable.Empty<City>();
                ModelState.AddModelError(string.Empty, "Server error");
                ViewBag.msg = "Server error";
            }
            return View(list);
        }




        // GET: CitiesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            City city = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"cities/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        city = JsonConvert.DeserializeObject<City>(content);
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
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);


        }



        // GET: CitiesController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: CitiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(City city)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(city);
                    var response = await client.PostAsync("cities",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Created City";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error");
                        return View(city);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error");
                return View(city);
            }
        }





        // GET: CitiesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            City city = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"cities/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        city = JsonConvert.DeserializeObject<City>(content);
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
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }





        // POST: CitiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, City city)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    string empjon = JsonConvert.SerializeObject(city);
                    var response = await client.PutAsync($"cities/{id}",
                        new StringContent(empjon, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Updated City";
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
                return View(city);
            }
            return View(city);



        }






        // GET: CitiesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            City city = null;
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.GetAsync($"cities/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        city = JsonConvert.DeserializeObject<City>(content);
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
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }






        // POST: CitiesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, City city)
        {
            try
            {
                using (var client = clientFactory.CreateClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = await client.DeleteAsync($"cities/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        @TempData["Message"] = "Successfully Deleted City";
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
                return View(city);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

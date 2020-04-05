using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleForm.BLL;

namespace SimpleForm.Web2.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368");
                var response = await client.GetAsync("api/forms");
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest("Something went wrong!");
                }
                var data = await response.Content.ReadAsStringAsync();
                var forms = JsonConvert.DeserializeObject<IEnumerable<Form>>(data);
                if(forms != null)
                {
                    return View();
                }
                return BadRequest("Something went wrong!");
            }
        }

        // GET: Forms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Forms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var user = new User();
                user.FirstName = "Kamil";
                user.LastName = "Rozanski";
                user.Email = "email@email.com";

                var form = new Form();
                form.Title = collection["Title"];
                form.Body = collection["Body"];

                form.Sender = user;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44368");
                    var formJson = JsonConvert.SerializeObject(form);
                    var content = new StringContent(formJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/forms", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest("Something went wrong!");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Forms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    public class PhonesController : Controller
    {
        static readonly List<Phone> data;
        static PhonesController()
        {
            data = new List<Phone>
            {
                new Phone { Id = Guid.NewGuid().ToString(), Name="Привет", Price=123 },
                new Phone { Id = Guid.NewGuid().ToString(), Name="Как дела?", Price=456 },
            };
        }
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post(Phone phone)
        {
            phone.Id = Guid.NewGuid().ToString();
            data.Add(phone);
            return Ok(phone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Phone phone = data.FirstOrDefault(x => x.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            data.Remove(phone);
            return Ok(phone);
        }
    }
}
using Inshat.Data;
using Inshat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly DbContextConfig _db;
        public ContactUsController(DbContextConfig db)
        {
            _db = db;
        }
        public  IActionResult Index()
        {
            var aboutUs = _db.ContactUs.FirstOrDefault() ??new ContactUs();
            return View(aboutUs);
        }
        public IActionResult Update()
        {
            var aboutUs = _db.ContactUs.FirstOrDefault() ?? new ContactUs() ;
            return View(aboutUs);
        }

        [HttpPost]
        public IActionResult Update(ContactUs contactUs)
        {
            if (contactUs.Id > 0)
                _db.ContactUs.Update(contactUs);
            else
                _db.ContactUs.Add(contactUs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

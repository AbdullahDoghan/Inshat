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
            var aboutUs = _db.ContactUs.FirstOrDefault();
            return View(aboutUs);
        }
        public IActionResult Update()
        {
            var aboutUs = _db.ContactUs.FirstOrDefault();
            return View(aboutUs);
        }

        [HttpPost]
        public IActionResult Update(ContactUs contactUs)
        {
            var contactus = _db.ContactUs.FirstOrDefault();
            contactus.Email = contactUs.Email;
            contactus.PhoneNumber = contactUs.PhoneNumber;
            contactus.Facebook = contactUs.Facebook;
            contactus.Instagram = contactUs.Instagram;
            contactus.Twitter = contactUs.Twitter;
            contactus.YouTube = contactUs.YouTube;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

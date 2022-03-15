using Inshat.Data;
using Inshat.Data.ManagingFiles;
using Inshat.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly DbContextConfig _db;
        private readonly IManagingFile _FileManaging;
   
        public AboutUsController(DbContextConfig db, IManagingFile FileManaging)
        {
            _db = db;
            _FileManaging = FileManaging;
        }
        public async Task<IActionResult> Index()
        {
            var aboutUs = await _db.AboutUs.FirstOrDefaultAsync();
            return View(aboutUs);
        }

        public IActionResult Update()
        {
            var aboutUs = _db.AboutUs.FirstOrDefault();
            return View(aboutUs);
        }
        [HttpPost]
        public IActionResult Update(AboutUs aboutUs, IFormFile file)
        {
            var about = _db.AboutUs.FirstOrDefault();
            about.Title = aboutUs.Title;
            about.Description = aboutUs.Description;
            if (file !=null)
            {
                var image = _FileManaging.SavingImage("AboutUs", file);
                _FileManaging.DeleteImage("AboutUs", about.Image);
                about.Image = image ?? about.Image;
            }
             _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

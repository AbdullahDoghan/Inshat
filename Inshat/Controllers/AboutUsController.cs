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
            var aboutUs = await _db.AboutUs.FirstOrDefaultAsync() ?? new AboutUs();
            return View(aboutUs);
        }

        public IActionResult Update()
        {
            var aboutUs = _db.AboutUs.FirstOrDefault() ?? new AboutUs();
            return View(aboutUs);
        }
        [HttpPost]
        public IActionResult Update(AboutUs aboutUs, IFormFile file)
        {
            if (aboutUs.Id > 0)
            {
                _db.AboutUs.Update(aboutUs);
                var image = _FileManaging.SavingImage("AboutUs", file);
                _FileManaging.DeleteImage("AboutUs", aboutUs.Image);
                aboutUs.Image = image ?? aboutUs.Image;
            }
            else
            {
                _db.AboutUs.Add(aboutUs);
                var image = _FileManaging.SavingImage("AboutUs", file);
                aboutUs.Image = image;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

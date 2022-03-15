using Inshat.Data.ManagingFiles;
using Inshat.Data.Services;
using Inshat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IManagingFile _FileManaging;
        private readonly IBlogService _service;
        public BlogsController(IBlogService service, IManagingFile FileManaging)
        {
            _service = service;
            _FileManaging = FileManaging;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _service.GetAllAsync();
            if (blogs == null)
            {
                return View("NotFound");
            }
            return View(blogs);
        }
        public  IActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            if (file != null)
            {
                var image = _FileManaging.SavingImage("Blog", file);
                blog.Image = image;
            }
            await _service.CreateAsync(blog);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var blog =await _service.GetByIdAsync(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Blog blog, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            if (file != null)
            {
                var image = _FileManaging.SavingImage("Blog", file);
                _FileManaging.DeleteImage("Blog", blog.Image);
                blog.Image = image ?? blog.Image;
            }
            await _service.UpdateAsync(id, blog);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _service.GetByIdAsync(id);
            if (blog == null)
            {
                return View("Notfound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

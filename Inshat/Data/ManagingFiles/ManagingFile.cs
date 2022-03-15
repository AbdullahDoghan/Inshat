﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.ManagingFiles
{
    public class ManagingFile:IManagingFile
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ManagingFile(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string SavingImage(string ImageFolder, IFormFile file)
        {
            var ImageId = Guid.NewGuid();
            if (file != null)
            {
                string filename = file.FileName;
                string strpath = System.IO.Path.GetExtension(filename);
                var Upload = Path.Combine(_hostingEnvironment.WebRootPath, $"Uploads/{ImageFolder}/{ImageId}{strpath}");
                using (var stream = System.IO.File.Create(Upload))
                {
                     file.CopyTo(stream);
                }
            }
            return ImageId.ToString();
        }
        public bool DeleteImage(string ImageFolder, string FileName)
        {
            string strpath = System.IO.Path.GetExtension(FileName);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, $"Uploads/{ImageFolder}/{FileName}{strpath}");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return !File.Exists(filePath);
            }
            return false;

        }

    }
}

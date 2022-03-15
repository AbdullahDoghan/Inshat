using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.ManagingFiles
{
    public interface IManagingFile
    {
        public string SavingImage(string ImageFolder, IFormFile file);

        public bool DeleteImage(string ImageFolder, string FileName);
    }
}

using Inshat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data
{
    public class DbContextConfig:DbContext
    {
        public DbContextConfig(DbContextOptions<DbContextConfig> options) :base(options)
        {
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Blog> Blog { get; set; }


    }
}

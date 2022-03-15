using Inshat.Data.BaseServices;
using Inshat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.Services
{
    public class BlogService: BaseServic<Blog,int>, IBlogService
    {
        public BlogService(DbContextConfig Db) : base(Db)
        {

        }
    }
}

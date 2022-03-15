using Inshat.Data.BaseServices;
using Inshat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.Services
{
    public interface IBlogService: IBaseServices<Blog,int>
    {
    }
}

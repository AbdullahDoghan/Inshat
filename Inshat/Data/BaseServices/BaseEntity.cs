using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.BaseServices
{
    public interface BaseEntity<T>
    {
        public T Id { get; set; }
        

    }
}

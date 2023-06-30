using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PagedResult<T>
    {
        public IList<T> Items { get; set; }

        public int TotalItems { get; set; }
    }
}

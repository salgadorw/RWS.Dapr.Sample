using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PageSizeIsTooLongException: Exception
    {
        public override string Message => "The limit parameter cannot be higher than 10!";
    }
}

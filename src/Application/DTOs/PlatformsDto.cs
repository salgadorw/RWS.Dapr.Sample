using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{   
    public class PlatformsDto
    {
        public bool Windows { get; set; } = new bool();
        public bool Mac { get; set; } = new bool();
        public bool Linux { get; set; } = new bool();
    }
}

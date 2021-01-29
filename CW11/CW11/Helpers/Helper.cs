using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Helpers
{
    public class Helper
    {
        public string Message { get; set; }
        public Doctor Doctor { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public int status { get; set; }
    }
}

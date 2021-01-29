using Cw11.Helpers;
using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public interface IDoctorService
    {
        public Helper GetDoctors();
        public Helper AddDoctor(Doctor doctor);
        public Helper UpdateDoctor(Doctor doctor);
        public Helper DeleteDoctor(string LastName);
    }
}

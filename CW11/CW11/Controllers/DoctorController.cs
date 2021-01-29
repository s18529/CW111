using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cw11.Helpers;
using Cw11.Models;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;
        public DoctorController(IDoctorService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            Helper helper = service.GetDoctors();
            if (helper.status == 0)
            {
                return Ok(helper.Doctors);
            }
            return NotFound(helper.Message);
        }
        [HttpPut]
        public IActionResult AddDocotr(Doctor doctor)
        {
            Helper helper = service.AddDoctor(doctor);
            if (helper.status == 0)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return NotFound(helper.Message);
        }

        [HttpPut("update")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            Helper helper = service.UpdateDoctor(doctor);
            if (helper.status == 0)
            {
                return Ok(helper.Message);
            }
            return NotFound(helper.Message);
        }
        [HttpDelete("{LastName}")]
        public IActionResult DeleteDocotor(string LastName) 
        {
            Helper helper = service.DeleteDoctor(LastName);
            if (helper.status == 0)
            {
                return Ok(helper.Message);
            }
            return NotFound(helper.Message);
        }
    }
}

using Cw11.Helpers;
using Cw11.Models;
using CW11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly s18529Context context;
        public DoctorService(s18529Context _context)
        {
            context = _context;
        }
        public Helper AddDoctor(Doctor doctor)
        {
            try
            {
                Helper helper = new Helper();
                context.Add(doctor);
                helper.Message = "added";
                helper.Doctor = doctor;
                helper.status = 0;
                context.SaveChanges();
                return helper;
            }catch(Exception ex)
            {
                Helper helper = new Helper();
                helper.Message = ex.ToString();
                helper.status = -1;
                return helper;
            }
        }

        public Helper DeleteDoctor(string LastName)
        {
            try
            {
                Helper helper = new Helper();
                var doc = context.Doctors.Where(x => x.LastName == LastName).First();
                context.Doctors.Remove(doc);
                context.SaveChanges();
                helper.Message = "deleted";
                helper.status = 0;
                return helper;
            }catch(Exception ex)
            {
                Helper helper = new Helper();
                helper.Message = ex.ToString();
                helper.status = -1;
                return helper;
            }
        }

        public Helper GetDoctors()
        {
            try
            {
                Helper helper = new Helper();
                var result = context.Doctors.ToList();
                helper.Doctors = result;
                helper.status = 0;
                return helper;
            }catch(Exception ex)
            {
                Helper helper = new Helper();
                helper.Message = ex.ToString();
                helper.status = -1;
                return helper;
            }
        }

        public Helper UpdateDoctor(Doctor doctor)
        {
            try
            {
                Helper helper = new Helper();
                context.Doctors.Attach(doctor);
                context.Entry(doctor).State = EntityState.Modified;
                context.SaveChanges();
                helper.Message = "updated";
                helper.status = 0;
                return helper;
            }catch(Exception ex)
            {
                Helper helper = new Helper();
                helper.Message = ex.ToString();
                helper.status = -1;
                return helper;
            }
        }
    }
}

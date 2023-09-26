using CureWell.DAL;
using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Routing;

namespace CureWell.API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        //private ICureWellRepository cureWellRepository;

        //public HomeController(ICureWellRepository cureWellRepository)
        //{
        //    this.cureWellRepository = cureWellRepository;
        //}
        private ICureWellRepository cureWellRepository;
        public HomeController()
        {
            cureWellRepository = new CureWellRepositoryImpl();
        }

        [HttpGet]
        [Route("doctor")]
        public IHttpActionResult GetDoctors()
        {
            var response = cureWellRepository.GetAllDoctors();
            var result = new { error = false, data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("doctor/{doctorId}")]
        public IHttpActionResult GetDoctorById(int doctorId)
        {
            var response = cureWellRepository.GetDoctorById(doctorId);
            if (response == null)
            {
                var result = new { error = true, message = "No data found" };
                return Ok(result);
            }
                 
            else
            {
                var result = new { error = false, data = response };
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("specialization")]
        public IHttpActionResult GetSpecializations()
        {
            var response = cureWellRepository.GetAllSpecializations();
            var result = new { error = false, data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("surgery")]
        public IHttpActionResult GetAllSurgery()
        {
            var response = cureWellRepository.GetAllSurgeries();
            var result = new { error = false, data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("surgery/today")]
        public IHttpActionResult GetAllSurgeryTypeForToday()
        {
            var response = cureWellRepository.GetAllSurgeryTypeForToday();
            var result = new { error = false, data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("surgery/{surgeryId}")]
        public IHttpActionResult GetSurgeryById(int surgeryId)
        {
            var response = cureWellRepository.GetSurgeryById(surgeryId);
            if (response == null)
            {
                var result = new { error = true, message = "No data found" };
                return Ok(result);
            }

            else
            {
                var result = new { error = false, data = response };
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("specialization/{specializationCode}")]
        public IHttpActionResult GetDoctorsBySpecialization(string specializationCode)
        {
            var response = cureWellRepository.GetDoctorsBySpecialization(specializationCode);
            if (response == null)
            {
                var result = new { error = true, message = "No data found" };
                return Ok(result);
            }

            else
            {
                var result = new { error = false, data = response };
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("doctor")]
        public IHttpActionResult AddDoctor(Doctor dObj)
        {
            var response = cureWellRepository.AddDoctor(dObj);
            if(response==true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("doctor")]
        public IHttpActionResult UpdateDoctorDetails(Doctor dObj)
        {
            var response = cureWellRepository.UpdateDoctorDetails(dObj);
            if (response == true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("surgery")]
        public IHttpActionResult UpdateSurgery(Surgery sObj)
        {
            var response = cureWellRepository.UpdateSurgery(sObj);
            if (response == true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route("doctor")]
        public IHttpActionResult DeleteDoctor(int doctorId)
        {
            var response = cureWellRepository.DeleteDoctor(doctorId);
            if (response == true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("doctor/{doctorId}/details")]
        public IHttpActionResult GetDoctorDetails(int doctorId)
        {
            var response = cureWellRepository.GetDoctorDetails(doctorId);
            if (response == null)
            {
                var result = new { error = true, message = "No data found" };
                return Ok(result);
            }

            else
            {
                var result = new { error = false, data = response };
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("specialization")]
        public IHttpActionResult AddSpecialization(Specialization dObj)
        {
            var response = cureWellRepository.AddSpecialization(dObj);
            if (response == true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }
        [HttpPost]
        [Route("surgery")]
        public IHttpActionResult AddSurgery(Surgery sObj)
        {
            var response = cureWellRepository.AddSurgery(sObj);
            if (response == true)
            {
                var result = new { status = true };
                return Ok(result);
            }
            else
            {
                var result = new { status = false };
                return Ok(result);
            }
        }
    }
}

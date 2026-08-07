using Microsoft.AspNetCore.Mvc;
using HealthClinic.Entities;
using HealthClinic.Service;

namespace HealthClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService = new DoctorService();

        // GET api/doctor
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            List<Doctor> doctors = doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        // POST api/doctor
        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            doctorService.AddDoctor(doctor);
            return Ok("Doctor added successfully.");
        }

        // PUT api/doctor/5
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            doctor.DoctorId = id;
            doctorService.UpdateDoctor(doctor);
            return Ok("Doctor updated successfully.");
        }

        // DELETE api/doctor/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            doctorService.DeleteDoctor(id);
            return Ok("Doctor deleted successfully.");
        }
    }
}
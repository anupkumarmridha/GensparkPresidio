using DoctorAppoinmentAPI.Controllers.InputModels;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppoinmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        // GET: api/Doctor/specialization
        [HttpGet("{specialization}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsBySpecialization(string specialization)
        {
            var doctors = await _doctorService.GetDoctorsBySpecialization(specialization);
            return Ok(doctors);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor(CreateDoctorModel doctorModel)
        {
            try
            {
                var newDoctor = await _doctorService.AddDoctor(doctorModel.UserId, doctorModel.Specialization);
                return CreatedAtAction(nameof(GetDoctor), new { id = newDoctor.Id }, newDoctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                await _doctorService.UpdateDoctor(doctor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.DeleteDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return doctor;
        }
    }
}

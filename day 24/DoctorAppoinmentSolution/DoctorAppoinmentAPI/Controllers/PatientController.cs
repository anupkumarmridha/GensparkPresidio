using DoctorAppoinmentAPI.Controllers.InputModels;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppoinmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(CreatePatientModel patient)
        {
            try
            {
                var newPatient = await _patientService.AddPatient(patient.UserId);
                return CreatedAtAction(nameof(GetPatient), new { id = newPatient.Id }, newPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                await _patientService.UpdatePatient(patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _patientService.DeletePatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }
    }
}

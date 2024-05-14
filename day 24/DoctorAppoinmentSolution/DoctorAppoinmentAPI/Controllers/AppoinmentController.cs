using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppoinmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppoinmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            try
            {
                var newAppointment = await _appointmentService.AddAppointment(appointment);
                return CreatedAtAction(nameof(GetAppointment), new { id = newAppointment.Id }, newAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                await _appointmentService.UpdateAppointment(appointment);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.DeleteAppointment(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return appointment;
        }
    }
}

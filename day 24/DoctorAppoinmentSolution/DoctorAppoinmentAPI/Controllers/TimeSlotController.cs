using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppoinmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        // GET: api/TimeSlot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSlot>>> GetTimeSlots()
        {
            var timeSlots = await _timeSlotService.GetAllTimeSlots();
            return Ok(timeSlots);
        }

        // GET: api/TimeSlot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlot>> GetTimeSlot(int id)
        {
            var timeSlot = await _timeSlotService.GetTimeSlotById(id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return timeSlot;
        }

        // POST: api/TimeSlot
        [HttpPost]
        public async Task<ActionResult<TimeSlot>> CreateTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                var newTimeSlot = await _timeSlotService.AddTimeSlot(timeSlot);
                return CreatedAtAction(nameof(GetTimeSlot), new { id = newTimeSlot.Id }, newTimeSlot);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TimeSlot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSlot(int id, TimeSlot timeSlot)
        {
            if (id != timeSlot.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                await _timeSlotService.UpdateTimeSlot(timeSlot);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TimeSlot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSlot>> DeleteTimeSlot(int id)
        {
            var timeSlot = await _timeSlotService.DeleteTimeSlot(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return timeSlot;
        }
    }
}

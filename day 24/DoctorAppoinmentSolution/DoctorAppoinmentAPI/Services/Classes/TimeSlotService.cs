using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Interfaces;

namespace DoctorAppoinmentAPI.Services.Classes
{
    public class TimeSlotService:ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TimeSlotService(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlots()
        {
            return await _timeSlotRepository.GetAll();
        }

        public async Task<TimeSlot> GetTimeSlotById(int id)
        {
            return await _timeSlotRepository.GetById(id);
        }

        public async Task<TimeSlot> AddTimeSlot(TimeSlot timeSlot)
        {
            return await _timeSlotRepository.Add(timeSlot);
        }

        public async Task<TimeSlot> UpdateTimeSlot(TimeSlot timeSlot)
        {
            return await _timeSlotRepository.Update(timeSlot);
        }

        public async Task<TimeSlot> DeleteTimeSlot(int id)
        {
            return await _timeSlotRepository.Delete(id);
        }
    }
}

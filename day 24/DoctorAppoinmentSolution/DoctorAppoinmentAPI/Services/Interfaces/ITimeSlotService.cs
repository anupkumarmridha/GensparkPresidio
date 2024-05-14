using DoctorAppoinmentAPI.Models;

namespace DoctorAppoinmentAPI.Services.Interfaces
{
    public interface ITimeSlotService
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
        Task<TimeSlot> GetTimeSlotById(int id);
        Task<TimeSlot> AddTimeSlot(TimeSlot timeSlot);
        Task<TimeSlot> UpdateTimeSlot(TimeSlot timeSlot);
        Task<TimeSlot> DeleteTimeSlot(int id);
    }
}

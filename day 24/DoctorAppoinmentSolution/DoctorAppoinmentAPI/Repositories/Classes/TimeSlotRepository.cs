using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class TimeSlotRepository : BaseRepository<int, TimeSlot>, ITimeSlotRepository
    {
        public TimeSlotRepository(DoctorAppoinmentDbContext context) : base(context)
        {

        }
    }
}

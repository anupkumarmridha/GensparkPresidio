using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class DoctorRepository: BaseRepository<int, Doctor>, IDoctorRepository
    {
        public DoctorRepository(DoctorAppoinmentDbContext context) : base(context)
        {

        }
    
    }
}

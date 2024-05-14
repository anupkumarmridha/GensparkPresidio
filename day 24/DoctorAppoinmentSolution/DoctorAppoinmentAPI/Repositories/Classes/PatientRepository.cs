using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class PatientRepository: BaseRepository<int, Patient>, IPatientRepository
    {
        public PatientRepository(DoctorAppoinmentDbContext context) : base(context)
        {
        }
    }
}

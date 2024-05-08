using DoctorAppoinmentModelLibery.Model;

namespace DoctorAppoinmentDALLibery
{
    public class PatientRepository : BaseRepository<int, Patient>, IPatientRepository
    {
        public PatientRepository(DBDoctorAppoinmentContext context) : base(context)
        {
        }
        protected override int GetKey(Patient item)
        {
            return item.Id;
        }
    }
}

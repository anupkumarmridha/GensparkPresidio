using DoctorAppoinmentModelLibery.Model;

namespace DoctorAppoinmentDALLibery
{
    public class DoctorRepository:BaseRepository<int, Doctor>, IDoctorRepository
    {

        public DoctorRepository(DBDoctorAppoinmentContext context) : base(context)
        {
        }
        protected override int GetKey(Doctor item)
        {
            return item.Id;
        }
    }
}

using DoctorAppoinmentModelLibery;
using System.Security.Cryptography.X509Certificates;

namespace DoctorAppoinmentDALLibery
{
    public class DoctorRepository:BaseRepository<int, Doctor>, IDoctorRepository
    {

        public override int GenerateId()
        {
            if (_data.Count == 0)
            {
                return 1;
            }
            else
            {
                return _data.Keys.Max() + 1;
            }
        }
        public override Doctor Add(Doctor item)
        {
            item.Id = GenerateId(); // Set the Id before adding
            return base.Add(item);
        }
        protected override int GetKey(Doctor item)
        {
            return item.Id;
        }
    }
}

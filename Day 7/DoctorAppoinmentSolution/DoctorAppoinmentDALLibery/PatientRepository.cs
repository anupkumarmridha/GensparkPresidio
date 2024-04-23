using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public class PatientRepository : BaseRepository<int, Patient>, IPatientRepository
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
        public override Patient Add(Patient item)
        {
            item.Id = GenerateId(); // Set the Id before adding
            return base.Add(item);
        }
        protected override int GetKey(Patient item)
        {
            return item.Id;
        }
    }
}

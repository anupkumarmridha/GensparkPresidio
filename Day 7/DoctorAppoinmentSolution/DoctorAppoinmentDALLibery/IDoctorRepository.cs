using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public interface IDoctorRepository:IRepository<int, Doctor>
    {
    }
}

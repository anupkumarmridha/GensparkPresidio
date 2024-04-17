using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentModelLibery
{
    public class Patient : User, IEntity<int>
    {
        Patient() 
        {
            Console.WriteLine("Paitent Class");
        }

    }
}

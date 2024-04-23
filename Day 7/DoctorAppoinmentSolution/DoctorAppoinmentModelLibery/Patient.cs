using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentModelLibery
{
    public class Patient : User
    {
        Patient() 
        {
            Console.WriteLine("Paitent Class");
        }

        public override string ToString()
        {
            return $"Patient ID: {Id}, Name: {Name}, Email: {Email}, Gender: {Gender}, Date of Birth: {DateOfBirth}";
        }
    }
}

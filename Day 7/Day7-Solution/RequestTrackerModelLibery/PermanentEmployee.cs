using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibery
{
    public class PermanentEmployee:Employee
    {
        public PermanentEmployee()
        {
            Type = "PermanentEmployee";
        }
        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
        {
            Salary = salary;

        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Basic Salary");
            Salary = Convert.ToDouble(Console.ReadLine());
        }
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }
        public void SpecialPermanentMethod()
        {
            Console.WriteLine("Special permanent method");
        }

        public override string ToString()
        {
            return base.ToString()
                + "\nEmployee Salary : Rs. " + Salary;
        }

    }
}

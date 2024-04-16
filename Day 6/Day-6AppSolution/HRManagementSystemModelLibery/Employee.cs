using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemModelLibery
{
    public class Employee:IGovtRules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double BasicSalary { get; set; }
        public string CompanyName { get; set; }

        public DateTime JoiningDate;
        public float ServiceCompleted;


        public float CalculateServiceYears()
        {
            TimeSpan serviceDuration = DateTime.Now - JoiningDate;
            return (float)serviceDuration.Days / 365;
        }
        public Employee() { 
        
            Id = 0;
            Name = string.Empty;
            Department = string.Empty;
            CompanyName = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0.0;
            ServiceCompleted = 0;
        }

        public Employee(int id, string name, string department, string designation, double basicSalary, DateTime joiningDate, float serviceCompleted)
        {
            Id = id;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
            JoiningDate = joiningDate;
            ServiceCompleted = serviceCompleted;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter date of joining: ");
            JoiningDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the Department: ");
            Department = Console.ReadLine();
            Console.WriteLine("Please enter the Designation: ");
            Designation = Console.ReadLine();
            Console.WriteLine("Please enter the Basic Salary: ");
            BasicSalary = Convert.ToDouble(Console.ReadLine());
            ServiceCompleted = CalculateServiceYears();
        }
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee Name : " + CompanyName);
            Console.WriteLine("Employee Joining Date : " + JoiningDate);
            Console.WriteLine("Employee Department " + Department);
            Console.WriteLine("Date of Designation : " + Designation);
            Console.WriteLine("Employee Basic Salary : " + BasicSalary);
            Console.WriteLine("Employee Total Service Completed : " + ServiceCompleted);
        }

        public double EmployeePF(double basicSalary)
        {
            Console.WriteLine("Under Employee class PF");
            throw new NotImplementedException();
        }

        public void LeaveDetails()
        {
            Console.WriteLine("Under Employee class Leave Details");
            throw new NotImplementedException();
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            Console.WriteLine("Under Employee class GratuityAmount");
            throw new NotImplementedException();
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBasics.Models
{
    internal class Employee
    {
        //internal int Id;
        //int Id;
        //public int GetId()
        //{
        //    return Id;
        //}

        //public void SetId(int eId)
        //{
        //    Id= eId;
        //}

        //public int Id {
        //    get { return Id; }
        //    set { Id = value; } 

        //}
        //public int Id
        //{
        //    get => Id;
        //    set => Id = value;
        //}

        double salary;
        public int Id { get; private set; }

        public string Name { get; set; }
        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return (salary - (salary * 10 / 100));
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Employee()
        {
            Id = 0;
            Name=string.Empty;
            Email = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Salary = 0;
        }

        public Employee(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Employee Id as Int</param>
        /// <param name="name">Employee name as string</param>
        /// <param name="salary">Employee salary as double without TDS deduction</param>
        /// <param name="dateOfBirth">DateOfBirth as DateTime(yaar,month, day)</param>
        /// <param name="email">Email as String</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        /// <summary>
        /// Print Employee Details
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee Id \t:\t{Id}");
            Console.WriteLine($"Employee Name \t:\t{Name}");
            Console.WriteLine($"Employee Email \t:\t{Email}");
            Console.WriteLine($"Employee Date Of Birth \t:\t{DateOfBirth}");
            Console.WriteLine($"Employee Salary \t:\t{Salary}");
        }

        /// <summary>
        /// Display the work done in the duration
        /// </summary>
        /// <param name="hours">Hours required for Work</param>
        /// <returns>Message Work done in the Duration</returns>
        public string Work(int hours)
        {
            Console.WriteLine("Work");
            return $"Done work for {hours} hours";
        }
    }
}

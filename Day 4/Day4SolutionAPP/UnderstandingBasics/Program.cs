using UnderstandingBasics.Models;

namespace UnderstandingBasics
{
    internal class Program
    {

        Employee CreateEmployeeByTakingDetailsFromConsole(int id)
        {
            //Employee employee = new Employee(id);
            Employee employee = new (id);
            Console.WriteLine("Please enter your name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Please enter your DOB");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter Salary");
            double salary;
            while(!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid entry! please try again");
            }
            employee.Salary = salary;
            Console.WriteLine("Please enter your email");
            employee.Email = Console.ReadLine();
            return employee;
        }
        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //employee.Id = 1;
            //employee.Name = "Test";
            //employee.Salary = 100000;
            //employee.DateOfBirth = new DateTime(2000, 12, 18);
            //employee.Email = "anup@gmail.com";

            //Employee employee1 = new Employee(101)
            //{
            //    Name = "Mon",
            //    DateOfBirth = new DateTime(2001, 05, 06),
            //    Email="mon@gmail.com",
            //    Salary=20000,
            //};
            //Employee employee2 = new Employee(103, "Sweety", 30000, new DateTime(2000, 05, 07), "sweety@gmail.com");
            //Console.WriteLine(employee1.Salary);
            //Console.WriteLine(employee.Salary);
            //employee.Work(12);
            //employee2.PrintEmployeeDetails();

            
            //Array's in C#

            //int[] ages = new int[3];
            //ages[0] = 1;
            //ages[1] = 2;
            //ages[2] = 3;

            //for (int i = 0; i < ages.Length; i++)
            //{
            //    Console.WriteLine(ages[i]);

            //}

            //int count = ages.Length - 1;

            //while (count>=0)
            //{
            //    Console.WriteLine(ages[count]);
            //    count--;
            //}

            //int count = ages.Length - 1;

            //do
            //{
            //    if (ages[count]>100)
            //    {
            //        Console.WriteLine("Age is Greater then 100");
            //    }
            //    Console.WriteLine(ages[count]);
            //    count--;
            //} while (count >= 0);

            Employee[] employees = new Employee[3];

            //Program program = new Program();
            Program program = new();


            for(int i = 0; i < employees.Length; i++)
            {
                employees[i] = program.CreateEmployeeByTakingDetailsFromConsole(100+i);
            }
            for(int i = 0; i < employees.Length; i++)
            {
                employees[i].PrintEmployeeDetails();
            }

        }
    }
}

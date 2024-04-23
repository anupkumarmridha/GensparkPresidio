using RequestTrackerBLLibery;
using RequestTrackerDALLibery;
using RequestTrackerModelLibery;
using System.Collections;
namespace RequestTrackerApp
{
    internal class Program
    {
        //int Divide(int num1, int num2)
        //{
        //    try
        //    {
        //        int result = num1 / num2;
        //        return result;
        //    }
        //    catch (DivideByZeroException dbze)
        //    {
        //        Console.WriteLine("You are trying to divide by zero. Its not worth");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Release the divide method resource");
        //    }
        //    Console.WriteLine("Your division did not go well");
        //    return 0;

        //}

        void AddDepartment()
        {

            DepartmentBL departmentBL = new DepartmentBL(new DepartmentRepository());
            try
            {
                Console.WriteLine("Please enter the number of Department you wanted to add: ");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddDepartment();
            //program.UnderstandingList();
            //int num1, num2, result;
            //try
            //{
            //    num1 = Convert.ToInt32(Console.ReadLine());
            //    num2 = Convert.ToInt32(Console.ReadLine());
            //    result = num1 / num2;
            //    Console.WriteLine(result);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine("The given data could not be converted to number.");
            //}
            //catch (DivideByZeroException dbze)
            //{
            //    Console.WriteLine("You are trying to divide by zero. Its not worth");
            //}
            //Console.WriteLine("Bye bye");
        }

    }
 }

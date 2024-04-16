using HRManagementSystemModelLibery;
namespace HRManagementSystem
{
    internal class Program
    {
        Employee[] employees;
        int count = 0;
        public Program()
        {
            int n;
            Console.WriteLine("Enter Total no of Employee at max: ");
            n = Convert.ToInt32(Console.ReadLine());
            employees = new Employee[n];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(100+i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (count == 0)
            {
                Console.WriteLine("no employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    PrintEmployee(employees[i]);

                }
            }
        }
        Employee CreateEmployee(int id)
        {
            string companyName;
            do
            {
                Console.WriteLine("Please enter the company name for employee (CTS or ACCENTURE):");
                companyName = Console.ReadLine().Trim().ToUpper();
            } while (companyName != "CTS" && companyName != "ACCENTURE");
            
            Employee employee = null;

            switch (companyName)
            {
                case "CTS":
                    employee = new CTS();
                    break;
                case "ACCENTURE":
                    employee = new Accenture();
                    break;                 
            }
            employee.Id = 100+id;
            employee.BuildEmployeeFromConsole();
            count++;
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            //Console.WriteLine(employee);
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                // if ( employees[i].Id == id && employees[i] != null)//Will lead to exception
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();

        }
    }
}

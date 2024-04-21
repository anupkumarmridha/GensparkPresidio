using EmployeeManagementBLLibery.Services;
using EmployeeManagementDALLibery.Repositories;
using EmployeeManagementUILibery;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Department");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Exit");
        }

        static void HandleDepartmentMenuChoice(ConsoleService consoleService,DepartmentService departmentService, int choice)
        {
            switch (choice)
            {
                case 1:
                    consoleService.AddDepartment(departmentService);
                    break;
                case 2:
                    consoleService.UpdateDepartment(departmentService);
                    break;
                case 3:
                    consoleService.DeleteDepartment(departmentService);
                    break;
                case 4:
                    consoleService.GetDepartmentByName(departmentService);
                    break;
                case 5:
                    consoleService.GetAllDepartments(departmentService);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void HandleEmployeeMenuChoice(ConsoleService consoleService,EmployeeService employeeService, int choice)
        {
            switch (choice)
            {
                case 1:

                    consoleService.AddEmployee(employeeService);
                    break;
                case 2:
                    consoleService.UpdateEmployee(employeeService);
                    break;
                case 3:
                    consoleService.DeleteEmployee(employeeService);
                    break;
                case 4:
                    consoleService.GetEmployeeById(employeeService);
                    break;
                case 5:
                    consoleService.GetAllEmployees(employeeService);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static int GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValidInput = false;
            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidInput);

            return result;
        }
        static void Main(string[] args)
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            DepartmentService departmentService = new DepartmentService(departmentRepository);
            EmployeeService employeeService = new EmployeeService(employeeRepository);
            ConsoleService consoleService = new ConsoleService();


            while (true)
            {
                DisplayMainMenu();
                int choice = GetValidIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        consoleService.DisplayDepartmentMenu();
                        int departmentChoice = GetValidIntegerInput("Enter your choice: ");
                        HandleDepartmentMenuChoice(consoleService, departmentService,departmentChoice);
                        break;
                    case 2:
                        consoleService.DisplayEmployeeMenu();
                        int employeeChoice = GetValidIntegerInput("Enter your choice: ");
                        HandleEmployeeMenuChoice(consoleService,employeeService, employeeChoice);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}

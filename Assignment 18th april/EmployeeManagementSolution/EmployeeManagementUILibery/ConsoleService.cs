using EmployeeManagementBLLibery.Interfaces;
using EmployeeManagementBLLibery.Services;
using EmployeeManagmentModelLibery;
using System.Xml.Linq;

namespace EmployeeManagementUILibery
{
    public class ConsoleService : IConsoleService
    {
        private EmployeeModel BuildEmployeeFromConsole()
        {
            Console.WriteLine("Enter Employee Details:");
            string name = GetValidStringInput("Enter Employee Name to Add: ");
            Console.Write("Department: ");
            string department = GetValidStringInput("Enter Employee Department to Add: ");
            Console.Write("Salary: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid input. Please enter a valid salary.");
            }
            return new EmployeeModel(name, department, salary);
        }
        private DepartmentModel BuildDepartmentFromConsole()
        {
            Console.WriteLine("Enter Department Details:");
            string departmentName = GetValidStringInput("Enter Department Name to Add: ");
            return new DepartmentModel(departmentName);
        }
        public void AddDepartment(IDepartmentService departmentService)
        {
            try
            {
                DepartmentModel NewDepartment=BuildDepartmentFromConsole();
                DepartmentModel savedDepartment=departmentService.AddDepartment(NewDepartment);
                if (savedDepartment != null)
                {
                    Console.WriteLine("Department Added Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddEmployee(IEmployeeService employeeService)
        {
            try
            {
                EmployeeModel NewEmployee=BuildEmployeeFromConsole();
                EmployeeModel savedEmployee=employeeService.AddEmployee(NewEmployee);
                if (savedEmployee != null)
                {
                    Console.WriteLine("Employee added success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteDepartment(IDepartmentService departmentService)
        {
            try
            {
                string departmentName = GetValidStringInput("Enter Department Name to Delete: ");
                bool isDeleted = departmentService.DeleteDepartment(departmentName);
                if (isDeleted)
                {
                    Console.WriteLine("Department Deleted success!!");
                }
                else
                {
                    Console.WriteLine("There is a problem while deleting employee!!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteEmployee(IEmployeeService employeeService)
        {
            try
            {
                int empId = GetValidIntegerInput("Enter employee Id: ");
                bool isDeleted=employeeService.DeleteEmployee(empId);
                if (isDeleted)
                {
                    Console.WriteLine("Employee Deleted success!!");
                }
                else
                {
                    Console.WriteLine("There is an internal problem while deleting employee");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void DisplayDepartmentMenu()
        {
            Console.WriteLine("Department Menu:");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Update Department");
            Console.WriteLine("3. Delete Department");
            Console.WriteLine("4. Get Department by Name");
            Console.WriteLine("5. Get All Departments");
        }

        public void DisplayEmployeeMenu()
        {
            Console.WriteLine("Employee Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Get Employee by Id");
            Console.WriteLine("5. Get All Employees");
        }

        public void GetAllDepartments(IDepartmentService departmentService)
        {
            try
            {
                List<DepartmentModel> departments = departmentService.GetAllDepartments();
                if (departments != null && departments.Count > 0)
                {
                    Console.WriteLine("All Departments:");
                    foreach (var department in departments)
                    {
                        Console.WriteLine(department.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No departments found.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GetAllEmployees(IEmployeeService employeeService)
        {
            try
            {
                List<EmployeeModel> employees= employeeService.GetAllEmployees();
                if (employees != null && employees.Count > 0)
                {
                    Console.WriteLine("All Employees:");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine(employee.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GetDepartmentByName(IDepartmentService departmentService)
        {
            try
            {
                string departmentName = GetValidStringInput("Enter Department Name to Find: ");
                DepartmentModel department = departmentService.GetDepartmentByName(departmentName);
                if (department != null)
                {
                    Console.WriteLine(department.ToString());
                }
                else
                {
                    Console.WriteLine("Department not exist!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GetEmployeeById(IEmployeeService employeeService)
        {
            try
            {
                int empId = GetValidIntegerInput("Enter employee Id: ");
                EmployeeModel employee = employeeService.GetEmployeeById(empId);
                if (employee != null)
                {
                    Console.WriteLine(employee.ToString());
                }else
                {
                    Console.WriteLine("Employee not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        


        public void UpdateDepartment(IDepartmentService departmentService)
        {
            try
            {
                string departmentName = GetValidStringInput("Enter Old Department name: ");
                DepartmentModel department = departmentService.GetDepartmentByName(departmentName);
                if (department != null)
                {
                    string newDepartmentName = GetValidStringInput("Enter New Department Name: ");
                    department.SetName(newDepartmentName);
                    DepartmentModel updatedDepartment = departmentService.UpdateDepartment(department);
                    if(updatedDepartment != null)
                        Console.WriteLine(updatedDepartment.ToString());
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateEmployee(IEmployeeService employeeService)
        {
            try
            {
                int employeeId = GetValidIntegerInput("Enter Employee ID: ");
                EmployeeModel employee = employeeService.GetEmployeeById(employeeId);

                if (employee != null)
                {
                    Console.WriteLine($"Employee found: {employee}");
                    DisplayUpdateMenuAndHandleInput(employeeService, employee);
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DisplayUpdateMenuAndHandleInput(IEmployeeService employeeService, EmployeeModel employee)
        {
            Console.WriteLine("Select which information to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Department");
            Console.WriteLine("3. Salary");

            int choice = GetValidIntegerInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    UpdateEmployeeName(employeeService, employee);
                    break;
                case 2:
                    UpdateEmployeeDepartment(employeeService, employee);
                    break;
                case 3:
                    UpdateEmployeeSalary(employeeService, employee);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        private void UpdateEmployeeName(IEmployeeService employeeService, EmployeeModel employee)
        {
            string newName = GetValidStringInput("Enter new name: ");
            employee.SetName(newName);
            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee name updated successfully.");
        }

        private void UpdateEmployeeDepartment(IEmployeeService employeeService, EmployeeModel employee)
        {
            string newDepartment = GetValidStringInput("Enter new department: ");
            employee.SetDepartment(newDepartment);
            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee department updated successfully.");
        }

        private void UpdateEmployeeSalary(IEmployeeService employeeService, EmployeeModel employee)
        {
            decimal newSalary;
            while (!decimal.TryParse(Console.ReadLine(), out newSalary))
            {
                Console.WriteLine("Invalid input. Please enter a valid salary.");
            }
            employee.SetSalary(newSalary);
            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee salary updated successfully.");
        }

        public string GetValidStringInput(string prompt)
        {
            string userInput;

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a non-empty string.");
                }
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }
        public int GetValidIntegerInput(string prompt)
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
    }
}

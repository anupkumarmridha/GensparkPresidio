using RequestTrackerModelLibery;
namespace RequestTrackerApp
{
    internal class Program
    {
        //void UnderstandingSequenceStatments()
        //{
        //    Console.WriteLine("Hello");
        //    Console.WriteLine("Hi");
        //    int num1, num2;
        //    num1 = 100;
        //    num2 = 20;
        //    int num3 = num1 / num2;
        //    Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        //}
        //void UnderstandingSelectionWithIf()
        //{
        //    string strName = "Ramu";
        //    if (strName == "Ramu")
        //    {
        //        Console.WriteLine("Welcome Ramu. you are authorized");
        //        Console.WriteLine("Bingo!!");
        //    }
        //    else if (strName == "Somu")
        //        Console.WriteLine("You are Somu not Ramu. ONly Basic access");
        //    else
        //        Console.WriteLine("I don't know who you are. Get out...");
        //}
        //void UnderstandingSwitchCase()
        //{
        //    Console.WriteLine("Please enter a number for day");
        //    int choice = Convert.ToInt32(Console.ReadLine());
        //    switch (choice)
        //    {
        //        case 1:
        //            Console.WriteLine("Monday");
        //            break;
        //        case 2:
        //            Console.WriteLine("Tuesday");
        //            break;
        //        case 3:
        //            Console.WriteLine("Wednesday");
        //            break;
        //        case 4:
        //            Console.WriteLine("Thursday");
        //            break;
        //        case 5:
        //            Console.WriteLine("Friday");
        //            break;
        //        case 6:
        //        case 7:
        //            Console.WriteLine("Weekend");
        //            break;
        //        default:
        //            Console.WriteLine("You dont know the numberof days in a week???");
        //            break;
        //    }
        //}
        //void UnderstandingIterationWithFor()
        //{
        //    for (int i = 0; i < 5; i = i + 2)
        //    {
        //        Console.WriteLine("Hello " + i);

        //    }
        //}
        //void UnderstandingIterationWithWhile()
        //{
        //    int count = 10;
        //    while (count > 0)
        //    {
        //        count--;
        //        if (count == 7)
        //            continue;
        //        Console.WriteLine("Thje value of count is " + count);
        //        if (count == 4)
        //            break;

        //    }
        //}
        //void UnderstandingIterationWithDoWhile()
        //{
        //    int count = -1;
        //    do
        //    {
        //        Console.WriteLine("In Do while the value is  " + count);
        //        Console.WriteLine("Please enter the number");
        //        count = Convert.ToInt32(Console.ReadLine());
        //    } while (count > 0);
        //}
        //void UnderstandingArray()
        //{
        //    int[] numbers = { 20, 67, 90, 77, 66, 68 };
        //    int countOfRepeatingNumbers = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        int firstNumber, secondNumber;
        //        firstNumber = numbers[i] / 10;
        //        secondNumber = numbers[i] % 10;
        //        if (firstNumber == secondNumber)
        //            countOfRepeatingNumbers++;
        //    }
        //    Console.WriteLine("The numbe rof repeating numbers is " + countOfRepeatingNumbers);
        //}

        //void ThreeDigitRepetingNumber()
        //{
        //    int[] numbers = { 200, 567, 909, 777, 626, 688 };
        //    int countOfRepeatingNumbers = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        int firstDigit, secondDigit, thirdDigit;
        //        firstDigit = numbers[i] / 100;
        //        secondDigit = (numbers[i] / 10) % 10;
        //        thirdDigit = numbers[i] % 10;
        //        if (firstDigit == secondDigit || secondDigit == thirdDigit || firstDigit == thirdDigit)
        //            countOfRepeatingNumbers++;
        //    }
        //    Console.WriteLine("The number of repeating numbers is " + countOfRepeatingNumbers);
        //}

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
            Console.WriteLine("4. Update Employee by ID");
            Console.WriteLine("5. Delete Employee by ID");
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
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
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
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (count==0)
            {
                Console.WriteLine("no employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    Company company = new Company();
                    company.EmployeeClientVisit(employees[i]);
                    PrintEmployee(employees[i]);

                }
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string type = Console.ReadLine();
            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            count++;
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            //employee.PrintEmployeeDetails();
            Console.WriteLine(employee);
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

        void UpdateName(Employee employee)
        {
            Console.WriteLine("Enter new Name:");
            employee.Name = Console.ReadLine();
        }
        void UpdateDOB(Employee employee)
        {
            Console.WriteLine("Enter new Date of Birth:");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }
        void UpdateSalary(Employee employee)
        {
            Console.WriteLine("Enter new Salary:");
            employee.Salary = Convert.ToDouble(Console.ReadLine());
        }

        void UpdateEmployee()
        {
            Console.WriteLine("Update Employee");
            int id= GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such employee present");
                return;
            }
            Console.WriteLine("Current Employee Details:");
            PrintEmployee(employee);

            Console.WriteLine("Select what you want to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Date of Birth");
            Console.WriteLine("3. Salary");
            Console.WriteLine("0. Exit");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice<0 || choice > 3)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            switch (choice)
            {
                case 0: 
                    Console.WriteLine("Bye");
                    break;
                case 1: 
                    Console.WriteLine("Update Name only");
                    UpdateName(employee);
                    break;
                case 2: 
                    Console.WriteLine("Update Date of Birth only");
                    UpdateDOB(employee);
                    break;
                case 3: 
                    UpdateSalary(employee);
                    Console.WriteLine("Update Salary only");
                    break;
               

            }
        }

        void DeleteEmployee()
        {
            Console.WriteLine("Delete Employee");
            int id=GetIdFromConsole();
            for(int i=0; i < employees.Length;i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    count--;
                    Console.WriteLine("Employee deleted successfully.");
                    break;
                }
            }
            PrintAllEmployees();
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
            //ContractEmployee employee = new ContractEmployee();
            //employee.BuildEmployeeFromConsole();
            //employee.PrintEmployeeDetails();
        }

    }
 }

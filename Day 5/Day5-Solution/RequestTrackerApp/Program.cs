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
        public Program()
        {
            employees = new Employee[3];
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
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
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

namespace ConsoleApp1
{
    internal class Program
    {
        static double Add(double num1, double num2)
        {
            try
            {
                checked
                {
                    double result = num1 + num2;
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Overflow occurred during addition");
                return 0;
            }
        }
        static double Subtract(double num1, double num2)
        {
            try
            {
                checked
                {
                    double result = num2 - num1;
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Overflow occurred during addition");
                return 0;
            }
        }
        static double Product(double num1, double num2)
        {
            try
            {
                checked
                {
                    double result = num2 * num1;
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Overflow occurred during addition");
                return 0;
            }
        }


        static double Divide(double num1, double num2, out double rem)
        {
            rem = 0;
            try
            {
                checked
                {
                    double result = num1 / num2;
                    rem = num1 % num2;
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Overflow occurred during addition");
                return 0;
            }
        }

        static double TakeNumber()
        {
            double num1;
            Console.WriteLine("Enter a number");
            while (double.TryParse(Console.ReadLine(), out num1) == false)
            {
                Console.WriteLine("Invalid entry. Please enter a number");
            }
            return num1;
        }
        private static void PrintResult(double result, string ops)
        {
            Console.WriteLine($"The {ops} is {result}");
        }

        static void AddOps()
        {
            double num1, num2, result;
            num1 = TakeNumber();
            num2 = TakeNumber();
            result = Add(num1, num2);
            PrintResult(result, "Sum");
        }
        static void SubOps()
        {
            double num1, num2, result;
            num1 = TakeNumber();
            num2 = TakeNumber();
            result = Subtract(num1, num2);
            PrintResult(result, "Subtract");
        }
        static void MultiOps()
        {
            double num1, num2, result;
            num1 = TakeNumber();
            num2 = TakeNumber();
            result = Product(num1, num2);
            PrintResult(result, "Product");
        }
        static void DivideOps()
        {
            double num1, num2, result, reminder;
            num1 = TakeNumber();
            num2 = TakeNumber();
            result = Divide(num1, num2, out reminder);
            PrintResult(result, "Division");
            PrintResult(reminder, "Reminder");
        }

        static void DisplayOption()
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    Console.Write("Enter your choice (1-5): ");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You selected Addition.");
                        AddOps();
                        break;
                    case 2:
                        Console.WriteLine("You selected Subtraction.");
                        SubOps();
                        break;
                    case 3:
                        Console.WriteLine("You selected Multiplication.");
                        MultiOps();
                        break;
                    case 4:
                        Console.WriteLine("You selected Division.");
                        DivideOps();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Basic Calculator !");
            DisplayOption();
        }
    }
}

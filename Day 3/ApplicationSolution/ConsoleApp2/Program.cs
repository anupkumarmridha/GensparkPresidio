namespace ConsoleApp2
{
    internal class Program
    {
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

        static void FindGreatestNumber()
        {
            double max = double.MinValue;
            double num;

            do
            {
                num = TakeNumber();

                if (num >= 0 && num > max)
                {
                    max = num;
                }
            } while (num >= 0);

            if (max == double.MinValue)
            {
                Console.WriteLine("No valid numbers were entered.");
            }
            else
            {
                Console.WriteLine("The greatest number entered is: " + max);
            }

        }
        static void Main(string[] args)
        {
            FindGreatestNumber();
        }
    }
}

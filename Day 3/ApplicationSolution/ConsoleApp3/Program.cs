namespace ConsoleApp3
{
    internal class Program
    {
        static double TakeNumber()
        {
            double num;
            Console.WriteLine("Enter a number");

            while (true)
            {
                while (!double.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Invalid entry. Please enter a number:");
                }

                if (num % 7 == 0 || num<0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The entered number is not divisible by 7. Please enter another number:");
                }
            }

            return num;
        }

        private static void PrintResult(double result, string ops)
        {
            Console.WriteLine($"The {ops} is {result}");
        }
        static void FindAndPrintAverageDivisibleBySeven()
        {
            double sum = 0;
            int count = 0;
            double num;

            do
            {
                num = TakeNumber();

                try
                {
                    checked
                    {
                        if (num >= 0 && num % 7 == 0)
                        {
                            sum += num;
                            count++;
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("An overflow occurred while performing arithmetic operations.");
                    return;
                }
            } while (num >= 0);

            double average = count > 0 ? sum / count : 0;

            PrintResult(average, "average of numbers divisible by 7");
        }

        static void Main(string[] args)
        {
            FindAndPrintAverageDivisibleBySeven();
        }
    }
}

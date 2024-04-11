namespace ConsoleApp4
{
    internal class Program
    {
        static void PrintResult(double result, string ops)
        {
            Console.WriteLine($"The {ops} is {result}");
        }
        static int FindNameLength()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine() ?? "";
            name = name.Trim();
            return name.Length;
        }
       
        static void Main(string[] args)
        {
            int nameLength = FindNameLength();
            PrintResult(nameLength, "length of your name");
        }
    }
}

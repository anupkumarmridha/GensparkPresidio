namespace ConsoleApp5
{
    internal class Program
    {
        static string TakeInput()
        {
            string input;
            do
            {
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter again:");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        static bool AuthenticateUser()
        {
            int attemptsLeft = 3;

            while (attemptsLeft > 0)
            {
                Console.WriteLine("Enter username:");
                string username = TakeInput();
                Console.WriteLine("Enter password:");
                string password = TakeInput();

                try
                {
                    if (username == "ABC" && password == "123")
                    {
                        return true;
                    }
                    else
                    {
                        attemptsLeft--;
                        Console.WriteLine($"Invalid username or password. Attempts left: {attemptsLeft}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            Console.WriteLine("You have exceeded the number of attempts. Please try again later.");
            return false;
        }


        static void Main(string[] args)
        {
            bool isAuthenticated = AuthenticateUser();
            if (isAuthenticated)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Login failed. Please try again later.");
            }
        }
    }
}

namespace CardValidationConsoleApp
{
    internal class Program
    {
        static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if(!char.IsDigit(c)) return false;
            }
            return true;
        }

        static bool Is16Digit(string input)
        {
            return input.Length == 16;
        }
        static string GetValidCardNumber()
        {
            string cardNumber;
            bool isValid = false;
            do
            {
                Console.WriteLine("Please enter your 16-digit card number:");
                cardNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cardNumber))
                {
                    Console.WriteLine("Invalid input! Card number cannot be empty or whitespace.");
                    continue;
                }
                // Check if the input contains any negative digits
                if (cardNumber.Contains('-'))
                {
                    Console.WriteLine("Invalid input! Card number cannot contain negative digits.");
                    continue;
                }
                // Check if the input consists only of numeric characters
                if (IsNumeric(cardNumber) && Is16Digit(cardNumber))
                {
                    isValid = true;
                }
                else if (!IsNumeric(cardNumber))
                {
                    Console.WriteLine("Invalid input! Card number should contain only numeric characters.");
                }
                else if (!Is16Digit(cardNumber))
                {
                    Console.WriteLine("Invalid input! Card number should be exactly 16 digits.");
                }

            } while (!isValid);

            return cardNumber;
        }

        static bool ValidateCard(string cardNumber)
        {
            char[] cardDigits = cardNumber.ToCharArray();
            Array.Reverse(cardDigits);

            int sum = 0;
            for (int i = 0; i < cardDigits.Length; i++)
            {
                int digit = cardDigits[i] - '0'; // Convert char to int
                //Console.WriteLine(digit);
                if (i % 2 == 1) 
                {
                    digit *= 2; 
                    digit = (digit < 10) ? digit : digit - 9; // If double digit, sum the digits
                }
                sum += digit;
            }
            //Console.WriteLine(sum);
            return sum % 10 == 0;
        }
        static void Main(string[] args)
        {
            string cardNumber = GetValidCardNumber();
            bool isValid = ValidateCard(cardNumber);
            Console.WriteLine($"Card number {cardNumber} is {(isValid ? "valid" : "invalid")}");
        }
    }
}

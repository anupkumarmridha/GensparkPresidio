using System;
using System.Linq;
using System.Threading.Tasks;

namespace CardNumberGenerator
{
    public class CardValidationService
    {
        private static readonly Random random = new Random();

        public async Task<bool> ValidateCard(string cardNumber, string cvv, DateTime expiryDate)
        {
            // Validate expiry date
            if (expiryDate < DateTime.Now)
            {
                return false;
            }

            // Validate CVV length
            if (cvv.Length != 3)
            {
                return false;
            }

            // Validate card number using Luhn algorithm
            return await IsValidCardNumberAsync(cardNumber);
        }

        private async Task<bool> IsValidCardNumberAsync(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }

                sum += n;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }

        public async Task<string> GenerateCardNumber()
        {
            // Generate a random 15-digit number
            string cardNumber = string.Concat(Enumerable.Range(0, 15).Select(_ => random.Next(0, 10).ToString()));

            // Calculate the check digit using the Luhn algorithm asynchronously
            int checkDigit = await CalculateLuhnCheckDigit(cardNumber);

            // Append the check digit to the end of the card number
            return cardNumber + checkDigit;
        }

        private async Task<int> CalculateLuhnCheckDigit(string cardNumber)
        {
            int sum = 0;
            bool alternate = true;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }

                sum += n;
                alternate = !alternate;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit;
        }
    }
}

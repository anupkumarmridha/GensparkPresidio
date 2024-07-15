using System.Text.Json;

namespace CardNumberGenerator
{
    public class CardInfo
    {
        public string CardNumber { get; set; }
        public string Pin { get; set; }
    }

    public class Program
    {
        private static readonly CardValidationService cardValidationService = new CardValidationService();

        public static async Task Main(string[] args)
        {
            int numberOfCards = 10; // Adjust this to generate more or fewer cards
            var cardInfos = new List<CardInfo>();

            for (int i = 0; i < numberOfCards; i++)
            {
                string cardNumber = await cardValidationService.GenerateCardNumber();
                string pin = GeneratePin();

                cardInfos.Add(new CardInfo { CardNumber = cardNumber, Pin = pin });
            }

            string jsonString = JsonSerializer.Serialize(cardInfos, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync("cardInfo.json", jsonString);

            Console.WriteLine("Card numbers and PINs have been generated and saved to cardInfo.json");
        }

        private static string GeneratePin()
        {
            return new Random().Next(1000, 9999).ToString();
        }
    }
}
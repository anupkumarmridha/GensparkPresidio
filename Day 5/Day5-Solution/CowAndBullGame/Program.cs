namespace CowAndBullGame
{
    internal class Program
    {

        static void PlayGame(string wordToGuess)
        {
            int attempts = 0;
            int totalCows = 0;
            int totalBulls = 0;

            while (true)
            {
                attempts++;
                Console.WriteLine($"Attempt #{attempts}:");
                string guess = GetGuessFromUser();

                int cows, bulls;
                CheckGuess(wordToGuess, guess, out cows, out bulls);

                Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");

                totalCows += cows;
                totalBulls += bulls;

                if (cows == 4)
                {
                    Console.WriteLine("Congrats!!! You won!!!!!");
                    break;
                }
            }

            DetermineWinner(totalCows, totalBulls);
        }

        static string GetInputFromUser()
        {
            string secret;
            do
            {
                Console.WriteLine("Enter your secrect (exactly 4 characters):");
                secret = Console.ReadLine().Trim().ToLower();
            } while (secret.Length != 4);

            return secret;
        }

        static string GetGuessFromUser()
        {
            string guess;
            do
            {
                Console.WriteLine("Enter your guess (exactly 4 characters):");
                guess = Console.ReadLine().Trim().ToLower();
            } while (guess.Length != 4);

            return guess;
        }

        static void CheckGuess(string wordToGuess, string guess, out int cows, out int bulls)
        {
            cows = 0;
            bulls = 0;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guess[i] == wordToGuess[i])
                {
                    cows++;
                }
                else if (wordToGuess.Contains(guess[i]))
                {
                    bulls++;
                }
            }
        }

        static void DetermineWinner(int totalCows, int totalBulls)
        {
            Console.WriteLine($"Total Score: Cow = {totalCows} and Bull = {totalBulls}");
            if (totalCows > totalBulls)
            {
                Console.WriteLine("Cows won the game!");
            }
            else if (totalCows < totalBulls)
            {
                Console.WriteLine("Bulls won the game!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cow and Bull game!");
            string wordToGuess = GetInputFromUser();
            Console.WriteLine($"Word to guess: {wordToGuess}");

            PlayGame(wordToGuess);
        }

        
    }
}

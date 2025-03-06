using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random number between 1 and 100
            Random rand = new Random();
            int magicNumber = rand.Next(1, 101); // Random number between 1 and 100

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine("I have chosen a number between 1 and 100. Can you guess it?");

            // Loop until the correct number is guessed
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                // Read user input and convert it to an integer
                string userInput = Console.ReadLine();

                // Ensure the user input is a valid number
                bool isValidNumber = int.TryParse(userInput, out guess);

                if (!isValidNumber || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 100.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();

            // Check if the user wants to play again
            if (playAgainInput != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Goodbye.");
            }
        }
    }
}

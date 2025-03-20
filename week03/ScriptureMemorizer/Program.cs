using System;

class Program
{
    static void Main()
    {
        // Load a sample scripture (you could extend this by loading from a file)
        string scriptureText = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, scriptureText);

        // Game loop
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(scripture.GetDisplayText());
            Console.ResetColor();

            Console.WriteLine("\nPress Enter to hide random words, or type 'quit' to exit.");
            Console.WriteLine("Or type the number of words you want to hide (1-4): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            int wordsToHide = 0;
            if (int.TryParse(input, out wordsToHide) && wordsToHide >= 1 && wordsToHide <= 4)
            {
                // Hide the specified number of words
                for (int i = 0; i < wordsToHide; i++)
                {
                    scripture.HideRandomWords();
                }
            }
            else
            {
                // Default behavior: Hide random words
                scripture.HideRandomWords();
            }
        }
        // When all words are hidden, print the final message
        Console.WriteLine("\nAll words hidden! Well done.");
    }
}

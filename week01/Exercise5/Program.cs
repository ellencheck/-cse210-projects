using System;

class Program
{
    static void Main(string[] args)
    {
        // Call DisplayWelcome to show a welcome message
        DisplayWelcome();

        // Call PromptUserName to get the user's name
        string userName = PromptUserName();

        // Call PromptUserNumber to get the user's favorite number
        int userNumber = PromptUserNumber();

        // Call SquareNumber to calculate the square of the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult to show the final result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to ask for the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to ask for the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }

    // Function to square a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}

using System;

class Program
{
    static void Main()
    {
        // Asking the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        // Variable to store the letter grade
        string letter = "";

        // Determining the letter grade based on the percentage
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine if the student passed or not
        bool passed = grade >= 70;

        // Displaying the letter grade
        Console.WriteLine("Your grade: " + letter);

        // Message based on whether the student passed or failed
        if (passed)
        {
            Console.WriteLine("Congratulations on passing!");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll do better next time.");
        }

        // Stretch Challenge: Adding '+' or '-' sign to the grade
        if (letter != "F") // No + or - for F
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                letter += "+"; // Adding "+" if the last digit is 7 or higher
            }
            else if (lastDigit < 3)
            {
                letter += "-"; // Adding "-" if the last digit is less than 3
            }
        }

        // Output the final grade with sign (if applicable)
        Console.WriteLine("Final grade with sign: " + letter);
    }
}

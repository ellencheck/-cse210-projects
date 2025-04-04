using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Continuously ask for user input until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
                break;
            numbers.Add(number);
        }

        // If there are numbers in the list, perform calculations and display results
        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();
            
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
            
            // Stretch challenge: Find the smallest positive number
            var smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
            if (smallestPositive != int.MaxValue)
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            else
                Console.WriteLine("There is no positive number.");
            
            // Sort the list and display it
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}

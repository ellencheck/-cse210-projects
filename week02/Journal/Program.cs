using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal(); // Create a new Journal object
        journal.LoadFromFile("journal.txt"); // Load journal entries from a file

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Exit");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    journal.WriteEntry(); // Call the method to write a new entry
                    break;
                case "2":
                    journal.DisplayEntries(); // Call the method to display all entries
                    break;
                case "3":
                    journal.SaveToFile("journal.txt"); // Save to file
                    break;
                case "4":
                    keepRunning = false; // Exit the loop
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

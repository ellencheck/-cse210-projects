using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        journal.LoadFromFile("journal.txt");

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
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile("journal.txt");
                    break;
                case "4":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

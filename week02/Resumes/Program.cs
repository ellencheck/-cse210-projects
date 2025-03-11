using System;

class Program
{
    static void Main()
    {
        // Create instances of Job
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Display the company names first
        Console.WriteLine(job1.Company); // Microsoft
        Console.WriteLine(job2.Company); // Apple

        // Display job details using DisplayJobDetails method
        job1.DisplayJobDetails(); // Software Engineer (Microsoft) 2019-2022
        job2.DisplayJobDetails(); // Manager (Apple) 2022-2023
    }
}

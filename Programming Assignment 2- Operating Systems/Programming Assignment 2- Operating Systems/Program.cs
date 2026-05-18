using System;

class FCFS_Scheduling
{
    static void Main()
    {
        Console.Write("Enter number of processes: ");
        int n = int.Parse(Console.ReadLine());

        int[] burstTime = new int[n];
        int[] completionTime = new int[n];
        int[] turnaroundTime = new int[n];
        int[] waitingTime = new int[n];
        string[] process = new string[n];

        // Input burst times
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter burst time for Process P{i + 1}: ");
            burstTime[i] = int.Parse(Console.ReadLine());
            process[i] = $"P{i + 1}";
        }

        // Calculate Completion Times
        completionTime[0] = burstTime[0];
        for (int i = 1; i < n; i++)
        {
            completionTime[i] = completionTime[i - 1] + burstTime[i];
        }

        // Calculate Turnaround Time and Waiting Time
        for (int i = 0; i < n; i++)
        {
            turnaroundTime[i] = completionTime[i];               // Since Arrival Time = 0
            waitingTime[i] = turnaroundTime[i] - burstTime[i];
        }

        // Calculate Averages
        double totalTAT = 0, totalWT = 0;
        for (int i = 0; i < n; i++)
        {
            totalTAT += turnaroundTime[i];
            totalWT += waitingTime[i];
        }

        double avgTAT = totalTAT / n;
        double avgWT = totalWT / n;

        // Display Results
        Console.WriteLine("\n--------------------------------------------------------------");
        Console.WriteLine("Process\tBurst Time\tCompletion Time\tTurnaround Time\tWaiting Time");
        Console.WriteLine("--------------------------------------------------------------");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{process[i]}\t{burstTime[i]}\t\t{completionTime[i]}\t\t{turnaroundTime[i]}\t\t{waitingTime[i]}");
        }

        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Average Turnaround Time: {avgTAT:F2}");
        Console.WriteLine($"Average Waiting Time:    {avgWT:F2}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
using System;
using System.Collections.Generic;

namespace PagingFIFO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] requests = { 10, 11, 104, 170, 73, 309, 185, 245, 246, 434, 458, 364 };

            Console.WriteLine("============================================");
            Console.WriteLine("   DEMAND PAGING SIMULATION - FIFO METHOD   ");
            Console.WriteLine("============================================\n");

            // --- Part (a) through (c): Main memory = 200 words ---
            Console.WriteLine("===== MAIN MEMORY: 200 WORDS =====\n");
            RunSimulation(requests, 100, 200, "a) Page size = 100 words");
            RunSimulation(requests, 20, 200, "b) Page size = 20 words");
            RunSimulation(requests, 200, 200, "c) Page size = 200 words");

            // --- Part (d): General statement about changing page size ---
            Console.WriteLine("\n(d) Discussion:");
            Console.WriteLine("   • When the page size is halved, the number of pages increases, causing more page faults.");
            Console.WriteLine("   • When the page size is doubled, fewer pages exist, sometimes improving spatial locality.");
            Console.WriteLine("   • However, too-large pages increase internal fragmentation.\n");

            // --- Part (e): Advantages / disadvantages of small pages ---
            Console.WriteLine("(e) Discussion:");
            Console.WriteLine("   Advantages of smaller pages:");
            Console.WriteLine("   • Reduce internal fragmentation.");
            Console.WriteLine("   • Allow finer control over what data is loaded.");
            Console.WriteLine("   Offsetting factors:");
            Console.WriteLine("   • More page table entries and overhead.");
            Console.WriteLine("   • More frequent page faults and I/O operations.");
            Console.WriteLine("   • Transferring smaller pages is less efficient due to fixed seek time.\n");

            // --- Part (f): Repeat with Main memory = 400 words ---
            Console.WriteLine("===== MAIN MEMORY: 400 WORDS =====\n");
            RunSimulation(requests, 100, 400, "f) Page size = 100 words");
            RunSimulation(requests, 20, 400, "f) Page size = 20 words");
            RunSimulation(requests, 200, 400, "f) Page size = 200 words");

            Console.WriteLine("\n(g) Summary of Observations:");
            Console.WriteLine("   • Increasing main memory generally improves success frequency.");
            Console.WriteLine("   • Page size and locality strongly affect hit rates.");
            Console.WriteLine("   • In longer, real programs, more memory reduces page faults further.\n");

            Console.WriteLine("===== END OF SIMULATION =====");
        }

        // Simulates FIFO page replacement and prints results
        static void RunSimulation(int[] requests, int pageSize, int memorySize, string label)
        {
            int numFrames = memorySize / pageSize;
            List<int> frames = new List<int>();
            int hits = 0, misses = 0;

            Console.WriteLine($"{label}");
            Console.WriteLine($"   Page size: {pageSize}, Memory: {memorySize}, Frames: {numFrames}");

            foreach (int req in requests)
            {
                int page = req / pageSize;
                if (frames.Contains(page))
                {
                    hits++;
                }
                else
                {
                    misses++;
                    if (frames.Count >= numFrames)
                        frames.RemoveAt(0); // FIFO: remove oldest
                    frames.Add(page);
                }
            }

            double successRate = (double)hits / requests.Length * 100;
            double faultRate = (double)misses / requests.Length * 100;

            Console.WriteLine($"   Hits: {hits}, Misses: {misses}");
            Console.WriteLine($"   Success Frequency (Hit Rate): {successRate:F2}%");
            Console.WriteLine($"   Page Fault Frequency: {faultRate:F2}%\n");
        }
    }
}
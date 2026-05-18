using System;
using System.Threading;

class Program
{
    // Buffer settings
    static int bufferSize = 5;
    static int[] buffer = new int[bufferSize];
    static int inPos = 0;
    static int outPos = 0;

    // Semaphores
    static SemaphoreSlim emptyCount = new SemaphoreSlim(5);   // spaces available
    static SemaphoreSlim fillCount = new SemaphoreSlim(0);    // items available

    // Mutex for exclusive access to buffer
    static object bufferLock = new object();

    static void Main(string[] args)
    {
        Thread producer = new Thread(Producer);
        Thread consumer = new Thread(Consumer);

        producer.Start();
        consumer.Start();
        producer.Join();
        consumer.Join();
    }

    static void Producer()
    {
        int item = 0;

        while (item < 20) // produce 20 items for demo
        {
            emptyCount.Wait();   // wait for empty slot

            lock (bufferLock)
            {
                buffer[inPos] = item;
                Console.WriteLine($"Producer produced: {item}");
                inPos = (inPos + 1) % bufferSize;
            }

            fillCount.Release(); // signal item added
            item++;

            Thread.Sleep(200); // slow producer for visibility
        }
    }

    static void Consumer()
    {
        int item;

        for (int i = 0; i < 20; i++)
        {
            fillCount.Wait(); // wait for item

            lock (bufferLock)
            {
                item = buffer[outPos];
                Console.WriteLine($"Consumer consumed: {item}");
                outPos = (outPos + 1) % bufferSize;
            }

            emptyCount.Release(); // signal space freed
            Thread.Sleep(400); // slow consumer for visibility
        }
    }
}

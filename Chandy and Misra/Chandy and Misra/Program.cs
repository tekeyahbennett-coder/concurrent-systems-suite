using System;
using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophersChandyMisra
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.ASCII; // ensure clean ASCII output
            int n = 5;
            Table table = new Table(n);

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < n; i++)
            {
                int id = i;
                Thread t = new Thread(() => table.Philosophers[id].Live())
                {
                    IsBackground = true
                };
                threads.Add(t);
                t.Start();
            }

            Console.WriteLine("Simulation running. Press ENTER to stop...");
            Console.ReadLine();
        }
    }

    class Fork
    {
        public int Id { get; }
        public int OwnerId { get; set; }
        public bool IsDirty { get; set; }

        public Fork(int id, int ownerId)
        {
            Id = id;
            OwnerId = ownerId;
            IsDirty = true; // all forks start dirty
        }
    }

    class Table
    {
        public int Count { get; }
        public List<Philosopher> Philosophers { get; }
        public List<Fork> Forks { get; }

        public Table(int count)
        {
            Count = count;
            Forks = new List<Fork>();
            Philosophers = new List<Philosopher>();

            // Initialize forks: each fork initially belongs to the higher-numbered philosopher
            for (int i = 0; i < count; i++)
            {
                int higher = Math.Max(i, (i + 1) % count);
                Forks.Add(new Fork(i, higher));
            }

            for (int i = 0; i < count; i++)
                Philosophers.Add(new Philosopher(i, this));
        }

        public int LeftOf(int id) => (id + Count - 1) % Count;
        public int RightOf(int id) => (id + 1) % Count;
    }

    class Philosopher
    {
        private readonly int id;
        private readonly Table table;
        private readonly Random rand = new Random();
        private readonly HashSet<int> heldForks = new HashSet<int>();

        public Philosopher(int id, Table table)
        {
            this.id = id;
            this.table = table;
        }

        public void Live()
        {
            while (true)
            {
                Think();
                RequestForks();
                Eat();
            }
        }

        private void Think()
        {
            Console.WriteLine($"Philosopher {id} is thinking.");
            Thread.Sleep(rand.Next(1000, 2000));
        }

        private void RequestForks()
        {
            int left = table.LeftOf(id);
            int right = id;

            AcquireFork(left);
            AcquireFork(right);
        }

        private void AcquireFork(int forkId)
        {
            Fork fork = table.Forks[forkId];
            lock (fork)
            {
                if (fork.OwnerId != id)
                {
                    Console.WriteLine($"Philosopher {id} requests fork {forkId} from Philosopher {fork.OwnerId}");
                    PassFork(fork, id);
                }

                heldForks.Add(forkId);
            }
        }

        private void PassFork(Fork fork, int newOwner)
        {
            // Clean fork before passing
            if (fork.IsDirty)
            {
                Console.WriteLine($"Philosopher {fork.OwnerId} cleans fork {fork.Id} before passing.");
                fork.IsDirty = false;
            }

            Console.WriteLine($"Fork {fork.Id} passed from Philosopher {fork.OwnerId} to Philosopher {newOwner}");
            fork.OwnerId = newOwner;
        }

        private void Eat()
        {
            int left = table.LeftOf(id);
            int right = id;

            if (heldForks.Contains(left) && heldForks.Contains(right))
            {
                Console.WriteLine($"Philosopher {id} starts eating.");
                Thread.Sleep(rand.Next(1000, 1500));
                Console.WriteLine($"Philosopher {id} finished eating.");

                // Mark forks dirty after eating
                lock (table.Forks[left]) table.Forks[left].IsDirty = true;
                lock (table.Forks[right]) table.Forks[right].IsDirty = true;

                ReleaseForks();
            }
        }

        private void ReleaseForks()
        {
            foreach (var forkId in heldForks)
            {
                Fork fork = table.Forks[forkId];
                lock (fork)
                {
                    int leftNeighbor = table.LeftOf(id);
                    int rightNeighbor = table.RightOf(id);

                    // Decide who to pass fork to
                    int neighbor = (fork.Id == id) ? rightNeighbor : leftNeighbor;
                    if (neighbor != id)
                    {
                        PassFork(fork, neighbor);
                    }
                }
            }

            heldForks.Clear();
        }
    }
}
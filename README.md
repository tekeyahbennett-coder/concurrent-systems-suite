# Concurrent Systems Suite

A collection of operating systems programming projects and written essays implementing classic OS algorithms and concepts in C#. Built for COP4610 (Operating Systems) at Daytona State College.

## Programming Projects

### 1. Dining Philosophers — Chandy-Misra Solution
**Folder:** `Chandy and Misra/`

Solves the classic concurrency problem with 5 philosophers using the Chandy-Misra algorithm. Prevents deadlock and starvation without a central coordinator.

- Thread-safe fork ownership using dirty/clean state tracking
- Lock-based synchronization to prevent deadlock and starvation
- Full philosopher lifecycle: thinking → requesting → eating → releasing
- 5 concurrent threads, one per philosopher

### 2. FIFO Demand Paging Simulator
**Folder:** `Programming A1/`

Simulates virtual memory management using First-In-First-Out (FIFO) page replacement. Tests how different page sizes affect performance.

- Runs 3 simulations: page size 100 words, 20 words, and 200 words (all with 200-word main memory)
- Calculates page hit rates, page fault rates, and performance tradeoffs
- Educational console output explaining the impact of page size on efficiency
- Reference string: 10, 11, 104, 170, 73, 309, 185, 245, 246, 434, 458, 364

### 3. FCFS CPU Scheduling
**Folder:** `Programming Assignment 2- Operating Systems/`

Implements First-Come-First-Served (FCFS) process scheduling with user-supplied input.

- Accepts any number of processes with custom burst times
- Calculates completion time, turnaround time, and waiting time per process
- Computes average turnaround time and average waiting time across all processes

### 4. Producer-Consumer Synchronization
**Folder:** `TeKeyah Bennett A4/`

Solves the classic bounded buffer problem using semaphores and a mutex lock.

- Semaphore-based coordination: `emptyCount` (5 slots) and `fillCount`
- `bufferLock` mutex for exclusive critical section access
- Producer and Consumer run as separate threads
- Circular buffer with size 5; producer generates 20 items, consumer processes 20 items thread-safely

## Discussion Essays

| File | Topic |
|---|---|
| `TeKeyah Bennett DE 1.docx` | Memory Management — fixed partitioning, internal fragmentation, relocation, and memory protection in early OS |
| `TeKeyah Bennett DE 2.docx` | Resource Allocation Graphs — deadlock detection using resource and process node diagrams |
| `TeKeyah Bennett DE 3.docx` | Working Directories, File Access Control Lists (ACLs), and capability-based security models |

## Repository Structure

```
concurrent-systems-suite/
├── Chandy and Misra/              # Dining Philosophers project
│   ├── Chandy and Misra/
│   │   └── Program.cs             # Main implementation (180 lines)
│   └── Chandy and Misra.sln
├── Programming A1/                # FIFO Demand Paging project
│   ├── Programming A1/
│   │   └── Program.cs             # Paging simulator (86 lines)
│   └── Programming A1.sln
├── Programming Assignment 2- Operating Systems/   # FCFS Scheduling project
│   ├── Programming Assignment 2- Operating Systems/
│   │   └── Program.cs             # Scheduling simulator (66 lines)
│   └── Programming Assignment 2- Operating Systems.sln
├── TeKeyah Bennett A4/            # Producer-Consumer project
│   ├── TeKeyah Bennett A4/
│   │   └── Program.cs             # Sync implementation (71 lines)
│   └── TeKeyah Bennett A4.sln
├── TeKeyah Bennett DE 1.docx      # Discussion Essay 1 — Memory Management
├── TeKeyah Bennett DE 2.docx      # Discussion Essay 2 — Resource Allocation Graphs
├── TeKeyah Bennett DE 3.docx      # Discussion Essay 3 — Working Directories & ACLs
├── Chandy and Misra.zip           # Zipped project archive
├── Programming Assignment 2- Operating Systems.zip
├── TeKeyah Bennett A4.zip
└── README.md
```

## Tech Stack

| Category | Details |
|---|---|
| Language | C# / .NET 8 |
| IDE | Visual Studio 2022 |
| Concurrency | System.Threading (Thread, SemaphoreSlim, lock) |
| Concepts | Threading, semaphores, mutexes, memory paging, CPU scheduling, deadlock prevention |
| Course | COP4610 — Operating Systems, Daytona State College |

## How to Run

1. Open any project folder in **Visual Studio 2022**
2. Open the `.sln` solution file
3. Press **F5** or click **Run** to build and execute
4. For FCFS Scheduling, enter the number of processes and burst times when prompted

## Author

**Te'Keyah Bennett** — [GitHub](https://github.com/tekeyahbennett-coder)

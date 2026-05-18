# Concurrent Systems Suite

A collection of operating systems programming projects implementing classic OS algorithms in C#.

## Projects Included

### 1. Dining Philosophers (Chandy-Misra Solution)
Solves the classic concurrency problem with 5 philosophers using the Chandy-Misra algorithm.
- Thread-safe fork ownership with dirty/clean tracking
- Lock-based synchronization to prevent deadlock and starvation
- Full philosopher lifecycle: thinking → requesting → eating → releasing

### 2. FIFO Demand Paging Simulator
Simulates virtual memory management with page replacement.
- Tests multiple page sizes (20, 100, 200 words) against fixed memory (200–400 words)
- Calculates page hit rates, fault rates, and performance tradeoffs
- Educational output explaining the impact of page size on efficiency

### 3. FCFS CPU Scheduling
Implements First-Come-First-Served process scheduling.
- Calculates completion time, turnaround time, and waiting time per process
- Computes average performance metrics across all processes

### 4. Producer-Consumer Synchronization
Classic bounded buffer problem with proper synchronization primitives.
- Semaphore-based coordination (emptyCount, fillCount)
- Mutex lock for critical section (buffer access)
- Producer generates 20 items; Consumer processes 20 items thread-safely

## Tech Stack

- **Language:** C# / .NET
- **Concepts:** Threading, semaphores, mutexes, memory management, CPU scheduling

## How to Run

Open each project in Visual Studio 2022 and run the solution.

## Author

Te'Keyah Bennett — [GitHub](https://github.com/tekeyahbennett-coder)

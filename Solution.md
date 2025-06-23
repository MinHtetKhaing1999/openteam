## Solution notes

### Task 01 – Run‑Length Encoder (Algorithms & Data Structures)
- Language: C#

- Approach: Iterated through the input string, maintaining a count of consecutive characters using Rune. When the current character differed from the previous, appended the character and count to the result.

- Why: I don't need to consider about UTF-8 by using Rune and provides linear time performance (O(n)).

- Time spent: ~15 min

- AI tools used: ChatGPT


### Task 02 – Fix‑the‑Bug (Thread Safety)
- Language: C#

- Approach: Replaced the non-thread-safe shared Dictionary with a ConcurrentDictionary, ensuring thread-safe access across multiple threads.

- Why: ConcurrentDictionary is designed specifically for concurrent scenarios, avoiding race conditions without needing explicit locking.

- Time spent: ~ 10 min

- AI tools used: None

### Task 03 – Sync Aggregator (Concurrency & I/O)
- Language: C#

- Approach: Implemented worker tasks using SemaphoreSlim to limit concurrency. Each task reads a file and processes results, using Task.WhenAll to aggregate.

- Why: Balances efficiency and control—limits system resource use while maintaining parallelism. Exception handling and cancellation were also managed.

- Time spent: ~60 min

- AI tools used: ChatGPT

### Task 04 – SQL Reasoning (Data Analytics & Index Design)
Language: C#

Approach: Used a CTE with ROW_NUMBER() and COUNT(*) and WITH for temp tables to compute the 90th percentile pledge amount using the nearest-rank method. Proposed adding index on campaign_id, donor_id foreign keys of the table pledge for faster query.

Why: 

Time spent: ~60 min

AI tools used: ChatGPT


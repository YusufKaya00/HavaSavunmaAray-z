## 2024-05-18 - C# LOH Fragmentation in High-Frequency Loops
**Learning:** Re-allocating large byte arrays (e.g., 1.2MB image frames) inside a high-frequency `while (true)` loop causes severe Large Object Heap (LOH) fragmentation and high Garbage Collection (GC) pressure in C#, as arrays larger than 85,000 bytes are allocated directly on the LOH.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside of processing loops and reuse them to prevent GC pauses and memory exhaustion when dealing with uncompressed video frames via shared memory.

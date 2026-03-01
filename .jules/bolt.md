## 2024-05-27 - Shared Memory Allocation
**Learning:** In C# applications reading continuously from `MemoryMappedFile` via `while (true)` loops, placing `CreateViewAccessor()` calls and allocating fixed-size byte arrays inside the loop causes massive garbage collection overhead (over 100MB/sec), significantly dropping application performance.
**Action:** Always allocate fixed-size structures, arrays, and accessors outside of high-frequency reading loops and reuse them across iterations to minimize GC pressure and ensure stable framerates.

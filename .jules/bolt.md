## 2025-03-13 - GC Allocation Overhead in High-Frequency C# Loops
**Learning:** Instantiating large byte arrays inside a high-frequency `while (true)` loop (running every ~15ms) generates an enormous amount of garbage (~144MB/s), severely increasing GC pressure and affecting application performance. Repeatedly creating `CreateViewAccessor` objects for `MemoryMappedFile` adds further I/O overhead.
**Action:** Lift buffer allocations and accessor creation outside of tight loops to reuse them. Pre-allocating buffers and retaining view accessors significantly reduces memory churn.

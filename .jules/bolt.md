## 2026-05-26 - Optimize Shared Memory Buffers
**Learning:** In C#, reallocating large byte arrays inside high-frequency loops (like reading frames from shared memory at 60fps) causes severe Large Object Heap fragmentation and GC pressure.
**Action:** Pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside the while loop.

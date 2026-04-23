## 2024-05-24 - Pre-allocating buffers for high-frequency frame processing
**Learning:** In C#, instantiating large arrays (like uncompressed 1.2MB image frames) inside a high-frequency loop (e.g., 60fps video processing) causes severe GC pressure and Large Object Heap (LOH) fragmentation, severely impacting performance.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency processing loops (such as `while(true)` reading shared memory).

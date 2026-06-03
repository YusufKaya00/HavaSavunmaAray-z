## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-06-03 - C# Shared Memory UI Updates
**Learning:** Calling `Invoke` synchronously in high-frequency background loops (e.g. ~60fps) blocks the loop on UI threads, causing major performance bottlenecks when rendering video frames read from shared memory.
**Action:** Use asynchronous `BeginInvoke` and combine multiple UI updates into a single call to prevent blocking high-frequency background loops.

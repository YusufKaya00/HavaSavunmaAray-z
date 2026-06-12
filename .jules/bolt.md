## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-06-12 - C# UI Updates in High-Frequency Loops
**Learning:** In C# applications reading uncompressed video frames at high frequencies (~60fps), using multiple synchronous `Invoke` calls for UI updates within the background processing loop blocks the thread and causes performance degradation.
**Action:** Always combine UI updates and use asynchronous `BeginInvoke` to prevent blocking the high-frequency reading loop.

## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-06-16 - Combine synchronous UI Updates in High-Frequency C# Threads
**Learning:** In C# applications processing high-frequency data (~60fps) on a background thread, using synchronous `Invoke` calls to update the UI blocks the processing thread, causing severe performance bottlenecks. Two separate `Invoke` calls for different components (e.g. `pictureBox2` and `pictureBox3`) further compound cross-thread marshalling overhead.
**Action:** Combine UI updates and use asynchronous `BeginInvoke` when updating the UI from a high-frequency background thread to prevent blocking and minimize cross-thread overhead.

## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-29 - Asynchronous UI Updates in High-Frequency Loops
**Learning:** Using synchronous `Invoke` calls to update the UI from a background thread processing high-frequency data (like 60fps video frames) blocks the background thread, degrading performance and throughput.
**Action:** Always combine UI updates and use asynchronous `BeginInvoke` to ensure the high-frequency background processing loop remains unblocked.

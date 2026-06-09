## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-04 - C# UI Update Optimization in High-Frequency Loops
**Learning:** Calling synchronous `Invoke` repeatedly for multiple UI elements within a high-frequency (e.g., 60fps) background thread that reads from shared memory blocks the background thread and increases cross-thread context switches, which lowers overall throughput.
**Action:** Combine multiple UI updates (e.g., updating multiple PictureBox images) into a single batch and use asynchronous `BeginInvoke` instead of synchronous `Invoke` to maintain high processing throughput.

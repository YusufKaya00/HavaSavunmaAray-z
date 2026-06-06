## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-17 - Asynchronous UI Updates in High-Frequency Loops
**Learning:** In C# applications reading high-frequency video frames (~60fps) from shared memory in a background thread, using synchronous `Invoke` calls to update the UI components blocks the background thread until the UI thread finishes processing. This drastically reduces the rate at which frames can be read and causes jitter.
**Action:** Always combine UI updates and use asynchronous `BeginInvoke` instead of multiple synchronous `Invoke` calls to prevent blocking the high-frequency background processing loop and improve overall throughput.

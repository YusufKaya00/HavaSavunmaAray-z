## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-06-02 - UI Thread Blocking in Background Loops
**Learning:** In C# WinForms applications processing high-frequency data (like 60fps video frames) in a background thread, using synchronous `Invoke` calls for UI updates blocks the processing loop until the UI thread completes rendering, severely degrading performance.
**Action:** Combine related UI updates into a single asynchronous `BeginInvoke` call to prevent the background loop from waiting on the UI thread, reducing context switches and improving throughput.

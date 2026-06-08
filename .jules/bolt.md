## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-04 - C# WinForms UI Update Optimization
**Learning:** In high-frequency background loops processing data like 60fps video frames, using synchronous `Invoke` calls to update the UI forces the background thread to block and wait for the main UI thread, causing sluggishness and reduced throughput. Multiple `Invoke` calls compound this issue.
**Action:** Always batch related UI updates together and use the asynchronous `BeginInvoke` method instead. This makes the UI update fire-and-forget, allowing the background high-frequency loop to run at full speed without waiting on the UI thread.

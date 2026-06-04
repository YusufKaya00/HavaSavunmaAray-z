## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-06-04 - C# UI Thread Blocking in High Frequency Loops
**Learning:** In C# WinForms applications processing high-frequency events (like reading 60fps video frames from shared memory in a background thread), making synchronous `Invoke` calls to update UI controls causes the background thread to block and wait for the UI thread, severely degrading performance.
**Action:** Combine related UI updates into a single batch and use asynchronous `BeginInvoke` instead of `Invoke` to decouple the background processing thread from the UI rendering cycle.

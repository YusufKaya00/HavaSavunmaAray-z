## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-06-07 - Batch UI Updates in C# WinForms
**Learning:** In C# WinForms applications processing high-frequency video frames from shared memory, performing separate, synchronous `Invoke` calls for each UI component (e.g., updating multiple PictureBox images) severely blocks the high-frequency image processing thread.
**Action:** Combine UI updates for multiple components into a single batch and use asynchronous `BeginInvoke` instead of synchronous `Invoke` to avoid blocking the background processing loop.

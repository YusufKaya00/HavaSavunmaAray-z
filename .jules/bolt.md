## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-04 - C# WinForms High-Frequency UI Updates
**Learning:** In C# WinForms applications reading uncompressed video frames at high frequencies (~60fps) from shared memory via background loops, using synchronous `Invoke` for updating UI controls sequentially will block the high-frequency thread and cause processing delays or frame drops.
**Action:** Use asynchronous `BeginInvoke` and combine multiple UI updates (like setting multiple PictureBox images) into a single call to unblock the high-frequency loop.

## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-18 - C# WinForms UI Updates in High-Frequency Loops
**Learning:** Calling synchronous `Invoke()` to update UI elements (like PictureBox images) within a high-frequency background loop processing large frames blocks the background thread. This bottleneck throttles the processing rate and can lead to UI freezes, defeating the purpose of reading from shared memory in a background thread.
**Action:** Replace synchronous `Invoke()` with asynchronous `BeginInvoke()` when continuously pushing data from high-frequency background loops to the UI thread, ensuring the background thread is never blocked waiting for the UI to paint.

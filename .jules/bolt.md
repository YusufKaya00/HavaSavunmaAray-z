## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-06-13 - C# WinForms High-Frequency UI Updates
**Learning:** In C# WinForms applications, synchronous `Invoke` calls for updating UI elements within a high-frequency background loop (e.g., reading video frames at ~60fps) block the background thread, degrading the video processing rate.
**Action:** Always use asynchronous `BeginInvoke` instead of `Invoke` for UI updates inside high-frequency background threads to prevent blocking and improve throughput.

## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2026-06-20 - Asynchronous UI Updates from High-Frequency Background Loops
**Learning:** In C# WinForms applications running high-frequency data ingestion loops (e.g., ~60fps video frames from shared memory), using synchronous `Invoke` to dispatch UI updates from a background thread severely blocks the ingestion loop, as it waits for the UI thread to complete rendering.
**Action:** Combine multiple UI updates within a single dispatch and use asynchronous `BeginInvoke` to prevent blocking the high-frequency background loop and maintain throughput.

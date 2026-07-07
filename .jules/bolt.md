## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-07-07 - C# WinForms High-Frequency Shared Memory Loops
**Learning:** Using synchronous `Invoke` in a high-frequency `while (true)` shared memory read loop (e.g., ~60fps) blocks the background thread and quickly floods the WinForms message queue if the UI cannot keep up, leading to `OutOfMemoryException` and extreme lag.
**Action:** When updating the UI from a high-frequency background loop, use `BeginInvoke` (asynchronous) combined with an atomic flow control flag (e.g., `isUpdatingUI`) to deliberately drop frames. This prevents message queue flooding and keeps the background processing thread running at full speed without blocking.

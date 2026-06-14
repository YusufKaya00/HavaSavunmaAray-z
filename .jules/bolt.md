## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-04 - WinForms UI Blocking in High-Frequency Loops
**Learning:** Using synchronous `Invoke` calls to update the UI from a background loop reading high-frequency video frames (~60fps) blocks the loop while waiting for the UI thread to paint, leading to missed frames and reduced throughput.
**Action:** Always combine related UI updates and use asynchronous `BeginInvoke` instead of `Invoke` when pumping data from a high-frequency background worker to the WinForms UI thread.

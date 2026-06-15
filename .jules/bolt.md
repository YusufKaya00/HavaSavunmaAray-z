## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2025-06-15 - WinForms UI Blocking Optimization
**Learning:** In C# WinForms applications processing high-frequency data in background loops, using synchronous `Invoke` calls for multiple UI updates blocks the background thread until the UI thread is free, creating significant bottlenecks.
**Action:** Combine UI updates and use asynchronous `BeginInvoke` instead of multiple `Invoke` calls to prevent blocking the high-frequency background loops.

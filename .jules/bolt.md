## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-04 - C# UI Update Loop Optimizations
**Learning:** Using multiple synchronous `Invoke` calls within a high-frequency background loop reading memory mapped frames can block the background thread unnecessarily and throttle overall throughput since the background thread has to wait for UI rendering.
**Action:** Consolidate UI updates inside high-frequency loops into single blocks and use `BeginInvoke` instead of `Invoke` so that the background thread isn't blocked by the UI render cycle.

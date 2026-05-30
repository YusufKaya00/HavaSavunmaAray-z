## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-30 - C# Shared Memory Optimizations (UI Updates)
**Learning:** Using synchronous `Invoke` calls inside a high-frequency background loop reading from shared memory blocks the loop until the UI thread finishes rendering, severely reducing throughput. Furthermore, making multiple separate `Invoke` calls (e.g., for different PictureBox components) multiplies this delay.
**Action:** Always combine related UI updates into a single call, and use asynchronous `BeginInvoke` instead of synchronous `Invoke` when updating the UI from a high-frequency background processing loop.

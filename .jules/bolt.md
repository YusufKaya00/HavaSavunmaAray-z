## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-06-19 - C# WinForms Cross-Thread UI Updates
**Learning:** In C# applications where a high-frequency background thread updates the UI (e.g., rendering ~60fps video frames), using synchronous `Invoke` calls forces the background thread to wait for the UI thread to complete rendering. This causes a major performance bottleneck. Furthermore, making multiple distinct `Invoke` calls per frame increases context switching overhead.
**Action:** Combine UI updates into a single block and use asynchronous `BeginInvoke` to ensure the background processing thread is never blocked waiting for the UI to paint.

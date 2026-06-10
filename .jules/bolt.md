## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-17 - C# Asynchronous UI Updates
**Learning:** Synchronous `Invoke` calls in high-frequency background loops (like video processing at 60fps) block the background thread, causing stutter, dropped frames, and excessive context switching.
**Action:** Use `BeginInvoke` to schedule UI updates asynchronously, and combine multiple UI component updates into a single `BeginInvoke` block to significantly reduce UI thread marshalling overhead.

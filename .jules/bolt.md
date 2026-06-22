## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-18 - C# WinForms UI Update Optimization
**Learning:** In high-frequency background processing loops (like reading ~60fps video frames), using synchronous `Invoke` calls to update the UI blocks the background thread and limits maximum throughput. Calling `Invoke` multiple times per frame also causes redundant context switching overhead.
**Action:** Combine multiple UI component updates into a single UI thread context switch and use asynchronous `BeginInvoke` to ensure the background processing loop remains unblocked and fast.
## 2024-05-18 - C# WinForms Message Queue Flooding
**Learning:** Using `BeginInvoke` in a high-frequency background loop without flow control can flood the WinForms message queue and cause an `OutOfMemoryException` if the UI thread falls behind the loop speed, causing `Action` delegates and Bitmaps to pile up.
**Action:** Always implement a boolean flag (e.g., `isUpdatingUI`) to drop frames if the UI is still processing a previous frame, ensuring the message queue remains manageable.

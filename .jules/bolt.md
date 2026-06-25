## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-03 - C# WinForms Message Queue Flooding in High-Frequency Loops
**Learning:** In C# WinForms applications processing high-frequency data streams (e.g., ~60fps uncompressed video frames via shared memory), using synchronous `Invoke` calls within the background `while (true)` processing loop rapidly floods the UI message queue. This causes significant memory bloat (`OutOfMemoryException`) as the queue backs up faster than the UI thread can process.
**Action:** When updating the UI from a high-frequency background loop, combine UI updates, use asynchronous `BeginInvoke`, and implement a flow control mechanism (like a volatile `isUpdatingUI` boolean flag). Skip frame rendering (drop frames) and immediately dispose of unneeded `Bitmap` objects if the UI thread is still processing the previous update.

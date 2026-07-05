## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2025-02-12 - Prevent WinForms Queue Flooding with UI Updates
**Learning:** Using synchronous `Invoke` in a high-frequency (~60fps) background thread (e.g. processing video frames) can block the background thread, causing stuttering. On the other hand, using `BeginInvoke` blindly can flood the WinForms message queue faster than the UI thread can process it, which eventually leads to memory bloat and `OutOfMemoryException`.
**Action:** When updating UI from high-frequency background loops, combine updates into a single `BeginInvoke` and use a flow-control flag (e.g. `isUpdatingUI`) to drop frames on the background thread if the UI thread is still processing the previous update. This keeps memory usage low and the application responsive.

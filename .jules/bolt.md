## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.

## 2024-05-04 - C# WinForms High-Frequency UI Updates
**Learning:** Sequential synchronous `Invoke` calls and unconditional Bitmap processing within high-frequency loops (e.g., ~60fps video processing) can block the background thread, flood the WinForms message queue, and cause UI freezing and memory bloat.
**Action:** Use an asynchronous `BeginInvoke` combined with a flow-control flag (e.g., `_isUpdatingUI`) to drop frames/skip expensive UI-bound allocations when the UI thread is busy, and unify updates into a single lambda.

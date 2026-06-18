## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-04 - C# UI Thread Sync Safety in High-Frequency Loops
**Learning:** Using `BeginInvoke` (asynchronous) for UI updates inside a high-frequency background loop removes necessary backpressure. If the UI thread is busy, unbounded `BeginInvoke` calls will continuously queue up un-garbage-collected `Bitmap` objects, leading to severe memory leaks and eventual `OutOfMemoryException`.
**Action:** Always prefer a single, grouped synchronous `Invoke` call over `BeginInvoke` in high-frequency loops unless explicit frame dropping or bounded queue management is implemented.

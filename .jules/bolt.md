## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-04 - C# WinForms UI Thread Flow Control
**Learning:** In C# WinForms, when processing high-frequency video frames (~60fps) in a background thread, using synchronous `Invoke` for UI updates, or even asynchronous `BeginInvoke` without flow control, can flood the message queue. This leads to memory bloat and `OutOfMemoryException`.
**Action:** When updating UI elements from a high-frequency background loop, use a `volatile bool isUpdatingUI` flag to implement flow control (dropping frames if the UI is busy) and combine multiple UI updates into a single asynchronous `BeginInvoke` call.

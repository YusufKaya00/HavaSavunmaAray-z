## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-19 - C# WinForms UI Thread Blocking
**Learning:** In C# WinForms applications, using synchronous `Invoke()` to append logs or update UI from high-frequency background threads (e.g., those reading from memory mapped files or polling processes) blocks the background thread until the UI thread processes the message. This causes significant performance bottlenecks.
**Action:** Always use asynchronous `BeginInvoke()` for non-critical UI updates (like appending logs) from high-frequency background loops to allow the background thread to continue processing immediately.

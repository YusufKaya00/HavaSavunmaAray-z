## 2024-05-03 - C# Shared Memory Optimizations
**Learning:** In C# applications reading uncompressed video frames (1.2MB each) at high frequencies (~60fps) from shared memory via `MemoryMappedFile`, instantiating large `byte[]` buffers and `CreateViewAccessor()` instances inside the processing loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` objects outside the `while (true)` loops and reuse them across iterations to maintain performance.
## 2024-05-27 - C# WinForms UI Updates
**Learning:** In C# WinForms applications processing video frames from shared memory, using `Invoke` to update UI elements (like `pictureBox.Image`) blocks the background processing thread until the UI finishes painting, capping the frame rate.
**Action:** Use `BeginInvoke` instead of `Invoke` to push updates asynchronously, freeing up the background thread to immediately fetch the next frame, vastly improving throughput.

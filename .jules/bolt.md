## 2024-05-06 - Initial Analysis
**Learning:** Found an OpenCvSharp4 WinForms application passing large frames via shared memory. Need to examine Form1.cs for high-frequency loops or GC pressure from large byte arrays.
**Action:** Review Form1.cs and how video frames/MemoryMappedFiles are read.
## 2024-05-06 - WinForms Shared Memory Allocation Overhead
**Learning:** Found an infinite loop in ReadSharedMemory allocating `new byte[FrameWidth * FrameHeight * 3]` (approx 1.2MB) and creating `ViewAccessor` objects *twice* per iteration (for raw and processed frames). This causes extreme Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Move the byte array allocations and `CreateViewAccessor()` calls outside the `while (true)` loop and reuse them.

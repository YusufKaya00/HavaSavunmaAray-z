
## 2024-03-21 - High-Frequency Shared Memory Buffer Allocation
**Learning:** In C# WinForms applications processing uncompressed video frames via Shared Memory at high frequencies (~60fps), continuously allocating large byte arrays (~1.2MB each) and recreating `MemoryMappedViewAccessor` inside the processing loop causes severe Large Object Heap (LOH) fragmentation and massive Garbage Collection (GC) pressure.
**Action:** Always pre-allocate large byte arrays and `CreateViewAccessor` instances outside of `while (true)` loops for shared memory reads to reuse the buffers, minimizing memory churn and keeping the application performant.

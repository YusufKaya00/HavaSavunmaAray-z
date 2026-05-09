## 2024-05-09 - C# WinForms Shared Memory LOH Fragmentation
**Learning:** High-frequency video processing from MemoryMappedFile shared memory allocating large byte arrays (~1.2MB for 640x640x3) and creating `MemoryMappedViewAccessor` inside `while(true)` loops causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency processing loops to prevent LOH fragmentation and reduce GC pressure.

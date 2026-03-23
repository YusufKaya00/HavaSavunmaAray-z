
## 2024-05-28 - LOH Fragmentation from High-Frequency Shared Memory Reads
**Learning:** Instantiating `MemoryMappedViewAccessor` and ~1.2MB `byte[]` arrays inside a ~60fps video processing loop creates ~144MB/sec of large object allocations, leading to severe Large Object Heap (LOH) fragmentation and Garbage Collection (GC) pressure in C# WinForms applications.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency `while (true)` processing loops.

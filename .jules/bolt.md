## 2024-04-05 - Avoid Pre-Frame Large Object Allocation in Shared Memory
**Learning:** The application processes uncompressed video frames via memory-mapped files at high frequency. Allocating large byte arrays (~1.2MB) and creating `MemoryMappedViewAccessor` instances inside the read loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency processing loops to avoid excessive GC overhead and ensure stable performance.

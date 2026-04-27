## 2024-04-27 - LOH Fragmentation in High-Frequency C# Loops
**Learning:** Allocating large byte arrays (e.g. uncompressed video frames at 1.2MB each) inside high-frequency loops (~60fps) causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency processing loops.

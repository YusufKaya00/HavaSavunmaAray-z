## 2024-05-23 - Shared Memory Buffer Allocation and LOH Fragmentation
**Learning:** In C#, continually allocating large byte arrays (e.g., `byte[] rawBuffer = new byte[FrameWidth * FrameHeight * 3];` which is ~1.2MB for a typical HD frame) inside a high-frequency loop (~60fps) causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation.
**Action:** Pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside the `while(true)` reading loop to reuse them and reduce GC overhead.

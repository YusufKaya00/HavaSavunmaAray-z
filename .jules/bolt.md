## 2024-05-24 - High-Frequency Large Allocations
**Learning:** Allocating large byte arrays (~1.2MB for 640x640x3 frames) inside a high-frequency `while (true)` loop creates significant Garbage Collection pressure and Large Object Heap (LOH) fragmentation in C#, potentially degrading long-running performance.
**Action:** When working with high-frequency image streaming or shared memory in C#, always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside the loop and reuse them to avoid LOH issues and GC spikes.

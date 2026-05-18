## 2024-05-24 - LOH Fragmentation in MemoryMappedFiles
**Learning:** In C#, continually allocating large byte arrays inside a high-frequency (e.g., 60fps) loop reading from `MemoryMappedFile` causes severe Large Object Heap (LOH) fragmentation and triggers massive GC spikes. Creating `MemoryMappedViewAccessor` in tight loops is also an expensive allocation that impacts frame rate processing.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances *outside* the loop and reuse them when processing streaming video or memory mapped structures.

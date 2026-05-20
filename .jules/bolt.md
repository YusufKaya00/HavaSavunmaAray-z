## 2024-05-24 - Pre-allocate MemoryMappedViewAccessor and buffers for high-frequency video processing
**Learning:** Re-creating MemoryMappedViewAccessor and large byte arrays (e.g., 1.2MB uncompressed frames) inside a while loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation in C#.
**Action:** Always pre-allocate and reuse large byte arrays and MemoryMappedViewAccessor instances outside of high-frequency processing loops (like video frame reading) to avoid GC thrashing.

## 2024-05-24 - Pre-allocating buffers for high-frequency processing
**Learning:** High-frequency (e.g., 60fps) processing of uncompressed video frames (approx 1.2MB each) using `MemoryMappedViewAccessor` and byte arrays within a continuous loop causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation in C#.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency processing loops to avoid excessive object creation and LOH allocations.

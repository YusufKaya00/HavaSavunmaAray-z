## 2024-05-05 - Avoid LOH Allocation in High-Frequency Loops
**Learning:** High-frequency video frame processing (~60fps) from shared memory triggers severe LOH (Large Object Heap) fragmentation and GC pressure when byte arrays (>85KB) and `MemoryMappedViewAccessor` instances are instantiated inside the `while(true)` loop.
**Action:** Pre-allocate large byte arrays and `CreateViewAccessor` objects outside of any high-frequency processing loops to minimize overhead and prevent GC pauses.

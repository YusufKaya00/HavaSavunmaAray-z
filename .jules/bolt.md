
## 2025-03-24 - Optimize shared memory frame buffer allocation
**Learning:** Large arrays (like 1.2MB image buffers) created within high-frequency operations (like a 60fps video read loop) directly hit the Large Object Heap (LOH), leading to rapid LOH fragmentation, severe GC pressure, and frame drops. `MemoryMappedViewAccessor` creation is also an unmanaged resource setup that adds unnecessary overhead per frame.
**Action:** Always pre-allocate large byte buffers and `MemoryMappedViewAccessor` instances *outside* of the high-frequency loop and reuse them across iterations when reading from memory-mapped files.

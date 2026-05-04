## 2024-05-04 - Pre-allocating Shared Memory Buffers
**Learning:** High-frequency loop allocating ~1.2MB byte arrays (`new byte[FrameWidth * FrameHeight * 3]`) per frame causes severe GC pressure and LOH fragmentation, tanking performance. Additionally, instantiating `MemoryMappedViewAccessor` per frame is very expensive.
**Action:** Always pre-allocate large byte arrays and reuse `MemoryMappedViewAccessor` instances outside the `while(true)` loop when reading high-frequency shared memory data.

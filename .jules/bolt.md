## 2024-05-18 - C# Large Object Heap (LOH) Fragmentation Avoidance
**Learning:** Pre-allocating large arrays (like ~1.2MB buffers for high-fps OpenCV frame processing) inside of high-frequency loops (like `while(true)` reading `MemoryMappedFiles`) causes severe GC pressure and LOH fragmentation in C#.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency loops to keep memory usage stable and performance fast.

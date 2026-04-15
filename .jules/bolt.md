
## 2024-04-15 - Optimizing High-Frequency Video Frame Processing
**Learning:** Pre-allocating large byte arrays (e.g., `byte[] rawBuffer = new byte[FrameWidth * FrameHeight * 3]`) inside a high-frequency `while(true)` loop causes extreme GC pressure and Large Object Heap (LOH) fragmentation in C#, drastically dropping FPS when reading memory-mapped files at 60fps.
**Action:** Always extract buffer instantiations and `MemoryMappedViewAccessor` creation out of high-frequency continuous loops when working with shared memory/video processing in C#.


## 2024-05-28 - Avoid LOH Fragmentation in High-Frequency C# Loops
**Learning:** Instantiating large byte arrays (e.g. uncompressed 640x640x3 image buffers ~1.2MB) inside a high-frequency (60fps) `while (true)` loop causes extreme Large Object Heap (LOH) fragmentation and continuous Garbage Collection (GC) pauses in C#.
**Action:** Always pre-allocate large byte arrays and object instances (like `MemoryMappedViewAccessor`) *outside* of tight rendering or data-processing loops, reusing the same instances on every iteration.

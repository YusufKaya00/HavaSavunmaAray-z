## 2024-05-24 - [Avoid Large Object Heap Fragmentation in WinForms Video Loops]
**Learning:** In a C# WinForms application heavily utilizing `MemoryMappedFile`s for ~60fps video frames (like OpenCV raw arrays), initializing large `byte[]` buffers (1.2MB+) inside a high-frequency loop rapidly increases Garbage Collection (GC) pressure and causes Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside the `while(true)` loops when processing shared memory frames.

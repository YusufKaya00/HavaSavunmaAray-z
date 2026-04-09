## 2024-04-09 - High-Frequency Shared Memory Reads causing LOH Fragmentation
**Learning:** Re-creating `MemoryMappedViewAccessor` and allocating large byte arrays (e.g., 1.2MB for 640x640x3 frames) inside a fast `while (true)` loop causes extreme Garbage Collection pressure and Large Object Heap (LOH) fragmentation in C#.
**Action:** Always pre-allocate large buffers and shared memory accessors outside of high-frequency polling/reading loops.

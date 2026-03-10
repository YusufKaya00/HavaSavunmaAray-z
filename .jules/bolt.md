## 2024-03-10 - Reduce Shared Memory Allocations
**Learning:** Re-creating `ViewAccessor` objects and allocating large byte arrays (e.g., 640x640x3 = 1.2MB) inside a tight `while(true)` video processing loop causes immense GC pressure and degrades performance.
**Action:** Always instantiate large buffers and reusable MemoryMappedFile accessors OUTSIDE of high-frequency rendering loops.

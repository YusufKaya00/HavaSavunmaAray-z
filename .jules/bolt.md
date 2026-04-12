## 2024-04-12 - Prevent LOH Fragmentation on WinForms Shared Memory Frames
**Learning:** In the high-frequency C# shared memory pipeline, allocating `new byte[1.2MB]` arrays inside a tight 15ms `while(true)` loop causes extreme GC pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always pre-allocate large buffers and `CreateViewAccessor()` instances outside of continuous processing loops.

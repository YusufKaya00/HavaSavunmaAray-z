## 2024-05-18 - C# Shared Memory Loops causing GC pressure
**Learning:** High-frequency memory-mapped file access loops (like 60fps video processing) suffer severely if large buffers (`new byte[FrameWidth * FrameHeight * 3]`, approx 1.2MB) and view accessors are allocated inside the loop, leading to immediate Large Object Heap (LOH) fragmentation.
**Action:** Always hoist byte array allocations and `MemoryMappedViewAccessor` creation outside of the `while (true)` loop and reuse the buffers.

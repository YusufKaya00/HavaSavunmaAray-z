## 2025-05-13 - [Preallocate large buffers and ViewAccessors to prevent LOH fragmentation]
**Learning:** Instantiating large byte arrays (e.g., `new byte[FrameWidth * FrameHeight * 3]`, which is `640 * 640 * 3 = ~1.2MB`) and `MemoryMappedViewAccessor` instances inside a high-frequency `while (true)` loop causes immense Garbage Collection pressure and severe Large Object Heap (LOH) fragmentation.
**Action:** Always preallocate large buffers and accessor instances outside of high-frequency loops and reuse them inside the loop.

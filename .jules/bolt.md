## 2024-05-24 - Pre-allocating large buffers in high-frequency video processing
**Learning:** Instantiating 1.2MB `byte[]` arrays inside a ~60fps `while (true)` loop causes severe Garbage Collection pressure and Large Object Heap (LOH) fragmentation in C# due to the ~2.4MB per frame allocations.
**Action:** Always pre-allocate and reuse large `byte[]` arrays outside of high-frequency loops in the video processing thread to minimize GC pressure and improve application stability.

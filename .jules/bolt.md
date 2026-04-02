## 2024-03-24 - Pre-allocating large byte arrays to reduce GC/LOH pressure
**Learning:** In high-frequency loops (like processing 60fps video frames from shared memory), allocating large arrays (e.g., 1.2MB for `byte[] rawBuffer`) inside the loop creates massive Large Object Heap (LOH) fragmentation and Garbage Collection pressure.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside the `while(true)` loop and reuse them to maintain high performance.

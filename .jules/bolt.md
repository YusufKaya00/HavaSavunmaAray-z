## 2024-05-24 - Pre-allocating buffers in high-frequency shared memory processing
**Learning:** Allocating large byte arrays (~1MB) inside a `while (true)` loop running at 60fps causes severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation in C#, drastically degrading WinForms application performance over time.
**Action:** Always pre-allocate large buffers and reuse `MemoryMappedViewAccessor` instances *outside* of high-frequency processing loops when reading from shared memory.

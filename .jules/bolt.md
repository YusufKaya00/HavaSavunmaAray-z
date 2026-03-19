
## 2024-05-28 - LOH Fragmentation in High-Frequency C# Loops
**Learning:** In C#, allocating large byte arrays (e.g., 640x640x3 = ~1.2MB for uncompressed video frames) inside high-frequency `while (true)` loops leads to continuous allocations on the Large Object Heap (LOH). The LOH is not compacted by default during garbage collection, leading to severe GC pressure, memory fragmentation, and eventual application stutter or crashes.
**Action:** Always pre-allocate large byte arrays (or use `ArrayPool<byte>`) outside of high-frequency execution loops and reuse them to completely avoid continuous LOH allocations.

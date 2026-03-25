## 2024-05-18 - LOH Fragmentation in High-Frequency C# Loops
**Learning:** Re-allocating 1.2MB byte arrays at 60fps (~144MB/s) in C# causes massive Large Object Heap (LOH) fragmentation and Gen 2 garbage collection pauses. Creating `MemoryMappedViewAccessor` in the loop is also an expensive OS call.
**Action:** Always hoist `MemoryMappedViewAccessor` creation and large array/buffer allocations OUTSIDE of the tight `while(true)` high-frequency loop, especially for things like video frames.

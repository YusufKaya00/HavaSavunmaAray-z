## 2024-05-24 - Prevent GC Pressure in High-Frequency C# Loops
**Learning:** Pre-allocating large byte arrays (1.2MB each) and reusing `MemoryMappedViewAccessor` instances outside the `while(true)` reading loop significantly reduces GC pressure and Large Object Heap (LOH) fragmentation.
**Action:** Always verify if large objects and memory accessors are instantiated repeatedly in high-frequency loops (~60fps) and refactor to reuse them.

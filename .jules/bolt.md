
## 2025-03-07 - Mitigating Extreme Memory Pressure in C# Shared Memory Streams
**Learning:** Instantiating large `byte[]` arrays and unmanaged mappings (`MemoryMappedFile.CreateViewAccessor()`) inside high-frequency `while(true)` loops causes dramatic memory pressure. At 60 FPS, this caused up to ~144 MB/s of unnecessary allocations to the Garbage Collector, drastically affecting performance.
**Action:** Extract memory array initializations and reusable unmanaged `CreateViewAccessor()` assignments out of continuous polling loops to reuse references, easing the pressure on the GC and avoiding OS-level map operations on each tick.

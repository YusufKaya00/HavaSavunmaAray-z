## 2024-04-08 - Shared Memory Read Loop Optimization
**Learning:** In C#, instantiating large arrays and MemoryMappedViewAccessors inside a high-frequency (e.g., while(true)) loop causes severe GC pressure and LOH (Large Object Heap) fragmentation.
**Action:** Pre-allocate large buffers and instantiate accessors outside the processing loop and reuse them to maintain low latency and stable memory usage.

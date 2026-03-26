## 2024-05-24 - Pre-allocating buffers for Shared Memory Mapped Files prevents LOH fragmentation
**Learning:** Re-allocating ~1.2MB byte arrays inside a `while (true)` high-frequency loop causes severe GC pressure since the objects are instantiated on the Large Object Heap (LOH). Memory mapped files don't automatically allocate, and manually allocating large buffers dynamically on every tick causes stuttering.
**Action:** Always pre-allocate and reuse large byte arrays and `MemoryMappedViewAccessor` instances outside of high-frequency reading loops when working with Shared Memory in C#.

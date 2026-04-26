## 2024-04-26 - Large Object Heap Fragmentation in High-Frequency C# Loops
**Learning:** Allocating arrays larger than 85,000 bytes (like uncompressed 1.2MB 640x640 24bpp images) inside a high-frequency `while (true)` loop forces allocations onto the Large Object Heap (LOH). Because LOH collections trigger blocking Gen 2 Garbage Collections, this causes severe UI stuttering and CPU spikes in real-time applications.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside of continuous processing loops when reading from shared memory.

## 2024-10-25 - LOH Fragmentation in High Frequency Loops
**Learning:** Pre-allocating buffers larger than 85KB inside a high-frequency (e.g., 60 FPS) loop in C# causes them to be allocated on the Large Object Heap (LOH). Continuous allocation on LOH leads to severe heap fragmentation and massive Garbage Collection pauses.
**Action:** Always hoist allocations of large objects (like 1.2MB byte arrays) and heavy object initializations (like MemoryMappedViewAccessor) completely outside of high-frequency execution loops.

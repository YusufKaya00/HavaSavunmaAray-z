
## 2025-03-30 - High-Frequency Large Array Allocation in C# Shared Memory Loops
**Learning:** The application processes uncompressed video frames (approx 1.2MB each) by creating new byte arrays and `MemoryMappedViewAccessor` objects for every iteration in a high-frequency (e.g., ~60fps) read loop. This continuously allocates large objects on the Large Object Heap (LOH), leading to fragmentation and severe Garbage Collection (GC) pressure which severely degrades performance over time.
**Action:** When working with high-frequency frame processing in C# (or similar architectures involving large buffers), always pre-allocate the large buffers (`byte[]`) and required view accessors (`MemoryMappedViewAccessor`) OUTSIDE the loop and reuse them during iterations.

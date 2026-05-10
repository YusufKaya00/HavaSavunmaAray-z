## 2025-05-10 - Avoiding Large Object Heap (LOH) Fragmentation in C# WinForms
**Learning:** High frequency loops parsing ~1.2MB video frames (640x640x3) from shared memory cause severe garbage collection pressure and LOH fragmentation when byte arrays (`byte[]`) or `MemoryMappedViewAccessor` instances are created inside the loop.
**Action:** Always pre-allocate large byte arrays and `MemoryMappedViewAccessor` instances outside of the `while (true)` processing loops.

## 2024-05-24 - High GC Pressure in Shared Memory Readers
**Learning:** In C# WinForms applications using MemoryMappedFiles for high-frequency data reads (like video frames at ~60fps), continuously calling `CreateViewAccessor()` and allocating large `byte[]` arrays (e.g., 1.2MB for 640x640x3 frames) inside the read loop causes severe Garbage Collector pressure and CPU overhead, leading to jitter and performance degradation.
**Action:** Always pre-allocate large byte arrays and reuse `MemoryMappedViewAccessor` instances outside the high-frequency read loops.

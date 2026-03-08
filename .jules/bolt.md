## 2024-05-18 - C# WinForms Video Processing Memory Leak
**Learning:** Found a massive ~160 MB/sec memory allocation bottleneck in a `while (true)` tight loop reading frames from `MemoryMappedFile`. Instantiating large byte arrays (`byte[640*640*3]`) repeatedly causes extreme Garbage Collection pressure, destroying UI thread performance in a WinForms app.
**Action:** Always inspect tight loops in real-time video processing functions (`ReadSharedMemory`). Move buffer allocations OUTSIDE of the loop and reuse the arrays with `ReadArray` and `Marshal.Copy`.

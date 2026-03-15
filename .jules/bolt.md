
## 2024-05-24 - Pre-allocating Buffers in High-Frequency C# Loops
**Learning:** In C# WinForms applications doing high-frequency video frame processing via memory-mapped files (e.g., polling every 15ms), allocating large arrays (like `byte[640*640*3]`) and re-creating unmanaged handle accessors (like `MemoryMappedFile.CreateViewAccessor()`) *inside* the `while (true)` loop generates enormous Garbage Collection (GC) pressure (approx. ~150MB/sec) and handle management overhead.
**Action:** Always hoist large array allocations and long-lived unmanaged resource handles (using `using` statements) outside of tight polling/processing loops to minimize per-frame allocations and significantly reduce GC pauses.

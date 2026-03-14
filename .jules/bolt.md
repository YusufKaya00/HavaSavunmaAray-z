
## 2025-01-09 - Avoid creating MMF Views and allocating large arrays in tight loops
**Learning:** Re-creating `MemoryMappedViewAccessor` and allocating large (`~1.2MB`) arrays inside a fast `while(true)` polling loop over shared memory causes enormous GC spikes and performance overhead.
**Action:** Always instantiate views (`CreateViewAccessor`) outside the polling loop and reuse single pre-allocated buffers across loop iterations when reading shared memory in C#.

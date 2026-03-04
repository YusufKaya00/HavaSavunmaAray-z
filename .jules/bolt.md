
## $(date +%Y-%m-%d) - Optimize MemoryMappedFile reading
**Learning:** Instantiating new memory mapped file accessors (`CreateViewAccessor`) and reallocating large buffers (`byte[]`) at high frequency (~60 FPS) via `MemoryMappedFile` inside an application's event loop causes high GC pressure and mapping/unmapping overhead that bogs down app performance heavily.
**Action:** Always hoist `MemoryMappedViewAccessor` instances and buffer allocation arrays outside the rendering/read loop and re-use the arrays to reduce GC allocations and expensive unmap operations.

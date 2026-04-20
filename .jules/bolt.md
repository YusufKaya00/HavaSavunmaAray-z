
## 2024-04-20 - Prevented GC Pressure and LOH Fragmentation in High-Frequency Loops
**Learning:** In C#, high-frequency processes that rapidly allocate large objects (like 1.2MB byte arrays mapped from shared memory) inside a tight `while (true)` loop create severe Garbage Collection (GC) pressure and Large Object Heap (LOH) fragmentation. This degrades the app's overall framerate and introduces significant micro-stuttering.
**Action:** When working with shared memory or reading raw/processed frames at high frequency (~60fps), always declare and pre-allocate large byte arrays and `.CreateViewAccessor()` streams *outside* the loop, and reuse them inside the loop.

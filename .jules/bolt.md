
## 2023-10-24 - High-Frequency LOH Allocations
**Learning:** Allocating large byte arrays (e.g., ~1.2MB for video frames) inside a 60 FPS while(true) loop creates massive Large Object Heap (LOH) fragmentation and triggers highly expensive Generation 2 Garbage Collections in .NET. Reusing these arrays eliminates over 140MB/sec of memory pressure without risking thread-safety (since data is fully overwritten per iteration).
**Action:** When working with image processing pipelines or shared memory readers, always hoist large array allocations out of tight execution loops to reuse them.

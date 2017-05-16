This is a test reimplementing MD5 using pure managed C# code, with uint, System.Numerics.Vectors.Vector<uint> and Mono.Simd.Vector4ui.

```
System.Numerics.Vector.IsHardwareAccelerated = false.
BenchmarkDotNet=v0.10.6, OS=Mac OS X 10.11
Processor=Intel Core2 Duo CPU P8700 2.53GHz, ProcessorCount=2
Frequency=10000000 Hz, Resolution=100.0000 ns, Timer=UNKNOWN
  [Host]     : Mono 5.0.0.100 (2017-02/9667aa6 Fri), 32bit
  DefaultJob : Mono 5.0.0.100 (2017-02/9667aa6 Fri), 32bit


        Method |      Mean |     Error |    StdDev | Relative |
-------------- |----------:|----------:|----------:|---------:|
           Md5 |  1.124 ms | 0.0399 ms | 0.1158 ms |  100.00% |
    Md5Managed |  1.978 ms | 0.0385 ms | 0.0360 ms |  175.97% |
 Md5Vectorized | 67.204 ms | 1.1802 ms | 1.0462 ms | 5979.00% |
       Md5Mono |  8.377 ms | 0.1606 ms | 0.1502 ms |  745.28% |
```


```
System.Numerics.Vector.IsHardwareAccelerated = true.
BenchmarkDotNet=v0.10.6, OS=Windows 10.0.16193
Processor=AMD Phenom(tm) 9650 Quad-Core Processor, ProcessorCount=4
Frequency=2246249 Hz, Resolution=445.1866 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2505.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2505.0


        Method |       Mean |     Error |    StdDev | Relative |
-------------- |-----------:|----------:|----------:|---------:|
           Md5 |   212.0 us | 0.9392 us | 0.8785 us |  100.00% |
    Md5Managed |   734.2 us | 1.9787 us | 1.6523 us |  346.32% |
 Md5Vectorized | 2,817.4 us | 3.9387 us | 3.2890 us | 1328.96% |
```


```
System.Numerics.Vector.IsHardwareAccelerated = false.
BenchmarkDotNet=v0.10.6, OS=Linux 4.10.13-1-ARCH
Processor=Intel Xeon CPU E5-2690 v3 2.60GHz, ProcessorCount=24
Frequency=10000000 Hz, Resolution=100.0000 ns, Timer=UNKNOWN
  [Host]     : Mono 5.0.0 (Stable 5.0.0.100/9667aa6), 64bit
  DefaultJob : Mono 5.0.0 (Stable 5.0.0.100/9667aa6), 64bit


        Method |        Mean |      Error |     StdDev | Relative |
-------------- |------------:|-----------:|-----------:|---------:|
           Md5 |    272.5 us |   1.733 us |   1.253 us |  100.00% |
    Md5Managed |    750.7 us |   8.095 us |   7.572 us |  275.49% |
 Md5Vectorized | 20,467.7 us | 181.869 us | 161.222 us | 7511.08% |
       Md5Mono |  2,628.7 us |  30.470 us |  27.011 us |  964.66% |
```
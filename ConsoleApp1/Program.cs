using BenchmarkDotNet.Running;
using ConsoleApp1.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        // For testing Parse
        BenchmarkRunner.Run<ParsableServiceBenchmark>();

        // For testing UnsafeAccessor
        BenchmarkRunner.Run<UnsafeAccessorServiceBenchmark>();
    }
}

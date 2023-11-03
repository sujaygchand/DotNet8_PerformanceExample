using BenchmarkDotNet.Attributes;
using ConsoleApp1.Services;
using System.Reflection;

namespace ConsoleApp1.Benchmarks
{
    [MemoryDiagnoser]
    public class UnsafeAccessorServiceBenchmark
	{
        private UnsafeAccessorService service = new UnsafeAccessorService();

        private static readonly MethodInfo CachedMethod = typeof(UnsafeAccessorService).GetMethod("GetName", BindingFlags.Instance | BindingFlags.NonPublic)!;

        [Benchmark]
        public string GetNamePublic()
        {
            return service.GetNamePublic();
        }

        [Benchmark]
        public string GetNamePrivate()
        {
            return UnsafeAccessorServiceCaller.GetName(service);
        }

        [Benchmark]
        public string GetNameReflection()
        {
            return ReflectionService.GetName(service);
        }

        [Benchmark]
        public string GetNameCachedReflection()
        {
            return (string)CachedMethod.Invoke(service, Array.Empty<object>());
        }
    }
}

using BenchmarkDotNet.Attributes;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Benchmarks
{
    [MemoryDiagnoser]
    public class ParsableServiceBenchmark
    {

        private ParsableService service = new ParsableService();

        [Benchmark]
        public User ParseUser()
        {
            return service.GetUser();
        }

        [Benchmark]
        public User TryParseUser()
        {
            return service.TryGetUser();
        }

        [Benchmark]
        public User ParseUserAsSpan()
        {
            return service.GetUserAsSpan();
        }

        [Benchmark]
        public User TryParseUserAsSpan()
        {
            return service.TryGetUserAsSpan();
        }
    }
}

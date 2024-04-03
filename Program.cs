using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ToAsyncOrNot
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }

    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class MyBenchmark
    {
        [Benchmark]
        public Task using_async_await()
        {
            return TaskWithAsync.Run();
        }

        [Benchmark]
        public Task skip_async_await()
        {
            return TaskWithoutAsync.Run();
        }
    }
}

public static class TaskWithAsync
{
    public static async Task Run()
    {
        await Task.Delay(0);
    }
}

public static class TaskWithoutAsync
{
    public static Task Run()
    {
        return Task.Delay(0);
    }
}
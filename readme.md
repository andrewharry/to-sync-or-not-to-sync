## Comparing `async await` to `return task`

| Method            | Job      | Runtime  | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
|------------------ |--------- |--------- |----------:|----------:|----------:|----------:|------:|--------:|
| using_async_await | .NET 6.0 | .NET 6.0 | 6.4713 ns | 0.0818 ns | 0.0725 ns | 6.4640 ns |  1.00 |    0.00 |
| using_async_await | .NET 8.0 | .NET 8.0 | 4.8750 ns | 0.0854 ns | 0.0713 ns | 4.8955 ns |  0.75 |    0.01 |
| skip_async_await  | .NET 6.0 | .NET 6.0 | 0.0036 ns | 0.0046 ns | 0.0043 ns | 0.0021 ns |  0.00 |    0.00 |
| skip_async_await  | .NET 8.0 | .NET 8.0 | 0.1016 ns | 0.0065 ns | 0.0054 ns | 0.1009 ns |  0.00 |    0.00 |

```csharp
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
```
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace AsyncEnumerableEnumeration;

[LongRunJob]
public class Benchmarks
{
    const int ItemCount = 1_000_000;

    private readonly IAsyncEnumerable<int> _asyncEnumerable =
        System.Linq.AsyncEnumerable.Range(1, ItemCount);

    private readonly IEnumerable<int> _enumerable = System.Linq.Enumerable.Range(1, ItemCount);


    [Benchmark]
    public async Task AsyncEnumerable()
    {
        await foreach (var _ in _asyncEnumerable)
        {
        }
    }

    [Benchmark]
    public void Enumerable()
    {
        foreach (var _ in _enumerable)
        {
        }
    }
}
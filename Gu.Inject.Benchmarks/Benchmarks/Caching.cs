// ReSharper disable All
namespace Gu.Inject.Benchmarks
{
    using System;
    using System.Collections.Concurrent;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Caching
    {
        private static readonly ConcurrentQueue<Node> Cache = new ConcurrentQueue<Node>();

        static Caching()
        {
            Cache.Enqueue(new Node(typeof(Caching)));
            Cache.Enqueue(new Node(typeof(Caching)));
            Cache.Enqueue(new Node(typeof(Caching)));
        }

        [Benchmark(Baseline = true)]
        public object New()
        {
            return new Node(typeof(Caching));
        }

        [Benchmark]
        public object TryDequeueEnqueue()
        {
            if (Cache.TryDequeue(out var result))
            {
                Cache.Enqueue(result);
                return result;
            }

            throw new InvalidOperationException();
        }

        private sealed class Node
        {
            private readonly Type type;
            private readonly Node? previous;

            internal Node(Type type)
                : this(type, null)
            {
            }

            private Node(Type type, Node? previous)
            {
                this.type = type;
                this.previous = previous;
            }
        }
    }
}
